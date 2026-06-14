---
title: 在 Python 中管理 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/python-net/manage-paragraph/
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
- 項目清單
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
description: "使用 Aspose.Slides for Python (透過 .NET) 精通段落格式設定—在 Python 中優化 PowerPoint 與 OpenDocument 簡報的對齊、間距與樣式，以吸引觀眾。"
---
## **簡介**

Aspose.Slides 提供您在 Python 中處理 PowerPoint 文字所需的類別。

* Aspose.Slides 提供 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 類別，用於建立文字框物件。`TextFrame` 物件可以包含一個或多個段落（每個段落以換行字元分隔）。
* Aspose.Slides 提供 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別，用於建立段落物件。`Paragraph` 物件可以包含一個或多個文字片段。
* Aspose.Slides 提供 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 類別，用於建立文字片段物件並指定其格式屬性。

`Paragraph` 物件可以透過其底層的 `Portion` 物件處理具有不同格式屬性的文字。

## **新增包含多個片段的多段落**

以下步驟示範如何新增一個包含三個段落、且每個段落都有三個片段的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得目標投影片的參考。
1. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取得與 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 相關聯的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 建立兩個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 物件，並將它們加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合中（加上預設段落共計三個段落）。
1. 對每個段落，建立三個 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 物件，並將它們加入該段落的片段集合中。
1. 為每個片段設定文字。
1. 使用 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 所提供的屬性，為每個文字片段套用所需的格式設定。
1. 儲存已修改的簡報。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化 Presentation 類別以建立新的 PPTX 檔案。
with slides.Presentation() as presentation:

    # 存取第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # 存取 AutoShape 的 TextFrame。
    text_frame = shape.text_frame

    # 建立段落和文字片段；以下套用格式設定。
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # 將 PPTX 儲存至磁碟。
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理段落項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。使用項目符號的段落通常更易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引存取目標投影片。
1. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 移除預設段落。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第一個段落。
1. 將段落的項目符號類型設定為 `SYMBOL`，並指定項目符號字元。
1. 設定段落文字。
1. 設定段落的項目符號縮排。
1. 設定項目符號顏色。
1. 設定項目符號大小（高度）。
1. 將段落加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合中。
1. 新增第二個段落，並重複步驟 7～12。
1. 儲存簡報。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立簡報實例。
with slides.Presentation() as presentation:

    # 存取第一張投影片。
    slide = presentation.slides[0]

    # 新增並存取 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 存取已建立 AutoShape 的文字框。
    text_frame = shape.text_frame

    # 移除預設段落。
    text_frame.paragraphs.remove_at(0)

    # 建立段落。
    paragraph = slides.Paragraph()

    # 設定段落的項目符號樣式與符號。
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # 設定段落文字。
    paragraph.text = "Welcome to Aspose.Slides"

    # 設定項目符號縮排。
    paragraph.paragraph_format.indent = 25

    # 設定項目符號顏色。
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # 設定項目符號高度。
    paragraph.paragraph_format.bullet.height = 100

    # 將段落加入文字框。
    text_frame.paragraphs.add(paragraph)

    # 建立第二個段落。
    paragraph2 = slides.Paragraph()

    # 設定段落的項目符號類型與樣式。
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # 設定段落文字。
    paragraph2.text = "This is numbered bullet"

    # 設定項目符號縮排。
    paragraph2.paragraph_format.indent = 25

    # 設定項目符號顏色。
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # 設定項目符號高度。
    paragraph2.paragraph_format.bullet.height = 100

    # 將段落加入文字框。
    text_frame.paragraphs.add(paragraph2)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理圖片項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。圖片項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引存取目標投影片。
1. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 移除預設段落。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第一個段落。
1. 將影像載入 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)。
1. 將項目符號類型設定為 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/)，並指派該影像。
1. 設定段落文字。
1. 設定段落的項目符號縮排。
1. 設定項目符號顏色。
1. 設定項目符號高度。
1. 將新段落加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合中。
1. 新增第二個段落，並重複步驟 8～12。
1. 儲存簡報。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # 存取第一張投影片。
    slide = presentation.slides[0]

    # 載入項目符號影像。
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # 新增並存取 AutoShape。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 存取已建立 AutoShape 的 TextFrame。
    text_frame = auto_shape.text_frame

    # 移除預設段落。
    text_frame.paragraphs.remove_at(0)

    # 建立新的段落。
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # 設定段落的項目符號類型為圖片並指派影像。
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # 設定項目符號高度。
    paragraph.paragraph_format.bullet.height = 100

    # 將段落加入文字框。
    text_frame.paragraphs.add(paragraph)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # 將簡報儲存為 PPT 檔案。
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **管理多層次項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。多層次項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引存取目標投影片。
1. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取得 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 移除預設段落。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第一個段落，並將其深度設為 0。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第二個段落，並將其深度設為 1。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第三個段落，並將其深度設為 2。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第四個段落，並將其深度設為 3。
1. 將新段落加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合中。
1. 儲存簡報。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立簡報實例。
with slides.Presentation() as presentation:

    # 存取第一張投影片。
    slide = presentation.slides[0]
    
    # 新增 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 存取已建立 AutoShape 的 TextFrame。
    text_frame = auto_shape.text_frame
    
    # 清除預設段落。
    text_frame.paragraphs.clear()

    # 新增第一個段落。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 設定項目符號層級。
    paragraph1.paragraph_format.depth = 0

    # 新增第二個段落。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 設定項目符號層級。
    paragraph2.paragraph_format.depth = 1

    # 新增第三個段落。
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 設定項目符號層級。
    paragraph3.paragraph_format.depth = 2

    # 新增第四個段落。
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 設定項目符號層級。
    paragraph4.paragraph_format.depth = 3

    # 將段落加入集合。
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理自訂編號清單的段落**

[BulletFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/) 類別提供 `numbered_bullet_start_with` 屬性（以及其他屬性），用於控制段落的自訂編號與格式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 存取將容納段落的投影片。
1. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 移除預設段落。
1. 建立第一個 [Paragraph]，並將 `numbered_bullet_start_with` 設為 2。
1. 建立第二個 [Paragraph]，並將 `numbered_bullet_start_with` 設為 3。
1. 建立第三個 [Paragraph]，並將 `numbered_bullet_start_with` 設為 7。
1. 將段落加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的集合中。
1. 儲存簡報。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # 新增並存取 AutoShape。
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 存取已建立 AutoShape 的 TextFrame。
    text_frame = shape.text_frame

    # 移除預設的現有段落。
    text_frame.paragraphs.remove_at(0)

    # 建立第一個編號項目（從 2 開始，層級 4）。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # 建立第二個編號項目（從 3 開始，層級 4）。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # 建立第三個編號項目（從 7 開始，層級 4）。
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定段落首行縮排**

使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 屬性可控制段落的首行縮排。此屬性僅會移動首行相對於段落左邊距的位置。正值會將首行向右移動，而其餘行則保持與段落正文對齊。

當需要移動整段文字時，請使用 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/)。若只需要移動首行，請使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/)。

以下範例建立多個段落，並套用不同的 `indent` 值，以示範首行縮排如何影響段落版面配置。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 為形狀新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)，並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

結果：
![段落的首行縮排](first_line_indent.png)

## **設定段落懸掛縮排**

懸掛縮排是指段落的版面配置，第一行起始於其餘行的左側。於 Aspose.Slides 中，可使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 屬性來實現此效果。將 `indent` 設為負值，即可使第一行相對於段落正文向左移動。

實務上，[ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/) 定義段落正文的左側位置，而 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 定義第一行相對於該左側的位移。若要建立懸掛縮排，請將 `margin_left` 設為正值，`indent` 設為負值。

此格式在書目、參考文獻、詞彙表項目以及其他需要讓換行文字對齊於段落正文而非首行第一個字元的段落中特別有用。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 為形狀新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)，並移除預設段落。
5. 建立段落，並為每個段落設定正的 [margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/) 值。
6. 設定負的 [indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 值，以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

結果：
![段落的懸掛縮排](hanging_indent.png)

## **管理段落末端片段格式**

當您需要控制段落「結尾」的樣式（最後一個文字片段之後的格式）時，可使用 `end_paragraph_portion_format` 屬性。以下範例將較大的 Times New Roman 字型套用於第二段落的結尾。

1. 建立或開啟 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 檔案。
2. 依索引取得目標投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 使用形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)，並建立兩個段落。
5. 建立一個 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/) ，設定為 48 點 Times New Roman，並將其作為段落的結尾片段格式。
6. 將其指派給段落的 `end_paragraph_portion_format`（套用於第二段落的結尾）。
7. 將已修改的簡報寫入為 PPTX 檔案。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **將 HTML 文字匯入段落**

Aspose.Slides 提供加強的支援，可將 HTML 文字匯入段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引存取目標投影片。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 取得 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
5. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 移除預設段落。
6. 讀取來源 HTML 檔案。
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第一個段落。
8. 將 HTML 內容加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合中。
9. 儲存已修改的簡報。

```python
import aspose.slides as slides

# 建立空的 Presentation 實例。
with slides.Presentation() as presentation:

    # 存取簡報的第一張投影片。
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # 新增一個 AutoShape 以容納 HTML 內容。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # 清除已新增文字框中的所有段落。
    shape.text_frame.paragraphs.clear()

    # 載入 HTML 檔案。
    with open("file.html", "rt") as html_stream:
        # 將 HTML 檔案的文字加入文字框。
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # 儲存簡報。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **將段落文字匯出為 HTML**

Aspose.Slides 提供加強的支援，可將文字匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例並載入目標簡報。
2. 依索引存取所需的投影片。
3. 選取包含要匯出文字的形狀。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
5. 開啟檔案串流以寫入 HTML 輸出，並指定起始索引以匯出所需的段落。

```python
import aspose.slides as slides

# 載入簡報檔案。
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # 存取簡報的第一張投影片。
    slide = presentation.slides[0]

    # 目標形狀索引。
    index = 0

    # 依索引存取形狀。
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # 透過提供起始段落索引與欲匯出段落總數，將段落資料寫入 HTML。
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **將段落儲存為影像**

在本節中，我們將探討兩個示例，說明如何將文字段落（由 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別表示）儲存為影像。兩個示例皆包括使用 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 類別的 `get_image` 方法取得包含段落的形狀影像，計算段落在形狀內的邊界，並將其匯出為點陣圖影像。這些方法讓您能從 PowerPoint 簡報中擷取特定的文字部分，並將其存為單獨的影像，供各種後續情境使用。

假設我們有一個名為 sample.pptx 的簡報檔案，裡面有一張投影片，第一個形狀是一個包含三個段落的文字方塊。

![含三個段落的文字方塊](paragraph_to_image_input.png)

**範例 1**

在此範例中，我們取得第二個段落的影像。為此，我們從簡報的第一張投影片中擷取形狀的影像，然後計算該形狀文字框中第二個段落的邊界。接著將段落重新繪製到新的點陣圖影像中，並以 PNG 格式儲存。此方法在需要將特定段落保存為獨立影像，同時保留文字的精確尺寸與格式時特別有用。

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 將形狀以位圖儲存於記憶體中。
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # 從記憶體建立形狀位圖。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 計算第二段落的邊界。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # 計算輸出影像的座標與大小（最小尺寸 - 1x1 像素）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 裁切形狀位圖以僅取得段落位圖。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

結果：
![段落影像](paragraph_to_image_output.png)

**範例 2**

在此範例中，我們在先前的方法基礎上加入縮放因子，以產生段落影像。形狀從簡報中擷取，並以縮放因子 `2` 儲存為影像。這可在匯出段落時得到較高解析度的輸出。接著在考慮縮放的情況下計算段落邊界。當需要更詳細的影像時（例如，用於高品質印刷材料），縮放特別有用。

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 將形狀於記憶體中儲存為位圖。
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # 從記憶體建立形狀位圖。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 計算第二段落的邊界。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # 計算輸出影像的座標與大小（最小尺寸 - 1x1 像素）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 裁切形狀位圖以僅取得段落位圖。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **常見問題**

**我可以完全停用文字框內的自動換行嗎？**

可以。使用文字框的換行設定（[wrap_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/wrap_text/)）關閉換行，即可避免文字在框邊自動斷行。

**如何取得特定段落在投影片上的精確邊界？**

您可以取得段落（甚至單一片段）的邊界矩形，以獲得其在投影片上的精確位置與尺寸。

**段落對齊（左、右、置中、兩端對齊）在哪裡設定？**

[Alignment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/alignment/) 是段落層級的設定，位於 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/) 中；它會套用於整個段落，與各片段的個別格式無關。

**我可以為段落的一部分（例如單一單詞）設定拼寫檢查語言嗎？**

可以。語言設定在片段層級（[PortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/language_id/)），因此單一段落內可同時存在多種語言。