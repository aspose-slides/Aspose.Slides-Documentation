---
title: Διαχείριση Πινάκων Παρουσίασης σε C++
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/cpp/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση σε πίνακα
- αναλογία διαστάσεων
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε και επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint με το Aspose.Slides για C++. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιώσετε τη ροή εργασίας με τους πίνακες."
---
## **Εισαγωγή**

Οι πίνακες στο PowerPoint οργανώνουν τις πληροφορίες σε γραμμές και στήλες, καθιστώντας πιο εύκολο το ανάγνωση και τη σύγκριση των τιμών.

Το Aspose.Slides παρέχει την κλάση [Πίνακας](https://reference.aspose.com/slides/cpp/aspose.slides/table/) (Table), τη διασύνδεση [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/), την κλάση [Κελί](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) (Cell), τη διασύνδεση [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) και άλλους τύπους για να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε παρουσιάσεις.

## **Δημιουργία Πίνακα από το Μηδέν**

Δημιουργήστε έναν πίνακα καθορίζοντας τη θέση του, το πλάτος των στηλών και το ύψος των γραμμών. Μετά την προσθήκη του σε μια διαφάνεια, μπορείτε να διαμορφώσετε τα περιθώρια των κελιών, να συγχωνεύσετε κελιά και να εισάγετε κείμενο.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Ορίστε έναν πίνακα με το πλάτος των στηλών σε points.
4. Ορίστε έναν πίνακα με το ύψος των γραμμών σε points.
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Διέρνετε κάθε [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) για να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά περιγράμματα.
7. Συγχωνεύστε τα πρώτα δύο κελιά της πρώτης γραμμής του πίνακα.
8. Προσπελάστε το συγχωνευμένο κελί μέσω της μεθόδου [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/).
9. Ορίστε το κείμενο στο συγχωνευμένο κελί.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα με τρεις στήλες και πέντε γραμμές στο (100, 50) points. Εφαρμόζει κόκκινα περιγράμματα με πλάτος 5 points, συγχωνεύει τα πρώτα δύο κελιά στην πρώτη γραμμή και αποθηκεύει το αποτέλεσμα ως `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, οι δείκτες των κελιών είναι μηδενικής βάσης και χρησιμοποιούν τη σειρά (στήλη, γραμμή). Το πρώτο κελί έχει δείκτη (0, 0).

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 γραμμές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτό το παράδειγμα δημιουργεί τον πίνακα 4 × 4 που φαίνεται παραπάνω, με πλάτος στηλών και ύψος γραμμών 70 points και κόκκινα περιγράμματα κελιών πλάτους 5 points. Οι συντεταγμένες απεικονίζουν τους δείκτες των κελιών· το παράδειγμα αφήνει τα κελιά κενά και αποθηκεύει τον πίνακα ως `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

Οι πίνακες αποθηκεύονται στη συλλογή σχημάτων μιας διαφάνειας. Διατρέξτε τα σχήματα για να εντοπίσετε έναν πίνακα, έπειτα χρησιμοποιήστε τη διασύνδεση [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) για να διαβάσετε ή να ενημερώσετε τα κελιά του.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα με το δείκτη της.
3. Διατρέξτε τα αντικείμενα [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) και σταματήστε όταν βρεθεί ένας πίνακας. Αν η διαφάνεια περιέχει πολλούς πίνακες, χρησιμοποιήστε το [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) για να εντοπίσετε αυτόν που χρειάζεστε.
4. Ενημερώστε το κείμενο στο επιθυμητό κελί.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `UpdateExistingTable.pptx` και εντοπίζει τον πρώτο πίνακα στην πρώτη διαφάνεια. Ορίζει το κελί στη στήλη 0, γραμμή 1 σε `New` και αποθηκεύει το αποτέλεσμα ως `table1_out.pptx`. Το εισερχόμενο αρχείο πρέπει να περιέχει τουλάχιστον μία διαφάνεια, και ο πρώτος πίνακας σε αυτή τη διαφάνεια πρέπει να έχει τουλάχιστον μία στήλη και δύο γραμμές.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Για να αλλάξετε το μέγεθος μιας γραμμής σε υπάρχον πίνακα και να κατανοήσετε γιατί το πραγματικό του ύψος μπορεί να υπερβαίνει το ελάχιστο που ζητήθηκε, δείτε [Έλεγχος Ύψους Γραμμής](/slides/el/cpp/manage-rows-and-columns/#control-row-height).

## **Εύρεση του Κελιού που Κατέχει ένα Πλαίσιο Κειμένου**

Όταν γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) από πίνακα, χρησιμοποιήστε το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) για να ανακτήσετε το ιδιοκτήτη [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/). Για πλαίσιο κειμένου κελιού πίνακα, το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) επιστρέφει τον ιδιοκτήτη και το [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) επιστρέφει `nullptr`, ακόμη και αν ο πίνακας είναι ίδιο το σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο για ανάγνωση μεθόδων [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) και [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/). Το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) παρέχει επίσης μόνο‑ανάγνωση πλοήγηση: επιστρέφει τον ιδιοκτήτη αλλά δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε αν το επιστρεφόμενο κελί είναι `nullptr` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κελιών πίνακα και σχημάτων, συμπεριλαμβανομένων σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/cpp/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

Μπορείτε να ελέγξετε την κάθετη αγκύρωση και την κατεύθυνση κειμένου των μεμονωμένων κελιών πίνακα. Το παράδειγμα σε αυτήν την ενότητα κεντράρει το κείμενο στο πρώτο κελί και το περιστρέφει κατά 270 μοίρες.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) στη διαφάνεια.
4. Προσπελάστε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) από τον πίνακα.
5. Προσπελάστε το πρώτο [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) και ορίστε το κείμενο και το χρώμα του.
6. Ορίστε την κάθετη αγκύρωση του κελιού και την κατεύθυνση κειμένου χρησιμοποιώντας τις μεθόδους [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) και [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με πλάτος στηλών 120 points και ύψος γραμμών 100 points. Διαμορφώνει το κείμενο στο κελί (0, 0), προσθέτει τιμές στα υπόλοιπα κελιά της πρώτης γραμμής και αποθηκεύει το αποτέλεσμα ως `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

Χρησιμοποιήστε τη μέθοδο [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) για να εφαρμόσετε μορφοποίηση κειμένου σε όλα τα κελιά ενός πίνακα. Οι υπερφορτώσεις της δέχονται μορφοποίηση τμήματος, παραγράφου και πλαισίου κειμένου, ώστε να μπορείτε να ορίσετε αυτές τις ιδιότητες χωρίς να διατρέχετε ξεχωριστά κάθε κελί.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Προσπελάστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) από τη διαφάνεια.
4. Ορίστε το μέγεθος γραμματοσειράς χρησιμοποιώντας τη μέθοδο [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) για το κείμενο.
5. Ορίστε την στοίχιση παραγράφου και το δεξί περιθώριο χρησιμοποιώντας τις μεθόδους [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) και [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Ορίστε την κατεύθυνση κειμένου χρησιμοποιώντας τη μέθοδο [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `table.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο σχήμα. Ορίζει το μέγεθος γραμματοσειράς σε 25 points, στοιχίζει τις παραγράφους δεξιά με δεξιό περιθώριο 20 points και κάνει το κείμενο κάθετο. Η μορφοποιημένη παρουσίαση αποθηκεύεται ως `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε τη μέθοδο [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) για να διαβάσετε το προεπιλεγμένο στυλ ενός πίνακα και τη μέθοδο [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) για να το ορίσετε. Αυτό το παράδειγμα εφαρμόζει το [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) σε έναν πίνακα, εκτυπώνει το όνομα του προεπιλεγμένου στυλ και το εφαρμόζει στον δεύτερο πίνακα. Και οι δύο πίνακες αποθηκεύονται στο `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός πίνακα είναι ο λόγος του πλάτους προς το ύψος του. Χρησιμοποιήστε τη μέθοδο [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) για να κλειδώσετε αυτήν την αναλογία για έναν πίνακα.

Το παρακάτω παράδειγμα ανοίγει το `pres.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο σχήμα. Εκτυπώνει την τρέχουσα κατάσταση κλειδώματος, ενεργοποιεί το κλείδωμα της αναλογίας διαστάσεων, εκτυπώνει την ενημερωμένη κατάσταση (`True`) και αποθηκεύει το αποτέλεσμα ως `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την κατεύθυνση ανάγνωσης από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει τη μέθοδο [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) και οι παράγραφοι διαθέτουν τη μέθοδο [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινούν ή να αλλάζουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα [κλειδώματα σχήματος](/slides/el/cpp/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα εφαρμόζονται και σε πίνακες.

**Υποστηρίζεται η εισαγωγή εικόνας ως φόντο μέσα σε κελί;**

Ναι. Μπορείτε να ορίσετε μια [συμπλήρωση εικόνας](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού σύμφωνα με την επιλεγμένη λειτουργία (stretch ή tile).