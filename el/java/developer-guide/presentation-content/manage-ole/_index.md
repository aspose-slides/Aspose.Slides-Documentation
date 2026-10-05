---
title: Διαχείριση OLE σε Παρουσιάσεις με Java
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/java/manage-ole/
keywords:
- Αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση Αντικειμένου
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
- Java
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με το Aspose.Slides for Java. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE άψοφα."
---
## **Εισαγωγή**

{{% alert color="info" title="Σημείωση" %}}

OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει στα δεδομένα και τα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε μια άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Ας θεωρήσουμε ένα διάγραμμα που δημιουργήθηκε στο MS Excel. Το διάγραμμα τοποθετείται στη συνέχεια σε μια διαφάνεια του PowerPoint. Αυτό το διάγραμμα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτήν την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το διάγραμμα ανοίγει στην σχετική του εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για να ανοίξετε ή να επεξεργαστείτε το αντικείμενο.
- Ένα αντικείμενο OLE μπορεί να εμφανίζει τα πραγματικά του περιεχόμενα, όπως τα περιεχόμενα ενός διαγράμματος. Σε αυτήν την περίπτωση, το διάγραμμα ενεργοποιείται στο PowerPoint, φορτώνεται η διεπαφή του διαγράμματος και μπορείτε να τροποποιήσετε τα δεδομένα του διαγράμματος μέσα στο PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) σας επιτρέπει να εισάγετε OLE Objects σε διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Προσθήκη πλαισίων αντικειμένων OLE σε διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα διάγραμμα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for Java, μπορείτε να το κάνετε με τον εξής τρόπο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Διαβάστε το αρχείο Excel ως πίνακα byte.
4. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) στη διαφάνεια περιλαμβάνοντας τον πίνακα byte και άλλες πληροφορίες σχετικά με το αντικείμενο OLE.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα διάγραμμα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for Java. **Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) δέχεται μια επέκταση ενσωματώσιμου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύει σωστά τον τύπο αρχείου και να επιλέξει τη σωστή εφαρμογή για το άνοιγμα αυτού του αντικειμένου OLE.

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

Το Aspose.Slides for Java σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεσμο προς το αρχείο.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

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

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά της διαφάνειας χρησιμοποιώντας το δείκτη της.
3. Προσπελάστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο σε [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις το πλαίσιο αντικειμένου OLE έχει προσπελαστεί, μπορείτε να εκτελέσετε οποιαδήποτε ενέργεια πάνω του.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) και τα δεδομένα αρχείου του έχουν προσπελαστεί.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Λάβετε τα ενσωματωμένα δεδομένα του αρχείου.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Λάβετε την επέκταση του ενσωματωμένου αρχείου.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Πρόσβαση σε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε τις ιδιότητες του συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας Java δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να λάβετε τη διαδρομή του συνδεδεμένου αρχείου:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ελέγξτε αν το αντικείμενο OLE είναι συνδεδεμένο.
    if (oleFrame.isObjectLink()) {
        // Εκτυπώστε την πλήρη διαδρομή του συνδεδεμένου αρχείου.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Εκτυπώστε τη σχετική διαδρομή του συνδεδεμένου αρχείου εάν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="info" title="Σημείωση" %}}

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να προσπελάσετε αυτό το αντικείμενο και να τροποποιήσετε τα δεδομένα του με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά της διαφάνειας μέσω του δείκτη της. 
3. Προσπελάστε το σχήμα πλαισίου αντικειμένου OLE. Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο σε [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις το πλαίσιο αντικειμένου OLE έχει προσπελαστεί, μπορείτε να εκτελέσετε οποιαδήποτε ενέργεια πάνω του.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσπελάστε τα δεδομένα OLE.
6. Προσπελάστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) έχει προσπελαστεί, και τα δεδομένα του αρχείου του έχουν τροποποιηθεί για την ενημέρωση των δεδομένων του διαγράμματος.

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

    // Τροποποιήστε τα δεδομένα του Workbook.
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

## **Ενσωμάτωση άλλων τύπων αρχείων σε διαφάνειες**

Εκτός από διαγράμματα Excel, το Aspose.Slides for Java σας επιτρέπει να ενσωματώνετε άλλους τύπους αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα, ή του ζητείται να επιλέξει ένα κατάλληλο πρόγραμμα για το άνοιγμά του.

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

Κατά την εργασία με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for Java σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα του πλαισίου OLE ή την επέκτασή του.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE στο `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ορισμός εικόνων εικονιδίων και τίτλων για ενσωματωμένα αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι αυτή που βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for Java.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Add an image to the presentation resources.
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

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση στο PowerPoint, ίσως δείτε ένα μήνυμα που σας ζητά να ενημερώσετε τις συνδέσεις. Κάνοντας κλικ στο κουμπί «Ενημέρωση Συνδέσεων» μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE, επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση του αντικειμένου. Για να αποτρέψετε το PowerPoint από το να ζητά ενημέρωση των δεδομένων του αντικειμένου, καλέστε τη μέθοδο [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) του διεπαφής [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) με τιμή `false`:

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

Το Aspose.Slides for Java σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE με τον εξής τρόπο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) που περιέχει τα αντικείμενα OLE που θέλετε να εξάγετε.
2. Περιηγηθείτε σε όλα τα σχήματα στην παρουσίαση και προσπελάστε τα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένων OLE και γράψτε τα στο δίσκο.

Αυτός ο κώδικας Java δείχνει πώς να εξάγετε αρχεία που είναι ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

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

## **Συχνές ερωτήσεις**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται—το εικονίδιο/εικονική εικόνα (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Αν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

Για να διατηρήσετε επίσης το ενσωματωμένο αρχείο ως προσάρτημα PDF, καλέστε τη μέθοδο [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) με `true`. Αυτή η επιλογή είναι απενεργοποιημένη από προεπιλογή. Για ένα παράδειγμα και οδηγίες για τον έλεγχο του προσάρτηματος, δείτε το [Preserve Embedded OLE Files as PDF Attachments](/slides/el/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [shape-level locks](/slides/el/java/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint ενδέχεται να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/java/working-solution-for-worksheet-resizing/)—είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε σταθερό πλαίσιο και ορίστε μια κατάλληλη εικονική εικόνα.

**Θα διατηρηθούν οι σχετικοί δρόμοι για τα συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, οι πληροφορίες «σχετικού δρόμου» δεν είναι διαθέσιμες—μόνο η πλήρης διαδρομή. Οι σχετικοί δρόμοι υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/πρόσβαση μέσω URI ή την ενσωμάτωση.