---
title: Μετατροπή διαφανειών παρουσίασης σε εικόνες σε JavaScript
linktitle: Διαφάνεια σε εικόνα
type: docs
weight: 35
url: /el/nodejs-java/convert-slide/
keywords:
- μετατροπή διαφάνειας
- εξαγωγή διαφάνειας
- διαφάνεια σε εικόνα
- αποθήκευση διαφάνειας ως εικόνα
- διαφάνεια σε EMF
- διαφάνεια σε PNG
- διαφάνεια σε JPEG
- διαφάνεια σε bitmap
- διαφάνεια σε TIFF
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες από παρουσιάσεις PPT, PPTX και ODP σε PNG, JPEG, GIF, TIFF, EMF και άλλες μορφές εικόνας σε JavaScript με το Aspose.Slides."
---
## **Εισαγωγή**

Το Aspose.Slides for Node.js μέσω Java μπορεί να αποδώσει μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument ως PNG, JPEG, GIF, TIFF και άλλες μορφές εικόνας.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .
2. Επιλέξτε τη διαφάνεια που θέλετε να αποδώσετε.
3. Εάν χρειάζεται, ρυθμίστε την απόδοση με την κλάση [RenderingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/) .
4. Καλέστε τη μέθοδο [Slide.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getImage) . Επιστρέφει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) .
5. Καλέστε τη μέθοδο [IImage.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/#save) και καθορίστε τη μορφή εξόδου με μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imageformat/) .

## **Μετατροπή μιας διαφάνειας σε εικόνα PNG**

Η πιο απλή μετατροπή χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις απόδοσης. Το παραγόμενο αντικείμενο [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) μπορεί να υποβληθεί σε επεξεργασία στη μνήμη ή να αποθηκευτεί σε αρχείο.

Το παρακάτω παράδειγμα JavaScript αποδίδει την πρώτη διαφάνεια και την αποθηκεύει ως εικόνα PNG:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή διαφανειών σε εικόνες με προσαρμοσμένα μεγέθη**

Χρησιμοποιήστε την υπερφόρτωση [Slide.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getImage) που δέχεται μια τιμή `java.awt.Dimension` για να αποδώσετε μια διαφάνεια με ακριβείς διαστάσεις εικονοστοιχείων.

Το παρακάτω παράδειγμα δημιουργεί μια εικόνα JPEG 1820 × 1040:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή διαφανειών με σημειώσεις και σχόλια σε εικόνες**

Από προεπιλογή, οι εικόνες των διαφανειών δεν περιλαμβάνουν σημειώσεις ή σχόλια. Πέραστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notescommentslayoutingoptions/) στη μέθοδο [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) για να ελέγξετε πού εμφανίζονται οι σημειώσεις και τα σχόλια.

Το παρακάτω παράδειγμα τοποθετεί περικομμένες σημειώσεις κάτω από τη διαφάνεια και σχόλια δεξιά της:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Για τη μετατροπή διαφάνειας-σε-εικόνα, μην περάσετε το [BottomFull](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notespositions/) στη μέθοδο [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) . Οι σημειώσεις μπορεί να περιέχουν περισσότερο κείμενο από ό,τι μπορεί να φιλοξενήσει το σταθερό μέγεθος εικόνας. Χρησιμοποιήστε το [BottomTruncated](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notespositions/) αντί αυτού.
{{% /alert %}}

## **Μετατροπή διαφανειών σε εικόνες χρησιμοποιώντας επιλογές TIFF**

Η κλάση [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/) σας επιτρέπει να ελέγξετε το μέγεθος, την ανάλυση και άλλες ιδιότητες της αποδιδόμενης εικόνας TIFF.

Το παρακάτω παράδειγμα αποδίδει την πρώτη διαφάνεια ως εικόνα TIFF 2160 × 2880 σε 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Η υποστήριξη TIFF δεν είναι εγγυημένη σε εκδόσεις Java παλαιότερες από το JDK 9.
{{% /alert %}}

## **Μετατροπή όλων των διαφανειών σε εικόνες**

Διασχίστε τη συλλογή διαφανειών για να μετατρέψετε ολόκληρη την παρουσίαση σε σειρά εικόνων. Οι κρυμμένες διαφάνειες περιλαμβάνονται εκτός αν τις παραβλέψετε ρητά.

Το παρακάτω παράδειγμα αποδίδει κάθε διαφάνεια ως εικόνα JPEG με οριζόντιους και κάθετους συντελεστές κλίμακας 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Δημιουργία εξόδου Enhanced Metafile**

Το Enhanced Metafile (EMF) είναι χρήσιμο όταν χρειάζεται η ανταλλαγή διανυσματικών γραφικών με το Microsoft Office ή άλλες εφαρμογές Windows που υποστηρίζουν Windows metafiles. Σε αντίθεση με μια εικόνα βασισμένη σε εικονοστοιχεία, ένα EMF μπορεί να διατηρήσει τις διανυσματικές λειτουργίες σχεδίασης που κλιμακώνται χωρίς την ίδια απώλεια ευκρίνειας. Ωστόσο, το EMF είναι κυρίως μια μορφή συμβατότητας για εφαρμογές με υποστήριξη Windows metafile, όχι μια καθολική μορφή ανταλλαγής. Επιπλέον, πολύπλοκο περιεχόμενο διαφάνειας, όπως εικόνες bitmap και ορισμένα εφέ, μπορεί να αποθηκευτεί ως ραστερικά στοιχεία μέσα στο διανυσματικό δοχείο metafile.

### **Εξαγωγή διαφάνειας σε EMF**

Η μέθοδος [Slide.writeAsEmf](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#writeAsEmf) γράφει μια διαφάνεια σε ρεύμα προορισμού σε μορφή EMF. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, επιλέγει την πρώτη διαφάνεια και την γράφει σε ρεύμα αρχείου EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Ο καλών καθορίζει την ιδιοκτησία του ρεύματος που περνιέται στο [Slide.writeAsEmf](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#writeAsEmf) και είναι υπεύθυνος για το κλείσιμο του, όπως φαίνεται παραπάνω.

### **Μετατροπή εικόνας SVG σε EMF και προσθήκη της σε παρουσίαση**

Χρησιμοποιήστε το [SvgImage.writeAsEmf](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/#writeAsEmf) για να μετατρέψετε το περιεχόμενο SVG σε EMF. Τα παραγόμενα bytes μπορούν να προστεθούν στην παρουσίαση μέσω του [ImageCollection.addImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagecollection/#addImage) και να τοποθετηθούν σε μια διαφάνεια με το [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

Το παρακάτω παράδειγμα δημιουργεί ένα [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/) από markup SVG, το μετατρέπει σε EMF εντός μνήμης, εισάγει το metafile στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το [SvgImage.writeAsEmf](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/#writeAsEmf) δεν αναλαμβάνει την ιδιοκτησία του ρεύματος προορισμού. Ένα `java.io.ByteArrayOutputStream` αποθηκεύει όλα τα παραγόμενα δεδομένα στη μνήμη, έτσι δεν απαιτείται επαναφορά θέσης πριν κληθεί το `toByteArray`. Ο επιστρεφόμενος πίνακας byte παραμένει έγκυρος μετά το κλείσιμο του ρεύματος.

Η δημιουργία EMF είναι διαθέσιμη στα λειτουργικά συστήματα που υποστηρίζονται από την επιλεγμένη διανομή Aspose.Slides for Node.js via Java και τη ρύθμιση JDK, αλλά η απόδοση μπορεί να διαφέρει μεταξύ πλατφορμών όταν λείπουν γραμματοσειρές ή εξαρτήσεις γραφικών. Εγκαταστήστε τις γραμματοσειρές που χρησιμοποιούνται από το πηγαίο περιεχόμενο ή ρυθμίστε κατάλληλες υποκαταστάσεις, ακολουθήστε τις [απαιτήσεις πλατφόρμας](/slides/el/nodejs-java/system-requirements/) για το Aspose.Slides for Node.js via Java, και ελέγξτε το αποτέλεσμα στην εφαρμογή‑πλήκτη EMF. Οι εφαρμογές Linux και macOS συχνά διαθέτουν περιορισμένη ή ασυνεπή υποστήριξη για την προβολή και επεξεργασία Windows metafiles.

## **Απόδοση χρωματικών Emoji**

{{% alert title="Note" color="info" %}}
Για την σωστή απόδοση χρωματικών emoji όταν μετατρέπονται διαφάνειες παρουσίασης σε εικόνες, οι γραμματοσειρές emoji που χρησιμοποιούνται στην παρουσίαση πρέπει να είναι εγκατεστημένες και διαθέσιμες στο σύστημα που εκτελεί τη μετατροπή. Για παράδειγμα, εάν η παρουσίαση χρησιμοποιεί **Segoe UI Emoji** και αυτή η γραμματοσειρά λείπει, τα emoji μπορεί να εμφανίζονται σε μονόχρωμο στις έξοδους εικόνες.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζει το Aspose.Slides την απόδοση διαφανειών με κίνηση;**

Όχι. Η μέθοδος [Slide.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getImage) αποδίδει μια στατική εικόνα της διαφάνειας και δεν εξάγει τις κινήσεις.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι. Οι κρυμμένες διαφάνειες μπορούν να αποδοθούν όπως οι κανονικές διαφάνειες. Συμπεριλάβετε τις στον βρόχο επεξεργασίας, όπως φαίνεται στο παραπάνω παράδειγμα.

**Διατηρούνται οι σκιές και άλλα εφέ στις εικόνες των διαφανειών;**

Ναι. Το Aspose.Slides αποδίδει σκιές, διαφάσεις και άλλα υποστηριζόμενα γραφικά εφέ στις εικόνες των διαφάνειών.