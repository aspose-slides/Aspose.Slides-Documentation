---
title: Διαχείριση Σημειώσεων Παρουσίασης σε .NET
linktitle: Σημειώσεις Παρουσίασης
type: docs
weight: 110
url: /el/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Προσαρμόστε τις σημειώσεις παρουσίασης με το Aspose.Slides για .NET. Εργαστείτε άψογα με σημειώσεις PowerPoint και OpenDocument για να αυξήσετε την παραγωγικότητά σας."
---
## **Επισκόπηση**

Το Aspose.Slides υποστηρίζει την αφαίρεση σημειώσεων διαφανειών από μια παρουσίαση. Σε αυτό το θέμα, θα παρουσιάσουμε αυτή τη δυνατότητα, συμπεριλαμβανομένου του πώς να αφαιρέσετε σημειώσεις και πώς να εφαρμόσετε στυλ στις σημειώσεις διαφανειών σε μια παρουσίαση. Το Aspose.Slides σας επιτρέπει να αφαιρέσετε σημειώσεις από οποιαδήποτε διαφάνεια και επίσης να εφαρμόσετε στυλ σε υπάρχουσες σημειώσεις. Οι προγραμματιστές μπορούν να αφαιρέσουν τις σημειώσεις με τους εξής τρόπους:

- Αφαίρεση σημειώσεων από συγκεκριμένη διαφάνειας σε μια παρουσίαση.
- Αφαίρεση σημειώσεων από όλες τις διαφάνειες σε μια παρουσίαση.

## **Κατάργηση Σημειώσεων από Διαφάνεια**
Οι σημειώσεις μιας συγκεκριμένης διαφάνειας μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```c#
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
// Αφαίρεση σημειώσεων της πρώτης διαφάνειας
// Αποθήκευση παρουσίασης στον δίσκο
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Removing notes of first slide
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Save presentation to disk
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Κατάργηση Σημειώσεων από Όλες τις Διαφάνειες**
Οι σημειώσεις όλων των διαφανειών μιας παρουσίασης μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```c#
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Αφαίρεση σημειώσεων από όλες τις διαφάνειες
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Αποθήκευση παρουσίασης στον δίσκο
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Στυλ Σημειώσεων**
Η ιδιότητα NotesStyle προστέθηκε στη διεπαφή [IMasterNotesSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasternotesslide) και στην κλήση [MasterNotesSlide](https://reference.aspose.com/slides/el/net/aspose.slides/masternotesslide) αντίστοιχα. Αυτή η ιδιότητα καθορίζει το στυλ του κειμένου σημειώσεων. Η υλοποίηση δείχνεται στο παρακάτω παράδειγμα.

```c#
// Δημιουργία κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Λήψη στυλ κειμένου MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // Ορισμός σύμβολου κουκίδας για τις παραγράφους του πρώτου επιπέδου
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Αποθήκευση του αρχείου PPTX στον δίσκο
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **Συχνές Ερωτήσεις**

**Ποιο αντικείμενο API παρέχει πρόσβαση στις σημειώσεις μιας συγκεκριμένης διαφάνειας;**

Οι σημειώσεις προσπελάζονται μέσω του διαχειριστή σημειώσεων της διαφάνειας: η διαφάνεια διαθέτει ένα [NotesSlideManager](https://reference.aspose.com/slides/el/net/aspose.slides/notesslidemanager/) και μια [property](https://reference.aspose.com/slides/el/net/aspose.slides/notesslidemanager/notesslide/) που επιστρέφει το αντικείμενο σημειώσεων, ή `null` εάν δεν υπάρχουν σημειώσεις.

**Υπάρχουν διαφορές στην υποστήριξη σημειώσεων μεταξύ των εκδόσεων του PowerPoint με τις οποίες λειτουργεί η βιβλιοθήκη;**

Η βιβλιοθήκη στοχεύει σε μια ευρεία γκάμα μορφών Microsoft PowerPoint (97‑και νεότερες) και ODP· οι σημειώσεις υποστηρίζονται σε αυτές τις μορφές χωρίς να εξαρτώνται από εγκατεστημένο αντίγραφο του PowerPoint.