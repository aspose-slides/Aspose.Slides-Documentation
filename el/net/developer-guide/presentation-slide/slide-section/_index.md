---
title: Διαχείριση ενοτήτων διαφανειών σε παρουσιάσεις σε .NET
linktitle: Ενότητα Διαφάνειας
type: docs
weight: 100
url: /el/net/slide-section/
keywords:
- δημιουργία ενότητας
- προσθήκη ενότητας
- επεξεργασία ενότητας
- αλλαγή ενότητας
- όνομα ενότητας
- ανάκτηση διαφανειών ενότητας
- επεξεργασία διαφανειών ενότητας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τις ενότητες διαφανειών με το Aspose.Slides για .NET: δημιουργία, μετονομασία, επαναδιάταξη, ανάκτηση και επεξεργασία διαφανειών ενότητας σε παρουσιάσεις PPTX."
---
## **Εισαγωγή**

Οι ενότητες οργανώνουν διαδοχικές διαφάνειες σε ονομαστικές ομάδες χωρίς να αλλάζουν το περιεχόμενο της διαφάνειας. Με το Aspose.Slides for .NET, μπορείτε να δημιουργείτε, να αναδιατάσσετε, να μετονομάζετε, να ελέγχετε και να αφαιρείτε ενότητες μέσω της ιδιότητας [Presentation.Sections](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sections/) .

Οι ενότητες είναι ιδιαίτερα χρήσιμες όταν:

- μια μεγάλη παρουσίαση χρειάζεται να χωριστεί σε λογικά θέματα ή κεφάλαια·
- διαφορετικές ομάδες διαφανειών ανατίθενται σε διαφορετικούς συνεργάτες·
- απαιτείται η επεξεργασία, η μετακίνηση ή η συγχώνευση των διαφανειών ως ομάδες.

Επιλέξτε σύντομα ονόματα ενοτήτων που περιγράφουν τον σκοπό των ομαδοποιημένων διαφανειών. Επειδή οι ενότητες αποτελούν μέρος της δομής της παρουσίασης, χρησιμοποιήστε τα API ενοτήτων για τον προσδιορισμό της συμμετοχής αντί να το προσαγάτε από τις θέσεις των διαφανειών.

## **Δημιουργία και Διαχείριση Ενοτήτων**

Χρησιμοποιήστε το [ISectionCollection.AddSection](https://reference.aspose.com/slides/el/net/aspose.slides/sectioncollection/addsection/) για να δημιουργήσετε μια ενότητα καθορίζοντας το όνομά της και τη διαφάνεια έναρξης. Το Aspose.Slides καθορίζει ποιες διαφάνειες ανήκουν στην ενότητα από τη τρέχουσα δομή ενοτήτων της παρουσίασης.

Το ίδιο [ISectionCollection](https://reference.aspose.com/slides/el/net/aspose.slides/isectioncollection/) επίσης σας επιτρέπει να:

- μετακινήσετε μια ενότητα μαζί με τις διαφάνειές της χρησιμοποιώντας το [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/el/net/aspose.slides/sectioncollection/reordersectionwithslides/);
- αφαιρέσετε μόνο τον ορισμό της ενότητας με το [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/el/net/aspose.slides/sectioncollection/removesection/), διατηρώντας τις διαφάνειές της·
- αφαιρέσετε μια ενότητα και τις διαφάνειές της με το [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/el/net/aspose.slides/sectioncollection/removesectionwithslides/);
- προσθέσετε μια κενή ενότητα στο τέλος με το [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/el/net/aspose.slides/sectioncollection/appendemptysection/).

Το παρακάτω παράδειγμα δημιουργεί δύο ενότητες, μετακινεί μια από αυτές, την αφαιρεί μαζί με τις διαφάνειές της και προσθέτει μια κενή ενότητα:
```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

Μετά από αυτές τις λειτουργίες, η παρουσίαση περιέχει την ενότητα `Introduction` με τις διαφάνειές της και μια κενή ενότητα `Appendix`. Η ενότητα `Results` και οι διαφάνειές της έχουν αφαιρεθεί.

## **Μετονομασία Ενοτήτων**

Για να μετονομάσετε μια ενότητα, ορίστε την ιδιότητα [ISection.Name](https://reference.aspose.com/slides/el/net/aspose.slides/isection/name/) . Οι διαφάνειες και η θέση της ενότητας παραμένουν αμετάβλητες.

Το παρακάτω παράδειγμα δημιουργεί μια ενότητα και αλλάζει το όνομά της:
```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Ανάκτηση Διαφανειών από Ενότητες**

Η ιδιότητα [Presentation.Sections](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sections/) επιστρέφει ένα [ISectionCollection](https://reference.aspose.com/slides/el/net/aspose.slides/isectioncollection/) που μπορείτε να επαναλάβετε. Για κάθε [ISection](https://reference.aspose.com/slides/el/net/aspose.slides/isection/), καλέστε το [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/el/net/aspose.slides/isection/getslideslistofsection/) για να λάβετε τις διαφάνειες που ανήκουν αυτή τη στιγμή σε αυτήν. Η μέθοδος επιστρέφει ένα [ISectionSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/isectionslidecollection/), το οποίο παρέχει μέτρηση, πρόσβαση μέσω ευρετηρίου και επανάληψη.

Το παρακάτω παράδειγμα δημιουργεί δύο γεμάτες ενότητες και μια κενή ενότητα, στη συνέχεια εκτυπώνει το [name](https://reference.aspose.com/slides/el/net/aspose.slides/isection/name/), το [identifier](https://reference.aspose.com/slides/el/net/aspose.slides/isection/sectionid/), τη [starting slide](https://reference.aspose.com/slides/el/net/aspose.slides/isection/startedfromslide/), τον αριθμό διαφανειών και τους αριθμούς διαφανειών για κάθε ενότητα. Χρησιμοποιεί τον δείκτη της συλλογής για να διαβάσει την πρώτη διαφάνεια και το `foreach` για να επεξεργαστεί κάθε διαφάνεια. Για την κενή ενότητα, η επιστρεφόμενη συλλογή έχει μέτρηση μηδέν, ο δείκτης δεν χρησιμοποιείται και η επανάληψη δεν εκτελεί καμία επανάληψη.
```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

Η συμμετοχή σε ενότητα καθορίζεται από τη δομή ενοτήτων της παρουσίασης. Μην υπολογίζετε το εύρος μιας ενότητας με μη αυτόματο τρόπο από το [ISection.StartedFromSlide](https://reference.aspose.com/slides/el/net/aspose.slides/isection/startedfromslide/), τους δείκτες διαφανειών και τη διαφάνεια έναρξης της επόμενης ενότητας.

Οι δομικές επεμβάσεις μπορούν να αλλάξουν τόσο τις διαφάνειες που επιστρέφονται για μια ενότητα όσο και τους αριθμούς των διαφανειών τους. Αυτό περιλαμβάνει την επαναταξινόμηση διαφανειών, την κλωνοποίηση μιας διαφάνειας σε μια ενότητα, τη μετακίνηση μιας ενότητας μαζί με τις διαφάνειές της, την αφαίρεση διαφανειών και την αφαίρεση ενοτήτων. Το επόμενο παράδειγμα καλεί το [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/el/net/aspose.slides/isection/getslideslistofsection/) μετά από κάθε τέτοια αλλαγή αντί να διατηρεί υποθέσεις σχετικά με τα προηγούμενα όρια της ενότητας.
```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Καλέστε ξανά το [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/el/net/aspose.slides/isection/getslideslistofsection/) όποτε διαφάνειες ή ενότητες επαναταξινομούνται, κλωνοποιούνται, μετακινούνται ή αφαιρούνται. Αυτό διατηρεί την επόμενη επεξεργασία ευθυγραμμισμένη με τη τρέχουσα δομή της παρουσίασης.

Η μορφή PPT (PowerPoint 97–2003) δεν διατηρεί μεταδεδομένα ενοτήτων. Χρησιμοποιήστε αυτήν τη ροή εργασίας με μια μορφή που υποστηρίζει ενότητες, όπως το PPTX· η μετατροπή σε PPT αφαιρεί τη δομή ενοτήτων που απαιτείται για μετέπειτα επανάληψη.

## **FAQ**

**Διατηρούνται οι ενότητες όταν αποθηκεύεται σε μορφή PPT (PowerPoint 97–2003);**

Όχι. Η μορφή PPT δεν υποστηρίζει μεταδεδομένα ενοτήτων, έτσι η ομαδοποίηση ενοτήτων χάνεται όταν αποθηκεύεται σε .ppt.

**Μπορεί μια ολόκληρη ενότητα να «κρυφτεί»;**

Όχι. Μια ενότητα δεν έχει κατάσταση ορατότητας. Για να κρύψετε το περιεχόμενό της, ορίστε την ιδιότητα [ISlide.Hidden](https://reference.aspose.com/slides/el/net/aspose.slides/islide/hidden/) για κάθε διαφάνεια στην ενότητα.

**Πώς μπορώ να βρω την ενότητα που περιέχει μια διαφάνεια;**

Επαναλάβετε την [Presentation.Sections](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sections/), καλέστε το [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/el/net/aspose.slides/isection/getslideslistofsection/) για κάθε ενότητα και συγκρίνετε τις επιστρεφόμενες διαφάνειες με τη διαφάνεια-στόχο. Για μια μη κενή ενότητα, το [ISection.StartedFromSlide](https://reference.aspose.com/slides/el/net/aspose.slides/isection/startedfromslide/) επιστρέφει την πρώτη της διαφάνεια· για μια κενή ενότητα, επιστρέφει `null`.