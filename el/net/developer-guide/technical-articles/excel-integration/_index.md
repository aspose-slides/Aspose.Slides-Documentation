---
title: Ενσωμάτωση Δεδομένων Excel σε Παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
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
description: "Ανάγνωση δεδομένων από βιβλία εργασίας Excel στο Aspose.Slides χρησιμοποιώντας το API ExcelDataWorkbook. Φόρτωση φύλλων και κελιών και χρήση των τιμών για τη δημιουργία παρουσιάσεων PowerPoint βασισμένων σε δεδομένα."
---
## **Εισαγωγή**

Οι παρουσιάσεις PowerPoint είναι ένας ισχυρός τρόπος για την προβολή και τη μετάδοση πληροφοριών. Συχνά χρησιμοποιούνται σε συνδυασμό με βιβλία εργασίας Excel, όπου το Excel λειτουργεί ως εξαιρετική πηγή δομημένων δεδομένων και το PowerPoint διαπρέπει στην οπτικοποίηση αυτών των δεδομένων για το κοινό.

Υπάρχουν πολλές πρακτικές περιπτώσεις όπου ο συνδυασμός Excel και PowerPoint είναι απαραίτητος: συγχωνεύσεις αλληλογραφίας, γέμισμα πινάκων δεδομένων, δημιουργία μίας διαφάνειας ανά εγγραφή δεδομένων (παρτίδα δημιουργίας διαφανειών), δημιουργία εκπαιδευτικού υλικού και ενοποίηση πολλαπλών αναφορών Excel σε μία παρουσίαση, για να αναφέρουμε μερικά.

Μέχρι τώρα, η υλοποίηση τέτοιων λειτουργιών με το API του Aspose.Slides απαιτούσε την εξάρτηση από λύσεις τρίτων, όπως το Aspose.Cells. Αν και αυτά τα εργαλεία είναι ισχυρά, μπορεί να είναι υπερβολικά πολύπλοκα και δαπανηρά για χρήστες που χρειάζονται μόνο βασική λειτουργικότητα ενσωμάτωσης δεδομένων.

## **Πώς Λειτουργεί**

Για να γίνει η εργασία με δεδομένα Excel πιο εύκολη και απλούστερη, το Aspose.Slides παρουσίασε νέες κλάδες για την ανάγνωση δεδομένων από βιβλία εργασίας Excel και την εισαγωγή περιεχομένου σε μια παρουσίαση. Αυτή η λειτουργία ανοίγει ισχυρές νέες δυνατότητες για χρήστες του API που θέλουν να αξιοποιήσουν το Excel ως πηγή δεδομένων μέσα στις ροές εργασίας των παρουσιάσεων τους.

Η νέα λειτουργικότητα σχεδιάστηκε για γενική πρόσβαση σε δεδομένα και δεν ενσωματώνεται στο Presentation Document Object Model (DOM). Αυτό σημαίνει ότι *δεν επιτρέπει την επεξεργασία ή αποθήκευση αρχείων Excel* — ο μοναδικός σκοπός της είναι το άνοιγμα βιβλίων εργασίας και η περιήγηση στο περιεχόμενό τους για την ανάκτηση δεδομένων κελιών.

Στον πυρήνα αυτής της λειτουργίας βρίσκεται η νέα κλάδα [ExcelDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.excel/exceldataworkbook/). Αυτή η κλάδα σας επιτρέπει να φορτώσετε ένα βιβλίο εργασίας Excel από τοπικό αρχείο ή ροή. Μόλις φορτωθεί, παρέχει πολλές υπερφορτώσεις της μεθόδου [GetCell](https://reference.aspose.com/slides/el/net/aspose.slides.excel/exceldataworkbook/getcell/), την οποία μπορείτε να χρησιμοποιήσετε για να ανακτήσετε συγκεκριμένα κελιά βάσει της θέσης τους (π.χ., δείκτες γραμμής και στήλης ή ονομαστικές περιοχές).

Κάθε κλήση στη [GetCell](https://reference.aspose.com/slides/el/net/aspose.slides.excel/exceldataworkbook/getcell/) επιστρέφει μια παρουσία της κλάδας [ExcelDataCell](https://reference.aspose.com/slides/el/net/aspose.slides.excel/exceldatacell/). Αυτό το αντικείμενο αντιπροσωπεύει ένα μοναδικό κελί στο βιβλίο εργασίας Excel και σας παρέχει πρόσβαση στην τιμή του με έναν απλό και διαισθητικό τρόπο.

#### **Εισαγωγή Γραφήματος Excel**

Το επόμενο βήμα για την επέκταση της λειτουργικότητας είναι η κλάδα [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/net/aspose.slides.import/excelworkbookimporter/). Αυτή η βοηθητική κλάδα παρέχει λειτουργικότητα για την εισαγωγή περιεχομένου από ένα βιβλίο εργασίας Excel σε μια παρουσίαση. Περιέχει πολλές υπερφορτώσεις της μεθόδου [AddChartFromWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), η οποία σας βοηθά να ανακτήσετε το επιλεγμένο γράφημα από το καθορισμένο βιβλίο εργασίας Excel και να το προσθέσετε στο τέλος της δοθείσας συλλογής σχημάτων στις καθορισμένες συντεταγμένες.

#### **Εισαγωγή Πίνακα Excel**

Η κλάδα [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/net/aspose.slides.import/excelworkbookimporter/) περιέχει επίσης πολλές υπερφορτώσεις της μεθόδου [AddTableFromWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Αυτές οι μέθοδοι σας επιτρέπουν να εισάγετε μια καθορισμένη περιοχή κελιών από ένα καθορισμένο φύλλο εργασίας και να την προσθέσετε ως πίνακα στο τέλος της δοθείσας συλλογής σχημάτων στις καθορισμένες συντεταγμένες.

Συνοπτικά, είναι ένα ελαφρύ και απλό API για την ανάγνωση δεδομένων Excel — ακριβώς αυτό που χρειάζονται πολλοί προγραμματιστές χωρίς το βάρος μιας πλήρους βιβλιοθήκης επεξεργασίας υπολογιστικών φύλλων.

## **Ας γράψουμε κώδικα**

### **Παράδειγμα Σεναρίου Συγχώνευσης Ταχυδρομείου**

Στο παρακάτω παράδειγμα, θα υλοποιήσουμε ένα απλό σενάριο Συγχώνευσης Ταχυδρομείου δημιουργώντας πολλαπλές παρουσιάσεις βάσει δεδομένων αποθηκευμένων σε βιβλίο εργασίας Excel.

Για να ξεκινήσουμε, χρειάζονται δύο πράγματα:
1. Ένα βιβλίο εργασίας Excel που περιέχει τα δεδομένα

![Παράδειγμα δεδομένων Excel](example1_image0.png)

2. Πρότυπο παρουσίασης PowerPoint

![Παράδειγμα προτύπου PowerPoint](example1_image1.png)

```csharp
// Φορτώστε το βιβλίο εργασίας Excel με δεδομένα υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Φορτώστε το πρότυπο παρουσίασης.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Διατρέξτε τις γραμμές του Excel (εξαιρώντας την κεφαλίδα στη γραμμή 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Δημιουργήστε μια νέα παρουσίαση για κάθε εγγραφή υπαλλήλου.
    using Presentation employeePresentation = new Presentation();

    // Αφαιρέστε την προεπιλεγμένη κενή διαφάνεια.
    employeePresentation.Slides.RemoveAt(0);

    // Κλωνοποιήστε τη διαφάνεια προτύπου στη νέα παρουσίαση.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Πάρτε τις παραγράφους από το στόχο σχήμα (υποθέτει ότι χρησιμοποιείται το σχήμα δείκτη 1).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Αντικαταστήστε τα αντικαταστάτες με δεδομένα από το Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Αποθηκεύστε την εξατομικευμένη παρουσίαση σε ξεχωριστό αρχείο.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Αποτέλεσμα](example1_image2.png)

### **Παράδειγμα Πίνακα Excel**

Στο δεύτερο παράδειγμα, αντιγράφουμε απλώς δεδομένα από έναν πίνακα Excel και τα εμφανίζουμε σε μια διαφάνεια PowerPoint με πιο οπτικά ελκυστική μορφή.

Σε αυτό το παράδειγμα, επαναχρησιμοποιούμε το ίδιο βιβλίο εργασίας Excel από το πρώτο παράδειγμα, το οποίο περιέχει έναν απλό πίνακα υπαλλήλων.

```csharp
// Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα των υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
using Presentation presentation = new Presentation();

// Προσθέστε ένα σχήμα πίνακα στην πρώτη διαφάνεια.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Γεμίστε τον πίνακα PowerPoint με δεδομένα από το βιβλίο εργασίας Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Αποτέλεσμα](example2_image0.png)

### **Παράδειγμα Εισαγωγής Γραφήματος Excel**

Σε αυτό το παράδειγμα, εισάγουμε ένα γράφημα από το πρώτο φύλλο εργασίας του βιβλίου εργασίας Excel που χρησιμοποιήθηκε στο προηγούμενο παράδειγμα. Το γράφημα θα συνδεθεί με το εξωτερικό βιβλίο εργασίας στην τελική παρουσίαση.

Πρώτα, προσθέτουμε ένα γράφημα πίτας στο βιβλίο εργασίας Excel βασισμένο στον πίνακα υπαλλήλων.

![Παράδειγμα γραφήματος Excel](example3_image0.png)

```csharp
// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
using Presentation presentation = new Presentation();

// Λάβετε τη συλλογή σχημάτων της πρώτης διαφάνειας.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Εισαγάγετε το γράφημα με όνομα "Chart 1" από το πρώτο φύλλο του βιβλίου εργασίας και προσθέστε το στη συλλογή σχημάτων.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Αποτέλεσμα](example3_image1.png)

### **Παράδειγμα Εισαγωγής Όλων των Γραφημάτων Excel**

Ας φανταστούμε ότι έχετε ένα βιβλίο εργασίας Excel γεμάτο γραφήματα και χρειάζεται να εισάγετε όλα τα γραφήματα σε μια παρουσίαση. Κάθε γράφημα πρέπει να τοποθετηθεί σε νέα διαφάνεια.

Ο παρακάτω κώδικας διατρέχει όλα τα φύλλα εργασίας στο πηγαίο αρχείο Excel, εξάγει τα γραφήματα από κάθε φύλλο και προσθέτει κάθε γράφημα σε ξεχωριστή διαφάνεια χρησιμοποιώντας κενή διάταξη διαφάνειας. Στην τελική παρουσίαση, θα ενσωματωθούν μόνο τα δεδομένα του γραφήματος, όχι ολόκληρο το βιβλίο εργασίας.

```csharp
// Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα των υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
using Presentation presentation = new Presentation();

// Αποκτήστε τη διάταξη κενής διαφάνειας.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Λάβετε τα ονόματα όλων των φύλλων εργασίας που περιέχονται στο βιβλίο εργασίας Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Αποκτήστε ένα λεξικό που αντιστοιχίζει δείκτες γραφημάτων σε ονόματα γραφημάτων για το φύλλο εργασίας.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Προσθέστε μια νέα διαφάνεια χρησιμοποιώντας τη διάταξη κενής διαφάνειας.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Εισάγετε το καθορισμένο γράφημα από το βιβλίο εργασίας Excel στη συλλογή σχημάτων της διαφάνειας.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Παράδειγμα Εισαγωγής Πίνακα Excel**

Σε αυτό το παράδειγμα, εισάγουμε έναν μορφοποιημένο πίνακα από ένα φύλλο εργασίας Excel απευθείας σε μια παρουσίαση PowerPoint.

Το πηγαίο φύλλο εργασίας Excel περιέχει έναν μορφοποιημένο πίνακα με δεδομένα υπαλλήλων:

![Παράδειγμα πίνακα Excel](example4_image0.png)

```csharp
// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
using Presentation presentation = new Presentation();

// Λάβετε τη συλλογή σχημάτων της πρώτης διαφάνειας.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Εισάγετε τον πίνακα από το πρώτο φύλλο του βιβλίου εργασίας και προσθέστε τον στη συλλογή σχημάτων.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![Αποτέλεσμα](example4_image1.png)

## **Σύνοψη**

Αυτός ο μηχανισμός, διαθέσιμος άμεσα στο Aspose.Slides, συνδυάζει την εργασία με δεδομένα Excel και παρουσιάσεις σε ένα μέρος. Σας επιτρέπει να δημιουργείτε διαφάνειες με οπτικά γραφήματα και δεδομένα που παρουσιάζονται ως πίνακες Excel — χωρίς πρόσθετες βιβλιοθήκες ή πολύπλοκες ενοποιήσεις.