---
title: Εικόνα
type: docs
weight: 50
url: /el/java/examples/elements/picture/
keywords:
- παράδειγμα κώδικα
- εικόνα
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Δουλέψτε με εικόνες στο Aspose.Slides for Java: εισαγάγετε, περικόψτε, συμπιέστε, επαναχρωματίστε και εξάγετε εικόνες με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εισάγετε και να προσπελάσετε εικόνες από εικόνες στη μνήμη χρησιμοποιώντας **Aspose.Slides for Java**. Τα παραδείγματα παρακάτω δημιουργούν μια εικόνα στη μνήμη, την τοποθετούν σε μια διαφάνεια και στη συνέχεια την ανακτούν.

## **Προσθήκη εικόνας**

Αυτός ο κώδικας δημιουργεί ένα μικρό bitmap, το μετατρέπει σε ροή και το εισάγει ως πλαίσιο εικόνας στην πρώτη διαφάνεια.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Δημιουργήστε μια απλή εικόνα στη μνήμη.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Μετατρέψτε το bitmap σε σειρά byte.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Προσθέστε την εικόνα στην παρουσίαση.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Εισάγετε ένα πλαίσιο εικόνας που εμφανίζει την εικόνα στην πρώτη διαφάνεια.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε εικόνα**

Αυτό το παράδειγμα εξασφαλίζει ότι μια διαφάνεια περιέχει ένα πλαίσιο εικόνας και στη συνέχεια προσπελαύνει το πρώτο που βρίσκει.

```java
public static void accessPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        BufferedImage bitmap = new BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB);
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

        IPictureFrame pictureFrame = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IPictureFrame) {
                pictureFrame = (IPictureFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```