---
title: Διαχείριση OLE σε Παρουσιάσεις με Java
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/java/manage-ole/
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
- Java
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με το Aspose.Slides for Java. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE άψογα."
---
## **Εισαγωγή**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει στα δεδομένα και στα αντικείμενα που δημιουργούνται σε μία εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Θεωρήστε ένα διάγραμμα που δημιουργήθηκε στο MS Excel. Το διάγραμμα τοποθετείται στη συνέχεια σε μια διαφάνεια PowerPoint. Αυτό το διάγραμμα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτήν την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το διάγραμμα ανοίγει στην συσχετισμένη εφαρμογή του (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείμενο OLE μπορεί να εμφανίζει τα πραγματικά του περιεχόμενα, όπως τα περιεχόμενα ενός διαγράμματος. Σε αυτήν την περίπτωση, το διάγραμμα ενεργοποιείται στο PowerPoint, φορτώνεται η διεπαφή του διαγράμματος και μπορείτε να τροποποιήσετε τα δεδομένα του διαγράμματος μέσα στο PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/el/java/) σας επιτρέπει να εισάγετε OLE Objects στις διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame)).

## **Προσθήκη Πλαισίων Αντικειμένων OLE σε Διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα διάγραμμα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for Java, μπορείτε να το κάνετε με τον ακόλουθο τρόπο:

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά της διαφάνειας μέσω του δείκτη της.
1. Διαβάστε το αρχείο Excel ως byte array.
1. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame) στη διαφάνεια, περιλαμβάνοντας το byte array και άλλες πληροφορίες για το αντικείμενο OLE.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα διάγραμμα από ένα αρχείο Excel σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for Java.
**Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleEmbeddedDataInfo) δέχεται μια επέκταση ενσωματώσιμου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύσει σωστά τον τύπο αρχείου και να επιλέξει τη σωστή εφαρμογή για το άνοιγμα αυτού του αντικειμένου OLE.

``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Προετοιμάστε τα δεδομένα για το αντικείμενο OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Προσθέστε το πλαίσιο αντικειμένου OLE στη διαφάνεια.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Προσθήκη Συνδεδεμένων Πλαισίων Αντικειμένων OLE**

Το Aspose.Slides for Java σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεσμο στο αρχείο.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Προσθέστε ένα πλαίσιο αντικειμένου OLE με ένα συνδεδεμένο αρχείο Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Πρόσβαση σε Πλαίσια Αντικειμένων OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά της διαφάνειας χρησιμοποιώντας τον δείκτη της.
3. Προσπελάστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame).
   Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενο δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* (μετατρέπουμε) αυτό το αντικείμενο σε ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/IOleObjectFrame). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE που θέλαμε να προσεγγίσουμε.
4. Μόλις το πλαίσιο αντικειμένου OLE προσεγγιστεί, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) και τα δεδομένα αρχείου του προσεγγίζονται.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Αποκτήστε τα ενσωματωμένα δεδομένα του αρχείου.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Αποκτήστε την επέκταση του ενσωματωμένου αρχείου.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Πρόσβαση σε Ιδιότητες Συνδεμένου Πλαισίου Αντικειμένου OLE**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε τις ιδιότητες του συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας Java δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να αποκτήσετε τη διαδρομή του συνδεδεμένου αρχείου:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ελέγξτε αν το αντικείμενο OLE είναι συνδεδεμένο.
    if (oleFrame.isObjectLink()) {
        // Εκτυπώστε την πλήρη διαδρομή του συνδεδεμένου αρχείου.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Εκτυπώστε τη σχετική διαδρομή του συνδεδεμένου αρχείου αν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Αλλαγή Δεδομένων Αντικειμένου OLE**

{{% alert color="primary" %}} 

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να προσπελάσετε αυτό το αντικείμενο και να τροποποιήσετε τα δεδομένα του με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά της διαφάνειας μέσω του δείκτη της.
3. Προσπελάστε το σχήμα του πλαισίου αντικειμένου OLE.
   Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενο δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* αυτό το αντικείμενο σε ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/IOleObjectFrame). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις προσεγγιστεί το πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσπελάστε τα δεδομένα OLE.
6. Προσπελάστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ένα  stream.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από το stream.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) προσεγγίζεται και τα δεδομένα του αρχείου τροποποιούνται για την ενημέρωση των δεδομένων του διαγράμματος.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Διαβάστε τα δεδομένα του αντικειμένου OLE ως αντικείμενο Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Τροποποιήστε τα δεδομένα του workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Αλλάξτε τα δεδομένα του αντικειμένου πλαισίου OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ενσωμάτωση Άλλων Τύπων Αρχείων σε Διαφάνειες**

Εκτός από διαγράμματα Excel, το Aspose.Slides for Java σας επιτρέπει να ενσωματώσετε άλλους τύπους αρχείων στις διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα ή εμφανίζεται προτροπή να επιλέξει κατάλληλο πρόγραμμα για το άνοιγμά του.

Αυτός ο κώδικας Java δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ορισμός Τύπων Αρχείων για Ενσωματωμένα Αντικείμενα**

Κατά την εργασία με παρουσιάσεις, ενδέχεται να χρειαστεί να αντικαταστήσετε παλαιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for Java σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντας την ενημέρωση των δεδομένων του πλαισίου OLE ή της επέκτασής του.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Αλλάξτε τον τύπο αρχείου σε ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ορισμός Εικόνων Εικονιδίου και Τίτλων για Ενσωματωμένα Αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από μια εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι ό,τι βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for Java.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Προσθέστε μια εικόνα στους πόρους της παρουσίασης.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Αποτροπή Αλλαγής Μεγέθους και Θέσης Πλαισίου Αντικειμένου OLE**

Μετά την προσθήκη ενός συνδεδεμένου αντικειμένου OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί ένα μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Κάνοντας κλικ στο κουμπί "Update Links" μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE, επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση του αντικειμένου. Για να αποτρέψετε το PowerPoint από το να προτρέπει την ενημέρωση των δεδομένων του αντικειμένου, ορίστε τη μέθοδο `setUpdateAutomatic` της διεπαφής [IOleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioleobjectframe/) σε `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Εξαγωγή Ενσωματωμένων Αρχείων**

Το Aspose.Slides for Java σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα στις διαφάνειες ως αντικείμενα OLE με τον εξής τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει τα αντικείμενα OLE που θέλετε να εξάγετε.
2. Διπλώστε (επαναλάβετε) μέσω όλων των σχήματων στην παρουσία και προσπελάστε τα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/oleobjectframe).
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένων OLE και γράψτε τα στο δίσκο.

Αυτός ο κώδικας Java δείχνει πώς να εξάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Απεικονίζεται ό,τι είναι ορατό στη διαφάνεια — το εικονίδιο/εικόνα υποκατάστασης (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Εάν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [κλειδώματα επιπέδου σχήματος](/slides/el/java/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες τροποποιήσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint ενδέχεται να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/java/working-solution-for-worksheet-resizing/) — είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε ένα σταθερό πλαίσιο και ορίστε μια κατάλληλη εικόνα υποκατάστασης.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, δεν υπάρχει πληροφορία «σχετική διαδρομή» — μόνο η πλήρης διαδρομή. Οι σχετικές διαδρομές υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/πρόσβαση μέσω URIs ή ενσωμάτωση.