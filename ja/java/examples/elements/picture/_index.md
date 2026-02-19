---
title: 画像
type: docs
weight: 50
url: /ja/java/examples/elements/picture/
keywords:
- コード例
- 画像
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で画像を操作する: 挿入、トリミング、圧縮、色調変更、エクスポートを行い、PPT、PPTX、ODP プレゼンテーション向けの Java サンプルとともに提供します。"
---
この記事では、**Aspose.Slides for Java** を使用してインメモリ画像から画像を挿入およびアクセスする方法を示します。以下の例では、画像をメモリ内で作成し、スライドに配置し、そして取得します。

## **画像を追加**

このコードは小さなビットマップを生成し、ストリームに変換して、最初のスライドに画像フレームとして挿入します。

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // シンプルなインメモリ画像を作成します。
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // ビットマップをバイト配列に変換します。
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // 画像をプレゼンテーションに追加します。
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // 最初のスライドに画像を表示する画像フレームを挿入します。
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **画像にアクセス**

この例では、スライドに画像フレームが含まれていることを確認し、見つかった最初の画像フレームにアクセスします。

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