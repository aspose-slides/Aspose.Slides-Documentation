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
- διαγραφή υδατογραφήματος
- προσθήκη υδατογραφήματος σε PPT
- προσθήκη υδατογραφήματος σε PPTX
- προσθήκη υδατογραφηματος σε ODP
- αφαίρεση υδατογραφήματος από PPT
- αφαίρεση υδατογραφήματος από PPTX
- αφαίρεση υδατογραφήματος από ODP
- διαγραφή υδατογραφηματος από PPT
- διαγραφή υδατογραφηματος από PPTX
- διαγραφή υδατογραφηματος από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument στο Android με Java για να υποδείξετε ένα προσχέδιο, εμπιστευτικές πληροφορίες και άλλα."
---
## **Εισαγωγή**

**Ένα υδατογράφημα** σε μια παρουσίαση είναι σήμα κειμένου ή εικόνας που χρησιμοποιείται σε μια διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, ένα υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι προσχέδιο (π.χ., υδατογράφημα «Προσχέδιο»), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ., υδατογράφημα «Εμπιστευτικό»), για να προσδιορίσει σε ποια εταιρεία ανήκει (π.χ., υδατογράφημα «Όνομα Εταιρείας»), για την ταυτοποίηση του συγγραφέα της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην αποτροπή παραβιάσεων πνευματικών δικαιωμάτων, υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφήματα χρησιμοποιούνται τόσο σε μορφές παρουσίασης PowerPoint όσο και OpenOffice. Στο Aspose.Slides, μπορείτε να προσθέσετε υδατογράφημα σε αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/android-java/), υπάρχουν διάφοροι τρόποι για να δημιουργήσετε υδατογραφήματα σε έγγραφα PowerPoint ή OpenOffice και να τροποποιήσετε το σχέδιο και τη συμπεριφορά τους. Το κοινό στοιχείο είναι ότι για προσθήκη υδατογράφηματος κειμένου, πρέπει να χρησιμοποιήσετε τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/), και για προσθήκη υδατογράφηματος εικόνας, χρησιμοποιήστε την κλάση [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/) ή γεμίστε ένα σχήμα υδατογράφηματος με εικόνα. Η `PictureFrame` υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) επιτρέποντάς σας να χρησιμοποιήσετε όλες τις ευέλικτες ρυθμίσεις του αντικειμένου σχήματος. Επειδή το `ITextFrame` δεν είναι σχήμα και οι ρυθμίσεις του είναι περιορισμένες, τυλίγεται σε ένα αντικείμενο [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/).

Υπάρχουν δύο τρόποι εφαρμογής υδατογραφήματος: σε μεμονωμένη διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Ο Δάσκαλος Διαφάνειας (Slide Master) χρησιμοποιείται για να εφαρμόσει υδατογράφημα σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στον Δάσκαλο, σχεδιάζεται πλήρως εκεί και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζει την άδεια τροποποίησης του υδατογραφήματος σε μεμονωμένες διαφάνειες.

Το υδατογράφημα θεωρείται συνήθως μη διαθέσιμο για επεξεργασία από άλλους χρήστες. Για να αποτραπεί η επεξεργασία του υδατογραφήματος (ή καλύτερα του γονικού του σχήματος), το Aspose.Slides παρέχει δυνατότητα κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδωθεί σε κανονική διαφάνεια ή σε Δάσκαλο Διαφάνειας. Όταν το σχήμα του υδατογραφήματος κλειδώνεται στον Δάσκαλο, κλειδώνεται σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε όνομα για το υδατογράφημα ώστε στο μέλλον, αν θέλετε να το διαγράψετε, να το εντοπίσετε στις διαφάνειες με βάση το όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με οποιονδήποτε τρόπο· ωστόσο συνήθως υπάρχουν κοινά χαρακτηριστικά, όπως κεντρική στοίχιση, περιστροφή, θέση εμπρός κ.λπ. Θα εξετάσουμε πώς να τα χρησιμοποιήσουμε στα παρακάτω παραδείγματα.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογραφήματος Κειμένου σε Διαφάνεια**

Για να προσθέσετε υδατογράφημα κειμένου σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια, μετά να προσθέσετε ένα πλαίσιο κειμένου σε αυτό το σχήμα. Το πλαίσιο κειμένου αντιπροσωπεύεται από τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/). Αυτός ο τύπος δεν κληρονομείται από το [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/), το οποίο έχει ένα ευρύ σύνολο ιδιοτήτων για τον ευέλικτο καθορισμό θέσης του υδατογραφήματος. Συνεπώς, το αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) τυλίγεται σε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/). Για να προσθέσετε κείμενο υδατογραφήματος στο σχήμα, χρησιμοποιήστε τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) όπως φαίνεται παρακάτω.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [Πώς να Χρησιμοποιήσετε την Κλάση TextFrame](/slides/el/androidjava/text-formatting/)
{{% /alert %}}

### **Προσθήκη Υδατογράφηματος Κειμένου σε Παρουσίαση**

Εάν θέλετε να προσθέσετε υδατογράφημα κειμένου σε ολόκληρη την παρουσίαση (δηλαδή σε όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/masterslide/). Η υπόλοιπη λογική είναι η ίδια όπως κατά την προσθήκη υδατογράφηματος σε μία διαφάνεια — δημιουργήστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) και μετά προσθέστε το υδατογράφημα χρησιμοποιώντας τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [Πώς να Χρησιμοποιήσετε το Slide Master](/slides/el/androidjava/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφάνειας Σχήματος Υδατογράφηματος**

Από προεπιλογή, το ορθογώνιο σχήμα είναι μορφοποιημένο με χρώματα γεμίσματος και γραμμής. Οι παρακάτω γραμμές κώδικα κάνουν το σχήμα διαφανές.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**

Μπορείτε να αλλάξετε τη γραμματοσειρά του κειμένου υδατογραφήματος όπως φαίνεται παρακάτω.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Ορισμός Χρώματος Κειμένου Υδατογράφηματος**

Για να θέσετε το χρώμα του κειμένου υδατογραφήματος, χρησιμοποιήστε αυτόν τον κώδικα:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Κεντράρισμα Υδατογράφηματος Κειμένου**

Είναι δυνατόν να κεντράρετε το υδατογράφημα σε μια διαφάνεια, και για αυτό μπορείτε να κάνετε το εξής:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

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

Για να προσθέσετε υδατογράφημα εικόνας σε διαφάνεια παρουσίασης, μπορείτε να ακολουθήσετε τα παρακάτω:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Κλείδωμα Υδατογραφήματος από Επεξεργασία**

Εάν είναι απαραίτητο να αποτραπεί η επεξεργασία του υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) στο σχήμα. Με αυτήν την ιδιότητα, μπορείτε να προστατέψετε το σχήμα από επιλογή, αλλαγή μεγέθους, επανατοποθέτηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου από επεξεργασία και πολλά άλλα:

```java
// Κλείδωμα του σχήματος υδατογραφήματος από τροποποίηση
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Μεταφορά Υδατογραφήματος στο Εμπρός**

Στο Aspose.Slides, η σειρά Z των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [IShapeCollection.reorder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Για να το κάνετε αυτό, πρέπει να καλέσετε αυτή τη μέθοδο από τη λίστα διαφανειών της παρουσίασης και να περάσετε την αναφορά του σχήματος και τον αριθμό σειράς του στη μέθοδο. Με αυτόν τον τρόπο, είναι δυνατή η μεταφορά ενός σχήματος στο εμπρός ή στο πίσω μέρος της διαφάνειας. Αυτή η λειτουργία είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να τοποθετήσετε υδατογράφημα μπροστά από την παρουσίαση:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Ορισμός Περιστροφής Υδατογράφηματος**

Ακολουθεί ένα παράδειγμα κώδικα για το πώς να ρυθμίσετε την περιστροφή του υδατογραφήματος ώστε να τοποθετηθεί διαγώνια στην διαφάνεια:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Ορισμός Ονόματος για Υδατογράφημα**

Το Aspose.Slides επιτρέπει να ορίσετε το όνομα ενός σχήματος. Χρησιμοποιώντας το όνομα του σχήματος, μπορείτε να το προσπελάσετε στο μέλλον για τροποποίηση ή διαγραφή. Για να ορίσετε το όνομα του σχήματος υδατογραφήματος, αντιστοιχίστε το στη μέθοδο [IAutoShape.setName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Αφαίρεση Υδατογραφήματος**

Για να αφαιρέσετε το σχήμα υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [IAutoShape.getName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getName--) για να το βρείτε στις διαφάνειες. Στη συνέχεια, περάστε το σχήμα υδατογραφήματος στη μέθοδο [IShapeCollection.remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

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

Το υδατογράφημα είναι μια επιφάνεια κειμένου ή εικόνας που εφαρμόζεται σε διαφάνειες και βοηθά στην προστασία της πνευματικής ιδιοκτησίας, στην ενίσχυση της αναγνώρισης της επωνυμίας ή στην αποτροπή μη εξουσιοδοτημένης χρήσης των παρουσιάσεων.

**Μπορώ να προσθέσω υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;**

Ναι, το Aspose.Slides σας επιτρέπει να προσθέσετε προγραμματιστικά υδατογράφημα σε κάθε διαφάνεια μιας παρουσίασης. Μπορείτε να επαναλάβετε όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις του υδατογραφήματος ξεχωριστά.

**Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογράφηματος;**

Μπορείτε να ρυθμίσετε τη διαφάνεια του υδατογράφηματος τροποποιώντας τις ρυθμίσεις γεμίσματος ([getFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getFillFormat--)) του σχήματος. Αυτό διασφαλίζει ότι το υδατογράφημα είναι διακριτό και δεν αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

**Ποιοι μορφότυποι εικόνας υποστηρίζονται για υδατογραφήματα;**

Το Aspose.Slides υποστηρίζει διάφορους μορφότυπους εικόνας όπως PNG, JPEG, GIF, BMP, SVG και άλλους.

**Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογραφήματος κειμένου;**

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ για να ταιριάζουν στο σχέδιο της παρουσίασής σας και να διατηρήσετε τη συνέπεια της επωνυμίας.

**Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογράφηματος;**

Μπορείτε να ρυθμίσετε τη θέση και τον προσανατολισμό του υδατογράφηματος προγραμματιστικά τροποποιώντας τις συντεταγμένες, το μέγεθος και τις ιδιότητες περιστροφής του σχήματος.