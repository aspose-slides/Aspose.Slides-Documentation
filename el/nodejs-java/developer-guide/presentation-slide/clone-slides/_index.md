---
title: Κλωνοποίηση Διαφανειών Παρουσίασης σε JavaScript
linktitle: Κλωνοποίηση Διαφανειών
type: docs
weight: 35
url: /el/nodejs-java/clone-slides/
keywords:
- κλωνοποίηση διαφάνειας
- αντιγραφή διαφάνειας
- αποθήκευση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε γρήγορα αντίγραφα διαφανειών PowerPoint με το Aspose.Slides για Node.js. Ακολουθήστε τα παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλείψετε την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντιδείγματος κάτι. Το Aspose.Slides για Node.js μέσω Java επιτρέπει επίσης τη δημιουργία αντιγράφου ή κλώνου οποιασδήποτε διαφάνειας και στη συνέχεια την εισαγωγή αυτής της κλωνοποιημένης διαφάνειας στην τρέχουσα ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν αρκετοί πιθανοί τρόποι κλωνοποίησης μιας διαφάνειας:

- Κλωνοποίηση στο τέλος μέσα σε μια παρουσίαση.
- Κλωνοποίηση σε άλλη θέση μέσα σε μια παρουσίαση.
- Κλωνοποίηση στο τέλος σε άλλη παρουσίαση.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides για Node.js μέσω Java, (μια συλλογή αντικειμένων [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide) ) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) και [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφάνειας

## **Κλωνοποίηση στο τέλος μέσα σε μια παρουσίαση**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης στο τέλος των υφιστάμενων διαφανειών, χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Δημιουργήστε ένα αντικείμενο της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) αναφερόμενοι στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```javascript
// Αρχικοποίηση της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Κλωνοποίηση της επιλεγμένης διαφάνειας στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Γράψτε την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση σε άλλη θέση μέσα στην παρουσίαση**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Δημιουργήστε ένα αντικείμενο της κλάσης αναφερόμενοι στη συλλογή **Slides** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με το δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στον δείκτη μηδέν – θέση 1 – της παρουσίασης) στη θέση 1 – Θέση 2 – της παρουσίασης.

```javascript
// Αρχικοποίηση της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Κλωνοποίηση της επιλεγμένης διαφάνειας στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    var slds = pres.getSlides();
    // Κλωνοποίηση της επιλεγμένης διαφάνειας στο καθορισμένο δείκτη στην ίδια παρουσίαση
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Γράψτε την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση στο τέλος σε άλλη παρουσίαση**
Αν χρειαστεί να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υφιστάμενων διαφανειών:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection) αναφερόμενοι στη συλλογή **Slides** που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης.

```javascript
// Αρχικοποίηση της κλάσης Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Αρχικοποίηση της κλάσης Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    var destPres = new aspose.slides.Presentation();
    try {
        // Κλωνοποίηση της επιλεγμένης διαφάνειας από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Γράψτε την προορισμένη παρουσίαση στο δίσκο
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση**
Αν χρειαστεί να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, σε συγκεκριμένη θέση:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) αναφερόμενοι στη συλλογή Slides που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με τη ζητούμενη θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον δείκτη μηδέν της πηγαίας παρουσίασης) στη θέση 1 (θέση 2) της προοριστικής παρουσίασης.

```javascript
// Αρχικοποίηση της κλάσης Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Αρχικοποίηση της κλάσης Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    var destPres = new aspose.slides.Presentation();
    try {
        // Κλωνοποίηση της επιλεγμένης διαφάνειας από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Γράψτε την προορισμένη παρουσίαση στο δίσκο
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση**
Αν χρειαστεί να κλωνοποιήσετε μια διαφάνεια με κύρια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε την επιθυμητή κύρια διαφάνεια από την πηγαία παρουσίαση στην προοριστική παρουσίαση. Στη συνέχεια, πρέπει να χρησιμοποιήσετε αυτήν τη κύρια διαφάνεια για την κλωνοποίηση της διαφάνειας με κύρια διαφάνεια. Η [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) αναμένει μια κύρια διαφάνεια από την προοριστική παρουσίαση αντί από την πηγαία παρουσίαση. Για να κλωνοποιήσετε τη διαφάνεια με κύρια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
1. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί μαζί με την κύρια διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [MasterSlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterSlideCollection) αναφερόμενοι στη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [MasterSlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterSlideCollection) και περάστε την κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Δημιουργήστε ένα αντικείμενο της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) ορίζοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση που θα κλωνοποιηθεί μαζί με την κύρια διαφάνεια ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια (που βρίσκεται στον δείκτη μηδέν της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης χρησιμοποιώντας κύρια από τη διαφάνεια προέλευσης.

```javascript
// Αρχικοποίηση της κλάσης Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Αρχικοποίηση της κλάσης Presentation για την προορισμένη παρουσίαση (όπου θα κλωνοποιηθεί η διαφάνεια)
    var destPres = new aspose.slides.Presentation();
    try {
        // Αρχικοποίηση του ISlide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
        // Κύρια διαφάνεια
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Κλωνοποίηση της επιλεγμένης κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κυρίων στην
        // Προορισμένη παρουσίαση
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Κλωνοποίηση της επιλεγμένης κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κυρίων στην
        // Προορισμένη παρουσίαση
        var iSlide = masters.addClone(SourceMaster);
        // Κλωνοποίηση της επιλεγμένης διαφάνειας από την πηγαία παρουσίαση με την επιλεγμένη κύρια στο τέλος της
        // Συλλογής διαφανειών στην προορισμένη παρουσίαση
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Αποθήκευση της προορισμένης παρουσίασης στο δίσκο
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση στο τέλος σε καθορισμένο τμήμα**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε στην ίδια παρουσίαση αλλά σε διαφορετικό τμήμα, χρησιμοποιήστε τη [**addClone**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) μέθοδο που εκτίθεται από την κλάση [**SlideCollection**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection). Το Aspose.Slides για Node.js μέσω Java επιτρέπει την κλωνοποίηση μιας διαφάνειας από το πρώτο τμήμα και την εισαγωγή της κλωνοποιημένης διαφάνειας στο δεύτερο τμήμα της ίδιας παρουσίασης.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισαγάγετε τη κλωνοποιημένη διαφάνεια σε ένα καθορισμένο τμήμα.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Αποθήκευση της προορισμένης παρουσίασης στο δίσκο
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Κλώνονται οι σημειώσεις ομιλητή και τα σχόλια ελεγκτών;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια ελέγχου συμπεριλαμβάνονται στην κλώνο. Αν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/nodejs-java/presentation-notes/) μετά την εισαγωγή.

**Πώς αντιμετωπίζονται τα διαγράμματα και οι πηγές δεδομένων τους;**

Το αντικείμενο διαγράμματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Αν το διάγραμμα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ. ένα ενσωματωμένο OLE‑μενού), η σύνδεση διατηρείται ως [OLE object](/slides/el/nodejs-java/manage-ole/). Μετά τη μετακίνηση μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ανανέωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για το κλώνο;**

Ναι. Μπορείτε να εισαγάγετε το κλώνο σε συγκεκριμένο δείκτη διαφάνειας και να το τοποθετήσετε σε επιλεγμένο [section](/slides/el/nodejs-java/slide-section/). Αν το τμήμα-στόχος δεν υπάρχει, δημιουργήστε το πρώτα και μετά μετακινήστε τη διαφάνεια σε αυτό.