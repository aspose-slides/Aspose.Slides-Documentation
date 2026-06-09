---
title: Κλωνοποίηση διαφανειών παρουσίασης σε Java
linktitle: Κλωνοποίηση Διαφανειών
type: docs
weight: 35
url: /el/java/clone-slides/
keywords:
- κλωνοποίηση διαφάνειας
- αντιγραφή διαφάνειας
- αποθήκευση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Γρήγορα αντιγράψτε διαφάνειες PowerPoint με το Aspose.Slides για Java. Ακολουθήστε τα σαφή παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλειφθεί η χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή απομιμήσεως κάτι. Το Aspose.Slides for Java επιτρέπει επίσης τη δημιουργία αντιγράφου ή κλώνου οποιασδήποτε διαφάνειας και στη συνέχεια την εισαγωγή αυτής της κλωνοποιημένης διαφάνειας στην τρέχουσα ή σε οποιαδήποτε άλλη ανοιγμένη παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν πολλές πιθανές μέθοδοι κλωνοποίησης διαφάνειας:

- Κλωνοποίηση στο τέλος εντός μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση εντός της παρουσίασης.
- Κλωνοποίηση στο τέλος σε άλλη παρουσίαση.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for Java, (μια συλλογή αντικειμένων [ISlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide)) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) και [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφάνειας.

## **Κλωνοποίηση διαφάνειας στο τέλος μιας παρουσίασης**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης στο τέλος των υφιστάμενων διαφανειών, χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) κάνοντας αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
3. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
4. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```java
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Αποθηκεύστε την τροποποιημένη παρουσίαση στον δίσκο
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση εντός μιας παρουσίασης**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Δημιουργήστε μια παρουσία της κλάσης κάνοντας αναφορά στη συλλογή [**Slides**](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
3. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με τον δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
4. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στον δείκτη μηδέν – θέση 1 – της παρουσίασης) στον δείκτη 1 – Θέση 2 – της παρουσίασης.

```java
// Δημιουργήστε αντικείμενο Presentation που αντιπροσωπεύει αρχείο παρουσίασης
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.getSlides();

    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στον καθορισμένο δείκτη στην ίδια παρουσίαση
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Αποθηκεύστε την τροποποιημένη παρουσίαση στον δίσκο
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας στο τέλος άλλης παρουσίασης**
Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υφιστάμενων διαφανειών:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
2. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
3. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection) κάνοντας αναφορά στη συλλογή [**Slides**](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
4. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
5. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης.

```java
// Δημιουργήστε αντικείμενο Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Δημιουργήστε αντικείμενο Presentation για την προοριστική PPTX (όπου η διαφάνεια θα κλωνοποιηθεί)
    Presentation destPres = new Presentation();
    try {
        // Κλωνοποιήστε τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Αποθηκεύστε την προοριστική παρουσίαση στον δίσκο
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση σε άλλη παρουσίαση**
Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, σε συγκεκριμένη θέση:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
2. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
3. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) κάνοντας αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
4. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με τη ζητούμενη θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
5. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον δείκτη μηδέν της πηγαίας παρουσίασης) στον δείκτη 1 (θέση 2) της προοριστικής παρουσίασης.

```java
// Δημιουργήστε αντικείμενο Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Δημιουργήστε αντικείμενο Presentation για την προοριστική PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Κλωνοποιήστε τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Αποθηκεύστε την προοριστική παρουσίαση στον δίσκο
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε συγκεκριμένη θέση σε άλλη παρουσίαση**
Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια με κύρια διαφάνεια (master slide) από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε τη ζητούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στην προοριστική παρουσίαση. Στη συνέχεια, χρησιμοποιήστε αυτή τη κύρια διαφάνεια για την κλωνοποίηση της διαφάνειας με κύρια διαφάνεια. Η μέθοδος [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) αναμένει μια κύρια διαφάνεια από την προοριστική παρουσίαση και όχι από την πηγαία. Για να κλωνοποιήσετε τη διαφάνεια με κύρια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
2. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
3. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί μαζί με την κύρια διαφάνεια.
4. Δημιουργήστε μια παρουσία της κλάσης [IMasterSlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IMasterSlideCollection) κάνοντας αναφορά στη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) της προοριστικής παρουσίασης.
5. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [IMasterSlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IMasterSlideCollection) και περάστε τη κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
6. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) ορίζοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) της προοριστικής παρουσίασης.
7. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση προς κλωνοποίηση και τη κύρια διαφάνεια ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
8. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια διαφάνεια (που βρίσκεται στον δείκτη μηδέν της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης χρησιμοποιώντας μια κύρια διαφάνεια από τη διαφάνεια πηγής.

```java
// Δημιουργήστε αντικείμενο Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Δημιουργήστε αντικείμενο Presentation για την προοριστική παρουσίαση (όπου η διαφάνεια θα κλωνοποιηθεί)
    Presentation destPres = new Presentation();
    try {
        // Δημιουργήστε ISlide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
        // Κύρια διαφάνεια
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Κλωνοποιήστε τη ζητούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στη συλλογή των κύριων διαφανειών στην
        // Προοριστική παρουσίαση
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Κλωνοποιήστε τη ζητούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στη συλλογή των κύριων διαφανειών στην
        // Προοριστική παρουσίαση
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Κλωνοποιήστε τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση με την επιθυμητή κύρια διαφάνεια στο τέλος της
        // Συλλογής διαφανειών στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Αποθηκεύστε την προοριστική παρουσίαση στον δίσκο
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας στο τέλος καθορισμένου τμήματος**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετικό τμήμα, χρησιμοποιήστε τη [**addClone**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) μέθοδο που εκτίθεται από τη διεπαφή [**ISlideCollection**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection). Το Aspose.Slides for Java επιτρέπει την κλωνοποίηση μιας διαφάνειας από το πρώτο τμήμα και την εισαγωγή της κλωνοποιημένης διαφάνειας στο δεύτερο τμήμα της ίδιας παρουσίασης.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να την εισάγετε σε καθορισμένο τμήμα.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Αποθηκεύστε την προοριστική παρουσίαση στον δίσκο
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Κλωνοποιούνται οι σημειώσεις ομιλητή και τα σχόλια του ελεγκτή;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια ελέγχου περιλαμβάνονται στην κλωνοποίηση. Αν δεν τα θέλετε, [remove them](/slides/el/java/presentation-notes/) μετά την εισαγωγή.

**Πώς γίνεται η διαχείριση των γραφημάτων και των πηγών δεδομένων τους;**

Το αντικείμενο γραφήματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Αν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ. ένα ενσωματωμένο OLE‑workbook), η σύνδεση διατηρείται ως [OLE object](/slides/el/java/manage-ole/). Μετά τη μεταφορά μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ανανέωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για την κλωνοποίηση;**

Ναι. Μπορείτε να εισάγετε την κλωνοποιημένη διαφάνεια σε συγκεκριμένο δείκτη διαφάνειας και να τη τοποθετήσετε σε επιλεγμένο [section](/slides/el/java/slide-section/). Αν το στόχο τμήμα δεν υπάρχει, δημιουργήστε το πρώτα και μετά μετακινήστε τη διαφάνεια σε αυτό.