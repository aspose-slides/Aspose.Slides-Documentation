---
title: 画像
type: docs
weight: 50
url: /ja/nodejs-java/examples/elements/picture/
keywords:
- コード例
- 画像
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js で画像を操作します：挿入、トリミング、圧縮、色調変更、エクスポートを行い、PPT、PPTX、ODP プレゼンテーションの例を示します。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用して画像を挿入およびアクセスする方法を示します。以下の例では、ファイルから画像を読み取り、スライドに配置し、そして取得します。

## **画像の追加**
このコードはファイルから画像を読み取り、最初のスライドに図形として挿入します。

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // 最初のスライドに画像を表示する画像フレームを挿入します。
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **画像へのアクセス**
この例では、スライドに図形が含まれていることを確認し、見つかった最初の図形にアクセスします。

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```