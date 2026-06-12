---
title: Afbeelding
type: docs
weight: 50
url: /nl/java/examples/elements/picture/
keywords:
- codevoorbeeld
- afbeelding
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Werk met afbeeldingen in Aspose.Slides for Java: voeg in, snij bij, comprimeer, recolor, en exporteer afbeeldingen met Java-voorbeelden voor PPT, PPTX en ODP-presentaties."
---
Dit artikel toont hoe je afbeeldingen uit in‑memory afbeeldingen invoegt en benadert met **Aspose.Slides for Java**. De onderstaande voorbeelden maken een afbeelding in het geheugen, plaatsen deze op een dia en halen deze vervolgens op.

## **Afbeelding toevoegen**

Deze code genereert een kleine bitmap, zet deze om naar een stream en voegt deze in als een afbeeldingframe op de eerste dia.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Maak een eenvoudige afbeelding in het geheugen.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Zet de bitmap om naar een byte-array.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Voeg de afbeelding toe aan de presentatie.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Voeg een afbeeldingframe in dat de afbeelding toont op de eerste dia.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Toegang tot een afbeelding**

Dit voorbeeld zorgt ervoor dat een dia een afbeeldingframe bevat en benadert vervolgens de eerste die gevonden wordt.

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