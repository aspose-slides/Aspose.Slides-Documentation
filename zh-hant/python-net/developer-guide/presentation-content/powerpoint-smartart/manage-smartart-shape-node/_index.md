---
title: 使用 Python 管理簡報中的 SmartArt 形狀節點
linktitle: SmartArt 形狀節點
type: docs
weight: 30
url: /zh-hant/python-net/manage-smartart-shape-node/
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
- 呈現節點
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理 PPT、PPTX 與 ODP 中的 SmartArt 形狀節點。取得清晰的程式範例與技巧，以簡化您的簡報。"
---
## **概述**

PowerPoint 簡報中的 SmartArt 圖形是透過包含文字的節點來組織，並定義圖表的結構。Aspose.Slides 允許您以程式方式操作這些 SmartArt 節點：新增節點與子節點、在特定位置插入子節點、存取現有節點，並讀取它們的文字、層級和位置。

本文說明如何管理 SmartArt 形狀節點。內容包括如何移除節點、依索引或位置操作子節點、將助理節點變更為普通節點、調整 SmartArt 節點形狀的位置、大小與旋轉、設定節點的填充格式，以及為 SmartArt 子節點產生縮圖影像。

## **新增 SmartArt 節點**
Aspose.Slides for Python via .NET 提供了最簡單的 API，以最容易的方式管理 SmartArt 形狀。以下範例程式碼可協助在 SmartArt 形狀內新增節點與子節點。

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例，並載入含有 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參照。
- 遍歷第一張投影片內的每個形狀。
- 檢查形狀是否為 SmartArt 類型，若是則將選取的形狀轉型為 SmartArt。
- 在 SmartArt 形狀的 NodeCollection 中新增節點，並於 TextFrame 設定文字。
- 現在，在剛新增的 SmartArt 節點中加入子節點，並於 TextFrame 設定文字。
- 儲存簡報。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 載入所需的簡報
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # 穿越第一張投影片內的每個形狀
    for shape in pres.slides[0].shapes:

        # 檢查形狀是否為 SmartArt 類型
        if type(shape) is art.SmartArt:
            # 新增一個 SmartArt 節點
            node1 = shape.all_nodes.add_node()
            # 加入文字
            node1.text_frame.text = "Test"

            # 在父節點中新增子節點。它將被加入到集合的末端
            new_node = node1.child_nodes.add_node()

            # 加入文字
            new_node.text_frame.text = "New Node Added"

    # 儲存簡報
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在特定位置新增 SmartArt 節點**
以下範例程式碼說明如何在特定位置為 SmartArt 形狀的相應節點加入子節點。

- 建立 `Presentation` 類別的實例。
- 使用索引取得第一張投影片的參照。
- 在取得的投影片中新增 StackedList 類型的 SmartArt 形狀。
- 存取新增 SmartArt 形狀的第一個節點。
- 現在，於位置 2 為選取的節點新增子節點，並設定其文字。
- 儲存簡報。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 建立簡報實例
with slides.Presentation() as pres:
    # 取得簡報投影片
    slide = pres.slides[0]

    # 新增 Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # 取得索引 0 的 SmartArt 節點
    node = smart.all_nodes[0]

    # 在父節點的第 2 個位置新增子節點
    chNode = node.child_nodes.add_node_by_position(2)

    # 加入文字
    chNode.text_frame.text = "Sample text Added"

    # 儲存簡報
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **存取 SmartArt 節點**
以下範例程式碼可協助存取 SmartArt 形狀內的節點。請注意，SmartArt 的 LayoutType 為唯讀，僅在新增 SmartArt 形狀時設定，無法變更。

- 建立 `Presentation` 類別的實例，並載入含有 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參照。
- 遍歷第一張投影片內的每個形狀。
- 檢查形狀是否為 SmartArt 類型，若是則將選取的形狀轉型為 SmartArt。
- 遍歷 SmartArt 形狀內的所有節點。
- 存取並顯示 SmartArt 節點的位置、層級與文字等資訊。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 載入所需的簡報
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # 穿越第一張投影片內的每個形狀
    for shape in pres.slides[0].shapes:
        # 檢查形狀是否為 SmartArt 類型
        if type(shape) is art.SmartArt:
            # 穿越 SmartArt 內的所有節點
            for i in range(len(shape.all_nodes)):
                # 取得索引 i 的 SmartArt 節點
                node = shape.all_nodes[i]

                # 印出 SmartArt 節點參數
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **存取 SmartArt 子節點**
以下範例程式碼可協助存取 SmartArt 形狀中各節點所屬的子節點。

- 建立 PresentationEx 類別的實例，並載入含有 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參照。
- 遍歷第一張投影片內的每個形狀。
- 檢查形狀是否為 SmartArt 類型，若是則將選取的形狀轉型為 SmartArtEx。
- 遍歷 SmartArt 形狀內的所有節點。
- 對於每個選取的 SmartArt 形狀節點，遍歷該節點內的所有子節點。
- 存取並顯示子節點的位置、層級與文字等資訊。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 載入所需的簡報
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # 穿越第一張投影片內的每個形狀
    for shape in pres.slides[0].shapes:
        # 檢查形狀是否為 SmartArt 類型
        if type(shape) is art.SmartArt:
            # 穿越 SmartArt 內的所有節點
            for node0 in shape.all_nodes:
                # 遍歷子節點
                for j in range(len(node0.child_nodes)):
                    # 取得 SmartArt 節點中的子節點
                    node = node0.child_nodes[j]

                    # 印出 SmartArt 子節點參數
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```

## **在特定位置存取 SmartArt 子節點**
在本範例中，我們將學習在特定位置存取屬於 SmartArt 形狀各節點的子節點。

- 建立 `Presentation` 類別的實例。
- 使用索引取得第一張投影片的參照。
- 新增 StackedList 類型的 SmartArt 形狀。
- 存取新增的 SmartArt 形狀。
- 取得該 SmartArt 形狀索引 0 的節點。
- 現在，使用 GetNodeByPosition() 方法取得該 SmartArt 節點位置 1 的子節點。
- 存取並顯示子節點的位置、層級與文字等資訊。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 建立簡報實例
with slides.Presentation() as pres:
    # 取得第一張投影片
    slide = pres.slides[0]
    # 在第一張投影片中新增 SmartArt 形狀
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # 取得索引 0 的 SmartArt 節點
    node = smart.all_nodes[0]
    # 取得父節點中位置 1 的子節點
    position = 1
    chNode = node.child_nodes[position] 
    # 印出 SmartArt 子節點參數
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```

## **移除 SmartArt 節點**
在本範例中，我們將學習移除 SmartArt 形狀內的節點。

- 建立 `Presentation` 類別的實例，並載入含有 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參照。
- 遍歷第一張投影片內的每個形狀。
- 檢查形狀是否為 SmartArt 類型，若是則將選取的形狀轉型為 SmartArt。
- 檢查 SmartArt 是否至少有一個節點。
- 選取欲刪除的 SmartArt 節點。
- 現在，使用 RemoveNode() 方法移除選取的節點，並儲存簡報。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 載入所需的簡報
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # 穿越第一張投影片內的每個形狀
    for shape in pres.slides[0].shapes:
        # 檢查形狀是否為 SmartArt 類型
        if type(shape) is art.SmartArt:
            # 將形狀類型轉換為 SmartArtEx
            if len(shape.all_nodes) > 0:
                # 取得索引 0 的 SmartArt 節點
                node = shape.all_nodes[0]

                # 移除選取的節點
                shape.all_nodes.remove_node(node)

    # 儲存簡報
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在特定位置移除 SmartArt 節點**
在本範例中，我們將學習在特定位置移除 SmartArt 形狀內的節點。

- 建立 `Presentation` 類別的實例，並載入含有 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參照。
- 遍歷第一張投影片內的每個形狀。
- 檢查形狀是否為 SmartArt 類型，若是則將選取的形狀轉型為 SmartArt。
- 選取索引 0 的 SmartArt 形狀節點。
- 現在，檢查選取的 SmartArt 節點是否有超過 2 個子節點。
- 現在，使用 RemoveNodeByPosition() 方法移除位置 1 的節點。
- 儲存簡報。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 載入所需的簡報
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # 穿越第一張投影片內的每個形狀
    for shape in pres.slides[0].shapes:
        # 檢查形狀是否為 SmartArt 類型
        if type(shape) is art.SmartArt:
            # 將形狀轉換為 SmartArt
            if len(shape.all_nodes) > 0:
                # 取得索引 0 的 SmartArt 節點
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # 移除位置 1 的子節點
                    node.child_nodes.remove_node(1)

    # 儲存簡報
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定 SmartArt 子節點的自訂位置**
現在 Aspose.Slides for Python via .NET 支援設定 SmartArtShape 的 X 與 Y 屬性。以下程式碼片段示範如何自訂 SmartArtShape 的位置、大小與旋轉，另請注意，新增節點會重新計算所有節點的位置與大小。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 載入所需的簡報
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# 將 SmartArt 形狀移動到新位置
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# 更改 SmartArt 形狀的寬度
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# 更改 SmartArt 形狀的高度
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# 更改 SmartArt 形狀的旋轉
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **檢查助理節點**
以下範例程式碼將探討如何在 SmartArt 節點集合中識別助理節點並變更其屬性。

- 建立 PresentationEx 類別的實例，並載入含有 SmartArt 形狀的簡報。
- 使用索引取得第二張投影片的參照。
- 遍歷第一張投影片內的每個形狀。
- 檢查形狀是否為 SmartArt 類型，若是則將選取的形狀轉型為 SmartArtEx。
- 遍歷 SmartArt 形狀內的所有節點，並檢查它們是否為助理節點。
- 將助理節點的狀態變更為普通節點。
- 儲存簡報。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 建立簡報實例
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # 穿越第一張投影片內的每個形狀
    for shape in pres.slides[0].shapes:
        # 檢查形狀是否為 SmartArt 類型
        if type(shape) is art.SmartArt:
            # 穿越 SmartArt 形狀的所有節點
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # 檢查節點是否為助理節點
                if node.is_assistant:
                    # 將助理節點設為 false 並將其變為普通節點
                    node.is_assistant = False
    # 儲存簡報
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定 節點的填充格式**
Aspose.Slides for Python via .NET 讓您能新增自訂的 SmartArt 形狀並設定其填充格式。本文說明如何建立與存取 SmartArt 形狀，並使用 Aspose.Slides for Python via .NET 設定其填充格式。

- 建立 `Presentation` 類別的實例。
- 使用索引取得投影片的參照。
- 透過設定 LayoutType 新增 SmartArt 形狀。
- 為 SmartArt 形狀的節點設定 FillFormat。
- 將修改後的簡報寫入為 PPTX 檔案。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # 取得投影片
    slide = presentation.slides[0]

    # 新增 SmartArt 形狀與節點
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # 設定節點填充顏色
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # 儲存簡報
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **產生 SmartArt 子節點的縮圖**
開發人員可依照以下步驟產生 SmartArt 子節點的縮圖：

1. 實例化代表 PPTX 檔案的 `Presentation` 類別。
2. 新增 SmartArt。
3. 使用索引取得節點的參照。
4. 取得縮圖影像。
5. 將縮圖影像儲存為任意想要的圖像格式。

以下範例產生 SmartArt 子節點的縮圖

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# 建立表示 PPTX 檔案的 Presentation 類別實例 
with slides.Presentation() as presentation: 
    # 新增 SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # 使用索引取得節點的參照  
    node = smart.nodes[1]

    # 取得縮圖
    with node.shapes[0].get_image() as bmp:
        # 儲存縮圖
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **常見問題**

**是否支援 SmartArt 動畫？**

是。SmartArt 被視為一般形狀，您可以[套用標準動畫](/slides/zh-hant/python-net/shape-animation/)（進入、退出、強調、移動路徑）並調整時間。必要時也可以為 SmartArt 節點內的形狀添加動畫。

**如果不知道內部 ID，如何可靠地在投影片上定位特定的 SmartArt？**

可透過[替代文字](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/alternative_text/)進行設定與搜尋。為 SmartArt 設定唯一的 AltText，即可在程式中不依賴內部識別碼而找到它。

**將簡報轉換為 PDF 時，SmartArt 的外觀會被保留下來嗎？**

會。Aspose.Slides 在[PDF 匯出](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)過程中以高視覺忠實度呈現 SmartArt，保持其版面、顏色與效果。

**我可以擷取整個 SmartArt 的影像（用於預覽或報告）嗎？**

可以。您能將 SmartArt 形狀渲染為[點陣格式](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/get_image/)或[SVG](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/write_as_svg/)，以產生可縮放的向量輸出，適合用於縮圖、報告或網頁。