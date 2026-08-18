---
title: Κλωνοποίηση διαφανειών παρουσίασης στο Android
linktitle: Κλωνοποίηση Διαφανειών
type: docs
weight: 35
url: /el/androidjava/clone-slides/
keywords:
- κλωνοποίηση διαφάνειας
- αντιγραφή διαφάνειας
- αποθήκευση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Αντιγράψτε διαφάνειες PowerPoint με το Aspose.Slides για Android. Ακολουθήστε τα σαφή παραδείγματα κώδικα Java για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλείψετε την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντίγραφου κάτι. Το Aspose.Slides for Android via Java επιτρέπει επίσης τη δημιουργία αντιγραφής ή κλώνου οποιασδήποτε διαφάνειας και την εισαγωγή της κλωνοποιημένης διαφάνειας στην τρέχουσα ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν διάφοροι τρόποι κλωνοποίησης μιας διαφάνειας:

- Κλωνοποίηση στο τέλος εντός μίας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση εντός παρουσίασης.
- Κλωνοποίηση στο τέλος σε άλλη παρουσίαση.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for Android via Java, (μια συλλογή αντικειμένων [ISlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlide)) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) και [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφάνειας.

## **Κλωνοποίηση διαφάνειας στο τέλος μιας παρουσίασης**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση στο τέλος των υπαρχουσών διαφανειών, χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ακολουθώντας τα βήματα που αναφέρονται παρακάτω:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο.
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```java
import com.aspose.slides.*;

// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Κλωνοποιήστε την επιλεγμένη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Γράψτε την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση εντός μιας παρουσίασης**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Δημιουργήστε την κλάση αναφέροντας τη συλλογή [**Slides**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με τον δείκτη για τη νέα θέση ως παράμετρο.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (στη θέση 2 – δείκτης 1 – της παρουσίασης) στη θέση 3 – δείκτης 2 – της παρουσίασης.

```java
import com.aspose.slides.*;

// Αρχικοποιήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Αποκτήστε τη συλλογή των διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.getSlides();

    // Κλωνοποιήστε την επιλεγμένη διαφάνεια στον καθορισμένο δείκτη στην ίδια παρουσίαση
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Γράψτε την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας στο τέλος μιας άλλης παρουσίασης**
Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υπαρχουσών διαφανειών:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection) αναφέροντας τη συλλογή [**Slides**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση ως παράμετρο.
1. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης.

```java
import com.aspose.slides.*;

// Αρχικοποιήστε την κλάση Presentation για να φορτώσετε το αρχείο πηγής παρουσίασης
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Αρχικοποιήστε την κλάση Presentation για την προοριστική PPTX (στην οποία θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Κλωνοποιήστε την επιλεγμένη διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Γράψτε την προοριστική παρουσίαση στο δίσκο
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση σε άλλη παρουσίαση**
Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, σε συγκεκριμένη θέση:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με την επιθυμητή θέση ως παράμετρο.
1. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από το δείκτη μηδέν της πηγαίας παρουσίασης) στον δείκτη 1 (θέση 2) της προοριστικής παρουσίασης.

```java
import com.aspose.slides.*;

// Αρχικοποιήστε την κλάση Presentation για να φορτώσετε το αρχείο πηγής παρουσίασης
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Αρχικοποιήστε την κλάση Presentation για την προοριστική PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Κλωνοποιήστε την επιλεγμένη διαφάνεια από την πηγαία παρουσίαση στον καθορισμένο δείκτη στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Γράψτε την προοριστική παρουσίαση στο δίσκο
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε συγκεκριμένη θέση σε άλλη παρουσίαση**
Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια με κύρια διαφάνεια (master slide) από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, πρώτα πρέπει να κλωνοποιήσετε την επιθυμητή κύρια διαφάνεια από την πηγαία παρουσίαση στην προοριστική. Στη συνέχεια, χρησιμοποιήστε αυτήν την κύρια διαφάνεια για την κλωνοποίηση της διαφάνειας με κύρια διαφάνεια. Η μέθοδος [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) απαιτεί μια κύρια διαφάνεια από την προοριστική παρουσίαση, όχι από την πηγαία. Για την κλωνοποίηση της διαφάνειας με κύρια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση.
1. Πρόσβαση στη διαφάνεια που πρόκειται να κλωνοποιηθεί μαζί με την κύρια διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [IMasterSlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IMasterSlideCollection) αναφέροντας τη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [IMasterSlideCollection] και περάστε την κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο.
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) ορίζοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation] της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection] και περάστε τη διαφάνεια από την πηγαία παρουσίαση και την κύρια διαφάνεια ως παράμετρο.
1. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια (στην θέση μηδέν της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης χρησιμοποιώντας μια κύρια διαφάνεια από τη πηγαία διαφάνεια.

```java
import com.aspose.slides.*;

// Αρχικοποιήστε την κλάση Presentation για να φορτώσετε το αρχείο πηγής παρουσίασης
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Αρχικοποιήστε την κλάση Presentation για την προοριστική παρουσίαση (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Δημιουργήστε ένα ISlide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
        // την κύρια διαφάνεια
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Κλωνοποιήστε την επιθυμητή κύρια διαφάνεια από την πηγαία παρουσίαση στη συλλογή κύριων διαφανειών στην
        // προοριστική παρουσίαση
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Κλωνοποιήστε την επιλεγμένη διαφάνεια από την πηγαία παρουσίαση με την επιθυμητή κύρια διαφάνεια στο τέλος της
        // συλλογής διαφανειών στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Αποθηκεύστε την προοριστική παρουσίαση στο δίσκο
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας στο τέλος ενός συγκεκριμένου τμήματος**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση αλλά σε διαφορετικό τμήμα, χρησιμοποιήστε τη μέθοδο [**addClone**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) που εκτίθεται από το interface [**ISlideCollection**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection). Το Aspose.Slides for Android via Java επιτρέπει την κλωνοποίηση μιας διαφάνειας από το πρώτο τμήμα και την εισαγωγή της κλωνοποιημένης διαφάνειας στο δεύτερο τμήμα της ίδιας παρουσίασης.

Το ακόλουθο απόσπασμα κώδικα δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισάγετε την κλωνοποιημένη διαφάνεια σε ένα συγκεκριμένο τμήμα.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
    // Αποθηκεύστε την προοριστική παρουσίαση στο δίσκο
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Διασφάλιση Συμφωνίας Μεγέθους Διαφάνειας**

Κατά την κλωνοποίηση διαφανειών σε άλλη παρουσίαση, βεβαιωθείτε ότι η προοριστική παρουσίαση έχει το ίδιο μέγεθος διαφάνειας με την πηγαία. Εάν τα μεγέθη διαφάνειας διαφέρουν, το Aspose.Slides δεν επαναμετρά αυτόματα τα κλωνοποιημένα σχήματα· διατηρούνται οι αρχικές τους συντεταγμένες και διαστάσεις, κάτι που μπορεί να προκαλέσει μη ευθυγράμμιση ή υπερέκταση του περιεχομένου εκτός των ορίων της διαφάνειας.

Μπορείτε να ορίσετε το μέγεθος διαφάνειας της προοριστικής παρουσίασης ώστε να ταιριάζει με το αρχικό πριν κλωνοποιήσετε τη κύρια διαφάνεια και τη διαφάνεια:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Κάντε αυτό πριν κλωνοποιήσετε τη κύρια διαφάνεια και τη διαφάνεια.

## **Συχνές Ερωτήσεις**

**Κλωνοποιούνται οι σημειώσεις ομιλητή και τα σχόλια αξιολογητών;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια αξιολόγησης συμπεριλαμβάνονται στο κλώνο. Εάν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/androidjava/presentation-notes/) μετά την εισαγωγή.

**Πώς αντιμετωπίζονται τα γραφήματα και οι πηγές δεδομένων τους;**

Το αντικείμενο γραφήματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Εάν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ. ένα ενσωματωμένο OLE‑βιβλίο εργασίας), η σύνδεση διατηρείται ως [OLE αντικείμενο](/slides/el/androidjava/manage-ole/). Μετά τη μετακίνηση μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ενημέρωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για το κ clones;**

Ναι. Μπορείτε να εισαγάγετε το κλώνο σε συγκεκριμένο δείκτη διαφάνειας και να το τοποθετήσετε σε επιλεγμένο [τμήμα](/slides/el/androidjava/slide-section/). Εάν το στόχο τμήμα δεν υπάρχει, δημιουργήστε το πρώτα και μετά μετακινήστε τη διαφάνεια σε αυτό.