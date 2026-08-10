---
title: Διαχείριση Αντικειμένων Μελάνης Παρουσίασης σε Android
linktitle: Διαχείριση Μελάνης
type: docs
weight: 95
url: /el/androidjava/manage-ink/
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
- IInkOptions
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα αντικείμενα μελάνης του PowerPoint, επεξεργαστείτε τα ίχνη και τις ιδιότητες του πινέλου, και ελέγξτε την εμφάνιση της μελάνης κατά την εξαγωγή PDF, HTML, SVG, TIFF και εικόνας με το Aspose.Slides για Android."
---
## **Εισαγωγή**

Το PowerPoint παρέχει μια λειτουργία μελάνης που σας επιτρέπει να σχεδιάζετε ελεύθερα στίγματα. Η μελάνη μπορεί να χρησιμοποιηθεί για να επισημάνει άλλα αντικείμενα, να δείξει συνδέσεις και διαδικασίες, και να τραβήξει την προσοχή σε συγκεκριμένα στοιχεία σε μια διαφάνεια.

Η Aspose.Slides παρέχει τους τύπους που χρειάζονται για εργασία με αντικείμενα μελάνης. Για παράδειγμα, η διεπαφή [IInk](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iink/) αντιπροσωπεύει ένα αντικείμενο μελάνης σε μια διαφάνεια.

## **Διαφορές μεταξύ Κανονικών Αντικειμένων και Αντικειμένων Μελάνης**

Τα αντικείμενα σε μια διαφάνεια PowerPoint συνήθως εκπροσωπούνται από αντικείμενα σχήματος. Στην πιο απλή μορφή του, ένα σχήμα είναι ένας περιέκτης που ορίζει την περιοχή του ίδιου του αντικειμένου (το πλαίσιό του) μαζί με ιδιότητες όπως το μέγεθος, το σχήμα και το φόντο του περιέκτη. Για περισσότερες πληροφορίες, δείτε το [Shape Layout Format](https://docs.aspose.com/slides/el/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Ωστόσο, όταν το PowerPoint διαχειρίζεται ένα αντικείμενο μελάνης, αγνοεί όλες τις ιδιότητες του πλαισίου του αντικειμένου (περιέκτη) εκτός από το μέγεθός του. Το μέγεθος της περιοχής του περιέκτη καθορίζεται από τις τυπικές μεθόδους [IShape.getWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getWidth--) και [IShape.getHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getHeight--) .

![ink_powerpoint1](ink_powerpoint1.png)

## **Ίχνη Μελάνης**

Ένα ίχνος μελάνης είναι ένα βασικό στοιχείο που χρησιμοποιείται για την καταγραφή της τροχιάς ενός στυλό καθώς ο χρήστης γράφει ψηφιακή μελάνη. Ένα ίχνος αποθηκεύει μια ακολουθία συνδεδεμένων σημείων.

Η πιο απλή μορφή κωδικοποίησης καθορίζει τις συντεταγμένες X και Y κάθε σημείου δείγματος. Όταν όλα τα συνδεδεμένα σημεία αποδοθούν, παράγουν μια εικόνα όπως αυτή:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ιδιότητες Πινέλου για Σχέδιο**

Ένα πινέλο χρησιμοποιείται για τη σχεδίαση γραμμών που συνδέουν τα σημεία ενός ίχνους μελάνης. Το πινέλο έχει το δικό του χρώμα και μέγεθος, τα οποία αντιπροσωπεύονται από τις μεθόδους [IInkBrush.getColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkbrush/#getColor--) και [IInkBrush.getSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkbrush/#getSize--) .

### **Ορισμός Χρώματος Πινέλου Μελάνης**

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε το χρώμα ενός πινέλου μελάνης:

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Ορισμός Μεγέθους Πινέλου Μελάνης**

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε το μέγεθος ενός πινέλου μελάνης:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Γενικά, το πλάτος και το ύψος ενός πινέλου δεν ταιριάζουν, έτσι το PowerPoint δεν εμφανίζει το μέγεθος του πινέλου (η αντίστοιχη ενότητα δεδομένων είναι ασαπτή). Όταν το πλάτος και το ύψος του πινέλου ταιριάζουν, το PowerPoint εμφανίζει το μέγεθός του με αυτόν τον τρόπο:

![ink_powerpoint3](ink_powerpoint3.png)

Για σαφήνεια, ας αυξήσουμε το ύψος του αντικειμένου μελάνης και να εξετάσουμε τις σημαντικές διαστάσεις:

![ink_powerpoint4](ink_powerpoint4.png)

Ο περιέκτης (πλαίσιο) δεν λαμβάνει υπόψη το μέγεθος των πινέλων — υποθέτει πάντα ότι το πάχος της γραμμής είναι μηδέν (δείτε την προηγούμενη εικόνα).

Επομένως, για να προσδιοριστεί η ορατή περιοχή ολόκληρου του αντικειμένου μελάνης, πρέπει να ληφθεί υπόψη το μέγεθος του πινέλου των ιχνών του. Εδώ, το αντικείμενο-στόχος (το ίχνος χειρόγραφου κειμένου) έχει κλιμακωθεί στο μέγεθος του περιέκτη (πλαισίου). Όταν το μέγεθος του περιέκτη αλλάζει, το μέγεθος του πινέλου παραμένει σταθερό, και αντίστροφα.

![ink_powerpoint5](ink_powerpoint5.png)

Το PowerPoint χρησιμοποιεί παρόμοια συμπεριφορά για αντικείμενα κειμένου:

![ink_powerpoint6](ink_powerpoint6.png)

## **Έλεγχος Εμφάνισης Μελάνης Κατά την Εξαγωγή και Απόδοση**

Η Aspose.Slides παρέχει τη διεπαφή [IInkOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/) για να ελέγξει πώς εμφανίζονται τα αντικείμενα μελάνης στην εξαγόμενη ή αποδοθείσα έξοδο. Μπορείτε να χρησιμοποιήσετε τις ιδιότητές της για να αποκρύψετε πλήρως τη μελάνη ή να αλλάξετε τον τρόπο ερμηνείας των λειτουργιών μάσκας πινέλου μελάνης.

Ink options are available through the export or rendering options for several output types:

| Έξοδος | Ιδιότητα επιλογών μελάνης |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Εικόνα διαφάνειας | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Οι παρακάτω μέθοδοι του [IInkOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/) εκθέτουν τις ίδιες δύο ρυθμίσεις:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) καθορίζει αν τα αντικείμενα μελάνης περιλαμβάνονται στην έξοδο. Η προεπιλεγμένη τιμή είναι `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) καθορίζει αν μια λειτουργία μάσκας ερμηνεύεται ως αδιαφάνεια κατά την απόδοση ενός πινέλου μελάνης. Η προεπιλεγμένη τιμή είναι `true`; καλέστε το [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) με `false` για να χρησιμοποιήσετε την ενέργεια ROP αντ' αυτού.

### **Απόκρυψη Αντικειμένων Μελάνης στην Εξαγωγή PDF**

Από προεπιλογή, τα αντικείμενα μελάνης παραμένουν ορατά κατά την εξαγωγή. Για να δημιουργήσετε μια καθαρή έξοδο χωρίς χειρόγραφες σημειώσεις ή άλλο περιεχόμενο μελάνης, καλέστε το [IInkOptions.setHideInk](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) με `true`.

Το παρακάτω παράδειγμα Java εξάγει μια παρουσίαση σε PDF ενώ αποκρύπτει όλα τα αντικείμενα μελάνης:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Απόκρυψη Αντικειμένων Μελάνης Κατά την Απόδοση Διαφάνειας ως Εικόνας**

Για να αποκρύψετε αντικείμενα μελάνης κατά την απόδοση διαφανειών ως εικόνες bitmap, διαμορφώστε το [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) και περάστε τις επιλογές απόδοσης στη μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Το παρακάτω παράδειγμα Java αποδίδει την πρώτη διαφάνεια ως εικόνα PNG χωρίς αντικείμενα μελάνης:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Έλεγχος Απόδοσης Μάσκας Μελάνης**

Η ρύθμιση [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) ελέγχει πώς ερμηνεύονται οι λειτουργίες μάσκας κατά την απόδοση πινέλων μελάνης. Η προεπιλεγμένη τιμή είναι `true`, που χρησιμοποιεί αδιαφάνεια. Για να χρησιμοποιήσετε την ενέργεια ROP αντί αυτού, καλέστε το [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) με `false`.

Το παρακάτω παράδειγμα Java εξάγει μια διαφάνεια σε SVG και χρησιμοποιεί απόδοση βάσει ROP για λειτουργίες μάσκας μελάνης:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

Η ίδια ρύθμιση μπορεί να εφαρμοστεί μέσω του [TiffOptions.getInkOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) όταν εξάγετε μια παρουσίαση ή αποδίδετε μια διαφάνεια σε TIFF.

### **Επιλέξτε Αν Θα Αποκρύψετε ή Να Διατηρήσετε τη Μελάνη**

Όταν χρειάζεστε μια καθαρή έκδοση μιας σημειωμένης παρουσίασης για διανομή χωρίς σημεία αξιολόγησης, καλέστε το [IInkOptions.setHideInk](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) με `true` κατά την εξαγωγή.

Αφήστε το [IInkOptions.getHideInk](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) στην προεπιλεγμένη τιμή του `false` όταν οι σημειώσεις μελάνης αποτελούν μέρος του προοριζόμενου περιεχομένου, όπως σχόλια αξιολόγησης, χειρόγραφες σημειώσεις, επισημάνσεις ή σχέδια που πρέπει να παραμείνουν ορατά στο εξαγόμενο αποτέλεσμα. Αυτό επιτρέπει στις εφαρμογές να παράγουν ξεχωριστές εξόδους αξιολόγησης και τελικές εξόδους από την ίδια παρουσίαση χωρίς να τροποποιούν τα πηγαία αντικείμενα μελάνης.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μπορώ να αλλάξω το χρώμα ή το μέγεθος ενός υπάρχοντος στίγματος μελάνης;**

Ναι. Λάβετε το ίχνος από το [IInk.getTraces](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iink/#getTraces--) , στη συνέχεια αλλάξτε το [IInkTrace.getBrush](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinktrace/#getBrush--). Καλέστε το [IInkBrush.setColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) ή το [IInkBrush.setSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) για να αλλάξετε το πινέλο.

**Αλλάζει η απόκρυψη της μελάνης την πηγαία παρουσίαση;**

Όχι. Η κλήση του [IInkOptions.setHideInk](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) επηρεάζει μόνο το αποδοθέν ή εξαχθέν αποτέλεσμα· δεν αφαιρεί ή τροποποιεί τα αντικείμενα μελάνης στην πηγαία παρουσίαση.

**Ποια μορφότυπα εξαγωγής υποστηρίζουν επιλογές μελάνης;**

Μπορείτε να ρυθμίσετε τις επιλογές μελάνης για PDF, HTML, SVG, TIFF και εικόνες bitmap διαφανειών μέσω των αντίστοιχων επιλογών εξαγωγής ή απόδοσης που εμφανίζονται παραπάνω.

**Περαιτέρω ανάγνωση**

* Για γενική ανάγνωση σχετικά με τα σχήματα, δείτε την ενότητα [PowerPoint Shapes](https://docs.aspose.com/slides/el/androidjava/powerpoint-shapes/).
* Για περισσότερες πληροφορίες σχετικά με τις αποτελεσματικές τιμές, δείτε το [Shape Effective Properties](https://docs.aspose.com/slides/el/androidjava/shape-effective-properties/#get-effective-font-height-value).
* Για λεπτομέρειες σχετικά με την εξαγωγή PDF, δείτε το [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/el/androidjava/convert-powerpoint-to-pdf/).
* Για λεπτομέρειες σχετικά με την εξαγωγή HTML, δείτε το [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/el/androidjava/convert-powerpoint-to-html/).
* Για λεπτομέρειες σχετικά με την εξαγωγή SVG, δείτε το [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/el/androidjava/render-a-slide-as-an-svg-image/).
* Για λεπτομέρειες σχετικά με την εξαγωγή TIFF, δείτε το [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/el/androidjava/convert-powerpoint-to-tiff/).
* Για λεπτομέρειες σχετικά με την απόδοση διαφανειών σε εικόνες, δείτε το [Convert Presentation Slides to Images](https://docs.aspose.com/slides/el/androidjava/convert-slide/).