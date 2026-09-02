---
title: Διαχειριστείτε Ιδιότητες Παρουσίασης με Python
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/python-net/presentation-properties/
keywords:
- ιδιότητες PowerPoint
- ιδιότητες παρουσίασης
- ιδιότητες εγγράφου
- ενσωματωμένες ιδιότητες
- προσαρμοσμένες ιδιότητες
- προηγμένες ιδιότητες
- διαχείριση ιδιοτήτων
- τροποποίηση ιδιοτήτων
- μεταδεδομένα εγγράφου
- επεξεργασία μεταδεδομένων
- γλώσσα ελέγχου ορθογραφίας
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε αποτελεσματικά τις ιδιότητες παρουσίασης στο Aspose.Slides for Python via .NET και βελτιστοποιήστε την αναζήτηση, το branding και τη ροή εργασίας στα αρχεία PowerPoint σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Ενσωματωμένες** και **Προσαρμοσμένες**. Και οι δύο αυτοί τύποι ιδιοτήτων μπορούν να προσπελαστούν και να διαχειριστούν εύκολα χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σάς επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/) . Μια εμφάνιση αυτής της κλάσης επιστρέφεται από την ιδιότητα [Presentation.document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/document_properties/) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}
Παρακαλούμε σημειώστε ότι δεν μπορείτε να ορίσετε τιμές στα πεδία **Application** και **Producer**, επειδή η Aspose Ltd. και το Aspose.Slides for Python via .NET x.x.x θα εμφανίζονται σε αυτά τα πεδία.
{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια λειτουργία για την προσθήκη ορισμένων ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής

- Προκαθορισμένες (Built-in) Ιδιότητες
- Προσαρμοσμένες (Custom) Ιδιότητες

**Ενσωματωμένες** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο όπως ο τίτλος του εγγράφου, το όνομα του δημιουργού, στατιστικά του εγγράφου κλπ. **Προσαρμοσμένες** ιδιότητες είναι αυτές που ορίζονται από τους χρήστες ως ζεύγη **Όνομα/Τιμή**, όπου τόσο το όνομα όσο και η τιμή καθορίζονται από τον χρήστη. Χρησιμοποιώντας το Aspose.Slides for Python via .NET, οι προγραμματιστές μπορούν να προσπελάσουν και να τροποποιήσουν τις τιμές των ενσωματωμένων ιδιοτήτων καθώς και των προσαρμοσμένων ιδιοτήτων. Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο του Office και στη συνέχεια στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007. Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint. Στο **Properties Dialog**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General, Summary, Statistics, Contents and Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών ειδών πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**
Αυτές οι ιδιότητες, όπως εκτίθενται από το αντικείμενο **IDocumentProperties**, περιλαμβάνουν: **Creator(Author)**, **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** και **Title**
```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει την παρουσίαση
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Δημιουργία αναφοράς στο αντικείμενο που σχετίζεται με την Presentation
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

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο εύκολη όσο η πρόσβαση σε αυτές. Απλώς εκχωρείτε μια συμβολοσειρά σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείξαμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου του αρχείου παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει την Presentation
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Δημιουργία αναφοράς στο αντικείμενο που σχετίζεται με την Presentation
    documentProperties = presentation.document_properties

    # Ορισμός των ενσωματωμένων ιδιοτήτων
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Αποθήκευση της παρουσίασής σας σε αρχείο
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Το Aspose.Slides for Python via .NET επιτρέπει επίσης στους προγραμματιστές να προσθέσουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Παρακάτω δίνεται ένα παράδειγμα που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation
with slides.Presentation() as presentation:
    # Λήψη Ιδιοτήτων Εγγράφου
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

Το Aspose.Slides for Python via .NET επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν τις τιμές των προσαρμοσμένων ιδιοτήτων. Παρακάτω δίνεται ένα παράδειγμα που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει το PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Δημιουργία αναφοράς στο αντικείμενο document_properties που σχετίζεται με την Presentation
    documentProperties = presentation.document_properties

    # Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Εμφάνιση ονομάτων και τιμών προσαρμοσμένων ιδιοτήτων
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Τροποποίηση τιμών προσαρμοσμένων ιδιοτήτων
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Αποθήκευση της παρουσίασής σας σε αρχείο
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` επιστρέφει την τιμή μέσω της λίστας μονού στοιχείου που περνιέται ως δεύτερο όρισμα, και η αποθηκευμένη τιμή μετατρέπεται στον τύπο του στοιχείου που ήδη υπάρχει στη λίστα. Το παραπάνω παράδειγμα χρησιμοποιεί `[""]`, επομένως διαβάζει ιδιότητες τύπου συμβολοσειράς· για να διαβάσετε μια ιδιότητα αποθηκευμένη ως αριθμός, περάστε έναν αριθμητικό υπόδειγμα όπως `[0]`· διαφορετικά η κλήση θα προκαλέσει `InvalidCastException`.

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Το Aspose.Slides παρέχει την ιδιότητα `Language_Id` (εκτεθειμένη από την κλάση [PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/)) για να σας επιτρέψει να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου ορθογραφίας είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα PowerPoint:

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

    # ορίστε το Id μιας γλώσσας ελέγχου ορθογραφίας
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε τη προεπιλεγμένη γλώσσα για ολόκληρη μια παρουσίαση PowerPoint:

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

Δοκιμάστε την εφαρμογή online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να δουλέψετε με τις ιδιότητες εγγράφου μέσω του API του Aspose.Slides:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε κενές εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) και στη συνέχεια [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια εμφάνιση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Δείτε [Build a Lightweight Presentation Inventory](/slides/el/python-net/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.