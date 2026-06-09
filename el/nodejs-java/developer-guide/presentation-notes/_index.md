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
description: "Προσαρμόστε τις σημειώσεις παρουσίασης σε JavaScript με το Aspose.Slides για Node.js. Εργαστείτε αβίαστα με σημειώσεις PowerPoint και OpenDocument για να αυξήσετε την παραγωγικότητά σας."
---
## **Επισκόπηση**

Το Aspose.Slides υποστηρίζει την αφαίρεση διαφανειών σημειώσεων από μια παρουσίαση. Σε αυτό το θέμα, θα παρουσιάσουμε αυτήν τη δυνατότητα, συμπεριλαμβανομένου του πώς να αφαιρέσετε σημειώσεις και πώς να εφαρμόσετε στυλ στις διαφάνειες σημειώσεων σε μια παρουσίαση. Το Aspose.Slides σας επιτρέπει να αφαιρέσετε σημειώσεις από οποιαδήποτε διαφάνεια και επίσης να εφαρμόσετε στυλισμό σε υπάρχουσες σημειώσεις. Οι προγραμματιστές μπορούν να αφαιρέσουν σημειώσεις με τους ακόλουθους τρόπους:

- Αφαίρεση σημειώσεων από μια συγκεκριμένη διαφάνεια σε μια παρουσίαση.
- Αφαίρεση σημειώσεων από όλες τις διαφάνειες σε μια παρουσίαση.

## **Αφαίρεση Σημειώσεων από τη Διαφάνεια**
Οι σημειώσεις μιας συγκεκριμένης διαφάνειας μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
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

## **Αφαίρεση Σημειώσεων από την Παρουσίαση**
Οι σημειώσεις όλων των διαφανειών μιας παρουσίασης μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Αφαίρεση σημειώσεων όλων των διαφανειών
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
[getNotesStyle](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) μέθοδος έχει προστεθεί στην κλάση [MasterNotesSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterNotesSlide) και στην κλάση [MasterNotesSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterNotesSlide) αντίστοιχα. Αυτή η ιδιότητα καθορίζει το στυλ του κειμένου σημειώσεων. Η υλοποίηση επιδεικνύεται στο παρακάτω παράδειγμα.

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Ανάκτηση στυλ κειμένου MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Ορισμός σύμβολου κεφαλαίου για τις παραγράφους του πρώτου επιπέδου
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Ποια οντότητα API παρέχει πρόσβαση στις σημειώσεις μιας συγκεκριμένης διαφάνειας;**

Οι σημειώσεις προσεγγίζονται μέσω του διαχειριστή σημειώσεων της διαφάνειας: η διαφάνεια διαθέτει έναν [NotesSlideManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notesslidemanager/) και μια [method](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) που επιστρέφει το αντικείμενο σημειώσεων, ή `null` εάν δεν υπάρχουν σημειώσεις.

**Υπάρχουν διαφορές στην υποστήριξη σημειώσεων μεταξύ των εκδόσεων του PowerPoint με τις οποίες λειτουργεί η βιβλιοθήκη;**

Η βιβλιοθήκη στοχεύει σε ένα ευρύ φάσμα μορφών Microsoft PowerPoint (97–νέας) και ODP· οι σημειώσεις υποστηρίζονται σε αυτές τις μορφές χωρίς εξάρτηση από εγκατεστημένο αντίγραφο του PowerPoint.