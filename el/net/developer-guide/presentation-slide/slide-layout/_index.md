---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε .NET
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/net/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- δεσμευτική θέση
- σχεδιασμός παρουσίασης
- σχεδιασμός διαφάνειας
- μη χρησιμοποιημένη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- κεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με λεζάντα
- εικόνα με λεζάντα
- τίτλος και κάθετο κείμενο
- κάθετος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- C#
- .NET
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για .NET, προσθέστε δεσμευτικές θέσεις, αφαιρέστε μη χρησιμοποιημένες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Μια διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των δεσμευτικών θέσεων, όπως τίτλους, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης παρέχει στις διαφάνειες μια συνεπή δομή, ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο κοινές διατάξεις περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει δεσμευτικές θέσεις τίτλου και υποτίτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει μια δεσμευτική θέση τίτλου και μια γενικής χρήσης δεσμευτική θέση περιεχομένου.
- **Κενό**: Δεν περιέχει δεσμευτικές θέσεις περιεχομένου και είναι χρήσιμο όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διάταξης**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. Ένα [master slide](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα παρασκήνια και τα κοινά αντικείμενα.
2. Μια [layout slide](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/) ανήκει σε ένα master και ορίζει μια συγκεκριμένη διάταξη δεσμευτικών θέσεων.
3. Μια [normal slide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/) χρησιμοποιεί μια διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, ενώ η διάταξη κληρονομεί από το master της. Μια τιμή που ορίζεται άμεσα στη κανονική διαφάνεια παρακάμπτει την κληρονομημένη τιμή σε εκείνο το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα των δεσμευτικών θέσεων παράγονται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις δεσμευτικές θέσεις ανήκει στη κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες δεσμευτικές θέσεις σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας ακόμη δεσμευτικής θέσης σε μια διάταση αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα δεσμευτικής θέσης στις υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της υπάρχουσας γεωμετρίας των δεσμευτικών θέσεων σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που χρησιμοποιείται ήδη, ελέγξτε τις εξαρτημένες διαφάνειες της και αναθεωρήστε την προκύπτουσα παρουσίαση.
- Μια διάταξη που εξακολουθεί να χρησιμοποιείται από μια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες της σε άλλη διάταξη, ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε το [Slide Master](/slides/el/net/slide-master/).

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήτε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα των διατάξεων είναι επεξεργάσιμα από τον χρήστη και μπορούν να εντοπιστούν, επομένως η επιλογή βάσει ονόματος είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πρότυπο πηγής.

Το παρακάτω παράδειγμα αναζητά το **Title and Content** στο πρώτο master. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει σκόπιμα στο **Blank**. Ο δεύτερος έλεγχος null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της ιδιότητας [ISlide.LayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/layoutslide/).

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

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα συνηθισμένα σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των δεσμευτικών θέσεων, η κληρονομημένη μορφοποίηση και η αντιστοιχία μεταξύ των υπάρχουσων δεσμευτικών θέσεων και της νέας διάταξης μπορεί να αλλάξει, γι' αυτό ελέγξτε το αποτέλεσμα όταν εναλλάσσετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν τη δημιουργεί. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/el/net/aspose.slides/masterlayoutslidecollection/add/) στη συλλογή διατάξεων του στόχου master.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, και στη συνέχεια προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Προσθέστε μια διάταξη μόνο όταν το πρότυπο χρειάζεται πραγματικά μια άλλη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διάταξη, επιλέξτε την και επαναχρησιμοποιήστε την αντί να δημιουργήσετε αντίγραφο.

## **Προσθήκη Δεσμευτικών Θέσεων σε Διάταξη Διαφάνειας**

Η ιδιότητα [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/placeholdermanager/) παρέχει ένα [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutplaceholdermanager/) για την προσθήκη σχημάτων δεσμευτικών θέσεων σε μια διάταξη.

| Δεσμευτική Θέση PowerPoint | `ILayoutPlaceholderManager` Μέθοδος |
| --------------------------- | ----------------------------------- |
| ![Περιεχόμενο](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Περιεχόμενο (Κάθετο)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Κείμενο](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Κείμενο (Κάθετο)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Εικόνα](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Διάγραμμα](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Πίνακας](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Το παρακάτω παράδειγμα επαληθεύει ότι η διάταξη **Blank** υπάρχει, προσθέτει τέσσερις δεσμευτικές θέσεις σε αυτήν και, στη συνέχεια, δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι δεσμευτικές θέσεις προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα δεσμευτικών θέσεων σε αυτήν τη διαφάνεια.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Προειδοποίηση" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπάρχουσων δεσμευτικών θέσεων διάταξης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια νεοπροστέθηκε δεσμευτική θέση διάταξης δεν προστίθεται αυτόματα στις υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε ένα αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Μη Χρησιμοποιημένων Διατάξεων Διαφάνειας**

Χρησιμοποιήτε τη μέθοδο [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει αμετάβλητες τις διατάξεις που εξακολουθούν να χρησιμοποιούνται.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, χρησιμοποιήστε πρώτα την ιδιότητα [HasDependingSlides](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/hasdependingslides/) ή τη μέθοδο [GetDependingSlides](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/getdependingslides/). Αναθέστε ξανά τυχόν εξαρτημένες διαφάνειες πριν καλέσετε το [ILayoutSlide.Remove](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/remove/). Η προσπάθεια αφαίρεσης μιας χρησιμοποιούμενης διάταξης προκαλεί ένα [PptxEditException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη έχει το δικό της υποσέλιδο, αριθμό διαφάνειας και δεσμευτικές θέσεις ημερομηνίας‑ώρας. Χρησιμοποιήτε την ιδιότητα [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/headerfootermanager/) για να ελέγξετε αυτές τις δεσμευτικές θέσεις για μια διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

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

## **Έλεγχος Ορατότητας Υποσέλιδου σε Master και τα Παιδικά του Διατάξεις**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε ολόκληρη την ιεραρχία ενός master, χρησιμοποιήτε την ιδιότητα [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/headerfootermanager/). Οι μέθοδοι διάδοσης του [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslideheaderfootermanager/) λειτουργούν στο master και στις εξαρτημένες διατάξεις διαφάνειας και στις κανονικές διαφάνειες· δεν στοχεύουν μόνο μια κανονική διαφάνεια.

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

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός Master Slide και ενός Layout Slide;**

Ένα master slide ορίζει το θέμα της παρουσίασης και τη κοινή μορφοποίηση. Ένα layout slide ανήκει σε ένα master και καθορίζει μια επαναχρησιμοποιήσιμη διάταξη δεσμευτικών θέσεων. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν περιεχόμενο ειδικό για κάθε διαφάνεια.

**Μπορώ να αντιγράψω ένα Layout Slide από μια παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/globallayoutslidecollection/addclone/). Κατά την αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιεί η διάταξη προέλευσης.

**Τι συμβαίνει όταν τροποποιώ μια διάταξη που χρησιμοποιείται ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης εκτός εάν παρακάμψουν τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των δεσμευτικών θέσεων και η κληρονομημένη στυλιζαρίστικη μορφοποίηση μπορούν επομένως να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήτε το [GetDependingSlides](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/getdependingslides/) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι συμβαίνει αν αφαιρέσω μια διάταξη που είναι ακόμα σε χρήση;**

Το Aspose.Slides εγείρει ένα [PptxEditException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήτε τη μέθοδο [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) για να αφαιρέσετε μόνο τις μη αναφερόμενες διατάξεις.