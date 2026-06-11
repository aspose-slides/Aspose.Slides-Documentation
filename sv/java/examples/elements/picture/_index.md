---
title: Bild
type: docs
weight: 50
url: /sv/java/examples/elements/picture/
keywords:
- kodexempel
- bild
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Arbeta med bilder i Aspose.Slides för Java: infoga, beskära, komprimera, färga om och exportera bilder med Java-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man kan infoga och komma åt bilder från minneslagrade bilder med hjälp av **Aspose.Slides for Java**. Exemplen nedan skapar en bild i minnet, placerar den på en bildspelssida och hämtar den sedan.

## **Lägg till en bild**

Denna kod genererar en liten bitmap, konverterar den till en ström och infogar den som en bildram på den första bilden.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Skapa en enkel bild i minnet.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Konvertera bitmapen till en bytearray.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Lägg till bilden i presentationen.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Infoga en bildram som visar bilden på den första bilden.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Kom åt en bild**

Detta exempel säkerställer att en bildspelssida innehåller en bildram och hämtar sedan den första som den hittar.

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