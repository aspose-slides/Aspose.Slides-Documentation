---
title: "Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις με Python"
linktitle: "Ετικέτες και Προσαρμοσμένα Δεδομένα"
type: docs
weight: 300
url: /el/python-net/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσαρμοσμένο XML
- προσαρμοσμένο τμήμα XML
- μεταδεδομένα XML
- ItemId
- προσθήκη ετικέτας
- ζεύγη τιμών
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε ετικέτες και προσαρμοσμένα δεδομένα XML σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω .NET, συμπεριλαμβανομένης της προσθήκης, ανάγνωσης, ενημέρωσης, ελέγχου και αφαίρεσης προσαρμοσμένων τμημάτων XML."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Τα δεδομένα ειδικά για μια παρουσίαση μπορούν να αποθηκευτούν ως ετικέτες ή προσαρμοσμένα μέρη XML. Οι ετικέτες είναι απλά ζεύγη κλειδιού‑τιμής συμβολοσειράς, ενώ τα προσαρμοσμένα μέρη XML μπορούν να αποθηκεύουν δομημένα μεταδεδομένα και XML φορτία ειδικά για την εφαρμογή.

Το Aspose.Slides παρέχει API για προσθήκη, ανάγνωση, ενημέρωση, έλεγχο και αφαίρεση προσαρμοσμένων μερών XML σε επίπεδο παρουσίασης, διαφάνειας και σχήματος. Τα προσαρμοσμένα μέρη XML είναι χρήσιμα για ενσωματώσεις που αποθηκεύουν πληροφορίες όπως ταυτοποιητές διαχείρισης εγγράφου, κατάσταση ροής εργασίας, μεταδεδομένα συμμόρφωσης, δεδομένα δέσμευσης προτύπου ή άλλα δομημένα δεδομένα εφαρμογής μέσα σε μια παρουσίαση.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX — αρχεία με την επέκταση `.pptx` — αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος των προδιαγραφών Office Open XML. Το Office Open XML ορίζει τη δομή του πακέτου και τις σχέσεις που χρησιμοποιούνται για την αποθήκευση του περιεχομένου παρουσίασης και των σχετιζόμενων δεδομένων.

Μια παρουσίαση περιλαμβάνει πολλαπλά τμήματα συνδεδεμένα με σχέσεις. Για παράδειγμα, ένα τμήμα διαφάνειας περιέχει το περιεχόμενο μιας μόνο διαφάνειας και μπορεί να έχει ρητές σχέσεις με άλλα τμήματα όπως ορίζεται από το ISO/IEC 29500.

Τα προσαρμοσμένα δεδομένα μπορούν να αποθηκευτούν ως ετικέτες ([TagCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/)) ή προσαρμοσμένα μέρη XML ([CustomXmlPartCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpartcollection/)). Και τα δύο είναι διαθέσιμα μέσω της κλάσης [`CustomData`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customdata/).

{{% alert color="primary" %}}
Οι ετικέτες αποθηκεύουν απλά ζεύγη κλειδιού‑τιμής συμβολοσειράς. Τα προσαρμοσμένα μέρη XML αποθηκεύουν δομημένα δεδομένα XML και μπορούν να συσχετιστούν με μια παρουσίαση, διαφάνεια ή σχήμα.
{{% /alert %}}

## **Εργασία με Προσαρμοσμένα Μέρη XML**

Η ιδιότητα [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customdata/custom_xml_parts/) επιστρέφει τη συλλογή των προσαρμοσμένων μερών XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης. Για παράδειγμα:

- `presentation.custom_data.custom_xml_parts` περιέχει τα προσαρμοσμένα μέρη XML που σχετίζονται με την ίδια την παρουσίαση.
- `slide.custom_data.custom_xml_parts` περιέχει τα προσαρμοσμένα μέρη XML που σχετίζονται με μια συγκεκριμένη διαφάνεια.
- `shape.custom_data.custom_xml_parts` περιέχει τα προσαρμοσμένα μέρη XML που σχετίζονται με ένα συγκεκριμένο σχήμα.

Χρησιμοποιήστε το [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/all_custom_xml_parts/) όταν χρειάζεται να εξετάσετε όλα τα προσαρμοσμένα μέρη XML στην παρουσίαση, ανεξάρτητα από το πού είναι συνδεδεμένα.

### **Προσθήκη Προσαρμοσμένου Μέρους XML σε Παρουσίαση**

Χρησιμοποιήστε το [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpartcollection/add/) για να προσθέσετε δεδομένα XML σε μια συλλογή προσαρμοσμένων μερών XML. Το XML πρέπει να είναι έγκυρο και μη κενό.

Το παρακάτω παράδειγμα προσθέτει δομημένα μεταδεδομένα στη συλλογή προσαρμοσμένων δεδομένων επιπέδου παρουσίασης:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # Η add αντιστοιχεί αυτόματα ένα αναγνωριστικό. Ορίστε ένα συγκεκριμένο GUID μόνο όταν απαιτείται.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Η μέθοδος `add` μπορεί επίσης να δεχθεί XML ως πίνακα byte ή ροή, κάτι που είναι χρήσιμο όταν το περιεχόμενο XML είναι ήδη διαθέσιμο σε δυαδική μορφή.

### **Προσθήκη Προσαρμοσμένου Μέρους XML σε Διαφάνεια ή Σχήμα**

Τα προσαρμοσμένα δεδομένα XML μπορούν να συσχετιστούν με μια συγκεκριμένη διαφάνεια ή σχήμα αντί για ολόκληρη την παρουσίαση. Αυτό είναι χρήσιμο όταν τα μεταδεδομένα περιγράφουν μόνο ένα αντικείμενο, όπως κλειδί προτύπου, εξωτερικό ταυτοποιητή εγγραφής ή πληροφορίες δέσμευσης.

Το παρακάτω παράδειγμα προσθέτει ένα προσαρμοσμένο μέρος XML σε μια διαφάνεια και ένα άλλο σε ένα σχήμα:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Το επίπεδο στο οποίο προστίθεται το τμήμα καθορίζει ποια συλλογή `custom_data.custom_xml_parts` του αντικειμένου περιέχει τη σχέση με το τμήμα. Τα δεδομένα επιπέδου παρουσίασης είναι κατάλληλα για μεταδεδομένα σε όλο το έγγραφο, τα δεδομένα επιπέδου διαφάνειας για πληροφορίες που ανήκουν σε συγκεκριμένη διαφάνεια, και τα δεδομένα επιπέδου σχήματος για μεταδεδομένα που συνδέονται με μεμονωμένο σχήμα.

### **Λίστα και Έλεγχος Όλων των Προσαρμοσμένων Μερών XML**

Χρησιμοποιήστε το [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/all_custom_xml_parts/) για να ανακτήσετε όλα τα προσαρμοσμένα μέρη XML από μια παρουσίαση. Κάθε [`CustomXmlPart`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpart/) εκθέτει το αναγνωριστικό του, το περιεχόμενο XML και τα συσχετισμένα σχήματα ονομάτων χώρο.

Το παρακάτω παράδειγμα καταγράφει όλα τα προσαρμοσμένα μέρη XML και τα σχήματα ονομάτων τους:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

Η ιδιότητα [`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpart/namespace_schemas/) επιστρέφει τα σχήματα XML που σχετίζονται με το προσαρμοσμένο μέρος XML. Αυτή η πληροφορία μπορεί να είναι χρήσιμη κατά τον έλεγχο παρουσιάσεων που περιέχουν XML παραγόμενο από εξωτερικά συστήματα.

### **Ανάγνωση και Ενημέρωση Περιεχομένου XML και ItemId**

Χρησιμοποιήστε το [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpart/xml_as_string/) για εργασία με XML ως συμβολοσειρά UTF‑8, ή το [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpart/xml_data/) για εργασία με τα ακατέργαστα bytes XML. Και οι δύο ιδιότητες μπορούν να διαβαστούν και να ενημερωθούν.

Η ιδιότητα [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpart/item_id/) περιέχει το GUID που ταυτοποιεί το προσαρμοσμένο μέρος XML στο έγγραφο Office Open XML. Μπορεί επίσης να αλλάξει όταν μια ενσωμάτωση απαιτεί νέο ταυτοποιητή.

Το παρακάτω παράδειγμα ενημερώνει το περιεχόμενο XML και το αναγνωριστικό:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Διαβάστε το τρέχον XML ως κείμενο.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Ενημερώστε το XML ως συμβολοσειρά UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # Το xml_data παρέχει το ίδιο περιεχόμενο XML ως ακατέργαστα bytes.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Αντικαταστήστε το αναγνωριστικό όταν απαιτείται από την ενσωμάτωση.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Κατά την ανάθεση του `xml_as_string` ή του `xml_data`, παρέχετε έγκυρο, μη κενό XML. Χρησιμοποιήστε τη μία ή την άλλη αναπαράσταση ανάλογα με το αν η εφαρμογή εργάζεται κυρίως με συμβολοσειρές ή με δεδομένα byte.

### **Αφαίρεση Προσαρμοσμένου Μέρους XML**

Το Aspose.Slides προσφέρει διάφορους τρόπους αφαίρεσης προσαρμοσμένων δεδομένων XML:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpart/remove/) αφαιρεί το προσαρμοσμένο μέρος XML από την παρουσίαση.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpartcollection/remove/) αφαιρεί ένα συγκεκριμένο τμήμα από μια συλλογή προσαρμοσμένων μερών XML.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpartcollection/remove_at/) αφαιρεί το τμήμα σε συγκεκριμένο δείκτη συλλογής.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/el/python-net/aspose.slides/customxmlpartcollection/clear/) αφαιρεί όλα τα τμήματα από μια συγκεκριμένη συλλογή.

Το παρακάτω παράδειγμα αφαιρεί ένα προσαρμοσμένο μέρος XML επιπέδου παρουσίασης με αναφορά:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Αν έχετε ήδη ένα `CustomXmlPart` και θέλετε να το αφαιρέσετε από την παρουσίαση αντί να στοχεύσετε μια συγκεκριμένη συλλογή, καλέστε `custom_xml_part.remove()`.

Μπορείτε επίσης να αφαιρέσετε ένα στοιχείο με βάση τον δείκτη:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Καθαρισμός Όλων των Προσαρμοσμένων Μερών XML από Συλλογή**

Χρησιμοποιήστε `clear` όταν όλα τα προσαρμοσμένα μέρη XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης πρέπει να αφαιρεθούν.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

Η `clear` επηρεάζει μόνο τη επιλεγμένη συλλογή. Για παράδειγμα, ο καθαρισμός της συλλογής μιας διαφάνειας δεν καθαρίζει τις συλλογές επιπέδου παρουσίασης ή σχήματος.

Για να αφαιρέσετε κάθε προσαρμοσμένο μέρος XML στην παρουσίαση, επαναλάβετε μέσω του `all_custom_xml_parts` και αφαιρέστε κάθε τμήμα:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Διαχείριση Συνδεδεμένων ή Κοινόχρηστων Προσαρμοσμένων Μερών XML**

Σε μια παρουσίαση Office Open XML, το ίδιο προσαρμοσμένο μέρος XML μπορεί να αναφέρεται από περισσότερα από ένα αντικείμενα παρουσίασης. Για παράδειγμα, ένα υπάρχον αρχείο μπορεί να περιέχει σχέσεις από πολλαπλές διαφάνειες ή σχήματα προς το ίδιο υποκείμενο προσαρμοσμένο μέρος XML.

Ένα κοινόχρηστο τμήμα πρέπει να αντιμετωπίζεται ως ένα αντικείμενο δεδομένων με πολλαπλές αναφορές:

- Η ενημέρωση του `xml_as_string`, `xml_data` ή `item_id` αλλάζει το υποκείμενο προσαρμοσμένο μέρος XML, επομένως η αλλαγή εφαρμόζεται όπου και αν το τμήμα αναφέρεται.
- Το `item_id` μπορεί να χρησιμοποιηθεί για την ταυτοποίηση του ίδιου προσαρμοσμένου μέρους XML κατά τον έλεγχο συλλογών επιπέδου αντικειμένου.
- Η αφαίρεση ενός τμήματος από μια συγκεκριμένη συλλογή `custom_xml_parts` το αφαιρεί μόνο από εκείνη τη συλλογή. Χρησιμοποιήστε `CustomXmlPart.remove()` όταν το τμήμα ίδιο πρέπει να αφαιρεθεί από την παρουσίαση.
- Πριν διαγράψετε ή αντικαταστήσετε ένα κοινόχρηστο τμήμα, ελέγξτε τις συλλογές επιπέδου αντικειμένου για να προσδιορίσετε εάν άλλες διαφάνειες ή σχήματα το αναφέρουν ακόμη.

Οι υπερφορτώσεις της `add` δημιουργούν νέο προσαρμοσμένο μέρος XML από το περιεχόμενο XML· δεν δέχονται υπάρχον `CustomXmlPart`. Συνεπώς, οι κοινές σχέσεις εμφανίζονται κυρίως κατά τη φόρτωση παρουσιάσεων που ήδη τα περιέχουν.

Το παρακάτω παράδειγμα ελέγχει τις συλλογές επιπέδου παρουσίασης, διαφάνειας και σχήματος βάσει `item_id` και αναφέρει τα τμήματα που αναφέρονται από περισσότερα από ένα μέρη:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Αυτός ο τύπος ελέγχου είναι χρήσιμος πριν τη μεταβολή ή διαγραφή προσαρμοσμένων δεδομένων XML σε παρουσιάσεις που δημιουργήθηκαν από εξωτερικά συστήματα, επειδή το ίδιο τμήμα μεταδεδομένων μπορεί να συμμετέχει σε περισσότερες από μία σχέσεις.

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στην ιδιότητα `DocumentProperties.keywords`. Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides for Python via .NET για [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides επιτρέπει την προσθήκη ετικετών σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας, π.χ. `MyTag`;
- την τιμή της προσαρμοσμένης ιδιότητας, π.χ. `My Tag Value`.

Εάν πρέπει να κατηγοριοποιήσετε παρουσιάσεις βάσει ενός συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να προσθέσετε ετικέτες για αυτόν τον σκοπό. Για παράδειγμα, αν θέλετε να κατηγοριοποιήσετε παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα “North American” και να ορίσετε τη σχετική χώρα ως τιμή της.

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) χρησιμοποιώντας το Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Οι ετικέτες μπορούν επίσης να οριστούν για μια [Slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Ή για ένα μεμονωμένο [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής `custom_data.tags` αποθηκεύονται μόνο στο αρχείο PowerPoint. Δεν **μεταβιβάζονται** στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος ταυτοποιητής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Λύση**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο ταυτοποιητή στο **Alt Text** του αντικειμένου (π.χ. `shape.alternative_text = "MyId"`). Μετά την εξαγωγή σε PDF, το Alt Text ενδέχεται να εμφανιστεί στη δομή ετικετών PDF.

## **ΣΥΝΕΧΕΣ ΕΡΩΤΗΜΑΤΑ (FAQ)**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μία ενέργεια;**

Ναι. Η [tag collection](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/) υποστηρίζει την ενέργεια [clear](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/clear/) που διαγράφει όλα τα ζεύγη κλειδιού‑τιμής ταυτοχρόνως.

**Πώς διαγράφω μία ετικέτα με βάση το όνομά της χωρίς να περάσω όλη τη συλλογή;**

Χρησιμοποιήστε [remove(name)](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/remove/) στη [TagCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω τον πλήρη κατάλογο των ονομάτων ετικετών για ανάλυση ή φιλτράρισμα;**

Χρησιμοποιήστε [get_names_of_tags](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/get_names_of_tags/) στη [tag collection](https://reference.aspose.com/slides/el/python-net/aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.

**Πώς μπορώ να βρω όλα τα προσαρμοσμένα μέρη XML, ανεξάρτητα από το πού αποθηκεύονται;**

Χρησιμοποιήστε [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/all_custom_xml_parts/) για να ανακτήσετε όλα τα προσαρμοσμένα μέρη XML στην παρουσίαση.

**Πρέπει να χρησιμοποιήσω `xml_as_string` ή `xml_data` για την ενημέρωση ενός προσαρμοσμένου μέρους XML;**

Χρησιμοποιήστε `xml_as_string` όταν η εφαρμογή εργάζεται με κείμενο XML UTF‑8. Χρησιμοποιήστε `xml_data` όταν το XML είναι ήδη διαθέσιμο ως πίνακας byte ή όταν η επεξεργασία σε δυαδική μορφή είναι πιο βολική. Και οι δύο ιδιότητες αντιπροσωπεύουν το ίδιο περιεχόμενο XML του προσαρμοσμένου μέρους.