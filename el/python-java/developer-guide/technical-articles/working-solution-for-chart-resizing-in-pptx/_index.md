---
title: Λύση Επιδιορθωμένη για την Αλλαγή Μεγέθους Διαγράμματος σε PPTX
type: docs
weight: 40
url: /el/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- αλλαγή μεγέθους διαγράμματος
- διάγραμμα Excel
- αντικείμενο OLE
- ενσωμάτωση διαγράμματος
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διορθώστε την απροσδόκητη αλλαγή μεγέθους διαγράμματος σε PPTX όταν χρησιμοποιείτε ενσωματωμένα αντικείμενα Excel OLE με το Aspose.Slides για Python μέσω Java. Ορίστε σταθερές διαστάσεις διαγράμματος ώστε να διατηρούνται συνεπείς οι διαστάσεις του διαγράμματος και του πλαισίου OLE."
---
## **Ιστορικό**

Τα διαγράμματα Excel που ενσωματώνονται ως αντικείμενα OLE σε παρουσιάσεις PowerPoint χρησιμοποιώντας συστατικά Aspose μπορούν να αλλάξουν μέγεθος μετά την πρώτη ενεργοποίησή τους. Αυτό μπορεί να προκαλέσει εμφανή διαφορά στην εμφάνιση του διαγράμματος πριν και μετά την ενεργοποίηση. Αυτό το άρθρο εξηγεί γιατί συμβαίνει η αλλαγή μεγέθους και δείχνει πώς να την αποτρέψετε ταιριάζοντας τις σταθερές διαστάσεις του διαγράμματος με το πλαίσιο OLE.

Στο [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/el/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), εξηγήσαμε πώς να δημιουργήσετε ένα διάγραμμα Excel με το Aspose.Cells for Python via Java και να το ενσωματώσετε σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Python via Java. Για να αντιμετωπίσουμε το [object preview issue](/slides/el/python-java/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε την εικόνα του διαγράμματος στο πλαίσιο OLE του διαγράμματος. Στην παραγόμενη παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο OLE που εμφανίζει την εικόνα του διαγράμματος, το διάγραμμα Excel ενεργοποιείται. Οι χρήστες μπορούν να επεξεργαστούν το ενσωματωμένο βιβλίο εργασίας Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας. Το μέγεθος του πλαισίου OLE αλλάζει όταν ο χρήστης επιστρέφει στη διαφάνεια, και ο παράγοντας αλλαγής μεγέθους διαφέρει ανάλογα με τα αρχικά μεγέθη τόσο του πλαισίου OLE όσο και του ενσωματωμένου βιβλίου εργασίας Excel.

## **Αιτία Αλλαγής Μεγέθους**

Το ενσωματωμένο βιβλίο εργασίας Excel διαθέτει τις δικές του διαστάσεις παραθύρου, τις οποίες το Excel προσπαθεί να διατηρήσει όταν το αντικείμενο ενεργοποιείται για πρώτη φορά. Το πλαίσιο OLE στη διαφάνεια έχει ανεξάρτητα ορισμένες διαστάσεις. Όταν το βιβλίο εργασίας Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος του αντικειμένου ώστε να διατηρηθούν οι αναλογίες του ως μέρος της διαδικασίας ενσωμάτωσης. Οι διαφορές μεταξύ του παραθύρου του βιβλίου εργασίας και του πλαισίου OLE μπορούν επομένως να προκαλέσουν αλλαγή μεγέθους του αντικειμένου.

## **Λειτουργική Λύση**

Ταιριάξτε το μέγεθος του διαγράμματος με το πλαίσιο OLE στη διαφάνεια και διατηρήστε τις διαστάσεις του διαγράμματος ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Αυτή η λύση λειτουργεί με μια νέα παρουσίαση ή με ένα υπάρχον πρότυπο.

Το παράδειγμα απαιτεί Aspose.Cells for Python via Java και Aspose.Slides for Python via Java. Δημιουργεί ένα απλό κυματικό διάγραμμα σε ενεργό φύλλο διαγράμματος και ενσωματώνει το βιβλίο εργασίας σε μορφή XLS. Δεν έχει οριστεί εικόνα προεπισκόπησης διαγράμματος· το διάγραμμα γίνεται ορατό όταν το αντικείμενο OLE ενεργοποιείται στο PowerPoint.

Το παράδειγμα δημιουργεί μια νέα παρουσίαση με πλαίσιο OLE μεγέθους 9,5 × 4 ίντσες, τοποθετημένο 0,5 ίντσες από το αριστερό άκρο και 1 ίντσα από το πάνω. Οι συντεταγμένες και οι διαστάσεις της διαφάνειας είναι σε points (72 points ανά ίντσα). Για υπάρχουσα παρουσίαση, δείτε [Χρήση Προτύπου](#use-a-template).

## **Ορισμός Σταθερού Μεγέθους Διαγράμματος**

Ορίστε το [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) σε false ώστε οι διαστάσεις του διαγράμματος να είναι ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Ορίστε τις διαστάσεις του [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) μέσω των [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) και [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), μετατρέποντας τα points σε pixels χρησιμοποιώντας 96 pixels ανά ίντσα: ένα πλαίσιο μεγέθους 684 × 288 points αντιστοιχεί σε διάγραμμα μεγέθους 912 × 384 pixels. Ορίστε το [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) στην τιμή CUSTOM του [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). Το παράδειγμα ενσωματώνει το βιβλίο εργασίας με το [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) και αποθηκεύει μια παρουσίαση με πλαίσιο OLE 9,5 × 4 ίντσες.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Οι συντεταγμένες και οι διαστάσεις της διαφάνειας είναι σε points (72 points ανά ίντσα).
        width = 684.0  # 9.5 ίντσες.
        height = 288.0  # 4 ίντσες.

        chart.setSizeWithWindow(False)
        # Μετατρέψτε τα points σε εικονοστοιχεία διαγράμματος χρησιμοποιώντας 96 εικονοστοιχεία ανά ίντσα.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Χρήση Προτύπου**

Η λογική μεγέθους είναι η ίδια για μια υπάρχουσα παρουσίαση. Για να προσαρμόσετε το παράδειγμα:

1. Φορτώστε την παρουσίαση προτύπου αντί να δημιουργήσετε μια κενή παρουσίαση.
1. Ελέγξτε ότι η πρώτη διαφάνεια περιέχει τουλάχιστον τρία σχήματα, και στη συνέχεια χρησιμοποιήστε το σχήμα στη θέση 2 ως placeholder.
1. Πάρτε το πλάτος και το ύψος του πλαισίου από αυτό το σχήμα αντί να χρησιμοποιήσετε τις σταθερές τιμές 684 και 288. Διατηρήστε τους υπολογισμούς διαστάσεων αμετάβλητους.
1. Προσθέστε το πλαίσιο OLE στην θέση του placeholder αντί για τις σταθερές συντεταγμένες 36 και 72.
1. Αφαιρέστε το placeholder πριν αποθηκεύσετε την παρουσίαση.

## **FAQ**

**Γιατί το ενσωματωμένο διάγραμμα Excel αλλάζει μέγεθος μετά την ενεργοποίησή του στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να επαναφέρει το αρχικό μέγεθος του παραθύρου όταν ενεργοποιείται για πρώτη φορά, ενώ το πλαίσιο OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος ώστε να διατηρηθεί η αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει αλλαγή μεγέθους.

**Πώς μπορώ να διατηρήσω σταθερές τις διαστάσεις του διαγράμματος και του πλαισίου OLE;**

Ορίστε σταθερές διαστάσεις διαγράμματος που ταιριάζουν με το πλαίσιο OLE και χρησιμοποιήστε προσαρμοσμένο μέγεθος εκτύπωσης διαγράμματος πριν ενσωματώσετε το βιβλίο εργασίας. Το παραπάνω παράδειγμα δείχνει τις απαιτούμενες ρυθμίσεις και μετατροπές μονάδων.

**Είναι αρκετή η αντιστοίχιση του μεγέθους του παραθύρου του βιβλίου εργασίας;**

Η μόνο αντιστοίχιση του μεγέθους του παραθύρου του βιβλίου εργασίας δεν αποτρέπει αξιόπιστα την αλλαγή μεγέθους του πλαισίου OLE μετά την ενεργοποίηση. Χρησιμοποιήστε σταθερές διαστάσεις διαγράμματος όπως φαίνεται στο παράδειγμα.

**Λειτουργεί αυτή η λύση τόσο με παρουσιάσεις βάσει προτύπου όσο και με νέες παρουσιάσεις;**

Ναι. Για πρότυπο, χρησιμοποιήστε τις διαστάσεις και τη θέση του placeholder. Για νέα παρουσίαση, καθορίστε απευθείας τις διαστάσεις και τη θέση του πλαισίου.

**Μπορώ να χρησιμοποιήσω αυτό το παράδειγμα με διαγράμματα που δημιουργήθηκαν σε άλλα προγράμματα λογιστικών φύλλων;**

Το παράδειγμα χρησιμοποιεί βιβλίο εργασίας Excel που δημιουργήθηκε με το Aspose.Cells. Δεν δείχνει τη συμπεριφορά ενεργοποίησης για άλλα προγράμματα λογιστικών φύλλων.

## **Σχετικές Ενότητες**

- [Δημιουργία Διαγραμμάτων Excel και Ενσωμάτωση τους ως Αντικείμενα OLE σε Παρουσιάσεις](/slides/el/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)