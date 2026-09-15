---
title: Ενσωμάτωση Δεδομένων Excel σε Παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/python-java/excel-integration/
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
- Python
- Java
- Aspose.Slides
description: "Ανάγνωση δεδομένων από βιβλία εργασίας Excel στο Aspose.Slides για Python μέσω Java χρησιμοποιώντας το API ExcelDataWorkbook. Φόρτωση φύλλων και κελιών και χρήση των τιμών για τη δημιουργία παρουσιάσεων PowerPoint που βασίζονται σε δεδομένα."
---
## **Εισαγωγή**

Οι παρουσιάσεις PowerPoint είναι ένας ισχυρός τρόπος παρουσίασης και μετάδοσης πληροφοριών. Συχνά χρησιμοποιούνται σε συνδυασμό με βιβλία εργασίας Excel, όπου το Excel λειτουργεί ως εξαιρετική πηγή δομημένων δεδομένων και το PowerPoint διαπρέπει στο να οπτικοποιεί αυτά τα δεδομένα για το κοινό.

Υπάρχουν πολλαπλές πρακτικές περιπτώσεις όπου ο συνδυασμός Excel και PowerPoint είναι σημαντικός: συγχωνεύσεις αλληλογραφίας, συμπλήρωση πινάκων δεδομένων, δημιουργία μιας διαφάνειας ανά εγγραφή δεδομένων (μαζική δημιουργία διαφανειών), δημιουργία εκπαιδευτικού υλικού και ενοποίηση πολλαπλών αναφορών Excel σε μία παρουσίαση, μεταξύ άλλων.

Μέχρι τώρα, η υλοποίηση τέτοιων λειτουργιών με το API του Aspose.Slides απαιτούσε την εξάρτηση από τρίτες λύσεις όπως το Aspose.Cells. Παρόλο που αυτά τα εργαλεία είναι ισχυρά, μπορούν να είναι υπερβολικά πολύπλοκα και ακριβά για χρήστες που χρειάζονται μόνο βασική λειτουργικότητα ενσωμάτωσης δεδομένων.

## **Πώς Λειτουργεί**

Για να γίνει η εργασία με δεδομένα Excel πιο εύκολη και απλοποιημένη, το Aspose.Slides εισήγαγε νέες κλάσεις για ανάγνωση δεδομένων από βιβλία εργασίας Excel και εισαγωγή περιεχομένου σε μια παρουσίαση. Αυτή η δυνατότητα ανοίγει ισχυρές νέες δυνατότητες για χρήστες του API που θέλουν να αξιοποιήσουν το Excel ως πηγή δεδομένων στις ροές εργασίας των παρουσιάσεων τους.

Η νέα λειτουργικότητα έχει σχεδιαστεί για γενική πρόσβαση σε δεδομένα και δεν είναι ενσωματωμένη στο Presentation Document Object Model (DOM). Αυτό σημαίνει *ότι δεν επιτρέπει την επεξεργασία ή αποθήκευση αρχείων Excel* — ο μοναδικός της σκοπός είναι το άνοιγμα βιβλίων εργασίας και η πλοήγηση στο περιεχόμενό τους για την ανάκτηση δεδομένων κελιών.

Στο πυρήνα αυτής της δυνατότητας βρίσκεται η νέα κλάση [ExcelDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/exceldataworkbook/). Αυτή η κλάση επιτρέπει τη φόρτωση ενός βιβλίου εργασίας Excel από τοπικό αρχείο ή ροή. Μόλις φορτωθεί, παρέχει πολλές υπερφορτώσεις της μεθόδου [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/exceldataworkbook/#getCell), που μπορείτε να χρησιμοποιήσετε για την ανάκτηση συγκεκριμένων κελιών βάσει της θέσης τους (π.χ., δείκτες γραμμής και στήλης ή ονομαστικές περιοχές).

Κάθε κλήση στη [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/exceldataworkbook/#getCell) επιστρέφει ένα αντικείμενο [ExcelDataCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/exceldatacell/). Αυτό το αντικείμενο αντιπροσωπεύει ένα μοναδικό κελί στο βιβλίο εργασίας Excel και προσφέρει πρόσβαση στην τιμή του με απλό και διαισθητικό τρόπο.

#### **Εισαγωγή Διαγράμματος Excel**

Το επόμενο βήμα για την επέκταση της λειτουργικότητας είναι η κλάση [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/python-java/aspose.slides/excelworkbookimporter/). Αυτή η βοηθητική κλάση παρέχει δυνατότητα εισαγωγής περιεχομένου από ένα βιβλίο εργασίας Excel σε μια παρουσίαση. Περιέχει πολλές υπερφορτώσεις της μεθόδου [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), που σας βοηθούν να ανακτήσετε το επιλεγμένο διάγραμμα από το καθορισμένο βιβλίο εργασίας Excel και να το προσθέσετε στο τέλος της δεδομένης συλλογής σχημάτων στις καθορισμένες συντεταγμένες.

#### **Εισαγωγή Πίνακα Excel**

Η κλάση [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/python-java/aspose.slides/excelworkbookimporter/) περιέχει επίσης πολλές υπερφορτώσεις της μεθόδου [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Αυτές οι μέθοδοι σας επιτρέπουν να εισάγετε μια καθορισμένη περιοχή κελιών από ένα καθορισμένο φύλλο εργασίας και να την προσθέσετε ως πίνακα στο τέλος της δεδομένης συλλογής σχημάτων στις καθορισμένες συντεταγμένες.

Συνοψίζοντας, είναι ένα ελαφρύ και απλό API για ανάγνωση δεδομένων Excel — ακριβώς αυτό που χρειάζονται πολλοί προγραμματιστές χωρίς το βάρος μιας πλήρους βιβλιοθήκης επεξεργασίας λογιστικών φύλλων.

## **Ας Γράψουμε Κώδικα**

### **Παράδειγμα Σεναρίου Συγχώνευσης Ταχυδρομείου**

Στο παρακάτω παράδειγμα, θα υλοποιήσουμε ένα απλό σενάριο συγχώνευσης ταχυδρομείου δημιουργώντας πολλαπλές παρουσιάσεις βάσει δεδομένων που αποθηκεύονται σε ένα βιβλίο εργασίας Excel.

Για να ξεκινήσουμε, χρειαζόμαστε δύο πράγματα:

1. Ένα βιβλίο εργασίας Excel που περιέχει τα δεδομένα

![Excel data example](example1_image0.png)

2. Ένα πρότυπο παρουσίασης PowerPoint

![PowerPoint template example](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Φορτώστε το βιβλίο εργασίας Excel με δεδομένα υπαλλήλων.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Φορτώστε το πρότυπο παρουσίασης.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Επανάληψη στις γραμμές του Excel (εξαιρώντας την κεφαλίδα στη γραμμή 0).
    for row_index in range(1, 5):

        # Δημιουργήστε μια παρουσίαση για κάθε εγγραφή υπαλλήλου.
        employee_presentation = Presentation()

        try:
            # Αφαιρέστε τη προεπιλεγμένη κενή διαφάνεια.
            employee_presentation.getSlides().removeAt(0)

            # Κλωνοποιήστε τη διαφάνεια προτύπου στην παρουσίαση.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Λάβετε τις παραγράφους από το επιλεγμένο σχήμα (προϋποθέτει ότι χρησιμοποιείται το σχήμα με δείκτη 1).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Αντικαταστήστε τα σύμβολα κράτησης θέσης με δεδομένα από το Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Αποθηκεύστε την εξατομικευμένη παρουσίαση σε ξεχωριστό αρχείο.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Αποτέλεσμα](example1_image2.png)

### **Παράδειγμα Πίνακα Excel**

Στο δεύτερο παράδειγμα, απλώς αντιγράφουμε δεδομένα από έναν πίνακα Excel και τα εμφανίζουμε σε μια διαφάνεια PowerPoint με πιο ελκυστική οπτική μορφή.

Σε αυτό το παράδειγμα, επαναχρησιμοποιούμε το ίδιο βιβλίο εργασίας Excel από το πρώτο παράδειγμα, το οποίο περιέχει έναν απλό πίνακα υπαλλήλων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα υπαλλήλων.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Δημιουργήστε μια παρουσίαση PowerPoint.
presentation = Presentation()

try:
    # Προσθέστε ένα σχήμα πίνακα στην πρώτη διαφάνεια.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Συμπληρώστε τον πίνακα PowerPoint με δεδομένα από το βιβλίο εργασίας Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Αποτέλεσμα](example2_image0.png)

### **Παράδειγμα Εισαγωγής Διαγράμματος Excel**

Σε αυτό το παράδειγμα, εισάγουμε ένα διάγραμμα από το πρώτο φύλλο εργασίας του βιβλίου εργασίας Excel που χρησιμοποιήθηκε στο προηγούμενο παράδειγμα. Το διάγραμμα θα συνδεθεί με το εξωτερικό βιβλίο εργασίας στην τελική παρουσίαση.

Πρώτα, προσθέτουμε ένα κυκλικό διάγραμμα (pie chart) στο βιβλίο εργασίας Excel βάσει του πίνακα υπαλλήλων.

![Παράδειγμα Διαγράμματος Excel](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Δημιουργήστε μια παρουσίαση PowerPoint.
presentation = Presentation()
try:
    # Λάβετε τη συλλογή σχημάτων της πρώτης διαφάνειας.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Εισάγετε το διάγραμμα με όνομα "Chart 1" από το πρώτο φύλλο του βιβλίου εργασίας και προσθέστε το στη συλλογή σχημάτων.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Αποτέλεσμα](example3_image1.png)

### **Παράδειγμα Εισαγωγής Όλων των Διαγραμμάτων Excel**

Ας υποθέσουμε ότι έχετε ένα βιβλίο εργασίας Excel γεμάτο διαγράμματα και πρέπει να τα εισάγετε όλα σε μια παρουσίαση. Κάθε διάγραμμα πρέπει να τοποθετηθεί σε μια νέα διαφάνεια.

Ο παρακάτω κώδικας διατρέπει σε όλα τα φύλλα εργασίας του πηγαίου αρχείου Excel, εξάγει τα διαγράμματα από κάθε φύλλο και προσθέτει κάθε διάγραμμα σε ξεχωριστή διαφάνεια χρησιμοποιώντας μια κενή διάταξη διαφάνειας. Στην τελική παρουσίαση, θα ενσωματωθούν μόνο τα δεδομένα του διαγράμματος, όχι ολόκληρο το βιβλίο εργασίας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα των υπαλλήλων.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Δημιουργήστε μια παρουσίαση PowerPoint.
presentation = Presentation()
try:
    # Ανάκτηση της διάταξης κενής διαφάνειας.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Αφαιρέστε την προεπιλεγμένη διαφάνεια ώστε το αποτέλεσμα να περιέχει μία διαφάνεια ανά διάγραμμα.
    presentation.getSlides().removeAt(0)

    # Λάβετε τα ονόματα όλων των φύλλων εργασίας που περιέχονται στο βιβλίο εργασίας Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Ανακτήστε έναν χάρτη που συσχετίζει δείκτες διαγραμμάτων με ονόματα διαγραμμάτων για το φύλλο εργασίας.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Προσθέστε μια διαφάνεια χρησιμοποιώντας τη διάταξη κενής διαφάνειας.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Εισάγετε το καθορισμένο διάγραμμα από το βιβλίο εργασίας Excel στη συλλογή σχημάτων της διαφάνειας.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Παράδειγμα Εισαγωγής Πίνακα Excel**

Σε αυτό το παράδειγμα, εισάγουμε έναν μορφοποιημένο πίνακα από ένα φύλλο εργασίας Excel απευθείας σε μια παρουσίαση PowerPoint.

Το πηγαίο φύλλο εργασίας Excel περιέχει έναν μορφοποιημένο πίνακα με δεδομένα υπαλλήλων:

![Παράδειγμα Πίνακα Excel](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Δημιουργήστε μια παρουσίαση PowerPoint.
presentation = Presentation()
try:
    # Λάβετε την πρώτη διαφάνεια και τη συλλογή σχημάτων της.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Εισάγετε τον πίνακα από το πρώτο φύλλο του βιβλίου εργασίας και προσθέστε τον στη συλλογή σχημάτων.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Αποτέλεσμα](example4_image1.png)

## **Σύνοψη**

Αυτός ο μηχανισμός, διαθέσιμος άμεσα στο Aspose.Slides, συνδυάζει την εργασία με δεδομένα Excel και παρουσιάσεις σε ένα μέρος. Σας επιτρέπει να δημιουργείτε διαφάνειες με οπτικά διαγράμματα και δεδομένα που παρουσιάζονται ως πίνακες Excel — χωρίς πρόσθετες βιβλιοθήκες ή πολύπλοκες ενσωματώσεις.