---
title: Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις με Java
linktitle: Ετικέτες και Προσαρμοσμένα Δεδομένα
type: docs
weight: 300
url: /el/java/managing-tags-and-custom-data/
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
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε ετικέτες και προσαρμοσμένα δεδομένα XML σε παρουσιάσεις PowerPoint με το Aspose.Slides για Java, συμπεριλαμβανομένης της προσθήκης, ανάγνωσης, ενημέρωσης, ελεγκτικής επιθεώρησης και αφαίρεσης προσαρμοσμένων τμημάτων XML."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Τα δεδομένα συγκεκριμένα για μια παρουσίαση μπορούν να αποθηκευτούν ως ετικέτες ή προσαρμοσμένα τμήματα XML. Οι ετικέτες είναι απλά ζεύγη κλειδιού‑τιμής ως συμβολοσειρές, ενώ τα προσαρμοσμένα τμήματα XML μπορούν να αποθηκεύουν δομημένα μεταδεδομένα και φορτία XML ειδικά για την εφαρμογή.

Το Aspose.Slides παρέχει API για προσθήκη, ανάγνωση, ενημέρωση, ελεγκτικές λειτουργίες και αφαίρεση προσαρμοσμένων τμημάτων XML σε επίπεδο παρουσίασης, διαφάνειας και σχήματος. Τα προσαρμοσμένα τμήματα XML είναι χρήσιμα για ενσωματώσεις που αποθηκεύουν πληροφορίες όπως αναγνωριστικά διαχείρισης εγγράφων, κατάσταση ροής εργασίας, μεταδεδομένα συμμόρφωσης, δεδομένα σύνδεσης προτύπου ή άλλα δομημένα δεδομένα εφαρμογής μέσα σε μια παρουσίαση.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX — αρχεία με την επέκταση `.pptx` — αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος της προδιαγραφής Office Open XML. Το Office Open XML καθορίζει τη δομή του πακέτου και τις σχέσεις που χρησιμοποιούνται για την αποθήκευση του περιεχομένου της παρουσίασης και των σχετικών δεδομένων.

Μια παρουσίαση περιέχει πολλαπλά τμήματα συνδεδεμένα μέσω σχέσεων. Για παράδειγμα, ένα τμήμα διαφάνειας περιέχει το περιεχόμενο μιας μοναδικής διαφάνειας και μπορεί να έχει ρητές σχέσεις με άλλα τμήματα σύμφωνα με το ISO/IEC 29500.

Τα προσαρμοσμένα δεδομένα μπορούν να αποθηκευτούν ως ετικέτες ([ITagCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITagCollection)) ή προσαρμοσμένα τμήματα XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPartCollection)). Και τα δύο διατίθενται μέσω της διεπαφής [`ICustomData`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomData/) .

{{% alert color="info" %}}
Οι ετικέτες αποθηκεύουν απλά ζεύγη κλειδιού‑τιμής ως συμβολοσειρές. Τα προσαρμοσμένα τμήματα XML αποθηκεύουν δομημένα δεδομένα XML και μπορούν να συσχετιστούν με μια παρουσίαση, διαφάνεια ή σχήμα.
{{% /alert %}}

## **Δουλειά με Προσαρμοσμένα Τμήματα XML**

Η μέθοδος [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomData#getCustomXmlParts--) επιστρέφει τη συλλογή των προσαρμοσμένων τμημάτων XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης. Για παράδειγμα:

- `presentation.getCustomData().getCustomXmlParts()` περιέχει τα προσαρμοσμένα τμήματα XML που σχετίζονται με την ίδια την παρουσίαση.
- `slide.getCustomData().getCustomXmlParts()` περιέχει τα προσαρμοσμένα τμήματα XML που σχετίζονται με μια συγκεκριμένη διαφάνεια.
- `shape.getCustomData().getCustomXmlParts()` περιέχει τα προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο σχήμα.

Χρησιμοποιήστε την μέθοδο [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) όταν χρειάζεται να εξετάσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση, ανεξάρτητα από το πού είναι συσχετισμένα.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Παρουσίαση**

Χρησιμοποιήστε τη μέθοδο [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) για να προσθέσετε δεδομένα XML σε μια συλλογή προσαρμοσμένων τμημάτων XML. Το XML πρέπει να είναι έγκυρο και μη κενό.

Το ακόλουθο παράδειγμα προσθέτει δομημένα μεταδεδομένα στη συλλογή προσαρμοσμένων δεδομένων επιπέδου παρουσίασης:

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

    // η προσθήκη εκχωρεί ένα αναγνωριστικό αυτόματα. Ορίστε ένα συγκεκριμένο UUID μόνο όταν απαιτείται.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μέθοδος `add` μπορεί επίσης να δεχτεί XML ως πίνακα byte ή ροή εισόδου, κάτι που είναι χρήσιμο όταν το περιεχόμενο XML είναι ήδη διαθέσιμο σε δυαδική μορφή.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Διαφάνεια ή Σχήμα**

Τα προσαρμοσμένα δεδομένα XML μπορούν να συσχετιστούν με μια συγκεκριμένη διαφάνεια ή σχήμα αντί για ολόκληρη την παρουσίαση. Αυτό είναι χρήσιμο όταν τα μεταδεδομένα περιγράφουν μόνο ένα αντικείμενο, όπως ένα κλειδί προτύπου, εξωτερικό αναγνωριστικό εγγραφής ή πληροφορίες σύνδεσης.

Το ακόλουθο παράδειγμα προσθέτει ένα προσαρμοσμένο τμήμα XML σε μια διαφάνεια και ένα άλλο σε ένα σχήμα:

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

Το επίπεδο στο οποίο προστίθεται ένα τμήμα καθορίζει ποια συλλογή `getCustomData().getCustomXmlParts()` του αντικειμένου περιέχει τη σχέση με το τμήμα. Τα δεδομένα επιπέδου παρουσίασης είναι κατάλληλα για μεταδεδομένα ολόκληρου του εγγράφου, τα δεδομένα επιπέδου διαφάνειας για πληροφορίες που ανήκουν σε συγκεκριμένη διαφάνεια, και τα δεδομένα επιπέδου σχήματος για μεταδεδομένα που συνδέονται με ένα μεμονωμένο σχήμα.

### **Καταγραφή και Ελεγκτική Επιθεώρηση Όλων των Προσαρμοσμένων Τμημάτων XML**

Χρησιμοποιήστε τη μέθοδο [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) για την ανάκτηση όλων των προσαρμοσμένων τμημάτων XML από μια παρουσίαση. Κάθε [`ICustomXmlPart`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart/) αποκαλύπτει το αναγνωριστικό του, το περιεχόμενο XML και τα συναφή σχήματα ονομάτων χώρου.

Το ακόλουθο παράδειγμα καταγράφει όλα τα προσαρμοσμένα τμήματα XML και τα σχήματα ονομάτων χώρου τους:

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

Η μέθοδος `ICustomXmlPart.getNamespaceSchemas()` επιστρέφει τα σχήματα XML που σχετίζονται με το προσαρμοσμένο τμήμα XML. Αυτές οι πληροφορίες μπορούν να είναι χρήσιμες κατά την ελεγκτική επιθεώρηση παρουσιάσεων που περιέχουν XML που παράχθηκε από εξωτερικά συστήματα.

### **Ανάγνωση και Ενημέρωση Περιεχομένου XML και ItemId**

Χρησιμοποιήστε τις μεθόδους [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) και [`setXmlAsString()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) για εργασία με XML ως συμβολοσειρά UTF‑8, ή τις [`getXmlData()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#getXmlData--) και [`setXmlData()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) για εργασία με τα ακατέργαστα byte του XML.

Η μέθοδος `ICustomXmlPart.getItemId()` επιστρέφει το UUID που ταυτοποιεί το προσαρμοσμένο τμήμα XML στο έγγραφο Office Open XML. Χρησιμοποιήστε τη μέθοδο `setItemId()` όταν μια ενσωμάτωση απαιτεί νέο αναγνωριστικό.

Το ακόλουθο παράδειγμα ενημερώνει το περιεχόμενο XML και το αναγνωριστικό:

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

    // Η μέθοδος getXmlData παρέχει το ίδιο περιεχόμενο XML ως ακατέργαστα byte.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Αντικαταστήστε το αναγνωριστικό όταν απαιτείται από την ενσωμάτωση.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Κατά την κλήση των `setXmlAsString` ή `setXmlData`, παρέχετε έγκυρο, μη κενό XML. Χρησιμοποιήστε τη μία ή την άλλη αναπαράσταση ανάλογα με το αν η εφαρμογή εργάζεται κυρίως με συμβολοσειρές ή με byte δεδομένα.

### **Αφαίρεση Προσαρμοσμένου Τμήματος XML**

Το Aspose.Slides παρέχει πολλές μεθόδους για αφαίρεση προσαρμοσμένων δεδομένων XML:

- `ICustomXmlPart.remove` αφαιρεί το προσαρμοσμένο τμήμα XML από την παρουσίαση.
- `ICustomXmlPartCollection.remove` αφαιρεί ένα συγκεκριμένο τμήμα από μια συλλογή προσαρμοσμένων τμημάτων XML.
- `ICustomXmlPartCollection.removeAt` αφαιρεί το τμήμα στη συγκεκριμένη θέση της συλλογής.
- `ICustomXmlPartCollection.clear` αφαιρεί όλα τα τμήματα από μια συγκεκριμένη συλλογή.

Το ακόλουθο παράδειγμα αφαιρεί ένα προσαρμοσμένο τμήμα XML επιπέδου παρουσίασης με αναφορά:

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

Εάν έχετε ήδη ένα `ICustomXmlPart` και θέλετε να αφαιρέσετε αυτό το τμήμα από την παρουσίαση αντί να στοχεύσετε μια συγκεκριμένη συλλογή, καλέστε `customXmlPart.remove()`.

Μπορείτε επίσης να αφαιρέσετε ένα στοιχείο με βάση τον δείκτη:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Διαγραφή Όλων των Προσαρμοσμένων Τμημάτων XML από Συλλογή**

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

Η `clear` επηρεάζει μόνο τη επιλεγμένη συλλογή. Για παράδειγμα, η εκκαθάριση της συλλογής μιας διαφάνειας δεν καθαρίζει τις συλλογές επιπέδου παρουσίασης ή σχήματος.

Για να αφαιρέσετε κάθε προσαρμοσμένο τμήμα XML στην παρουσίαση, επαναλάβετε μέσω του `getAllCustomXmlParts()` και αφαιρέστε κάθε τμήμα:

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

Η κοινή χρήση ενός τμήματος πρέπει να αντιμετωπίζεται ως ένα αντικείμενο δεδομένων με πολλαπλές αναφορές:

- Η ενημέρωση του με `setXmlAsString`, `setXmlData` ή `setItemId` τροποποιεί το υποκείμενο προσαρμοσμένο τμήμα XML, έτσι η αλλαγή εφαρμόζεται όπου και αν αναφέρεται το τμήμα.
- `getItemId()` μπορεί να χρησιμοποιηθεί για την ταυτοποίηση του ίδιου προσαρμοσμένου τμήματος XML κατά την ελεγκτική επιθεώρηση συλλογών επιπέδου αντικειμένου.
- Η αφαίρεση ενός τμήματος από μια συγκεκριμένη συλλογή `getCustomXmlParts()` το αφαιρεί από εκείνη τη συλλογή. Χρησιμοποιήστε `ICustomXmlPart.remove()` όταν το ίδιο το τμήμα πρέπει να αφαιρεθεί από την παρουσίαση.
- Πριν διαγράψετε ή αντικαταστήσετε ένα κοινόχρηστο τμήμα, εξετάστε τις συλλογές επιπέδου αντικειμένου για να καθορίσετε εάν άλλες διαφάνειες ή σχήματα το αναφέρουν ακόμα.

Οι υπερφορτώσεις της `add` δημιουργούν νέο προσαρμοσμένο τμήμα XML από το περιεχόμενο XML· δεν αποδέχονται υπάρχον `ICustomXmlPart`. Επομένως, οι κοινόχρηστες σχέσεις συναντώνται συνήθως όταν φορτώνετε παρουσιάσεις που τα περιέχουν ήδη.

Το ακόλουθο παράδειγμα ελέγχει τις συλλογές επιπέδων παρουσίασης, διαφάνειας και σχήματος με βάση το `ItemId` και αναφέρει τμήματα που αναφέρονται από περισσότερα από ένα σημεία:

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

Αυτός ο τύπος ελέγχου είναι χρήσιμος πριν την τροποποίηση ή διαγραφή προσαρμοσμένων δεδομένων XML σε παρουσιάσεις που δημιουργήθηκαν από εξωτερικά συστήματα, επειδή το ίδιο τμήμα μεταδεδομένων μπορεί να συμμετέχει σε περισσότερες από μία σχέσεις.

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στη μέθοδο `IDocumentProperties.getKeywords()`. Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides for Java για [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation):

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

Το Aspose.Slides σάς επιτρέπει να προσθέτετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας, π.χ. `MyTag`;
- την τιμή της προσαρμοσμένης ιδιότητας, π.χ. `My Tag Value`.

Εάν χρειάζεται να κατηγοριοποιήσετε παρουσιάσεις βάσει ενός συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να προσθέσετε ετικέτες για αυτό το σκοπό. Για παράδειγμα, αν θέλετε να ταξινομήσετε παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα «North American» και να ορίσετε τη σχετική χώρα ως τιμή της.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) χρησιμοποιώντας το Aspose.Slides for Java:

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

Οι ετικέτες που προστίθενται μέσω της συλλογής `getCustomData().getTags()` αποθηκεύονται μόνο στο αρχείο PowerPoint. **Δεν** μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένα προσαρμοσμένο αναγνωριστικό που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Λύση**: Μπορείτε να αποθηκεύσετε ένα προσαρμοσμένο αναγνωριστικό στο **Alt Text** του αντικειμένου (π.χ. `shape.setAlternativeText("MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών του PDF.

## **FAQ**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα σε μια ενέργεια;**

Ναι. Η [συλλογή ετικετών](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/) υποστηρίζει μια λειτουργία [clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/#clear--) που διαγράφει όλα τα ζεύγη κλειδιού‑τιμής ταυτόχρονα.

**Πώς μπορώ να διαγράψω μία ετικέτα με το όνομα της χωρίς να διατρέχω ολόκληρη τη συλλογή;**

Χρησιμοποιήστε το [remove(name)](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω τον πλήρη κατάλογο των ονομάτων ετικετών για ανάλυση ή φιλτράρισμα;**

Χρησιμοποιήστε το [getNamesOfTags](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/#getNamesOfTags--) στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.

**Πώς μπορώ να βρω όλα τα προσαρμοσμένα τμήματα XML ανεξάρτητα από το πού είναι αποθηκευμένα;**

Χρησιμοποιήστε τη μέθοδο [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση.

**Πρέπει να χρησιμοποιήσω `getXmlAsString`/`setXmlAsString` ή `getXmlData`/`setXmlData` για την ενημέρωση ενός προσαρμοσμένου τμήματος XML;**

Χρησιμοποιήστε τις `getXmlAsString` και `setXmlAsString` όταν η εφαρμογή εργάζεται με κείμενο XML σε κωδικοποίηση UTF‑8. Χρησιμοποιήστε τις `getXmlData` και `setXmlData` όταν το XML είναι ήδη διαθέσιμο ως πίνακας byte ή όταν η επεξεργασία σε δυαδική μορφή είναι πιο βολική. Και οι δύο αναπαραστάσεις αναφέρονται στο περιεχόμενο XML του ίδιου προσαρμοσμένου τμήματος XML.