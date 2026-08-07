---
title: Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις με χρήση JavaScript
linktitle: Ετικέτες και Προσαρμοσμένα Δεδομένα
type: docs
weight: 300
url: /el/nodejs-java/managing-tags-and-custom-data/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε ετικέτες και προσαρμοσμένα δεδομένα XML σε παρουσιάσεις PowerPoint με το Aspose.Slides για Node.js μέσω Java, συμπεριλαμβανομένης της προσθήκης, ανάγνωσης, ενημέρωσης, ελέγχου και αφαίρεσης προσαρμοσμένων τμημάτων XML."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Τα δεδομένα που αφορούν την παρουσίαση μπορούν να αποθηκευτούν ως ετικέτες ή προσαρμοσμένα τμήματα XML. Οι ετικέτες είναι απλά ζεύγη κλειδιού‑τιμής τύπου string, ενώ τα προσαρμοσμένα τμήματα XML μπορούν να αποθηκεύουν δομημένα μεταδεδομένα και XML φορτία ειδικά για την εφαρμογή.

Το Aspose.Slides παρέχει API για προσθήκη, ανάγνωση, ενημέρωση, έλεγχο και αφαίρεση προσαρμοσμένων τμημάτων XML σε επίπεδο παρουσίασης, διαφάνειας και σχήματος. Τα προσαρμοσμένα τμήματα XML είναι χρήσιμα για ενσωματώσεις που αποθηκεύουν πληροφορίες όπως αναγνωριστικά διαχείρισης εγγράφων, κατάσταση ροής εργασίας, μεταδεδομένα συμμόρφωσης, δεδομένα σύνδεσης προτύπου ή άλλα δομημένα δεδομένα εφαρμογής μέσα σε μια παρουσίαση.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX —αρχεία με την επέκταση `.pptx`— αποθηκεύονται στην μορφή PresentationML, η οποία αποτελεί μέρος του προτύπου Office Open XML. Το Office Open XML ορίζει τη δομή του πακέτου και τις σχέσεις που χρησιμοποιούνται για την αποθήκευση του περιεχομένου της παρουσίασης και των σχετικών δεδομένων.

Μια παρουσίαση περιέχει πολλαπλά τμήματα συνδεδεμένα με σχέσεις. Για παράδειγμα, ένα τμήμα διαφάνειας περιέχει το περιεχόμενο μιας μοναδικής διαφάνειας και μπορεί να έχει ρητές σχέσεις με άλλα τμήματα που ορίζονται από το ISO/IEC 29500.

Τα προσαρμοσμένα δεδομένα μπορούν να αποθηκευτούν ως ετικέτες ([TagCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/)) ή προσαρμοσμένα τμήματα XML ([CustomXmlPartCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customxmlpartcollection/)). Και οι δύο είναι διαθέσιμες μέσω της κλάσης [`CustomData`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customdata/) .

{{% alert color="primary" %}}
Οι ετικέτες αποθηκεύουν απλά ζεύγη κλειδιού‑τιμής τύπου string. Τα προσαρμοσμένα τμήματα XML αποθηκεύουν δομημένα δεδομένα XML και μπορούν να συσχετιστούν με μια παρουσίαση, διαφάνεια ή σχήμα.
{{% /alert %}}

## **Εργασία με Προσαρμοσμένα Τμήματα XML**

Η μέθοδος `getCustomXmlParts()` της κλάσης [`CustomData`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customdata/) επιστρέφει τη συλλογή των προσαρμοσμένων τμημάτων XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης. Για παράδειγμα:

- `presentation.getCustomData().getCustomXmlParts()` περιέχει τα προσαρμοσμένα τμήματα XML που σχετίζονται με την ίδια την παρουσίαση.
- `slide.getCustomData().getCustomXmlParts()` περιέχει τα προσαρμοσμένα τμήματα XML που σχετίζονται με μια συγκεκριμένη διαφάνεια.
- `shape.getCustomData().getCustomXmlParts()` περιέχει τα προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο σχήμα.

Χρησιμοποιήστε [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) όταν χρειάζεται να εξετάσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση ανεξάρτητα από το πού είναι συσχετισμένα.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Παρουσίαση**

Χρησιμοποιήστε τη μέθοδο `add` της κλάσης [`CustomXmlPartCollection`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customxmlpartcollection/) για να προσθέσετε δεδομένα XML σε μια συλλογή προσαρμοσμένων τμημάτων XML. Το XML πρέπει να είναι έγκυρο και μη κενό.

Το παρακάτω παράδειγμα προσθέτει δομημένα μεταδεδομένα στη συλλογή προσαρμοσμένων δεδομένων επιπέδου παρουσίασης:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // Το add αναθέτει ένα αναγνωριστικό αυτόματα. Ορίστε συγκεκριμένο UUID μόνο όταν απαιτείται.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μέθοδος `add` μπορεί επίσης να δεχτεί XML ως πίνακα byte, κάτι που είναι χρήσιμο όταν το περιεχόμενο XML είναι ήδη διαθέσιμο σε δυαδική μορφή.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Διαφάνεια ή Σχήμα**

Τα προσαρμοσμένα δεδομένα XML μπορούν να συσχετιστούν με μια συγκεκριμένη διαφάνεια ή σχήμα αντί για ολόκληρη την παρουσίαση. Αυτό είναι χρήσιμο όταν τα μεταδεδομένα περιγράφουν μόνο ένα αντικείμενο, όπως κλειδί προτύπου, εξωτερικό αναγνωριστικό εγγραφής ή πληροφορίες σύνδεσης.

Το παρακάτω παράδειγμα προσθέτει ένα προσαρμοσμένο τμήμα XML σε μια διαφάνεια και ένα άλλο σε ένα σχήμα:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το επίπεδο στο οποίο προστίθεται ένα τμήμα καθορίζει η συλλογή `getCustomData().getCustomXmlParts()` ποίου αντικειμένου περιέχει τη σχέση με εκείνο το τμήμα. Τα δεδομένα επιπέδου παρουσίασης είναι κατάλληλα για μεταδεδομένα εντός ολόκληρου του εγγράφου, τα δεδομένα επιπέδου διαφάνειας για πληροφορίες που ανήκουν σε συγκεκριμένη διαφάνεια, και τα δεδομένα επιπέδου σχήματος για μεταδεδομένα που συνδέονται με ένα μεμονωμένο σχήμα.

### **Λίστα και Έλεγχος Όλων των Προσαρμοσμένων Τμημάτων XML**

Χρησιμοποιήστε [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML από μια παρουσίαση. Κάθε [`CustomXmlPart`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customxmlpart/) εκθέτει το αναγνωριστικό του, το περιεχόμενο XML και τα συσχετισμένα σχήματα ονομάτων χώρου (namespace).

Το παρακάτω παράδειγμα εμφανίζει όλα τα προσαρμοσμένα τμήματα XML και τα σχήματα ονομάτων χώρου τους:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

Η μέθοδος [`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customxmlpart/) επιστρέφει τα σχήματα XML που συσχετίζονται με το προσαρμοσμένο τμήμα XML. Αυτές οι πληροφορίες μπορεί να είναι χρήσιμες κατά τον έλεγχο παρουσιάσεων που περιέχουν XML παραγόμενο από εξωτερικά συστήματα.

### **Ανάγνωση και Ενημέρωση Περιεχομένου XML και ItemId**

Χρησιμοποιήστε `getXmlAsString()` και `setXmlAsString()` από την κλάση [`CustomXmlPart`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customxmlpart/) για εργασία με XML ως συμβολοσειρά UTF‑8, ή `getXmlData()` και `setXmlData()` για εργασία με τα ακατέργαστα byte του XML.

Η μέθοδος `getItemId()` επιστρέφει το UUID που προσδιορίζει το προσαρμοσμένο τμήμα XML στο έγγραφο Office Open XML. Χρησιμοποιήστε `setItemId()` όταν μια ενσωμάτωση απαιτεί νέο αναγνωριστικό.

Το παρακάτω παράδειγμα ενημερώνει το περιεχόμενο XML και το αναγνωριστικό:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Διαβάστε το τρέχον XML ως κείμενο.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Ενημερώστε το XML ως συμβολοσειρά UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // Το getXmlData παρέχει το ίδιο περιεχόμενο XML ως ακατέργαστα byte.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Αντικαταστήστε το αναγνωριστικό όταν απαιτείται από την ενσωμάτωση.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Κατά την κλήση `setXmlAsString` ή `setXmlData`, παρέχετε έγκυρο, μη κενό XML. Χρησιμοποιήστε τη μία ή την άλλη αναπαράσταση ανάλογα με το αν η εφαρμογή εργάζεται κυρίως με συμβολοσειρές ή με δεδομένα byte.

### **Αφαίρεση Προσαρμοσμένου Τμήματος XML**

Το Aspose.Slides παρέχει διάφορους τρόπους αφαίρεσης προσαρμοσμένων δεδομένων XML:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customxmlpart/) αφαιρεί το προσαρμοσμένο τμήμα XML από την παρουσίαση.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customxmlpartcollection/) αφαιρεί ένα συγκεκριμένο τμήμα από μια συλλογή προσαρμοσμένων τμημάτων XML.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customxmlpartcollection/) αφαιρεί το τμήμα στη συγκεκριμένη θέση της συλλογής.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/customxmlpartcollection/) αφαιρεί όλα τα τμήματα από μια συγκεκριμένη συλλογή.

Το παρακάτω παράδειγμα αφαιρεί ένα προσαρμοσμένο τμήμα XML επιπέδου παρουσίασης με αναφορά:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αν έχετε ήδη ένα `CustomXmlPart` και θέλετε να αφαιρέσετε αυτό το τμήμα από την παρουσίαση αντί να απευθυνθείτε σε συγκεκριμένη συλλογή, καλέστε `customXmlPart.remove()`.

Μπορείτε επίσης να αφαιρέσετε ένα στοιχείο με βάση το δείκτη:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Καθαρισμός Όλων των Προσαρμοσμένων Τμημάτων XML από Συλλογή**

Χρησιμοποιήστε τη μέθοδο `clear` όταν πρέπει να αφαιρεθούν όλα τα προσαρμοσμένα τμήματα XML που συσχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η `clear` επηρεάζει μόνο τη συγκεκριμένη συλλογή. Για παράδειγμα, ο καθαρισμός της συλλογής μιας διαφάνειας δεν καθαρίζει τις συλλογές επιπέδου παρουσίασης ή σχήματος.

Για να αφαιρέσετε κάθε προσαρμοσμένο τμήμα XML στην παρουσίαση, κάντε επανάληψη μέσω του `getAllCustomXmlParts()` και αφαιρέστε κάθε τμήμα:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Διαχείριση Συνδεδεμένων ή Κοινοχρηστών Προσαρμοσμένων Τμημάτων XML**

Σε μια παρουσίαση Office Open XML, το ίδιο προσαρμοσμένο τμήμα XML μπορεί να αναφέρεται από περισσότερα από ένα αντικείμενα παρουσίασης. Για παράδειγμα, ένα υπάρχον αρχείο μπορεί να περιέχει σχέσεις από πολλαπλές διαφάνειες ή σχήματα προς το ίδιο υποκείμενο τμήμα XML.

Ένα κοινόχρηστο τμήμα πρέπει να αντιμετωπίζεται ως ένα αντικείμενο δεδομένων με πολλαπλές αναφορές:

- Η ενημέρωσή του με `setXmlAsString`, `setXmlData` ή `setItemId` αλλάζει το υποκείμενο τμήμα XML, οπότε η αλλαγή ισχύει όπου και αν αναφέρεται το τμήμα.
- Η `getItemId()` μπορεί να χρησιμοποιηθεί για την ταυτοποίηση του ίδιου τμήματος XML κατά τον έλεγχο συλλογών επιπέδου αντικειμένου.
- Η αφαίρεση ενός τμήματος από μια συγκεκριμένη συλλογή `getCustomXmlParts()` το αφαιρεί μόνο από εκείνη τη συλλογή. Χρησιμοποιήστε `CustomXmlPart.remove()` όταν το τμήμα πρέπει να αφαιρεθεί από την παρουσίαση.
- Πριν διαγράψετε ή αντικαταστήσετε ένα κοινόχρηστο τμήμα, εξετάστε τις συλλογές επιπέδου αντικειμένου για να διαπιστώσετε αν άλλες διαφάνειες ή σχήματα το αναφέρονται ακόμη.

Οι υπερφορτώσεις της μεθόδου `add` δημιουργούν νέο προσαρμοσμένο τμήμα XML από περιεχόμενο XML· δεν δέχονται υπάρχον `CustomXmlPart`. Επομένως, οι κοινόχρηστες σχέσεις εμφανίζονται κυρίως όταν φορτώνετε παρουσιάσεις που τα περιέχουν ήδη.

Το παρακάτω παράδειγμα ελέγχει τις συλλογές επιπέδου παρουσίασης, διαφάνειας και σχήματος με βάση το `ItemId` και αναφέρει τα τμήματα που αναφέρονται από περισσότερα από ένα σημεία:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Αυτός ο τύπος ελέγχου είναι χρήσιμος πριν από την τροποποίηση ή διαγραφή προσαρμοσμένων δεδομένων XML σε παρουσιάσεις που δημιουργήθηκαν από εξωτερικά συστήματα, επειδή το ίδιο τμήμα μεταδεδομένων μπορεί να συμμετέχει σε περισσότερες από μία σχέσεις.

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στη μέθοδο `DocumentProperties.getKeywords()`. Αυτό το παράδειγμα κώδικα δείχνει πώς να λάβετε μια τιμή ετικέτας με το Aspose.Slides for Node.js via Java για το [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides σάς επιτρέπει να προσθέτετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας, για παράδειγμα `MyTag`;
- την τιμή της προσαρμοσμένης ιδιότητας, για παράδειγμα `My Tag Value`.

Αν χρειάζεται να ταξινομήσετε τις παρουσιάσεις βάσει συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να προσθέσετε ετικέτες για αυτόν το σκοπό. Για παράδειγμα, αν θέλετε να κατηγοριοποιήσετε παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα «North American» και να ορίσετε τη σχετική χώρα ως τιμή της.

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε ένα [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) χρησιμοποιώντας το Aspose.Slides for Node.js via Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Οι ετικέτες μπορούν επίσης να οριστούν για μια [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Ή για ένα μεμονωμένο [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής `getCustomData().getTags()` αποθηκεύονται μόνο στο αρχείο PowerPoint. Δεν μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος αναγνωριστής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Παράκαμψη**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο αναγνωριστή στο **Alt Text** του αντικειμένου (π.χ., `shape.setAlternativeText("MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text ενδέχεται να εμφανιστεί στη δομή ετικετών του PDF.

## **ΣΥΝΗΘΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μια ενέργεια;**

Ναί. Η [συλλογή ετικετών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/) υποστηρίζει τη λειτουργία [clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/) που διαγράφει όλα τα ζεύγη κλειδί‑τιμής μονομιάς.

**Πώς διαγράφω μία μόνο ετικέτα με βάση το όνομά της χωρίς να περάσω όλη τη συλλογή;**

Χρησιμοποιήστε `remove(name)` στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το συγκεκριμένο κλειδί.

**Πώς μπορώ να λάβω τη πλήρη λίστα των ονομάτων ετικετών για ανάλυση ή φιλτράρισμα;**

Χρησιμοποιήστε `getNamesOfTags()` στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/)· επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.

**Πώς μπορώ να βρω όλα τα προσαρμοσμένα τμήματα XML ανεξάρτητα από το πού είναι αποθηκευμένα;**

Χρησιμοποιήστε [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση.

**Πρέπει να χρησιμοποιήσω `getXmlAsString`/`setXmlAsString` ή `getXmlData`/`setXmlData` για την ενημέρωση ενός προσαρμοσμένου τμήματος XML;**

Χρησιμοποιήστε `getXmlAsString` και `setXmlAsString` όταν η εφαρμογή εργάζεται με κείμενο XML UTF‑8. Χρησιμοποιήστε `getXmlData` και `setXmlData` όταν το XML είναι ήδη διαθέσιμο ως πίνακας byte ή όταν η επεξεργασία σε δυαδική μορφή είναι πιο βολική. Και οι δύο αναπαραστάσεις αναφέρονται στο ίδιο περιεχόμενο XML του προσαρμοσμένου τμήματος.