---
title: 使用 JavaScript 管理簡報中的圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/nodejs-java/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 新增圖像
- 建立圖像
- 擷取圖像
- 點陣圖像
- 向量圖像
- 裁切圖像
- 已裁切區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對縮放
- 圖像效果
- 長寬比
- 圖像透明度
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 為 PowerPoint 與 OpenDocument 簡報加入圖片框。簡化工作流程並提升投影片設計。"
---
## **簡介**

圖片框是一種包含圖像的形狀——它就像框中的圖片。

您可以透過圖片框將圖像加入投影片。這樣，您可以藉由設定圖片框的格式來調整圖像的格式。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免費的轉換器——[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能快速從圖像建立簡報。 
{{% /alert %}} 

## **建立圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將圖像加入與簡報物件相關聯的 [ImagesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ImageCollection) 來建立 `PPImage` 物件，以供填充形狀使用。  
4. 指定圖像的寬度與高度。  
5. 透過與參考投影片相關聯的 shape 物件所提供的 `addPictureFrame` 方法，依據圖像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFrame)。  
6. 將圖片框（含圖像）加入投影片。  
7. 將修改後的簡報寫入為 PPTX 檔案。  

以下 JavaScript 程式碼示範如何建立圖片框：

```javascript
// 實例化表示 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 實例化 Image 類別
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 加入圖片框，使用圖片相同的高度與寬度
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

圖片框讓您能快速以圖像建立投影片。結合圖片框與 Aspose.Slides 的儲存選項，您可以操作輸入/輸出以將圖像從一種格式轉換為另一種格式。

## **建立相對縮放的圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 將圖像加入簡報的圖像集合。  
4. 透過將圖像加入與簡報物件相關聯的 [ImagesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ImageCollection) 來建立 `PPImage` 物件，以供填充形狀使用。  
5. 在圖片框中指定圖像的相對寬度與高度。  
6. 將修改後的簡報寫入為 PPTX 檔案。  

以下 JavaScript 程式碼示範如何建立具相對縮放的圖片框：

```javascript
// 實例化表示 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 實例化 Image 類別
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 新增圖片框，其高度與寬度與圖片相同
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 設定相對縮放的寬度與高度
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **從圖片框中擷取點陣圖像**

您可以擷取 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFrame) 物件的點陣圖像，並儲存為 PNG、JPG 以及其他格式。以下程式碼範例示範如何從文件 "sample.pptx" 中擷取圖像並以 PNG 格式儲存。

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **從圖片框中擷取 SVG 圖像**

當簡報內的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 形狀中包含 SVG 圖形時，透過 Java 的 Aspose.Slides for Node.js 可讓您完整保留原始向量圖像。透過遍歷投影片的形狀集合，您可以識別每個 [PictureFrame]、檢查其底層的 [PPImage] 是否含有 SVG 內容，然後將該圖像以原生 SVG 格式儲存至磁碟或串流。

以下程式碼範例示範如何從圖片框中擷取 SVG 圖像：

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **取得圖像的透明度**

Aspose.Slides 可讓您取得套用於圖像的透明度效果。以下 JavaScript 程式碼示範此操作：

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **圖片框格式設定**

Aspose.Slides 提供許多可套用於圖片框的格式設定選項。使用這些選項，您可以調整圖片框以符合特定需求。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將圖像加入與簡報物件相關聯的 [ImagesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ImageCollection) 來建立 `PPImage` 物件，以供填充形狀使用。  
4. 指定圖像的寬度與高度。  
5. 透過與參考投影片相關聯的 [Shapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 物件所提供的 [addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 方法，依據圖像的寬度與高度建立 `PictureFrame`。  
6. 將圖片框（含圖像）加入投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線條寬度。  
9. 透過給予正值或負值來旋轉圖片框。  
   * 正值會順時針旋轉圖像。  
   * 負值會逆時針旋轉圖像。  
10. 將圖片框（含圖像）加入投影片。  
11. 將修改後的簡報寫入為 PPTX 檔案。  

以下 JavaScript 程式碼示範圖片框格式設定流程：

```javascript
// 實例化表示 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 實例化 Image 類別
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 新增圖片框，其高度與寬度與圖片相同
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 對 PictureFrameEx 套用一些格式設定
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose 最近開發了 [免費拼貼製作器](https://products.aspose.app/slides/zh-hant/collage)。如果您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 圖像，或 [從照片建立格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，都可以使用此服務。 
{{% /alert %}}

## **將圖像作為連結加入**

為避免簡報檔案過大，您可以透過連結的方式加入圖像（或影片），而不是直接將檔案嵌入簡報。以下 JavaScript 程式碼示範如何將圖像與影片加入佔位區：

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **裁切圖像**

以下 JavaScript 程式碼示範如何裁切投影片上的既有圖像：

```javascript
var pres = new aspose.slides.Presentation();
// 建立新的影像物件
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 將 PictureFrame 加入投影片
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // 裁切影像（百分比值）
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // 儲存結果
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **刪除圖片的裁切區域**

若要刪除框中圖像的裁切區域，可使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 方法。若不需要裁切，該方法會回傳原始圖像。以下 JavaScript 程式碼示範此操作：

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 取得第一張投影片的 PictureFrame
    var picFrame = slide.getShapes().get_Item(0);
    // 刪除 PictureFrame 圖像的裁切區域並回傳裁切後的圖像
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // 儲存結果
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 方法會將裁切後的圖像加入簡報的圖像集合。若該圖像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 中使用，這種設定可減少簡報大小；否則，最終簡報的圖像數量會增加。

此方法在裁切過程中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 圖像。 
{{% /alert %}}

## **壓縮圖像**

您可以使用 [PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定的解析度縮減圖像尺寸，並可選擇刪除裁切區域。

它會調整圖片的大小與解析度，類似於 PowerPoint 的 **圖片格式 → 壓縮圖片 → 解析度** 功能。

以下 JavaScript 範例示範如何透過指定目標解析度以及可選的刪除裁切區域，於簡報中壓縮圖像：

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 使用目標解析度 150 DPI（網路解析度）壓縮圖像，並移除裁切區域。
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // 檢查壓縮結果。
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

或使用其他預先定義的 DPI 值：

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 將影像壓縮至 96 DPI（電子郵件解析度），並移除裁切區域。
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
此方法會根據形狀大小與提供的 DPI 將圖像轉換為較低解析度。亦可刪除裁切區域以最佳化檔案大小。若圖像為中繪圖檔 (WMF/EMF) 或 SVG，則不會套用壓縮。JPEG 的品質會依解析度保留或略為降低，類似於 PowerPoint 處理高解析度 JPEG 的方式。 
{{% /alert %}}

## **鎖定長寬比**

若希望包含圖像的形狀在變更圖像尺寸後仍保持其長寬比，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) 方法設定 *Lock Aspect Ratio* 屬性。

以下 JavaScript 程式碼示範如何鎖定形狀的長寬比：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // 設定形狀在調整大小時保持長寬比
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
此 *Lock Aspect Ratio* 設定僅保留形狀的長寬比，而不會影響其內含圖像。 
{{% /alert %}}

## **使用 StretchOff 屬性**

使用 [setStretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-)、[setStretchOffsetTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--)、[setStretchOffsetRight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) 與 [setStretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) 方法（屬於 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat) 類別），您可指定填充矩形。

當對圖像指定拉伸時，來源矩形會被縮放以符合指定的填充矩形。填充矩形的每一邊皆以相對於形狀邊界框相應邊的百分比偏移來定義。正百分比表示內縮，負百分比表示外擴。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入一個矩形 `AutoShape`。  
4. 建立圖像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 加入設定的圖像以填充形狀。  
8. 指定圖像相對於形狀邊界框相應邊的偏移量。  
9. 將修改後的簡報寫入為 PPTX 檔案。  

以下 JavaScript 程式碼示範使用 StretchOff 屬性之流程：

```javascript
// 實例化表示 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 實例化 ImageEx 類別
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 新增設定為矩形的 AutoShape
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // 設定形狀的填充類型
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // 設定形狀的圖片填充模式
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // 設定用於填充形狀的圖像
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // 指定圖像相對於形狀邊界框相應邊的偏移量
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // 將 PPTX 檔案寫入磁碟
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**如何得知 PictureFrame 支援哪些圖像格式？**

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 的圖像物件，支援點陣圖 (PNG、JPEG、BMP、GIF 等) 與向量圖 (如 SVG)。支援的格式清單大致與投影片與圖像轉換引擎的能力相互重疊。

**大量加入大型圖像會如何影響 PPTX 檔案大小與效能？**

嵌入大型圖像會增加檔案大小與記憶體使用量；透過連結圖像可降低簡報大小，但須確保外部檔案仍可存取。Aspose.Slides 提供以連結方式加入圖像的功能，以減少檔案大小。

**如何防止圖像物件意外移動或調整大小？**

可使用針對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 的 [shape locks](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/getpictureframelock/)（例如停用移動或調整大小）。此鎖定機制支援多種形狀類型，包括 [PictureFrame]。

**將簡報匯出為 PDF／圖像時，SVG 向量精度是否得以保留？**

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 中擷取 SVG，保留其原始向量。當 [匯出為 PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/) 或 [點陣格式](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 時，結果可能會依匯出設定而被點陣化；而 SVG 仍以向量儲存的事實，可從擷取行為得到驗證。