---
title: Διαχείριση Γραμμών και Στηλών σε Πίνακες PowerPoint με C++
linktitle: Γραμμές και Στήλες
type: docs
weight: 20
url: /el/cpp/manage-rows-and-columns/
keywords:
- γραμμή πίνακα
- στήλη πίνακα
- πρώτη γραμμή
- κεφαλίδα πίνακα
- κλωνοποίηση γραμμής
- κλωνοποίηση στήλης
- αντιγραφή γραμμής
- αντιγραφή στήλης
- αφαίρεση γραμμής
- αφαίρεση στήλης
- μορφοποίηση κειμένου γραμμής
- μορφοποίηση κειμένου στήλης
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τις γραμμές και τις στήλες των πινάκων σε PowerPoint με το Aspose.Slides για C++ και επιταχύνετε την επεξεργασία παρουσιάσεων και τις ενημερώσεις δεδομένων."
---
## **Εισαγωγή**

Aspose.Slides για C++ σας επιτρέπει να διαχειρίζεστε τη δομή και τη μορφοποίηση πινάκων σε παρουσιάσεις PowerPoint μέσω της κλάσης [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) και της διεπαφής [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Μπορείτε να ορίσετε μια γραμμή κεφαλίδας, να κλωνοποιήσετε ή να αφαιρέσετε γραμμές και στήλες, και να εφαρμόσετε μορφοποίηση κειμένου σε ολόκληρη μια γραμμή ή στήλη.

Αυτό το άρθρο εξηγεί αυτές τις λειτουργίες με παραδείγματα C++. Δείχνει επίσης πώς να ανακτήσετε το προεπιλεγμένο στυλ ενός πίνακα ώστε να το επαναχρησιμοποιήσετε. Οι δείκτες των γραμμών και στηλών του πίνακα είναι μηδενικής βάσης.

## **Έλεγχος Ύψους Γραμμής**

Χρησιμοποιήστε το [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) για να ορίσετε το ελάχιστο ύψος μιας γραμμής σε points. Είναι ένα κατώτερο όριο, όχι σταθερό ύψος. Το [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) επιστρέφει το πραγματικό ύψος· αυτή η τιμή δεν μπορεί να οριστεί άμεσα. Πρόσβαση στη γραμμή γίνεται μέσω του [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

Το παράδειγμα φορτώνει το [row-height-input.pptx](row-height-input.pptx), το οποίο περιέχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη του γραμμή ξεκινάει στα 70 points. Τα κελιά χρησιμοποιούν κείμενο Arial 18 pt, με αναδίπλωση και περιθώρια 6 pt από πάνω και από κάτω· το μεγαλύτερο κείμενο στη δεύτερη στήλη αναδιπλώνεται σε πολλές γραμμές. Το παράδειγμα αυξάνει το ελάχιστο σε 100 pt, μετά το μειώνει σε 20 pt, εκτυπώνει το πραγματικό ύψος μετά από κάθε αλλαγή και αποθηκεύει και τα δύο αποτελέσματα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Με την παρεχόμενη παρουσίαση, η αύξηση του ελάχιστου προσθέτει χώρο στη γραμμή. Η μείωση του αφαιρεί αυτόν τον επιπλέον χώρο, αλλά το πραγματικό ύψος παραμένει μεγαλύτερο από 20 pt επειδή το κείμενο και τα περιθώρια του κελιού χρειάζονται περισσότερο χώρο. Η μείωση του ελάχιστου μόνον δεν μπορεί να ωθήσει τη γραμμή κάτω από τον χώρο που απαιτεί το περιεχόμενό της.

Πολλοί παράγοντες επηρεάζουν το πραγματικό ύψος:

- **Κείμενο και μέγεθος γραμματοσειράς:** μεγαλύτερο κείμενο, ρητοί αλλαγές γραμμής ή μεγαλύτερη γραμματοσειρά μπορούν να απαιτήσουν περισσότερο κάθετο χώρο.
- **Αναδίπλωση και πλάτος στήλης:** με ενεργή την αναδίπλωση, η μείωση του πλάτους της στήλης με το [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) μπορεί να δημιουργήσει περισσότερες γραμμές. Μία πιο πλατιά στήλη μπορεί να μειώσει τον απαιτούμενο κάθετο χώρο.
- **Περιθώρια κελιού:** τα [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) και [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) ελέγχουν τα περιθώρια που προσθέτουν κάθετο χώρο. Τα [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) και [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) ελέγχουν τα περιθώρια που μειώνουν το διαθέσιμο πλάτος για κείμενο και μπορούν να προκαλέσουν πρόσθετη αναδίπλωση.

Για αυτόν τον πίνακα χωρίς συγχωνευμένα κελιά, το κελί που χρειάζεται τον περισσότερο κάθετο χώρο καθορίζει το όριο του περιεχομένου για ολόκληρη τη γραμμή. Για να μικρύνει η γραμμή, ίσως χρειαστεί επίσης να μειώσετε το κείμενο, το μέγεθος γραμματοσειράς ή τα περιθώρια, ή να διευρύνετε μια στήλη.

Οι εικόνες παρακάτω δείχνουν τον ίδιο πίνακα στην ίδια κλίμακα. Στην αναφορά .NET που παρουσιάζεται εδώ, τα πραγματικά ύψη ήταν 70, 100 και 55,2 pt: η τελική γραμμή παρέμεινε ψηλότερη από το ελάχιστο των 20 pt. Οι ακριβείς μετρήσεις κειμένου μπορεί να διαφέρουν ανάλογα με τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον σας. Κατεβάστε τα αποθηκευμένα αποτελέσματα: [αυξημένο ελάχιστο](row-height-increased.pptx) και [μειωμένο ελάχιστο](row-height-decreased.pptx).

| Αρχικό: ελάχιστο 70 pt, πραγματικό 70 pt | Αυξημένο: ελάχιστο 100 pt, πραγματικό 100 pt | Μειωμένο: ελάχιστο 20 pt, πραγματικό 55,2 pt |
| --- | --- | --- |
| ![Αρχικός πίνακας με πρώτη γραμμή 70 pt.](row-height-before.png) | ![Πίνακας μετά την αύξηση του ελάχιστου της πρώτης γραμμής σε 100 pt.](row-height-increased.png) | ![Πίνακας μετά τη μείωση του ελάχιστου της πρώτης γραμμής σε 20 pt· το αναδιπλωμένο κείμενο κρατά τη γραμμή ψηλότερη από το ελάχιστο.](row-height-decreased.png) |

## **Ορίστε την Πρώτη Γραμμή ως Κεφαλίδα**

Χρησιμοποιήστε τη μέθοδο [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) για να σημειώσετε την πρώτη γραμμή για μορφοποίηση κεφαλίδας. Η εμφάνισή της εξαρτάται από το στυλ πίνακα που έχει εφαρμοστεί.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Πρόσβαση στον πίνακα που είναι το πρώτο σχήμα στη διαφάνεια.
4. Ενεργοποιήστε τη μορφοποίηση κεφαλίδας για την πρώτη του γραμμή.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ενεργοποιεί τη μορφοποίηση κεφαλίδας για την πρώτη γραμμή και αποθηκεύει το `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Κλωνοποίηση Γραμμής ή Στήλης Πίνακα**

Κλωνοποιήστε γραμμές ή στήλες για να επαναχρησιμοποιήσετε το περιεχόμενο και τη μορφοποίησή τους. Μπορείτε να προσθέσετε ένα αντίγραφο στο τέλος του πίνακα ή να το εισαγάγετε σε συγκεκριμένη θέση.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.
4. Προσθέστε έναν πίνακα με τη μέθοδο [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Κλωνοποιήστε τις απαιτούμενες γραμμές.
6. Κλωνοποιήστε τις απαιτούμενες στήλες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `Test.pptx` με τουλάχιστον μία διαφάνεια. Δημιουργεί έναν πίνακα με τρεις στήλες και πέντε γραμμές, με διαστάσεις καθορισμένες σε points. Προσθέτει αντίγραφα της πρώτης γραμμής και στήλης, έπειτα εισάγει αντίγραφα της δεύτερης γραμμής και στήλης στη θέση 3 (την τέταρτη θέση). Ο τελικός πίνακας έχει επτά γραμμές και πέντε στήλες. Το όρισμα `false` απενεργοποιεί την κλωνοποίηση σε παρακείμενες συγχωνευμένες γραμμές ή στήλες· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Αφαίρεση Γραμμής ή Στήλης από Πίνακα**

Αφαιρέστε γραμμές ή στήλες που δεν χρειάζονται πλέον σε έναν πίνακα. Η αφαίρεση ενός στοιχείου μετατοπίζει τους δείκτες των γραμμών ή στηλών που ακολουθούν.

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.
4. Προσθέστε έναν πίνακα με τη μέθοδο [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Αφαιρέστε τη δεύτερη γραμμή και τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 3 × 3 και αφαιρεί τη γραμμή και τη στήλη στο δείκτη 1, αφήνοντας έναν πίνακα 2 × 2 στο `TestTable_out.pptx`. Οι διαστάσεις είναι σε points. Το όρισμα `false` απενεργοποιεί την αφαίρεση σε παρακείμενες συγχωνευμένες γραμμές ή στήλες· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Ορισμός Μορφοποίησης Κειμένου στο Επίπεδο Γραμμής Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη μια γραμμή για να διατηρήσετε τις κυψέλες της συνεπείς. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Ορίστε το ύψος γραμματοσειράς με το [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) για την πρώτη γραμμή.
4. Ορίστε την ευθυγράμμιση και το δεξί περιθώριο παραγράφου με τα [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) και [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) για την πρώτη γραμμή.
5. Ορίστε την κατεύθυνση κειμένου με το [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) για τη δεύτερη γραμμή.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο γραμμές. Εφαρμόζει κείμενο 25 pt, δεξιό στοίχιση και περιθώριο παραγράφου 20 pt δεξιά στην πρώτη γραμμή, μετά ορίζει κάθετο κείμενο στη δεύτερη γραμμή.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Ορισμός Μορφοποίησης Κειμένου στο Επίπεδο Στήλης Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη μια στήλη για να διατηρήσετε τις κυψέλες της συνεπείς. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Ορίστε το ύψος γραμματοσειράς με το [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) για την πρώτη στήλη.
4. Ορίστε την ευθυγράμμιση και το δεξί περιθώριο παραγράφου με τα [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) και [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) για την πρώτη στήλη.
5. Ορίστε την κατεύθυνση κειμένου με το [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) για τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο στήλες. Εφαρμόζει κείμενο 25 pt, δεξιό στοίχιση και περιθώριο παραγράφου 20 pt δεξιά στην πρώτη στήλη, μετά ορίζει κάθετο κείμενο στη δεύτερη στήλη.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε τη μέθοδο [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) για να ανακτήσετε το προεπιλεγμένο στυλ που έχει εφαρμοστεί σε έναν πίνακα και να το επαναχρησιμοποιήσετε σε άλλο πίνακα. Αυτό προσδιορίζει το preset αντί για μεμονωμένες παρακάμψεις μορφοποίησης κελιών.

Το παράδειγμα δημιουργεί έναν πίνακα, εφαρμόζει το [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) και διαβάζει το preset πίσω. Εκτυπώνει το `DarkStyle1` και αποθηκεύει τον πίνακα στο `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν πίνακα που έχει ήδη δημιουργηθεί;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/πρότυπου, και μπορείτε ακόμη να υπερκαλυφθείτε τα γεμίσματα, τα περιγράμματα και τα χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα σας στη μνήμη πρώτα, μετά επανασυμπληρώστε τις γραμμές του πίνακα με τη σωστή σειρά.

**Μπορώ να έχω λωρίδες (striped) στήλες διατηρώντας προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις λωρίδες στη στήλη, μετά υπερκαλύψτε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση σε επίπεδο κελιού έχει προτεραιότητα έναντι του στυλ πίνακα.