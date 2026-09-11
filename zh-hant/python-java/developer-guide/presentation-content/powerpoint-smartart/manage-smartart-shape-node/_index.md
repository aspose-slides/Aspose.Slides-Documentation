---
title: 使用 Python 在簡報中管理 SmartArt 形狀節點
linktitle: SmartArt 形狀節點
type: docs
weight: 30
url: /zh-hant/python-java/manage-smartart-shape-node/
keywords:
- SmartArt 節點
- 子節點
- 新增節點
- 節點位置
- 存取節點
- 移除節點
- 自訂位置
- 助理節點
- 填充格式
- 渲染節點
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PPT 與 PPTX 中管理 SmartArt 形狀節點。取得清晰的程式碼範例與技巧，以簡化您的簡報。"
---
## **概述**

PowerPoint 簡報中的 SmartArt 圖形透過包含文字的節點組織，並定義圖表的結構。Aspose.Slides 允許您以程式方式操作這些 SmartArt 節點：新增節點與子節點、在特定位置插入子節點、存取現有節點，並讀取它們的文字、層級與位置。

本文說明如何管理 SmartArt 形狀節點。內容包括移除節點、透過索引或位置操作子節點、將助理節點變更為普通節點、調整 SmartArt 節點形狀的位置、大小與旋轉、設定節點填充格式，以及為 SmartArt 子節點產生縮圖。

## **新增 SmartArt 節點**
Aspose.Slides for Python via Java 提供管理 SmartArt 形狀的 API。以下範例將節點與子節點新增至 SmartArt 形狀。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例，並載入包含 SmartArt 形狀的簡報。
2. 依索引取得第一張投影片。
3. 逐一巡訪第一張投影片上的每個形狀。
4. 檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 例項。
5. 使用 [Add a new node](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnodecollection/#addNode) 新增節點至 SmartArt 形狀的 [node collection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/#getAllNodes)，並透過 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 設定其文字。
6. 使用 [Add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnodecollection/#addNode) 新增 [child node](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/#getChildNodes) 至該節點，並透過 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 設定文字。
7. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在特定位置新增 SmartArt 節點**
以下範例在 SmartArt 節點中於特定位置新增子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
2. 依索引取得第一張投影片。
3. 在投影片上加入具有 [StackedList](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartlayouttype/#StackedList) 版面的 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 形狀。
4. 取得已加入 SmartArt 形狀的第一個節點。
5. 使用 [addNodeByPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) 在位置 2 新增子節點，並設定其文字。
6. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取 SmartArt 節點**
以下範例存取 SmartArt 形狀中的節點。[getLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/#getLayout) 回傳的版面為唯讀，且在加入 SmartArt 形狀時即設定。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例，並載入包含 SmartArt 形狀的簡報。
2. 依索引取得第一張投影片。
3. 逐一巡訪第一張投影片上的每個形狀。
4. 檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 例項。
5. 逐一巡訪 SmartArt 形狀中所有 [nodes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/#getAllNodes)。
6. 讀取並顯示每個 SmartArt 節點的位置、層級與文字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **存取 SmartArt 子節點**
以下範例存取 SmartArt 形狀中每個節點的子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例，並載入包含 SmartArt 形狀的簡報。
2. 依索引取得第一張投影片。
3. 逐一巡訪第一張投影片上的每個形狀。
4. 檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 例項。
5. 逐一巡訪 SmartArt 形狀中所有 [nodes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/#getAllNodes)。
6. 對每個節點，巡訪其 [child nodes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/#getChildNodes)。
7. 讀取並顯示 [child node](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/#getChildNodes) 的位置、層級與文字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **在特定位置存取 SmartArt 子節點**
以下範例在父節點集合中以特定索引存取子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
2. 依索引取得第一張投影片。
3. 加入具有 [StackedList](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartlayouttype/#StackedList) 版面的 SmartArt 形狀。
4. 取得已加入的 SmartArt 形狀。
5. 取得 SmartArt 形狀中索引為 0 的節點。
6. 使用 [get_Item](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnodecollection/#get_Item) 取得索引為 1 的子節點。
7. 讀取並顯示 [child node](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/#getChildNodes) 的位置、層級與文字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **移除 SmartArt 節點**
以下範例從 SmartArt 形狀中移除節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例，並載入包含 SmartArt 形狀的簡報。
2. 依索引取得第一張投影片。
3. 逐一巡訪第一張投影片上的每個形狀。
4. 檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 例項。
5. 確認 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 形狀至少包含一個節點。
6. 選取要刪除的 SmartArt 節點。
7. 使用 [removeNode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnodecollection/#removeNode) 移除所選節點。
8. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在特定位置移除 SmartArt 節點**
以下範例在 SmartArt 節點的集合中以特定索引移除子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例，並載入包含 SmartArt 形狀的簡報。
2. 依索引取得第一張投影片。
3. 逐一巡訪第一張投影片上的每個形狀。
4. 檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 例項。
5. 取得索引為 0 的 SmartArt 節點（若存在）。
6. 確認選取的 SmartArt 節點至少有兩個子節點。
7. 使用 [removeNode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnodecollection/#removeNode) 移除索引為 1 的子節點。
8. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **為 SmartArt 物件的子節點設定自訂位置**
Aspose.Slides for Python via Java 支援使用 [setX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setX) 與 [setY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setY) 設定 [SmartArtShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartshape/) 的位置。以下範例為 SmartArt 節點形狀設定自訂位置、大小與旋轉。新增節點會重新計算所有節點的位置與大小。自訂定位讓您依需求安排節點。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **檢查助理節點**
{{% alert color="info" title="Note" %}} 

本節探討使用 Aspose.Slides for Python via Java 以程式方式加入至簡報投影片的 SmartArt 形狀。

{{% /alert %}} 

以下來源 SmartArt 形狀用於本範例。

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**圖示：投影片上的來源 SmartArt 形狀**|

以下範例識別 SmartArt 節點集合中的助理節點，並將其變更為普通節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例，並載入包含 SmartArt 形狀的簡報。
2. 依索引取得第一張投影片。
3. 逐一巡訪第一張投影片上的每個形狀。
4. 檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 例項。
5. 逐一巡訪 SmartArt 形狀中的所有節點，並檢查其是否為 [Assistant Nodes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/#isAssistant)。
6. 將每個助理節點變更為普通節點。
7. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**圖示：投影片上 SmartArt 形狀中的助理節點已變更**|

## **設定節點的填充格式**
Aspose.Slides for Python via Java 讓您能新增自訂 SmartArt 形狀並設定其填充格式。本文說明如何建立與存取 SmartArt 形狀，並使用 Aspose.Slides for Python via Java 設定其填充格式。

請依以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
2. 依索引取得投影片。
3. 新增具有 [ClosedChevronProcess](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) 版面的 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 形狀。
4. 為 SmartArt 形狀的節點設定 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getFillFormat)。
5. 將修改後的簡報寫入 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **產生 SmartArt 子節點的縮圖**
若要產生 SmartArt 子節點的縮圖，請依下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
2. [Add a SmartArt shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addSmartArt)。
3. 依索引取得節點。
4. 取得縮圖影像。
5. 以任意想要的影像格式儲存縮圖。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **常見問題**

**支援 SmartArt 動畫嗎？**

是的。SmartArt 被視為一般形狀，您可以套用[標準動畫](/slides/zh-hant/python-java/shape-animation/)（進入、退出、強調、移動路徑）並調整時間。必要時也可為 SmartArt 節點內的形狀加入動畫。

**如果不知道內部 ID，如何可靠地在投影片上定位特定 SmartArt？**

請使用[替代文字](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getAlternativeText)進行設定與搜尋。為 SmartArt 設定唯一的替代文字，即可在程式中找尋，而不必依賴內部識別碼。

**將簡報轉換為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。Aspose.Slides 在[PDF 匯出](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)時，以高視覺忠實度呈現 SmartArt，保留其版面、顏色與效果。

**我可以擷取整個 SmartArt 的圖像嗎（用於預覽或報告）？**

可以。您可以將 SmartArt 形狀渲染為[點陣格式](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage)或[SVG](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#writeAsSvgToBytes)以取得可縮放的向量輸出，適用於縮圖、報告或網頁使用。