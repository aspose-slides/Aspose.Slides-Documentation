---
title: Προστασία Εγγραφής Παρουσιάσεων σε JavaScript
linktitle: Προστασία Εγγραφής
type: docs
weight: 25
url: /el/nodejs-java/write-protected-presentation/
keywords:
- προστασία εγγραφής
- προστασία εγγραφής PowerPoint
- κωδικός για τροποποίηση
- περιορισμός επεξεργασίας παρουσίασης
- αφαίρεση προστασίας εγγραφής
- επικύρωση κωδικού τροποποίησης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ορίστε, εντοπίστε, επικυρώστε και αφαιρέστε κωδικούς προστασίας εγγραφής σε παρουσιάσεις PowerPoint PPT και PPTX χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java."
---
## **Εισαγωγή**

Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση μιας παρουσίασης, αλλά δεν κρυπτογραφεί το περιεχόμενό της. Οι χρήστες μπορούν να φορτώσουν και να προβάλλουν μια παρουσίαση με προστασία εγγραφής χωρίς τον κωδικό. Ανάλογα με την εφαρμογή, ενδέχεται επίσης να μπορούν να επεξεργαστούν το περιεχόμενο και να το αποθηκεύσουν με διαφορετικό όνομα, έτσι η προστασία εγγραφής δεν πρέπει να θεωρείται μηχανισμός εχεμύθειας.

Ένας κωδικός ανοίγματος εξυπηρετεί διαφορετικό σκοπό: κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Για κρυπτογράφηση παρουσίασης ή επαλήθευση κωδικού ανοίγματος, δείτε [Προστασία Παρουσιασεων με Κωδικο](/slides/el/nodejs-java/password-protected-presentation/).

Οι ροές εργασίας σε αυτό το άρθρο εφαρμόζονται τόσο σε παρουσιάσεις PPT όσο και PPTX. Τα παραδείγματα χρησιμοποιούν αρχεία PPTX· όταν αποθηκεύετε σε PPT, χρησιμοποιήστε την επέκταση `.ppt` και την αντίστοιχη μορφή αποθήκευσης PPT.

## **Ορίστε Προστασία Εγγραφής σε Παρουσίαση**

Χρησιμοποιήστε [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) για να ορίσετε κωδικό πρόσβασης για τη τροποποίηση μιας παρουσίασης. Η αποθήκευση της παρουσίασης διατηρεί τη ρύθμιση προστασίας.

Το παρακάτω παράδειγμα ορίζει προστασία εγγραφής σε μια παρουσίαση PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Φορτώστε μια Παρουσίαση με Προστασία Εγγραφής**

Καθώς η προστασία εγγραφής δεν κρυπτογραφεί το περιεχόμενο της παρουσίασης, δεν απαιτείται κωδικός για τη φόρτωση της παρουσίασης. Ο κωδικός είναι σχετικός μόνο κατά την επαλήθευση εξουσιοδότησης για τροποποίηση της προστατευμένης παρουσίασης.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Μην περάσετε κωδικό προστασίας εγγραφής στο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword). Αυτή η μέθοδος αποδέχεται έναν κωδικό ανοίγματος για κρυπτογραφημένο περιεχόμενο. Εάν μια παρουσίαση έχει και τους δύο τύπους προστασίας, δώστε τον κωδικό ανοίγματος για να τη φορτώσετε και χειριστείτε ξεχωριστά τον κωδικό προστασίας εγγραφής.

## **Αφαίρεση Προστασίας Εγγραφής από Παρουσίαση**

Χρησιμοποιήστε [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) για να αφαιρέσετε τον περιορισμό τροποποίησης, και μετά αποθηκεύστε την παρουσίαση.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Εάν μια Παρουσίαση Έχει Προστασία Εγγραφής**

Για να ελέγξετε ένα αρχείο χωρίς τη δημιουργία πλήρους αντικειμένου [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/), καλέστε [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) και ελέγξτε το [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). Η μέθοδος χρησιμοποιεί το [NullableBool](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/nullablebool/) και επιστρέφει `NullableBool.True` όταν ανιχνεύεται προστασία εγγραφής.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Η μέθοδος ροής [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) παρέχει τις ίδιες πληροφορίες για μια παρουσίαση που παρέχεται ως ρεύμα ανάγνωσης του Node.js.

## **Επικύρωση Κωδικού Προστασίας Εγγραφής**

Χρησιμοποιήστε [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) για να επικυρώσετε έναν κωδικό τροποποίησης χωρίς τη φόρτωση της πλήρους παρουσίασης. Ελέγξτε πρώτα το [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) ώστε η εφαρμογή να ζητά ή να επικυρώνει κωδικό μόνο όταν υπάρχει προστασία εγγραφής.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) επικυρώνει μόνο τον κωδικό προστασίας εγγραφής. Δεν επικυρώνει κωδικό ανοίγματος ούτε καθορίζει αν μπορεί να φορτωθεί κρυπτογραφημένο περιεχόμενο. Αντίστροφα, το [PresentationInfo.checkPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#checkPassword) επικυρώνει μόνο έναν κωδικό ανοίγματος. Εάν μια πλήρης παρουσίαση έχει ήδη φορτωθεί, το [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) παρέχει τον ισοδύναμο έλεγχο προστασίας εγγραφής μέσω του διαχειριστή προστασίας του.

Σε παραγωγικές εφαρμογές, μην καταγράφετε τους κωδικούς ή τους ενσωματώνετε σε μηνύματα διάγνωσης. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης και κρατήστε τους κωδικούς στη μνήμη μόνο για όσο διάστημα απαιτείται.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Προστασία Παρουσανων με Κωδικο](/slides/el/nodejs-java/password-protected-presentation/)
- [Παρουσιασεις Μόνο για Ανάγνωση](/slides/el/nodejs-java/read-only-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Κρυπτογραφεί η προστασία εγγραφής μια παρουσίαση;**

Όχι. Περιορίζει τη τροποποίηση αλλά αφήνει το περιεχόμενο της παρουσίασης διαθέσιμο για φόρτωση και προβολή.

**Απαιτείται ο κωδικός προστασίας εγγραφής για το άνοιγμα μιας παρουσίασης;**

Όχι. Μόνο ένας κωδικός ανοίγματος απαιτείται για τη φόρτωση κρυπτογραφημένου περιεχομένου παρουσίασης.

**Μπορεί μια παρουσίαση να έχει τόσο κωδικό ανοίγματος όσο και κωδικό προστασίας εγγραφής;**

Ναι. Δώστε τον κωδικό ανοίγματος μέσω των επιλογών φόρτωσης για να ανοίξετε την κρυπτογραφημένη παρουσίαση και επικυρώστε ξεχωριστά τον κωδικό προστασίας εγγραφής όταν απαιτείται εξουσιοδότηση τροποποίησης.