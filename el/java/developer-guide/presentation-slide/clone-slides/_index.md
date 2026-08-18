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
description: "Αντιγράψτε γρήγορα διαφάνειες PowerPoint με το Aspose.Slides για Java. Ακολουθήστε τα σαφή παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλείψετε τη χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντιδιπλώματος κάτι­τι. Το Aspose.Slides for Java επιτρέπει επίσης το να δημιουργηθεί αντίγραφο ή κλώνος οποιασδήποτε διαφάνειας και, στη συνέχεια, να εισαχθεί η κλωνοποιημένη διαφάνεια στην τρέχουσα ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν αρκετοί πιθανοί τρόποι κλωνοποίησης διαφάνειας:

- Κλωνοποίηση στο τέλος εντός μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση εντός παρουσίασης.
- Κλωνοποίηση στο τέλος σε άλλη παρουσίαση.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση μαζί με τη κύρια διαφάνειά της σε άλλη παρουσίαση.

Στο Aspose.Slides for Java, (μια συλλογή αντικειμένων [ISlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide)) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) και [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφάνειας.

## **Κλωνοποίηση διαφάνειας στο τέλος μιας παρουσίασης**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση στο τέλος των υπαρχουσών διαφανειών, χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ακολουθώντας τα παρακάτω βήματα:

1. Δημιουργήστε μια διεργασία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Δημιουργήστε μια διεργασία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Καλείστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Αποθηκεύστε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```java
import com.aspose.slides.*;

// Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση εντός μιας παρουσίασης**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Δημιουργήστε μια διεργασία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Δημιουργήστε τη διεργασία της κλάσης αναφέροντας τη συλλογή [**Slides**](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Καλείστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με τον δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στον δείκτη 1 – θέση 2 – της παρουσίασης) στον δείκτη 2 – θέση 3 – της παρουσίασης.

```java
import com.aspose.slides.*;

// Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Λάβετε τη συλλογή διαφανειών στην παρουσίαση
    ISlideCollection slds = pres.getSlides();

    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στην καθορισμένη θέση στην ίδια παρουσίαση
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας στο τέλος άλλης παρουσίασης**
Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υπαρχουσών διαφανειών:

1. Δημιουργήστε μια διεργασία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια διεργασία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε τη διεργασία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection) αναφέροντας τη συλλογή [**Slides**](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλείστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Αποθηκεύστε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης.

```java
import com.aspose.slides.*;

// Δημιουργήστε αντικείμενο της κλάσης Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Δημιουργήστε αντικείμενο της κλάσης Presentation για την προοριστική PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Κλωνοποιήστε τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Αποθηκεύστε την προοριστική παρουσίαση στο δίσκο
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

1. Δημιουργήστε μια διεργασία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση.
1. Δημιουργήστε μια διεργασία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε τη διεργασία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλείστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με την επιθυμητή θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
1. Αποθηκεύστε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον δείκτη μηδέν της πηγαίας παρουσίασης) στον δείκτη 1 (θέση 2) της προοριστικής παρουσίασης.

```java
import com.aspose.slides.*;

// Δημιουργήστε αντικείμενο της κλάσης Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Δημιουργήστε αντικείμενο της κλάσης Presentation για την προοριστική PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Κλωνοποιήστε τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση στην καθορισμένη θέση στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Αποθηκεύστε την προοριστική παρουσίαση στο δίσκο
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας με τη κύρια διαφάνειά της σε άλλη παρουσίαση**
Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια μαζί με την κύρια διαφάνειά της από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε την επιθυμητή κύρια διαφάνεια από την πηγαία παρουσίαση στην προοριστική. Στη συνέχεια, χρησιμοποιείτε αυτήν την κύρια διαφάνεια για την κλωνοποίηση της διαφάνειας με κύρια. Η μέθοδος [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) απαιτεί μια κύρια διαφάνεια από την προοριστική παρουσίαση και όχι από την πηγαία. Για να κλωνοποιήσετε τη διαφάνεια με κύρια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια διεργασία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση.
1. Δημιουργήστε μια διεργασία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση.
1. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί μαζί με τη κύρια διαφάνειά της.
1. Δημιουργήστε τη διεργασία της κλάσης [IMasterSlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IMasterSlideCollection) αναφέροντας τη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) της προοριστικής παρουσίασης.
1. Καλείστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [IMasterSlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IMasterSlideCollection) και περάστε τη κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Δημιουργήστε τη διεργασία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) ορίζοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) της προοριστικής παρουσίασης.
1. Καλείστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση που θα κλωνοποιηθεί και την κύρια διαφάνεια ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Αποθηκεύστε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια (που βρίσκεται στον δείκτη μηδέν της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης χρησιμοποιώντας κύρια από την πηγαία διαφάνεια.

```java
import com.aspose.slides.*;

// Δημιουργήστε αντικείμενο της κλάσης Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Δημιουργήστε αντικείμενο της κλάσης Presentation για την προοριστική παρουσίαση (όπου θα κλωνοποιηθεί η διαφάνεια)
    Presentation destPres = new Presentation();
    try {
        // Δημιουργήστε αντικείμενο ISlide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
        // τη κύρια διαφάνεια
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Κλωνοποιήστε τη ζητούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στη συλλογή των κυρίων διαφανειών στην
        // προοριστική παρουσίαση
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Κλωνοποιήστε τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση με τη ζητούμενη κύρια διαφάνεια στο τέλος της
        // συλλογής διαφανειών στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // Αποθηκεύστε την προοριστική παρουσίαση στο δίσκο
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση διαφάνειας στο τέλος καθορισμένου τμήματος**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στην ίδια παρουσίαση αλλά σε διαφορετικό τμήμα, χρησιμοποιήστε τη [**addClone**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) μέθοδο που εκτίθεται από το interface [**ISlideCollection**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlideCollection). Το Aspose.Slides for Java επιτρέπει την κλωνοποίηση μιας διαφάνειας από το πρώτο τμήμα και την εισαγωγή της κλωνοποιημένης διαφάνειας στο δεύτερο τμήμα της ίδιας παρουσίασης.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να την εισάγετε σε καθορισμένο τμήμα.

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

## **Διασφάλιση ταύτιου μεγέθους διαφάνειας**

Κατά την κλωνοποίηση διαφανειών σε άλλη παρουσίαση, βεβαιωθείτε ότι η προοριστική παρουσίαση έχει το ίδιο μέγεθος διαφάνειας με την πηγαία. Εάν τα μεγέθη διαφανειών διαφέρουν, το Aspose.Slides δεν επανακλιμακώνει αυτόματα τα κλωνοποιημένα σχήματα· συντηρούνται οι αρχικές τους συντεταγμένες και διαστάσεις, γεγονός που μπορεί να οδηγήσει σε λανθασμένη ευθυγράμμιση ή έξω από τα όρια της διαφάνειας.

Μπορείτε να ορίσετε το μέγεθος διαφάνειας της προοριστικής παρουσίασης ώστε να ταιριάζει με την πηγαία πριν την κλωνοποίηση της κύριας διαφάνειας και της διαφάνειας:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Κάντε αυτό πριν την κλωνοποίηση της κύριας διαφάνειας και της διαφάνειας.

## **Συχνές ερωτήσεις**

**Κλωνοποιούνται οι σημειώσεις ομιλητή και τα σχόλια αξιολογητών;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια αξιολόγησης περιλαμβάνονται στον κλώνο. Αν δεν τα θέλετε, [remove them](/slides/el/java/presentation-notes/) μετά την εισαγωγή.

**Πώς αντιμετωπίζονται τα διαγράμματα και οι πηγές δεδομένων τους;**

Το αντικείμενο διαγράμματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Αν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ. ένα ενσωματωμένο OLE-προγράμμα εργασίας), η σύνδεση διατηρείται ως [OLE object](/slides/el/java/manage-ole/). Μετά τη μεταφορά μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ενημέρωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για τον κλώνο;**

Ναι. Μπορείτε να εισάγετε τον κλώνο σε συγκεκριμένο δείκτη διαφάνειας και να τον τοποθετήσετε σε επιλεγμένο [section](/slides/el/java/slide-section/). Αν το τμήμα προορισμού δεν υπάρχει, δημιουργήστε το πρώτα και μετά μετακινήστε τη διαφάνεια σε αυτό.