---
title: Διαχείριση OLE σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/nodejs-java/manage-ole/
keywords:
- αντικείμενο OLE
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
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με το Aspose.Slides για Node.js μέσω Java. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE απρόσκοπτα."
---
## **Εισαγωγή**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) είναι τεχνολογία της Microsoft που επιτρέπει σε δεδομένα και αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Σκεφτείτε ένα γράφημα που δημιουργήθηκε στο MS Excel. Το γράφημα τοποθετείται στη συνέχεια σε μια διαφάνεια PowerPoint. Αυτό το γράφημα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτήν την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το γράφημα ανοίγει στην σχετική εφαρμογή (Excel) ή σας ζητείται να επιλέξετε εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός γραφήματος. Σε αυτήν την περίπτωση, το γράφημα ενεργοποιείται στο PowerPoint, φορτώνεται η διεπαφή του και μπορείτε να τροποποιήσετε τα δεδομένα του γραφήματος μέσα στο PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/el/nodejs-java/) σας επιτρέπει να εισάγετε αντικείμενα OLE σε διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/OleObjectFrame)).

## **Προσθήκη πλαισίων αντικειμένου OLE σε διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα γράφημα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας Aspose.Slides for Node.js via Java, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation). 
1. Λάβετε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
1. Διαβάστε το αρχείο Excel ως πίνακα byte. 
1. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/OleObjectFrame) στη διαφάνεια, συμπεριλαμβάνοντας τον πίνακα byte και άλλες πληροφορίες για το αντικείμενο OLE. 
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX. 

Στο παρακάτω παράδειγμα, προσθέσαμε ένα γράφημα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας Aspose.Slides for Node.js via Java.  
**Note** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/OleEmbeddedDataInfo) δέχεται μια επέκταση ενσωματώσιμου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να αναγνωρίσει σωστά τον τύπο αρχείου και να επιλέξει τη σωστή εφαρμογή για το άνοιγμα του αντικειμένου OLE.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Προετοιμασία δεδομένων για το αντικείμενο OLE.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Προσθήκη πλαισίου αντικειμένου OLE στη διαφάνεια.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Προσθήκη συνδεδεμένων πλαισίων αντικειμένου OLE**

Aspose.Slides for Node.js via Java σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/OleObjectFrame) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεση στο αρχείο.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/OleObjectFrame) με συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Προσθήκη πλαισίου αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Πρόσβαση σε πλαίσια αντικειμένου OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να αποκτήσετε πρόσβαση σε αυτό ως εξής:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation). 
2. Λάβετε την αναφορά της διαφάνειας χρησιμοποιώντας το δείκτη της. 
3. Αποκτήστε πρόσβαση στο σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/OleObjectFrame). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. 
4. Μόλις αποκτήσετε πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία πάνω του. 

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) και τα δεδομένα αρχείου του προσεγγίζονται.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Λάβετε τα ενσωματωμένα δεδομένα αρχείου.
    // Λάβετε την επέκταση του ενσωματωμένου αρχείου.
    // ...
}
```

### **Πρόσβαση σε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE**

Aspose.Slides σας επιτρέπει να προσπελάσετε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας JavaScript δείχνει πώς να ελέγξετε εάν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να λάβετε τη διαδρομή του συνδεδεμένου αρχείου:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Ελέγξτε αν το αντικείμενο OLE είναι συνδεδεμένο.
    if (oleFrame.isObjectLink()) {
        // Εμφανίστε το πλήρες μονοπάτι του συνδεδεμένου αρχείου.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Εμφανίστε το σχετικό μονοπάτι του συνδεδεμένου αρχείου εάν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν το σχετικό μονοπάτι.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="primary" %}} 

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να αποκτήσετε πρόσβαση σε αυτό το αντικείμενο και να τροποποιήσετε τα δεδομένα του ως εξής:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation). 
2. Λάβετε την αναφορά της διαφάνειας μέσω του δείκτη της. 
3. Αποκτήστε πρόσβαση στο σχήμα πλαισίου αντικειμένου OLE. Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. 
4. Μόλις αποκτήσετε πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία πάνω του. 
5. Δημιουργήστε ένα αντικείμενο `Workbook` και αποκτήστε πρόσβαση στα δεδομένα OLE. 
6. Αποκτήστε πρόσβαση στο επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα. 
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ροή. 
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή. 

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) προσεγγίζεται και τα δεδομένα αρχείου του τροποποιούνται για ενημέρωση των δεδομένων του γραφήματος.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Διαβάστε τα δεδομένα του αντικειμένου OLE ως αντικείμενο Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Τροποποιήστε τα δεδομένα του workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Αλλάξτε τα δεδομένα του αντικειμένου πλαισίου OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ενσωμάτωση άλλων τύπων αρχείων σε διαφάνειες**

Εκτός από γραφήματα Excel, το Aspose.Slides for Node.js via Java σας επιτρέπει να ενσωματώσετε άλλους τύπους αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε HTML, PDF και ZIP αρχεία ως αντικείμενα. Όταν ο χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, ανοίγει αυτόματα στο σχετικό πρόγραμμα ή του ζητείται να επιλέξει κατάλληλο πρόγραμμα για το άνοιγμα.

Αυτός ο κώδικας JavaScript δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```javascript
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

## **Ορισμός τύπων αρχείων για ενσωματωμένα αντικείμενα**

Κατά τη δουλειά με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for Node.js via Java σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα ή την επέκταση του πλαισίου OLE.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

```javascript
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

## **Ορισμός εικόνων εικονιδίου και τίτλων για ενσωματωμένα αντικείμενα**

Αφού ενσωματώσετε ένα αντικείμενο OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι αυτό που βλέπουν οι χρήστες πριν αποκτήσουν πρόσβαση ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας Aspose.Slides for Node.js via Java.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```javascript
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

## **Αποτροπή αλλαγής μεγέθους και θέσης πλαισίου αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί ένα μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Κάνοντας κλικ στο κουμπί «Update Links» μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE, επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση. Για να αποφύγετε το αίτημα ενημέρωσης των δεδομένων του αντικειμένου, χρησιμοποιήστε τη μέθοδο `setUpdateAutomatic` της κλάσης [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleobjectframe/) με τιμή `false`:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Εξαγωγή ενσωματωμένων αρχείων**

Aspose.Slides for Node.js via Java σας επιτρέπει να εξαγάγετε τα αρχεία που έχουν ενσωματωθεί σε διαφάνειες ως αντικείμενα OLE ως εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει τα αντικείμενα OLE που θέλετε να εξαγάγετε. 
2. Διατρέξτε όλα τα σχήματα στην παρουσία και αποκτήστε πρόσβαση στα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/o oleobjectframe). 
3. Αποκτήστε πρόσβαση στα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένου OLE και γράψτε τα στο δίσκο. 

Αυτός ο κώδικας JavaScript δείχνει πώς να εξαγάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```javascript
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

## **Συχνές ερωτήσεις**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται — το εικονίδιο/εικόνα αντικατάστασης (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά τη διαδικασία απόδοσης. Εάν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην το μετακινούν/επεξεργάζονται στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει κλειδώματα σε επίπεδο σχήματος. Δεν πρόκειται για κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες τροποποιήσεις και μετακινήσεις.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, η πληροφορία «σχετική διαδρομή» δεν διατίθεται — μόνο η πλήρης διαδρομή. Οι σχετικές διαδρομές υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/προσβάσιμες URIs ή ενσωμάτωση.