---
title: Διαχείριση OLE σε Παρουσιάσεις σε Android
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/androidjava/manage-ole/
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
- Συνδεμένο αρχείο
- Αλλαγή OLE
- Εικονίδιο OLE
- Τίτλος OLE
- Εξαγωγή OLE
- Εξαγωγή αντικειμένου
- Εξαγωγή αρχείου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με το Aspose.Slides for Android via Java. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE απρόσκοπτα."
---
## **Εισαγωγή**

{{% alert color="primary" %}} 

Το OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει στα δεδομένα και στα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Σκεφτείτε ένα διάγραμμα που δημιουργήθηκε στο MS Excel. Το διάγραμμα τοποθετείται στη συνέχεια μέσα σε διαφάνεια PowerPoint. Αυτό το διάγραμμα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτήν την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το διάγραμμα ανοίγει στην σχετική εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα στοιχεία ενός διαγράμματος. Σε αυτήν την περίπτωση, το διάγραμμα ενεργοποιείται στο PowerPoint, φορτώνει η διεπαφή του διαγράμματος και μπορείτε να τροποποιήσετε τα δεδομένα του διαγράμματος μέσα στο PowerPoint. 

Το Aspose.Slides for Android via Java σας επιτρέπει να εισάγετε OLE Objects σε διαφάνειες ως πλαίσια OLE αντικειμένων ([OleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/OleObjectFrame)).

## **Προσθήκη Πλαισίων OLE Αντικειμένων σε Διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα διάγραμμα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο OLE αντικειμένου χρησιμοποιώντας το Aspose.Slides for Android via Java, μπορείτε να το κάνετε με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Διαβάστε το αρχείο Excel ως πίνακα byte.
1. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/OleObjectFrame) στη διαφάνεια, συμπεριλαμβάνοντας τον πίνακα byte και άλλες πληροφορίες για το αντικείμενο OLE.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα διάγραμμα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο OLE αντικειμένου χρησιμοποιώντας το Aspose.Slides for Android via Java. **Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/OleEmbeddedDataInfo) δέχεται μια επέκταση ενσωματωμένου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύσει σωστά τον τύπο του αρχείου και να επιλέξει την κατάλληλη εφαρμογή για το άνοιγμα του αντικειμένου OLE.

```java
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Προετοιμάστε τα δεδομένα για το αντικείμενο OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Προσθήκη Συνδεδεμένων Πλαισίων OLE Αντικειμένων**

Aspose.Slides for Android via Java επιτρέπει την προσθήκη ενός [OleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/OleObjectFrame) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με μια σύνδεση στο αρχείο.

Αυτός ο κώδικας Java σας δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/OleObjectFrame) με συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Προσθήκη πλαισίου αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Πρόσβαση σε Πλαίσια OLE Αντικειμένων**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε με τον παρακάτω τρόπο:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
2. Αποκτήστε την αναφορά της διαφάνειας χρησιμοποιώντας το δείκτη της.
3. Προσπελάστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/OleObjectFrame). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενα δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* αυτό το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ioleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο OLE αντικειμένου που θέλαμε να προσπελάσουμε.
4. Μόλις προσπελαστεί το πλαίσιο OLE αντικειμένου, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Αποκτήστε τα δεδομένα του ενσωματωμένου αρχείου.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Αποκτήστε την επέκταση του ενσωματωμένου αρχείου.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Πρόσβαση στις Ιδιότητες Συνδεδεμένου Πλαισίου OLE Αντικειμένου**

Aspose.Slides σας επιτρέπει να προσπελάσετε τις ιδιότητες των συνδεδεμένων πλαισίων OLE αντικειμένων.

Αυτός ο κώδικας Java σας δείχνει πώς να ελέγξετε εάν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να αποκτήσετε τη διαδρομή του συνδεδεμένου αρχείου:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ελέγξτε εάν το αντικείμενο OLE είναι συνδεδεμένο.
    if (oleFrame.isObjectLink()) {
        // Εκτυπώστε τη πλήρη διαδρομή του συνδεδεμένου αρχείου.
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

## **Αλλαγή Δεδομένων OLE Αντικειμένου**

{{% alert color="primary" %}} 

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for Android via Java](/cells/androidjava/). 

{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το προσπελάσετε και να τροποποιήσετε τα δεδομένα του με τον εξής τρόπο:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
2. Αποκτήστε την αναφορά της διαφάνειας μέσω του δείκτη της. 
3. Προσπελάστε το σχήμα του πλαισίου OLE αντικειμένου. Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενα δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* αυτό το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ioleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο OLE αντικειμένου που θέλαμε να προσπελάσουμε.
4. Μόλις προσπελαστεί το πλαίσιο OLE αντικειμένου, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και αποκτήστε πρόσβαση στα δεδομένα OLE.
6. Πρόσβαση στο επιθυμητό `Worksheet` και τροποποίηση των δεδομένων.
7. Αποθήκευση του ενημερωμένου `Workbook` σε ροή (stream).
8. Αλλαγή των δεδομένων του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, προσπελάζεται ένα πλαίσιο OLE αντικειμένου (ένα αντικείμενο διαγράμματος Excel ενσωματωμένο σε διαφάνεια) και τροποποιούνται τα δεδομένα του αρχείου για ενημέρωση των δεδομένων του διαγράμματος.

```java 
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

Εκτός από τα διαγράμματα Excel, το Aspose.Slides for Android via Java σας επιτρέπει να ενσωματώσετε άλλους τύπους αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ο χρήστης κάνει διπλό κλικ στο ενσωματωμένο αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα ή του ζητείται να επιλέξει ένα κατάλληλο πρόγραμμα για το άνοιγμα.

Αυτός ο κώδικας Java σας δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ορισμός Τύπων Αρχείων για Ενσωματωμένα Αντικείμενα**

Κατά την εργασία με παρουσιάσεις, ενδέχεται να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for Android via Java σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα του πλαισίου OLE ή την επέκτασή του.

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

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προβάλλεται αυτόματα μια προεπισκόπηση που αποτελείται από εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι αυτό που βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for Android via Java.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Προσθήκη εικόνας στους πόρους της παρουσίασης.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Αποτροπή Αλλαγής Μεγέθους και Θέσης Πλαισίου OLE Αντικειμένου**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί ένα μήνυμα που ζητά την ενημέρωση των συνδέσμων. Κάνοντας κλικ στο κουμπί «Update Links» μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου OLE επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση. Για να αποτρέψετε το PowerPoint από το να ζητά ενημέρωση των δεδομένων του αντικειμένου, ορίστε τη μέθοδο `setUpdateAutomatic` του interface [IOleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ioleobjectframe/) σε `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Εξαγωγή Ενσωματωμένων Αρχείων**

Το Aspose.Slides for Android via Java σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει τα αντικείμενα OLE που θέλετε να εξάγετε.
2. Περπατήστε (loop) σε όλα τα σχήματα της παρουσίασης και προσπελάστε τα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/oleobjectframe).
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια OLE αντικειμένων και γράψτε τα στον δίσκο.

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **Συχνές Ερωτήσεις**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται — το εικονίδιο/εικόνα υποκατάστασης (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Εάν χρειαστεί, ορίστε τη δική σας εικόνα προεπισκόπηση για να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει κλειδώματα επιπέδου σχήματος. Δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες τροποποιήσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel «ξεπροβάλλεται» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint ενδέχεται να ανανεώνει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/androidjava/working-solution-for-worksheet-resizing/) — είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε σταθερό πλαίσιο και ορίστε μια κατάλληλη εικόνα υποκατάστασης.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στο μορφότυπο PPTX;**

Στο PPTX, οι πληροφορίες «σχετικής διαδρομής» δεν είναι διαθέσιμες — μόνο η πλήρης διαδρομή. Οι σχετικές διαδρομές υπάρχουν μόνο στη παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/προσβάσιμες URI ή ενσωμάτωση.