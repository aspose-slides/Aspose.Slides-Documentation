---
title: Bild
type: docs
weight: 50
url: /de/java/examples/elements/picture/
keywords:
- Codebeispiel
- Bild
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Arbeiten mit Bildern in Aspose.Slides für Java: Einfügen, Zuschneiden, Komprimieren, Einfärben und Exportieren von Bildern mit Java-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie man Bilder aus speicherinternen Grafiken mit **Aspose.Slides for Java** einfügt und darauf zugreift. Die nachstehenden Beispiele erzeugen ein Bild im Speicher, platzieren es auf einer Folie und rufen es anschließend ab.

## **Bild hinzufügen**

Dieser Code erzeugt ein kleines Bitmap, konvertiert es in einen Stream und fügt es als Bildrahmen auf der ersten Folie ein.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Erstelle ein einfaches Bild im Speicher.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Konvertiere das Bitmap in ein Byte-Array.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Füge das Bild zur Präsentation hinzu.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Füge einen Bildrahmen ein, der das Bild auf der ersten Folie anzeigt.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf ein Bild**

Dieses Beispiel stellt sicher, dass eine Folie einen Bildrahmen enthält, und greift dann auf den ersten gefundenen Bildrahmen zu.

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