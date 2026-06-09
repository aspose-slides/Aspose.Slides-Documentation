---
title: Ανακτηση και Ενημερωση Ιδιοτητων Προβολης Παρουσιασης σε .NET
linktitle: Ιδιοτητες Προβολης
type: docs
weight: 80
url: /el/net/presentation-view-properties/
keywords:
- ιδιοτητες προβολης
- κανονικη προβολη
- περιεχομενο περιγραμματος
- εικονιδια περιγραμματος
- πιαση κατακορυφου διαχωριστη
- απλη προβολη
- κατασταση γραμμης
- μεγεθος διαστασης
- αυτοματη προσαρμογη
- προεπιλεγμενη μεγενθυση
- PowerPoint
- OpenDocument
- παρουσιαση
- .NET
- C#
- Aspose.Slides
description: "Ανακαλυψτε τις ιδιοτητες προβολης του Aspose.Slides για .NET για να προσαρμοσετε τις μορφες διαφανειων PPT, PPTX και ODP—ρυθμιστε τις διαταξεις, τα επιπεδα μεγενθυσης και τις ρυθμισεις εμφανισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθαυτή, μια πλευρική περιοχή περιεχομένου και μια κατώτερη περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφόρων περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η ιδιότητα [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/iviewproperties/properties/normalviewproperties) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες κανονικής προβολής της παρουσίασης.

Προστέθηκαν οι διεπαφές [INormalViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/net/aspose.slides/inormalviewrestoredproperties) και ο τύπος enum [SplitterBarStateType](https://reference.aspose.com/slides/el/net/aspose.slides/splitterbarstatetype).

## **Σχετικά με το INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Η ιδιότητα **ShowOutlineIcons** καθορίζει εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζεται περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Η ιδιότητα **SnapVerticalSplitter** καθορίζει εάν η κατακόρυφη γραμμή διαχωρισμού πρέπει να “κόβει” σε μειωμένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα **PreferSingleView** καθορίζει εάν ο χρήστης προτιμά να βλέπει μια πλήρους παραθύρου περιοχή περιεχομένου αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε ολόκληρο το παράθυρο.

Οι ιδιότητες **VerticalBarState** και **HorizontalBarState** καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η οριζόντια ή κατακόρυφη γραμμή διαχωρισμού. Μια οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ μια κατακόρυφη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** και **SplitterBarStateType.Restored**.

Οι ιδιότητες **RestoredLeft** και **RestoredTop** καθορίζουν το μέγεθος της άνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή **SplitterBarStateType.Restored** έχει εφαρμοστεί αντίστοιχα στις **VerticalBarState** και **HorizontalBarState**.

## **Σχετικά με την αποκατάσταση του INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft) της κανονικής προβολής, όταν η περιοχή είναι ενός μεταβλητού αποκαταστημένου μεγέθους (ούτε μειωμένη ούτε μεγιστοποιημένη).

Η ιδιότητα **DimensionSize** καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η ιδιότητα **AutoAdjust** καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμόζεται για το νέο μέγεθος κατά την αλλαγή του μεγέθους του παραθύρου που περιέχει την προβολή μέσα στην εφαρμογή.

Παρακάτω παρατίθεται ένα παράδειγμα που δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες **ViewProperties.NormalViewProperties** για μια παρουσίαση.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Επαναφορά των ιδιοτήτων προβολής της παρουσίασης
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός της Προεπιλεγμένης Τιμής Εστίασης**

Το Aspose.Slides for .NET υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής εστίασης για μια παρουσίαση, ώστε όταν η παρουσίαση ανοίξει, η εστίαση να είναι ήδη ορισμένη. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties) μιας παρουσίασης. Οι ιδιότητες προβολής διαφάνειας καθώς και οι [NotesViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/properties/notesviewproperties) μπορούν να οριστούν προγραμματικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσετε τις Ιδιότητες Προβολής μιας παρουσίασης στο Aspose.Slides.

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)
1. Ορίστε τις [Properties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties) προβολής της παρουσίασης
1. Γράψτε την παρουσίαση ως αρχείο PPTX

Στο παρακάτω παράδειγμα, ορίσαμε την τιμή εστίασης τόσο για την προβολή διαφάνειας όσο και για την προβολή σημειώσεων.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Τιμή μεγέθυνσης σε ποσοστά για προβολή διαφάνειας
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Τιμή μεγέθυνσης σε ποσοστά για προβολή σημειώσεων 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικά τμήματα μιας παρουσίασης;**

Οι [Ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/viewproperties/) ορίζονται σε επίπεδο παρουσίασης ([Κανονική προβολή](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/normalviewproperties/)/[Προβολή διαφάνειας](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/slideviewproperties/)), όχι ανά τμήμα, επομένως ένα μόνο σύνολο παραμέτρων εφαρμόζεται σε όλο το έγγραφο κατά το άνοιγμα.

**Μπορώ να καθορίσω εκ των προτέρων διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι εφαρμογές προβολής μπορεί να λαμβάνουν υπόψη τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να προετοιμάσω ένα πρότυπο με προορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με το ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/viewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.