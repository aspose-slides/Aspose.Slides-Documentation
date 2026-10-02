---
title: 管理 PowerPoint 文字段落（Python via Java）
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
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
- 段落轉圖像
- 文字轉圖像
- 匯出段落
- PowerPoint
- 投影片
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 建立與格式化段落、部分、項目符號、編號清單、縮排、HTML 內容，以及段落圖像。"
---
## **概述**

Aspose.Slides for Python via Java 將文字表示為文字框、段落和部分的層次結構：

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) 表示形狀中的文字容器，並提供對其段落集合的存取。
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) 表示文字框中的一個段落，並提供對其部分和段落層級格式設定的存取。
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) 表示段落內的文字片段。每個部分可以具有自己的文字和字元層級格式設定。

因此，段落可以透過使用多個部分來包含具有不同字體、顏色、大小及其他格式設定的文字。

## **建立與格式化段落**

### **建立具有多個部分的段落**

以下步驟會建立一個文字框，內含三個段落，每個段落包含三個部分：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關的投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
4. 存取形狀的 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)。
5. 使用預設段落，並向文字框新增另外兩個 [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) 物件。
6. 為每個段落加入足夠的 [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) 物件以包含三個部分。預設段落已包含一個空的部分。
7. 設定每個部分的文字。
8. 透過 [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat) 套用字元層級的格式設定。
9. 儲存修改後的投影片。

以下 Python 範例實作上述步驟：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **建立項目符號與編號清單**

### **建立項目符號或編號清單**

項目符號與編號可讓相關項目更易於瀏覽。在 Aspose.Slides 中，清單設定是透過 [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) 定義的。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關的投影片。
3. 向選取的投影片新增一個 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
4. 存取形狀的 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)。
5. 從文字框中移除預設段落。
6. 建立一個用於符號項目符號的 [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/)。
7. 將 [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) 設為 [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol)，並指定項目符號字元。
8. 設定段落文字、縮排、項目符號顏色與項目符號高度。
9. 將段落加入文字框。
10. 建立第二個段落，並將 [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) 設為 [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered)。
11. 設定編號項目符號樣式，並將段落加入文字框。
12. 儲存投影片。

以下 Python 範例建立一個符號項目符號和一個編號項目符號：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **使用圖片項目符號**

圖片項目符號讓您可以使用自訂圖片取代符號或編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關的投影片。
3. 新增一個 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 並存取其 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)。
4. 從文字框中移除預設段落。
5. 載入項目符號圖像，並以 [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) 形式加入投影片的影像集合。
6. 建立一個 [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) 並設定其文字。
7. 將 [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) 設為 [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture)。
8. 透過 [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) 指定圖像，並設定項目符號高度。
9. 將段落加入文字框。
10. 儲存修改後的投影片。

以下 Python 範例建立圖片項目符號：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **建立多層級清單**

將 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) 設定為將段落放置於清單的不同層級。最高層的深度為 `0`。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 並存取投影片。
2. 新增一個 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)，並清除其文字框中的預設段落。
3. 建立四個段落，並設定它們的項目符號。
4. 將它們的 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) 值分別設定為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框，並儲存投影片。

以下 Python 範例建立四層級的項目符號清單：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **自訂編號清單起始值**

使用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 來設定編號段落的起始數字。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 並向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
2. 清除形狀文字框中的預設段落。
3. 建立三個編號段落。
4. 為相應的段落將 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 設為 `2`、`3` 與 `7`。
5. 將段落加入文字框，並儲存投影片。

以下 Python 範例為每個段落指定自訂的起始編號：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制段落版面配置與結尾屬性**

### **設定首行縮排**

使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) 來控制段落的首行縮排。此方法僅移動第一行相對於段落左邊距的位移。正值會將首行向右移動，而其餘行則保持與段落主體對齊。

當需要移動整個段落時，請使用 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft)。當只需移動首行時，請使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent)。

以下範例建立數個段落，並套用不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) 值，以示範首行縮排對段落版面配置的影響。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
4. 存取形狀的 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)，並移除預設段落。
5. 建立數個段落，並為它們設定不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) 值。
6. 將段落加入文字框。
7. 儲存修改後的投影片。

以下程式碼示範如何設定段落縮排：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![段落的首行縮排](first_line_indent.png)

### **設定懸掛縮排**

懸掛縮排是一種段落版面配置，第一行位於其餘行的左側。在 Aspose.Slides 中，您可使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) 產生此效果。傳遞負值即可將第一行相對於段落正文向左移動。

實際上，[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) 定義段落正文的左側位置，而 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) 定義第一行相對於該邊距的位置。若要建立懸掛縮排，請對 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) 傳遞正值，並對 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) 傳遞負值。

此格式化在參考文獻、引用、詞彙表條目及其他需要讓換行後的行對齊段落正文而非首行第一個字元的段落中相當有用。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
4. 存取形狀的 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)，並移除預設段落。
5. 建立段落，並對每個段落傳遞正值給 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft)。
6. 傳遞負值給 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) 以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存修改後的投影片。

以下程式碼示範如何為段落設定懸掛縮排：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![段落的懸掛縮排](hanging_indent.png)

### **設定段落結尾執行屬性**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) 控制段落結尾標記的格式設定。以下範例將字型大小與拉丁字型指定給第二段落的結尾標記：

1. 載入一個 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 並存取投影片。
2. 新增一個 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)，並清除其預設段落。
3. 建立兩個段落，並為其加入文字部分。
4. 為第二段落的結尾標記建立一個 [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/)。
5. 設定 [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) 與 [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont)。
6. 使用 [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) 指定格式，並儲存投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **計算已渲染的行數**

有關影響自動換行與行尾標點符號的段落規則，請參閱 [控制換行](/slides/zh-hant/python-java/text-formatting/#control-line-breaking) 與 [控制懸掛標點](/slides/zh-hant/python-java/text-formatting/#control-hanging-punctuation)。

使用 [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) 可以計算段落在文字版面配置後所佔的行數，包括自動換行。此功能在檢查投影片範本中的文字長度與版面配置時非常有用。

段落是 [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) 中的一項，它可能佔用多行已渲染的文字。段落內的明確換行符會強制換行但不會產生新的段落。自動換行則根據可用寬度產生行數，且不會在文字中插入明確的換行字元。因此，僅計算段落數或換行字元並無法得出已渲染的行數。

以下範例建立一個文字形狀，計算其行數，縮小形狀寬度，然後將文字取代為較短的字串。啟用換行且停用自動調整大小，以使形狀寬度控制換行，而不會自動縮小文字或調整形狀尺寸。形狀尺寸以點 (point) 為單位。最後，範例再加入另一個段落，並將文字框內所有段落的行數加總。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

使用此文字與這些尺寸時，縮小形狀會增加行數，而以短字串取代文字則會減少行數。實際行數會因字型可用性與替代、字型大小、邊距、縮排、換行與自動調整設定等因素而異。檢查範本時，請使用目標環境所預期的字型與版面設定。

僅憑行數無法判斷文字是否溢出其容器。可用高度、行高、段落與行間距以及自動調整行為也同樣重要；即使是單行文字，若未啟用換行，也可能超過可用寬度。

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) 可將 HTML 標記轉換為文字框中的段落和部分。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。
2. 存取投影片，並新增一個 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
3. 存取形狀的 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)，並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳給 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml)。
6. 儲存修改後的投影片。

以下 Python 範例將 HTML 匯入文字框：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **將段落文字匯出為 HTML**

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) 可將選取的段落範圍匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例，並載入所需的投影片。
2. 存取投影片，並找出包含文字的 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
3. 存取形狀的 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)。
4. 呼叫 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml)，傳入起始段落索引與要匯出的段落數量。
5. 將回傳的 HTML 字串寫入檔案。

以下 Python 範例匯出第一個文字形狀的所有段落：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **將段落渲染為圖像**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) 直接渲染單一段落，並回傳圖像物件。可使用其 `save` 方法將結果儲存至檔案或串流。不需要渲染包含的形狀或手動裁切位圖。

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) 可能在段落未在父集合中找到、沒有有效的渲染邊界，或無法渲染時回傳 `None`。請在儲存之前檢查結果，並在使用完畢後釋放回傳的圖像。

#### **以預設比例渲染段落**

假設我們有一個名為 sample.pptx 的投影片檔案，只有一張投影片，且第一個形狀是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例在常規文字形狀中以預設比例渲染第二個段落，並將回傳的圖像以 PNG 格式儲存。`finally` 區塊確保圖像正確釋放。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

結果：

![段落圖像](paragraph_to_image_output.png)

#### **以比例在表格儲存格中渲染段落**

使用接受 `scale_x` 與 `scale_y` 參數的 [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) 重載，以設定水平與垂直縮放係數。以下範例建立一個表格，於第一個儲存格中以預設寬高的兩倍渲染段落，並將結果儲存為 PNG 圖像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

`1` 的縮放係數會使該軸保持預設像素大小。例如，兩個係數皆為 `2` 會產生寬高約為預設兩倍的圖像，像素數量為原來的四倍。較大的係數通常可產生較銳利的文字，以供放大或高解析度輸出，但也會增加記憶體使用與檔案大小。低於 `1` 的係數會產生較小且細節較少的圖像。使用相同的係數可保留段落的比例；不同的水平與垂直係數會分別拉伸輸出。

在輸出必須包含形狀的填充、邊框或其他視覺上下文時，使用 [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) 渲染整個形狀仍然有用。若僅需段落圖像，請使用 [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/)。

## **FAQ**

**我可以完全停用文字框內的換行嗎？**

是的。將 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) 設為停用，即可停止換行，讓行不在文字框邊緣斷開。

**我如何取得特定段落在投影片上的精確邊界？**

使用 [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) 可取得段落的邊界矩形。[Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) 則提供單一部分的邊界。

**段落對齊（左、右、置中或兩端對齊）在哪裡設定？**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) 為段落層級設定，會套用於整個段落，不受個別部分格式影響。

若要在每行內垂直對齊不同字型大小的部分，請參閱 [在行內對齊字型](/slides/zh-hant/python-java/text-formatting/#align-fonts-within-a-line)。

**我可以為段落的部分文字設定校對語言嗎？**

可以。對個別部分設定 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId)，即可讓同一段落包含多種語言的文字。