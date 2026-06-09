---
title: "Βελτιώστε την επεξεργασία εικόνων με το Modern API"
linktitle: "Σύγχρονο API"
type: docs
weight: 237
url: /el/nodejs-java/modern-api/
keywords:
- "σύγχρονο API"
- "σχεδίαση"
- "μικρογραφία διαφάνειας"
- "διαφάνεια σε εικόνα"
- "μικρογραφία σχήματος"
- "σχήμα σε εικόνα"
- "μικρογραφία παρουσίασης"
- "παρουσίαση σε εικόνες"
- "προσθήκη εικόνας"
- "προσθήκη εικόνας"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Εκσυγχρονίστε την επεξεργασία εικόνων διαφανειών αντικαθιστώντας τα παρωχημένα APIs απεικόνισης με το JavaScript Modern API για απρόσκοπτη αυτοματοποίηση PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Ιστορικά, το Aspose Slides έχει εξάρτηση από το java.awt και στο δημόσιο API περιλαμβάνει τις ακόλουθες κλάσεις από εκεί:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Από την έκδοση 24.4, αυτό το δημόσιο API έχει δηλωθεί ως παρωχημένο.

Για να απαλλαγούμε από τις εξαρτήσεις από αυτές τις κλάσεις, προσθέσαμε το λεγόμενο “Modern API” — δηλαδή το API που πρέπει να χρησιμοποιείται αντί του παρωχημένου, του οποίου οι υπογραφές περιέχουν εξαρτήσεις από [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). Το [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) έχει δηλωθεί παρωχημένο και η υποστήριξή του έχει αφαιρεθεί από το δημόσιο Slides API.

Στις τρέχουσες εκδόσεις, θεωρήστε το δημόσιο API που εξαρτάται από τύπους java.awt ως παλαιό/παρωχημένο. Χρησιμοποιήστε το Modern API για νέο κώδικα και κατά τη μεταφορά υπαρχουσών ροών επεξεργασίας εικόνας.

## **Modern API**

Προστέθηκαν οι ακόλουθες κλάσεις και απαριθμήσεις στο δημόσιο API:

- [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) - αντιπροσωπεύει τη ραστέρ ή διανυσματική εικόνα.
- [ImageFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imageformat/) - αντιπροσωπεύει τη μορφή αρχείου της εικόνας.
- [Images](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/images/) - μεθόδους για τη δημιουργία και εργασία με την κλάση [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/).

Λάβετε υπόψη ότι το [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) είναι διαχειρίσιμο και η χρήση του πρέπει να ακολουθεί κλήση `dispose()` ή κάποιο άλλο βολικό μοτίβο αποδέσμευσης.

Χρησιμοποιήστε `getImage` για απόδοση μιας μόνο διαφάνειας ή σχήματος. Χρησιμοποιήστε `getImages` για απόδοση πολλαπλών διαφανειών παρουσίασης. Χρησιμοποιήστε τις μεθόδους του [Images](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/images/) για φόρτωση εικόνων, `addImage` με [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) για προσθήκη τους σε παρουσίαση, και `replaceImage` με [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) για ενημέρωση υπάρχουσας εικόνας παρουσίασης.

Ένα τυπικό σενάριο χρήσης του νέου API μπορεί να φαίνεται ως εξής:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // δημιουργία ενός απορρίψιμου αντικειμένου IImage από το αρχείο στο δίσκο.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // δημιουργήστε μια εικόνα PowerPoint προσθέτοντας ένα αντικείμενο IImage στις εικόνες της παρουσίασης.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // προσθέστε ένα σχήμα εικόνας στη διαφάνεια #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // λάβετε ένα αντικείμενο IImage που αντιπροσωπεύει τη διαφάνεια #1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // αποθήκευση της εικόνας στο δίσκο.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αντικατάσταση παλιού κώδικα με Modern API**

Γενικά, θα χρειαστεί να αντικαταστήσετε κλήσεις που χρησιμοποιούν [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) και [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) με τις νέες μεθόδους που χρησιμοποιούν [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/).

Legacy/deprecated API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Modern API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Λήψη μικρογραφίας διαφάνειας**

Legacy/deprecated API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Λήψη μικρογραφίας σχήματος**

Legacy/deprecated API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Λήψη μικρογραφίας παρουσίασης**

Legacy/deprecated API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Προσθήκη εικόνας σε παρουσίαση**

Legacy/deprecated API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Deprecated Methods and Their Replacement in Modern API**

### **Presentation**
| Υπογραφή μεθόδου | Υπογραφή μεθόδου αντικατάστασης |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Υπογραφή μεθόδου | Υπογραφή μεθόδου αντικατάστασης |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Υπογραφή μεθόδου | Υπογραφή μεθόδου αντικατάστασης |
|-----------------------------------------------|---------------------------------------------------------|
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
| Υπογραφή μεθόδου | Υπογραφή μεθόδου αντικατάστασης |
|-----------------------------------------------|---------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Υπογραφή μεθόδου | Υπογραφή μεθόδου αντικατάστασης |
|-----------------------------------------------|---------------------------------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Υπογραφή μεθόδου | Υπογραφή μεθόδου αντικατάστασης |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Υπογραφή μεθόδου | Υπογραφή μεθόδου αντικατάστασης |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Υπογραφή μεθόδου | Υπογραφή μεθόδου αντικατάστασης |
|-----------------------------------------------|---------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API Support for Graphics2D**

Οι μέθοδοι με [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) έχουν δηλωθεί παρωχημένες και δεν υπάρχει άμεση Modern API αντικατάσταση.

Χρησιμοποιήστε τις Modern API μεθόδους απόδοσης εικόνας αντί του API που αποδίδει σε [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **Συχνές ερωτήσεις**

**Ποιο είναι το πρακτικό όφελος του [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) σε σχέση με το [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html);**

[IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/) ενοποιεί την εργασία με ραστέρ και διανυσματικές εικόνες και απλοποιεί την αποθήκευση σε διάφορες μορφές μέσω του [ImageFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imageformat/).

**Θα επηρεάσει το Modern API την απόδοση της δημιουργίας μικρογραφιών;**

Η μετάβαση από `getThumbnail` σε `getImage` δεν επιδεινώνει τα σενάρια: οι νέες μέθοδοι παρέχουν τις ίδιες δυνατότητες παραγωγής εικόνων με επιλογές και μεγέθη, διατηρώντας την υποστήριξη επιλογών απόδοσης. Το συγκεκριμένο κέρδος ή η μείωση εξαρτάται από το σενάριο, αλλά λειτουργικά οι αντικαταστάσεις είναι ισοδύναμες.