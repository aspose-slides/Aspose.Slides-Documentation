---
title: 在 Python 中管理簡報的繪圖參考線
linktitle: 繪圖參考線
type: docs
weight: 85
url: /zh-hant/python-java/drawing-guides/
keywords:
- 繪圖參考線
- 水平參考線
- 垂直參考線
- 對齊參考線
- 投影片檢視
- 母片
- 版面投影片
- 備註母片
- 講義母片
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中新增、存取與清除水平與垂直的繪圖參考線。"
---
## **概觀**

繪圖參考線是可調整的水平與垂直線條，可協助使用者在 PowerPoint 中編輯簡報時持續對齊圖形。當應用程式產生簡報，之後需手動微調時，特別有用：應用程式可以儲存相同的對齊輔助，讓作者在新增或移動內容時遵循。

繪圖參考線是編輯輔助工具，而非投影片內容。它們不會出現在投影片放映或渲染輸出中。Aspose.Slides for Python via Java 透過 [DrawingGuidesCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguidescollection/) 類別公開這些參考線。每條參考線以 [DrawingGuide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguide/) 表示，並具備方向、位置與顏色。

位置以點為單位，從相關投影片或母片的左上角測量。垂直參考線使用水平座標，通常介於 0 與投影片寬度之間。水平參考線使用垂直座標，通常介於 0 與投影片高度之間。

## **將參考線新增至投影片檢視**

使用 [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) 來管理編輯普通投影片時顯示的參考線。呼叫 [DrawingGuidesCollection.add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguidescollection/#add)，傳入 [Orientation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/orientation/) 值以及點為單位的位置。

以下範例在投影片中心右側新增一條垂直參考線，並在其下方新增一條水平參考線：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取繪圖參考線**

透過 [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguidescollection/#getCount) 與 [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguidescollection/#get_Item) 方法可取得現有的參考線。 [DrawingGuide.getOrientation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguide/#getOrientation)、[DrawingGuide.getPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguide/#getPosition) 與 [DrawingGuide.getColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguide/#getColor) 方法回傳的值也可透過對應的設定子方法進行變更。

以下範例從上述建立的簡報中讀取投影片檢視的參考線：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **將參考線新增至母片與版面投影片**

投影片母片及其每個版面投影片都可以擁有自己的繪圖參考線集合。對於母片，使用 [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/#getDrawingGuides)；對於版面投影片，使用 [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/#getDrawingGuides)。

以下範例在第一張母片上新增一條垂直參考線，並在第一個版面投影片上新增一條水平參考線：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **將參考線新增至備註與講義母片**

備註母片與講義母片也支援繪圖參考線。可以使用 [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslide/#getDrawingGuides) 與 [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) 取得它們的集合。若簡報未包含其中任一母片，`MasterNotesSlideManager.setDefaultMasterNotesSlide` 或 `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` 會建立預設母片並回傳。

以下範例在備註母片上新增一條水平參考線，並在講義母片上新增一條垂直參考線：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **清除繪圖參考線**

呼叫 [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguidescollection/#clear) 可從特定集合中移除所有參考線。清除某個集合不會影響其他範圍中保存的參考線。

以下範例在不建立缺失母片的情況下，清除投影片檢視的參考線以及投影片母片、版面投影片、備註母片與講義母片上的所有參考線：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**繪圖參考線會出現在投影片放映或匯出影像中嗎？**

不會。繪圖參考線僅作為編輯對齊輔助，並不會被渲染為簡報內容。

**可以直接將繪圖參考線新增至單一普通投影片嗎？**

普通投影片的編輯參考線儲存在簡報的投影片檢視屬性中。投影片母片、版面投影片、備註母片與講義母片各自擁有獨立的參考線集合。

**參考線位置使用何種單位？**

位置以點為單位，72 點等於一英吋。垂直位置以左邊緣為基準測量，水平位置以頂端為基準測量。

**清除繪圖參考線會移除圖形或變更投影片內容嗎？**

不會。[DrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/drawingguidescollection/#clear) 方法僅移除所選集合中的參考線。圖形與其他投影片內容保持不變。