---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις στο Android
linktitle: Πλαίσιο εικόνας
type: docs
weight: 10
url: /el/androidjava/picture-frame/
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
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργία, μορφοποίηση, σύνδεση, περικοπή, εξαγωγή και συμπίεση πλαισίων εικόνας σε παρουσιάσεις με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω του [IImageCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagecollection/), ενώ ένα [IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/) ελέγχει τη θέση, το μέγεθος, τη διαμόρφωση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διάσπαση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, διατηρήστε το επιστραφόμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας όταν δημιουργείτε πλαίσια εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνες όπως PNG ή JPEG και διανυσματικές SVG εικόνες. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, οπότε είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, έτσι η παρουσίαση παραμένει αυτόνομη όταν μεταφερθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια εικόνα JPEG, δημιουργεί ένα πλαίσιο στις φυσικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Το πλαίσιο εικόνας ελέγχει την εμφανιζόμενη γεωμετρία· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που είναι αποθηκευμένες στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόπτετε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση σχετικής κλίμακας**

[IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο μέσω των [setRelativeScaleWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τα τελικά διαστήματα με χειροκίνητο τρόπο.

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

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ούτε συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και επομένως είναι η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική θέση μέσω της μεθόδου [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα ενδέχεται να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να σταλούν μέσω email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

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

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε απλώς ως υποκατάστατο συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτόνομη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξάγετε μια εικόνα από υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πραγματικά ένα [IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας μπορεί να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ραστερ εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί απευθείας το [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) και δεν απαιτεί τον παλιό Java wrapper. Το παρακάτω παράδειγμα εντοπίζει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

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

Η αποθήκευση μέσω του [IImage.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που είναι αποθηκευμένα στην παρουσίαση αντί για ένα μετατρεπόμενο ραστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG εικόνας**

Για μια SVG εικόνα, το [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) εκθέτει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG απευθείας αντί να ραστεροποιήσετε την εικόνα πρώτα.

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

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές σε ραστερ όπως PNG ή JPEG απαραιτήτως αποδίδουν αυτό το διανυσματικό περιεχόμενο σε pixel. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης λειτουργία απόδοσης, έτσι τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφα byte‑από‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του [ISvgImage.getSvgData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgimage/#getSvgData--) όταν απαιτείται ο ίδιος ο διανυσματικός πόρος.

## **Περικοπή εικόνας**

Η περικοπή αλλάζει ποιο τμήμα μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [IPictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή αρχικά δεν διαγράφει τα κρυφά pixel από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει ένα πλαίσιο εικόνας με ασφάλεια και εφαρμόζει τιμές περικοπής:

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

Επειδή τα κρυφά δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να αλλάξει αργότερα χωρίς απώλεια των αρχικών pixel. Εάν το μέγεθος αρχείου είναι πιο σημαντικό από την αναστροφή, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων περικομμένης εικόνας**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρεμένα pixel δεν είναι πλέον διαθέσιμα για μετέπειτα ενέργεια «un‑crop».

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

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο, οπότε η διαγραφή περικομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεροποιεί το αποτέλεσμα σε PNG.

## **Συμπίεση ραστερ εικόνων**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) μειώνει την ανάλυση της ραστερ εικόνας σε σχέση με το μέγεθος με το οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα επαναμεγέθυνθηκε ή περικόπηκε και `false` όταν δεν απαιτήθηκε καμία αλλαγή.

Χρησιμοποιήστε μια προκαθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/picturescompression/) όταν μια τυπική στοχευμένη ανάλυση είναι επαρκής:

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

Μια προσαρμοσμένη θετική τιμή DPI μπορεί να περαστεί αντί για προκαθορισμένη τιμή όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το περιεχόμενο SVG και metafile δεν μειώνεται από αυτή τη διαδικασία συμπίεσης ραστερ. Επίσης, να θυμάστε ότι χαμηλότερη ανάλυση και διαγραμμένες περικομμένες περιοχές δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης βάσει του μεγαλύτερου μεγέθους στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Διαχείριση εφέ μετασχηματισμού εικόνας**

Για μια πλήρη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, χρωματικούς μετασχηματισμούς, θόλωση, εφέ άλφα, αλυσίδες ταξινόμησης, επιθεώρηση, αφαίρεση και επαλήθευση μεταξύ των βημάτων, δείτε [Image Transform Effects](/androidjava/image-transform-effects/).

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις του [IPictureFrameLock](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το [setAspectRatioLocked](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) διατηρεί τις αναλογίες του σχήματος κατά την αλλαγή μεγέθους.

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

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να μετατραπεί μόνιμα στην ίδια αναλογία.

## **Ρύθμιση τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι «stretch», οι τιμές stretch‑offset στο [IPictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/) ορίζουν το ορθογώνιο γέμισμα σε σχέση με το περιοριστικό κουτί του πλαισίου εικόνας. Τα θετικά ποσοστά δημιουργούν εσοχή από την άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν έξοδο.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι stretch offsets αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γέμισμα εικόνας.

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

Χρησιμοποιήστε stretch offsets για τοποθέτηση γεμίσματος. Χρησιμοποιήστε ιδιότητες περικοπής όταν ο στόχος είναι η απόκρυψη των άκρων της πηγαίας εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και παραμέτρους εξαγωγής**

Οι κύριες ανταλλαγές είναι πιο εύκολο να διαχειριστούν όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση διακομιστή, αλλά οι μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να κρατήσουν το πακέτο μικρότερο, όμως η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή θέσεις.
- **Περικοπή** αρχικά είναι μη‑καταστροφική. Τα κρυφά pixel παραμένουν ενσωματωμένα μέχρι να διαγραφούν ρητά οι περικομμένες περιοχές ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθη ραστερ εικόνες, αλλά θυσιάζει την αρχική ανάλυση. Θα πρέπει να εφαρμοστεί μετά τον καθορισμό του επιθυμητού μεγέθους στην διαφάνεια.
- **SVG εικόνες** θα πρέπει να παραμείνουν ως SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι εξαγωγές διαφανειών σε ραστερ πάντα μετατρέπουν τη διαφανεια σε pixel.
- **Επαναλαμβανόμενες εικόνες** θα πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) όταν είναι δυνατόν, αντί να φορτώνουν ξανά το ίδιο αρχείο στη ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν γίνεται επιλεκτικά: κρατήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες σύμφωνα με το πραγματικό μέγεθος εμφάνισης, αφαιρέστε περικομμένα pixel μόνο όταν δεν απαιτείται μετέπειτα επεξεργασία, και αποφύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδιασμού ανάπτυξης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου εικόνας και πόρου εικόνας;**

Ένα [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) αντιπροσωπεύει έναν πόρο εικόνας που σχετίζεται με την παρουσίαση. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/) είναι ένα σχήμα σε διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώνω ή να συνδέω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή να αποδίδεται χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές θέσεις μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του αρχείου PPTX;**

Δίχως πρόσθετες ενέργειες όχι. Οι κανονικές ρυθμίσεις περικοπής κρύβουν τμήματα της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε το [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ή τη συμπίεση εικόνας με αφαίρεση περιοχών περικοπής όταν αυτά τα pixel μπορούν να διαγραφούν μόνιμα.

**Μπορώ να επαναφέρω την ποιότητα της εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγή εικόνας εκτός της παρουσίασης εάν ενδέχεται να απαιτηθεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις SVG εικόνες;**

Κρατήστε το περιεχόμενο SVG ως SVG όταν η ακρίβεια του διανύσματος είναι σημαντική. Το ενσωματωμένο [ISvgImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε ραστερ μορφή όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας της διαφάνειας.

**Πώς να αποφύγω μη ασφαλείς μετατροπές τύπων όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Ένας έλεγχος `instanceof` κατά του [IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/) αποτρέπει μη έγκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.