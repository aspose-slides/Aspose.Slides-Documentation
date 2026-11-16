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
- συνένωση κατακόρυφου διαχωριστή
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για .NET για να διαμορφώσετε τη διάταξη της κανονικής προβολής, το ζουμ της διαφάνειας και των σημειώσεων, την απόσταση του πλέγματος και την ορατότητα των σχολίων σε παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Στην κανονική προβολή του PowerPoint, η διαφάνεια εμφανίζεται μεταξύ ενός πλαϊνού πλαισίου για μικρογραφίες ή ένα περίγραμμα και ενός πλαισίου σημειώσεων από κάτω. Το Aspose.Slides για .NET εκθέτει τις αποθηκευμένες προτιμήσεις επεξεργασίας της παρουσίασης μέσω του [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Αυτές περιλαμβάνουν τη διάταξη των πλαισίων, τα επίπεδα ζουμ, την απόσταση του πλέγματος και την ορατότητα των σχολίων.

## **Σχετικά με INormalViewProperties**

Χρησιμοποιήστε το [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) για να προσπελάσετε τη διεπαφή [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). Το [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) ελέγχει αν εμφανίζονται εικονίδια δίπλα στους τίτλους των διαφανειών στο περίγραμμα. Το [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) επιτρέπει στο πλαϊνό πλαίσιο να «κολλάει» στην ελαχιστοποιημένη του κατάσταση όταν ο χρήστης το μειώνει. Το [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) δηλώνει προτίμηση για εμφάνιση ενός μόνο πλαισίου σε πλήρη παράθυρο.

Το [VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) ελέγχει τον διαχωριστικό μεταξύ του πλαϊνού πλαισίου και της διαφάνειας. Το [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) ελέγχει τον διαχωριστικό πάνω από το πλαίσιο σημειώσεων. Και τα δύο δέχονται τιμή τύπου [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/)· `Minimized`, `Maximized` ή `Restored`.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Όταν ένας διαχωριστής επαναφέρεται, το [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) παρέχει το αποθηκευμένο μέγεθος του πλαϊνού πλαισίου και το [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) παρέχει το αποθηκευμένο μέγεθος της άνω περιοχής της διαφάνειας. Και τα δύο εκθέτουν το [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Η ιδιότητα [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) δέχεται ποσοστό από 0 έως 100, και το [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) ελέγχει αν ο επεξεργαστής προσαρμόζει το μέγεθος όταν το παράθυρο αλλάζει μέγεθος.

Αυτό το παράδειγμα ενημερώνει μια υπάρχουσα παρουσίαση. Επαναφέρει τον οριζόντιο διαχωριστή, ορίζει το [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) στο 80 % με ενεργοποιημένη την αυτόματη προσαρμογή, και μεγιστοποιεί τον κάθετο διαχωριστή. Ενεργοποιεί επίσης το [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) για την προβολή περιγράμματος.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Ορισμός της Προεπιλεγμένης Τιμής Ζουμ**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) και [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) αποθηκεύουν ανεξάρτητες ρυθμίσεις ζουμ για τον επεξεργαστή. Αυτές οι ρυθμίσεις δεν επηρεάζουν τις διαστάσεις της διαφάνειας, την αναπαραγωγή παρουσίασης ή την ανάλυση εξαγόμενης εικόνας.

Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και ενεργοποιεί το [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) για να προσαρμόσει τη διαφάνεια στο παράθυρο επεξεργασίας. Για τη σελίδα σημειώσεων, απενεργοποιεί την αυτόματη κλιμάκωση και ορίζει το [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) σε σταθερό ζουμ 80 %.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Ορισμός της Απόστασης Πλέγματος**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) ορίζει την απόσταση μεταξύ των γραμμών πλέγματος σε όλη την παρουσίαση. Λαμβάνει μια θετική τιμή σε σημεία, με 72 σημεία ανά ίντσα. Αυτό το παράδειγμα εκτυπώνει την τρέχουσα απόσταση σε μια υπάρχουσα παρουσίαση και αποθηκεύει ένα πλέγμα τέταρτης ίντσας ορίζοντας το διάστημα στα 18 σημεία.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Το πλέγμα επαναλαμβάνεται σε σταθερό διάστημα. Τα [Drawing guides](/slides/el/net/drawing-guides/) σημειώνουν μεμονωμένες οριζόντιες ή κάθετες θέσεις. Και τα δύο είναι βοηθήματα επεξεργασίας και εμφανίζονται μόνο σε επεξεργαστές που τα εμφανίζουν. Οι προβολές διαφανειών και οι εξαγωγές σε PDF, εικόνες ή SVG τα παραλείπουν.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) αποθηκεύει μια προτίμηση που τα συμβατά εργαλεία χρησιμοποιούν όταν ανοίγουν την παρουσίαση. Για μια υπάρχουσα παρουσίαση με σχόλια, αυτό το παράδειγμα εκτυπώνει την τρέχουσα ρύθμιση και αποθηκεύει ένα αντίγραφο με κρυμμένα σχόλια. Επίσης ορίζει το [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) στο [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) ώστε το αντίγραφο να ανοίξει σε προβολή διαφάνειας.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Η απόκρυψη των σχολίων διατηρεί το κείμενο, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις τους. Για αλλαγή των ίδιων των σχολίων, δείτε το [Presentation Comments](/slides/el/net/presentation-comments/). Οι ρυθμίσεις εξαγωγής ελέγχουν αν τα σχόλια εμφανίζονται σε PDF, HTML, εικόνες, σημειώσεις ή φυλλάδια.

## **Συχνές ερωτήσεις**

**Γιατί είναι κρυφό το πλέγμα όταν ανοίγω ξανά την παρουσίαση;**

Η παρουσίαση αποθηκεύει το διάστημα του πλέγματος. Για να δείτε το πλέγμα, ενεργοποιήστε την ορατότητα του πλέγματος στον επεξεργαστή.

**Αλλάζει η απόσταση του πλέγματος όταν διαγράφονται οι οδηγίες σχεδίασης;**

Όχι. Η προσθήκη, η μετακίνηση ή η διαγραφή μιας οδηγίας αφήνει αμετάβλητο το διάστημα του πλέγματος.

**Μπορούν διαφορετικά τμήματα μιας παρουσίασης να έχουν διαφορετικές ρυθμίσεις προβολής;**

Όχι. Το [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) εφαρμόζεται σε ολόκληρη την παρουσίαση.

**Μπορώ να αποθηκεύσω διαφορετικές ρυθμίσεις προβολής για διαφορετικούς χρήστες;**

Το αρχείο αποθηκεύει ένα σύνολο ιδιοτήτων προβολής για όλους. Ένας επεξεργαστής μπορεί επίσης να εφαρμόσει τις τοπικές προτιμήσεις ενός χρήστη.

**Μπορώ να αποθηκεύσω ρυθμίσεις προβολής σε πρότυπο;**

Ναι. Οι παρουσιάσεις που δημιουργούνται από το πρότυπο κληρονομούν τις αποθηκευμένες ρυθμίσεις προβολής.