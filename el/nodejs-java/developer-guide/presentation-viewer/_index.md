---
title: Δημιουργία προβολέα παρουσίασης σε JavaScript
linktitle: Προβολέας Παρουσίασης
type: docs
weight: 50
url: /el/nodejs-java/presentation-viewer/
keywords: 
- προβολή παρουσίασης
- προβολέας παρουσίασης
- δημιουργία προβολέα παρουσίασης
- προβολή PPT
- προβολή PPTX
- προβολή ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε έναν προσαρμοσμένο προβολέα παρουσίασης σε JavaScript με Aspose.Slides για Node.js. Εύκολα εμφανίστε αρχεία PowerPoint και OpenDocument χωρίς το Microsoft PowerPoint."
---
## **Εισαγωγή**

Το Aspose.Slides για Node.js μέσω Java χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης με διαφάνειες. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τις παρουσιάσεις σε Microsoft PowerPoint, για παράδειγμα. Ωστόσο, μερικές φορές οι προγραμματιστές ενδέχεται να χρειάζονται να προβάλλουν τις διαφάνειες ως εικόνες στον προτιμώμενο προβολέα εικόνων ή να δημιουργήσουν τη δική τους προβολή παρουσίασης. Σε τέτοιες περιπτώσεις, το Aspose.Slides επιτρέπει την εξαγωγή μιας μεμονωμένης διαφάνειας ως εικόνα. Αυτό το άρθρο περιγράφει πώς να το κάνετε.

## **Δημιουργία εικόνας SVG από διαφάνεια**

Για να δημιουργήσετε μια εικόνα SVG από μια διαφάνεια παρουσίασης με το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε την αναφορά της διαφάνειας με βάση τον δείκτη της.
1. Ανοίξτε μια ροή αρχείου.
1. Αποθηκεύστε τη διαφάνεια ως εικόνα SVG στη ροή αρχείου.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Δημιουργία SVG με προσαρμοσμένο αναγνωριστικό σχήματος**

Το Aspose.Slides μπορεί να χρησιμοποιηθεί για τη δημιουργία ενός [SVG](https://docs.fileformat.com/page-description-language/svg/) από μια διαφάνεια με προσαρμοσμένο αναγνωριστικό σχήματος. Για να το κάνετε αυτό, χρησιμοποιήστε τη μέθοδο `setId` από το [SvgShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgshape/). Το `CustomSvgShapeFormattingController` μπορεί να χρησιμοποιηθεί για τον καθορισμό του αναγνωριστικού σχήματος.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **Δημιουργία εικόνας μικρογραφίας διαφάνειας**

Το Aspose.Slides σας βοηθά να δημιουργήσετε εικόνες μικρογραφίας διαφανειών. Για να δημιουργήσετε μια μικρογραφία διαφάνειας χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε την αναφορά της διαφάνειας με βάση τον δείκτη της.
1. Λάβετε την εικόνα μικρογραφίας της αναφερθείσας διαφάνειας σε ορισμένη κλίμακα.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Δημιουργία μικρογραφίας διαφάνειας με διαστάσεις ορισμένες από τον χρήστη**

Για να δημιουργήσετε μια εικόνα μικρογραφίας διαφάνειας με διαστάσεις ορισμένες από τον χρήστη, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε την αναφορά της διαφάνειας με βάση τον δείκτη της.
1. Λάβετε την εικόνα μικρογραφίας της αναφερθείσας διαφάνειας με τις καθορισμένες διαστάσεις.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Δημιουργία μικρογραφίας διαφάνειας με σημειώσεις ομιλητή**

Για να δημιουργήσετε τη μικρογραφία μιας διαφάνειας με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [RenderingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/).
1. Χρησιμοποιήστε τη μέθοδο `RenderingOptions.setSlidesLayoutOptions` για να ορίσετε τη θέση των σημειώσεων ομιλητή.
1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε την αναφορά της διαφάνειας με βάση τον δείκτη της.
1. Λάβετε την εικόνα μικρογραφίας της αναφερθείσας διαφάνειας με τις επιλογές απόδοσης.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Ζωντανό Παράδειγμα**

Μπορείτε να δοκιμάσετε την δωρεάν εφαρμογή [**Aspose.Slides Viewer**](https://products.aspose.app/slides/el/viewer/) για να δείτε τι μπορείτε να υλοποιήσετε με το API του Aspose.Slides:

![Online Προβολέας PowerPoint](online-PowerPoint-viewer.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να ενσωματώσω έναν προβολέα παρουσίασης σε μια web εφαρμογή Node.js;**

Ναι. Μπορείτε να χρησιμοποιήσετε το Aspose.Slides στην πλευρά του διακομιστή για να αποδίδετε διαφάνειες ως εικόνες ή HTML και να τις εμφανίζετε στον περιηγητή. Οι λειτουργίες πλοήγησης και ζουμ μπορούν να υλοποιηθούν με JavaScript για μια διαδραστική εμπειρία.

**Ποιος είναι ο καλύτερος τρόπος για να εμφανίσετε διαφάνειες μέσα σε έναν προσαρμοσμένο προβολέα;**

Η συνιστώμενη προσέγγιση είναι να αποδίδετε κάθε διαφάνεια ως εικόνα (π.χ., PNG ή SVG) ή να τη μετατρέπετε σε HTML χρησιμοποιώντας το Aspose.Slides, μετά να εμφανίζετε το αποτέλεσμα μέσα σε ένα πλαίσιο εικόνας (για επιτραπέζιες εφαρμογές) ή σε έναν HTML container (για το web).

**Πώς μπορώ να διαχειριστώ μεγάλες παρουσιάσεις με πολλές διαφάνειες;**

Για μεγάλες παρουσιάσεις, εξετάστε τη χρήση lazy-loading ή απόδοση κατά απαίτηση των διαφανειών. Αυτό σημαίνει ότι το περιεχόμενο μιας διαφάνειας δημιουργείται μόνο όταν ο χρήστης μεταβεί σε αυτήν, μειώνοντας τη μνήμη και τον χρόνο φόρτωσης.