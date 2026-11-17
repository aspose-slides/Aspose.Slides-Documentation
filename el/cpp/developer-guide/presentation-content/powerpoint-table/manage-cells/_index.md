---
title: Διαχείριση Κελιών Πίνακα σε Παρουσιάσεις Χρησιμοποιώντας C++
linktitle: Διαχείριση Κελιών
type: docs
weight: 30
url: /el/cpp/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διάσπαση κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τα κελιά πίνακα του PowerPoint σε C++: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε περιγράμματα, διασπάστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει την πρόσβαση και τροποποίηση των κελιών πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίσετε συγχωνευμένα κελιά πινάκων, να καταργήσετε τις γραμμές περιγράμματος, να εργαστείτε με την αρίθμηση κελιών μετά τη συγχώνευση ή τη διάσχισή τους, να αλλάξετε το χρώμα φόντου ενός κελιού και να προσθέσετε μια εικόνα μέσα σε κελί πινάκα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κελιών μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες που ξεκινούν από το μηδέν για την πρόσβαση στα κελιά του πίνακα με τη σειρά `(column, row)`.

## **Αναγνώριση Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια διασχίζει όλες τις γραμμές και στήλες και χρησιμοποιεί [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με τη σειρά `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), και τις αρχικές συντεταγμένες της περιοχής, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) και [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Αφαίρεση Περιγραμμάτων Κελών Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με το [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Τα πλάτη των στηλών, τα ύψη των γραμμών και η θέση του πίνακα ορίζονται σε μονάδες points. Το παράδειγμα θέτει όλα τα τέσσερα περιγράμματα κελιού σε [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), καθιστώντας τα αόρατα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Προσθήκη Διαγώνιων Περιγραμμάτων Κελιού**

Χρησιμοποιήστε [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) για να σχεδιάσετε μια γραμμή από την πάνω‑αριστερή γωνία προς την κάτω‑δεξιά, και [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) για να σχεδιάσετε μια γραμμή από την κάτω‑αριστερή γωνία προς την πάνω‑δεξιά. Μια διαγώνιος μπορεί να σηματοδοτήσει μια κεφαλίδα γωνίας· και οι δύο διαγώνιοι μπορούν να σχηματίσουν ένα Χ για να υποδείξουν ότι το κελί δεν είναι εφαρμόσιμο.

Κάθε διαγώνιος είναι ένα [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/). Χρησιμοποιήστε το [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) για πρόσβαση στο γέμισμα, καλέστε το [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) με το [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) και επιλέξτε χρώμα μέσω του [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/). Ορίστε το πλάτος της γραμμής με το [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) σε μονάδες points.

Το παράδειγμα δημιουργεί τρία κελιά σε μια γραμμή: μια κόκκινη διαγώνιο προς τα κάτω, μια μπλε διαγώνιο προς τα πάνω και και τις δύο διαγώνιους. Διατηρεί τα περιγράμματα πάνω, κάτω, αριστερά και δεξιά αμετάβλητα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

Μια διαγώνιος είναι ιδιότητα μορφοποίησης, όχι διάσπαση κελιού. Κάθε κελί διατηρεί ένα μοναδικό πλαίσιο κειμένου που προσπελαύνεται μέσω του [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/); οι περιοχές στα πλάγια μιας διαγώνιου δεν μπορούν να επεξεργαστούν ανεξάρτητα.

Ο αποθηκευμένος πίνακας, αποδομένος στο Microsoft PowerPoint:

![Τρία κελιά πίνακα που εμφανίζουν μια κόκκινη διαγώνιο από την επάνω‑αριστερή στην κάτω‑δεξιά, μια μπλε διαγώνιο από την κάτω‑αριστερή στην πάνω‑δεξιά, και και τις δύο διαγώνιους σχηματίζουν ένα Χ.](diagonal-cell-borders.png)

*Αριστερά προς δεξιά: διαγώνιος προς τα κάτω (κόκκινο, 3 pt), διαγώνιος προς τα πάνω (μπλε, 5 pt) και και οι δύο διαγώνιοι.*

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε το [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) για να συνδυάσετε μια ορθογώνια περιοχή κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην πάνω‑αριστερή και κάτω‑δεξιά γωνία της περιοχής. Το τελευταίο επιχείρημα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κελιά εκτός της καθορισμένης περιοχής· το `false` διατηρεί τη συγχώνευση εντός αυτής της περιοχής.

Το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και γραμμές 70 points, στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` έως το `(2, 2)`. Το αποτέλεσμα είναι ένα κελί που εκτείνεται σε δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα παραμένει με τέσσερις στήλες και τέσσερις γραμμές. Για πρόσβαση στο περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του επάνω‑αριστερού άκρου: `table->idx_get(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στην συγχωνευμένη περιοχή παραμένουν μέρος του πλέγματος του πίνακα, έτσι ότι δείκτες κελιών εκτός της περιοχής δεν αλλάζουν.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Διαίρεση Κελιών Πίνακα**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Η διάσπαση ενός κελιού μπορεί να εισαγάγει μια νέα στήλη πλέγματος και να αλλάξει τους δείκτες στήλης των κελιών που βρίσκονται στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και γραμμές 70 points και καλεί το [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) στο κελί `(1, 1)`. Το ήμισυ του πλάτους των 70 points του κελιού περνιέται για τη δημιουργία δύο κελιών ίσου πλάτους.

Μετά τη διάσπαση, τα δύο μισά προσπελαύνονται ως `table->idx_get(1, 1)` και `table->idx_get(2, 1)`. Το πλέγμα του πίνακα έχει τώρα πέντε στήλες: τα κελιά που αρχικά ήταν στις στήλες 2 και 3 μεταπηδούν στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά τη διάσπαση.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

<!-- visual-explanation:manage-cells:start -->
[![Ένα μη συγχωνευμένο κελί 70 point χωρίζεται σε δύο κελιά 35 point, προσθέτοντας μια πέμπτη στήλη πλέγματος και μετατοπίζοντας τους δείκτες στα δεξιά του.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Η διάσπαση του πλάτους επηρεάζει το κελί (1, 1), χρησιμοποιώντας δείκτες μηδενικής βάσης (column, row). Οι άλλες γραμμές διατηρούν ένα κελί που εκτείνεται και στις δύο νέες θέσεις στήλης.*
<!-- visual-explanation:manage-cells:end -->

### **Διαίρεση Συγχωνευμένων Κελιών κατά Γραμμή ή Στήλη**

Για την προετοιμασία συγχωνευμένων κελιών προτύπου για πληροφόρηση δεδομένων, χρησιμοποιήστε το [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) για διάσπαση κατά υπάρχον όριο γραμμής, ή το [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) για διάσπαση κατά όριο στήλης.

Το όρισμα `index` μετρά γραμμές στο ανώτερο τμήμα ή στήλες στο αριστερό τμήμα της διάσπασης· είναι σχετικό με την συγχωνευμένη περιοχή:

- Διάσπαση γραμμής: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Διάσπαση στήλης: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Το παράδειγμα υποθέτει ότι η παρουσίαση διαθέτει έναν πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τα κελιά `(1, 2)` και `(1, 3)` να είναι συγχωνευμένα κάθετα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί τα [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) και [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) για να εντοπίσει την αρχή και ελέγχει και τις δύο εκτάσεις. Το `SplitByRowSpan(1)` χωρίζει τότε τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για μια οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε αντί αυτού το `SplitByColSpan(1)`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Ανακτήστε τα προκύπτοντα κελιά από τον πίνακα μετά τη διάσπαση.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

Το πλέγμα του πίνακα και οι γειτονικοί δείκτες κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτουν κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν εκτάσεις 1 και το [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) εκτυπώνει `False`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά από μία διάσπαση.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο ανώτερο (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά τη διάσπαση και ορίστε τυχόν απαιτούμενη μορφοποίηση κειμένου ρητά.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά “Product A” και “Product B” με τη μορφοποίηση του προτύπου διατηρημένη. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) για λεπτομέρειες.

### **Διαίρεση Κελιού σε Συγκεκριμένο Ύψος**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) λαμβάνει το ύψος του ανώτερου μέρους σε points. Το [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) λαμβάνει τον αριθμό των υπαρχουσών γραμμών πλέγματος στο ανώτερο μέρος. Για κεντράρισμα ενός κελιού 40 point στη δεξιά στήλη, αφαιρέστε 40 από το πραγματικό ύψος του κελιού και διαιρέστε το υπόλοιπο ίσα πάνω και κάτω.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

Η πρώτη διάσπαση προσθέτει μια γραμμή πλέγματος, αφήνοντας τα κάτω 90 points στο `(1, 1)`. Η δεύτερη διάσπαση στοχεύει αυτό το κελί και προσθέτει άλλη μια γραμμή κάτω από αυτό. Η δεξιά στήλη περιέχει τώρα το `(1, 0)` στα 50 points (`margin`), το `(1, 1)` στα 40 points, και το `(1, 2)` στα 50 points (`margin`). Το αριστερό κελί καλύπτει και τις τρεις γραμμές με το αρχικό του ύψος 140 points.

![Το αριστερό κελί καλύπτει όλο το ύψος του πίνακα δίπλα σε τρία κελιά με το Middle στο κέντρο.](split-by-height.png)

## **Αλλαγή Χρώματος Φόντου Κελού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 point και γραμμές 50 point. Χρησιμοποιεί το [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) για να επιλέξει συμπαγές γέμισμα και το [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) για πρόσβαση στο χρώμα γεμίσματος, ορίζοντάς το σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη γραμμή.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

Τοποθετήστε την είσοδο εικόνας στον κατάλογο εργασίας πριν εκτελέσετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Στη συνέχεια αντιστοιχίζει την εικόνα στη γεμιστική εικόνα κελιού `(0, 0)`, το πρώτο κελί του πίνακα.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία του. Τα πλάτη των στηλών και τα ύψη των γραμμών εκφράζονται σε points. Η φορτωμένη εικόνα διαγράφεται μετά την προσθήκη της στην παρουσίαση.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/), [bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/), [left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/), [right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς να μπορεί να διαφέρει.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος στήλης/γραμμής μετά τη ρύθμιση μιας εικόνας ως φόντο κελιού;**

Η συμπεριφορά εξαρτάται από τη [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη, τα εικονοστοιχεία επαναϋπολογίζονται.

**Μπορώ να αντιστοιχίσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

[Hyperlinks](/slides/el/cpp/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (τμήματος) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, αντιστοιχίζετε τον σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (τμήματα) με ανεξάρτητη μορφοποίηση — οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.