---
title: Διαχείριση κεφαλίδων και υποσέλιδων παρουσίασης σε .NET
linktitle: Κεφαλίδα και υποσέλιδο
type: docs
weight: 140
url: /el/net/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορισμός κεφαλίδας
- ορισμός υποσέλιδου
- φυλλάδιο
- σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τα placeholders υποσέλιδου, ημερομηνίας-ώρας, αριθμού διαφάνειας και κεφαλίδας σε διαφάνειες, σελίδες σημειώσεων και φυλλάδια με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το PowerPoint χρησιμοποιεί διαφορετικά placeholders κεφαλίδας και υποσέλιδου ανάλογα με τον τύπο της σελίδας. Το Aspose.Slides for .NET επιτρέπει τον έλεγχο του κειμένου και της ορατότητας αυτών των placeholders μέσω των διεπαφών διαχείρισης κεφαλίδας/υποσέλιδου.

Τα διαθέσιμα placeholders εξαρτώνται από το πεδίο εφαρμογής:

| Εύρος | Κεφαλίδα | Υποσέλιδο | Ημερομηνία/ώρα | Αριθμός διαφάνειας/σελίδας |
|---|---|---|---|---|
| Κανονική διαφάνεια | Όχι | Ναι | Ναι | Ναι |
| Κύριος σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Διαφάνεια σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Κύριος φυλλαδίου | Ναι | Ναι | Ναι | Ναι |

Μια κανονική διαφάνεια παρουσίασης δεν έχει placeholder κεφαλίδας. Τα placeholders κεφαλίδας είναι διαθέσιμα σε σελίδες σημειώσεων και φυλλαδίου. Για κανονικές διαφάνειες, χρησιμοποιήστε τα placeholders υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας.

Το πεδίο εφαρμογής μιας αλλαγής εξαρτάται από τη διαχειριστική διεπαφή που χρησιμοποιείτε. Η διεπαφή [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/islideheaderfootermanager/) ελέγχει μία κανονική διαφάνεια. Η διεπαφή [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/inotesslideheaderfootermanager/) ελέγχει μία διαφάνεια σημειώσεων. Οι διαχειριστές master και layout μπορούν επίσης να διαδώσουν τις ρυθμίσεις σε εξαρτώμενες διαφάνειες, ενώ η διεπαφή [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/imasterhandoutslideheaderfootermanager/) ελέγχει το master του φυλλαδίου.

## **Ορισμός υποσέλιδου, ημερομηνίας/ώρας και αριθμών διαφάνειας σε κανονικές διαφάνειες**

Για κανονικές διαφάνειες, η βασική ροή εργασίας είναι: πρόσβαση στη διαχείριση κεφαλίδας/υποσέλιδου της κάθε διαφάνειας, ορισμός του κειμένου υποσέλιδου και ημερομηνίας/ώρας, ενεργοποίηση των απαιτούμενων placeholders και αποθήκευση της παρουσίασης. Οι αριθμοί διαφάνειας δημιουργούνται αυτόματα, οπότε χρειάζεται μόνο να ελέγξετε την ορατότητά τους.

Χρησιμοποιήστε το [`SetFooterText`](https://reference.aspose.com/slides/el/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) και το [`SetDateTimeText`](https://reference.aspose.com/slides/el/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) για να ορίσετε κείμενο, και τα [`SetFooterVisibility`](https://reference.aspose.com/slides/el/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/el/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) και [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/el/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) για να εμφανίσετε τα αντίστοιχα placeholders.

Το παρακάτω παράδειγμα end-to-end εφαρμόζει το ίδιο υποσέλιδο, κείμενο ημερομηνίας/ώρας και ορατότητα αριθμού διαφάνειας σε όλες τις κανονικές διαφάνειες:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Αν χρειάζεται να ενημερώσετε μόνο μία διαφάνεια, αποκτήστε πρόσβαση απευθείας σε αυτήν μέσω της συλλογής [`Slides`](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/) αντί να κάνετε επανάληψη σε ολόκληρη τη συλλογή.

## **Ορισμός κεφαλίδων και υποσέλιδων στο Master Σημειώσεων**

Το master σημειώσεων ορίζει κοινή μορφοποίηση και συμπεριφορά placeholders για τις σελίδες σημειώσεων. Χρησιμοποιήστε τη διεπαφή [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/imasternotesslideheaderfootermanager/) όταν θέλετε να αλλάξετε μόνο το ίδιο το master σημειώσεων.

Το παρακάτω παράδειγμα ορίζει κεφαλίδα, υποσέλιδο και κείμενο ημερομηνίας/ώρας στο master σημειώσεων και κάνει όλα τα υποστηριζόμενα placeholders ορατά σε αυτό το master:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

Η ιδιότητα [`MasterNotesSlide`](https://reference.aspose.com/slides/el/net/aspose.slides/imasternotesslidemanager/masternotesslide/) επιστρέφει `null` όταν η παρουσίαση δεν περιέχει master σημειώσεων.

## **Εφαρμογή ρυθμίσεων Master Σημειώσεων σε θυγατρικές διαφάνειες Σημειώσεων**

Ένα master σημειώσεων μπορεί να εφαρμόσει ρυθμίσεις κεφαλίδας και υποσέλιδου στον εαυτό του και σε όλες τις εξαρτώμενες διαφάνειες σημειώσεων. Χρησιμοποιήστε τις ειδικές μεθόδους διάδοσης στη διεπαφή [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/imasternotesslideheaderfootermanager/) όταν οι ίδιες ρυθμίσεις πρέπει να εφαρμοστούν σε όλη τη ιεραρχία σημειώσεων.

Για παράδειγμα, τα [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/el/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) και [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/el/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) ενημερώνουν την κεφαλίδα του master σημειώσεων και όλες τις θυγατρικές κεφαλίδες. Παρόμοιες μέθοδοι υπάρχουν για υποσέλιδα, ημερομηνία/ώρα και αριθμούς διαφάνειας.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Οι μέθοδοι διάδοσης που χρησιμοποιήθηκαν παραπάνω είναι [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/el/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/el/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/el/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/el/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) και [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/el/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Ορισμός κεφαλίδων και υποσέλιδων σε μεμονωμένη διαφάνεια Σημειώσεων**

Μια διαφάνεια σημειώσεων ανήκει σε συγκεκριμένη κανονική διαφάνεια. Χρησιμοποιήστε τη διεπαφή [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/inotesslideheaderfootermanager/) όταν θέλετε να προσαρμόσετε μόνο αυτή τη σελίδα σημειώσεων.

Η μέθοδος [`AddNotesSlide`](https://reference.aspose.com/slides/el/net/aspose.slides/inotesslidemanager/addnotesslide/) επιστρέφει τη διαφάνεια σημειώσεων για την τρέχουσα διαφάνεια και δημιουργεί μία εάν δεν υπάρχει ήδη. Το παρακάτω παράδειγμα διαμορφώνει τη σελίδα σημειώσεων που συνδέεται με την πρώτη διαφάνεια της παρουσίασης:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Αν πρώτα διαδώσετε τις ρυθμίσεις από το master σημειώσεων και μετά αλλάξετε μια μεμονωμένη διαφάνεια σημειώσεων, οι μεταγενέστερες ρυθμίσεις ανά διαφάνεια σας επιτρέπουν να προσαρμόσετε αυτή τη σελίδα ανεξάρτητα.

## **Ορισμός κεφαλίδων και υποσέλιδων στο Master Φυλλαδίου**

Οι σελίδες φυλλαδίου χρησιμοποιούν το master φυλλαδίου για τα placeholders κεφαλίδας, υποσέλιδου, ημερομηνίας/ώρας και αριθμού σελίδας. Σε αντίθεση με τις σελίδες σημειώσεων, οι ρυθμίσεις φυλλαδίου διαχειρίζονται μέσω του master φυλλαδίου και όχι μέσω μεμονωμένων διαφανειών φυλλαδίου.

Χρησιμοποιήστε την ιδιότητα [`MasterHandoutSlide`](https://reference.aspose.com/slides/el/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) για πρόσβαση στο master φυλλαδίου. Εάν δεν υπάρχει, καλέστε τη μέθοδο [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/el/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) για να δημιουργήσετε το προεπιλεγμένο master φυλλαδίου.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Κατανόηση πεδίου εφαρμογής και κληρονομικότητας**

Επιλέξτε τον διαχειριστή κεφαλίδας/υποσέλιδου που ταιριάζει με το πεδίο εφαρμογής που θέλετε να αλλάξετε:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/islideheaderfootermanager/) αλλάζει τις ρυθμίσεις υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας για μία κανονική διαφάνεια.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslideheaderfootermanager/) ελέγχει μια διαφάνεια layout και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτώμενες διαφάνειες.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslideheaderfootermanager/) ελέγχει ένα κανονικό master διαφάνειας και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτώμενες διαφάνειες.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/imasternotesslideheaderfootermanager/) ελέγχει το master σημειώσεων και μπορεί να διαδώσει ρυθμίσεις σε όλες τις εξαρτώμενες διαφάνειες σημειώσεων.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/inotesslideheaderfootermanager/) αλλάζει μία διαφάνεια σημειώσεων και υποστηρίζει placeholder κεφαλίδας επιπλέον του υποσέλιδου, της ημερομηνίας/ώρας και του αριθμού διαφάνειας.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/net/aspose.slides/imasterhandoutslideheaderfootermanager/) αλλάζει το master φυλλαδίου και υποστηρίζει και τους τέσσερις τύπους placeholders.

Χρησιμοποιήστε διάδοση από ένα master ή layout όταν η ίδια ρύθμιση πρέπει να ισχύει σε όλη τη ιεραρχία του. Χρησιμοποιήστε έναν μεμονωμένο διαχειριστή διαφάνειας ή σημειώσεων όταν χρειάζεστε τοπική ρύθμιση για μία σελίδα.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να προσθέσω κεφαλίδα σε κανονική διαφάνεια;**

Όχι. Το PowerPoint δεν ορίζει placeholder κεφαλίδας για κανονικές διαφάνειες. Σε κανονικές διαφάνειες, χρησιμοποιήστε τα placeholders υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας. Τα placeholders κεφαλίδας είναι διαθέσιμα σε σελίδες σημειώσεων και φυλλαδίου.

**Τι γίνεται αν ένα placeholder υποσέλιδου, ημερομηνίας/ώρας ή αριθμού διαφάνειας δεν είναι ορατό;**

Χρησιμοποιήστε τον αντίστοιχο διαχειριστή κεφαλίδας/υποσέλιδου για να ελέγξετε την ορατότητά του και ενεργοποιήστε το όταν χρειάζεται. Για παράδειγμα, η μέθοδος [`IsFooterVisible`](https://reference.aspose.com/slides/el/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) αναφέρει αν υπάρχει placeholder υποσέλιδου, και η μέθοδος [`SetFooterVisibility`](https://reference.aspose.com/slides/el/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) αλλάζει την ορατότητά του.

**Πώς μπορώ να ξεκινήσω την αρίθμηση διαφανειών από τιμή διαφορετική από 1;**

Ορίστε την ιδιότητα [`FirstSlideNumber`](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/firstslidenumber/) της παρουσίασης. Τα placeholders αριθμού διαφάνειας θα χρησιμοποιήσουν τη νέα ακολουθία αρίθμησης.

**Τι συμβαίνει με τις κεφαλίδες και τα υποσέλιδα κατά την εξαγωγή σε PDF, εικόνες ή HTML;**

Τα ορατά στοιχεία κεφαλίδας και υποσέλιδου αποδίδονται μαζί με το υπόλοιπο περιεχόμενο της παρουσίασης στην έξοδο. Η εμφάνισή τους εξαρτάται από τον τύπο της σελίδας που εξάγεται και τις αντίστοιχες ρυθμίσεις ορατότητας των placeholders.