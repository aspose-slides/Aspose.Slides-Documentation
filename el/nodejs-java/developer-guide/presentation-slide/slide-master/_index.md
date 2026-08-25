---
title: Διαχείριση Κύριων Διαφανειών Παρουσίασης σε JavaScript
linktitle: Κύρια Διαφάνεια
type: docs
weight: 70
url: /el/nodejs-java/slide-master/
keywords:
- κύριος διαφάνειας
- κύρια διαφάνεια
- κύρια διαφάνεια PPT
- πολλαπλοί κύριοι διαφάνειας
- σύγκριση κυρίων διαφανειών
- φόντο
- σύμβολο κράτησης
- κλωνοποίηση κύριας διαφάνειας
- αντιγραφή κύριας διαφάνειας
- δημιουργία διπλότυπης κύριας διαφάνειας
- αχρησιμοποίητη κύρια διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τους κύριους διαφάνειες στο Aspose.Slides για Node.js μέσω Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση κυρίων διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **κύριος διαφάνειας** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιλαμβάνει κοινά σχήματα, λογότυπα, φόντα, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός κυρίου διαφάνειας είναι ο συνηθισμένος τρόπος για να διατηρείται μια παρουσίαση συνεπής χωρίς επανάληψη της ίδιας μορφοποίησης σε κάθε διαφάνεια.

Το Aspose.Slides for Node.js via Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει έναν ή περισσότερους κύριους διαφάνειας, και κάθε κύριος διαφάνειας μπορεί να περιέχει αρκετές διατάξεις διαφανειών. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται άμεσα σε κύριο διαφάνειας. Αντί αυτού, μια κανονική διαφάνεια χρησιμοποιεί μια διάταξη διαφάνειας, η οποία ανήκει σε ένα κύριο διαφάνειας.

Η ιεραρχία είναι:

1. **Κύριος διαφάνειας** – ορίζει το κοινό σχέδιο και το θέμα.
1. **Διάταξη διαφάνειας** – ορίζει μια συγκεκριμένη διάταξη στοιχείων κράτησης θέσης και μορφοποίησης επιπέδου διάταξης.
1. **Κανονική διαφάνεια** – περιέχει το πραγματικό περιεχόμενο παρουσίασης και χρησιμοποιεί μία διάταξη διαφάνειας.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Στο Aspose.Slides, ένας κύριος διαφάνειας αντιπροσωπεύεται από την κλάση [MasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/). Όλοι οι κύριοι διαφάνειας σε μια παρουσίαση είναι διαθέσιμοι μέσω της συλλογής `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο προτεραιοποιείται. Για παράδειγμα, εάν ένας κύριος διαφάνειας και μια διάταξη διαφάνειας ορίζουν και οι δύο φόντο, οι διαφάνειες που βασίζονται σε αυτήν τη διάταξη χρησιμοποιούν το φόντο της διάταξης. Για περισσότερες πληροφορίες σχετικά με τις διατάξεις διαφανειών, δείτε [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Πρόσβαση σε Κύριους Διαφάνειας**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Κύριου Διαφάνειας από **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `getMasters()` για να έχετε πρόσβαση στους κύριους διαφάνειας:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να λάβετε τον κύριο διαφάνειας που χρησιμοποιείται από μια κανονική διαφάνεια μέσω της διάταξής της:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Τι Περιέχει ένας Κύριος Διαφάνιας**

Ένας κύριος διαφάνιας είναι ένα αντικείμενο παρόμοιο με διαφάνεια. Κληρονομεί κοινή συμπεριφορά διαφάνειας από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/), έτσι εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από τις κανονικές και τις διατάξεις διαφανειών. Τα μέλη ειδικά για τον κύριο διαφάνειας καταγράφονται στη σελίδα API [MasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/).

Συχνά χρησιμοποιούμενα μέλη κυρίου διαφάνειας περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `getBackground()` | Ορίζει το φόντο του κυρίου επιπέδου διαφάνειας. |
| `getShapes()` | Αποθηκεύει σχήματα που τοποθετούνται στον κύριο, όπως λογότυπα, πλαίσια εικόνων και κοινό κείμενο. |
| `getLayoutSlides()` | Αποθηκεύει τις διατάξεις διαφανειών που ανήκουν στον κύριο. |
| `getThemeManager()` | Παρέχει πρόσβαση στα API θέματος του κυρίου. |
| `getHeaderFooterManager()` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για τον κύριο και τις θυγατρικές του διατάξεις. |
| `getDependingSlides()` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από τον κύριο μέσω των διατάξεών τους. |

## **Προσθήκη Εικόνας σε Κύριο Διαφάνειας**

Όταν προσθέτετε μια εικόνα σε ένα κύριο διαφάνειας, εμφανίζεται στις διαφάνειες που χρησιμοποιούν διατάξεις από αυτόν τον κύριο. Αυτό είναι χρήσιμο για λογότυπα, υδατικά στίγματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη κύρια διαφάνειας:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνων, δείτε [Picture Frame](/nodejs-java/picture-frame/).

## **Εργασία με Συμπληρωματικά Πεδία**

Τα συμπληρωματικά πεδία ορίζονται συνήθως στις διατάξεις διαφανειών. Ο κύριος διαφάνειας παρέχει το κοινό στυλ και το θέμα που κληρονομούν αυτές οι διατάξεις, ενώ κάθε διάταξη αποφασίζει ποια συμπληρωματικά πεδία είναι διαθέσιμα και πού τοποθετούνται.

Στο PowerPoint, οι εντολές συμπληρωματικών πεδίων είναι διαθέσιμες στην προβολή Κύριου Διαφάνειας.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Για να προσθέσετε νέα συμπληρωματικά πεδία με το Aspose.Slides, εργαστείτε με τη διάταξη διαφάνειας που ανήκει στον κύριο:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να μορφοποιήσετε σχήματα συμπληρωματικών πεδίων που ήδη υπάρχουν σε ένα κύριο διαφάνειας. Το παρακάτω παράδειγμα βρίσκει το συμπληρωματικό πεδίο τίτλου και εφαρμόζει ένα γραμμικό γεωμετρικό γέμισμα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης συμπληρωματικών πεδίων και κειμένου, δείτε [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) και [Text Formatting](/nodejs-java/text-formatting/).

## **Αλλαγή Φόντου Κύριου Διαφάνειας**

Ένα φόντο κυρίου κληρονομείται από τις διατάξεις και τις διαφάνειες που δεν το υπερισχύουν. Το παρακάτω παράδειγμα θέτει ένα στερεό χρώμα φόντου για την πρώτη κύρια διαφάνειας:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για συναφή θέματα, δείτε [Presentation Background](/nodejs-java/presentation-background/) και [Presentation Theme](/nodejs-java/presentation-theme/).

## **Κλωνοποίηση Κύριου Διαφάνειας σε Άλλη Παρουσίαση**

Χρησιμοποιήστε `MasterSlideCollection.addClone` για να αντιγράψετε έναν κύριο διαφάνειας σε άλλη παρουσίαση. Ο αντιγραμμένος κύριος μπορεί στη συνέχεια να χρησιμοποιηθεί από διατάξεις και διαφάνειες στην προορισμένη παρουσίαση.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Αν χρειάζεστε κλωνοποίηση κανονικών διαφανειών μαζί με τον κύριό τους, δείτε [Clone Slides](/nodejs-java/clone-slides/).

## **Προσθήκη Πολλαπλών Κυρίων Διαφάνειας**

Μια παρουσίαση μπορεί να περιέχει πολλαπλούς κύριους διαφάνειας. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετικό branding, δομή σελίδας ή ρυθμίσεις θέματος.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί τον προεπιλεγμένο κύριο, δίνει στο κλώνο διαφορετικό φόντο, δημιουργεί μια διάταξη κάτω από αυτόν τον κλώνο και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτήν τη διάταξη:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Σύγκριση Κυρίων Διαφάνειας**

Οι κύριοι διαφάνειες μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινήσεις και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως τα IDs διαφανειών, ή δυναμικές τιμές συμπληρωματικών πεδίων, όπως η τρέχουσα ημερομηνία.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Για περισσότερες πληροφορίες, δείτε [Compare Presentation Slides](/slides/el/nodejs-java/compare-slides/).

## **Ορισμός Προβολής Κύριου Διαφάνειας ως Προεπιλεγμένης Προβολής**

Χρησιμοποιήστε τη μέθοδο `setLastView` στην κλάση [ViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει το PowerPoint πρώτα. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση στην προβολή Κύριου Διαφάνειας:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Save Presentation](/slides/el/nodejs-java/save-presentation/).

## **Αφαίρεση Μη Χρησιμοποιούμενων Κυρίων Διαφάνειας**

Μερικές φορές οι παρουσιάσεις περιέχουν κύριους διαφάνειας που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση των μη χρησιμοποιούμενων κυριών μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε το `removeUnused` για να αφαιρέσετε τους μη χρησιμοποιούμενους κύριους από τη συλλογή `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο low-code `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Ποια είναι η διαφορά μεταξύ κύριου διαφάνειας και διάταξης διαφάνειας;

Ένας κύριος διαφάνειας ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Μια διάταξη διαφάνειας ανήκει σε έναν κύριο διαφάνειας και ορίζει μια συγκεκριμένη διάταξη στοιχείων κράτησης θέσης. Μια κανονική διαφάνεια χρησιμοποιεί μια διάταξη, οπότε κληρονομεί τόσο από τη διάταξη όσο και από τον κύριο.

### Μπορεί μια παρουσίαση να περιέχει πολλούς κύριους διαφάνειας;

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλούς κύριους διαφάνειας. Χρησιμοποιήστε πολλαπλούς κυρίους όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή branding.

### Πρέπει να προσθέσω συμπληρωματικά πεδία σε κύριο διαφάνειας ή σε διάταξη διαφάνειας;

Στις περισσότερες περιπτώσεις, προσθέτετε συμπληρωματικά πεδία στις διατάξεις. Τοποθετήστε τα κοινά οπτικά στοιχεία και τη κοινή μορφοποίηση στον κύριο διαφάνειας, και τοποθετήστε τα πεδία περιεχομένου στις διατάξεις που θα χρησιμοποιούν οι κανονικές διαφάνειες.

### Μπορώ να διαγράψω έναν κύριο διαφάνειας που εξακολουθεί να χρησιμοποιείται;

Όχι. Ένας κύριος διαφάνειας που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί ασφαλώς απευθείας. Πρώτα μετακινήστε αυτές τις διαφάνειες σε διατάξεις υπό άλλο κύριο, ή χρησιμοποιήστε μια μέθοδο καθαρισμού μη χρησιμοποιούμενων κυρίων που αφαιρεί μόνο τους κυρίους που δεν είναι σε χρήση.