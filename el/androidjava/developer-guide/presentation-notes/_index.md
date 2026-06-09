---
title: Διαχείριση Σημειώσεων Παρουσίασης σε Android
linktitle: Σημειώσεις Παρουσίασης
type: docs
weight: 110
url: /el/androidjava/presentation-notes/
keywords:
- σημειώσεις
- διαφάνεια σημειώσεων
- προσθήκη σημειώσεων
- κατάργηση σημειώσεων
- στυλ σημειώσεων
- κύριες σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσαρμόστε τις σημειώσεις παρουσίασης με το Aspose.Slides για Android μέσω Java. Εργαστείτε άψογα με σημειώσεις PowerPoint και OpenDocument για να αυξήσετε την παραγωγικότητα σας."
---
## **Επισκόπηση**

Το Aspose.Slides υποστηρίζει την αφαίρεση διαφανειών σημειώσεων από μια παρουσίαση. Σε αυτό το θέμα θα παρουσιάσουμε αυτή τη δυνατότητα, συμπεριλαμβανομένου του πώς να αφαιρέσετε σημειώσεις και πώς να εφαρμόσετε στυλ σε διαφάνειες σημειώσεων σε μια παρουσίαση. Το Aspose.Slides σας επιτρέπει να αφαιρέσετε σημειώσεις από οποιαδήποτε διαφάνεια και επίσης να εφαρμόσετε μορφοποίηση σε υπάρχουσες σημειώσεις. Οι προγραμματιστές μπορούν να αφαιρέσουν σημειώσεις με τους παρακάτω τρόπους:

- Κατάργηση σημειώσεων από συγκεκριμένη διαφάνεια σε μια παρουσίαση.
- Κατάργηση σημειώσεων από όλες τις διαφάνειες σε μια παρουσίαση.

## **Κατάργηση σημειώσεων από διαφάνεια**
Οι σημειώσεις μιας συγκεκριμένης διαφάνειας μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```java
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Αφαίρεση σημειώσεων της πρώτης διαφάνειας
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Κατάργηση σημειώσεων από παρουσίαση**
Οι σημειώσεις όλων των διαφανειών μιας παρουσίασης μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```java
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Αφαίρεση σημειώσεων από όλες τις διαφάνειες
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη στυλ σημειώσεων**
Η μέθοδος [getNotesStyle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) προστέθηκε στο interface [IMasterNotesSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IMasterNotesSlide) και στην κλάση [MasterNotesSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/MasterNotesSlide) αντίστοιχα. Αυτή η ιδιότητα καθορίζει το στυλ του κειμένου σημειώσεων. Η υλοποίηση παρουσιάζεται στο παρακάτω παράδειγμα.

```java
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Λάβετε το στυλ κειμένου MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Ορίστε σύμβολο κουκίδας για τις παραγράφους πρώτου επιπέδου
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Ποια οντότητα API παρέχει πρόσβαση στις σημειώσεις μιας συγκεκριμένης διαφάνειας;**

Οι σημειώσεις προσπελάζονται μέσω του διαχειριστή σημειώσεων της διαφάνειας: η διαφάνεια διαθέτει έναν [NotesSlideManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notesslidemanager/) καθώς και μια [method](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) που επιστρέφει το αντικείμενο σημειώσεων ή `null` αν δεν υπάρχουν σημειώσεις.

**Υπάρχουν διαφορές στην υποστήριξη σημειώσεων μεταξύ των εκδόσεων του PowerPoint με τις οποίες λειτουργεί η βιβλιοθήκη;**

Η βιβλιοθήκη στοχεύει σε μεγάλο εύρος μορφών Microsoft PowerPoint (97‑και νεότερων) και ODP· οι σημειώσεις υποστηρίζονται σε αυτές τις μορφές χωρίς να απαιτείται εγκατεστημένο αντίγραφο του PowerPoint.