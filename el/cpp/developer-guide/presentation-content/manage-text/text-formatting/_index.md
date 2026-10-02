---
title: Μορφοποίηση κειμένου παρουσίασης σε C++
linktitle: Μορφοποίηση κειμένου
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
- άγκυρο πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μορφοποίηση και στυλιζάρισμα κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++. Προσαρμόστε τις γραμματοσειρές, τα χρώματα, την στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++. Καλύπτει τα χρώματα φόντου, τη διαφάνεια, το διάστημα χαρακτήρων, τις ιδιότητες γραμματοσειράς, την περιστροφή, το διάστημα παραγράφων, τη συμπεριφορά αυτόματης προσαρμογής, την αγκύρωση κειμένου, τις στάσεις στηλέδων και τις ρυθμίσεις γλώσσας.

Εκτός αν αναφέρεται κάτι διαφορετικό, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνειά του είναι ένα πεδίο κειμένου, και η πρώτη του παράγραφος περιέχει το κείμενο που φαίνεται παρακάτω. Και οι δείκτες των διαφανειών και των σχημάτων είναι μηδενικής βάσης. Τα παραδείγματα που επιλέγουν έντονες (bold) περιοχές χρησιμοποιούν την αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισημάνετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/cpp/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε το [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) για μεμονωμένες περιοχές κειμένου.

Το παρακάτω παράδειγμα ορίζει μια ανοιχτόγκρι επισήμανση ως προεπιλογή για την πρώτη παράγραφο. Τα ρητά χρώματα επισήμανσης σε μεμονωμένες περιοχές έχουν προτεραιότητα πάνω από αυτήν την προεπιλογή:

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

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **περιοχές κειμένου με έντονη γραμματοσειρά**:

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
        // Ορίστε το χρώμα επισήμανσης για την περιοχή κειμένου.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι γκρι περιοχές κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) για να ορίσετε την στοίχιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, πλήρως στοίχισμένη κ.λπ.

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
// Ορίστε την ευθυγράμμιση της παραγράφου στο κέντρο.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η στοιχισμένη παράγραφος](aligned_paragraph.png)

## **Στοίχιση Γραμματοσειρών Μέσα σε Μία Γραμμή**

Χρησιμοποιήστε το [IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) για να ευθυγραμμίσετε κατακόρυφα περιοχές κειμένου διαφορετικού μεγέθους γραμματοσειράς μέσα σε μια γραμμή. Αυτή η ρύθμιση εφαρμόζεται στην ολόκληρη την παράγραφο και ελέγχει τη στοίχιση σε κάθε μία από τις γραμμές της.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τέσσερα ετικετισμένα πεδία κειμένου σε μια διαφάνεια. Κάθε παράγραφος περιέχει το ίδιο κείμενο σε μεγέθη 18, 36 και 54 σημεία, με διαφορετική στοίχιση γραμματοσειράς. Χρησιμοποιεί Arial, απενεργοποιεί την αυτόματη προσαρμογή και την αναδίπλωση, και διατηρεί τα πλαίσια κειμένου αρκετά μεγάλα για μία γραμμή.

```cpp
#include <DOM/FontAlignment.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

FontAlignment alignments[] = { FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom };
String labels[] = { u"Baseline", u"Top", u"Center", u"Bottom" };
float fontSizes[] = { 18.0f, 36.0f, 54.0f };
auto font = MakeObject<FontData>(u"Arial");

for (auto i = 0; i < 4; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20 + i * 130, 660, 120);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);

    auto label = textFrame->get_Paragraph(0);
    label->set_Text(labels[i]);
    label->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto labelFormat = label->get_ParagraphFormat()->get_DefaultPortionFormat();
    labelFormat->set_FontHeight(14);
    labelFormat->set_LatinFont(font);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_FontAlignment(alignments[i]);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto portionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    portionFormat->set_LatinFont(font);
    portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
    portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    for (auto fontSize : fontSizes)
    {
        auto portion = MakeObject<Portion>(u"Ag ");
        portion->get_PortionFormat()->set_FontHeight(fontSize);
        paragraph->get_Portions()->Add(portion);
    }

    textFrame->get_Paragraphs()->Add(paragraph);
}

presentation->Save(u"font_alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Σύγκριση στοίχισης γραμματοσειράς Βάσης, Πάνω, Κέντρο και Κάτω με μεικτά μεγέθη γραμματοσειράς](font_alignment.png)

Η στοίχιση γραμματοσειράς χρησιμοποιεί μετρικές γραμματοσειράς, έτσι οι ορατές άκρες των μεμονωμένων γραμμάτων δεν ευθυγραμμίζονται απαραίτητα ακριβώς. Το παράδειγμα περιλαμβάνει τόσο ένα κεφαλαίο γράμμα όσο και ένα κατάβατο χαρακτήρα για να δείξει τη διαφορά μεταξύ στοίχισης βάσης και κάτω. Η διαθεσιμότητα και η αντικατάσταση της γραμματοσειράς, οι χαρακτήρες που χρησιμοποιούνται και η διαφορά στα μεγέθη της γραμματοσειράς επηρεάζουν το αποτέλεσμα. Οι διαστάσεις του πλαισίου, τα περιθώρια, το διάστημα μεταξύ γραμμών, η αναδίπλωση και η αυτόματη προσαρμογή επηρεάζουν επίσης τη διάταξη· χρησιμοποιήστε τις ίδιες γραμματοσειρές και ρυθμίσεις διάταξης όταν συγκρίνετε τις λειτουργίες.

Αυτή η ρύθμιση διαφέρει από το [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/), που ελέγχει την οριζόντια στοίχιση παραγράφου, και το [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/), που τοποθετεί το μπλοκ κειμένου κάθετα μέσα στο σχήμα του. Η μορφοποίηση εκθέτη και υπο‑εκθέτη μέσω του [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) μετατοπίζει τις μεμονωμένες περιοχές σε σχέση με τη βάση αντί να ορίζει τη στοίχιση γραμματοσειράς για τις γραμμές της παραγράφου.

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του συνιστώσας άλφα του χρώματος που ορίζεται με το [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή καναλιού άλφα ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στο **ολόκληρη παράγραφος**:

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

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **περιοχές κειμένου με έντονη γραμματοσειρά**:

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
        // Ορίστε τη διαφάνεια της περιοχής κειμένου.
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

![Οι διαφανείς περιοχές κειμένου](transparent_text_portions.png)

## **Ορισμός Διανομής Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) για να αυξήσετε ή να μειώσετε το διάστημα μεταξύ των χαρακτήρων σε ένα πεδίο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία διαστήματος· οι αρνητικές τιμές μειώνουν το κείμενο.

Το παρακάτω C++ κώδικας δείχνει πώς να επεκτείνετε τη διανομή χαρακτήρων στην **ολόκληρη παράγραφος**:

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
// Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Αυξήστε το διάστημα χαρακτήρων.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η διανομή χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να επεκτείνετε τη διανομή χαρακτήρων σε **περιοχές κειμένου με έντονη γραμματοσειρά**:

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
        // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
        portionFormat->set_Spacing(3.0f); // Αυξήστε το διάστημα χαρακτήρων.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η διανομή χαρακτήρων στις περιοχές κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Στελέχωσης για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο πυκνό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβεί επειδή το PowerPoint μπορεί να αγνοήσει τα δεδομένα στελέχωσης για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες στελέχωσης και η στελέχωση είναι ενεργοποιημένη στις ρυθμίσεις του PowerPoint.

Για να κάνετε την απόδοση πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε τη στελέχωση για τις περιοχές κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Χρησιμοποιήστε το [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) για να ορίσετε μια τιμή μεγαλύτερη από το πραγματικό μέγεθος της γραμματοσειράς. Αυτό το παράδειγμα απαιτεί το "presentation.pptx" με ένα πεδίο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και ορίζει ένα όριο 100 σημείων για τις περιοχές που χρησιμοποιούν το Roboto. Αυτό απενεργοποιεί τη στελέχωση για τις αντίστοιχες περιοχές με μέγεθος γραμματοσειράς κάτω των 100 σημείων:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IPortionFormatEffectiveData.h>
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
        auto textFormat = portionFormat->GetEffective();
        auto latinFont = textFormat->get_LatinFont();
        auto eastAsianFont = textFormat->get_EastAsianFont();
        auto complexScriptFont = textFormat->get_ComplexScriptFont();

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

Για κείμενο που ταιριάζει και βρίσκεται κάτω από το όριο, αυτή η ρύθμιση αποτρέπει τη στελέχωση και μπορεί να βοηθήσει στη σύγκλιση της απόδοσης του Aspose.Slides με το οπτικό αποτέλεσμα του PowerPoint για τις γραμματοσειρές που επηρεάζονται από αυτήν τη συμπεριφορά του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες της γραμματοσειράς μπορούν να οριστούν στο επίπεδο παραγράφου μέσω του [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) ή σε μεμονωμένες περιοχές μέσω του [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείων με έντονη, πλάγια και υπογράμμιση με κουκκίδες. Η ρητή μορφοποίηση σε μεμονωμένες περιοχές έχει προτεραιότητα έναντι αυτών των προεπιλογών:

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

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημείων, πλάγια μορφοποίηση και υπογράμμιση με κουκκίδες σε περιοχές των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

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
        // Ορίστε τις ιδιότητες γραμματοσειράς για την περιοχή κειμένου.
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

![Οι ιδιότητες γραμματοσειράς για τις περιοχές κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) για να ορίσετε μια προκαθορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερά**:

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

Χρησιμοποιήστε το [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).

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

## **Ορισμός Διαστήματος Γραμμής των Παραγράφων**

Το Aspose.Slides παρέχει τα [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/), και [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) για τον έλεγχο του διαστήματος παραγράφων. Αυτές οι μέθοδοι χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε μια θετική τιμή για να καθορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήτε μια αρνητική τιμή για να καθορίσετε το διάστημα γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει το διάστημα εντός της πρώτης παραγράφου στο 200% του ύψους της γραμμής (διπλό διάστημα):

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

![Το διάστημα γραμμής εντός της παραγράφου](line_spacing.png)

## **Έλεγχος Σπάσης Γραμμής**

Οι κανόνες σπασίματος γραμμής παραγράφων είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και ασιατικό κείμενο. Οι παρακάτω μέθοδοι ανήκουν στο [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/), έτσι εφαρμόζονται σε ολόκληρη την παράγραφο:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) ελέγχει τους κανόνες σπασίματος γραμμής για λατινικό κείμενο. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου το κείμενο και η στίξη της Ανατολικής Ασίας αναδιπλώνονται.
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) ελέγχει τους κανόνες σπασίματος γραμμής για Ασία, συμπεριλαμβανομένων περιορισμών σε χαρακτήρες στην αρχή και το τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/), το οποίο ενεργοποιεί την αυτόματη αναδίπλωση μέσα σε ένα πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν συμβαίνει η αναδίπλωση· δεν εισάγουν χαρακτήρες αλλαγής γραμμής. Μια ρητή αλλαγή γραμμής προκαλεί νέα γραμμή στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει κινέζικο και λατινικό κείμενο. Ορίζει ρητά και τους δύο κανόνες σπασίματος και αποθηκεύει το «line_breaking.pptx». Για να πειραματιστείτε με οποιονδήποτε κανόνα, αλλάξτε την τιμή που περνάτε στον setter διατηρώντας τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί Arial 24 σημείων και SimSun με πλάτος πλαισίου 160 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) καλείται με το [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις του πλαισίου να παραμείνουν σταθερά.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 160.0f, 300.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"中文排版测试，PowerPoint 中文演示。");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
auto eastAsianFont = System::MakeObject<FontData>(u"SimSun");
portionFormat->set_EastAsianFont(eastAsianFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_LatinLineBreak(NullableBool::False);
format->set_EastAsianLineBreak(NullableBool::True);

presentation->Save(u"line_breaking.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Έλεγχος Κρεμαστών Σημείων Στίξης**

Το [IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) επιτρέπει στα κατάλληλα σημεία στίξης να επεκταθούν πέρα από το δεξιό άκρο της γραμμής κειμένου αντί να καταλάβουν την επόμενη γραμμή. Εφαρμόζεται στην ολόκληρη την παράγραφο και διαφέρει από ένα κρεμασμένο εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί κρεμαστά σημεία στίξης σε πλαίσιο κειμένου με πλάτος 100 σημείων και αποθηκεύει το «hanging_punctuation.pptx». Με Arial 24 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου, η τελική τελεία παραμένει μετά το «sentence» και εκτείνεται πέρα από το δεξιό άκρο του κειμένου. Πραγματοποιήστε κλήση με το [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργοποιημένη και η αυτόματη προσαρμογή είναι απενεργοποιημένη για να διατηρηθεί το διαθέσιμο πλάτος σταθερό.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 200.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"Simple text, next sentence.");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_HangingPunctuation(NullableBool::True);

presentation->Save(u"hanging_punctuation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Δεν μπορεί να κρεμαστεί κάθε σημάδι στίξης. Οι [συνθήκες γραμματοσειράς και διάταξης που περιγράφησαν παραπάνω](#control-line-breaking) ισχύουν επίσης για αυτήν τη σύγκριση: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων αυτόματης προσαρμογής μπορεί να αφαιρέσει τη διακριτή διαφορά.

## **Ορισμός Τύπου Αυτόματης Προσαρμογής για Πλαίσια Κειμένου**

Το [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, υπερέχει ή αλλάζει αυτόματα το μέγεθος του σχήματος ώστε να ταιριάζει. Το παρακάτω παράδειγμα ρυθμίζει το σχήμα ώστε να αλλάζει μέγεθος ώστε να ταιριάζει στο κείμενο του και αποθηκεύει το αποτέλεσμα στο «autofit_type.pptx».

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

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς το κείμενο ή το πλάτος του σχήματος αλλάζει το αποτέλεσμα, δείτε [Καταμέτρηση Σχεδίαστων Γραμμών](/slides/el/cpp/manage-paragraph/). Ο μόνος ο αριθμός γραμμών δεν δείχνει αν το κείμενο υπερέχει του περιέκτη του.

## **Ορισμός Αγκύρωσης Πλαισίων Κειμένου**

Το [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) ορίζει πώς τοποθετείται το κείμενο κατακόρυφα μέσα σε ένα σχήμα, π.χ. στην κορυφή, στο μέσο ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο «text_anchor.pptx».

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

## **Ορισμός Στηλοθέτησης Κειμένου**

Χρησιμοποιήστε τα [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) και [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) για να ρυθμίσετε στάσεις στηλέδας σε μια παράγραφο. Το παρακάτω παράδειγμα θέτει την προεπιλεγμένη απόσταση στηλέδας στα 100 σημεία και προσθέτει μια αριστερά στοίχηση στηλέδας στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν κείμενο που περιέχει χαρακτήρες στηλέδας.

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

![Οι στηλοθέτες της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Διόρθωσης**

Το Aspose.Slides παρέχει το [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/), το οποίο επιτρέπει τον ορισμό της γλώσσας διόρθωσης για μια περιοχή κειμένου. Η γλώσσα διόρθωσης καθορίζει τη γλώσσα που θα χρησιμοποιηθεί για ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με πεδίο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μια παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με «1。», ορίζει το SimSun ως τη γραμματοσειρά του και θέτει τη γλώσσα διόρθωσης απλοποιημένου Κινέζικου (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο «proofing_language.pptx»:

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

// Ορίστε τη γλώσσα διόρθωσης σε απλοποιημένα Κινέζικα.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με αμερικανικά αγγλικά ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει πεδίο κειμένου και εκτυπώνει `en-US` για την πρώτη περιοχή κειμένου.

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

// Προσθέστε ένα νέο σχήμα ορθογωνίου με κείμενο.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Ελέγξτε τη γλώσσα της πρώτης περιοχής.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

Το παρακάτω παράδειγμα ορίζει μια γραμματοσειρά 14 σημείων, έντονη, ως προεπιλογή για παραγράφους κορυφαίου επιπέδου σε νέα παρουσίαση και την αποθηκεύει στο «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο συγκεκριμένη μορφοποίηση τις αντικαταστήσει.

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

// Λάβετε τη μορφοποίηση παραγράφου ανώτερου επιπέδου.
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

## **Εξαγωγή Κειμένου με το Εφέ Όλων Κεφαλαίων**

Στο PowerPoint, η εφαρμογή του **Όλα Κεφαλαία** εφέ γραμματοσειράς κάνει το κείμενο να εμφανίζεται με κεφαλαία στην διαφάνεια ακόμη και αν αρχικά είχε πληκτρολογηθεί με πεζά. Όταν ανακτάτε μια τέτοια περιοχή κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) και μετατρέψτε την επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/).

Το παρακάτω παράδειγμα απαιτεί το «sample2.pptx» με πεδίο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη περιοχή της πρώτης παραγράφου περιέχει το «Hello, Aspose!» με το εφέ Όλες Κεφαλαία εφαρμοσμένο, όπως φαίνεται παρακάτω.

![Το εφέ Όλων Κεφαλαίων](all_caps_effect.png)

Το παράδειγμα κώδικα παρακάτω δείχνει πώς να εξάγετε το κείμενο με το **Όλα Κεφαλαία** εφέ εφαρμοσμένο:

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

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να τροποποιήσω το κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Επανάλαβε μέσα από τα κελιά και ενημερώστε κάθε κελί μέσω του [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) και τη μορφοποίηση παραγράφου μέσω του [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**Πώς μπορώ να εφαρμόσω ένα διαβαθμισμένο χρώμα σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε ένα διαβαθμισμένο χρώμα σε κείμενο, χρησιμοποιήστε το [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Ορίστε το [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) σε [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) και διαμορφώστε τις στάσεις διαβάθμισης, την κατεύθυνση και τη διαφάνεια.