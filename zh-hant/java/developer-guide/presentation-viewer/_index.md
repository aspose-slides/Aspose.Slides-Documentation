---
title: 在 Java 中建立簡報檢視器
linktitle: 簡報檢視器
type: docs
weight: 50
url: /zh-hant/java/presentation-viewer/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中建立自訂簡報檢視器。輕鬆顯示 PowerPoint 和 OpenDocument 檔案，無需 Microsoft PowerPoint。"
---
## **簡介**

Aspose.Slides for Java 用於建立包含投影片的簡報檔案。這些投影片可透過在 Microsoft PowerPoint 等程式中開啟簡報來檢視。然而，有時開發人員可能需要在自己偏好的影像檢視器中將投影片以影像形式檢視，或是自行建立簡報檢視器。在此情況下，Aspose.Slides 允許您將單一投影片匯出為影像。本文說明如何操作。

## **從投影片產生 SVG 影像**

若要使用 Aspose.Slides 從簡報投影片產生 SVG 影像，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 開啟檔案串流。
1. 將投影片以 SVG 影像儲存至檔案串流。

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **產生具自訂形狀 ID 的 SVG**

Aspose.Slides 可用於從投影片產生具有自訂形狀 ID 的 [SVG](https://docs.fileformat.com/page-description-language/svg/)。為此，請使用來自 [ISvgShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgshape/) 的 `setId` 方法。`CustomSvgShapeFormattingController` 可用於設定形狀 ID。

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **建立投影片縮圖影像**

Aspose.Slides 可協助您產生投影片的縮圖影像。若要使用 Aspose.Slides 產生投影片縮圖，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 以定義的比例取得參考投影片的縮圖影像。
1. 以任意想要的影像格式儲存縮圖影像。

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **以使用者自訂尺寸建立投影片縮圖**

若要以使用者自訂尺寸建立投影片縮圖影像，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 以自訂的尺寸取得參考投影片的縮圖影像。
1. 以任意想要的影像格式儲存縮圖影像。

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **以講者備註建立投影片縮圖**

若要使用 Aspose.Slides 產生含講者備註的投影片縮圖，請依照下列步驟：

1. 建立 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/renderingoptions/) 類別的執行個體。
1. 使用 `RenderingOptions.setSlidesLayoutOptions` 方法設定講者備註的位置。
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 使用渲染選項取得參考投影片的縮圖影像。
1. 以任意想要的影像格式儲存縮圖影像。

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **即時範例**

您可試用免費的 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/zh-hant/viewer/) 應用程式，了解使用 Aspose.Slides API 可實作的功能：

![線上 PowerPoint 檢視器](online-PowerPoint-viewer.png)

## **常見問題**

**我可以在 Web 應用程式中嵌入簡報檢視器嗎？**

可以。您可以在伺服器端使用 Aspose.Slides 將投影片渲染為影像或 HTML，並在瀏覽器中顯示。可使用 JavaScript 實作導覽與縮放功能，以提供互動體驗。

**在自訂檢視器中顯示投影片的最佳方式是什麼？**

建議的做法是使用 Aspose.Slides 將每張投影片渲染為影像（例如 PNG 或 SVG）或轉換為 HTML，然後將輸出顯示於圖片框（桌面版）或 HTML 容器（Web 版）中。

**如何處理包含大量投影片的簡報？**

對於大型簡報，可考慮延遲載入或按需渲染投影片。即僅在使用者切換至該投影片時才產生其內容，以減少記憶體使用與載入時間。