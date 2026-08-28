---
title: 管理 Python 中的 PowerPoint 文字段落
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
description: "學習如何使用 Aspose.Slides for Python via .NET 建立與格式化段落、區段、項目符號、編號清單、縮排、HTML 內容以及段落影像。"
---
## **概觀**

Aspose.Slides for Python via .NET 將文字表示為文字框、段落和區段的層級結構：

* [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 代表形狀中的文字容器，並提供對其段落集合的存取。
* [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 代表文字框中的一個段落，並提供對其區段和段落層級格式的存取。
* [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 代表段落中的文字執行區段。每個區段可以擁有自己的文字和字元層級格式。

因此，一個段落可以透過使用多個區段來包含具有不同字型、顏色、大小及其他格式設定的文字。

## **建立與格式化段落**

### **使用多個區段建立段落**

以下步驟會建立一個文字框，內含三個段落，每個段落包含三個區段：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關的投影片。
3. 在投影片上新增一個矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 存取該圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
5. 使用預設段落，並向文字框新增另外兩個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 物件。
6. 為每個段落新增足夠的 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 物件，使其包含三個區段。預設段落已包含一個空的區段。
7. 設定每個區段的文字。
8. 透過 [Portion.portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/portion_format/) 套用字元層級的格式設定。
9. 儲存已修改的簡報。

以下 Python 範例實作上述步驟：

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

項目符號與編號可讓相關項目更易於掃描。在 Aspose.Slides 中，清單設定是透過 [BulletFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/) 來定義的。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關的投影片。
3. 在選取的投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 存取圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
5. 從文字框移除預設段落。
6. 為符號項目符號建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/)。
7. 將 [BulletFormat.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/type/) 設為 [BulletType.SYMBOL](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bullettype/) ，並指定項目符號字元。
8. 設定段落文字、縮排、項目符號顏色與項目符號高度。
9. 將段落加入文字框。
10. 建立第二個段落，並將 [BulletFormat.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/type/) 設為 [BulletType.NUMBERED](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bullettype/)。
11. 配置編號項目符號樣式，並將段落加入文字框。
12. 儲存簡報。

以下 Python 範例會建立符號項目符號與編號項目符號：

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

使用圖片項目符號可讓您以自訂影像取代符號或編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關的投影片。
3. 新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 並存取其 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
4. 從文字框移除預設段落。
5. 載入項目符號圖片，並將其以 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 新增至簡報的圖像集合中。
6. 建立 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 並設定其文字。
7. 將 [BulletFormat.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/type/) 設為 [BulletType.PICTURE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bullettype/)。
8. 透過 [BulletFormat.picture](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/picture/) 指定圖片，並設定項目符號高度。
9. 將段落加入文字框。
10. 儲存已修改的簡報。

以下 Python 範例會建立圖片項目符號：

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

將 [ParagraphFormat.depth](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/depth/) 設定為可將段落置於清單的不同層級。最高層級的深度為 `0`。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 並存取投影片。
2. 新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) ，並清除其文字框的預設段落。
3. 建立四個段落並設定其項目符號。
4. 將它們的 [ParagraphFormat.depth](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/depth/) 值分別設為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框，並儲存簡報。

以下 Python 範例會建立四層級的項目符號清單：

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

### **自訂編號清單起始值**

使用 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 來設定編號段落的起始顯示數字。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 並在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
2. 清除圖形文字框的預設段落。
3. 建立三個編號段落。
4. 將 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 分別設為 `2`、`3`、`7`。
5. 將段落加入文字框，並儲存簡報。

以下 Python 範例為每個段落指定自訂起始編號：

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

## **控制段落版面配置與結尾屬性**

### **設定首行縮排**

使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 屬性可控制段落的首行縮排。此屬性僅會相對於段落左邊界移動第一行。正值會將第一行向右平移，其他行仍與段落本體對齊。

若需要整段移動，請使用 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/)。若只想移動第一行，請使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/)。

以下範例建立多個段落，並套用不同的 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 值，以示範首行縮排如何影響段落版面：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上新增一個矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 存取圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 並移除預設段落。
5. 建立多個段落，為其設定不同的 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

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

懸掛縮排是指第一行位於其餘行左側的段落版面配置。在 Aspose.Slides 中，您可以使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 屬性來實作此效果。將 `indent` 設為負值，即可相對於段落本體把第一行向左移動。

實務上，[ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/) 定義段落本體的左側位置，而 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 定義第一行相對於該左側的位移。若要產生懸掛縮排，請將正的 `margin_left` 與負的 `indent` 同時設定。

此格式常用於書目、參考文獻、詞彙表條目，以及其他需要讓換行行對齊於段落本體而非第一行第一個字元的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上新增一個矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 存取圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 並移除預設段落。
5. 為每個段落建立並設定正的 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/) 值。
6. 設定負的 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 值以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

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

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) 屬性控制段落結尾標記的格式。以下範例為第二個段落的結尾標記指定字型大小與拉丁字型：

1. 載入 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 並存取投影片。
2. 新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 並清除其預設段落。
3. 建立兩個段落，並為它們加入文字區段。
4. 為第二個段落的結尾標記建立一個 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/)。
5. 設定 [PortionFormat.font_height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/font_height/) 與 [PortionFormat.latin_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/latin_font/)。
6. 將格式指派給 [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/end_paragraph_portion_format/)，然後儲存簡報。

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

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphcollection/add_from_html/) 可將 HTML 標記轉換為文字框中的段落與區段。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 存取投影片並新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
3. 存取圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳遞給 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphcollection/add_from_html/)。
6. 儲存已修改的簡報。

以下 Python 範例將 HTML 匯入文字框：

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

使用 [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphcollection/export_to_html/) 可將選取的段落範圍匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例，並載入目標簡報。
2. 存取投影片，並找出包含文字的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
3. 存取圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
4. 呼叫 [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphcollection/export_to_html/) ，傳入起始段落索引與要匯出的段落數量。
5. 將回傳的 HTML 字串寫入檔案。

以下 Python 範例會匯出第一個文字圖形的所有段落：

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

[Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 提供 `get_image` 方法，可直接渲染單一段落。此方法會回傳一個 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 物件，您可以使用 [IImage.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/save/) 將其儲存至檔案或串流。您不必先渲染整個圖形或手動裁切位圖。

如果段落在父集合中找不到、沒有有效的渲染邊界，或無法渲染，`get_image` 會回傳 `None`。請在儲存前檢查結果，並以 context manager 的方式使用回傳的影像，以釋放資源。

#### **以預設比例渲染段落**

假設我們有一個名為 sample.pptx 的簡報檔案，內含一張投影片，第一個圖形是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例在預設比例下，將第二個段落渲染為 PNG 影像並儲存：

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

#### **在表格儲存格中渲染段落並縮放**

將水平與垂直縮放因子傳入 `get_image`，即可控制渲染段落的大小。以下範例建立一個表格，將其第一個儲存格內的段落以寬高各兩倍的比例渲染，並儲存為 PNG 影像：

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

`1` 的縮放因子會保留該軸的預設像素大小。例如，同時使用 `2` 會產生寬度與高度約為預設的兩倍的影像，像素數量約為四倍。較大的因子通常可產生較銳利的文字，適合放大或高解析度輸出，但也會增加記憶體使用量與檔案大小。小於 `1` 的因子會產生較小且細節較少的影像。使用相同的因子可維持段落的長寬比例；不同的水平與垂直因子會分別拉伸輸出。

在需要包含圖形填色、邊框或其他視覺上下文時，仍可使用 [Shape.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/) 來渲染整個圖形。若僅需段落影像，請使用 `Paragraph.get_image`。

## **常見問題**

**我能完全停用文字框內的換行嗎？**

可以。將 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/wrap_text/) 設為停用，即可防止文字在文字框邊緣換行。

**如何取得特定段落在投影片上的精確邊界？**

使用 [Paragraph.get_rect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/get_rect/) 取得段落的外框矩形。[Portion.get_rect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/get_rect/) 可取得單一區段的邊界。

**段落對齊（左、右、置中或分散對齊）在哪裡設定？**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/alignment/) 是段落層級的設定，會套用於整個段落，而不受個別區段格式的影響。

**我能為段落的一部份設定校對語言嗎？**

可以。為個別區段設定 [PortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/language_id/)，即可讓同一段落包含多種語言的文字。