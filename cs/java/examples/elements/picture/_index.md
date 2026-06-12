---
title: Obrázek
type: docs
weight: 50
url: /cs/java/examples/elements/picture/
keywords:
- příklad kódu
- obrázek
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Práce s obrázky v Aspose.Slides for Java: vkládání, ořezávání, komprese, změna barev a export obrázků s příklady v jazyce Java pro prezentace PPT, PPTX a ODP."
---
Tento článek demonstruje, jak vkládat a přistupovat k obrázkům z obrázků v paměti pomocí **Aspose.Slides for Java**. Níže uvedené příklady vytvoří obrázek v paměti, umístí jej na snímek a poté jej načtou.

## **Přidat obrázek**

Tento kód vygeneruje malý bitmapový obrázek, převede jej na proud a vloží jej jako rámec obrázku na první snímek.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Vytvořte jednoduchý obrázek v paměti.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Převeďte bitmapu na pole bajtů.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Přidejte obrázek do prezentace.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Vložte rámeček obrázku zobrazující obrázek na první snímek.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k obrázku**

Tento příklad zajistí, že snímek obsahuje rámec obrázku, a poté přistoupí k prvnímu nalezenému.

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