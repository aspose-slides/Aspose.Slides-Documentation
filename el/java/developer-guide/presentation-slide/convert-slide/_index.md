---
title: Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες σε Java
linktitle: Διαφάνεια σε εικόνα
type: docs
weight: 35
url: /el/java/convert-slide/
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
- παρουσίαση
- Java
- Aspose.Slides
description: "Μετατροπή διαφανειών από παρουσιάσεις PPT, PPTX και ODP σε PNG, JPEG, GIF, TIFF, EMF και άλλες μορφές εικόνας σε Java με Aspose.Slides."
---
## **Εισαγωγή**

Το Aspose.Slides for Java μπορεί να αποδίδει μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument ως PNG, JPEG, GIF, TIFF και άλλες μορφές εικόνας.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα εξής βήματα:

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
2. Επιλέξτε τη διαφάνεια που θέλετε να αποδώσετε.
3. Αν χρειάζεται, διαμορφώστε την απόδοση με την κλάση [RenderingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/renderingoptions/) ή την κλάση [TiffOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/tiffoptions/).
4. Κληλώστε τη μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#getImage--) . Επιστρέφει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/).
5. Κληλώστε τη μέθοδο [IImage.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/#save-java.lang.String-int-) και καθορίστε τη μορφή εξόδου με μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/imageformat/).

## **Μετατροπή μιας Διαφάνειας σε Εικόνα PNG**

Η πιο απλή μετατροπή χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις απόδοσης. Το προκύπτον αντικείμενο [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) μπορεί να επεξεργαστεί στη μνήμη ή να αποθηκευτεί σε αρχείο.

Το παρακάτω παράδειγμα Java αποδίδει την πρώτη διαφάνεια και την αποθηκεύει ως εικόνα PNG:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή Διαφανειών σε Εικόνες με Προσαρμοσμένα Μεγέθη**

Χρησιμοποιήστε την υπερφόρτωση της [ISlide.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) που δέχεται μια τιμή [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) για να αποδώσετε μια διαφάνεια με ακριβείς διαστάσεις εικονοστοιχείων.

Το παρακάτω παράδειγμα δημιουργεί μια εικόνα JPEG 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή Διαφανειών με Σημειώσεις και Σχόλια σε Εικόνες**

Από προεπιλογή, οι εικόνες διαφανειών δεν περιλαμβάνουν σημειώσεις ή σχόλια. Περνάτε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/notescommentslayoutingoptions/) στη μέθοδο [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) για να ελέγξετε πού εμφανίζονται οι σημειώσεις και τα σχόλια.

Το παρακάτω παράδειγμα τοποθετεί περικομμένες σημειώσεις κάτω από τη διαφάνεια και σχόλια στα δεξιά της:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Για τη μετατροπή διαφάνειας σε εικόνα, μην περάσετε το [BottomFull](https://reference.aspose.com/slides/el/java/com.aspose.slides/notespositions/) στη μέθοδο [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/el/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Οι σημειώσεις μπορεί να περιέχουν περισσότερο κείμενο από ό,τι μπορεί να φιλοξενήσει το σταθερό μέγεθος εικόνας. Χρησιμοποιήστε το [BottomTruncated](https://reference.aspose.com/slides/el/java/com.aspose.slides/notespositions/) αντ' αυτού.
{{% /alert %}}

## **Μετατροπή Διαφανειών σε Εικόνες με Χρήση Επιλογών TIFF**

Η κλάση [TiffOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/tiffoptions/) σας επιτρέπει να ελέγξετε το μέγεθος, την ανάλυση και άλλες ιδιότητες της αποδοθένσης εικόνας TIFF.

Το παρακάτω παράδειγμα αποδίδει την πρώτη διαφάνεια ως εικόνα TIFF 2160 × 2880 στα 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
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

## **Μετατροπή Όλων των Διαφανειών σε Εικόνες**

Διέλθετε τη συλλογή διαφανειών για να μετατρέψετε ολόκληρη την παρουσίαση σε μια σειρά εικόνων. Οι κρυμμένες διαφάνειες περιλαμβάνονται εκτός εάν τις παραλείψετε ρητά.

Το παρακάτω παράδειγμα αποδίδει κάθε διαφάνεια ως εικόνα JPEG με οριζόντιους και κατακόρυφους συντελεστές κλίμακας 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Δημιουργία Εξόδου Enhanced Metafile**

Το Enhanced Metafile (EMF) είναι χρήσιμο όταν γραφικά βασισμένα σε διανύσματα πρέπει να ανταλλαγούν με το Microsoft Office ή άλλα προγράμματα των Windows που υποστηρίζουν Windows metafiles. Σε αντίθεση με μια εικόνα βασισμένη σε εικονοστοιχεία, ένα EMF μπορεί να διατηρήσει τις ενέργειες διανυσματικών σχεδίων που κλιμακώνται χωρίς την ίδια απώλεια ευκρίνειας. Ωστόσο, το EMF είναι κυρίως μορφή συμβατότητας για εφαρμογές με υποστήριξη Windows metafile, όχι μια καθολική μορφή ανταλλαγής. Επιπλέον, πολύπλοκο περιεχόμενο διαφάνειας, όπως bitmap εικόνες και ορισμένα εφέ, μπορεί να αποθηκευτεί ως ραστροποιημένα στοιχεία μέσα στο διανυσματικό κοντέινερ metafile.

### **Εξαγωγή Διαφάνειας σε EMF**

Η μέθοδος [ISlide.writeAsEmf](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) γράφει ένα [ISlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/) σε έναν προορισμό ροής σε μορφή EMF. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, επιλέγει την πρώτη διαφάνεια και τη γράφει σε ροή αρχείου EMF:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Ο καλών είναι κάτοχος της ροής που περνά στην [ISlide.writeAsEmf](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) και είναι υπεύθυνος για το κλείσιμο της, όπως φαίνεται παραπάνω.

### **Μετατροπή Εικόνας SVG σε EMF και Προσθήκη της σε Παρουσίαση**

Χρησιμοποιήστε το [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) για να μετατρέψετε περιεχόμενο SVG σε EMF. Τα προκύπτοντα bytes μπορούν να προστεθούν στην παρουσίαση μέσω του [IImageCollection.addImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) και να τοποθετηθούν σε μια διαφάνεια με το [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Το παρακάτω παράδειγμα δημιουργεί ένα [SvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/svgimage/) από κώδικα SVG, το μετατρέπει σε EMF στη μνήμη, εισάγει το metafile στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) δεν αναλαμβάνει την ιδιοκτησία του ρεύματος προορισμού. Ένα [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) αποθηκεύει όλα τα παραγόμενα δεδομένα στη μνήμη, έτσι δεν απαιτείται επαναφορά θέσης πριν την κλήση του `toByteArray`. Ο επιστρεφόμενος πίνακας byte παραμένει έγκυρος μετά το κλείσιμο του ρεύματος.

Η δημιουργία EMF είναι διαθέσιμη στα λειτουργικά συστήματα που υποστηρίζονται από την επιλεγμένη παραμετροποίηση Aspose.Slides for Java και JDK, αλλά η απόδοση μπορεί να διαφέρει μεταξύ πλατφορμών όταν λείπουν γραμματοσειρές ή εξαρτήσεις γραφικών. Εγκαταστήστε τις γραμματοσειρές που χρησιμοποιούνται από το πηγαίο περιεχόμενο ή διαμορφώστε κατάλληλες αντικαταστάσεις, ακολουθήστε τις [πλατφορμικές απαιτήσεις](/slides/el/java/system-requirements/) για το Aspose.Slides for Java, και επαληθεύστε το αποτέλεσμα στην εφαρμογή‑καταναλωτή EMF. Οι εφαρμογές Linux και macOS συχνά έχουν περιορισμένη ή ασυνεπή υποστήριξη για εμφάνιση και επεξεργασία Windows metafiles.

## **Απόδοση Χρωματικών Emoji**

{{% alert title="Note" color="info" %}}
Για να αποδώσετε σωστά χρωματικά emoji όταν μετατρέπετε διαφάνειες παρουσίασης σε εικόνες, οι γραμματοσειρές emoji που χρησιμοποιούνται στην παρουσίαση πρέπει να είναι εγκατεστημένες και διαθέσιμες στο σύστημα που εκτελεί τη μετατροπή. Για παράδειγμα, εάν η παρουσίαση χρησιμοποιεί **Segoe UI Emoji** και αυτή η γραμματοσειρά λείπει, τα emoji μπορεί να εμφανιστούν μονόχρωμα στις εικόνες εξόδου.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides την απόδοση διαφανειών με κινούμενα στοιχεία;**

Όχι. Η μέθοδος [ISlide.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#getImage--) αποδίδει μια στατική εικόνα της διαφάνειας και δεν εξάγει τις κινήσεις.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι. Οι κρυμμένες διαφάνειες μπορούν να αποδοθούν όπως οι κανονικές διαφάνειες. Συμπεριλάβετε τις στον βρόχο επεξεργασίας, όπως φαίνεται στο παραπάνω παράδειγμα.

**Διατηρούνται οι σκιές και άλλα εφέ στις εικόνες διαφανειών;**

Ναι. Το Aspose.Slides αποδίδει σκιές, διαφάνειες και άλλα υποστηριζόμενα γραφικά εφέ στις εικόνες διαφανειών.