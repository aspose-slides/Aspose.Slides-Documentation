---
title: Διαχείριση Ιδιοτήτων Παρουσίασης με Python
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/python-net/presentation-properties/
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
- Γλώσσα διόρθωσης
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Κατέχετε τις ιδιότητες παρουσίασης στο Aspose.Slides for Python via .NET και βελτιστοποιήστε την αναζήτηση, το branding και τη ροή εργασίας στα αρχεία PowerPoint σας."
---
## **Εισαγωγή**

Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Ενσωματωμένες** και **Προσαρμοσμένες**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσεγγιστούν και να διαχειριστούν μέσω του Aspose.Slides API.

Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/) . Μια παρουσία της κλάσης επιστρέφεται από την ιδιότητα [Presentation.document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/document_properties/) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}

Παρακαλούμε σημειώστε ότι δεν μπορείτε να ορίσετε τιμές στα πεδία **Application** και **Producer**, επειδή θα εμφανίζονται η Aspose Ltd. και το Aspose.Slides for Python via .NET x.x.x σε αυτά τα πεδία.

{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει δυνατότητα προσθήκης κάποιων ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής

- Ιδιότητες Συστηματος (Ενσωματωμένες)
- Ιδιότητες Χρήστη (Προσαρμοσμένες)

Οι **Ενσωματωμένες** ιδιότητες περιέχουν γενικές πληροφορίες σχετικά με το έγγραφο, όπως τίτλος εγγράφου, όνομα δημιουργού, στατιστικά εγγράφου κλπ. Οι **Προσαρμοσμένες** ιδιότητες είναι αυτές που ορίζονται από τους χρήστες ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή ορίζονται από τον χρήστη. Χρησιμοποιώντας το Aspose.Slides for Python via .NET, οι προγραμματιστές μπορούν να έχουν πρόσβαση και να τροποποιήσουν τις τιμές των ενσωματωμένων ιδιοτήτων καθώς και των προσαρμοσμένων. Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007. Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint. Στον **Properties Dialog**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General, Summary, Statistics, Contents and Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη ρύθμιση διαφορετικών τύπων πληροφοριών που σχετίζονται με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός ανοίγματος προστατεύει συνήθως τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται με τη μέθοδο [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ορισμένη σε `False`, οι ιδιότητες εγγράφου παραμένουν δημόσιες. Μια εφαρμογή μπορεί στη συνέχεια να ορίσει το [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/only_load_document_properties/) σε `True` και να διαβάσει τα δημόσια μεταδεδομένα χωρίς την παροχή του κωδικού ανοίγματος.

`only_load_document_properties` ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωσή τους χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται ολόκληρη η παρουσίαση.

Το παρακάτω παράδειγμα επαληθεύει τη λειτουργία φόρτωσης μέσω της μεθόδου [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) και στη συνέχεια διαβάζει τις ενσωματωμένες ιδιότητες μέσω του [Presentation.document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Διαφάνειες, masters, layouts, shapes, media και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το `is_only_document_properties_loaded` πριν εκτελέσουν λειτουργία που απαιτεί το πλήρες μοντέλο αντικειμένων παρουσίασης.

{{% alert color="warning" title="Ασφάλεια" %}}
Τα δημόσια μεταδεδομένα μπορεί να αποκαλύψουν ονόματα δημιουργών, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Αφήστε τα δημόσια μόνο όταν συστήματα ευρετηρίου, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων έχουν συγκεκριμένη απαίτηση πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται με `only_load_document_properties` προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο‑μεταδεδομένων, επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν συμβατές με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί λοιπόν το σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση με [LoadOptions.password](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/password/), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/is_encrypted/) για να επαληθεύσει ότι η κρυπτογράφηση διατηρήθηκε και ανοίγει ξανά τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο‑ανάγνωση.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**
Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο **IDocumentProperties** περιλαμβάνουν: **Creator(Author)**, **Description**, **Keywords**, **Created** (Ημερομηνία Δημιουργίας), **Modified** (Ημερομηνία Τροποποίησης), **Printed** (Τελευταία Εκτύπωση), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινή χρήση μεταξύ διαφορετικών παραγωγών;), **PresentationFormat**, **Subject** και **Title**
```py
import aspose.slides as slides

# Αρχικοποίηση της κλάσης Presentation που αντιπροσωπεύει την παρουσίαση
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Δημιουργία αναφοράς στο αντικείμενο που συνδέεται με την παρουσίαση
    documentProperties = pres.document_properties

    # Εμφάνιση των ενσωματωμένων ιδιοτήτων
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο εύκολη όσο η πρόσβασή τους. Μπορείτε απλώς να αντιστοιχίσετε μια συμβολοσειρά σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου της παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει την παρουσίαση
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Δημιουργία αναφοράς στο αντικείμενο που σχετίζεται με την παρουσίαση
    documentProperties = presentation.document_properties

    # Ορισμός των ενσωματωμένων ιδιοτήτων
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # αποθήκευση της παρουσίασης σε αρχείο
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Το Aspose.Slides for Python via .NET επιτρέπει επίσης στους προγραμματιστές να προσθέτουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου της παρουσίασης. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργία αντικειμένου Presentation
with slides.Presentation() as presentation:
    # Λήψη ιδιοτήτων εγγράφου
    documentProperties = presentation.document_properties

    # Προσθήκη προσαρμοσμένων ιδιοτήτων
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Λήψη ονόματος ιδιότητας σε συγκεκριμένο δείκτη
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Αφαίρεση επιλεγμένης ιδιότητας
    documentProperties.remove_custom_property(getPropertyName)

    # Αποθήκευση παρουσίασης
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides for Python via .NET επιτρέπει επίσης στους προγραμματιστές να έχουν πρόσβαση στις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει το PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Δημιουργία αναφοράς στο αντικείμενο document_properties που συνδέεται με την Παρουσίαση
    documentProperties = presentation.document_properties

    # Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Εμφάνιση ονομάτων και τιμών των προσαρμοσμένων ιδιοτήτων
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Τροποποίηση τιμών των προσαρμοσμένων ιδιοτήτων
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Αποθήκευση της παρουσίασης σε αρχείο
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` επιστρέφει την τιμή μέσω της λίστας ενός στοιχείου που περνάται ως δεύτερο όρισμα, και η αποθηκευμένη τιμή μετατρέπεται στον τύπο του στοιχείου που υπάρχει ήδη σε αυτή τη λίστα. Το παραπάνω παράδειγμα χρησιμοποιεί `[""]`, ώστε να διαβάζει ιδιότητες συμβολοσείρας· για να διαβάσετε μια ιδιότητα που αποθηκεύεται ως αριθμός, περάστε έναν αριθμητικό placeholder όπως `[0]`· διαφορετικά η κλήση προκαλεί `InvalidCastException`.

## **Ορισμός Γλώσσας Διόρθωσης**

Το Aspose.Slides παρέχει την ιδιότητα `Language_Id` (εμφανίζεται από την κλάση [PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/)) για να σας επιτρέψει να ορίσετε τη γλώσσα διόρθωσης για ένα έγγραφο PowerPoint. Η γλώσσα διόρθωσης είναι η γλώσσα στην οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε τη γλώσσα διόρθωσης για ένα PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # ορίστε το Id μιας γλώσσας διόρθωσης
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε τη προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την online εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου μέσω του Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε σε κενό εάν το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Εάν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες παρουσίασης χωρίς να φορτώνω ολόκληρη την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) και έπειτα το [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Δείτε το [Build a Lightweight Presentation Inventory](/slides/el/python-net/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η παρουσίαση πρέπει να έχει κρυπτογραφηθεί με `encrypt_document_properties` ορισμένο σε `False`, και πρέπει να φορτωθεί με `only_load_document_properties` ορισμένο σε `True`.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο‑ιδιοτήτων‑εγγράφου;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμένουν συμβατά, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση της πλήρους παρουσίασης με το σωστό κωδικό ανοίγματος.