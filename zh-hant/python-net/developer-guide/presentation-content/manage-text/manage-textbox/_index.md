---
title: 使用 Python 管理簡報中的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/python-net/manage-textbox/
keywords:
- 文字方塊
- 文字框架
- 新增文字
- 更新文字
- 建立文字方塊
- 檢查文字方塊
- 新增文字欄位
- 新增超連結
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "Aspose.Slides for Python 透過 .NET，讓您輕鬆在 PowerPoint 與 OpenDocument 檔案中建立、編輯和複製文字方塊，提升簡報自動化效能。"
---
## **簡介**

投影片上的文字通常位於文字方塊或圖形中。因此，要在投影片上加入文字，必須先新增文字方塊，然後在方塊內放入文字。Aspose.Slides for Python 提供了 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 類別，讓您可以新增包含文字的圖形。

{{% alert title="Info" color="info" %}}

Aspose.Slides 也提供了 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 類別。然而，並非所有圖形都能容納文字。

{{% /alert %}}

{{% alert title="Note" color="warning" %}}

因此，當處理想要加入文字的圖形時，您可能需要檢查並確認它是透過 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 類別轉型的。只有這樣才可以使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)，它是屬於 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 的屬性。請參閱本頁面的 [更新文字](/slides/zh-hant/python-net/manage-textbox/#update-text) 章節。

{{% /alert %}}

## **在投影片上建立文字方塊**

建立投影片文字方塊的步驟：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 取得第一張投影片的參考。  
3. 在投影片的適當位置加入一個 `ShapeType.RECTANGLE` 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。  
4. 設定圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 內的文字。  
5. 將簡報儲存為 PPTX 檔案。

以下 Python 範例實作了上述步驟：

```py
import aspose.slides as slides

# 實例化 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得簡報中的第一張投影片。
    slide = presentation.slides[0]

    # 新增類型為 RECTANGLE 的 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # 將簡報儲存至磁碟。
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **檢查圖形是否為文字方塊**

Aspose.Slides 在 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 類別上提供了 [is_text_box](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/is_text_box/) 屬性，讓您判斷圖形是否為文字方塊。

![文字方塊和圖形](istextbox.png)

此 Python 範例示範如何檢查圖形是否已建立為文字方塊：

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

請注意，如果使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 類別新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)，其 `is_text_box` 屬性會回傳 `False`。但在您加入文字（使用 `add_text_frame` 方法或設定 `text` 屬性）之後，`is_text_box` 會回傳 `True`。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box 為 false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box 為 true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box 為 false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box 為 true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box 為 false
    shape3.add_text_frame("")
    # shape3.is_text_box 為 false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box 為 false
    shape4.text_frame.text = ""
    # shape4.is_text_box 為 false
```

## **尋找擁有 TextFrame 的圖形**

在一般的文字處理程式碼中，您可能會取得一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)，卻還不知道是哪一個簡報物件包含它。使用 [TextFrame.parent_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/parent_shape/) 屬性即可回溯至擁有該文字方塊的 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/)。

對於屬於 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 或其他含文字圖形的文字方塊，`TextFrame.parent_shape` 會被設定，而 `TextFrame.parent_cell` 為 `None`。這兩個屬性都是唯讀的導覽屬性，讀取它們不會改變所有權。存取圖形之前，務必先檢查返回值是否為 `None`。

完整範例（包括辨識圖形與表格儲存格所有者，以及與 SmartArt 節點相關的圖形）請參考 [搜尋與取代文字](/slides/zh-hant/python-net/search-and-replace-text/)。

## **為文字方塊新增欄位**

Aspose.Slides 在 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 類別上提供了 [column_count](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/column_count/) 與 [column_spacing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/column_spacing/) 屬性，以在文字方塊中加入欄位。您可以指定欄位數量並設定欄位之間的間距（單位為點）。

以下 Python 程式碼示範此操作：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# 取得簡報中的第一張投影片。
	slide = presentation.slides[0]

	# 新增類型為 RECTANGLE 的 AutoShape。
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# 為矩形新增 TextFrame。
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# 取得 TextFrame 的文字格式。
	format = shape.text_frame.text_frame_format

	# 指定 TextFrame 中的欄位數量。
	format.column_count = 3

	# 指定欄位之間的間距。
	format.column_spacing = 10

	# 儲存簡報。
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **更新文字**

Aspose.Slides 允許您更新單一文字方塊或整個簡報中的文字。

以下 Python 範例示範如何更新簡報內的所有文字：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # 儲存已修改的簡報。
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **新增包含超連結的文字方塊**

您可以在文字方塊中插入連結。點擊文字方塊時，會開啟該連結。

若要新增包含超連結的文字方塊，請依照下列步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 取得第一張投影片的參考。  
3. 在投影片的適當位置加入一個 `ShapeType.RECTANGLE` 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。  
4. 設定圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 內的文字。  
5. 取得 [HyperlinkManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkmanager/) 的參考。  
6. 使用 `hyperlink_manager` 屬性設定外部點擊超連結。  
7. 將簡報儲存為 PPTX 檔案。

此 Python 範例示範如何在投影片上加入帶有超連結的文字方塊：

```py
import aspose.slides as slides

# 實例化 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得簡報中的第一張投影片。
    slide = presentation.slides[0]

    # 新增類型為 RECTANGLE 的 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # 為框架新增文字。
    text_portion.text = "Aspose.Slides"

    # 設定文字區段的超連結。
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**在使用母片時，文字方塊與文字佔位符有何不同？**

[placeholder](/slides/zh-hant/python-net/manage-placeholder/) 會從 [master](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslide/) 繼承樣式/位置，且可以在 [layout](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/) 上覆寫；相較之下，普通的文字方塊是特定投影片上的獨立物件，切換版面配置時不會變動。

**如何在簡報中大量取代文字，同時避免影響圖表、表格與 SmartArt 內的文字？**

將迭代限制為具有文字方塊的自動圖形，並排除嵌入物件（如 [charts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/)），可透過分別遍歷其集合或跳過這些物件類型來實現。