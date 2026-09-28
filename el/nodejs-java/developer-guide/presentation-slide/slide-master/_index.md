---
title: Διαχείριση κύριων διαφανειών παρουσίασης σε JavaScript
linktitle: Κύρια Διαφάνεια
type: docs
weight: 70
url: /el/nodejs-java/slide-master/
keywords:
- κύρια διαφάνεια
- κύρια διαφάνεια
- κύρια διαφάνεια PPT
- πολλαπλές κύριες διαφάνειες
- σύγκριση κυρίων διαφανειών
- φόντο
- θέση κράτησης
- κλωνοποίηση κύριας διαφάνειας
- αντιγραφή κύριας διαφάνειας
- διπλασιασμός κύριας διαφάνειας
- αχρησιμοποίητη κύρια διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχείριση κυρίων διαφανειών στο Aspose.Slides για Node.js μέσω Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση κυρίων διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **κύριος διαφάνειας** (slide master) ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, φόντα, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός κύριου διαφάνειας είναι ο συνηθισμένος τρόπος να διατηρηθεί μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides for Node.js via Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες κύριες διαφάνειες, και κάθε κύρια διαφάνεια μπορεί να περιέχει αρκετές διαφάνειες διαρρύθμισης (layout slides). Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται απευθείας σε μια κύρια διαφάνεια. Αντ' αυτού, μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διαρρύθμισης, η οποία ανήκει σε μια κύρια διαφάνεια.

Η ιεραρχία είναι:

1. **Κύρια διαφάνεια** – ορίζει το κοινό σχέδιο και το θέμα.  
1. **Διαφάνεια διαρρύθμισης** – ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης και μορφοποίησης επιπέδου διαρρύθμισης.  
1. **Κανονική διαφάνεια** – περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία διαφάνεια διαρρύθμισης.

![Η ιεραρχία των κύριων διαφανειών, διαφανειών διαρρύθμισης και κανονικών διαφανειών](slide-master_2.jpg)

Στο Aspose.Slides, μια κύρια διαφάνεια αντιπροσωπεύεται από την κλάση [MasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/). Όλες οι κύριες διαφάνειες σε μια παρουσίαση είναι διαθέσιμες μέσω της συλλογής `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο κερδίζει. Για παράδειγμα, εάν μια κύρια διαφάνεια και μια διαφάνεια διαρρύθμισης ορίζουν και τις δύο ένα φόντο, οι διαφάνειες που βασίζονται σε εκείνη τη διαρρύθμιση χρησιμοποιούν το φόντο της διαρρύθμισης. Για περισσότερες πληροφορίες σχετικά με τις διαφάνειες διαρρύθμισης, δείτε [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Πρόσβαση σε κύριες διαφάνειες**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Κύριας Διαφάνειας από **View** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `getMasters()` για πρόσβαση στις κύριες διαφάνειες:

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

Μπορείτε επίσης να λάβετε τη κύρια διαφάνεια που χρησιμοποιείται από μια κανονική διαφάνεια μέσω της διαρρύθμισής της:

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

## **Τι περιέχει μια κύρια διαφάνεια**

Μια κύρια διαφάνεια είναι ένα αντικείμενο παρόμοιο με διαφάνεια. Κληρονομεί κοινή συμπεριφορά διαφάνειας από το [BaseSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/), επομένως εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από τις κανονικές και τις διαφάνειες διαρρύθμισης. Τα μέλη ειδικά για κύριες διαφάνειες παρατίθενται στη σελίδα API του [MasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/).

Συνηθισμένα μέλη κύριας διαφάνειας περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `getBackground()` | Ορίζει το φόντο διαφάνειας επιπέδου κύριας. |
| `getShapes()` | Αποθηκεύει σχήματα τοποθετημένα στην κύρια, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `getLayoutSlides()` | Αποθηκεύει τις διαφάνειες διαρρύθμισης που ανήκουν στην κύρια. |
| `getThemeManager()` | Παρέχει πρόσβαση στα API θέματος της κύριας. |
| `getHeaderFooterManager()` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για την κύρια και τις θυγατρικές της διαρρυθμίσεις. |
| `getDependingSlides()` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από την κύρια μέσω των διαρρυθμίσεων τους. |

## **Προσθήκη εικόνας σε κύρια διαφάνεια**

Όταν προσθέτετε μια εικόνα σε μια κύρια διαφάνεια, αυτή εμφανίζεται στις διαφάνειες που χρησιμοποιούν διαρρυθμίσεις από αυτήν την κύρια. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη κύρια διαφάνεια:

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

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε [Picture Frame](/nodejs-java/picture-frame/).

## **Έλεγχος ορατότητας των γραφικών της κύριας διαφάνειας**

Χρησιμοποιήστε το [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) για να κρύψετε κληρονομημένα γραφικά της κύριας, όπως λογότυπα ή διακοσμητικά σχήματα, χωρίς να τα διαγράψετε από την κύρια. Περάστε `false` στο [Slide.setShowMasterShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#setShowMasterShapes) στη διαφάνεια που πρέπει να παραλείψει αυτά τα γραφικά και κρατήστε το `true` στις διαφάνειες που πρέπει να τα εμφανίσει.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια μπλε διακοσμητική λωρίδα σε μια κύρια και δύο διαφάνειες που χρησιμοποιούν την ίδια κενή διαρρύθμιση. Η λωρίδα είναι ορατή στην πρώτη διαφάνεια και κρυμμένη στη δεύτερη. Δεν απαιτείται είσοδος παρουσίασης ή εικόνα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το παράδειγμα χρησιμοποιεί τη διαρρύθμιση **Blank** που παρέχεται με μια νέα παρουσίαση και αφαιρεί τις αρχικές θέσεις κράτησης της πρώτης διαφάνειας.

### **Επιλογή πεδίου εφαρμογής της ρύθμισης**

Μια κανονική διαφάνεια χρησιμοποιεί την κύρια της μέσω του [Slide.getLayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getLayoutSlide) και του [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Η ρύθμιση της ιδιότητας σε μια μεμονωμένη διαφάνεια επηρεάζει μόνο εκείνη τη διαφάνεια. Περάστε `false` στο [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) για να κρύψετε τα γραφικά της κύριας για τις διαφάνειες που χρησιμοποιούν εκείνη τη κοινή διαρρύθμιση, ακόμη και αν η δική τους ρύθμιση είναι `true`. Για να κρύψετε τα γραφικά μόνο σε μία διαφάνεια, αλλάξτε την ιδιότητα της διαφάνειας και αφήστε τη διαρρύθμιση αμετάβλητη.

Η ρύθμιση δεν υποστηρίζεται ως έλεγχος ορατότητας στην ίδια την κύρια διαφάνεια. Σε μια κύρια, το [getShowMasterShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) επιστρέφει πάντα `false`, και η περάτωση `true` στο [setShowMasterShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) προκαλεί εξαίρεση. Εφαρμόστε το σε μια κανονική διαφάνεια ή σε μια διαρρύθμιση.

### **Διαχωρισμός γραφικών από το φόντο**

| Ενέργεια | Αποτέλεσμα |
| --- | --- |
| Απόκρυψη γραφικών της κύριας | Ελέγχει την ορατότητα των κληρονομημένων σχημάτων της κύριας χωρίς διαγραφή ή αλλαγή των δικών της σχημάτων. |
| Αλλαγή του γεμίσματος φόντου της διαφάνειας | Αλλάζει το χρώμα, το gradient ή την εικόνα του φόντου. Τα γραφικά της κύριας είναι ξεχωριστά σχήματα και μπορούν να παραμείνουν ορατά πάνω από αυτό το φόντο. Δείτε το [Presentation Background](/slides/el/nodejs-java/presentation-background/). |
| Διαγραφή σχήματος από την κύρια | Αφαιρεί το κοινό σχήμα προέλευσης, ώστε να μην είναι διαθέσιμο σε καμία διαφάνεια που χρησιμοποιεί εκείνη την κύρια. |

## **Εργασία με θέσεις κράτησης (placeholders)**

Οι θέσεις κράτησης ορίζονται συνήθως σε διαφάνειες διαρρύθμισης. Η κύρια διαφάνεια παρέχει το κοινό στυλ και το θέμα που κληρονομούν αυτές οι διαρρυθμίσεις, ενώ κάθε διαρρύθμιση αποφασίζει ποιες θέσεις κράτησης είναι διαθέσιμες και πού τοποθετούνται.

Στο PowerPoint, οι εντολές θέσεων κράτησης είναι διαθέσιμες στην προβολή Κύριας Διαφάνειας.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέες θέσεις κράτησης με το Aspose.Slides, εργαστείτε με τη διαφάνεια διαρρύθμισης που ανήκει στην κύρια:

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

Μπορείτε επίσης να μορφοποιήσετε σχήματα θέσεων κράτησης που ήδη υπάρχουν σε μια κύρια διαφάνεια. Το παρακάτω παράδειγμα εντοπίζει τη θέση κράτησης τίτλου και εφαρμόζει μια γραμμική κλίση:

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

![Μορφοποιημένη θέση κράτησης τίτλου κληρονομική από κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης θέσεων κράτησης και κειμένου, δείτε [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) και [Text Formatting](/nodejs-java/text-formatting/).

## **Αλλαγή φόντου κύριας διαφάνειας**

Ένα φόντο κύριας κληρονομείται από τις διαρρυθμίσεις και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα συμπαγές χρώμα φόντου για την πρώτη κύρια διαφάνεια:

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

## **Αντιγραφή (κλωνοποίηση) κύριας διαφάνειας σε άλλη παρουσίαση**

Χρησιμοποιήστε το `MasterSlideCollection.addClone` για να αντιγράψετε μια κύρια διαφάνεια σε άλλη παρουσίαση. Η αντιγραμμένη κύρια μπορεί στη συνέχεια να χρησιμοποιηθεί από διαρρυθμίσεις και διαφάνειες στην προοριστική παρουσίαση.

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

Εάν χρειάζεστε κλωνοποίηση κανονικών διαφανειών μαζί με την κύρια τους, δείτε [Clone Slides](/nodejs-java/clone-slides/).

## **Προσθήκη πολλαπλών κυρίων διαφανειών**

Μια παρουσίαση μπορεί να περιέχει πολλαπλές κύριες διαφάνειες. Αυτό είναι χρήσιμο όταν διαφορετικά τμήματα απαιτούν διαφορετικό branding, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για προσθήκη και διαχείριση κυρίων διαφανειών](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί την προεπιλεγμένη κύρια, δίνει στο κλώνο διαφορετικό φόντο, δημιουργεί μια διαρρύθμιση κάτω από αυτήν την κλωνοποιημένη κύρια και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτήν τη διαρρύθμιση:

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

## **Σύγκριση κυρίων διαφανειών**

Οι κύριες διαφάνειες μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από το [BaseSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινήσεις και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως IDs διαφανειών, ή δυναμικές τιμές θέσεων κράτησης, όπως η τρέχουσα ημερομηνία.

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

## **Ορισμός προβολής κύριας διαφάνειας ως προεπιλεγμένη προβολή**

Χρησιμοποιήστε τη μέθοδο `setLastView` στο [ViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει πρώτο το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση σε προβολή Κύριας Διαφάνειας:

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

## **Αφαίρεση αχρησιμοποίητων κυρίων διαφανειών**

Μερικές φορές οι παρουσιάσεις περιέχουν κύριες διαφάνειες που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση των αχρησιμοποίητων κυρίων μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε το `removeUnused` για να αφαιρέσετε αχρησιμοποίητες κύριες από τη συλλογή `getMasters()`:

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

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο low‑code `Compress.removeUnusedMasterSlides`:

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

## **Συχνές ερωτήσεις (FAQ)**

**Ποια είναι η διαφορά μεταξύ κύριας διαφάνειας και διαφάνειας διαρρύθμισης;**

Μια κύρια διαφάνεια ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Μια διαφάνεια διαρρύθμισης ανήκει σε μια κύρια διαφάνεια και ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης. Μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διαρρύθμισης, οπότε κληρονομεί τόσο από τη διαρρύθμιση όσο και από την κύρια.

**Μπορεί μια παρουσίαση να περιέχει πολλές κύριες διαφάνειες;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλές κύριες διαφάνειες. Χρησιμοποιήστε πολλαπλές κύριες όταν διαφορετικά τμήματα χρειάζονται διαφορετικά οπτικά συστήματα ή branding.

**Πρέπει να προσθέσω θέσεις κράτησης σε κύρια διαφάνεια ή σε διαφάνεια διαρρύθμισης;**

Στις περισσότερες περιπτώσεις, προσθέτετε θέσεις κράτησης σε διαφάνειες διαρρύθμισης. Τοποθετήστε τα κοινά οπτικά στοιχεία και την κοινή μορφοποίηση στην κύρια διαφάνεια, στη συνέχεια τοποθετήστε τις θέσεις κράτησης περιεχομένου στις διαρρυθμίσεις που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω μια κύρια διαφάνεια που χρησιμοποιείται ακόμη;**

Όχι. Μια κύρια διαφάνεια που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια. Πρώτα μετακινήστε αυτές τις διαφάνειες σε διαρρυθμίσεις κάτω από άλλη κύρια, ή χρησιμοποιήστε μια μέθοδο εκκαθάρισης αχρησιμοποίητων κυρίων που αφαιρεί μόνο τις κύριες που δεν είναι σε χρήση.