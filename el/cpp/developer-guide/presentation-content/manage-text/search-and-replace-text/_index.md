---
title: Αναζήτηση και Αντικατάσταση Κειμένου σε Παρουσιάσεις PowerPoint σε C++
linktitle: Αναζήτηση και Αντικατάσταση Κειμένου
type: docs
weight: 55
url: /el/cpp/search-and-replace-text/
keywords:
- αναζήτηση κειμένου
- επισήμανση κειμένου
- αντικατάσταση κειμένου
- κανονική έκφραση
- callback αποτελέσματος
- πλαίσιο κειμένου
- αναφορά ελέγχου
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Αναζητήστε, επισημάνετε και αντικαταστήστε κείμενο σε παρουσιάσεις PowerPoint συλλέγοντας κάθε αντιστοιχία με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ενημερώσει μια εφαρμογή για κάθε αντιστοιχία μέσω μιας κλήσης αποτελέσματος. Αυτό καθιστά δυνατόν να ενημερώνετε την παρουσίαση και ταυτόχρονα να δημιουργείτε ένα αρχείο ελέγχου που περιέχει το αντιστοιχισμένο κείμενο, το περιεχόμενό του, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για έλεγχο, διαγραφή, επαλήθευση ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες ροές εργασίας αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το παρακάτω κείμενο:

![Sample text](sample_text.png)

## **Επιλογή Εύρους Αναζήτησης**

Χρησιμοποιήστε μεθόδους στο [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήτε μεθόδους στο [IPresentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/) για να επεξεργαστείτε όλο το κείμενο που εφαρμόζεται στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [ITextFrame::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/highlighttext/) |
| Επισήμανση αντιστοιχίσεων κανονικής έκφρασης | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/highlightregex/) |
| Αντικατάσταση κυριολεκτικού κειμένου | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/replacetext/) |
| Αντικατάσταση αντιστοιχίσεων κανονικής έκφρασης | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Διαμόρφωση Ταύτισης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [ITextSearchOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/) για να ελέγξετε την ταύτιση:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) περιορίζει τις αντιστοιχίες σε πλήρεις λέξεις.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) ελέγχει εάν η πεζοκεφαλαία πρέπει να ταιριάζει.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_includenotes/) περιλαμβάνει τις σημειώσεις διαφάνειας σε λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης επιπέδου παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα `System::Text::RegularExpressions::Regex`, οπότε οι κανόνες ταύτισης όπως η ευαισθησία πεζών-κεφαλαίων και τα όρια λέξεων ορίζονται από την έκφραση και τις επιλογές της.

## **Αναγνώριση Ιδιοκτήτη Πλαισίου Κειμένου**

Οι γενικές ροές επεξεργασίας κειμένου συχνά λαμβάνουν ένα [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) κατά την αναζήτηση, αντικατάσταση, επικύρωση ή εξαγωγή κειμένου. Χρησιμοποιήστε το [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentshape/) και το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentcell/) για να προσδιορίσετε ποιο αντικείμενο παρουσίασης κατέχει το πλαίσιο κειμένου.

Οι αναμενόμενες τιμές εξαρτώνται από τον ιδιοκτήτη:

| Ιδιοκτήτης πλαισίου κειμένου | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| Ένα AutoShape ή άλλο σχήμα που περιέχει κείμενο | Το ιδιοκτησιακό [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) | `nullptr` |
| Κελί πίνακα | `nullptr` | Το ιδιοκτησιακό [ICell](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/) |

Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση. Η κλήση τους δεν μετακινεί το πλαίσιο κειμένου ούτε αλλάζει τον ιδιοκτήτη του. Ο γενικός κώδικας θα πρέπει να ελέγχει και τις δύο τιμές για `nullptr` και να διαχειρίζεται την περίπτωση που κανένας ιδιοκτήτης δεν είναι διαθέσιμος.

Το παρακάτω παράδειγμα χρησιμοποιεί το [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/getalltextframes/) για να επαναλάβει όλα τα πλαίσια κειμένου σε μια παρουσίαση. Για σχήματα, αναφέρει το όνομα του σχήματος, τον τύπο χρόνου εκτέλεσης C++ και τη διαφάνεια που το περιέχει. Για κελιά πίνακα, αναφέρει τις συντεταγμένες στήλης και γραμμής (μηδενική βάση) και τη διαφάνεια που το περιέχει.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

Για περιεχόμενο SmartArt, επαναλάβετε τα σχήματα στο [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) και αποκτήστε κάθε [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). Το πλαίσιο κειμένου μπορεί να εντοπιστεί στο σχετικό σχήμα μέσω του [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentshape/), ενώ το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentcell/) επιστρέφει `nullptr`. Συνεπώς, το κλαδί σχήματος στο παράδειγμα διαχειρίζεται επίσης κείμενο από κόμβους SmartArt.

## **Συλλογή Πληροφοριών Αντιστοιχίας με Κλήση Επιστροφής**

Εφαρμόστε το [IFindResultCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifindresultcallback/) για να λαμβάνετε ειδοποίηση για κάθε αντιστοιχία. Η μέθοδός του [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifindresultcallback/foundresult/) παρέχει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο και τη θέση αντιστοιχίας.

Η κλήση επιστροφής δεν λαμβάνει απευθείας τον αριθμό της διαφάνειας. Η υλοποίηση παρακάτω τον αντλεί από το [ISlideComponent::get_Slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecomponent/get_slide/) και διαχειρίζεται επίσης κείμενο που βρέθηκε σε σημειώσεις διαφάνειας μέσω του [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/inotesslide/get_parentslide/). Ένας nullable αριθμός διαφάνειας επιτρέπει στο ίδιο μοντέλο αποτελέσματος να αναπαριστά κείμενο που σχετίζεται με άλλους τύπους διαφάνειας.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
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
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

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

Για λειτουργίες αντικατάστασης, το `FoundText` περιέχει το αρχικό αντιστοιχισμένο κείμενο, ώστε η κλήση επιστροφής να μπορεί να καταγράψει ακριβώς ποιες φράσεις αντικαταστάθηκαν.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlighttext/) για να επισημάνετε κυριολεκτικές αντιστοιχίες κειμένου σε ένα πλαίσιο κειμένου. Περάστε ένα [ITextSearchOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/) για να ελέγξετε την αναζήτηση και μια κλήση επιστροφής για τη συλλογή λεπτομερειών αντιστοιχίας.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη λέξη **"to"**. Και οι δύο αναζητήσεις αναφέρουν τις αντιστοιχίες τους στην ίδια κλήση επιστροφής.

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

// Λάβετε το πρώτο σχήμα από την πρώτη διαφάνεια.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Επισημάνετε κάθε εμφάνιση του "try" στο πλαίσιο κειμένου.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Επισημάνετε μόνο τη πλήρη λέξη "to".
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

![The highlighted text](highlighted_text.png)

## **Επισήμανση Κειμένου με Κανονικές Εκφράσεις**

Η μέθοδος [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlightregex/) επισημαίνει τις αντιστοιχίες κειμένου που βρέθηκαν από κανονική έκφραση σε ένα πλαίσιο κειμένου.

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τις μεθόδους [IPresentation::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/highlighttext/) και [IPresentation::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/highlightregex/) για να αναζητήσετε όλα τα εφαρμόσιμα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email, διατηρώντας ξεχωριστές συλλογές αποτελεσμάτων για τις δύο αναζητήσεις.

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

Χρησιμοποιήστε το [ITextFrame::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replacetext/) για κυριολεκτικό κείμενο και το [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replaceregex/) για αντικατάσταση βάσει προτύπου. Αυτές οι μέθοδοι ενημερώνουν το αντιστοιχισμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου, διατηρώντας τη μορφοποίηση του περιβάλλοντος τμήματος αντί να ξαναχτίζουν το πλαίσιο κειμένου από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα ενοποιεί μια παραλλαγή ορθογραφίας και, στη συνέχεια, αντικαθιστά ετικέτες εκδόσεων. Η ίδια κλήση επιστροφής καταγράφει τους αρχικούς όρους που ταιριάζουν και από τις δύο λειτουργίες.

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

## **Αντικατάσταση Κειμένου σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τις μεθόδους [IPresentation::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/replacetext/) και [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/replaceregex/) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και διαγραφές.

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

## **Ομαδοποίηση Αντιστοιχιών για Αναφορά**

Καθώς κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιούν τις αντιστοιχίες για ελέγχους, αναφορές ή διαδικασίες ανασκόπησης. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα ανά διαφάνεια και μετά ανά πλαίσιο κειμένου:

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

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε το [ITextFrame::HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replacetext/) ή το [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replaceregex/) σε εκείνο το πλαίσιο κειμένου. Οι μέθοδοι επιπέδου παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου αντίθετα.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με τη σωστή κεφαλαιοποίηση;**

Καλέστε το [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) και το [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) με `true`, και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και την ευαισθησία πεζών‑κεφαλαίων στο ίδιο το `System::Text::RegularExpressions::Regex`.

**Μπορεί η αναζήτηση και η αντικατάσταση να περιλαμβάνουν κείμενο στις σημειώσεις διαφάνειας;**

Ναι. Καλέστε το [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/set_includenotes/) με `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου επιπέδου παρουσίασης. Η υλοποίηση της κλήσης επιστροφής που εμφανίζεται παραπάνω αντιστοιχίζει μια αντιστοιχία σε μια σημείωση διαφάνειας στον αριθμό της γονικής διαφάνειας.

**Πώς μπορώ να δημιουργήσω μια αναφορά χωρίς να σαρώσω ξανά την παρουσίαση;**

Περάστε μια υλοποίηση του [IFindResultCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifindresultcallback/) στην λειτουργία επισήμανσης ή αντικατάστασης. Η κλήση επιστροφής λαμβάνει κάθε αντιστοιχία καθώς εκτελείται η λειτουργία, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον προεξαγόμενο αριθμό διαφάνειας για μετέπειτα ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίηση του;**

Τα [ITextFrame::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replacetext/) και [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/replaceregex/) τροποποιούν το αντιστοιχισμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου και διατηρούν τη μορφοποίηση του περιβάλλοντος τμήματος. Εάν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να βεβαιωθείτε ότι η αντικατάσταση χρησιμοποιεί το επιθυμητό στυλ.