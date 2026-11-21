---
title: Διαχείριση σημειώσεων παρουσίασης σε Android
linktitle: Σημειώσεις παρουσίασης
type: docs
weight: 110
url: /el/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Προσαρμόστε τις σημειώσεις παρουσίασης με το Aspose.Slides για Android μέσω Java. Εργαστείτε απρόσκοπτα με σημειώσεις PowerPoint και OpenDocument για να αυξήσετε την παραγωγικότητά σας."
---
## **Επισκόπηση**

Aspose.Slides υποστηρίζει την αφαίρεση διαφανειών σημειώσεων από μια παρουσίαση. Σε αυτό το θέμα, θα παρουσιάσουμε αυτή τη λειτουργία, συμπεριλαμβανομένου του πώς να αφαιρέσετε σημειώσεις και πώς να εφαρμόσετε στυλ σε διαφάνειες σημειώσεων σε μια παρουσίαση. Aspose.Slides σας επιτρέπει να αφαιρέσετε σημειώσεις από οποιαδήποτε διαφάνεια και επίσης να εφαρμόσετε στυλ σε υπάρχουσες σημειώσεις. Οι προγραμματιστές μπορούν να αφαιρέσουν σημειώσεις με τους ακόλουθους τρόπους:

- Αφαίρεση σημειώσεων από μια συγκεκριμένη διαφάνεια σε μια παρουσίαση.
- Αφαίρεση σημειώσεων από όλες τις διαφάνειες σε μια παρουσίαση.

Για να διαβάσετε ή να αλλάξετε τις διαστάσεις της σελίδας σημειώσεων, να αλλάξετε προσανατολισμό και να ελέγξετε τη συμπεριφορά εξαγωγής, δείτε [Μέγεθος σελίδας σημειώσεων](/slides/el/androidjava/notes-size/).

## **Αφαίρεση σημειώσεων από διαφάνεια**
Οι σημειώσεις από μια συγκεκριμένη διαφάνεια μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
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

## **Αφαίρεση σημειώσεων από παρουσίαση**
Οι σημειώσεις από όλες τις διαφάνειες σε μια παρουσίαση μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Αφαίρεση σημειώσεων όλων των διαφανειών
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
Η μέθοδος [getNotesStyle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) προστέθηκε στο interface [IMasterNotesSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IMasterNotesSlide) και στην κλάση [MasterNotesSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/MasterNotesSlide) αντίστοιχα. Αυτή η ιδιότητα καθορίζει το στυλ του κειμένου των σημειώσεων. Η υλοποίηση παρουσιάζεται στο παρακάτω παράδειγμα.

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Λήψη στυλ κειμένου MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Ορισμός συμβολικού στίξης για τις παραγράφους πρώτου επιπέδου
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

Οι σημειώσεις προσπελαύνονται μέσω του διαχειριστή σημειώσεων της διαφάνειας: η διαφάνεια διαθέτει ένα [NotesSlideManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notesslidemanager/) και μια [μέθοδος](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) που επιστρέφει το αντικείμενο σημειώσεων, ή `null` εάν δεν υπάρχουν σημειώσεις.

**Υπάρχουν διαφορές στην υποστήριξη σημειώσεων μεταξύ των εκδόσεων του PowerPoint με τις οποίες λειτουργεί η βιβλιοθήκη;**

Η βιβλιοθήκη στοχεύει σε μια ευρεία γκάμα μορφών Microsoft PowerPoint (97‑και νεότερες) και ODP· οι σημειώσεις υποστηρίζονται σε αυτές τις μορφές χωρίς να εξαρτώνται από εγκατεστημένο αντίγραφο του PowerPoint.