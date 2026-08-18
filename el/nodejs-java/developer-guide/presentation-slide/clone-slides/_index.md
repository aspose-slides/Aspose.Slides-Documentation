---
title: Κλωνοποίηση διαφανειών παρουσίασης σε JavaScript
linktitle: Κλωνοποίηση διαφανειών
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
description: "Γρήγορα αντιγράψτε διαφάνειες PowerPoint με το Aspose.Slides για Node.js. Ακολουθήστε τα παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλείψετε την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ενός ακριβούς αντιγράφου ή αντίτυπου κάτι. Το Aspose.Slides for Node.js via Java επίσης καθιστά δυνατό το να δημιουργηθεί ένα αντίγραφο ή κλώνος οποιασδήποτε διαφάνειας και στη συνέχεια να εισαχθεί αυτή η κλωνοποιημένη διαφάνεια στην τρέχουσα ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν διάφοροι τρόποι κλωνοποίησης μιας διαφάνειας:

- Κλωνοποίηση στο τέλος εντός μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση εντός παρουσίασης.
- Κλωνοποίηση στο τέλος σε άλλη παρουσίαση.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for Node.js via Java, (μια συλλογή από αντικείμενα [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide)) που εκτίθενται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) και [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφάνειας.

## **Κλωνοποίηση στο Τέλος εντός μιας Παρουσίασης**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε εντός του ίδιου αρχείου παρουσίασης στο τέλος των υπαρχουσών διαφανειών, χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Δημιουργήστε ένα αντικείμενο της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) με αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Κλωνοποιεί τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Γράφει την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση σε άλλη θέση εντός παρουσίασης**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε εντός του ίδιου αρχείου παρουσίασης αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Δημιουργήστε ένα αντικείμενο της κλάσης αναφέροντας τη συλλογή [**Slides**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με τον δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στο δείκτη 1 – θέση 2 – της παρουσίασης) στο δείκτη 2 – θέση 3 – της παρουσίασης.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Κλωνοποιεί τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    var slds = pres.getSlides();
    // Κλωνοποιεί τη ζητούμενη διαφάνεια στο καθορισμένο δείκτη στην ίδια παρουσίαση
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Γράφει την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Κλωνοποίηση στο Τέλος σε άλλη Παρουσίαση**
Αν χρειαστεί να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υπαρχουσών διαφανειών:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection) με αναφορά στη συλλογή [**Slides**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Γράψτε το τροποποιημένο αρχείο προορισμού παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί την κλάση Presentation για να φορτώσει το αρχείο πηγαίας παρουσίασης
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Δημιουργεί την κλάση Presentation για την προοριστική PPTX (όπου η διαφάνεια θα κλωνοποιηθεί)
    var destPres = new aspose.slides.Presentation();
    try {
        // Κλωνοποιεί τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προοριστική παρουσίαση
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Γράφει την προοριστική παρουσίαση στο δίσκο
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

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) με αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με τη ζητούμενη θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Γράψτε το τροποποιημένο αρχείο προορισμού παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από το μηδενικό δείκτη της πηγαίας παρουσίασης) στο δείκτη 1 (θέση 2) της προοριστικής παρουσίασης.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί την κλάση Presentation για να φορτώσει το αρχείο πηγαίας παρουσίασης
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Δημιουργεί την κλάση Presentation για την προοριστική PPTX (όπου η διαφάνεια θα κλωνοποιηθεί)
    var destPres = new aspose.slides.Presentation();
    try {
        // Κλωνοποιεί τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προοριστική παρουσίαση
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Γράφει την προοριστική παρουσίαση στο δίσκο
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση**
Αν χρειαστεί να κλωνοποιήσετε μια διαφάνεια με κύρια διαφάνεια (master slide) από μια παρουσίαση και να την χρησιμοποιήσετε σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε τη ζητούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στην προοριστική παρουσίαση. Στη συνέχεια, χρησιμοποιήστε αυτή τη κύρια διαφάνεια για την κλωνοποίηση της διαφάνειας με κύρια διαφάνεια. Η μέθοδος [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) αναμένει μια κύρια διαφάνεια από την προοριστική παρουσίαση αντί από την πηγαία. Για να κλωνοποιήσετε τη διαφάνεια με κύρια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
1. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί μαζί με τη κύρια διαφάνεια.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [MasterSlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterSlideCollection) με αναφορά στη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [MasterSlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterSlideCollection) και περάστε την κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Δημιουργήστε ένα αντικείμενο της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) ορίζοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) και περάστε τη διαφάνεια από την πηγαία παρουσίαση για κλωνοποίηση και τη κύρια διαφάνεια ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides<ISlide-).
1. Γράψτε το τροποποιημένο αρχείο προορισμού παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια (που βρίσκεται στο μηδενικό δείκτη της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης χρησιμοποιώντας μια κύρια διαφάνεια από τη πηγαία διαφάνεια.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί την κλάση Presentation για να φορτώσει το αρχείο πηγαίας παρουσίασης
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Δημιουργεί την κλάση Presentation για την προοριστική παρουσίαση (όπου η διαφάνεια θα κλωνοποιηθεί)
    var destPres = new aspose.slides.Presentation();
    try {
        // Δημιουργεί το ISlide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
        // την κύρια διαφάνεια
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Κλωνοποιεί τη ζητούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στη συλλογή master στην
        // προοριστική παρουσίαση
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Κλωνοποιεί τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση με την επιθυμητή κύρια διαφάνεια στο τέλος της
        // συλλογής διαφανειών στην προοριστική παρουσίαση
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Αποθηκεύει την προοριστική παρουσίαση στο δίσκο
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Κλωνοποίηση στο Τέλος σε Καθορισμένο Τμήμα**
Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε εντός του ίδιου αρχείου παρουσίασης αλλά σε διαφορετικό τμήμα, τότε χρησιμοποιήστε τη [**addClone**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) μέθοδο που εκτίθεται από την κλάση [**SlideCollection**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection). Το Aspose.Slides for Node.js via Java καθιστά δυνατό το να κλωνοποιήσετε μια διαφάνεια από το πρώτο τμήμα και να την εισάγετε στο δεύτερο τμήμα της ίδιας παρουσίασης.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισάγετε την κλωνοποιημένη διαφάνεια σε ένα καθορισμένο τμήμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Αποθηκεύει την προοριστική παρουσίαση στο δίσκο
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Βεβαιώστε Συμφωνία Μεγέθους Διαφάνειας**

Όταν κλωνοποιείτε διαφάνειες σε άλλη παρουσίαση, βεβαιωθείτε ότι η προοριστική παρουσίαση έχει το ίδιο μέγεθος διαφάνειας με την πηγή. Εάν τα μεγέθη διαφάνειας διαφέρουν, το Aspose.Slides δεν κλιμακώνει αυτόματα τα κλωνοποιημένα σχήματα· οι αρχικές συντεταγμένες και διαστάσεις τους διατηρούνται, κάτι που μπορεί να προκαλέσει την εμφάνιση του περιεχομένου εκτός ευθυγράμμισης ή εκτός των ορίων της διαφάνειας.

Μπορείτε να ορίσετε το μέγεθος διαφάνειας της προοριστικής παρουσίασης ώστε να ταιριάζει με αυτό της πηγής πριν κλωνοποιήσετε τη κύρια διαφάνεια και τη διαφάνεια:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Κάντε αυτό πριν κλωνοποιήσετε τη κύρια διαφάνεια και τη διαφάνεια.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Αντιγράφονται οι σημειώσεις ομιλητή και τα σχόλια ελεγκτών;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια ελέγχου περιλαμβάνονται στον κλώνο. Αν δεν τα θέλετε, [αφαιρέσετε τα](/slides/el/nodejs-java/presentation-notes/) μετά την εισαγωγή.

**Πώς διαχειρίζονται τα γραφήματα και οι πηγές δεδομένων τους;**

Το αντικείμενο του γραφήματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Εάν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ., ένα ενσωματωμένο σε OLE φύλλο εργασίας), αυτή η σύνδεση διατηρείται ως [αντικείμενο OLE](/slides/el/nodejs-java/manage-ole/). Μετά τη μεταφορά μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ανανέωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για τον κλώνο;**

Ναι. Μπορείτε να εισαγάγετε τον κλώνο σε συγκεκριμένο δείκτη διαφάνειας και να τον τοποθετήσετε σε μια επιλεγμένη [section](/slides/el/nodejs-java/slide-section/). Εάν το επιθυμητό τμήμα δεν υπάρχει, δημιουργήστε το πρώτα και στη συνέχεια μετακινήστε τη διαφάνεια σε αυτό.