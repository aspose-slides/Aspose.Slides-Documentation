---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε JavaScript
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/nodejs-java/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- ιδιότητες παρουσίασης
- ιδιότητες εγγράφου
- ενσωματωμένες ιδιότητες
- προσαρμοσμένες ιδιότητες
- προηγμένες ιδιότητες
- διαχείριση ιδιοτήτων
- τροποποίηση ιδιοτήτων
- μεταδεδομένα εγγράφου
- επεξεργασία μεταδεδομένων
- γλώσσα επιμέλειας
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Κατακτήστε τις ιδιότητες παρουσίασης στο Aspose.Slides για Node.js μέσω Java και βελτιστοποιήστε την αναζήτηση, τη δημιουργία εταιρικής ταυτότητας και τη ροή εργασιών στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides για Node.js μέσω Java υποστηρίζει **ενσωματωμένες** και **προσαρμοσμένες** ιδιότητες εγγράφου. Χρησιμοποιήστε αυτές τις ιδιότητες για να διαβάσετε και να ενημερώσετε τα μεταδεδομένα της παρουσίασης, όπως ο συγγραφέας, ο τίτλος και οι τιμές που ορίζονται από τον χρήστη.

Το Aspose.Slides επιτρέπει την εργασία με τις ιδιότητες εγγράφου της παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). Μια παρουσία της κλάσης αυτής επιστρέφεται από τη μέθοδο [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}

Το Aspose.Slides διαχειρίζεται τα μεταδεδομένα της εφαρμογής και του δημιουργού κατά την αποθήκευση παρουσιάσεων· αυτά τα πεδία αναγνωρίζουν το λογισμικό που δημιούργησε το αποτέλεσμα.

{{% /alert %}}

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες εγγράφου αποθηκεύουν περιγραφικές πληροφορίες παράλληλα με το περιεχόμενο της παρουσίασης. Κατατάσσονται σε δύο κατηγορίες:

- **Built‑in properties** περιέχουν τυπικά μεταδεδομένα, όπως ο τίτλος, ο συγγραφέας και στατιστικά του εγγράφου.
- **Custom properties** αποθηκεύουν ζεύγη όνομα/τιμή που ορίζονται από τον χρήστη.

Το Aspose.Slides για Node.js μέσω Java παρέχει πρόσβαση και στις δύο κατηγορίες. Στο PowerPoint, επιλέξτε **File → Info → Properties → Advanced Properties** για να εξετάσετε τα μεταδεδομένα του εγγράφου. Ο διάλογος ομαδοποιεί τις πληροφορίες σε καρτέλες όπως **Summary**, **Statistics**, **Contents** και **Custom**. Χρησιμοποιήστε την καρτέλα **Custom** για να διαχειριστείτε ιδιότητες που ορίζονται από τον χρήστη.

## **Ανάγνωση Δημοσίων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός ανοίγματος προστατεύει κανονικά τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται μετά την κλήση της μεθόδου [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) με `false`, οι ιδιότητες εγγράφου παραμένουν δημόσιες. Μια εφαρμογή μπορεί στη συνέχεια να καλέσει τη μέθοδο [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) με `true` και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό ανοίγματος.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωση χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και η πλήρης παρουσίαση φορτώνεται.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση της οποίας οι ιδιότητες εγγράφου έχουν αφήσει δημόσιες. Επαληθεύει τη λειτουργία φόρτωσης μέσω της μεθόδου [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) και στη συνέχεια διαβάζει ενσωματωμένες ιδιότητες μέσω της [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Οι διαφάνειες, τα master, τα layouts, τα σχήματα, τα μέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) πριν εκτελέσουν κάποια ενέργεια που απαιτεί το πλήρες μοντέλο αντικειμένων της παρουσίασης.

{{% alert color="warning" title="Warning" %}}
Τα δημόσια μεταδεδομένα μπορεί να αποκαλύψουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Αφήστε τις δημόσιες μόνο όταν συστήματα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων έχουν συγκεκριμένη απαίτηση πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται μετά την κλήση της [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) με `true` προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο‑μεταδεδομένων επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν σύμφωνες με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί λοιπόν τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση PPTX με δημόσιες ιδιότητες εγγράφου και γνωστό κωδικό ανοίγματος. Ανοίγει την πλήρη παρουσίαση με τη [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), ενημερώνει δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί τη μέθοδο [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) για να επαληθεύσει ότι η κρυπτογράφηση διατηρείται και ξαναανοίγει τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο‑ανάγνωση.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Η κλάση [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) εκθέτει ενσωματωμένα μεταδεδομένα μέσω μεθόδων getter, όπως [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) και [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και εκτυπώνει τα αποθηκευμένα μεταδεδομένα στη γραμμή εντολών. Οι τιμές εξαρτώνται από την είσοδο· ορισμένα πεδία μπορεί να είναι κενά.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Για να ενημερώσετε ενσωματωμένα μεταδεδομένα, χρησιμοποιήστε τις μεθόδους setter στο αντικείμενο που επιστρέφεται από τη [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση, καλεί τις [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) και [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), στη συνέχεια αποθηκεύει την ενημερωμένη παρουσίαση με τη [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Η αποθηκευμένη PPTX περιέχει τα νέα μεταδεδομένα.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαχείριση Βάσης Υπερσυνδέσμων**

Η μέθοδος [DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) επιστρέφει τη βάση σε επίπεδο εγγράφου για σχετικούς υπερσυνδέσμους. Χρησιμοποιήστε τη [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) για να την αλλάξετε ή να την καθαρίσετε. Αυτό είναι χρήσιμο όταν μετακινείτε μια παρουσίαση και τα συνδεδεμένα αρχεία της σε άλλη θέση. Είναι ανεξάρτητο από τη μέθοδο [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) ενός μεμονωμένου υπερσυνδέσμου· η αλλαγή της βάσης δεν ξαναγράφει τις αποθηκευμένες διευθύνσεις των συνδέσμων ούτε αλλάζει απόλυτους προορισμούς.

Το παράδειγμα απαιτεί μια παρουσίαση που περιέχει τόσο έναν σχετικό σύνδεσμο, όπως `target.html`, όσο και έναν απόλυτο σύνδεσμο, όπως `https://example.org/absolute.html`. Διαβάζει τη υπάρχουσα βάση, ορίζει νέα διεύθυνση βάσης, αποθηκεύει και ξαναανοίγει την παρουσίαση για να ελέγξει την τιμή. Στη συνέχεια καθαρίζει τη βάση με κενή συμβολοσειρά και επαληθεύει την κενή τιμή σε ξεχωριστό αποθηκευμένο αρχείο. Αντικαταστήστε τη διεύθυνση βάσης του παραδείγματος με τη θέση των συνδεδεμένων αρχείων σας.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

Τα δύο μηνύματα επαλήθευσης θα πρέπει να εκτυπώσουν `true`. Ο καθαρισμός της βάσης αφήνει τις διευθύνσεις των μεμονωμένων υπερσυνδέσμων αμετάβλητες.

Ένας σχετικός σύνδεσμος προς `target.pptx` άνοιγε `old/target.pptx` όταν η βάση υπαγόταν στο φάκελο `old`. Αφού η βάση αλλάξει στον φάκελο `new`, η αποθήκευση και η επανάληψη ανοίγματος οδηγούν τον ίδιο σύνδεσμο να ανοίγει `new/target.pptx`. Ένας απόλυτος σύνδεσμος συνεχίζει να ανοίγει το ίδιο αρχείο. Δοκιμάστε τους σχετικούς συνδέσμους σας στο PowerPoint πριν και μετά τη μετακίνηση της παρουσίασης ή την αλλαγή της βάσης.

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες αποθηκεύουν μεταδεδομένα που δεν έχουν αντίστοιχο ενσωματωμένο πεδίο. Η μέθοδος [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) σας επιτρέπει να ορίσετε μια τιμή με βάση το όνομα της ιδιότητας. Αυτό το παράδειγμα δημιουργεί μια παρουσίαση, προσθέτει δύο τιμές κειμένου και μια ακέραια τιμή έκδοσης, και αποθηκεύει την παρουσίαση με τη [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Η ανάθεση τιμής σε υπάρχον όνομα αντικαθιστά την τιμή της ιδιότητας.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Αυτό το παράδειγμα ανοίγει μια παρουσίαση που περιέχει προσαρμοσμένες ιδιότητες και χρησιμοποιεί τη [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) για να επαναλάβει πάνω τους. Η [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) δέχεται έναν μηδενικό δείκτη και επιστρέφει το όνομα που χρησιμοποιείται από τη [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). Το παράδειγμα εκτυπώνει κάθε αρχικό όνομα και τιμή, αντικαθιστά κάθε τιμή με μια αριθμημένη συμβολοσειρά ανεξάρτητα από τον αρχικό τύπο, και αποθηκεύει τις αλλαγές. Εάν δεν υπάρχουν προσαρμοσμένες ιδιότητες, η επανάληψη δεν κάνει καμία αλλαγή.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την διαδικτυακή εφαρμογή [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) για να δείτε πώς να εργάζεστε με ιδιότητες εγγράφου χρησιμοποιώντας το API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες είναι αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε κενές εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της.

**Μπορώ να έχω πρόσβαση στις ιδιότητες παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε τη [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) και στη συνέχεια τη [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Δείτε το άρθρο [Build a Lightweight Presentation Inventory](/slides/el/nodejs-java/examine-presentation/) για πλήρες παράδειγμα αναφοράς και περιορισμούς ανά τύπο μορφής.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η παρουσίαση πρέπει να έχει κρυπτογραφηθεί μετά την κλήση της [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) με `false`, και πρέπει να φορτωθεί μετά την κλήση της [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) με `true`.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο‑ιδιότητες‑εγγράφου;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμείνουν σύμφωνα, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση της πλήρους παρουσίασης με τον σωστό κωδικό ανοίγματος.