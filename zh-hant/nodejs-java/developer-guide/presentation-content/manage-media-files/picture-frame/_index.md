---
title: 使用 JavaScript 於簡報中管理圖片框
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
- 裁剪圖像
- 裁剪區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對比例
- 圖像效果
- 長寬比
- 圖像透明度
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 為 PowerPoint 與 OpenDocument 簡報新增圖片框。簡化工作流程並提升投影片設計。"
---
## **簡介**

圖片框是一種包含圖像的形狀——它就像框中的圖片。

您可以透過圖片框將圖像加入投影片。如此，您可以透過設定圖片框的方式來格式化圖像。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免費的轉換工具——[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能快速從圖像建立簡報。 

{{% /alert %}} 

## **建立圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將圖像加入與簡報物件關聯的 [ImagesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ImageCollection) 來建立 `PPImage` 物件，以供填充圖形使用。  
4. 指定圖像的寬度與高度。  
5. 透過參考投影片關聯的 shape 物件所公開的 `addPictureFrame` 方法，根據圖像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFrame)。  
6. 將圖片框（包含圖片）加入投影片。  
7. 將修改後的簡報寫入為 PPTX 檔案。  

以下 JavaScript 程式碼示範如何建立圖片框：

```javascript
// 實例化代表 PPTX 檔案的 Presentation 類別
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

圖片框讓您能快速依據圖像建立投影片。將圖片框與 Aspose.Slides 的儲存選項結合，即可操作輸入/輸出以將圖像從一種格式轉換為另一種格式。

## **使用相對比例建立圖片框**

透過調整圖像的相對比例，您可以建立更複雜的圖片框。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 將圖像加入簡報的圖像集合。  
4. 透過將圖像加入與簡報物件關聯的 [ImagesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ImageCollection) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PPImage) 物件，以供填充圖形使用。  
5. 在圖片框中指定圖像的相對寬度與高度。  
6. 將修改後的簡報寫入為 PPTX 檔案。  

以下 JavaScript 程式碼示範如何建立具相對比例的圖片框：

```javascript
// 實例化代表 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 實例化 Image 類別
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 加入與圖片相同高度與寬度的圖片框
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 設定相對比例的寬度與高度
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

## **從圖片框擷取點陣圖像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFrame) 物件擷取點陣圖像，並將其儲存為 PNG、JPG 等格式。以下程式碼示範如何從檔案「sample.pptx」中擷取圖像並以 PNG 格式儲存。

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

## **從圖片框擷取 SVG 圖像**

當簡報在 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 形狀內放置 SVG 圖形時，Aspose.Slides for Node.js via Java 可讓您以完整保真度取得原始向量圖像。透過遍歷投影片的形狀集合，您可以辨識每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/)，檢查其底層的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 是否含有 SVG 內容，並將該圖像以原生 SVG 格式儲存至磁碟或串流。

以下程式碼示範如何從圖片框擷取 SVG 圖像：

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

Aspose.Slides 允許您取得套用於圖像的透明度效果。以下 JavaScript 程式碼示範此操作：

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

## **取得圖像的亮度與對比度**

Aspose.Slides 允許您取得套用於圖像的亮度與對比度效果。[Luminance](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/luminance/) 類別代表此圖像變換效果。

以下 JavaScript 程式碼示範如何從圖片框取得亮度與對比度設定：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **圖片框格式設定**

Aspose.Slides 提供多種可套用於圖片框的格式設定選項。使用這些選項，您可以調整圖片框以符合特定需求。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將圖像加入與簡報物件關聯的 [ImagesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ImageCollection) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PPImage) 物件，以供填充圖形使用。  
4. 指定圖像的寬度與高度。  
5. 透過 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 物件所公開的 [addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 方法，根據圖像的寬度與高度建立 `PictureFrame`。  
6. 將圖片框（包含圖片）加入投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線條寬度。  
9. 以正值或負值旋轉圖片框。  
   * 正值會順時針旋轉圖像。  
   * 負值會逆時針旋轉圖像。  
10. 再次將圖片框（包含圖片）加入投影片。  
11. 將修改後的簡報寫入為 PPTX 檔案。  

以下 JavaScript 程式碼示範圖片框格式設定流程：

```javascript
// 實例化代表 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 實例化 Image 類別
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 加入與圖片相同高度與寬度的圖片框
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 為 PictureFrameEx 套用一些格式設定
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

{{% alert title="提示" color="primary" %}}

Aspose 最近開發了免費的 [Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。若您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 圖像，或是 [從照片建立格線](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，皆可使用此服務。 

{{% /alert %}}

## **將圖像作為連結加入**

為了避免簡報體積過大，您可以透過連結方式加入圖像（或影片），而非直接嵌入檔案。以下 JavaScript 程式碼示範如何將圖像與影片加入佔位元件：

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

## **裁剪圖像**

以下 JavaScript 程式碼示範如何裁剪投影片上既有的圖像：

```javascript
var pres = new aspose.slides.Presentation();
// 建立新的圖像物件
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
    // 在投影片中加入 PictureFrame
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // 裁剪圖像（百分比值）
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

## **刪除圖片框的裁剪區域**

若您想刪除框內圖像的裁剪區域，可使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 方法。若不需要裁剪，該方法會傳回原始圖像。

以下 JavaScript 程式碼示範此操作：

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 從第一張投影片取得 PictureFrame
    var picFrame = slide.getShapes().get_Item(0);
    // 刪除 PictureFrame 圖像的裁剪區域並回傳裁剪後的圖像
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // 儲存結果
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="注意" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 方法會將裁剪後的圖像加入簡報的圖像集合。若該圖像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 中使用，此設定可減少簡報大小；否則，結果簡報中的圖像數量會增加。

此方法在裁剪過程中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 圖像。 

{{% /alert %}}

## **壓縮圖像**

您可以使用 [PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定的解析度減少圖像尺寸，並可選擇刪除裁剪區域。

它的調整方式類似 PowerPoint 的 **圖片格式 → 壓縮圖片 → 解析度** 功能。

以下 JavaScript 範例示範如何以目標解析度壓縮簡報中的圖像，並可選擇移除裁剪區域：

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 以 150 DPI（網頁解析度）為目標解析度壓縮影像，並移除裁剪區域。
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

或使用其他預設 DPI 值：

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 壓縮影像至 96 DPI（電子郵件解析度），並移除裁剪區域。
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

此方法會根據形狀大小與提供的 DPI 將圖像轉為較低解析度。也可刪除裁剪區域以優化檔案大小。若圖像為中繪檔 (WMF/EMF) 或 SVG，則不會套用壓縮。JPEG 的品質會依解析度略有下降，與 PowerPoint 處理高解析度 JPEG 的方式相同。 

{{% /alert %}}

## **鎖定長寬比**

若您希望含有圖像的形狀在變更圖像尺寸後仍保持長寬比，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) 方法設定 *Lock Aspect Ratio* 屬性。

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
    // 設定形狀在調整大小時保留長寬比
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="注意" color="warning" %}} 

此 *Lock Aspect Ratio* 設定僅保留形狀的長寬比，並不會影響其內含圖像。 

{{% /alert %}}

## **使用 StretchOff 屬性**

透過 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat) 類別的 [setStretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-)、[setStretchOffsetTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--)、[setStretchOffsetRight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) 與 [setStretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) 方法，您可以指定填充矩形。

當為圖像指定伸展時，來源矩形會依指定的填充矩形進行縮放。每個填充矩形的邊緣皆以形狀邊界盒相對邊緣的百分比偏移定義。正百分比表示內縮，負百分比表示外伸。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增一個矩形 `AutoShape`。  
4. 建立圖像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 新增設定好的圖像以填充形狀。  
8. 指定圖像相對於形狀邊界盒各邊的偏移量。  
9. 將修改後的簡報寫入為 PPTX 檔案。  

以下 JavaScript 程式碼示範使用 StretchOff 屬性的流程：

```javascript
// 實例化代表 PPTX 檔案的 Presentation 類別
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
    // 加入設定為 Rectangle 的 AutoShape
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // 設定形狀的填充類型
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // 設定形狀的圖片填充模式
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // 設定圖像以填滿形狀
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // 指定圖像相對於形狀邊界盒各邊的偏移量
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

**如何查詢圖片框支援的圖像格式？**  

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 的圖像物件，同時支援點陣圖像（PNG、JPEG、BMP、GIF 等）與向量圖像（例如 SVG）。支援的格式列表通常與投影片與圖像轉換引擎的功能相吻合。

**大量加入大型圖像會如何影響 PPTX 檔案大小與效能？**  

嵌入大型圖像會增加檔案大小與記憶體使用；使用連結方式加入圖像可降低簡報大小，但需確保外部檔案持續可取得。Aspose.Slides 提供以連結方式加入圖像的功能，以減少檔案容量。

**如何防止圖像物件因誤操作而移動或調整大小？**  

使用 [shape locks](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) 於 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/)（例如停用移動或調整大小）。此鎖定機制支援多種形狀類型，包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/)。

**在匯出簡報為 PDF／圖像時，SVG 向量的保真度是否得以保留？**  

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 中擷取原始 SVG 向量。於 [匯出為 PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/) 或 [點陣格式](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 時，結果可能因匯出設定而被點陣化；但原始 SVG 仍以向量形式儲存，這可從擷取行為得到驗證。