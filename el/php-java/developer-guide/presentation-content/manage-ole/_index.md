---
title: Διαχείριση OLE σε Παρουσιάσεις με PHP
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/php-java/manage-ole/
keywords:
- Αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση Αντικειμένων
- Προσθήκη OLE
- Ενσωμάτωση OLE
- Προσθήκη αντικειμένου
- Ενσωμάτωση αντικειμένου
- Προσθήκη αρχείου
- Ενσωμάτωση αρχείου
- Συνδεδεμένο αντικείμενο
- Συνδεδεμένο αρχείο
- Αλλαγή OLE
- Εικονίδιο OLE
- Τίτλος OLE
- Εξαγωγή OLE
- Εξαγωγή αντικειμένου
- Εξαγωγή αρχείου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE στο PowerPoint και σε αρχεία OpenDocument με το Aspose.Slides για PHP μέσω Java. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE απρόσκοπτα."
---
## **Εισαγωγή**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) είναι τεχνολογία της Microsoft που επιτρέπει τα δεδομένα και τα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Σκεφτείτε ένα διάγραμμα που δημιουργήθηκε στο MS Excel. Το διάγραμμα τοποθετείται στη συνέχεια μέσα σε μια διαφάνεια του PowerPoint. Αυτό το διάγραμμα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτή την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το διάγραμμα ανοίγει στην συνδεδεμένη εφαρμογή του (Excel) ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός διαγράμματος. Σε αυτή την περίπτωση, το διάγραμμα ενεργοποιείται στο PowerPoint, φορτώνεται η διεπαφή του διαγράμματος και μπορείτε να τροποποιήσετε τα δεδομένα του διαγράμματος μέσα στο PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/el/php-java/) σας επιτρέπει να εισάγετε αντικείμενα OLE σε διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/)).

## **Προσθήκη Πλαισίων Αντικειμένων OLE σε Διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα διάγραμμα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας Aspose.Slides for PHP via Java, μπορείτε να το κάνετε με τον εξής τρόπο:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). 
1. Πάρτε μια αναφορά σε μία διαφάνεια μέσω του δείκτη της. 
1. Διαβάστε το αρχείο Excel ως byte array. 
1. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/) στη διαφάνεια περιλαμβάνοντας το byte array και άλλες πληροφορίες για το αντικείμενο OLE. 
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX. 

Στο παρακάτω παράδειγμα, προσθέσαμε ένα διάγραμμα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας Aspose.Slides for PHP via Java.  
**Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleembeddeddatainfo/) δέχεται μια επέκταση ενσωματωμένου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύσει σωστά τον τύπο του αρχείου και να επιλέξει τη σωστή εφαρμογή για το άνοιγμα του αντικειμένου OLE.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Προετοιμασία δεδομένων για το αντικείμενο OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Προσθήκη του πλαισίου αντικειμένου OLE στη διαφάνεια.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Προσθήκη Συνδεδεμένων Πλαισίων Αντικειμένων OLE**

Το Aspose.Slides for PHP via Java σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/) χωρίς ενσωμάτωση δεδομένων αλλά μόνο με σύνδεσμο προς το αρχείο.

Αυτός ο κώδικας PHP σας δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Προσθήκη πλαισίου αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Πρόσβαση σε Πλαίσια Αντικειμένων OLE**

Αν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε με τον εξής τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). 
2. Πάρτε την αναφορά της διαφάνειας χρησιμοποιώντας τον δείκτη της. 
3. Προσεγγίστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/). Στο παράδειγμά μας χρησιμοποιήσαμε το PPTX που δημιουργήσαμε νωρίτερα και που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. 
4. Μόλις έχετε πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία πάνω του. 

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα ενσωματωμένο διάγραμμα Excel σε διαφάνεια) και τα δεδομένα του αρχείου προσπελαύνται.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Ανάκτηση των δεδομένων του ενσωματωμένου αρχείου.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Ανάκτηση της επέκτασης του ενσωματωμένου αρχείου.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Πρόσβαση σε Ιδιότητες Συνδεδεμένου Πλαισίου Αντικειμένου OLE**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε ιδιότητες του συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας PHP δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να πάρετε τη διαδρομή του συνδεδεμένου αρχείου:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Ελέγξτε αν το αντικείμενο OLE είναι συνδεδεμένο.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Εκτυπώστε τη πλήρη διαδρομή του συνδεδεμένου αρχείου.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Εκτυπώστε τη σχετική διαδρομή του συνδεδεμένου αρχείου αν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Αλλαγή Δεδομένων Αντικειμένου OLE**

{{% alert color="primary" %}} 

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί [Aspose.Cells for PHP via Java](/cells/php-java/). 

{{% /alert %}}

Αν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να προσπελάσετε το αντικείμενο και να τροποποιήσετε τα δεδομένα του με τον εξής τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). 
2. Πάρτε την αναφορά της διαφάνειας μέσω του δείκτη της. 
3. Προσεγγίστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/). Στο παράδειγμά μας χρησιμοποιήσαμε το PPTX που δημιουργήθηκε νωρίτερα και που έχει ένα σχήμα στην πρώτη διαφάνεια. 
4. Μόλις έχετε πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία πάνω του. 
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσπελάστε τα δεδομένα OLE. 
6. Προσπελάστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα. 
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ροή. 
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή. 

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα ενσωματωμένο διάγραμμα Excel σε διαφάνεια) προσπελαύνεται και τα δεδομένα του αρχείου τροποποιούνται ώστε να ενημερωθούν τα δεδομένα του διαγράμματος.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Ανάγνωση των δεδομένων του αντικειμένου OLE ως αντικείμενο Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Τροποποίηση των δεδομένων του workbook.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Αλλαγή των δεδομένων του αντικειμένου πλαισίου OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ενσωμάτωση Άλλων Τύπων Αρχείων σε Διαφάνειες**

Εκτός από διαγράμματα Excel, το Aspose.Slides for PHP via Java σας επιτρέπει να ενσωματώσετε άλλους τύπους αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ο χρήστης κάνει διπλό κλικ στο ενσωματωμένο αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα ή του ζητάται να επιλέξει ένα κατάλληλο πρόγραμμα για το άνοιγμα.

Αυτός ο κώδικας PHP δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ορισμός Τύπων Αρχείων για Ενσωματωμένα Αντικείμενα**

Κατά τη δουλειά με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for PHP via Java σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, διευκολύνοντας την ενημέρωση των δεδομένων του πλαισίου OLE ή της επέκτασής του.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε τον τύπο αρχείου ενός ενσωματωμένου αντικειμένου OLE σε `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Αλλαγή του τύπου αρχείου σε ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ορισμός Εικόνων Εικονιδίων και Τίτλων για Ενσωματωμένα Αντικείμενα**

Αφού ενσωματώσετε ένα αντικείμενο OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από μια εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι αυτό που βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Αν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία της προεπισκόπησης, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας Aspose.Slides for PHP via Java.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Προσθήκη εικόνας στους πόρους της παρουσίασης.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Ορισμός τίτλου και εικόνας για την προεπισκόπηση OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Αποτροπή Αλλαγής Μεγέθους και Θέσης Πλαισίου Αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Πατώντας το κουμπί «Update Links» μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση του αντικειμένου. Για να αποτρέψετε το PowerPoint από το να ζητά ενημέρωση των δεδομένων του αντικειμένου, ορίστε τη μέθοδο `setUpdateAutomatic` της κλάσης [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/) σε `false`:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Εξαγωγή Ενσωματωμένων Αρχείων**

Το Aspose.Slides for PHP via Java σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE με τον παρακάτω τρόπο:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που περιέχει τα αντικείμενα OLE που θέλετε να εξάγετε. 
2. Περιηγηθείτε σε όλα τα σχήματα στην παρουσία και προσπελάστε τα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/). 
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια OLEObject και γράψτε τα στο δίσκο. 

Αυτός ο κώδικας PHP δείχνει πώς να εξάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **Συχνές Ερωτήσεις**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται — το εικονίδιο/εναλλακτική εικόνα (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Αν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης ώστε να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει κλειδαριές σε επίπεδο σχήματος. Δεν πρόκειται για κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

**Θα διατηρηθούν οι σχετικοί δρόμοι για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, οι πληροφορίες «σχετικού δρόμου» δεν διατίθενται — μόνο η πλήρης διαδρομή. Οι σχετικοί δρόμοι υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/πρόσβαση μέσω URI ή ενσωμάτωση.