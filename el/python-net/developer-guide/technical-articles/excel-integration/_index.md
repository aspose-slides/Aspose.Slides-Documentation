---
title: Ενσωμάτωση Δεδομένων Excel σε Παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/python-net/excel-integration/
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
- Aspose.Slides
description: "Ανάγνωση δεδομένων από βιβλία εργασίας Excel στο Aspose.Slides χρησιμοποιώντας το API ExcelDataWorkbook. Φόρτωση φύλλων και κελιών και χρήση των τιμών για δημιουργία παρουσιάσεων PowerPoint βασισμένων σε δεδομένα."
---
## **Εισαγωγή**

Οι παρουσιάσεις PowerPoint είναι ένας ισχυρός τρόπος για την προβολή και τη μετάδοση πληροφοριών. Συχνά χρησιμοποιούνται σε συνδυασμό με βιβλία εργασίας Excel, όπου το Excel λειτουργεί ως εξαιρετική πηγή δομημένων δεδομένων και το PowerPoint διαπρέπει στην οπτικοποίηση αυτών των δεδομένων για το κοινό.

Υπάρχουν πολλές πρακτικές περιπτώσεις όπου ο συνδυασμός Excel και PowerPoint είναι απαραίτητος: συγχωνεύσεις αλληλογραφίας, γέμιση πινάκων δεδομένων, δημιουργία μιας διαφάνειας ανά εγγραφή δεδομένων (ομαδική δημιουργία διαφανειών), δημιουργία εκπαιδευτικού υλικού και ενοποίηση πολλαπλών αναφορών Excel σε μία παρουσίαση, για παράδειγμα.

Μέχρι τώρα, η υλοποίηση τέτοιων λειτουργιών με το Aspose.Slides API απαιτούσε την εξάρτηση από λύσεις τρίτων, όπως το Aspose.Cells. Παρόλο που αυτά τα εργαλεία είναι ισχυρά, μπορούν να είναι υπερβολικά σύνθετα και δαπανηροί για χρήστες που χρειάζονται μόνο βασική λειτουργικότητα ενσωμάτωσης δεδομένων.

## **Πώς Λειτουργεί**

Για να καταστεί η εργασία με δεδομένα Excel πιο εύκολη και πιο απλή, το Aspose.Slides εισήγαγε νέες κλάσεις για ανάγνωση δεδομένων από βιβλία εργασίας Excel και εισαγωγή περιεχομένου σε μια παρουσίαση. Αυτή η δυνατότητα ανοίγει ισχυρές νέες προοπτικές για χρήστες του API που θέλουν να αξιοποιήσουν το Excel ως πηγή δεδομένων μέσα στις ροές εργασίας των παρουσιάσεών τους.

Η νέα λειτουργικότητα έχει σχεδιαστεί για γενική πρόσβαση σε δεδομένα και δεν είναι ενσωματωμένη στο Presentation Document Object Model (DOM). Αυτό σημαίνει *ότι δεν επιτρέπει την επεξεργασία ή αποθήκευση αρχείων Excel* — ο μοναδικός σκοπός της είναι το άνοιγμα βιβλίων εργασίας και η περιήγηση στο περιεχόμενό τους για την ανάκτηση δεδομένων κελιών.

Στον πυρήνα αυτής της δυνατότητας βρίσκεται η νέα κλάση [ExcelDataWorkbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.excel/exceldataworkbook/) . Αυτή η κλάση σάς επιτρέπει να φορτώσετε ένα βιβλίο εργασίας Excel από τοπικό αρχείο ή ρεύμα. Μόλις φορτωθεί, παρέχει πολλές υπερφορτώσεις της μεθόδου [get_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) , τις οποίες μπορείτε να χρησιμοποιήσετε για να ανακτήσετε συγκεκριμένα κελιά με βάση τη θέση τους (π.χ. δείκτες γραμμής και στήλης ή ονομαστικές περιοχές).

Κάθε κλήση στη [get_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) επιστρέφει μια παρουσία της κλάσης [ExcelDataCell](https://reference.aspose.com/slides/el/python-net/aspose.slides.excel/exceldatacell/) . Αυτό το αντικείμενο αντιπροσωπεύει ένα μεμονωμένο κελί στο βιβλίο εργασίας Excel και σας δίνει πρόσβαση στην τιμή του με έναν απλό και διαισθητικό τρόπο.

#### **Εισαγωγή Διαγράμματος Excel**

Το επόμενο βήμα για την επέκταση της λειτουργικότητας είναι η κλάση [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/python-net/aspose.slides.importing/excelworkbookimporter/) . Αυτή η βοηθητική κλάση παρέχει λειτουργίες για την εισαγωγή περιεχομένου από ένα βιβλίο εργασίας Excel σε μια παρουσίαση. Περιλαμβάνει πολλές υπερφορτώσεις της μεθόδου [add_chart_from_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/) , οι οποίες σας βοηθούν να ανακτήσετε το επιλεγμένο διάγραμμα από το καθορισμένο βιβλίο εργασίας Excel και να το προσθέσετε στο τέλος της δεδομένης συλλογής σχημάτων στις καθορισμένες συντεταγμένες.

Συνοπτικά, είναι ένα ελαφρύ και άμεσο API για ανάγνωση δεδομένων Excel — ακριβώς αυτό που πολλοί προγραμματιστές χρειάζονται χωρίς το βάρος μιας πλήρους βιβλιοθήκης επεξεργασίας φύλλων υπολογιστών.

## **Ας Κωδικοποιήσουμε**

### **Παράδειγμα Σεναρίου Συγχώνευσης Αλληλογραφίας**

Στο παρακάτω παράδειγμα, θα υλοποιήσουμε ένα απλό σενάριο Συγχώνευσης Αλληλογραφίας δημιουργώντας πολλαπλές παρουσιάσεις βάσει δεδομένων που αποθηκεύονται σε ένα βιβλίο εργασίας Excel.

Για να ξεκινήσουμε, χρειάζονται δύο πράγματα:
1. Ένα βιβλίο εργασίας Excel που περιέχει τα δεδομένα

![Παράδειγμα δεδομένων Excel](example1_image0.png)

2. Πρότυπο παρουσίασης PowerPoint

![Παράδειγμα προτύπου PowerPoint](example1_image1.png)

```py
import aspose.slides as slides

# Φόρτωση του βιβλίου εργασίας Excel με δεδομένα υπαλλήλων.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Φόρτωση του προτύπου παρουσίασης.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Επανάληψη σε γραμμές Excel (εξαιρείται η κεφαλίδα στη γραμμή 0).
    for row_index in range(1, 5):

        # Δημιουργία νέας παρουσίασης για κάθε εγγραφή υπαλλήλου.
        with slides.Presentation() as employee_presentation:

            # Αφαίρεση της προεπιλεγμένης κενής διαφάνειας.
            employee_presentation.slides.remove_at(0)

            # Κλωνοποίηση της διαφάνειας προτύπου στη νέα παρουσίαση.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Λήψη παραγράφων από το στόχο σχήμα (υποθέτει ότι χρησιμοποιείται ο δείκτης σχήματος 1).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Αντικατάσταση των θέσεων κράτησης με δεδομένα από το Excel.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Αποθήκευση της εξατομικευμένης παρουσίασης σε ξεχωριστό αρχείο.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Αποτέλεσμα](example1_image2.png)

### **Παράδειγμα Πίνακα Excel**

Στο δεύτερο παράδειγμα, αντιγράφουμε απλώς δεδομένα από έναν πίνακα Excel και τα εμφανίζουμε σε μια διαφάνεια PowerPoint με πιο ελκυστική οπτική μορφή.

Σε αυτό το παράδειγμα, επαναχρησιμοποιούμε το ίδιο βιβλίο εργασίας Excel από το πρώτο παράδειγμα, το οποίο περιέχει έναν απλό πίνακα υπαλλήλων.

```py
# Φόρτωση του βιβλίου εργασίας Excel που περιέχει τα δεδομένα υπαλλήλου.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Δημιουργία νέας παρουσίασης PowerPoint.
with slides.Presentation() as presentation:

    # Προσθήκη σχήματος πίνακα στην πρώτη διαφάνεια.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Συμπλήρωση του πίνακα PowerPoint με δεδομένα από το βιβλίο εργασίας Excel.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Αποθήκευση της δημιουργηθείσας παρουσίασης σε αρχείο.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Αποτέλεσμα](example2_image0.png)

### **Παράδειγμα Εισαγωγής Διαγράμματος Excel**

Σε αυτό το παράδειγμα, εισάγουμε ένα διάγραμμα από το πρώτο φύλλο εργασίας του βιβλίου εργασίας Excel που χρησιμοποιήθηκε στο προηγούμενο παράδειγμα. Το διάγραμμα θα συνδεθεί με το εξωτερικό βιβλίο εργασίας στην τελική παρουσίαση.

Πρώτα, προσθέτουμε ένα γράφημα τύπου Πίτας στο βιβλίο εργασίας Excel βάσει του πίνακα υπαλλήλων.

![Παράδειγμα διαγράμματος Excel](example3_image0.png)

```py
# Δημιουργία νέας παρουσίασης PowerPoint.
with slides.Presentation() as presentation:
    # Λήψη της συλλογής σχημάτων της πρώτης διαφάνειας.
    shapes = presentation.slides[0].shapes

    # Εισαγωγή του διαγράμματος με όνομα "Chart 1" από το πρώτο φύλλο του βιβλίου εργασίας και προσθήκη του στη συλλογή σχημάτων.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Αποθήκευση της προκύπτουσας παρουσίασης σε αρχείο.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Αποτέλεσμα](example3_image1.png)

### **Παράδειγμα Εισαγωγής Όλων των Διαγραμμάτων Excel**

Ας φανταστούμε ότι έχετε ένα βιβλίο εργασίας Excel γεμάτο διαγράμματα και χρειάζεται να τα εισάγετε όλα σε μια παρουσίαση. Κάθε διάγραμμα πρέπει να τοποθετηθεί σε νέα διαφάνεια.

Ο παρακάτω κώδικας διατρέχει όλα τα φύλλα εργασίας στο πηγαίο αρχείο Excel, εξάγει τα διαγράμματα από κάθε φύλλο και προσθέτει κάθε διάγραμμα σε ξεχωριστή διαφάνεια χρησιμοποιώντας διάταξη κενής διαφάνειας. Στην τελική παρουσίαση, θα είναι ενσωματωμένα μόνο τα δεδομένα του διαγράμματος, όχι ολόκληρο το βιβλίο εργασίας.

```py
# Φόρτωση του βιβλίου εργασίας Excel που περιέχει τα δεδομένα υπαλλήλου.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Δημιουργία νέας παρουσίασης PowerPoint.
with slides.Presentation() as presentation:
    # Ανάκτηση της διάταξης κενής διαφάνειας.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Λήψη των ονομάτων όλων των φύλλων εργασίας που περιέχονται στο βιβλίο εργασίας Excel.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Ανάκτηση λεξικού που αντιστοιχίζει δείκτες διαγραμμάτων σε ονόματα διαγραμμάτων για το φύλλο εργασίας.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Προσθήκη νέας διαφάνειας χρησιμοποιώντας τη διάταξη κενής.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Εισαγωγή του καθορισμένου διαγράμματος από το βιβλίο εργασίας Excel στη συλλογή σχημάτων της διαφάνειας.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Αποθήκευση της προκύπτουσας παρουσίασης σε αρχείο.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Σύνοψη**

Αυτός ο μηχανισμός, διαθέσιμος απευθείας στο Aspose.Slides, συνδυάζει την εργασία με δεδομένα Excel και παρουσιάσεις σε ένα μέρος. Σας επιτρέπει να δημιουργείτε διαφάνειες με οπτικά διαγράμματα και δεδομένα που παρουσιάζονται ως πίνακες Excel — χωρίς πρόσθετες βιβλιοθήκες ή περίπλοκες ενσωματώσεις.