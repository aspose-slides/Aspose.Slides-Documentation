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
- Γλώσσα ελέγχου ορθογραφίας
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- Παρουσίαση
- Python
- Aspose.Slides
description: "Κατακτήστε τις ιδιότητες παρουσίασης στο Aspose.Slides for Python via .NET και απλοποιήστε την αναζήτηση, την εμπορική επωνυμία και τη ροή εργασίας στα αρχεία PowerPoint σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν να προσπελαστούν και να διαχειριστούν εύκολα χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/) . Μια παρουσίαση αυτής της κλάσης επιστρέφεται από την ιδιότητα [Presentation.document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/document_properties/) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="primary" %}} 
Παρακαλούμε σημειώστε ότι δεν μπορείτε να ορίσετε τιμές στα πεδία **Application** και **Producer**, επειδή το Aspose Ltd. και το Aspose.Slides for Python via .NET x.x.x θα εμφανίζονται σε αυτά τα πεδία.
{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια δυνατότητα για προσθήκη ορισμένων ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

Οι **Built-in** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο όπως τίτλος εγγράφου, όνομα συγγραφέα, στατιστικά του εγγράφου κλπ. Οι **Custom** ιδιότητες είναι εκείνες που ορίζονται από τους χρήστες ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή καθορίζονται από το χρήστη. Χρησιμοποιώντας το Aspose.Slides for Python via .NET, οι προγραμματιστές μπορούν να προσπελάσουν και να τροποποιήσουν τις τιμές των ενσωματωμένων ιδιοτήτων καθώς και των προσαρμοσμένων ιδιοτήτων. Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και έπειτα στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007. Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint. Στον **Properties Dialog**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General, Summary, Statistics, Contents and Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών τύπων πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Πρόσβαση σε Built-in Ιδιότητες**

Αυτές οι ιδιότητες, όπως εκτίθενται από το αντικείμενο **IDocumentProperties**, περιλαμβάνουν: **Creator(Author)**, **Description**, **Keywords**, **Created** (Ημερομηνία Δημιουργίας), **Modified** (Ημερομηνία Τροποποίησης), **Printed** (Ημερομηνία Τελευταίας Εκτύπωσης), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινή χρήση μεταξύ διαφορετικών παραγωγών;), **PresentationFormat**, **Subject** και **Title**.

```py
import aspose.slides as slides

# Δημιουργία του αντικειμένου Presentation που αντιπροσωπεύει την παρουσίαση
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Δημιουργία αναφοράς σε αντικείμενο που σχετίζεται με την Presentation
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

## **Τροποποίηση Built-in Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι εξίσου εύκολη με την πρόσβαση σε αυτές. Μπορείτε απλώς να αναθέσετε μια τιμή συμβολοσειράς σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείξαμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου του αρχείου παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει την Presentation
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Δημιουργία αναφοράς σε αντικείμενο που σχετίζεται με την Presentation
    documentProperties = presentation.document_properties

    # Ορισμός των ενσωματωμένων ιδιοτήτων
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Αποθήκευση της παρουσίασης σε αρχείο
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Το Aspose.Slides for Python via .NET επιτρέπει επίσης στους προγραμματιστές να προσθέσουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation
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

Το Aspose.Slides for Python via .NET επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν τις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει το PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Δημιουργία αναφοράς σε αντικείμενο document_properties που σχετίζεται με την Presentation
    documentProperties = presentation.document_properties

    # Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for i in range(documentProperties.count_of_custom_properties):
        # Εμφάνιση ονομάτων και τιμών προσαρμοσμένων ιδιοτήτων
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Τροποποίηση τιμών προσαρμοσμένων ιδιοτήτων
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Αποθήκευση της παρουσίασής σας σε αρχείο
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Το Aspose.Slides παρέχει την ιδιότητα `Language_Id` (εκτεθειμένη από την κλάση [PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/)) για να σας επιτρέψει να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου είναι η γλώσσα στην οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας Python σας δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # ορίστε το Id μιας γλώσσας ελέγχου
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας Python σας δείχνει πώς να ορίσετε την προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

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

Δοκιμάστε την online εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργαστείτε με ιδιότητες εγγράφου μέσω του API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια built-in ιδιότητα από μια παρουσίαση;**

Οι built-in ιδιότητες είναι αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε σε κενό εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που ήδη υπάρχει;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που ήδη υπάρχει, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι, μπορείτε να προσπελάσετε τις ιδιότητες παρουσίασης χωρίς να φορτώσετε πλήρως την παρουσίαση χρησιμοποιώντας τη μέθοδο [get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) από την κλάση [PresentationFactory](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/). Στη συνέχεια, χρησιμοποιήστε τη μέθοδο [read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/) που παρέχεται από την κλάση [PresentationInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/) για να διαβάσετε τις ιδιότητες αποδοτικά, εξοικονομώντας μνήμη και βελτιώνοντας την απόδοση.