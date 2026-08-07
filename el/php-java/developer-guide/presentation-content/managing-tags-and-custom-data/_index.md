---
title: Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις με PHP
linktitle: Ετικέτες και Προσαρμοσμένα Δεδομένα
type: docs
weight: 300
url: /el/php-java/managing-tags-and-custom-data/
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
- PHP
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε ετικέτες και προσαρμοσμένα δεδομένα XML σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java, συμπεριλαμβανομένης της προσθήκης, ανάγνωσης, ενημέρωσης, ελέγχου και κατάργησης προσαρμοσμένων τμημάτων XML."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Τα δεδομένα που αφορούν συγκεκριμένα την παρουσίαση μπορούν να αποθηκευτούν ως ετικέτες ή προσαρμοσμένα τμήματα XML. Οι ετικέτες είναι απλά ζεύγη κλειδιού‑τιμής τύπου συμβολοσειράς, ενώ τα προσαρμοσμένα τμήματα XML μπορούν να αποθηκεύσουν δομημένα μεταδεδομένα και XML φορτία ειδικά για την εφαρμογή.

Aspose.Slides παρέχει API για προσθήκη, ανάγνωση, ενημέρωση, έλεγχο και κατάργηση προσαρμοσμένων τμημάτων XML στα επίπεδα παρουσίασης, διαφάνειας και σχήματος. Τα προσαρμοσμένα τμήματα XML είναι χρήσιμα για ενσωματώσεις που αποθηκεύουν πληροφορίες όπως αναγνωριστικά διαχείρισης εγγράφων, κατάσταση ροής εργασίας, μεταδεδομένα συμμόρφωσης, δεδομένα σύνδεσης προτύπου ή άλλα δομημένα δεδομένα εφαρμογής εντός μιας παρουσίασης.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX — αρχεία με την επέκταση `.pptx` — αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος της προδιαγραφής Office Open XML. Το Office Open XML ορίζει τη δομή του πακέτου και τις σχέσεις που χρησιμοποιούνται για την αποθήκευση του περιεχομένου της παρουσίασης και των σχετικών δεδομένων.

Μια παρουσίαση περιέχει πολλαπλά τμήματα συνδεδεμένα μέσω σχέσεων. Για παράδειγμα, ένα τμήμα διαφάνειας περιλαμβάνει το περιεχόμενο μιας μόνο διαφάνειας και μπορεί να έχει σαφείς σχέσεις με άλλα τμήματα όπως ορίζεται από το ISO/IEC 29500.

Τα προσαρμοσμένα δεδομένα μπορούν να αποθηκευτούν ως ετικέτες ([TagCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/)) ή ως προσαρμοσμένα τμήματα XML ([CustomXmlPartCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpartcollection/)). Και τα δύο είναι διαθέσιμα μέσω της κλάσης [`CustomData`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customdata/) .

{{% alert color="primary" %}}
Οι ετικέτες αποθηκεύουν απλά ζεύγη κλειδιού‑τιμής τύπου συμβολοσειράς. Τα προσαρμοσμένα τμήματα XML αποθηκεύουν δομημένα δεδομένα XML και μπορούν να συνδεθούν με μια παρουσίαση, μια διαφάνεια ή ένα σχήμα.
{{% /alert %}}

## **Εργασία με Προσαρμοσμένα Τμήματα XML**

Η μέθοδος [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customdata/#getCustomXmlParts) επιστρέφει τη συλλογή των προσαρμοσμένων τμημάτων XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης. Για παράδειγμα:

- `$presentation->getCustomData()->getCustomXmlParts()` περιέχει τα προσαρμοσμένα τμήματα XML που σχετίζονται με την ίδια την παρουσίαση.  
- `$slide->getCustomData()->getCustomXmlParts()` περιέχει τα προσαρμοσμένα τμήματα XML που σχετίζονται με μια συγκεκριμένη διαφάνεια.  
- `$shape->getCustomData()->getCustomXmlParts()` περιέχει τα προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο σχήμα.

Χρησιμοποιήστε [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getAllCustomXmlParts) όταν χρειάζεται να εξετάσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση, ανεξάρτητα από το πού είναι συσχετισμένα.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Παρουσίαση**

Χρησιμοποιήστε [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpartcollection/#add) για να προσθέσετε δεδομένα XML στη συλλογή προσαρμοσμένων τμημάτων XML. Το XML πρέπει να είναι έγκυρο και μη κενό.

Το παρακάτω παράδειγμα προσθέτει δομημένα μεταδεδομένα στη συλλογή προσαρμοσμένων δεδομένων επιπέδου παρουσίασης:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add αναθέτει ένα αναγνωριστικό αυτόματα. Ορίστε ένα συγκεκριμένο UUID μόνο όταν απαιτείται.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η μέθοδος `add` μπορεί επίσης να δεχτεί XML ως πίνακα byte ή ροή εισόδου, κάτι που είναι χρήσιμο όταν το περιεχόμενο XML είναι ήδη διαθέσιμο σε δυαδική μορφή.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Διαφάνεια ή Σχήμα**

Τα προσαρμοσμένα δεδομένα XML μπορούν να συνδεθούν με μια συγκεκριμένη διαφάνεια ή σχήμα αντί για ολόκληρη την παρουσίαση. Αυτό είναι χρήσιμο όταν τα μεταδεδομένα περιγράφουν μόνο ένα αντικείμενο, όπως κλειδί προτύπου, εξωτερικό αναγνωριστικό εγγραφής ή πληροφορίες σύνδεσης.

Το παρακάτω παράδειγμα προσθέτει ένα προσαρμοσμένο τμήμα XML σε μια διαφάνεια και ένα άλλο σε ένα σχήμα:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το επίπεδο στο οποίο προστίθεται ένα τμήμα καθορίζει ποια συλλογή `getCustomData()->getCustomXmlParts()` περιέχει τη σχέση προς το τμήμα. Τα δεδομένα επιπέδου παρουσίασης είναι κατάλληλα για μεταδεδομένα εγγράφου, τα δεδομένα επιπέδου διαφάνειας για πληροφορίες που ανήκουν σε συγκεκριμένη διαφάνεια, και τα δεδομένα επιπέδου σχήματος για μεταδεδομένα που σχετίζονται με ένα μεμονωμένο σχήμα.

### **Λίστα και Έλεγχος Όλων των Προσαρμοσμένων Τμημάτων XML**

Χρησιμοποιήστε [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getAllCustomXmlParts) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML από μια παρουσίαση. Κάθε [`CustomXmlPart`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpart/) εμφανίζει το αναγνωριστικό του, το περιεχόμενο XML και τα συνδεδεμένα σχήματα ονομάτων χώρου.

Το παρακάτω παράδειγμα εμφανίζει όλα τα προσαρμοσμένα τμήματα XML και τα σχήματα ονομάτων χώρου τους:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Η μέθοδος [`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) επιστρέφει τα σχήματα XML που σχετίζονται με το προσαρμοσμένο τμήμα XML. Αυτές οι πληροφορίες μπορούν να είναι χρήσιμες κατά τον έλεγχο παρουσιάσεων που περιέχουν XML παραγόμενο από εξωτερικά συστήματα.

### **Ανάγνωση και Ενημέρωση Περιεχομένου XML και ItemId**

Χρησιμοποιήστε [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpart/#getXmlAsString) και [`setXmlAsString()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpart/#setXmlAsString) για εργασία με XML ως συμβολοσειρά UTF‑8, ή [`getXmlData()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpart/#getXmlData) και [`setXmlData()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpart/#setXmlData) για εργασία με τα ακατέργαστα byte XML.

Η μέθοδος [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpart/#getItemId) επιστρέφει το UUID που ταυτοποιεί το προσαρμοσμένο τμήμα XML στο έγγραφο Office Open XML. Χρησιμοποιήστε [`setItemId()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpart/#setItemId) όταν μια ενσωμάτωση απαιτεί νέο αναγνωριστικό.

Το παρακάτω παράδειγμα ενημερώνει το περιεχόμενο XML και το αναγνωριστικό:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Διαβάστε το τρέχον XML ως κείμενο.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Ενημερώστε το XML ως συμβολοσειρά UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // Η μέθοδος getXmlData παρέχει το ίδιο περιεχόμενο XML ως ακατέργαστα bytes.
    $customXmlData = $customXmlPart->getXmlData();

    // Αντικαταστήστε το αναγνωριστικό όταν απαιτείται από την ενσωμάτωση.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Κατά την κλήση του `setXmlAsString` ή `setXmlData`, παρέχετε έγκυρο, μη κενό XML. Χρησιμοποιήστε την μία ή την άλλη αναπαράσταση ανάλογα με το αν η εφαρμογή λειτουργεί κυρίως με συμβολοσειρές ή με byte δεδομένα.

### **Κατάργηση Προσαρμοσμένου Τμήματος XML**

Το Aspose.Slides παρέχει διάφορους τρόπους για την κατάργηση προσαρμοσμένων δεδομένων XML:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpart/#remove) καταργεί το προσαρμοσμένο τμήμα XML από την παρουσίαση.  
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpartcollection/#remove) καταργεί ένα συγκεκριμένο τμήμα από μια συλλογή προσαρμοσμένων τμημάτων XML.  
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpartcollection/#removeAt) καταργεί το τμήμα στη συγκεκριμένη θέση της συλλογής.  
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/el/php-java/aspose.slides/customxmlpartcollection/#clear) καταργεί όλα τα τμήματα από μια συγκεκριμένη συλλογή.

Το παρακάτω παράδειγμα καταργεί ένα προσαρμοσμένο τμήμα XML επιπέδου παρουσίασης με αναφορά:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αν έχετε ήδη ένα αντικείμενο `CustomXmlPart` και θέλετε να το καταργήσετε από την παρουσίαση αντί να στοχεύσετε μια συγκεκριμένη συλλογή, καλέστε `$customXmlPart->remove()`.

Μπορείτε επίσης να καταργήσετε ένα στοιχείο κατά θέση:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Καθαρισμός Όλων των Προσαρμοσμένων Τμημάτων XML από Συλλογή**

Χρησιμοποιήστε `clear` όταν πρέπει να αφαιρεθούν όλα τα προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το `clear` επηρεάζει μόνο τη συλλογή που επιλέχθηκε. Για παράδειγμα, ο καθαρισμός της συλλογής μιας διαφάνειας δεν καθαρίζει τις συλλογές επιπέδου παρουσίασης ή σχήματος.

Για να αφαιρέσετε κάθε προσαρμοσμένο τμήμα XML στην παρουσίαση, κάντε επανάληψη μέσω του `getAllCustomXmlParts()` και καταργήστε κάθε τμήμα:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Διαχείριση Συνδεδεμένων ή Κοινόχρηστων Προσαρμοσμένων Τμημάτων XML**

Σε μια παρουσίαση Office Open XML, το ίδιο προσαρμοσμένο τμήμα XML μπορεί να αναφέρεται από περισσότερα από ένα αντικείμενα παρουσίασης. Για παράδειγμα, ένα υπάρχον αρχείο μπορεί να περιέχει σχέσεις από πολλές διαφάνειες ή σχήματα προς το ίδιο υποκείμενο τμήμα XML.

Ένα κοινόχρηστο τμήμα πρέπει να θεωρείται ως ένα αντικείμενο δεδομένων με πολλαπλές αναφορές:

- Η ενημέρωσή του με `setXmlAsString`, `setXmlData` ή `setItemId` αλλάζει το υποκείμενο τμήμα XML, επομένως η αλλαγή ισχύει όπουδήποτε το τμήμα αναφέρεται.  
- Το `getItemId()` μπορεί να χρησιμοποιηθεί για την ταυτοποίηση του ίδιου τμήματος XML κατά τον έλεγχο συλλογών επιπέδου αντικειμένου.  
- Η κατάργηση ενός τμήματος από μια συγκεκριμένη συλλογή `getCustomXmlParts()` το αφαιρεί μόνο από εκείνη τη συλλογή. Χρησιμοποιήστε `CustomXmlPart::remove()` όταν το ίδιο το τμήμα πρέπει να αφαιρεθεί από την παρουσίαση.  
- Πριν διαγράψετε ή αντικαταστήσετε ένα κοινόχρηστο τμήμα, ελέγξτε τις συλλογές επιπέδου αντικειμένου για να διαπιστώσετε αν άλλες διαφάνειες ή σχήματα το αναφέρουν ακόμη.

Οι υπερφορτώσεις της `add` δημιουργούν ένα νέο προσαρμοσμένο τμήμα XML από περιεχόμενο XML· δεν δέχονται υπάρχον `CustomXmlPart`. Έτσι, οι κοινόχρηστες σχέσεις εμφανίζονται κυρίως όταν φορτώνετε παρουσιάσεις που τα περιέχουν ήδη.

Το παρακάτω παράδειγμα ελέγχει συλλογές επιπέδου παρουσίασης, διαφάνειας και σχήματος κατά `ItemId` και αναφέρει τμήματα που αναφέρονται από περισσότερα από ένα μέρη:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Αυτός ο τύπος ελέγχου είναι χρήσιμος πριν από τροποποίηση ή διαγραφή προσαρμοσμένων δεδομένων XML σε παρουσιάσεις που δημιουργήθηκαν από εξωτερικά συστήματα, επειδή το ίδιο τμήμα μεταδεδομένων μπορεί να συμμετέχει σε περισσότερες από μία σχέσεις.

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στη μέθοδο `DocumentProperties::getKeywords()`. Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με Aspose.Slides για PHP μέσω Java για [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides σας επιτρέπει να προσθέσετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας, π.χ. `MyTag`;  
- την τιμή της προσαρμοσμένης ιδιότητας, π.χ. `My Tag Value`.

Αν χρειάζεται να ταξινομήσετε παρουσιάσεις βάσει ενός συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να προσθέσετε ετικέτες για αυτόν τον σκοπό. Για παράδειγμα, αν θέλετε να κατηγοριοποιήσετε παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα “NorthAmerican” και να ορίσετε τη σχετική χώρα ως τιμή της.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε ένα [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Οι ετικέτες μπορούν επίσης να οριστούν για ένα [Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/) :

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Ή για ένα μεμονωμένο [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) :

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής `getCustomData()->getTags()` αποθηκεύονται μόνο στο αρχείο PowerPoint. Δεν **μεταφέρονται** στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος αναγνωριστικός που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Λύση**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο αναγνωριστικό στο **Alt Text** του αντικειμένου (π.χ. `$shape->setAlternativeText("MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών του PDF.

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μία λειτουργία;**

Ναί. Η [tag collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/) υποστηρίζει τη λειτουργία [clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/#clear) που διαγράφει όλα τα ζεύγη κλειδί‑τιμής ταυτόχρονα.

**Πώς διαγράφω μια μόνο ετικέτα με βάση το όνομά της χωρίς να διατρέχω ολόκληρη τη συλλογή;**

Χρησιμοποιήστε [remove(name)](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/#remove) στη [tag collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω τη πλήρη λίστα των ονομάτων ετικετών για ανάλυση ή φιλτράρισμα;**

Χρησιμοποιήστε [getNamesOfTags](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/#getNamesOfTags) στη [tag collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/tagcollection/)· επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.

**Πώς μπορώ να βρω όλα τα προσαρμοσμένα τμήματα XML ανεξάρτητα από το πού είναι αποθηκευμένα;**

Χρησιμοποιήστε [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getAllCustomXmlParts) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση.

**Θα πρέπει να χρησιμοποιήσω `getXmlAsString`/`setXmlAsString` ή `getXmlData`/`setXmlData` για την ενημέρωση ενός προσαρμοσμένου τμήματος XML;**

Χρησιμοποιήστε `getXmlAsString` και `setXmlAsString` όταν η εφαρμογή εργάζεται με κείμενο XML UTF‑8. Χρησιμοποιήστε `getXmlData` και `setXmlData` όταν το XML είναι ήδη διαθέσιμο ως πίνακας byte ή όταν είναι πιο βολική η διεκπεραίωση σε δυαδική μορφή. Και οι δύο αναπαραστάσεις αναφέρονται στο ίδιο περιεχόμενο XML του τμήματος.