---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις με Java
linktitle: Πλαίσιο εικόνας
type: docs
weight: 10
url: /el/java/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- ενσωματωμένη εικόνα
- συνδεδεμένη εικόνα
- εξαγωγή εικόνας
- εικόνα ράστερ
- εικόνα SVG
- περικοπή εικόνας
- διαγραφή περικομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- λόγος διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, περικόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: μια [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω του [IImageCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagecollection/), ενώ ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις σε επίπεδο πλαισίου.

Αυτός ο διαχωρισμός είναι χρήσιμος όταν η ίδια εικόνα εμφανίζεται περισσότερο από μία φορά. Προσθέστε την εικόνα στην παρουσίαση μία φορά, διατηρήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας κατά τη δημιουργία πλαισίων εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ράστερ εικόνες όπως PNG ή JPEG και διανυσματικές SVG εικόνες. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή επηρεάζει τη φορητότητα, το μέγεθος αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, γι’ αυτό είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευθεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και Μορφοποίηση Ενσωματωμένης Εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα της εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, έτσι η παρουσίαση παραμένει αυτόνομη όταν μεταφερθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια JPEG εικόνα, δημιουργεί ένα πλαίσιο στις εγγενείς διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν προχωράτε σε περικοπή ή συμπίεση μιας εικόνας αργότερα.

## **Χρήση Σχετικής Κλίμακας**

[IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο μέσω [setRelativeScaleWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Μια τιμή του `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει χειροκίνητα τις τελικές διαστάσεις.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ή συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και Συνδεδεμένες Εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και αποτελεί επομένως την πιο ασφαλή επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική τοποθεσία μέσω της μεθόδου [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα ενδέχεται να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να αποσταλούν μέσω email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη Συνδεδεμένης Εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το κατευθύνει σε ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή μέσων και σκόπιμα δεν αναμειγνύεται σε αυτό το παράδειγμα.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιείτε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως αντικατάσταση για συμπίεση: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτόνομη παρουσίαση.

## **Εξαγωγή Εικόνων από Πλαίσια Εικόνας**

Πριν εξαγάγετε μια εικόνα από μια υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πραγματικά ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή Ράστερ Εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί άμεσα το [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) και δεν απαιτεί το παλαιό Java image wrapper. Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη ράστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Η αποθήκευση μέσω του [IImage.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/#save-java.lang.String-int-) μετατρέπει την εξαγόμενη εικόνα στην ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που αποθηκεύονται στην παρουσίαση αντί για ένα μετασχηματισμένο ράστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG Εικόνας**

Για μια SVG εικόνα, το [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) εκθέτει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα SVG δεδομένα απευθείας αντί να ραστεροποιήσετε πρώτα την εικόνα.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Η διατήρηση του SVG περιεχομένου ως SVG διασφαλίζει τη διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές ράστερ όπως PNG ή JPEG απαιτούν την απόδοση του διανυσματικού περιεχομένου σε pixels. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης λειτουργία απόδοσης, επομένως τα εξαγώμενα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφα byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του ενσωματωμένου [ISvgImage.getSvgData](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/#getSvgData--) όταν απαιτείται ο ίδιος ο διανυσματικός πόρος.

## **Κόψιμο Εικόνας**

Η περικοπή αλλάζει ποιο μέρος μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [IPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή αρχικά δεν διαγράφει τα κρυμμένα pixels από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει με ασφάλεια ένα πλαίσιο εικόνας και εφαρμόζει τιμές περικοπής:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Καθώς τα κρυφά δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να τροποποιηθεί αργότερα χωρίς απώλεια των αρχικών pixels. Εάν το μέγεθος του αρχείου είναι πιο σημαντικό από τη δυνατότητα αντιστροφής, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Κατάργηση Δεδομένων Κομμένων Εικόνων**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) αφαιρεί δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα διαγραμμένα pixels δεν είναι πλέον διαθέσιμα για μετέπειτα ανπέρικοπηση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υφιστάμενο πόρο, επομένως η διαγραφή των περιοχών περικοπής δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεροποιεί το αποτέλεσμα σε PNG.

## **Συμπίεση Ράστερ Εικόνων**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) μειώνει την ανάλυση της ράστερ εικόνας σε σχέση με το μέγεθος με το οποίο εμφανίζεται η εικόνα. Μπορεί επίσης να αφαιρέσει τις περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα ελήφθη σε νέο μέγεθος ή περικόπηκε και `false` όταν δεν απαιτήθηκε καμία αλλαγή.

Χρησιμοποιήστε μια προκαθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturescompression/) όταν είναι επαρκής μια τυπική στόχευση ανάλυσης:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Μπορείτε να περάσετε μια προσαρμοσμένη θετική τιμή DPI αντί για προκαθορισμένη τιμή όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ράστερ εικόνες. Το περιεχόμενο SVG και των μετααρχείων δεν μειώνεται από αυτή τη ροή συμπίεσης ράστερ. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες περιοχές περικοπής δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης βάσει του μεγαλύτερου μεγέθους στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί στην πράξη, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Επιθεώρηση Εφέ Εικόνας**

Τα εφέ εικόνας αποθηκεύονται στην εικόνα που χρησιμοποιείται από το πλαίσιο. Η συλλογή μετασχηματισμών εικόνας μπορεί να περιλαμβάνει εφέ όπως σταθερή διαμόρφωση άλφα για διαφάνεια και φωτεινότητα/αντίθεση για λάμψη. Το παρακάτω παράδειγμα διαβάζει με ασφάλεια και τις δύο κατηγορίες εφέ από το πρώτο πλαίσιο εικόνας σε μια διαφάνεια:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Αυτά τα εφέ αλλάζουν τον τρόπο απόδοσης της εικόνας στο πλαίσιο· δεν επανεγγράφουν τα αρχικά ενσωματωμένα bytes της εικόνας.

## **Κλείδωμα Γεωμετρίας Πλαισίου Εικόνας**

Οι ρυθμίσεις του [IPictureFrameLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, η μέθοδος [setAspectRatioLocked](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) διατηρεί τις αναλογίες του σχήματος κατά τη μεταβολή μεγέθους.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγή εικόνας να επαναδειγματοληπτεί ή να μεταβληθεί μόνιμα στην ίδια αναλογία διαστάσεων.

## **Ρύθμιση Τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι «stretch», οι τιμές stretch‑offset στο [IPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) ορίζουν το γεωμετρικό ορθογώνιο γεμίσματος σε σχέση με το οριακό πλαίσιο του πλαισίου εικόνας. Τα θετικά ποσοστά δημιουργούν εσοχή από την άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν προεξοχή.

Αυτή η λειτουργία διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο μέρος της πηγαίας εικόνας είναι ορατό· οι τιμές stretch‑offset αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γεμίσμα εικόνας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε τα stretch‑offset για τοποθέτηση γεμίσματος. Χρησιμοποιήστε τις ιδιότητες περικοπής όταν ο στόχος είναι η απόκρυψη των άκρων της πηγαίας εικόνας.

## **Αποθήκευση, Μέγεθος Αρχείου και Σκέψεις Εξαγωγής**

Οι κύριες ανταλλαγές είναι πιο εύκολο να διαχειριστούν όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται χωριστά:

- **Embedded images** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση από διακομιστή, αλλά οι μεγάλες ράστερ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Linked images** μπορούν να κρατήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμείνουν διαθέσιμα στις αποθηκευμένες διαδρομές ή τοποθεσίες.
- **Cropping** είναι αρχικά μη καταστροφική. Τα κρυφά pixels παραμένουν ενσωματωμένα μέχρι να διαγραφούν ρητά οι περικομμένες περιοχές ή να αφαιρεθούν κατά τη συμπίεση.
- **Compression** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθη ράστερ εικόνες, αλλά ανταλλάσσει την πηγαία ανάλυση. Θα πρέπει να εφαρμοστεί μετά την καθορισμένη στο διαφάνειας διάσταση.
- **SVG images** πρέπει να παραμένουν ως SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι εξαγωγές διαφάνειας σε ράστερ όπως PNG ή JPEG πάντα μετατρέπουν την απόδοση της διαφάνειας σε pixels.
- **Repeated images** πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [IPPImage] όταν είναι δυνατόν, αντί να φορτώνουν επανειλημμένα το ίδιο αρχείο στην ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν γίνεται επιλεκτικά: διατηρήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε τις φωτογραφίες σύμφωνα με το πραγματικό μέγεθος προβολής, αφαιρέστε τα περικομμένα pixels μόνο όταν δεν απαιτείται μετέπειτα επεξεργασία και αποφύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδίου ανάπτυξης.

## **ΣΥΝΗΘΕΣΜΕΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου εικόνας και ενός πόρου εικόνας;**

Ένα [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) είναι ένα σχήμα σε μια διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώνω ή να συνδέω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδοθεί χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές τοποθεσίες μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν τμήματα της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixels. Χρησιμοποιήστε τη μέθοδο [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ή τη συμπίεση εικόνας με αφαίρεση περιοχών περικοπής όταν αυτά τα pixels μπορούν να απορριφθούν μόνιμα.

**Μπορώ να επαναφέρω την ποιότητα της εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ράστερ ανάλυση και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγαία εικόνα εκτός της παρουσίασης εάν μπορεί να χρειαστεί μετά για επεξεργασία υψηλής ανάλυσης.

**Πώς πρέπει να διαχειρίζομαι τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η διανυσματική πιστότητα είναι σημαντική. Το ενσωματωμένο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/) μπορεί να εξαχθεί άμεσα. Η απόδοση μιας διαφάνειας σε ράστερ μορφή όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπων όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Μια έλεγχος `instanceof` εναντίον του [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) αποτρέπει μη έγκυρες μετατροπές τύπων και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.