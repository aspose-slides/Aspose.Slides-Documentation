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

Aspose.Slides υποστηρίζει την αφαίρεση διαφανειών σημειώσεων από μια παρουσίαση. Σε αυτό το θέμα, θα παρουσιάσουμε αυτή τη δυνατότητα, συμπεριλαμβανομένου του πώς να αφαιρέσετε σημειώσεις και πώς να εφαρμόσετε στυλ σε διαφάνειες σημειώσεων στην παρουσίαση. Aspose.Slides σας επιτρέπει να αφαιρέσετε σημειώσεις από οποιαδήποτε διαφάνεια και επίσης να εφαρμόσετε μορφοποίηση σε υπάρχουσες σημειώσεις. Οι προγραμματιστές μπορούν να αφαιρέσουν σημειώσεις με τους παρακάτω τρόπους:

- Αφαίρεση σημειώσεων από μια συγκεκριμένη διαφάνεια σε μια παρουσίαση.  
- Αφαίρεση σημειώσεων από όλες τις διαφάνειες σε μια παρουσίαση.

Για να διαβάσετε ή να αλλάξετε τις διαστάσεις της σελίδας σημειώσεων, να αλλάξετε προσανατολισμό ή να ελέγξετε τη συμπεριφορά εξαγωγής, δείτε [Μέγεθος Σελίδας Σημειώσεων](/slides/el/net/notes-size/).

## **Αφαίρεση Σημειώσεων από Διαφάνεια**
Οι σημειώσεις κάποιων συγκεκριμένων διαφανειών μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία ενός αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation presentation = new Presentation("AccessSlides.pptx");

// Αφαίρεση σημειώσεων από την πρώτη διαφάνεια
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Αποθήκευση παρουσίασης στο δίσκο
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Αφαίρεση Σημειώσεων από Όλες τις Διαφάνειες**
Οι σημειώσεις όλων των διαφανειών μιας παρουσίασης μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία ενός αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Αφαίρεση σημειώσεων από όλες τις διαφάνειες
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Αποθήκευση παρουσίασης στο δίσκο
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Στυλ Σημειώσεων**
Η ιδιότητα NotesStyle έχει προστεθεί στη διεπαφή [IMasterNotesSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasternotesslide) και στην κλάση [MasterNotesSlide](https://reference.aspose.com/slides/el/net/aspose.slides/masternotesslide) αντίστοιχα. Αυτή η ιδιότητα καθορίζει το στυλ του κειμένου σημειώσεων. Η υλοποίηση φαίνεται στο παρακάτω παράδειγμα.

```c#
using Aspose.Slides;

// Δημιουργία κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Ανάκτηση του στυλ κειμένου MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // Ορισμός σύμβολου κουκκίδας για τις παραγράφους του πρώτου επιπέδου
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Αποθήκευση του αρχείου PPTX στον δίσκο
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **Συχνές Ερωτήσεις**

### Ποια οντότητα API παρέχει πρόσβαση στις σημειώσεις μιας συγκεκριμένης διαφάνειας;
Οι σημειώσεις προσπελάζονται μέσω του διαχειριστή σημειώσεων της διαφάνειας: η διαφάνεια διαθέτει έναν [NotesSlideManager](https://reference.aspose.com/slides/el/net/aspose.slides/notesslidemanager/) και μια [ιδιότητα](https://reference.aspose.com/slides/el/net/aspose.slides/notesslidemanager/notesslide/) που επιστρέφει το αντικείμενο σημειώσεων, ή `null` εάν δεν υπάρχουν σημειώσεις.

### Υπάρχουν διαφορές στην υποστήριξη σημειώσεων μεταξύ των εκδόσεων PowerPoint με τις οποίες λειτουργεί η βιβλιοθήκη;
Η βιβλιοθήκη στοχεύει σε ευρύ φάσμα μορφών Microsoft PowerPoint (97–και νεότερες) και ODP· οι σημειώσεις υποστηρίζονται σε αυτές τις μορφές χωρίς να απαιτείται εγκατεστημένο αντίγραφο του PowerPoint.