---
title: Προσθήκη Υδατογραφημάτων σε Παρουσιάσεις σε Java
linktitle: Υδατογράφημα
type: docs
weight: 40
url: /el/java/watermark/
keywords:
- υδατογράφημα
- υδατογράφημα κειμένου
- υδατογράφημα εικόνας
- προσθήκη υδατογράφηματος
- αλλαγή υδατογράφηματος
- αφαίρεση υδατογράφηματος
- διαγραφή υδατογράφηματος
- προσθήκη υδατογράφηματος σε PPT
- προσθήκη υδατογράφηματος σε PPTX
- προσθήκη υδατογράφηματος σε ODP
- αφαίρεση υδατογράφηματος από PPT
- αφαίρεση υδατογράφηματος από PPTX
- αφαίρεση υδατογράφηματος από ODP
- διαγραφή υδατογράφηματος από PPT
- διαγραφή υδατογράφηματος από PPTX
- διαγραφή υδατογράφηματος από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument σε Java για να υποδείξετε ένα πρόχειρο, εμπιστευτικές πληροφορίες, πνευματικά δικαιώματα και άλλα."
---
## **Εισαγωγή**

**Υδατογράφημα** σε μια παρουσίαση είναι ένα σήμα κειμένου ή εικόνας που χρησιμοποιείται σε μια διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, ένα υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι πρόχειρη (π.χ., υδατογράφημα «Πρόχειρο»), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ., υδατογράφημα «Εμπιστευτικό»), για να προσδιοριστεί η εταιρεία στην οποία ανήκει (π.χ., υδατογράφημα «Όνομα Εταιρείας»), για την ταυτοποίηση του συγγραφέα της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην αποτροπή παραβίασης πνευματικών δικαιωμάτων υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφήματα χρησιμοποιούνται τόσο σε μορφές παρουσίασης PowerPoint όσο και OpenOffice. Στο Aspose.Slides, μπορείτε να προσθέσετε ένα υδατογράφημα σε αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/java/), υπάρχουν διάφοροι τρόποι δημιουργίας υδατογραφημάτων σε έγγραφα PowerPoint ή OpenOffice και τροποποίησης του σχεδιασμού και της συμπεριφοράς τους. Το κοινό στοιχείο είναι ότι για την προσθήκη υδατογραφημάτων κειμένου, πρέπει να χρησιμοποιήσετε τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/), και για την προσθήκη υδατογραφημάτων εικόνας, χρησιμοποιήστε την κλάση [PictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/pictureframe/) ή γεμίστε ένα σχήμα υδατογράφημα με εικόνα. Η `PictureFrame` υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) επιτρέποντας τη χρήση όλων των ευέλικτων ρυθμίσεων του αντικειμένου σχήματος. Δεδομένου ότι η `ITextFrame` δεν είναι σχήμα και οι ρυθμίσεις της είναι περιορισμένες, τυλίγεται σε ένα αντικείμενο [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/).

Υπάρχουν δύο τρόποι εφαρμογής υδατογράφηματος: σε μία μόνο διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Ο Διαχειριστής Διαφανειών (Slide Master) χρησιμοποιείται για την εφαρμογή υδατογράφηματος σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στον Διαχειριστή Διαφανειών, σχεδιάζεται ολοκληρωμένα εκεί και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζει την άδεια τροποποίησης του υδατογράφηματος σε μεμονωμένες διαφάνειες.

Το υδατογράφημα θεωρείται συνήθως μη διαθέσιμο για επεξεργασία από άλλους χρήστες. Για να αποτρέψετε την επεξεργασία του υδατογράφηματος (ή καλύτερα του γονικού σχήματος του υδατογράφημα), το Aspose.Slides παρέχει λειτουργία κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδ ωθεί σε κανονική διαφάνεια ή σε Διαχειριστή Διαφανειών. Όταν το σχήμα του υδατογράφημα κλειδ ωθεί στον Διαχειριστή Διαφανειών, κλειδ ωθεί σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε όνομα για το υδατογράφημα ώστε στο μέλλον, αν θέλετε να το διαγράψετε, να το εντοπίσετε στις διαφάνειες με βάση το όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με οποιονδήποτε τρόπο· ωστόσο, συνήθως τα υδατογραφήματα έχουν κοινά χαρακτηριστικά, όπως στοίχιση κέντρου, περιστροφή, θέση στο προσκήνιο κ.λπ. Θα εξετάσουμε πώς να τα χρησιμοποιήσουμε στα παραδείγματα που ακολουθούν.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογραφήματος Κειμένου σε Διαφάνεια**

Για να προσθέσετε ένα υδατογράφημα κειμένου σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια, στη συνέχεια να προσθέσετε ένα πλαίσιο κειμένου σε αυτό το σχήμα. Το πλαίσιο κειμένου αντιπροσωπεύεται από τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/). Αυτός ο τύπος δεν κληρονομείται από την [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/), η οποία διαθέτει ευρύ σύνολο ιδιοτήτων για την τοποθέτηση του υδατογράφημα με ευέλικτο τρόπο. Συνεπώς, το αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) τυλίγεται σε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/). Για να προσθέσετε κείμενο υδατογράφημα στο σχήμα, χρησιμοποιήστε τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) όπως φαίνεται παρακάτω.

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
- [Πώς να χρησιμοποιήσετε την κλάση TextFrame](/slides/el/java/text-formatting/)
{{% /alert %}}

### **Προσθήκη Υδατογραφήματος Κειμένου σε Παρουσίαση**

Αν θέλετε να προσθέσετε ένα υδατογράφημα κειμένου σε ολόκληρη την παρουσίαση (δηλαδή σε όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/masterslide/). Η υπόλοιπη λογική είναι η ίδια όπως όταν προσθέτετε υδατογράφημα σε μία διαφάνεια — δημιουργήστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) και στη συνέχεια προσθέστε το υδατογράφημα χρησιμοποιώντας τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

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
- [Πώς να χρησιμοποιήσετε το Slide Master](/slides/el/java/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφανούς Σχήματος Υδατογράφηματος**

Από προεπιλογή, το σχήμα του ορθογωνίου μορφοποιείται με χρώματα γεμίσματος και περιγράμματος. Οι ακόλουθες γραμμές κώδικα κάνουν το σχήμα διαφανές.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**

Μπορείτε να αλλάξετε τη γραμματοσειρά του υδατογράφημα κειμένου όπως φαίνεται παρακάτω.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Ορισμός Χρώματος Κειμένου Υδατογράφηματος**

Για να ορίσετε το χρώμα του κειμένου του υδατογράφημα, χρησιμοποιήστε αυτόν τον κώδικα:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Κεντράρισμα Υδατογραφήματος Κειμένου**

Είναι δυνατόν να κεντράρετε το υδατογράφημα σε μια διαφάνεια, και για αυτό μπορείτε να κάνετε το εξής:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

Η παρακάτω εικόνα δείχνει το τελικό αποτέλεσμα.

![Το υδατογράφημα κειμένου](text_watermark.png)

## **Υδατογράφημα Εικόνας**

### **Προσθήκη Υδατογραφήματος Εικόνας σε Παρουσίαση**

Για να προσθέσετε ένα υδατογράφημα εικόνας σε διαφάνεια παρουσίασης, μπορείτε να κάνετε το ακόλουθο:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Κλείδωμα Υδατογράφηματος από Επεξεργασία**

Αν είναι απαραίτητο να αποτρέψετε την επεξεργασία ενός υδατογράφημα, χρησιμοποιήστε τη μέθοδο [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) στο σχήμα. Με αυτήν την ιδιότητα, μπορείτε να προστατεύσετε το σχήμα από επιλογή, αλλαγή μεγέθους, μετακίνηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου από επεξεργασία και πολλά άλλα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Κλείδωμα του σχήματος υδατογράφημα από τροποποίηση
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Μεταφορά Υδατογράφηματος στην Πρόσθια Θέση**

Στο Aspose.Slides, η σειρά Z των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [IShapeCollection.reorder](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Για να το κάνετε αυτό, πρέπει να καλέσετε αυτή τη μέθοδο από τη λίστα των διαφανειών της παρουσίασης και να περάσετε την αναφορά του σχήματος και τον αριθμό της σειράς στη μέθοδο. Με αυτόν τον τρόπο, είναι δυνατόν να φέρετε ένα σχήμα στην πρόσοψη ή να το στείλετε στο παρασκήνιο της διαφάνειας. Αυτή η λειτουργία είναι ιδιαίτερα χρήσιμη εάν χρειάζεται να τοποθετήσετε ένα υδατογράφημα μπροστά από την παρουσίαση:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Ορισμός Περιστροφής Υδατογράφημα**

Ακολουθεί ένα παράδειγμα κώδικα για το πώς να ρυθμίσετε την περιστροφή του υδατογράφημα ώστε να τοποθετηθεί διαγώνια στην διαφάνεια:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Ορισμός Ονόματος για Υδατογράφημα**

Το Aspose.Slides σας επιτρέπει να ορίσετε το όνομα ενός σχήματος. Με τη χρήση του ονόματος του σχήματος, μπορείτε να το προσπελάσετε στο μέλλον για να το τροποποιήσετε ή να το διαγράψετε. Για να ορίσετε το όνομα του σχήματος του υδατογράφημα, αντιστοιχίστε το στη μέθοδο [IAutoShape.setName](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Αφαίρεση Υδατογράφημα**

Για να αφαιρέσετε το σχήμα του υδατογράφημα, χρησιμοποιήστε τη μέθοδο [IAutoShape.getName](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getName--) για να το βρείτε στα σχήματα της διαφάνειας. Στη συνέχεια, περάστε το σχήμα του υδατογράφημα στη μέθοδο [IShapeCollection.remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **Συχνές Ερωτήσεις**

### Τι είναι ένα υδατογράφημα και γιατί πρέπει να το χρησιμοποιήσω;

Ένα υδατογράφημα είναι μια επικάλυψη κειμένου ή εικόνας που εφαρμόζεται στις διαφάνειες και βοηθά στην προστασία της πνευματικής ιδιοκτησίας, στην ενίσχυση της αναγνώρισης της μάρκας ή στην πρόληψη μη εξουσιοδοτημένης χρήσης των παρουσιάσεων.

### Μπορώ να προσθέσω ένα υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;

Ναι, το Aspose.Slides σας επιτρέπει να προσθέσετε προγραμματιστικά ένα υδατογράφημα σε κάθε διαφάνεια μιας παρουσίασης. Μπορείτε να διατρέξετε όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις του υδατογράφημα ξεχωριστά.

### Πώς μπορώ να προσαρμόσω τη διαφάνεια του υδατογράφημα;

Μπορείτε να προσαρμόσετε τη διαφάνεια του υδατογράφημα τροποποιώντας τις ρυθμίσεις γεμίσματος ([getFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getFillFormat--)) του σχήματος. Αυτό διασφαλίζει ότι το υδατογράφημα είναι διακριτικό και δεν αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

### Ποιες μορφές εικόνας υποστηρίζονται για υδατογραφήματα;

Το Aspose.Slides υποστηρίζει διάφορες μορφές εικόνας όπως PNG, JPEG, GIF, BMP, SVG και άλλες.

### Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογράφημα κειμένου;

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ για να ταιριάζει με το σχεδιασμό της παρουσίασής σας και να διατηρήσει τη συνέπεια της μάρκας.

### Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογράφημα;

Μπορείτε να προσαρμόσετε τη θέση και τον προσανατολισμό του υδατογράφημα προγραμματιστικά τροποποιώντας τις συντεταγμένες, το μέγεθος και τις ιδιότητες περιστροφής του σχήματος.