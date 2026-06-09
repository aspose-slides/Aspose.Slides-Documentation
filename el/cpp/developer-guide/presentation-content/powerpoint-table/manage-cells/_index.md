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
- διαχωρισμός κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε εύκολα τα κελιά πίνακα στο PowerPoint με το Aspose.Slides για C++. Μάθετε να προσπελάζετε, να τροποποιείτε και να μορφοποιείτε τα κελιά γρήγορα για αδιάλειπτη αυτοματοποίηση διαφανειών."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να έχετε πρόσβαση και να τροποποιείτε τα κελιά πίνακα σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πίνακα, να αφαιρείτε τα περιθώρια των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό τους, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να πάρετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κελιών μέσω των ιδιοτήτων των κελιών και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

## **Εντοπισμός Συγχωνευμένου Κελιού**
1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
2. Αποκτήστε τον πίνακα από την πρώτη διαφάνεια. 
3. Επαναλάβετε τις γραμμές και τις στήλες του πίνακα για να βρείτε συγχωνευμένα κελιά.
4. Εκτυπώστε μήνυμα όταν βρεθούν συγχωνευμένα κελιά.

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Αφαίρεση Περιγραμμάτων Κελιών Πίνακα**
1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
2. Αποκτήστε τη αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα στήλων με πλάτος.
4. Ορίστε έναν πίνακα γραμμών με ύψος.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου `AddTable`.
6. Περιηγηθείτε σε κάθε κελί για να διαγράψετε τα άνω, κάτω, δεξιά και αριστερά περιγράμματα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` cpp
// Δημιουργεί μια παρουσίαση μέσω της κλάσης Presentation η οποία αντιπροσωπεύει ένα αρχείο PPTX
auto pres = MakeObject<Presentation>();
// Προσπελάζει την πρώτη διαφάνία
auto sld = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και γραμμές με ύψη
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Προσθέτει ένα σχήμα πίνακα στη διαφάνία
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ορίζει τη μορφή περιγράμματος για κάθε κελί
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// Γράφει το αρχείο PPTX στον δίσκο
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Αρίθμηση σε Συγχωνευμένα Κελιά**
Αν συγχωνεύσουμε 2 ζεύγη κελιών (1, 1) x (2, 1) και (1, 2) x (2, 2), ο προκύπτων πίνακας θα αριθμηθεί. Αυτός ο κώδικας C# παρουσιάζει τη διαδικασία:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Φορτώνει την επιθυμητή παρουσίαση
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και γραμμές με ύψη
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
// Συγχωνεύει τα κελιά (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Συγχωνεύει τα κελιά (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Αποθηκεύει το αρχείο PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Στη συνέχεια συγχωνεύουμε περαιτέρω τα κελιά συγχωνεύοντας τα (1, 1) και (1, 2). Το αποτέλεσμα είναι ένας πίνακας που περιέχει ένα μεγάλο συγχωνευμένο κελί στο κέντρο του:

```c++
// Η διαδρομή προς τον φάκελο εγγράφων.
const String outPath = u"../out/MergeCells_out.pptx";

// Φορτώνει την επιθυμητή παρουσίαση
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και γραμμές με ύψη
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

// Συγχωνεύει τα κελιά (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Συγχωνεύει τα κελιά (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Αποθηκεύει το αρχείο PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Αρίθμηση σε Διαχωρισμένο Κελί**
Στα προηγούμενα παραδείγματα, όταν τα κελιά πίνακα συγχωνεύθηκαν, η αρίθμηση ή το σύστημα αριθμών στα άλλα κελιά δεν άλλαζε. 

Αυτή τη φορά, παίρνουμε έναν κανονικό πίνακα (έναν πίνακα χωρίς συγχωνευμένα κελιά) και προσπαθούμε να διαχωρίσουμε το κελί (1,1) για να δημιουργήσουμε έναν ειδικό πίνακα. Ίσως θέλετε να προσέξετε την αρίθμηση αυτού του πίνακα, η οποία μπορεί να φαίνεται παράξενη. Ωστόσο, έτσι ακολουθεί η αρίθμηση κελιών πίνακα του Microsoft PowerPoint και το Aspose.Slides συμπεριφέρεται με τον ίδιο τρόπο. 

Αυτός ο κώδικας C++ παρουσιάζει τη διαδικασία που περιγράψαμε:

```c++
// Η διαδρομή προς τον φάκελο εγγράφων.
const String outPath = u"../out/CellSplit_out.pptx";

// Φορτώνει την επιθυμητή παρουσίαση
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και γραμμές με ύψη
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Προσθέτει σχήμα πίνακα στη διαφάνεια
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

// Συγχωνεύει τα κελιά (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Συγχωνεύει τα κελιά (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Διαχωρίζει το κελί (1, 1).
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Αποθηκεύει το αρχείο PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε το χρώμα φόντου ενός κελιού πίνακα:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// δημιουργεί νέο πίνακα
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// ορίζει το χρώμα φόντου για ένα κελί 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**
1. Δημιουργήστε μια παρουσίαση της κλάσης `Presentation`.
2. Αποκτήστε τη αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Ορίστε έναν πίνακα στήλων με πλάτος.
4. Ορίστε έναν πίνακα γραμμών με ύψος.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου `AddTable`. 
6. Δημιουργήστε ένα αντικείμενο `Bitmap` για την αποθήκευση του αρχείου εικόνας.
7. Προσθέστε την εικόνα bitmap στο αντικείμενο `IPPImage`.
8. Ορίστε το `FillFormat` για το κελί του πίνακα σε `Picture`.
9. Προσθέστε την εικόνα στο πρώτο κελί του πίνακα.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX

```c++
// Η διαδρομή προς τον φάκελο εγγράφων.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Φορτώνει την επιθυμητή παρουσίαση
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Ορίζει στήλες με πλάτη και γραμμές με ύψη
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Προσθέτει σχήμα πίνακα στη διαφάνεια
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Παίρνει την εικόνα
auto img = Images::FromFile(ImagePath);

// Προσθέτει την εικόνα στη συλλογή εικόνων της παρουσίασης
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);

// Προσθέτει την εικόνα στο πρώτο κελί του πίνακα
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Αποθηκεύει το αρχείο PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ορίσω διαφορετικά πάχη γραμμής και στυλ για διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιθώρια [top](https://reference.aspose.com/slides/el/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/el/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/el/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/el/cpp/aspose.slides/cellformat/get_borderright/) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς να μπορούν να διαφέρουν. Αυτό προκύπτει λογικά από τον έλεγχο των περιγραμμάτων ανά πλευρά για ένα κελί που παρουσιάζεται στο άρθρο.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο κελιού;**

Η συμπεριφορά εξαρτάται από το [fill mode](https://reference.aspose.com/slides/el/cpp/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη, τα πλακίδια επαναϋπολογίζονται. Το άρθρο αναφέρει τις λειτουργίες εμφάνισης εικόνας σε ένα κελί.

**Μπορώ να αντιστοιχίσω έναν υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

Οι [Hyperlinks](/slides/el/cpp/manage-hyperlinks/) ορίζονται στο επίπεδο του κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, ορίζετε τον σύνδεσμο σε μια περιοχή ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/el/cpp/aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.