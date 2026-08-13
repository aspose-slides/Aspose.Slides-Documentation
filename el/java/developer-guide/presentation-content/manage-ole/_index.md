---
title: Διαχείριση OLE σε Παρουσιάσεις χρησιμοποιώντας Java
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
- συνδεμένο αρχείο
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
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με το Aspose.Slides για Java. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE αδιάκοπα."
---
## **Εισαγωγή**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει σε δεδομένα και αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Σκεφτείτε ένα γράφημα που δημιουργήθηκε στο MS Excel. Το γράφημα τοποθετείται στη συνέχεια μέσα σε μια διαφάνεια του PowerPoint. Αυτό το γράφημα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτή την περίπτωση, όταν κάνετε διπλό‑κλικ στο εικονίδιο, το γράφημα ανοίγει στην σχετική εφαρμογή (Excel) ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός γραφήματος. Σε αυτήν την περίπτωση, το γράφημα ενεργοποιείται στο PowerPoint, φορτώνεται η διεπαφή του γραφήματος και μπορείτε να τροποποιήσετε τα δεδομένα του γραφήματος μέσα στο PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/el/java/) επιτρέπει την εισαγωγή OLE αντικειμένων στις διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame)).

## **Προσθήκη πλαισίων αντικειμένων OLE στις διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα γράφημα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας Aspose.Slides for Java, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του ευρετηρίου της.
1. Διαβάστε το αρχείο Excel ως πίνακα byte.
1. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame) στη διαφάνεια περιέχοντας τον πίνακα byte και τις άλλες πληροφορίες για το αντικείμενο OLE.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα γράφημα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας Aspose.Slides for Java.
**Σημείωση** ότι ο κατασκευαστής του [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleEmbeddedDataInfo) δέχεται ως δεύτερη παράμετρο μια επέκταση ενσωματώσιμου αντικειμένου. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύσει σωστά τον τύπο του αρχείου και να επιλέξει τη σωστή εφαρμογή για το άνοιγμα του αντικειμένου OLE.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Προσθήκη συνδεδεμένων πλαισίων αντικειμένων OLE**

Aspose.Slides for Java επιτρέπει την προσθήκη ενός [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεσμο προς το αρχείο.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame) με συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Προσθήκη πλαισίου αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Πρόσβαση σε πλαίσια αντικειμένων OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το αποκτήσετε με τον ακόλουθο τρόπο:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά της διαφάνειας χρησιμοποιώντας το ευρετήριο της.
3. Αποκτήστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/OleObjectFrame). Στο παράδειγμά μας, χρησιμοποιήσαμε το PPTX που δημιουργήθηκε προηγουμένως και έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/IOleObjectFrame). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις αποκτηθεί το πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία επάνω του.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) και τα δεδομένα του αρχείου του προέρχονται.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Ανάκτηση των ενσωματωμένων δεδομένων αρχείου.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Ανάκτηση της επέκτασης του ενσωματωμένου αρχείου.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Πρόσβαση στις ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE**

Aspose.Slides επιτρέπει την πρόσβαση στις ιδιότητες των συνδεδεμένων πλαισίων αντικειμένου OLE.

Αυτός ο κώδικας Java δείχνει πώς να ελέγξετε εάν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να λάβετε τη διαδρομή προς το συνδεδεμένο αρχείο:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ελέγξτε αν το αντικείμενο OLE είναι συνδεδεμένο.
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

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="info" %}} 

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να αποκτήσετε πρόσβαση στο αντικείμενο και να τροποποιήσετε τα δεδομένα του ως εξής:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά της διαφάνειας μέσω του ευρετηρίου της. 
3. Αποκτήστε το σχήμα του πλαισίου αντικειμένου OLE. Στο παράδειγμά μας, χρησιμοποιήσαμε το PPTX που δημιουργήθηκε προηγουμένως και έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/IOleObjectFrame). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις αποκτηθεί το πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία επάνω του.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και αποκτήστε πρόσβαση στα δεδομένα OLE.
6. Αποκτήστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) προέρχεται, και τα δεδομένα του αρχείου τροποποιούνται ώστε να ενημερώσουν τα δεδομένα του γραφήματος.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Διαβάστε τα δεδομένα του αντικειμένου OLE ως αντικείμενο Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Τροποποίηση των δεδομένων του βιβλίου εργασίας.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Αλλαγή των δεδομένων του αντικειμένου πλαισίου OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ενσωμάτωση άλλων τύπων αρχείων στις διαφάνειες**

Εκτός από γραφήματα Excel, Aspose.Slides for Java επιτρέπει την ενσωμάτωση άλλων τύπων αρχείων στις διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε HTML, PDF και ZIP αρχεία ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό‑κλικ στο ενσωματωμένο αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα ή του ζητείται να επιλέξει ένα κατάλληλο πρόγραμμα για το άνοιγμα.

Αυτός ο κώδικας Java δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **Ορισμός τύπων αρχείων για ενσωματωμένα αντικείμενα**

Κατά την εργασία με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Aspose.Slides for Java επιτρέπει τον ορισμό του τύπου αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντας την ενημέρωση των δεδομένων του πλαισίου OLE ή της επέκτασής του.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Αλλαγή του τύπου αρχείου σε ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ορισμός εικόνων εικονιδίου και τίτλων για ενσωματωμένα αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από μια εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι αυτό που βλέπουν οι χρήστες πριν αποκτήσουν πρόσβαση ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας Aspose.Slides for Java.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Προσθήκη εικόνας στους πόρους της παρουσίασης.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Αποτροπή αλλαγής μεγέθους και θέσης πλαισίου αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίγετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Κάνοντας κλικ στο κουμπί «Update Links» μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση. Για να αποτρέψετε το PowerPoint από το να ζητά ενημέρωση των δεδομένων του αντικειμένου, ορίστε τη μέθοδο `setUpdateAutomatic` της διεπαφής [IOleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioleobjectframe/) σε `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Εξαγωγή ενσωματωμένων αρχείων**

Aspose.Slides for Java επιτρέπει την εξαγωγή των αρχείων που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE ως εξής:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει τα αντικείμενα OLE που θέλετε να εξαγάγετε.
2. Περιηγηθείτε σε όλα τα σχήματα της παρουσίασης και αποκτήστε πρόσβαση στα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/oleobjectframe).
3. Αποκτήστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένων OLE και γράψτε τα στο δίσκο.

Αυτός ο κώδικας Java δείχνει πώς να εξαγάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

### Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται — το εικονίδιο/εικόνα προεπισκόπησης. Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Εάν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης ώστε να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

### Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [κλειδώματα επιπέδου σχήματος](/slides/el/java/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά εμποδίζει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

### Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδάει» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;

Το PowerPoint μπορεί να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/java/working-solution-for-worksheet-resizing/) — είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε σταθερό πλαίσιο και ορίστε μια κατάλληλη εναλλακτική εικόνα.

### Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;

Στη μορφή PPTX, οι πληροφορίες «σχετική διαδρομή» δεν είναι διαθέσιμες — μόνο η πλήρης διαδρομή. Σχετικές διαδρομές υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/προσβάσιμα URIs ή ενσωμάτωση.