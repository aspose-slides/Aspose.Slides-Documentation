---
title: Διαχείριση Τμημάτων Διαφανειών σε Παρουσιάσεις σε Android
linktitle: Τμήμα Διαφάνειας
type: docs
weight: 90
url: /el/androidjava/slide-section/
keywords:
- δημιουργία τμήματος
- προσθήκη τμήματος
- επεξεργασία τμήματος
- αλλαγή τμήματος
- όνομα τμήματος
- ανάκτηση διαφανειών τμήματος
- επεξεργασία διαφανειών τμήματος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα τμήματα διαφανειών με το Aspose.Slides για Android μέσω Java: δημιουργία, μετονομασία, επαναδιάταξη, ανάκτηση και επεξεργασία διαφανειών τμήματος σε παρουσιάσεις PPTX."
---
## **Εισαγωγή**

Τα τμήματα οργανώνουν διαδοχικές διαφάνειες σε ονομασμένες ομάδες χωρίς να αλλάζουν το περιεχόμενο της διαφάνειας. Με το Aspose.Slides for Android μέσω Java, μπορείτε να δημιουργήσετε, να επαναδιατάξετε, να μετονομάσετε, να εξετάσετε και να αφαιρέσετε τμήματα μέσω της μεθόδου [Presentation.getSections](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSections--) .

Τα τμήματα είναι ιδιαίτερα χρήσιμα όταν:

- μια μεγάλη παρουσίαση χρειάζεται να χωριστεί σε λογικά θέματα ή κεφάλαια·
- διαφορετικές ομάδες διαφανειών ανατίθενται σε διαφορετικούς συνεργάτες·
- είναι απαραίτητο να υποβληθούν σε επεξεργασία, μεταφορά ή συγχώνευση ως ομάδες.

Επιλέξτε σύντομα ονόματα τμημάτων που περιγράφουν το σκοπό των ομαδοποιημένων διαφανειών. Επειδή τα τμήματα είναι μέρος της δομής της παρουσίασης, χρησιμοποιήστε τα API τμημάτων για να καθορίσετε τη συμμετοχή αντί να τη συμπεραίνετε από τις θέσεις των διαφανειών.

## **Δημιουργία και Διαχείριση Τμημάτων**

Χρησιμοποιήστε το [ISectionCollection.addSection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) για να δημιουργήσετε ένα τμήμα καθορίζοντας το όνομά του και τη διαφάνεια εκκίνησης. Το Aspose.Slides καθορίζει ποιες διαφάνειες ανήκουν στο τμήμα με βάση την τρέχουσα δομή τμημάτων της παρουσίασης.

Το ίδιο [ISectionCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isectioncollection/) επίσης σας επιτρέπει να:

- μετακινήσετε ένα τμήμα μαζί με τις διαφάνειές του χρησιμοποιώντας το [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- αφαιρέσετε μόνο τον ορισμό του τμήματος με το [ISectionCollection.removeSection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), το οποίο διατηρεί τις διαφάνειές του·
- αφαιρέσετε ένα τμήμα και τις διαφάνειές του με το [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- προσθέσετε ένα κενό τμήμα στο τέλος με το [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Το παρακάτω παράδειγμα δημιουργεί δύο τμήματα, μετακινεί ένα από αυτά, το αφαιρεί μαζί με τις διαφάνειές του και προσθέτει ένα κενό τμήμα:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Μετά από αυτές τις λειτουργίες, η παρουσίαση περιέχει το τμήμα `Introduction` με τις διαφάνειες του και ένα κενό τμήμα `Appendix`. Το τμήμα `Results` και οι διαφάνειες του έχουν αφαιρεθεί.

## **Μετονομασία Τμημάτων**

Για να μετονομάσετε ένα τμήμα, καλέστε τη μέθοδο [ISection.setName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#setName-java.lang.String-). Οι διαφάνειες του τμήματος και η θέση του παραμένουν αμετάβλητες.

Το παρακάτω παράδειγμα δημιουργεί ένα τμήμα και αλλάζει το όνομά του:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Ανάκτηση Διαφανειών από Τμήματα**

Η μέθοδος [Presentation.getSections](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSections--) επιστρέφει ένα [ISectionCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isectioncollection/) το οποίο μπορείτε να διασχίσετε. Για κάθε [ISection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/), καλέστε το [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) για να λάβετε τις διαφάνειες που ανήκουν σε αυτόν αυτή τη στιγμή. Η μέθοδος επιστρέφει ένα [ISectionSlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isectionslidecollection/), το οποίο παρέχει αριθμό, πρόσβαση μέσω δείκτη και επανάληψη.

Το παρακάτω παράδειγμα δημιουργεί δύο γεμάτα τμήματα και ένα κενό τμήμα, στη συνέχεια εκτυπώνει για κάθε τμήμα το [name](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getName--), το [identifier](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getSectionId--), τη [starting slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), τον αριθμό διαφανειών και τους αριθμούς διαφανειών. Χρησιμοποιεί το [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) για να διαβάσει την πρώτη διαφάνεια και μια βελτιωμένη δήλωση `for` για να επεξεργαστεί κάθε διαφάνεια. Για το κενό τμήμα, η επιστρεφόμενη συλλογή έχει μέγεθος μηδέν, η μέθοδος δεν καλείται και η επανάληψη δεν εκτελεί καμία ενέργεια.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Η συμμετοχή σε τμήμα καθορίζεται από τη δομή τμημάτων της παρουσίασης. Μην υπολογίζετε το εύρος ενός τμήματος χειροκίνητα από το [ISection.getStartedFromSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), τους δείκτες των διαφανειών και τη διαφάνεια εκκίνησης του επόμενου τμήματος.

Οι δομικές αλλαγές μπορούν να αλλάξουν τόσο τις διαφάνειες που επιστρέφονται για ένα τμήμα όσο και τους αριθμούς των διαφανειών τους. Αυτό περιλαμβάνει επαναδιάταξη διαφανειών, κλωνοποίηση μιας διαφάνειας σε ένα τμήμα, μετακίνηση ενός τμήματος μαζί με τις διαφάνειές του, αφαίρεση διαφανειών και αφαίρεση τμημάτων. Το επόμενο παράδειγμα καλεί το [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) μετά από κάθε τέτοια αλλαγή αντί να διατηρεί υποθέσεις σχετικά με τα προηγούμενα όρια του τμήματος.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Καλέστε ξανά το [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) όποτε διαφάνειες ή τμήματα επαναδιατάσσονται, κλωνοποιούνται, μετακινούνται ή αφαιρούνται. Αυτό διατηρεί την επόμενη επεξεργασία συμβατή με την τρέχουσα δομή της παρουσίασης.

Η μορφή PPT (PowerPoint 97–2003) δεν διατηρεί τα μεταδεδομένα των τμημάτων. Χρησιμοποιήστε αυτή τη ροή εργασίας με μια μορφή που υποστηρίζει τμήματα, όπως το PPTX· η μετατροπή σε PPT αφαιρεί τη δομή τμημάτων που χρειάζεται για μετέπειτα επανάληψη.

## **Συχνές Ερωτήσεις**

**Διατηρούνται τα τμήματα κατά την αποθήκευση σε μορφή PPT (PowerPoint 97–2003);**

Όχι. Η μορφή PPT δεν υποστηρίζει μεταδεδομένα τμημάτων, έτσι η ομαδοποίηση τμημάτων χάνονται κατά την αποθήκευση σε .ppt.

**Μπορεί ένα ολόκληρο τμήμα να είναι "κρυφό";**

Όχι. Ένα τμήμα δεν έχει κατάσταση ορατότητας. Για να κρύψετε τα περιεχόμενά του, καλέστε το [ISlide.setHidden](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#setHidden-boolean-) για κάθε διαφάνεια στο τμήμα.

**Πώς μπορώ να βρω το τμήμα που περιέχει μια διαφάνεια;**

Διασχίστε τη συλλογή που επιστρέφει η [Presentation.getSections](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSections--) , καλέστε το [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) για κάθε τμήμα και συγκρίνετε τις επιστρεφόμενες διαφάνειες με τη διαφάνεια-στόχο. Για ένα μη κενό τμήμα, το [ISection.getStartedFromSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) επιστρέφει την πρώτη του διαφάνεια· για ένα κενό τμήμα, επιστρέφει `null`.