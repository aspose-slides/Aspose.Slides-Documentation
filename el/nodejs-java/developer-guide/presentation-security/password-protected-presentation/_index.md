---
title: ΠΡΟΤΑΣΙΑ ΣΤΑ ΓΙΑ Να Ειδά του φίag' Passage in Greek
linktitle: Προστασία Κωδικού Πρόσβασης
type: docs
weight: 20
url: /el/nodejs-java/password-protected-presentation/
keywords:
- παρουσίαση προστατευμένη με κωδικό πρόσβασης
- κωδικός πρόσβασης ανοίγματος
- κρυπτογράφηση PowerPoint
- αποκρυπτογράφηση PowerPoint
- επικύρωση κωδικού παρουσίασης
- έλεγχος κωδικού παρουσίασης
- άνοιγμα κρυπτογραφημένης παρουσίασης
- αφαίρεση κρυπτογράφησης
- PowerPoint
- PPT
- PPTX
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Κρυπτογραφήστε, εντοπίστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX που είναι προστατευμένες με κωδικό πρόσβασης σε JavaScript με Aspose.Slides."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός πρόσβασης απαιτείται για τη φόρτωση και την προβολή του περιεχομένου της παρουσίασης, έτσι αυτή η προστασία παρέχει εμπιστευτικότητα.

Ο κωδικός πρόσβασης ανοίγματος διαφέρει από έναν κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση αλλά δεν κρυπτογραφεί το περιεχόμενο ούτε αποτρέπει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για την τροποποίηση παρουσιάσεων, δείτε [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/nodejs-java/write-protected-presentation/).

Οι ροές εργασίας παρακάτω ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όπου η συμπεριφορά τους βάσει αρχείου και ροής είναι σημαντική.

## **Κρυπτογράφηση Παρουσίασης με Κωδικό Πρόσβασης Ανοίγματος**

Χρησιμοποιήστε [ProtectionManager.encrypt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/protectionmanager/#encrypt) για να ορίσετε έναν κωδικό πρόσβασης ανοίγματος. Στη συνέχεια, χρησιμοποιήστε [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

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

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε το [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword) με τον κωδικό πρόσβασης ανοίγματος και περάστε τις επιλογές στο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός πρόσβασης ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

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

Φορτώστε την παρουσίαση με τον κωδικό πρόσβασης ανοίγματος, καλέστε [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό πρόσβασης.

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

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) για να λάβετε το [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/) χωρίς να δημιουργήσετε μια πλήρη παρουσίαση. Ελέγξτε το [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) πριν ζητήσετε ή επικυρώσετε έναν κωδικό πρόσβασης. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [PresentationInfo.checkPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Ροή Εργασίας Διαδρομής Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό πρόσβασης ανοίγματος για ένα αρχείο PPTX, περνά την επικυρωμένη τιμή στο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword) και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

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

### **Ροή Εργασίας Ροής**

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) για να ελέγξετε ένα αναγνώσιμο ρεύμα του Node.js. Αφού το ρεύμα ελέγχου έχει καταναλωθεί, δημιουργήστε ένα νέο ρεύμα πριν φορτώσετε την πλήρη παρουσίαση με το [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Το παρακάτω παράδειγμα χρησιμοποιεί ένα αρχείο PPT:

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

### **Τιμές Επιστροφής της checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#checkPassword) επιστρέφει `true` μόνο όταν η παρουσίαση διαθέτει κωδικό πρόσβασης ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε κάθε μία από τις παρακάτω περιπτώσεις:

- Ο κωδικός πρόσβασης είναι λανθασμένος.
- Η παρουσίαση δεν διαθέτει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός πρόσβασης είναι `null` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Αν Η Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Αφού φορτώσετε μια παρουσίαση με τον σωστό κωδικό πρόσβασης, ελέγξτε το [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) για να επιβεβαιώσετε ότι η αρχική παρουσίαση είχε κρυπτογραφηθεί. Για να εντοπίσετε την προστασία με κωδικό πρόσβασης ανοίγματος πριν από τη φόρτωση, χρησιμοποιήστε το [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) όπως φαίνεται παραπάνω.

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

## **Συστάσεις Ασφαλείας**

{{% alert color="warning" title="Security" %}}
Μην καταγράφετε τους κωδικούς πρόσβασης ανοίγματος ή τους συμπεριλάβετε σε μηνύματα διάγνωσης. Αποφύγετε τις περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, διατηρήστε τους κωδικούς πρόσβασης στη μνήμη μόνο όσο χρειάζεται, και επαναχρησιμοποιήστε ένα επιτυχές αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Πρόσβασης Διαδικτυακά**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
1. Επιλέξτε ή ανεβάστε την παρουσίαση.
1. Εισάγετε έναν κωδικό πρόσβασης για προστασία προβολής.
1. Προαιρετικά, εισάγετε έναν ξεχωριστό κωδικό πρόσβασης για προστασία επεξεργασίας.
1. Εφαρμόστε την προστασία και κατεβάστε το αρχείο που προκύπτει.

{{% alert color="info" title="See also" %}}
- [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/nodejs-java/write-protected-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κωδικού πρόσβασης ανοίγματος και κωδικού προστασίας εγγραφής;**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό πρόσβασης ανοίγματος χωρίς να φορτώσω όλες τις διαφάνειες;**

Ναι. Λάβετε πληροφορίες της παρουσίασης, ελέγξτε αν υπάρχει προστασία με κωδικό πρόσβασης ανοίγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε ένα πλήρες αντικείμενο παρουσίασης.

**Υποστηρίζουν οι διαδικασίες ελέγχου κωδικού πρόσβασης τόσο PPT όσο και PPTX;**

Ναι. Η ανίχνευση και η επικύρωση κωδικών πρόσβασης βάσει διαδρομής αρχείου και ροής συμπεριφέρονται με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.