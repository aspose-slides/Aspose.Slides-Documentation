---
title: Αναζήτηση και Αντικατάσταση Κειμένου σε Παρουσιάσεις PowerPoint με C++
linktitle: Αναζήτηση και Αντικατάσταση Κειμένου
type: docs
weight: 55
url: /el/cpp/search-and-replace-text/
keywords:
- αναζήτηση κειμένου
- επισήμανση κειμένου
- αντικατάσταση κειμένου
- κανονική έκφραση
- κλήση ανάκλησης αποτελέσματος
- πλαίσιο κειμένου
- αναφορά ελέγχου
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Αναζητήστε, επισημάνετε και αντικαταστήστε κείμενο σε παρουσιάσεις PowerPoint, συλλέγοντας κάθε αντιστοίχιση με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ενημερώνει μια εφαρμογή για κάθε αντιστοίχιση μέσω μιας κλήσης ανάκλησης αποτελέσματος. Αυτό καθιστά εφικτή την ενημέρωση μιας παρουσίασης και ταυτόχρονα τη δημιουργία ενός αρχείου ελέγχου που περιέχει το αντιστοιχισμένο κείμενο, το περιεχόμενό του, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για ανασκόπηση, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες διαδικασίες αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το εξής κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλογή Πεδίου Αναζήτησης**

Χρησιμοποιήστε τις μεθόδους στο [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε τις μεθόδους στο [IPresentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/) για να επεξεργαστείτε όλο το κείμενο που είναι εφαρμόσιμο στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη η παρουσίαση |
|---|---|---|
| Επισημάνετε κυριολεκτικό κείμενο | [ITextFrame::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/highlighttext/) |
| Επισημάνετε αντιστοιχίσεις κανονικής έκφρασης | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/highlightregex/) |
| Αντικαταστήστε κυριολεκτικό κείμενο | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/replacetext/) |
| Αντικαταστήστε αντιστοιχίσεις κανονικής έκφρασης | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Διαμόρφωση Ταίριαξης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [ITextSearchOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/) για να ελέγξετε την ταυτοποίηση:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) περιορίζει τις αντιστοιχίσεις σε ολόκληρες λέξεις.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) ελέγχει αν πρέπει να ταιριάζει το πεζό/κεφαλαίο των χαρακτήρων.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_includenotes/) περιλαμβάνει τις σημειώσεις διαφάνειας στις λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα `System::Text::RegularExpressions::Regex`, έτσι οι κανόνες ταίριαξης όπως η ευαισθησία σε πεζά/κεφαλαία και τα όρια λέξεων ορίζονται από την έκφραση και τις επιλογές της.

## **Συλλογή Πληροφοριών Αντιστοιχίας με Κλήση Ανάκλησης**

Εφαρμόστε το [IFindResultCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifindresultcallback/) για να λαμβάνετε μια ειδοποίηση για κάθε αντιστοιχία. Η μέθοδος του [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifindresultcallback/foundresult/) παρέχει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο και τη θέση της αντιστοιχίας.

Η κλήση ανάκλησης δεν λαμβάνει απευθείας αριθμό διαφάνειας. Η υλοποίηση παρακάτω τον εξάγει από το [ISlideComponent::get_Slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecomponent/get_slide/) και επίσης διαχειρίζεται κείμενο που εντοπίζεται σε σημειώσεις διαφάνειας μέσω του [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/inotesslide/get_parentslide/). Ένας δυνατό αριθμός διαφάνειας που μπορεί να είναι κενός επιτρέπει στο ίδιο μοντέλο αποτελέσματος να αντιπροσωπεύει κείμενο που σχετίζεται με άλλους τύπους διαφανειών.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

Για λειτουργίες αντικατάστασης, το `FoundText` περιέχει το αρχικό αντιστοιχισμένο κείμενο, έτσι η κλήση ανάκλησης μπορεί να καταγράψει ακριβώς ποιοι όροι αντικαταστάθηκαν.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlighttext/) για να επισημάνετε τις κυριολεκτικές αντιστοιχίες κειμένου σε ένα πλαίσιο κειμένου. Μεταβιβάστε το [ITextSearchOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/) για να ελέγξετε την αναζήτηση και μια κλήση ανάκλησης για τη συλλογή λεπτομερειών της αντιστοιχίας.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο την πλήρη λέξη **"to"**. Και οι δύο αναζητήσεις αναφέρουν τις αντιστοιχίες τους στην ίδια κλήση ανάκλησης.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Get the first shape from the first slide.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου με Κανονικές Εκφράσεις**

Η μέθοδος [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlightregex/) επισημαίνει τις αντιστοιχίες κειμένου που βρέθηκαν από μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισημαίνει όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες και συλλέγει κάθε αντιστοιχία:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο με την κανονική έκφραση](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Ολόκληρη την Παρουσίαση**

Χρησιμοποιήστε τις [IPresentation::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/highlighttext/) και [IPresentation::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/highlightregex/) για να αναζητήσετε όλα τα εφαρμόσιμα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email, διατηρώντας ξεχωριστές συλλογές αποτελεσμάτων για τις δύο αναζητήσεις.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αντικατάσταση Κειμένου σε Πλαίσιο Κειμένου**

Χρησιμοποιήστε το [ITextFrame::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replacetext/) για κυριολεκτικό κείμενο και το [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replaceregex/) για αντικατάσταση με βάση πρότυπο. Αυτές οι μέθοδοι ενημερώνουν το αντιστοιχισμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου, το οποίο διατηρεί τη μορφοποίηση του περιβάλλοντος τμήματος αντί να ξαναχτίζει το πλαίσιο κειμένου από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα ενοποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες έκδοσης. Η ίδια κλήση ανάκλησης καταγράφει τους αρχικούς όρους που αντιστοιχίστηκαν από και τις δύο λειτουργίες.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Εάν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου σε Ολόκληρη την Παρουσίαση**

Χρησιμοποιήστε τα [IPresentation::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/replacetext/) και [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/replaceregex/) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και διαγραφή.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ομαδοποίηση Αντιστοιχών για Αναφορές**

Επειδή κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιούν τις αντιστοιχίες για ελεγκτικούς, αναφοριστικούς ή ελεγκτικούς σκοπούς. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα ανά διαφάνεια και μετά ανά πλαίσιο κειμένου:

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε τις [ITextFrame::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replacetext/), ή [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replaceregex/) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι σε επίπεδο παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με τη σωστή κεφαλαιοποίηση;**

Καλέστε τις [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) και [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) με τιμή `true`, και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και την ευαισθησία πεζών/κεφαλαίων μέσα στο ίδιο το `System::Text::RegularExpressions::Regex`.

**Μπορούν η αναζήτηση και η αντικατάσταση να περιλαμβάνουν το κείμενο σε σημειώσεις διαφάνειας;**

Ναι. Καλέστε την [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_includenotes/) με `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου σε επίπεδο παρουσίασης. Η υλοποίηση της κλήσης ανάκλησης που φαίνεται παραπάνω αντιστοιχίζει μια αντιστοίχηση σε σημειώσεις διαφάνειας στον αριθμό γονικής διαφάνειας.

**Πώς μπορώ να δημιουργήσω μια αναφορά χωρίς να σαρώσω τη παρουσίαση για δεύτερη φορά;**

Περάστε μια υλοποίηση του [IFindResultCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifindresultcallback/) στην λειτουργία επισήμανσης ή αντικατάστασης. Η κλήση ανάκλησης λαμβάνει κάθε αντιστοιχία κατά την εκτέλεση της λειτουργίας, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον προεξαγόμενο αριθμό διαφάνειας για μετέπειτα ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Οι [ITextFrame::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replacetext/) και [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replaceregex/) τροποποιούν το αντιστοιχισμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου και διατηρούν τη μορφοποίηση των περιβάλλοντων τμημάτων. Εάν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, εξετάστε το αποτέλεσμα ώστε η αντικατάσταση να χρησιμοποιεί το επιθυμητό στυλ.