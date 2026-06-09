---
title: Λήψη Ορίων Παραγράφου από Παρουσιάσεις σε C++
linktitle: Παράγραφος
type: docs
weight: 60
url: /el/cpp/paragraph/
keywords:
- όρια παραγράφου
- όρια τμήματος κειμένου
- συντεταγμένη παραγράφου
- συντεταγμένη τμήματος
- μέγεθος παραγράφου
- μέγεθος τμήματος κειμένου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να ανακτάτε τα όρια παραγράφου και τμήματος κειμένου στο Aspose.Slides για C++ προκειμένου να βελτιστοποιήσετε την τοποθέτηση κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λαμβάνετε τα όρια, το μέγεθος και τις συντεταγμένες παραγράφων και τμημάτων κειμένου στο Aspose.Slides. Δείχνει πώς να ανακτήσετε το ορθογώνιο μιας παραγράφου σε ένα `TextFrame` χρησιμοποιώντας τη μέθοδο `GetRect()`, πώς να λάβετε τις συντεταγμένες της παραγράφου και του τμήματος μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και επισημαίνει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel και οι τιμές της αποτελεσματικής μορφοποίησης παραγράφων.

## **Λήψη Συντεταγμένων Παραγράφου και Τμήματος σε TextFrame**

Με τη χρήση του Aspose.Slides για C++, οι προγραμματιστές μπορούν πλέον να λαμβάνουν τις ορθογώνιες συντεταγμένες για Paragraph μέσα στη συλλογή παραγράφων του TextFrame. Επιτρέπει επίσης τη λήψη των συντεταγμένων ενός τμήματος μέσα στη συλλογή τμημάτων μιας παραγράφου. Σε αυτό το θέμα, θα δείξουμε με τη βοήθεια ενός παραδείγματος πώς να λαμβάνετε τις ορθογώνιες συντεταγμένες για μια παράγραφο μαζί με τη θέση του τμήματος μέσα στην παράγραφο.

## **Λήψη Ορθογώνιων Συντεταγμένων Παραγράφου**

Η νέα μέθοδος **GetRect()** έχει προστεθεί. Επιτρέπει τη λήψη του ορθογωνίου ορίων της παραγράφου.

``` cpp
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Λήψη του Μεγέθους Παραγράφου και Τμήματος μέσα σε TextFrame Κελιού Πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες του [Τμήματος](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.portion) ή της [Παραγράφου](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.paragraph) σε ένα πλαίσιο κειμένου κελιού πίνακα, μπορείτε να χρησιμοποιήσετε τις μεθόδους [IPortion::GetRect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) και [IParagraph::GetRect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Αυτός ο κώδικας δείγματος επιδεικνύει τη περιγραφόμενη λειτουργία:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Σε ποιες μονάδες επιστρέφονται οι συντεταγμένες για μια παράγραφο και τμήματα κειμένου;**

Σε πόντους, όπου 1 ίντσα = 72 πόντοι. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν η [αναδίπλωση](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframeformat/set_wraptext/) είναι ενεργοποιημένη στο [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframe/), το κείμενο χωρίζεται ώστε να ταιριάζει στο πλάτος της περιοχής, γεγονός που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να αντιστοιχούν αξιόπιστα σε pixel στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τους πόντους σε pixel χρησιμοποιώντας: pixel = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση/εξαγωγή.

**Πώς μπορώ να λάβω τις «αποτελεσματικές» παραμέτρους μορφοποίησης παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα στυλ;**

Χρησιμοποιήστε τη [δεδομένα αποτελεσματικής μορφοποίησης παραγράφου](/slides/el/cpp/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.