---
title: 圖片
type: docs
weight: 50
url: /zh-hant/nodejs-java/examples/elements/picture/
keywords:
- 程式碼範例
- 圖片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中處理圖片：插入、裁切、壓縮、重新著色，並以範例說明如何在 PPT、PPTX 與 ODP 簡報中匯出圖像。"
---
本文示範如何使用 **Aspose.Slides for Node.js via Java** 插入與存取圖片。以下範例會從檔案讀取圖像、將其放置於投影片上，然後再取得它。

## **新增圖片**

此程式碼會從檔案讀取圖像，並將其作為圖片框插入第一張投影片。

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // 在第一張投影片上插入顯示圖像的圖片框。
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **存取圖片**

此範例會確認投影片包含圖片框，然後存取找到的第一個圖片框。

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