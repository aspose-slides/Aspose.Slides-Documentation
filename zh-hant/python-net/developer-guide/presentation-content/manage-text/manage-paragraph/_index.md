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
- 項目清單
- 段落屬性
- 匯入 HTML
- 文字轉 HTML
- 段落轉 HTML
- 段落轉圖像
- 文字轉圖像
- 匯出段落
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "透過 .NET 的 Aspose.Slides for Python，掌握段落格式設定——在 PowerPoint 與 OpenDocument 簡報中優化對齊、間距與樣式，提升觀眾體驗。"
---
## **簡介**

Aspose.Slides 提供您在 Python 中處理 PowerPoint 文字所需的類別。

* Aspose.Slides 提供 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 類別，用於建立文字框物件。`TextFrame` 物件可以包含一個或多個段落（每個段落以換行字元分隔）。
* Aspose.Slides 提供 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別，用於建立段落物件。`Paragraph` 物件可以包含一個或多個文字 Portion。
* Aspose.Slides 提供 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 類別，用於建立文字 Portion 並指定其格式屬性。

`Paragraph` 物件可以透過其底層的 `Portion` 物件處理具有不同格式屬性的文字。

## **安裝**

```bash
pip install aspose.slides
```

## **新增多段落 (包含多個 Portion)**

以下步驟示範如何新增一個包含三個段落、每個段落有三個 Portion 的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得目標投影片的參照。
1. 在投影片上加入一個矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取得與該 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 相關聯的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 建立兩個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 物件，並將它們加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合中（再加上預設段落即可得到三個段落）。
1. 為每個段落建立三個 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 物件，並將它們加入該段落的 Portion 集合。
1. 設定每個 Portion 的文字內容。
1. 使用 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 所公開的屬性，對每個文字 Portion 套用所需的格式。
1. 儲存已修改的簡報。

以下 Python 程式碼實作上述步驟：

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

    # 建立段落和 Portion；以下套用格式。
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
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # 將 PPTX 儲存至磁碟。
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理段落項目符號**

項目清單可協助您快速且有效率地組織與呈現資訊。使用項目符號的段落通常較易閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引存取目標投影片。
1. 在投影片上加入一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取用該圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 中移除預設段落。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第一個段落。
1. 將段落的項目符號類型設定為 `SYMBOL`，並指定項目符號字元。
1. 設定段落的文字內容。
1. 設定段落的項目符號縮排。
1. 設定項目符號顏色。
1. 設定項目符號大小（高度）。
1. 將段落加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合。
1. 加入第二個段落，並重複第 7 至第 12 步驟。
1. 儲存簡報。

以下 Python 程式碼示範如何新增項目符號段落：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立簡報實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增並取得 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 取得已建立 AutoShape 的文字框。
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
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # 設定項目符號高度。
    paragraph.paragraph_format.bullet.height = 100

    # 將段落加入文字框。
    text_frame.paragraphs.add(paragraph)

    # 建立第二個段落。
    paragraph2 = slides.Paragraph()

    # 設定段落的項目符號類型與樣式。
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # 設定段落文字。
    paragraph2.text = "This is numbered bullet"

    # 設定項目符號縮排。
    paragraph2.paragraph_format.indent = 25

    # 設定項目符號顏色。
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # 設定項目符號高度。
    paragraph2.paragraph_format.bullet.height = 100

    # 將段落加入文字框。
    text_frame.paragraphs.add(paragraph2)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理圖片項目符號**

項目清單可協助您快速且有效率地組織與呈現資訊。圖片項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引存取目標投影片。
1. 在投影片上加入一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取用該圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 中移除預設段落。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立段落並設定其文字。
1. 載入圖像，並以 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 的形式加入簡報的圖像集合。
1. 將項目符號類型設定為 `PICTURE`，並將該 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 指派給項目符號。
1. 設定項目符號高度。
1. 將新段落加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合。
1. 儲存簡報。

以下 Python 程式碼示範如何新增與管理圖片項目符號：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 載入項目符號圖像。
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # 新增並取得 AutoShape。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 取得已建立 AutoShape 的 TextFrame。
    text_frame = auto_shape.text_frame

    # 移除預設段落。
    text_frame.paragraphs.remove_at(0)

    # 建立新段落。
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # 設定段落的項目符號類型為圖片並指派圖像。
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

## **管理多層項目符號**

項目清單可協助您快速且有效率地組織與呈現資訊。多層項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引存取目標投影片。
1. 在投影片上加入一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取用 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 中移除預設段落。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第一個段落，並將其深度設為 0。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第二個段落，並將其深度設為 1。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第三個段落，並將其深度設為 2。
1. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別建立第四個段落，並將其深度設為 3。
1. 將新段落加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合。
1. 儲存簡報。

以下 Python 程式碼示範如何新增與管理多層項目符號：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立簡報實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]
    
    # 新增 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 取得已建立 AutoShape 的 TextFrame。
    text_frame = shape.text_frame
    
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

## **管理具有自訂編號清單的段落**

[BulletFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/bulletformat/) 類別提供 `numbered_bullet_start_with` 屬性（以及其他屬性），可用來控制段落的自訂編號與格式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 取用將要包含段落的投影片。
1. 在投影片上加入一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取用圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 中移除預設段落。
1. 建立第一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/)，並將 `numbered_bullet_start_with` 設為 2。
1. 建立第二個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/)，並將 `numbered_bullet_start_with` 設為 3。
1. 建立第三個 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/)，並將 `numbered_bullet_start_with` 設為 7。
1. 將段落加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的集合中。
1. 儲存簡報。

以下 Python 程式碼示範如何新增與管理帶有自訂編號與格式的段落。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # 新增並取得 AutoShape。
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 取得已建立 AutoShape 的 TextFrame。
    text_frame = shape.text_frame

    # 移除預設的既有段落。
    text_frame.paragraphs.remove_at(0)

    # 建立第一個編號項目（起始於 2，深度等級 4）。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # 建立第二個編號項目（起始於 3，深度等級 4）。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # 建立第三個編號項目（起始於 7，深度等級 4）。
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定段落的首行縮排**

使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 屬性可控制段落的首行縮排。此屬性僅會移動段落左側邊距相對的第一行。正值會將第一行向右平移，而其餘行則保持與段落正文對齊。

當您需要移動整個段落時，請使用 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/)。當您只需要移動第一行時，請使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/)。

以下範例建立多個段落，並套用不同的 `indent` 值，以示範首行縮排對段落版面配置的影響。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 取用目標投影片。
3. 在投影片上加入一個矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 在圖形上加入空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)，並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

此程式碼示範如何設定段落縮排：

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

## **設定段落的懸掛縮排**

懸掛縮排是一種段落版面配置，第一行會位於其餘行的左側。在 Aspose.Slides 中，您可使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 屬性來實作此效果。將 `indent` 設為負值，即可使第一行相對於段落正文向左移動。

實務上，[ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/) 定義段落正文的左側位置，而 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 定義第一行相對於該邊距的位置。要建立懸掛縮排，請將正的 `margin_left` 與負的 `indent` 結合使用。

此格式特別適用於參考文獻、引用、詞彙表項目等，需要讓換行的文字對齊在段落正文下方的情境。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 取用目標投影片。
3. 在投影片上加入一個矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 在圖形上加入空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)，並移除預設段落。
5. 為每個段落建立正的 [margin_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/margin_left/) 值。
6. 設定負的 [indent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/indent/) 值以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

此程式碼示範如何為段落設定懸掛縮排：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

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

## **管理段落結尾 Portion 格式**

當您需要控制段落「結尾」的樣式（最後一個文字 Portion 之後套用的格式）時，可使用 `end_paragraph_portion_format` 屬性。以下範例將第二段落的結尾套用較大的 Times New Roman 字型。

1. 建立或開啟一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 檔案。
1. 依索引取得目標投影片。
1. 在投影片上加入一個矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 使用圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)，建立兩個段落。
1. 建立一個 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/) 設為 48 點 Times New Roman，並將其套用為段落的結尾 Portion 格式。
1. 將其指派給段落的 `end_paragraph_portion_format`（套用於第二段落的結尾）。
1. 將修改後的簡報寫為 PPTX 檔案。

此 Python 程式碼示範如何為第二段落設定段落結尾的格式：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# 移除預設段落。
	shape.text_frame.paragraphs.clear()

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

Aspose.Slides 提供加強的功能，可將 HTML 文字匯入段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取用目標投影片。
1. 在投影片上加入一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 取用該 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 中移除預設段落。
1. 讀取來源 HTML 檔案。
1. 將 HTML 內容加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的段落集合。
1. 儲存已修改的簡報。

以下 Python 程式碼實作上述步驟，將 HTML 文字匯入段落。

```python
import aspose.slides as slides

# 建立空的 Presentation 實例。
with slides.Presentation() as presentation:

    # 取得簡報的第一張投影片。
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # 新增 AutoShape 以容納 HTML 內容。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # 清除新增文字框中的所有段落。
    shape.text_frame.paragraphs.clear()

    # 載入 HTML 檔案。
    with open("file.html", "rt") as html_stream:
        # 將 HTML 檔案的文字加入文字框。
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # 儲存簡報。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **匯出段落文字為 HTML**

Aspose.Slides 提供加強的功能，可將文字匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例並載入目標簡報。
1. 依索引取用所需的投影片。
1. 選取包含欲匯出文字的圖形。
1. 取用圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
1. 開啟檔案串流以寫入 HTML 輸出，並指定起始索引，匯出所需的段落。

此 Python 範例示範如何將段落文字匯出為 HTML。

```python
import aspose.slides as slides

# 載入簡報檔案。
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # 取得簡報的第一張投影片。
    slide = presentation.slides[0]

    # 目標圖形索引。
    index = 0

    # 依索引取得圖形。
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # 透過提供起始段落索引及要匯出的段落總數，將段落資料寫入 HTML。
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **將段落另存為圖像**

在本節中，我們將探討兩個範例，說明如何將由 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 類別表示的文字段落另存為圖像。兩個範例皆會使用 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 類別的 `get_image` 方法取得包含段落的圖形圖像，計算段落在圖形內的邊界，並將其匯出為位圖圖像。這些方法可讓您從 PowerPoint 簡報中提取特定文字部份，並另存為單獨的圖像，適用於各種後續情境。

假設我們有一個名為 sample.pptx 的簡報檔案，內含一張投影片，第一個圖形是一個文字方塊，裡面有三個段落。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

**Example 1**

在此範例中，我們取得第二段落的圖像。為此，我們先從簡報的第一張投影片中取得圖形的圖像，然後計算該圖形文字框中第二段落的邊界。接著將段落重新繪製到新的位圖圖像，並以 PNG 格式儲存。此方法特別適用於需要將特定段落另存為獨立圖像，同時保留文字的精確尺寸與格式的情況。

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 將圖形儲存於記憶體中為位圖。
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # 從記憶體建立圖形位圖。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 計算第二段落的邊界。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # 計算輸出圖像的坐標與尺寸（最小尺寸為 1x1 像素）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 裁剪圖形位圖以僅取得段落位圖。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

結果：

![段落圖像](paragraph_to_image_output.png)

**Example 2**

在此範例中，我們在前一個方法的基礎上加入縮放因子，將圖形以 `2` 的倍率儲存為圖像，從而在匯出段落時獲得更高解析度的輸出。接著在考慮縮放比例後計算段落邊界。當需要更細緻的圖像（例如用於高品質列印材料）時，縮放會非常有用。

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 將圖形儲存於記憶體中為位圖。
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # 從記憶體建立圖形位圖。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 計算第二段落的邊界。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # 計算輸出圖像的座標與大小（最小尺寸為 1x1 像素）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 裁剪圖形位圖以僅取得段落位圖。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

### 我可以完全停用文字框內的換行嗎？

可以。使用文字框的換行設定（[wrap_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/wrap_text/)）將換行關閉，即可避免文字在框邊緣斷行。

### 如何取得特定段落在投影片上的精確邊界？

您可以取得段落（甚至單一 Portion）的邊界矩形，從而得知其在投影片上的精確位置與大小。

### 段落對齊（左/右/置中/分散對齊）在哪裡控制？

[Alignment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/alignment/) 是段落層級的設定，位於 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/) 中；它會套用於整個段落，與各個 Portion 的格式無關。

### 我可以為段落的部分文字（例如單一字詞）設定拼寫檢查語言嗎？

可以。語言設定在 Portion 層級（[PortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/language_id/)），因此同一段落中可以同時存在多種語言。