---
title: Διαμόρφωση κειμένου παρουσίασης σε C++
linktitle: Διαμόρφωση Κειμένου
type: docs
weight: 50
url: /el/cpp/text-formatting/
keywords:
- επισήμανση κειμένου
- κανονική έκφραση
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
- διάστημα γραμμών
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαμορφώστε και στυλιζάστε το κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και πολλά άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides for C++. Καλύπτει την επισήμανση, τα χρώματα φόντου, τη διαφάνεια, την απόσταση χαρακτήρων, τις ιδιότητες γραμματοσειράς, την περιστροφή, το διάστημα παραγράφων, τη συμπεριφορά Autofit, την αγκύρωση κειμένου, τα διαλείμματα στηλοθετών και τις ρυθμίσεις γλώσσας.

Στα παραδείγματα παρακάτω, θα χρησιμοποιήσουμε ένα αρχείο με όνομα “sample.pptx”, το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame.HighlightText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlighttext/) όταν χρειάζεται να επισημάνετε κείμενο που ταιριάζει με ένα συγκεκριμένο δείγμα μέσα σε ένα πλαίσιο κειμένου. Η μέθοδος εφαρμόζει ένα χρώμα επισήμανσης στα τμήματα κειμένου που ταιριάζουν και μπορεί να χρησιμοποιηθεί με το [ITextSearchOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextsearchoptions/) για να ελέγξετε πώς γίνεται η αναζήτηση, π.χ. ώστε να ταιριάζει μόνο ολόκληρες λέξεις.

Ο κώδικας παρακάτω επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και έπειτα επισημαίνει μόνο τη λέξη **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Λάβετε το πρώτο σχήμα από την πρώτη διαφάνεια.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Επισημάνετε τη λέξη "try" στο σχήμα.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Επισημάνετε τη λέξη "to" στο σχήμα.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου Χρησιμοποιώντας Κανονικές Εκφράσεις**

Η μέθοδος [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/highlightregex/) επισήμανει τις αντιστοιχίες κειμένου που βρέθηκαν με κανονική έκφραση. Στη C++, αυτό το API εκτίθεται στο [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/).

Ο κώδικας παρακάτω επισήμανει όλες τις λέξεις που περιέχουν **επτά ή περισσότερους χαρακτήρες**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο χρησιμοποιώντας την κανονική έκφραση](highlighted_text_using_regex.png)

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το `[IParagraphFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε το `[IPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/)`.HighlightColor` για μεμονωμένες περιοχές κειμένου.

Ο παρακάτω κώδικας δείχνει πώς να ορίσετε το χρώμα φόντου για **ολόκληρη την παράγραφο**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Ο κώδικας παρακάτω δείχνει πώς να ορίσετε το χρώμα φόντου για **περιοχές κειμένου με έντονη γραφή**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Ορίστε το χρώμα επισήμανσης για το τμήμα κειμένου.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι γκρι περιοχές κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε το `[IParagraphFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/)`.Alignment` για να ορίσετε το στοίχισμα παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερά, δεξιά, πλήρως ευθυγραμμισμένη κ.λπ.

Ο παρακάτω κώδικας δείχνει πώς να στοίχετε την παράγραφο στο **κέντρο**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Ορίστε την ευθυγράμμιση της παραγράφου στο κέντρο.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η στοιχισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του συστατικού άλφα του χρώματος που έχει οριστεί στο `[IPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/)`.FillFormat`. Στα παραδείγματα παρακάτω, `alpha = 50` είναι μια τιμή καναλιού ARGB σε κλίμακα 0‑255, όχι ποσοστό διαφάνειας.

Ο κώδικας παρακάτω δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Ορίστε το χρώμα γεμίσματος του κειμένου σε διαφανές χρώμα.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Ο παρακάτω κώδικας δείχνει πώς να εφαρμόσετε διαφάνεια σε **περιοχές κειμένου με έντονη γραφή**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Ορίστε τη διαφάνεια του τμήματος κειμένου.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι διαφανείς περιοχές κειμένου](transparent_text_portions.png)

## **Ορισμός Απόστασης Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το `[IBasePortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/)`.Spacing` για να επεκτείνετε ή να συμπτύξετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας C++ δείχνει πώς να επεκτείνετε την απόσταση χαρακτήρων στην **ολόκληρη την παράγραφο**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπτύξετε την απόσταση χαρακτήρων.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Ο κώδικας παρακάτω δείχνει πώς να επεκτείνετε την απόσταση χαρακτήρων σε **περιοχές κειμένου με έντονη γραφή**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπτύξετε την απόσταση χαρακτήρων.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στις περιοχές κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο πυκνά από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint μπορεί να αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να κάνετε την αποτυπώσιμη έξοδο πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για περιοχές κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε το `[IPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` σε τιμή σημαντικά μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
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

Αυτή η ρύθμιση αποτρέπει την εφαρμογή kerning σε αντίστοιχες περιοχές κειμένου και μπορεί να βοηθήσει το Aspose.Slides να ευθυγραμμίζεται με την οπτική απόδοση του PowerPoint για τις γραμματοσειρές που επηρεάζονται από αυτήν τη συμπεριφορά.

## **Διαχείριση Ιδιότητων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του `[IParagraphFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` ή σε μεμονωμένες περιοχές μέσω του `[IPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/)`.

Ο παρακάτω κώδικας ορίζει τη γραμματοσειρά και το στυλ κειμένου για ολόκληρη την παράγραφο: εφαρμόζει μέγεθος γραμματοσειράς, έντονη, πλάγια, υπογράμμιση με τελείες και τη γραμματοσειρά Times New Roman σε όλες τις περιοχές της παραγράφου.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Ο κώδικας παρακάτω εφαρμόζει παρόμοιες ιδιότητες σε **περιοχές κειμένου με έντονη γραφή**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Ορίστε τις ιδιότητες γραμματοσειράς για το τμήμα κειμένου.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για τις περιοχές κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το `[ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` για να ορίσετε προκαθορισμένο προσανατολισμό κειμένου μέσα σε σχήμα.

Ο παρακάτω κώδικας ορίζει τον προσανατολισμό κειμένου στο σχήμα σε `Vertical270`, που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η περιστροφή κειμένου](text_rotation.png)

## **Προσαρμοσμένη Περιστροφή για Πλαίσια Κειμένου**

Χρησιμοποιήστε το `[ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/)`.RotationAngle` για να ορίσετε προσαρμοσμένη γωνία περιστροφής για ένα `[ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/)`.

Ο κώδικας παρακάτω περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμών Παραγράφων**

Το Aspose.Slides παρέχει τα `[IParagraphFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore` και `IParagraphFormat.SpaceWithin` για να ελέγχετε το διάστημα παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να καθορίσετε το διάστημα γραμμής ως ποσοστό του ύψους γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να καθορίσετε το διάστημα γραμμής σε σημεία.

Ο παρακάτω κώδικας δείχνει πώς να καθορίσετε το διάστημα γραμμής μέσα στην παράγραφο:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το διάστημα γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

Το `[ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/)`.AutofitType` καθορίζει πώς συμπεριφέρεται το κείμενο όταν ξεπερνά τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, υπερέχει ή αλλάζει αυτόματα το μέγεθος του σχήματος.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

Το `[ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/)`.AnchoringType` καθορίζει πώς τοποθετείται το κείμενο κάθετα μέσα σε σχήμα, π.χ. στην κορυφή, στο μέσο ή στη βάση.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός Ταμπώσεων Κειμένου**

Χρησιμοποιήστε το `[IParagraphFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` και `IParagraphFormat.Tabs` για να ρυθμίσετε τα διαλείμματα ταμπών σε μια παράγραφο.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι ταμπές της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Το Aspose.Slides παρέχει το `[IPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/)`.LanguageId`, το οποίο σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για μια περιοχή κειμένου. Η γλώσσα ελέγχου ορθογραφίας καθορίζει τη γλώσσα που χρησιμοποιείται για ελέγχους ορθογραφίας και γραμματικής στο PowerPoint.

Ο παρακάτω κώδικας δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για μια περιοχή κειμένου:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Set the Id of a proofing language.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το `[ILoadOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή δημιουργία μιας παρουσίασης.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα νέο σχήμα ορθογώνιο με κείμενο.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Ελέγξτε τη γλώσσα της πρώτης περιοχής.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το `[IPresentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`.

Ο παρακάτω κώδικας δείχνει πώς να ορίσετε μια προεπιλεγμένη έντονη γραμματοσειρά μεγέθους 14 pt για όλο το κείμενο σε όλες τις διαφάνειες μιας νέας παρουσίασης.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Λάβετε τη μορφοποίηση παραγράφου ανώτερου επιπέδου.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Εξαγωγή Κειμένου με Εφέ Όλων Σε Κεφαλαία**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στην διαφάνεια ακόμη και αν αρχικά είχε πληκτρολογηθεί με πεζά. Όταν ανακτάτε μια τέτοια περιοχή κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/cpp/aspose.slides/textcaptype/) και μετατρέψτε τη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Ας υποθέσουμε ότι έχουμε το παρακάτω πλαίσιο κειμένου στην πρώτη διαφάνεια του αρχείου sample2.pptx.

![Το εφέ All Caps](all_caps_effect.png)

Ο κώδικας παρακάτω δείχνει πώς να εξάγετε το κείμενο με το εφέ **All Caps** εφαρμοσμένο:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Συχνές Ερωτήσεις**

**Πώς να τροποποιήσετε το κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το `[ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/)`. Περιηγηθείτε στα κελιά και ενημερώστε κάθε κελί μέσω του `[ICell](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/)`.TextFrame` και τη μορφοποίηση παραγράφου μέσω του `[IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`.

**Πώς να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο σε διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το `[IPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/)`.FillFormat`. Ορίστε το `[IFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifillformat/)`.FillType` σε `[FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/)`.Gradient` και διαμορφώστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.