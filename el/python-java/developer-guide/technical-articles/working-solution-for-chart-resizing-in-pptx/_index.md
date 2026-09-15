---
title: Λύση Εργασίας για Αλλαγή Μεγέθους Διαγράμματος σε PPTX
type: docs
weight: 40
url: /el/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- αλλαγή μεγέθους διαγράμματος
- διάγραμμα Excel
- αντικείμενο OLE
- ενσωμάτωση διαγράμματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διορθώστε την απρόσμενη αλλαγή μεγέθους διαγράμματος σε PPTX όταν χρησιμοποιούνται ενσωματωμένα αντικείμενα Excel OLE με το Aspose.Slides για Python via Java. Μάθετε δύο μεθόδους με κώδικα για να διατηρείτε σταθερά τα μεγέθη."
---
## **Ιστορικό**

Έχει παρατηρηθεί ότι τα διαγράμματα του Excel τα οποία ενσωματώνονται ως αντικείμενα OLE σε μια παρουσίαση PowerPoint μέσω των στοιχείων Aspose, αλλάζουν μέγεθος σε ακαθόριστη κλίμακα μετά την πρώτη ενεργοποίησή τους. Αυτή η συμπεριφορά δημιουργεί εμφανή οπτική διαφορά στην παρουσίαση μεταξύ της κατάστασης πριν και μετά την ενεργοποίηση του διαγράμματος. Η ομάδα του Aspose διερεύνησε το πρόβλημα λεπτομερώς και βρήκε μια λύση. Αυτό το άρθρο περιγράφει τις αιτίες του προβλήματος και τη σχετική διόρθωση.

Στο [previous article](/slides/el/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) εξηγήσαμε πώς να δημιουργήσετε ένα διάγραμμα Excel με το Aspose.Cells for Python via Java και να το ενσωματώσετε σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Python via Java. Για την αντιμετώπιση του [object preview issue](/slides/el/python-java/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε την εικόνα του διαγράμματος στο πλαίσιο αντικειμένου OLE του διαγράμματος. Στην έξοδο της παρουσίασης, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του διαγράμματος, ενεργοποιείται το διάγραμμα Excel. Οι τελικοί χρήστες μπορούν να κάνουν τις επιθυμητές αλλαγές στο υποκείμενο βιβλίο εργασίας Excel και, στη συνέχεια, να επιστρέψουν στη σχετική διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας. Το μέγεθος του πλαισίου αντικειμένου OLE αλλάζει όταν ο χρήστης επιστρέφει στη διαφάνεια και ο παράγοντας αλλαγής μεγέθους διαφέρει ανάλογα με τα αρχικά μεγέθη τόσο του πλαισίου αντικειμένου OLE όσο και του ενσωματωμένου βιβλίου εργασίας Excel.

## **Αιτία της Αλλαγής Μεγέθους**

Επειδή το βιβλίο εργασίας Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Το πλαίσιο αντικειμένου OLE, ωστόσο, έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος και διατηρούν τις σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Ανάλογα με τις διαφορές μεταξύ του μεγέθους του παραθύρου Excel και του μεγέθους ή της θέσης του πλαισίου αντικειμένου OLE, πραγματοποιείται αλλαγή μεγέθους.

## **Λειτουργική Λύση**

Υπάρχουν δύο πιθανά σενάρια για τη δημιουργία παρουσιάσεων PowerPoint χρησιμοποιώντας το Aspose.Slides for Python via Java.

**Scenario 1:** Δημιουργία παρουσίασης βάσει υπάρχοντος προτύπου.

**Scenario 2:** Δημιουργία παρουσίασης από το μηδέν.

Η λύση που παρέχουμε εδώ εφαρμόζεται και στα δύο σενάρια. Η βάση όλων των προσεγγίσεων λύσης είναι η ίδια: **το παράθυρο του ενσωματωμένου αντικειμένου OLE πρέπει να ταιριάζει με το πλαίσιο αντικειμένου OLE στη διαφάνεια PowerPoint**. Θα συζητήσουμε τώρα τις δύο προσεγγίσεις για αυτή τη λύση.

## **Πρώτη Προσέγγιση**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να ορίσουμε το μέγεθος του παραθύρου του ενσωματωμένου βιβλίου εργασίας Excel ώστε να ταιριάζει με το μέγεθος του πλαισίου αντικειμένου OLE στη διαφάνεια PowerPoint.

**Scenario 1**

Υποθέτουμε ότι έχουμε ορίσει ένα πρότυπο και θέλουμε να δημιουργήσουμε παρουσιάσεις βάσει αυτού. Υπάρχει ένα σχήμα στο δείκτη 2 του προτύπου όπου θέλουμε να τοποθετήσουμε ένα πλαίσιο OLE που περιέχει ένα ενσωματωμένο βιβλίο εργασίας Excel. Σε αυτό το σενάριο, το μέγεθος του πλαισίου αντικειμένου OLE είναι προκαθορισμένο — ταιριάζει με το μέγεθος του σχήματος στο δείκτη 2 του προτύπου. Ό,τι χρειάζεται να κάνουμε είναι να ορίσουμε το μέγεθος του παραθύρου του βιβλίου εργασίας ίσο με το μέγεθος αυτού του σχήματος. Ο παρακάτω κώδικας εξυπηρετεί αυτόν τον σκοπό:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Φορτώστε το βιβλίο εργασίας Excel που περιέχει το διάγραμμα.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Ορίστε το μέγεθος του παραθύρου του βιβλίου εργασίας σε ίντσες (το PowerPoint χρησιμοποιεί 72 σημεία ανά ίντσα).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Αποθηκεύστε το βιβλίο εργασίας σε ροή μνήμης.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Δημιουργήστε ένα πλαίσιο αντικειμένου OLE με τα ενσωματωμένα δεδομένα Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

Ας υποθέσουμε ότι θέλουμε να δημιουργήσουμε μια παρουσίαση από το μηδέν και να συμπεριλάβουμε ένα πλαίσιο αντικειμένου OLE οποιουδήποτε μεγέθους με ενσωματωμένο βιβλίο εργασίας Excel. Στον παρακάτω κώδικα, δημιουργούμε ένα πλαίσιο αντικειμένου OLE ύψους 4 ίντσες και πλάτους 9,5 ίντσες στο x = 0,5 ίντσες και y = 1 ίντσα στη διαφάνεια. Στη συνέχεια ορίζουμε το παράθυρο του βιβλίου εργασίας Excel στο ίδιο μέγεθος — 4 ίντσες ύψος και 9,5 ίντσες πλάτος.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Φορτώστε το βιβλίο εργασίας Excel που περιέχει το διάγραμμα.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 ίντσες (4 * 72).
    desired_width = 684  # 9,5 ίντσες (9.5 * 72).

    # Ορίστε το μέγεθος του διαγράμματος με παράθυρο.
    chart.setSizeWithWindow(True)

    # Ορίστε το μέγεθος του παραθύρου του βιβλίου εργασίας σε ίντσες (το PowerPoint χρησιμοποιεί 72 σημεία ανά ίντσα).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Αποθηκεύστε το βιβλίο εργασίας σε ροή μνήμης.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Δημιουργήστε ένα πλαίσιο αντικειμένου OLE με τα ενσωματωμένα δεδομένα Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Δεύτερη Προσέγγιση**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να ορίσουμε το μέγεθος του διαγράμματος στο ενσωματωμένο βιβλίο εργασίας Excel ώστε να ταιριάζει με το μέγεθος του πλαισίου αντικειμένου OLE στη διαφάνεια PowerPoint. Αυτή η προσέγγιση είναι χρήσιμη όταν το μέγεθος του διαγράμματος είναι γνωστό εκ των προτέρων και δεν θα αλλάξει.

**Scenario 1**

Υποθέτουμε ότι έχουμε ορίσει ένα πρότυπο και θέλουμε να δημιουργήσουμε παρουσιάσεις βάσει αυτού. Υπάρχει ένα σχήμα στο δείκτη 2 του προτύπου όπου προτιμάμε να τοποθετήσουμε ένα πλαίσιο OLE που περιέχει ένα ενσωματωμένο βιβλίο εργασίας Excel. Σε αυτό το σενάριο, το μέγεθος του πλαισίου OLE είναι προκαθορισμένο — ταιριάζει με το μέγεθος του σχήματος στο δείκτη 2 του προτύπου. Ό,τι χρειάζεται να κάνουμε είναι να ορίσουμε το μέγεθος του διαγράμματος στο βιβλίο εργασίας ώστε να είναι ίσο με το μέγεθος του σχήματος. Ο παρακάτω κώδικας εξυπηρετεί αυτόν τον σκοπό:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Φορτώστε το βιβλίο εργασίας Excel που περιέχει το διάγραμμα.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Ορίστε το μέγεθος του διαγράμματος χωρίς παράθυρο.
    chart.setSizeWithWindow(False)

    # Ορίστε το μέγεθος του διαγράμματος σε εικονοστοιχεία (το Excel χρησιμοποιεί 96 εικονοστοιχεία ανά ίντσα).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Ορίστε το μέγεθος εκτύπωσης του διαγράμματος.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Αποθηκεύστε το βιβλίο εργασίας σε ροή μνήμης.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Δημιουργήστε ένα πλαίσιο αντικειμένου OLE με τα ενσωματωμένα δεδομένα Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**:

Ας υποθέσουμε ότι θέλουμε να δημιουργήσουμε μια παρουσίαση από το μηδέν και να συμπεριλάβουμε ένα πλαίσιο αντικειμένου OLE οποιουδήποτε μεγέθους με ενσωματωμένο βιβλίο εργασίας Excel. Στον παρακάτω κώδικα, δημιουργούμε ένα πλαίσιο αντικειμένου OLE με ύψος 4 ίντσες και πλάτος 9,5 ίντσες στη διαφάνεια στο x = 0,5 ίντσες και y = 1 ίντσα. Ορίζουμε επίσης το αντίστοιχο μέγεθος του διαγράμματος στις ίδιες διαστάσεις: ύψος 4 ίντσες και πλάτος 9,5 ίντσες.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Φορτώστε το βιβλίο εργασίας Excel που περιέχει το διάγραμμα.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 ίντσες (4 * 72).
    desired_width = 684  # 9.5 ίντσες (9.5 * 72).

    # Ορίστε το μέγεθος του διαγράμματος χωρίς παράθυρο.
    chart.setSizeWithWindow(False)

    # Ορίστε το μέγεθος του διαγράμματος σε εικονοστοιχεία (Excel uses 96 pixels per inch).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Αποθηκεύστε το βιβλίο εργασίας σε ροή μνήμης.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Δημιουργήστε ένα πλαίσιο αντικειμένου OLE με τα ενσωματωμένα δεδομένα Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Συμπέρασμα**

Υπάρχουν δύο προσεγγίσεις για την επίλυση του ζητήματος αλλαγής μεγέθους του διαγράμματος. Η επιλογή της προσέγγισης εξαρτάται από τις απαιτήσεις και τη χρήση. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από το μηδέν. Επίσης, δεν υπάρχει όριο στο μέγεθος του πλαισίου αντικειμένου OLE σε αυτή τη λύση.

## **Συχνές Ερωτήσεις**

**Γιατί το ενσωματωμένο διάγραμμα Excel αλλάζει μέγεθος μετά την ενεργοποίησή του στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να αποκαταστήσει το αρχικό μέγεθος του παραθύρου όταν ενεργοποιείται για πρώτη φορά, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει αλλαγή μεγέθους.

**Μπορεί να αποτραπεί εντελώς αυτό το πρόβλημα αλλαγής μεγέθους;**

Ναι. Συμφωνώντας το μέγεθος του παραθύρου του βιβλίου εργασίας Excel ή το μέγεθος του διαγράμματος με το μέγεθος του πλαισίου αντικειμένου OLE πριν από την ενσωμάτωση, μπορείτε να κρατήσετε το μέγεθος του διαγράμματος σταθερό.

**Ποια προσέγγιση πρέπει να επιλέξω, να ορίσω το μέγεθος του παραθύρου του βιβλίου εργασίας ή το μέγεθος του διαγράμματος;**

Χρησιμοποιήστε **Approach 1 (window size)** εάν θέλετε να διατηρήσετε την αναλογία του βιβλίου εργασίας και πιθανώς να επιτρέψετε αλλαγή μεγέθους αργότερα.  
Χρησιμοποιήστε **Approach 2 (chart size)** εάν οι διαστάσεις του διαγράμματος είναι σταθερές και δεν θα αλλάξουν μετά την ενσωμάτωση.

**Θα λειτουργήσουν αυτές οι μέθοδοι και για παρουσιάσεις βάσει προτύπου και για νέες παρουσιάσεις;**

Ναι. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο για παρουσιάσεις που δημιουργούνται από πρότυπα και από το μηδέν.

**Υπάρχει όριο στο μέγεθος του πλαισίου αντικειμένου OLE;**

Όχι. Μπορείτε να ορίσετε το πλαίσιο OLE σε οποιοδήποτε μέγεθος, εφόσον κλιμακώνεται κατάλληλα στο μέγεθος του βιβλίου εργασίας ή του διαγράμματος.

**Μπορώ να χρησιμοποιήσω αυτές τις μεθόδους με διαγράμματα που δημιουργήθηκαν σε άλλα προγράμματα λογιστικού φύλλου;**

Τα παραδείγματα έχουν σχεδιαστεί για διαγράμματα Excel που δημιουργούνται με το Aspose.Cells, αλλά οι αρχές ισχύουν και για άλλα προγράμματα λογιστικών φύλλων συμβατά με OLE, εφόσον υποστηρίζουν παρόμοιες επιλογές μεγέθους.

## **Σχετικές Ενότητες**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/el/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)