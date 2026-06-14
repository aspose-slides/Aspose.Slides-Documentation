---
title: 使用 JavaScript 優化簡報影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/nodejs-java/image/
keywords:
- 新增影像
- 新增圖片
- 新增點陣圖
- 取代影像
- 取代圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 新增 EMF
- 新增 WMF
- 新增 TIFF
- PowerPoint
- OpenDocument
- 簡報
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 以及 Aspose.Slides for Node.js，簡化 PowerPoint 與 OpenDocument 中的影像管理，提升效能並自動化工作流程。"
---
## **簡介**

影像使簡報更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以從檔案、網際網路或其他位置將圖片插入投影片。類似地，Aspose.Slides 允許您透過各種方式將影像加入簡報的投影片中。

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免費轉換器—[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—讓使用者能快速從影像建立簡報。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

如果您想將影像作為框架物件加入——尤其是計畫使用標準格式選項來調整大小、添加效果等——請參閱 [圖片框架](https://docs.aspose.com/slides/zh-hant/nodejs-java/picture-frame/)。 

{{% /alert %}} 

Aspose.Slides 支援在這些常見格式的影像操作：JPEG、PNG、GIF 等。

## **將本機儲存的影像加入投影片**

您可以將電腦上的一張或多張影像加入簡報的投影片中。以下 JavaScript 範例程式碼示範如何將影像加入投影片：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **從串流加入影像至投影片**

如果您想加入投影片的影像在電腦上無法取得，您可以直接從網路加入影像。  
以下範例程式碼示範如何在 JavaScript 中從網路將影像加入投影片：

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 存取第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 將 Excel 檔案載入為串流
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // 建立用於嵌入的資料物件
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // 加入 Ole 物件框架形狀
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // 將 PPTX 檔案寫入磁碟
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將影像加入投影片母片**

投影片母片是最高層的投影片，負責儲存與控制其下所有投影片的資訊（佈景主題、版面配置等）。因此，當您將影像加入投影片母片時，該影像會出現在該母片所屬的每一張投影片上。  
以下 JavaScript 範例程式碼示範如何將影像加入投影片母片：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將影像設為投影片背景**

您可能決定將圖片作為特定投影片或多張投影片的背景。此時，請參閱 *[將影像設為投影片背景](https://docs.aspose.com/slides/zh-hant/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 加入簡報**

您可以使用屬於 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 類別的 [addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 方法，將任何影像加入或插入簡報中。  
若要根據 SVG 影像建立影像物件，您可以這樣做：

1. 建立 SvgImage 物件以插入到 ImageShapeCollection  
2. 從 ISvgImage 建立 PPImage 物件  
3. 使用 PPImage 類別建立 PictureFrame 物件  

以下範例程式碼示範如何實作上述步驟，將 SVG 影像加入簡報：

```javascript
// 實例化代表 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將 SVG 轉換為形狀集合**

Aspose.Slides 將 SVG 轉換為形狀集合的功能類似於 PowerPoint 用於處理 SVG 影像的功能：

![PowerPoint 快顯功能表](img_01_01.png)

此功能由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 類別的其中一個 [addGroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) 方法的超載提供，該方法的第一個參數是 [SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SvgImage) 物件。

以下範例程式碼示範如何使用上述方法，將 SVG 檔案轉換為形狀集合：

```javascript
// 建立新的簡報
var presentation = new aspose.slides.Presentation();
try {
    // 讀取 SVG 檔案內容
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // 建立 SvgImage 物件
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // 取得投影片尺寸
    var slideSize = presentation.getSlideSize().getSize();
    // 將 SVG 影像轉換為形狀群組，並縮放至投影片尺寸
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // 以 PPTX 格式儲存簡報
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **將影像作為 EMF 加入投影片**

Aspose.Slides for Node.js via Java 允許您從 Excel 工作表產生 EMF 影像，並使用 Aspose.Cells 將這些影像以 EMF 形式加入投影片中。  
以下範例程式碼示範如何執行上述工作：

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **取代影像集合中的影像**

Aspose.Slides 允許您取代儲存在簡報影像集合中的影像（包括投影片形狀使用的影像）。本節示範了更新集合中影像的多種方法。API 提供直接的方式，可使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 實例，或集合中已存在的其他影像來取代影像。  
請依循以下步驟：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入包含影像的簡報檔案。  
2. 從檔案載入新影像至位元組陣列。  
3. 使用該位元組陣列將目標影像取代為新影像。  
4. 在第二種方法中，將影像載入 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 物件，並以該物件取代目標影像。  
5. 在第三種方法中，將目標影像取代為簡報影像集合中已存在的影像。  
6. 將修改後的簡報寫入為 PPTX 檔案。  

```js
// 實例化代表簡報檔案的 Presentation 類別。
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 第一種方法。
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 第二種方法。
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 第三種方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // 將簡報儲存至檔案。
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

使用 Aspose FREE 的 [文字轉 GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆為文字添加動畫、從文字建立 GIF 等。 

{{% /alert %}}

## **常見問題**

**插入後原始影像解析度是否保持完整？**  
是的。會保留來源像素，但最終顯示結果取決於投影片上 [picture](/slides/zh-hant/nodejs-java/picture-frame/) 的縮放方式以及儲存時的壓縮情況。

**一次取代數十張投影片上相同標誌的最佳方法是什麼？**  
將標誌放置於母片或版面配置上，並在簡報的影像集合中取代它—此變更會自動傳播至所有使用該資源的元件。

**插入的 SVG 是否可以轉換為可編輯的形狀？**  
可以。您可以將 SVG 轉換為形狀群組，之後各個部件即可使用標準形狀屬性進行編輯。

**如何一次將圖片設定為多張投影片的背景？**  
在母片或相關版面配置上 [將影像設定為背景](/slides/zh-hant/nodejs-java/presentation-background/)，所有套用該母片/版面的投影片皆會繼承此背景。

**如何防止因大量圖片導致簡報檔案體積「膨脹」？**  
請重複使用同一個影像資源而非多個副本，選擇適當的解析度，儲存時啟用壓縮，並在適當情況下將重複圖形放置於母片上。