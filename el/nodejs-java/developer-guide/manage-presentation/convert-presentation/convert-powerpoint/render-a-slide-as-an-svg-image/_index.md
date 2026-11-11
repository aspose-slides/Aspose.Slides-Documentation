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
description: "Εξαγωγή διαφανειών PowerPoint ως εικόνες SVG σε JavaScript και έλεγχος γραμματοσειρών, κειμένου, εικόνων, IDs και γεγονότων με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια επεκτάσιμη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, ροές εργασίας προσβασιμότητας και αυτοματοποιημένη μετά-επεξεργασία. Το Aspose.Slides for Node.js via Java εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) όταν το εξαχθέν SVG πρέπει να είναι συμπαγές, προβλέψιμο μεταξύ των προγραμμάτων περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ρεύμα με το [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

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

Το όνομα αρχείου χρησιμοποιεί το [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) αντί για τον δείκτη του βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο εκείνο το σχήμα.

## **Διαμόρφωση εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) καθορίζει εάν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) σε `true` όταν το κείμενο πρέπει να αποδοθεί χωρίς λιγκάτρες.

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

## **Έλεγχος περικοπής άκρων γραμμών στα βελάκια**

Το SVG 1.1 δεν διαθέτει ρύθμιση εσωτερικού δείκτη marker για να ορίσει πού πρέπει να σταματήσει μια γραμμή κάτω από ένα βελάκι. Από προεπιλογή, το Aspose.Slides συντομεύει την εξαγόμενη γραμμή ώστε η γραμμή δεν να προεξήχεται μέσω του marker. Καλέστε το [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) με `true` για να σχεδιάσετε τη γραμμή μέχρι το αρχικό της άκρο. Αυτή η ρύθμιση επηρεάζει μόνο την έξοδο SVG. Η γραμμή διατηρεί τη θέση και το μήκος της στη διαφάνεια.

Το παράδειγμα σχεδιάζει τριγωνικά και διαμαντένια βελάκια σε γραμμές 2 και 10 σημείων πλάτους. Εξάγει την ίδια διαφάνεια δύο φορές, αλλάζοντας μόνο την επιλογή περικοπής.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

Η σύγκριση δείχνει το τριγωνικό βελάκι στη γραμμή 10 σημείων. Με την περικοπή ενεργοποιημένη, η άκρη είναι κοφτερή. Με την περικοπή απενεργοποιημένη, η γραμμή προεξέρχεται μέσω των πλαγίων πλευρών του marker και αφήνει μια επίπεδη άκρη.

![Μεγαλυμένο τρίγωνο 10 σημείων με κοφτερή άκρη όταν η περικοπή είναι ενεργοποιημένη και επίπεδη άκρη όταν η περικοπή είναι απενεργοποιημένη](line-end-cropping.png)

Στις άλλες γραμμές του παραδείγματος, η προεξέχουσα γραμμή είναι λιγότερο ορατή στο τρίγωνο 2 σημείων. Το γεμιστό διαμάντι καλύπτει το άκρο της γραμμής και στα δύο πλάτη.

## **Έλεγχος κειμένου και γραμματοσειρών**

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε εάν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, καθώς και πώς συμπεριλαμβάνονται ή παραπέμπονται οι εξωτερικές γραμματοσειρές. Οι παρακάτω επιλογές σας βοηθούν να ισορροπήσετε τη συμβατότητα εμφάνισης, την επιλογή κειμένου και τις εξαρτήσεις γραμματοσειρών στο εξαγόμενο SVG.

### **Διανυσιοποίηση όλου του κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις γραμματοσειρών και κάνει το οπτικό αποτέλεσμα πιο συνεπές μεταξύ των προγραμμάτων περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλογή ή αναζήσιμο ως κείμενο SVG.

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

### **Επιλέξτε πώς θα διαχειρίζονται οι εξωτερικές γραμματοσειρές**

Το [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να παραπέμπετε σε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να ενσωματώσετε τα δεδομένα της γραμματοσειράς στο SVG, ή `Vectorize` για να αποδώσετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε τα δικαιώματα χρήσης της γραμματοσειράς πριν την ενσωματώσετε.

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

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) για να παραλείψετε τα περικομμένα τμήματα πηγής, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος τη πιστότητα της εικόνας ή τα διατηρημένα δεδομένα εικόνας.

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

## **Έλεγχος ανάλυσης rasterization Metafile DPI**

Το [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) ορίζει το κατώτερο όριο ανάλυσης για τη rasterization των metafile κατά την εξαγωγή SVG. Χρησιμοποιήστε το για να ισορροπήσετε την λεπτομέρεια και το μέγεθος του αρχείου όταν μια εικόνα EMF ή WMF rasterizes. Δεν ορίζει καθολικό DPI για το SVG ούτε επιβάλλει σε κάθε αντικείμενο στη διαφάνεια να γίνει ραστερική εικόνα.

Κατεβάστε το [metafile-rasterization.pptx](metafile-rasterization.pptx), το οποίο περιέχει εικόνα EMF με στενά τοποθετημένες διαγώνιες γραμμές. Το παρακάτω παράδειγμα εξάγει την πρώτη του διαφάνεια σε τρεις αναλύσεις rasterization μέσω του [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν ίδιες ώστε τα αποτελέσματα να συγκρίνονται.

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

Στην έξοδο, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Τα παρακάτω μεγέθη αφορούν την παρεχόμενη παρουσίαση· δεν αποτελούν γενικό τύπο μετατροπής DPI σε διαστάσεις εικονοστοιχείων.

| Ανάλυση rasterization Metafile DPI | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η σύγκριση παρακάτω δείχνει την ίδια περιοχή του ενσωματωμένου raster στο ίδιο μεγέθυσμένο μέγεθος εμφάνισης. Οι διαγώνιες γραμμές παρουσιάζουν ορατή εικονοστοιχείωση στα 72 DPI και πιο ομαλές άκρες σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG μεγαλώνει. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή αλλάζει κάθε εξαγόμενο σχέδιο.

![Μεγαλυμένο λεπτομέρεια διαγώνιας γραμμής στα 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

Το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) ελέγχει τη μείωση ανάλυσης εικόνας και μπορεί να κρύψει το αποτέλεσμα της αλλαγής της ανάλυσης rasterization του metafile. Το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση rasterization του metafile.

## **Ανάθεση σταθερών IDs σε σχήματα και κείμενο**

Περάστε έναν ελεγκτή διαμόρφωσης στο [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) ώστε να ορίσετε το [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) για κάθε σχήμα SVG. Ένας ελεγκτής που διαχειρίζεται επίσης τα διαστήματα κειμένου μπορεί να ορίσει τιμές [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) στα στοιχεία `tspan` του κειμένου.

Ο παρακάτω ελεγκτής χρησιμοποιεί το [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), το οποίο είναι σταθερό για τη διάρκεια ζωής του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα διαστήματα κειμένου. Αυτό καθιστά τα παραγόμενα IDs κατάλληλα για επεξεργασία μετά από μια αμετάβλητη παρουσίαση.

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

Σε έναν ελεγκτή διαμόρφωσης, καλέστε το [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) για να προσθέσετε έναν χειριστή JavaScript σε ένα εξαγόμενο σχήμα. Αναθέστε τον ελεγκτή με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) και ορίστε τη λειτουργία JavaScript στη σελίδα ή το έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

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

Η κεντρική σελίδα μπορεί να ορίσει τη λειτουργία JavaScript στην οποία αναφέρεται ο χειριστής. Η ανάθεση IDs και χειριστών συμβάντων ενεργοποιεί προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **Συχνές ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) αντί για [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από τις γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος για να μειώσετε το μέγεθος ενός SVG;**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή των περιοχών που έχουν περικοπεί και την επιλογή συνδέσμων σε αρχεία γραμματοσειρών όταν το περιβάλλον-στόχος μπορεί να τα σερβίρει. Δοκιμάστε το αποτέλεσμα, επειδή η μειωμένη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το διανυσματισμένο κείμενο έχουν διαφορετικές ανταλλαγές ποιότητας‑μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε IDs μέσω ενός ελεγκτή διαμόρφωσης, στη συνέχεια επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο ή το σενάριό σας.