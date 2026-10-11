---
title: Διαχείριση Σημειώσεων Παρουσίασης σε JavaScript
linktitle: Σημειώσεις Παρουσίασης
type: docs
weight: 110
url: /el/nodejs-java/presentation-notes/
keywords:
- σημειώσεις
- διαφάνεια σημειώσεων
- προσθήκη σημειώσεων
- αφαίρεση σημειώσεων
- στυλ σημειώσεων
- κύριες σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσαρμόστε τις σημειώσεις παρουσίασης σε JavaScript με το Aspose.Slides για Node.js. Εργαστείτε αβίαστα με σημειώσεις PowerPoint και OpenDocument για να ενισχύσετε τη παραγωγικότητά σας."
---
## **Επισκόπηση**

Το Aspose.Slides υποστηρίζει την αφαίρεση διαφανειών σημειώσεων από μια παρουσίαση. Σε αυτό το θέμα, θα παρουσιάσουμε αυτή τη λειτουργία, συμπεριλαμβανομένου του πώς να αφαιρέσετε τις σημειώσεις και πώς να εφαρμόσετε στυλ σε διαφάνειες σημειώσεων σε μια παρουσίαση. Το Aspose.Slides επιτρέπει την αφαίρεση σημειώσεων από οποιαδήποτε διαφάνεια και επίσης την εφαρμογή στυλ σε υπάρχουσες σημειώσεις. Οι προγραμματιστές μπορούν να αφαιρέσουν σημειώσεις με τους εξής τρόπους:

- Αφαίρεση σημειώσεων από μια συγκεκριμένη διαφάνεια σε μια παρουσίαση.
- Αφαίρεση σημειώσεων από όλες τις διαφάνειες σε μια παρουσίαση.

Για να διαβάσετε ή να αλλάξετε τις διαστάσεις της σελίδας σημειώσεων, να αλλάξετε προσανατολισμό και να ελέγξετε τη συμπεριφορά εξαγωγής, δείτε το [Notes Page Size](/slides/el/nodejs-java/notes-size/).

## **Αφαίρεση Σημειώσεων από Διαφάνεια**
Οι σημειώσεις από μια συγκεκριμένη διαφάνεια μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Αφαίρεση σημειώσεων της πρώτης διαφάνειας
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αφαίρεση Σημειώσεων από Παρουσίαση**
Οι σημειώσεις από όλες τις διαφάνειες σε μια παρουσίαση μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Αφαίρεση σημειώσεων από όλες τις διαφάνειες
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη NotesStyle**
Η μέθοδος [getNotesStyle](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) προστέθηκε στην κλάση [MasterNotesSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterNotesSlide) και στην κλάση [MasterNotesSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterNotesSlide) αντίστοιχα. Αυτή η ιδιότητα καθορίζει το στυλ του κειμένου σημειώσεων. Η υλοποίηση παρουσιάζεται στο παρακάτω παράδειγμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Λήψη στυλ κειμένου MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Ορισμός σύμβολου σημείου για τις παραγράφους του πρώτου επιπέδου
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Ποιο στοιχείο API παρέχει πρόσβαση στις σημειώσεις μιας συγκεκριμένης διαφάνειας;**

Οι σημειώσεις προβάλλονται μέσω του διαχειριστή σημειώσεων της διαφάνειας: η διαφάνεια διαθέτει έναν [NotesSlideManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notesslidemanager/) και μια [method](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) που επιστρέφει το αντικείμενο σημειώσεων, ή `null` εάν δεν υπάρχουν σημειώσεις.

**Υπάρχουν διαφορές στην υποστήριξη σημειώσεων μεταξύ των εκδόσεων PowerPoint με τις οποίες λειτουργεί η βιβλιοθήκη;**

Η βιβλιοθήκη στοχεύει σε ένα μεγάλο εύρος μορφών Microsoft PowerPoint (97–και νεότερες) και ODP· οι σημειώσεις υποστηρίζονται σε αυτές τις μορφές χωρίς εξάρτηση από εγκατεστημένο αντίγραφο του PowerPoint.