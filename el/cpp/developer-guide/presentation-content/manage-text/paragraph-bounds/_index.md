---
title: Απόκτηση ορίων παραγράφων από παρουσιάσεις σε C++
linktitle: Όρια Παραγράφων
type: docs
weight: 43
url: /el/cpp/paragraph-bounds/
keywords:
- όρια παραγράφων
- συντεταγμένη παραγράφου
- μέγεθος παραγράφου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφων στο Aspose.Slides για C++ ώστε να βελτιστοποιήσετε τη θέση του κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λάβετε τα όρια, το μέγεθος και τις συντεταγμένες των παραγράφων στο Aspose.Slides. Δείχνει πώς να ανακτήσετε ένα ορθογώνιο παραγράφου από ένα [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) χρησιμοποιώντας το [IParagraph::GetRect](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/getrect/), πώς να λάβετε τις συντεταγμένες της παραγράφου μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και επισημαίνει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixels και οι αποτελεσματικές τιμές μορφοποίησης παραγράφου.

## **Λήψη Ορθογώνιων Συντεταγμένων Παραγράφου**

Χρησιμοποιήτε το [IParagraph::GetRect](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/getrect/) για να λάβετε το ορθογώνιο περιθώριο μιας παραγράφου.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Λήψη του Μεγέθους μιας Παραγράφου σε Πλαίσιο Κειμένου Κελιού Πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες ενός [IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/) σε πλαίσιο κειμένου κελιού πίνακα, χρησιμοποιήτε το [IParagraph::GetRect](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/getrect/). Το επιστραφέν ορθογώνιο είναι σχετικό με το πλαίσιο κειμένου του κελιού πίνακα, επομένως προσθέστε τη θέση του πίνακα και την μετατόπιση του κελιού όταν χρειάζεστε συντεταγμένες επιπέδου διαφάνειας.

Το παρακάτω παράδειγμα εμφανίζει τα όρια μιας παραγράφου μέσα σε κελί πίνακα και σχεδιάζει ορθογώνια στη διαφάνεια για να οπτικοποιήσει αυτά τα όρια:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες μετρώνται οι συντεταγμένες της παραγράφου;**

Μετρώνται σε points, όπου 1 ίντσα ισούται με 72 points. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν η μέθοδος [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_wraptext/) είναι ενεργοποιημένη για το [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/), το κείμενο κόβεται ώστε να ταιριάζει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να αντιστοιχιστούν αξιόπιστα σε pixels στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τα points σε pixels χρησιμοποιώντας τον τύπο: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση ή την εξαγωγή.

**Πώς μπορώ να λάβω τις «αποτελεσματικές» παραμέτρους μορφοποίησης της παραγράφου, λαμβάνοντας υπόψη την κληρονόμηση στυλ;**

Χρησιμοποιήτε τη [effective paragraph formatting data structure](/slides/el/cpp/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για τις εσοχές, το διάστημα, την αναδίπλωση, RTL και άλλα.