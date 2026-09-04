---
title: "Αυτοματοποίηση της δημιουργίας PowerPoint σε Python: Δημιουργία δυναμικών παρουσιάσεων εύκολα"
linktitle: "Αυτοματοποίηση δημιουργίας PowerPoint"
type: docs
weight: 20
url: /el/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- πλατφόρμες σύννεφου
- ενσωμάτωση σύννεφου
- αυτοματοποίηση δημιουργίας PowerPoint
- δημιουργία παρουσιάσεων προγραμματιστικά
- αυτοματοποίηση PowerPoint
- δυναμική δημιουργία διαφανειών
- αυτοματοποιημένες επιχειρηματικές αναφορές
- αυτοματοποίηση PPT
- παρουσίαση Python
- Python
- Aspose.Slides
description: "Αυτοματοποίηση της δημιουργίας PowerPoint με Aspose.Slides για Python μέσω Java: δημιουργία επιχειρηματικής παρουσίασης με διαγράμματα, πίνακες και κουκκίδες σε εφαρμογές cloud."
---
## **Εισαγωγή**

Η δημιουργία παρουσιάσεων χειροκίνητα γίνεται επαναλαμβανόμενη όταν το περιεχόμενό τους αλλάζει συχνά. Οι εβδομαδιαίες αναφορές, τα εκπαιδευτικά υλικά και οι παρουσιάσεις πελατών συχνά μοιράζονται μια κοινή δομή, αλλά απαιτούν νέα δεδομένα για κάθε παράδοση.

Το Aspose.Slides for Python via Java σας επιτρέπει να δημιουργείτε αυτές τις παρουσιάσεις από εφαρμογές Python. Μπορείτε να ενσωματώσετε τη δημιουργία διαφανειών σε διαδικτυακές πύλες, προγραμματισμένες εργασίες και cloud workers, χρησιμοποιώντας δεδομένα από βάσεις δεδομένων, API ή ανεβασμένα αρχεία.

## **Κοινές περιπτώσεις χρήσης για αυτοματοποίηση PowerPoint σε Python**

- **Επιχειρηματικές αναφορές και πίνακες ελέγχου:** μετατρέψτε τα στοιχεία πωλήσεων και τις μετρικές απόδοσης σε διαγράμματα και πίνακες.
- **Προσαρμοσμένες παρουσιάσεις πωλήσεων:** γεμίστε τις διαφάνειες με δεδομένα ειδικά για κάθε πελάτη διατηρώντας ένα συνεπές σχέδιο.
- **Εκπαιδευτικό περιεχόμενο:** συναρμολογήστε μαθήματα, κουίζ και συνοψίσεις μαθημάτων από δομημένο υλικό.
- **Δεδομένα και insights βασισμένα σε AI:** χρησιμοποιήστε τα αποτελέσματα από αναλύσεις ή υπηρεσίες επεξεργασίας φυσικής γλώσσας ως περιεχόμενο παρουσίασης.
- **Διαφάνειες με μέσα:** συνδυάστε ανεβασμένες εικόνες ή στιγμιότυπα οθόνης με εξηγητικό κείμενο.
- **Ροές εργασίας εγγράφων:** χαρτογραφήστε το περιεχόμενο που εξάγεται από άλλα εργαλεία σε διατάξεις παρουσιάσεων.
- **Εργαλεία προγραμματιστών:** δημιουργήστε συνοπτικές εκδόσεων, τεχνικές επισκοπήσεις ή επιδείξεις από δεδομένα του έργου.

## **Προαπαιτούμενα**

Ακολουθήστε την [Εγκατάσταση](/slides/el/python-java/installation/) για να ρυθμίσετε το Python, το Java, το JPype και το Aspose.Slides. Για την ανάπτυξη στο cloud, επίσης εξετάστε τις [Διαφάνειες σε Πλατφόρμες Cloud](/slides/el/python-java/slides-on-cloud-platforms/).

Το παράδειγμα χρησιμοποιεί σταθερά επιχειρησιακά δεδομένα ώστε να μπορεί να εκτελεστεί χωρίς βάση δεδομένων ή εξωτερική υπηρεσία. Αντικαταστήστε αυτές τις τιμές με δεδομένα από την εφαρμογή σας όταν το ενσωματώνετε σε μια ροή εργασίας αναφοράς.

{{% alert color="info" title="Note" %}}
Μπορείτε να δοκιμάσετε το παράδειγμα χωρίς άδεια, αλλά το αποτέλεσμα της αξιολόγησης περιλαμβάνει υδατογράφημα και υπόκειται σε περιορισμούς αξιολόγησης. Δείτε την [Αξιολόγηση Aspose.Slides](/slides/el/python-java/evaluate-aspose-slides/) για λεπτομέρειες και πληροφορίες προσωρινής άδειας.
{{% /alert %}}

## **Δημιουργία της Παρουσίασης**

Το πλήρες σενάριο παρακάτω δημιουργεί μια παρουσίαση που περιέχει τέσσερις διαφάνειες. Κάθε βήμα χρησιμοποιεί την ίδια παρουσίαση και το τελευταίο βήμα την αποθηκεύει ως `presentation.pptx`.

### **Δημιουργία Διαφάνειας Τίτλου**

Χρησιμοποιήστε την αρχική διαφάνεια σε ένα νέο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και εφαρμόστε τη διάταξη τίτλου. Συμπληρώστε τα placeholders τίτλου και υποτίτλου με την επικεφαλίδα της αναφοράς και το κοινό.

![Η διαφάνεια τίτλου](slide_0.png)

### **Προσθήκη Διαφάνειας με Στήλη Γράφημα**

Προσθέστε μια κενή διαφάνεια και δημιουργήστε ένα γράφημα με [ShapeCollection.addChart](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addChart). Συμπληρώστε το ενσωματωμένο workbook με πέντε περιοχές και μία σειρά πωλήσεων. Οι τιμές παραμένουν επεξεργάσιμες στο PowerPoint.

![Η διαφάνεια με το γράφημα](slide_1.png)

### **Προσθήκη Διαφάνειας με Πίνακα**

Δημιουργήστε έναν πίνακα με [ShapeCollection.addTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addTable) και γεμίστε δύο στήλες με ονόματα μετρικών και τιμές. Το παράδειγμα περνάει ρητές σειρές Java τύπου double για το πλάτος των στηλών και το ύψος των γραμμών μέσω JPype.

![Η διαφάνεια με τον πίνακα](slide_2.png)

### **Προσθήκη Συνοπτικής Διαφάνειας με Κουκκίδες**

Δημιουργήστε ένα σχήμα κειμένου και προσθέστε ένα [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/) για κάθε στοιχείο δράσης. Εφαρμόστε μια κουκκίδα σύμβολο και μαύρο κείμενο σε κάθε παράγραφο, και αφαιρέστε το γέμισμα και το περίγραμμα του σχήματος.

![Η διαφάνεια με τη σύνοψη](slide_3.png)

### **Αποθήκευση της Παρουσίασης**

Χρησιμοποιήστε το [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) για να γράψετε το αρχείο PowerPoint. Αποδεσμεύστε την παρουσίαση με το [Presentation.dispose](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#dispose) σε ένα μπλοκ `finally`.

### **Πλήρες Παράδειγμα Python**

Αποθηκεύστε αυτό το σενάριο σε έναν φάκελο με δυνατότητα εγγραφής και εκτελέστε το με το περιβάλλον Python που έχει διαμορφωθεί παραπάνω. Ξεκινά το JVM μόνο εάν είναι απαραίτητο και το διατηρεί διαθέσιμο μέχρι το τέλος της διεργασίας. Για χρήση σε notebook και υπηρεσίες, δείτε τις [Οδηγίες κύκλου ζωής JVM](/slides/el/python-java/limitations-and-api-differences/#import-the-library).

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # Δημιουργία της διαφάνειας τίτλου.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # Προσθήκη διαφάνειας με γράφημα.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Προσθήκη διαφάνειας με πίνακα.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # Προσθήκη συνοπτικής διαφάνειας.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
Οι εικονογραφήσεις δείχνουν τις αντίστοιχες διαφάνειες από το παράδειγμα Java. Η εμφάνιση μπορεί να διαφέρει ανάλογα με τις εγκατεστημένες γραμματοσειρές και τη λειτουργία αξιολόγησης.

## **Χρήση του Παραδείγματος σε Εφαρμογή Cloud**

Ασφαλίστε τα δεδομένα της αναφοράς πριν δημιουργήσετε την παρουσίαση, έπειτα περάστε τα στα βήματα του γραφήματος, του πίνακα και της παραγωγής κειμένου. Χρησιμοποιήστε διαφορετική διαδρομή εξόδου για κάθε εργασία. Μετά την αποθήκευση, η εφαρμογή σας μπορεί να ανεβάσει το αρχείο σε αποθήκευση αντικειμένων ή να το επιστρέψει ως λήψη.

Διατηρήστε το JVM ενεργό μεταξύ των εργασιών στο ίδιο worker process και απελευθερώστε κάθε παρουσίαση όταν ολοκληρωθεί η εργασία της. Συμπεριλάβετε τις γραμματοσειρές που απαιτούνται από το σχέδιο της αναφοράς μαζί με την ανάπτυξη για να μειώσετε τις διαφορές μεταξύ των περιβαλλόντων.

## **Συμπέρασμα**

Αυτό το παράδειγμα δημιουργεί μια πλήρη επιχειρηματική παρουσίαση από Python, χρησιμοποιώντας επεξεργάσιμα γραφήματα, πίνακες και κείμενο. Αντικαθιστώντας τα δείγμα δεδομένων με δεδομένα εφαρμογής, η ίδια προσέγγιση γίνεται χρήσιμη για επαναλαμβανόμενες αναφορές, παρουσιάσεις πελατών και εκπαιδευτικό υλικό.

## **FAQ**

**Η εντολή απαιτεί το Microsoft PowerPoint ή το Excel;**

Όχι. Το Aspose.Slides δημιουργεί τις διαφάνειες και το ενσωματωμένο workbook του γραφήματος χωρίς καμία από τις εφαρμογές.

**Γιατί το παράδειγμα του πίνακα χρησιμοποιεί πίνακες Java;**

Η υποκείμενη μέθοδος δέχεται πίνακες Java τύπου double. Οι ρητοί πίνακες κάνουν σαφείς τους αριθμητικούς τύπους που περνούν μέσω JPype.

**Μπορώ να αποθηκεύσω την ίδια παρουσίαση ως PDF ή ODP;**

Ναι. Πριν το απελευθερώσετε, αποθηκεύστε σε άλλο όνομα αρχείου εξόδου με την αντίστοιχη τιμή του [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/). Δείτε τις [Υποστηριζόμενες Μορφές Αρχείων](/slides/el/python-java/supported-file-formats/) για δυνατότητες ανά μορφή.

**Μπορώ να χρησιμοποιήσω προσαρμοσμένο πρότυπο;**

Ναι. Φορτώστε το πρότυπό σας αντί να δημιουργήσετε μια κενή παρουσίαση, έπειτα προσαρμόστε τη διάταξη και την επιλογή placeholders στο πρότυπο. Το δείγμα υποθέτει τις διατάξεις και τη σειρά των placeholders μιας νέας προεπιλεγμένης παρουσίασης.