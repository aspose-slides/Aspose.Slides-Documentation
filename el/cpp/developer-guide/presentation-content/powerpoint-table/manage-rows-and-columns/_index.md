---
title: Διαχείριση Σειρών και Στηλών σε Πίνακες PowerPoint με C++
linktitle: Σειρές και Στήλες
type: docs
weight: 20
url: /el/cpp/manage-rows-and-columns/
keywords:
- σειρά πίνακα
- στήλη πίνακα
- πρώτη σειρά
- κεφαλίδα πίνακα
- κλωνοποίηση σειράς
- κλωνοποίηση στήλης
- αντιγραφή σειράς
- αντιγραφή στήλης
- αφαίρεση σειράς
- αφαίρεση στήλης
- μορφοποίηση κειμένου σειράς
- μορφοποίηση κειμένου στήλης
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τις σειρές και τις στήλες του πίνακα σε PowerPoint με Aspose.Slides για C++ και επιταχύνετε την επεξεργασία της παρουσίασης και τις ενημερώσεις δεδομένων."
---
## **Εισαγωγή**

Για να μπορείτε να διαχειριστείτε τις σειρές και τις στήλες ενός πίνακα σε παρουσίαση PowerPoint, η Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/cpp/aspose.slides/table/) , το interface [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) και πολλούς άλλους τύπους. 

## **Ορισμός της πρώτης σειράς ως κεφαλίδα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) και φορτώστε την παρουσίαση. 
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) και ορίστε το σε null. 
4. Περιηγηθείτε σε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) για να βρείτε τον αντίστοιχο πίνακα. 
5. Ορίστε την πρώτη σειρά του πίνακα ως κεφαλίδα. 

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε την πρώτη σειρά ενός πίνακα ως κεφαλίδα:

```c++
// Δημιουργεί μια παρουσία της κλάσης Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Προσπελάζει την πρώτη διαφάνεια
auto sld = pres->get_Slides()->idx_get(0);

// Αρχικοποιεί το null TableEx
SharedPtr<ITable> tbl;

// Διασχίζει τα σχήματα και ορίζει μια αναφορά στον πίνακα
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Ορίζει την πρώτη σειρά του πίνακα ως κεφαλίδα 
tbl->set_FirstRow(true);
```


## **Κλωνοποίηση σειράς ή στήλης πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) και φορτώστε την παρουσίαση, 
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα `columnWidth`. 
4. Ορίστε έναν πίνακα `rowHeight`. 
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addtable/). 
6. Κλωνοποιήστε τη σειρά του πίνακα. 
7. Κλωνοποιήστε τη στήλη του πίνακα. 
8. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C++ δείχνει πώς να κλωνοποιήσετε τη σειρά ή τη στήλη ενός πίνακα PowerPoint:

```c++
 // Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/CloningInTable_out.pptx";

// Δημιουργεί μια παρουσία της κλάσης Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Προσπελάζει την πρώτη διαφάνεια
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και σειρές με ύψη
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Ορίζει τη μορφή περιγράμματος για κάθε κελί
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);

	}

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone προσθέτει μια σειρά στο τέλος του πίνακα
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone προσθέτει μια σειρά σε συγκεκριμένη θέση σε έναν πίνακα
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone προσθέτει μια στήλη στο τέλος του πίνακα
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone προσθέτει μια στήλη σε συγκεκριμένη θέση σε έναν πίνακα
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Αποθηκεύει την παρουσίαση στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Αφαίρεση σειράς ή στήλης από πίνακα**

1. Δημιουργήτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) και φορτώστε την παρουσίαση, 
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα `columnWidth`. 
4. Ορίστε έναν πίνακα `rowHeight`. 
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [AddTable()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addtable/). 
6. Αφαιρέστε τη σειρά του πίνακα. 
7. Αφαιρέστε τη στήλη του πίνακα. 
8. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C++ δείχνει πώς να αφαιρέσετε μια σειρά ή στήλη από έναν πίνακα:

```c++
// Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Δημιουργεί μια παρουσία της κλάσης Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Προσπελάζει την πρώτη διαφάνεια
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Ορίζει τις στήλες με πλάτη και τις σειρές με ύψη
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Merges cells (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Merges cells (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Αποθηκεύει την παρουσίαση στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Ορισμός μορφοποίησης κειμένου σε επίπεδο σειράς πίνακα**

1. Δημιουργάτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) και φορτώστε την παρουσίαση, 
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Πρόσβαση στο σχετικό αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) από τη διαφάνεια. 
4. Ορίστε το [set_FontHeight()](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_fontheight/) των κελιών της πρώτης σειράς. 
5. Ορίστε το [set_Alignment()](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_alignment/) και το [set_MarginRight()](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_marginright/) των κελιών της πρώτης σειράς. 
6. Ορίστε το [set_TextVerticalType()](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframeformat/set_textverticaltype/) των κελιών της δεύτερης σειράς. 
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C++ εμφανίζει τη λειτουργία.

```c++
// Δημιουργεί μια παρουσία της κλάσης Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
// Ορίζει το ύψος γραμματοσειράς των κελιών της πρώτης σειράς
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Ορίζει τη στοίχιση κειμένου και το δεξιό περιθώριο των κελιών της πρώτης σειράς
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Ορίζει τον κάθετο τύπο κειμένου των κελιών της δεύτερης σειράς
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Αποθηκεύει την παρουσίαση στο δίσκο
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Ορισμός μορφοποίησης κειμένου σε επίπεδο στήλης πίνακα**

1. Δημιουργήτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) και φορτώστε την παρουσίαση, 
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Πρόσβαση στο σχετικό αντικείμενο [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) από τη διαφάνεια. 
4. Ορίστε το [set_FontHeight()](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_fontheight/) των κελιών της πρώτης στήλης. 
5. Ορίστε το [set_Alignment()](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_alignment/) και το [set_MarginRight()](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_marginright/) των κελιών της πρώτης στήλης. 
6. Ορίστε το [set_TextVerticalType()](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframeformat/set_textverticaltype/) των κελιών της δεύτερης στήλης. 
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C++ εμφανίζει τη λειτουργία: 

```c++
// Δημιουργεί μια παρουσία της κλάσης Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας

// Ορίζει το ύψος γραμματοσειράς των κελιών της πρώτης στήλης
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Ορίζει τη στοίχιση κειμένου και το δεξιό περιθώριο των κελιών της πρώτης στήλης σε μία κλήση
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Ορίζει τον κάθετο τύπο κειμένου των κελιών της δεύτερης στήλης
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Λήψη ιδιοτήτων στυλ πίνακα**

Η Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ για έναν πίνακα, ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για άλλο πίνακα ή σε άλλο μέρος. Αυτός ο κώδικας C++ δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προρυθμισμένο στυλ πίνακα:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν πίνακα που έχει ήδη δημιουργηθεί;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/κύριου θέματος, και μπορείτε ακόμα να παρακάμψετε τα γεμίσματα, τα περιγράμματα και τα χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις σειρές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, στη συνέχεια επαναπληρώστε τις σειρές του πίνακα με αυτή τη σειρά.

**Μπορώ να έχω στήλες με λωρίδες (banded) διατηρώντας προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις στήλες με λωρίδες, στη συνέχεια παρακάμψτε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση σε επίπεδο κελιού έχει προτεραιότητα έναντι του στυλ πίνακα.