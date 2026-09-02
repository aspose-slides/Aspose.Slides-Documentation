---
title: Απόδοση διαφανειών παρουσίασης ως εικόνες SVG σε Android
linktitle: Διαφάνεια σε SVG
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
description: "Εξάγετε διαφάνειες PowerPoint ως εικόνες SVG σε Android και ελέγξτε τις γραμματοσειρές, το κείμενο, τις εικόνες, τα αναγνωριστικά και τα συμβάντα με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια κλιμακώσιμη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, διαδικασίες προσβασιμότητας και αυτοματοποιημένη μετα-επεξεργασία. Το Aspose.Slides for Android μέσω Java εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγξετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή με τη μέθοδο [ISlide.writeAsSvg](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Το ακόλουθο παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

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

Το όνομα αρχείου χρησιμοποιεί το [ISlide.getSlideNumber](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#getSlideNumber--) αντί για το δείκτη βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με τη μέθοδο [IShape.writeAsSvg](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

[SVGOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) σε `true` όταν το κείμενο πρέπει να αποδίδεται χωρίς λιγάρτες.

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

### **Διανυσματισμός όλου του κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις από γραμματοσειρές και καθιστά το οπτικό αποτέλεσμα πιο συνεπές σε διαφορετικά προγράμματα περιήγησης, όμως το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

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

### **Επιλέξτε πώς θα διαχειρίζονται οι εξωτερικές γραμματοσειρές**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgexternalfontshandling/) για να αναφέρετε ξεχωριστά αρχεία γραμματοσειρών, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgexternalfontshandling/) για να συμπεριλάβετε τα δεδομένα γραμματοσειράς στο SVG, ή [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgexternalfontshandling/) για να αποδώσετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε την άδεια χρήσης των γραμματοσειρών πριν από την ενσωμάτωσή τους.

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

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) για να παραλείψετε περιοχές που έχουν περικοπεί, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος την πιστότητα της εικόνας ή τα διατηρημένα δεδομένα εικόνας.

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

## **Ανάθεση σταθερών ID σε σχήματα και κείμενο**

Χρησιμοποιήστε το [ISvgShapeFormattingController](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) για να ορίσετε το [ISvgShape.setId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) για κάθε σχήμα SVG. Για να ορίσετε επίσης τιμές [ISvgTSpan.setId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) σε στοιχεία κειμένου `tspan`, υλοποιήστε το [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Αναθέστε οποιονδήποτε από τους ελεγκτές με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

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

Σε έναν [ISvgShapeFormattingController](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), καλέστε το [ISvgShape.setEventHandler](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgevent/) για να προσθέσετε έναν χειριστή JavaScript σε ένα εξαγόμενο σχήμα. Αναθέστε τον ελεγκτή με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) και ορίστε τη λειτουργία JavaScript στη σελίδα ή στο έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

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

Η σελίδα-φιλοξενητής μπορεί να ορίσει τη λειτουργία JavaScript που αναφέρεται από το χειριστή. Η ανάθεση ID και χειριστών συμβάντων ενεργοποιεί προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) αντί για το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να μειωθεί το μέγεθος ενός SVG;**

Ξεκινήστε με συμπίεση των ενσωματωμένων εικόνων, διαγραφή των περικομμένων περιοχών εικόνας και επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το περιβάλλον-στόχος μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και ο διανυσματισμός του κειμένου έχουν διαφορετικές ανταλλαγές ποιότητας‑μεγέθους.

**Μπορώ να τροποποιήσω τα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Ανάθετε ID μέσω ενός ελεγκτή μορφοποίησης, έπειτα επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο ή το σενάριο του προγράμματος περιήγησης που χρησιμοποιείτε για μετα‑επεξεργασία.