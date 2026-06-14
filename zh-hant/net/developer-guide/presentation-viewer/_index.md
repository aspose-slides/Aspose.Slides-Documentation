---
title: 在 .NET 中建立簡報檢視器
linktitle: 簡報檢視器
type: docs
weight: 50
url: /zh-hant/net/presentation-viewer/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中建立自訂簡報檢視器。輕鬆顯示 PowerPoint 與 OpenDocument 檔案，無需 Microsoft PowerPoint。"
---
## **簡介**

Aspose.Slides for .NET 用於建立包含投影片的簡報檔案。這些投影片可以透過在 Microsoft PowerPoint 等程式中開啟簡報來檢視。然而，開發人員有時可能需要在其偏好的影像檢視器中將投影片視為影像，或在自訂的簡報檢視器中使用它們。在此情況下，Aspose.Slides 允許您將單獨的投影片匯出為影像。本文說明如何執行此操作。

## **從投影片產生 SVG 圖像**

使用 Aspose.Slides 從簡報投影片產生 SVG 圖像，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 依索引取得投影片的參考。
1. 開啟檔案串流。
1. 將投影片儲存為 SVG 圖像至檔案串流。

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **產生具自訂形狀 ID 的 SVG**

Aspose.Slides 可用於從具有自訂形狀 `ID` 的投影片產生 [SVG](https://docs.fileformat.com/page-description-language/svg/)。為了達成此目的，請使用 [ISvgShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/isvgshape) 介面的 Id 屬性。可使用 `CustomSvgShapeFormattingController` 類別來設定形狀 ID。

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **建立投影片縮圖影像**

Aspose.Slides 可協助您產生投影片的縮圖影像。使用 Aspose.Slides 產生投影片縮圖，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 依索引取得投影片的參考。
1. 以所需比例建立參考投影片的縮圖影像。
1. 以您偏好的影像格式儲存縮圖影像。

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **建立具使用者自訂尺寸的投影片縮圖**

要建立具使用者自訂尺寸的投影片縮圖影像，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 依索引取得投影片的參考。
1. 使用指定的尺寸產生參考投影片的縮圖影像。
1. 以您偏好的影像格式儲存縮圖影像。

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **建立含講者備註的投影片縮圖**

使用 Aspose.Slides 產生含講者備註的投影片縮圖，請遵循以下步驟：

1. 建立 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/renderingoptions/) 類別的實例。
1. 使用 `RenderingOptions.SlidesLayoutOptions` 屬性設定講者備註的位置。
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 依索引取得投影片的參考。
1. 使用渲染選項產生參考投影片的縮圖影像。
1. 以您偏好的影像格式儲存縮圖影像。

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **即時範例**

試用免費的 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/zh-hant/viewer/) 應用程式，了解您可以使用 Aspose.Slides API 實作的功能：

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/zh-hant/viewer/)

## **常見問題**

**我可以在 ASP.NET 網站應用程式中嵌入簡報檢視器嗎？**

可以。您可以於伺服器端使用 Aspose.Slides 將投影片渲染為影像或 HTML，並在瀏覽器中顯示。可使用 JavaScript 實作導覽與縮放功能，以提供互動體驗。

**在自訂的 .NET 檢視器中顯示投影片的最佳方式是什麼？**

建議的做法是使用 Aspose.Slides 將每張投影片渲染為影像（例如 PNG 或 SVG）或轉換為 HTML，然後在桌面應用程式的圖片框或 Web 應用程式的 HTML 容器中顯示該輸出。

**我該如何處理擁有大量投影片的簡報？**

對於大型簡報，建議採用延遲載入或即時渲染投影片的方式。這表示僅在使用者導航至特定投影片時才產生其內容，可降低記憶體使用量與載入時間。