---
title: Βελτιώστε την Επεξεργασία Εικόνας με το Modern API
linktitle: Σύγχρονο API
type: docs
weight: 237
url: /el/java/modern-api/
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
- προσθήκη εικόνας
- Java
- Aspose.Slides
description: "Εξατομικεύστε την επεξεργασία εικόνων διαφανειών αντικαθιστώντας τα παρωχημένα API εικόνας με το Java Modern API για απρόσκοπτη αυτοματοποίηση PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Ιστορικά, το Aspose Slides εξαρτάται από το java.awt και διαθέτει στο δημόσιο API τις ακόλουθες κλάσεις από εκεί:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Από την έκδοση 24.4, αυτό το δημόσιο API έχει χαρακτηριστεί ως παρωχημένο.

Για να απαλλαγούμε από τις εξαρτήσεις από αυτές τις κλάσεις, προσθέσαμε το λεγόμενο «Modern API»‑ δηλαδή το API που πρέπει να χρησιμοποιείται αντί του παρωχημένου, των οποίων οι υπογραφές περιέχουν εξαρτήσεις από [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). Το [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) έχει χαρακτηριστεί ως παρωχημένο και η υποστήριξή του έχει αφαιρεθεί από το δημόσιο API του Slides.

Στις τρέχουσες εκδόσεις, θεωρείτε το δημόσιο API που εξαρτάται από τύπους java.awt ως κληρονομικό/παρωχημένο. Χρησιμοποιήστε το Modern API για νέο κώδικα και κατά τη μετάβαση υφιστάμενων εργασιών επεξεργασίας εικόνας.

## **Modern API**

Προστέθηκαν οι ακόλουθες κλάσεις και enums στο δημόσιο API:

- [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) – αντιπροσωπεύει την ράστερ ή διανυσματική εικόνα.
- [ImageFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/imageformat/) – αντιπροσωπεύει τη μορφή αρχείου της εικόνας.
- [Images](https://reference.aspose.com/slides/el/java/com.aspose.slides/images/) – μέθοδοι για δημιουργία και εργασία με το interface [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/).

Παρακαλώ σημειώστε ότι το [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) είναι disposable και η χρήση του πρέπει να ακολουθείται από κλήση `dispose()` ή κάποιον άλλο βολικό μηχανισμό απελευθέρωσης.

Χρησιμοποιήστε `getImage` για απόδοση μιας μονής διαφάνειας ή σχήματος. Χρησιμοποιήστε `getImages` για απόδοση πολλαπλών διαφανειών παρουσίασης. Χρησιμοποιήστε τις μεθόδους του [Images](https://reference.aspose.com/slides/el/java/com.aspose.slides/images/) για φόρτωση εικόνων, `addImage` με το [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) για προσθήκη τους σε μια παρουσίαση, και `replaceImage` με το [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) για ενημέρωση υπάρχουσας εικόνας παρουσίασης.

Ένα τυπικό σενάριο χρήσης του νέου API μπορεί να μοιάζει ως εξής:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // δημιουργεί ένα διαχειρίσιμο στιγμιότυπο του IImage από το αρχείο στον δίσκο.
    IImage image = Images.fromFile("image.png");
    try {
        // δημιουργεί μια εικόνα PowerPoint προσθέτοντας ένα στιγμιότυπο του IImage στις εικόνες της παρουσίασης.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // προσθέτει ένα σχήμα εικόνας στη διαφάνεια #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // λαμβάνει ένα στιγμιότυπο του IImage που αντιπροσωπεύει τη διαφάνεια #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // αποθηκεύει την εικόνα στον δίσκο.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αντικατάσταση Παλαιού Κώδικα με Modern API**

Σε γενικές γραμμές, θα χρειαστεί να αντικαταστήσετε κλήσεις που χρησιμοποιούν το [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) και το ImageIO με τις νέες μεθόδους που χρησιμοποιούν το [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/).

Legacy/deprecated API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Modern API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Λήψη Μικρογραφίας Διαφάνειας**

API Κληρονομιάς/παρωχημένο:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Λήψη Μικρογραφίας Σχήματος**

API Κληρονομιάς/παρωχημένο:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Λήψη Μικρογραφίας Παρουσίασης**

API Κληρονομιάς/παρωχημένο:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Προσθήκη Εικόνας σε Παρουσίαση**

API Κληρονομιάς/παρωχημένο:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Παρωχημένες Μέθοδοι και η Αντικατάστασή τους στο Modern API**

### **Presentation**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|------------------|-----------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|------------------|-----------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|------------------|-----------------------------------|
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
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|------------------|-----------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|------------------|-----------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|------------------|-----------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|------------------|-----------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|------------------|-----------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Υποστήριξη API για Graphics2D**

Οι μέθοδοι με [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) έχουν χαρακτηριστεί ως παρωχημένες και δεν έχουν άμεση αντικατάσταση στο Modern API.

Χρησιμοποιήστε τις μεθόδους απόδοσης εικόνας του Modern API αντί του API που αποδίδει σε [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Γιατί αποσύρθηκε το [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html);**

Η υποστήριξη του [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) χαρακτηρίστηκε ως παρωχημένη στο δημόσιο API για ενοποίηση της εργασίας με απόδοση και εικόνες, εξάλειψη εξαρτήσεων από συγκεκριμένες πλατφόρμες και μετάβαση σε προσέγγιση διαπλατφόρμας με το [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/). Χρησιμοποιήστε `getImage` ή `getImages` αντί για απόδοση σε [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Ποιο είναι το πρακτικό όφελος του [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) σε σχέση με το [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html);**

Το [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) ενοποιεί την εργασία με ραστερ και διανυσματικές εικόνες και απλοποιεί την αποθήκευση σε διάφορες μορφές μέσω του [ImageFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/imageformat/).

**Θα επηρεάσει το Modern API την απόδοση της δημιουργίας μικρογραφιών;**

Η μετάβαση από `getThumbnail` σε `getImage` δεν επιδεινώνει τις περιπτώσεις: οι νέες μέθοδοι παρέχουν τις ίδιες δυνατότητες παραγωγής εικόνων με επιλογές και μεγέθη, διατηρώντας την υποστήριξη επιλογών απόδοσης. Η συγκεκριμένη κερδοφορία ή απώλεια εξαρτάται από το σενάριο, αλλά λειτουργικά οι αντικαταστάσεις είναι ισοδύναμες.