---
title: Διαχείριση Σημειώσεων Παρουσίασης σε Python
linktitle: Σημειώσεις Παρουσίασης
type: docs
weight: 110
url: /el/python-net/presentation-notes/
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
- Python
- Aspose.Slides
description: "Προσαρμόστε τις σημειώσεις παρουσίασης με το Aspose.Slides για Python μέσω .NET. Εργαστείτε άψογα με σημειώσεις PowerPoint και OpenDocument για να αυξήσετε την παραγωγικότητά σας."
---
## **Επισκόπηση**

Aspose.Slides υποστηρίζει την κατάργηση σημειώσεων διαφανειών από μια παρουσίαση. Σε αυτό το θέμα, θα παρουσιάσουμε αυτή τη λειτουργία, συμπεριλαμβανομένου του πώς να καταργήσετε σημειώσεις και πώς να εφαρμόσετε στυλ σε διαφάνειες σημειώσεων σε μια παρουσίαση. Το Aspose.Slides σας επιτρέπει να καταργήσετε σημειώσεις από οποιαδήποτε διαφάνεια και επίσης να εφαρμόσετε μορφοποίηση σε υπάρχουσες σημειώσεις. Οι προγραμματιστές μπορούν να καταργήσουν σημειώσεις με τους ακόλουθους τρόπους:

- Κατάργηση σημειώσεων από συγκεκριμένη διαφάνεια σε μια παρουσίαση.
- Κατάργηση σημειώσεων από όλες τις διαφάνειες σε μια παρουσίαση.

## **Κατάργηση Σημειώσεων από Διαφάνεια**
Οι σημειώσεις μιας συγκεκριμένης διαφάνειας μπορούν να καταργηθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```py
import aspose.slides as slides

# Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Αφαίρεση σημειώσεων της πρώτης διαφάνειας
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # αποθήκευση παρουσίασης στο δίσκο
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κατάργηση Σημειώσεων από Όλες τις Διαφάνειες**
Οι σημειώσεις όλων των διαφανειών μιας παρουσίασης μπορούν να καταργηθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```py
import aspose.slides as slides

# Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Αφαίρεση σημειώσεων από όλες τις διαφάνειες
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # αποθήκευση παρουσίασης στο δίσκο
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Στυλ Σημειώσεων**
Η ιδιότητα [notes_style](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslide/notes_style/) έχει προστεθεί στην κλάση [MasterNotesSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslide/). Αυτή η ιδιότητα καθορίζει το στυλ κειμένου σημειώσεων. Η υλοποίηση παρουσιάζεται στο παρακάτω παράδειγμα.

```py
import aspose.slides as slides

# Δημιουργία κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Λήψη στυλ κειμένου MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Set σύμβολο σφαίρας για τις παραγράφους πρώτου επιπέδου
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # αποθήκευση του αρχείου PPTX στο δίσκο
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Ποια οντότητα API παρέχει πρόσβαση στις σημειώσεις μιας συγκεκριμένης διαφάνειας;**

Οι σημειώσεις προσβάλλονται μέσω του διαχειριστή σημειώσεων της διαφάνειας: η διαφάνεια διαθέτει έναν [NotesSlideManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/notesslidemanager/) και μια [property](https://reference.aspose.com/slides/el/python-net/aspose.slides/notesslidemanager/notes_slide/) που επιστρέφει το αντικείμενο σημειώσεων, ή `None` εάν δεν υπάρχουν σημειώσεις.

**Υπάρχουν διαφορές στην υποστήριξη σημειώσεων μεταξύ των εκδόσεων του PowerPoint με τις οποίες λειτουργεί η βιβλιοθήκη;**

Η βιβλιοθήκη στοχεύει σε ένα ευρύ φάσμα μορφών Microsoft PowerPoint (97–νεότερες) και ODP· οι σημειώσεις υποστηρίζονται σε αυτές τις μορφές χωρίς να εξαρτώνται από εγκατεστημένο αντίγραφο του PowerPoint.