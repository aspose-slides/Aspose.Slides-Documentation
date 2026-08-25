---
title: Διαχείριση Πλαισίων Εικόνας σε Παρουσιάσεις με Java
linktitle: Πλαίσιο Εικόνας
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
- κοπή εικόνας
- διαγραφή κομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, κόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: μια [Παρουσίαση](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) διαχειρίζεται ενσωματωμένους πόρους εικόνας μέσω της [IImageCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagecollection/), ενώ ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την κοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διάσπαση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας όταν δημιουργείτε πλαίσια εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνες όπως PNG ή JPEG και διανυσματικές εικόνες SVG. Μπορούν επίσης να παραπέμπουν σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, οπότε είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με την [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, έτσι η παρουσίαση παραμένει αυτόνομη όταν μεταφερθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια εικόνα JPEG, δημιουργεί πλαίσιο στις εγγενείς διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

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

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις εικονοστοιχείων που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόπτετε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση σχετικής κλίμακας**

Το [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο μέσω των [setRelativeScaleWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας πρέπει να διατηρεί τη σχέση με το μέγεθος της πηγής αντί να υπολογίζει τις τελικές διαστάσεις χειροκίνητα.

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

Η σχετική κλίμακα τροποποιεί τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ή συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα της μέσα στην παρουσίαση και είναι επομένως η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική θέση μέσω της μεθόδου [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) αντί να ενσωματώνει τα δεδομένα της εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα δεδομένων εικόνας που αποθηκεύεται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Αν αλλάξει η διαδρομή, μεταφερθεί το αρχείο ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα μπορεί να μην εμφανιστεί όπως αναμενόταν. Για παρουσιάσεις που πρέπει να αποσταλούν μέσω email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το κατευθύνει σε τοπικό αρχείο εικόνας. Ασχολείται μόνο με σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμειγνύεται σε αυτό το παράδειγμα.

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

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε απλώς ως αντικατάσταση συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη, αυτόνομη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξάγετε μια εικόνα από υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πραγματικά ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας μπορεί να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ραστερ εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί άμεσα το [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) και δεν απαιτεί το παλαιότερο Java image wrapper. Το παρακάτω παράδειγμα εντοπίζει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

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

Η αποθήκευση μέσω του [IImage.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/#save-java.lang.String-int-) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Αν χρειάζεστε τα κωδικοποιημένα bytes που είναι αποθηκευμένα στην παρουσίαση αντί για ένα μετατρεπόμενο ραστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG εικόνας**

Για μια SVG εικόνα, το [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) εκθέτει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG απευθείας αντί να ραστεροποιήσετε την εικόνα πρώτα.

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

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι ραστερ εξαγωγές όπως PNG ή JPEG μετατρέπουν υποχρεωτικά το διανυσματικό περιεχόμενο σε pixels. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης μια λειτουργία απόδοσης, οπότε τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφο byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του ενσωματωμένου [ISvgImage.getSvgData](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/#getSvgData--) όταν απαιτείται ο ίδιος ο διανυσματικός πόρος.

## **Κοπή εικόνας**

Η κοπή αλλάζει ποιο τμήμα μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές κοπής στο [IPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η κοπή δεν διαγράφει αρχικά τα κρυμμένα pixels από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει ένα πλαίσιο εικόνας με ασφάλεια και εφαρμόζει τιμές κοπής:

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

Επειδή τα κρυφά δεδομένα εικόνας παραμένουν, η κοπή μπορεί να τροποποιηθεί αργότερα χωρίς απώλεια των αρχικών pixels. Αν το μέγεθος αρχείου είναι πιο σημαντικό από την αναστρεψιμότητα, οι κομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων κομμένων εικόνων**

Η μέθοδος [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) αφαιρεί δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου κοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά είναι μια καταστροφική βελτιστοποίηση: αφού η παρουσίαση αποθηκευτεί, τα αφαιρεθέντα pixels δεν είναι πλέον διαθέσιμα για μεταγενέστερη λειτουργία “αποκοπής”.

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

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Αν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο, έτσι η διαγραφή των κομμένων περιοχών δεν μειώνει απαραίτητα το συνολικό αριθμό εικόνων. Η κοπή WMF ή EMF περιεχομένου με αυτή τη μέθοδο ραστεροποιεί το αποτέλεσμα σε PNG.

## **Συμπίεση ραστερ εικόνων**

Η μέθοδος [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) μειώνει την ανάλυση ραστερ εικόνας σε σχέση με το μέγεθος με το οποίο εμφανίζεται η εικόνα. Μπορεί επίσης να αφαιρέσει περιοχές κοπής στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα επαναμεγέθυνθηκε ή κοπήθηκε και `false` όταν δεν απαιτήθηκε καμία αλλαγή.

Χρησιμοποιήστε μια προ‑καθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturescompression/) όταν μια τυπική ανάλυση στόχου είναι επαρκής:

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

Μπορείτε αντί αυτού να περάσετε μια προσαρμοσμένη θετική τιμή DPI όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το περιεχόμενο SVG και metafile δεν μειώνεται από αυτή τη διαδικασία ραστερ συμπίεσης. Επίσης, να θυμάστε ότι χαμηλότερη ανάλυση και διαγραμμένες κομμένες περιοχές δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε την ανάλυση στόχου βάσει του μεγαλύτερου μεγέθους με το οποίο η εικόνα θα προβληθεί ή εξαχθεί, αντί να εφαρμόζετε το μικρότερο DPI παγκοσμίως.

## **Διαχείριση εφ effets μετασχηματισμού εικόνας**

Για μια πλήρη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, μετασχηματισμούς χρώματος, θόλωση, εφ effects άλφα, ακολουθίες, έλεγχο, αφαίρεση και επαλήθευση κύκλου, δείτε [Image Transform Effects](/java/image-transform-effects/).

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις του [IPictureFrameLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το [setAspectRatioLocked](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) διατηρεί τις αναλογίες του σχήματος ενώ αλλάζει το μέγεθός του.

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

Το κλείδωμα εφαρμόζεται στο σχήμα πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να αλλάξει μόνιμα σε ίδια αναλογία.

## **Ρύθμιση τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι “stretch”, οι τιμές stretch‑offset στο [IPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) ορίζουν το ορθογώνιο γεμίσματος σε σχέση με το πλαίσιο πλαισίου. Τα θετικά ποσοστά δημιουργούν εσοχή από την άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν εξώθηση.

Αυτό διαφέρει από την κοπή. Οι τιμές κοπής επιλέγουν ποιο τμήμα της πηγής είναι ορατό· οι stretch‑offset αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γεμίσμα εικόνας.

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

Χρησιμοποιήστε stretch‑offset για τοποθέτηση γεμίσματος. Χρησιμοποιήστε ιδιότητες κοπής όταν ο στόχος είναι η απόκρυψη άκρων της πηγής.

## **Αποθήκευση, μέγεθος αρχείου και σκέψεις εξαγωγής**

Οι κύριοι συμβιβασμοί γίνονται πιο εύκολα διαχειρίσιμοι όταν η αποθήκευση εικόνων και η μορφοποίηση πλαισίου αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση στον διακομιστή, αλλά μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή τοποθεσίες.
- **Κοπή** είναι αρχικά μη καταστροφική. Τα κρυφά pixels παραμένουν ενσωματωμένα μέχρι να διαγραφούν ρητά ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερβάλλουσες ραστερ εικόνες, αλλά θυσιάζει την ανάλυση πηγής. Πρέπει να εφαρμόζεται μετά τον καθορισμό του επιθυμητού μεγέθους στην διαφάνεια.
- **SVG εικόνες** πρέπει να παραμείνουν ως SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι ραστερ εξαγωγές διαφάνειας μετατρέπουν πάντα τη διαφάνεια σε pixels.
- **Επαναλαμβανόμενες εικόνες** θα πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) όταν είναι δυνατόν αντί να φορτώνουν ξανά το ίδιο αρχείο στην ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν εκτελείται επιλεκτικά: διατηρήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες σύμφωνα με το πραγματικό μέγεθος προβολής, αφαιρέστε τα κομμένα pixels μόνο όταν δεν απαιτείται επεξεργασία αργότερα, και αποφύγετε εξωτερικούς συνδέσμους εκτός αν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδίου ανάπτυξης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου εικόνας και πόρου εικόνας;**

Ένα [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) είναι ένα σχήμα σε διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές κοπής, εφέ και κλειδώματα.

**Να ενσωματώσω ή να συνδέσω τις εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδοθεί χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές θέσεις μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η κοπή το μέγεθος αρχείου PPTX;**

Δεν το κάνει από μόνη της. Οι κανονικές ρυθμίσεις κοπής κρύβουν μέρη της πηγής αλλά κρατούν τα υποκείμενα pixels. Χρησιμοποιήστε το [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ή τη συμπίεση εικόνας με αφαίρεση κομμένων περιοχών όταν αυτά τα pixels μπορούν να διαγραφούν μόνιμα.

**Μπορώ να επαναφέρω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση, και η αφαίρεση κομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγή εικόνας εκτός της παρουσίασης αν μπορεί να χρειαστεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η πιστότητα διανύσματος έχει σημασία. Το ενσωματωμένο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε ραστερ μορφή όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας διαφάνειας.

**Πώς να αποφύγω μη ασφαλείς μετατροπές τύπου όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Μια δοκιμή `instanceof` κατά του [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) αποτρέπει μη έγκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.