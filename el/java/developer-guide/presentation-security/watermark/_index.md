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
description: "Διαχειριστείτε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με Java για να υποδείξετε πρόχειρο, εμπιστευτικές πληροφορίες, πνευματικά δικαιώματα και άλλα."
---
## **Εισαγωγή**

**Υδατογράφημα** σε μια παρουσίαση είναι ένδειξη κειμένου ή εικόνας που χρησιμοποιείται σε μια διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, το υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι πρόχειρη (π.χ. υδατογράφημα «Πρόχειρο»), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ. υδατογράφημα «Εμπιστευτικό»), για να προσδιορίσει σε ποια εταιρεία ανήκει (π.χ. υδατογράφημα «Όνομα Εταιρείας»), για να αναγνωριστεί ο συγγραφέας της παρουσίασης κ.ά. Το υδατογράφημα βοηθά στην αποτροπή παραβίασης πνευματικών δικαιωμάτων, υποδηλώνοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφία χρησιμοποιούνται τόσο σε μορφές PowerPoint όσο και σε μορφές OpenOffice. Στο Aspose.Slides, μπορείτε να προσθέσετε υδατογράφημα σε αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/java/), υπάρχουν διάφοροι τρόποι δημιουργίας υδατογραφιών σε έγγραφα PowerPoint ή OpenOffice και τροποποίησης του σχεδιασμού και της συμπεριφοράς τους. Το κοινό στοιχείο είναι ότι για την προσθήκη υδατογραφιών κειμένου πρέπει να χρησιμοποιήσετε τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/), ενώ για την προσθήκη υδατογραφιών εικόνας, χρησιμοποιήστε την κλάση [PictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/pictureframe/) ή γεμίστε ένα σχήμα υδατογραφήματος με εικόνα. Η `PictureFrame` υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) και επιτρέπει τη χρήση όλων των ευέλικτων ρυθμίσεων του αντικειμένου σχήματος. Δεδομένου ότι η `ITextFrame` δεν είναι σχήμα και οι ρυθμίσεις της είναι περιορισμένες, τυλίγεται σε ένα αντικείμενο [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/).

Υπάρχουν δύο τρόποι εφαρμογής υδατογραφήματος: σε μία μόνο διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Ο Δάσκαλος Διαφανειών (Slide Master) χρησιμοποιείται για την εφαρμογή υδατογραφήματος σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στον Δάσκαλο Διαφανειών, σχεδιάζεται πλήρως εκεί και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζεται η δυνατότητα τροποποίησης του υδατογραφήματος σε μεμονωμένες διαφάνειες.

Ένα υδατογράφημα συνήθως θεωρείται μη επεξεργάσιμο από άλλους χρήστες. Για να αποτρέψετε την επεξεργασία του υδατογραφήματος (ή του γονικού του σχήματος), το Aspose.Slides παρέχει λειτουργικότητα κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδωθεί σε κανονική διαφάνεια ή σε Δάσκαλο Διαφανειών. Όταν το σχήμα του υδατογραφήματος κλειδωθεί στον Δάσκαλο Διαφανειών, θα κλειδωθεί σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε όνομα για το υδατογράφημα ώστε στο μέλλον, εάν θέλετε να το διαγράψετε, να το βρείτε στις διαφάνειες με βάση το όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με οποιονδήποτε τρόπο· ωστόσο, υπάρχουν κοινά χαρακτηριστικά, όπως στοίχιση στο κέντρο, περιστροφή, θέση στο προσκήνιο κ.λπ. Θα δούμε πώς να τα χρησιμοποιήσουμε στα παραδείγματα παρακάτω.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογράφηματος Κειμένου σε Διαφάνεια**

Για να προσθέσετε υδατογράφημα κειμένου σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια και, στη συνέχεια, ένα πλαίσιο κειμένου στο σχήμα αυτό. Το πλαίσιο κειμένου αντιπροσωπεύεται από τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/). Αυτός ο τύπος δεν κληρονομεί από το [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/), το οποίο παρέχει εκτενή σύνολο ιδιοτήτων τοποθέτησης του υδατογραφήματος με ευέλικτο τρόπο. Συνεπώς, το αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) τυλίγεται σε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/). Για να προσθέσετε κείμενο υδατογραφήματος στο σχήμα, χρησιμοποιήστε τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) όπως φαίνεται παρακάτω.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Πώς να χρησιμοποιήσετε την κλάση TextFrame](/slides/el/java/text-formatting/)
{{% /alert %}}

### **Προσθήκη Υδατογράφηματος Κειμένου σε Ολόκληρη Παρουσίαση**

Εάν θέλετε να προσθέσετε υδατογράφημα κειμένου σε ολόκληρη την παρουσίαση (δηλαδή σε όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/masterslide/). Η υπόλοιπη λογική είναι η ίδια με την προσθήκη υδατογραφήματος σε μία διαφάνεια — δημιουργήστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) και κατόπιν προσθέστε το υδατογράφημα με τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Πώς να χρησιμοποιήσετε το Slide Master](/slides/el/java/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφάνειας Σχήματος Υδατογραφήματος**

Από προεπιλογή, το ορθογώνιο σχήμα έχει χρώματα γεμίσματος και περιγράμματος. Οι παρακάτω γραμμές κώδικα κάνουν το σχήμα διαφανές.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**

Μπορείτε να αλλάξετε τη γραμματοσειρά του υδατογραφήματος κειμένου όπως φαίνεται παρακάτω.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Ορισμός Χρώματος Κειμένου Υδατογραφήματος**

Για να ορίσετε το χρώμα του κειμένου του υδατογραφήματος, χρησιμοποιήστε τον ακόλουθο κώδικα:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Στοίχιση Υδατογραφήματος Κειμένου στο Κέντρο**

Είναι δυνατόν να κεντράρετε το υδατογράφημα σε μια διαφάνεια, και για αυτό μπορείτε να κάνετε τα εξής:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Η παρακάτω εικόνα δείχνει το τελικό αποτέλεσμα.

![The text watermark](text_watermark.png)

## **Υδατογράφημα Εικόνας**

### **Προσθήκη Υδατογραφήματος Εικόνας σε Παρουσίαση**

Για να προσθέσετε υδατογράφημα εικόνας σε διαφάνεια παρουσίασης, μπορείτε να ακολουθήσετε τα παρακάτω βήματα:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Κλείδωμα Υδατογραφήματος από Επεξεργασία**

Εάν χρειάζεται να αποτρέψετε την επεξεργασία ενός υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) στο σχήμα. Με αυτήν την ιδιότητα, μπορείτε να προστατεύσετε το σχήμα από επιλογή, αλλαγή μεγέθους, μετακίνηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου από επεξεργασία και πολλά άλλα:

```java
// Κλείδωμα του σχήματος υδατογραφήματος από τροποποίηση
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Μεταφορά Υδατογραφήματος στην Προσκήνιο**

Στο Aspose.Slides, η σειρά Z των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [IShapeCollection.reorder](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Για να το κάνετε αυτό, καλέστε τη μέθοδο από τη λίστα διαφανειών της παρουσίασης και περάστε την αναφορά του σχήματος και τον αριθμό σειράς του. Με αυτόν τον τρόπο είναι δυνατόν να φέρετε ένα σχήμα στην προσοχή ή να το στείλετε στο βάθος της διαφάνειας. Η δυνατότητα αυτή είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να τοποθετήσετε το υδατογράφημα μπροστά από την παρουσίαση:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Ορισμός Περιστροφής Υδατογραφήματος**

Ακολουθεί παράδειγμα κώδικα για την προσαρμογή της περιστροφής του υδατογραφήματος ώστε να τοποθετηθεί διαγώνια στην διαφάνεια:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Ορισμός Ονόματος για Υδατογράφημα**

Το Aspose.Slides επιτρέπει τον ορισμό ονόματος σχήματος. Με τη χρήση του ονόματος σχήματος, μπορείτε να το προσπελάσετε στο μέλλον για τροποποίηση ή διαγραφή. Για να ορίσετε το όνομα του σχήματος υδατογραφήματος, καλέστε τη μέθοδο [IAutoShape.setName](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Αφαίρεση Υδατογραφήματος**

Για να αφαιρέσετε το σχήμα του υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [IAutoShape.getName](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getName--) για να το βρείτε στα σχήματα της διαφάνειας. Στη συνέχεια, περάστε το σχήμα υδατογραφήματος στη μέθοδο [IShapeCollection.remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Συχνές Ερωτήσεις**

**Τι είναι το υδατογράφημα και γιατί πρέπει να το χρησιμοποιήσω;**

Το υδατογράφημα είναι μια επικάλυψη κειμένου ή εικόνας που εφαρμόζεται στις διαφάνειες και βοηθά στην προστασία της πνευματικής ιδιοκτησίας, στην ενίσχυση της αναγνωρισιμότητας της μάρκας ή στην αποτροπή μη εξουσιοδοτημένης χρήσης των παρουσιάσεων.

**Μπορώ να προσθέσω υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;**

Ναι, το Aspose.Slides επιτρέπει τον προγραμματισμό προσθήκης υδατογραφήματος σε κάθε διαφάνεια μιας παρουσίασης. Μπορείτε να επαναλάβετε τη διαδικασία για όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις υδατογραφήματος ξεχωριστά.

**Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογραφήματος;**

Μπορείτε να ρυθμίσετε τη διαφάνεια του υδατογραφήματος τροποποιώντας τις ρυθμίσεις γεμίσματος ([getFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getFillFormat--)) του σχήματος. Αυτό εξασφαλίζει ότι το υδατογράφημα είναι διακριτικό και δεν αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

**Ποιες μορφές εικόνας υποστηρίζονται για υδατογραφήματα;**

Το Aspose.Slides υποστηρίζει διάφορες μορφές εικόνας όπως PNG, JPEG, GIF, BMP, SVG κ.ά.

**Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογραφήματος κειμένου;**

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ ώστε να ταιριάζει με το σχέδιο της παρουσίασής σας και να διατηρεί τη συνέπεια της μάρκας.

**Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογραφήματος;**

Μπορείτε να προσαρμόσετε τη θέση και τον προσανατολισμό του υδατογραφήματος προγραμματιστικά τροποποιώντας τις συντεταγμένες, το μέγεθος και τις ιδιότητες περιστροφής του σχήματος.