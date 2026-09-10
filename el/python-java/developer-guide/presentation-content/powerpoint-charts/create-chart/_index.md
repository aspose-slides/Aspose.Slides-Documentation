---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε Python
linktitle: Δημιουργία ή Ενημέρωση Διαγραμμάτων
type: docs
weight: 10
url: /el/python-java/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διάγραμμα διασποράς
- διάγραμμα πίτας
- γραμμικό διάγραμμα
- διάγραμμα δέντρου
- διάγραμμα χρεοστηριών
- διάγραμμα κουτιού και γρενάδας
- διάγραμμα χωνίου
- διάγραμμα ηλιακής έκρηξης
- διάγραμμα ιστογράμματος
- διάγραμμα ραντάρ
- πολυκατηγορικό διάγραμμα
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργία και προσαρμογή διαγραμμάτων σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Προσθήκη, μορφοποίηση και επεξεργασία διαγραμμάτων με πρακτικά παραδείγματα κώδικα σε Python."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει στις ειδικές απαιτήσεις σχεδίασής σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος μέχρι τη διαμόρφωση σειρών, αξόνων και λεζαντών. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε στιβαρή κατανόηση του πώς να ενσωματώνετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές σας, καθιστώντας τη διαδικασία δημιουργίας παρουσιάσεων βάσει δεδομένων πιο αποδοτική.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να αντλούν πληροφορίες που μπορεί να μην είναι αμέσως εμφανείς από έναν πίνακα ή ένα λογιστικό φύλλο.

**Γιατί να Δημιουργήσετε Διαγράμματα;**

Χρησιμοποιώντας διαγράμματα, μπορείτε:

* να συγκεντρώσετε, συμπτύξετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μία διαφάνεια μιας παρουσίασης
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα
* να καταλάβετε την κατεύθυνση και την ορμή των δεδομένων κατά τη διάρκεια του χρόνου ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης
* να εντοπίσετε ακραίες τιμές, αποκλίσεις, σφάλματα, άσκοπα δεδομένα κ.λπ.
* να επικοινωνήσετε ή να παρουσιάσετε σύνθετα δεδομένα

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της *Insert* λειτουργίας, η οποία παρέχει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βάσει δημοφιλών τύπων) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" title="Σημείωση" %}}
Για τη δημιουργία διαγραμμάτων, χρησιμοποιήστε την κλάση [ChartType](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/). Τα πεδία σε αυτήν την κλάση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.
{{% /alert %}}

### **Δημιουργία Ομαδοποιημένων Στήλων**

Αυτό το τμήμα εξηγεί πώς να δημιουργήσετε ομαδοποιημένα διαγράμματα στήλης χρησιμοποιώντας το Aspose.Slides. Θα μάθετε να αρχικοποιείτε μια παρουσίαση, να προσθέτετε ένα διάγραμμα και να προσαρμόζετε τα στοιχεία του όπως ο τίτλος, τα δεδομένα, οι σειρές, οι κατηγορίες και το στυλ. Ακολουθήστε τα παρακάτω βήματα για να δείτε πώς δημιουργείται ένα τυπικό ομαδοποιημένο διάγραμμα στήλης:

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.ClusteredColumn` .
4. Προσθέστε έναν τίτλο στο διάγραμμα.
5. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
6. Καθαρίστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.
7. Προσθέστε νέες σειρές και κατηγορίες.
8. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
9. Εφαρμόστε χρώμα γεμίσματος στις σειρές του διαγράμματος.
10. Προσθέστε ετικέτες στις σειρές του διαγράμματος.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα ομαδοποιημένο διάγραμμα στήλης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

    # Δημιουργεί μια παρουσία κλάσης που αντιπροσωπεύει αρχείο PPTX.
presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη διαγράμματος με τα προεπιλεγμένα δεδομένα
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Ορίζει τον τίτλο του διαγράμματος
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ορίζει το ευρετήριο για το φύλλο δεδομένων του διαγράμματος
    default_worksheet_index = 0

    # Λαμβάνει το φύλλο εργασίας δεδομένων του διαγράμματος
    workbook = chart.getChartData().getChartDataWorkbook()

    # Διαγράφει τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Προσθήκη νέων σειρών
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Προσθήκη νέων κατηγοριών
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # Παίρνει την πρώτη σειρά του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(0)

    # Τώρα γεμίζει τα δεδομένα της σειράς
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Ορίζει το χρώμα γεμίσματος για τη σειρά
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # Παίρνει τη δεύτερη σειρά του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1)

    # Γεμίζει τα δεδομένα της σειράς
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Ορίζει το χρώμα γεμίσματος για τη σειρά
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Δημιουργία προσαρμοσμένων ετικετών για κάθε κατηγορία της νέας σειράς
    # Ορίζει την πρώτη ετικέτα να εμφανίζει το όνομα της κατηγορίας
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Εμφανίζει την τιμή για την τρίτη ετικέτα
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Αποθηκεύει την παρουσίαση με το διάγραμμα
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Διαγραμμάτων Διασποράς**

Τα διαγράμματα διασποράς (επίσης γνωστά ως scatter plots ή x‑y γραφήματα) χρησιμοποιούνται συχνά για τον έλεγχο μοτίβων ή την απόδειξη συσχετίσεων μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε ένα διάγραμμα διασποράς όταν:

* έχετε ζευγάρια αριθμητικών δεδομένων
* έχετε δύο μεταβλητές που ταιριάζουν καλά μεταξύ τους
* θέλετε να διαπιστώσετε εάν δύο μεταβλητές σχετίζονται
* έχετε μια ανεξάρτητη μεταβλητή που έχει πολλαπλές τιμές για μια εξαρτημένη μεταβλητή

1. Ακολουθήστε τα βήματα στην [Δημιουργία Ομαδοποιημένων Στήλων](#create-clustered-column-charts).
2. Στο τρίτο βήμα, προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο διαγράμματος ως έναν από τους ακόλουθους:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Αντιπροσωπεύει ένα διάγραμμα διασποράς._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Αντιπροσωπεύει ένα διάγραμμα διασποράς συνδεδεμένο με καμπύλες, με δείκτες δεδομένων._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Αντιπροσωπεύει ένα διάγραμμα διασποράς συνδεδεμένο με καμπύλες, χωρίς δείκτες δεδομένων._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Αντιπροσωπεύει ένα διάγραμμα διασποράς συνδεδεμένο με γραμμές, με δείκτες δεδομένων._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Αντιπροσωπεύει ένα διάγραμμα διασποράς συνδεδεμένο με γραμμές, χωρίς δείκτες δεδομένων._

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα διασποράς με διαφορετικούς δείκτες για κάθε σειρά:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# Δημιουργεί μια παρουσία κλάσης που αντιπροσωπεύει αρχείο PPTX.
presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Δημιουργεί το προεπιλεγμένο διάγραμμα
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Λαμβάνει το ευρετήριο του προεπιλεγμένου φύλλου δεδομένων του διαγράμματος
    default_worksheet_index = 0

    # Λαμβάνει το φύλλο εργασίας δεδομένων του διαγράμματος
    workbook = chart.getChartData().getChartDataWorkbook()

    # Διαγράφει τη δοκιμαστική σειρά
    chart.getChartData().getSeries().clear()

    # Προσθέτει νέες σειρές
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Παίρνει την πρώτη σειρά του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(0)

    # Προσθέτει ένα νέο σημείο (1:3) στη σειρά
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Προσθέτει ένα νέο σημείο (2:10)
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Αλλάζει τον τύπο της σειράς
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Αλλάζει το δείκτη της σειράς του διαγράμματος
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # Παίρνει τη δεύτερη σειρά του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1)

    # Προσθέτει ένα νέο σημείο (5:2) εκεί
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Προσθέτει ένα νέο σημείο (3:1)
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Προσθέτει ένα νέο σημείο (2:2)
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Προσθέτει ένα νέο σημείο (5:1)
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Αλλάζει το δείκτη της σειράς του διαγράμματος
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Διαγραμμάτων Πίτας**

Τα διαγράμματα πίτας είναι ιδανικά για την εμφάνιση της σχέσης μέρος‑σε‑ολό σε δεδομένα, ιδιαίτερα όταν τα δεδομένα περιέχουν κατηγορηματικές ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιλαμβάνουν πολλά μέρη ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε αντί αυτού ένα διάγραμμα ράβδων.

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Pie](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#Pie) .
4. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
8. Προσθέστε νέα σημεία για το διάγραμμα και εφαρμόστε προσαρμοσμένα χρώματα στους τομείς του διαγράμματος πίτας.
9. Ορίστε ετικέτες για τις σειρές.
10. Ενεργοποιήστε τις γραμμές οδηγού για τις ετικέτες των σειρών.
11. Ορίστε τη γωνία περιστροφής για τους τομείς του διαγράμματος πίτας.
12. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα πίτας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Δημιουργεί μια παρουσία κλάσης που αντιπροσωπεύει αρχείο PPTX.
presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Ορίζει τον τίτλο του διαγράμματος
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ορίζει το ευρετήριο για το φύλλο δεδομένων του διαγράμματος
    default_worksheet_index = 0

    # Λαμβάνει το φύλλο εργασίας δεδομένων του διαγράμματος
    workbook = chart.getChartData().getChartDataWorkbook()

    # Διαγράφει τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Προσθέτει νέες κατηγορίες
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Προσθέτει νέες σειρές
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Populates τη σειρά δεδομένων
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Προσθήκη νέων σημείων και ορισμός χρώματος τομέα
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Ορίζει το περίγραμμα του τομέα
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Ορίζει το περίγραμμα του τομέα
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Ορίζει το περίγραμμα του τομέα
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Δημιουργεί προσαρμοσμένες ετικέτες για κάθε κατηγορία της νέας σειράς
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Εμφανίζει γραμμές οδηγού για το διάγραμμα
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Ορίζει τη γωνία περιστροφής για τους τομείς του διαγράμματος πίτας
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Αποθηκεύει την παρουσίαση με ένα διάγραμμα
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Γραμμικών Διαγραμμάτων**

Τα γραμμικά διαγράμματα (επίσης γνωστά ως γραφικές παραστάσεις) είναι ιδανικά σε καταστάσεις όπου θέλετε να δείξετε αλλαγές στις τιμές με την πάροδο του χρόνου. Χρησιμοποιώντας ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε μεγάλες ποσότητες δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις με την πάροδο του χρόνου, να επισημάνετε ανωμαλίες σε σειρές δεδομένων και πολλά άλλα.

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Line](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#Line) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα γραμμικό διάγραμμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Από προεπιλογή, τα σημεία σε ένα γραμμικό διάγραμμα ενώνονται με ενόντες ευθείες γραμμές. Εάν θέλετε τα σημεία να ενώνονται με παύλες, μπορείτε να ορίσετε τον προτιμώμενο τύπο παύλας ως εξής:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Διαγραμμάτων Δέντρου (Tree Map)**

Τα διαγράμματα δέντρου είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να εστιάσετε γρήγορα σε στοιχεία που συνεισφέρουν σημαντικά μέσα σε κάθε κατηγορία.

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Treemap](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#Treemap) .
4. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα δέντρου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #κλάδος 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #κλάδος 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Διαγραμμάτων Χρόνου (Stock)**

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
8. Ορίστε τη μορφή των γραμμών υψηλού‑χαμηλού.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα χρόνου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Διαγραμμάτων Box και Whisker**

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα Box και Whisker:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Διαγραμμάτων Funnel**

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Funnel](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#Funnel) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα Funnel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Διαγραμμάτων Sunburst**

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Sunburst](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#Sunburst) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα Sunburst:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #κλάδος 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #κλάδος 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Ιστογραμμάτων (Histogram)**

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.Histogram](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#Histogram) .
4. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα ιστογράμμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Διαγραμμάτων Radar**

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον προτιμώμενο τύπο διαγράμματος ([ChartType.Radar](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#Radar) σε αυτήν την περίπτωση).
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα Radar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Πολυ‑Κατηγορικών Διαγραμμάτων**

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο [ChartType.ClusteredColumn](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#ClusteredColumn) .
4. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/) .
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα πολυ‑κατηγορικό διάγραμμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # Προσθήκη Σειράς
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Save presentation with chart
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Διαγραμμάτων Χαρτών**

Τα διαγράμματα χάρτες οπτικοποιούν γεωγραφικά δεδομένα και βοηθούν στη σύγκριση τιμών μεταξύ περιοχών.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα διάγραμμα χάρτη:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα μόνο γράφημα. Αυτό το διάγραμμα σας επιτρέπει να τονίσετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![Το συνδυαστικό διάγραμμα](combination_chart.png)

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε το παραπάνω συνδυαστικό διάγραμμα σε μια παρουσίαση PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Ορίζεται ο τίτλος του διαγράμματος.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Ορίζεται η λεζάντα του διαγράμματος.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Διαγράφονται οι προεπιλεγμένες παραγόμενες σειρές και κατηγορίες.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Προσθήκη νέων κατηγοριών.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Προσθήκη της πρώτης σειράς.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Ορίζεται ο οριζόντιος άξονας.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Ορίζεται ο κάθετος άξονας.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Ορίζεται το χρώμα των κύριων γραμμών πλέγματος του κάθετου άξονα.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Ορίζεται ο δευτερεύων οριζόντιος άξονας.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Ορίζεται ο δευτερεύων κάθετος άξονας.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Ενημέρωση Διαγραμμάτων**

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα που θέλετε να ενημερώσετε.
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Πλοηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
5. Τροποποιήστε τις σειρές δεδομένων του διαγράμματος αλλάζοντας τις τιμές των σειρών.
6. Προσθέστε μια νέα σειρά και γεμίστε τα δεδομένα της.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Ανοίγει την παρουσίαση που περιέχει το διάγραμμα για ενημέρωση
presentation = Presentation("ExistingChart.pptx")
try:
    # Πρόσβαση στην πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Λήψη του διαγράμματος από τη διαφάνεια
    chart = slide.getShapes().get_Item(0)

    # Ορισμός του ευρετηρίου του φύλλου δεδομένων του διαγράμματος
    default_worksheet_index = 0

    # Λήψη του φύλλου εργασίας δεδομένων του διαγράμματος
    workbook = chart.getChartData().getChartDataWorkbook()

    # Αλλαγή του ονόματος κατηγορίας του διαγράμματος
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # Λήψη της πρώτης σειράς του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(0)

    # Ενημέρωση των δεδομένων της σειράς
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Τροποποίηση ονόματος σειράς
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # Λήψη της δεύτερης σειράς του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(1)

    # Ενημέρωση των δεδομένων της σειράς
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Τροποποίηση ονόματος σειράς
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Προσθήκη μιας νέας σειράς
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Λήψη της τρίτης σειράς του διαγράμματος
    series = chart.getChartData().getSeries().get_Item(2)

    # Συμπλήρωση των δεδομένων της σειράς
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Αποθήκευση της παρουσίασης με το διάγραμμα
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Περιοχής Δεδομένων για Διάγραμμα**

Για να ορίσετε την περιοχή δεδομένων για ένα διάγραμμα, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
2. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Πλοηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στα δεδομένα του διαγράμματος και ορίστε την περιοχή.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε την περιοχή δεδομένων για ένα διάγραμμα:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Ανοίγει την παρουσίαση που περιέχει το διάγραμμα
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Χρήση Προεπιλεγμένων Δεικτών σε Διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό σύμβολο δείκτη.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε αυτόματα δείκτη σειράς διαγράμματος:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    # Πάρε τη δεύτερη σειρά του διαγράμματος
    second_series = chart.getChartData().getSeries().get_Item(1)

    # Τώρα συμπλήρωση δεδομένων σειράς
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides;**

Το Aspose.Slides υποστηρίζει ένα ευρύ φάσμα [chart types](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/), συμπεριλαμβανομένων των διαγραμμάτων μπάρας, γραμμής, πίτας, περιοχής, διασποράς, ιστογραμμάτων, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς μπορώ να προσθέσω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, πρώτα δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) , ανακτήστε τη ζητούμενη διαφάνεια χρησιμοποιώντας το ευρετήριο της και, στη συνέχεια, καλέστε τη μέθοδο προσθήκης διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράµατος αποκτώντας πρόσβαση στο βιβλίο δεδομένων του ([ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες και, στη συνέχεια, προσθέτοντας τα δεδομένα σας. Αυτό σας επιτρέπει να ανανεώσετε το διάγραμμα ώστε να αντανακλά τα πιο πρόσφατα δεδομένα.

**Είναι δυνατόν η προσαρμογή της εμφάνισης του διαγράμματος;**

Ναι, το Aspose.Slides παρέχει εκτεταμένες επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, λεζάντες και άλλα [formatting elements](/slides/el/python-java/chart-entities/) ώστε να προσαρμόσετε την εμφάνιση του διαγράμματος σύμφωνα με τις συγκεκριμένες απαιτήσεις σχεδίασής σας.