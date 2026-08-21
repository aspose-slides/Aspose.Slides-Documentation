---
title: 在 Python 中管理簡報的繪圖參考線
linktitle: 繪圖參考線
type: docs
weight: 85
url: /zh-hant/python-net/drawing-guides/
keywords:
- 繪圖參考線
- 水平參考線
- 垂直參考線
- 對齊參考線
- 投影片檢視
- 母片投影片
- 版面投影片
- 備註母片
- 講義母片
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中新增、存取和清除水平與垂直繪圖參考線。"
---
## **概述**

繪圖參考線是可調整的水平和垂直線，可協助使用者在 PowerPoint 中編輯簡報時一致地對齊形狀。當應用程式產生簡報，之後需要手動精細調整時，它特別有用：應用程式可以儲存相同的對齊輔助，作者在新增或移動內容時應遵循這些輔助。

繪圖參考線是編輯輔助工具，而非投影片內容。它們不會出現在投影片放映或渲染輸出中。Aspose.Slides for Python via .NET 透過 [IDrawingGuidesCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/idrawingguidescollection/) 介面公開這些參考線。參考線由 [IDrawingGuide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/idrawingguide/) 代表，具備方向、位置與顏色。

位置以點 (points) 為單位，從相關投影片或母片的左上角測量。垂直參考線使用水平座標，通常介於 0 與投影片寬度之間。水平參考線使用垂直座標，通常介於 0 與投影片高度之間。

## **將參考線新增至投影片檢視**

使用 [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) 來管理編輯一般投影片時顯示的參考線。呼叫 [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/idrawingguidescollection/add/)，傳入 [Orientation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/orientation/) 值與以點為單位的位置。

以下範例於投影片中心右側新增一條垂直參考線，於其下方新增一條水平參考線：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **存取繪圖參考線**

[IDrawingGuidesCollection.count](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/idrawingguidescollection/count/) 屬性與索引子提供對現有參考線的存取。[IDrawingGuide.orientation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/idrawingguide/orientation/)、[IDrawingGuide.position](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/idrawingguide/position/) 以及 [IDrawingGuide.color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/idrawingguide/color/) 屬性可讀寫。

以下範例讀取上述建立的簡報中投影片檢視的參考線：

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **將參考線新增至母片與版面投影片**

投影片母片與其每個版面投影片皆可擁有各自的繪圖參考線集合。對母片使用 [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterslide/drawing_guides/)，對版面投影片使用 [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ilayoutslide/drawing_guides/)。

以下範例於第一個母片新增一條垂直參考線，於第一個版面投影片新增一條水平參考線：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **將參考線新增至備註母片與講義母片**

備註母片與講義母片也支援繪圖參考線。使用 [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasternotesslide/drawing_guides/) 與 [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) 可存取它們的集合。若簡報未包含其中任一母片，[IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) 或 [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) 會建立預設母片並回傳。

以下範例於備註母片新增一條水平參考線，於講義母片新增一條垂直參考線：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **清除繪圖參考線**

呼叫 [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/idrawingguidescollection/clear/) 可移除特定集合中所有參考線。清除一個集合不會影響其他範圍內儲存的參考線。

以下範例在不建立缺失母片的情況下，清除投影片檢視的參考線以及投影片母片、版面投影片、備註母片與講義母片上的所有參考線：

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**繪圖參考線會出現在投影片放映或匯出圖片中嗎？**

不會。繪圖參考線是用於編輯的對齊輔助，並不會作為簡報內容被渲染。

**可以將繪圖參考線直接新增至單一一般投影片嗎？**

一般投影片的編輯參考線儲存在簡報的投影片檢視屬性中。針對投影片母片、版面投影片、備註母片與講義母片亦提供獨立的參考線集合。

**參考線位置使用哪種單位？**

位置以點為單位，72 點等於一英吋。垂直位置以左邊緣為起點測量，水平位置以上邊緣為起點測量。

**清除繪圖參考線會移除圖形或變更投影片內容嗎？**

不會。`clear` 方法僅移除所選集合中的參考線。圖形及其他投影片內容保持不變。