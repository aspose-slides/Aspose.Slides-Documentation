---
title: Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις με Java
linktitle: Ετικέτες και Προσαρμοσμένα Δεδομένα
type: docs
weight: 300
url: /el/java/managing-tags-and-custom-data/
keywords:
- Ιδιότητες εγγράφου
- Ετικέτα
- Προσαρμοσμένα δεδομένα
- Προσαρμοσμένο XML
- Προσαρμοσμένο τμήμα XML
- Μεταδεδομένα XML
- ItemId
- προσθήκη ετικέτας
- ζευγάρια τιμών
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε ετικέτες και προσαρμοσμένα δεδομένα XML σε παρουσιάσεις PowerPoint με την Aspose.Slides για Java, συμπεριλαμβανομένης της προσθήκης, ανάγνωσης, ενημέρωσης, ελέγχου και αφαίρεσης προσαρμοσμένων τμημάτων XML."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς η Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Τα δεδομένα που αφορούν συγκεκριμένη παρουσίαση μπορούν να αποθηκευτούν ως ετικέτες ή προσαρμοσμένα τμήματα XML. Οι ετικέτες είναι απλά ζεύγη κλειδιού‑τιμής σε μορφή συμβολοσειράς, ενώ τα προσαρμοσμένα τμήματα XML μπορούν να αποθηκεύσουν δομημένα μεταδεδομένα και XML φορτία ειδικά για την εφαρμογή.

Η Aspose.Slides παρέχει API για προσθήκη, ανάγνωση, ενημέρωση, έλεγχο και αφαίρεση προσαρμοσμένων τμημάτων XML σε επίπεδο παρουσίασης, διαφάνειας και σχήματος. Τα προσαρμοσμένα τμήματα XML είναι χρήσιμα για ενσωματώσεις που αποθηκεύουν πληροφορίες όπως ταυτοποιητές διαχείρισης εγγράφων, κατάσταση ροής εργασίας, μεταδεδομένα συμμόρφωσης, δεδομένα σύνδεσης προτύπων ή άλλα δομημένα δεδομένα εφαρμογής μέσα σε μια παρουσίαση.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX —αρχεία με την επέκταση `.pptx`— αποθηκεύονται στη μορφή PresentationML, η οποία αποτελεί μέρος της προδιαγραφής Office Open XML. Το Office Open XML ορίζει τη δομή του πακέτου και τις σχέσεις που χρησιμοποιούνται για την αποθήκευση του περιεχομένου παρουσίασης και των συναφών δεδομένων.

Μια παρουσίαση περιλαμβάνει πολλαπλά τμήματα συνδεδεμένα μέσω σχέσεων. Για παράδειγμα, ένα τμήμα διαφάνειας περιέχει το περιεχόμενο μιας μόνο διαφάνειας και μπορεί να έχει ρητές σχέσεις με άλλα τμήματα όπως ορίζεται από το ISO/IEC 29500.

Τα προσαρμοσμένα δεδομένα μπορούν να αποθηκευτούν ως ετικέτες ([ITagCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITagCollection)) ή προσαρμοσμένα τμήματα XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPartCollection)). Και οι δύο είναι διαθέσιμες μέσω της διεπαφής [`ICustomData`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}
Οι ετικέτες αποθηκεύουν απλά ζεύγη κλειδί‑τιμής τύπου συμβολοσειράς. Τα προσαρμοσμένα τμήματα XML αποθηκεύουν δομημένα δεδομένα XML και μπορούν να συσχετιστούν με παρουσίαση, διαφάνεια ή σχήμα.
{{% /alert %}}

## **Εργασία με Προσαρμοσμένα Τμήματα XML**

Η μέθοδος [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomData#getCustomXmlParts--) επιστρέφει τη συλλογή των προσαρμοσμένων τμημάτων XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης. Για παράδειγμα:

- `presentation.getCustomData().getCustomXmlParts()` περιέχει προσαρμοσμένα τμήματα XML συνδεδεμένα με την ίδια την παρουσίαση.
- `slide.getCustomData().getCustomXmlParts()` περιέχει προσαρμοσμένα τμήματα XML συνδεδεμένα με μια συγκεκριμένη διαφάνεια.
- `shape.getCustomData().getCustomXmlParts()` περιέχει προσαρμοσμένα τμήματα XML συνδεδεμένα με ένα συγκεκριμένο σχήμα.

Χρησιμοποιήστε τη μέθοδο [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) όταν χρειάζεται να ελέγξετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση, ανεξάρτητα από το πού είναι συνδεδεμένα.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Παρουσίαση**

Χρησιμοποιήστε το [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) για να προσθέσετε δεδομένα XML σε μια συλλογή προσαρμοσμένων τμημάτων XML. Το XML πρέπει να είναι έγκυρο και μη κενό.

Το παρακάτω παράδειγμα προσθέτει δομημένα μεταδεδομένα στη συλλογή προσαρμοσμένων δεδομένων επιπέδου παρουσίασης:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // Η add εκχωρεί ένα αναγνωριστικό αυτόματα. Ορίστε ένα συγκεκριμένο UUID μόνο όταν απαιτείται.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μέθοδος `add` μπορεί επίσης να δέχεται XML ως πίνακα byte ή ροή εισόδου, κάτι που είναι χρήσιμο όταν το περιεχόμενο XML είναι ήδη διαθέσιμο σε δυαδική μορφή.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Διαφάνεια ή Σχήμα**

Τα προσαρμοσμένα δεδομένα XML μπορούν να συσχετιστούν με μια συγκεκριμένη διαφάνεια ή σχήμα αντί για ολόκληρη την παρουσίαση. Αυτό είναι χρήσιμο όταν τα μεταδεδομένα περιγράφουν μόνο ένα αντικείμενο, π.χ. ένα κλειδί προτύπου, εξωτερικό ταυτοποιητή εγγραφής ή πληροφορίες σύνδεσης.

Το παρακάτω παράδειγμα προσθέτει ένα προσαρμοσμένο τμήμα XML σε μια διαφάνεια και ένα ακόμη σε ένα σχήμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το επίπεδο στο οποίο προστίθεται ένα τμήμα καθορίζει ποια συλλογή `getCustomData().getCustomXmlParts()` του αντικειμένου περιέχει τη σχέση προς το τμήμα. Τα δεδομένα επιπέδου παρουσίασης είναι κατάλληλα για μεταδεδομένα εγγράφου, τα δεδομένα επιπέδου διαφάνειας για πληροφορίες που ανήκουν σε συγκεκριμένη διαφάνεια, και τα δεδομένα επιπέδου σχήματος για μεταδεδομένα που συνδέονται με μεμονωμένο σχήμα.

### **Λίστα και Έλεγχος Όλων των Προσαρμοσμένων Τμημάτων XML**

Χρησιμοποιήστε τη μέθοδο [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML από μια παρουσίαση. Κάθε [`ICustomXmlPart`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart/) αποκαλύπτει το αναγνωριστικό του, το περιεχόμενο XML και τα συνδεδεμένα σχήματα χώρου ονομάτων.

Το παρακάτω παράδειγμα καταχωρίζει όλα τα προσαρμοσμένα τμήματα XML και τα σχήματα χώρου ονομάτων τους:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Η μέθοδος [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) επιστρέφει τα σχήματα XML που σχετίζονται με το προσαρμοσμένο τμήμα XML. Αυτή η πληροφορία μπορεί να είναι χρήσιμη κατά τον έλεγχο παρουσιάσεων που περιέχουν XML παραγόμενο από εξωτερικά συστήματα.

### **Ανάγνωση και Ενημέρωση Περιεχομένου XML και ItemId**

Χρησιμοποιήστε τις μεθόδους [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) και [`setXmlAsString()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) για εργασία με XML ως συμβολοσειρά UTF‑8, ή τις μεθόδους [`getXmlData()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#getXmlData--) και [`setXmlData()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) για εργασία με τα ακατέργαστα byte του XML.

Η μέθοδος [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#getItemId--) επιστρέφει το UUID που ταυτοποιεί το προσαρμοσμένο τμήμα XML στο έγγραφο Office Open XML. Χρησιμοποιήστε τη μέθοδο [`setItemId()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) όταν μια ενσωμάτωση απαιτεί νέο αναγνωριστικό.

Το παρακάτω παράδειγμα ενημερώνει το περιεχόμενο XML και το αναγνωριστικό:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Διαβάστε το τρέχον XML ως κείμενο.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Ενημερώστε το XML ως συμβολοσειρά UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // Το getXmlData παρέχει το ίδιο περιεχόμενο XML ως ακατέργαστα byte.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Αντικαταστήστε το αναγνωριστικό όταν απαιτείται από την ενσωμάτωση.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Κατά την κλήση `setXmlAsString` ή `setXmlData`, παρέχετε έγκυρο, μη κενό XML. Επιλέξτε την αναπαράσταση που ταιριάζει στον τρόπο που η εφαρμογή σας εργάζεται, είτε με συμβολοσειρές είτε με byte δεδομένα.

### **Αφαίρεση Προσαρμοσμένου Τμήματος XML**

Η Aspose.Slides παρέχει διάφορους τρόπους αφαίρεσης προσαρμοσμένων δεδομένων XML:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#remove--) αφαιρεί το προσαρμοσμένο τμήμα XML από την παρουσίαση.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) αφαιρεί ένα συγκεκριμένο τμήμα από μια συλλογή προσαρμοσμένων τμημάτων XML.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) αφαιρεί το τμήμα στη συγκεκριμένη θέση του δείκτη της συλλογής.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPartCollection#clear--) αφαιρεί όλα τα τμήματα από μια συγκεκριμένη συλλογή.

Το παρακάτω παράδειγμα αφαιρεί ένα προσαρμοσμένο τμήμα XML επιπέδου παρουσίασης με αναφορά:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Εάν διαθέτετε ήδη ένα αντικείμενο `ICustomXmlPart` και θέλετε να αφαιρέσετε αυτό το τμήμα από την παρουσίαση αντί να απευθυνθείτε σε συγκεκριμένη συλλογή, καλέστε `customXmlPart.remove()`.

Μπορείτε επίσης να αφαιρέσετε ένα στοιχείο με βάση το δείκτη:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Καθαρισμός Όλων των Προσαρμοσμένων Τμημάτων XML από Συλλογή**

Χρησιμοποιήστε τη μέθοδο `clear` όταν πρέπει να αφαιρεθούν όλα τα προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η `clear` επηρεάζει μόνο τη συγκεκριμένη συλλογή. Για παράδειγμα, ο καθαρισμός της συλλογής μιας διαφάνειας δεν καθαρίζει τις συλλογές επιπέδου παρουσίασης ή σχήματος.

Για να αφαιρέσετε κάθε προσαρμοσμένο τμήμα XML στην παρουσίαση, επαναλάβετε τη μέθοδο `getAllCustomXmlParts()` και αφαιρέστε κάθε τμήμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Διαχείριση Συνδεδεμένων ή Κοινόχρηστων Προσαρμοσμένων Τμημάτων XML**

Σε μια παρουσίαση Office Open XML, το ίδιο προσαρμοσμένο τμήμα XML μπορεί να αναφέρεται από περισσότερα από ένα αντικείμενα παρουσίασης. Για παράδειγμα, ένα υπάρχον αρχείο μπορεί να περιέχει σχέσεις από πολλαπλές διαφάνειες ή σχήματα προς το ίδιο υποκείμενο προσαρμοσμένο τμήμα XML.

Ένα κοινόχρηστο τμήμα πρέπει να θεωρείται ως ένα αντικείμενο δεδομένων με πολλαπλές αναφορές:

- Η ενημέρωσή του με `setXmlAsString`, `setXmlData` ή `setItemId` αλλάζει το υποκείμενο τμήμα XML, έτσι η αλλαγή εφαρμόζεται όπου και αν αναφέρεται το τμήμα.
- Η μέθοδος `getItemId()` μπορεί να χρησιμοποιηθεί για τον εντοπισμό του ίδιου τμήματος XML κατά τον έλεγχο συλλογών επιπέδου αντικειμένου.
- Η αφαίρεση ενός τμήματος από μια συγκεκριμένη συλλογή `getCustomXmlParts()` το αφαιρεί από εκείνη τη συλλογή. Χρησιμοποιήστε `ICustomXmlPart.remove()` όταν το τμήμα πρέπει να αφαιρεθεί ολοκληρωτικά από την παρουσίαση.
- Πριν διαγράψετε ή αντικαταστήσετε ένα κοινόχρηστο τμήμα, εξετάστε τις συλλογές επιπέδου αντικειμένου για να διαπιστώσετε εάν άλλες διαφάνειες ή σχήματα το αναφέρονται ακόμη.

Οι υπερφορτώσεις της μεθόδου `add` δημιουργούν νέο προσαρμοσμένο τμήμα XML από περιεχόμενο XML· δεν δέχονται υπάρχον `ICustomXmlPart`. Συνεπώς, οι κοινόχρηστες σχέσεις εμφανίζονται κυρίως όταν φορτώνετε παρουσιάσεις που τα περιέχουν ήδη.

Το παρακάτω παράδειγμα ελέγχει τις συλλογές επιπέδου παρουσίασης, διαφάνειας και σχήματος βάσει `ItemId` και αναφέρει τμήματα που αναφέρονται από περισσότερα από ένα σημεία:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Αυτός ο τύπος ελέγχου είναι χρήσιμος πριν από τροποποίηση ή διαγραφή προσαρμοσμένων δεδομένων XML σε παρουσιάσεις που δημιουργήθηκαν από εξωτερικά συστήματα, επειδή το ίδιο τμήμα μεταδεδομένων μπορεί να συμμετέχει σε περισσότερες από μία σχέσεις.

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στη μέθοδο `IDocumentProperties.getKeywords()`. Αυτό το παράδειγμα κώδικα δείχνει πώς να λάβετε την τιμή μίας ετικέτας με την Aspose.Slides for Java για [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Η Aspose.Slides σας επιτρέπει να προσθέσετε ετικέτες σε παρουσιάσεις. Μία ετικέτα αποτελείται συνήθως από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας, π.χ. `MyTag`;
- την τιμή της προσαρμοσμένης ιδιότητας, π.χ. `My Tag Value`.

Εάν χρειάζεται να ταξινομήσετε τις παρουσιάσεις βάσει συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να προσθέσετε ετικέτες για αυτόν τον σκοπό. Για παράδειγμα, αν θέλετε να κατηγοριοποιήσετε παρουσιάσεις από χώρες της Βόρειας Αμερικής, δημιουργήστε μια ετικέτα “NorthAmerican” και ορίστε τη σχετική χώρα ως τιμή της.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) χρησιμοποιώντας την Aspose.Slides for Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Οι ετικέτες μπορούν επίσης να οριστούν για μια [Slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Ή για ένα μεμονωμένο [Shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής `getCustomData().getTags()` αποθηκεύονται μόνο στο αρχείο PowerPoint. **Δεν** μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξαχθεί σε PDF. Συνεπώς, ένας προσαρμοσμένος ταυτοποιητής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Παράκαμψη**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο ταυτοποιητή στο **Alt Text** του αντικειμένου (π.χ. `shape.setAlternativeText("MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών του PDF.

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μία ενέργεια;**

Ναι. Η συλλογή ετικετών ([tag collection](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/)) υποστηρίζει τη λειτουργία [clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/#clear--) η οποία διαγράφει όλα τα ζεύγη κλειδί‑τιμής μονομιάς.

**Πώς διαγράφω μία συγκεκριμένη ετικέτα με βάση το όνομά της χωρίς να διασχίζω ολόκληρη τη συλλογή;**

Χρησιμοποιήστε τη μέθοδο [remove(name)](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα βάσει του κλειδιού της.

**Πώς μπορώ να ανακτήσω την πλήρη λίστα των ονομάτων ετικετών για ανάλυση ή φιλτράρισμα;**

Χρησιμοποιήστε τη μέθοδο [getNamesOfTags](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/#getNamesOfTags--) στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.

**Πώς μπορώ να βρω όλα τα προσαρμοσμένα τμήματα XML ανεξάρτητα από το πού είναι αποθηκευμένα;**

Χρησιμοποιήστε τη μέθοδο [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση.

**Πρέπει να χρησιμοποιήσω `getXmlAsString`/`setXmlAsString` ή `getXmlData`/`setXmlData` για την ενημέρωση ενός προσαρμοσμένου τμήματος XML;**

Χρησιμοποιήστε `getXmlAsString` και `setXmlAsString` όταν η εφαρμογή εργάζεται με κείμενο XML UTF‑8. Χρησιμοποιήστε `getXmlData` και `setXmlData` όταν το XML είναι ήδη διαθέσιμο ως πίνακας byte ή όταν η επεξεργασία σε δυαδική μορφή είναι πιο βολική. Και οι δύο αναπαραστάσεις αναφέρονται στο ίδιο περιεχόμενο XML του προσαρμοσμένου τμήματος.