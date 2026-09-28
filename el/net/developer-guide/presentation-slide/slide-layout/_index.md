---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας στο .NET
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/net/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- δεσμευτική θέση
- σχεδίαση παρουσίασης
- σχεδίαση διαφάνειας
- αχρησιμοποίητη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- επικεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με λεζάντα
- εικόνα με λεζάντα
- τίτλος και κατακόρυφο κείμενο
- κατακόρυφος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- C#
- .NET
- Aspose.Slides
description: "Εφαρμόζετε, δημιουργείτε και τροποποιείτε διατάξεις διαφάνειας στο Aspose.Slides για .NET, προσθέτετε δεσμευτικές θέσεις, αφαιρείτε αχρησιμοποίητες διατάξεις και ελέγχετε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Ένα διάταξη διαφάνειας καθορίζει τις θέσεις και τη μορφοποίηση των δεσμευτικών θέσεων όπως τίτλοι, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης δίνει στις διαφάνειες μια συνεπή δομή ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συνοπτικές διατάξεις περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει δεσμευτικές θέσεις τίτλου και υποτίτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει μια δεσμευτική θέση τίτλου και μια γενικής χρήσης δεσμευτική θέση περιεχομένου.
- **Κενό**: Δεν περιέχει δεσμευτικές θέσεις περιεχομένου και είναι χρήσιμο όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληροδοσίας Διάταξης**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. A [κύρια διαφάνεια](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα φόντα και τα κοινά αντικείμενα.
1. A [διάταξη διαφάνειας](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/) ανήκει σε μια κύρια και ορίζει μια συγκεκριμένη διάταξη δεσμευτικών θέσεων.
1. A [κανονική διαφάνεια](https://reference.aspose.com/slides/el/net/aspose.slides/islide/) χρησιμοποιεί μία διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για αυτή τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, και η διάταξη κληρονομεί από την κύρια της. Μια τιμή που ορίζεται απευθείας σε μια κανονική διαφάνεια αντικαθιστά την κληρονομημένη τιμή σε αυτό το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα των δεσμευτικών θέσεων δημιουργούνται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις δεσμευτικές θέσεις ανήκει στην κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες δεσμευτικές θέσεις σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας επιπλέον δεσμευτικής θέσης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα δεσμευτικής θέσης στις υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της υπάρχουσας γεωμετρίας των δεσμευτικών θέσεων σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που είναι ήδη σε χρήση, ελέγξτε τις εξαρτημένες διαφάνειες της και εξετάστε την προκύπτουσα παρουσίαση.
- Μια διάταξη που χρησιμοποιείται ακόμη από κάποια διαφάνεια δεν μπορεί να αφαιρεθεί. Επαναπροσαρμόστε πρώτα τις εξαρτημένες διαφάνειες της σε μια άλλη διάταξη ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε [Κύρια Διαφάνεια](/slides/el/net/slide-master/).

Για απόκρυψη κληρονομημένων λογοτύπων ή διακοσμητικών σχημάτων της κύριας διαφάνειας σε μία διαφάνεια ή μέσω κοινής διάταξης, δείτε [Έλεγχος Ορατότητας Γραφικών Κύριας Διαφάνειας](/slides/el/net/slide-master/). Το παράδειγμα συγκρίνει δύο διαφάνειες που χρησιμοποιούν την ίδια κύρια διαφάνεια.

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα των διατάξεων μπορούν να επεξεργαστούν από τον χρήστη και να τοπικοποιηθούν, έτσι η επιλογή βάσει ονόματος είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το αρχικό πρότυπο.

Το παρακάτω παράδειγμα αναζητά το **Title and Content** στην πρώτη κύρια διαφάνεια. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει σκόπιμα στην **Blank**. Ο δεύτερος έλεγχος για null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της ιδιότητας [ISlide.LayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα συνηθισμένα σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των δεσμευτικών θέσεων, η κληρονομημένη μορφοποίηση και η αντιστοιχία μεταξύ των υπαρχουσών δεσμευτικών θέσεων και της νέας διάταξης μπορούν να αλλάξουν, γι' αυτό ελέγξτε το αποτέλεσμα όταν εναλλάσσετε μεταξύ ουσιαστικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν δημιουργεί νέα. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/el/net/aspose.slides/masterlayoutslidecollection/add/) στη συλλογή διατάξεων της στοχευμένης κύριας διαφάνειας.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια με βάση αυτήν. Τα ονόματα διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Προσθέστε μια διάταξη μόνο όταν το πρότυπο χρειάζεται πραγματικά μια ακόμη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη κατάλληλη διάταξη, επιλέξτε την και επαναχρησιμοποιήστε την αντί να δημιουργήσετε αντίγραφο.

## **Προσθήκη Δεσμευτικών Θέσεων σε Διάταξη Διαφάνειας**

Η ιδιότητα [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/placeholdermanager/) παρέχει έναν [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutplaceholdermanager/) για την προσθήκη σχημάτων δεσμευτικών θέσεων σε μια διάταξη.

| PowerPoint Placeholder | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![Περιεχόμενο](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Κείμενο](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Εικόνα](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Διάγραμμα](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Πίνακας](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Μέσα](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Το παρακάτω παράδειγμα ελέγχει αν υπάρχει η διάταξη **Blank**, προσθέτει τέσσερις δεσμευτικές θέσεις σε αυτήν, και έπειτα δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι δεσμευτικές θέσεις προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα δεσμευτικών θέσεων σε εκείνη τη διαφάνεια.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι δεσμευτικές θέσεις στη διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υφιστάμενων δεσμευτικών θέσεων της διάταξης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια νεοπροστέθηκε δεσμευτική θέση διάταξης δεν προστίθεται αυτόματα στις υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε ένα αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Αχρησιμοποίητων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος διατηρεί τις διατάξεις που είναι ακόμα σε χρήση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, πρώτα χρησιμοποιήστε την ιδιότητά της [HasDependingSlides](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/hasdependingslides/) ή τη μέθοδο [GetDependingSlides](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/getdependingslides/). Επαναπροσαρμόστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε τη μέθοδο [ILayoutSlide.Remove](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/remove/). Η προσπάθεια αφαίρεσης μιας χρησιμοποιούμενης διάταξης προκαλεί μια [PptxEditException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη έχει τις δικές της δεσμευτικές θέσεις υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας-ώρας. Χρησιμοποιήστε την ιδιότητα [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/headerfootermanager/) για να ελέγξετε αυτές τις δεσμευτικές θέσεις για μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου δεν πρέπει.

Το παρακάτω παράδειγμα επιλέγει μια διάταξη με ασφάλεια και κάνει τα στοιχεία υποσέλιδου της ορατά:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Έλεγχος Ορατότητας Υποσέλιδου σε Κύρια Διαφάνεια και στις Παράγοντες Διατάξεις της**

Για να εφαρμόσετε σύμφωνες ρυθμίσεις υποσέλιδου σε ολόκληρη την ιεραρχία της κύριας διαφάνειας, χρησιμοποιήστε την ιδιότητα [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/headerfootermanager/). Οι μέθοδοι διάδοσης του [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslideheaderfootermanager/) λειτουργούν στην κύρια διαφάνεια και στις εξαρτημένες διατάξεις και κανονικές διαφάνειες· δεν στοχεύουν μόνο σε μία κανονική διαφάνεια.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **ΣΥΧΝΑ ΕΡΩΤΗΣΑΤΑ**

**Τι είναι η διαφορά μεταξύ κύριας διαφάνειας και διάταξης διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το θέμα της παρουσίασης και τη κοινή μορφοποίηση. Μια διάταξη διαφάνειας ανήκει σε μία κύρια και καθορίζει μια επαναχρησιμοποιήσιμη διάταξη δεσμευτικών θέσεων. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν το περιεχόμενο που αφορά την συγκεκριμένη διαφάνεια.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μία παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/globallayoutslidecollection/addclone/). Κατά την αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιεί η διατάξη προέλευσης.

**Τι συμβαίνει όταν τροποποιώ μια διάταξη που είναι ήδη σε χρήση;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης εκτός εάν παρακάμψουν την επηρεασμένη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των δεσμευτικών θέσεων και η κληρονομημένη μορφοποίηση μπορούν επομένως να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε το [GetDependingSlides](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/getdependingslides/) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι συμβαίνει αν αφαιρέσω μια διάταξη που είναι ακόμη σε χρήση;**

Το Aspose.Slides αποδίδει μια [PptxEditException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxeditexception/). Επαναπροσαρμόστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε το [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) για να αφαιρέσετε μόνο τις μη αναφερόμενες διατάξεις.