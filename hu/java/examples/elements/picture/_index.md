---
title: Kép
type: docs
weight: 50
url: /hu/java/examples/elements/picture/
keywords:
- kódrészlet
- kép
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Képek kezelése az Aspose.Slides for Java-ban: beszúrás, vágás, tömörítés, színezés és képek exportálása Java példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan szúrhat be és érhet el képeket a memóriában tárolt képekből az **Aspose.Slides for Java** használatával. Az alábbi példák memóriában hoznak létre egy képet, helyezik el egy dián, majd lekérdezik azt.

## **Kép hozzáadása**

Ez a kód egy kis bitmapet generál, átalakítja streammé, és képkockaként illeszti be az első diára.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Hozzon létre egy egyszerű memóriában tárolt képet.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Alakítsa át a bitmapet bájt tömbbé.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Adja hozzá a képet a prezentációhoz.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Helyezzen be egy képkeretet, amely megjeleníti a képet az első dián.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Kép elérése**

Ez a példa biztosítja, hogy a dián legyen egy képkocka, majd hozzáfér az első megtalált képkockához.

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