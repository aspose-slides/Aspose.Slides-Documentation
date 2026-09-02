---
title: Βελτιστοποιήστε τη Διαχείριση Εικόνων σε Παρουσιάσεις Χρησιμοποιώντας PHP
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/php-java/image/
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
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να επαναχρησιμοποιείτε, να συνδέετε, να αντικαθιστάτε και να διαχειρίζεστε ραστερ και SVG εικόνες σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java."
---
## **Εισαγωγή**

Το Aspose.Slides για PHP μέσω Java παρέχει αρκετούς τρόπους για εργασία με εικόνες, και κάθε ένας εξυπηρετεί διαφορετικό σκοπό. Μπορείτε να αποθηκεύσετε μια εικόνα σε μια παρουσίαση, να την εμφανίσετε σε ένα πλαίσιο εικόνας, να την χρησιμοποιήσετε ως παρασκήνιο διαφάνειας, να δημιουργήσετε σύνδεσμο σε εξωτερική εικόνα, να αντικαταστήσετε έναν κοινόχρηστο πόρο εικόνας ή να μετατρέψετε περιεχόμενο SVG σε επεξεργάσιμα σχήματα.

Αυτό το άρθρο εστιάζει στους πόρους εικόνας και στο πώς χρησιμοποιούνται σε μια παρουσίαση. Για περικοπή, διαφάνεια, εφέ, τέντωμα και άλλες μορφοποιήσεις που εφαρμόζονται σε ένα μεμονωμένο πλαίσιο εικόνας, δείτε [Πλαίσιο Εικόνας](/slides/el/php-java/picture-frame/).

## **Κατανοήστε το Μοντέλο Εικόνας**

Οι παρακάτω έννοιες API σχετίζονται στενά αλλά δεν είναι εναλλάξιμες:

- Η [Συλλογή εικόνων παρουσίασης](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) αποθηκεύει πόρους εικόνας που χρησιμοποιούνται από την παρουσίαση. Χρησιμοποιήστε το [ImageCollection::addImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) για να προσθέσετε δεδομένα εικόνας και να αποκτήσετε έναν πόρο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/).
- Ένα [πλαίσιο εικόνας](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) είναι ένα σχήμα που εμφανίζει μια εικόνα σε μια διαφάνεια, διάταξη ή master. Χρησιμοποιήστε το [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addpictureframe/) για να τοποθετήσετε έναν πόρο εικόνας σε μια διαφάνεια.
- Ένα φόντο διαφάνειας χρησιμοποιεί μια εικόνα ως μέρος της γεμίσεως της διαφάνειας και όχι ως σχήμα. Συνεπώς δεν συμπεριφέρεται όπως ένα πλαίσιο εικόνας.
- [PPImage::replaceImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) αντικαθιστά έναν πόρο εικόνας. Εάν πολλά στοιχεία παρουσίασης χρησιμοποιούν αυτόν τον πόρο, όλα θα χρησιμοποιούν την αντικατάσταση.
- Η μετατροπή ενός SVG σε σχήματα δημιουργεί επεξεργάσιμα σχήματα διαφάνειας. Μετά τη μετατροπή, το περιεχόμενο δεν διαχειρίζεται πλέον ως ένας ενιαίος πόρος εικόνας.

Έτσι, μια τυπική ροή εργασίας είναι: προσθέστε δεδομένα εικόνας στη συλλογή εικόνων, λάβετε ένα [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/), και στη συνέχεια χρησιμοποιήστε αυτόν τον πόρο σε ένα ή περισσότερα πλαίσια εικόνας ή γεμίσματα.

## **Προσθέστε μια ενσωματωμένη εικόνα**

Για να εισαγάγετε μια τοπική εικόνα, φορτώστε το αρχείο, προσθέστε το στη συλλογή εικόνων και δημιουργήστε ένα πλαίσιο εικόνας που χρησιμοποιεί το επιστρεφόμενο `PPImage`.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η εικόνα που προστίθεται με αυτόν τον τρόπο ενσωματώνεται στην παρουσίαση, έτσι το παραγόμενο αρχείο δεν εξαρτάται από το αρχείο εικόνας να παραμένει διαθέσιμο.

### **Προσθέστε μια εικόνα από το web**

Όταν μια εικόνα είναι διαθέσιμη μέσω HTTP ή HTTPS, κατεβάστε τα byte της, προσθέστε τα στη συλλογή εικόνων παρουσίασης και χρησιμοποιήστε τον επιστρεφόμενο πόρο εικόνας με τον ίδιο τρόπο όπως μια τοπική εικόνα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Σε εφαρμογές που εκτελούνται για μεγάλο χρονικό διάστημα, επαναχρησιμοποιήστε έναν πελάτη HTTP ή στρατηγική διαχείρισης συνδέσεων κατάλληλη για την εφαρμογή αντί να δημιουργείτε επανειλημμένα περιττή υποδομή δικτύου. Επίσης, επικυρώστε απομακρυσμένα URLs, μεγέθη απαντήσεων και τύπους περιεχομένου όταν η πηγή δεν είναι αξιόπιστη.

## **Επαναχρησιμοποίηση εικόνων σε πολλές διαφάνειες**

Εάν η ίδια εικόνα χρειάζεται περισσότερες από μία φορές, προσθέστε τη στην παρουσίαση μία φορά και επαναχρησιμοποιήστε το επιστρεφόμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) όταν δημιουργείτε επιπλέον πλαίσια εικόνας. Αυτό αποτρέπει τη συνεχή φόρτωση των ίδιων δεδομένων πηγής και κάνει τη σχέση μεταξύ του κοινόχρηστου πόρου εικόνας και των χρήσεών του σαφή.

Για γραφικά που πρέπει να εμφανίζονται αυτόματα σε πολλές διαφάνειες, όπως το λογότυπο της εταιρείας, σκεφτείτε να τοποθετήσετε το πλαίσιο εικόνας σε ένα [κύρια διαφάνεια](/slides/el/php-java/slide-master/) ή διάταξη αντί να προσθέτετε ένα ισοδύναμο σχήμα σε κάθε διαφάνεια.

## **Χρησιμοποιήστε μια εικόνα ως φόντο διαφάνειας**

Μια εικόνα φόντου ανατίθεται στο γέμισμα της διαφάνειας· δεν προστίθεται ως σχήμα πλαισίου εικόνας. Αυτό είναι χρήσιμο όταν η εικόνα πρέπει να καλύπτει το φόντο της διαφάνειας και δεν πρέπει να επεξεργάζεται ως κανονικό αντικείμενο διαφάνειας.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για πρόσθετες επιλογές φόντου, συμπεριλαμβανομένων φόντων master και διάταξης, δείτε [Φόντο Παρουσίασης](/slides/el/php-java/presentation-background/).

## **Ενσωματωμένες εικόνες και συνδεδεμένες εικόνες**

Οι ενσωματωμένες και οι συνδεδεμένες εικόνες έχουν διαφορετικές ανταλλαγές φορητότητας και μεγέθους αρχείου:

- **Embedded image:** τα δεδομένα της εικόνας αποθηκεύονται μέσα στην παρουσίαση. Η παρουσίαση είναι ανεξάρτητη, αλλά το μέγεθος του αρχείου περιλαμβάνει τα δεδομένα της εικόνας.
- **Linked image:** η παρουσίαση αποθηκεύει μια διαδρομή ή URL σε εξωτερική εικόνα. Αυτό μπορεί να μειώσει το μέγεθος της παρουσίασης, αλλά ο εξωτερικός πόρος πρέπει να παραμένει προσβάσιμος όταν η παρουσίαση ανοίγει ή αποδίδεται.

Μια συνδεδεμένη εικόνα μπορεί να δημιουργηθεί αντιστοιχίζοντας τη εξωτερική διαδρομή ή URL μέσω του [Picture::setLinkPathLong](https://reference.aspose.com/slides/el/php-java/aspose.slides/picture/) αντί για ενσωμάτωση των δεδομένων της εικόνας.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν το περιβάλλον ανάπτυξης μπορεί αξιόπιστα να προσπελάσει τον εξωτερικό πόρο. Για παρουσιάσεις που πρέπει να λειτουργούν εκτός σύνδεσης ή να μετακινούνται μεταξύ συστημάτων, οι ενσωματωμένες εικόνες είναι συνήθως πιο ασφαλείς.

## **Εργασία με SVG εικόνες**

Το SVG είναι μορφή διανυσματική, επομένως μπορεί να είναι χρήσιμο για εικονίδια, διαγράμματα και άλλα γραφικά που πρέπει να κλιμακώνονται χωρίς την ίδια απώλεια λεπτομέρειας όπως τις ραστερ εικόνες. Το Aspose.Slides υποστηρίζει το SVG τόσο ως πόρο εικόνας όσο και ως πηγή για επεξεργάσιμα σχήματα διαφάνειας.

### **Προσθέστε ένα SVG ως εικόνα**

Δημιουργήστε ένα [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/), προσθέστε το στη συλλογή εικόνων και τοποθετήστε τον παραγόμενο πόρο εικόνας σε ένα πλαίσιο εικόνας.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Αρχεία SVG με εξωτερικούς πόρους**

Ένα SVG μπορεί να αναφέρεται σε εξωτερικές εικόνες, φύλλα στιλ ή γραμματοσειρές. Για αυτές τις περιπτώσεις, το [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/) παρέχει κατασκευαστές που δέχονται έναν [ExternalResourceResolver](https://reference.aspose.com/slides/el/php-java/aspose.slides/externalresourceresolver/) και μια βασική URI. Ο resolver μπορεί να χαρτογραφήσει μια σχετική URI σε μια επιτρεπόμενη απόλυτη URI και να επιστρέψει μια ροή για τον ζητούμενο πόρο.

Ο resolver καθιστά τους εξωτερικούς πόρους διαθέσιμους κατά τη διαδικασία του SVG από το Aspose.Slides, αλλά δεν ξαναγράφει το SVG σε ένα αυτόνομο έγγραφο. Εάν το SVG πρέπει να παραμείνει φορητό, ενσωματώστε τους απαιτούμενους πόρους στο ίδιο το SVG, για παράδειγμα χρησιμοποιώντας `data:` URIs για συνδεδεμένες εικόνες.

Όταν τα αρχεία SVG προέρχονται από μη αξιόπιστες πηγές, περιορίστε τα σχήματα, τις θέσεις αρχείων και τους κεντρικούς υπολογιστές που μπορεί να προσπελάσει ο resolver. Οι δικτυακοί resolvers πρέπει επίσης να εφαρμόζουν χρονικά όρια, περιορισμούς μεγέθους απάντησης και επικύρωση περιεχομένου.

### **Μετατροπή SVG σε επεξεργάσιμα σχήματα**

Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε μια ομάδα επεξεργάσιμων σχημάτων διαφάνειας, παρόμοια με την αντίστοιχη εντολή του PowerPoint.

![Μενού αναδυόμενο του PowerPoint](img_01_01.png)

Χρησιμοποιήστε το υπερφόρτωμα του [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addgroupshape/) που δέχεται ένα [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/) για να εκτελέσετε τη μετατροπή.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Χρησιμοποιήστε τη μετατροπή SVG-σε-σχήματα όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζεται να επεξεργαστούν ως σχήματα PowerPoint. Εάν το SVG χρειάζεται μόνο να εμφανιστεί, η διατήρησή του ως εικόνα είναι πιο απλή και αποφεύγει τη δημιουργία πολλών ξεχωριστών σχημάτων.

## **Αντικατάσταση υπάρχοντος πόρου εικόνας**

Χρησιμοποιήστε το [PPImage::replaceImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) όταν θέλετε να αντικαταστήσετε έναν υπάρχοντα πόρο εικόνας. Αυτό είναι ιδιαίτερα χρήσιμο για κοινά γραφικά όπως λογότυπα.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Εάν πολλά πλαίσια εικόνας, φόντα, master ή διατάξεις χρησιμοποιούν τον ίδιο πόρο εικόνας, η αντικατάσταση του πόρου ενημερώνει όλες τις χρήσεις του. Εάν πρέπει να αλλάξει μόνο ένα πλαίσιο εικόνας, αντιστοιχίστε μια διαφορετική εικόνα σε αυτό το πλαίσιο αντί για την αντικατάσταση του κοινόχρηστου πόρου.

`PPImage::replaceImage` παρέχει επίσης υπερφορτώσεις που δέχονται έναν πίνακα byte ή ένα άλλο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/).

## **Πρακτικές οδηγίες διαχείρισης εικόνων**

### **Έλεγχος μεγέθους παρουσίασης**

Οι μεγάλες ραστερ εικόνες μπορούν να κάνουν μια παρουσίαση ανεξήγητα μεγάλη. Χρησιμοποιήστε εικόνες πηγής με διαστάσεις κατάλληλες για το προβλεπόμενο μέγεθος εμφάνισης, επαναχρησιμοποιείστε κοινά πόρους εικόνας όπου είναι δυνατόν, και αποφύγετε την ενσωμάτωση επαναλαμβανόμενων αντιγράφων του ίδιου γραφικού υψηλής ανάλυσης.

Για ραστερ εικόνες που έχουν ήδη τοποθετηθεί σε πλαίσια εικόνας, το [PictureFillFormat::compressImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/) μπορεί να μειώσει τα δεδομένα της εικόνας σύμφωνα με την επιλεγμένη ανάλυση και τις ρυθμίσεις περικοπής. Αυτό είναι επεξεργασία πλαισίου εικόνας και όχι διαχείριση συλλογής εικόνων, οπότε δείτε το [Picture Frame](/slides/el/php-java/picture-frame/) για σχετικές λειτουργίες μορφοποίησης.

### **Επιλογή μεταξύ ενσωματωμένου και συνδεδεμένου περιεχομένου**

Η ενσωμάτωση κάνει την παρουσίαση φορητή επειδή όλα τα απαιτούμενα δεδομένα εικόνας μεταφέρονται με το αρχείο. Η σύνδεση μπορεί να μειώσει το μέγεθος του αρχείου, αλλά εισάγει μια εξωτερική εξάρτηση. Χρησιμοποιήστε συνδέσμους μόνο όταν αυτή η εξάρτηση είναι αποδεκτή και σταθερή.

### **Επαναχρησιμοποίηση κοινής επωνυμίας**

Για επαναλαμβανόμενα λογότυπα, υδατογραφήματα ή διακοσμητικά γραφικά, χρησιμοποιήστε έναν πόρο εικόνας και επαναχρησιμοποιήστε τον. Εάν το γραφικό ανήκει στο σχεδιασμό της παρουσίασης και όχι στο περιεχόμενο της διαφάνειας, τοποθετήστε το σε ένα master ή διάταξη ώστε να κληρονομείται από τις αντίστοιχες διαφάνειες.

### **Διατηρήστε τους πόρους SVG φορητούς**

Ένα αυτόνομο SVG είναι πιο εύκολο να μεταφερθεί και να αποδοθεί σταθερά από ένα SVG που εξαρτάται από εξωτερικά αρχεία ή δικτυακούς πόρους. Όταν είναι δυνατόν, ενσωματώστε τους απαιτούμενους πόρους πριν την εισαγωγή του SVG. Μετατρέψτε το SVG σε σχήματα μόνο όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζεται να επεξεργαστούν.

### **Χρησιμοποιήστε το σύγχρονο διασυνοριακό API εικόνων**

Για νέο κώδικα PHP μέσω Java, χρησιμοποιήστε τα APIs Aspose.Slides [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) και [Images](https://reference.aspose.com/slides/el/php-java/aspose.slides/images/) αντί του παλαιού δημόσιου API που βασίζεται στο `java.awt.image.BufferedImage`. Δείτε το [Modern API](/slides/el/php-java/modern-api/) για οδηγίες μετάβασης.

Τα WMF και EMF απαιτούν ειδική προσοχή. Όταν αυτές οι μορφές περνούν μέσω ενός [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/), το [ImageCollection::addImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) μετατρέπει το μετααρχείο σε αναπαράσταση raster PNG πριν την εισαγωγή. Εάν η διατήρηση των δεδομένων του μετααρχείου είναι σημαντική, χρησιμοποιήστε μια υπερφόρτωση του [ImageCollection::addImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) που βασίζεται σε ροή. Η δημιουργία περιεχομένου EMF από υπολογιστικά φύλλα ή άλλα προϊόντα είναι μια ξεχωριστή ροή ενσωμάτωσης και βρίσκεται εκτός του πεδίου αυτού του άρθρου.

## **FAQ**

**Ποια είναι η διαφορά μεταξύ της συλλογής εικόνων και ενός πλαισίου εικόνας;**

Η συλλογή εικόνων αποθηκεύει επαναχρησιμοποιήσιμους πόρους εικόνας. Ένα πλαίσιο εικόνας είναι ένα σ_shape διαφάνειας που εμφανίζει έναν από τους πόρους αυτούς και παρέχει μορφοποίηση ειδική για εικόνα όπως περικοπή και εφέ.

**Ποιος είναι ο καλύτερος τρόπος να αντικαταστήσετε το ίδιο λογότυπο παντού;**

Εάν το λογότυπο είναι ήδη κοινόχρηστο ως ένας πόρος εικόνας, αντικαταστήστε αυτόν τον πόρο με το [PPImage::replaceImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/). Για εταιρική επωνυμία σε ολόκληρη την παρουσίαση, η τοποθέτηση του λογότυπου σε ένα master ή διάταξη μπορεί επίσης να μειώσει το διπλό περιεχόμενο διαφάνειας.

**Γιατί μια συνδεδεμένη εικόνα εξαφανίζεται σε έναν άλλο υπολογιστή;**

Μια συνδεδεμένη εικόνα εξαρτάται από το εξωτερικό αρχείο ή URL της. Εάν αυτός ο πόρος δεν μπορεί να προσεγγιστεί από τον άλλο υπολογιστή, η συνδεδεμένη εικόνα ενδέχεται να μην υπάρχει. Ενσωματώστε την εικόνα όταν η παρουσίαση πρέπει να είναι αυτόνομη.

**Μπορεί ένα εισαχθέν SVG να επεξεργαστεί ως σχήματα PowerPoint;**

Ναι. Μετατρέψτε το SVG με το [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addgroupshape/); η παραγόμενη ομάδα περιέχει επεξεργάσιμα σχήματα διαφάνειας αντί για μια ενιαία εικόνα SVG.

**Πώς μπορώ να διατηρήσω τις παρουσιάσεις με πολλές εικόνες μικρότερες;**

Επαναχρησιμοποιήστε κοινά πόρους εικόνας, αποφύγετε τα περιττά μεγάλα ραστερ αρχεία, συμπιέστε κατάλληλες ραστερ εικόνες όταν είναι σκόπιμο, διατηρήστε την επαναλαμβανόμενη επωνυμία σε master ή διατάξεις, και χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν αποδεκτή είναι μια εξωτερική εξάρτηση.