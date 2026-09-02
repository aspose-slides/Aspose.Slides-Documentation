---
title: Διαχείριση κεφαλίδων και υποσέλιδων παρουσίασης σε Android
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τους δείκτες θέσης υποσέλιδου, ημερομηνίας-ώρας, αριθμού διαφάνειας και κεφαλίδας σε διαφάνειες, σελίδες σημειώσεων και φυλλάδια με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Το PowerPoint χρησιμοποιεί διαφορετικούς δείκτες θέσης κεφαλίδας και υποσέλιδου ανάλογα με τον τύπο σελίδας. Το Aspose.Slides για Android μέσω Java σάς επιτρέπει να ελέγχετε το κείμενο και την ορατότητα αυτών των δεικτών θέσης μέσω διεπαφών διαχειριστή κεφαλίδας/υποσέλιδου.

Οι διαθέσιμοι δείκτες θέσης εξαρτώνται από το πεδίο εφαρμογής:

| Πεδίο | Κεφαλίδα | Υποσέλιδο | Ημερομηνία/ώρα | Αριθμός διαφάνειας/σελίδας |
|---|---|---|---|---|
| Κανονική διαφάνεια | Όχι | Ναι | Ναι | Ναι |
| Κύριος σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Διαφάνεια σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Κύριος φυλλάδιο | Ναι | Ναι | Ναι | Ναι |

Μια κανονική διαφάνεια παρουσίασης δεν διαθέτει δείκτη θέσης κεφαλίδας. Οι κεφαλίδες είναι διαθέσιμες σε σελίδες σημειώσεων και φυλλάδια. Για κανονικές διαφάνειες, χρησιμοποιήστε αντί αυτού τους δείκτες θέσης υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας.

Το πεδίο εφαρμογής μιας αλλαγής εξαρτάται από τον διαχειριστή που χρησιμοποιείτε. Η διεπαφή [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islideheaderfootermanager/) ελέγχει μία κανονική διαφάνεια. Η διεπαφή [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) ελέγχει μία διαφάνεια σημειώσεων. Οι διαχειριστές master και layout μπορούν επίσης να μεταβιβάσουν τις ρυθμίσεις σε εξαρτημένες διαφάνειες, ενώ η διεπαφή [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) ελέγχει το κύριο φυλλάδιο.

## **Ορισμός υποσέλιδου, ημερομηνίας/ώρας και αριθμών διαφανειών σε κανονικές διαφάνειες**

Για τις κανονικές διαφάνειες, η βασική ροή εργασίας είναι να αποκτήσετε πρόσβαση στον διαχειριστή κεφαλίδας/υποσέλιδου κάθε διαφάνειας, να ορίσετε το κείμενο του υποσέλιδου και της ημερομηνίας/ώρας, να ενεργοποιήσετε τους απαιτούμενους δείκτες θέσης και να αποθηκεύσετε την παρουσίαση. Οι αριθμοί διαφανειών δημιουργούνται από την παρουσίαση, οπότε χρειάζεται μόνο να ελέγξετε την ορατότητά τους.

Χρησιμοποιήστε το [`setFooterText`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) και το [`setDateTimeText`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) για να ορίσετε το κείμενο, και χρησιμοποιήστε τα [`setFooterVisibility`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), και [`setSlideNumberVisibility`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) για να εμφανίσετε τους αντίστοιχους δείκτες θέσης.

Το ακόλουθο πλήρες παράδειγμα εφαρμόζει το ίδιο υποσέλιδο, κείμενο ημερομηνίας/ώρας και ορατότητα αριθμού διαφάνειας σε όλες τις κανονικές διαφάνειες:

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

Εάν χρειάζεται να ενημερώσετε μόνο μία διαφάνεια, αποκτήστε πρόσβαση σε αυτήν απευθείας μέσω της μεθόδου [`getSlides`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlides--) αντί να διασχίζετε όλη τη συλλογή.

## **Ορισμός κεφαλίδων και υποσέλιδων στον κύριο σημειώσεων**

Ο κύριος σημειώσεων ορίζει κοινή μορφοποίηση και συμπεριφορά δεικτών θέσης για σελίδες σημειώσεων. Χρησιμοποιήστε τη διεπαφή [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) όταν θέλετε να αλλάξετε μόνο τον ίδιο τον κύριο σημειώσεων.

Το ακόλουθο παράδειγμα ορίζει κεφαλίδα, υποσέλιδο και κείμενο ημερομηνίας/ώρας στον κύριο σημειώσεων και κάνει όλους τους υποστηριζόμενους δείκτες θέσης ορατούς σε αυτόν τον κύριο:

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

Η μέθοδος [`getMasterNotesSlide`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) επιστρέφει `null` όταν η παρουσίαση δεν περιέχει κύριο σημειώσεων.

## **Εφαρμογή ρυθμίσεων κύριου σημειώσεων σε θυγατρικές διαφάνειες σημειώσεων**

Ένας κύριος σημειώσεων μπορεί να εφαρμόσει τις ρυθμίσεις κεφαλίδας και υποσέλιδου στον εαυτό του και σε όλες τις εξαρτημένες διαφάνειες σημειώσεων. Χρησιμοποιήστε τις αφιερωμένες μεθόδους διάδοσης στη [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) όταν οι ίδιες ρυθμίσεις πρέπει να εφαρμοστούν σε όλη τη ιεραρχία σημειώσεων.

Για παράδειγμα, τα [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) και [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) ενημερώνουν την κεφαλίδα του κύριου σημειώσεων και όλες τις θυγατρικές κεφαλίδες. Ισοδύναμες μέθοδοι είναι διαθέσιμες για τα υποσέλιδα, την ημερομηνία/ώρα και τους αριθμούς διαφανειών.

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

Οι μέθοδοι διάδοσης που χρησιμοποιήθηκαν παραπάνω είναι τα [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), και [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Ορισμός κεφαλίδων και υποσέλιδων σε μεμονωμένη διαφάνεια σημειώσεων**

Μια διαφάνεια σημειώσεων ανήκει σε μια συγκεκριμένη κανονική διαφάνεια. Χρησιμοποιήστε τη διεπαφή [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) όταν θέλετε να προσαρμόσετε μόνο αυτή τη σελίδα σημειώσεων.

Η μέθοδος [`addNotesSlide`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) επιστρέφει τη διαφάνεια σημειώσεων για τη τρέχουσα διαφάνεια και δημιουργεί μία αν δεν υπάρχει ήδη. Το ακόλουθο παράδειγμα διαμορφώνει τη σελίδα σημειώσεων που συνδέεται με την πρώτη διαφάνεια της παρουσίασης:

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

Εάν πρώτα διαδώσετε τις ρυθμίσεις από τον κύριο σημειώσεων και μετά αλλάξετε μία μεμονωμένη διαφάνεια σημειώσεων, οι μεταγενέστερες ρυθμίσεις ανά διαφάνεια σας επιτρέπουν να προσαρμόσετε αυτή τη σελίδα σημειώσεων ανεξάρτητα.

## **Ορισμός κεφαλίδων και υποσέλιδων στον κύριο φυλλάδιο**

Οι σελίδες φυλλαδίων χρησιμοποιούν τον κύριο φυλλάδιο για τους δείκτες θέσης κεφαλίδας, υποσέλιδου, ημερομηνίας/ώρας και αριθμού σελίδας. Σε αντίθεση με τις σελίδες σημειώσεων, οι ρυθμίσεις φυλλαδίου διαχειρίζονται μέσω του κύριου φυλλαδίου αντί για μεμονωμένες διαφάνειες φυλλαδίου.

Χρησιμοποιήστε τη μέθοδο [`getMasterHandoutSlide`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) για πρόσβαση στον κύριο φυλλάδιο. Εάν δεν υπάρχει, καλέστε το [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) για να δημιουργήσετε τον προεπιλεγμένο κύριο φυλλάδιο.

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

## **Κατανόηση πεδίου εφαρμογής και κληρονομικότητας**

Επιλέξτε τον διαχειριστή κεφαλίδας/υποσέλιδου που αντιστοιχεί στο πεδίο εφαρμογής που θέλετε να αλλάξετε:

- Το `ISlideHeaderFooterManager` αλλάζει τις ρυθμίσεις υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας για μία κανονική διαφάνεια.
- Το `ILayoutSlideHeaderFooterManager` ελέγχει μία διαφάνεια layout και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- Το `IMasterSlideHeaderFooterManager` ελέγχει έναν κύριο κανονικών διαφανειών και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- Το `IMasterNotesSlideHeaderFooterManager` ελέγχει τον κύριο σημειώσεων και μπορεί να διαδώσει τις ρυθμίσεις σε όλες τις εξαρτημένες διαφάνειες σημειώσεων.
- Το `INotesSlideHeaderFooterManager` αλλάζει μία διαφάνεια σημειώσεων και υποστηρίζει δείκτη θέσης κεφαλίδας εκτός από υποσέλιδο, ημερομηνία/ώρα και αριθμό διαφάνειας.
- Το `IMasterHandoutSlideHeaderFooterManager` αλλάζει τον κύριο φυλλάδιο και υποστηρίζει και τα τέσσερα είδη δεικτών θέσης.

Χρησιμοποιήστε τη διάδοση από έναν κύριο ή layout όταν η ίδια ρύθμιση πρέπει να ισχύει σε όλη τη ιεραρχία του. Χρησιμοποιήστε έναν μεμονωμένο διαχειριστή διαφάνειας ή διαφάνειας σημειώσεων όταν χρειάζεστε τοπική ρύθμιση για μία σελίδα.

## **Συχνές ερωτήσεις**

**Μπορώ να προσθέσω κεφαλίδα σε κανονική διαφάνεια;**

Όχι. Το PowerPoint δεν ορίζει δείκτη θέσης κεφαλίδας για κανονικές διαφάνειες. Σε κανονικές διαφάνειες, χρησιμοποιήστε τους δείκτες θέσης υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας. Οι δείκτες θέσης κεφαλίδας είναι διαθέσιμοι σε σελίδες σημειώσεων και φυλλάδια.

**Τι γίνεται αν ένας δείκτης θέσης υποσέλιδου, ημερομηνίας/ώρας ή αριθμού διαφάνειας δεν είναι ορατός;**

Χρησιμοποιήστε τον αντίστοιχο διαχειριστή κεφαλίδας/υποσέλιδου για να ελέγξετε την ορατότητά του και ενεργοποιήστε τον όταν χρειάζεται. Για παράδειγμα, το [`isFooterVisible`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) αναφέρει αν υπάρχει δείκτης θέσης υποσέλιδου, και το [`setFooterVisibility`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) αλλάζει την ορατότητά του.

**Πώς μπορώ να ξεκινήσω την αρίθμηση διαφανειών από τιμή διαφορετική από 1;**

Καλέστε τη μέθοδο [`setFirstSlideNumber`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) της παρουσίασης. Οι δείκτες θέσης αριθμού διαφάνειας θα χρησιμοποιούν τότε την ενημερωμένη ακολουθία αρίθμησης.

**Τι συμβαίνει με τις κεφαλίδες και τα υποσέλιδα όταν γίνεται εξαγωγή σε PDF, εικόνες ή HTML;**

Τα ορατά στοιχεία κεφαλίδας και υποσέλιδου αποδίδονται μαζί με το υπόλοιπο περιεχόμενο της παρουσίασης στη μορφή εξόδου. Η εμφάνισή τους εξαρτάται από τον τύπο σελίδας που εξάγεται και τις αντίστοιχες ρυθμίσεις ορατότητας δεικτών θέσης.