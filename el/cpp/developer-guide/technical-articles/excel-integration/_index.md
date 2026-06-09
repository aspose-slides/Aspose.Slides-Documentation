---
title: Ενσωμάτωση δεδομένων Excel σε παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/cpp/excel-integration/
keywords:
- Excel
- Βιβλίο εργασίας
- ανάγνωση Excel
- ενσωμάτωση Excel
- πηγή δεδομένων
- συγχώνευση αλληλογραφίας
- εισαγωγή πίνακα
- Excel σε PowerPoint
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανάγνωση δεδομένων από βιβλία εργασίας Excel στο Aspose.Slides χρησιμοποιώντας το API ExcelDataWorkbook. Φόρτωση φύλλων και κελιών και χρήση τιμών για τη δημιουργία παρουσιάσεων PowerPoint καθοδηγούμενων από δεδομένα."
---
## **Εισαγωγή**

Οι παρουσιάσεις PowerPoint αποτελούν έναν ισχυρό τρόπο παρουσίασης και επικοινωνίας πληροφοριών. Συχνά χρησιμοποιούνται σε συνδυασμό με βιβλία εργασίας Excel, όπου το Excel λειτουργεί ως εξαιρετική πηγή δομημένων δεδομένων και το PowerPoint διαπρέπει στην οπτικοποίηση αυτών των δεδομένων για το ακροατήριο.

Υπάρχουν πολλές πρακτικές περιπτώσεις όπου ο συνδυασμός Excel και PowerPoint είναι απαραίτητος: συγχωνεύσεις αλληλογραφίας, πλήρωση πινάκων δεδομένων, δημιουργία μιας διαφάνειας ανά εγγραφή δεδομένων (μαζική δημιουργία διαφανειών), δημιουργία εκπαιδευτικού υλικού και ενοποίηση πολλαπλών αναφορών Excel σε μία παρουσίαση, για παράδειγμα.

Μέχρι τώρα, η υλοποίηση τέτοιων λειτουργιών με το Aspose.Slides API απαιτούσε την εξάρτηση από τρίτες λύσεις όπως το Aspose.Cells. Ενώ αυτά τα εργαλεία είναι ισχυρά, μπορεί να είναι υπερβολικά περίπλοκα και δαπανηρά για χρήστες που χρειάζονται μόνο βασική λειτουργικότητα ενσωμάτωσης δεδομένων.

## **Πώς λειτουργεί**

Για να γίνει η εργασία με δεδομένα Excel πιο εύκολη και αποδοτική, το Aspose.Slides έχει εισαγάγει νέες κλάσεις για ανάγνωση δεδομένων από βιβλία εργασίας Excel και εισαγωγή περιεχομένου σε μια παρουσίαση. Αυτή η δυνατότητα ανοίγει ισχυρές νέες προοπτικές για τους χρήστες του API που θέλουν να αξιοποιήσουν το Excel ως πηγή δεδομένων στις διαδικασίες παρουσίασής τους.

Η νέα λειτουργικότητα έχει σχεδιαστεί για γενική πρόσβαση σε δεδομένα και δεν είναι ενσωματωμένη στο Presentation Document Object Model (DOM). Αυτό σημαίνει ότι *δεν επιτρέπει την επεξεργασία ή αποθήκευση αρχείων Excel* — ο μοναδικός σκοπός της είναι το άνοιγμα βιβλίων εργασίας και η περιήγηση στο περιεχόμενό τους για την ανάκτηση τιμών κελιών.

Στον πυρήνα αυτής της δυνατότητας βρίσκεται η νέα κλάση [ExcelDataWorkbook](https://reference.aspose.com/slides/el/cpp/aspose.slides.excel/exceldataworkbook/). Αυτή η κλάση σας επιτρέπει να φορτώσετε ένα βιβλίο εργασίας Excel από τοπικό αρχείο ή ροή. Μόλις φορτωθεί, παρέχει αρκετές υπερφορτώσεις της μεθόδου [GetCell](https://reference.aspose.com/slides/el/cpp/aspose.slides.excel/exceldataworkbook/getcell/), την οποία μπορείτε να χρησιμοποιήσετε για να ανακτήσετε συγκεκριμένα κελιά βάσει της θέσης τους (π.χ. δείκτες γραμμής και στήλης ή ονομαστικές περιοχές).

Κάθε κλήση στη μέθοδο [GetCell](https://reference.aspose.com/slides/el/cpp/aspose.slides.excel/exceldataworkbook/getcell/) επιστρέφει μια παρουσία της κλάσης [ExcelDataCell](https://reference.aspose.com/slides/el/cpp/aspose.slides.excel/exceldatacell/). Αυτό το αντικείμενο αντιπροσωπεύει ένα μόνο κελί στο βιβλίο εργασίας Excel και σας δίνει πρόσβαση στην τιμή του με απλό και διαισθητικό τρόπο.

#### **Εισαγωγή γραφήματος Excel**

Το επόμενο βήμα για την επέκταση της λειτουργικότητας είναι η κλάση [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/cpp/aspose.slides.import/excelworkbookimporter/). Αυτή η βοηθητική κλάση παρέχει δυνατότητα εισαγωγής περιεχομένου από βιβλίο εργασίας Excel σε μια παρουσίαση. Περιλαμβάνει αρκετές υπερφορτώσεις της μεθόδου [AddChartFromWorkbook](https://reference.aspose.com/slides/el/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), η οποία σας βοηθά να ανακτήσετε το επιλεγμένο γράφημα από το καθορισμένο βιβλίο εργασίας Excel και να το προσθέσετε στο τέλος της δεδομένης συλλογής σχημάτων στις καθορισμένες συντεταγμένες.

Συνοπτικά, είναι ένα ελαφρύ και άμεσο API για ανάγνωση δεδομένων Excel — ακριβώς αυτό που χρειάζονται πολλοί προγραμματιστές χωρίς το βάρος μιας πλήρους βιβλιοθήκης επεξεργασίας υπολογιστικών φύλλων.

## **Ας κωδικοποιήσουμε**

### **Παράδειγμα σεναρίου συγχώνευσης αλληλογραφίας**

Στο παρακάτω παράδειγμα, θα υλοποιήσουμε ένα απλό σενάριο συγχώνευσης αλληλογραφίας δημιουργώντας πολλαπλές παρουσιάσεις βασισμένες στα δεδομένα που αποθηκεύονται σε ένα βιβλίο εργασίας Excel.

Για να ξεκινήσουμε, χρειαζόμαστε δύο πράγματα:
1. Ένα βιβλίο εργασίας Excel που περιέχει τα δεδομένα

![Excel data example](example1_image0.png)

2. Πρότυπο παρουσίασης PowerPoint

![PowerPoint template example](example1_image1.png)

```cpp
// Φόρτωση του βιβλίου εργασίας Excel με δεδομένα υπαλλήλων.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Φόρτωση του προτύπου παρουσίασης.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Επανάληψη στις σειρές του Excel (εξαιόντας την κεφαλίδα στη σειρά 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Δημιουργία νέας παρουσίασης για κάθε εγγραφή υπαλλήλου.
    auto employeePresentation = MakeObject<Presentation>();

    // Αφαίρεση της προεπιλεγμένης κενής διαφάνειας.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Κλωνοποίηση της διαφάνειας προτύπου στη νέα παρουσίαση.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Λήψη παραγράφων από το επιλεγμένο σχήμα (υποθέτει ότι χρησιμοποιείται ο δείκτης σχήματος 1).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Αντικατάσταση των δεσμευτικών θέσεων με δεδομένα από το Excel.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Αποθήκευση της προσωποποιημένης παρουσίασης σε ξεχωριστό αρχείο.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Result](example1_image2.png)

### **Παράδειγμα πίνακα Excel**

Στο δεύτερο παράδειγμα, αντιγράφουμε απλώς δεδομένα από έναν πίνακα Excel και τα εμφανίζουμε σε μια διαφάνεια PowerPoint με πιο ελκυστική οπτική μορφή.

Σε αυτό το παράδειγμα, ξαναχρησιμοποιούμε το ίδιο βιβλίο εργασίας Excel από το πρώτο παράδειγμα, το οποίο περιέχει έναν απλό πίνακα εργαζομένων.

```cpp
// Φόρτωση του βιβλίου εργασίας Excel που περιέχει τα δεδομένα των υπαλλήλων.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Δημιουργία νέας παρουσίασης PowerPoint.
auto presentation = MakeObject<Presentation>();

// Προσθήκη σχήματος πίνακα στην πρώτη διαφάνεια.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Συμπλήρωση του πίνακα PowerPoint με δεδομένα από το βιβλίο εργασίας Excel.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Αποθήκευση της προκύπτουσας παρουσίασης σε αρχείο.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Result](example2_image0.png)

### **Παράδειγμα εισαγωγής γραφήματος Excel**

Σε αυτό το παράδειγμα, εισάγουμε ένα γράφημα από το πρώτο φύλλο εργασίας του βιβλίου εργασίας Excel που χρησιμοποιήθηκε στο προηγούμενο παράδειγμα. Το γράφημα θα συνδεθεί με το εξωτερικό βιβλίο εργασίας στην τελική παρουσίαση.

Πρώτα, προσθέτουμε ένα γράφημα Πίτας στο βιβλίο εργασίας Excel με βάση τον πίνακα εργαζομένων.

![Excel Chart example](example3_image0.png)

```cpp
// Δημιουργία νέας παρουσίασης PowerPoint.
auto presentation = MakeObject<Presentation>();

// Λήψη της συλλογής σχημάτων της πρώτης διαφάνειας.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Εισαγωγή του γραφήματος με όνομα "Chart 1" από το πρώτο φύλλο του βιβλίου εργασίας και προσθήκη στη συλλογή σχημάτων.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Αποθήκευση της προκύπτουσας παρουσίασης σε αρχείο.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Result](example3_image1.png)

### **Παράδειγμα εισαγωγής όλων των γραφημάτων Excel**

Ας υποθέσουμε ότι έχετε ένα βιβλίο εργασίας Excel γεμάτο γραφήματα και χρειάζεται να τα εισάγετε όλα σε μια παρουσίαση. Κάθε γράφημα πρέπει να τοποθετηθεί σε μια νέα διαφάνεια.

Ο παρακάτω κώδικας διατρέχει όλα τα φύλλα εργασίας στο πηγαίο αρχείο Excel, εξάγει τα γραφήματα από κάθε φύλλο και προσθέτει καθένα σε ξεχωριστή διαφάνεια χρησιμοποιώντας μια κενή διάταξη διαφάνειας. Στην τελική παρουσίαση, θα ενσωματωθούν μόνο τα δεδομένα του γραφήματος, όχι ολόκληρο το βιβλίο εργασίας.

```cpp
// Φόρτωση του βιβλίου εργασίας Excel που περιέχει τα δεδομένα των υπαλλήλων.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Δημιουργία νέας παρουσίασης PowerPoint.
auto presentation = MakeObject<Presentation>();

// Ανάκτηση της διάταξης κενής διαφάνειας.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Λήψη των ονομάτων όλων των φύλλων εργασίας που περιέχονται στο βιβλίο εργασίας Excel.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Ανάκτηση ενός λεξικού που αντιστοιχεί τους δείκτες γραφημάτων σε ονόματα γραφημάτων για το φύλλο εργασίας.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Προσθήκη νέας διαφάνειας χρησιμοποιώντας τη διάταξη κενής διαφάνειας.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Εισαγωγή του καθορισμένου γραφήματος από το βιβλίο εργασίας Excel στη συλλογή σχημάτων της διαφάνειας.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Αποθήκευση της προκύπτουσας παρουσίασης σε αρχείο.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Σύνοψη**

Αυτός ο μηχανισμός, διαθέσιμος απευθείας στο Aspose.Slides, συνδυάζει την εργασία με δεδομένα Excel και παρουσιάσεις σε ένα ενιαίο σημείο. Σας επιτρέπει να δημιουργείτε διαφάνειες με οπτικά γραφήματα και δεδομένα παρουσιασμένα ως πίνακες Excel — χωρίς πρόσθετες βιβλιοθήκες ή πολύπλοκες ενσωματώσεις.