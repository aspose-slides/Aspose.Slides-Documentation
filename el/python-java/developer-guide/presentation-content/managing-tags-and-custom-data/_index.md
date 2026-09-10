---
title: Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις Χρησιμοποιώντας Python
linktitle: Ετικέτες και Προσαρμοσμένα Δεδομένα
type: docs
weight: 300
url: /el/python-java/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσαρμοσμένο XML
- προσαρμοσμένο τμήμα XML
- μεταδεδομένα XML
- ItemId
- προσθήκη ετικέτας
- ζεύγος τιμών
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε ετικέτες και προσαρμοσμένα δεδομένα XML σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω Java, περιλαμβάνοντας τη προσθήκη, την ανάγνωση, την ενημέρωση, τον έλεγχο και την αφαίρεση προσαρμοσμένων τμημάτων XML."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Τα δεδομένα που αφορούν συγκεκριμένα την παρουσίαση μπορούν να αποθηκευτούν ως ετικέτες ή προσαρμοσμένα τμήματα XML. Οι ετικέτες είναι απλά ζεύγη κλειδιού‑τιμής τύπου συμβολοσειράς, ενώ τα προσαρμοσμένα τμήματα XML μπορούν να αποθηκεύουν δομημένα μεταδεδομένα και φορτία XML ειδικά για την εφαρμογή.

Το Aspose.Slides παρέχει API για προσθήκη, ανάγνωση, ενημέρωση, έλεγχο και αφαίρεση προσαρμοσμένων τμημάτων XML σε επίπεδο παρουσίασης, διαφάνειας και σχήματος. Τα προσαρμοσμένα τμήματα XML είναι χρήσιμα για ενσωματώσεις που αποθηκεύουν πληροφορίες όπως ταυτοποιητές διαχείρισης εγγράφων, κατάσταση ροής εργασίας, μεταδεδομένα συμμόρφωσης, δεδομένα σύνδεσης προτύπου ή άλλα δομημένα δεδομένα εφαρμογής μέσα σε μια παρουσίαση.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσιάσεων**

Τα αρχεία PPTX — αρχεία με την επέκταση `.pptx` — αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος της προδιαγραφής Office Open XML. Το Office Open XML ορίζει τη δομή του πακέτου και τις σχέσεις που χρησιμοποιείται για την αποθήκευση του περιεχομένου της παρουσίασης και των σχετικών δεδομένων.

Μια παρουσίαση περιέχει πολλαπλά τμήματα συνδεδεμένα μέσω σχέσεων. Για παράδειγμα, ένα τμήμα διαφάνειας περιέχει το περιεχόμενο μιας μόνο διαφάνειας και μπορεί να έχει ρητές σχέσεις με άλλα τμήματα όπως ορίζεται από το ISO/IEC 29500.

Τα προσαρμοσμένα δεδομένα μπορούν να αποθηκευτούν ως ετικέτες ([TagCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/tagcollection/)) ή προσαρμοσμένα τμήματα XML ([CustomXmlPartCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpartcollection/)). Και οι δύο είναι διαθέσιμες μέσω της κλάσης [CustomData](https://reference.aspose.com/slides/el/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Σημείωση" %}}
Οι ετικέτες αποθηκεύουν απλούς ζεύγους κλειδιού‑τιμής τύπου συμβολοσειράς. Τα προσαρμοσμένα τμήματα XML αποθηκεύουν δομημένα δεδομένα XML και μπορούν να συσχετιστούν με μια παρουσίαση, διαφάνεια ή σχήμα.
{{% /alert %}}

## **Εργασία με Προσαρμοσμένα Τμήματα XML**

Η μέθοδος [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/customdata/#getCustomXmlParts) επιστρέφει τη συλλογή των προσαρμοσμένων τμημάτων XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης. Για παράδειγμα:

- Η συλλογή [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/customdata/#getCustomXmlParts) της παρουσίασης περιέχει προσαρμοσμένα τμήματα XML που σχετίζονται με την ίδια την παρουσίαση.
- Η συλλογή [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/customdata/#getCustomXmlParts) της διαφάνειας περιέχει προσαρμοσμένα τμήματα XML που σχετίζονται με τη συγκεκριμένη διαφάνεια.
- Η συλλογή [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/customdata/#getCustomXmlParts) του σχήματος περιέχει προσαρμοσμένα τμήματα XML που σχετίζονται με το συγκεκριμένο σχήμα.

Χρησιμοποιήστε το [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAllCustomXmlParts) όταν χρειάζεται να εξετάσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση, ανεξάρτητα από το που είναι συνδεδεμένα.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Παρουσίαση**

Χρησιμοποιήστε το [CustomXmlPartCollection.add](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpartcollection/#add) για να προσθέσετε δεδομένα XML σε μια συλλογή προσαρμοσμένων τμημάτων XML. Το XML πρέπει να είναι έγκυρο και μη κενό.

Το παρακάτω παράδειγμα προσθέτει δομημένα μεταδεδομένα στη συλλογή προσαρμοσμένων δεδομένων επιπέδου παρουσίασης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add εκχωρεί αναγνωριστικό αυτόματα. Ορίστε συγκεκριμένο UUID μόνο όταν απαιτείται.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η μέθοδος [add](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpartcollection/#add) μπορεί επίσης να δέχεται XML ως πίνακα byte ή ροή εισόδου, κάτι χρήσιμο όταν το περιεχόμενο XML είναι ήδη διαθέσιμο σε δυαδική μορφή.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Διαφάνεια ή Σχήμα**

Τα προσαρμοσμένα δεδομένα XML μπορούν να συσχετιστούν με μια συγκεκριμένη διαφάνεια ή σχήμα αντί για ολόκληρη την παρουσίαση. Αυτό είναι χρήσιμο όταν τα μεταδεδομένα περιγράφουν μόνο ένα αντικείμενο, όπως κλειδί προτύπου, εξωτερικό αναγνωριστικό εγγραφής ή πληροφορίες σύνδεσης.

Το παρακάτω παράδειγμα προσθέτει ένα προσαρμοσμένο τμήμα XML σε μια διαφάνεια και ένα άλλο σε ένα σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το επίπεδο στο οποίο προστίθεται ένα τμήμα καθορίζει σε ποια συλλογή [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/customdata/#getCustomXmlParts) περιλαμβάνεται η σχέση. Τα δεδομένα επιπέδου παρουσίασης είναι κατάλληλα για μεταδεδομένα όλου του εγγράφου, τα δεδομένα επιπέδου διαφάνειας για πληροφορίες που ανήκουν σε συγκεκριμένη διαφάνεια, και τα δεδομένα επιπέδου σχήματος για μεταδεδομένα που συνδέονται με ένα μεμονωμένο σχήμα.

### **Απαρίθμηση και Έλεγχος Όλων των Προσαρμοσμένων Τμημάτων XML**

Χρησιμοποιήστε το [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAllCustomXmlParts) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML από μια παρουσίαση. Κάθε [CustomXmlPart](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/) εκθέτει τον αναγνωριστικό του, το περιεχόμενο XML και τα συσχετισμένα σχήματα ονομάτων χώρου.

Το παρακάτω παράδειγμα απαριθμεί όλα τα προσαρμοσμένα τμήματα XML και τα σχήματα ονομάτων τους:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

Η μέθοδος [CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) επιστρέφει τα σχήματα XML που σχετίζονται με το προσαρμοσμένο τμήμα XML. Αυτές οι πληροφορίες μπορούν να είναι χρήσιμες όταν γίνεται έλεγχος παρουσιάσεων που περιέχουν XML που παρήχθησαν από εξωτερικά συστήματα.

### **Ανάγνωση και Ενημέρωση Περιεχομένου XML και ItemId**

Χρησιμοποιήστε τα [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#getXmlAsString) και [setXmlAsString](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlAsString) για εργασία με το XML ως συμβολοσειρά UTF‑8, ή τα [getXmlData](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#getXmlData) και [setXmlData](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlData) για εργασία με τα ακατέργαστα byte του XML.

Η μέθοδος [CustomXmlPart.getItemId](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#getItemId) επιστρέφει το UUID που αναγνωρίζει το προσαρμοσμένο τμήμα XML στο έγγραφο Office Open XML. Χρησιμοποιήστε το [setItemId](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setItemId) όταν μια ενσωμάτωση απαιτεί νέο αναγνωριστικό.

Το παρακάτω παράδειγμα ενημερώνει το περιεχόμενο XML και τον αναγνωριστικό:

```python
import jpure
import asposeslides

if not jpure.isJVMStarted():
    jpure.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Διαβάζουμε το τρέχον XML ως κείμενο.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Ενημερώνουμε το XML ως συμβολοσειρά UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # Το getXmlData παρέχει το ίδιο περιεχόμενο XML ως ακατέργαστα byte.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Αντικαταστήστε τον αναγνωριστικό όταν απαιτείται από την ενσωμάτωση.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Κατά την κλήση του [setXmlAsString](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlAsString) ή του [setXmlData](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlData), δώστε έγκυρο, μη κενό XML. Χρησιμοποιήστε τη μία ή την άλλη αναπαράσταση ανάλογα με το αν η εφαρμογή εργάζεται κυρίως με συμβολοσειρές ή με byte δεδομένα.

### **Αφαίρεση Προσαρμοσμένου Τμήματος XML**

Το Aspose.Slides παρέχει αρκετούς τρόπους αφαίρεσης προσαρμοσμένων δεδομένων XML:

- Το [CustomXmlPart.remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#remove) αφαιρεί το προσαρμοσμένο τμήμα XML από την παρουσίαση.
- Το [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpartcollection/#remove) αφαιρεί ένα συγκεκριμένο τμήμα από μια συλλογή προσαρμοσμένων τμημάτων XML.
- Το [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpartcollection/#removeAt) αφαιρεί το τμήμα από ένα καθορισμένο δείκτη συλλογής.
- Το [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpartcollection/#clear) αφαιρεί όλα τα τμήματα από μια συγκεκριμένη συλλογή.

Το παρακάτω παράδειγμα αφαιρεί ένα προσαρμοσμένο τμήμα XML επιπέδου παρουσίασης με αναφορά:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αν έχετε ήδη ένα [CustomXmlPart](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/) και θέλετε να αφαιρέσετε αυτό το τμήμα από την παρουσίαση αντί να στοχεύσετε μια συγκεκριμένη συλλογή, καλέστε το [CustomXmlPart.remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#remove).

Μπορείτε επίσης να αφαιρέσετε ένα στοιχείο με δείκτη:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Καθαρισμός Όλων των Προσαρμοσμένων Τμημάτων XML από Συλλογή**

Χρησιμοποιήστε το [clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpartcollection/#clear) όταν όλα τα προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης πρέπει να αφαιρεθούν.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το [clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpartcollection/#clear) επηρεάζει μόνο τη επιλεγμένη συλλογή. Για παράδειγμα, ο καθαρισμός της συλλογής μιας διαφάνειας δεν καθαρίζει τις συλλογές επιπέδου παρουσίασης ή σχήματος.

Για να αφαιρέσετε κάθε προσαρμοσμένο τμήμα XML στην παρουσίαση, διατρέξτε τα [getAllCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAllCustomXmlParts) και αφαιρέστε κάθε τμήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Διαχείριση Συνδεδεμένων ή Κοινοπραχτικών Προσαρμοσμένων Τμημάτων XML**

Σε μια παρουσίαση Office Open XML, το ίδιο προσαρμοσμένο τμήμα XML μπορεί να αναφέρεται από περισσότερα από ένα αντικείμενα παρουσίασης. Για παράδειγμα, ένα υπάρχον αρχείο μπορεί να περιέχει σχέσεις από πολλαπλές διαφάνειες ή σχήματα προς το ίδιο υποκείμενο προσαρμοσμένο τμήμα XML.

Ένα κοινότμημα πρέπει να αντιμετωπίζεται ως ένα αντικείμενο δεδομένων με πολλαπλές αναφορές:

- Η ενημέρωσή του με [setXmlAsString](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlData) ή [setItemId](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setItemId) αλλάζει το υποκείμενο προσαρμοσμένο τμήμα XML, οπότε η αλλαγή ισχύει όπου και να αναφέρεται το τμήμα.
- Το [getItemId](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#getItemId) μπορεί να χρησιμοποιηθεί για την ταυτοποίηση του ίδιου τμήματος XML κατά τον έλεγχο συλλογών επιπέδου αντικειμένου.
- Η αφαίρεση ενός τμήματος από μια συγκεκριμένη συλλογή [getCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/customdata/#getCustomXmlParts) το αφαιρεί από εκείνη τη συλλογή. Χρησιμοποιήστε το [CustomXmlPart.remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#remove) όταν το τμήμα πρέπει να αφαιρεθεί από την παρουσίαση.
- Πριν διαγράψετε ή αντικαταστήσετε ένα κοινό τμήμα, εξετάστε τις συλλογές επιπέδου αντικειμένου για να διαπιστώσετε αν άλλες διαφάνειες ή σχήματα το αναφέρουν ακόμα.

Οι υπερφορτώσεις του [add](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpartcollection/#add) δημιουργούν νέο προσαρμοσμένο τμήμα XML από περιεχόμενο XML· δεν δέχονται υπάρχον [CustomXmlPart](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/). Συνεπώς, κοινές σχέσεις συναντώνται κυρίως όταν φορτώνουμε παρουσιάσεις που ήδη τα περιέχουν.

Το παρακάτω παράδειγμα ελέγχει τις συλλογές παρουσίασης, διαφάνειας και σχήματος κατά `ItemId` και αναφέρει τμήματα που αναφέρονται από περισσότερα από ένα σημεία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Αυτό το είδος ελέγχου είναι χρήσιμο πριν την τροποποίηση ή διαγραφή προσαρμοσμένων δεδομένων XML σε παρουσιάσεις που δημιουργήθηκαν από εξωτερικά συστήματα, επειδή το ίδιο τμήμα μεταδεδομένων μπορεί να συμμετέχει σε περισσότερες από μία σχέσεις.

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στη μέθοδο [DocumentProperties.getKeywords](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getKeywords). Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides for Python via Java για μια [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides σας επιτρέπει να προσθέσετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας, όπως `MyTag`;
- την τιμή της προσαρμοσμένης ιδιότητας, όπως `My Tag Value`.

Αν χρειάζεται να ταξινομήσετε παρουσιάσεις βάσει ενός συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να προσθέσετε ετικέτες για αυτόν τον σκοπό. Για παράδειγμα, αν θέλετε να κατηγοριοποιήσετε παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα "NorthAmerican" και να ορίσετε τη σχετική χώρα ως τιμή της.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) χρησιμοποιώντας το Aspose.Slides for Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Οι ετικέτες μπορούν επίσης να οριστούν για μια [Slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Ή για ένα μεμονωμένο [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής [CustomData.getTags](https://reference.aspose.com/slides/el/python-java/aspose.slides/customdata/#getTags) αποθηκεύονται μόνο στο αρχείο PowerPoint. **Δεν** μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξαχθεί σε PDF. Συνεπώς, ένας προσαρμοσμένος αναγνωριστής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Παράκαμψη**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο αναγνωριστικό στο **Alt Text** του αντικειμένου (π.χ., [Shape.setAlternativeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setAlternativeText) με την τιμή `"MyId"`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών PDF.

## **Συχνές Ερωτήσεις (FAQ)**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μία ενέργεια;**

Ναι. Η [tag collection](https://reference.aspose.com/slides/el/python-java/aspose.slides/tagcollection/) υποστηρίζει την ενέργεια [clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/tagcollection/#clear) που διαγράφει όλα τα ζεύγη κλειδί‑τιμή ταυτόχρονα.

**Πώς διαγράφω μια μεμονωμένη ετικέτα με βάση το όνομά της χωρίς να διατρέξω ολόκληρη τη συλλογή;**

Χρησιμοποιήστε το [remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/tagcollection/#remove) στη [tag collection](https://reference.aspose.com/slides/el/python-java/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω τη πλήρη λίστα των ονομάτων ετικετών για αναλύσεις ή φιλτράρισμα;**

Χρησιμοποιήστε το [getNamesOfTags](https://reference.aspose.com/slides/el/python-java/aspose.slides/tagcollection/#getNamesOfTags) στη [tag collection](https://reference.aspose.com/slides/el/python-java/aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.

**Πώς μπορώ να βρω όλα τα προσαρμοσμένα τμήματα XML ανεξάρτητα από το που είναι αποθηκευμένα;**

Χρησιμοποιήστε το [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getAllCustomXmlParts) για ανάκτηση όλων των προσαρμοσμένων τμημάτων XML στην παρουσίαση.

**Θα πρέπει να χρησιμοποιήσω το [getXmlAsString](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlAsString) ή το [getXmlData](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlData) για την ενημέρωση ενός προσαρμοσμένου τμήματος XML;**

Χρησιμοποιήστε το [getXmlAsString](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#getXmlAsString) και το [setXmlAsString](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlAsString) όταν η εφαρμογή εργάζεται με κείμενο XML UTF‑8. Χρησιμοποιήστε το [getXmlData](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#getXmlData) και το [setXmlData](https://reference.aspose.com/slides/el/python-java/aspose.slides/customxmlpart/#setXmlData) όταν το XML είναι ήδη διαθέσιμο ως πίνακας byte ή όταν η επεξεργασία σε δυαδική μορφή είναι πιο βολική. Και οι δύο αναπαραστάσεις αναφέρονται στο ίδιο περιεχόμενο XML του προσαρμοσμένου τμήματος.