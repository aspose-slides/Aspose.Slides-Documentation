---
title: 在 .NET 中管理簡報的繪圖參考線
linktitle: 繪圖參考線
type: docs
weight: 85
url: /zh-hant/net/drawing-guides/
keywords:
- 繪圖參考線
- 水平參考線
- 垂直參考線
- 對齊參考線
- 投影片檢視
- 母片投影片
- 版面配置投影片
- 備註母片
- 講義母片
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 PowerPoint 簡報中使用 Aspose.Slides for .NET 添加、存取和清除水平與垂直繪圖參考線。"
---
## **概觀**

繪圖參考線是可調整的水平和垂直線條，可協助使用者在 PowerPoint 中編輯簡報時一致地對齊圖形。當應用程式產生的簡報之後需要手動調整時，它們特別有用：應用程式可以儲存相同的對齊輔助，讓作者在新增或移動內容時遵循。

繪圖參考線是編輯輔助工具，而非投影片內容。它們不會出現在投影片放映或渲染輸出中。Aspose.Slides for .NET 透過 [IDrawingGuidesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idrawingguidescollection/) 介面公開這些參考線。參考線以 [IDrawingGuide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idrawingguide/) 來表示，具有方向、位置與顏色。

位置以點 (point) 為單位，從相關投影片或母片的左上角測量。垂直參考線使用水平座標，通常介於 0 與投影片寬度之間。水平參考線使用垂直座標，通常介於 0 與投影片高度之間。

## **將參考線加入投影片檢視**

使用 [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icommonslideviewproperties/drawingguides/) 來管理編輯普通投影片時顯示的參考線。呼叫 [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idrawingguidescollection/add/) 並傳入 [Orientation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/orientation/) 值以及以點為單位的位置。

以下範例在投影片中心右側加入一條垂直參考線，並在其下方加入一條水平參考線：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **存取繪圖參考線**

[IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idrawingguidescollection/count/) 屬性與索引子提供對現有參考線的存取。可讀取或變更 [IDrawingGuide.Orientation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idrawingguide/orientation/)、[IDrawingGuide.Position](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idrawingguide/position/) 以及 [IDrawingGuide.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idrawingguide/color/) 屬性。

以下範例讀取上述建立的簡報中的投影片檢視參考線：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **將參考線加入母片與版面配置投影片**

投影片母片及其每個版面配置投影片都可以擁有各自的繪圖參考線集合。對母片投影片使用 [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/drawingguides/)，對版面配置投影片使用 [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/drawingguides/)。

以下範例在第一張母片投影片添加一條垂直參考線，並在第一張版面配置投影片添加一條水平參考線：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **將參考線加入備註與講義母片**

備註母片與講義母片也支援繪圖參考線。使用 [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasternotesslide/drawingguides/) 與 [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterhandoutslide/drawingguides/) 來存取它們的集合。如果簡報沒有這些母片，則 [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) 或 [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) 會建立預設母片並回傳。

以下範例在備註母片添加一條水平參考線，並在講義母片添加一條垂直參考線：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **清除繪圖參考線**

呼叫 [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idrawingguidescollection/clear/) 以移除特定集合中的所有參考線。清除一個集合不會影響存於其他範圍的參考線。

以下範例在不建立缺少母片的情況下，清除投影片檢視參考線以及投影片母片、版面配置投影片、備註母片與講義母片上的所有參考線：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **常見問題**

**繪圖參考線會出現在投影片放映或匯出的影像中嗎？**

不會。繪圖參考線是編輯時的對齊輔助，並不會作為簡報內容被渲染。

**可以直接將繪圖參考線加入單一普通投影片嗎？**

普通投影片的編輯參考線儲存在簡報的投影片檢視屬性中。對投影片母片、版面配置投影片、備註母片與講義母片則有各自的參考線集合。

**參考線位置使用什麼單位？**

位置以點 (point) 為單位，1 英吋等於 72 點。垂直位置從左邊緣測量，水平位置從上邊緣測量。

**清除繪圖參考線會移除圖形或變更投影片內容嗎？**

不會。`Clear` 方法僅會移除所選集合中的參考線。圖形與其他投影片內容保持不變。