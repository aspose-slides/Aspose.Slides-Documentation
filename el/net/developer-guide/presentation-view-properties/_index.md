---
title: "Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε .NET"
linktitle: "Ιδιότητες Προβολής"
type: docs
weight: 80
url: /el/net/presentation-view-properties/
keywords:
- "ιδιότητες προβολής"
- "κανονική προβολή"
- "περιεχόμενο περιγράμματος"
- "εικονίδια περιγράμματος"
- "προσαρμογή κάθετης γραμμής διαχωρισμού"
- "μονή προβολή"
- "κατάσταση γραμμής"
- "μέγεθος διάστασης"
- "αυτόματη προσαρμογή"
- "προεπιλεγμένη μεγέθυνση"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για .NET για να προσαρμόσετε μορφές διαφανειών PPT, PPTX και ODP — ρυθμίστε διατάξεις, επίπεδα μεγέθυνσης και ρυθμίσεις προβολής."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια ίδια, μια πλευρική περιοχή περιεχομένου και μια περιοχή περιεχομένου στο κάτω μέρος. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύσει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση με αυτήν που αποθηκεύτηκε τελευταία φορά η παρουσίαση.

Η ιδιότητα [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/iviewproperties/properties/normalviewproperties) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης.

Τα interfaces [INormalViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/net/aspose.slides/inormalviewrestoredproperties), και οι απογόνους τους, καθώς και η enum [SplitterBarStateType](https://reference.aspose.com/slides/el/net/aspose.slides/splitterbarstatetype) έχουν προστεθεί.

## **Σχετικά με INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Η ιδιότητα **ShowOutlineIcons** καθορίζει αν η εφαρμογή θα εμφανίζει εικονίδια όταν εμφανίζει περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Η ιδιότητα **SnapVerticalSplitter** καθορίζει αν η κάθετη γραμμή διαχωρισμού θα «προσαρμόζεται» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα **PreferSingleView** καθορίζει αν ο χρήστης προτιμά να δει μια περιοχή περιεχομένου πλήρους παραθύρου αντί της τυπικής κανονικής προβολής με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι ιδιότητες **VerticalBarState** και **HorizontalBarState** καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η αντίστοιχη γραμμή διαχωρισμού (οριζόντια ή κάθετη). Μια οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, η κάθετη χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** και **SplitterBarStateType.Restored**.

Οι ιδιότητες **RestoredLeft** και **RestoredTop** καθορίζουν το μέγεθος της πάνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή **SplitterBarStateType.Restored** εφαρμόζεται αντίστοιχα στην **VerticalBarState** και **HorizontalBarState**.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό αποκατεστημένο μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη).

Η ιδιότητα **DimensionSize** καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η ιδιότητα **AutoAdjust** καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου θα προσαρμόζεται αυτόματα στο νέο μέγεθος όταν αλλάζει το μέγεθος του παραθύρου που περιέχει τη προβολή μέσα στην εφαρμογή.

Παρακάτω δίνεται ένα παράδειγμα που δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες **ViewProperties.NormalViewProperties** μιας παρουσίασης.

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

## **Ορισμός της Προεπιλεγμένης Τιμής Μεγέθυνσης**

Το Aspose.Slides for .NET υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής μεγέθυνσης για μια παρουσίαση, έτσι ώστε όταν η παρουσίαση ανοίγει, η μεγέθυνση να είναι ήδη ορισμένη. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties) μιας παρουσίασης. Οι ιδιότητες προβολής διαφάνειας καθώς και οι [NotesViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/properties/notesviewproperties) μπορούν να οριστούν προγραμματικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις Ιδιότητες Προβολής μιας Παρουσίασης στο Aspose.Slides.

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)
1. Ορίστε τις [Properties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties) προβολής της Παρουσίασης
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX

Στο παρακάτω παράδειγμα, έχουμε ορίσει την τιμή μεγέθυνσης για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Τιμή μεγέθυνσης σε ποσοστό για προβολή διαφάνειας
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Τιμή μεγέθυνσης σε ποσοστό για προβολή σημειώσεων 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός της Απόστασης Πλέγματος**

Χρησιμοποιήστε το [Presentation.ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/viewproperties/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής ολόκληρης της παρουσίασης. Η ιδιότητα [IViewProperties.GridSpacing](https://reference.aspose.com/slides/el/net/aspose.slides/iviewproperties/gridspacing/) διαβάζει ή αλλάζει το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παρουσίαση, όχι μόνο σε μία διαφάνεια. Η απόσταση πλέγματος καθορίζεται σε σημεία, όπου 72 σημεία ισοδυναμούν με ένα ίντσα. Χρησιμοποιήστε μια θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει την τρέχουσα απόσταση πλέγματος, ορίζει ένα διάστημα τέταρτο ίντσας και αποθηκεύει το αποτέλεσμα.

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

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/net/drawing-guides/). Η απόσταση πλέγματος ελέγχει ένα τακτικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι μεμονωμένα τοποθετημένες οριζόντιες ή κάθετες ευθυγραμμιστικές γραμμές. Η προσθήκη, η μετακίνηση ή η διαγραφή των οδηγών σχεδίασης δεν αλλάζει την απόσταση πλέγματος.

Τόσο το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση της απόστασης πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του προγράμματος προβολής ή επεξεργασίας.

## **Συχνές Ερωτήσεις**

**Γιατί το πλέγμα δεν είναι ορατό μετά το άνοιγμα ξανά της παρουσίασης;**

Το αρχείο αποθηκεύει την απόσταση πλέγματος, αλλά ο επεξεργαστής ελέγχει εάν το πλέγμα θα εμφανιστεί. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η διαγραφή των οδηγών σχεδίασης την απόσταση πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και η απόσταση πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η διαγραφή των οδηγών αφήνει το αποθηκευμένο διάστημα πλέγματος αμετάβλητο.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικά τμήματα μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/viewproperties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/slideviewproperties/)), όχι ανά τμήμα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε όλο το έγγραφο κατά το άνοιγμά του.

**Μπορώ να προκαθορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορεί να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα μόνο σύνολο ιδιοτήτων προβολής.

**Μπορώ να ετοιμάσω ένα πρότυπο με προκαθορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με την ίδια διαμόρφωση;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/viewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.