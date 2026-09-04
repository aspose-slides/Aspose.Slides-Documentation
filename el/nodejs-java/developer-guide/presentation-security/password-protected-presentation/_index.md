---
title: "Προστασία Παρουσιάσεων με Κωδικό Πρόσβασης σε JavaScript"
linktitle: "Προστασία Κωδικού Πρόσβασης"
type: docs
weight: 20
url: /el/nodejs-java/password-protected-presentation/
keywords:
- "παρουσίαση με προστασία κωδικού πρόσβασης"
- "κωδικός πρόσβασης ανοίγματος"
- "κρυπτογράφηση PowerPoint"
- "αποκρυπτογράφηση PowerPoint"
- "επικύρωση κωδικού πρόσβασης παρουσίασης"
- "έλεγχος κωδικού πρόσβασης παρουσίασης"
- "άνοιγμα κρυπτογραφημένης παρουσίασης"
- "αφαίρεση κρυπτογράφησης"
- "PowerPoint"
- "PPT"
- "PPTX"
- "παρουσίαση"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Κρυπτογραφήστε, ανιχνεύστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX με προστασία κωδικού πρόσβασης σε JavaScript με το Aspose.Slides."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός πρόσβασης απαιτείται για τη φόρτωση και την προβολή του περιεχομένου της παρουσίασης, έτσι η προστασία αυτή παρέχει εμπιστευτικότητα.

Ένας κωδικός πρόσβασης ανοίγματος διαφέρει από έναν κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση, αλλά δεν κρυπτογραφεί το περιεχόμενο ούτε εμποδίζει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για την τροποποίηση παρουσιάσεων, δείτε [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/nodejs-java/write-protected-presentation/).

Οι παρακάτω ροές εργασίας ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όπου η συμπεριφορά με βάση το αρχείο και το ρεύμα είναι σημαντική.

## **Κρυπτογράφηση Παρουσίασης με Κωδικό Πρόσβασης Ανοίγματος**

Χρησιμοποιήστε το ProtectionManager.encrypt για να ορίσετε έναν κωδικό πρόσβασης ανοίγματος. Στη συνέχεια, χρησιμοποιήστε το Presentation.save για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το παρακάτω παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διατήρηση Δημοσίων Ιδιοτήτων Εγγράφου**

Από προεπιλογή, το Aspose.Slides περιλαμβάνει τις ιδιότητες εγγράφου στην κρυπτογράφηση της παρουσίασης. Η μέθοδος ProtectionManager.setEncryptDocumentProperties ελέγχει αυτή τη συμπεριφορά ανεξάρτητα από την κρυπτογράφηση του περιεχομένου των διαφανειών. Περάστε false πριν καλέσετε το ProtectionManager.encrypt όταν ένα σύστημα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφου πρέπει να διαβάσει μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος.

Το παρακάτω παράδειγμα δημιουργεί μια κρυπτογραφημένη παρουσίαση PPTX ενώ αφήνει τις ενσωματωμένες ιδιότητες εγγράφου δημόσιες:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μεταβίβαση του false στη μέθοδο ProtectionManager.setEncryptDocumentProperties δεν καθιστά τις διαφάνειες, τα master, τις διατάξεις, τα σχήματα, τα μέσα ή άλλο περιεχόμενο παρουσίασης δημόσια. Επηρεάζει μόνο τις ιδιότητες εγγράφου. Για να διαβάσετε αυτές τις ιδιότητες χωρίς τη φόρτωση του κρυπτογραφημένου περιεχομένου, δείτε [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/nodejs-java/presentation-properties/).

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε το LoadOptions.setPassword στον κωδικό πρόσβασης ανοίγματος και περάστε τις επιλογές στο Presentation κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός πρόσβασης ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Εργασία με την αποκρυπτογραφημένη παρουσίαση.
} finally {
    presentation.dispose();
}
```

## **Αφαίρεση Κρυπτογράφησης από Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό πρόσβασης ανοίγματος, καλέστε το ProtectionManager.removeEncryption και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Επικύρωση Κωδικού Πρόσβασης Ανοίγματος Πριν τη Φόρτωση**

Χρησιμοποιήστε το PresentationFactory.getPresentationInfo για να λάβετε το PresentationInfo χωρίς να δημιουργήσετε μια πλήρη παρουσίαση. Ελέγξτε το PresentationInfo.isPasswordProtected πριν ζητήσετε ή επικυρώσετε έναν κωδικό πρόσβασης. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το PresentationInfo.checkPassword.

### **Ροή Εργασίας Βάσει Διαδρομής Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό πρόσβασης ανοίγματος για αρχείο PPTX, περνά την επικυρωμένη τιμή στο LoadOptions.setPassword και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Ροή Εργασίας Ρεύματος**

Χρησιμοποιήστε το PresentationFactory.getPresentationInfoFromStream για να εξετάσετε ένα αναγνώσιμο ρεύμα Node.js. Αφού το ρεύμα ελέγχου έχει καταναλωθεί, δημιουργήστε νέο ρεύμα πριν φορτώσετε την πλήρη παρουσίαση με το Presentation.createPresentationFromStream.

Το παρακάτω παράδειγμα χρησιμοποιεί αρχείο PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Τιμές Επιστροφής checkPassword**

Το PresentationInfo.checkPassword επιστρέφει true μόνο όταν η παρουσίαση έχει κωδικό πρόσβασης ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει false σε κάθε μία από τις παρακάτω περιπτώσεις:

- Ο κωδικός πρόσβασης είναι λανθασμένος.
- Η παρουσίαση δεν έχει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός είναι null ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Αν Η Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Μετά τη φόρτωση μιας παρουσίασης με τον σωστό κωδικό, εξετάστε το ProtectionManager.isEncrypted για να επιβεβαιώσετε ότι η αρχική παρουσίαση ήταν κρυπτογραφημένη. Για να ανιχνεύσετε την προστασία κωδικού πρόσβασης ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το PresentationInfo.isPasswordProtected όπως φαίνεται παραπάνω.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Συμβουλές Ασφαλείας**

{{% alert color="warning" title="Security" %}}
Μην καταγράφετε τους κωδικούς πρόσβασης ανοίγματος ή τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, διατηρείτε τους κωδικούς στη μνήμη μόνο όσο χρειάζεται, και επαναχρησιμοποιήστε ένα επιτυχημένο αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.

Οι δημόσιες ιδιότητες εγγράφου μπορεί να αποκαλύψουν ονόματα δημιουργών, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές, ακόμη και αν το περιεχόμενο της παρουσίασης είναι κρυπτογραφημένο. Κρυπτογραφήστε τα ευαίσθητα μεταδεδομένα μαζί με την παρουσίαση. Η διατήρηση των ιδιοτήτων δημόσιες πρέπει να είναι σαφής απόφαση που λαμβάνεται μόνο όταν τα συστήματα πρέπει να ευρετηριάσουν, ταξινομήσουν, αναζητήσουν ή διαχειριστούν το αρχείο χωρίς κωδικό πρόσβασης ανοίγματος.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Πρόσβασης Διαδικτυακά**

1. Ανοίξτε την εφαρμογή Aspose.Slides Lock.
1. Επιλέξτε ή ανεβάστε την παρουσίαση.
1. Εισάγετε έναν κωδικό για προστασία προβολής.
1. Προαιρετικά, εισάγετε ξεχωριστό κωδικό για προστασία επεξεργασίας.
1. Εφαρμόστε την προστασία και κατεβάστε το παραγόμενο αρχείο.

{{% alert color="info" title="See also" %}}
- [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/nodejs-java/write-protected-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κωδικού πρόσβασης ανοίγματος και κωδικού προστασίας εγγραφής;**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό πρόσβασης ανοίγματος χωρίς να φορτώσω όλες τις διαφάνειες;**

Ναι. Λάβετε τις πληροφορίες της παρουσίασης, ελέγξτε αν υπάρχει προστασία κωδικού πρόσβασης ανοίγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε μια πλήρη παρουσίαση.

**Μπορεί μια εφαρμογή να διαβάσει μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος;**

Ναι, αλλά μόνο όταν η παρουσίαση κρυπτογραφήθηκε με την κρυπτογράφηση των ιδιοτήτων εγγράφου απενεργοποιημένη. Η εφαρμογή πρέπει τότε να χρησιμοποιήσει τη λειτουργία φόρτωσης μόνο-ιδιοτήτων-εγγράφου που περιγράφεται στο [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/nodejs-java/presentation-properties/).

**Υποστηρίζουν οι ροές ελέγχου κωδικού πρόσβασης τόσο PPT όσο και PPTX;**

Ναι. Ο εντοπισμός και η επικύρωση κωδικού πρόσβασης βάσει διαδρομής αρχείου ή ρεύματος λειτουργούν με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.