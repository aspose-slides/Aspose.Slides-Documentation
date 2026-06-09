---
title: Διαχείριση Πινάκων Παρουσίασης σε C++
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/cpp/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση πίνακα
- αναλογία διαστάσεων
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργία & επεξεργασία πινάκων σε διαφάνειες PowerPoint με Aspose.Slides για C++. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιώσετε τις ροές εργασίας με τους πίνακες."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος προβολής και παρουσίασης πληροφοριών. Οι πληροφορίες σε ένα πλέγμα κελιών (διατεταγμένα σε γραμμές και στήλες) είναι απλές και εύκολα κατανοητές.

Η Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/cpp/aspose.slides/table/) , την διεπαφή [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) , την κλάση [Cell](https://reference.aspose.com/slides/el/cpp/aspose.slides/cell/) , την διεπαφή [ICell](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/) και άλλους τύπους που σας επιτρέπουν να δημιουργήσετε, ενημερώσετε και διαχειριστείτε πίνακες σε όλα τα είδη παρουσιάσεων. 

## **Δημιουργία Πίνακα από το Μηδέν**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα του `columnWidth` .
4. Ορίστε έναν πίνακα του `rowHeight` .
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addtable/) .
6. Επαναλάβετε για κάθε [ICell](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/) για να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχωνεύστε τα πρώτα δύο κελιά της πρώτης γραμμής του πίνακα. 
8. Αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframe/) ενός [ICell](https://reference.aspose.com/slides/el/cpp/aspose.slides/icell/) . 
9. Προσθέστε κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframe/) .
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c++
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PPTX
auto pres = System::MakeObject<Presentation>();

// Προσπελαύνει την πρώτη διαφάνεια
auto sld = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και γραμμές με ύψη
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ορίζει τη μορφή των περιγραμμάτων για κάθε κελί
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

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, η αρίθμηση των κελιών είναι απλή και ξεκινά από το μηδέν. Το πρώτο κελί σε έναν πίνακα έχει δείκτη 0,0 (στήλη 0, γραμμή 0). 

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 γραμμές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε την αρίθμηση των κελιών σε έναν πίνακα:

```c++
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
auto pres = System::MakeObject<Presentation>();

// Προσπελαύνει την πρώτη διαφάνεια
auto sld = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και γραμμές με ύψη
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ορίζει τη μορφή του περιγράμματος για κάθε κελί
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

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) και ορίστε το σε null.
4. Επαναλάβετε σε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) μέχρι να βρεθεί ο πίνακας.

   Αν υποψιάζεστε ότι η διαφάνεια που επεξεργάζεστε περιέχει έναν μόνο πίνακα, μπορείτε απλώς να ελέγξετε όλα τα σχήματα που περιέχει. Όταν ένα σχήμα αναγνωριστεί ως πίνακας, μπορείτε να το μετατρέψετε σε αντικείμενο [Table](https://reference.aspose.com/slides/el/cpp/aspose.slides/table/) . Αλλά αν η διαφάνεια περιέχει πολλούς πίνακες, είναι προτιμότερο να ψάξετε για τον πίνακα που χρειάζεστε μέσω της μεθόδου [set_AlternativeText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_alternativetext/) .
5. Χρησιμοποιήστε το αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) για να εργαστείτε με τον πίνακα. Στο παρακάτω παράδειγμα, προσθέσαμε μια νέα γραμμή στον πίνακα.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c++
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Προσπελαύνει την πρώτη διαφάνεια
auto sld = pres->get_Slides()->idx_get(0);

// Αρχικοποιεί έναν κενό Πίνακα
System::SharedPtr<ITable> tbl;

// Διέρχεται τα σχήματα και ορίζει μια αναφορά στον εντοπισθέντα πίνακα
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Ορίζει το κείμενο για την πρώτη στήλη της δεύτερης γραμμής
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Στοίχιση Κειμένου σε Πίνακα**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) στη διαφάνεια. 
4. Αποκτήστε πρόσβαση σε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) από τον πίνακα. 
5. Αποκτήστε το [IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/) του [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) .
6. Στοίχτε το κείμενο κατακόρυφα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c++
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
auto presentation = System::MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια 
auto slide = presentation->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και γραμμές με ύψη
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Προσθέτει το σχήμα πίνακα στη διαφάνεια
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Προσπελαύνει το πλαίσιο κειμένου
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

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Αποκτήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) από τη διαφάνεια.
4. Ορίστε το [set_FontHeight](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_fontheight/) για το κείμενο. 
5. Ορίστε το [set_Alignment](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_alignment/) και το [set_MarginRight](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_marginright/) . 
6. Ορίστε το [set_TextVerticalType](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

```c++
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Sets the table cells' font height
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Sets the table cells' text alignment and right margin in one call
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Sets the table cells' text vertical type
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Η Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ για έναν πίνακα ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για άλλον πίνακα ή αλλού. Αυτός ο κώδικας C++ δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προεπιλεγμένο στυλ πίνακα:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός γεωμετρικού σχήματος είναι η αναλογία των μεγεθών του σε διαφορετικές διαστάσεις. Η Aspose.Slides παρείχε την ιδιότητα `AspectRatioLocked()` για να μπορείτε να κλειδώσετε τη ρύθμιση της αναλογίας διαστάσεων για πίνακες και άλλα σχήματα. 

Αυτός ο κώδικας C++ δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων για έναν πίνακα:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς τα αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας προσφέρει τη μέθοδο [set_RightToLeft](https://reference.aspose.com/slides/el/cpp/aspose.slides/table/set_righttoleft/) , και οι παράγραφοι έχουν το [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από τη μετακίνηση ή την αλλαγή μεγέθους ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα [shape locks](/slides/el/cpp/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα εφαρμόζονται επίσης σε πίνακες.

**Υποστηρίζεται η εισαγωγή μιας εικόνας μέσα σε κελί ως παρασκήνιο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/el/cpp/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού ανάλογα με το επιλεγμένο mode (stretch ή tile).