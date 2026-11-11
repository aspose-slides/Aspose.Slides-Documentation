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
description: "Εξαγωγή διαφανειών PowerPoint ως εικόνες SVG σε JavaScript και έλεγχος γραμματοσειρών, κειμένου, εικόνων, αναγνωριστικών και συμβάντων με το Aspose.Slides."
---
## **Επισκόπηση**

SVG είναι μια ευέλικτη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, ροές προσβασιμότητας και αυτοματοποιημένη επεξεργασία μετά την εξαγωγή. Το Aspose.Slides for Node.js via Java εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και επιτρέπει τον έλεγχο του τρόπου με τον οποίο γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο μεταξύ των προγραμμάτων περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή με το [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

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

Το όνομα αρχείου χρησιμοποιεί το [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) αντί του δείκτη βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) ελέγχει τη σχεδίαση SVG. Για πλαίσια κειμένου, το [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) περιλαμβάνει το πλαίσιο κειμένου στη ζώνη απόδοσης, και το [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) σε `true` όταν το κείμενο πρέπει να αποδοθεί χωρίς συνδέσεις γραμμάτων.

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

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε αν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, και πώς ενσωματώνονται ή αναφέρονται οι εξωτερικές γραμματοσειρές. Οι ακόλουθες επιλογές σας βοηθούν να ισορροπήσετε τη οπτική συνέπεια, την επιλογή κειμένου και τις εξαρτήσεις γραμματοσειρών στο εξαγόμενο SVG.

### **Διανυσματοποίηση όλου του κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις από γραμματοσειρές και κάνει το οπτικό αποτέλεσμα πιο συνεπές μεταξύ των προγραμμάτων περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

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

### **Επιλογή τρόπου διαχείρισης εξωτερικών γραμματοσειρών**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να παραπέμπετε σε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να ενσωματώσετε δεδομένα γραμματοσειρών στο SVG, ή `Vectorize` για να αποδόσετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Ελέγξτε την άδεια χρήσης των γραμματοσειρών πριν τις ενσωματώσετε.

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

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) για να παραλείψετε περιοχές της πηγής που έχουν περικοπεί, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος τη πιστότητα της εικόνας ή τα διατηρημένα δεδομένα εικόνας.

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

## **Έλεγχος ανάλυσης rasterization μετααρχείου**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) ορίζει το κατώτερο όριο ανάλυσης για rasterization μετααρχείων κατά την εξαγωγή SVG. Χρησιμοποιήστε το για να ισορροπήσετε την λεπτομέρεια και το μέγεθος του αρχείου όταν μια εικόνα EMF ή WMF rasterizes. Δεν ορίζει ένα καθολικό DPI για το SVG ούτε αναγκάζει κάθε αντικείμενο στη διαφάνεια να μετατραπεί σε raster εικόνα.

Κατεβάστε το [metafile-rasterization.pptx](metafile-rasterization.pptx), που περιέχει μια εικόνα EMF με στενά τοποθετημένες διαγώνιες γραμμές. Το παρακάτω παράδειγμα εξάγει την πρώτη του διαφάνεια σε τρεις αναλύσεις rasterization μέσω του [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν ίδιες ώστε τα αποτελέσματα να συγκριθούν.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Στην έξοδο, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Οι παρακάτω μετρήσεις αφορούν την παρεχόμενη παρουσίαση· δεν είναι γενικός τύπος για τη μετατροπή DPI σε διαστάσεις pixel.

| Rasterization DPI μετααρχείου | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η σύγκριση παρακάτω δείχνει την ίδια περιοχή του ενσωματωμένου raster στην ίδια μεγεθυμένη προβολή. Οι διαγώνιες γραμμές εμφανίζουν εμφανή εικονοστοιχία στα 72 DPI και πιο ομαλές άκρες σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG μεγαλώνει. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή αλλάζει κάθε εξαγόμενη εικόνα.

![Μεγεθυμένη λεπτομέρεια διαγώνιας γραμμής στα 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) ελέγχει τη μείωση ανάλυσης εικόνας και μπορεί να καλύψει την επίδραση της αλλαγής της ανάλυσης rasterization του μετααρχείου. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση rasterization του μετααρχείου.

## **Ανάθεση σταθερών αναγνωριστικών σε σχήματα και κείμενο**

Πέρασμα ενός ελεγκτή μορφοποίησης στο [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) για να ορίσετε το [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) για κάθε σχήμα SVG. Ένας ελεγκτής που διαχειρίζεται επίσης κείμενα `tspan` μπορεί να ορίσει τιμές [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) στα στοιχεία κειμένου `tspan`.

Ο παρακάτω ελεγκτής χρησιμοποιεί το [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), το οποίο είναι σταθερό για τη διάρκεια ζωής του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα κείμενα του. Αυτό καθιστά τα παραγόμενα αναγνωριστικά κατάλληλα για επεξεργασία μετά από μια αμετάβλητη παρουσίαση.

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

Σε έναν ελεγκτή μορφοποίησης, καλέστε το [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) για να προσθέσετε έναν χειριστή συμβάντος JavaScript σε ένα εξαγόμενο σχήμα. Αναθέστε τον ελεγκτή με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) και ορίστε τη λειτουργία JavaScript στη σελίδα ή το έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

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

Η αρχική σελίδα μπορεί να ορίσει τη συνάρτηση JavaScript που αναφέρεται από τον χειριστή. Η ανάθεση αναγνωριστικών και χειριστών συμβάντων ενεργοποιεί προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **FAQ**

**Πότε πρέπει να χρησιμοποιήσω [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) αντί για [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να μειώσετε το μέγεθος ενός SVG;**

Ξεκινήστε συμπιέζοντας τις ενσωματωμένες εικόνες, διαγράφοντας τις περικομμένες περιοχές των εικόνων και επιλέγοντας συνδεδεμένα αρχεία γραμματοσειρών όταν το περιβάλλον-στόχος μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και η διανυσματοποίηση κειμένου έχουν διαφορετικές ανταλλαγές ποιότητας και μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε αναγνωριστικά μέσω ενός ελεγκτή μορφοποίησης, κατόπιν επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο επεξεργασίας ή στο script του προγράμματος περιήγησης.