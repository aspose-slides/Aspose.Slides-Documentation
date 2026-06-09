---
title: Ενσωμάτωση Δεδομένων Excel σε Παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/net/excel-integration/
keywords:
- Excel
- βιβλίο εργασίας
- ανάγνωση Excel
- ενσωμάτωση Excel
- πηγή δεδομένων
- συγχώνευση αλληλογραφίας
- εισαγωγή πίνακα
- Excel σε PowerPoint
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανάγνωση δεδομένων από βιβλία εργασίας Excel στο Aspose.Slides χρησιμοποιώντας το API ExcelDataWorkbook. Φόρτωση φύλλων και κυψελών και χρήση των τιμών για δημιουργία παρουσιάσεων PowerPoint βάσει δεδομένων."
---
## **Εισαγωγή**

Οι παρουσιάσεις PowerPoint είναι ένας ισχυρός τρόπος για την προβολή και την επικοινωνία πληροφοριών. Συχνά χρησιμοποιούνται σε συνδυασμό με βιβλία εργασίας Excel, όπου το Excel λειτουργεί ως εξαιρετική πηγή δομημένων δεδομένων και το PowerPoint διαπρέπει στην απεικόνιση αυτών των δεδομένων για ένα κοινό.

Υπάρχουν πολλές πρακτικές περιπτώσεις όπου ο συνδυασμός Excel και PowerPoint είναι απαραίτητος: συγχωνεύσεις αλληλογραφίας, πληθώρα δεδομένων σε πίνακες, δημιουργία μίας διαφάνειας ανά εγγραφή δεδομένων (παραγωγή διαφανειών σε παρτίδα), δημιουργία εκπαιδευτικού υλικού και ενοποίηση πολλαπλών αναφορών Excel σε μία παρουσίαση, για παράδειγμα.

Μέχρι τώρα, η υλοποίηση τέτοιων λειτουργιών με το Aspose.Slides API απαιτούσε την εξάρτηση από λύσεις τρίτων όπως το Aspose.Cells. Ενώ αυτά τα εργαλεία είναι ισχυρά, μπορούν να είναι υπερβολικά πολύπλοκα και δαπανηρά για χρήστες που χρειάζονται μόνο βασική λειτουργικότητα ενσωμάτωσης δεδομένων.

## **Πώς Λειτουργεί**

Για να γίνει η εργασία με δεδομένα Excel πιο εύκολη και πιο ομαλή, το Aspose.Slides έχει εισαγάγει νέες κλάσεις για την ανάγνωση δεδομένων από βιβλία εργασίας Excel και την εισαγωγή περιεχομένου σε μια παρουσίαση. Αυτό το χαρακτηριστικό ανοίγει ισχυρές νέες δυνατότητες για χρήστες του API που θέλουν να αξιοποιήσουν το Excel ως πηγή δεδομένων μέσα στις ροές εργασίας των παρουσιάσεων τους.

Η νέα λειτουργικότητα σχεδιάστηκε για γενική πρόσβαση σε δεδομένα και δεν είναι ενσωματωμένη στο Presentation Document Object Model (DOM). Αυτό σημαίνει *ότι δεν επιτρέπει την επεξεργασία ή αποθήκευση αρχείων Excel* — ο μοναδικός της σκοπός είναι το άνοιγμα βιβλίων εργασίας και η περιήγηση στο περιεχόμενό τους για την ανάκτηση δεδομένων κελιών.

Στην καρδιά αυτού του χαρακτηριστικού βρίσκεται η νέα κλάση [ExcelDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.excel/exceldataworkbook/). Αυτή η κλάση σας επιτρέπει να φορτώσετε ένα βιβλίο εργασίας Excel από τοπικό αρχείο ή ροή. Μόλις φορτωθεί, παρέχει αρκετές υπερφορτώσεις της μεθόδου [GetCell](https://reference.aspose.com/slides/el/net/aspose.slides.excel/exceldataworkbook/getcell/), τις οποίες μπορείτε να χρησιμοποιήσετε για να ανακτήσετε συγκεκριμένα κελιά με βάση τη θέση τους (π.χ. δείκτες γραμμής και στήλης ή ονομαστικές περιοχές).

Κάθε κλήση στη μέθοδο [GetCell](https://reference.aspose.com/slides/el/net/aspose.slides.excel/exceldataworkbook/getcell/) επιστρέφει ένα στιγμιότυπο της κλάσης [ExcelDataCell](https://reference.aspose.com/slides/el/net/aspose.slides.excel/exceldatacell/). Αυτό το αντικείμενο αντιπροσωπεύει ένα μοναδικό κελί στο βιβλίο εργασίας Excel και σας δίνει πρόσβαση στην τιμή του με έναν απλό και διαισθητικό τρόπο.

#### **Εισαγωγή Διαγράμματος Excel**

Το επόμενο βήμα για την επέκταση της λειτουργικότητας είναι η κλάση [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/net/aspose.slides.import/excelworkbookimporter/). Αυτή η βοηθητική κλάση παρέχει λειτουργίες για την εισαγωγή περιεχομένου από ένα βιβλίο εργασίας Excel σε μια παρουσίαση. Περιέχει αρκετές υπερφορτώσεις της μεθόδου [AddChartFromWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), οι οποίες σας βοηθούν να ανακτήσετε το επιλεγμένο γράφημα από το συγκεκριμένο βιβλίο εργασίας Excel και να το προσθέσετε στο τέλος της δεδομένης συλλογής σχήματος στις καθορισμένες συντεταγμένες.

Συνοπτικά, είναι ένα ελαφρύ και απλό API για την ανάγνωση δεδομένων Excel — ακριβώς ό,τι χρειάζονται πολλοί προγραμματιστές χωρίς το βάρος μιας πλήρους βιβλιοθήκης επεξεργασίας υπολογιστικών φύλλων.

## **Ας Γράψουμε Κώδικα**

### **Παράδειγμα Σεναρίου Συγχώνευσης Ταχυδρομείου**

Στο παρακάτω παράδειγμα, θα υλοποιήσουμε ένα απλό σενάριο συγχώνευσης ταχυδρομείου δημιουργώντας πολλαπλές παρουσιάσεις βασισμένες στα δεδομένα που αποθηκεύονται σε ένα βιβλίο εργασίας Excel.

Για να ξεκινήσουμε, χρειαζόμαστε δύο πράγματα:
1. Ένα βιβλίο εργασίας Excel που περιέχει τα δεδομένα

![Παράδειγμα δεδομένων Excel](example1_image0.png)

2. Πρότυπο παρουσίασης PowerPoint

![Παράδειγμα προτύπου PowerPoint](example1_image1.png)

```csharp
// Φόρτωση του βιβλίου εργασίας Excel με δεδομένα υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Φόρτωση του προτύπου παρουσίασης.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Επανάληψη στις γραμμές του Excel (εξαίρεση της κεφαλίδας στη γραμμή 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Δημιουργία νέας παρουσίασης για κάθε εγγραφή υπαλλήλου.
    using Presentation employeePresentation = new Presentation();

    // Αφαίρεση της προεπιλεγμένης κενής διαφάνειας.
    employeePresentation.Slides.RemoveAt(0);

    // Κλωνοποίηση της διαφάνειας προτύπου στη νέα παρουσίαση.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Λήψη παραγράφων από το στόχο σχήμα (υποθέτει ότι χρησιμοποιείται δείκτης σχήματος 1).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Αντικατάσταση των δεσμευτικών θέσεων με δεδομένα από το Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Αποθήκευση της προσαρμοσμένης παρουσίασης σε ξεχωριστό αρχείο.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Αποτέλεσμα](example1_image2.png)

### **Παράδειγμα Πίνακα Excel**

Στο δεύτερο παράδειγμα, αντιγράφουμε απλώς δεδομένα από έναν πίνακα Excel και τα εμφανίζουμε σε μια διαφάνεια PowerPoint με πιο ελκυστική οπτική μορφή.

Σε αυτό το παράδειγμα, ξαναχρησιμοποιούμε το ίδιο βιβλίο εργασίας Excel από το πρώτο παράδειγμα, το οποίο περιέχει έναν απλό πίνακα υπαλλήλων.

```csharp
// Φόρτωση του βιβλίου εργασίας Excel που περιέχει τα δεδομένα των υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Δημιουργία νέας παρουσίασης PowerPoint.
using Presentation presentation = new Presentation();

// Προσθήκη σχήματος πίνακα στην πρώτη διαφάνεια.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Συμπλήρωση του πίνακα PowerPoint με δεδομένα από το βιβλίο εργασίας Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Αποθήκευση της προκύπτουσας παρουσίασης σε αρχείο.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Αποτέλεσμα](example2_image0.png)

### **Παράδειγμα Εισαγωγής Διαγράμματος Excel**

Σε αυτό το παράδειγμα, εισάγουμε ένα γράφημα από το πρώτο φύλλο εργασίας του βιβλίου εργασίας Excel που χρησιμοποιήθηκε στο προηγούμενο παράδειγμα. Το γράφημα θα συνδεθεί με το εξωτερικό βιβλίο εργασίας στην τελική παρουσίαση.

Αρχικά, προσθέτουμε ένα γράφημα τύπου Πίτα στο βιβλίο εργασίας Excel με βάση τον πίνακα υπαλλήλων.

![Παράδειγμα διαγράμματος Excel](example3_image0.png)

```csharp
// Δημιουργία νέας παρουσίασης PowerPoint.
using Presentation presentation = new Presentation();

// Λήψη της συλλογής σχημάτων της πρώτης διαφάνειας.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Εισαγωγή του διαγράμματος με όνομα "Chart 1" από το πρώτο φύλλο του βιβλίου εργασίας και προσθήκη του στη συλλογή σχημάτων.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Αποθήκευση της προκύπτουσας παρουσίασης σε αρχείο.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Αποτέλεσμα](example3_image1.png)

### **Παράδειγμα Εισαγωγής Όλων των Διαγραμμάτων Excel**

Ας υποθέσουμε ότι έχετε ένα βιβλίο εργασίας Excel γεμάτο γραφήματα και πρέπει να τα εισάγετε όλα σε μια παρουσίαση. Κάθε γράφημα πρέπει να τοποθετηθεί σε νέα διαφάνεια.

Ο παρακάτω κώδικας διατρέχει όλα τα φύλλα εργασίας στο πηγαίο αρχείο Excel, εξάγει τα γραφήματα από κάθε φύλλο και προσθέτει κάθε γράφημα σε ξεχωριστή διαφάνεια χρησιμοποιώντας μια κενή διάταξη διαφάνειας. Στην τελική παρουσίαση, θα ενσωματωθούν μόνο τα δεδομένα του γραφήματος, όχι ολόκληρο το βιβλίο εργασίας.

```csharp
// Φόρτωση του βιβλίου εργασίας Excel που περιέχει τα δεδομένα των υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Δημιουργία νέας παρουσίασης PowerPoint.
using Presentation presentation = new Presentation();

// Ανάκτηση της κενής διάταξης διαφάνειας.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Λήψη των ονομάτων όλων των φύλλων εργασίας που περιέχονται στο βιβλίο εργασίας Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Ανάκτηση λεξικού που αντιστοιχίζει δείκτες διαγραμμάτων σε ονόματα διαγραμμάτων για το φύλλο εργασίας.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Προσθήκη νέας διαφάνειας χρησιμοποιώντας την κενή διάταξη.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Εισαγωγή του καθορισμένου διαγράμματος από το βιβλίο εργασίας Excel στη συλλογή σχημάτων της διαφάνειας.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Αποθήκευση της προκύπτουσας παρουσίασης σε αρχείο.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **Σύνοψη**

Αυτός ο μηχανισμός, διαθέσιμος απευθείας στο Aspose.Slides, συνδυάζει την εργασία με δεδομένα Excel και παρουσιάσεις σε ένα σημείο. Σας επιτρέπει να δημιουργήσετε διαφάνειες με οπτικά γραφήματα και δεδομένα που παρουσιάζονται ως πίνακες Excel — χωρίς επιπλέον βιβλιοθήκες ή περίπλοκες ενσωματώσεις.