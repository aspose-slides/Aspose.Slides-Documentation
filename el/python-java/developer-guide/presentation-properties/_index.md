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
- Γλώσσα επιμέλειας
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- Παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε πλήρως τις ιδιότητες παρουσίασης στο Aspose.Slides για Python μέσω Java και βελτιστοποιήστε την αναζήτηση, το branding και τη ροή εργασιών στα αρχεία PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Το Aspose.Slides για Python μέσω Java υποστηρίζει **ενσωματωμένες** και **προσαρμοσμένες** ιδιότητες εγγράφου. Χρησιμοποιήστε αυτές τις ιδιότητες για να διαβάσετε και να ενημερώσετε τα μεταδεδομένα της παρουσίασης, όπως ο συγγραφέας, ο τίτλος και οι τιμές που ορίζονται από τον χρήστη.

Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/). Μια παρουσία της κλάσης αυτής επιστρέφεται από το [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides διαχειρίζεται τα μεταδεδομένα της εφαρμογής και του παραγωγού κατά την αποθήκευση των παρουσιάσεων· αυτά τα πεδία ταυτοποιούν το λογισμικό που δημιούργησε το αποτέλεσμα.
{{% /alert %}}

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες εγγράφου αποθηκεύουν περιγραφικές πληροφορίες παράλληλα με το περιεχόμενο της παρουσίασης. Κατατάσσονται σε δύο κατηγορίες:

- **Ενσωματωμένες ιδιότητες** περιέχουν τυπικά μεταδεδομένα, όπως ο τίτλος, ο συγγραφέας και τα στατιστικά του εγγράφου.
- **Προσαρμοσμένες ιδιότητες** αποθηκεύουν ζεύγη ονόματος/τιμής που ορίζονται από τον χρήστη.

Το Aspose.Slides για Python μέσω Java παρέχει πρόσβαση και στις δύο κατηγορίες. Στο PowerPoint, επιλέξτε **Αρχείο → Πληροφορίες → Ιδιότητες → Προηγμένες Ιδιότητες** για να εξετάσετε τα μεταδεδομένα του εγγράφου. Ο διάλογος ομαδοποιεί τις πληροφορίες σε καρτέλες όπως **Περίληψη**, **Στατιστικά**, **Περιεχόμενα** και **Προσαρμοσμένες**. Χρησιμοποιήστε την καρτέλα **Προσαρμοσμένες** για να διαχειριστείτε τις ιδιότητες που ορίζονται από τον χρήστη.

## **Ανάγνωση Δημοσίων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός πρόσβασης ανοίγματος προστατεύει συνήθως τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες του εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται μετά από κλήση του [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) με τιμή `False`, οι ιδιότητες του εγγράφου παραμένουν δημόσιες. Μια εφαρμογή μπορεί τότε να καλέσει το [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) με τιμή `True` και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό πρόσβασης ανοίγματος.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ελέγχει τι φορτώνει το Aspose.Slides· δεν πραγματοποιεί καμία αποσαφήνιση. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωσή τους χωρίς κωδικό αποτυχίζει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται η πλήρης παρουσίαση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση της οποίας οι ιδιότητες εγγράφου έχουν μείνει δημόσιες. Επαληθεύει τη λειτουργία φόρτωσης μέσω του [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) και στη συνέχεια διαβάζει τις ενσωματωμένες ιδιότητες μέσω του [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

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

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Διαφάνειες, πρότυπα, διατάξεις, σχήματα, πολυμέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) πριν εκτελέσουν λειτουργία που απαιτεί το πλήρες μοντέλο αντικειμένων της παρουσίασης.

{{% alert color="warning" title="Warning" %}}
Τα δημόσια μεταδεδομένα ενδέχεται να αποκαλύψουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Κρατήστε τις δημόσιες μόνο όταν η ευρετηρίαση, η ταξινόμηση, η αναζήτηση ή τα συστήματα διαχείρισης εγγράφων έχουν συγκεκριμένη απαίτηση να τις προσπελάσουν χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται μετά από κλήση του [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) με `True` προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο-με-μεταδεδομένα, επειδή οι δημόσιες ιδιότητες πρέπει να παραμένουν συνεπείς με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί συνεπώς τον σωστό κωδικό πρόσβασης ανοίγματος και μια πλήρη φόρτωση.

Το παράδειγμα απαιτεί ένα κρυπτογραφημένο αρχείο PPTX παρουσίασης με δημόσιες ιδιότητες εγγράφου και γνωστό κωδικό ανοίγματος. Ανοίγει την πλήρη παρουσίαση με το [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) για να επαληθεύσει ότι η κρυπτογράφηση διατηρείται και ξανά ανοίγει τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

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

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο-ανάγνωση.

## **Πρόσβαση στις Ενσωματωμένες Ιδιότητες**

Η κλάση [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) εκθέτει ενσωματωμένα μεταδεδομένα μέσω μεθόδων getter, συμπεριλαμβανομένων των [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) και [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και εμφανίζει τα αποθηκευμένα μεταδεδομένα στην κονσόλα. Οι τιμές εξαρτώνται από την είσοδο παρουσίασης· ορισμένα πεδία μπορεί να είναι κενά.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Για να ενημερώσετε ενσωματωμένα μεταδεδομένα, χρησιμοποιήστε τις μεθόδους setter στο αντικείμενο που επιστρέφεται από το [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση, καλεί τα [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) και [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager), έπειτα αποθηκεύει την ενημερωμένη παρουσίαση με το [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Το αποθηκευμένο PPTX περιέχει τα νέα μεταδεδομένα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Διαχείριση Βάσης Υπερσυνδέσμου**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) επιστρέφει τη βάση επιπέδου εγγράφου για σχετικούς υπερσυνδέσμους. Χρησιμοποιήστε το [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) για να την αλλάξετε ή να την αφαιρέσετε. Αυτό είναι χρήσιμο όταν μετακινείτε μια παρουσίαση και τα συνδεδεμένα της αρχεία σε άλλη τοποθεσία. Είναι ξεχωριστό από το [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) ενός μεμονωμένου υπερσυνδέσμου· η αλλαγή της βάσης δεν ανανεώνει τις αποθηκευμένες διευθύνσεις συνδέσμων ούτε αλλάζει απόλυτους προορισμούς.

Το παράδειγμα απαιτεί μια παρουσίαση που περιέχει τόσο έναν σχετικό σύνδεσμο, όπως `target.html`, όσο και έναν απόλυτο σύνδεσμο, όπως `https://example.org/absolute.html`. Διαβάζει την υπάρχουσα βάση, εκχωρεί νέα διεύθυνση βάσης και αποθηκεύει και ξανά ανοίγει την παρουσίαση για να ελέγξει την τιμή. Στη συνέχεια αφαιρεί τη βάση με μια κενή συμβολοσειρά και επαληθεύει την κενή τιμή σε ξεχωριστό αποθηκευμένο αρχείο. Αντικαταστήστε τη διεύθυνση βάσης του παραδείγματος με τη θέση των συνδεδεμένων αρχείων σας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

Τα δύο μηνύματα επαλήθευσης πρέπει να εκτυπώσουν `True`. Η αφαίρεση της βάσης αφήνει ανέπαφες τις διευθύνσεις των μεμονωμένων υπερσυνδέσμων.

Ένας σχετικός σύνδεσμος προς `target.pptx` άνοιγε `old/target.pptx` όταν η βάση έδειχνε στον φάκελο `old`. Αφού η βάση άλλαξε στον φάκελο `new`, αποθηκεύτηκε και ξανανοιώθηκε η παρουσίαση, ο ίδιος σύνδεσμος άνοιγε `new/target.pptx`. Ένας απόλυτος σύνδεσμος συνέχισε να ανοίγει το ίδιο αρχείο. Δοκιμάστε τους σχετικούς συνδέσμους σας στο PowerPoint πριν και μετά τη μετακίνηση της παρουσίασης ή την αλλαγή της βάσης.

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες αποθηκεύουν μεταδεδομένα που δεν έχουν αντίστοιχο ενσωματωμένο πεδίο. Η μέθοδος [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) σας επιτρέπει να εκχωρήσετε τιμή με βάση το όνομα της ιδιότητας. Αυτό το παράδειγμα δημιουργεί μια παρουσίαση, προσθέτει δύο τιμές κειμένου και μια ακέραια τιμή έκδοσης (χρησιμοποιώντας `jpype.JInt` για τη διέλευση ενός Java ακέραιου), και αποθηκεύει την παρουσίαση με το [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Η εκχώρηση τιμής σε υπάρχον όνομα αντικαθιστά την τιμή εκείνης της ιδιότητας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Αυτό το παράδειγμα ανοίγει μια παρουσίαση που περιέχει προσαρμοσμένες ιδιότητες και χρησιμοποιεί το [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) για να τις επαναλάβει. Η [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) δέχεται δείκτη μηδενικής βάσης και επιστρέφει το όνομα που χρησιμοποιείται από το [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). Το παράδειγμα εκτυπώνει κάθε αρχικό όνομα και τιμή, αντικαθιστά κάθε τιμή με αριθμημένη συμβολοσειρά ανεξαρτήτως αρχικού τύπου και αποθηκεύει τις αλλαγές. Εάν δεν υπάρχουν προσαρμοσμένες ιδιότητες, ο βρόχος δεν κάνει αλλαγές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την εφαρμογή [**Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint**](https://products.aspose.app/slides/metadata) online για να δείτε πώς να εργάζεστε με ιδιότητες εγγράφου χρησιμοποιώντας το API του Aspose.Slides:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες είναι αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε κενές εφόσον αυτό επιτρέπεται από τη συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) και στη συνέχεια το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Δείτε το [Build a Lightweight Presentation Inventory](/slides/el/python-java/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες μιας κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό πρόσβασης ανοίγματος;**

Ναι. Η παρουσίαση πρέπει να έχει κρυπτογραφηθεί μετά από κλήση του [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) με `False`, και πρέπει να φορτωθεί μετά από κλήση του [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) με `True`.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο-ιδιοτήτων-εγγράφου;**

Όχι. Οι δημόσιες και κρυπτογραφημένες ιδιότητες πρέπει να παραμένουν συνεπείς, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση της πλήρους παρουσίασης με τον σωστό κωδικό πρόσβασης ανοίγματος.