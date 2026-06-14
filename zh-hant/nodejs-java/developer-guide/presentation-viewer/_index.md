---
title: 在 JavaScript 中建立簡報檢視器
linktitle: 簡報檢視器
type: docs
weight: 50
url: /zh-hant/nodejs-java/presentation-viewer/
keywords:
- 檢視簡報
- 簡報檢視器
- 建立簡報檢視器
- 檢視 PPT
- 檢視 PPTX
- 檢視 ODP
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中建立自訂簡報檢視器。輕鬆顯示 PowerPoint 與 OpenDocument 檔案，無需 Microsoft PowerPoint。"
---
## **簡介**

Aspose.Slides for Node.js via Java 用於建立包含投影片的簡報檔案。這些投影片可以透過在 Microsoft PowerPoint 等程式中開啟簡報來檢視。但有時開發人員可能需要在喜好的影像檢視器中將投影片視為圖片，或自行建構簡報檢視器。在此情況下，Aspose.Slides 允許您將單一投影片匯出為圖像。本文說明如何執行此操作。

## **從投影片產生 SVG 圖像**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 開啟檔案串流。
1. 將投影片以 SVG 圖像儲存至檔案串流。

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **產生具有自訂形狀 ID 的 SVG**

Aspose.Slides 可用於從投影片產生具有自訂形狀 ID 的 [SVG](https://docs.fileformat.com/page-description-language/svg/)。為此，請使用來自 [SvgShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgshape/) 的 `setId` 方法。`CustomSvgShapeFormattingController` 可用於設定形狀 ID。

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **建立投影片縮圖圖像**

Aspose.Slides 幫助您產生投影片的縮圖圖像。要使用 Aspose.Slides 產生投影片縮圖，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 依設定的比例取得參考投影片的縮圖圖像。
1. 以任何想要的圖像格式儲存縮圖圖像。

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **以使用者自訂尺寸建立投影片縮圖**

要以使用者自訂尺寸建立投影片縮圖圖像，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 以自訂尺寸取得參考投影片的縮圖圖像。
1. 以任何想要的圖像格式儲存縮圖圖像。

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **以講者備註建立投影片縮圖**

要使用 Aspose.Slides 產生帶有講者備註的投影片縮圖，請遵循以下步驟：

1. 建立 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/) 類別的實例。
1. 使用 `RenderingOptions.setSlidesLayoutOptions` 方法設定講者備註的位置。
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 使用渲染選項取得參考投影片的縮圖圖像。
1. 以任何想要的圖像格式儲存縮圖圖像。

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **即時範例**

您可以試用 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/zh-hant/viewer/) 免費應用程式，了解可使用 Aspose.Slides API 實作的功能：

![線上 PowerPoint 檢視器](online-PowerPoint-viewer.png)

## **常見問題**

**我可以在 Node.js 網路應用程式中嵌入簡報檢視器嗎？**

是的。您可以在伺服器端使用 Aspose.Slides 將投影片渲染為圖像或 HTML，並在瀏覽器中顯示。可透過 JavaScript 實作導覽與縮放功能，以提供互動式體驗。

**在自訂檢視器中顯示投影片的最佳方式是什麼？**

建議的做法是使用 Aspose.Slides 將每張投影片渲染為圖像（例如 PNG 或 SVG）或轉換為 HTML，然後將產出放入圖片框（桌面版）或 HTML 容器（網頁版）中顯示。

**我該如何處理擁有大量投影片的簡報？**

對於大型簡報，建議使用延遲載入或按需渲染投影片的方式。也就是說，僅在使用者切換至該投影片時才產生其內容，以降低記憶體使用量與載入時間。