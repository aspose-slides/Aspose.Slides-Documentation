---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε .NET
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/net/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- συγκράτηση κατακόρυφου διαχωριστή
- μονή προβολή
- κατάσταση μπάρας
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για .NET για προσαρμογή μορφών διαφανειών PPT, PPTX και ODP—ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής της στο αρχείο, έτσι ώστε όταν ανοίγεται ξανά η προβολή να είναι στην ίδια κατάσταση όπως όταν αποθηκεύτηκε τελευταία φορά η παρουσίαση.

Η ιδιότητα [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/iviewproperties/properties/normalviewproperties) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης.

Οι διεπαφές [INormalViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/net/aspose.slides/inormalviewrestoredproperties) και οι απογόνους τους, καθώς και το enum [SplitterBarStateType](https://reference.aspose.com/slides/el/net/aspose.slides/splitterbarstatetype) προστέθηκαν.

## **Σχετικά με INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Η ιδιότητα **ShowOutlineIcons** καθορίζει αν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζεται περιεχόμενο περίγραμμα σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Η ιδιότητα **SnapVerticalSplitter** καθορίζει αν ο κατακόρυφος διαχωριστής πρέπει να «κολλάει» σε μειωμένη κατάσταση όταν η πλευρική περιοχή είναι επαρκώς μικρή.

Η ιδιότητα **PreferSingleView** καθορίζει αν ο χρήστης προτιμά να δει μια μονή περιοχή περιεχομένου σε πλήρη παράθυρο αντί της τυπικής κανονικής προβολής με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι ιδιότητες **VerticalBarState** και **HorizontalBarState** καθορίζουν την κατάσταση στην οποία πρέπει να εμφανίζεται η οριζόντια ή κατακόρυφη μπάρκα διαχωριστή. Μία οριζόντια μπάρκα διαχωριστή χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κατακόρυφη μπάρκα διαχωριστή χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** και **SplitterBarStateType.Restored**.

Οι ιδιότητες **RestoredLeft** και **RestoredTop** καθορίζουν το μέγεθος της επάνω ή της πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή **SplitterBarStateType.Restored** εφαρμοστεί αντίστοιχα στις ιδιότητες **VerticalBarState** και **HorizontalBarState**.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε μειωμένη ούτε μεγιστοποιημένη).

Η ιδιότητα **DimensionSize** καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft).

Η ιδιότητα **AutoAdjust** καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμόζεται στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή μέσα στην εφαρμογή.

Παρακάτω δίνεται ένα παράδειγμα που δείχνει πώς μπορείτε να προσπελάσετε τις ιδιότητες **ViewProperties.NormalViewProperties** για μια παρουσίαση.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Ορισμός Προεπιλεγμένης Τιμής Zoom**

Το Aspose.Slides για .NET υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για την παρουσίαση ώστε όταν η παρουσίαση ανοίξει, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties) μιας παρουσίασης. Οι ιδιότητες προβολής διαφάνειας καθώς και οι [NotesViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/properties/notesviewproperties) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις Ιδιότητες Προβολής της Παρουσίασης στο Aspose.Slides.

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)
1. Ορίστε τις [Properties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties) Προβολής της Παρουσίασης
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX

Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Απόστασης Πλέγματος**

Χρησιμοποιήστε τις [Presentation.ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/viewproperties/) για να προσπελάσετε τις ρυθμίσεις προβολής σε ολόκληρη την παρουσίαση. Η ιδιότητα [IViewProperties.GridSpacing](https://reference.aspose.com/slides/el/net/aspose.slides/iviewproperties/gridspacing/) διαβάζει ή αλλάζει το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση ισχύει για ολόκληρη την παρουσίαση, όχι για μεμονωμένη διαφάνεια. Η απόσταση πλέγματος ορίζεται σε σημεία, όπου 72 σημεία ισοδυναμούν με ένα ίντσα. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει την τρέχουσα απόσταση πλέγματος, ορίζει ένα διάστημα τέταρτου ίντσας και αποθηκεύει το αποτέλεσμα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/net/drawing-guides/). Η απόσταση πλέγματος ελέγχει ένα τακτικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι μεμονωμένα τοποθετημένες οριζόντιες ή κατακόρυφες ευθυγραμμιστικές γραμμές. Η προσθήκη, μετακίνηση ή διαγραφή οδηγών σχεδίασης δεν αλλάζει την απόσταση πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση της απόστασης πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του θεατή ή του επεξεργαστή.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίας**

Χρησιμοποιήστε τις [Presentation.ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/viewproperties/) για να προσπελάσετε τις ρυθμίσεις προβολής σε ολόκληρη την παρουσίαση. Διαβάστε ή τροποποιήστε το [IViewProperties.ShowComments](https://reference.aspose.com/slides/el/net/aspose.slides/iviewproperties/showcomments/) για να αποθηκεύσετε μια προτίμηση σχετικά με το αν τα σχόλια θα εμφανίζονται όταν η παρουσίαση ανοίγει στο PowerPoint ή σε κάποιο άλλο συμβατό πρόγραμμα.

Αυτή η ρύθμιση ελέγχει μόνο την αποθηκευμένη προτίμηση προβολής. Δεν προσθέτει, αφαιρεί, επεξεργάζεται ή επιλύει σχόλια. Η απόκρυψη σχολίων διατηρεί το περιεχόμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Δείτε τις [Presentation Comments](/slides/el/net/presentation-comments/) για ενέργειες που αλλάζουν τα ίδια τα σχόλια.

Το παρακάτω παράδειγμα απαιτεί ένα υπάρχον `comments.pptx` που περιέχει σχόλια. Εκτυπώνει τη τρέχουσα ρύθμιση ορατότητας, ζητά την απόκρυψη των σχολίων και αποθηκεύει ένα νέο PPTX χωρίς να αφαιρέσει κανένα σχόλιο. Επίσης ορίζει το [IViewProperties.LastView](https://reference.aspose.com/slides/el/net/aspose.slides/iviewproperties/lastview/) σε [ViewType.SlideView](https://reference.aspose.com/slides/el/net/aspose.slides/viewtype/) για να διαμορφώσει την αρχική προβολή επεξεργασίας μαζί με την ορατότητα σχολίων.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Αυτή η ρύθμιση δεν καθορίζει αν τα σχόλια θα συμπεριλαμβάνονται στις εξαγωγές PDF, HTML, εικόνα, σημειώσεις ή φυλλάδια. Ρυθμίστε τις σχετικές επιλογές εξαγωγής ξεχωριστά.

## **Συχνές Ερωτήσεις**

**Γιατί το πλέγμα δεν είναι ορατό μετά το άνοιγμα ξανά της παρουσίασης;**

Το αρχείο αποθηκεύει την απόσταση πλέγματος, αλλά ο επεξεργαστής ελέγχει αν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η διαγραφή των οδηγών σχεδίασης την απόσταση πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και η απόσταση πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η διαγραφή των οδηγών δεν αλλάζει το αποθηκευμένο διάστημα πλέγματος.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/viewproperties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/slideviewproperties/)), όχι ανά ενότητα, έτσι ένα σύνολο παραμέτρων ισχύει για ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να ορίσω προκαθορισμένες διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινόχρηστες. Οι εφαρμογές προβολής μπορεί να σεβαστούν τις προτιμήσεις των χρηστών, αλλά το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προκαθορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/viewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική ρύθμιση προβολής.