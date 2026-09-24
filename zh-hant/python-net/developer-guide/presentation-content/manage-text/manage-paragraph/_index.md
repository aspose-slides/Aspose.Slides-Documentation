---
title: 在 Python 中管理 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
  - 新增文字
  - 新增段落
  - 管理文字
  - 管理段落
  - 管理項目符號
  - 段落縮排
  - 懸掛縮排
  - 段落項目符號
  - 編號清單
  - 項目符號清單
  - 段落屬性
  - 匯入 HTML
  - 文字轉 HTML
  - 段落轉 HTML
  - 段落轉影像
  - 文字轉影像
  - 匯出段落
  - PowerPoint
  - 簡報
  - Python
  - Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 建立與格式化段落、Portion、項目符號、編號清單、縮排、HTML 內容以及段落影像。"
---
## **概述**

Aspose.Slides for Python via .NET 將文字表示為文字框、段落與 Portion 的層次結構：

* [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 表示形狀中的文字容器，並提供對其段落集合的存取。
* [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 代表文字框中的一個段落，並提供對其 Portion 以及段落級格式的存取。
* [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 代表段落內的文字執行。每個 Portion 可以有自己的文字與字元級格式。

因此，一個段落可以透過多個 Portion 包含具有不同字型、顏色、大小與其他格式的文字。

## **建立與格式化段落**

### **建立具有多個 Portion 的段落**

以下步驟會建立一個文字框，內含三個段落，每個段落包含三個 Portion：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得目標投影片。
3. 向投影片新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
5. 使用預設段落，並向文字框再新增兩個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 物件。
6. 為每個段落新增足夠的 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 物件，使其包含三個 Portion。預設段落已包含一個空的 Portion。
7. 設定每個 Portion 的文字。
8. 透過 [Portion.portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/portion_format/) 套用字元級格式。
9. 儲存已修改的簡報。

此 Python 範例實作上述步驟：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **建立項目符號與編號清單**

### **建立項目符號或編號清單**

項目符號與編號可讓相關項目更易於掃描。於 Aspose.Slides 中，清單設定是透過 [BulletFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/) 定義的。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得目標投影片。
3. 向所選投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
5. 從文字框中移除預設段落。
6. 為符號項目建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/)。
7. 將 [BulletFormat.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/type/) 設為 [BulletType.SYMBOL](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bullettype/) 並指定項目符號字元。
8. 設定段落文字、縮排、項目符號顏色與項目高度。
9. 將段落加入文字框。
10. 建立第二個段落，將 [BulletFormat.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/type/) 設為 [BulletType.NUMBERED](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bullettype/)。
11. 設定編號項目樣式，並將段落加入文字框。
12. 儲存簡報。

此 Python 範例建立符號項目與編號項目：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **使用圖片項目符號**

圖片項目符號允許使用自訂圖像取代符號或編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得目標投影片。
3. 新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 並取得其 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
4. 從文字框中移除預設段落。
5. 載入項目圖片，並以 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 加入簡報的圖像集合。
6. 建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 並設定其文字。
7. 將 [BulletFormat.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/type/) 設為 [BulletType.PICTURE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bullettype/)。
8. 透過 [BulletFormat.picture](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/picture/) 指派圖像，並設定項目高度。
9. 將段落加入文字框。
10. 儲存已修改的簡報。

此 Python 範例建立圖片項目符號：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **建立多層級清單**

將 [ParagraphFormat.depth](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/depth/) 設為不同值，可在清單中放置不同層級的段落。最高層級的深度為 `0`。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 並取得投影片。
2. 新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 並清除其文字框中的預設段落。
3. 建立四個段落，並設定各自的項目符號。
4. 將它們的 [ParagraphFormat.depth](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/depth/) 分別設定為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框，然後儲存簡報。

此 Python 範例建立四層級的項目清單：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **自訂編號清單的起始值**

使用 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 可設定編號段落的起始號碼。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 並向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
2. 清除形狀文字框中的預設段落。
3. 建立三個編號段落。
4. 分別將 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 設為 `2`、`3`、`7`。
5. 將段落加入文字框，並儲存簡報。

此 Python 範例為每個段落指定自訂起始編號：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **控制段落版面與結尾屬性**

### **設定首行縮排**

使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 屬性可控制段落的首行縮排。此屬性只會相對於段落左邊界移動第一行。正值會將第一行向右移動，其他行保持與段落正文對齊。

若需移動整段文字，請使用 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/)。若只要移動第一行，請使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/)。

以下範例建立多個段落，並套用不同的 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 值，以示範首行縮排如何影響段落版面。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 向投影片新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 並移除預設段落。
5. 建立多個段落，為它們設定不同的 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

此程式碼示範如何設定段落縮排：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落的首行縮排](first_line_indent.png)

### **設定懸掛縮排**

懸掛縮排是一種段落版面配置，第一行位於其餘行的左側。於 Aspose.Slides 中，可透過 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 屬性實作。將 `indent` 設為負值，即可使第一行相對於段落正文向左移動。

實務上，`[ParagraphFormat.margin_left]` 定義段落正文的左側位置，而 `indent` 定義第一行相對於該左側的位移。若要產生懸掛縮排，請將正的 `margin_left` 與負的 `indent` 同時設定。

此格式常用於書目、參考文獻、詞彙表等，需要讓換行後的文字對齊於段落正文而非第一行的首字元。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 向投影片新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 並移除預設段落。
5. 為每個段落設定正的 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/)。
6. 設定負的 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

此程式碼示範如何為段落設定懸掛縮排：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落的懸掛縮排](hanging_indent.png)

### **設定段落結尾執行屬性**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) 屬性控制段落結尾標記的格式。以下範例為第二個段落的結尾標記指定字型大小與西文字型：

1. 載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 並取得投影片。
2. 新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)，並清除其預設段落。
3. 建立兩個段落，並為它們加入文字 Portion。
4. 為第二個段落的結尾標記建立 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/)。
5. 設定 [PortionFormat.font_height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/font_height/) 與 [PortionFormat.latin_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/latin_font/)。
6. 將此格式指派給 [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/end_paragraph_portion_format/)，並儲存簡報。

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **計算已呈現的行數**

使用 [Paragraph.get_lines_count](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/get_lines_count/) 可取得段落在文字佈局後實際佔用的行數（含自動換行）。此功能在檢查簡報樣板中文本長度與版面配置時非常有用。

段落是 [TextFrame.paragraphs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/paragraphs/) 中的一個項目，可能會佔用多行已呈現的文字。段落內的明確換行會強制產生新行，但不會產生新段落。自動換行則根據可用寬度產生行，而不會在文字中插入明確的換行字元。因此，僅計算段落或換行字元無法得到已呈現的行數。

以下範例建立一個文字形狀，計算其行數，縮小形狀，然後以較短的字串取代文字。示例開啟換行、停用自動調整大小，使形狀寬度控制換行，而不會自動縮小文字或調整形狀尺寸。形狀尺寸以點為單位。最後，範例再加入另一個段落，並將整個文字框的行數相加。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

透過此文字與尺寸組合，縮小形狀會增加行數，而以較短字串取代則會減少行數。實際行數會因字型可用性與替代、字型大小、邊距、縮排、換行與自動調整設定而異；請在檢查樣板時使用目標環境的字型與版面設定。

僅靠行數並無法判斷文字是否溢出容器。可用的高度、行高、段落與行間距以及自動調整行為同樣重要；即使只有單行文字，若關閉換行，也可能超出可用寬度。

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphcollection/add_from_html/) 可將 HTML 標記轉換為文字框中的段落與 Portion。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 取得投影片並新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
3. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳遞給 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphcollection/add_from_html/)。
6. 儲存已修改的簡報。

此 Python 範例將 HTML 匯入文字框：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **將段落文字匯出為 HTML**

使用 [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphcollection/export_to_html/) 可將選定範圍的段落匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例並載入目標簡報。
2. 取得投影片，找出包含文字的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
3. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
4. 呼叫 [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphcollection/export_to_html/) 並傳入起始段落索引與要匯出的段落數量。
5. 將回傳的 HTML 字串寫入檔案。

此 Python 範例匯出第一個文字形狀中的所有段落：

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **將段落渲染為影像**

[Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 提供 `get_image` 方法，可直接將單一段落渲染為影像。此方法回傳一個 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/)，您可以使用 [IImage.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/save/) 將其儲存為檔案或串流。您無需渲染整個形狀或手動裁切位圖。

如果段落在其父集合中找不到、沒有有效的呈現邊界，或無法渲染，`get_image` 會回傳 `None`。在儲存之前請先檢查結果，並以 context manager 方式使用回傳的影像，以釋放其資源。

#### **以預設比例渲染段落**

假設我們有一個名為 sample.pptx 的簡報檔，內含一張投影片，第一個形狀是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例於預設比例下，將第二個段落在普通文字形狀中渲染，並以 PNG 格式儲存回傳的影像：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

結果：

![段落影像](paragraph_to_image_output.png)

#### **在表格儲存格中以比例渲染段落**

將水平與垂直比例因子傳遞給 `get_image`，即可控制渲染段落的大小。以下範例建立一個表格，於第一個儲存格中以兩倍寬高渲染段落，並以 PNG 影像儲存結果：

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

比例因子 `1` 代表該軸保持預設像素大小。例如，同時使用 `2` 會產生寬度與高度約為預設兩倍的影像，像素數量約為四倍。較大的因子通常能提供更銳利的文字，適合放大或高解析度輸出，但也會增加記憶體使用與檔案大小。低於 `1` 的因子則會產生較小且細節較少的影像。使用相同的水平與垂直因子可保持段落的長寬比；若使用不同的因子，則會分別拉伸水平或垂直方向。

在需要包含形狀填色、邊框或其他視覺語境時，仍可使用 [Shape.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/)。若僅需段落影像，請使用 `Paragraph.get_image`。

## **常見問題**

**能否完全停用文字框內的換行功能？**

可以。將 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/wrap_text/) 設為關閉，即可停用換行，讓行不會在文字框邊緣斷開。

**如何取得特定段落在投影片上的實際邊界？**

使用 [Paragraph.get_rect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/get_rect/) 取得段落的外接矩形。[Portion.get_rect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/get_rect/) 可取得單一 Portion 的邊界。

**段落對齊方式（左、右、置中或兩端對齊）在哪裡設定？**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/alignment/) 為段落層級設定，會套用於整個段落，與個別 Portion 的格式無關。

**能否為段落的部分文字設定校對語言？**

可以。將 [PortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/language_id/) 設定於個別 Portion，即可在同一段落中包含多種語言的文字。