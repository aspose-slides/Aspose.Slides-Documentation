---
title: Διαχείριση OLE σε Παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/nodejs-java/manage-ole/
keywords:
- Αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση Αντικειμένων
- προσθήκη OLE
- ενσωμάτωση OLE
- προσθήκη αντικειμένου
- ενσωμάτωση αντικειμένου
- προσθήκη αρχείου
- ενσωμάτωση αρχείου
- συνδεδεμένο αντικείμενο
- συνδεδεμένο αρχείο
- αλλαγή OLE
- εικονίδιο OLE
- τίτλος OLE
- εξαγωγή OLE
- εξαγωγή αντικειμένου
- εξαγωγή αρχείου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE στο PowerPoint και σε αρχεία OpenDocument με το Aspose.Slides για Node.js μέσω Java. Ενσωματώστε, ενημερώστε και εξαγάγετε το περιεχόμενο OLE απρόσκοπτα."
---
## **Εισαγωγή**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει τα δεδομένα και τα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Θεωρήστε ένα γράφημα που δημιουργήθηκε στο MS Excel. Το γράφημα τοποθετείται στη συνέχεια μέσα σε μια διαφάνεια PowerPoint. Αυτό το γράφημα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτή την περίπτωση, όταν κάνετε διπλό‑κλικ στο εικονίδιο, το γράφημα ανοίγει στην συσχετισμένη εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου.
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός γραφήματος. Σε αυτή την περίπτωση, το γράφημα ενεργοποιείται στο PowerPoint, φορτώνει η διεπαφή του γραφήματος, και μπορείτε να τροποποιήσετε τα δεδομένα του γραφήματος μέσα στο PowerPoint.

[Aspose.Slides για Node.js μέσω Java](https://products.aspose.com/slides/nodejs-java/) επιτρέπει την εισαγωγή OLE Objects σε διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Προσθήκη Πλαισίων OLE Αντικειμένων σε Διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα γράφημα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο OLE αντικειμένου χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) κλάσης.
1. Λάβετε την παραπομπή σε μια διαφάνεια μέσω του δείκτη της.
1. Διαβάστε το αρχείο Excel ως πίνακα byte.
1. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) στη διαφάνεια περιλαμβάνοντας τον πίνακα byte και άλλες πληροφορίες για το αντικείμενο OLE.
1. Γράψτε την τροποποιημένη παρουσία ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα γράφημα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο OLE αντικειμένου χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java.
**Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) δέχεται μια επέκταση ενσωματώσιμου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύσει σωστά τον τύπο αρχείου και να επιλέξει τη σωστή εφαρμογή για το άνοιγμα του αντικειμένου OLE.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Προσθήκη Συνδεδεμένων Πλαισίων OLE Αντικειμένων**

Το Aspose.Slides για Node.js μέσω Java επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) χωρίς την ενσωμάτωση δεδομένων, μόνο με σύνδεσμο προς το αρχείο.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Προσθήκη πλαισίου OLE αντικειμένου με συνδεδεμένο αρχείο Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Πρόσβαση σε Πλαίσια OLE Αντικειμένων**

Αν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε με τον εξής τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την παραπομπή της διαφάνειας χρησιμοποιώντας τον δείκτη της.
3. Προσπελάστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια.
4. Μόλις προσπελαστεί το πλαίσιο OLE αντικειμένου, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.

Στο παρακάτω παράδειγμα, ένα πλαίσιο OLE αντικειμένου (αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) και τα δεδομένα αρχείου του προσπελαύνονται.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Λάβετε τα ενσωματωμένα δεδομένα αρχείου.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Λάβετε την επέκταση του ενσωματωμένου αρχείου.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Πρόσβαση σε Ιδιότητες Συνδεδεμένων Πλαισίων OLE Αντικειμένων**

Το Aspose.Slides επιτρέπει την πρόσβαση στις ιδιότητες των συνδεδεμένων πλαισίων OLE αντικειμένων.

Αυτός ο κώδικας JavaScript δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να αποκτήσετε τη διαδρομή του συνδεδεμένου αρχείου:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Ελέγξτε εάν το αντικείμενο OLE είναι συνδεδεμένο.
    if (oleFrame.isObjectLink()) {
        // Εκτυπώστε τη πλήρη διαδρομή προς το συνδεδεμένο αρχείο.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Εκτυπώστε τη σχετική διαδρομή προς το συνδεδεμένο αρχείο αν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Αλλαγή Δεδομένων OLE Αντικειμένου**

{{% alert color="info" title="Note" %}}

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Αν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το προσπελάσετε και να τροποποιήσετε τα δεδομένα του με τον εξής τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την παραπομπή της διαφάνειας μέσω του δείκτη της. 
3. Προσπελάστε το σχήμα του πλαισίου OLE αντικειμένου. Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια.
4. Μόλις προσπελαστεί το πλαίσιο OLE αντικειμένου, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσπελάστε τα δεδομένα OLE.
6. Προσπελάστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, ένα πλαίσιο OLE αντικειμένου (αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) προσπελάζεται και τα δεδομένα αρχείου του τροποποιούνται για ενημέρωση των δεδομένων του γραφήματος.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Διαβάστε τα δεδομένα του αντικειμένου OLE ως αντικείμενο Workbook.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Τροποποιήστε τα δεδομένα του Workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Αλλάξτε τα δεδομένα του αντικειμένου πλαισίου OLE.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ενσωμάτωση Άλλων Τύπων Αρχείων σε Διαφάνειες**

Εκτός από γραφήματα Excel, το Aspose.Slides για Node.js μέσω Java επιτρέπει την ενσωμάτωση άλλων τύπων αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε HTML, PDF και ZIP αρχεία ως αντικείμενα. Όταν ο χρήστης κάνει διπλό‑κλικ στο ενσωματωμένο αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα, ή ο χρήστης καλείται να επιλέξει το κατάλληλο πρόγραμμα για το άνοιγμα του.

Αυτός ο κώδικας JavaScript δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ορισμός Τύπων Αρχείων για Ενσωματωμένα Αντικείμενα**

Κατά την εργασία με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με καινούρια ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides για Node.js μέσω Java επιτρέπει τον ορισμό του τύπου αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντας την ενημέρωση των δεδομένων του πλαισίου OLE ή της επέκτασής του.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Αλλάξτε τον τύπο αρχείου σε ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ορισμός Εικόνων Εικονιδίων και Τίτλων για Ενσωματωμένα Αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από μια εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι ό,τι βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Αν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Προσθήκη εικόνας στους πόρους της παρουσίασης.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Ορισμός τίτλου και εικόνας για την προεπισκόπηση OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Αποτροπή Αλλαγής Μεγέθους και Θέσης Πλαισίου OLE Αντικειμένου**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίγετε την παρουσίαση στο PowerPoint, ίσως δείτε ένα μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Το κλικ στο κουμπί "Update Links" μπορεί να αλλάξει το μέγεθος και τη θέση του πλαισίου OLE αντικειμένου επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση του αντικειμένου. Για να αποτρέψετε το PowerPoint από το να ζητά την ενημέρωση των δεδομένων του αντικειμένου, καλέστε τη μέθοδο [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) της κλάσης [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) με `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Εξαγωγή Ενσωματωμένων Αρχείων**

Το Aspose.Slides για Node.js μέσω Java επιτρέπει την εξαγωγή των αρχείων που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE με τον ακόλουθο τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) που περιέχει τα αντικείμενα OLE που θέλετε να εξάγετε.
2. Διασχίστε όλα τα σχήματα στην παρουσία και προσπελάστε τα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe).
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια OLE αντικειμένων και γράψτε τα στο δίσκο.

Αυτός ο κώδικας JavaScript δείχνει πώς να εξαγάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **Συχνές Ερωτήσεις**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται — το εικονίδιο/εικόνα υποκατάστασης (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά τη διαδικασία απόδοσης. Αν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαχθέν PDF.

Για να διατηρήσετε επίσης το ενσωματωμένο αρχείο ως συνημμένο PDF, καλέστε το [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) με `true`. Αυτή η επιλογή είναι απενεργοποιημένη από προεπιλογή. Για ένα παράδειγμα και οδηγίες για τον έλεγχο του συνημμένου, δείτε [Preserve Embedded OLE Files as PDF Attachments](/slides/el/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Πώς μπορείτε να κλειδώσετε ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει κλειδώματα σε επίπεδο σχήματος. Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες τροποποιήσεις και μετακινήσεις.

**Θα διατηρηθούν οι σχετικοί δρόμοι για τα συνδεδεμένα OLE αντικείμενα στο φορμάτ PPTX;**

Στο PPTX, οι πληροφορίες «σχετικού δρόμου» δεν είναι διαθέσιμες — μόνο η πλήρης διαδρομή. Οι σχετικοί δρόμοι υπάρχουν μόνο στο παλαιότερο φορμάτ PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/πρόσβαση μέσω URI ή ενσωμάτωση.