---
title: Διαχείριση Κυψέλων Πίνακα σε Παρουσιάσεις Χρησιμοποιώντας C++
linktitle: Διαχείριση Κυψέλων
type: docs
weight: 30
url: /el/cpp/manage-cells/
keywords:
- κυψέλη πίνακα
- συγχώνευση κυψέλων
- αφαίρεση περιγράμματος
- διαχωρισμός κυψέλης
- εικόνα στην κυψέλη
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχείριση κυψέλων πίνακα PowerPoint σε C++: εντοπισμός συγχωνευμένων κυψέλων, αφαίρεση περιγραμμάτων, διαχωρισμός κυψέλων και ορισμός χρωμάτων φόντου και εικόνων με Aspose.Slides για C++."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να προσπερνάτε και να τροποποιείτε κυψέλες πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένες κυψέλες πίνακα, να αφαιρείτε τα περιθώρια των κυψέλων, να εργάζεστε με την αρίθμηση των κυψέλων μετά τη συγχώνευση ή το διαχωρισμό των κυψέλων, να αλλάζετε το χρώμα φόντου μιας κυψέλης και να προσθέτετε εικόνα μέσα σε μια κυψέλη πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να πάρετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κυψέλων μέσω των ιδιοτήτων της κυψέλης, και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες μηδενικής βάσης για την πρόσβαση στις κυψέλες πίνακα με τη σειρά `(column, row)`.

## **Εντοπισμός Συγχωνευμένης Κυψέλης Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια, επαναλαμβάνει όλες τις σειρές και στήλες και χρησιμοποιεί [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) για να εντοπίσει τις κυψέλες σε συγχωνευμένες περιοχές. Για κάθε αντιστοίχηση, εκτυπώνει τις συντεταγμένες της κυψέλης με τη σειρά `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), και τις αρχικές συντεταγμένες της περιοχής, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) και [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

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

## **Αφαίρεση Περιγραμμάτων Κυψέλης Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη διαφάνειά του με την [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Τα πλάτη των στηλών, τα ύψη των σειρών και η θέση του πίνακα ορίζονται σε μονάδες point. Το παράδειγμα ορίζει όλα τα τέσσερα περιγράμματα της κυψέλης σε [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), καθιστώντας τα αόρατα.

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

## **Συγχώνευση Κυψέλων Πίνακα**

Χρησιμοποιήστε το [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) για να συνδυάσετε μια ορθογώνια περιοχή κυψέλων πίνακα σε μία κυψέλη. Καθορίστε τις κυψέλες στην επάνω αριστερή και κάτω δεξιά γωνία της περιοχής. Το τελευταίο όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κυψέλες εκτός της καθορισμένης περιοχής· `false` διατηρεί τη συγχώνευση εντός της περιοχής.

Το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και σειρές 70 point, στη συνέχεια συγχωνεύει τις τέσσερις κεντρικές κυψέλες από `(1, 1)` έως `(2, 2)`. Η προκύπτουσα κυψέλη καλύπτει δύο στήλες και δύο σειρές, ενώ το υποκείμενο πλέγμα του πίνακα παραμένει με τέσσερις στήλες και τέσσερις σειρές. Για να προσπεράσετε το περιεχόμενο ή τη μορφοποίηση της συγχωνευμένης κυψέλης, χρησιμοποιήστε τη θέση επάνω-αριστερά: `table->idx_get(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στην συγχωνευμένη περιοχή παραμένουν μέρος του πλέγματος του πίνακα, έτσι οι δείκτες των κυψέλων εκτός της περιοχής δεν αλλάζουν.

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

## **Διαχωρισμός Κυψέλων Πίνακα**

Η συγχώνευση κυψέλων στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Ο διαχωρισμός μιας κυψέλης μπορεί να εισαγάγει μια νέα στήλη πλέγματος και να αλλάξει τους δείκτες στήλης των κυψέλων στα δεξιά της. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πίνακα του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και σειρές 70 point και καλεί το [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) στην κυψέλη `(1, 1)`. Η μισή του πλάτος 70 point της κυψέλης μεταβιβάζεται για τη δημιουργία δύο κυψελών ίσου πλάτους.

Μετά από αυτόν τον διαχωρισμό, τα δύο μέρη προσπελαύνονται ως `table->idx_get(1, 1)` και `table->idx_get(2, 1)`. Το πλέγμα του πίνακα έχει τώρα πέντε στήλες: οι κυψέλες που ήταν αρχικά στις στήλες 2 και 3 μετατοπίζονται στις στήλες 3 και 4 αντίστοιχα. Οι δείκτες σειρών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε τις κυψέλες μετά τον διαχωρισμό.

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

### **Διαχωρισμός Συγχωνευμένων Κυψέλων κατά Σειρά ή Στήλη**

Για να προετοιμάσετε τις συγχωνευμένες κυψέλες προτύπου για εισαγωγή δεδομένων, χρησιμοποιήστε το [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) για διαχωρισμό κατά μήκος υπάρχοντος ορίου σειράς, ή το [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) για διαχωρισμό κατά μήκος ορίου στήλης.

Το όρισμα `index` μετράει σειρές στο άνω μέρος ή στήλες στο αριστερό μέρος του διαχωρισμού· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Row split: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)
- Column split: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)

Το παράδειγμα υποθέτει ότι μια παρουσίαση περιέχει έναν πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τις κυψέλες `(1, 2)` και `(1, 3)` να είναι συγχωνευμένες κάθετα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί τα [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) και [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) για να εντοπίσει το σημείο εκκίνησης και ελέγχει και τις δύο εκτάσεις. Το `SplitByRowSpan(1)` στη συνέχεια διαχωρίζει τις σειρές 2 και 3 για τα ονόματα προϊόντων. Για μια οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε `SplitByColSpan(1)`.

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

    // Ανακτήστε τις προκύπτουσες κυψέλες από τον πίνακα μετά το διαχωρισμό.
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

Το πλέγμα του πίνακα και οι δείκτες των γύρω κυψέλων παραμένουν αμετάβλητοι. Ανακτήστε τις προκύπτουσες κυψέλες με βάση τις συντεταγμένες τους· εδώ, και οι δύο έχουν εκτάσεις 1 και το [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) εκτυπώνει `False`. Μεγαλύτερες περιοχές μπορεί να παραμείνουν εν μέρει συγχωνευμένες μετά από έναν διαχωρισμό.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στην άνω (ή αριστερή) κυψέλη· η νέα κυψέλη είναι κενή αλλά κληρονομεί τη μορφοποίηση της κυψέλης, όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τις κυψέλες μετά τον διαχωρισμό και ορίστε ρητά τυχόν απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστές κυψέλες "Product A" και "Product B" με τη μορφοποίηση της κυψέλης του προτύπου να διατηρείται. Δείτε το [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) για λεπτομέρειες.

## **Αλλαγή Χρώματος Φόντου Κυψέλης Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 point και σειρές 50 point. Χρησιμοποιεί το [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) για να επιλέξει γεμισμό συμπαγές και το [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) για να προσπελάσει το χρώμα γεμίσματος και να το ορίσει σε κόκκινο για την κυψέλη `(2, 3)`, στην τρίτη στήλη και τέταρτη σειρά.

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

## **Προσθήκη Εικόνας Μέσα σε Κυψέλη Πίνακα**

Τοποθετήστε την είσοδο εικόνας στον κατάλογο εργασίας πριν τρέξετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/), και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Στη συνέχεια αναθέτει την εικόνα στο γέμισμα εικόνας της κυψέλης `(0, 0)`, η πρώτη κυψέλη του πίνακα.

Το [PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει την κυψέλη, κάτι που μπορεί να αλλάξει την αναλογία διαστάσεών της. Τα πλάτη των στηλών και τα ύψη των σειρών είναι σε μονάδες point. Η φορτωμένη εικόνα απελευθερώνεται μετά την προσθήκη της στην παρουσίαση.

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

**Μπορώ να ορίσω διαφορετικά πάχη γραμμής και στυλ για τις διαφορετικές πλευρές μιας μόνο κυψέλης;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ της κάθε πλευράς να μπορούν να διαφέρουν.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος της στήλης/γραμμής μετά την ορισμένη εικόνα ως φόντο της κυψέλης;**

Η συμπεριφορά εξαρτάται από το [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/). Με τέντωμα, η εικόνα προσαρμόζεται στη νέα κυψέλη· με επικάλυψη, τα κομμάτια επαναϋπολογίζονται.

**Μπορώ να αντιστοιχίσω έναν υπερσύνδεσμο σε όλο το περιεχόμενο μιας κυψέλης;**

Τα [Hyperlinks](/slides/el/cpp/manage-hyperlinks/) ορίζονται στο επίπεδο του κειμένου (portion) μέσα στο πλαίσιο κειμένου της κυψέλης ή στο επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αναθέτετε τον σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο της κυψέλης.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε μία κυψέλη;**

Ναι. Το πλαίσιο κειμένου μιας κυψέλης υποστηρίζει [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.