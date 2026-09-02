---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις με Java
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/java/image/
keywords:
- προσθήκη εικόνας
- προσθήκη εικόνας
- αντικατάσταση εικόνας
- συλλογή εικόνων
- πλαίσιο εικόνας
- συνδεδεμένη εικόνα
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- SVG σε σχήματα
- εξωτερικοί πόροι SVG
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να επαναχρησιμοποιείτε, να συνδέετε, να αντικαθιστάτε και να διαχειρίζεστε raster και SVG εικόνες σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Java."
---
## **Εισαγωγή**

Το Aspose.Slides for Java παρέχει διάφορους τρόπους εργασίας με εικόνες, και ο καθένας εξυπηρετεί διαφορετικό σκοπό. Μπορείτε να αποθηκεύσετε μια εικόνα σε μια παρουσίαση, να την εμφανίσετε σε ένα πλαίσιο εικόνας, να τη χρησιμοποιήσετε ως φόντο διαφάνειας, να συνδέσετε μια εξωτερική εικόνα, να αντικαταστήσετε έναν κοινόχρηστο πόρο εικόνας ή να μετατρέψετε το περιεχόμενο SVG σε επεξεργάσιμα σχήματα.

Το παρόν άρθρο εστιάζει στους πόρους εικόνας και στο πώς χρησιμοποιούνται σε μια παρουσίαση. Για περικοπή, διαφάνεια, εφέ, τέντωμα και άλλες μορφοποιήσεις που εφαρμόζονται σε ένα μεμονωμένο πλαίσιο εικόνας, δείτε [Picture Frame](/slides/el/java/picture-frame/).

## **Κατανόηση του Μοντέλου Εικόνας**

Οι παρακάτω έννοιες του API σχετίζονται στενά, αλλά δεν είναι εναλλάξιμες:

- Η [presentation image collection](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagecollection/) αποθηκεύει πόρους εικόνας που χρησιμοποιούνται στην παρουσίαση. Χρησιμοποιήστε το [ImageCollection.addImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/imagecollection/) για να προσθέσετε δεδομένα εικόνας και να λάβετε έναν πόρο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/).
- Ένα [picture frame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) είναι ένα σχήμα που εμφανίζει μια εικόνα σε διαφάνεια, διάταξη ή master. Χρησιμοποιήστε το [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/) για να τοποθετήσετε έναν πόρο εικόνας σε μια διαφάνεια.
- Ένα φόντο διαφάνειας χρησιμοποιεί μια εικόνα ως μέρος της γεμίσματος της διαφάνειας αντί για σχήμα. Συνεπώς δεν συμπεριφέρεται όπως ένα picture frame.
- Το [IPPImage.replaceImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) αντικαθιστά έναν πόρο εικόνας. Εάν πολλά στοιχεία παρουσίασης χρησιμοποιούν αυτόν τον πόρο, όλα λαμβάνουν την αντικατάσταση.
- Η μετατροπή ενός SVG σε σχήματα δημιουργεί επεξεργάσιμα σχήματα διαφάνειας. Μετά τη μετατροπή, το περιεχόμενο δεν διαχειρίζεται πλέον ως ένας πόρος εικόνας.

Έτσι, μια τυπική ροή εργασίας είναι: προσθέστε δεδομένα εικόνας στη συλλογή εικόνων, λάβετε ένα [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/), και στη συνέχεια χρησιμοποιήστε αυτόν τον πόρο σε ένα ή περισσότερα picture frames ή γεμίσματα.

## **Προσθήκη Ενσωματωμένης Εικόνας**

Για να εισάγετε μια τοπική εικόνα, φορτώστε το αρχείο, προσθέστε το στη συλλογή εικόνων και δημιουργήστε ένα picture frame που χρησιμοποιεί το επιστρεφόμενο `IPPImage`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η εικόνα που προστέθηκε με αυτόν τον τρόπο ενσωματώνεται στην παρουσίαση, έτσι ώστε το τελικό αρχείο να μην εξαρτάται από τη διαθεσιμότητα του αρχικού αρχείου εικόνας.

### **Προσθήκη Εικόνας από τον Ιστό**

Όταν μια εικόνα είναι διαθέσιμη μέσω HTTP ή HTTPS, κατεβάστε τα byte της, προσθέστε τα στη συλλογή εικόνων της παρουσίασης και χρησιμοποιήστε τον επιστρεφόμενο πόρο εικόνας με τον ίδιο τρόπο όπως μια τοπική εικόνα.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Σε εφαρμογές μεγάλης διάρκειας, επαναχρησιμοποιήστε έναν πελάτη HTTP ή στρατηγική διαχείρισης συνδέσεων κατάλληλη για την εφαρμογή αντί να δημιουργείτε επανειλημμένα περιττή υποδομή δικτύου. Επίσης, επικυρώστε απομακρυσμένα URL, μεγέθη απαντήσεων και τύπους περιεχομένου όταν η πηγή δεν είναι αξιόπιστη.

## **Επαναχρησιμοποίηση Εικόνων σε Διάφορες Διαφάνειες**

Εάν η ίδια εικόνα χρειάζεται περισσότερες από μία φορές, προσθέστε την στην παρουσίαση μία φορά και επαναχρησιμοποιήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) όταν δημιουργείτε επιπλέον picture frames. Αυτό αποφεύγει την επαναλαμβανόμενη φόρτωση των ίδιων δεδομένων πηγής και κάνει τη σχέση μεταξύ του κοινόχρηστου πόρου εικόνας και των χρήσεών του σαφή.

Για γραφικά που πρέπει να εμφανίζονται αυτόματα σε πολλές διαφάνειες, όπως το λογότυπο μιας εταιρείας, εξετάστε το ενδεχόμενο τοποθέτησης του picture frame σε ένα [slide master](/slides/el/java/slide-master/) ή διάταξη αντί για προσθήκη ενός ισοδυναμικού σχήματος σε κάθε διαφάνεια.

## **Χρήση Εικόνας ως Φόντο Διαφάνειας**

Μια εικόνα φόντου ανατίθεται στο γέμισμα της διαφάνειας· δεν προστίθεται ως σχήμα picture-frame. Αυτό είναι χρήσιμο όταν η εικόνα πρέπει να καλύπτει το φόντο της διαφάνειας και δεν πρέπει να μεταχειρίζεται ως κανονικό αντικείμενο διαφάνειας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για πρόσθετες επιλογές φόντου, συμπεριλαμβανομένων φόντων master και διάταξης, δείτε [Presentation Background](/slides/el/java/presentation-background/).

## **Ενσωματωμένες και Συνδεδεμένες Εικόνες**

Οι ενσωματωμένες και συνδεδεμένες εικόνες έχουν διαφορετικές ανταλλαγές φορητότητας και μεγέθους αρχείου:

- **Ενσωματωμένη εικόνα:** τα δεδομένα εικόνας αποθηκεύονται μέσα στην παρουσίαση. Η παρουσίαση είναι αυτόνομη, αλλά το μέγεθος του αρχείου περιλαμβάνει τα δεδομένα εικόνας.
- **Συνδεδεμένη εικόνα:** η παρουσίαση αποθηκεύει μια διαδρομή ή URL σε εξωτερική εικόνα. Αυτό μπορεί να μειώσει το μέγεθος της παρουσίασης, αλλά ο εξωτερικός πόρος πρέπει να παραμένει προσβάσιμος όταν η παρουσίαση ανοίγει ή αποδίδεται.

Μια συνδεδεμένη εικόνα μπορεί να δημιουργηθεί ορίζοντας τη εξωτερική διαδρομή ή URL μέσω του [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidespicture/) αντί για ενσωμάτωση των δεδομένων εικόνας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν το περιβάλλον ανάπτυξης μπορεί αξιόπιστα να προσπελάσει τον εξωτερικό πόρο. Για παρουσιάσεις που πρέπει να λειτουργούν εκτός σύνδεσης ή να μεταφέρονται μεταξύ συστημάτων, οι ενσωματωμένες εικόνες είναι συνήθως πιο ασφαλείς.

## **Εργασία με Εικόνες SVG**

Το SVG είναι μορφή διανυσματική, οπότε μπορεί να είναι χρήσιμο για εικονίδια, διαγράμματα και άλλα γραφικά που πρέπει να κλιμακώνονται χωρίς την ίδια απώλεια λεπτομέρειας όπως οι raster εικόνες. Το Aspose.Slides υποστηρίζει SVG τόσο ως πόρο εικόνας όσο και ως πηγή για επεξεργάσιμα σχήματα διαφάνειας.

### **Προσθήκη SVG ως Εικόνας**

Δημιουργήστε ένα [SvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/svgimage/), προσθέστε το στη συλλογή εικόνων και τοποθετήστε τον προκύπτον πόρο εικόνας σε ένα picture frame.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Αρχεία SVG με Εξωτερικούς Πόρους**

Ένα SVG μπορεί να αναφέρει εξωτερικές εικόνες, φύλλα στυλ ή γραμματοσειρές. Σε αυτές τις περιπτώσεις, το [SvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/svgimage/) παρέχει κατασκευαστές που δέχονται ένα [IExternalResourceResolver](https://reference.aspose.com/slides/el/java/com.aspose.slides/iexternalresourceresolver/) και μια βασική URI. Ο resolver μπορεί να αντιστοιχίσει μια σχετική URI σε επιτρεπόμενη απόλυτη URI και να επιστρέψει ένα ρεύμα για το ζητούμενο πόρο.

Ο resolver καθιστά διαθέσιμους τους εξωτερικούς πόρους ενώ το Aspose.Slides επεξεργάζεται το SVG, αλλά δεν ξαναγράφει το SVG σε έγγραφο αυτόνομο. Εάν το SVG πρέπει να παραμείνει φορητό, ενσωματώστε τους απαιτούμενους πόρους στο ίδιο το SVG, π.χ. χρησιμοποιώντας URI τύπου `data:` για τις συνδεδεμένες εικόνες.

Όταν τα αρχεία SVG προέρχονται από μη έμπιστες πηγές, περιορίστε τα σχήματα, τις θέσεις αρχείων και τους διακομιστές που μπορεί να προσπελάσει ο resolver. Οι δικτυακοί resolvers πρέπει επίσης να εφαρμόζουν χρονικά όρια, περιορισμούς μεγέθους απαντήσεων και επικύρωση περιεχομένου.

### **Μετατροπή SVG σε Επεξεργάσιμα Σχήματα**

Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε μια ομάδα επεξεργάσιμων σχημάτων διαφάνειας, παρόμοια με την αντίστοιχη εντολή του PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Χρησιμοποιήστε την υπερφόρτωση του [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/) που δέχεται ένα [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgimage/) για να εκτελέσετε τη μετατροπή.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε τη μετατροπή SVG-σε-σχήματα όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζεται να επεξεργαστούν ως σχήματα PowerPoint. Εάν το SVG χρειάζεται μόνο να εμφανιστεί, η διατήρησή του ως εικόνα είναι πιο απλή και αποφεύγει τη δημιουργία πολλών ξεχωριστών σχημάτων.

## **Αντικατάσταση Υπάρχοντος Πόρου Εικόνας**

Χρησιμοποιήστε το [IPPImage.replaceImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) όταν θέλετε να αντικαταστήσετε έναν υπάρχοντα πόρο εικόνας. Αυτό είναι ιδιαίτερα χρήσιμο για κοινόχρηστα γραφικά όπως λογότυπα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Εάν πολλά picture frames, φόντα, masters ή διατάξεις χρησιμοποιούν τον ίδιο πόρο εικόνας, η αντικατάσταση του πόρου ενημερώνει όλες αυτές τις χρήσεις. Εάν πρέπει να αλλάξει μόνο ένα picture frame, εκχωρήστε μια διαφορετική εικόνα σε εκείνο το πλαίσιο αντί να αντικαταστήσετε τον κοινόχρηστο πόρο.

`replaceImage` παρέχει επίσης υπερφορτώσεις που δέχονται έναν πίνακα byte ή ένα άλλο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/).

## **Πρακτικές Οδηγίες Διαχείρισης Εικόνων**

### **Έλεγχος Μεγέθους Παρουσίασης**

Οι μεγάλες raster εικόνες μπορούν να κάνουν την παρουσίαση άσκοπα μεγάλη. Χρησιμοποιήστε εικόνες πηγής με διαστάσεις κατάλληλες για το προοριζόμενο μέγεθος προβολής, επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας όπου είναι δυνατόν και αποφύγετε την ενσωμάτωση επαναλαμβανόμενων αντιγράφων του ίδιου γραφικού πλήρους ανάλυσης.

Για raster εικόνες που έχουν ήδη τοποθετηθεί σε picture frames, το [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) μπορεί να μειώσει τα δεδομένα εικόνας σύμφωνα με την επιλεγμένη ανάλυση και τις ρυθμίσεις περικοπής. Αυτό είναι επεξεργασία picture-frame και όχι διαχείριση συλλογής εικόνων, γι' αυτό δείτε το [Picture Frame](/slides/el/java/picture-frame/) για σχετικές λειτουργίες μορφοποίησης.

### **Επιλογή μεταξύ Ενσωματωμένου και Συνδεδεμένου Περιεχομένου**

Η ενσωμάτωση καθιστά την παρουσίαση φορητή επειδή όλα τα απαιτούμενα δεδομένα εικόνας μεταφέρονται μαζί με το αρχείο. Η σύνδεση μπορεί να μειώσει το μέγεθος του αρχείου, αλλά εισάγει εξωτερική εξάρτηση. Χρησιμοποιήστε συνδέσμους μόνο όταν αυτή η εξάρτηση είναι αποδεκτή και σταθερή.

### **Επαναχρησιμοποίηση Κοινόχρηστης Επωνυμίας**

Για επαναλαμβανόμενα λογότυπα, υδατογραφήματα ή διακοσμητικά γραφικά, χρησιμοποιήστε έναν πόρο εικόνας και επαναχρησιμοποιήστε τον. Εάν το γραφικό ανήκει στο σχεδιασμό της παρουσίασης παρά στο περιεχόμενο των διαφανειών, τοποθετήστε το σε master ή διάταξη ώστε να κληρονομείται από τις κατάλληλες διαφάνειες.

### **Διατήρηση Φορητών Πόρων SVG**

Ένα αυτόνομο SVG είναι πιο εύκολο να μεταφερθεί και να αποδοθεί σταθερά από ένα SVG που εξαρτάται από εξωτερικά αρχεία ή δικτυακούς πόρους. Όταν είναι δυνατόν, ενσωματώστε τους απαιτούμενους πόρους πριν την εισαγωγή του SVG. Μετατρέψτε το SVG σε σχήματα μόνο όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζονται επεξεργασία.

### **Χρήση του Σύγχρονου Cross-Platform API Εικόνας**

Για νέο κώδικα Java, χρησιμοποιήστε τα API Aspose.Slides [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) και [Images](https://reference.aspose.com/slides/el/java/com.aspose.slides/images/) αντί του παλαιού δημόσιου API που βασίζεται στο `java.awt.image.BufferedImage`. Δείτε το [Modern API](/slides/el/java/modern-api/) για οδηγίες μετάβασης.

Τα WMF και EMF απαιτούν ειδική προσοχή. Όταν αυτά τα φορμάτ περνούν μέσω ενός [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/), το [ImageCollection.addImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/imagecollection/) μετατρέπει το μετααρχείο σε raster PNG αναπαράσταση πριν την εισαγωγή. Εάν η διατήρηση των δεδομένων του μετααρχείου είναι σημαντική, χρησιμοποιήστε μια υπερφόρτωση του [ImageCollection.addImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/imagecollection/) που βασίζεται σε ροή. Η δημιουργία περιεχομένου EMF από λογιστικά φύλλα ή άλλα προϊόντα είναι ξεχωριστή ροή ενσωμάτωσης και εκτός του πλαισίου του παρόντος άρθρου.

## **FAQ**

**What is the difference between the image collection and a picture frame?**

Η συλλογή εικόνων αποθηκεύει επαναχρησιμοποιήσιμους πόρους εικόνας. Ένα picture frame είναι ένα σχήμα διαφάνειας που εμφανίζει έναν από αυτούς τους πόρους και παρέχει μορφοποίηση ειδική για εικόνες, όπως περικοπή και εφέ.

**What is the best way to replace the same logo everywhere?**

Εάν το λογότυπο είναι ήδη κοινόχρηστο ως ένας πόρος εικόνας, αντικαταστήστε αυτόν τον πόρο με το [IPPImage.replaceImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/). Για branding σε όλη την παρουσίαση, η τοποθέτηση του λογότυπου σε ένα master ή layout μπορεί επίσης να μειώσει το διπλό περιεχόμενο των διαφανειών.

**Why does a linked image disappear on another computer?**

Μια συνδεδεμένη εικόνα εξαρτάται από το εξωτερικό αρχείο ή URL της. Εάν ο πόρος αυτός δεν είναι προσβάσιμος από τον άλλο υπολογιστή, η συνδεδεμένη εικόνα μπορεί να μην είναι διαθέσιμη. Ενσωματώστε την εικόνα όταν η παρουσίαση πρέπει να είναι αυτόνομη.

**Can an inserted SVG be edited as PowerPoint shapes?**

Ναι. Μετατρέψτε το SVG με το [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/); η προκύπτουσα ομάδα περιέχει επεξεργάσιμα σχήματα διαφάνειας αντί για μία εικόνα SVG.

**How can I keep presentations with many images smaller?**

Επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας, αποφύγετε ανεξήγητα μεγάλες raster πηγές, συμπιέστε κατάλληλες raster εικόνες όταν είναι σκόπιμο, διατηρήστε την επαναλαμβανόμενη επωνυμία σε masters ή layouts, και χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν μια εξωτερική εξάρτηση είναι αποδεκτή.