---
title: Κλωνοποίηση διαφανειών παρουσίασης σε Android
linktitle: Κλωνοποίηση διαφανειών
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
description: "Διπλασιάστε διαφάνειες PowerPoint με το Aspose.Slides για Android. Ακολουθήστε τα σαφή παραδείγματα κώδικα Java μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλείψετε την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Το κλώνησμα είναι η διαδικασία δημιουργίας ενός ακριβούς αντιγράφου ή αντίγραφου κάτι. Το Aspose.Slides for Android μέσω Java καθιστά επίσης δυνατόν να γίνει ένα αντίγραφο ή κλώνος οποιασδήποτε διαφάνειας και κατόπιν να εισαχθεί αυτή η κλωνοποιημένη διαφάνεια στην τρέχουσα ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από τους προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν διάφοροι πιθανοί τρόποι κλωνοποίησης μιας διαφάνειας:

- Κλωνοποίηση στο τέλος εντός μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση εντός της παρουσίασης.
- Κλωνοποίηση στο τέλος σε άλλη παρουσίαση.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for Android μέσω Java, (μια συλλογή από αντικείμενα [ISlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlide)) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) και [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφάνειας

## **Κλωνοποίηση διαφάνειας στο τέλος μιας παρουσίασης**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και μετά να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης στο τέλος των υφιστάμενων διαφανειών, χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Δημιουργήστε ένα αντικείμενο της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Κλωνοποίηση της επιθυμητής διαφάνειας στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Αποθήκευση της τροποποιημένης παρουσίασης στον δίσκο
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση εντός μιας παρουσίασης**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Δημιουργήστε το αντικείμενο αναφέροντας τη συλλογή [**Slides**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με τον δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στον δείκτη μηδέν – θέση 1 – της παρουσίασης) στο δείκτη 1 – θέση 2 – της παρουσίασης.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Κλωνοποίηση της επιθυμητής διαφάνειας στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.getSlides();

    // Κλωνοποίηση της επιθυμητής διαφάνειας στον καθορισμένο δείκτη στην ίδια παρουσίαση
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Αποθήκευση της τροποποιημένης παρουσίασης στον δίσκο
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας στο τέλος μιας άλλης παρουσίασης**
Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υφιστάμενων διαφανειών:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την προορισματική παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection) αναφέροντας τη συλλογή [**Slides**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο Presentation της προορισματικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Γράψτε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προορισματικής παρουσίασης.

```java
// Δημιουργία αντικειμένου Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Δημιουργία αντικειμένου Presentation για την προορισμένη PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Κλωνοποίηση της επιθυμητής διαφάνειας από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Αποθήκευση της προορισμένης παρουσίασης στον δίσκο
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση σε άλλη παρουσίαση**
Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, σε συγκεκριμένη θέση:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο Presentation της προορισματικής παρουσίασης.
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με την επιθυμητή θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
1. Γράψτε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον δείκτη μηδέν της πηγαίας παρουσίασης) στο δείκτη 1 (θέση 2) της προορισματικής παρουσίασης.

```java
// Δημιουργία αντικειμένου Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Δημιουργία αντικειμένου Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Κλωνοποίηση της επιθυμητής διαφάνειας από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Αποθήκευση της προορισμένης παρουσίασης στον δίσκο
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε συγκεκριμένη θέση σε άλλη παρουσίαση**
Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια με κύρια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε τη ζητούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στην προορισματική. Στη συνέχεια πρέπει να χρησιμοποιήσετε αυτή τη κύρια διαφάνεια για την κλωνοποίηση διαφάνειας με κύρια διαφάνεια. Η μέθοδος [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) αναμένει μια κύρια διαφάνεια από την προορισματική παρουσίαση και όχι από την πηγαία. Για να κλωνοποιήσετε τη διαφάνεια με κύρια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει την προορισματική παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
1. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί μαζί με τη κύρια διαφάνεια.
1. Δημιουργήστε το αντικείμενο [IMasterSlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IMasterSlideCollection) αναφέροντας τη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) της προορισματικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) που εκτίθεται από το αντικείμενο [IMasterSlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IMasterSlideCollection) και περάστε τη κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Δημιουργήστε το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) ορίζοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) της προορισματικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με τη κύρια διαφάνεια ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Γράψτε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια διαφάνεια (που βρίσκεται στον δείκτη μηδέν της πηγαίας παρουσίασης) στο τέλος της προορισματικής παρουσίασης χρησιμοποιώντας μια κύρια διαφάνεια από τη διαφάνεια προέλευσης.

```java
// Δημιουργία αντικειμένου Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Δημιουργία αντικειμένου Presentation για την προορισμένη παρουσίαση (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Δημιουργία ISlide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
        // κύρια διαφάνεια
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Κλωνοποίηση της επιθυμητής κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κύριων διαφανειών στην
        // προορισμένη παρουσίαση
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Κλωνοποίηση της επιθυμητής κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κύριων διαφανειών στην
        // προορισμένη παρουσίαση
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Κλωνοποίηση της επιθυμητής διαφάνειας από την πηγαία παρουσίαση με την επιθυμητή κύρια διαφάνεια στο τέλος της
        // συλλογής διαφανειών στην προορισμένη παρουσίαση
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Αποθήκευση της προορισμένης παρουσίασης στον δίσκο
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας στο τέλος μιας καθορισμένης ενότητας**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση αλλά σε διαφορετική ενότητα, χρησιμοποιήστε τη [**addClone**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) μέθοδο που εκτίθεται από το interface [**ISlideCollection**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlideCollection). Το Aspose.Slides for Android μέσω Java επιτρέπει την κλωνοποίηση μιας διαφάνειας από την πρώτη ενότητα και την εισαγωγή της κλωνοποιημένης διαφάνειας στη δεύτερη ενότητα της ίδιας παρουσίασης.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να την εισάγετε σε μια καθορισμένη ενότητα.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Αποθήκευση της προορισμένης παρουσίασης στον δίσκο
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Κλωνοποιούνται οι σημειώσεις ομιλητή και οι σχόλια ελεγκτή;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια ελέγχου περιλαμβάνονται στην κλώνο. Εάν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/androidjava/presentation-notes/) μετά την εισαγωγή.

**Πώς αντιμετωπίζονται τα διαγράμματα και οι πηγές δεδομένων τους;**

Το αντικείμενο του διαγράμματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Εάν το διάγραμμα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ., ένα ενσωματωμένο OLE βιβλίο εργασίας), αυτή η σύνδεση διατηρείται ως [OLE αντικείμενο](/slides/el/androidjava/manage-ole/). Μετά τη μετακίνηση μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη λειτουργία ανανέωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τις ενότητες για την κλώνο;**

Ναι. Μπορείτε να εισάγετε την κλώνο σε συγκεκριμένο δείκτη διαφάνειας και να την τοποθετήσετε σε μια επιλεγμένη [ενότητα](/slides/el/androidjava/slide-section/). Εάν η επιλεγμένη ενότητα δεν υπάρχει, δημιουργήστε την πρώτα και στη συνέχεια μετακινήστε τη διαφάνεια σε αυτήν.