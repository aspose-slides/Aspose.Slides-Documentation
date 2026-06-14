---
title: 使用 Python 管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/python-net/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格中的影像
- 背景顏色
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Python（.NET）在 PowerPoint 與 OpenDocument 中管理表格儲存格。快速掌握存取、修改與樣式設定，實現無縫投影片自動化。"
---
## **概觀**

Aspose.Slides 讓您能在 PowerPoint 簡報中存取和修改表格儲存格。本文說明如何辨識合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色，以及在表格儲存格中插入影像。範例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

## **辨識合併的表格儲存格**

表格常會為標題或將相關資料分組而使用合併儲存格。在本節中，您將了解如何判斷特定儲存格是否屬於合併區域，以及如何引用主儲存格（左上角），以便一致地讀取或格式化整個區塊。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從第一張投影片取得表格。
1. 遍歷表格的列與欄以找出合併的儲存格。
1. 當找到合併的儲存格時印出訊息。

以下 Python 程式碼示範如何在簡報中辨識合併的表格儲存格：

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # 假設第一張投影片上的第一個形狀是一個表格。
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **移除表格儲存格邊框**

有時表格邊框會分散內容注意力或造成視覺雜亂。本節說明如何從選取的儲存格或儲存格的特定邊移除邊框，以達到更整潔的版面配置，並與投影片設計更契合。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片。
1. 定義欄寬陣列。
1. 定義列高陣列。
1. 使用 [add_table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_table/) 方法將表格加入投影片。
1. 遍歷每個儲存格以清除上、下、左、右邊框。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範如何移除表格儲存格的邊框：

```python
import aspose.slides as slides

# 實例化代表 PPTX 檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 定義欄寬與列高。
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 向投影片加入表格形狀。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 清除每個儲存格的邊框填充。
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **合併儲存格的編號**

如果您合併兩對儲存格，例如 (1, 1) ⨉ (2, 1) 與 (1, 2) ⨉ (2, 2)，合併後的表格仍會保留與未合併時相同的儲存格編號。以下 Python 程式碼示範此行為：

```python
import aspose.slides as slides

# 實例化代表 PPTX 檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 定義欄寬與列高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 向投影片加入表格形狀。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 合併儲存格 (1,1) 與 (2,1)。
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # 合併儲存格 (1, 2) 與 (2, 2)。
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # 列印儲存格索引。
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

輸出：

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **拆分儲存格的編號**

在前一個範例中，當表格儲存格被合併時，其他儲存格的編號並未變更。這次，我們建立一個普通表格（未合併儲存格），然後拆分儲存格 (1, 1) 以產生特殊的表格。請留意此表格的編號——它可能看起來不尋常。然而，這正是 Microsoft PowerPoint 為表格儲存格編號的方式，Aspose.Slides 亦遵循相同行為。

以下 Python 程式碼示範此行為：

```python
import aspose.slides as slides

# 實例化代表 PPTX 檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 定義欄寬與列高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 向投影片加入表格形狀。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 分割儲存格 (1, 1)。
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # 列印儲存格索引。
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

輸出：

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **變更表格儲存格背景色**

以下 Python 範例示範如何變更表格儲存格的背景色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # 建立新表格。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 設定儲存格的背景色。
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格儲存格中插入影像**

本節說明如何在 Aspose.Slides 的表格儲存格中插入影像。它包含將圖片填充套用至目標儲存格，並設定顯示選項（如拉伸或平鋪）。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 定義欄寬陣列。
1. 定義列高陣列。
1. 使用 [add_table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_table/) 方法將表格加入投影片。
1. 從檔案載入影像。
1. 將影像加入簡報的 images，以取得 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)。
1. 將表格儲存格的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `PICTURE`。
1. 將影像套用至表格儲存格，並選擇填充模式（例如 `STRETCH`）。
1. 將簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範在建立表格時，如何將影像放入表格儲存格內：

```python
import aspose.slides as slides

# 實例化 Presentation 物件。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 定義欄寬與列高。
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # 向投影片加入表格形狀。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 載入影像並將其加入簡報以取得 PPImage。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 將影像套用到第一個表格儲存格。
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # 將簡報儲存至磁碟。
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細和樣式嗎？**

可以。[top](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cellformat/border_right/) 邊框各自擁有獨立的屬性，因而每一側的粗細與樣式皆可不同。此行為與本文中示範的每側邊框控制相符。

**如果在將圖片設定為儲存格背景後，變更欄/列的大小，影像會發生什麼情況？**

行為取決於 [fill mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillmode/)（stretch/tiling）。若採用拉伸，影像會依新儲存格調整；若採用平鋪，則會重新計算圖塊。本文已說明儲存格中影像的顯示模式。

**我可以將超連結指派給儲存格的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/python-net/manage-hyperlinks/) 會在儲存格文字框內的文字（段落）層級或整個表格/形狀層級設定。實務上，您可以將連結指派給段落或儲存格內的全部文字。

**我可以在單一儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/)（文字區塊），可針對字型、樣式、大小與顏色獨立設定。