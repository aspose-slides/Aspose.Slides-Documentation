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
description: "了解如何使用 Aspose.Slides for Python via .NET 建立與格式化段落、文字段、項目符號、編號清單、縮排、HTML 內容以及段落影像。"
---
## **概觀**

Aspose.Slides for Python via .NET 以文字框、段落和文字段的層級結構表示文字：

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 代表形狀中的文字容器，並提供對其段落集合的存取。
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 代表文字框中的一個段落，並提供對其文字段及段落層級格式的存取。
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 代表段落內的文字執行。每個文字段可以有自己的文字與字元層級格式。

因此，一個段落可以透過使用多個文字段，包含字型、顏色、大小以及其他格式各異的文字。

## **建立與格式化段落**

在形狀的文字框中建立段落，並使用文字段格式化個別的文字執行。本節說明如何在每個段落中結合多個文字段，並套用不同的顏色、字型大小與樣式。

### **使用多個文字段建立段落**

下列 Python 範例建立三個段落，每個段落在其 [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/) 集合中包含三個文字執行。它重新使用預設的段落及其空白文字段，然後加入剩餘的段落與文字段。格式化透過 [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) 進行：每個段落的第一個文字段為紅色、粗體、15 點；第二個為藍色、斜體、18 點。第三個文字段保留預設格式：

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

將段落文字以符號、編號或自訂圖像組織成清單。本節的範例涵蓋項目符號格式、多層清單與自訂起始編號。

### **建立項目符號或編號清單**

項目符號與編號讓相關項目更易於掃描。在 Aspose.Slides 中，清單設定透過 [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) 定義。

此 Python 範例在同一文字框中加入符號項目符號與編號項目。 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) 用來選取項目符號類型，[BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) 提供符號，而 [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) 選擇編號樣式。兩個項目皆使用黑色項目符號，高度為 100%，段落縮排為 25 點：

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

圖片項目符號允許使用自訂圖像取代符號或數字。

此範例需要工作目錄中存在 `bullets.png`。此 Python 範例將圖像加入簡報的圖像集合，作為 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)，並將其用作段落項目符號。它將 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) 設為使用圖片項目符號，並透過 [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) 指派圖像。[BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) 設為 100% 以依段落文字相對調整項目符號大小：

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

### **建立多層清單**

將 [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) 設為不同值，以在清單中放置不同層級的段落。最高層的深度為 `0`。

此 Python 範例為四個段落分別指定 0 到 3 的 [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) 值，於同一文字框內建立層級結構。每個段落使用符號項目符號，[BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) 在圓形項目符號與連字號之間交替，以區分相鄰層級：

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

### **以自訂值開始編號清單項目**

使用 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 來設定編號段落的起始號碼。

此 Python 範例將 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) 設為編號，並為三個段落分別指定 2、3、7 的 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 值。起始值分別設定於每個段落，使顯示的編號可跳過數字：

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

## **控制段落版面配置與結束屬性**

調整段落的邊距與縮排，以控制首行與換行後行的定位。您亦可將段落結束標記的格式獨立於可見文字段進行設定。

### **設定首行縮排**

使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 屬性控制段落的首行縮排。此屬性僅移動首行相對於段落左邊界的距離。正值會將首行向右移動，剩餘行則保持與段落本體對齊。

當需要移動整個段落時，使用 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/)；當只需移動首行時，使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)。

以下範例將三個段落的 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 都設為 20 點，並分別將 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 設為 0、20、40 點。首行的起始位置逐漸向右偏移，而換行後的行保留相同左邊距：

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

懸掛縮排是指首行位於其餘行左側的段落版面配置。在 Aspose.Slides 中，可使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 屬性實現。將 `indent` 設為負值，即可使首行相對於段落本體向左移動。

實務上，[ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 定義段落本體的左側位置，而 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 定義首行相對於該左側邊距的位置。要產生懸掛縮排，請將 `margin_left` 設為正值，`indent` 設為負值。

此版面配置常用於參考書目、引用、詞彙表條目等需要讓換行後的行與段落本體對齊，而非與首行第一個字元對齊的情況。

以下 Python 範例將 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 設為 40 與 60 點，並分別將 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 設為 -20 與 -30 點。每個段落的首行皆位於換行後行的左側；第二個段落的懸掛縮排更深：

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

### **設定段落結束執行屬性**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) 屬性控制段落結束標記的格式。範例載入 `Test.pptx`（必須至少包含一張投影片），並建立一個 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) ，其 [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) 設為 48 點，且 [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) 設為 Times New Roman。將此格式指派給第二個段落的結束標記，保持可見文字段的格式不變：

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

## **計算已渲染的行數**

有關會影響自動換行與行尾標點的段落規則，請參閱 [Control Line Breaking](/slides/zh-hant/python-net/text-formatting/#control-line-breaking) 與 [Control Hanging Punctuation](/slides/zh-hant/python-net/text-formatting/#control-hanging-punctuation)。

使用 [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) 取得段落在文字佈局後所佔用的行數，包括自動換行。這在檢查投影片範本的文字長度與版面配置時相當有用。

段落是 [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) 中的單一項目，可能占用多行已渲染的文字。段落內的明確換行會強制產生新行而不會建立新段落。自動換行則根據可用寬度產生行，且不會在文字中插入明確的換行字元。因此，僅計算段落或換行字元並不能得到已渲染的行數。

以下範例建立一個文字形狀，計算其行數，然後縮小形狀，最後以較短的字串取代文字。範例同時啟用 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) 並停用 [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)，使形狀寬度控制換行，而不會自動縮小文字或調整形狀大小。每一次測量皆使用 [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/)。形狀尺寸以點 (pt) 為單位。最後，範例再新增一個段落，並將所有段落的行數總合。

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

在此文字與尺寸下，縮小形狀會增加行數，而以較短的字串取代文字則會減少行數。實際行數可能因字型可用性與替換、字型大小、邊距、縮排、換行與自動適應設定而異。檢查範本時，請使用目標環境所使用的字型與版面設定。

僅行數並不足以判斷文字是否超出容器。可用高度、行高、段落與行距以及自動適應行為同樣重要；即使是一行文字，若停用換行，亦可能超出可用寬度。

## **匯入與匯出段落內容**

使用 HTML 可將文字導入投影片，或將既有段落匯出供外部使用。本節亦說明如何將單一段落渲染為影像，包括表格儲存格內的段落。

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) 將 HTML 標記轉換為文字框中的段落與文字段。

此 Python 範例從工作目錄中的 `file.html` 讀取 HTML，並將其傳遞給 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/)。它會清除文字框的預設段落，使框內僅包含匯入的內容。矩形形狀在投影片四周保留 10 點的邊距：

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

使用 [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) 可將選取的段落範圍匯出為 HTML。當在網站上重用投影片文字時，您可能希望保留本地的強調效果，但不攜帶投影片的字型、大小或文字方塊樣式。可以設定 [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) 來控制匯出器追蹤格式繼承的深度。

下載 [範例投影片](text-inheritance.pptx) 並放置於應用程式的工作目錄。其第一張投影片包含一個文字形狀，文字為「Inherited text; explicit red 18pt」。輸入特意使用了多層格式：

- 投影片的預設文字樣式提供 Calibri 字型與 28 pt 大小。
- 文字框的第一層文字樣式提供藍色文字與斜體。
- 段落明確設定為粗體。
- 第二個文字段「explicit red 18pt」明確設定為紅色文字與 18 pt 大小。

以下完整範例將相同的段落匯出三次。它將 [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) 傳遞給匯出方法，並將每個結果寫入獨立的 UTF-8 HTML 檔案：

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

產生的 HTML 在第一段的 CSS 如下所示。表格列出相關宣告；為了清晰，其他產生的屬性已省略。

| 輸出 | 第一步段的相關 CSS | 外觀 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | 藍色、粗體、斜體文字，字型為 Calibri，大小 28 pt（若系統有此字型）。 |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 藍色、粗體、斜體文字；字型與大小由所在頁面或瀏覽器提供。 |
| `ParagraphOnly.html` | `font-weight:bold` | 粗體文字；字型、大小、顏色與斜體樣式由所在頁面或瀏覽器提供。 |

第二段在所有三個輸出中皆保留 `color:#ff0000`、`font-size:18pt` 與 `font-weight:bold`。在 `ALL` 與 `TEXT_BOX` 中亦保留斜體，但在 `PARAGRAPH_ONLY` 中則不保留。限制繼承因此不會移除明確指派給段落或文字段的格式。

在相同的瀏覽器中開啟這些檔案以進行比較。於兩個受限制的模式中，省略的 CSS 屬性將由目標頁面的樣式或瀏覽器預設值解決，最終外觀取決於 HTML 使用的環境。

### **將段落渲染為影像**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) 會直接渲染單一段落，並回傳一個 [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/)。可使用 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 將結果存檔或寫入串流。無需渲染所在形狀或自行裁切位圖。

如果段落在父集合中找不到、沒有有效的渲染邊界，或無法渲染，則 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) 會回傳 `None`。在保存之前請先檢查結果，使用後請釋放回傳的影像。

#### **以預設比例渲染段落**

範例使用 `sample.pptx`，該投影片有一張投影片，其第一個形狀為包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例於索引為 1 的第二段落呼叫 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)（未傳入比例參數），在確認形狀包含所需段落且渲染回傳影像後，使用 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 以 PNG 格式儲存。內容管理器在使用完畢後釋放影像資源。

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

使用接受 `scale_x` 與 `scale_y` 參數的 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) 重載，設定水平與垂直比例因子。下列範例建立表格，於第一個儲存格中將段落以兩倍寬度與高度渲染，並以 PNG 影像儲存。

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

比例因子為 `1` 時保持該軸的預設像素大小。例如，兩個因子皆為 `2` 時，產生的影像寬高約為預設尺寸的兩倍，像素數量約為四倍。較大的因子通常可在縮放或高解析度輸出時產生較銳利的文字，但同時會增加記憶體使用與檔案大小。小於 `1` 的因子會產生較小且細節較少的影像。使用相等的因子可保留段落的長寬比例；若水平與垂直因子不同，輸出會分別被拉伸。

當輸出必須包含形狀的填色、邊框或其他視覺上下文時，使用 [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) 渲染整個形狀仍然有用。若僅需段落影像，請使用 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)。

## **常見問題**

**是否可以完全停用文字框內的自動換行？**

可以。將 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) 設為停用，即可避免行在文字框邊緣自動斷行。

**如何取得特定段落在投影片上的精確邊界？**

使用 [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) 可取得段落的外接矩形。[Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) 則提供個別文字段的邊界。

**段落的對齊方式（左、右、置中或兩端對齊）在何處設定？**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 為段落層級設定，會套用於整個段落，與個別文字段的格式無關。

若想在每行中垂直對齊不同字型大小的文字段，請參閱 [Align Fonts Within a Line](/slides/zh-hant/python-net/text-formatting/#align-fonts-within-a-line)。

**是否可以為段落的部分文字設定校對語言？**

可以。將 [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) 設定於個別文字段，即可在同一段落中使用多種語言的校對功能。