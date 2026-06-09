---
title: Προσθήκη Υδατογραφημάτων σε Παρουσιάσεις σε PHP
linktitle: Υδατογράφημα
type: docs
weight: 40
url: /el/php-java/watermark/
keywords:
- υδατογράφημα
- υδατογράφημα κειμένου
- υδατογράφημα εικόνας
- προσθήκη υδατογραφήματος
- αλλαγή υδατογραφήματος
- αφαίρεση υδατογράφηματος
- διαγραφή υδατογράφηματος
- προσθήκη υδατογραφήματος σε PPT
- προσθήκη υδατογραφήματος σε PPTX
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
- PHP
- Aspose.Slides
description: "Διαχειριστείτε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με PHP για να υποδείξετε ένα πρόχειρο, εμπιστευτικές πληροφορίες, πνευματικά δικαιώματα και άλλα."
---
## **Εισαγωγή**

**Ένα υδατογράφημα** σε μια παρουσίαση είναι μια ένδειξη κειμένου ή εικόνας που χρησιμοποιείται σε μια διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, ένα υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι πρόχειρο (π.χ. υδατογράφημα “Πρόχειρο”), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ. υδατογράφημα “Εμπιστευτικό”), για να προσδιορίσει σε ποια εταιρεία ανήκει (π.χ. υδατογράφημα “Όνομα Εταιρείας”), για την ταυτοποίηση του δημιουργού της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην πρόληψη παραβίασης πνευματικών δικαιωμάτων υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφήματα χρησιμοποιούνται τόσο στις μορφές παρουσίασης PowerPoint όσο και OpenOffice. Στο Aspose.Slides, μπορείτε να προσθέσετε ένα υδατογράφημα σε αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/php-java/), υπάρχουν διάφοροι τρόποι για να δημιουργήσετε υδατογραφήματα σε έγγραφα PowerPoint ή OpenOffice και να τροποποιήσετε το σχεδιασμό και τη συμπεριφορά τους. Η κοινή πτυχή είναι ότι για την προσθήκη υδατογραφημάτων κειμένου πρέπει να χρησιμοποιήσετε την κλάση [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/), ενώ για την προσθήκη υδατογραφημάτων εικόνας, τη [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) ή να γεμίσετε ένα σχήμα υδατογραφήματος με εικόνα. Η `PictureFrame` υλοποιεί την κλάση [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/), δίνοντάς σας τη δυνατότητα χρήσης όλων των ευέλικτων ρυθμίσεων του αντικειμένου σχήματος. Επειδή η `ITextFrame` δεν είναι σχήμα και οι ρυθμίσεις της είναι περιορισμένες, περιβάλλεται σε ένα αντικείμενο [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) .

Υπάρχουν δύο τρόποι εφαρμογής ενός υδατογραφήματος: σε μία διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Το Slide Master χρησιμοποιείται για την εφαρμογή ενός υδατογραφήματος σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στο Slide Master, σχεδιάζεται πλήρως εκεί και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζει την άδεια τροποποίησης του υδατογραφήματος σε μεμονωμένες διαφάνειες.

Συνήθως, ένα υδατογράφημα θεωρείται μη επεξεργάσιμο από άλλους χρήστες. Για να εμποδίσετε την επεξεργασία του υδατογραφήματος (ή, πιο συγκεκριμένα, του γονέα σχήματος του υδατογραφήματος), το Aspose.Slides παρέχει λειτουργικότητα κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδωθεί σε κανονική διαφάνεια ή στο Slide Master. Όταν το σχήμα του υδατογραφήματος κλειδωθεί στο Slide Master, θα είναι κλειδωμένο σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε ένα όνομα για το υδατογράφημα ώστε στο μέλλον, αν θέλετε να το διαγράψετε, να το βρείτε στα σχήματα της διαφάνειας με βάση το όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με οποιονδήποτε τρόπο· ωστόσο, συνήθως υπάρχουν κοινά χαρακτηριστικά στα υδατογραφήματα, όπως κεντρική στοίχιση, περιστροφή, θέση μπροστά κ.λπ. Θα εξετάσουμε πώς να τα χρησιμοποιήσουμε στα παραδείγματα παρακάτω.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογράφηματος Κειμένου σε Διαφάνεια**

Για να προσθέσετε ένα υδατογράφημα κειμένου σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια, στη συνέχεια να προσθέσετε ένα πλαίσιο κειμένου σε αυτό το σχήμα. Το πλαίσιο κειμένου αντιπροσωπεύεται από την κλάση [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/). Αυτός ο τύπος δεν κληρονομείται από την [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/), η οποία διαθέτει ευρύ σύνολο ιδιοτήτων για την ευέλικτη τοποθέτηση του υδατογραφήματος. Συνεπώς, το αντικείμενο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) περιβάλλεται σε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/). Για να προσθέσετε κείμενο υδατογραφήματος στο σχήμα, χρησιμοποιήστε τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/#addTextFrame) όπως φαίνεται παρακάτω.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [Πώς να χρησιμοποιήσετε την κλάση TextFrame](/slides/el/php-java/text-formatting/)
{{% /alert %}}

### **Προσθήκη Υδατογράφηματος Κειμένου σε Παρουσίαση**

Αν θέλετε να προσθέσετε ένα υδατογράφημα κειμένου σε ολόκληρη την παρουσίαση (δηλαδή σε όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/). Η υπόλοιπη λογική είναι η ίδια όπως όταν προσθέτετε ένα υδατογράφημα σε μία διαφάνεια — δημιουργήστε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) και στη συνέχεια προσθέστε το υδατογράφημα χρησιμοποιώντας τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [Πώς να χρησιμοποιήσετε το Slide Master](/slides/el/php-java/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφάνειας Σχήματος Υδατογράφηματος**

Από προεπιλογή, το ορθογώνιο σχήμα μορφοποιείται με χρώματα γέμισης και περιγράμματος. Οι παρακάτω γραμμές κώδικα κάνουν το σχήμα διαφανές.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**

Μπορείτε να αλλάξετε τη γραμματοσειρά του υδατογραφήματος κειμένου όπως φαίνεται παρακάτω.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Ορισμός Χρώματος Κειμένου Υδατογράφηματος**

Για να ορίσετε το χρώμα του κειμένου του υδατογράφηματος, χρησιμοποιήστε αυτόν τον κώδικα:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Κεντράρισμα Υδατογραφήματος Κειμένου**

Μπορείτε να κεντράρετε το υδατογράφημα σε μια διαφάνεια, και για αυτό μπορείτε να κάνετε τα εξής:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

Η εικόνα παρακάτω δείχνει το τελικό αποτέλεσμα.

![Το υδατογράφημα κειμένου](text_watermark.png)

## **Υδατογράφημα Εικόνας**

### **Προσθήκη Υδατογραφήματος Εικόνας σε Παρουσίαση**

Για προσθήκη υδατογραφήματος εικόνας σε διαφάνεια παρουσίασης, μπορείτε να κάνετε τα εξής:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Κλείδωμα Υδατογράφηματος από Επεξεργασία**

Αν είναι απαραίτητο να αποτρέψετε την επεξεργασία ενός υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/#getAutoShapeLock) στο σχήμα. Με αυτή την ιδιότητα, μπορείτε να προστατεύσετε το σχήμα από επιλογή, αλλαγή μεγέθους, επανατοποθέτηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου του από επεξεργασία και πολλά άλλα:

```php
// Κλείδωμα του σχήματος του υδατογράφηματος από τροποποίηση
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Φέρετε το Υδατογράφημα Μπροστά**

Στο Aspose.Slides, η σειρά Z των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [ShapeCollection.reorder](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#reorder). Για να γίνει αυτό, πρέπει να καλέσετε αυτή τη μέθοδο από τη λίστα διαφανειών της παρουσίασης και να περάσετε την αναφορά του σχήματος και τον αριθμό σειράς του στη μέθοδο. Με αυτόν τον τρόπο είναι δυνατόν να φέρετε ένα σχήμα μπροστά ή να το στείλετε πίσω στη διαφάνεια. Αυτή η λειτουργία είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να τοποθετήσετε ένα υδατογράφημα μπροστά στην παρουσίαση:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Ορισμός Περιστροφής Υδατογράφηματος**

Ακολουθεί ένα παράδειγμα κώδικα για το πώς να ρυθμίσετε την περιστροφή του υδατογραφήματος ώστε να τοποθετηθεί διαγώνια στη διαφάνεια:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Ορισμός Ονόματος για Υδατογράφημα**

Το Aspose.Slides σας επιτρέπει να ορίσετε το όνομα ενός σχήματος. Χρησιμοποιώντας το όνομα του σχήματος, μπορείτε να το προσπελάσετε στο μέλλον για τροποποίηση ή διαγραφή. Για να ορίσετε το όνομα του σχήματος του υδατογραφήματος, αναθέστε το στη μέθοδο [AutoShape.setName](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("watermark");
```

### **Αφαίρεση Υδατογραφήματος**

Για να αφαιρέσετε το σχήμα του υδατογράφηματος, χρησιμοποιήστε τη μέθοδο [AutoShape.getName](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getName) για να το βρείτε στα σχήματα της διαφάνειας. Στη συνέχεια, περάστε το σχήμα του υδατογράφηματος στη μέθοδο [ShapeCollection.remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **Συχνές Ερωτήσεις**

**Τι είναι ένα υδατογράφημα και γιατί πρέπει να το χρησιμοποιήσω;**

Ένα υδατογράφημα είναι μια επικάλυψη κειμένου ή εικόνας που εφαρμόζεται σε διαφάνειες και βοηθά στην προστασία της πνευματικής ιδιοκτησίας, ενισχύει την αναγνώριση του brand ή αποτρέπει την μη εξουσιοδοτημένη χρήση των παρουσιάσεων.

**Μπορώ να προσθέσω ένα υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;**

Ναι, το Aspose.Slides επιτρέπει την προγραμματιστική προσθήκη υδατογραφήματος σε κάθε διαφάνεια της παρουσίασης. Μπορείτε να επαναλάβετε όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις του υδατογράφηματος ξεχωριστά.

**Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογραφήματος;**

Μπορείτε να ρυθμίσετε τη διαφάνεια του υδατογράφηματος τροποποιώντας τις ρυθμίσεις γεμίσματος ([getFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getfillformat/)) του σχήματος. Αυτό εξασφαλίζει ότι το υδατογράφημα είναι διακριτικό και δεν αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

**Τι μορφές εικόνας υποστηρίζονται για υδατογραφήματα;**

Το Aspose.Slides υποστηρίζει διάφορες μορφές εικόνας όπως PNG, JPEG, GIF, BMP, SVG και άλλα.

**Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογράφηματος κειμένου;**

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ ώστε να ταιριάζει με το σχεδιασμό της παρουσίασής σας και να διατηρήσει τη συνοχή του brand.

**Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογράφηματος;**

Μπορείτε να ρυθμίσετε τη θέση και τον προσανατολισμό του υδατογράφηματος προγραμματιστικά τροποποιώντας τις συντεταγμένες, το μέγεθος και τις ιδιότητες περιστροφής του σχήματος.