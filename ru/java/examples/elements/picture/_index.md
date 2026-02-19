---
title: Изображение
type: docs
weight: 50
url: /ru/java/examples/elements/picture/
keywords:
- пример кода
- изображение
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Работайте с изображениями в Aspose.Slides for Java: вставка, обрезка, сжатие, изменение цвета и экспорт изображений с примерами на Java для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как вставлять и получать доступ к изображениям из памяти, используя **Aspose.Slides for Java**. Приведённые ниже примеры создают изображение в памяти, размещают его на слайде и затем извлекают.

## **Add a Picture**
Этот код генерирует небольшое растровое изображение, преобразует его в поток и вставляет как рамку изображения на первый слайд.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Создайте простое изображение в памяти.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Преобразуйте bitmap в массив байтов.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Добавьте изображение в презентацию.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Вставьте рамку изображения, отображающую картинку на первом слайде.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Picture**
В этом примере проверяется, содержит ли слайд рамку изображения, и затем происходит доступ к первой найденной.

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