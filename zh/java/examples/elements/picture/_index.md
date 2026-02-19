---
title: 图片
type: docs
weight: 50
url: /zh/java/examples/elements/picture/
keywords:
- 代码示例
- 图片
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中处理图片：插入、裁剪、压缩、重新着色，并使用 Java 示例导出 PPT、PPTX 和 ODP 演示文稿的图像。"
---
本文演示了如何使用 **Aspose.Slides for Java** 将内存中的图像插入并访问图片。以下示例在内存中创建图像，将其放置在幻灯片上，然后检索它。

## **添加图片**

此代码生成一个小位图，将其转换为流，并将其作为图片框插入第一张幻灯片。

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 创建一个简单的内存图像。
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // 将位图转换为字节数组。
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // 将图像添加到演示文稿。
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // 在第一张幻灯片上插入显示该图像的图片框。
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **访问图片**

此示例确保幻灯片中包含图片框，并访问它找到的第一个图片框。

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