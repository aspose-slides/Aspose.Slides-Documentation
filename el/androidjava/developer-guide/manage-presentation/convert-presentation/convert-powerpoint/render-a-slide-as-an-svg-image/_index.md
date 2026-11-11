---
title: Render Presentation Slides as SVG Images on Android
linktitle: Slide to SVG
type: docs
weight: 50
url: /el/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Εξαγωγή διαφανειών PowerPoint ως εικόνων SVG σε Android και έλεγχος γραμματοσειρών, κειμένου, εικόνων, αναγνωριστικών και συμβάντων με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια κλιμακώσιμη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για τη δημοσίευση στο web, προγράμματα προβολής διαφανειών, διαδικασίες προσβασιμότητας και αυτοματοποιημένη μετα‑επεξεργασία. Το Aspose.Slides for Android μέσω Java εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο σε όλα τα προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή με [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

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

Το όνομα αρχείου χρησιμοποιεί το [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) αντί για το δείκτη του βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) όταν ένας προβάτης διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο εκείνο το σχήμα.

## **Διαμόρφωση εξόδου SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) ελέγχει την απόδοση SVG. Για πλαίσια κειμένου, το [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) καθορίζει αν θα εφαρμοστεί η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) σε `true` όταν το κείμενο πρέπει να αποδίδεται χωρίς συνδέσεις.

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

## **Έλεγχος κειμένου και γραμματοσειρών**

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε εάν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, καθώς και πώς ενσωματώνονται ή αναφέρονται οι εξωτερικές γραμματοσειρές. Οι παρακάτω επιλογές σας βοηθούν να ισορροπήσετε την οπτική συνέπεια, την επιλογή κειμένου και τις εξαρτήσεις γραμματοσειρών στο εξαγόμενο SVG.

### **Διανυσματοποίηση όλου του κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις γραμματοσειρών και κάνει το οπτικό αποτέλεσμα πιο συνεπές σε όλα τα προγράμματα περιήγησης, όμως το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

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

### **Επιλέξτε πώς διαχειρίζονται οι εξωτερικές γραμματοσειρές**

Το [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε το [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) για να αναφερθείτε σε ξεχωριστά αρχεία γραμματοσειρών, το [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) για να συμπεριλάβετε τα δεδομένα γραμματοσειράς στο SVG, ή το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) για να αποτυπώσετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε τις άδειες γραμματοσειρών πριν την ενσωμάτωση.

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

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) για να παραλείψετε τις περικομμένες περιοχές προέλευσης, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) για να ελέγχετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος την πιστότητα της εικόνας ή τα διατηρημένα δεδομένα εικόνας.

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

## **Έλεγχος ανάλυσης rasterization μετααρχείου**

Το [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) ορίζει το κάτω όριο ανάλυσης για τη rasterization των μετααρχείων κατά την εξαγωγή SVG. Χρησιμοποιήστε το για να εξισορροπήσετε τις λεπτομέρειες και το μέγεθος του αρχείου όταν μια εικόνα EMF ή WMF rasterizes. Δεν ορίζει ένα παγκόσμιο DPI για το SVG ούτε αναγκάζει κάθε αντικείμενο στη διαφάνεια να μετατραπεί σε raster εικόνα.

Κατεβάστε το [metafile-rasterization.pptx](metafile-rasterization.pptx), το οποίο περιέχει μια εικόνα EMF με στενά τοποθετημένες διαγώνιες γραμμές. Το παρακάτω παράδειγμα εξάγει την πρώτη του διαφάνεια σε τρεις αναλύσεις rasterization μέσω του [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν ίδιες ώστε τα αποτελέσματα να μπορούν να συγκριθούν.

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
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

Στο αποτέλεσμα, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Οι παρακάτω μετρήσεις αφορούν την παρεχόμενη παρουσίαση· δεν αποτελούν γενική τύπο μετατροπής DPI σε διαστάσεις εικονοστοιχείων.

| Rasterization DPI μετααρχείου | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η σύγκριση παρακάτω δείχνει την ίδια περιοχή του ενσωματωμένου raster στην ίδια μεγεθυμένη προβολή. Οι διαγώνιες γραμμές εμφανίζουν καθαρή εικονοκλίμακα στα 72 DPI και πιο ομαλές άκρες σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG μεγαλώνει. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή αλλάζει κάθε εξαγόμενη εικόνα.

![Μεγεθυμένη λεπτομέρεια διαγωνίων γραμμών σε 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

Το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) ελέγχει τη μείωση της ανάλυσης της εικόνας και μπορεί να καλύψει το αποτέλεσμα της αλλαγής της ανάλυσης rasterization του μετααρχείου. Το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση rasterization του μετααρχείου.

## **Ανάθεση σταθερών αναγνωριστικών σε σχήματα και κείμενο**

Χρησιμοποιήστε το [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) για να ορίσετε το [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) για κάθε σχήμα SVG. Για να ορίσετε τιμές [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) στα στοιχεία κειμένου `tspan`, υλοποιήστε το [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Εκχωρήστε οποιονδήποτε από τους ελεγκτές με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Ο παρακάτω ελεγκτής χρησιμοποιεί το [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), το οποίο είναι σταθερό για τη διάρκεια ζωής του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα κείμενα του. Αυτό καθιστά τα παραγόμενα αναγνωριστικά κατάλληλα για μετα‑επεξεργασία μιας αμετάβλητης παρουσίασης.

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

## **Πρόσθεση χειριστών συμβάντων SVG**

Σε έναν [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), καλέστε το [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) για να προσθέσετε έναν χειριστή JavaScript σε ένα εξαγόμενο σχήμα. Εκχωρήστε τον ελεγκτή με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) και ορίστε τη λειτουργία JavaScript στη σελίδα ή στο έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

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

Η σελίδα κεντρικού υποδοχέα μπορεί να ορίσει τη λειτουργία JavaScript που αναφέρεται από τον χειριστή. Η εκχώρηση αναγνωριστικών και χειριστών συμβάντων ενεργοποιεί προγράμματα προβολής διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **FAQ**

**Πότε πρέπει να χρησιμοποιήσω [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) αντί για [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από τις γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές θα πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να μικρύνετε ένα SVG;**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή των περικομμένων περιοχών εικόνας και την επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το περιβάλλον‑στόχος μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το διανυσματοποιημένο κείμενο έχουν διαφορετικές ανταλλαγές ποιότητας και μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Εκχωρήστε αναγνωριστικά μέσω ενός ελεγκτή μορφοποίησης, έπειτα επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μετά‑επεξεργασίας ή στο σενάριο του προγράμματος περιήγησης.