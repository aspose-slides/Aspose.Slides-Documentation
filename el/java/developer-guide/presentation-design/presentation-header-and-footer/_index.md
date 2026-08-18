---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης σε Java
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις θέσεις κράτησης υποσέλιδου, ημερομηνίας-ώρας, αριθμού διαφάνειας και κεφαλίδας σε διαφάνειες, σελίδες σημειώσεων και φυλλάδια με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Το PowerPoint χρησιμοποιεί διαφορετικά σύμβολα κράτησης θέσης κεφαλίδας και υποσέλιδου ανάλογα με τον τύπο σελίδας. Το Aspose.Slides for Java σάς επιτρέπει να ελέγχετε το κείμενο και την ορατότητα αυτών των θέσεων κράτησης μέσω διεπαφών διαχειριστή κεφαλίδας/υποσέλιδου.

Οι διαθέσιμες θέσεις κράτησης εξαρτώνται από το πεδίο:

| Εύρος | Κεφαλίδα | Υποσέλιδο | Ημερομηνία/ώρα | Αριθμός διαφάνειας/σελίδας |
|---|---|---|---|---|
| Κανονική διαφάνεια | Όχι | Ναι | Ναι | Ναι |
| Κύριος σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Διαφάνεια σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Κύριος φυλλάδίου | Ναι | Ναι | Ναι | Ναι |

Μία κανονική διαφάνεια παρουσίασης δεν διαθέτει θέση κράτησης κεφαλίδας. Οι κεφαλίδες είναι διαθέσιμες σε σελίδες σημειώσεων και φυλλάδια. Για κανονικές διαφάνειες, χρησιμοποιήστε τις θέσεις κράτησης υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας αντί αυτού.

Η απήχηση μιας αλλαγής εξαρτάται από το διαχειριστή που χρησιμοποιείτε. Η διεπαφή [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideheaderfootermanager/) ελέγχει μία κανονική διαφάνεια. Η διεπαφή [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/inotesslideheaderfootermanager/) ελέγχει μία διαφάνεια σημειώσεων. Οι διαχειριστές κύριου και διάταξης μπορούν επίσης να διαδώσουν τις ρυθμίσεις σε εξαρτημένες διαφάνειες, ενώ η διεπαφή [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) ελέγχει τον κύριο φυλλάδιο.

## **Ορισμός υποσέλιδου, ημερομηνίας/ώρας και αριθμών διαφάνειας σε κανονικές διαφάνειες**

Για κανονικές διαφάνειες, η βασική ροή εργασίας είναι να προσπελάσετε τον διαχειριστή κεφαλίδας/υποσέλιδου κάθε διαφάνειας, να ορίσετε το κείμενο υποσέλιδου και ημερομηνίας/ώρας, να ενεργοποιήσετε τις απαιτούμενες θέσεις κράτησης και να αποθηκεύσετε την παρουσίαση. Οι αριθμοί διαφανειών δημιουργούνται από την παρουσίαση, επομένως χρειάζεται μόνο να ελέγξετε την ορατότητά τους.

Χρησιμοποιήστε [`setFooterText`](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) και [`setDateTimeText`](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) για να ορίσετε το κείμενο, και χρησιμοποιήστε [`setFooterVisibility`](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), και [`setSlideNumberVisibility`](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) για να εμφανίσετε τις αντίστοιχες θέσεις κράτησης.

Το παρακάτω παράδειγμα end‑to‑end εφαρμόζει το ίδιο υποσέλιδο, κείμενο ημερομηνίας/ώρας και ορατότητα αριθμού διαφάνειας σε όλες τις κανονικές διαφάνειες:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αν χρειάζεται να ενημερώσετε μόνο μία διαφάνεια, προσπελάστε την απευθείας μέσω της μεθόδου [`getSlides`](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSlides--) αντί να επαναλαμβάνετε όλη τη συλλογή.

## **Ορισμός κεφαλίδων και υποσέλιδων στον Κύριο Σημειώσεων**

Ο κύριος σημειώσεων ορίζει κοινή μορφοποίηση και συμπεριφορά θέσεων κράτησης για σελίδες σημειώσεων. Χρησιμοποιήστε τη διεπαφή [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/) όταν θέλετε να αλλάξετε μόνο τον ίδιο τον κύριο σημειώσεων.

Το παρακάτω παράδειγμα ορίζει κεφαλίδα, υποσέλιδο και κείμενο ημερομηνίας/ώρας στον κύριο σημειώσεων και κάνει όλες τις υποστηριζόμενες θέσεις κράτησης ορατές σε αυτόν τον κύριο:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μέθοδος [`getMasterNotesSlide`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) επιστρέφει `null` όταν η παρουσίαση δεν περιέχει κύριο σημειώσεων.

## **Εφαρμογή Ρυθμίσεων Κύριου Σημειώσεων σε Παιδικές Διαφάνειες Σημειώσεων**

Ένας κύριος σημειώσεων μπορεί να εφαρμόσει ρυθμίσεις κεφαλίδας και υποσέλιδου στον εαυτό του και σε όλες τις εξαρτημένες διαφάνειες σημειώσεων. Χρησιμοποιήστε τις αφιερωμένες μεθόδους διάδοσης στη διεπαφή [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/) όταν οι ίδιες ρυθμίσεις πρέπει να εφαρμοστούν σε όλη την ιεραρχία σημειώσεων.

Για παράδειγμα, οι μέθοδοι [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) και [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) ενημερώνουν την κεφαλίδα του κύριου σημειώσεων και όλες τις παιδικές κεφαλίδες. Παρόμοιες μέθοδοι υπάρχουν για υποσέλιδα, ημερομηνία/ώρα και αριθμούς διαφάνειας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι μέθοδοι διάδοσης που χρησιμοποιήθηκαν παραπάνω είναι [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), και [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Ορισμός κεφαλίδων και υποσέλιδων σε Ατομική Διαφάνεια Σημειώσεων**

Μια διαφάνεια σημειώσεων ανήκει σε συγκεκριμένη κανονική διαφάνεια. Χρησιμοποιήστε τη διεπαφή [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/inotesslideheaderfootermanager/) όταν θέλετε να προσαρμόσετε μόνο αυτή τη σελίδα σημειώσεων.

Η μέθοδος [`addNotesSlide`](https://reference.aspose.com/slides/el/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) επιστρέφει τη διαφάνεια σημειώσεων για την τρέχουσα διαφάνεια και τη δημιουργεί εάν δεν υπάρχει ήδη. Το παρακάτω παράδειγμα διαμορφώνει τη σελίδα σημειώσεων που συνδέεται με την πρώτη διαφάνεια παρουσίασης:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αν πρώτα διαδώσετε τις ρυθμίσεις από τον κύριο σημειώσεων και μετά αλλάξετε μια ατομική διαφάνεια σημειώσεων, οι μετέπειτα ρυθμίσεις ανά διαφάνεια σας επιτρέπουν να προσαρμόσετε αυτή τη σελίδα σημειώσεων ανεξάρτητα.

## **Ορισμός κεφαλίδων και υποσέλιδων στον Κύριο Φυλλάδιου**

Οι σελίδες φυλλαδίου χρησιμοποιούν τον κύριο φυλλάδιο για τις θέσεις κράτησης κεφαλίδας, υποσέλιδου, ημερομηνίας/ώρας και αριθμού σελίδας. Σε αντίθεση με τις σελίδες σημειώσεων, οι ρυθμίσεις φυλλαδίου διαχειρίζονται μέσω του κύριου φυλλάδιου και όχι μέσω ατομικών διαφανειών φυλλαδίου.

Χρησιμοποιήστε τη μέθοδο [`getMasterHandoutSlide`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) για να προσπελάσετε τον κύριο φυλλάδιο. Εάν δεν υπάρχει, καλέστε τη μέθοδο [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) για να δημιουργήσετε τον προεπιλεγμένο κύριο φυλλάδιο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Κατανόηση Πεδίου και Κληρονομικότητας**

Επιλέξτε τον διαχειριστή κεφαλίδας/υποσέλιδου που ταιριάζει στο πεδίο που θέλετε να αλλάξετε:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/islideheaderfootermanager/) αλλάζει τις ρυθμίσεις υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας για μία κανονική διαφάνεια.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslideheaderfootermanager/) ελέγχει μια διαφάνεια διάταξης και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslideheaderfootermanager/) ελέγχει έναν κύριο διαφάνειας και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasternotesslideheaderfootermanager/) ελέγχει τον κύριο σημειώσεων και μπορεί να διαδώσει τις ρυθμίσεις σε όλες τις εξαρτημένες διαφάνειες σημειώσεων.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/inotesslideheaderfootermanager/) αλλάζει μία διαφάνεια σημειώσεων και υποστηρίζει θέση κράτησης κεφαλίδας εκτός από υποσέλιδο, ημερομηνία/ώρα και αριθμό διαφάνειας.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) αλλάζει τον κύριο φυλλάδιο και υποστηρίζει όλους τους τέσσερις τύπους θέσεων κράτησης.

Χρησιμοποιήστε διάδοση από κύριο ή διάταξη όταν η ίδια ρύθμιση πρέπει να ισχύει σε ολόκληρη την ιεραρχία του. Χρησιμοποιήστε διαχειριστή ατομικής διαφάνειας ή διαφάνειας σημειώσεων όταν χρειάζεστε τοπική ρύθμιση για μία σελίδα.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσθέσω κεφαλίδα σε κανονική διαφάνεια;**

Όχι. Το PowerPoint δεν ορίζει θέση κράτησης κεφαλίδας για κανονικές διαφάνειες. Σε κανονικές διαφάνειες, χρησιμοποιήστε τις θέσεις κράτησης υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας. Οι θέσεις κράτησης κεφαλίδας είναι διαθέσιμες σε σελίδες σημειώσεων και φυλλάδια.

**Τι γίνεται αν μια θέση κράτησης υποσέλιδου, ημερομηνίας/ώρας ή αριθμού διαφάνειας δεν είναι ορατή;**

Χρησιμοποιήστε τον αντίστοιχο διαχειριστή κεφαλίδας/υποσέλιδου για να ελέγξετε την ορατότητά του και ενεργοποιήστε το όταν χρειάζεται. Για παράδειγμα, η μέθοδος [`isFooterVisible`](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) αναφέρει εάν υπάρχει θέση κράτησης υποσέλιδου, και η μέθοδος [`setFooterVisibility`](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) αλλάζει την ορατότητά του.

**Πώς μπορώ να ξεκινήσω την αρίθμηση διαφανειών από τιμή διαφορετική από το 1;**

Κληθείτε τη μέθοδο [`setFirstSlideNumber`](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) της παρουσίασης. Οι θέσεις κράτησης αριθμού διαφάνειας θα χρησιμοποιήσουν την ενημερωμένη ακολουθία αρίθμησης.

**Τι συμβαίνει με τις κεφαλίδες και τα υποσέλιδα κατά την εξαγωγή σε PDF, εικόνες ή HTML;**

Τα ορατά στοιχεία κεφαλίδας και υποσέλιδου αποδίδονται μαζί με το υπόλοιπο περιεχόμενο της παρουσίασης στην έξοδο. Η εμφάνισή τους εξαρτάται από τον τύπο σελίδας που εξάγεται και τις αντίστοιχες ρυθμίσεις ορατότητας των θέσεων κράτησης.