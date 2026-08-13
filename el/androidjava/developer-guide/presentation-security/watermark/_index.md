---
title: Προσθήκη Υδατογραφημάτων σε Παρουσιάσεις στο Android
linktitle: Υδατογράφημα
type: docs
weight: 40
url: /el/androidjava/watermark/
keywords:
- υδατογράφημα
- υδατογράφημα κειμένου
- υδατογράφημα εικόνας
- προσθήκη υδατογραφήματος
- αλλαγή υδατογραφήματος
- αφαίρεση υδατογραφήματος
- διαγραφή υδατογράφηματος
- προσθήκη υδατογραφήματος σε PPT
- προσθήκη υδατογραφήματος σε PPTX
- προσθήκη υδατογραφήματος σε ODP
- αφαίρεση υδατογράφηματος από PPT
- αφαίρεση υδατογράφηματος από PPTX
- αφαίρεση υδατογράφηματος από ODP
- διαγραφή υδατογράφηματος από PPT
- διαγραφή υδατογράφηματος από PPTX
- διαγραφή υδατογράφηματος από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχείριση υδατογραφημάτων κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument στο Android με Java για να υποδείξετε προσχέδιο, εμπιστευτικές πληροφορίες και άλλα."
---
## **Εισαγωγή**

**Ένα υδατογράφημα** σε μια παρουσίαση είναι μια σήμανση κειμένου ή εικόνας που χρησιμοποιείται σε μία διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, ένα υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι πρόχειρη (π.χ., υδατογράφημα «Πρόχειρο»), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ., υδατογράφημα «Εμπιστευτικό»), για να προσδιορίσει σε ποια εταιρεία ανήκει (π.χ., υδατογράφημα «Όνομα Εταιρείας»), για να ταυτοποιήσει τον συγγραφέα της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην πρόληψη παραβιάσεων πνευματικών δικαιωμάτων, υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφήματα χρησιμοποιούνται τόσο στις μορφές παρουσίασης PowerPoint όσο και OpenOffice. Στο Aspose.Slides, μπορείτε να προσθέσετε υδατογράφημα σε αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/android-java/), υπάρχουν διάφοροι τρόποι για να δημιουργήσετε υδατογραφήματα σε έγγραφα PowerPoint ή OpenOffice και να τροποποιήσετε το σχεδιασμό και τη συμπεριφορά τους. Το κοινό στοιχείο είναι ότι για την προσθήκη υδατογραφημάτων κειμένου, πρέπει να χρησιμοποιήσετε τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/), ενώ για την προσθήκη υδατογραφημάτων εικόνας, χρησιμοποιήστε την κλάση [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/) ή γεμίστε ένα σχήμα υδατογραφήματος με εικόνα. Το `PictureFrame` υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) , επιτρέποντάς σας να χρησιμοποιήσετε όλες τις ευέλικτες ρυθμίσεις του αντικειμένου σχήματος. Επειδή το `ITextFrame` δεν είναι σχήμα και οι ρυθμίσεις του είναι περιορισμένες, ενσωματώνεται σε ένα αντικείμενο [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/).

Υπάρχουν δύο τρόποι εφαρμογής ενός υδατογραφήματος: σε μία ενιαία διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Το Slide Master χρησιμοποιείται για την εφαρμογή υδατογραφήματος σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στο Slide Master, σχεδιάζεται εκεί πλήρως και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζει την άδεια τροποποίησης του υδατογραφήματος σε μεμονωμένες διαφάνειες.

Ένα υδατογράφημα θεωρείται συνήθως μη επεξεργάσιμο από άλλους χρήστες. Για να αποτραπεί η επεξεργασία του υδατογραφήματος (ή πιο συγκεκριμένα του γονικού του σχήματος), το Aspose.Slides παρέχει λειτουργία κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδωθεί σε κανονική διαφάνεια ή σε Slide Master. Όταν το σχήμα υδατογραφήματος κλειδωθεί στο Slide Master, κλειδώνεται σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε όνομα για το υδατογράφημα ώστε στο μέλλον, αν θέλετε να το διαγράψετε, να το βρείτε στις μορφές της διαφάνειας με βάση το όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με οποιονδήποτε τρόπο· ωστόσο, συνήθως υπάρχουν κοινά χαρακτηριστικά στα υδατογραφήματα, όπως κεντρισμένη στοίχιση, περιστροφή, θέση εμπρός κ.λπ. Θα δούμε πώς να τα χρησιμοποιήσουμε στα παρακάτω παραδείγματα.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογραφήματος Κειμένου σε Διαφάνεια**

Για να προσθέσετε υδατογράφημα κειμένου σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια, στη συνέχεια να προσθέσετε ένα πλαίσιο κειμένου σε αυτό το σχήμα. Το πλαίσιο κειμένου αντιπροσωπεύεται από τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/). Αυτός ο τύπος δεν κληρονομείται από το [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/), το οποίο διαθέτει ευρύ σύνολο ιδιοτήτων για τη θέση του υδατογραφήματος με ευέλικτο τρόπο. Επομένως, το αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) περιβιβάζεται σε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/). Για να προσθέσετε κείμενο υδατογραφήματος στο σχήμα, χρησιμοποιήστε τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) όπως φαίνεται παρακάτω.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Δείτε επίσης" %}} 
- [Πώς να Χρησιμοποιήσετε την Κλάση TextFrame](/slides/el/androidjava/text-formatting/)
{{% /alert %}}

### **Προσθήκη Υδατογραφήματος Κειμένου σε Παρουσίαση**

Αν θέλετε να προσθέσετε υδατογράφημα κειμένου σε ολόκληρη την παρουσίαση (δηλαδή σε όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/masterslide/). Η υπόλοιπη λογική είναι η ίδια όπως όταν προσθέτετε υδατογράφημα σε μια μοναδική διαφάνεια — δημιουργήστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) και, στη συνέχεια, προσθέστε το υδατογράφημα χρησιμοποιώντας τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Δείτε επίσης" %}} 
- [Πώς να Χρησιμοποιήσετε το Slide Master](/slides/el/androidjava/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφάνειας Σχήματος Υδατογραφήματος**

Από προεπιλογή, το ορθογώνιο σχήμα έχει χρώμα γεμίσματος και περιγράμματος. Οι παρακάτω γραμμές κώδικα καθιστούν το σχήμα διαφανές.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**

Μπορείτε να αλλάξετε τη γραμματοσειρά του υδατογραφήματος κειμένου όπως φαίνεται παρακάτω.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Ορισμός Χρώματος Κειμένου Υδατογραφήματος**

Για να ορίσετε το χρώμα του κειμένου του υδατογραφήματος, χρησιμοποιήστε αυτόν τον κώδικα:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Κεντρισμός Υδατογραφήματος Κειμένου**

Μπορείτε να κεντράρετε το υδατογράφημα σε μία διαφάνεια, κάνοντας ως εξής:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

Η παρακάτω εικόνα δείχνει το τελικό αποτέλεσμα.

![The text watermark](text_watermark.png)

## **Υδατογράφημα Εικόνας**

### **Προσθήκη Υδατογράφημα Εικόνας σε Παρουσίαση**

Για να προσθέσετε υδατογράφημα εικόνας σε διαφάνεια παρουσίασης, μπορείτε να ακολουθήσετε τα εξής βήματα:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Κλείδωμα Υδατογραφήματος από Επεξεργασία**

Αν χρειάζεται να αποτρέψετε την επεξεργασία του υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) στο σχήμα. Με αυτήν την ιδιότητα, μπορείτε να προστατεύσετε το σχήμα από επιλογή, αλλαγή μεγέθους, μετακίνηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου από επεξεργασία και πολύ περισσότερα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Κλείδωμα του σχήματος υδατογράφηματος από τροποποίηση
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Μεταφορά Υδατογραφήματος Εμπρός**

Στο Aspose.Slides, η σειρά Z των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [IShapeCollection.reorder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) . Για να το κάνετε αυτό, καλέστε τη μέθοδο από τη λίστα διαφανειών της παρουσίασης και περάστε την αναφορά του σχήματος και τον αριθμό σειράς του στη μέθοδο. Με αυτόν τον τρόπο, είναι δυνατόν να φέρετε ένα σχήμα εμπρός ή να το στείλετε στο παρασκήνιο της διαφάνειας. Η λειτουργία αυτή είναι ιδιαιτέρως χρήσιμη όταν πρέπει να τοποθετήσετε ένα υδατογράφημα μπροστά από την παρουσίαση:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Ορισμός Περιστροφής Υδατογραφήματος**

Ακολουθεί παράδειγμα κώδικα για το πώς να ρυθμίσετε την περιστροφή του υδατογραφήματος ώστε να τοποθετείται διαγώνια κατά μήκος της διαφάνειας:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Ορισμός Ονόματος για Υδατογράφημα**

Το Aspose.Slides σας επιτρέπει να ορίσετε το όνομα ενός σχήματος. Με τη χρήση του ονόματος σχήματος, μπορείτε στο μέλλον να το προσπελάσετε για τροποποίηση ή διαγραφή. Για να ορίσετε το όνομα του σχήματος υδατογραφήματος, καλέστε τη μέθοδο [IAutoShape.setName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Αφαίρεση Υδατογραφήματος**

Για να αφαιρέσετε το σχήμα υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [IAutoShape.getName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getName--) για να το βρείτε στις μορφές της διαφάνειας. Στη συνέχεια, περάστε το σχήμα υδατογραφήματος στη μέθοδο [IShapeCollection.remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

### Τι είναι ένα υδατογράφημα και γιατί πρέπει να το χρησιμοποιήσω;

Ένα υδατογράφημα είναι μια επικάλυψη κειμένου ή εικόνας που εφαρμόζεται σε διαφάνειες και βοηθά στην προστασία της πνευματικής ιδιοκτησίας, στην ενίσχυση της αναγνωρισιμότητας της μάρκας ή στην αποτροπή μη εξουσιοδοτημένης χρήσης των παρουσιάσεων.

### Μπορώ να προσθέσω υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;

Ναι, το Aspose.Slides επιτρέπει την προγραμματιστική προσθήκη υδατογραφήματος σε κάθε διαφάνεια μιας παρουσίασης. Μπορείτε να επαναλάβετε τη διαδικασία για όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις του υδατογραφήματος μεμονωμένα.

### Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογραφήματος;

Μπορείτε να ρυθμίσετε τη διαφάνεια του υδατογράφηματος τροποποιώντας τις ρυθμίσεις γεμίσματος ([getFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getFillFormat--)) του σχήματος. Αυτό εξασφαλίζει ότι το υδατογράφημα είναι διακριτικό και δεν αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

### Ποιοι μορφοί εικόνας υποστηρίζονται για υδατογραφήματα;

Το Aspose.Slides υποστηρίζει διάφορους μορφούς εικόνας όπως PNG, JPEG, GIF, BMP, SVG και άλλους.

### Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογράφηματος κειμένου;

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ ώστε να ταιριάζει με το σχεδιασμό της παρουσίασής σας και να διατηρεί τη συνέπεια της μάρκας.

### Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογραφήματος;

Μπορείτε να προσαρμόσετε τη θέση και τον προσανατολισμό του υδατογραφήματος προγραμματιστικά, τροποποιώντας τις συντεταγμένες, το μέγεθος και τις ιδιότητες περιστροφής του σχήματος.