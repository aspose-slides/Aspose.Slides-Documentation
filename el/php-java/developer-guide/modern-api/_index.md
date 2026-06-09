---
title: Βελτίωση Επεξεργασίας Εικόνας με το Σύγχρονο API
linktitle: Σύγχρονο API
type: docs
weight: 237
url: /el/php-java/modern-api/
keywords:
- σύγχρονο API
- σχεδίαση
- μικρογραφία διαφάνειας
- διαφάνεια σε εικόνα
- μικρογραφία σχήματος
- σχήμα σε εικόνα
- μικρογραφία παρουσίασης
- παρουσίαση σε εικόνες
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- PHP
- Aspose.Slides
description: "Εκσυγχρονίστε την επεξεργασία εικόνων διαφανειών αντικαθιστώντας τις μη ενδεικτικές API απεικόνισης με το PHP Modern API για αδιάκοπη αυτοματοποίηση PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Ιστορικά, το Aspose Slides εξαρτάται από το java.awt και διαθέτει στο δημόσιο API τις ακόλουθες κλάσεις από αυτό:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Από την έκδοση 24.4, αυτό το δημόσιο API έχει δηλωθεί ως μη ενδεικτικό.

Για να απαλλαγούμε από τις εξαρτήσεις σε αυτές τις κλάσεις, προσθέσαμε το λεγόμενο «Σύγχρονο API» - δηλαδή το API που πρέπει να χρησιμοποιείται αντί του μη ενδεικτικού, των οποίων οι υπογραφές περιέχουν εξαρτήσεις στο [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). Το [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) έχει δηλωθεί ως μη ενδεικτικό και η υποστήριξή του έχει αφαιρεθεί από το δημόσιο Slides API.

Στις τρέχουσες εκδόσεις, θεωρήστε το δημόσιο API που εξαρτάται από τύπους του java.awt ως παλαιό/μη ενδεικτικό. Χρησιμοποιήστε το Σύγχρονο API για νέο κώδικα και κατά τη μεταφορά υφιστάμενων ροών επεξεργασίας εικόνας.

## **Σύγχρονο API**

Προστέθηκαν οι παρακάτω κλάσεις και απαριθμήσεις στο δημόσιο API:

- [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) - αντιπροσωπεύει τη ραστέρα ή διανυσματική εικόνα.
- [ImageFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/imageformat/) - αντιπροσωπεύει τη μορφή αρχείου της εικόνας.
- [Images](https://reference.aspose.com/slides/el/php-java/aspose.slides/images/) - μεθόδους για δημιουργία και εργασία με την κλάση [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/).

Σημειώστε ότι το [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) είναι διαχειρίσιμο (πρέπει να απελευθερώνεται μετά τη χρήση).

Χρησιμοποιήστε `getImage` για απόδοση μιας μόνο διαφάνειας ή σχήματος. Χρησιμοποιήστε `getImages` για απόδοση πολλαπλών διαφανειών παρουσίασης. Χρησιμοποιήστε τις μεθόδους του [Images](https://reference.aspose.com/slides/el/php-java/aspose.slides/images/) για φόρτωση εικόνων, `addImage` με [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) για προσθήκη τους σε παρουσίαση, και `replaceImage` με [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) για ενημέρωση υπάρχουσας εικόνας παρουσίασης.

Ένα τυπικό σενάριο χρήσης του νέου API μπορεί να είναι ως εξής:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# δημιουργήστε μια διαχειρίσιμη εικόνα IImage από το αρχείο στο δίσκο.
$image = Images::fromFile("image.png");

# δημιουργήστε μια εικόνα PowerPoint προσθέτοντας μια παρουσίαση IImage στις εικόνες της παρουσίασης.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# προσθέστε ένα σχήμα εικόνας στη διαφάνεια #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# λάβετε μια παρουσία της IImage που αντιπροσωπεύει τη διαφάνεια #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# αποθηκεύστε την εικόνα στο δίσκο.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Αντικατάσταση Παλιού Κώδικα με το Σύγχρονο API**

Γενικά, θα χρειαστεί να αντικαταστήσετε κλήσεις που χρησιμοποιούν [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) και [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) με τις νέες μεθόδους που χρησιμοποιούν [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/).

API παλαιού/μη ενδεικτικού:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Σύγχρονο API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Λήψη Μικρογραφίας Διαφάνειας**

API παλαιού/μη ενδεικτικού:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Σύγχρονο API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Λήψη Μικρογραφίας Σχήματος**

API παλαιού/μη ενδεικτικού:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Σύγχρονο API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Λήψη Μικρογραφίας Παρουσίασης**

API παλαιού/μη ενδεικτικού:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

Σύγχρονο API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **Προσθήκη Εικόνας σε Παρουσίαση**

API παλαιού/μη ενδεικτικού:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

Σύγχρονο API:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **Μη ενδεικτικές μέθοδοι και η αντικατάστασή τους στο Σύγχρονο API**

### **Presentation**
| Υπογραφή Μεθόδου | Υπογραφή Αντικαταστατικής Μεθόδου |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Υπογραφή Μεθόδου | Υπογραφή Αντικαταστατικής Μεθόδου |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Υπογραφή Μεθόδου | Υπογραφή Αντικαταστατικής Μεθόδου |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| Υπογραφή Μεθόδου | Υπογραφή Αντικαταστατικής Μεθόδου |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Υπογραφή Μεθόδου | Υπογραφή Αντικαταστατικής Μεθόδου |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Υπογραφή Μεθόδου | Υπογραφή Αντικαταστατικής Μεθόδου |
|--------------------------------------|-------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Υπογραφή Μεθόδου | Υπογραφή Αντικαταστατικής Μεθόδου |
|-----------------------------------------------------------|-----------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Υπογραφή Μεθόδου | Υπογραφή Αντικαταστατικής Μεθόδου |
|-----------------------------------------------------------|-----------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Υποστήριξη API για Graphics2D**

Οι μέθοδοι με [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) έχουν δηλωθεί ως μη ενδεικτικές και δεν έχουν άμεση αντικατάσταση στο Σύγχρονο API.

Χρησιμοποιήστε τις μεθόδους απόδοσης εικόνας του Σύγχρονου API αντί του API που αποδίδει σε [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Συχνές ερωτήσεις**

**Γιατί απομακρύνθηκε το [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html);**

Η υποστήριξη για το [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) θεωρείται μη ενδεικτική στο δημόσιο API ώστε να ενοποιηθεί η εργασία με απόδοση και εικόνες, να εξαλειφθούν οι εξαρτήσεις από πλατφόρμα‑συγκεκριμένα στοιχεία και να υιοθετηθεί μια διαπλατφόρμα προσέγγιση με το [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/). Χρησιμοποιήστε `getImage` ή `getImages` αντί για απόδοση σε [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Ποιο είναι το πρακτικό όφελος του [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) σε σχέση με το [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html);**

Το [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) ενοποιεί την εργασία με ραστέρ και διανυσματικές εικόνες και απλοποιεί την αποθήκευση σε διάφορες μορφές μέσω του [ImageFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/imageformat/).

**Θα επηρεάσει το Σύγχρονο API την απόδοση της δημιουργίας μικρογραφιών;**

Η μετάβαση από `getThumbnail` σε `getImage` δεν επιδεινώνει τα σενάρια: οι νέες μέθοδοι παρέχουν τις ίδιες δυνατότητες παραγωγής εικόνας με επιλογές και μεγέθη, διατηρώντας την υποστήριξη για επιλογές απόδοσης. Το συγκεκριμένο κέρδος ή η απώλεια εξαρτώνται από το σενάριο, αλλά λειτουργικά οι αντικαταστάσεις είναι ισοδύναμες.