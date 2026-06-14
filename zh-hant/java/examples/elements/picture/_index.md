---
title: 圖片
type: docs
weight: 50
url: /zh-hant/java/examples/elements/picture/
keywords:
- 程式碼範例
- 圖片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中使用圖片：插入、裁剪、壓縮、重新著色，以及匯出影像，並提供適用於 PPT、PPTX 和 ODP 簡報的 Java 範例。"
---
本文說明如何使用 **Aspose.Slides for Java** 插入和存取來自記憶體中的圖像。以下範例會在記憶體中建立圖像，將其放置於投影片上，然後再取回。

## **新增圖片**

此程式碼會產生一個小的位圖，將其轉換為串流，並將其作為圖片框插入至第一張投影片。

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 建立一個簡單的記憶體圖像。
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // 將位圖轉換為位元組陣列。
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // 將影像新增至簡報中。
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // 在第一張投影片上插入顯示該影像的圖片框。
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **存取圖片**

此範例會確保投影片中包含圖片框，然後存取它找到的第一個圖片框。

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