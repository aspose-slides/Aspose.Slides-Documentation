---
title: Απόδοση διαφανειών παρουσίασης ως εικόνες SVG σε JavaScript
linktitle: Διαφάνεια σε SVG
type: docs
weight: 50
url: /el/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint σε SVG
- παρουσίαση σε SVG
- διαφάνεια σε SVG
- PPT σε SVG
- PPTX σε SVG
- επιλογές εξαγωγής SVG
- διαδραστικό SVG
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξάγετε διαφάνειες PowerPoint ως εικόνες SVG σε JavaScript και ελέγξτε τις γραμματοσειρές, το κείμενο, τις εικόνες, τα αναγνωριστικά και τα συμβάντα με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι ένα κλιμακούμενο μορφότυπο εικόνας βασισμένο σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, ροές εργασίας προσβασιμότητας και αυτοματοποιημένη μεταεπεξεργασία. Το Aspose.Slides for Node.js μέσω Java εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σάς επιτρέπει να ελέγχετε πώς γράφεται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή με το [Slide.writeAsSvg](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/writeassvg/). Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Το όνομα αρχείου χρησιμοποιεί το [Slide.getSlideNumber](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/getslidenumber/) αντί του δείκτη βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [Shape.writeAsSvg](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/writeassvg/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζονται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setuseframesize/) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) σε `true` όταν το κείμενο πρέπει να αποδοθεί χωρίς λιγότερα.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Έλεγχος κειμένου και γραμματοσειρών**

### **Διάνυσμα Όλων του Κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) σε `true` για να γράφετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις από γραμματοσειρές και κάνει το οπτικό αποτέλεσμα πιο συνεπές μεταξύ των browsers, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Επιλογή του τρόπου διαχείρισης εξωτερικών γραμματοσειρών**

Το [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να παραπέμπετε σε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να συμπεριλάβετε τα δεδομένα της γραμματοσειράς στο SVG, ή `Vectorize` για να αποδίδετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε τις άδειες χρήσης γραμματοσειρών πριν τις ενσωματώσετε.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Μείωση μεγέθους ενσωματωμένων εικόνων**

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) για να παραλείψετε τις περικομμένες περιοχές προέλευσης, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setjpegquality/) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος στην πιστότητα της εικόνας ή στα διατηρημένα δεδομένα της εικόνας.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Ανάθεση σταθερών αναγνωριστικών σε σχήματα και κείμενο**

Περάστε έναν ελεγκτή μορφοποίησης στο [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) για να ορίσετε το [SvgShape.setId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgshape/setid/) για κάθε σχήμα SVG. Ένας ελεγκτής που διαχειρίζεται επίσης τα τμήματα κειμένου μπορεί να ορίσει τιμές στο [SvgTSpan.setId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgtspan/setid/) για τα στοιχεία `tspan` του κειμένου.

Ο παρακάτω ελεγκτής χρησιμοποιεί το [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), το οποίο είναι σταθερό για τη διάρκεια ζωής του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα τμήματα κειμένου του. Αυτό καθιστά τα παραγόμενα αναγνωριστικά κατάλληλα για μεταεπεξεργασία μιας αμετάβλητης παρουσίασης.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Προσθήκη χειριστών συμβάντων SVG**

Σε έναν ελεγκτή μορφοποίησης, καλέστε το [SvgShape.setEventHandler](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgshape/seteventhandler/) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgevent/) για να προσθέσετε έναν χειριστή JavaScript σε ένα εξαγόμενο σχήμα. Αναθέστε τον ελεγκτή με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) και ορίστε τη λειτουργία JavaScript στη σελίδα ή στο έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

Η σελίδα φιλοξενίας μπορεί να ορίσει τη λειτουργία JavaScript στην οποία αναφέρεται ο χειριστής. Η ανάθεση αναγνωριστικών και χειριστών συμβάντων ενεργοποιεί προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **FAQ**

**Πότε πρέπει να χρησιμοποιήσω το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) αντί του [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να γίνει ένα SVG μικρότερο;**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή των περικομμένων περιοχών εικόνας και την επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το περιβάλλον στόχου μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, γιατί η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το κειμένο σε διανύσματα έχουν διαφορετικές ανταλλαγές ποιότητας‑μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Ανάθεση αναγνωριστικών μέσω ελεγκτή μορφοποίησης, στη συνέχεια επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μεταεπεξεργασίας ή στο σενάριο του προγράμματος περιήγησης.