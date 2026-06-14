---
title: 在 C++ 中建立簡報檢視器
linktitle: 簡報檢視器
type: docs
weight: 50
url: /zh-hant/cpp/presentation-viewer/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中建立自訂簡報檢視器。輕鬆顯示 PowerPoint 與 OpenDocument 檔案，無需 Microsoft PowerPoint。"
---
## **簡介**

Aspose.Slides for C++ 用於建立包含投影片的簡報檔案。這些投影片可以透過開啟 Microsoft PowerPoint 等程式來檢視。然而，有時開發人員可能需要在喜愛的影像檢視器中將投影片顯示為圖像，或自行建立簡報檢視器。在此情況下，Aspose.Slides 允許您將單一投影片匯出為圖像。本文說明如何執行此操作。

## **從投影片產生 SVG 圖像**

若要使用 Aspose.Slides 從簡報投影片產生 SVG 圖像，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 開啟檔案串流。
1. 將投影片以 SVG 圖像儲存至檔案串流。

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **產生具有自訂形狀 ID 的 SVG**

Aspose.Slides 可用於從投影片產生具有自訂形狀 ID 的 [SVG](https://docs.fileformat.com/page-description-language/svg/)。為此，請使用 [ISvgShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isvgshape/) 的 `set_Id` 方法。`CustomSvgShapeFormattingController` 可用來設定形狀 ID。

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **建立投影片縮圖圖像**

Aspose.Slides 可協助您產生投影片的縮圖圖像。若要使用 Aspose.Slides 產生投影片縮圖，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 以定義的比例取得參考投影片的縮圖圖像。
1. 以任意所需的影像格式儲存縮圖圖像。

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **以使用者自訂尺寸建立投影片縮圖**

若要以使用者自訂尺寸建立投影片縮圖圖像，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 以自訂尺寸取得參考投影片的縮圖圖像。
1. 以任意所需的影像格式儲存縮圖圖像。

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **建立帶有講者備註的投影片縮圖**

若要使用 Aspose.Slides 產生帶有講者備註的投影片縮圖，請依照以下步驟操作：

1. 建立 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/renderingoptions/) 類別的實例。
1. 使用 `RenderingOptions.set_SlidesLayoutOptions` 方法設定講者備註的位置。
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 以渲染選項取得參考投影片的縮圖圖像。
1. 以任意所需的影像格式儲存縮圖圖像。

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **即時範例**

您可以試用免費的 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/zh-hant/viewer/) 應用程式，了解可使用 Aspose.Slides API 實作的功能：

![線上 PowerPoint 檢視器](online-PowerPoint-viewer.png)

## **常見問題**

**我可以在 Web 應用程式中嵌入簡報檢視器嗎？**

可以。您可以在伺服器端使用 Aspose.Slides 將投影片呈現為圖像或 HTML，並在瀏覽器中顯示。導航與縮放功能可透過 JavaScript 實作，以提供互動體驗。

**在自訂檢視器中顯示投影片的最佳方式是什麼？**

建議的做法是將每張投影片渲染為圖像（例如 PNG 或 SVG）或使用 Aspose.Slides 轉換為 HTML，然後將輸出顯示在桌面應用程式的 picture box 或 Web 應用程式的 HTML 容器中。

**如何處理包含大量投影片的簡報？**

對於大型簡報，建議採用懶載入或按需渲染投影片的方式。這意味著僅在使用者導航至特定投影片時才產生該投影片的內容，可減少記憶體使用量與載入時間。