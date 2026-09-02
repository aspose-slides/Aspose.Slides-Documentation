---
title: "Διαχείριση Πινάκων Παρουσίασης σε C++"
linktitle: "Διαχείριση Πίνακα"
type: docs
weight: 10
url: /el/cpp/manage-table/
keywords:
- "προσθήκη πίνακα"
- "δημιουργία πίνακα"
- "πρόσβαση σε πίνακα"
- "αναλογία διαστάσεων"
- "στοίχιση κειμένου"
- "μορφοποίηση κειμένου"
- "στυλ πίνακα"
- "PowerPoint"
- "παρουσίαση"
- "C++"
- "Aspose.Slides"
description: "Δημιουργήστε και επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint με το Aspose.Slides για C++. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιστοποιήσετε τις ροές εργασίας με τους πίνακες."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος εμφάνισης και απεικόνισης πληροφοριών. Οι πληροφορίες σε ένα πλέγμα κελιών (διατεταγμένα σε σειρές και στήλες) είναι απλές και εύκολα κατανοητές.

Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/cpp/aspose.slides/table/) , το interface [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) , την κλάση [Cell](https://reference.aspose.com/slides/el/cpp/aspose.slides/cell/) , το interface [ICell](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/) και άλλους τύπους που σας επιτρέπουν να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε κάθε είδους παρουσιάσεις. 

## **Δημιουργία Πίνακα από το Μηδέν**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα `columnWidth`.
4. Ορίστε έναν πίνακα `rowHeight`.
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addtable/).
6. Επαναλάβετε για κάθε [ICell](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/) για να εφαρμόσετε μορφοποίηση στα επάνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχωνεύστε τα πρώτα δύο κελιά της πρώτης γραμμής του πίνακα. 
8. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframe/) ενός [ICell](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/). 
9. Προσθέστε κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframe/).
10. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας C++ δείχνει πώς να δημιουργήσετε έναν πίνακα σε μια παρουσίαση:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
auto pres = System::MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
auto sld = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και σειρές με ύψη
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ορίζει τη μορφοποίηση του περιγράμματος για κάθε κελί
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// Συγχωνεύει τα κελιά 1 και 2 της γραμμής 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Προσθέτει κείμενο στο συγχωνευμένο κελί
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Αποθηκεύει την παρουσίαση στο δίσκο
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Αρίθμηση σε έναν Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, η αρίθμηση των κελιών είναι απλή και βασίζεται στο μηδέν. Το πρώτο κελί ενός πίνακα έχει δείκτη 0,0 (στήλη 0, σειρά 0). 

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτός ο κώδικας C++ δείχνει πώς να καθορίσετε την αρίθμηση για κελιά σε έναν πίνακα:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
auto pres = System::MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
auto sld = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και σειρές με ύψη
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ορίζει τη μορφοποίηση του περιγράμματος για κάθε κελί
for (const auto& row : tbl->get_Rows())
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

// Αποθηκεύει την παρουσίαση στο δίσκο
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).

2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα μέσω του δείκτη της. 

3. Δημιουργήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) και ορίστε το σε `null`.

4. Επαναλάβετε μέσω όλων των αντικειμένων [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) έως ότου βρεθεί ο πίνακας.

   Αν υποπτεύεστε ότι η διαφάνεια που επεξεργάζεστε περιέχει μόνο έναν πίνακα, μπορείτε απλώς να ελέγξετε όλα τα σχήματα που περιέχει. Όταν ένα σχήμα αναγνωρίζεται ως πίνακας, μπορείτε να το μετατρέψετε σε αντικείμενο [Table](https://reference.aspose.com/slides/el/cpp/aspose.slides/table/). Αν όμως η διαφάνεια περιέχει πολλούς πίνακες, είναι καλύτερο να ψάξετε για τον απαιτούμενο πίνακα μέσω του [set_AlternativeText()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_alternativetext/).

5. Χρησιμοποιήστε το αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) για να εργαστείτε με τον πίνακα. Στο παρακάτω παράδειγμα προσθέσαμε μια νέα σειρά στον πίνακα.

6. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας C++ δείχνει πώς να προσπελάσετε και να εργαστείτε με έναν υπάρχοντα πίνακα:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Πρόσβαση στην πρώτη διαφάνεια
auto sld = pres->get_Slides()->idx_get(0);

// Αρχικοποιεί έναν μηδενικό Table
System::SharedPtr<ITable> tbl;

// Διατρέχει τα σχήματα και θέτει μια αναφορά στον εντοπισμένο πίνακα
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Θέτει το κείμενο για την πρώτη στήλη της δεύτερης γραμμής
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Εντοπισμός του Κελιού που Κατέχει ένα Πλαίσιο Κειμένου**

Όταν γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) από έναν πίνακα, χρησιμοποιήστε το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentcell/) για να εντοπίσετε το ιδιοκτήτη [ICell](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/). Για ένα πλαίσιο κειμένου κελιού πίνακα, το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentcell/) επιστρέφει τον κάτοχο και το [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentshape/) επιστρέφει `nullptr`, παρόλο που ο πίνακας είναι ένα σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο για ανάγνωση μεθόδων [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/get_firstcolumnindex/) και [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/get_firstrowindex/). Το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentcell/) παρέχει επίσης μόνο για ανάγνωση πλοήγηση: επιστρέφει τον ιδιοκτήτη χωρίς να αλλάζει την κυριότητα. Πάντα ελέγχετε αν το επιστρεφόμενο κελί είναι `nullptr` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κελιών πίνακα και σχήματος, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/cpp/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) στη διαφάνεια. 
4. Προσπελάστε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) από τον πίνακα. 
5. Προσπελάστε το [IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/) του [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/).
6. Στοίχνετε το κείμενο κάθετα.
7. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας C++ δείχνει πώς να στοίχειτε το κείμενο σε έναν πίνακα:

```c++
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
#include <DOM/ISlideCollection.h>
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

// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
auto presentation = System::MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια
auto slide = presentation->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και σειρές με ύψη
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Προσθέτει το σχήμα πίνακα στη διαφάνεια
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Πρόσβαση στο πλαίσιο κειμένου
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Δημιουργεί το αντικείμενο Portion για την παράγραφο
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Στοίχει το κείμενο κάθετα
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Αποθηκεύει την παρουσίαση στο δίσκο
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) κλάσης.
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της. 
3. Προσπελάστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) από τη Διαφάνεια.
4. Ορίστε το [set_FontHeight()](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_fontheight/) για το κείμενο. 
5. Ορίστε το [set_Alignment()](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_alignment/) και το [set_MarginRight()](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Ορίστε το [set_TextVerticalType()](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Αποθηκεύστε την τροποποιημένη παρουσία. 

Αυτός ο κώδικας C++ δείχνει πώς να εφαρμόσετε τις προτιμώμενες επιλογές μορφοποίησης στο κείμενο ενός πίνακα:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Έστω ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Ορίζει το ύψος γραμματοσειράς των κελιών του πίνακα
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Ορίζει τη στοίχιση κειμένου και το δεξί περιθώριο των κελιών του πίνακα με μία κλήση
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Ορίζει τον κάθετο τύπο κειμένου των κελιών του πίνακα
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Το Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ για έναν πίνακα ώστε να τις χρησιμοποιήσετε σε άλλον πίνακα ή αλλού. Αυτός ο κώδικας C++ δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προεπιλεγμένο στυλ πίνακα:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Κλείδωμα Αναλογίας Διαστάσεων ενός Πίνακα**

Η αναλογία διαστάσεων ενός γεωμετρικού σχήματος είναι η σχέση των μεγεθών του σε διαφορετικές διαστάσεις. Το Aspose.Slides παρέχει την ιδιότητα `AspectRatioLocked()` για να κλειδώνετε τη ρύθμιση της αναλογίας διαστάσεων για πίνακες και άλλα σχήματα. 

Αυτός ο κώδικας C++ δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων για έναν πίνακα:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας διαθέτει τη μέθοδο [set_RightToLeft](https://reference.aspose.com/slides/el/cpp/aspose.slides/table/set_righttoleft/) και οι παράγραφοι έχουν τη μέθοδο [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraphformat/set_righttoleft/). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να εμποδίσω τους χρήστες να μετακινήσουν ή να αλλάξουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τις [shape locks](/slides/el/cpp/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κλπ. Αυτά τα κλειδώματα ισχύουν και για πίνακες.

**Υποστηρίζεται η εισαγωγή εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/el/cpp/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύπτει την περιοχή του κελιού ανάλογα με την επιλεγμένη λειτουργία (stretch ή tile).