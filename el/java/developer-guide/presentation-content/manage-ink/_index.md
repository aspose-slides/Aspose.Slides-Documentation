---
title: Διαχείριση Αντικειμένων Μελάνης Παρουσίασης σε Java
linktitle: Διαχείριση Μελάνης
type: docs
weight: 95
url: /el/java/manage-ink/
keywords:
- μελάνη
- αντικείμενο μελάνης
- ίχνος μελάνης
- διαχείριση μελάνης
- σχεδίαση μελάνης
- σχεδίαση
- εξαγωγή μελάνης
- απόδοση μελάνης
- απόκρυψη μελάνης
- IInkOptions
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε αντικείμενα μελάνης PowerPoint, επεξεργαστείτε ίχνη και ιδιότητες πινέλου, και ελέγξτε την εμφάνιση της μελάνης κατά την εξαγωγή σε PDF, HTML, SVG, TIFF και εικόνα με το Aspose.Slides για Java."
---
## **Εισαγωγή**

Το PowerPoint παρέχει μια λειτουργία μελάνης που σας επιτρέπει να σχεδιάζετε ελεύθερα στίγματα. Η μελάνη μπορεί να χρησιμοποιηθεί για να τονίσει άλλα αντικείμενα, να δείξει συνδέσεις και διαδικασίες, και να εστιάσει την προσοχή σε συγκεκριμένα στοιχεία σε μια διαφάνεια.

Το Aspose.Slides παρέχει τους τύπους που χρειάζεστε για την εργασία με αντικείμενα μελάνης. Για παράδειγμα, η διεπαφή [IInk](https://reference.aspose.com/slides/el/java/com.aspose.slides/iink/) αντιπροσωπεύει ένα αντικείμενο μελάνης σε μια διαφάνεια.

## **Διαφορές μεταξύ Κανονικών Αντικειμένων και Αντικειμένων Μελάνης**

Τα αντικείμενα σε μια διαφάνεια PowerPoint συνήθως αντιπροσωπεύονται από αντικείμενα σχήματος. Στη πιο απλή του μορφή, ένα σχήμα είναι ένας container που ορίζει την περιοχή του ίδιου του αντικειμένου (το πλαίσιο του) μαζί με ιδιότητες όπως το μέγεθος του container, το σχήμα και το φόντο. Για περισσότερες πληροφορίες, δείτε το [Shape Layout Format](https://docs.aspose.com/slides/el/java/shape-manipulations/#access-layout-formats-for-shape).

Ωστόσο, όταν το PowerPoint διαχειρίζεται ένα αντικείμενο μελάνης, αγνοεί όλες τις ιδιότητες του πλαισίου του αντικειμένου (container) εκτός από το μέγεθός του. Το μέγεθος της περιοχής του container καθορίζεται από τις τυπικές μεθόδους [IShape.getWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getWidth--) και [IShape.getHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Ίχνη Μελάνης**

Ένα ίχνος μελάνης είναι ένα βασικό στοιχείο που χρησιμοποιείται για την εγγραφή της τροχιάς μιας πένας καθώς ο χρήστης γράφει ψηφιακή μελάνη. Ένα ίχνος αποθηκεύει μια ακολουθία συνδεδεμένων σημείων.

Η πιο απλή μορφή κωδικοποίησης καθορίζει τις συντεταγμένες X και Y κάθε σημείου δειγματοληψίας. Όταν αποδοθούν όλα τα συνδεδεμένα σημεία, παράγουν μια εικόνα όπως αυτή:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ιδιότητες Πινέλου για Σχεδίαση**

Ένα πινέλο χρησιμοποιείται για το σχεδιασμό γραμμών που συνδέουν τα σημεία ενός ίχνους μελάνης. Το πινέλο έχει το δικό του χρώμα και μέγεθος, που αντιπροσωπεύονται από τις μεθόδους [IInkBrush.getColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkbrush/#getColor--) και [IInkBrush.getSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkbrush/#getSize--) .

### **Ορισμός Χρώματος Πινέλου Μελάνης**

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε το χρώμα ενός πινέλου μελάνης:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Γενικά, το πλάτος και το ύψος ενός πινέλου δεν ταιριάζουν, έτσι το PowerPoint δεν εμφανίζει το μέγεθος του πινέλου (η αντίστοιχη ενότητα δεδομένων είναι ακατέργαστη). Όταν το πλάτος και το ύψος του πινέλου ταιριάζουν, το PowerPoint εμφανίζει το μέγεθός του με αυτόν τον τρόπο:

![ink_powerpoint3](ink_powerpoint3.png)

Για σαφήνεια, ας αυξήσουμε το ύψος του αντικειμένου μελάνης και να εξετάσουμε τις σημαντικές διαστάσεις:

![ink_powerpoint4](ink_powerpoint4.png)

Το container (πλαίσιο) δεν λαμβάνει υπόψη το μέγεθος των πινέλων — πάντα υποθέτει ότι το πάχος της γραμμής είναι μηδέν (δείτε την προηγούμενη εικόνα).

Κατά συνέπεια, για να καθοριστεί η ορατή περιοχή ολόκληρου του αντικειμένου μελάνης, πρέπει να ληφθεί υπόψη το μέγεθος του πινέλου των ιχνηών του. Εδώ, το αντικείμενο-στόχος (το ίχνος του χειρόγραφου κειμένου) έχει κλιματοποιηθεί στο μέγεθος του container (πλαισίου). Όταν το μέγεθος του container αλλάζει, το μέγεθος του πινέλου παραμένει σταθερό, και αντίστροφα.

![ink_powerpoint5](ink_powerpoint5.png)

Το PowerPoint χρησιμοποιεί παρόμοια συμπεριφορά για αντικείμενα κειμένου:

![ink_powerpoint6](ink_powerpoint6.png)

## **Έλεγχος Εμφάνισης Μελάνης Κατά την Εξαγωγή και Απόδοση**

Το Aspose.Slides παρέχει τη διεπαφή [IInkOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/) για να ελέγξει πώς εμφανίζονται τα αντικείμενα μελάνης στην εξαγόμενη ή αποδοθείσα έξοδο. Μπορείτε να χρησιμοποιήσετε τις ιδιότητές της για να κρύψετε πλήρως τη μελάνη ή να αλλάξετε τον τρόπο ερμηνείας των λειτουργιών μάσκας πινέλου μελάνης.

Οι επιλογές μελάνης είναι διαθέσιμες μέσω των επιλογών εξαγωγής ή απόδοσης για πολλούς τύπους εξόδου:

| Έξοδος | Ιδιότητα επιλογών μελάνης |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/el/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/el/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/el/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/el/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Οι ακόλουθες μέθοδοι [IInkOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/) εκθέτουν τις ίδιες δύο ρυθμίσεις:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/#getHideInk--) καθορίζει εάν τα αντικείμενα μελάνης περιλαμβάνονται στην έξοδο. Η προεπιλεγμένη τιμή του είναι `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) καθορίζει εάν μια λειτουργία μάσκας ερμηνεύεται ως αδιαφάνεια κατά την απόδοση ενός πινέλου μελάνης. Η προεπιλεγμένη τιμή του είναι `true`; καλέστε [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) με `false` για να χρησιμοποιήσετε αντί αυτού τη λειτουργία ROP.

### **Απόκρυψη Αντικειμένων Μελάνης στην Έξοδο PDF**

Από προεπιλογή, τα αντικείμενα μελάνης παραμένουν ορατά κατά την εξαγωγή. Για να δημιουργήσετε μια καθαρή έξοδο χωρίς χειρόγραφες σημειώσεις ή άλλο περιεχόμενο μελάνης, καλέστε [IInkOptions.setHideInk](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) με `true`.

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

### **Απόκρυψη Αντικειμένων Μελάνης Κατά την Απόδοση μιας Διαφάνειας ως Εικόνας**

Για να κρύψετε αντικείμενα μελάνης κατά την απόδοση διαφανειών ως bitmap εικόνες, ρυθμίστε [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/renderingoptions/#getInkOptions--) και περάστε τις επιλογές απόδοσης στο [ISlide.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

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

Η ρύθμιση [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) ελέγχει πώς ερμηνεύονται οι λειτουργίες μάσκας κατά την απόδοση πινέλων μελάνης. Η προεπιλεγμένη τιμή είναι `true`, που χρησιμοποιεί αδιαφάνεια. Για χρήση της λειτουργίας ROP αντί αυτού, καλέστε [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) με `false`.

Ο ακόλουθος κώδικας Java εξάγει μια διαφάνεια σε SVG και χρησιμοποιεί απόδοση βασισμένη σε ROP για λειτουργίες μάσκας μελάνης:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Η ίδια ρύθμιση μπορεί να εφαρμοστεί μέσω του [TiffOptions.getInkOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/tiffoptions/#getInkOptions--) όταν εξάγετε μια παρουσίαση ή αποδίδετε μια διαφάνεια σε TIFF.

### **Επιλέξτε αν θα Κρύψετε ή θα Διατηρήσετε τη Μελάνη**

Όταν χρειάζεστε μια καθαρή έκδοση μιας σημειωμένης παρουσίασης για διανομή χωρίς σημεία αξιολόγησης, καλέστε [IInkOptions.setHideInk](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) με `true` κατά την εξαγωγή.

Αφήστε το [IInkOptions.getHideInk](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/#getHideInk--) στην προεπιλεγμένη τιμή του `false` όταν οι σημειώσεις μελάνης αποτελούν μέρος του προοριζόμενου περιεχομένου, όπως σχόλια αξιολόγησης, χειρόγραφες σημειώσεις, επισημάνσεις ή σχέδια που πρέπει να παραμείνουν ορατά στην εξαγόμενη έξοδο. Αυτό επιτρέπει στις εφαρμογές να δημιουργούν ξεχωριστές εξόδους αξιολόγησης και τελικές από την ίδια παρουσίαση χωρίς να τροποποιούν τα πηγαία αντικείμενα μελάνης.

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω το χρώμα ή το μέγεθος ενός υπάρχοντος στίγματος μελάνης;**

Ναι. Λάβετε το ίχνος από το [IInk.getTraces](https://reference.aspose.com/slides/el/java/com.aspose.slides/iink/#getTraces--), στη συνέχεια αλλάξτε το [IInkTrace.getBrush](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinktrace/#getBrush--). Καλέστε [IInkBrush.setColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) ή [IInkBrush.setSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) για να αλλάξετε το πινέλο.

**Η απόκρυψη της μελάνης αλλάζει την πηγαία παρουσίαση;**

Όχι. Η κλήση του [IInkOptions.setHideInk](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) επηρεάζει μόνο το αποδοθέν ή εξαγόμενο αποτέλεσμα· δεν αφαιρεί ή τροποποιεί τα αντικείμενα μελάνης στην πηγαία παρουσίαση.

**Ποιοι τύποι εξαγωγής υποστηρίζουν επιλογές μελάνης;**

Μπορείτε να ρυθμίσετε τις επιλογές μελάνης για PDF, HTML, SVG, TIFF και εικόνες διαφάνειας bitmap μέσω των αντίστοιχων επιλογών εξαγωγής ή απόδοσης που εμφανίζονται παραπάνω.

**Περαιτέρω ανάγνωση**

* Για γενικές πληροφορίες σχετικά με τα σχήματα, δείτε την ενότητα [PowerPoint Shapes](https://docs.aspose.com/slides/el/java/powerpoint-shapes/).
* Για περισσότερες πληροφορίες σχετικά με αποτελεσματικές τιμές, δείτε [Shape Effective Properties](https://docs.aspose.com/slides/el/java/shape-effective-properties/#get-effective-font-height-value).
* Για λεπτομέρειες εξαγωγής PDF, δείτε [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/el/java/convert-powerpoint-to-pdf/).
* Για λεπτομέρειες εξαγωγής HTML, δείτε [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/el/java/convert-powerpoint-to-html/).
* Για λεπτομέρειες εξαγωγής SVG, δείτε [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/el/java/render-a-slide-as-an-svg-image/).
* Για λεπτομέρειες εξαγωγής TIFF, δείτε [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/el/java/convert-powerpoint-to-tiff/).
* Για λεπτομέρειες απόδοσης διαφάνειας σε εικόνα, δείτε [Convert Presentation Slides to Images](https://docs.aspose.com/slides/el/java/convert-slide/).