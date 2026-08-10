---
title: Διαχείριση Αντικειμένων Μελάνης Παρουσίασης σε JavaScript
linktitle: Διαχείριση Μελάνης
type: docs
weight: 95
url: /el/nodejs-java/manage-ink/
keywords:
- μελάνη
- αντικείμενο μελάνης
- ίχνος μελάνης
- διαχείριση μελάνης
- σχεδίαση μελάνης
- σχέδιο
- εξαγωγή μελάνης
- απόδοση μελάνης
- απόκρυψη μελάνης
- InkOptions
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τα αντικείμενα μελάνης του PowerPoint, επεξεργαστείτε ιχνη και ιδιότητες πινέλου, και ελέγξτε την εμφάνιση της μελάνης κατά την εξαγωγή PDF, HTML, SVG, TIFF και εικόνας με το Aspose.Slides για Node.js μέσω Java."
---
## **Εισαγωγή**

Το PowerPoint παρέχει μια λειτουργία μελάνης που σας επιτρέπει να σχεδιάζετε ελεύθερες γραμμές. Η μελάνη μπορεί να χρησιμοποιηθεί για την επισήμανση άλλων αντικειμένων, την εμφάνιση συνδέσεων και διαδικασιών, και την προσέλκυση προσοχής σε συγκεκριμένα στοιχεία μιας διαφάνειας.

Το Aspose.Slides παρέχει τους τύπους που απαιτούνται για εργασία με αντικείμενα μελάνης. Για παράδειγμα, η κλάση [Ink](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ink/) αντιπροσωπεύει ένα αντικείμενο μελάνης σε μια διαφάνεια.

## **Διαφορές μεταξύ Κανονικών Αντικειμένων και Αντικειμένων Μελάνης**

Τα αντικείμενα σε μια διαφάνεια του PowerPoint αντιπροσωπεύονται συνήθως από αντικείμενα σχήματος. Στην πιο απλή του μορφή, ένα σχήμα είναι ένας κοντέινερ που ορίζει την περιοχή του ίδιου του αντικειμένου (το πλαίσιο του) μαζί με ιδιότητες όπως το μέγεθος του κοντέινερ, το σχήμα και το φόντο. Για περισσότερες πληροφορίες, δείτε το [Shape Layout Format](https://docs.aspose.com/slides/el/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Ωστόσο, όταν το PowerPoint διαχειρίζεται ένα αντικείμενο μελάνης, αγνοεί όλες τις ιδιότητες του πλαισίου του αντικειμένου (κοντέινερ) εκτός από το μέγεθός του. Το μέγεθος της περιοχής του κοντέινερ καθορίζεται από τις τυπικές μεθόδους [Shape.getWidth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getWidth--) και [Shape.getHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Ίχνη Μελάνης**

Ένα ίχνος μελάνης είναι ένα βασικό στοιχείο που χρησιμοποιείται για την καταγραφή της τροχιάς ενός στυλό καθώς ο χρήστης γράφει ψηφιακή μελάνη. Ένα ίχνος αποθηκεύει μια αλληλουχία συνδεδεμένων σημείων.

Η πιο απλή μορφή κωδικοποίησης προσδιορίζει τις συντεταγμένες X και Y κάθε σημείου δείγματος. Όταν αποδοθούν όλα τα συνδεδεμένα σημεία, παράγουν μια εικόνα όπως αυτή:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ιδιότητες Πινέλου για Σχεδίαση**

Ένα πινέλο χρησιμοποιείται για τη σχεδίαση γραμμών που συνδέουν τα σημεία ενός ιχνός μελάνης. Το πινέλο έχει το δικό του χρώμα και μέγεθος, που αντιπροσωπεύονται από τις μεθόδους [InkBrush.getColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkbrush/#getColor--) και [InkBrush.getSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkbrush/#getSize--) .

### **Ορισμός Χρώματος Πινέλου Μελάνης**

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε το χρώμα ενός πινέλου μελάνης:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Ορισμός Μεγέθους Πινέλου Μελάνης**

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε το μέγεθος ενός πινέλου μελάνης:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Γενικά, το πλάτος και το ύψος ενός πινέλου δεν ταιριάζουν, επομένως το PowerPoint δεν εμφανίζει το μέγεθος του πινέλου (η αντίστοιχη ενότητα δεδομένων είναι ανοιχτή). Όταν το πλάτος και το ύψος του πινέλου ταιριάζουν, το PowerPoint εμφανίζει το μέγεθός του με τον εξής τρόπο:

![ink_powerpoint3](ink_powerpoint3.png)

Για σαφήνεια, ας αυξήσουμε το ύψος του αντικειμένου μελάνης και να εξετάσουμε τις σημαντικές διαστάσεις:

![ink_powerpoint4](ink_powerpoint4.png)

Ο κοντέινερ (πλαίσιο) δεν λαμβάνει υπόψη το μέγεθος των πινέλων — πάντα θεωρεί ότι το πάχος της γραμμής είναι μηδέν (δείτε την προηγούμενη εικόνα).

Επομένως, για να προσδιοριστεί η ορατή περιοχή ολόκληρου του αντικειμένου μελάνης, πρέπει να ληφθεί υπόψη το μέγεθος του πινέλου των ιχνών του. Εδώ, το αντικείμενο στόχος (το ίχνος χειρόγραφου κειμένου) έχει κλιμακωθεί στο μέγεθος του κοντέινερ (πλαισίου). Όταν το μέγεθος του κοντέινερ αλλάξει, το μέγεθος του πινέλου παραμένει σταθερό, και αντίστροφα.

![ink_powerpoint5](ink_powerpoint5.png)

Το PowerPoint χρησιμοποιεί παρόμοια συμπεριφορά για αντικείμενα κειμένου:

![ink_powerpoint6](ink_powerpoint6.png)

## **Έλεγχος Εμφάνισης Μελάνης Κατά την Εξαγωγή και Απόδοση**

Το Aspose.Slides παρέχει την κλάση [InkOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/) για να ελέγχει πώς εμφανίζονται τα αντικείμενα μελάνης στην εξαγόμενη ή αποδομένη έξοδο. Μπορείτε να χρησιμοποιήσετε τις ιδιότητες της για να κρύψετε εντελώς τη μελάνη ή να αλλάξετε τον τρόπο ερμηνείας των λειτουργιών μάσκας του πινέλου μελάνης.

Οι επιλογές μελάνης διατίθενται μέσω των επιλογών εξαγωγής ή απόδοσης για διάφορους τύπους εξόδου:

| Έξοδος | Ιδιότητα επιλογών Μελάνης |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Οι παρακάτω μέθοδοι [InkOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/) αποκαλύπτουν τις ίδιες δύο ρυθμίσεις:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/#getHideInk--) καθορίζει εάν τα αντικείμενα μελάνης περιλαμβάνονται στην έξοδο. Η προεπιλεγμένη τιμή του είναι `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) καθορίζει εάν μια λειτουργία μάσκας ερμηνεύεται ως αδιαφάνεια κατά την απόδοση ενός πινέλου μελάνης. Η προεπιλεγμένη τιμή του είναι `true`; καλέστε [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) με `false` για να χρησιμοποιήσετε τη λειτουργία ROP αντί αυτού.

### **Απόκρυψη Αντικειμένων Μελάνης στην Έξοδο PDF**

Από προεπιλογή, τα αντικείμενα μελάνης παραμένουν ορατά κατά την εξαγωγή. Για να δημιουργήσετε μια καθαρή έξοδο χωρίς χειρόγραφες σημειώσεις ή άλλο περιεχόμενο μελάνης, καλέστε [InkOptions.setHideInk](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) με `true`.

Το παρακάτω παράδειγμα JavaScript εξάγει μια παρουσίαση σε PDF ενώ κρύβει όλα τα αντικείμενα μελάνης:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Απόκρυψη Αντικειμένων Μελάνης κατά την Απόδοση μιας Διαφάνειας ως Εικόνας**

Για να κρύψετε τα αντικείμενα μελάνης όταν αποδίδετε διαφάνειες ως εικόνες bitmap, ρυθμίστε το [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) και περάστε τις επιλογές απόδοσης στο [Slide.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

Το παρακάτω παράδειγμα JavaScript αποδίδει την πρώτη διαφάνεια ως εικόνα PNG χωρίς αντικείμενα μελάνης:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Έλεγχος Απόδοσης Μάσκας Μελάνης**

Η ρύθμιση [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) ελέγχει πώς ερμηνεύονται οι λειτουργίες μάσκας κατά την απόδοση πινέλων μελάνης. Η προεπιλεγμένη τιμή είναι `true`, η οποία χρησιμοποιεί αδιαφάνεια. Για χρήση της λειτουργίας ROP αντί αυτού, καλέστε [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) με `false`.

Το παρακάτω παράδειγμα JavaScript εξάγει μια διαφάνεια σε SVG και χρησιμοποιεί απόδοση με βάση ROP για λειτουργίες μάσκας μελάνης:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

Η ίδια ρύθμιση μπορεί να εφαρμοστεί μέσω του [TiffOptions.getInkOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) κατά την εξαγωγή μιας παρουσίασης ή την απόδοση μιας διαφάνειας σε TIFF.

### **Επιλέξτε Αν Θα Αποκρύψετε ή Θα Διατηρήσετε τη Μελάνη**

Όταν χρειάζεστε μια καθαρή έκδοση μιας σημειωμένης παρουσίασης για διανομή χωρίς σημάδια ανασκόπησης, καλέστε [InkOptions.setHideInk](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) με `true` κατά την εξαγωγή.

Αφήστε το [InkOptions.getHideInk](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/#getHideInk--) στην προεπιλεγμένη τιμή του `false` όταν οι σημειώσεις μελάνης αποτελούν μέρος του προοριζόμενου περιεχομένου, όπως σχόλια ανασκόπησης, χειρόγραφες σημειώσεις, επισημάνσεις ή σχέδια που πρέπει να παραμείνουν ορατά στο εξαγόμενο αποτέλεσμα. Αυτό επιτρέπει στις εφαρμογές να δημιουργούν ξεχωριστές εξόδους ανασκόπησης και τελικής έκδοσης από την ίδια παρουσίαση χωρίς να τροποποιούν τα πηγαία αντικείμενα μελάνης.

## **Συχνές ερωτήσεις**

**Μπορώ να αλλάξω το χρώμα ή το μέγεθος μιας υπάρχουσας γραμμής μελάνης;**

Ναι. Πάρτε το ίχνος από [Ink.getTraces](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ink/#getTraces--) και μετά αλλάξτε το [InkTrace.getBrush](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inktrace/#getBrush--). Καλέστε [InkBrush.setColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) ή [InkBrush.setSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) για να αλλάξετε το πινέλο.

**Αλλάζει η απόκρυψη της μελάνης την πηγαία παρουσίαση;**

Όχι. Η κλήση του [InkOptions.setHideInk](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) επηρεάζει μόνο το αποδοθέν ή εξαγόμενο αποτέλεσμα· δεν αφαιρεί ή τροποποιεί τα αντικείμενα μελάνης στην πηγαία παρουσίαση.

**Ποιες μορφές εξαγωγής υποστηρίζουν τις επιλογές μελάνης;**

Μπορείτε να ρυθμίσετε τις επιλογές μελάνης για PDF, HTML, SVG, TIFF και εικόνες διαφανειών bitmap μέσω των αντίστοιχων επιλογών εξαγωγής ή απόδοσης που εμφανίζονται παραπάνω.

**Περαιτέρω ανάγνωση**

* Για γενική ανάγνωση σχετικά με τα σχήματα, δείτε την ενότητα [PowerPoint Shapes](https://docs.aspose.com/slides/el/nodejs-java/powerpoint-shapes/).
* Για περισσότερες πληροφορίες σχετικά με τις αποτελεσματικές τιμές, δείτε το [Shape Effective Properties](https://docs.aspose.com/slides/el/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Για λεπτομέρειες σχετικά με την εξαγωγή PDF, δείτε το [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/el/nodejs-java/convert-powerpoint-to-pdf/).
* Για λεπτομέρειες σχετικά με την εξαγωγή HTML, δείτε το [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/el/nodejs-java/convert-powerpoint-to-html/).
* Για λεπτομέρειες σχετικά με την εξαγωγή SVG, δείτε το [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/el/nodejs-java/render-a-slide-as-an-svg-image/).
* Για λεπτομέρειες σχετικά με την εξαγωγή TIFF, δείτε το [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/el/nodejs-java/convert-powerpoint-to-tiff/).
* Για λεπτομέρειες σχετικά με την απόδοση διαφανειών σε εικόνες, δείτε το [Convert Presentation Slides to Images](https://docs.aspose.com/slides/el/nodejs-java/convert-slide/).