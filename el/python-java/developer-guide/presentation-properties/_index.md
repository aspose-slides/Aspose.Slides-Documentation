---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε Python
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/python-java/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προηγμένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα ελέγχου ορθογραφίας
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τις ιδιότητες παρουσίασης στο Aspose.Slides για Python μέσω Java και βελτιστοποιήστε την αναζήτηση, την ενσάρκωση της επωνυμίας και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Ενσωματωμένες** και **Προσαρμοσμένες**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/) . Μια εμφάνιση αυτής της κλάσης επιστρέφεται από τη μέθοδο [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getDocumentProperties) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}
Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **AppVersion** δεν μπορούν να τροποποιηθούν. Το Aspose.Slides τα ξαναγράφει σε κάθε αποθήκευση, έτσι μια αποθηκευμένη παρουσίαση πάντα αναφέρει «Aspose.Slides for Java» και την έκδοση της βιβλιοθήκης που τη δημιούργησε. Οποιαδήποτε τιμή περάσει στη μέθοδο [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#setNameOfApplication) απορρίπτεται όταν η παρουσίαση γράφεται.
{{% /alert %}}

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 σας επιτρέπει να διαχειρίζεστε τις ιδιότητες εγγράφου των αρχείων παρουσίασης. Κάντε κλικ στο εικονίδιο Office και επιλέξτε **Prepare | Properties | Advanced Properties**, όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Προηγμένες Ιδιότητες**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|
Αφού επιλέξετε **Advanced Properties**, εμφανίζεται ένας διάλογος όπου μπορείτε να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint:

|**Διάλογος Ιδιοτήτων**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|
Ο **Διάλογος Ιδιοτήτων** περιέχει καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Αυτές οι καρτέλες σας επιτρέπουν να ρυθμίσετε διαφορετικά είδη πληροφοριών για αρχεία PowerPoint. Χρησιμοποιήστε την καρτέλα **Custom** για να διαχειριστείτε προσαρμοσμένες ιδιότητες.

## **Εργασία με Ιδιότητες Εγγράφου χρησιμοποιώντας Aspose.Slides for Python via Java**

Όπως περιγράφηκε παραπάνω, το Aspose.Slides for Python via Java υποστηρίζει τόσο **Ενσωματωμένες** όσο και **Προσαρμοσμένες** ιδιότητες εγγράφου. Η κλάση [DocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/) αντιπροσωπεύει τις ιδιότητες εγγράφου που σχετίζονται με ένα αρχείο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getDocumentProperties) για να προσπελάσετε αυτές τις ιδιότητες όπως περιγράφεται παρακάτω.

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός ανοίγματος προστατεύει κανονικά τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται με το πέρασμα της τιμής `false` στη μέθοδο [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), οι ιδιότητες εγγράφου παραμένουν δημόσιες. Μια εφαρμογή μπορεί τότε να περάσει `true` στη μέθοδο [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό ανοίγματος.

Η επιλογή «μόνο ιδιότητες εγγράφου» ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφιση, η φόρτωση χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται ολόκληρη η παρουσίαση.

Το παρακάτω παράδειγμα επαληθεύει τη λειτουργία φόρτωσης μέσω της μεθόδου [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) και στη συνέχεια διαβάζει ενσωματωμένες ιδιότητες μέσω της μεθόδου [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Διαφάνειες, master, layouts, shapes, media και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν την μέθοδο [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) πριν εκτελέσουν ενέργεια που απαιτεί το πλήρες μοντέλο αντικειμένων παρουσίασης.

{{% alert color="warning" title="Προειδοποίηση" %}}
Τα δημόσια μεταδεδομένα μπορεί να εκθέσουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Διατηρήστε τις δημόσιες μόνο όταν συστήματα ευρετηρίου, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων έχουν συγκεκριμένη απαίτηση πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίας**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται σε λειτουργία «μόνο ιδιότητες εγγράφου» προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει τις αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο‑μεταδεδομένων, επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν συνεπείς με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί επομένως τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση με τη μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setPassword), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί τη μέθοδο [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#isEncrypted) για να επαληθεύσει ότι η κρυπτογράφιση διατηρείται και ξανανοίγει τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο‑ανάγνωση.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Οι ενσωματωμένες ιδιότητες που εκτίθενται από το [DocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/) περιλαμβάνουν: **Creator** (Συγγραφέας), **Description**, **Created** (Ημερομηνία Δημιουργίας), **Modified** (Ημερομηνία Τροποποίησης), **Printed** (Τελευταία Ημερομηνία Εκτύπωσης), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινόχρηστο μεταξύ διαφορετικών δημιουργών;), **PresentationFormat**, **Subject**, και **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει την παρουσίαση
presentation = Presentation("Presentation.pptx")
try:
    # Δημιουργία αναφοράς σε αντικείμενο DocumentProperties που σχετίζεται με την Presentation
    properties = presentation.getDocumentProperties()

    # Εμφάνιση των ενσωματωμένων ιδιοτήτων
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων είναι τόσο απλή όσο η πρόσβαση σε αυτές. Χρησιμοποιήστε τον αντίστοιχο setter για να ορίσετε νέα τιμή. Το παρακάτω παράδειγμα τροποποιεί ενσωματωμένες ιδιότητες εγγράφου χρησιμοποιώντας το Aspose.Slides for Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Δημιουργία αναφοράς σε αντικείμενο DocumentProperties που συσχετίζεται με την Presentation
    properties = presentation.getDocumentProperties()

    # Ορισμός των ενσωματωμένων ιδιοτήτων
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Αποθήκευση της παρουσίασης σε αρχείο
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αυτό το παράδειγμα τροποποιεί τις ενσωματωμένες ιδιότητες της παρουσίασης, όπως φαίνεται παρακάτω:

|**Ενσωματωμένες ιδιότητες εγγράφου μετά τη τροποποίηση**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides for Python via Java επιτρέπει επίσης στους προγραμματιστές να προσθέτουν προσαρμοσμένες ιδιότητες εγγράφου σε παρουσιάσεις. Το παρακάτω παράδειγμα προσθέτει τρεις προσαρμοσμένες ιδιότητες, στη συνέχεια αναζητά το όνομα που αποθηκεύτηκε στο δείκτη 2 και αφαιρεί αυτή την ιδιότητα, έτσι ώστε η αποθηκευμένη παρουσίαση να κρατά δύο από αυτές. Οι προσαρμοσμένες ιδιότητες ταξινομούνται αλφαβητικά, όχι με τη σειρά προσθήκης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Λήψη ιδιοτήτων εγγράφου
    properties = presentation.getDocumentProperties()

    # Προσθήκη προσαρμοσμένων ιδιοτήτων
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Λήψη ονόματος ιδιότητας σε συγκεκριμένο δείκτη
    property_name = properties.getCustomPropertyName(2)

    # Αφαίρεση επιλεγμένης ιδιότητας
    properties.removeCustomProperty(property_name)

    # Αποθήκευση παρουσίασης
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Προσαρμοσμένες Ιδιότητες Εγγράφου που Προστέθηκαν**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides for Python via Java επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν τις τιμές των προσαρμοσμένων ιδιοτήτων. Το παρακάτω παράδειγμα δείχνει πώς να προσπελάσετε και να τροποποιήσετε όλες τις προσαρμοσμένες ιδιότητες σε μια παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Δημιουργία αναφοράς σε αντικείμενο DocumentProperties που σχετίζεται με την Presentation
    properties = presentation.getDocumentProperties()

    # Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Εμφάνιση ονομάτων και τιμών προσαρμοσμένων ιδιοτήτων
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Τροποποίηση τιμών προσαρμοσμένων ιδιοτήτων
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Αποθήκευση της παρουσίασης σε αρχείο
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες της παρουσίασης [PPTX](https://docs.fileformat.com/presentation/pptx/). Οι παρακάτω εικόνες δείχνουν τις προσαρμοσμένες ιδιότητες πριν και μετά την τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν τη Τροποποίηση**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Προσαρμοσμένες Ιδιότητες μετά τη Τροποποίηση**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Προηγμένες Ιδιότητες Εγγράφου**

{{% alert color="info" title="Σημείωση" %}}
Νέες μέθοδοι [readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) και [writeBindedPresentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/), ενώ η συμπεριφορά της μεθόδου [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#setLastSavedTime) άλλαξε.
{{% /alert %}}

Οι δύο νέες μέθοδοι [readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) και [updateDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/) . Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και σας επιτρέπουν να αλλάζετε και να ενημερώνετε ιδιότητες χωρίς φόρτωση ολόκληρης της παρουσίασης.

Η τυπική ροή εργασίας φόρτωσης ιδιοτήτων, αλλαγής τιμών και ενημέρωσης του εγγράφου μπορεί να υλοποιηθεί ως εξής:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Διαβάστε τις πληροφορίες της παρουσίασης
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Αποκτήστε τις τρέχουσες ιδιότητες
properties = presentation_info.readDocumentProperties()

# Ορίστε τις νέες τιμές των πεδίων Συγγραφέας και Τίτλος
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Ενημερώστε την παρουσίαση με τις νέες τιμές
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Υπάρχει μια άλλη μέθοδος για χρήση των ιδιοτήτων μιας συγκεκριμένης παρουσίασης ως προτύπου για ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Νέο πρότυπο μπορεί να δημιουργηθεί από το μηδέν και έπειτα να χρησιμοποιηθεί για ενημέρωση πολλαπλών παρουσιάσεων:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Το Aspose.Slides παρέχει τη μέθοδο [PortionFormat.setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#setLanguageId) για να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου είναι η γλώσσα για την οποία ελέγχονται ορθογραφία και γραμματική στην παρουσίαση.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # ορίστε το Id μιας γλώσσας ελέγχου

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε την προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Προσθέτει ένα σχήμα ορθογωνίου με κείμενο
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Ελέγχει τη γλώσσα του πρώτου τμήματος
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την εφαρμογή online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου μέσω του API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες είναι αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν πλήρως. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε κενές εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που ήδη υπάρχει;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες παρουσίασης χωρίς να φορτώσω ολόκληρη την παρουσίαση;**

Ναι. Χρησιμοποιήστε τη μέθοδο [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) και έπειτα [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια εμφάνιση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) . Δείτε το «Build a Lightweight Presentation Inventory» (/slides/el/python-java/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η κρυπτογράφιση των ιδιοτήτων εγγράφου πρέπει να έχει απενεργοποιηθεί πριν κρυπτογραφηθεί η παρουσίαση, και η παρουσίαση πρέπει να φορτωθεί σε λειτουργία «μόνο ιδιότητες εγγράφου».

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία «μόνο ιδιότητες εγγράφου»;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμείνουν συνεπή, έτσι η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί πλήρη φόρτωση της παρουσίασης με τον σωστό κωδικό ανοίγματος.