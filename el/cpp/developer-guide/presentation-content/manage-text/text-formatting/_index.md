---
title: Μορφοποίηση Κειμένου Παρουσίασης σε C++
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 50
url: /el/cpp/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- εσοχές κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μορφοποιήστε και διαμορφώστε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και πολλά άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++. Καλύπτει τα χρώματα φόντου, τη διαφάνεια, το διάστημα χαρακτήρων, τις ιδιότητες γραμματοσειράς, την περιστροφή, το διάστημα παραγράφων, τη συμπεριφορά αυτόματης προσαρμογής, την αγκύρωση κειμένου, τις στάσεις tab και τις ρυθμίσεις γλώσσας.

Στα παραδείγματα παρακάτω, θα χρησιμοποιήσουμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισημάνετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/cpp/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **όλη την παράγραφο**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
auto highlightColor = System::Drawing::Color::get_LightGray();

// Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto highlightColor = System::Drawing::Color::get_LightGray();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Ορίστε το χρώμα επισήμανσης για το τμήμα κειμένου.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Τα γκρι τμήματα κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_alignment/) για να ορίσετε την στοίχιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερά στοιχισμένη, δεξιά στοιχισμένη, πλήρης στοίχιση, κ.λπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να στοιχίσετε την παράγραφο στο **κέντρο**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextAlignment.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Ορίστε τη στοίχιση της παραγράφου στο κέντρο.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η στοιχισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφα‑συστατικού του χρώματος που έχει οριστεί με χρήση του [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Στα παραδείγματα παρακάτω, `alpha = 50` είναι μια τιμή ARGB αλφα‑καναλιού στην κλίμακα 0‑255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Ορίστε το χρώμα γεμίσματος του κειμένου σε διαφανές χρώμα.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Ορίστε τη διαφάνεια του τμήματος κειμένου.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Τα διαφανή τμήματα κειμένου](transparent_text_portions.png)

## **Ορισμός Διαστήματος Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/set_spacing/) για να επεκτείνετε ή να μειώσετε το διάστημα μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας C++ δείχνει πώς να επεκτείνετε το διάστημα χαρακτήρων στην **ολόκληρη την παράγραφο**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπτύξετε το διάστημα χαρακτήρων.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Διευρύνετε το διάστημα χαρακτήρων.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να επεκτείνετε το διάστημα χαρακτήρων σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπτύξετε το διάστημα χαρακτήρων.
        portionFormat->set_Spacing(3.0f); // Διευρύνετε το διάστημα χαρακτήρων.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στα τμήματα κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο συμπιεσμένο από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβεί επειδή το PowerPoint αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμα και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να φέρετε την αποτύπωση πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν την επηρεασμένη γραμματοσειρά. Χρησιμοποιήστε [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) για να ορίσετε μια τιμή σημαντικά μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
System::String targetFont = u"Roboto";
auto textFrame = autoShape->get_TextFrame();
auto paragraphs = textFrame->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Αυτή η ρύθμιση εμποδίζει την εφαρμογή του kerning σε αντίστοιχα τμήματα κειμένου και μπορεί να βοηθήσει στην ευθυγράμμιση της απόδοσης του Aspose.Slides με την οπτική έξοδο του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά ειδική του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/), ή σε μεμονωμένα τμήματα μέσω του [IPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/).

Ο παρακάτω κώδικας ορίζει τη γραμματοσειρά και το στυλ κειμένου για ολόκληρη την παράγραφο: εφαρμόζει το μέγεθος γραμματοσειράς, έντονη, πλάγια, υπογράμμιση με κουκίδες και τη γραμματοσειρά Times New Roman σε όλα τα τμήματα της παραγράφου.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα κώδικα εφαρμόζει παρόμοιες ιδιότητες σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto font = System::MakeObject<FontData>(u"Times New Roman");

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Ορίστε τις ιδιότητες γραμματοσειράς για το τμήμα κειμένου.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για τα τμήματα κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_textverticaltype/) για να ορίσετε μια προκαθορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Ο παρακάτω κώδικας ορίζει τον προσανατολισμό του κειμένου στο σχήμα σε [TextVerticalType::Vertical270](https://reference.aspose.com/slides/el/cpp/aspose.slides/textverticaltype/), ο οποίος περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η περιστροφή κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_rotationangle/) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμών για Παραγράφους**

Το Aspose.Slides παρέχει τις μεθόδους [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_spacebefore/), και [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_spacewithin/) για να ελέγξετε το διάστημα παραγράφων. Αυτές οι μέθοδοι χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε μια θετική τιμή για να ορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε μια αρνητική τιμή για να ορίσετε το διάστημα γραμμής σε μονάδες point.

Ο παρακάτω κώδικας δείχνει πώς να ορίσετε το διάστημα γραμμής μέσα στην παράγραφο:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το διάστημα γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Ορισμός Τύπου Αυτοπροσαρμογής για Πλαίσια Κειμένου**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_autofittype/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, υπερχειλίζει ή αλλάζει αυτόματα το μέγεθος του σχήματος.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς η αλλαγή του πλάτους του κειμένου ή του σχήματος επηρεάζει το αποτέλεσμα, δείτε [Καταμέτρηση Σχεδιασμένων Γραμμών](/slides/el/cpp/manage-paragraph/). Η απλή καταμέτρηση γραμμών δεν δείχνει αν το κείμενο υπερχειλίζει το περιέκτη του.

## **Ορισμός Άγκυρας για Πλαίσια Κειμένου**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_anchoringtype/) ορίζει πώς το κείμενο τοποθετείται κάθετα μέσα σε ένα σχήμα, π.χ. στην κορυφή, το κέντρο ή το κάτω μέρος.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός Ταμπελίσματος Κειμένου**

Χρησιμοποιήστε [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) και [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/get_tabs/) για να ρυθμίσετε τις στάσεις tab σε μια παράγραφο.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TabAlignment.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι στάσεις tab της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Επιθεώρησης**

Το Aspose.Slides παρέχει [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/set_languageid/), το οποίο σας επιτρέπει να ορίσετε τη γλώσσα επιθεώρησης για ένα τμήμα κειμένου. Η γλώσσα επιθεώρησης καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε τη γλώσσα επιθεώρησης για ένα τμήμα κειμένου:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
auto portionFormat = textPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

// Ορίστε το Id μιας γλώσσας επιθεώρησης.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα νέο σχήμα παραλληλογράμμου με κείμενο.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Ελέγξτε τη γλώσσα του πρώτου τμήματος.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε μια προεπιλεγμένη έντονη γραμματοσειρά με μέγεθος 14 pt για όλο το κείμενο σε όλες τις διαφάνειες μιας νέας παρουσίασης.

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

// Λάβετε τη μορφοποίηση παραγράφου του κορυφαίου επιπέδου.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    auto defaultPortionFormat = paragraphFormat->get_DefaultPortionFormat();
    defaultPortionFormat->set_FontHeight(14.0f);
    defaultPortionFormat->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ανάκτηση Κειμένου με το Εφέ All Caps**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** στη γραμματοσειρά κάνει το κείμενο να εμφανίζεται σε κεφαλαία στην διαφάνεια ακόμα και αν αρχικά είχε πληκτρολογηθεί με μικρά γράμματα. Όταν ανακτάτε ένα τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθηκε. Για να ταιριάζει με το εμφανιζόμενο κείμενο, ελέγξτε το TextCapType και μετατρέψτε την επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι [TextCapType::All](https://reference.aspose.com/slides/el/cpp/aspose.slides/textcaptype/).

Ας υποθέσουμε ότι έχουμε το ακόλουθο πλαίσιο κειμένου στην πρώτη διαφάνεια του αρχείου sample2.pptx.

![Το εφέ All Caps](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με εφαρμοσμένο το εφέ **All Caps**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextCapType.h>
#include <system/console.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

auto originalText = textPortion->get_Text();
System::Console::WriteLine(u"Original text: " + originalText);

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto uppercaseText = originalText.ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + uppercaseText);
}

presentation->Dispose();
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Πώς να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/). Επαναλάβετε πάνω στα κελιά και ενημερώστε κάθε κελί μέσω του [ICell::get_TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/get_textframe/) και τη μορφοποίηση παραγράφου μέσω του [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**Πώς να εφαρμόσετε διαβαθμισμένο χρώμα σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε διαβαθμισμένο χρώμα σε κείμενο, χρησιμοποιήστε [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Ορίστε το [IFillFormat::set_FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifillformat/set_filltype/) σε [FillType::Gradient](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) και διαμορφώστε τα στάδια του gradient, την κατεύθυνση και τη διαφάνεια.