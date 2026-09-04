---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε JavaScript
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/nodejs-java/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προχωρημένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα ελέγχου ορθογραφίας
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε πλήρως τις ιδιότητες παρουσίασης στο Aspose.Slides για Node.js μέσω Java και βελτιστοποιήστε την αναζήτηση, την εμπορική σήμανση και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφων παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/) . Μια παρουσία αυτής της κλάσης επιστρέφεται από τη μέθοδο [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Τα ακόλουθα παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}
Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **AppVersion** δεν μπορούν να τροποποιηθούν. Το Aspose.Slides τα ξαναγράφει σε κάθε αποθήκευση, έτσι μια αποθηκευμένη παρουσίαση πάντα αναφέρει "Aspose.Slides for Node.js via Java" και την έκδοση της βιβλιοθήκης που τη δημιούργησε. Οποιαδήποτε τιμή περαστεί στη μέθοδο `setNameOfApplication` απορρίπτεται όταν η παρουσίαση γράφεται.
{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια δυνατότητα για προσθήκη κάποιων ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

Οι **Built-in** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο όπως ο τίτλος, το όνομα του δημιουργού, στατιστικά του εγγράφου κ.λπ. Οι **Custom** ιδιότητες είναι εκείνες που ορίζονται από τους χρήστες ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή ορίζονται από τον χρήστη. Χρησιμοποιώντας το Aspose.Slides for Node.js via Java, οι προγραμματιστές μπορούν να έχουν πρόσβαση και να τροποποιούν τις τιμές των ενσωματωμένων ιδιοτήτων καθώς και των προσαρμοσμένων ιδιοτήτων.

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και, στη συνέχεια, στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, εμφανίζεται ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint όπως φαίνεται παρακάτω:

|**Διάλογος Ιδιοτήτων**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Στον παραπάνω **Διάλογο Ιδιοτήτων**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών ειδών πληροφοριών που σχετίζονται με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Εργασία με Ιδιότητες Εγγράφου Χρησιμοποιώντας Aspose.Slides for Node.js via Java**

Όπως περιγράφηκε νωρίτερα, το Aspose.Slides for Node.js via Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου, που είναι οι **Built-in** και **Custom** ιδιότητες. Έτσι, οι προγραμματιστές μπορούν να έχουν πρόσβαση και στα δύο είδη ιδιοτήτων μέσω του API του Aspose.Slides for Node.js via Java. Το Aspose.Slides for Node.js via Java παρέχει την κλάση [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που σχετίζονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **DocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) για να προσπελάσουν τις ιδιότητες εγγράφου των αρχείων παρουσίασης όπως περιγράφεται παρακάτω:

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός πρόσβασης ανοίγματος προστατεύει συνήθως τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται περνώντας `false` στη μέθοδο [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), οι ιδιότητες εγγράφου παραμένουν δημόσιες. Μια εφαρμογή μπορεί στη συνέχεια να περάσει `true` στη μέθοδο [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό ανοίγματος.

Η επιλογή μόνο ιδιότητες εγγράφου ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωσή τους χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται ολόκληρη η παρουσίαση.

Το παρακάτω παράδειγμα επαληθεύει τη λειτουργία φόρτωσης μέσω της μεθόδου [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) και στη συνέχεια διαβάζει τις ενσωματωμένες ιδιότητες μέσω της μεθόδου [Presentation.getDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Διαφάνειες, master, layouts, σχήματα, μέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) πριν εκτελέσουν λειτουργία που απαιτεί το πλήρες μοντέλο αντικειμένων παρουσίασης.

{{% alert color="warning" title="Προειδοποίηση" %}}
Τα δημόσια μεταδεδομένα μπορεί να αποκαλύψουν τα ονόματα συγγραφέων, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Αφήστε τις δημόσιες μόνο όταν συστήματα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων έχουν ειδική απαίτηση πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται σε λειτουργία μόνο ιδιοτήτων εγγράφου προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο-μεταδεδομένων, επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν συμβατές με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί επομένως τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση με τη μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί τη μέθοδο [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) για να επαληθεύσει ότι η κρυπτογράφηση διατηρείται και ξαναανοίγει τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

Εάν μια εφαρμογή δεν έχει άδεια να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο‑ανάγνωση.

## **Πρόσβαση στις Ενσωματωμένες Ιδιότητες**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties) περιλαμβάνουν: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** και **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει την παρουσίαση
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που συνδέεται με την Presentation
    var dp = pres.getDocumentProperties();
    // Εμφάνιση των ενσωματωμένων ιδιοτήτων
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο εύκολη όσο η πρόσβασή τους. Απλώς εκχωρείτε μια τιμή κειμένου σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα δείξαμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου της παρουσίασης χρησιμοποιώντας το Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που συνδέεται με την Presentation
    var dp = pres.getDocumentProperties();
    // Ορισμός των ενσωματωμένων ιδιοτήτων
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Αποθήκευση της παρουσίασης σε αρχείο
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αυτό το παράδειγμα τροποποιεί τις ενσωματωμένες ιδιότητες της παρουσίασης όπως φαίνεται παρακάτω:

|**Ενσωματωμένες ιδιότητες εγγράφου μετά την τροποποίηση**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides for Node.js via Java επιτρέπει επίσης στους προγραμματιστές να προσθέσουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου της παρουσίασης. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Λήψη ιδιοτήτων εγγράφου
    var dProps = pres.getDocumentProperties();
    // Πρόσθεση προσαρμοσμένων ιδιοτήτων
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Λήψη ονόματος ιδιότητας σε συγκεκριμένο δείκτη
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Αφαίρεση επιλεγμένης ιδιότητας
    dProps.removeCustomProperty(getPropertyName);
    // Αποθήκευση παρουσίασης
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Προσαρμοσμένες Ιδιότητες Εγγράφου Προστέθηκαν**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides for Node.js via Java επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν τις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο DocumentProperties που συνδέεται με την Presentation
    var dp = pres.getDocumentProperties();
    // Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Εμφάνιση ονομάτων και τιμών των προσαρμοσμένων ιδιοτήτων
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Τροποποίηση τιμών των προσαρμοσμένων ιδιοτήτων
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Αποθήκευση της παρουσίασης σε αρχείο
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες του [PPTX](https://docs.fileformat.com/presentation/pptx/) παρουσίασης. Τα παρακάτω σχήματα δείχνουν τις προσαρμοσμένες ιδιότητες της παρουσίασης πριν και μετά την τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες Πριν την Τροποποίηση**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Προσαρμοσμένες Ιδιότητες Μετά την Τροποποίηση**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προχωρημένες Ιδιότητες Εγγράφου**

{{% alert color="info" title="Σημείωση" %}}
Νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), και [WriteBindedPresentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo). Η λογική του setter της ιδιότητας [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) άλλαξε.
{{% /alert %}} 

Οι δύο νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) και [UpdateDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo). Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς τη φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φορτώνει τις ιδιότητες, αλλάζει κάποια τιμή και ενημερώνει το έγγραφο ως εξής:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// διαβάστε τις πληροφορίες της παρουσίασης
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// αποκτήστε τις τρέχουσες ιδιότητες
var props = info.readDocumentProperties();
// ορίστε τις νέες τιμές των πεδίων Συγγραφέας και Τίτλος
props.setAuthor("New Author");
props.setTitle("New Title");
// ενημερώστε την παρουσίαση με τις νέες τιμές
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Υπάρχει ένας άλλος τρόπος να χρησιμοποιήσετε τις ιδιότητες μιας συγκεκριμένης παρουσίασης ως πρότυπο για την ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Μπορεί να δημιουργηθεί νέο πρότυπο από το μηδέν και στη συνέχεια να χρησιμοποιηθεί για την ενημέρωση πολλαπλών παρουσιάσεων:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εκτίθεται από την κλάση PortionFormat) για να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου ορθογραφίας είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα PowerPoint: xxx Why is LanguageId missing from JavaScript PortionFormat class?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// ορίστε το Id μιας γλώσσας ελέγχου ορθογραφίας
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να ορίσετε την προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Προσθέτει ένα νέο σχήμα ορθογωνίου με κείμενο
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Ελέγχει τη γλώσσα του πρώτου τμήματος
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την online εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργαστείτε με ιδιότητες εγγράφου μέσω του API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν πλήρως. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε κενές εάν το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει εάν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Εάν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων· το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες παρουσίασης χωρίς να φορτώνω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε τη μέθοδο [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) και, στη συνέχεια, τη μέθοδο [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) για να διαβάσετε αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Δείτε το άρθρο [Build a Lightweight Presentation Inventory](/slides/el/nodejs-java/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες μιας κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η κρυπτογράφηση των ιδιοτήτων εγγράφου πρέπει να είχε απενεργοποιηθεί πριν κρυπτογραφηθεί η παρουσίαση και η παρουσίαση πρέπει να φορτωθεί σε λειτουργία μόνο ιδιοτήτων εγγράφου.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο ιδιοτήτων εγγράφου;**

Όχι. Τα δημόσια και τα κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμείνουν συμβατά, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση ολόκληρης της παρουσίασης με τον σωστό κωδικό ανοίγματος.