---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις στο Android
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/androidjava/image/
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
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να επαναχρησιμοποιείτε, να συνδέετε, να αντικαθιστάτε και να διαχειρίζεστε ραστερ και SVG εικόνες σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Android μέσω Java."
---
## **Εισαγωγή**

Το Aspose.Slides for Android μέσω Java παρέχει διάφορους τρόπους για εργασία με εικόνες, και ο καθένας εξυπηρετεί διαφορετικό σκοπό. Μπορείτε να αποθηκεύσετε μια εικόνα σε μια παρουσίαση, να την εμφανίσετε σε πλαίσιο εικόνας, να τη χρησιμοποιήσετε ως φόντο διαφάνειας, να συνδέσετε με εξωτερική εικόνα, να αντικαταστήσετε έναν κοινόχρηστο πόρο εικόνας ή να μετατρέψετε το περιεχόμενο SVG σε επεξεργάσιμα σχήματα.

Αυτό το άρθρο εστιάζει στους πόρους εικόνας και στο πώς χρησιμοποιούνται σε όλη την παρουσίαση. Για κοπή, διαφάνεια, εφέ, τέντυση και άλλες μορφοποιήσεις που εφαρμόζονται σε ένα μεμονωμένο πλαίσιο εικόνας, δείτε [Picture Frame](/slides/el/androidjava/picture-frame/).

## **Κατανόηση του Μοντέλου Εικόνας**

Οι παρακάτω έννοιες του API είναι στενά συσχετισμένες αλλά δεν είναι εναλλάξιμες:

- Η [presentation image collection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagecollection/) αποθηκεύει πόρους εικόνας που χρησιμοποιούνται από την παρουσίαση. Χρησιμοποιήστε το [ImageCollection.addImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imagecollection/) για να προσθέσετε δεδομένα εικόνας και να αποκτήσετε έναν πόρο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/).
- Ένα [picture frame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/) είναι ένα σχήμα που εμφανίζει μια εικόνα σε διαφάνεια, διάταξη ή κύριο πρότυπο. Χρησιμοποιήστε το [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/) για να τοποθετήσετε έναν πόρο εικόνας σε μια διαφάνεια.
- Ένα φόντο διαφάνειας χρησιμοποιεί μια εικόνα ως μέρος της γεμίσματος της διαφάνειας και όχι ως σχήμα. Συνεπώς δεν συμπεριφέρεται όπως ένα πλαίσιο εικόνας.
- Το [IPPImage.replaceImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) αντικαθιστά έναν πόρο εικόνας. Εάν πολλά στοιχεία της παρουσίασης χρησιμοποιούν αυτόν τον πόρο, όλα θα χρησιμοποιήσουν την αντικατάσταση.
- Η μετατροπή ενός SVG σε σχήματα δημιουργεί επεξεργάσιμα σχήματα διαφάνειας. Μετά τη μετατροπή, το περιεχόμενο δεν διαχειρίζεται πλέον ως ένας πόρος εικόνας.

Έτσι, μια τυπική ροή εργασίας είναι: προσθέστε δεδομένα εικόνας στη συλλογή εικόνων, λάβετε ένα [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/), και στη συνέχεια χρησιμοποιήστε αυτόν τον πόρο σε ένα ή περισσότερα πλαίσια εικόνας ή γεμίσματα.

## **Προσθήκη Ενσωματωμένης Εικόνας**

Για να εισάγετε μια τοπική εικόνα, φορτώστε το αρχείο, προσθέστε το στη συλλογή εικόνων και δημιουργήστε ένα πλαίσιο εικόνας που χρησιμοποιεί το επιστρεφόμενο `IPPImage`.

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

Η εικόνα που προστίθεται με αυτόν τον τρόπο ενσωματώνεται στην παρουσίαση, έτσι ώστε το τελικό αρχείο να μην εξαρτάται από τη διαθεσιμότητα του αρχικού αρχείου εικόνας.

### **Προσθήκη Εικόνας από το Διαδίκτυο**

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

Σε εφαρμογές που εκτελούνται για μεγάλο χρονικό διάστημα, επαναχρησιμοποιήστε έναν πελάτη HTTP ή μια στρατηγική διαχείρισης συνδέσεων κατάλληλη για την εφαρμογή αντί να δημιουργείτε επανειλημμένα περιττή υποδομή δικτύωσης. Επαληθεύστε επίσης απομακρυσμένα URL, μεγέθη απαντήσεων και τύπους περιεχομένου όταν η πηγή δεν είναι αξιόπιστη.

## **Επανάχρηση Εικόνων σε Πολλές Διαφάνειες**

Εάν η ίδια εικόνα χρειάζεται περισσότερες από μία φορές, προσθέστε την μία φορά στην παρουσίαση και επαναχρησιμοποιήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) κατά τη δημιουργία επιπλέον πλαισίων εικόνας. Αυτό αποτρέπει τη συνεχή φόρτωση των ίδιων δεδομένων πηγής και καθιστά σαφής η σχέση μεταξύ του κοινόχρηστου πόρου εικόνας και των χρησιμοποιήσεών του.

Για γραφικά που πρέπει να εμφανίζονται αυτόματα σε πολλές διαφάνειες, όπως το λογότυπο μιας εταιρείας, σκεφτείτε να τοποθετήσετε το πλαίσιο εικόνας σε έναν [slide master](/slides/el/androidjava/slide-master/) ή σε μια διάταξη αντί να προσθέτετε ένα ισοδύναμο σχήμα σε κάθε διαφάνεια.

## **Χρήση Εικόνας ως Φόντο Διαφάνειας**

Μια εικόνα φόντου προσαρμόζεται στο γεμίσμα της διαφάνειας· δεν προστίθεται ως σχήμα πλαισίου εικόνας. Αυτό είναι χρήσιμο όταν η εικόνα πρέπει να καλύπτει το φόντο της διαφάνειας και δεν πρέπει να επεξεργάζεται όπως ένα κανονικό αντικείμενο διαφάνειας.

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

Για πρόσθετες επιλογές φόντου, συμπεριλαμβανομένων φόντων κύριων προτύπων και διατάξεων, δείτε [Presentation Background](/slides/el/androidjava/presentation-background/).

## **Ενσωματωμένες Εικόνες και Συνδεδεμένες Εικόνες**

Οι ενσωματωμένες και οι συνδεδεμένες εικόνες έχουν διαφορετικές ανταλλαγές φορητότητας και μεγέθους αρχείου:

- **Ενσωματωμένη εικόνα:** τα δεδομένα εικόνας αποθηκεύονται μέσα στην παρουσίαση. Η παρουσίαση είναι αυτοδύναμη, αλλά το μέγεθος του αρχείου περιλαμβάνει τα δεδομένα της εικόνας.
- **Συνδεδεμένη εικόνα:** η παρουσίαση αποθηκεύει μια διαδρομή ή URL σε εξωτερική εικόνα. Αυτό μπορεί να μειώσει το μέγεθος της παρουσίασης, αλλά ο εξωτερικός πόρος πρέπει να παραμένει προσβάσιμος όταν η παρουσίαση ανοίγει ή αποδίδεται.

Μια συνδεδεμένη εικόνα μπορεί να δημιουργηθεί ορίζοντας τη διαδρομή ή το URL μέσω του [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidespicture/) αντί να ενσωματώνετε τα δεδομένα εικόνας.

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

Χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν το περιβάλλον ανάπτυξης μπορεί αξιόπιστα να προσπελάσει τον εξωτερικό πόρο. Για παρουσιάσεις που πρέπει να λειτουργούν εκτός σύνδεσης ή να μετακινούνται μεταξύ συστημάτων, οι ενσωματωμένες εικόνες είναι συνήθως πιο ασφαλείς.

## **Εργασία με Εικόνες SVG**

Το SVG είναι μορφή διανυσματικών γραφικών, επομένως μπορεί να είναι χρήσιμο για εικονίδια, διαγράμματα και άλλα γραφικά που πρέπει να κλιμακώνονται χωρίς την ίδια απώλεια λεπτομέρειας όπως οι ραστερ εικόνες. Το Aspose.Slides υποστηρίζει SVG τόσο ως πόρο εικόνας όσο και ως πηγή επεξεργάσιμων σ shapes διαφάνειας.

### **Προσθήκη SVG ως Εικόνας**

Δημιουργήστε ένα [SvgImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgimage/), προσθέστε το στη συλλογή εικόνων και τοποθετήστε τον προκύπτοντα πόρο εικόνας σε ένα πλαίσιο εικόνας.

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

Ένα SVG μπορεί να αναφέρεται σε εξωτερικές εικόνες, φύλλα στυλ ή γραμματοσειρές. Για αυτές τις περιπτώσεις, το [SvgImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/svgimage/) παρέχει κατασκευαστές που δέχονται ένα [IExternalResourceResolver](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iexternalresourceresolver/) και μια βασική URI. Ο resolver μπορεί να αντιστοιχίσει μια σχετική URI σε μια επιτρεπόμενη απόλυτη URI και να επιστρέψει ένα ρεύμα για τον ζητούμενο πόρο.

Ο resolver καθιστά διαθέσιμους τους εξωτερικούς πόρους ενώ το Aspose.Slides επεξεργάζεται το SVG, αλλά δεν ξαναγράφει το SVG σε ένα αυτοδυναμικό έγγραφο. Εάν το SVG πρέπει να παραμείνει φορητό, ενσωματώστε τους απαιτούμενους πόρους μέσα στο ίδιο το SVG, π.χ. χρησιμοποιώντας URI τύπου `data:` για συνδεδεμένες εικόνες.

Όταν τα αρχεία SVG προέρχονται από μη αξιόπιστες πηγές, περιορίστε τα σχήματα, τις θέσεις αρχείων και τους κεντρικούς υπολογιστές που μπορεί να προσπελάσει ο resolver. Οι δικτυακοί resolvers πρέπει επίσης να εφαρμόζουν χρονικά όρια, περιορισμούς μεγέθους αποκρίσεων και επαλήθευση περιεχομένου.

### **Μετατροπή SVG σε Επεξεργάσιμα Σχήματα**

Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε μια ομάδα επεξεργάσιμων σ shapes διαφάνειας, παρόμοια με την αντίστοιχη εντολή του PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Χρησιμοποιήστε την υπερφόρτωση του [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/) που δέχεται ένα [ISvgImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgimage/) για να εκτελέσετε τη μετατροπή.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε τη μετατροπή SVG‑σε‑σχήματα όταν απαιτείται η επεξεργασία μεμονωμένων διανυσματικών στοιχείων ως σ shapes PowerPoint. Εάν το SVG χρειάζεται μόνο να εμφανιστεί, η διατήρησή του ως εικόνα είναι πιο απλή και αποφεύγει τη δημιουργία πολλών ξεχωριστών σ shapes.

## **Αντικατάσταση Υπάρχουσας Πόρου Εικόνας**

Χρησιμοποιήστε το [IPPImage.replaceImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) όταν θέλετε να αντικαταστήσετε έναν υπάρχοντα πόρο εικόνας. Αυτό είναι ιδιαίτερα χρήσιμο για κοινά γραφικά όπως λογότυπα.

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

Εάν πολλά πλαίσια εικόνας, φόντα, κύρια πρότυπα ή διατάξεις χρησιμοποιούν τον ίδιο πόρο εικόνας, η αντικατάσταση αυτού του πόρου ενημερώνει όλες αυτές τις χρήσεις. Εάν πρέπει να αλλάξει μόνο ένα πλαίσιο εικόνας, αντιστοιχίστε μια διαφορετική εικόνα σε εκείνο το πλαίσιο αντί να αντικαταστήσετε τον κοινόχρηστο πόρο.

`replaceImage` παρέχει επίσης υπερφορτώσεις που δέχονται έναν πίνακα byte ή ένα άλλο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/).

## **Πρακτικές Οδηγίες Διαχείρισης Εικόνων**

### **Έλεγχος Μεγέθους Παρουσίασης**

Μεγάλες ραστερ εικόνες μπορούν να κάνουν μια παρουσίαση περιττά μεγάλη. Χρησιμοποιήστε εικόνες πηγής με διαστάσεις κατάλληλες για το προβλεπόμενο μέγεθος προβολής, επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας όπου είναι δυνατόν και αποφύγετε την ενσωμάτωση επαναλαμβανόμενων αντιγράφων του ίδιου γραφικού υψηλής ανάλυσης.

Για ραστερ εικόνες που έχουν ήδη τοποθετηθεί σε πλαίσια εικόνας, το [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/) μπορεί να μειώσει τα δεδομένα εικόνας σύμφωνα με την επιλεγμένη ανάλυση και τις ρυθμίσεις κοπής. Πρόκειται για επεξεργασία πλαισίου εικόνας και όχι διαχείριση συλλογής εικόνων, οπότε δείτε το [Picture Frame](/slides/el/androidjava/picture-frame/) για σχετικές λειτουργίες μορφοποίησης.

### **Επιλογή μεταξύ Ενσωματωμένου και Συνδεδεμένου Περιεχομένου**

Η ενσωμάτωση καθιστά την παρουσίαση φορητή επειδή όλα τα απαιτούμενα δεδομένα εικόνας μεταφέρονται μαζί με το αρχείο. Η σύνδεση μπορεί να μειώσει το μέγεθος του αρχείου, αλλά δημιουργεί εξωτερική εξάρτηση. Χρησιμοποιήστε συνδέσμους μόνο όταν αυτή η εξάρτηση είναι αποδεκτή και σταθερή.

### **Επαναχρησιμοποίηση Κοινής Επωνυμίας**

Για επαναλαμβανόμενα λογότυπα, υδατογραφήματα ή διακοσμητικά γραφικά, χρησιμοποιήστε έναν πόρο εικόνας και επαναχρησιμοποιήστε τον. Εάν το γραφικό ανήκει στο σχεδιασμό της παρουσίασης και όχι στο περιεχόμενο των διαφανειών, τοποθετήστε το σε ένα κύριο πρότυπο ή διάταξη ώστε να κληρονομείται από τις αντίστοιχες διαφάνειες.

### **Διατήρηση Φορητότητας Πόρων SVG**

Ένα αυτοδυναμικό SVG είναι ευκολότερο να μετακινηθεί και να αποδοθεί σταθερά από ένα SVG που εξαρτάται από εξωτερικά αρχεία ή δικτυακούς πόρους. Όταν είναι δυνατόν, ενσωματώστε τους απαιτούμενους πόρους πριν εισαγάγετε το SVG. Μετατρέψτε το SVG σε σ shapes μόνο όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζεται να επεξεργαστούν.

### **Χρήση του Σύγχρονου Cross‑Platform Image API**

Για νέο κώδικα Android μέσω Java, χρησιμοποιήστε τα APIs Aspose.Slides [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) και [Images](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/images/) αντί του παλαιού δημόσιου API που βασίζεται στο `android.graphics.Bitmap`. Δείτε το [Modern API](/slides/el/androidjava/modern-api/) για οδηγίες μετάβασης.

Τα WMF και EMF απαιτούν ειδική προσοχή. Όταν αυτά τα φορμά περνούν μέσω ενός [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/), το [ImageCollection.addImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imagecollection/) μετατρέπει το μετααρχείο σε ραστερ αναπαράσταση PNG πριν την εισαγωγή. Εάν είναι σημαντικό να διατηρηθούν τα δεδομένα του μετααρχείου, χρησιμοποιήστε την υπερφόρτωση του [ImageCollection.addImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imagecollection/) που δέχεται ροή. Η δημιουργία περιεχομένου EMF από λογιστικά φύλλα ή άλλα προϊόντα είναι ξεχωριστή ροή ενσωμάτωσης και δεν περιλαμβάνεται στο πεδίο αυτού του άρθρου.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ της συλλογής εικόνων και ενός πλαισίου εικόνας;**

Η συλλογή εικόνων αποθηκεύει επαναχρησιμοποιήσιμους πόρους εικόνας. Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει έναν από αυτούς τους πόρους και παρέχει μορφοποιήσεις ειδικές για εικόνες, όπως κοπή και εφέ.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσω το ίδιο λογότυπο παντού;**

Εάν το λογότυπο είναι ήδη κοινόχρηστος ως ένας πόρος εικόνας, αντικαταστήστε αυτόν τον πόρο με το [IPPImage.replaceImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/). Για ολική επωνυμία σε όλη την παρουσίαση, η τοποθέτηση του λογοτύπου σε ένα κύριο πρότυπο ή διάταξη μπορεί επίσης να μειώσει το διπλό περιεχόμενο των διαφανειών.

**Γιατί μια συνδεδεμένη εικόνα εξαφανίζεται σε άλλον υπολογιστή;**

Μια συνδεδεμένη εικόνα εξαρτάται από το εξωτερικό αρχείο ή URL της. Εάν αυτός ο πόρος δεν είναι προσβάσιμος από τον άλλον υπολογιστή, η συνδεδεμένη εικόνα μπορεί να μην είναι διαθέσιμη. Ενσωματώστε την εικόνα όταν η παρουσίαση πρέπει να είναι αυτοδυναμική.

**Μπορεί ένα εισαχθέν SVG να επεξεργαστεί ως σ shapes PowerPoint;**

Ναι. Μετατρέψτε το SVG με το [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/); η προκύπτουσα ομάδα περιέχει επεξεργάσιμα σ shapes διαφάνειας αντί για μια ενιαία εικόνα SVG.

**Πώς μπορώ να κρατήσω τις παρουσιάσεις με πολλές εικόνες μικρότερες;**

Επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας, αποφύγετε τις περιττά μεγάλες ραστερ πηγές, συμπιέστε τις κατάλληλες ραστερ εικόνες όταν χρειάζεται, τοποθετήστε την επαναλαμβανόμενη επωνυμία σε κύρια πρότυπα ή διατάξεις, και χρησιμοποιήστε συνδεδεμένες εικόνες μόνο εάν η εξωτερική εξάρτηση είναι αποδεκτή.