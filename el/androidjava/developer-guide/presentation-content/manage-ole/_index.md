---
title: "Διαχείριση OLE σε Παρουσιάσεις σε Android"
linktitle: "Διαχείριση OLE"
type: docs
weight: 40
url: /el/androidjava/manage-ole/
keywords:
- "Αντικείμενο OLE"
- "Σύνδεση & Ενσωμάτωση Αντικειμένων"
- "Προσθήκη OLE"
- "Ενσωμάτωση OLE"
- "Προσθήκη αντικειμένου"
- "Ενσωμάτωση αντικειμένου"
- "Προσθήκη αρχείου"
- "Ενσωμάτωση αρχείου"
- "Συνδεδεμένο αντικείμενο"
- "Συνδεδεμένο αρχείο"
- "Αλλαγή OLE"
- "Εικονίδιο OLE"
- "Τίτλος OLE"
- "Εξαγωγή OLE"
- "Εξαγωγή αντικειμένου"
- "Εξαγωγή αρχείου"
- "PowerPoint"
- "παρουσίαση"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE στο PowerPoint και στα αρχεία OpenDocument με το Aspose.Slides για Android μέσω Java. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE αβίαστα."
---
## **Εισαγωγή**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει τα δεδομένα και τα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Σκεφτείτε ένα διάγραμμα που δημιουργήθηκε στο MS Excel. Το διάγραμμα τοποθετείται στη συνέχεια σε μια διαφάνεια του PowerPoint. Αυτό το διάγραμμα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτή την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το διάγραμμα ανοίγει στην αντίστοιχη εφαρμογή του (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για άνοιγμα ή επεξεργασία του αντικειμένου.
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός διαγράμματος. Σε αυτή την περίπτωση, το διάγραμμα ενεργοποιείται στο PowerPoint, φορτώνει η διεπαφή του διαγράμματος και μπορείτε να τροποποιήσετε τα δεδομένα του διαγράμματος εντός του PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) σας επιτρέπει να εισάγετε αντικείμενα OLE στις διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Προσθήκη Πλαισίων Αντικειμένου OLE στις Διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα διάγραμμα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for Android via Java, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Διαβάστε το αρχείο Excel ως πίνακα byte.
1. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) στη διαφάνεια, περιλαμβάνοντας τον πίνακα byte και άλλες πληροφορίες για το αντικείμενο OLE.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα διάγραμμα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for Android via Java.  
**Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) δέχεται ως δεύτερο παράμετρο μια επέκταση ενσωματωμένου αντικειμένου. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύει σωστά τον τύπο αρχείου και να επιλέγει τη σωστή εφαρμογή για το άνοιγμα αυτού του αντικειμένου OLE.

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Προσθήκη Συνδεδεμένων Πλαισίων Αντικειμένου OLE**

Το Aspose.Slides for Android via Java σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεσμο προς το αρχείο.

Αυτός ο κώδικας Java σας δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Προσθέστε ένα πλαίσιο αντικειμένου OLE με ένα συνδεδεμένο αρχείο Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Πρόσβαση σε Πλαίσια Αντικειμένου OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Λάβετε την αναφορά της διαφάνειας χρησιμοποιώντας τον δείκτη της.
3. Πρόσβαση στο σχήμα [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame).
   Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενο δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο αυτό ως [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE προς προσπέλαση.
4. Μόλις το πλαίσιο αντικειμένου OLE έχει προσπελαστεί, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) και τα δεδομένα αρχείου του προσπελαύνονται.

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Λάβετε τα ενσωματωμένα δεδομένα αρχείου.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Λάβετε την επέκταση του ενσωματωμένου αρχείου.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Πρόσβαση στις Ιδιότητες Συνδεδεμένου Πλαισίου Αντικειμένου OLE**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε τις ιδιότητες του συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας Java σας δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να λάβετε τη διαδρομή του συνδεδεμένου αρχείου:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Ελέγξτε αν το αντικείμενο OLE είναι συνδεδεμένο.
    if (oleFrame.isObjectLink()) {
        // Εκτυπώστε το πλήρες μονοπάτι του συνδεδεμένου αρχείου.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Εκτυπώστε το σχετικό μονοπάτι του συνδεδεμένου αρχείου αν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν το σχετικό μονοπάτι.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Αλλαγή Δεδομένων Αντικειμένου OLE**

{{% alert color="info" title="Note" %}}

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/).

{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να προσπελάσετε εκείνο το αντικείμενο και να τροποποιήσετε τα δεδομένα του με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Λάβετε την αναφορά της διαφάνειας μέσω του δείκτη της. 
3. Πρόσβαση στο σχήμα του πλαισίου αντικειμένου OLE.
   Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενο δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE προς προσπέλαση.
4. Μόλις το πλαίσιο αντικειμένου OLE έχει προσπελαστεί, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσπελάστε τα δεδομένα OLE.
6. Προσπελάστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε μια ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) προσπελάζεται, και τα δεδομένα αρχείου του τροποποιούνται για την ενημέρωση των δεδομένων του διαγράμματος.

```java 
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

    // Τροποποιήστε τα δεδομένα του βιβλίου εργασίας.
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

Εκτός από τα διαγράμματα Excel, το Aspose.Slides for Android via Java σας επιτρέπει να ενσωματώσετε άλλους τύπους αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα, ή ο χρήστης προτρέπεται να επιλέξει το κατάλληλο πρόγραμμα για το άνοιγμά του.

Αυτός ο κώδικας Java σας δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

Κατά τη δουλειά με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με καινούργια ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for Android via Java σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντας την ενημέρωση των δεδομένων του πλαισίου OLE ή της επέκτασής του.

Αυτός ο κώδικας Java σας δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

```java
import com.aspose.slides.*;

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

## **Ορισμός Εικόνων Εικονιδίων και Τίτλων για Ενσωματωμένα Αντικείμενα**

Αφού ενσωματώσετε ένα αντικείμενο OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από μια εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι ό,τι βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for Android via Java.

Αυτός ο κώδικας Java σας δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Προσθέστε μια εικόνα στους πόρους της παρουσίασης.
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

## **Αποτροπή Αλλαγής Μεγέθους και Επανατοποθέτησης Πλαισίου Αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση στο PowerPoint, ενδέχεται να εμφανιστεί ένα μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Κάνοντας κλικ στο κουμπί "Update Links" μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE, επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση του αντικειμένου. Για να αποτρέψετε το PowerPoint από το ερώτημα ενημέρωσης των δεδομένων του αντικειμένου, καλέστε τη μέθοδο [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) του διεπαφής [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) με `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Εξαγωγή Ενσωματωμένων Αρχείων**

Το Aspose.Slides for Android via Java σας επιτρέπει να εξάγετε τα αρχεία που έχουν ενσωματωθεί σε διαφάνειες ως αντικείμενα OLE με τον εξής τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) που περιέχει τα αντικείμενα OLE που προτίθεστε να εξάγετε.
2. Επανάληψη μέσω όλων των σχημάτων στην παρουσίαση και πρόσβαση στα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. Πρόσβαση στα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένου OLE και εγγραφή τους στο δίσκο.

Αυτός ο κώδικας Java σας δείχνει πώς να εξάγετε αρχεία που είναι ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData];
        fos.close();
    }
}

presentation.dispose();
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται—το εικονίδιο/εικόνα-αντικατάστασης (προεπισκόπηση). Το "ζωντανό" περιεχόμενο OLE δεν εκτελείται κατά τη διαδικασία απόδοσης. Εάν χρειαστεί, ορίστε τη δική σας εικόνα προεπισκόπησης ώστε να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.  
Για να διατηρήσετε επίσης το ενσωματωμένο αρχείο ως συνημμένο PDF, καλέστε τη λειτουργία [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) με `true`. Αυτή η επιλογή είναι απενεργοποιημένη από προεπιλογή. Για παράδειγμα και οδηγίες ελέγχου του συνημμένου, δείτε [Preserve Embedded OLE Files as PDF Attachments](/slides/el/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει κλειδώματα σε επίπεδο σχήματος. Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel "πηδά" ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint ενδέχεται να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/androidjava/working-solution-for-worksheet-resizing/)—είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε ένα σταθερό πλαίσιο και ορίστε μια κατάλληλη εικόνα-αντικατάστασης.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, οι πληροφορίες "σχετική διαδρομή" δεν είναι διαθέσιμες—μόνο η πλήρης διαδρομή. Οι σχετικές διαδρομές υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/πρόσβαση URI ή ενσωμάτωση.