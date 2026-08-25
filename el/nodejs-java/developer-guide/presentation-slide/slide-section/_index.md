---
title: Διαχειριστείτε τις Ενότητες Διαφανειών σε Παρουσιάσεις με JavaScript
linktitle: Ενότητα Διαφάνειας
type: docs
weight: 90
url: /el/nodejs-java/slide-section/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τις ενότητες διαφανειών με το Aspose.Slides για Node.js μέσω Java: δημιουργία, μετονομασία, επαναδιάταξη, ανάκτηση και επεξεργασία διαφανειών ενότητας σε παρουσιάσεις PPTX."
---
## **Εισαγωγή**

Οι ενότητες οργανώνουν διαδοχικές διαφάνειες σε ονομασμένες ομάδες χωρίς να αλλάζουν το περιεχόμενο της διαφάνειας. Με το Aspose.Slides για Node.js μέσω Java, μπορείτε να δημιουργείτε, να επαναδιατάξετε, να μετονομάζετε, να επιθεωρείτε και να αφαιρείτε ενότητες μέσω της μεθόδου [Presentation.getSections](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSections) .

Οι ενότητες είναι ιδιαίτερα χρήσιμες όταν:

- μια μεγάλη παρουσίαση χρειάζεται να διαιρεθεί σε λογικά θέματα ή κεφάλαια·
- διαφορετικές ομάδες διαφανειών ανατίθενται σε διαφορετικούς συνεργάτες·
- οι διαφάνειες χρειάζεται να υποβληθούν σε επεξεργασία, να μετακινηθούν ή να συγχωνευτούν ως ομάδες.

Επιλέξτε σύντομα ονόματα ενοτήτων που περιγράφουν το σκοπό των ομαδοποιημένων διαφανειών. Επειδή οι ενότητες αποτελούν μέρος της δομής της παρουσίασης, χρησιμοποιήστε τα API ενοτήτων για να καθορίσετε τη συμμετοχή αντί να την προκύψετε από τις θέσεις των διαφανειών.

## **Δημιουργία και Διαχείριση Ενοτήτων**

Χρησιμοποιήστε το [SectionCollection.addSection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectioncollection/#addSection) για να δημιουργήσετε μια ενότητα, καθορίζοντας το όνομά της και τη διαφάνεια εκκίνησης. Το Aspose.Slides καθορίζει ποιες διαφάνειες ανήκουν στην ενότητα από την τρέχουσα δομή ενοτήτων της παρουσίασης.

Το ίδιο [SectionCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectioncollection/) σας επιτρέπει επίσης:

- να μετακινήσετε μια ενότητα μαζί με τις διαφάνειές της χρησιμοποιώντας το [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides)·
- να αφαιρέσετε μόνο τον ορισμό της ενότητας με το [SectionCollection.removeSection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectioncollection/#removeSection), που διατηρεί τις διαφάνειές της·
- να αφαιρέσετε μια ενότητα και τις διαφάνειές της με το [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides)·
- να προσθέσετε μια κενή ενότητα στο τέλος με το [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Το παρακάτω παράδειγμα δημιουργεί δύο ενότητες, μετακινεί τη μία, τη αφαιρεί μαζί με τις διαφάνειές της και προσθέτει μια κενή ενότητα:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Μετά από αυτές τις ενέργειες, η παρουσίαση περιέχει την ενότητα `Introduction` με τις διαφάνειές της και μια κενή ενότητα `Appendix`. Η ενότητα `Results` και οι διαφάνειές της έχουν αφαιρεθεί.

## **Μετονομασία Ενοτήτων**

Για να μετονομάσετε μια ενότητα, καλέστε τη μέθοδο [Section.setName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#setName). Οι διαφάνειες της ενότητας και η θέση της παραμένουν αμετάβλητες.

Το παρακάτω παράδειγμα δημιουργεί μια ενότητα και αλλάζει το όνομά της:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Ανάκτηση Διαφανειών από Ενότητες**

Η μέθοδος [Presentation.getSections](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSections) επιστρέφει ένα [SectionCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectioncollection/) που μπορείτε να προσπελάσετε με δείκτη. Για κάθε [Section](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/), καλέστε το [Section.getSlidesListOfSection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getSlidesListOfSection) για να λάβετε τις διαφάνειες που ανήκουν προς το παρόν σε αυτήν. Η μέθοδος επιστρέφει ένα [SectionSlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectionslidecollection/), που παρέχει αριθμό και προσπέλαση με δείκτη.

Το παρακάτω παράδειγμα δημιουργεί δύο γεμάτες ενότητες και μια κενή ενότητα, στη συνέχεια εκτυπώνει το [name](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getName), το [identifier](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getSectionId), τη [starting slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getStartedFromSlide), τον αριθμό διαφανειών και τους αριθμούς διαφανειών της κάθε ενότητας. Χρησιμοποιεί το [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) για να διαβάσει τόσο την πρώτη διαφάνεια όσο και κάθε διαφάνεια στη συλλογή. Για την κενή ενότητα, η επιστραφμένη συλλογή έχει μέγεθος μηδέν, η προσπέλαση με δείκτη παραλείπεται και ο βρόχος δεν εκτελεί καμία λειτουργία.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Η συμμετοχή σε ενότητες καθορίζεται από τη δομή ενοτήτων της παρουσίασης. Μην υπολογίζετε χειροκίνητα την περιοχή μιας ενότητας από το [Section.getStartedFromSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getStartedFromSlide), τους δείκτες διαφανειών και τη διαφάνεια εκκίνησης της επόμενης ενότητας.

Οι διαρθρωτικές επεμβάσεις μπορούν να αλλάξουν τόσο τις διαφάνειες που επιστρέφονται για μια ενότητα όσο και τους αριθμούς τους. Αυτό περιλαμβάνει την επαναδιάταξη διαφανειών, την κλωνοποίηση μιας διαφάνειας σε μια ενότητα, τη μετακίνηση μιας ενότητας μαζί με τις διαφάνειές της, την αφαίρεση διαφανειών και την αφαίρεση ενοτήτων. Το επόμενο παράδειγμα καλεί το [Section.getSlidesListOfSection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getSlidesListOfSection) μετά από κάθε τέτοια αλλαγή αντί να διατηρεί υποθέσεις σχετικά με τα προηγούμενα όρια της ενότητας.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Καλέστε το [Section.getSlidesListOfSection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getSlidesListOfSection) ξανά όποτε οι διαφάνειες ή οι ενότητες επαναδιατάσσονται, κλωνοποιούνται, μετακινούνται ή αφαιρούνται. Αυτό διατηρεί την επόμενη επεξεργασία σε ευθυγράμμιση με τη τρέχουσα δομή της παρουσίασης.

Η μορφή PPT (PowerPoint 97–2003) δεν διατηρεί τα μεταδεδομένα των ενοτήτων. Χρησιμοποιήστε αυτή τη ροή εργασίας με μια μορφή που υποστηρίζει ενότητες, όπως το PPTX· η μετατροπή σε PPT αφαιρεί τη δομή ενοτήτων που χρειάζεται για μεταγενέστερη επανάληψη.

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι ενότητες κατά την αποθήκευση σε μορφή PPT (PowerPoint 97–2003);**

Όχι. Η μορφή PPT δεν υποστηρίζει μεταδεδομένα ενοτήτων, επομένως η ομαδοποίηση ενοτήτων χάνονται κατά την αποθήκευση σε .ppt.

**Μπορεί μια ολόκληρη ενότητα να είναι "κρυφή";**

Όχι. Μια ενότητα δεν έχει κατάσταση ορατότητας. Για να κρύψετε τα περιεχόμενά της, καλέστε το [Slide.setHidden](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#setHidden) για κάθε διαφάνεια στην ενότητα.

**Πώς μπορώ να βρω την ενότητα που περιέχει μια διαφάνεια;**

Προσπελάστε κάθε ενότητα στη συλλογή που επιστρέφεται από το [Presentation.getSections](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSections), καλέστε το [Section.getSlidesListOfSection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getSlidesListOfSection) για κάθε ενότητα και συγκρίνετε τις επιστρεφόμενες διαφάνειες με τη διαφάνεια‑στόχο. Για μια μη κενή ενότητα, το [Section.getStartedFromSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getStartedFromSlide) επιστρέφει την πρώτη της διαφάνεια· για μια κενή ενότητα, επιστρέφει `null`.