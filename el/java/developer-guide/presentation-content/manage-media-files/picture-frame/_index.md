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
- ραστερ εικόνα
- SVG εικόνα
- περικοπή εικόνας
- διαγραφή περικομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετικό κλιμάκωμα
- εφέ εικόνας
- αναλογία διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: Δημιουργία, μορφοποίηση, σύνδεση, περικοπή, εξαγωγή και συμπίεση πλαισίων εικόνας σε παρουσιάσεις με Aspose.Slides για Java.
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) διαχειρίζεται ενσωματωμένους πόρους εικόνας μέσω της [IImageCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagecollection/), ενώ ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διάκριση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας κατά τη δημιουργία πλαισίων εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνες όπως PNG ή JPEG και διάνυσμα SVG. Μπορούν επίσης να παραπέμπουν σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή επηρεάζει τη φορητότητα, το μέγεθος αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, γι' αυτό είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν την εφαρμογή μορφοποίησης ή βελτιστοποίησης.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, ώστε η παρουσίαση να παραμένει αυτόνομα ενσωματωμένη όταν μεταφερθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια εικόνα JPEG, δημιουργεί ένα πλαίσιο στις φυσικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

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

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόπτετε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση σχετικού κλιμακώματος**

[IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) εκθέτει σχετικό κλιμάκωμα πλάτους και ύψους για το πλαίσιο μέσω των [setRelativeScaleWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους εικόνας. Το σχετικό κλιμάκωμα είναι χρήσιμο όταν μια ροή εργασίας χρειάζεται να διατηρήσει μια σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τελικά διαστάσεις χειροκίνητα.

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

Το σχετικό κλιμάκωμα αλλάζει τις ρυθμίσεις κλιμάκωσης του πλαισίου· δεν επαναδειγματοληπτεί ούτε συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και επομένως είναι η ασφαλέστερη επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική θέση μέσω της μεθόδου [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν τον όγκο των δεδομένων εικόνας που αποθηκεύεται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Αν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος γίνει μη διαθέσιμος, η συνδεδεμένη εικόνα ενδέχεται να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να αποσταλούν με email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το συνδέει με ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμιγνύεται σε αυτό το παράδειγμα.

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

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως υποκατάστατο συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη, αυτόνομα ενσωματωμένη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξαγάγετε μια εικόνα από υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πραγματικά ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ραστερ εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί άμεσα το [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) και δεν απαιτεί το παλιότερο Java image wrapper. Το παρακάτω παράδειγμα εντοπίζει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

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

Η αποθήκευση μέσω του [IImage.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/#save-java.lang.String-int-) μετατρέπει την εξαγόμενη εικόνα στην ζητούμενη μορφή εξόδου. Αν χρειάζεστε τα κωδικοποιημένα bytes που αποθηκεύονται στην παρουσίαση αντί για ένα μετατρεπόμενο ραστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή εικόνας SVG**

Για μια εικόνα SVG, το [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) εκθέτει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG άμεσα αντί να ραστεροποιήσετε την εικόνα πρώτα.

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

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές ραστερ όπως PNG ή JPEG υποχρεωτικά αποδίδουν αυτό το διανυσματικό περιεχόμενο σε pixels. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης μια διαδικασία απόδοσης, επομένως τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται ακριβές byte‑for‑byte αντίγραφο του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τη μέθοδο [ISvgImage.getSvgData](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/#getSvgData--) όταν απαιτείται ο ίδιος ο διανυσματικός πόρος.

## **Περικοπή εικόνας**

Η περικοπή αλλάζει ποιο τμήμα της εικόνας είναι ορατό εντός του πλαισίου. Οι τιμές περικοπής στο [IPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή αρχικά δεν διαγράφει τα κρυφά pixels από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει με ασφάλεια ένα πλαίσιο εικόνας και εφαρμόζει τις τιμές περικοπής:

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

Επειδή τα κρυφά δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να αλλάξει αργότερα χωρίς να χαθούν τα αρχικά pixels. Αν το μέγεθος αρχείου έχει μεγαλύτερη σημασία από την αντιστροφικότητα, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Κατάργηση δεδομένων περικομμένης εικόνας**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: αφού η παρουσίαση αποθηκευτεί, τα αφαιρεθέντα pixels δεν είναι πλέον διαθέσιμα για μετέπειτα ενέργειες «από-περίκοψη».

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

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Αν η αρχική εικόνα χρησιμοποιείται και από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο, έτσι η διαγραφή περιοχών περικοπής δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεροποιεί το περικομμένο αποτέλεσμα σε PNG.

## **Συμπίεση ραστερ εικόνων**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) μειώνει την ανάλυση ραστερ εικόνας σε σχέση με το μέγεθος με το οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει περιοχές περικοπής στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα μεταβλήθηκε σε μέγεθος ή περικόπη και `false` όταν δεν απαιτήθηκε αλλαγή.

Χρησιμοποιήστε μια προκαθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturescompression/) όταν μια τυπική στόχευμένη ανάλυση αρκεί:

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

Μπορείτε επίσης να περάσετε μια προσαρμοσμένη θετική τιμή DPI αντί για προκαθορισμένη τιμή όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το περιεχόμενο SVG και μεταφίλων δεν μειώνεται από αυτή τη ρευστική συμπίεση. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες περιοχές περικοπής δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης βάσει του μεγαλύτερου μεγέθους στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Διαχείριση εφέ μετασχηματισμού εικόνας**

Για έναν πλήρη οδηγό που καλύπτει φωτεινότητα, αντίθεση, μετασχηματισμούς χρώματος, θόλωση, εφέ άλφα, αλυσίδες εντολών, έλεγχο, αφαίρεση και επαλήθευση «round‑trip», δείτε [Image Transform Effects](/slides/el/java/image-transform-effects/).

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις του [IPictureFrameLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframelock/) ελέγχουν ποιες ενέργειες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το [setAspectRatioLocked](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) διατηρεί τις αναλογίες του σχήματος ενώ το μέγεθός του αλλάζει.

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

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν επιβάλλει την επαναδειγματοληψία ή μόνιμη αλλαγή της πηγαίας εικόνας ώστε να ταιριάζει στο ίδιο λόγο διαστάσεων.

## **Ρύθμιση τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι «stretch», οι τιμές stretch‑offset στο [IPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) ορίζουν το ορθογώνιο γεμίσματος σε σχέση με το πλαίσιο του πλαισίου εικόνας. Τα θετικά ποσοστά δημιουργούν εσωτερικό περιθώριο από την άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν εξωτερικό περιθώριο.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι offset διαστέλλουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γέμισμα εικόνας.

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

Χρησιμοποιήστε stretch offsets για τοποθέτηση γεμίσματος. Χρησιμοποιήστε ιδιότητες περικοπής όταν ο στόχος είναι η απόκρυψη άκρων της πηγαίας εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και σκέψεις εξαγωγής**

Οι κύριες ανταλλαγές είναι πιο εύκολο να διαχειριστούν όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου αντιμετωπίζονται χωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομα ενσωματωμένη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση στην πλευρά του διακομιστή, αλλά μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή τοποθεσίες.
- **Περικοπή** είναι αρχικά μη καταστροφική. Τα κρυφά pixels παραμένουν ενσωματωμένα μέχρι οι περικομμένες περιοχές να διαγραφούν ρητά ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος αρχείου για υπερμεγέθη ραστερ εικόνες, αλλά θυσιάζει την αρχική ανάλυση. Θα πρέπει να εφαρμοστεί αφού το επιδιωκόμενο μέγεθος στην διαφάνεια είναι γνωστό.
- **Εικόνες SVG** θα πρέπει να παραμείνουν ως SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG άμεσα όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι εξαγωγές διαφανειών σε ραστερ πάντα μετατρέπουν τη διαφάνεια σε pixels.
- **Επαναλαμβανόμενες εικόνες** πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) όποτε είναι δυνατόν αντί να φορτώνουν ξανά το ίδιο αρχείο στη ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν γίνεται επιλεκτικά: κρατήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες σύμφωνα με το πραγματικό μέγεθος εμφάνισής τους, αφαιρέστε περικομμένα pixels μόνο όταν δεν απαιτείται μετέπειτα επεξεργασία, και αποφύγετε εξωτερικούς συνδέσμους εκτός αν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδίου ανάπτυξης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου εικόνας και πόρου εικόνας;**

Ένα [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) είναι ένα σχήμα σε διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώνω ή να συνδέω τις εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδοθεί χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές τοποθεσίες μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν μέρη της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixels. Χρησιμοποιήστε το [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ή τη συμπίεση εικόνας με αφαίρεση περιοχών περικοπής όταν αυτά τα pixels μπορούν να διαγραφούν μόνιμα.

**Μπορώ να αποκαταστήσω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση, και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγή εικόνας έξω από την παρουσίαση αν μπορεί να χρειαστεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις εικόνες SVG;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η διανυσματική πιστότητα μετράει. Το ενσωματωμένο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/) μπορεί να εξαχθεί άμεσα. Η απόδοση μιας διαφάνειας σε ραστερ μορφή όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας της διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπων όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Μια δοκιμή `instanceof` κατά του [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) αποτρέπει μη έγκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειρίζεται διαφάνειες που δεν περιέχουν πλαίσια εικόνας.