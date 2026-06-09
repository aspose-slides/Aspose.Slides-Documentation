---
title: Διαχείριση Κύριων Διαφανειών Παρουσίασης σε JavaScript
linktitle: Κύριος Διαφάνειας
type: docs
weight: 70
url: /el/nodejs-java/slide-master/
keywords:
- κύριος διαφάνειας
- κύρια διαφάνεια
- κύρια διαφάνεια PPT
- πολλοί κύριοι διαφάνειες
- σύγκριση κυρίων διαφανειών
- φόντο
- τοποθετητής
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
description: "Διαχειριστείτε τους κύριους διαφάνειες στο Aspose.Slides για Node.js μέσω Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση κυρίων διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **κύριος διαφάνειας** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιλαμβάνει κοινά σχήματα, λογότυπα, φόντο, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός κύριου διαφάνειας είναι ο τυπικός τρόπος διατήρησης της συνοχής μιας παρουσίασης χωρίς την ανάγκη επανάληψης της ίδιας μορφοποίησης σε κάθε διαφάνεια.

Το Aspose.Slides for Node.js via Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει έναν ή περισσότερους κύριους διαφάνειες, και κάθε κύριος διαφάνειας μπορεί να περιέχει αρκετές διαφάνειες διάταξης. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται άμεσα σε έναν κύριο διαφάνειας. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διάταξης, η οποία ανήκει σε έναν κύριο διαφάνειας.

Η ιεραρχία είναι:

1. **Κύριος διαφάνειας** – ορίζει το κοινό σχέδιο και το θέμα.
1. **Διάταξη διαφάνειας** – ορίζει μια συγκεκριμένη διάταξη τοποθετητών και μορφοποιήσεων επιπέδου διάταξης.
1. **Κανονική διαφάνεια** – περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία διάταξη διαφάνειας.

![Η ιεραρχία των κύριων διαφανειών, διαφανειών διάταξης και κανονικών διαφανειών](slide-master_2.jpg)

Στο Aspose.Slides, ένας κύριος διαφάνειας αντιπροσωπεύεται από την κλάση [MasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/). Όλοι οι κύριοι διαφάνειες μιας παρουσίασης είναι διαθέσιμοι μέσω της συλλογής `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο κερδίζει. Για παράδειγμα, εάν ένας κύριος διαφάνειας και μια διαφάνεια διάταξης ορίζουν και οι δύο φόντο, οι διαφάνειες που βασίζονται σε αυτή τη διάταξη χρησιμοποιούν το φόντο της διάταξης. Για περισσότερες πληροφορίες σχετικά με τις διαφάνειες διάταξης, δείτε [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Πρόσβαση σε Κύριους Διαφάνειας**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Κύριου Διαφάνειας από **View** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `getMasters()` για πρόσβαση στους κύριους διαφάνειες:

```javascript
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

## **Τι Περιέχει ένας Κύριος Διαφάνειας**

Ένας κύριος διαφάνειας είναι ένα αντικείμενο παρόμοιο με διαφάνεια. Κληρονομεί τη γενική συμπεριφορά διαφάνειας από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/), επομένως εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από κανονικές και διαφάνειες διάταξης. Τα μέλη ειδικά για κύριους διαφάνειες αναφέρονται στη σελίδα API [MasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/).

Κάποια κοινά μέλη κύριου διαφάνειας περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `getBackground()` | Ορίζει το φόντο σε επίπεδο κύριου διαφάνειας. |
| `getShapes()` | Αποθηκεύει τα σχήματα που τοποθετούνται στον κύριο, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `getLayoutSlides()` | Αποθηκεύει τις διαφάνειες διάταξης που ανήκουν στον κύριο. |
| `getThemeManager()` | Παρέχει πρόσβαση στα API θέματος του κύριου. |
| `getHeaderFooterManager()` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για τον κύριο και τις θυγατρικές του διαφάνειες διάταξης. |
| `getDependingSlides()` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από τον κύριο μέσω των διαφανειών διάταξης. |

## **Προσθήκη Εικόνας σε Κύριο Διαφάνειας**

Όταν προσθέτετε μια εικόνα σε έναν κύριο διαφάνειας, εμφανίζεται στις διαφάνειες που χρησιμοποιούν διαφάνειες διάταξης από αυτόν τον κύριο. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη κύρια διαφάνεια:

```javascript
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

## **Εργασία με Τοποθετητές (Placeholders)**

Οι τοποθετητές ορίζονται συνήθως στις διαφάνειες διάταξης. Ο κύριος διαφάνειας παρέχει το κοινό στυλ και θέμα που κληρονομούν αυτές οι διαφάνειες, ενώ κάθε διάταξη αποφασίζει ποιοι τοποθετητές είναι διαθέσιμοι και πού τοποθετούνται.

Στο PowerPoint, οι εντολές τοποθετητών είναι διαθέσιμες στην προβολή Κύριου Διαφάνειας.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέους τοποθετητές με το Aspose.Slides, εργαστείτε με τη διαφάνεια διάταξης που ανήκει στον κύριο:

```javascript
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

Μπορείτε επίσης να μορφοποιήσετε σχήματα τοποθετητών που ήδη υπάρχουν σε έναν κύριο διαφάνειας. Το παρακάτω παράδειγμα εντοπίζει τον τοποθετητή τίτλου και εφαρμόζει μια γραμμική διαβάθμιση γεμίσματος:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Τίτλος τοποθετητή μορφοποιημένος και κληρονομωμένος από κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης τοποθετητών και κειμένου, δείτε [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) και [Text Formatting](/nodejs-java/text-formatting/).

## **Αλλαγή Φόντου Κύριου Διαφάνειας**

Ένα φόντο κύριου διαφάνειας κληρονομείται από τις διαφάνειες διάταξης και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα στερεό χρώμα φόντου για την πρώτη κύρια διαφάνεια:

```javascript
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

Χρησιμοποιήστε `MasterSlideCollection.addClone` για να αντιγράψετε έναν κύριο διαφάνειας σε άλλη παρουσίαση. Ο αντίγραφος κύριος μπορεί στη συνέχεια να χρησιμοποιηθεί από διαφάνειες διάταξης και κανονικές διαφάνειες στην προοριστική παρουσίαση.

```javascript
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

Εάν χρειάζεται να κλωνοποιήσετε κανονικές διαφάνειες μαζί με τον κύριο τους, δείτε [Clone Slides](/nodejs-java/clone-slides/).

## **Προσθήκη Πολλαπλών Κύριων Διαφάνειας**

Μια παρουσίαση μπορεί να περιέχει πολλαπλούς κύριους διαφάνειες. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετική επωνυμία, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για εισαγωγή και διαχείριση κύριων διαφανειών](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί τον προεπιλεγμένο κύριο, δίνει στον κλώνο διαφορετικό φόντο, δημιουργεί μια διάταξη κάτω από αυτόν τον κλώνο και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτή τη διάταξη:

```javascript
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

## **Σύγκριση Κύριων Διαφάνειας**

Οι κύριοι διαφάνειες μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από την κλάση [BaseSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινούμενα στοιχεία και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως IDs διαφανειών, ή δυναμικές τιμές τοποθετητών, όπως η τρέχουσα ημερομηνία.

```javascript
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

Για περισσότερες πληροφορίες, δείτε [Compare Presentation Slides](/nodejs-java/compare-slides/).

## **Ορισμός Προβολής Κύριου Διαφάνειας ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε τη μέθοδο `setLastView` στην κλάση [ViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει πρώτα το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση σε προβολή Κύριου Διαφάνειας:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Save Presentation](/nodejs-java/save-presentation/).

## **Αφαίρεση Αχρησιμοποίητων Κύριων Διαφάνειας**

Οι παρουσιάσεις μερικές φορές περιέχουν κύριους διαφάνειες που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση των αχρησιμοποίητων κυρίων μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε `removeUnused` για να αφαιρέσετε τους αχρησιμοποίητους κύριους από τη συλλογή `getMasters()`:

```javascript
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
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις (FAQ)**

**Ποια είναι η διαφορά μεταξύ κύριου διαφάνειας και διαφάνειας διάταξης;**

Ένας κύριος διαφάνειας ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Μια διαφάνεια διάταξης ανήκει σε έναν κύριο διαφάνειας και ορίζει μια συγκεκριμένη διάταξη τοποθετητών. Μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διάταξης, έτσι κληρονομεί τόσο από τη διάταξη όσο και από τον κύριο.

**Μπορεί μια παρουσίαση να περιέχει αρκετούς κύριους διαφάνειες;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλούς κύριους διαφάνειες. Χρησιμοποιήστε πολλαπλούς κύριους όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή επωνυμία.

**Πρέπει να προσθέσω τοποθετητές σε κύριο διαφάνειας ή σε διαφάνεια διάταξης;**

Στις περισσότερες περιπτώσεις, προσθέτετε τοποθετητές στις διαφάνειες διάταξης. Τοποθετήστε κοινά οπτικά στοιχεία και κοινή μορφοποίηση στον κύριο διαφάνειας, και έπειτα τοποθετήστε τους τοποθετητές περιεχομένου στις διαφάνειες διάταξης που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω έναν κύριο διαφάνειας που εξακολουθεί να χρησιμοποιείται;**

Όχι. Ένας κύριος διαφάνειας που έχει εξαρτώμενες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια απευθείας. Πρώτα μετακινήστε αυτές τις διαφάνειες σε διαφάνειες διάταξης υπό άλλο κύριο, ή χρησιμοποιήστε μια μέθοδο καθαρισμού αχρησιμοποίητων κυρίων που αφαιρεί μόνο τους κύριους που δεν χρησιμοποιούνται.