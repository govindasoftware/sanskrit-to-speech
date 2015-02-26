//
// Filename: sanskrit_to_speech.exe
//
// Author: David Lugan
//
// Date Created: 2012-02-08T14:00-06:00
//
// Description: This application converts a VedaBase exported file (RTF) to
// a text file (ANSI) which is spelled so a Text-to-Speech system
// properly pronounces the Sanskrit.
//
// Instructions: Drag and drop an RTF file to this program window.
//
// Output:
//   <input_filename_part>_speech_kindle.txt
//
// Date, Version, Modifications:
//
// 2012-02-08T14:00-06:00, 0.0.0.000, File created.
//
// 2012-02-08T17:50-06:00, 0.0.0.001, Removes devanagari and synonyms successfully.
//
// 2012-02-08T21:00-06:00, 0.0.0.002, Successfully converted from Balarama to Unicode UTF-8.
//
// 2012-02-09T15:52-06:00, 0.0.0.003, Successfully inserted <i> and </i> where italics were present.
//
// 2012-02-09T19:43-06:00, 0.0.0.004, Successfully inserted Kindle Text-to-Speech pronunciation for italicized words.
//
// 2012-02-09T22:03-06:00, 0.0.0.008, Successfully inserted Kindle Text-to-Speech pronunciation for words with diacritics present.
//
// 2012-02-10T21:15-06:00, 0.0.0.009, Successfully inserted Text-to-Speech for Sanskrit words which do not include italics or diacritics. Removed "Bg 1.1" and added period after "PURPORT" for a pause.
//
// 2012-02-13T03:05-06:00, 0.0.0.039, Getting close to a release. Internal Text-to-Speech engine corrected. Added progress bar.
//
// 2012-02-13T03:08-06:00, 0.0.0.040, Added settings.ini to store  last speech selection. Added automatic naming of output file.
//
// 2012-02-14T01:15-06:00, 0.0.0.045, Added support for 50 Sanskrit letters.
//
// 2012-02-14T05:39-06:00, 0.0.0.049, Added drag and drop RTF file support.
//
// 2012-02-14T05:39-06:00, 0.0.0.050, Added ability for user to click any part of the form to move it around in Windows. Allow only .RTF files to be opened.
//
// 2012-02-15T00:53-06:00, 0.0.0.053, Rest progressbar to 0 on each button click.
//
// 2012-02-15T04:07-06:00, 0.0.0.055, Added panel for advanced options. Added "Custom Replacements" button and file loader.
//
// 2012-02-15T05:17-06:00, 0.0.0.056, Added support for custom text replacements.
//
// 2012-02-15T05:42-06:00, 0.0.0.057, Added .ToLower() to replacement comparison for case insensitivity. Added create_default_substitutions_ini()
//
// 2012-02-15T14:22-06:00, 0.0.0.058, Added unique delimiter (\x1A) which appears as a right arrow in Notepad. Added spaces before and after Sanskrit word for creating special replacement rules for the start and end of a word.
//
// 2012-02-16T05:39-06:00, 0.0.0.061, Reduced font size to 11 points. Merged custom replacements and Sanskrit alphabet files. Enabled drag and drop instant conversion.
//
// 2012-02-16T05:49-06:00, 0.0.0.062, Fixed Substitutions file loading issue.
//
// 2012-02-17T00:41-06:00, 0.0.0.062, Added drag and drop to program window multiple files feature. Added drag and drop to program executable multiple files feature.
//
// 2012-02-18T22:45-06:00, 0.0.0.065, Added seperate thread for processing files. Escape key quits the program at any time.
//
// 2012-02-18T23:17-06:00, 0.0.0.066, Added sanskrit_without_diacritics.ini title in combobox when opened in the textbox.
//
// 2012-02-18T23:19-06:00, 0.0.0.067, Added support for reading text files.
//
// 2012-02-18T23:42-06:00, 0.0.0.068, Added ability to select TEXT, SYNONYMS, TRANSLATION and PURPORT
//
// 2012-02-20T00:27-06:00, 0.0.0.070, Simplified internal engine for selecting "substitutions_none.ini" 
//
// 2012-02-20T00:28-06:00, 0.0.0.071, Implementing ability to select Text, Synonyms, Translations or Puport
//
// 2012-02-21T21:50-06:00, 0.0.0.075, Renamed Customize to Advanced. Successfully implemented Devanagari and Text removal.
//
// 2012-02-22T00:30-06:00, 0.0.0.076, Successfully implemented Devanagari, Text, Synonyms, Translation and Purport removal.
//
// 2012-02-22T00:32-06:00, 0.0.0.077, Added save to settings file Text, Synonyms, Translation and Purport.
//
// 2012-02-22T01:50-06:00, 0.0.0.078, Added label for "List of Sanskrit Words Without Diacritics"
//
// 2012-02-22T03:32-06:00, 0.0.0.079, Added regular expressions replacing in settings.ini.
//
// 2012-02-22T03:32-06:00, 0.0.0.080, Added substitution with blank option (i.e. "a->").
//
// 2012-02-22T05:27-06:00, 0.0.0.081, Updated tab order. Increased font of Convert button. Tested regular expressions replacing in settings.ini.
//
// 2012-02-23T04:12-06:00, 0.0.0.083, Added exception handling to every function.
//
// 2012-02-24T02:30-06:00, 0.0.0.085, Adding "PURPORT," whenever a PURPORT is present and "," whenever TRANSLATION is present. Updated Kindle defaults.
//
// 2012-02-26T02:25-06:00, 0.0.0.086, Enable users to edit settings file.
//
// 2012-02-26T23:13-06:00, 0.0.0.088, Enabled backreferencing.
//
// 2012-02-26T23:13-06:00, 0.0.0.089, Fixed too much italics.
//
// 2012-02-28T21:47-06:00, 0.0.0.090, Fixed </i> being deleted in regular expressions.
//
// 2012-03-02T20:20-06:00, 0.0.0.092, Merged two conversion threads and timer into a single thread. Fixed <ih> found in output. Fixed settings button should be enabled in substitutions_none.ini mode.
//
// 2012-03-03T18:35-06:00, 0.0.0.093, Placed progress bar back on the front page. When a conversion starts then the front page is shown.
//
// 2012-03-03T19:46-06:00, 0.0.0.094, Fixed </i> showing up in output.
//
// 2012-03-12T19:35-06:00, 0.0.0.095, Updated Kindle defaults. Fixed PURPORT: <these words were deleted on previous version>
//
// 2012-03-13T17:35-06:00, 0.0.0.096, Updated Kindle defaults.
//
// 2012-03-13T17:35-06:00, 0.0.0.097, Fixed " y" from adding a space at the beginning of a word. Fixed <i> and </i> from showing up in output. Added the same list of words ending with s for matching plural base words.
//
// 2012-03-16T02:50-06:00, 0.0.0.098, Enabled regular expressions for substitutions.
//
// 2012-03-18T22:26-06:00, 0.0.0.101, Fixed <ee> showing up in output.
//
// 2012-03-18T22:27-06:00, 0.0.0.102, Added "!" prefix to output filenames. Creating list of Sanskrit words without diacritics which are italicized in RTFs.
//
// 2012-03-19T02:23-06:00, 0.0.0.104, Rewrote system of marking sanskrit words using a flag system.
//
// 2012-03-20T05:23-06:00, 0.0.0.105, Rewrote conversion engine to use Regex. Fixed settings.ini removing section headers.
//
// 2012-03-20T09:11-06:00, 0.0.0.106, Added support for named groups in substitutions and settings.ini
//
// 2012-03-23T22:50-06:00, 0.0.0.108, Fixed bug where a leading non-sanskrit words were not included in the output text file. Fixed words ending with "s" processing.
//
// 2012-03-26T18:59-06:00, 0.0.0.112, Making substitions be ordered by how it is read in the file.
//
// 2012-03-30T00:44-06:00, 0.0.0.113, Removed "Sat" from Sanskrit word list because it is an English word. Updated Kindle default substitutions.
//
// 2012-03-30T20:31-06:00, 0.0.0.114, Added Hare as a Sanskrit word. Added yogi substitution.
//
// 2012-03-30T23:56-06:00, 0.0.0.116, Fixing no substitions.
//
// 2012-04-01T23:44-05:00, 0.0.0.117, Updated Kindle substitutions. Prefixed filename with "!kindle_Bhagavad-gita.txt"
//
// 2012-04-14T20:41-05:00, 0.0.0.119, Fixed devanagari removal for multiple verse translations. Updated settings.ini processing, so empty entries are acceptable.
//
// 2012-04-15T22:05-05:00, 0.0.0.121, Fixed devanagari removal for Brhad-Bhagavatamrta exception.
//
// 2012-04-16T04:19-05:00, 0.0.0.122, Fixed devanagari removal by rewriting removal engine. Fixed settings.ini so it saves changes properly.
//
// 2012-04-21T21:14-05:00, 0.0.0.125, Created general function for removing RTF sections.
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace sanskrit_to_speech
{
    public partial class Form_main : Form
    {
        string[] string_devanagari_tags_array = {
"Devanagar",
"Dev;",
"dev;",
"dev-rm;"};
        static Char char_substitution = '\x001A'; // Decimal: 26, Hexadecimal: 1A, Char: Substitution (looks like a right arrow)
        static RegexOptions regexOptions_default = RegexOptions.IgnoreCase | RegexOptions.Multiline;
        Regex regex_find_no_dash_or_apostrophe_punctuation_after_word = new Regex(@"(\s|[\p{P}-['\p{Pd}]]|$)", regexOptions_default | RegexOptions.Compiled);
        Regex regex_find_no_dash_or_apostrophe_punctuation_before_word = new Regex(@"(^|\s|[\p{P}-['\p{Pd}]])", regexOptions_default | RegexOptions.RightToLeft | RegexOptions.Compiled);        
        Regex regex_replace_non_substitution_character_with_space = new Regex("[^" + char_substitution + "]", regexOptions_default | RegexOptions.Compiled);
        Regex regex_replace_word_from_plural_to_singular = new Regex(@"(\w+)(s|'s)$", regexOptions_default | RegexOptions.Compiled);
        Regex regex_find_diacritic_word = new Regex(@"(?<diacritic_word>\w*(Ṣ|ṣ|Ñ|ñ|Ā|ā|Ī|ī|Ś|ś|Ū|ū|Ḍ|ḍ|Ḥ|ḥ|Ḷ|ḷ|Ṁ|ṁ|Ṅ|ṅ|Ṇ|ṇ|Ṛ|ṛ|Ṝ|ṝ|Ṭ|ṭ|l̐)\w*)", regexOptions_default | RegexOptions.Compiled);
        Regex regex_find_one_or_more_substitution_characters = new Regex(char_substitution + "+", regexOptions_default | RegexOptions.Compiled);
        Regex regex_find_italics_start_tag = new Regex(@"\<i\>", RegexOptions.Compiled);
        Regex regex_find_italics_end_tag = new Regex(@"\<\/i\>", RegexOptions.Compiled);
        Regex regex_find_end_of_chapter_sentence = new Regex(@"(\r\nEND OF THE|\r\nThus end the|\r\nThus ends the|Bhagavad-gītā As It Is in the form in which it is presented now)", RegexOptions.Multiline | RegexOptions.Compiled);
        
        String string_output_speech;
        String string_input_sanskrit;
        String string_input_sanskrit_flags;
        static String string_output_filename_prefix = "!";        
        static String string_delimiter = "->";
        List<class_substitution> list_substitutions_sanskrit_without_diacritics = new List<class_substitution>();
        List<class_substitution> list_substitutions_regex_from_settings = new List<class_substitution>();
        static String[] string_regular_expressions_array_default = {
@"(\r\n,)+" + string_delimiter + @"\r\n,",
@"^.*\s(\d*\.\d*)\r\n" + string_delimiter + @"\r\n$1\r\n",
@"^.*\s(\d*\.\d*\.\d*)\r\n" + string_delimiter + @"\r\n$1\r\n",
@"^.*\s(\d*\.\d*)-(\d*)\r\n" + string_delimiter + @"\r\n$1 through $2\r\n",
@"^.*\s(\d*\.\d*\.\d*)-(\d*)\r\n" + string_delimiter + @"\r\n$1 through $2\r\n",
@"^Audio\r\n" + string_delimiter + @"\r\n",
@"\r\n\r\n\r\n" + string_delimiter + @"\r\n\r\n"};

        static String string_settings_sanskrit_checked_prefix_default = "Sanskrit Checked:";
        static String string_settings_synonyms_checked_prefix_default = "Synonyms Checked:";
        static String string_settings_translation_checked_prefix_default = "Translation Checked:";
        static String string_settings_purport_checked_prefix_default = "Purport Checked:";

        static String string_settings_sanskrit_checked_default = string_settings_sanskrit_checked_prefix_default + "False";
        static String string_settings_synonyms_checked_default = string_settings_synonyms_checked_prefix_default + "False";
        static String string_settings_translation_checked_default = string_settings_translation_checked_prefix_default + "True";
        static String string_settings_purport_checked_default = string_settings_purport_checked_prefix_default + "True";

        static String string_settings_sanskrit_checked_substitution_prefix_default = "Sanskrit Checked Substitution:";
        static String string_settings_synonyms_checked_substitution_prefix_default = "Synonyms Checked Substitution:";
        static String string_settings_translation_checked_substitution_prefix_default = "Translation Checked Substitution:";
        static String string_settings_purport_checked_substitution_prefix_default = "Purport Checked Substitution:";

        static String string_settings_sanskrit_checked_substitution_default = string_settings_sanskrit_checked_substitution_prefix_default + @"(TEXT|TEXT.*|SŪTRA|SŪTRA.*)\r\n" + string_delimiter + @",\r\n";
        static String string_settings_synonyms_checked_substitution_default = string_settings_synonyms_checked_substitution_prefix_default + @"SYNONYMS\r\n" + string_delimiter + @",\r\n";
        static String string_settings_translation_checked_substitution_default = string_settings_translation_checked_substitution_prefix_default + @"TRANSLATION\r\n" + string_delimiter + @",\r\n";
        static String string_settings_purport_checked_substitution_default = string_settings_purport_checked_substitution_prefix_default + @"(PURPORT|COMMENTARY)\r\n" + string_delimiter + @"\r\n,$1,\r\n";

        static String string_settings_sanskrit_unchecked_substitution_prefix_default = "Sanskrit Unchecked Substitution:";
        static String string_settings_synonyms_unchecked_substitution_prefix_default = "Synonyms Unchecked Substitution:";
        static String string_settings_translation_unchecked_substitution_prefix_default = "Translation Unchecked Substitution:";
        static String string_settings_purport_unchecked_substitution_prefix_default = "Purport Unchecked Substitution:";

        static String string_settings_sanskrit_unchecked_substitution_default = string_settings_sanskrit_unchecked_substitution_prefix_default + @"(TEXT|TEXT.*|SŪTRA|SŪTRA.*)\r\n" + string_delimiter + @",\r\n";
        static String string_settings_synonyms_unchecked_substitution_default = string_settings_synonyms_unchecked_substitution_prefix_default + @"SYNONYMS\r\n" + string_delimiter + @",\r\n";
        static String string_settings_translation_unchecked_substitution_default = string_settings_translation_unchecked_substitution_prefix_default + @"TRANSLATION\r\n" + string_delimiter + @",\r\n";
        static String string_settings_purport_unchecked_substitution_default = string_settings_purport_unchecked_substitution_prefix_default + @"(PURPORT|COMMENTARY)\r\n" + string_delimiter + @",\r\n";

        String string_input_file_path = "";
        String string_output_file_path = "";
        String string_sanskrit_rtf = "";
        bool bool_sanskrit_checked = false;
        bool bool_synonyms_checked = false;
        bool bool_translation_checked = false;
        bool bool_purport_checked = false;
        bool bool_stop_conversion = false;
        List<String> list_string_input_files_to_process = new List<String>();

        class class_substitution
        {
            public String string_input;
            public String string_replacement;
            public String string_prefix;
            public Regex regex_compiled;
            public RegexOptions regexOptions_compiled;
            public bool bool_compile_regex;

            class_substitution()
            {
                string_input = "";
                string_replacement = "";
                string_prefix = "";
                regex_compiled = null;
                regexOptions_compiled = RegexOptions.Compiled | RegexOptions.Multiline;
                bool_compile_regex = true;
            }

            public class_substitution(
                String string_original_input, 
                String string_substitution_input, 
                String string_prefix_input = "", 
                RegexOptions regexOptions_input = RegexOptions.Compiled | RegexOptions.Multiline,
                bool bool_compile_regex_input = true)
            {
                string_input = string_original_input;
                string_replacement = string_substitution_input;
                string_prefix = string_prefix_input;
                regexOptions_compiled = regexOptions_input;
                bool_compile_regex = bool_compile_regex_input;

                if (
                    (String.IsNullOrEmpty(string_input) == true) ||
                    (bool_compile_regex == false))
                {
                    regex_compiled = null;
                }
                else
                {
                    regex_compiled = new Regex(string_input, regexOptions_compiled);
                }
            }
        };

        static IEnumerable<class_substitution> substitutions_sort_by_original_string_length_descending(IEnumerable<class_substitution> list_substitution_input)
        {
            // Use LINQ to sort the array received and return a copy.
            var var_sorted_descending = from substitution in list_substitution_input
                                        orderby substitution.string_input.Length descending
                                        select substitution;

            return var_sorted_descending;
        }

        //const and dll functions for moving form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        System.Windows.Forms.ToolTip toolTip_gutturals;
        System.Windows.Forms.ToolTip toolTip_palatals;
        System.Windows.Forms.ToolTip toolTip_cerebrals;
        System.Windows.Forms.ToolTip toolTip_dentals;
        System.Windows.Forms.ToolTip toolTip_labials;
        System.Windows.Forms.ToolTip toolTip_semivowels;
        System.Windows.Forms.ToolTip toolTip_sibilants;
        System.Windows.Forms.ToolTip toolTip_aspirate;
        System.Windows.Forms.ToolTip toolTip_00;
        System.Windows.Forms.ToolTip toolTip_01;
        System.Windows.Forms.ToolTip toolTip_02;
        System.Windows.Forms.ToolTip toolTip_03;
        System.Windows.Forms.ToolTip toolTip_04;
        System.Windows.Forms.ToolTip toolTip_05;
        System.Windows.Forms.ToolTip toolTip_06;
        System.Windows.Forms.ToolTip toolTip_07;
        System.Windows.Forms.ToolTip toolTip_08;
        System.Windows.Forms.ToolTip toolTip_09;
        System.Windows.Forms.ToolTip toolTip_10;
        System.Windows.Forms.ToolTip toolTip_11;
        System.Windows.Forms.ToolTip toolTip_12;
        System.Windows.Forms.ToolTip toolTip_13;
        System.Windows.Forms.ToolTip toolTip_14;
        System.Windows.Forms.ToolTip toolTip_15;
        System.Windows.Forms.ToolTip toolTip_16;
        System.Windows.Forms.ToolTip toolTip_17;
        System.Windows.Forms.ToolTip toolTip_18;
        System.Windows.Forms.ToolTip toolTip_19;
        System.Windows.Forms.ToolTip toolTip_20;
        System.Windows.Forms.ToolTip toolTip_21;
        System.Windows.Forms.ToolTip toolTip_22;
        System.Windows.Forms.ToolTip toolTip_23;
        System.Windows.Forms.ToolTip toolTip_24;
        System.Windows.Forms.ToolTip toolTip_25;
        System.Windows.Forms.ToolTip toolTip_26;
        System.Windows.Forms.ToolTip toolTip_27;
        System.Windows.Forms.ToolTip toolTip_28;
        System.Windows.Forms.ToolTip toolTip_29;
        System.Windows.Forms.ToolTip toolTip_30;
        System.Windows.Forms.ToolTip toolTip_31;
        System.Windows.Forms.ToolTip toolTip_32;
        System.Windows.Forms.ToolTip toolTip_33;
        System.Windows.Forms.ToolTip toolTip_34;
        System.Windows.Forms.ToolTip toolTip_35;
        System.Windows.Forms.ToolTip toolTip_36;
        System.Windows.Forms.ToolTip toolTip_37;
        System.Windows.Forms.ToolTip toolTip_38;
        System.Windows.Forms.ToolTip toolTip_39;
        System.Windows.Forms.ToolTip toolTip_40;
        System.Windows.Forms.ToolTip toolTip_41;
        System.Windows.Forms.ToolTip toolTip_42;
        System.Windows.Forms.ToolTip toolTip_43;
        System.Windows.Forms.ToolTip toolTip_44;
        System.Windows.Forms.ToolTip toolTip_45;
        System.Windows.Forms.ToolTip toolTip_46;
        System.Windows.Forms.ToolTip toolTip_47;
        System.Windows.Forms.ToolTip toolTip_48;
        System.Windows.Forms.ToolTip toolTip_49;
        List<class_substitution> list_substitution = new List<class_substitution>();
        static int int_dialog_height_max = 768;
        static int int_dialog_height_min = 300;
        static String string_settings_ini_file_path = AppDomain.CurrentDomain.BaseDirectory + "settings.ini";
        static String string_substitutions_filename_prefix = "substitutions_";
        static String string_substitutions_apple_ini_file_path = AppDomain.CurrentDomain.BaseDirectory + string_substitutions_filename_prefix + "apple.ini";
        static String string_substitutions_kindle_ini_file_path = AppDomain.CurrentDomain.BaseDirectory + string_substitutions_filename_prefix + "kindle.ini";
        static String string_substitutions_microsoft_ini_file_path = AppDomain.CurrentDomain.BaseDirectory + string_substitutions_filename_prefix + "microsoft.ini";
        static String string_substitutions_none_ini_file_path = AppDomain.CurrentDomain.BaseDirectory + string_substitutions_filename_prefix + "none.ini";
        static String string_italicized_unicode_txt_file_path = AppDomain.CurrentDomain.BaseDirectory + "italicized_unicode.txt";
        static String string_sanskrit_without_diacritics_ini_file_path = AppDomain.CurrentDomain.BaseDirectory + "sanskrit_without_diacritics.ini";
        static String string_substitutions_default_ini_filename = Path.GetFileName(string_substitutions_kindle_ini_file_path);
        static String string_rtf_italics_start_tag = "\\i";
        static Char[] char_rtf_tag_terminators_array = {
' ',
'\\',
'\r',
'\n'};

        //
        // Note that there is a space after the \b tag: you have to end the tag with a space, a line ending, or another tag.
        //
        static string[] string_rtf_italics_end_tag_array = {
"}",
"\\i0",
"\\pard"};

        String string_currently_selected_combobox_filename = "";

        static char[] char_white_space_array = {
' ',
'\r',
'\n'};

static char[] char_punctuation_non_dash_array = {
'\r',
'\n',
' ',
'`',
'~',
'!',
'@',
'#',
'$',
'%',
'^',
'&',
'*',
'(',
')',
'_',
'+',
'=',
'[',
'{',
']',
'}',
'\\',
'|',
';',
':',
'\'',
'\"',
',',
'<',
'.',
'>',
'/',
'?'};

static char[] char_punctuation_array = {
'\r',
'\n',
' ',
'`',
'~',
'!',
'@',
'#',
'$',
'%',
'^',
'&',
'*',
'(',
')',
'-',
'_',
'+',
'=',
'[',
'{',
']',
'}',
'\\',
'|',
';',
':',
'\'',
'\"',
',',
'<',
'.',
'>',
'/',
'?'};


static char[] char_sanskrit_single_consonant_letters_array = {
'ṛ',
'ṝ',
'ḷ',
'ṁ',
'ḥ',
'k',
'g',
'ṅ',
'c',
'j',
'ñ',
'ṭ',
'ḍ',
'ṇ',
't',
'd',
'n',
'p',
'b',
'm',
'y',
'r',
'l',
'v',
'ś',
'ṣ',
's',
'h'};

static String[] string_sanskrit_single_consonant_letter_replacements_array = {
"ri",
"ri",
"l",
"ng",
"h",
"k",
"g",
"n",
"ch",
"j",
"n",
"t",
"d",
"n",
"t",
"d",
"n",
"p",
"b",
"m",
"y",
"r",
"l",
"v",
"sh",
"sh",
"s",
"h"};

        static String[] string_50_sanskrit_letters_array = {
"a",
"ā",
"i",
"ī",
"u",
"ū",
"ṛ",
"ṝ",
"ḷ",
"l̐",
"e",
"ai",
"o",
"au",
"ṁ",
"ḥ",
"k",
"kh",
"g",
"gh",
"ṅ",
"c",
"ch",
"j",
"jh",
"ñ",
"ṭ",
"ṭh",
"ḍ",
"ḍh",
"ṇ",
"t",
"th",
"d",
"dh",
"n",
"p",
"ph",
"b", 
"bh",
"m",
"y",
"r",
"l",
"v",
"ś",
"ṣ",
"s",
"h",
"'"};

        ////////////////////////////////////////////////////////////////////////////////

        void substitutions_clear_sanskrit_alphabet_textboxes()
        {
            try
            {
                textBox_00.Text = "";
                textBox_01.Text = "";
                textBox_02.Text = "";
                textBox_03.Text = "";
                textBox_04.Text = "";
                textBox_05.Text = "";
                textBox_06.Text = "";
                textBox_07.Text = "";
                textBox_08.Text = "";
                textBox_09.Text = "";
                textBox_10.Text = "";
                textBox_11.Text = "";
                textBox_12.Text = "";
                textBox_13.Text = "";
                textBox_14.Text = "";
                textBox_15.Text = "";
                textBox_16.Text = "";
                textBox_17.Text = "";
                textBox_18.Text = "";
                textBox_19.Text = "";
                textBox_20.Text = "";
                textBox_21.Text = "";
                textBox_22.Text = "";
                textBox_23.Text = "";
                textBox_24.Text = "";
                textBox_25.Text = "";
                textBox_26.Text = "";
                textBox_27.Text = "";
                textBox_28.Text = "";
                textBox_29.Text = "";
                textBox_30.Text = "";
                textBox_31.Text = "";
                textBox_32.Text = "";
                textBox_33.Text = "";
                textBox_34.Text = "";
                textBox_35.Text = "";
                textBox_36.Text = "";
                textBox_37.Text = "";
                textBox_38.Text = "";
                textBox_39.Text = "";
                textBox_40.Text = "";
                textBox_41.Text = "";
                textBox_42.Text = "";
                textBox_43.Text = "";
                textBox_44.Text = "";
                textBox_45.Text = "";
                textBox_46.Text = "";
                textBox_47.Text = "";
                textBox_48.Text = "";
                textBox_49.Text = "";
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        void substitutions_fill_sanskrit_alphabet_textboxes_from_filename(String string_filename_input)
        {
            try
            {
                List<class_substitution> list_substitutions_from_file_unsorted = substitutions_get_from_file_unsorted(AppDomain.CurrentDomain.BaseDirectory + string_filename_input);
                class_substitution substitution_found = null;

                if (list_substitutions_from_file_unsorted.Count > 0)
                {
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_00.Text); if (substitution_found == null) { textBox_00.Text = ""; } else { textBox_00.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_01.Text); if (substitution_found == null) { textBox_01.Text = ""; } else { textBox_01.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_02.Text); if (substitution_found == null) { textBox_02.Text = ""; } else { textBox_02.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_03.Text); if (substitution_found == null) { textBox_03.Text = ""; } else { textBox_03.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_04.Text); if (substitution_found == null) { textBox_04.Text = ""; } else { textBox_04.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_05.Text); if (substitution_found == null) { textBox_05.Text = ""; } else { textBox_05.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_06.Text); if (substitution_found == null) { textBox_06.Text = ""; } else { textBox_06.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_07.Text); if (substitution_found == null) { textBox_07.Text = ""; } else { textBox_07.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_08.Text); if (substitution_found == null) { textBox_08.Text = ""; } else { textBox_08.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_09.Text); if (substitution_found == null) { textBox_09.Text = ""; } else { textBox_09.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_10.Text); if (substitution_found == null) { textBox_10.Text = ""; } else { textBox_10.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_11.Text); if (substitution_found == null) { textBox_11.Text = ""; } else { textBox_11.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_12.Text); if (substitution_found == null) { textBox_12.Text = ""; } else { textBox_12.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_13.Text); if (substitution_found == null) { textBox_13.Text = ""; } else { textBox_13.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_14.Text); if (substitution_found == null) { textBox_14.Text = ""; } else { textBox_14.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_15.Text); if (substitution_found == null) { textBox_15.Text = ""; } else { textBox_15.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_16.Text); if (substitution_found == null) { textBox_16.Text = ""; } else { textBox_16.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_17.Text); if (substitution_found == null) { textBox_17.Text = ""; } else { textBox_17.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_18.Text); if (substitution_found == null) { textBox_18.Text = ""; } else { textBox_18.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_19.Text); if (substitution_found == null) { textBox_19.Text = ""; } else { textBox_19.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_20.Text); if (substitution_found == null) { textBox_20.Text = ""; } else { textBox_20.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_21.Text); if (substitution_found == null) { textBox_21.Text = ""; } else { textBox_21.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_22.Text); if (substitution_found == null) { textBox_22.Text = ""; } else { textBox_22.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_23.Text); if (substitution_found == null) { textBox_23.Text = ""; } else { textBox_23.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_24.Text); if (substitution_found == null) { textBox_24.Text = ""; } else { textBox_24.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_25.Text); if (substitution_found == null) { textBox_25.Text = ""; } else { textBox_25.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_26.Text); if (substitution_found == null) { textBox_26.Text = ""; } else { textBox_26.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_27.Text); if (substitution_found == null) { textBox_27.Text = ""; } else { textBox_27.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_28.Text); if (substitution_found == null) { textBox_28.Text = ""; } else { textBox_28.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_29.Text); if (substitution_found == null) { textBox_29.Text = ""; } else { textBox_29.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_30.Text); if (substitution_found == null) { textBox_30.Text = ""; } else { textBox_30.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_31.Text); if (substitution_found == null) { textBox_31.Text = ""; } else { textBox_31.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_32.Text); if (substitution_found == null) { textBox_32.Text = ""; } else { textBox_32.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_33.Text); if (substitution_found == null) { textBox_33.Text = ""; } else { textBox_33.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_34.Text); if (substitution_found == null) { textBox_34.Text = ""; } else { textBox_34.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_35.Text); if (substitution_found == null) { textBox_35.Text = ""; } else { textBox_35.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_36.Text); if (substitution_found == null) { textBox_36.Text = ""; } else { textBox_36.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_37.Text); if (substitution_found == null) { textBox_37.Text = ""; } else { textBox_37.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_38.Text); if (substitution_found == null) { textBox_38.Text = ""; } else { textBox_38.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_39.Text); if (substitution_found == null) { textBox_39.Text = ""; } else { textBox_39.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_40.Text); if (substitution_found == null) { textBox_40.Text = ""; } else { textBox_40.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_41.Text); if (substitution_found == null) { textBox_41.Text = ""; } else { textBox_41.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_42.Text); if (substitution_found == null) { textBox_42.Text = ""; } else { textBox_42.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_43.Text); if (substitution_found == null) { textBox_43.Text = ""; } else { textBox_43.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_44.Text); if (substitution_found == null) { textBox_44.Text = ""; } else { textBox_44.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_45.Text); if (substitution_found == null) { textBox_45.Text = ""; } else { textBox_45.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_46.Text); if (substitution_found == null) { textBox_46.Text = ""; } else { textBox_46.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_47.Text); if (substitution_found == null) { textBox_47.Text = ""; } else { textBox_47.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_48.Text); if (substitution_found == null) { textBox_48.Text = ""; } else { textBox_48.Text = substitution_found.string_replacement; }
                    substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_49.Text); if (substitution_found == null) { textBox_49.Text = ""; } else { textBox_49.Text = substitution_found.string_replacement; }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        List<class_substitution> substitutions_get_from_file_sorted_descending(String string_file_path_input)
        {
            List<class_substitution> list_substitutions_from_file_sorted_descending = new List<class_substitution>();

            try
            {
                List<class_substitution> list_substitutions_from_file_unsorted = substitutions_get_from_file_unsorted(string_file_path_input);

                //
                // Sort the custom replacement list alphabetically
                //
                foreach (class_substitution substitution in substitutions_sort_by_original_string_length_descending(list_substitutions_from_file_unsorted))
                {
                    list_substitutions_from_file_sorted_descending.Add(substitution);
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }

            return list_substitutions_from_file_sorted_descending;
        }

        ////////////////////////////////////////////////////////////////////////////////

        List<class_substitution> substitutions_get_from_file_unsorted(String string_file_path_input)
        {
            List<class_substitution> list_substitutions_from_file_unsorted = new List<class_substitution>();

            try
            {
                StreamReader streamReader_currently_selected_filename = new StreamReader(string_file_path_input);

                String string_replacement = streamReader_currently_selected_filename.ReadLine();

                while (string_replacement != null)
                {
                    int int_delimiter_found_index = string_replacement.IndexOf(string_delimiter);

                    if (int_delimiter_found_index != -1)
                    {
                        if ((int_delimiter_found_index + string_delimiter.Length) < string_replacement.Length)
                        {
                            list_substitutions_from_file_unsorted.Add(new class_substitution(string_replacement.Substring(0, int_delimiter_found_index), string_replacement.Substring(int_delimiter_found_index + string_delimiter.Length), "", RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Compiled));
                        }
                        else
                        {
                            list_substitutions_from_file_unsorted.Add(new class_substitution(string_replacement.Substring(0, int_delimiter_found_index), "", "", RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Compiled));
                        }
                    }

                    string_replacement = streamReader_currently_selected_filename.ReadLine();
                };

                streamReader_currently_selected_filename.Close();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }

            return list_substitutions_from_file_unsorted;
        }

        /// ////////////////////////////////////////////////////////////////////////////

        void reload_sanskrit_without_diacritics()
        {
            try
            {
                if (File.Exists(string_sanskrit_without_diacritics_ini_file_path) == false)
                {
                    list_substitutions_sanskrit_without_diacritics.Clear();
                    create_sanskrit_without_diacritics_default_file();
                }

                if (list_substitutions_sanskrit_without_diacritics.Count < 1)
                {
                    StreamReader streamReader_sanskrit_words_without_diacritics_list = new StreamReader(string_sanskrit_without_diacritics_ini_file_path);

                    String string_sanskrit_word = streamReader_sanskrit_words_without_diacritics_list.ReadLine();

                    while (string_sanskrit_word != null)
                    {
                        String string_word_singular = "";

                        string_sanskrit_word = string_sanskrit_word.Trim().ToLower();
                        Match match_replace_word_from_plural_to_singular = regex_replace_word_from_plural_to_singular.Match(string_sanskrit_word);

                        if (match_replace_word_from_plural_to_singular.Success == true)
                        {
                            string_word_singular = match_replace_word_from_plural_to_singular.Groups[1].Value;
                        }
                        else
                        {
                            string_word_singular = string_sanskrit_word;
                        }

                        list_substitutions_sanskrit_without_diacritics.Add(new class_substitution(@"(^|[\s\p{P}])" + string_word_singular + @"(s|'s)*([\s\p{P}]|$)", "", string_sanskrit_word, regexOptions_default | RegexOptions.IgnoreCase));

                        string_sanskrit_word = streamReader_sanskrit_words_without_diacritics_list.ReadLine();
                    }

                    streamReader_sanskrit_words_without_diacritics_list.Close();
                }


            }
            catch(Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        static char[] char_30_unicode_encoded_sanskrit_letters_array = {
                    'Ṣ',
                    'ṣ',
                    'Ñ',
                    'ñ',
                    'Ā',
                    'ā',
                    'Ī',
                    'ī',
                    'Ś',
                    'ś',
                    'Ū',
                    'ū',
                    'Ḍ',
                    'ḍ',
                    'Ḥ',
                    'ḥ',
                    'Ḷ',
                    'ḷ',
                    'Ṁ',
                    'ṁ',
                    'Ṅ',
                    'ṅ',
                    'Ṇ',
                    'ṇ',
                    'Ṛ',
                    'ṛ',
                    'Ṝ',
                    'ṝ',
                    'Ṭ',
                    'ṭ'};

        ////////////////////////////////////////////////////////////////////////////////

        static String[] string_31_unicode_encoded_sanskrit_letters_array = {
                    "Ṣ",
                    "ṣ",
                    "Ñ",
                    "ñ",
                    "Ā",
                    "ā",
                    "Ī",
                    "ī",
                    "Ś",
                    "ś",
                    "Ū",
                    "ū",
                    "Ḍ",
                    "ḍ",
                    "Ḥ",
                    "ḥ",
                    "Ḷ",
                    "ḷ",
                    "Ṁ",
                    "ṁ",
                    "Ṅ",
                    "ṅ",
                    "Ṇ",
                    "ṇ",
                    "Ṛ",
                    "ṛ",
                    "Ṝ",
                    "ṝ",
                    "Ṭ",
                    "ṭ",
                    "l̐"};

        static String[] string_31_balarama_encoded_sanskrit_letters_array = {
                    "Ñ",
                    "ñ",
                    "Ï",
                    "ï",
                    "Ä",
                    "ä",
                    "É",
                    "é",
                    "Ç",
                    "ç",
                    "Ü",
                    "ü",
                    "Ò",
                    "ò",
                    "Ù",
                    "ù",
                    "ß",
                    "ÿ",
                    "À",
                    "à",
                    "Ì",
                    "ì",
                    "Ë",
                    "ë",
                    "Å",
                    "å",
                    "È",
                    "è",
                    "Ö",
                    "ö",
                    "û"};

        static String convert_balarama_encoding_to_unicode_encoding(String string_balarama_encoding_input)
        {
            String string_unicode_encoding_output = string_balarama_encoding_input;

            try
            {
                for (int i = 0; i < string_31_unicode_encoded_sanskrit_letters_array.Length; i++)
                {
                    string_unicode_encoding_output = string_unicode_encoding_output.Replace(string_31_balarama_encoded_sanskrit_letters_array[i], string_31_unicode_encoded_sanskrit_letters_array[i]);
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }

            return string_unicode_encoding_output;
        }

        ////////////////////////////////////////////////////////////////////////////////

        static string RemoveDiacritics(string stIn)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                string stFormD = stIn.Normalize(NormalizationForm.FormD);

                for (int ich = 0; ich < stFormD.Length; ich++)
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                    if (uc != UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(stFormD[ich]);
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        ////////////////////////////////////////////////////////////////////////////////

        public Form_main()
        {
            try
            {
                InitializeComponent();

                toolTip_gutturals = new System.Windows.Forms.ToolTip(); toolTip_gutturals.SetToolTip(this.label_gutturals, "'Pronounced in the throat or the back of the mouth' [Collins English Dictionary, 2003]"); toolTip_gutturals.ShowAlways = true; toolTip_gutturals.AutomaticDelay = 1000; toolTip_gutturals.AutoPopDelay = 30000; toolTip_gutturals.InitialDelay = 1000; toolTip_gutturals.ReshowDelay = 1000;
                toolTip_palatals = new System.Windows.Forms.ToolTip(); toolTip_palatals.SetToolTip(this.label_palatals, "'Produced with the front of the tongue near or against the hard palate, as the (y) in English young.' [American Heritage Dictionary, 2009]"); toolTip_palatals.ShowAlways = true; toolTip_palatals.AutomaticDelay = 1000; toolTip_palatals.AutoPopDelay = 30000; toolTip_palatals.InitialDelay = 1000; toolTip_palatals.ReshowDelay = 1000;
                toolTip_cerebrals = new System.Windows.Forms.ToolTip(); toolTip_cerebrals.SetToolTip(this.label_cerebrals, "'Articulated with the tip of the tongue turned back and up toward the roof of the mouth; retroflex.' [American Heritage Dictionary, 2009]"); toolTip_cerebrals.ShowAlways = true; toolTip_cerebrals.AutomaticDelay = 1000; toolTip_cerebrals.AutoPopDelay = 30000; toolTip_cerebrals.InitialDelay = 1000; toolTip_cerebrals.ReshowDelay = 1000;
                toolTip_dentals = new System.Windows.Forms.ToolTip(); toolTip_dentals.SetToolTip(this.label_dentals, "'Articulated with the tip of the tongue near or against the upper front teeth: the English dental consonants t and d.' [American Heritage Dictionary, 2009]"); toolTip_dentals.ShowAlways = true; toolTip_dentals.AutomaticDelay = 1000; toolTip_dentals.AutoPopDelay = 30000; toolTip_dentals.InitialDelay = 1000; toolTip_dentals.ReshowDelay = 1000;
                toolTip_labials = new System.Windows.Forms.ToolTip(); toolTip_labials.SetToolTip(this.label_labials, "'Articulated mainly by closing or partly closing the lips, as the sounds (b), (m), or (w).' [American Heritage Dictionary, 2009]"); toolTip_labials.ShowAlways = true; toolTip_labials.AutomaticDelay = 1000; toolTip_labials.AutoPopDelay = 30000; toolTip_labials.InitialDelay = 1000; toolTip_labials.ReshowDelay = 1000;
                toolTip_semivowels = new System.Windows.Forms.ToolTip(); toolTip_semivowels.SetToolTip(this.label_semivowels, "'A vowel-like sound that acts like a consonant, in that it serves the same function in a syllable carrying the same amount of prominence as a consonant relative to a true vowel, the nucleus of the syllable In English and many other languages the chief semivowels are (w) in well and (j), represented as y, in yell' [Collins English Dictionary, 2003]"); toolTip_semivowels.ShowAlways = true; toolTip_semivowels.AutomaticDelay = 1000; toolTip_semivowels.AutoPopDelay = 30000; toolTip_semivowels.InitialDelay = 1000; toolTip_semivowels.ReshowDelay = 1000;
                toolTip_sibilants = new System.Windows.Forms.ToolTip(); toolTip_sibilants.SetToolTip(this.label_sibilants, "'Relating to or denoting the consonants (s, z, ʃ, ʒ), all pronounced with a characteristic hissing sound' [Collins English Dictionary, 2003]"); toolTip_sibilants.ShowAlways = true; toolTip_sibilants.AutomaticDelay = 1000; toolTip_sibilants.AutoPopDelay = 30000; toolTip_sibilants.InitialDelay = 1000; toolTip_sibilants.ReshowDelay = 1000;
                toolTip_aspirate = new System.Windows.Forms.ToolTip(); toolTip_aspirate.SetToolTip(this.label_aspirate, "'To pronounce (a vowel or word) with the initial release of breath associated with English h, as in hurry.' [American Heritage Dictionary, 2009]"); toolTip_aspirate.ShowAlways = true; toolTip_aspirate.AutomaticDelay = 1000; toolTip_aspirate.AutoPopDelay = 30000; toolTip_aspirate.InitialDelay = 1000; toolTip_aspirate.ReshowDelay = 1000;
                toolTip_00 = new System.Windows.Forms.ToolTip(); toolTip_00.SetToolTip(this.label_00, "a - like the a in organ or the u in but. [u]"); toolTip_00.ShowAlways = true; toolTip_00.AutomaticDelay = 1000; toolTip_00.AutoPopDelay = 30000; toolTip_00.InitialDelay = 1000; toolTip_00.ReshowDelay = 1000;
                toolTip_01 = new System.Windows.Forms.ToolTip(); toolTip_01.SetToolTip(this.label_01, "ā - like the ā in far but held twice as long as a. [a]"); toolTip_01.ShowAlways = true; toolTip_01.AutomaticDelay = 1000; toolTip_01.AutoPopDelay = 30000; toolTip_01.InitialDelay = 1000; toolTip_01.ReshowDelay = 1000;
                toolTip_02 = new System.Windows.Forms.ToolTip(); toolTip_02.SetToolTip(this.label_02, "i - like the i in pin. [i]"); toolTip_02.ShowAlways = true; toolTip_02.AutomaticDelay = 1000; toolTip_02.AutoPopDelay = 30000; toolTip_02.InitialDelay = 1000; toolTip_02.ReshowDelay = 1000;
                toolTip_03 = new System.Windows.Forms.ToolTip(); toolTip_03.SetToolTip(this.label_03, "ī - like the ī in pique but held twice as long as i. [i]"); toolTip_03.ShowAlways = true; toolTip_03.AutomaticDelay = 1000; toolTip_03.AutoPopDelay = 30000; toolTip_03.InitialDelay = 1000; toolTip_03.ReshowDelay = 1000;
                toolTip_04 = new System.Windows.Forms.ToolTip(); toolTip_04.SetToolTip(this.label_04, "u - like the u in push. [u]"); toolTip_04.ShowAlways = true; toolTip_04.AutomaticDelay = 1000; toolTip_04.AutoPopDelay = 30000; toolTip_04.InitialDelay = 1000; toolTip_04.ReshowDelay = 1000;
                toolTip_05 = new System.Windows.Forms.ToolTip(); toolTip_05.SetToolTip(this.label_05, "ū - like the ū in rule but held twice as long as u. [u]"); toolTip_05.ShowAlways = true; toolTip_05.AutomaticDelay = 1000; toolTip_05.AutoPopDelay = 30000; toolTip_05.InitialDelay = 1000; toolTip_05.ReshowDelay = 1000;
                toolTip_06 = new System.Windows.Forms.ToolTip(); toolTip_06.SetToolTip(this.label_06, "ṛ - like the ri in Rita (but more like French ru). [Ri]"); toolTip_06.ShowAlways = true; toolTip_06.AutomaticDelay = 1000; toolTip_06.AutoPopDelay = 30000; toolTip_06.InitialDelay = 1000; toolTip_06.ReshowDelay = 1000;
                toolTip_07 = new System.Windows.Forms.ToolTip(); toolTip_07.SetToolTip(this.label_07, "ṝ - same as ṛi but held twice as long."); toolTip_07.ShowAlways = true; toolTip_07.AutomaticDelay = 1000; toolTip_07.AutoPopDelay = 30000; toolTip_07.InitialDelay = 1000; toolTip_07.ReshowDelay = 1000;
                toolTip_08 = new System.Windows.Forms.ToolTip(); toolTip_08.SetToolTip(this.label_08, "ḷ - like lree (lruu). [lree, lruu]"); toolTip_08.ShowAlways = true; toolTip_08.AutomaticDelay = 1000; toolTip_08.AutoPopDelay = 30000; toolTip_08.InitialDelay = 1000; toolTip_08.ReshowDelay = 1000;
                toolTip_09 = new System.Windows.Forms.ToolTip(); toolTip_09.SetToolTip(this.label_09, "l̐ = same as lree (lruu) but held twice as long."); toolTip_09.ShowAlways = true; toolTip_09.AutomaticDelay = 1000; toolTip_09.AutoPopDelay = 30000; toolTip_09.InitialDelay = 1000; toolTip_09.ReshowDelay = 1000;
                toolTip_10 = new System.Windows.Forms.ToolTip(); toolTip_10.SetToolTip(this.label_10, "e - like the e in they. [e]"); toolTip_10.ShowAlways = true; toolTip_10.AutomaticDelay = 1000; toolTip_10.AutoPopDelay = 30000; toolTip_10.InitialDelay = 1000; toolTip_10.ReshowDelay = 1000;
                toolTip_11 = new System.Windows.Forms.ToolTip(); toolTip_11.SetToolTip(this.label_11, "ai - like the ai in aisle. [ai]"); toolTip_11.ShowAlways = true; toolTip_11.AutomaticDelay = 1000; toolTip_11.AutoPopDelay = 30000; toolTip_11.InitialDelay = 1000; toolTip_11.ReshowDelay = 1000;
                toolTip_12 = new System.Windows.Forms.ToolTip(); toolTip_12.SetToolTip(this.label_12, "o - like the o in go. [o]"); toolTip_12.ShowAlways = true; toolTip_12.AutomaticDelay = 1000; toolTip_12.AutoPopDelay = 30000; toolTip_12.InitialDelay = 1000; toolTip_12.ReshowDelay = 1000;
                toolTip_13 = new System.Windows.Forms.ToolTip(); toolTip_13.SetToolTip(this.label_13, "au - like the ow in how. [ow]"); toolTip_13.ShowAlways = true; toolTip_13.AutomaticDelay = 1000; toolTip_13.AutoPopDelay = 30000; toolTip_13.InitialDelay = 1000; toolTip_13.ReshowDelay = 1000;
                toolTip_14 = new System.Windows.Forms.ToolTip(); toolTip_14.SetToolTip(this.label_14, "ṁ (anusvāra) - a resonant nasal like the n in the French word bon. [on]"); toolTip_14.ShowAlways = true; toolTip_14.AutomaticDelay = 1000; toolTip_14.AutoPopDelay = 30000; toolTip_14.InitialDelay = 1000; toolTip_14.ReshowDelay = 1000;
                toolTip_15 = new System.Windows.Forms.ToolTip(); toolTip_15.SetToolTip(this.label_15, "ḥ (visarga) - a final h-sound: aḥ is pronounced like aha; iḥ like ihi."); toolTip_15.ShowAlways = true; toolTip_15.AutomaticDelay = 1000; toolTip_15.AutoPopDelay = 30000; toolTip_15.InitialDelay = 1000; toolTip_15.ReshowDelay = 1000;
                toolTip_16 = new System.Windows.Forms.ToolTip(); toolTip_16.SetToolTip(this.label_16, "k - as in kite [k]"); toolTip_16.ShowAlways = true; toolTip_16.AutomaticDelay = 1000; toolTip_16.AutoPopDelay = 30000; toolTip_16.InitialDelay = 1000; toolTip_16.ReshowDelay = 1000;
                toolTip_17 = new System.Windows.Forms.ToolTip(); toolTip_17.SetToolTip(this.label_17, "kh - as in Eckhart [kh]"); toolTip_17.ShowAlways = true; toolTip_17.AutomaticDelay = 1000; toolTip_17.AutoPopDelay = 30000; toolTip_17.InitialDelay = 1000; toolTip_17.ReshowDelay = 1000;
                toolTip_18 = new System.Windows.Forms.ToolTip(); toolTip_18.SetToolTip(this.label_18, "g - as in give [g]"); toolTip_18.ShowAlways = true; toolTip_18.AutomaticDelay = 1000; toolTip_18.AutoPopDelay = 30000; toolTip_18.InitialDelay = 1000; toolTip_18.ReshowDelay = 1000;
                toolTip_19 = new System.Windows.Forms.ToolTip(); toolTip_19.SetToolTip(this.label_19, "gh - as in dig-hard [g-h]"); toolTip_19.ShowAlways = true; toolTip_19.AutomaticDelay = 1000; toolTip_19.AutoPopDelay = 30000; toolTip_19.InitialDelay = 1000; toolTip_19.ReshowDelay = 1000;
                toolTip_20 = new System.Windows.Forms.ToolTip(); toolTip_20.SetToolTip(this.label_20, "ṅ - as in sing [n]"); toolTip_20.ShowAlways = true; toolTip_20.AutomaticDelay = 1000; toolTip_20.AutoPopDelay = 30000; toolTip_20.InitialDelay = 1000; toolTip_20.ReshowDelay = 1000;
                toolTip_21 = new System.Windows.Forms.ToolTip(); toolTip_21.SetToolTip(this.label_21, "c - as in chair [ch]"); toolTip_21.ShowAlways = true; toolTip_21.AutomaticDelay = 1000; toolTip_21.AutoPopDelay = 30000; toolTip_21.InitialDelay = 1000; toolTip_21.ReshowDelay = 1000;
                toolTip_22 = new System.Windows.Forms.ToolTip(); toolTip_22.SetToolTip(this.label_22, "ch - as in staunch-heart [ch-h]"); toolTip_22.ShowAlways = true; toolTip_22.AutomaticDelay = 1000; toolTip_22.AutoPopDelay = 30000; toolTip_22.InitialDelay = 1000; toolTip_22.ReshowDelay = 1000;
                toolTip_23 = new System.Windows.Forms.ToolTip(); toolTip_23.SetToolTip(this.label_23, "j - as in joy [j]"); toolTip_23.ShowAlways = true; toolTip_23.AutomaticDelay = 1000; toolTip_23.AutoPopDelay = 30000; toolTip_23.InitialDelay = 1000; toolTip_23.ReshowDelay = 1000;
                toolTip_24 = new System.Windows.Forms.ToolTip(); toolTip_24.SetToolTip(this.label_24, "jh - as in hedgehog [edgeh]"); toolTip_24.ShowAlways = true; toolTip_24.AutomaticDelay = 1000; toolTip_24.AutoPopDelay = 30000; toolTip_24.InitialDelay = 1000; toolTip_24.ReshowDelay = 1000;
                toolTip_25 = new System.Windows.Forms.ToolTip(); toolTip_25.SetToolTip(this.label_25, "ñ - as in canyon [ny]"); toolTip_25.ShowAlways = true; toolTip_25.AutomaticDelay = 1000; toolTip_25.AutoPopDelay = 30000; toolTip_25.InitialDelay = 1000; toolTip_25.ReshowDelay = 1000;
                toolTip_26 = new System.Windows.Forms.ToolTip(); toolTip_26.SetToolTip(this.label_26, "ṭ - as in tub [t]"); toolTip_26.ShowAlways = true; toolTip_26.AutomaticDelay = 1000; toolTip_26.AutoPopDelay = 30000; toolTip_26.InitialDelay = 1000; toolTip_26.ReshowDelay = 1000;
                toolTip_27 = new System.Windows.Forms.ToolTip(); toolTip_27.SetToolTip(this.label_27, "ṭh - as in light-heart [t-h]"); toolTip_27.ShowAlways = true; toolTip_27.AutomaticDelay = 1000; toolTip_27.AutoPopDelay = 30000; toolTip_27.InitialDelay = 1000; toolTip_27.ReshowDelay = 1000;
                toolTip_28 = new System.Windows.Forms.ToolTip(); toolTip_28.SetToolTip(this.label_28, "ṇ - as in rna (prepare to say the r and say na) [n]"); toolTip_28.ShowAlways = true; toolTip_28.AutomaticDelay = 1000; toolTip_28.AutoPopDelay = 30000; toolTip_28.InitialDelay = 1000; toolTip_28.ReshowDelay = 1000;
                toolTip_29 = new System.Windows.Forms.ToolTip(); toolTip_29.SetToolTip(this.label_29, "ḍha - as in red-hot [d-h]"); toolTip_29.ShowAlways = true; toolTip_29.AutomaticDelay = 1000; toolTip_29.AutoPopDelay = 30000; toolTip_29.InitialDelay = 1000; toolTip_29.ReshowDelay = 1000;
                toolTip_30 = new System.Windows.Forms.ToolTip(); toolTip_30.SetToolTip(this.label_30, "ḍ - as in dove [d]"); toolTip_30.ShowAlways = true; toolTip_30.AutomaticDelay = 1000; toolTip_30.AutoPopDelay = 30000; toolTip_30.InitialDelay = 1000; toolTip_30.ReshowDelay = 1000;
                toolTip_31 = new System.Windows.Forms.ToolTip(); toolTip_31.SetToolTip(this.label_31, "t - as in tub but with tongue against the teeth. [t]"); toolTip_31.ShowAlways = true; toolTip_31.AutomaticDelay = 1000; toolTip_31.AutoPopDelay = 30000; toolTip_31.InitialDelay = 1000; toolTip_31.ReshowDelay = 1000;
                toolTip_32 = new System.Windows.Forms.ToolTip(); toolTip_32.SetToolTip(this.label_32, "th - as in light-heart but with tongue against the teeth. [t-h]"); toolTip_32.ShowAlways = true; toolTip_32.AutomaticDelay = 1000; toolTip_32.AutoPopDelay = 30000; toolTip_32.InitialDelay = 1000; toolTip_32.ReshowDelay = 1000;
                toolTip_33 = new System.Windows.Forms.ToolTip(); toolTip_33.SetToolTip(this.label_33, "d - as in dove but tongue against teeth. [d]"); toolTip_33.ShowAlways = true; toolTip_33.AutomaticDelay = 1000; toolTip_33.AutoPopDelay = 30000; toolTip_33.InitialDelay = 1000; toolTip_33.ReshowDelay = 1000;
                toolTip_34 = new System.Windows.Forms.ToolTip(); toolTip_34.SetToolTip(this.label_34, "dh - as in red-hot but with tongue against the teeth. [d-h]"); toolTip_34.ShowAlways = true; toolTip_34.AutomaticDelay = 1000; toolTip_34.AutoPopDelay = 30000; toolTip_34.InitialDelay = 1000; toolTip_34.ReshowDelay = 1000;
                toolTip_35 = new System.Windows.Forms.ToolTip(); toolTip_35.SetToolTip(this.label_35, "n - as in nut but with tongue in between teeth. [n]"); toolTip_35.ShowAlways = true; toolTip_35.AutomaticDelay = 1000; toolTip_35.AutoPopDelay = 30000; toolTip_35.InitialDelay = 1000; toolTip_35.ReshowDelay = 1000;
                toolTip_36 = new System.Windows.Forms.ToolTip(); toolTip_36.SetToolTip(this.label_36, "p - as in pine [p]"); toolTip_36.ShowAlways = true; toolTip_36.AutomaticDelay = 1000; toolTip_36.AutoPopDelay = 30000; toolTip_36.InitialDelay = 1000; toolTip_36.ReshowDelay = 1000;
                toolTip_37 = new System.Windows.Forms.ToolTip(); toolTip_37.SetToolTip(this.label_37, "ph - as in up-hill (not f) [p-h]"); toolTip_37.ShowAlways = true; toolTip_37.AutomaticDelay = 1000; toolTip_37.AutoPopDelay = 30000; toolTip_37.InitialDelay = 1000; toolTip_37.ReshowDelay = 1000;
                toolTip_38 = new System.Windows.Forms.ToolTip(); toolTip_38.SetToolTip(this.label_38, "b - as in bird [i]"); toolTip_38.ShowAlways = true; toolTip_38.AutomaticDelay = 1000; toolTip_38.AutoPopDelay = 30000; toolTip_38.InitialDelay = 1000; toolTip_38.ReshowDelay = 1000;
                toolTip_39 = new System.Windows.Forms.ToolTip(); toolTip_39.SetToolTip(this.label_39, "bh - as in rub-hard [b-h]"); toolTip_39.ShowAlways = true; toolTip_39.AutomaticDelay = 1000; toolTip_39.AutoPopDelay = 30000; toolTip_39.InitialDelay = 1000; toolTip_39.ReshowDelay = 1000;
                toolTip_40 = new System.Windows.Forms.ToolTip(); toolTip_40.SetToolTip(this.label_40, "m - as in mother [m]"); toolTip_40.ShowAlways = true; toolTip_40.AutomaticDelay = 1000; toolTip_40.AutoPopDelay = 30000; toolTip_40.InitialDelay = 1000; toolTip_40.ReshowDelay = 1000;
                toolTip_41 = new System.Windows.Forms.ToolTip(); toolTip_41.SetToolTip(this.label_41, "y - as in yes [y]"); toolTip_41.ShowAlways = true; toolTip_41.AutomaticDelay = 1000; toolTip_41.AutoPopDelay = 30000; toolTip_41.InitialDelay = 1000; toolTip_41.ReshowDelay = 1000;
                toolTip_42 = new System.Windows.Forms.ToolTip(); toolTip_42.SetToolTip(this.label_42, "r - as in run [r]"); toolTip_42.ShowAlways = true; toolTip_42.AutomaticDelay = 1000; toolTip_42.AutoPopDelay = 30000; toolTip_42.InitialDelay = 1000; toolTip_42.ReshowDelay = 1000;
                toolTip_43 = new System.Windows.Forms.ToolTip(); toolTip_43.SetToolTip(this.label_43, "l - as in light [l]"); toolTip_43.ShowAlways = true; toolTip_43.AutomaticDelay = 1000; toolTip_43.AutoPopDelay = 30000; toolTip_43.InitialDelay = 1000; toolTip_43.ReshowDelay = 1000;
                toolTip_44 = new System.Windows.Forms.ToolTip(); toolTip_44.SetToolTip(this.label_44, "v - as in vine. [v]"); toolTip_44.ShowAlways = true; toolTip_44.AutomaticDelay = 1000; toolTip_44.AutoPopDelay = 30000; toolTip_44.InitialDelay = 1000; toolTip_44.ReshowDelay = 1000;
                toolTip_45 = new System.Windows.Forms.ToolTip(); toolTip_45.SetToolTip(this.label_45, "s - as in sun [s]"); toolTip_45.ShowAlways = true; toolTip_45.AutomaticDelay = 1000; toolTip_45.AutoPopDelay = 30000; toolTip_45.InitialDelay = 1000; toolTip_45.ReshowDelay = 1000;
                toolTip_46 = new System.Windows.Forms.ToolTip(); toolTip_46.SetToolTip(this.label_46, "ś (palatal) - as in the s in the German word sprechen [sprechen]"); toolTip_46.ShowAlways = true; toolTip_46.AutomaticDelay = 1000; toolTip_46.AutoPopDelay = 30000; toolTip_46.InitialDelay = 1000; toolTip_46.ReshowDelay = 1000;
                toolTip_47 = new System.Windows.Forms.ToolTip(); toolTip_47.SetToolTip(this.label_47, "ṣ (cerebral) - as the sh in shine [sh]"); toolTip_47.ShowAlways = true; toolTip_47.AutomaticDelay = 1000; toolTip_47.AutoPopDelay = 30000; toolTip_47.InitialDelay = 1000; toolTip_47.ReshowDelay = 1000;
                toolTip_48 = new System.Windows.Forms.ToolTip(); toolTip_48.SetToolTip(this.label_48, "h - as in home [h]"); toolTip_48.ShowAlways = true; toolTip_48.AutomaticDelay = 1000; toolTip_48.AutoPopDelay = 30000; toolTip_48.InitialDelay = 1000; toolTip_48.ReshowDelay = 1000;
                toolTip_49 = new System.Windows.Forms.ToolTip(); toolTip_49.SetToolTip(this.label_49, "' (avagraha) - the apostrophe - When a word ending in either of the vowels 'e' or 'o' are followed by a word beginning with the short vowel 'a', the 'a' is elided (i.e. omitted) and replaced with the silent avagraha. Thus e + a = written e' pronounced e; and o + a = written o' pronounced o. [Avagraha, http://rigpawiki.org, 2007-06-26]"); toolTip_49.ShowAlways = true; toolTip_49.AutomaticDelay = 1000; toolTip_49.AutoPopDelay = 30000; toolTip_49.InitialDelay = 1000; toolTip_49.ReshowDelay = 1000;
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void create_default_substitutions_none_ini()
        {
            try
            {
                File.Create(string_substitutions_none_ini_file_path);
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void Form_main_Load(object sender, EventArgs e)
        {
            comboBox_select_substitutions_filename.SelectedIndex = -1;

            try
            {
                create_default_substitutions_none_ini();

                FileInfo fileInfo_size_check;

                try
                {
                    fileInfo_size_check = new FileInfo(string_settings_ini_file_path);

                    if (
                        (File.Exists(string_settings_ini_file_path) == false) ||
                        (fileInfo_size_check.Length == 0))
                    {

                        create_default_settings_ini();
                    }
                }
                catch (Exception exception_00)
                {
                    exception_00.ToString();
                }

                try
                {
                    fileInfo_size_check = new FileInfo(string_sanskrit_without_diacritics_ini_file_path);

                    if (
                        (File.Exists(string_sanskrit_without_diacritics_ini_file_path) == false) ||
                        (fileInfo_size_check.Length == 0))
                    {
                        create_sanskrit_without_diacritics_default_file();
                    }
                }
                catch (Exception exception_00)
                {
                    exception_00.ToString();
                }


                try
                {

                    fileInfo_size_check = new FileInfo(string_substitutions_apple_ini_file_path);

                    if (
                        (File.Exists(string_substitutions_apple_ini_file_path) == false) ||
                        (fileInfo_size_check.Length == 0))
                    {
                        create_default_substitutions_apple_ini();
                    }
                }
                catch (Exception exception_00)
                {
                    exception_00.ToString();
                }

                try
                {
                    fileInfo_size_check = new FileInfo(string_substitutions_kindle_ini_file_path);

                    if (
                        (File.Exists(string_substitutions_kindle_ini_file_path) == false) ||
                        (fileInfo_size_check.Length == 0))
                    {
                        create_default_substitutions_kindle_ini();
                    }
                }
                catch (Exception exception_00)
                {
                    exception_00.ToString();
                }

                try
                {
                    fileInfo_size_check = new FileInfo(string_substitutions_microsoft_ini_file_path);

                    if (
                        (File.Exists(string_substitutions_microsoft_ini_file_path) == false) ||
                        (fileInfo_size_check.Length == 0))
                    {
                        create_default_substitutions_microsoft_ini();
                    }
                }
                catch (Exception exception_00)
                {
                    exception_00.ToString();
                }

                reload_combobox_and_select_substitution_filename();
                
                load_settings_ini();

                for (int i = 1; i < Environment.GetCommandLineArgs().Length; i++)
                {
                    if (File.Exists(Environment.GetCommandLineArgs()[i]) == true)
                    {
                        list_string_input_files_to_process.Add(Environment.GetCommandLineArgs()[i]);
                    }
                }

                if (list_string_input_files_to_process.Count > 0)
                {
                    if (list_substitutions_sanskrit_without_diacritics.Count < 1)
                    {
                        reload_sanskrit_without_diacritics();
                    }

                    start_conversion_thread();
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void reload_combobox_and_select_substitution_filename(String string_substitution_filename_to_select = "")
        {
            try
            {
                comboBox_select_substitutions_filename.Items.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                FileInfo[] fileInfo_array = directoryInfo.GetFiles(string_substitutions_filename_prefix + "*.ini");

                foreach (FileInfo fileInfo in fileInfo_array)
                {
                    comboBox_select_substitutions_filename.Items.Add(fileInfo.Name);
                }

                if (String.IsNullOrEmpty(string_substitution_filename_to_select) == false)
                {
                    int int_found_index = comboBox_select_substitutions_filename.FindStringExact(string_substitution_filename_to_select);

                    if (int_found_index > -1)
                    {
                        comboBox_select_substitutions_filename.SelectedIndex = -1;
                        comboBox_select_substitutions_filename.SelectedIndex = int_found_index;
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void button_convert_Click(object sender, EventArgs e)
        {
            try
            {
                if (list_substitutions_sanskrit_without_diacritics.Count < 1)
                {
                    reload_sanskrit_without_diacritics();
                }

                start_conversion_thread();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void button_defaults_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult_defaults = MessageBox.Show("Hare Kṛṣṇa! Are you sure you want to restore all the defaults?", "Restore All Defaults", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

                if (dialogResult_defaults == DialogResult.Yes)
                {
                    if (button_cancel.Text == "Cancel")
                    {
                        label_settings.Visible = false;
                        label_sanskrit_without_diacritics.Visible = false;
                        textBox_displayed_file.Text = "";
                        textBox_displayed_file.Visible = false;
                        button_cancel.Text = "Substitutions";
                        button_save.Text = "Words";
                        button_save.Font = new Font(button_save.Font, FontStyle.Regular);
                        update_controls();
                    }

                    string_currently_selected_combobox_filename = "";
                    create_default_settings_ini();
                    create_default_substitutions_apple_ini();
                    create_default_substitutions_kindle_ini();
                    create_default_substitutions_microsoft_ini();
                    reload_combobox_and_select_substitution_filename();
                    load_settings_ini();
                    create_sanskrit_without_diacritics_default_file();
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        void create_sanskrit_without_diacritics_default_file()
        {
            try
            {
                StreamWriter streamWriter_sanskrit_without_diacritics = new StreamWriter(string_sanskrit_without_diacritics_ini_file_path);
                streamWriter_sanskrit_without_diacritics.WriteLine("Abhaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Abhidheya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Abhimanyu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Acala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Acchha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Acintya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Acit");
                streamWriter_sanskrit_without_diacritics.WriteLine("Acyuta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Adbhuta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Adhama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Adharma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Adhibhautika");
                streamWriter_sanskrit_without_diacritics.WriteLine("Adhidaivatam");
                streamWriter_sanskrit_without_diacritics.WriteLine("Adhidaivic");
                streamWriter_sanskrit_without_diacritics.WriteLine("Adhidaivika");
                streamWriter_sanskrit_without_diacritics.WriteLine("Adhiratha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Aditi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Advaita Prabhu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Advaita");
                streamWriter_sanskrit_without_diacritics.WriteLine("Advaitin");
                streamWriter_sanskrit_without_diacritics.WriteLine("Agastya Muni");
                streamWriter_sanskrit_without_diacritics.WriteLine("Agastya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Aghana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Agni");
                streamWriter_sanskrit_without_diacritics.WriteLine("Agra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Agnistoma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Aja");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ajam");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ajita");
                streamWriter_sanskrit_without_diacritics.WriteLine("Akarma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Alakshmi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Alolupa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Alu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Alwars");
                streamWriter_sanskrit_without_diacritics.WriteLine("Anamra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ananta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Anantavijaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Anaranya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Anavasara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Angrezi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Aniruddha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Anna");
                streamWriter_sanskrit_without_diacritics.WriteLine("Annamaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Annapurna");
                streamWriter_sanskrit_without_diacritics.WriteLine("Antyajas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Anukara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Anurasa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Anusara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Anuvinda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Aparasa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Apavarga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Aprameya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Arcana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Arbuda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Arci");
                streamWriter_sanskrit_without_diacritics.WriteLine("Arghya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ari");
                streamWriter_sanskrit_without_diacritics.WriteLine("Arjama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Arjuna");
                streamWriter_sanskrit_without_diacritics.WriteLine("Artha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Aryan");
                streamWriter_sanskrit_without_diacritics.WriteLine("Asamanya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Asat");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ashoka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Asita");
                streamWriter_sanskrit_without_diacritics.WriteLine("Asura");
                streamWriter_sanskrit_without_diacritics.WriteLine("Atma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Atri");
                streamWriter_sanskrit_without_diacritics.WriteLine("Atharva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Augrya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Autsukya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Avara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Avyakta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ayodya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ayoga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ayukta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Baba");
                streamWriter_sanskrit_without_diacritics.WriteLine("Babhru");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bagh");
                streamWriter_sanskrit_without_diacritics.WriteLine("Baksheesh");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bakula");
                streamWriter_sanskrit_without_diacritics.WriteLine("Baladeva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ballal");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bandi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Barbaras");
                streamWriter_sanskrit_without_diacritics.WriteLine("Benares");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhadra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhadrakali");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhagadatta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhairava");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhajana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhakta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhakti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhaktidevi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhaktivedanta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhaktivinode");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhaktivinod");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bharata");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhoga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhrama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhukti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bhuvar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bihar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Birnagar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Bodhi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Brahmacarya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Brahmajyoti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Brahmaloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Brahma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Brahman");
                streamWriter_sanskrit_without_diacritics.WriteLine("Brajbhasah");
                streamWriter_sanskrit_without_diacritics.WriteLine("Buddha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Buddhi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Buddhism");
                streamWriter_sanskrit_without_diacritics.WriteLine("Caitanya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Caitanyadeva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Cakita");
                streamWriter_sanskrit_without_diacritics.WriteLine("Cakora");
                streamWriter_sanskrit_without_diacritics.WriteLine("Cakra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Candana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Candra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Candragupta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Candraloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Cetana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chadar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chaitya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chakra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chamara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chandas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chandra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Channa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chappals");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chaukidar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Choko");
                streamWriter_sanskrit_without_diacritics.WriteLine("Cholas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Choli");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chonki");
                streamWriter_sanskrit_without_diacritics.WriteLine("Chos");
                streamWriter_sanskrit_without_diacritics.WriteLine("Choti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Choultry");
                streamWriter_sanskrit_without_diacritics.WriteLine("chowkidar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Cit");
                streamWriter_sanskrit_without_diacritics.WriteLine("Citragupta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Citraka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Citraketu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Citrasena");
                streamWriter_sanskrit_without_diacritics.WriteLine("Citravarma");
                streamWriter_sanskrit_without_diacritics.WriteLine("coti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Cratylus");
                streamWriter_sanskrit_without_diacritics.WriteLine("Crore");
                streamWriter_sanskrit_without_diacritics.WriteLine("Cyavana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dacoit");
                streamWriter_sanskrit_without_diacritics.WriteLine("Daihika");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dainya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Daityas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Darwaza");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dasendriya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Deul");
                streamWriter_sanskrit_without_diacritics.WriteLine("Deva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Devadatta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Devaki");
                streamWriter_sanskrit_without_diacritics.WriteLine("Devala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dhanur");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dhanvantari");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dharma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dharmaputra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dhaumya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dhobi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dhoti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dhrupad");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dhruva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dhruvaloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dhvajastambha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dinoia");
                streamWriter_sanskrit_without_diacritics.WriteLine("Diti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Divya Desam");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dosa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dosas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dravida");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dravya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Drupada");
                streamWriter_sanskrit_without_diacritics.WriteLine("Durbar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Durjaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Durmukha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Durvimocana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Durvirocana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Duryodhana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dvaita");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dvaitavana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dvija");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dvivida");
                streamWriter_sanskrit_without_diacritics.WriteLine("Dwarapala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ekacakra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ekalavya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gada");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gajendra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Galangal");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gamcha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gandharvas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Garbhodaka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Garga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Garh");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gari");
                streamWriter_sanskrit_without_diacritics.WriteLine("Garuda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Garva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gaudiya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gaura");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gauracandra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gaurasundara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gautama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ghat");
                streamWriter_sanskrit_without_diacritics.WriteLine("Giri");
                streamWriter_sanskrit_without_diacritics.WriteLine("Girivraja");
                streamWriter_sanskrit_without_diacritics.WriteLine("Godown");
                streamWriter_sanskrit_without_diacritics.WriteLine("Goloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gokula");
                streamWriter_sanskrit_without_diacritics.WriteLine("gopura");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gopuram");
                streamWriter_sanskrit_without_diacritics.WriteLine("Govardhana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Govinda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Granthika");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gujarat");
                streamWriter_sanskrit_without_diacritics.WriteLine("Gurdwara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Guru");
                streamWriter_sanskrit_without_diacritics.WriteLine("Haihayas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Hara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Hare");
                streamWriter_sanskrit_without_diacritics.WriteLine("Hari");
                streamWriter_sanskrit_without_diacritics.WriteLine("Haribol");
                streamWriter_sanskrit_without_diacritics.WriteLine("Hathi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Hayagriva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Hoysala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Indra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Indraloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Indraprastha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Jagamohana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Jagannatha Misra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Jagat");
                streamWriter_sanskrit_without_diacritics.WriteLine("Jajmani");
                streamWriter_sanskrit_without_diacritics.WriteLine("Janaloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Janamejaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Janas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Japa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Jaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Jayadratha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Jayatsena");
                streamWriter_sanskrit_without_diacritics.WriteLine("Jhulana yatra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ji");
                streamWriter_sanskrit_without_diacritics.WriteLine("Jitendriya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kabandha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kadru");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kailasa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kaivalya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kaivalyam");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kajjala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kali");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kalki");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kalpa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kapha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kapila");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kardama Muni");
                streamWriter_sanskrit_without_diacritics.WriteLine("Karhai");
                streamWriter_sanskrit_without_diacritics.WriteLine("Karma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Karmendriya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Karmendriyas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Katha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kathakali");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kaunteya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kauravas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kaustubha gem");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kekaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kesava Gaudiya Matha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kesava Kasmir");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kevala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Khetari");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kindama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kinnaras");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kitava");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kosala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kovil");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kratu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Krishnanagar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Krodha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kumbha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kumera");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kuntibhoja");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kurara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kurta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kuru");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kurus");
                streamWriter_sanskrit_without_diacritics.WriteLine("Kuvera");
                streamWriter_sanskrit_without_diacritics.WriteLine("Lakh");
                streamWriter_sanskrit_without_diacritics.WriteLine("Laksman");
                streamWriter_sanskrit_without_diacritics.WriteLine("Laos");
                streamWriter_sanskrit_without_diacritics.WriteLine("Lassi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Laukika");
                streamWriter_sanskrit_without_diacritics.WriteLine("Lobha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Loka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mada");
                streamWriter_sanskrit_without_diacritics.WriteLine("Madana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Madhupati");
                streamWriter_sanskrit_without_diacritics.WriteLine("Madhva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Magadha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mahal");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mahapuri");
                streamWriter_sanskrit_without_diacritics.WriteLine("Maharloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mahat");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mahendra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mahodara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Maidan");
                streamWriter_sanskrit_without_diacritics.WriteLine("Maitreya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Malayadhvaja");
                streamWriter_sanskrit_without_diacritics.WriteLine("mandapa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mandapam");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mandir");
                streamWriter_sanskrit_without_diacritics.WriteLine("Manomaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mantra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Manu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Manvantara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Maratha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Martya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Marudloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Maruts");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mata");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mati");
                streamWriter_sanskrit_without_diacritics.WriteLine("Matiar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Matsya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Maugdhya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mela");
                streamWriter_sanskrit_without_diacritics.WriteLine("Meru");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mezze");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mirabai");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mithila");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mitra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mleccha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mlecchas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Moghul");
                streamWriter_sanskrit_without_diacritics.WriteLine("Moha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mohana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Muhammed");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mukti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mukunda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Mukut");
                streamWriter_sanskrit_without_diacritics.WriteLine("Muni");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nadi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nagara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Narottama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Naishada");
                streamWriter_sanskrit_without_diacritics.WriteLine("naiskarma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nakula");
                streamWriter_sanskrit_without_diacritics.WriteLine("namak");
                streamWriter_sanskrit_without_diacritics.WriteLine("Namaste");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nan");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nanda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nandavana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nandi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Navagraha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nawab");
                streamWriter_sanskrit_without_diacritics.WriteLine("Neti neti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nimai");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nimi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nindakas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nirantara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nirjala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nirmama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nirodha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Nirveda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Niyama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Om");
                streamWriter_sanskrit_without_diacritics.WriteLine("Paani");
                streamWriter_sanskrit_without_diacritics.WriteLine("Padma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Paise");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pakka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pallavas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Panch masala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Panch puran");
                streamWriter_sanskrit_without_diacritics.WriteLine("Para");
                streamWriter_sanskrit_without_diacritics.WriteLine("Parabrahman");
                streamWriter_sanskrit_without_diacritics.WriteLine("Param ");
                streamWriter_sanskrit_without_diacritics.WriteLine("Parantapa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Parasara Muni");
                streamWriter_sanskrit_without_diacritics.WriteLine("Paravyoma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Paricchada");
                streamWriter_sanskrit_without_diacritics.WriteLine("Parikrama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pati");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pautra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pavitram");
                streamWriter_sanskrit_without_diacritics.WriteLine("Phalgu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Phalguna");
                streamWriter_sanskrit_without_diacritics.WriteLine("Phul gobhi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pika");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pitha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pitta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Prabhu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Prabodha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pradesh");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pradyumna");
                streamWriter_sanskrit_without_diacritics.WriteLine("Prahara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Prajalpa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Prakara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pramatta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pratigraha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Prativindhya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pravartaka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Prayojana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Prema");
                streamWriter_sanskrit_without_diacritics.WriteLine("Prema");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pretsila");
                streamWriter_sanskrit_without_diacritics.WriteLine("Preyas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Priyatama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Priyavrata");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pulaha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Pulastya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Puraka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Puram");
                streamWriter_sanskrit_without_diacritics.WriteLine("Purnima");
                streamWriter_sanskrit_without_diacritics.WriteLine("Purocana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Putra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Raita");
                streamWriter_sanskrit_without_diacritics.WriteLine("Raivataka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Raja");
                streamWriter_sanskrit_without_diacritics.WriteLine("Rajas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Rakta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ranaghat");
                streamWriter_sanskrit_without_diacritics.WriteLine("Rasa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Rasam");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ratha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Rati");
                streamWriter_sanskrit_without_diacritics.WriteLine("Recaka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Rishi");
                streamWriter_sanskrit_without_diacritics.WriteLine("Rudra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Rudras");
                streamWriter_sanskrit_without_diacritics.WriteLine("Rukmaratha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sabji");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sagar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sage");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sahadeva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sahib");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sainika");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sakhya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sambhoga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sampradaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Santan");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sarga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sattvatanu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Satya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Satyadeva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Satyajit");
                streamWriter_sanskrit_without_diacritics.WriteLine("Satyaloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Satyaratha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Satyasena");
                streamWriter_sanskrit_without_diacritics.WriteLine("Satyavarma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Satyavrata Manu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Satyavrata");
                streamWriter_sanskrit_without_diacritics.WriteLine("Saubha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Saubhari Muni");
                streamWriter_sanskrit_without_diacritics.WriteLine("Savitri");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sen");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sevaka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sevya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Shukla");
                streamWriter_sanskrit_without_diacritics.WriteLine("Shyama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Siddha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Siddhaloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Siddhis");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sindhu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Smarta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sneha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Snigdha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Soma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Somadatta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Somaka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Stotra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Stupa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Subala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sukham");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sulocana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sumeru");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sunanda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Supti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Suras");
                streamWriter_sanskrit_without_diacritics.WriteLine("Suruci");
                streamWriter_sanskrit_without_diacritics.WriteLine("Suryaloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Suta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sutasoma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Svadharmas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Svar");
                streamWriter_sanskrit_without_diacritics.WriteLine("Svarga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Svargaloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Sveta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Takuwan");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tamas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tantras");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tapas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tapasya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tapoloka");
                streamWriter_sanskrit_without_diacritics.WriteLine("tat");
                streamWriter_sanskrit_without_diacritics.WriteLine("tattva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tattvas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tattvavit");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tava");
                streamWriter_sanskrit_without_diacritics.WriteLine("Thali");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tilaka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tithis");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tonga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Toovar dal");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tribunga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Trigarta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Tripura");
                streamWriter_sanskrit_without_diacritics.WriteLine("Trivikrama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Triyuga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Uddhava");
                streamWriter_sanskrit_without_diacritics.WriteLine("Udvega");
                streamWriter_sanskrit_without_diacritics.WriteLine("Ugrasena");
                streamWriter_sanskrit_without_diacritics.WriteLine("Upaplavya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Uparasa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Upendra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Urukrama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Utkala");
                streamWriter_sanskrit_without_diacritics.WriteLine("Uttama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Uttamaujas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Uttara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vahana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vaisnava");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vaivasvata");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vajra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vajradatta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vandana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vapu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vastu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vasudeva");
                streamWriter_sanskrit_without_diacritics.WriteLine("Veda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Veda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vedas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vena");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vidagdha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vidarbha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Videha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vidura");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vidyanagara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vihara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vijara");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vijaya");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vijighatsa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vikarma");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vinda");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vipra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vipralambha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Viraha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Virakti");
                streamWriter_sanskrit_without_diacritics.WriteLine("Visarga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Visvarupa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vitarka");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vivarta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Viyoga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vraja");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vrajendra");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vrihadashwa");
                streamWriter_sanskrit_without_diacritics.WriteLine("Vyakta");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yadavadri");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yadu");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yadupati");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yadus");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yajana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yama");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yavana");
                streamWriter_sanskrit_without_diacritics.WriteLine("yoga");
                streamWriter_sanskrit_without_diacritics.WriteLine("yogas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yogarudha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yogendras");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yojana");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yuddha");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yuga");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yugas");
                streamWriter_sanskrit_without_diacritics.WriteLine("Yuyutsu");
                streamWriter_sanskrit_without_diacritics.Close();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        void load_settings_ini(bool bool_just_load_regular_expressions_list = false)
        {
            FileInfo fileInfo_settings = null;
            int int_delimiter_found_index = -1;
            int int_found_index = -1;
            String string_line_read = "";
            String string_parsed_text = "";
            StreamReader streamReader_settings_ini = null;
            List<String> list_string_settings_ini_contents = new List<String>();

            try
            {
                fileInfo_settings = new FileInfo(string_settings_ini_file_path);

                if ((File.Exists(string_settings_ini_file_path) == false) ||
                    (fileInfo_settings.Length == 0))
                {
                    create_default_settings_ini();
                }

                streamReader_settings_ini = new StreamReader(string_settings_ini_file_path);

                string_line_read = streamReader_settings_ini.ReadLine();

                while (string_line_read != null)
                {
                    list_string_settings_ini_contents.Add(string_line_read);
                    string_line_read = streamReader_settings_ini.ReadLine();
                }

                streamReader_settings_ini.Close();


                if (list_string_settings_ini_contents.Count < 1)
                {
                    string_line_read = null;
                }
                else
                {
                    string_line_read = list_string_settings_ini_contents[0];
                    list_string_settings_ini_contents.RemoveAt(0);
                }

                if ((Path.GetExtension(string_line_read).ToString() != ".ini") ||
                    (File.Exists(string_line_read) == false))
                {
                    list_string_settings_ini_contents.Clear();
                    create_default_settings_ini();
                    string_line_read = string_substitutions_default_ini_filename;

                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + string_substitutions_default_ini_filename) == false)
                    {
                        create_default_substitutions_kindle_ini();
                    }
                    else
                    {
                        fileInfo_settings = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + string_substitutions_default_ini_filename);

                        if (fileInfo_settings.Length == 0)
                        {
                            create_default_substitutions_kindle_ini();
                        }
                    }
                }

                int_found_index = string_line_read.Trim().IndexOf(string_substitutions_filename_prefix, 0);

                if (int_found_index == -1)
                {
                    list_string_settings_ini_contents.Clear();
                    create_default_settings_ini();
                    string_line_read = string_substitutions_default_ini_filename;

                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + string_substitutions_default_ini_filename) == false)
                    {
                        create_default_substitutions_kindle_ini();
                    }
                    else
                    {
                        fileInfo_settings = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + string_substitutions_default_ini_filename);

                        if (fileInfo_settings.Length == 0)
                        {
                            create_default_substitutions_kindle_ini();
                        }
                    }
                }

                int_found_index = comboBox_select_substitutions_filename.FindStringExact(Path.GetFileName(string_line_read));

                if (int_found_index == -1)
                {
                    if (bool_just_load_regular_expressions_list == false)
                    {
                        comboBox_select_substitutions_filename.Items.Add(Path.GetFileName(string_line_read));
                    }
                }

                int_found_index = comboBox_select_substitutions_filename.FindStringExact(Path.GetFileName(string_line_read));

                if (int_found_index != -1)
                {
                    if (bool_just_load_regular_expressions_list == false)
                    {
                        comboBox_select_substitutions_filename.SelectedIndex = -1;
                        comboBox_select_substitutions_filename.SelectedIndex = int_found_index;
                    }
                }

                ////////////////////////////////////////////////////////////////////////////////

                List<System.Windows.Forms.CheckBox> list_checkbox_settings_file = new List<System.Windows.Forms.CheckBox>();
                list_checkbox_settings_file.Add(checkBox_sanskrit);
                list_checkbox_settings_file.Add(checkBox_synonyms);
                list_checkbox_settings_file.Add(checkBox_translation);
                list_checkbox_settings_file.Add(checkBox_purport);

                List<class_substitution> list_substitution_checkbox_settings = new List<class_substitution>();
                list_substitution_checkbox_settings.Add(new class_substitution("", string_settings_sanskrit_checked_default, string_settings_sanskrit_checked_prefix_default));
                list_substitution_checkbox_settings.Add(new class_substitution("", string_settings_synonyms_checked_default, string_settings_synonyms_checked_prefix_default));
                list_substitution_checkbox_settings.Add(new class_substitution("", string_settings_translation_checked_default, string_settings_translation_checked_prefix_default));
                list_substitution_checkbox_settings.Add(new class_substitution("", string_settings_purport_checked_default, string_settings_purport_checked_prefix_default));

                for (int i = 0; i < list_substitution_checkbox_settings.Count; i++)
                {
                    if (list_string_settings_ini_contents.Count < 1)
                    {
                        string_line_read = null;
                    }
                    else
                    {
                        string_line_read = list_string_settings_ini_contents[0];
                        list_string_settings_ini_contents.RemoveAt(0);
                    }

                    if (string_line_read == null)
                    {
                        list_string_settings_ini_contents.Clear();
                        create_default_settings_ini();
                        string_line_read = list_substitution_checkbox_settings[i].string_replacement;
                    }

                    int_found_index = string_line_read.IndexOf(list_substitution_checkbox_settings[i].string_prefix);
                    string_parsed_text = "";

                    if ((int_found_index == -1) ||
                       (list_substitution_checkbox_settings[i].string_prefix.Length >= string_line_read.Length))
                    {
                        list_string_settings_ini_contents.Clear();
                        create_default_settings_ini();
                        string_line_read = list_substitution_checkbox_settings[i].string_replacement;
                        int_found_index = string_line_read.IndexOf(list_substitution_checkbox_settings[i].string_prefix);
                    }

                    if ((int_found_index + list_substitution_checkbox_settings[i].string_prefix.Length) < string_line_read.Length)
                    {
                        string_parsed_text = string_line_read.Substring(int_found_index + list_substitution_checkbox_settings[i].string_prefix.Length);
                    }

                    if (bool_just_load_regular_expressions_list == false)
                    {
                        if (string_parsed_text.Trim().ToLower() == "false")
                        {
                            list_checkbox_settings_file[i].Checked = false;
                        }
                        else if (string_parsed_text.Trim().ToLower() == "true")
                        {
                            list_checkbox_settings_file[i].Checked = true;
                        }
                        else
                        {
                            list_string_settings_ini_contents.Clear();
                            create_default_settings_ini();
                            string_line_read = list_substitution_checkbox_settings[i].string_replacement;
                            int_found_index = string_line_read.IndexOf(list_substitution_checkbox_settings[i].string_prefix);

                            if ((int_found_index != -1) &&
                                (int_found_index + list_substitution_checkbox_settings[i].string_prefix.Length) < string_line_read.Length)
                            {
                                string_parsed_text = string_line_read.Substring(int_found_index + list_substitution_checkbox_settings[i].string_prefix.Length);

                                if (string_parsed_text.Trim().ToLower() == "false")
                                {
                                    list_checkbox_settings_file[i].Checked = false;
                                }
                                else if (string_parsed_text.Trim().ToLower() == "true")
                                {
                                    list_checkbox_settings_file[i].Checked = true;
                                }
                            }
                        }
                    }
                }

                ////////////////////////////////////////////////////////////////////////////////

                list_substitutions_regex_from_settings.Clear();

                List<class_substitution> list_substitution_defaults = new List<class_substitution>();
                list_substitution_defaults.Add(new class_substitution("", string_settings_sanskrit_checked_substitution_default, string_settings_sanskrit_checked_substitution_prefix_default));
                list_substitution_defaults.Add(new class_substitution("", string_settings_synonyms_checked_substitution_default, string_settings_synonyms_checked_substitution_prefix_default));
                list_substitution_defaults.Add(new class_substitution("", string_settings_translation_checked_substitution_default, string_settings_translation_checked_substitution_prefix_default));
                list_substitution_defaults.Add(new class_substitution("", string_settings_purport_checked_substitution_default, string_settings_purport_checked_substitution_prefix_default));
                list_substitution_defaults.Add(new class_substitution("", string_settings_sanskrit_unchecked_substitution_default, string_settings_sanskrit_unchecked_substitution_prefix_default));
                list_substitution_defaults.Add(new class_substitution("", string_settings_synonyms_unchecked_substitution_default, string_settings_synonyms_unchecked_substitution_prefix_default));
                list_substitution_defaults.Add(new class_substitution("", string_settings_translation_unchecked_substitution_default, string_settings_translation_unchecked_substitution_prefix_default));
                list_substitution_defaults.Add(new class_substitution("", string_settings_purport_unchecked_substitution_default, string_settings_purport_unchecked_substitution_prefix_default));

                for (int i = 0; i < list_substitution_defaults.Count; i++)
                {
                    if (list_string_settings_ini_contents.Count < 1)
                    {
                        string_line_read = null;
                    }
                    else
                    {
                        string_line_read = list_string_settings_ini_contents[0];
                        list_string_settings_ini_contents.RemoveAt(0);
                    }

                    if (string_line_read == null)
                    {
                        list_string_settings_ini_contents.Clear();
                        create_default_settings_ini();
                        string_line_read = list_substitution_defaults[i].string_replacement;
                    }

                    int_found_index = string_line_read.IndexOf(list_substitution_defaults[i].string_prefix);
                    string_parsed_text = "";

                    if (
                        (int_found_index == -1) ||
                        (string_line_read.Length < list_substitution_defaults[i].string_prefix.Length))
                    {
                        list_string_settings_ini_contents.Clear();
                        create_default_settings_ini();
                        string_line_read = list_substitution_defaults[i].string_replacement;

                        int_found_index = string_line_read.IndexOf(list_substitution_defaults[i].string_prefix);
                    }

                    if (int_found_index != -1)
                    {
                        if ((int_found_index + list_substitution_defaults[i].string_prefix.Length) < string_line_read.Length)
                        {
                            string_parsed_text = string_line_read.Substring(int_found_index + list_substitution_defaults[i].string_prefix.Length);
                        }
                        else
                        {
                            string_parsed_text = "";
                        }

                        if (String.IsNullOrEmpty(string_parsed_text) == false)
                        {
                            int_delimiter_found_index = string_parsed_text.IndexOf(string_delimiter);

                            if (int_delimiter_found_index != -1)
                            {
                                if ((int_delimiter_found_index + string_delimiter.Length) < string_parsed_text.Length)
                                {
                                    list_substitutions_regex_from_settings.Add(new class_substitution(string_parsed_text.Substring(0, int_delimiter_found_index), string_parsed_text.Substring(int_delimiter_found_index + string_delimiter.Length), list_substitution_defaults[i].string_prefix));
                                }
                                else
                                {
                                    list_substitutions_regex_from_settings.Add(new class_substitution(string_parsed_text.Substring(0, int_delimiter_found_index), "", list_substitution_defaults[i].string_prefix));
                                }
                            }
                        }
                    }
                }

                ////////////////////////////////////////////////////////////////////////////////

                if (list_string_settings_ini_contents.Count < 1)
                {
                    string_line_read = null;
                }
                else
                {
                    string_line_read = list_string_settings_ini_contents[0];
                    list_string_settings_ini_contents.RemoveAt(0);
                }

                int_delimiter_found_index = -1;

                while (string_line_read != null)
                {
                    int_delimiter_found_index = string_line_read.IndexOf(string_delimiter);

                    if (int_delimiter_found_index != -1)
                    {
                        if ((int_delimiter_found_index + string_delimiter.Length) < string_line_read.Length)
                        {
                            list_substitutions_regex_from_settings.Add(new class_substitution(string_line_read.Substring(0, int_delimiter_found_index), string_line_read.Substring(int_delimiter_found_index + string_delimiter.Length)));
                        }
                        else
                        {
                            list_substitutions_regex_from_settings.Add(new class_substitution(string_line_read.Substring(0, int_delimiter_found_index), ""));
                        }
                    }

                    if (list_string_settings_ini_contents.Count < 1)
                    {
                        string_line_read = null;
                    }
                    else
                    {
                        string_line_read = list_string_settings_ini_contents[0];
                        list_string_settings_ini_contents.RemoveAt(0);
                    }
                }
            }
            catch (Exception exception_create_default_settings_ini)
            {
                exception_create_default_settings_ini.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        void create_default_settings_ini()
        {
            StreamWriter streamWriter_settings_ini = null;

            try
            {
                streamWriter_settings_ini = new StreamWriter(string_settings_ini_file_path);
                streamWriter_settings_ini.WriteLine(Path.GetFileName(string_substitutions_default_ini_filename));
                streamWriter_settings_ini.WriteLine(string_settings_sanskrit_checked_default);
                streamWriter_settings_ini.WriteLine(string_settings_synonyms_checked_default);
                streamWriter_settings_ini.WriteLine(string_settings_translation_checked_default);
                streamWriter_settings_ini.WriteLine(string_settings_purport_checked_default);
                streamWriter_settings_ini.WriteLine(string_settings_sanskrit_checked_substitution_default);
                streamWriter_settings_ini.WriteLine(string_settings_synonyms_checked_substitution_default);
                streamWriter_settings_ini.WriteLine(string_settings_translation_checked_substitution_default);
                streamWriter_settings_ini.WriteLine(string_settings_purport_checked_substitution_default);
                streamWriter_settings_ini.WriteLine(string_settings_sanskrit_unchecked_substitution_default);
                streamWriter_settings_ini.WriteLine(string_settings_synonyms_unchecked_substitution_default);
                streamWriter_settings_ini.WriteLine(string_settings_translation_unchecked_substitution_default);
                streamWriter_settings_ini.WriteLine(string_settings_purport_unchecked_substitution_default);

                for (int i = 0; i < string_regular_expressions_array_default.Length; i++)
                {
                    streamWriter_settings_ini.WriteLine(string_regular_expressions_array_default[i]);
                }

                streamWriter_settings_ini.Close();
            }
            catch (Exception exception_create_default_settings_ini)
            {
                exception_create_default_settings_ini.ToString();
            }

            if (streamWriter_settings_ini != null)
            {
                try
                {
                    streamWriter_settings_ini.Close();
                }
                catch (Exception exception_00)
                {
                    exception_00.ToString();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        void create_default_substitutions_apple_ini()
        {
            try
            {
                StreamWriter streamWriter_substitutions = new StreamWriter(string_substitutions_apple_ini_file_path);
                streamWriter_substitutions.WriteLine(@"sage" + string_delimiter + "sage");

                //
                // 50 entry Sanskrit alphabet minus two character consonant entries
                //
                streamWriter_substitutions.WriteLine(@"ai" + string_delimiter + @"eye");
                streamWriter_substitutions.WriteLine(@"au" + string_delimiter + @"ow");
                streamWriter_substitutions.WriteLine(@"a" + string_delimiter + @"u");
                streamWriter_substitutions.WriteLine(@"ā" + string_delimiter + @"awe");
                streamWriter_substitutions.WriteLine(@"i" + string_delimiter + @"ee");
                streamWriter_substitutions.WriteLine(@"ī" + string_delimiter + @"ee");
                streamWriter_substitutions.WriteLine(@"u" + string_delimiter + @"oo");
                streamWriter_substitutions.WriteLine(@"ū" + string_delimiter + @"oo");
                streamWriter_substitutions.WriteLine(@"ṛ" + string_delimiter + @"ri");
                streamWriter_substitutions.WriteLine(@"ṝ" + string_delimiter + @"ri");
                streamWriter_substitutions.WriteLine(@"ḷ" + string_delimiter + @"l");
                streamWriter_substitutions.WriteLine(@"l̐" + string_delimiter + @"l");
                streamWriter_substitutions.WriteLine(@"e" + string_delimiter + @"ay");
                streamWriter_substitutions.WriteLine(@"o" + string_delimiter + @"oh");
                streamWriter_substitutions.WriteLine(@"ṁ" + string_delimiter + @"ng");
                streamWriter_substitutions.WriteLine(@"ḥ" + string_delimiter + @"h");
                streamWriter_substitutions.WriteLine(@"k" + string_delimiter + @"k");
                streamWriter_substitutions.WriteLine(@"g" + string_delimiter + @"g");
                streamWriter_substitutions.WriteLine(@"ṅ" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"c" + string_delimiter + @"ch");
                streamWriter_substitutions.WriteLine(@"j" + string_delimiter + @"j");
                streamWriter_substitutions.WriteLine(@"ñ" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"ṭ" + string_delimiter + @"t");
                streamWriter_substitutions.WriteLine(@"ḍ" + string_delimiter + @"d");
                streamWriter_substitutions.WriteLine(@"ṇ" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"t" + string_delimiter + @"t");
                streamWriter_substitutions.WriteLine(@"d" + string_delimiter + @"d");
                streamWriter_substitutions.WriteLine(@"n" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"p" + string_delimiter + @"p");
                streamWriter_substitutions.WriteLine(@"b" + string_delimiter + @"b");
                streamWriter_substitutions.WriteLine(@"m" + string_delimiter + @"m");
                streamWriter_substitutions.WriteLine(@"y" + string_delimiter + @"y");
                streamWriter_substitutions.WriteLine(@"r" + string_delimiter + @"r");
                streamWriter_substitutions.WriteLine(@"l" + string_delimiter + @"l");
                streamWriter_substitutions.WriteLine(@"v" + string_delimiter + @"v");
                streamWriter_substitutions.WriteLine(@"ś" + string_delimiter + @"sh");
                streamWriter_substitutions.WriteLine(@"ṣ" + string_delimiter + @"sh");
                streamWriter_substitutions.WriteLine(@"s" + string_delimiter + @"s");
                streamWriter_substitutions.WriteLine(@"h" + string_delimiter + @"h");
                streamWriter_substitutions.WriteLine(@"'" + string_delimiter + @"'");
                streamWriter_substitutions.Close();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        void create_default_substitutions_kindle_ini()
        {
            try
            {
                StreamWriter streamWriter_substitutions = new StreamWriter(string_substitutions_kindle_ini_file_path);
                streamWriter_substitutions.WriteLine(@"satya-yuga" + string_delimiter + "sat ya you ga");
                streamWriter_substitutions.WriteLine(@"Kāmyaka" + string_delimiter + "kam yuck uh");
                streamWriter_substitutions.WriteLine(@"Vrihadashwa" + string_delimiter + "vree huh dush wa");
                streamWriter_substitutions.WriteLine(@"Vāyu" + string_delimiter + "va you");
                streamWriter_substitutions.WriteLine(@"Siddha" + string_delimiter + "sid huh");
                streamWriter_substitutions.WriteLine(@"Cāraṇa" + string_delimiter + "char uhnuh");
                streamWriter_substitutions.WriteLine(@"Nāga" + string_delimiter + "naguh");
                streamWriter_substitutions.WriteLine(@"Rudra" + string_delimiter + "roodruh");
                streamWriter_substitutions.WriteLine(@"Daitya" + string_delimiter + "daityuh");
                streamWriter_substitutions.WriteLine(@"Dānava" + string_delimiter + "dahnuvuh");
                streamWriter_substitutions.WriteLine(@"Guhaka" + string_delimiter + "goo huckuh");
                streamWriter_substitutions.WriteLine(@"Dhaumya" + string_delimiter + "dome ya");
                streamWriter_substitutions.WriteLine(@"Rākṣasa" + string_delimiter + "rock shasuh");
                streamWriter_substitutions.WriteLine(@"Amarāvatī" + string_delimiter + "uh mara watea");
                streamWriter_substitutions.WriteLine(@"Yayāti" + string_delimiter + "ya ya tee");
                streamWriter_substitutions.WriteLine(@"Pūrurava" + string_delimiter + "poor o rava");
                streamWriter_substitutions.WriteLine(@"Sabha" + string_delimiter + "sub ha");
                streamWriter_substitutions.WriteLine(@"Gandharava" + string_delimiter + "gan dar uh was");
                streamWriter_substitutions.WriteLine(@"Badarīkā" + string_delimiter + "bad ah reek ah");
                streamWriter_substitutions.WriteLine(@"Kaurava" + string_delimiter + "co ravuh");
                streamWriter_substitutions.WriteLine(@"Vyāsadeva" + string_delimiter + "v yasadevuh");
                streamWriter_substitutions.WriteLine(@"Sañjaya" + string_delimiter + "son jai uh");
                streamWriter_substitutions.WriteLine(@"Himalaya" + string_delimiter + "him uh lay uh");
                streamWriter_substitutions.WriteLine(@"Arghya" + string_delimiter + "arg ya");
                streamWriter_substitutions.WriteLine(@"Nala" + string_delimiter + "nal uh");
                streamWriter_substitutions.WriteLine(@"svayaṁvara" + string_delimiter + "swa young vara");
                streamWriter_substitutions.WriteLine(@"sage" + string_delimiter + "sayje");
                streamWriter_substitutions.WriteLine(@"mathurā" + string_delimiter + "ma tour ah");
                streamWriter_substitutions.WriteLine(@"duryodhana" + string_delimiter + @"door yo done");
                streamWriter_substitutions.WriteLine(@"adhiratha" + string_delimiter + @"odd he rut huh");
                streamWriter_substitutions.WriteLine(@"droṇācārya" + string_delimiter + @"drone ah char ya");
                streamWriter_substitutions.WriteLine(@"droṇa" + string_delimiter + @"drone uh");
                streamWriter_substitutions.WriteLine(@"yogi" + string_delimiter + @"yo ghee");
                streamWriter_substitutions.WriteLine(@"yogī" + string_delimiter + @"yo ghee");
                streamWriter_substitutions.WriteLine(@"mahābhārata" + string_delimiter + @"ma ha bar uh tuh");
                streamWriter_substitutions.WriteLine(@"govardhana" + string_delimiter + @"go ver done uh");
                streamWriter_substitutions.WriteLine(@"raj" + string_delimiter + @"raj");
                streamWriter_substitutions.WriteLine(@"loka" + string_delimiter + @"lowka");
                streamWriter_substitutions.WriteLine(@"mahā" + string_delimiter + @"ma ha");
                streamWriter_substitutions.WriteLine(@"rab" + string_delimiter + @"rub");
                streamWriter_substitutions.WriteLine(@"jña" + string_delimiter + @"ni ya");
                streamWriter_substitutions.WriteLine(@"vai" + string_delimiter + @"vai");
                streamWriter_substitutions.WriteLine(@"cai" + string_delimiter + @"chai");
                streamWriter_substitutions.WriteLine(@"tan" + string_delimiter + @"ton");
                streamWriter_substitutions.WriteLine(@"tt" + string_delimiter + @"t");
                streamWriter_substitutions.WriteLine(@"og" + string_delimiter + @"oh g");
                streamWriter_substitutions.WriteLine(@"gī" + string_delimiter + @"ghee");
                streamWriter_substitutions.WriteLine(@"gi" + string_delimiter + @"ghee");
                streamWriter_substitutions.WriteLine(@"hu" + string_delimiter + @" who ");
                streamWriter_substitutions.WriteLine(@"sv" + string_delimiter + @"sw"); 
                streamWriter_substitutions.WriteLine(@"(?<=^|[\s\p{P}])al" + string_delimiter + @"uh l");
                streamWriter_substitutions.WriteLine(@"(?<=a)h" + string_delimiter + @" ");
                streamWriter_substitutions.WriteLine(@"(?<=^|[\s\p{P}])a" + string_delimiter + @"uh");
                streamWriter_substitutions.WriteLine(@"sa(?<s>|s|'s)(?=[\s\p{P}]|$)" + string_delimiter + @"sa${s}");
                streamWriter_substitutions.WriteLine(@"a(?<s>|s|'s)(?=[\s\p{P}]|$)" + string_delimiter + @"uh${s}");
                streamWriter_substitutions.WriteLine(@"(?<=^|[\s\p{P}])hā" + string_delimiter + @"ha ");
                streamWriter_substitutions.WriteLine(@"(?<=^|[\s\p{P}])ha" + string_delimiter + @"ha ");
                streamWriter_substitutions.WriteLine(@"re(?<s>|s|'s)(?=[\s\p{P}]|$)" + string_delimiter + @"ray${s}");
                streamWriter_substitutions.WriteLine(@"(?<=[\w-[aāiīuūṛṝḷl̐eaioau]])(?:|h)a(?=\w{2,})" + string_delimiter + @"a ");                              

                //
                // 50 entry Sanskrit alphabet minus two character consonant entries
                //
                streamWriter_substitutions.WriteLine(@"ai" + string_delimiter + @"eye");
                streamWriter_substitutions.WriteLine(@"au" + string_delimiter + @"ow");
                streamWriter_substitutions.WriteLine(@"a" + string_delimiter + @"u");
                streamWriter_substitutions.WriteLine(@"ā" + string_delimiter + @"awe");
                streamWriter_substitutions.WriteLine(@"i" + string_delimiter + @"ee");
                streamWriter_substitutions.WriteLine(@"ī" + string_delimiter + @"ee");
                streamWriter_substitutions.WriteLine(@"u" + string_delimiter + @"oo");
                streamWriter_substitutions.WriteLine(@"ū" + string_delimiter + @"oo");
                streamWriter_substitutions.WriteLine(@"ṛ" + string_delimiter + @"ri");
                streamWriter_substitutions.WriteLine(@"ṝ" + string_delimiter + @"ri");
                streamWriter_substitutions.WriteLine(@"ḷ" + string_delimiter + @"l");
                streamWriter_substitutions.WriteLine(@"l̐" + string_delimiter + @"l");                
                streamWriter_substitutions.WriteLine(@"e" + string_delimiter + @"ay");
                streamWriter_substitutions.WriteLine(@"o" + string_delimiter + @"oh");
                streamWriter_substitutions.WriteLine(@"ṁ" + string_delimiter + @"ng");
                streamWriter_substitutions.WriteLine(@"ḥ" + string_delimiter + @"h");
                streamWriter_substitutions.WriteLine(@"k" + string_delimiter + @"k");
                streamWriter_substitutions.WriteLine(@"g" + string_delimiter + @"g");
                streamWriter_substitutions.WriteLine(@"ṅ" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"c" + string_delimiter + @"ch");
                streamWriter_substitutions.WriteLine(@"j" + string_delimiter + @"j");
                streamWriter_substitutions.WriteLine(@"ñ" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"ṭ" + string_delimiter + @"t");
                streamWriter_substitutions.WriteLine(@"ḍ" + string_delimiter + @"d");
                streamWriter_substitutions.WriteLine(@"ṇ" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"t" + string_delimiter + @"t");
                streamWriter_substitutions.WriteLine(@"d" + string_delimiter + @"d");
                streamWriter_substitutions.WriteLine(@"n" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"p" + string_delimiter + @"p");
                streamWriter_substitutions.WriteLine(@"b" + string_delimiter + @"b");
                streamWriter_substitutions.WriteLine(@"m" + string_delimiter + @"m");
                streamWriter_substitutions.WriteLine(@"y" + string_delimiter + @"y");
                streamWriter_substitutions.WriteLine(@"r" + string_delimiter + @"r");
                streamWriter_substitutions.WriteLine(@"l" + string_delimiter + @"l");
                streamWriter_substitutions.WriteLine(@"v" + string_delimiter + @"v");
                streamWriter_substitutions.WriteLine(@"ś" + string_delimiter + @"sh");
                streamWriter_substitutions.WriteLine(@"ṣ" + string_delimiter + @"sh");
                streamWriter_substitutions.WriteLine(@"s" + string_delimiter + @"s");
                streamWriter_substitutions.WriteLine(@"h" + string_delimiter + @"h");
                streamWriter_substitutions.WriteLine(@"'" + string_delimiter + @"'");
                streamWriter_substitutions.Close();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        void create_default_substitutions_microsoft_ini()
        {
            try
            {
                StreamWriter streamWriter_substitutions = new StreamWriter(string_substitutions_microsoft_ini_file_path);
                streamWriter_substitutions.WriteLine(@"sage" + string_delimiter + "sage");
                
                //
                // 50 entry Sanskrit alphabet minus two character consonant entries
                //
                streamWriter_substitutions.WriteLine(@"ai" + string_delimiter + @"eye");
                streamWriter_substitutions.WriteLine(@"au" + string_delimiter + @"ow");
                streamWriter_substitutions.WriteLine(@"a" + string_delimiter + @"u");
                streamWriter_substitutions.WriteLine(@"ā" + string_delimiter + @"awe");
                streamWriter_substitutions.WriteLine(@"i" + string_delimiter + @"ee");
                streamWriter_substitutions.WriteLine(@"ī" + string_delimiter + @"ee");
                streamWriter_substitutions.WriteLine(@"u" + string_delimiter + @"oo");
                streamWriter_substitutions.WriteLine(@"ū" + string_delimiter + @"oo");
                streamWriter_substitutions.WriteLine(@"ṛ" + string_delimiter + @"ri");
                streamWriter_substitutions.WriteLine(@"ṝ" + string_delimiter + @"ri");
                streamWriter_substitutions.WriteLine(@"ḷ" + string_delimiter + @"l");
                streamWriter_substitutions.WriteLine(@"l̐" + string_delimiter + @"l");
                streamWriter_substitutions.WriteLine(@"e" + string_delimiter + @"ay");
                streamWriter_substitutions.WriteLine(@"o" + string_delimiter + @"oh");
                streamWriter_substitutions.WriteLine(@"ṁ" + string_delimiter + @"ng");
                streamWriter_substitutions.WriteLine(@"ḥ" + string_delimiter + @"h");
                streamWriter_substitutions.WriteLine(@"k" + string_delimiter + @"k");
                streamWriter_substitutions.WriteLine(@"g" + string_delimiter + @"g");
                streamWriter_substitutions.WriteLine(@"ṅ" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"c" + string_delimiter + @"ch");
                streamWriter_substitutions.WriteLine(@"j" + string_delimiter + @"j");
                streamWriter_substitutions.WriteLine(@"ñ" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"ṭ" + string_delimiter + @"t");
                streamWriter_substitutions.WriteLine(@"ḍ" + string_delimiter + @"d");
                streamWriter_substitutions.WriteLine(@"ṇ" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"t" + string_delimiter + @"t");
                streamWriter_substitutions.WriteLine(@"d" + string_delimiter + @"d");
                streamWriter_substitutions.WriteLine(@"n" + string_delimiter + @"n");
                streamWriter_substitutions.WriteLine(@"p" + string_delimiter + @"p");
                streamWriter_substitutions.WriteLine(@"b" + string_delimiter + @"b");
                streamWriter_substitutions.WriteLine(@"m" + string_delimiter + @"m");
                streamWriter_substitutions.WriteLine(@"y" + string_delimiter + @"y");
                streamWriter_substitutions.WriteLine(@"r" + string_delimiter + @"r");
                streamWriter_substitutions.WriteLine(@"l" + string_delimiter + @"l");
                streamWriter_substitutions.WriteLine(@"v" + string_delimiter + @"v");
                streamWriter_substitutions.WriteLine(@"ś" + string_delimiter + @"sh");
                streamWriter_substitutions.WriteLine(@"ṣ" + string_delimiter + @"sh");
                streamWriter_substitutions.WriteLine(@"s" + string_delimiter + @"s");
                streamWriter_substitutions.WriteLine(@"h" + string_delimiter + @"h");
                streamWriter_substitutions.WriteLine(@"'" + string_delimiter + @"'");
                streamWriter_substitutions.Close();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void button_advanced_handler()
        {
            try
            {
                progressBar_convert.Value = 0;

                if (button_advanced.Text == "Advanced")
                {
                    this.Height = int_dialog_height_max;
                    button_advanced.Text = "Hide Details";
                    substitutions_fill_sanskrit_alphabet_textboxes_from_filename(string_currently_selected_combobox_filename);
                    panel_advanced.Visible = true;
                }
                else
                {
                    substitution_save_changes_to_currently_selected_file();

                    if (textBox_displayed_file.Visible == true)
                    {
                        label_sanskrit_without_diacritics.Visible = false;
                        label_settings.Visible = false;
                        update_controls();
                    }

                    this.Height = int_dialog_height_min;
                    button_advanced.Text = "Advanced";
                    panel_advanced.Visible = false;
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void button_advanced_Click(object sender, EventArgs e)
        {
            try
            {
                button_advanced_handler();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private DialogResult substitution_save_changes_to_currently_selected_file()
        {
            try
            {
                class_substitution substitution_found = null;
                String string_replacement_found;
                bool bool_value_changed = false;

                while (true)
                {
                    List<class_substitution> list_substitutions_from_file_unsorted = substitutions_get_from_file_unsorted(AppDomain.CurrentDomain.BaseDirectory + Path.GetFileName(string_currently_selected_combobox_filename));

                    if (list_substitutions_from_file_unsorted.Count > 0)
                    {
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_00.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_00.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_01.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_01.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_02.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_02.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_03.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_03.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_04.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_04.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_05.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_05.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_06.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_06.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_07.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_07.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_08.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_08.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_09.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_09.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_10.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_10.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_11.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_11.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_12.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_12.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_13.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_13.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_14.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_14.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_15.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_15.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_16.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_16.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_17.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_17.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_18.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_18.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_19.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_19.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_20.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_20.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_21.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_21.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_22.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_22.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_23.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_23.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_24.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_24.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_25.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_25.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_26.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_26.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_27.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_27.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_28.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_28.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_29.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_29.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_30.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_30.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_31.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_31.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_32.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_32.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_33.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_33.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_34.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_34.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_35.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_35.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_36.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_36.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_37.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_37.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_38.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_38.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_39.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_39.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_40.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_40.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_41.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_41.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_42.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_42.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_43.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_43.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_44.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_44.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_45.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_45.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_46.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_46.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_47.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_47.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_48.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_48.Text != string_replacement_found) { bool_value_changed = true; break; }
                        string_replacement_found = ""; substitution_found = list_substitutions_from_file_unsorted.Find(class_substitution => class_substitution.string_input == label_49.Text); if (substitution_found != null) { string_replacement_found = substitution_found.string_replacement; } if (textBox_49.Text != string_replacement_found) { bool_value_changed = true; break; }
                    }
                    break;
                };

                if (bool_value_changed == true)
                {
                    DialogResult dialogResult_defaults = MessageBox.Show("Hare Kṛṣṇa! Do you want to save changes to " + Path.GetFileName(string_currently_selected_combobox_filename) + " ?", "Save Substitution Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (dialogResult_defaults == DialogResult.Yes)
                    {
                        substitutions_save_sanskrit_alphabet_textboxes_to_file(string_currently_selected_combobox_filename);
                        return DialogResult.Yes;
                    }
                    else if (dialogResult_defaults == DialogResult.Cancel)
                    {
                        return DialogResult.Cancel;
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }

            return DialogResult.No;
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void substitutions_disable_checkboxes()
        {
            try
            {
                checkBox_sanskrit.Enabled = false;
                checkBox_synonyms.Enabled = false;
                checkBox_translation.Enabled = false;
                checkBox_purport.Enabled = false;
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void substitutions_enable_checkboxes()
        {
            try
            {
                checkBox_sanskrit.Enabled = true;
                checkBox_synonyms.Enabled = true;
                checkBox_translation.Enabled = true;
                checkBox_purport.Enabled = true;
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void substitutions_disable_sanskrit_alphabet_textboxes()
        {
            try
            {
                textBox_00.Enabled = false;
                textBox_01.Enabled = false;
                textBox_02.Enabled = false;
                textBox_03.Enabled = false;
                textBox_04.Enabled = false;
                textBox_05.Enabled = false;
                textBox_06.Enabled = false;
                textBox_07.Enabled = false;
                textBox_08.Enabled = false;
                textBox_09.Enabled = false;
                textBox_10.Enabled = false;
                textBox_11.Enabled = false;
                textBox_12.Enabled = false;
                textBox_13.Enabled = false;
                textBox_14.Enabled = false;
                textBox_15.Enabled = false;
                textBox_16.Enabled = false;
                textBox_17.Enabled = false;
                textBox_18.Enabled = false;
                textBox_19.Enabled = false;
                textBox_20.Enabled = false;
                textBox_21.Enabled = false;
                textBox_22.Enabled = false;
                textBox_23.Enabled = false;
                textBox_24.Enabled = false;
                textBox_25.Enabled = false;
                textBox_26.Enabled = false;
                textBox_27.Enabled = false;
                textBox_28.Enabled = false;
                textBox_29.Enabled = false;
                textBox_30.Enabled = false;
                textBox_31.Enabled = false;
                textBox_32.Enabled = false;
                textBox_33.Enabled = false;
                textBox_34.Enabled = false;
                textBox_35.Enabled = false;
                textBox_36.Enabled = false;
                textBox_37.Enabled = false;
                textBox_38.Enabled = false;
                textBox_39.Enabled = false;
                textBox_40.Enabled = false;
                textBox_41.Enabled = false;
                textBox_42.Enabled = false;
                textBox_43.Enabled = false;
                textBox_44.Enabled = false;
                textBox_45.Enabled = false;
                textBox_46.Enabled = false;
                textBox_47.Enabled = false;
                textBox_48.Enabled = false;
                textBox_49.Enabled = false;
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void substitutions_enable_sanskrit_alphabet_textboxes()
        {
            try
            {
                textBox_00.Enabled = true;
                textBox_01.Enabled = true;
                textBox_02.Enabled = true;
                textBox_03.Enabled = true;
                textBox_04.Enabled = true;
                textBox_05.Enabled = true;
                textBox_06.Enabled = true;
                textBox_07.Enabled = true;
                textBox_08.Enabled = true;
                textBox_09.Enabled = true;
                textBox_10.Enabled = true;
                textBox_11.Enabled = true;
                textBox_12.Enabled = true;
                textBox_13.Enabled = true;
                textBox_14.Enabled = true;
                textBox_15.Enabled = true;
                textBox_16.Enabled = true;
                textBox_17.Enabled = true;
                textBox_18.Enabled = true;
                textBox_19.Enabled = true;
                textBox_20.Enabled = true;
                textBox_21.Enabled = true;
                textBox_22.Enabled = true;
                textBox_23.Enabled = true;
                textBox_24.Enabled = true;
                textBox_25.Enabled = true;
                textBox_26.Enabled = true;
                textBox_27.Enabled = true;
                textBox_28.Enabled = true;
                textBox_29.Enabled = true;
                textBox_30.Enabled = true;
                textBox_31.Enabled = true;
                textBox_32.Enabled = true;
                textBox_33.Enabled = true;
                textBox_34.Enabled = true;
                textBox_35.Enabled = true;
                textBox_36.Enabled = true;
                textBox_37.Enabled = true;
                textBox_38.Enabled = true;
                textBox_39.Enabled = true;
                textBox_40.Enabled = true;
                textBox_41.Enabled = true;
                textBox_42.Enabled = true;
                textBox_43.Enabled = true;
                textBox_44.Enabled = true;
                textBox_45.Enabled = true;
                textBox_46.Enabled = true;
                textBox_47.Enabled = true;
                textBox_48.Enabled = true;
                textBox_49.Enabled = true;
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void comboBox_select_speech_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_select_substitutions_filename.SelectedIndex == -1)
                {
                    return;
                }

                progressBar_convert.Value = 0;

                if (String.IsNullOrEmpty(string_currently_selected_combobox_filename) == false)
                {
                    substitution_save_changes_to_currently_selected_file();
                }

                string_currently_selected_combobox_filename = comboBox_select_substitutions_filename.Text;

                if (string_currently_selected_combobox_filename == Path.GetFileName(string_substitutions_none_ini_file_path))
                {
                    update_controls();
                    return;
                }

                update_controls();
                
                substitutions_fill_sanskrit_alphabet_textboxes_from_filename(string_currently_selected_combobox_filename);

                if (textBox_displayed_file.Visible == true)
                {
                    textBox_displayed_file.Text = "";

                    try
                    {
                        textBox_displayed_file.Text = File.ReadAllText(string_currently_selected_combobox_filename);
                    }
                    catch (Exception exception_00)
                    {
                        exception_00.ToString();
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void button_select_input_file_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar_convert.Value = 0;

                if (File.Exists(textBox_input_file_path.Text) == true)
                {
                    openFileDialog_input.InitialDirectory = Path.GetDirectoryName(textBox_input_file_path.Text) + @"\";
                }
                else
                {
                    openFileDialog_input.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                }

                openFileDialog_input.FileName = textBox_input_file_path.Text;
                openFileDialog_input.Title = "Select Sanskrit Input";
                DialogResult dialogResult_input_file = openFileDialog_input.ShowDialog();

                if (dialogResult_input_file == DialogResult.OK)
                {
                    if (
                        (Path.GetExtension(openFileDialog_input.FileName).ToLower() != ".rtf") &&
                        (Path.GetExtension(openFileDialog_input.FileName).ToLower() != ".txt"))
                    {
                        MessageBox.Show("Hare Kṛṣṇa! Only VedaBase exported RTF files and text files are supported at this time.", "Invalid Sanskrit Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        textBox_input_file_path.Text = openFileDialog_input.FileName;
                        string_input_file_path = textBox_input_file_path.Text;
                        textBox_input_file_path.SelectionStart = textBox_input_file_path.Text.Length;
                        textBox_input_file_path.ScrollToCaret();
                        set_output_file_path();
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void set_output_file_path()
        {
            try
            {
                if (comboBox_select_substitutions_filename.Text == Path.GetFileName(string_substitutions_none_ini_file_path))
                {
                    String string_filename_part_prefix = "";

                    if (checkBox_sanskrit.Checked == true)
                    {
                        string_filename_part_prefix += "SA_";
                    }

                    if (checkBox_synonyms.Checked == true)
                    {
                        string_filename_part_prefix += "SY_";
                    }

                    if (checkBox_translation.Checked == true)
                    {
                        string_filename_part_prefix += "TR_";
                    }

                    if (checkBox_purport.Checked == true)
                    {
                        string_filename_part_prefix += "PU_";
                    }

                    string_filename_part_prefix = string_filename_part_prefix.Replace("__", "_");

                    if (String.IsNullOrEmpty(string_filename_part_prefix) == true)
                    {
                        string_filename_part_prefix = "_";
                    }

                    textBox_output_file_path.Text = Path.GetDirectoryName(textBox_input_file_path.Text) + @"\" + string_output_filename_prefix + string_filename_part_prefix + Path.GetFileNameWithoutExtension(textBox_input_file_path.Text) + ".txt";
                }
                else
                {
                    textBox_output_file_path.Text = Path.GetDirectoryName(textBox_input_file_path.Text) + @"\" + string_output_filename_prefix + Path.GetFileNameWithoutExtension(comboBox_select_substitutions_filename.Text).Replace(string_substitutions_filename_prefix, "") + "_" + Path.GetFileNameWithoutExtension(textBox_input_file_path.Text) + ".txt";
                }

                string_output_file_path = textBox_output_file_path.Text;
                textBox_output_file_path.SelectionStart = textBox_output_file_path.Text.Length;
                textBox_output_file_path.ScrollToCaret();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void button_select_output_file_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar_convert.Value = 0;

                try
                {
                    if (File.Exists(textBox_output_file_path.Text) == true)
                    {
                        saveFileDialog_output.FileName = textBox_output_file_path.Text;

                    }
                }
                catch (Exception exception_00)
                {
                    exception_00.ToString();
                }

                saveFileDialog_output.Title = "Select Speech Output";
                DialogResult dialogResult_output_file = saveFileDialog_output.ShowDialog();

                if (dialogResult_output_file == DialogResult.OK)
                {
                    textBox_output_file_path.Text = saveFileDialog_output.FileName;
                    string_output_file_path = textBox_output_file_path.Text;
                    textBox_output_file_path.SelectionStart = textBox_output_file_path.Text.Length;
                    textBox_output_file_path.ScrollToCaret();
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void save_to_settings_ini()
        {
            StreamWriter streamWriter_settings_ini = null;

            try
            {
                streamWriter_settings_ini = new StreamWriter(string_settings_ini_file_path);

                if (String.IsNullOrEmpty(comboBox_select_substitutions_filename.Text) == true)
                {
                    streamWriter_settings_ini.WriteLine(Path.GetFileName(string_substitutions_none_ini_file_path));
                }
                else
                {
                    streamWriter_settings_ini.WriteLine(comboBox_select_substitutions_filename.Text);
                }

                streamWriter_settings_ini.WriteLine(string_settings_sanskrit_checked_prefix_default + checkBox_sanskrit.Checked.ToString());
                streamWriter_settings_ini.WriteLine(string_settings_synonyms_checked_prefix_default + checkBox_synonyms.Checked.ToString());
                streamWriter_settings_ini.WriteLine(string_settings_translation_checked_prefix_default + checkBox_translation.Checked.ToString());
                streamWriter_settings_ini.WriteLine(string_settings_purport_checked_prefix_default + checkBox_purport.Checked.ToString());

                if (list_substitutions_regex_from_settings.Count < 1)
                {
                    add_default_list_substitutions_regular_expressions();
                }

                for (int i = 0; i < list_substitutions_regex_from_settings.Count; i++)
                {
                    streamWriter_settings_ini.WriteLine(list_substitutions_regex_from_settings[i].string_input + string_delimiter + list_substitutions_regex_from_settings[i].string_replacement);
                }

                streamWriter_settings_ini.Close();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }

            if (streamWriter_settings_ini != null)
            {
                try
                {
                    streamWriter_settings_ini.Close();
                }
                catch (Exception exception_00)
                {
                    exception_00.ToString();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (substitution_save_changes_to_currently_selected_file() == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                save_to_settings_ini();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        void substitutions_save_sanskrit_alphabet_textboxes_to_file(String string_file_path_input)
        {
            try
            {
                List<class_substitution> list_substitutions_from_file_unsorted = substitutions_get_from_file_unsorted(string_file_path_input);

                //
                // Remove the values currently in the custom replacement list that were read from the custom replacement file
                //
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[00]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[01]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[02]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[03]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[04]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[05]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[06]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[07]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[08]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[09]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[10]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[11]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[12]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[13]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[14]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[15]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[16]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[17]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[18]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[19]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[20]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[21]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[22]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[23]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[24]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[25]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[26]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[27]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[28]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[29]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[30]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[31]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[32]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[33]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[34]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[35]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[36]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[37]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[38]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[39]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[40]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[41]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[42]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[43]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[44]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[45]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[46]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[47]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[48]);
                list_substitutions_from_file_unsorted.RemoveAll(class_substitution => class_substitution.string_input == string_50_sanskrit_letters_array[49]);
                
                //
                //Add the two character Sanskrit letters first
                //
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[11], textBox_11.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[13], textBox_13.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[17], textBox_17.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[19], textBox_19.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[22], textBox_22.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[24], textBox_24.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[27], textBox_27.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[29], textBox_29.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[32], textBox_32.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[34], textBox_34.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[37], textBox_37.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[39], textBox_39.Text, "", RegexOptions.None, false));

                //
                // Add the single character Sanskrit letters next
                //
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[00], textBox_00.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[01], textBox_01.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[02], textBox_02.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[03], textBox_03.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[04], textBox_04.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[05], textBox_05.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[06], textBox_06.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[07], textBox_07.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[08], textBox_08.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[09], textBox_09.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[10], textBox_10.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[12], textBox_12.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[14], textBox_14.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[15], textBox_15.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[16], textBox_16.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[18], textBox_18.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[20], textBox_20.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[21], textBox_21.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[23], textBox_23.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[25], textBox_25.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[26], textBox_26.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[28], textBox_28.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[30], textBox_30.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[31], textBox_31.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[33], textBox_33.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[35], textBox_35.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[36], textBox_36.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[38], textBox_38.Text, "", RegexOptions.None, false));
                
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[40], textBox_40.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[41], textBox_41.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[42], textBox_42.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[43], textBox_43.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[44], textBox_44.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[45], textBox_45.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[46], textBox_46.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[47], textBox_47.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[48], textBox_48.Text, "", RegexOptions.None, false));
                list_substitutions_from_file_unsorted.Add(new class_substitution(string_50_sanskrit_letters_array[49], textBox_49.Text, "", RegexOptions.None, false));
                
                //List<class_substitution> list_substitutions_from_file_sorted_descending = new List<class_substitution>();
                ////
                //// Sort the custom replacement list alphabetically
                ////
                //foreach (class_substitution substitution in substitutions_sort_by_original_string_length_descending(list_substitutions_from_file_unsorted))
                //{
                //    list_substitutions_from_file_sorted_descending.Add(substitution);
                //}

                StreamWriter streamWriter_output = new StreamWriter(string_file_path_input);

                for (int i = 0; i < list_substitutions_from_file_unsorted.Count; i++)
                {
                    streamWriter_output.WriteLine(list_substitutions_from_file_unsorted[i].string_input + string_delimiter + list_substitutions_from_file_unsorted[i].string_replacement);
                }

                streamWriter_output.Close();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (button_save.Text == "Save")
                {
                    try
                    {

                        if (
                            (label_settings.Visible == true) ||
                            (label_sanskrit_without_diacritics.Visible == true))
                        {
                            if (label_settings.Visible == true)
                            {
                                File.WriteAllText(string_settings_ini_file_path, textBox_displayed_file.Text);
                            }
                            else
                            {
                                File.WriteAllText(string_sanskrit_without_diacritics_ini_file_path, textBox_displayed_file.Text);
                                list_substitutions_sanskrit_without_diacritics.Clear();
                            }

                            label_settings.Visible = false;
                            label_sanskrit_without_diacritics.Visible = false;

                            load_settings_ini();
                        }
                        else
                        {
                            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + string_currently_selected_combobox_filename, textBox_displayed_file.Text);
                        }

                        update_controls();
                    }
                    catch (Exception exception_00)
                    {
                        exception_00.ToString();
                    }
                }
                else
                {
                    substitution_save_changes_to_currently_selected_file();
                    //
                    // Clicked "Words" button
                    //
                    try
                    {
                        textBox_displayed_file.Text = "";

                        if (File.Exists(string_sanskrit_without_diacritics_ini_file_path) == false)
                        {
                            create_sanskrit_without_diacritics_default_file();
                        }

                        textBox_displayed_file.Text = File.ReadAllText(string_sanskrit_without_diacritics_ini_file_path);

                        label_settings.Visible = false;
                        label_sanskrit_without_diacritics.Visible = true;
                        update_controls();
                    }
                    catch (Exception exception_00)
                    {
                        exception_00.ToString();
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void Form_main_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // Extract the data from the DataObject-Container into a string list
                string[] string_file_paths = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                // Do something with the data...
                list_string_input_files_to_process.Clear();

                // For example add all files into a simple label control:
                foreach (string string_file_path in string_file_paths)
                {
                    if (File.Exists(string_file_path) == true)
                    {
                        list_string_input_files_to_process.Add(string_file_path);
                    }
                }

                if (list_string_input_files_to_process.Count > 0)
                {
                    if (list_substitutions_sanskrit_without_diacritics.Count < 1)
                    {
                        reload_sanskrit_without_diacritics();
                    }

                    start_conversion_thread();
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void Form_main_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                // Check if the Dataformat of the data can be accepted
                // (we only accept file drops from Explorer, etc.)
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy; // Okay
                }
                else
                {
                    e.Effect = DragDropEffects.None; // Unknown data, ignore it
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void Form_main_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void button_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (button_cancel.Text == "Cancel")
                {
                    label_settings.Visible = false;
                    label_sanskrit_without_diacritics.Visible = false;
                    update_controls();
                }
                else
                {
                    substitution_save_changes_to_currently_selected_file();
                    //
                    // Clicked "Substitutions"
                    //
                    try
                    {
                        if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + string_currently_selected_combobox_filename) == true)
                        {
                            textBox_displayed_file.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + string_currently_selected_combobox_filename);
                        }

                        button_settings.Enabled = false;
                        button_cancel.Text = "Cancel";
                        button_save.Text = "Save";
                        button_save.Font = new Font(button_save.Font, FontStyle.Bold);
                        button_save.Select();
                        textBox_displayed_file.Visible = true;
                    }
                    catch (Exception exception_00)
                    {
                        exception_00.ToString();
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void Form_main_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (bool_stop_conversion == false)
                    {
                        bool_stop_conversion = true;
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void start_conversion_thread()
        {
            try
            {
                bool_stop_conversion = false;

                if (list_string_input_files_to_process.Count > 0)
                {
                    if (File.Exists(list_string_input_files_to_process[0]) == true)
                    {
                        if (
                            (Path.GetExtension(list_string_input_files_to_process[0]).ToLower() != ".rtf") &&
                            (Path.GetExtension(list_string_input_files_to_process[0]).ToLower() != ".txt"))
                        {
                            MessageBox.Show("Hare Kṛṣṇa! Only VedaBase exported RTF files and text files are supported at this time.", "Invalid Sanskrit Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        textBox_input_file_path.Text = list_string_input_files_to_process[0];
                        string_input_file_path = textBox_input_file_path.Text;
                        textBox_input_file_path.SelectionStart = textBox_input_file_path.Text.Length;
                        textBox_input_file_path.ScrollToCaret();
                        set_output_file_path();
                    }
                }

                if (File.Exists(textBox_input_file_path.Text) == false)
                {
                    openFileDialog_input.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    openFileDialog_input.FileName = textBox_input_file_path.Text;
                    openFileDialog_input.Title = "Select Sanskrit Input";
                    DialogResult dialogResult_input_file = openFileDialog_input.ShowDialog();

                    if (dialogResult_input_file == DialogResult.OK)
                    {
                        if (
                            (Path.GetExtension(openFileDialog_input.FileName).ToLower() != ".rtf") &&
                            (Path.GetExtension(openFileDialog_input.FileName).ToLower() != ".txt"))
                        {
                            MessageBox.Show("Hare Kṛṣṇa! Only VedaBase exported RTF files and text files are supported at this time.", "Invalid Sanskrit Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        textBox_input_file_path.Text = openFileDialog_input.FileName;
                        string_input_file_path = textBox_input_file_path.Text;
                        textBox_input_file_path.SelectionStart = textBox_input_file_path.Text.Length;
                        textBox_input_file_path.ScrollToCaret();
                        set_output_file_path();
                    }
                    else
                    {
                        return;
                    }
                }

                disable_all_controls();
                load_settings_ini(true);
                backgroundWorker_convert.RunWorkerAsync();
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void disable_all_controls()
        {
            try
            {
                button_advanced.Enabled = false;
                comboBox_select_substitutions_filename.Enabled = false;
                button_select_input_file.Enabled = false;
                button_select_output_file.Enabled = false;
                button_convert.Enabled = false;

                label_sanskrit_without_diacritics.Visible = false;
                label_settings.Visible = false;
                substitutions_disable_checkboxes();
                substitutions_disable_sanskrit_alphabet_textboxes();
                textBox_displayed_file.Visible = false;            
                button_cancel.Enabled = false;
                button_save.Enabled = false;
                button_defaults.Enabled = false;
                button_settings.Enabled = false;

                progressBar_convert.Value = 0;
                this.Height = int_dialog_height_min;
                button_advanced.Text = "Advanced";
                panel_advanced.Visible = false;
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }        
        }


        ////////////////////////////////////////////////////////////////////////////////

        private void update_controls()
        {
            if (
                (label_settings.Visible == true) ||
                (label_sanskrit_without_diacritics.Visible == true))
            {
                button_advanced.Enabled = true;
                comboBox_select_substitutions_filename.Enabled = false;
                comboBox_select_substitutions_filename.Visible = false;
                button_select_input_file.Enabled = true;
                button_select_output_file.Enabled = true;
                button_convert.Enabled = true;

                if (label_settings.Visible == true)
                {
                    label_sanskrit_without_diacritics.Visible = false;
                }
                else
                {
                    label_settings.Visible = false;
                }

                substitutions_enable_checkboxes();
                textBox_displayed_file.Visible = true;
                button_cancel.Text = "Cancel";
                button_save.Text = "Save";
                button_save.Font = new Font(button_save.Font, FontStyle.Bold);
                button_cancel.Enabled = true;
                button_save.Enabled = true;
                button_save.Select();
                button_defaults.Enabled = true;
                button_settings.Enabled = false;
            }
            else
            {
                button_advanced.Enabled = true;
                comboBox_select_substitutions_filename.Enabled = true;
                comboBox_select_substitutions_filename.Visible = true;
                button_select_input_file.Enabled = true;
                button_select_output_file.Enabled = true;
                button_convert.Enabled = true;

                substitutions_enable_checkboxes();
                textBox_displayed_file.Visible = false;

                button_cancel.Text = "Substitutions";
                button_save.Text = "Words";
                button_save.Font = new Font(button_save.Font, FontStyle.Regular);

                if (comboBox_select_substitutions_filename.Text == Path.GetFileName(string_substitutions_none_ini_file_path))
                {
                    substitutions_clear_sanskrit_alphabet_textboxes();
                    substitutions_disable_sanskrit_alphabet_textboxes();                    
                    button_cancel.Enabled = false;
                    button_save.Enabled = false;
                }
                else
                {
                    substitutions_enable_sanskrit_alphabet_textboxes();
                    button_cancel.Enabled = true;
                    button_save.Enabled = true;
                }

                button_defaults.Enabled = true;
                button_settings.Enabled = true;
            }
        }

        //String string_sanskrit_end_tag = " SYNONYMS\r\n";
        //int int_sanskrit_start_index = matchCollection_devanagari_tags_found[j].Index;
        //int int_sanskrit_end_index = -1;
        //int int_sanskrit_end_tag_index = -1;

        //if (int_sanskrit_start_index > (string_sanskrit_rtf.Length - 1))
        //{
        //    int_sanskrit_start_index = string_sanskrit_rtf.Length - 1;
        //}

        //int_sanskrit_end_tag_index = string_sanskrit_rtf.IndexOf(string_sanskrit_end_tag, int_sanskrit_start_index);

        //if (int_sanskrit_end_tag_index != -1)
        //{
        //    int_sanskrit_end_index = string_sanskrit_rtf.LastIndexOf(" }", int_sanskrit_end_tag_index);

        //    if (int_sanskrit_end_index != -1)
        //    {
        //        int_sanskrit_end_index += " }".Length - 1;

        //        string_sanskrit_rtf = string_sanskrit_rtf.Remove(int_sanskrit_start_index, string_sanskrit_rtf.Substring(int_sanskrit_start_index, int_sanskrit_end_index - int_sanskrit_start_index + 1).Length);
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////
        private bool remove_rtf_style_section(String string_style_name_search_input)
        {
            try
            {
                if (string_sanskrit_rtf.Length < 1)
                {
                    return true;
                }

                if (string_style_name_search_input.Length > 0)
                {
                    String string_style_tag_definition_pattern = @"{(\\s\d+)[^}]*?(";

                    for (int i = 0; i < string_style_name_search_input.Length; i++)
                    {
                        string_style_tag_definition_pattern += string_style_name_search_input[i] + @"(\r\n)?";
                    }

                    string_style_tag_definition_pattern += @")";

                    MatchCollection matchCollection_style_tag = Regex.Matches(string_sanskrit_rtf, string_style_tag_definition_pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);

                    for (int i = 0; i < matchCollection_style_tag.Count; i++)
                    {
                        if (matchCollection_style_tag[i].Groups[1].Success == true)
                        {
                            if (matchCollection_style_tag[i].Groups[1].Value == "\\s240")
                            {
                                "here".ToString();
                            }

                            String string_style_tag_in_rtf_pattern = "(\\" + matchCollection_style_tag[i].Groups[1].Value + @")\s.*?( }|}})";
                            MatchCollection matchCollection_style_tag_in_rtf = Regex.Matches(string_sanskrit_rtf, string_style_tag_in_rtf_pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);

                            for (int j = (matchCollection_style_tag_in_rtf.Count - 1); j >= 0; j--)
                            {
                                String string_match_substring = string_sanskrit_rtf.Substring(matchCollection_style_tag_in_rtf[j].Index, matchCollection_style_tag_in_rtf[j].Length);
                                Match match_applied_style_tag = Regex.Match(string_match_substring, @"(\\s\d+)\s", RegexOptions.RightToLeft | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                                if (match_applied_style_tag.Success == true)
                                {
                                    if (matchCollection_style_tag_in_rtf[j].Groups[1].Value == match_applied_style_tag.Groups[1].Value)
                                    {
                                        Regex regex_next_style_tag = new Regex(@"(\\s\d+)\s", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                        Match match_next_style_tag = regex_next_style_tag.Match(string_sanskrit_rtf, matchCollection_style_tag_in_rtf[j].Index + matchCollection_style_tag_in_rtf[j].Length - 1);
                                        bool bool_section_removed = false;

                                        while (match_next_style_tag.Success == true)
                                        {
                                            if (matchCollection_style_tag_in_rtf[j].Groups[1].Value != match_next_style_tag.Value)
                                            {
                                                string_sanskrit_rtf = string_sanskrit_rtf.Remove(matchCollection_style_tag_in_rtf[j].Index, match_next_style_tag.Index - matchCollection_style_tag_in_rtf[j].Index);
                                                bool_section_removed = true;
                                                break;
                                            }

                                            match_next_style_tag = match_next_style_tag.NextMatch();
                                        };

                                        if (bool_section_removed == false)
                                        {
                                            string_sanskrit_rtf = string_sanskrit_rtf.Remove(matchCollection_style_tag_in_rtf[j].Index);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
                return false;
            }

            return true;
        }
    
        ////////////////////////////////////////////////////////////////////////////////

        private void backgroundWorker_convert_DoWork(object sender, DoWorkEventArgs e)
        {
            String string_italicized;

            try
            {
                //here2
                this.Invoke((MethodInvoker)delegate
                {
                    progressBar_convert.Value = 0;
                });

                if (Path.GetExtension(string_input_file_path).ToLower() == ".rtf")
                {
                    StreamReader streamReader_sanskrit_rtf = new StreamReader(string_input_file_path);
                    string_sanskrit_rtf = streamReader_sanskrit_rtf.ReadToEnd();
                    streamReader_sanskrit_rtf.Close();

                    //
                    // Always remove devanagari
                    //
                    remove_rtf_style_section("dev");

                    if (bool_sanskrit_checked == false)
                    {
                        if (remove_rtf_style_section("Verse;|Verse Text;|Uvaca line;|Prose Verse;|Verse in purp;") == false)
                        {
                            return;
                        }
                    }

                    if (bool_synonyms_checked == false)
                    {
                        if (remove_rtf_style_section("Synonyms;") == false)
                        {
                            return;
                        }
                    }

                    if (bool_translation_checked == false)
                    {
                        if (remove_rtf_style_section("After Verse;|Translation;") == false)
                        {
                            return;
                        }
                    }

                    if (bool_purport_checked == false)
                    {
                        if (remove_rtf_style_section("Purport;") == false)
                        {
                            return;
                        }
                    }

                    //
                    // Finished removing unselected RTF sections
                    //
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBar_convert.Value = 10;
                    });

                    //
                    // Embed "<i>" and "</i>" tags into RTF document
                    //
                    if (string_currently_selected_combobox_filename != Path.GetFileName(string_substitutions_none_ini_file_path))
                    {
                        for (int i = 0; i < char_rtf_tag_terminators_array.Length; i++)
                        {
                            string_sanskrit_rtf = string_sanskrit_rtf.Replace(string_rtf_italics_start_tag + char_rtf_tag_terminators_array[i], "<i>" + string_rtf_italics_start_tag + char_rtf_tag_terminators_array[i]);
                        }

                        int int_start_index = string_sanskrit_rtf.IndexOf("<i>");
                        int int_end_index = -1;

                        while (int_start_index != -1)
                        {                  
                            if (bool_stop_conversion == true)
                            {
                                return;
                            }

                            int[] int_found_index_array = new int[string_rtf_italics_end_tag_array.Length];

                            for (int i = 0; i < int_found_index_array.Length; i++)
                            {
                                int_found_index_array[i] = -1;
                            }

                            int int_index_max = string_sanskrit_rtf.Length;
                            int int_index_min = int_index_max;
                            
                            for (int i = 0; i < string_rtf_italics_end_tag_array.Length; i++)
                            {
                                int_found_index_array[i] = string_sanskrit_rtf.IndexOf(string_rtf_italics_end_tag_array[i], int_start_index + "<i>".Length - 1);

                                if (int_found_index_array[i] == -1)
                                {
                                    int_found_index_array[i] = int_index_max;
                                }
                            }

                            for (int i = 0; i < int_found_index_array.Length; i++)
                            {
                                if (int_found_index_array[i] < int_index_min)
                                {
                                    int_index_min = int_found_index_array[i];
                                }
                            }

                            if (
                                (int_index_min != -1) &&
                                (int_index_min != int_index_max))
                            {
                                int_end_index = int_index_min;
                            }
                            else
                            {
                                int_end_index = string_sanskrit_rtf.Length - 1;
                            }

                            string_sanskrit_rtf = string_sanskrit_rtf.Insert(int_end_index, "</i>");
                            int_start_index = string_sanskrit_rtf.IndexOf("<i>", int_end_index + "</i>".Length - 1);
                        }
                    }

                    //
                    // Finished embedding "<i>" and "</i>" tags into RTF document
                    //
                
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBar_convert.Value = 20;
                    });

                    this.Invoke((MethodInvoker)delegate
                    {
                        richTextBox_main.Rtf = string_sanskrit_rtf;
                        Font font_current = new Font("Segoe UI", richTextBox_main.Font.Size);
                        richTextBox_main.Font = font_current;
                        richTextBox_main.Text = convert_balarama_encoding_to_unicode_encoding(richTextBox_main.Text);
                        richTextBox_main.SaveFile(string_italicized_unicode_txt_file_path, RichTextBoxStreamType.UnicodePlainText);
                    });

                    string_italicized = File.ReadAllText(string_italicized_unicode_txt_file_path, Encoding.Unicode);

                    try
                    {
                        File.Delete(string_italicized_unicode_txt_file_path);
                    }
                    catch (Exception exception_00)
                    {
                        exception_00.ToString();
                    }

                    //
                    // Convert "<i>" and "</i>" tags to flag string
                    //
                    string_input_sanskrit_flags = string_italicized;
                    string_input_sanskrit = string_italicized.Replace("<i>", "");
                    string_input_sanskrit = string_input_sanskrit.Replace("</i>", "");

                    MatchCollection matchCollection_start_italics_tag = regex_find_italics_start_tag.Matches(string_italicized); //Regex.Matches(string_italicized, @"\<i\>");
                    MatchCollection matchCollection_end_italics_tag = regex_find_italics_end_tag.Matches(string_italicized); //Regex.Matches(string_italicized, @"\<\/i\>");

                    for (int i = 0; i < matchCollection_start_italics_tag.Count; i++)
                    {
                        for (int j = 0; j < matchCollection_end_italics_tag.Count; j++)
                        {
                            if (matchCollection_end_italics_tag[j].Index > matchCollection_start_italics_tag[i].Index)
                            {
                                try
                                {
                                    string_input_sanskrit_flags = string_input_sanskrit_flags.Remove(matchCollection_start_italics_tag[i].Index + matchCollection_start_italics_tag[i].Length, matchCollection_end_italics_tag[j].Index - (matchCollection_start_italics_tag[i].Index + matchCollection_start_italics_tag[i].Length));
                                }
                                catch (Exception exception_00)
                                {
                                    exception_00.ToString();
                                }

                                try
                                {
                                    string_input_sanskrit_flags = string_input_sanskrit_flags.Insert(matchCollection_start_italics_tag[i].Index + matchCollection_start_italics_tag[i].Length, new String(char_substitution, matchCollection_end_italics_tag[j].Index - (matchCollection_start_italics_tag[i].Index + matchCollection_start_italics_tag[i].Length)));
                                }
                                catch (Exception exception_00)
                                {
                                    exception_00.ToString();
                                }

                                break;
                            }
                        }
                    }

                    string_input_sanskrit_flags = string_input_sanskrit_flags.Replace("<i>", "");
                    string_input_sanskrit_flags = string_input_sanskrit_flags.Replace("</i>", "");
                    
                    string_input_sanskrit_flags = regex_replace_non_substitution_character_with_space.Replace(string_input_sanskrit_flags, " "); //Regex.Replace(string_input_sanskrit_flags, "[^" + char_substitution + "]", " ", regexOptions_default);
                }
                else
                {
                    string_input_sanskrit = File.ReadAllText(string_input_file_path);
                    string_input_sanskrit_flags = new String(' ', string_input_sanskrit.Length);
                }

                //
                // Finished converting "<i>" and "</i>" tags to flag string
                //

                this.Invoke((MethodInvoker)delegate
                {
                    progressBar_convert.Value = 30;
                });
                
                //
                // Apply Regex replacements from settings.ini
                //
                if (list_substitutions_regex_from_settings.Count < 1)
                {
                    add_default_list_substitutions_regular_expressions();
                }

                bool bool_proceed = false;

                for (int i = 0; i < list_substitutions_regex_from_settings.Count; i++)
                {
                    bool_proceed = false;

                    if (list_substitutions_regex_from_settings[i].string_prefix == string_settings_sanskrit_checked_substitution_prefix_default)
                    {
                        if (bool_sanskrit_checked == true)
                        {
                            bool_proceed = true;
                        }
                    }
                    else if (list_substitutions_regex_from_settings[i].string_prefix == string_settings_synonyms_checked_substitution_prefix_default)
                    {
                        if (bool_synonyms_checked == true)
                        {
                            bool_proceed = true;
                        }
                    }
                    else if (list_substitutions_regex_from_settings[i].string_prefix == string_settings_translation_checked_substitution_prefix_default)
                    {
                        if (bool_translation_checked == true)
                        {
                            bool_proceed = true;
                        }
                    }
                    else if (list_substitutions_regex_from_settings[i].string_prefix == string_settings_purport_checked_substitution_prefix_default)
                    {
                        if (bool_purport_checked == true)
                        {
                            bool_proceed = true;
                        }
                    }
                    else if (list_substitutions_regex_from_settings[i].string_prefix == string_settings_sanskrit_unchecked_substitution_prefix_default)
                    {
                        if (bool_sanskrit_checked == false)
                        {
                            bool_proceed = true;
                        }
                    }
                    else if (list_substitutions_regex_from_settings[i].string_prefix == string_settings_synonyms_unchecked_substitution_prefix_default)
                    {
                        if (bool_synonyms_checked == false)
                        {
                            bool_proceed = true;
                        }
                    }
                    else if (list_substitutions_regex_from_settings[i].string_prefix == string_settings_translation_unchecked_substitution_prefix_default)
                    {
                        if (bool_translation_checked == false)
                        {
                            bool_proceed = true;
                        }
                    }
                    else if (list_substitutions_regex_from_settings[i].string_prefix == string_settings_purport_unchecked_substitution_prefix_default)
                    {
                        if (bool_purport_checked == false)
                        {
                            bool_proceed = true;
                        }
                    }
                    else
                    {
                        bool_proceed = true;
                    }

                    if (bool_proceed == true)
                    {
                        Regex regex_settings_ini = list_substitutions_regex_from_settings[i].regex_compiled; //new Regex(list_substitutions_regex_from_settings[i].string_input, RegexOptions.Multiline);
                        Match match_settings_ini = regex_settings_ini.Match(string_input_sanskrit);
                        String string_replacement;

                        while (match_settings_ini.Success == true)
                        {
                            string_input_sanskrit = string_input_sanskrit.Remove(match_settings_ini.Index, match_settings_ini.Length);
                            string_input_sanskrit_flags = string_input_sanskrit_flags.Remove(match_settings_ini.Index, match_settings_ini.Length);
                            
                            string_replacement = list_substitutions_regex_from_settings[i].string_replacement;
                            
                            for (int k = 0; k < regex_settings_ini.GetGroupNumbers().Length; k++)
                            {
                                if (regex_settings_ini.GetGroupNumbers()[k] > 0)
                                {
                                    if (match_settings_ini.Groups[regex_settings_ini.GetGroupNumbers()[k]].Success == true)
                                    {
                                        if (regex_settings_ini.GetGroupNumbers()[k].ToString() == regex_settings_ini.GetGroupNames()[regex_settings_ini.GetGroupNumbers()[k]])
                                        {
                                            string_replacement = string_replacement.Replace("$" + regex_settings_ini.GetGroupNames()[regex_settings_ini.GetGroupNumbers()[k]], match_settings_ini.Groups[regex_settings_ini.GetGroupNames()[k]].Value);
                                        }
                                        else
                                        {
                                            string_replacement = string_replacement.Replace("${" + regex_settings_ini.GetGroupNames()[regex_settings_ini.GetGroupNumbers()[k]] + "}", match_settings_ini.Groups[regex_settings_ini.GetGroupNames()[k]].Value);
                                        }
                                    }
                                }
                            }

                            string_replacement = System.Text.RegularExpressions.Regex.Unescape(string_replacement);

                            string_input_sanskrit = string_input_sanskrit.Insert(match_settings_ini.Index, string_replacement);
                            string_input_sanskrit_flags = string_input_sanskrit_flags.Insert(match_settings_ini.Index, new String(' ', string_replacement.Length));

                            if ((match_settings_ini.Index + string_replacement.Length) >= (string_input_sanskrit.Length - 1))
                            {
                                break;
                            }

                            match_settings_ini = regex_settings_ini.Match(string_input_sanskrit, match_settings_ini.Index + string_replacement.Length);
                        }
                    }
                }

                //
                // Finished applying Regex replacements from settings.ini
                //
                this.Invoke((MethodInvoker)delegate
                {
                    progressBar_convert.Value = 40;
                });

                List<class_substitution> list_substitutions_descending = substitutions_get_from_file_unsorted(string_currently_selected_combobox_filename); //substitutions_get_from_file_sorted_descending(string_currently_selected_combobox_filename);

                if (string_currently_selected_combobox_filename == Path.GetFileName(string_substitutions_none_ini_file_path))
                {
                    string_output_speech = string_input_sanskrit;
                }
                else
                {
                    //
                    // Unmark end of chapter sentence
                    //
                    MatchCollection matchCollection_chapter_ending = regex_find_end_of_chapter_sentence.Matches(string_input_sanskrit); //Regex.Matches(string_input_sanskrit, @"(\r\nEND OF THE|\r\nThus end the|\r\nThus ends the|Bhagavad-gītā As It Is in the form in which it is presented now)", RegexOptions.Multiline);

                    for (int i = 0; i < matchCollection_chapter_ending.Count; i++)
                    {
                        int int_space_found_index = string_input_sanskrit_flags.IndexOf(' ', matchCollection_chapter_ending[i].Groups[1].Index + "\r\n".Length);

                        if (int_space_found_index == -1)
                        {
                            int_space_found_index = string_input_sanskrit_flags.Length;
                        }

                        string_input_sanskrit_flags = string_input_sanskrit_flags.Remove(matchCollection_chapter_ending[i].Groups[1].Index, int_space_found_index - matchCollection_chapter_ending[i].Groups[1].Index);
                        string_input_sanskrit_flags = string_input_sanskrit_flags.Insert(matchCollection_chapter_ending[i].Groups[1].Index, new String(' ', int_space_found_index - matchCollection_chapter_ending[i].Groups[1].Index));
                    }
                    //
                    // Finished unmarking end of chapter sentence
                    //
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBar_convert.Value = 40;
                    });

                    //
                    // Mark Sanskrit words without diacritics
                    //
                    if (list_substitutions_sanskrit_without_diacritics.Count < 1)
                    {
                        reload_sanskrit_without_diacritics();
                    }

                    for (int i = 0; i < list_substitutions_sanskrit_without_diacritics.Count; i++)
                    {
                        MatchCollection matchCollection_word_singular_plural_or_ownership = list_substitutions_sanskrit_without_diacritics[i].regex_compiled.Matches(string_input_sanskrit);

                        for (int j = 0; j < matchCollection_word_singular_plural_or_ownership.Count; j++)
                        {
                            int int_word_start_index = -1;
                            int int_word_end_index = -1;

                            if (
                                (matchCollection_word_singular_plural_or_ownership[j].Groups[1].ToString().Trim() == "-") ||
                                (matchCollection_word_singular_plural_or_ownership[j].Groups[1].ToString().Trim() == "'"))
                            {
                                //Regex regex_find_no_dash_or_apostrophe_punctuation_before_word = new Regex(@"(^|\s|[\p{P}-['\p{Pd}]])", regexOptions_default | RegexOptions.RightToLeft);
                                Match match_no_dash_or_apostrophe_punctuation_before_word = regex_find_no_dash_or_apostrophe_punctuation_before_word.Match(string_input_sanskrit, 0, matchCollection_word_singular_plural_or_ownership[j].Groups[1].Index);

                                if (match_no_dash_or_apostrophe_punctuation_before_word.Success == true)
                                {
                                    int_word_start_index = match_no_dash_or_apostrophe_punctuation_before_word.Index + match_no_dash_or_apostrophe_punctuation_before_word.Length;
                                }
                                else
                                {
                                    int_word_start_index = 0;
                                }
                            }
                            else
                            {
                                int_word_start_index = matchCollection_word_singular_plural_or_ownership[j].Groups[1].Index + matchCollection_word_singular_plural_or_ownership[j].Groups[1].Length;
                            }

                            if (
                                (matchCollection_word_singular_plural_or_ownership[j].Groups[3].ToString().Trim() == "-") ||
                                (matchCollection_word_singular_plural_or_ownership[j].Groups[3].ToString().Trim() == "'"))
                            {
                                //Regex regex_find_no_dash_or_apostrophe_punctuation_after_word = new Regex(@"(\s|[\p{P}-['\p{Pd}]]|$)", regexOptions_default);
                                Match match_no_dash_or_apostrophe_punctuation_after_word = regex_find_no_dash_or_apostrophe_punctuation_after_word.Match(string_input_sanskrit, matchCollection_word_singular_plural_or_ownership[j].Groups[3].Index);

                                if (match_no_dash_or_apostrophe_punctuation_after_word.Success == true)
                                {
                                    int_word_end_index = match_no_dash_or_apostrophe_punctuation_after_word.Index;
                                }
                                else
                                {
                                    int_word_end_index = string_input_sanskrit.Length;
                                }
                            }
                            else
                            {
                                int_word_end_index = matchCollection_word_singular_plural_or_ownership[j].Groups[3].Index;
                            }

                            string_input_sanskrit_flags = string_input_sanskrit_flags.Remove(int_word_start_index, int_word_end_index - int_word_start_index);
                            string_input_sanskrit_flags = string_input_sanskrit_flags.Insert(int_word_start_index, new String(char_substitution, int_word_end_index - int_word_start_index));
                        }
                    }
                    //
                    // Finished marking Sanskrit words without diacritics
                    //
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBar_convert.Value = 50;
                    });

                    //
                    // Mark remaining words with diacritics
                    //                    
                    MatchCollection matchCollection_letters_with_diacritics = regex_find_diacritic_word.Matches(string_input_sanskrit); //Regex.Matches(string_input_sanskrit, @"(?<diacritic_word>\w*(Ṣ|ṣ|Ñ|ñ|Ā|ā|Ī|ī|Ś|ś|Ū|ū|Ḍ|ḍ|Ḥ|ḥ|Ḷ|ḷ|Ṁ|ṁ|Ṅ|ṅ|Ṇ|ṇ|Ṛ|ṛ|Ṝ|ṝ|Ṭ|ṭ|l̐)\w*)", regexOptions_default);

                    for (int j = 0; j < matchCollection_letters_with_diacritics.Count; j++)
                    {
                        int int_word_start_index = -1;
                        int int_word_end_index = -1;

                        try
                        {
                            //Regex regex_find_no_dash_or_apostrophe_punctuation_before_word = new Regex(@"(^|\s|[\p{P}-['\p{Pd}]])", regexOptions_default | RegexOptions.RightToLeft);
                            Match match_no_dash_or_apostrophe_punctuation_before_word = regex_find_no_dash_or_apostrophe_punctuation_before_word.Match(string_input_sanskrit, 0, matchCollection_letters_with_diacritics[j].Groups["diacritic_word"].Index);

                            try
                            {
                                if (match_no_dash_or_apostrophe_punctuation_before_word.Success == true)
                                {
                                    int_word_start_index = match_no_dash_or_apostrophe_punctuation_before_word.Index + match_no_dash_or_apostrophe_punctuation_before_word.Length;
                                }
                                else
                                {
                                    int_word_start_index = 0;
                                }
                            }
                            catch (Exception exception_00)
                            {
                                exception_00.ToString();
                            }

                            try
                            {
                                //Regex regex_find_no_dash_or_apostrophe_punctuation_after_word = new Regex(@"(\s|[\p{P}-['\p{Pd}]]|$)", regexOptions_default);

                                if ((matchCollection_letters_with_diacritics[j].Groups["diacritic_word"].Index + matchCollection_letters_with_diacritics[j].Groups["diacritic_word"].Length) >= (string_input_sanskrit.Length - 1))
                                {
                                    int_word_end_index = string_input_sanskrit.Length;
                                }
                                else
                                {
                                    Match match_no_dash_or_apostrophe_punctuation_after_word = regex_find_no_dash_or_apostrophe_punctuation_after_word.Match(string_input_sanskrit, matchCollection_letters_with_diacritics[j].Groups["diacritic_word"].Index + matchCollection_letters_with_diacritics[j].Groups["diacritic_word"].Length);

                                    if (match_no_dash_or_apostrophe_punctuation_after_word.Success == true)
                                    {
                                        int_word_end_index = match_no_dash_or_apostrophe_punctuation_after_word.Index;
                                    }
                                    else
                                    {
                                        int_word_end_index = string_input_sanskrit.Length;
                                    }
                                }
                            }
                            catch (Exception exception_00)
                            {
                                exception_00.ToString();
                            }

                            string_input_sanskrit_flags = string_input_sanskrit_flags.Remove(int_word_start_index, int_word_end_index - int_word_start_index);
                            string_input_sanskrit_flags = string_input_sanskrit_flags.Insert(int_word_start_index, new String(char_substitution, int_word_end_index - int_word_start_index));
                        }
                        catch (Exception exception_00)
                        {
                            exception_00.ToString();
                        }
                    }
                    //
                    // Finished marking words with diacritics
                    //
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBar_convert.Value = 60;
                    });


                    //
                    // Convert marked Sanskrit to speech
                    //
                    MatchCollection matchCollection_marked = regex_find_one_or_more_substitution_characters.Matches(string_input_sanskrit_flags); //Regex.Matches(string_input_sanskrit_flags, char_substitution + "+", regexOptions_default);
                    string_output_speech = "";

                    if (matchCollection_marked.Count == 0)
                    {
                        string_output_speech = string_input_sanskrit;
                    }
                    else
                    {
                        string_output_speech = string_input_sanskrit.Substring(0, matchCollection_marked[0].Index);

                        for (int i = 0; i < matchCollection_marked.Count; i++)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                progressBar_convert.Value = (int)(60.0 + (i / (matchCollection_marked.Count * 1.0)) * 40.0);
                            });

                            String string_sanskrit_input_phrase = string_input_sanskrit.Substring(matchCollection_marked[i].Index, matchCollection_marked[i].Length);
                            String string_sanskrit_input_phrase_flags = new String(char_substitution, string_sanskrit_input_phrase.Length);
                            List<String> list_string_output_phrase = new List<String>();
                            
                            for (int x = 0; x < string_sanskrit_input_phrase.Length; x++)
                            {
                                list_string_output_phrase.Add("");
                            }

                            for (int m = 0; m < list_substitutions_descending.Count; m++)
                            {
                                Regex regex_sanskrit_input_phrase = list_substitutions_descending[m].regex_compiled; //new Regex(list_substitutions_descending[m].string_input, regexOptions_default);
                                MatchCollection matchCollection_sanskrit_input_phrase = regex_sanskrit_input_phrase.Matches(string_sanskrit_input_phrase);
                                String string_replacement;

                                for (int j = 0; j < matchCollection_sanskrit_input_phrase.Count; j++)
                                {   
                                    if (string_sanskrit_input_phrase_flags.Substring(matchCollection_sanskrit_input_phrase[j].Index, matchCollection_sanskrit_input_phrase[j].Length) == (new String(char_substitution, matchCollection_sanskrit_input_phrase[j].Length)))
                                    {
                                        //
                                        // Replacement has not yet been used for this set of input letters
                                        //
                                        string_sanskrit_input_phrase_flags = string_sanskrit_input_phrase_flags.Remove(matchCollection_sanskrit_input_phrase[j].Index, matchCollection_sanskrit_input_phrase[j].Length);
                                        string_sanskrit_input_phrase_flags = string_sanskrit_input_phrase_flags.Insert(matchCollection_sanskrit_input_phrase[j].Index, new String(' ', matchCollection_sanskrit_input_phrase[j].Length));

                                        string_replacement = list_substitutions_descending[m].string_replacement;

                                        for (int k = 0; k < regex_sanskrit_input_phrase.GetGroupNumbers().Length; k++)
                                        {
                                            if (regex_sanskrit_input_phrase.GetGroupNumbers()[k] > 0)
                                            {
                                                if (matchCollection_sanskrit_input_phrase[j].Groups[regex_sanskrit_input_phrase.GetGroupNumbers()[k]].Success == true)
                                                {
                                                    if (regex_sanskrit_input_phrase.GetGroupNumbers()[k].ToString() == regex_sanskrit_input_phrase.GetGroupNames()[regex_sanskrit_input_phrase.GetGroupNumbers()[k]])
                                                    {
                                                        string_replacement = string_replacement.Replace("$" + regex_sanskrit_input_phrase.GetGroupNames()[regex_sanskrit_input_phrase.GetGroupNumbers()[k]], matchCollection_sanskrit_input_phrase[j].Groups[regex_sanskrit_input_phrase.GetGroupNames()[k]].Value);
                                                    }
                                                    else
                                                    {
                                                        string_replacement = string_replacement.Replace("${" + regex_sanskrit_input_phrase.GetGroupNames()[regex_sanskrit_input_phrase.GetGroupNumbers()[k]] + "}", matchCollection_sanskrit_input_phrase[j].Groups[regex_sanskrit_input_phrase.GetGroupNames()[k]].Value);
                                                    }
                                                }
                                            }
                                        }


                                        for (int k = 1; k < matchCollection_sanskrit_input_phrase[j].Groups.Count; k++)
                                        {
                                            String name = matchCollection_sanskrit_input_phrase[j].Groups[k].ToString();

                                            if (matchCollection_sanskrit_input_phrase[j].Groups[k].Success == true)
                                            {   
                                                string_replacement = string_replacement.Replace("$" + k.ToString(), matchCollection_sanskrit_input_phrase[j].Groups[k].Value);
                                            }
                                        }

                                        string_replacement = System.Text.RegularExpressions.Regex.Unescape(string_replacement);

                                        list_string_output_phrase[matchCollection_sanskrit_input_phrase[j].Index] = string_replacement;

                                        for (int y = matchCollection_sanskrit_input_phrase[j].Index; y < (matchCollection_sanskrit_input_phrase[j].Index + matchCollection_sanskrit_input_phrase[j].Length); y++)
                                        {
                                            if (String.IsNullOrEmpty(list_string_output_phrase[y]) == true)
                                            {
                                                list_string_output_phrase[y] = char_substitution.ToString();
                                            }
                                        }
                                    }
                                }
                            }

                            String string_sanskrit_output_phrase = "";

                            for (int h = 0; h < list_string_output_phrase.Count; h++)
                            {
                                if (String.IsNullOrEmpty(list_string_output_phrase[h]) == true)
                                {
                                    //
                                    // Substitution not made
                                    //
                                    string_sanskrit_output_phrase += string_sanskrit_input_phrase[h];
                                }
                                else
                                {
                                    if (list_string_output_phrase[h] != char_substitution.ToString())
                                    {
                                        string_sanskrit_output_phrase += list_string_output_phrase[h];
                                    }
                                }
                            }

                            string_output_speech += string_sanskrit_output_phrase;

                            if (i < (matchCollection_marked.Count - 1))
                            {
                                string_output_speech += string_input_sanskrit.Substring(
                                    matchCollection_marked[i].Index + matchCollection_marked[i].Length,
                                    matchCollection_marked[i + 1].Index - (matchCollection_marked[i].Index + matchCollection_marked[i].Length));
                            }
                            else
                            {
                                if ((matchCollection_marked[i].Index + matchCollection_marked[i].Length) < string_input_sanskrit.Length)
                                {
                                    string_output_speech += string_input_sanskrit.Substring(matchCollection_marked[i].Index + matchCollection_marked[i].Length);
                                }
                            }
                        }
                    }
                }
                //
                // Finished converting marked Sanskrit to speech
                //
                File.WriteAllText(string_output_file_path, string_output_speech);

                //
                // Finished converting all Sanskrit to Speech
                //
                this.Invoke((MethodInvoker)delegate
                {
                    progressBar_convert.Value = 100;
                });
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void backgroundWorker_convert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                update_controls();
                
                if (bool_stop_conversion == true)
                {
                    progressBar_convert.Value = 0;
                    list_string_input_files_to_process.Clear();
                }
                else if (list_string_input_files_to_process.Count > 1)
                {
                    list_string_input_files_to_process.RemoveAt(0);
                    start_conversion_thread();
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void add_default_list_substitutions_regular_expressions()
        {
            try
            {
                int int_delimiter_found_index = -1;

                for (int i = 0; i < string_regular_expressions_array_default.Length; i++)
                {
                    int_delimiter_found_index = string_regular_expressions_array_default[i].IndexOf(string_delimiter);

                    if (int_delimiter_found_index != -1)
                    {
                        if ((int_delimiter_found_index + string_delimiter.Length) < string_regular_expressions_array_default[i].Length)
                        {
                            list_substitutions_regex_from_settings.Add(new class_substitution(string_regular_expressions_array_default[i].Substring(0, int_delimiter_found_index), string_regular_expressions_array_default[i].Substring(int_delimiter_found_index + string_delimiter.Length)));
                        }
                        else
                        {
                            list_substitutions_regex_from_settings.Add(new class_substitution(string_regular_expressions_array_default[i].Substring(0, int_delimiter_found_index), ""));
                        }
                    }
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void checkBox_sanskrit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Font font_current = checkBox_sanskrit.Font;

                if (checkBox_sanskrit.Checked == true)
                {
                    bool_sanskrit_checked = true;
                    checkBox_sanskrit.Font = new Font(font_current, FontStyle.Bold);
                }
                else
                {
                    bool_sanskrit_checked = false;
                    checkBox_sanskrit.Font = new Font(font_current, FontStyle.Regular);
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void checkBox_synonyms_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Font font_current = checkBox_synonyms.Font;

                if (checkBox_synonyms.Checked == true)
                {
                    bool_synonyms_checked = true;
                    checkBox_synonyms.Font = new Font(font_current, FontStyle.Bold);
                }
                else
                {
                    bool_synonyms_checked = false;
                    checkBox_synonyms.Font = new Font(font_current, FontStyle.Regular);
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void checkBox_translation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Font font_current = checkBox_translation.Font;

                if (checkBox_translation.Checked == true)
                {
                    bool_translation_checked = true;
                    checkBox_translation.Font = new Font(font_current, FontStyle.Bold);
                }
                else
                {
                    bool_translation_checked = false;
                    checkBox_translation.Font = new Font(font_current, FontStyle.Regular);
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void checkBox_purport_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Font font_current = checkBox_purport.Font;

                if (checkBox_purport.Checked == true)
                {
                    bool_purport_checked = true;
                    checkBox_purport.Font = new Font(font_current, FontStyle.Bold);
                }
                else
                {
                    bool_purport_checked = false;
                    checkBox_purport.Font = new Font(font_current, FontStyle.Regular);
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private void button_settings_Click(object sender, EventArgs e)
        {
            try
            {
                if (label_settings.Visible == false)
                {
                    label_settings.Visible = true;
                    update_controls();

                    substitution_save_changes_to_currently_selected_file();
                    save_to_settings_ini();
                    
                    if (File.Exists(string_settings_ini_file_path) == false)
                    {
                        create_default_settings_ini();
                    }

                    textBox_displayed_file.Text = File.ReadAllText(string_settings_ini_file_path);
                }
            }
            catch (Exception exception_00)
            {
                exception_00.ToString();
            }
        }
    }
}