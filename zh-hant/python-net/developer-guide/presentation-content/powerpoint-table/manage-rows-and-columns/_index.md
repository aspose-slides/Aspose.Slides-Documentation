---
title: 使用 Python 管理 PowerPoint 表格的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/python-net/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 首列
- 表格標題列
- 複製列
- 複製欄
- 複製列
- 複製欄
- 移除列
- 移除欄
- 列文字格式設定
- 欄文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 中管理表格列與欄，並加速簡報編輯與資料更新。"
---
## **簡介**

Aspose.Slides for Python via .NET 讓您可以透過 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 類別管理 PowerPoint 簡報中的表格結構與格式設定。您可以指定標題列、複製或刪除列與欄，並對整列或整欄套用文字格式。

本文說明這些操作並提供 Python 範例。它也示範如何取得表格的樣式預設，以便重複使用。表格列與欄的索引是從零開始的。

## **控制列高度**

使用 [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) 以設定列的最小高度（點數）。這是下限，而非固定高度。[Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) 會回傳實際高度，且為唯讀。透過 [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/) 取得列。

The example loads [row-height-input.pptx](row-height-input.pptx)，此檔案的第一張投影片的第一個圖形是一個表格。其第一列的起始高度為 70 點。儲存格使用 18 點 Arial 文字、換行，且上下邊距為 6 點；第二欄較長的文字會換成多行。範例將最小高度提升至 100 點，然後降低至 20 點，於每次變更後列印實際高度，並儲存兩個結果。

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

使用提供的簡報時，提升最小值會為列增加空間。降低最小值會移除額外的空間，但實際高度仍大於 20 點，因為文字與儲存格邊距需要更大的空間。僅減少最小值無法將列的高度壓低於內容所需的空間。

實際高度受多項因素影響：

- **文字與字型大小：** 較長的文字、明確的換行或較大的字型都可能需要更多垂直空間。
- **換行與欄寬度：** 啟用換行時，較窄的 [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) 會產生更多行。較寬的欄位可減少垂直需求的空間。
- **儲存格邊距：** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) 與 [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) 會增加垂直空間。[Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) 與 [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) 會減少文字可用寬度，可能導致額外換行。

對於此未合併儲存格的表格，需求最高垂直空間的儲存格決定整列的內容驅動下限。若要縮短列高，您可能需要縮短文字、減少字型大小或邊距，或是加寬欄位。

下方的圖像顯示相同表格在相同比例下的樣子。在此執行中，實際高度分別為 70、100 與 55.2 點：最後一列仍高於其 20 點的最小值。文字的實際測量會因環境中可用的字型而異。下載保存的結果：[增加最小值](row-height-increased.pptx) 與 [降低最小值](row-height-decreased.pptx)。

| 原始：最小 70 點，實際 70 點 | 增加：最小 100 點，實際 100 點 | 降低：最小 20 點，實際 55.2 點 |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **將第一列設為標題列**

使用 [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) 屬性將第一列標記為標題格式。其外觀取決於套用於表格的表格樣式。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 取得投影片上第一個圖形所存放的表格。
4. 為其第一列啟用標題格式。
5. 儲存已修改的簡報。

此範例需要 `table.pptx`，其中第一張投影片的第一個圖形是一個表格。它為第一列啟用標題格式，並儲存為 `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **複製表格列或欄**

複製列或欄以重複使用其內容與格式。您可以將副本新增至表格的末端，或插入至特定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 方法新增表格。
5. 複製所需的列。
6. 複製所需的欄。
7. 儲存已修改的簡報。

此範例需要 `Test.pptx`，且至少包含一張投影片。它建立一個三欄五列的表格，尺寸以點數指定。它將第一列與第一欄的副本追加至表格末端，然後在索引 3（第四個位置）插入第二列與第二欄的副本。最終表格有七列五欄。`False` 參數會停用對相鄰合併列或欄的複製；此表格沒有合併儲存格。

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **從表格中移除列或欄**

移除表格中不再需要的列或欄。移除後，後續列或欄的索引會向前移動。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別建立簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 方法新增表格。
5. 移除第二列與第二欄。
6. 儲存已修改的簡報。

此範例建立一個 3×3 的表格，並移除索引為 1 的列與欄，留下 2×2 的表格，儲存為 `TestTable_out.pptx`。尺寸以點數表示。`False` 參數會停用對相鄰合併列或欄的移除；此表格沒有合併儲存格。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格列層級設定文字格式**

對整列套用文字格式，以保持儲存格的一致性。您可以設定字型屬性、段落格式與文字方向，而無需個別設定每個儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 為第一列設定 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/)。
4. 為第一列設定 [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 與 [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)。
5. 為第二列設定 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)。
6. 儲存已修改的簡報。

此範例需要 `table.pptx`，其第一張投影片的第一個圖形是一個表格且至少有兩列。它對第一列套用 25 點文字、右對齊以及 20 點的右側段落邊距，然後在第二列設定垂直文字。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格欄層級設定文字格式**

對整欄套用文字格式，以保持儲存格的一致性。您可以設定字型屬性、段落格式與文字方向，而無需個別設定每個儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 為第一欄設定 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/)。
4. 為第一欄設定 [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 與 [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)。
5. 為第二欄設定 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)。
6. 儲存已修改的簡報。

此範例需要 `table.pptx`，其第一張投影片的第一個圖形是一個表格且至少有兩欄。它對第一欄套用 25 點文字、右對齊以及 20 點的右側段落邊距，然後在第二欄設定垂直文字。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **取得表格樣式屬性**

使用 [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) 屬性取得套用於表格的樣式預設，並可在其他表格上重新使用。此屬性會辨識樣式預設，而不是個別儲存格的格式覆寫。

此範例建立表格，套用 [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/)，並讀回該預設。當讀取的預設與套用的預設相符時會印出 `True`，並將表格儲存為 `table.pptx`。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**我可以將 PowerPoint 主題/樣式套用到已建立的表格嗎？**

可以。表格會繼承投影片/版面/母版的主題，且您仍可在此主題之上自行覆寫填色、框線與文字顏色。

**我可以像在 Excel 中那樣對表格列進行排序嗎？**

不能，Aspose.Slides 的表格沒有內建的排序或篩選功能。請先在記憶體中排序資料，然後依該順序重新填入表格列。

**我可以在保留特定儲存格自訂顏色的同時，使用條紋欄位嗎？**

可以。開啟條紋欄位後，對特定儲存格套用局部格式；儲存格層級的格式會優先於表格樣式。