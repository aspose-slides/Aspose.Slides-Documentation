---
title: Διαχείριση έργων VBA σε παρουσιάσεις με Python
linktitle: Παρουσίαση μέσω VBA
type: docs
weight: 250
url: /el/python-java/presentation-via-vba/
keywords:
- μακροεντολή
- VBA
- μακροεντολή VBA
- προσθήκη μακροεντολής
- αφαίρεση μακροεντολής
- εξαγωγή μακροεντολής
- προσθήκη VBA
- αφαίρεση VBA
- εξαγωγή VBA
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να επεξεργάζεστε παρουσιάσεις PowerPoint και OpenDocument μέσω VBA με το Aspose.Slides για Python μέσω Java, ώστε να απλοποιήσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Aspose.Slides παρέχει κλάσεις και διεπαφές για εργασία με μακροεντολές και κώδικα VBA.

{{% alert title="Warning" color="warning" %}} 

Όταν μετατρέπετε μια παρουσίαση που περιέχει μακροεντολές σε διαφορετική μορφή αρχείου (PDF, HTML κ.λπ.), το Aspose.Slides αγνοεί όλες τις μακροεντολές (οι μακροεντολές δεν μεταφέρονται στο προκύπτον αρχείο).

Όταν προσθέτετε μακροεντολές σε μια παρουσίαση ή αποθηκεύετε ξανά μια παρουσίαση που περιέχει μακροεντολές, το Aspose.Slides απλώς γράφει τα byte των μακροεντολών.

Το Aspose.Slides **ποτέ** δεν εκτελεί τις μακροεντολές σε μια παρουσίαση.

{{% /alert %}}

## **Προσθήκη μακροεντολών VBA**

Το Aspose.Slides παρέχει την κλάση [VbaProject](https://reference.aspose.com/slides/el/python-java/aspose.slides/vbaproject/) για να δημιουργείτε έργα VBA (και αναφορές έργου) και να επεξεργάζεστε υπάρχοντες μονάδες. Μπορείτε να χρησιμοποιήσετε την κλάση [VbaProject](https://reference.aspose.com/slides/el/python-java/aspose.slides/vbaproject/) για να διαχειριστείτε VBA ενσωματωμένο σε μια παρουσίαση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Χρησιμοποιήστε τον κατασκευαστή [VbaProject](https://reference.aspose.com/slides/el/python-java/aspose.slides/vbaproject/#vbaproject) για να προσθέσετε ένα νέο έργο VBA.
1. Προσθέστε μια μονάδα στο έργο VBA.
1. Ορίστε τον πηγαίο κώδικα της μονάδας.
1. Προσθέστε αναφορές στο `stdole`.
1. Προσθέστε αναφορές στη **Microsoft Office**.
1. Συνδέστε τις αναφορές με το έργο VBA.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε μια μακροεντολή VBA από την αρχή σε μια παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Δημιουργία νέου έργου VBA.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Προσθήκη κενής μονάδας και ορισμός του πηγαίου κώδικα.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Δημιουργία αναφορών σε stdole και Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Προσθήκη αναφορών στο έργο VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Αποθήκευση της παρουσίασης.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Μπορεί να θέλετε να δείτε το **Aspose** [Macro Remover](https://products.aspose.app/slides/el/remove-macros), το οποίο είναι μια δωρεάν διαδικτυακή εφαρμογή για την αφαίρεση μακροεντολών από έγγραφα PowerPoint, Excel και Word.

{{% /alert %}} 

## **Αφαίρεση μακροεντολών VBA**

Χρησιμοποιώντας τη μέθοδο [getVbaProject](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getvbaproject) της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), μπορείτε να αφαιρέσετε μια μακροεντολή VBA.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
1. Αποκτήστε πρόσβαση στη μονάδα της μακροεντολής και αφαιρέστε την.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python δείχνει πώς να αφαιρέσετε μια μακροεντολή VBA:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Φόρτωση της παρουσίασης που περιέχει τη μακροεντολή.
presentation = Presentation("VBA.pptm")
try:
    # Πρόσβαση στη μονάδα VBA και αφαίρεσή της.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Αποθήκευση της παρουσίασης.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Εξαγωγή μακροεντολών VBA**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει Έργο VBA.
3. Κάντε επανάληψη σε όλες τις μονάδες που περιέχονται στο Έργο VBA για να προβάλετε τις μακροεντολές.

Αυτός ο κώδικας Python δείχνει πώς να εξαγάγετε μακροεντολές VBA από μια παρουσίαση που περιέχει μακροεντολές:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Φόρτωση της παρουσίασης που περιέχει τη μακροεντολή.
presentation = Presentation("VBA.pptm")
try:
    # Έλεγχος εάν η παρουσίαση περιέχει έργο VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Έλεγχος εάν ένα Έργο VBA είναι προστατευμένο με κωδικό πρόσβασης**

Χρησιμοποιώντας τη μέθοδο [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/el/python-java/aspose.slides/vbaproject/#ispasswordprotected), μπορείτε να προσδιορίσετε εάν οι ιδιότητες ενός έργου είναι προστατευμένες με κωδικό πρόσβασης.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε μια παρουσίαση που περιέχει μακροεντολή.
2. Ελέγξτε εάν η παρουσίαση περιέχει ένα [VBA project](https://reference.aspose.com/slides/el/python-java/aspose.slides/vbaproject/).
3. Ελέγξτε εάν το Έργο VBA είναι προστατευμένο με κωδικό πρόσβασης για να προβάλετε τις ιδιότητές του.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Έλεγχος εάν η παρουσίαση περιέχει έργο VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Τι συμβαίνει με τις μακροεντολές αν αποθηκεύσω την παρουσίαση ως PPTX;**

Οι μακροεντολές θα αφαιρεθούν επειδή το PPTX δεν υποστηρίζει VBA. Για να διατηρήσετε τις μακροεντολές, επιλέξτε PPTM, PPSM ή POTM.

**Μπορεί το Aspose.Slides να εκτελεί μακροεντολές μέσα σε μια παρουσίαση, για παράδειγμα, για να ενημερώσει δεδομένα;**

Όχι. Η βιβλιοθήκη δεν εκτελεί ποτέ κώδικα VBA· η εκτέλεση είναι δυνατή μόνο μέσα στο PowerPoint με τις κατάλληλες ρυθμίσεις ασφαλείας.

**Υπάρχει υποστήριξη για τη χρήση ελεγκτών ActiveX συνδεδεμένων με κώδικα VBA;**

Ναι, μπορείτε να έχετε πρόσβαση σε υπάρχοντες [ActiveX controls](/slides/el/python-java/activex/), να τροποποιήσετε τις ιδιότητές τους και να τους αφαιρέσετε. Αυτό είναι χρήσιμο όταν οι μακροεντολές αλληλεπιδρούν με ActiveX.