---
title: Απόδοση Διαφανειών Παρουσίασης ως Εικόνες SVG σε Java
linktitle: Διαφάνεια σε SVG
type: docs
weight: 50
url: /el/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "Εξάγετε διαφάνειες PowerPoint ως εικόνες SVG σε Java και ελέγξτε τις γραμματοσειρές, το κείμενο, τις εικόνες, τα IDs και τα συμβάντα με το Aspose.Slides."
---
## **Επισκόπηση**

SVG είναι μια κλιμακούμενη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, ροές προσβασιμότητας και αυτοματοποιημένη μεταεπεξεργασία. Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγξετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ρεύμα με τη μέθοδο [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια μιας παρουσίασης ως ξεχωριστό αρχείο SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Το όνομα αρχείου χρησιμοποιεί το [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) αντί για τον δείκτη του βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, ενώ το [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) καθορίζει αν θα εφαρμοστεί η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) σε `true` όταν το κείμενο πρέπει να αποδίδεται χωρίς λιγατούρες.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Έλεγχος περικοπής τέλους γραμμής στα άκρα βελών**

Το SVG 1.1 δεν διαθέτει ρύθμιση εσωτερικού περιθωρίου (marker inset) για να προσδιορίσει πού πρέπει να σταματήσει μια γραμμή κάτω από την άκρη ενός βέλους. Από προεπιλογή, το Aspose.Slides συντομεύει τη εξαγόμενη γραμμή ώστε η πινελιά της (stroke) να μην προεξέχει μέσα από το marker. Καλέστε το [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) με `true` για να σχεδιάσετε τη γραμμή μέχρι το αρχικό της άκρο. Αυτή η ρύθμιση επηρεάζει μόνο την έξοδο SVG. Η γραμμή διατηρεί τη θέση και το μήκος της στη διαφάνεια.

Το παράδειγμα σχεδιάζει άκρα βελών τύπου τριγώνου και ρόμβου σε γραμμές με πλάτος 2 και 10 σημεία. Εξάγει την ίδια διαφάνεια δύο φορές, αλλάζοντας μόνο την επιλογή περικοπής.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

Η σύγκριση δείχνει το τριγωνικό άκρο βέλους στη γραμμή των 10 σημείων. Όταν η περικοπή είναι ενεργή, η άκρη είναι αιχμηρή. Όταν η περικοπή είναι απενεργοποιημένη, η πινελιά προεξέρχεται από τις κεκλιμένες πλευρές του marker και αφήνει μια επίπεδη άκρη.

![Μεγεθυμένο 10‑σημείων τρίγωνο με αιχμηρή άκρη όταν η περικοπή είναι ενεργή και επίπεδη άκρη όταν η περικοπή είναι απενεργοποιημένη](line-end-cropping.png)

Στις άλλες γραμμές του παραδείγματος, η προεξέχουσα πινελιά είναι λιγότερο ορατή στο τρίγωνο των 2 σημείων. Ο γεμάτος ρόμβος καλύπτει το άκρο της πινελιάς και στα δύο πλάτη.

## **Έλεγχος κειμένου και γραμματοσειρών**

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε αν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, καθώς και πώς θα συμπεριληφθούν ή θα αναφερθούν εξωτερικές γραμματοσειρές. Οι παρακάτω επιλογές σας βοηθούν να ισορροπήσετε τη οπτική συνέπεια, την επιλογή κειμένου και τις εξαρτήσεις γραμματοσειράς στο εξαγόμενο SVG.

### **Διανυσματοποίηση όλου του κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις γραμματοσειράς και καθιστά το οπτικό αποτέλεσμα πιο συνεπές σε διαφορετικά προγράμματα περιήγησης, αλλά το κείμενο δεν θα είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Επιλογή τρόπου διαχείρισης εξωτερικών γραμματοσειρών**

Το [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) για τις γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να αναφέρετε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να ενσωματώσετε τα δεδομένα γραμματοσειράς στο SVG, ή `Vectorize` για να αποδίδετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε την άδεια χρήσης των γραμματοσειρών πριν τις ενσωματώσετε.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Μείωση μεγέθους ενσωματωμένων εικόνων**

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) για να παραλείψετε τις περικομμένες περιοχές των πηγών, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου εις βάρος της πιστότητας ή των διατηρημένων δεδομένων της εικόνας.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Έλεγχος ανάλυσης rasterization μετααρχείων**

Το [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) ορίζει το κατώτερο όριο ανάλυσης για rasterization μετααρχείων κατά την εξαγωγή SVG. Χρησιμοποιήστε το για να ισορροπήσετε τις λεπτομέρειες και το μέγεθος του αρχείου όταν μια εικόνα EMF ή WMF rasterizes. Δεν ορίζει μια καθολική τιμή DPI για το SVG ούτε αναγκάζει κάθε αντικείμενο στη διαφάνεια να μετατραπεί σε raster εικόνα.

Κατεβάστε το αρχείο [metafile-rasterization.pptx](metafile-rasterization.pptx), που περιλαμβάνει μια εικόνα EMF με στενά τοποθετημένες διαγώνιες γραμμές. Το παρακάτω παράδειγμα εξάγει την πρώτη διαφάνειά του σε τρεις αναλύσεις rasterization μέσω του [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν ίδιες ώστε τα αποτελέσματα να συγκριθούν.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream outputFileName) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

Στην έξοδο, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Οι παρακάτω μετρήσεις αφορούν την παρεχόμενη παρουσίαση· δεν αποτελούν γενικό τύπο μετατροπής DPI σε διαστάσεις pixel.

| Ανάλυση rasterization μετααρχείου DPI | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η σύγκριση παρακάτω εμφανίζει την ίδια περιοχή του ενσωματωμένου raster στην ίδια μεγεθυμένη προβολή. Οι διαγώνιες γραμμές δείχνουν ορατό pixelation στα 72 DPI και πιο ομαλές άκρες σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG μεγαλώνει. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή δεν αλλάζει κάθε εξαγόμενη εικόνα.

![Μεγεθυμένη λεπτομέρεια διαγώνιων γραμμών στα 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

Το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) ελέγχει τη μείωση της ανάλυσης της εικόνας και μπορεί να καλύψει την επίδραση της αλλαγής της ανάλυσης rasterization μετααρχείου. Το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση rasterization μετααρχείου.

## **Ανάθεση σταθερών ID σε σχήματα και κείμενο**

Χρησιμοποιήστε το [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) για να ορίσετε το [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) για κάθε σχήμα SVG. Για να ορίσετε τιμές [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) στα στοιχεία `tspan` κειμένου, υλοποιήστε το [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Αναθέστε οποιονδήποτε ελεγκτή με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Ο παρακάτω ελεγκτής χρησιμοποιεί το [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) που είναι σταθερό για τη διάρκεια ζωής του σχήματος, και έναν επαναλήψιμο μετρητή για τα κείμενα του. Αυτό κάνει τα παραγόμενα ID κατάλληλα για μεταεπεξεργασία μιας αμετάβλητης παρουσίασης.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Προσθήκη χειριστών συμβάντων SVG**

Σε έναν [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/), καλέστε το [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) για να προσθέσετε έναν χειριστή JavaScript σε ένα εξαγόμενο σχήμα. Αναθέστε τον ελεγκτή με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) και ορίστε τη λειτουργία JavaScript στη σελίδα ή το έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

Η κεντρική σελίδα μπορεί να ορίσει τη λειτουργία JavaScript στην οποία αναφέρεται ο χειριστής. Η ανάθεση ID και χειριστών συμβάντων ενεργοποιεί προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **FAQ**

**Πότε πρέπει να χρησιμοποιήσω το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) αντί για το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από τις γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να κάνετε ένα SVG μικρότερο;**

Ξεκινήστε συμπιέζοντας τις ενσωματωμένες εικόνες, διαγράφοντας τις περιοχές των εικόνων που έχουν περικοπεί και επιλέγοντας συνδεδεμένα αρχεία γραμματοσειρών όταν το περιβάλλον-στόχος μπορεί να τα σερβίρει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και η διανυσματοποίηση του κειμένου έχουν διαφορετικούς συμβιβασμούς ποιότητας και μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγμένα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε ID μέσω ενός ελεγκτή μορφοποίησης, στη συνέχεια επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μετα-επεξεργασίας ή στο σενάριο του προγράμματος περιήγησης.