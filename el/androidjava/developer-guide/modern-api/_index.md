---
title: Βελτιώστε την Επεξεργασία Εικόνας με τη Σύγχρονη API
linktitle: Σύγχρονη API
type: docs
weight: 237
url: /el/androidjava/modern-api/
keywords:
- android.graphics
- Σύγχρονη API
- σχεδίαση
- μικρογραφία διαφάνειας
- διαφάνεια σε εικόνα
- μικρογραφία σχήματος
- σχήμα σε εικόνα
- μικρογραφία παρουσίασης
- παρουσίαση σε εικόνες
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- Android
- Java
- Aspose.Slides
description: "Εκσυγχρονίστε την επεξεργασία εικόνων των διαφανειών αντικαθιστώντας τις παρωχημένες API απεικόνισης με τη Java Σύγχρονη API για απρόσκοπτη αυτοματοποίηση PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Ιστορικά, το Aspose Slides εξαρτάται από το android.graphics και έχει στην δημόσια API τις ακόλουθες κλάσεις από εκεί:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Από την έκδοση 24.4, αυτή η δημόσια API έχει χαρακτηριστεί ως παραιτημένη.

Για να απαλλαγούμε από τις εξαρτήσεις από αυτές τις κλάσεις, προσθέσαμε τη λεγόμενη «Σύγχρονη API» – δηλαδή την API που πρέπει να χρησιμοποιείται αντί της παροχημένης, των οποίων οι υπογραφές περιέχουν εξαρτήσεις από [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). Το [Canvas](https://developer.android.com/reference/android/graphics/Canvas) θεωρείται παραιτημένο και η υποστήριξή του αφαιρείται από τη δημόσια API του Slides.

Στις τρέχουσες εκδόσεις, αντιμετωπίζετε τη δημόσια API που εξαρτάται από τύπους android.graphics ως κληρονομική/παραδοχή. Χρησιμοποιήστε τη Σύγχρονη API για νέο κώδικα και κατά τη μετάβαση σε υπάρχουσες ροές επεξεργασίας εικόνας.

## **Σύγχρονη API**

Προστέθηκαν οι ακόλουθες κλάσεις και enum στη δημόσια API:

- [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) – αντιπροσωπεύει την raster ή vector εικόνα.
- [ImageFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imageformat/) – αντιπροσωπεύει τη μορφή αρχείου της εικόνας.
- [Images](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/images/) – μέθοδοι για δημιουργία και εργασία με τη διεπαφή [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/).

Λάβετε υπόψη ότι το [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) είναι αποδεσμεύσιμο και η χρήση του πρέπει να ακολουθείται από κλήση `dispose()` ή άλλο βολικό πρότυπο αποδέσμευσης.

Χρησιμοποιήστε `getImage` για απόδοση μιας ενιαίας διαφάνειας ή σχήματος. Χρησιμοποιήστε `getImages` για απόδοση πολλαπλών διαφανειών παρουσίασης. Χρησιμοποιήστε τις μεθόδους του [Images](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/images/) για φόρτωση εικόνων, `addImage` με [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) για προσθήκη τους σε παρουσίαση, και `replaceImage` με [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) για ενημέρωση υπάρχουσας εικόνας παρουσίασης.

Ένα τυπικό σενάριο χρήσης της νέας API μπορεί να είναι το εξής:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // δημιουργήστε μια αποδεσμεύσιμη παρουσία του IImage από το αρχείο στο δίσκο.
    IImage image = Images.fromFile("image.png");
    try {
        // δημιουργήστε μια εικόνα PowerPoint προσθέτοντας μια παρουσία του IImage στις εικόνες της παρουσίασης.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // προσθέστε ένα σχήμα εικόνας στη διαφάνεια #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // λάβετε μια παρουσία του IImage που αντιπροσωπεύει τη διαφάνεια #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // αποθηκεύστε την εικόνα στο δίσκο.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αντικατάσταση παλαιού κώδικα με τη Σύγχρονη API**

Γενικά, θα χρειαστεί να αντικαταστήσετε κλήσεις που χρησιμοποιούν [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) με τις νέες μεθόδους που χρησιμοποιούν [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/).

**Παλαιό/παρωχημένο API:**
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
**Σύγχρονη API:**
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Λήψη μικρογραφίας διαφάνειας**

**Παλαιό/παρωχημένο API:**
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

**Σύγχρονη API:**
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

### **Λήψη μικρογραφίας σχήματος**

**Παλαιό/παρωχημένο API:**
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

**Σύγχρονη API:**
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

### **Λήψη μικρογραφίας παρουσίασης**

**Παλαιό/παρωχημένο API:**
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

**Σύγχρονη API:**
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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

### **Προσθήκη εικόνας σε παρουσίαση**

**Παλαιό/παρωχημένο API:**
``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

**Σύγχρονη API:**
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

## **Παρουσίαση**

| Υπογραφή Μεθόδου                               | Υπογραφή Μεθόδου Αντικατάστασης                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

## **Σχήμα**

| Υπογραφή Μεθόδου                                                      | Υπογραφή Μεθόδου Αντικατάστασης                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

## **Διαφάνεια**

| Υπογραφή Μεθόδου                                                      | Υπογραφή Μεθόδου Αντικατάστασης                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

## **Έξοδος**

| Υπογραφή Μεθόδου                                                | Υπογραφή Μεθόδου Αντικατάστασης                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

## **Συλλογή Εικόνων**

| Υπογραφή Μεθόδου                          | Υπογραφή Μεθόδου Αντικατάστασης               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

## **PPImage**

| Υπογραφή Μεθόδου                     | Υπογραφή Μεθόδου Αντικατάστασης   |
|--------------------------------------|-----------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

## **PatternFormat**

| Υπογραφή Μεθόδου                                          | Υπογραφή Μεθόδου Αντικατάστασης                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor)   | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

## **PatternFormatEffectiveData**

| Υπογραφή Μεθόδου                                          | Υπογραφή Μεθόδου Αντικατάστασης                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Υποστήριξη API για Canvas**

Οι μέθοδοι με [Canvas](https://developer.android.com/reference/android/graphics/Canvas) θεωρούνται παρωχημένες και δεν έχουν άμεση αντικατάσταση στη Σύγχρονη API.

Χρησιμοποιήστε τις μεθόδους απόδοσης εικόνας της Σύγχρονης API αντί της API που αποδίδει σε [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **Συχνές ερωτήσεις**

**Γιατί αποσύρθηκε το android.graphics.Canvas;**

Η υποστήριξη για το [Canvas](https://developer.android.com/reference/android/graphics/Canvas) έχει χαρακτηριστεί ως παρωχημένη στη δημόσια API ώστε να ενοποιηθεί η εργασία με απόδοση και εικόνες, να εξαλειφθούν οι εξαρτήσεις από ειδικές πλατφόρμες και να υιοθετηθεί μια πολυπλατφορμική προσέγγιση με το [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/). Χρησιμοποιήστε `getImage` ή `getImages` αντί για απόδοση σε [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Ποιο είναι το πρακτικό όφελος του [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) σε σχέση με το [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap);**

Το [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) ενοποιεί την εργασία με raster και vector εικόνες και απλοποιεί την αποθήκευση σε διάφορες μορφές μέσω του [ImageFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imageformat/).

**Θα επηρεάσει η Σύγχρονη API την απόδοση της δημιουργίας μικρογραφιών;**

Η μετάβαση από `getThumbnail` σε `getImage` δεν επιδεινώνει τα σενάρια: οι νέες μέθοδοι παρέχουν τις ίδιες δυνατότητες παραγωγής εικόνων με επιλογές και μεγέθη, διατηρώντας την υποστήριξη των επιλογών απόδοσης. Το συγκεκριμένο κέρδος ή η απώλεια εξαρτάται από το σενάριο, αλλά λειτουργικά οι αντικαταστάσεις είναι ισοδύναμες.