---
title: 在 Python via Java 中管理 PowerPoint 文字段落
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 建立與格式化段落、文字片段、項目符號、編號清單、縮排、HTML 內容以及段落圖像。"
---
## **概述**

Aspose.Slides for Python via Java 將文字表示為文字框、段落與文字片段的層級結構：

* [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 代表形狀中的文字容器，並提供對其段落集合的存取。
* [Paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/) 代表文字框中的一個段落，並提供對其文字片段及段落層級格式設定的存取。
* [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 代表段落內的一段文字。每個文字片段可以有自己的文字與字元層級格式設定。

段落因此可以透過使用多個文字片段，包含具有不同字型、顏色、大小以及其他格式設定的文字。

## **建立與格式化段落**

### **建立具有多個文字片段的段落**

以下步驟會建立一個文字框，內含三個段落，每個段落包含三個文字片段：

1. 建立 [Presentation] 類別的實例。
2. 透過索引存取相關投影片。
3. 在投影片上新增一個矩形的 [AutoShape]。
4. 存取形狀的 [TextFrame]。
5. 使用預設段落，並向文字框新增另外兩個 [Paragraph] 物件。
6. 為每個段落新增足夠的 [Portion] 物件，使其包含三個文字片段。預設段落已包含一個空的文字片段。
7. 設定每個文字片段的文字。
8. 透過 [Portion.getPortionFormat] 套用字元層級的格式設定。
9. 儲存已修改的簡報。

此 Python 範例實作上述步驟：

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

## **建立項目與編號清單**

### **建立項目或編號清單**

項目符號與編號可讓相關項目更易於掃描。在 Aspose.Slides 中，清單設定是透過 [BulletFormat] 定義的。

1. 建立 [Presentation] 類別的實例。
2. 透過索引存取相關投影片。
3. 在選取的投影片上新增一個 [AutoShape]。
4. 存取形狀的 [TextFrame]。
5. 從文字框中移除預設段落。
6. 建立一個用於符號項目的 [Paragraph]。
7. 將 [BulletFormat.setType] 設為 [BulletType.Symbol]，並指定項目符號字符。
8. 設定段落文字、縮排、項目顏色與項目高度。
9. 將段落加入文字框。
10. 建立第二個段落，並將 [BulletFormat.setType] 設為 [BulletType.Numbered]。
11. 設定編號項目樣式，並將段落加入文字框。
12. 儲存簡報。

此 Python 範例建立符號項目與編號項目：

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

### **使用圖片項目**

圖片項目允許您使用自訂圖片代替符號或編號。

1. 建立 [Presentation] 類別的實例。
2. 透過索引存取相關投影片。
3. 新增一個 [AutoShape]，並存取其 [TextFrame]。
4. 從文字框中移除預設段落。
5. 載入項目圖片，並以 [PPImage] 形式加入簡報的圖像集合中。
6. 建立一個 [Paragraph] 並設定其文字。
7. 將 [BulletFormat.setType] 設為 [BulletType.Picture]。
8. 透過 [BulletFormat.getPicture] 指定圖像，並設定項目高度。
9. 將段落加入文字框。
10. 儲存已修改的簡報。

此 Python 範例建立圖片項目：

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

### **建立多層次清單**

將 [ParagraphFormat.setDepth] 設定為不同深度，可將段落放置於清單的不同層級。最高層的深度為 `0`。

1. 建立一個 [Presentation] 並存取投影片。
2. 新增一個 [AutoShape]，並清除其文字框中的預設段落。
3. 建立四個段落，並設定它們的項目符號。
4. 將它們的 [ParagraphFormat.setDepth] 值分別設定為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框，並儲存簡報。

此 Python 範例建立四層級的項目清單：

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

### **從自訂值開始編號清單項目**

使用 [BulletFormat.setNumberedBulletStartWith] 可設定編號段落的起始編號。

1. 建立 [Presentation] 類別的實例並存取投影片。
2. 清除形狀文字框中的預設段落。
3. 建立三個編號段落。
4. 對相應段落將 [BulletFormat.setNumberedBulletStartWith] 設為 `2`、`3`、`7`。
5. 將段落加入文字框，並儲存簡報。

此 Python 範例為每個段落指派自訂的起始編號：

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

## **控制段落版面與結尾屬性**

### **設定首行縮排**

使用 [ParagraphFormat.setIndent] 來控制段落的首行縮排。此方法僅移動首行相對於段落左邊距的距離。正值會將首行向右移動，而其餘行則保持與段落本體對齊。若需移動整段文字，請使用 [ParagraphFormat.setMarginLeft]；若僅需移動首行，請使用 [ParagraphFormat.setIndent]。以下範例建立多個段落，並套用不同的 [ParagraphFormat.setIndent] 值，以示範首行縮排如何影響段落版面。

1. 建立 [Presentation] 類別的實例。
2. 存取目標投影片。
3. 在投影片上新增一個矩形的 [AutoShape]。
4. 存取形狀的 [TextFrame]，並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [ParagraphFormat.setIndent] 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

此程式碼示範如何設定段落縮排：

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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
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

懸掛縮排是一種段落版面配置，第一行起始位置位於其餘行的左側。在 Aspose.Slides 中，可透過 [ParagraphFormat.setIndent] 產生此效果。傳入負值即可將第一行向左移動，相對於段落本體。實務上，[ParagraphFormat.setMarginLeft] 定義段落本體的左側位置，而 [ParagraphFormat.setIndent] 定義第一行相對於該邊距的位置。若要建立懸掛縮排，請對 [ParagraphFormat.setMarginLeft] 傳入正值，並對 [ParagraphFormat.setIndent] 傳入負值。此種格式化對於書目、參考文獻、詞彙表條目，以及其他需要讓換行後的文字對齊段落本體，而非對齊首行第一個字元的段落特別有用。

1. 建立 [Presentation] 類別的實例。
2. 存取目標投影片。
3. 在投影片上新增一個矩形的 [AutoShape]。
4. 存取形狀的 [TextFrame]，並移除預設段落。
5. 建立段落，並對每個段落傳入正值給 [ParagraphFormat.setMarginLeft]。
6. 傳入負值給 [ParagraphFormat.setIndent] 以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

此程式碼示範如何為段落設定懸掛縮排：

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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
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

[Paragraph.setEndParagraphPortionFormat] 控制段落結尾標記的格式設定。以下範例將字型大小與拉丁字型套用於第二個段落的結尾標記：

1. 載入一個 [Presentation] 並存取投影片。
2. 新增一個 [AutoShape]，並清除其預設段落。
3. 建立兩個段落，並為其加入文字片段。
4. 為第二個段落的結尾標記建立一個 [PortionFormat]。
5. 設定 [BasePortionFormat.setFontHeight] 與 [BasePortionFormat.setLatinFont]。
6. 使用 [Paragraph.setEndParagraphPortionFormat] 指派格式，並儲存簡報。

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

## **計算呈現行數**

使用 [Paragraph.getLinesCount] 可計算段落在文字版面布局後佔用的行數，包含自動換行。此功能在檢查簡報範本的文字長度與版面配置時相當有用。段落是 [TextFrame.getParagraphs] 中的單一項目，且可能佔用多行呈現。段落內的明確換行會強制產生新行，但不會建立新段落。自動換行則根據可用寬度產生行，而不會在文字中插入明確的換行字元。因此，僅統計段落數或換行字元無法得到實際呈現的行數。以下範例建立一個文字形狀，計算其行數，縮小形狀寬度，然後以較短的字串取代文字。啟用換行且停用自動調整大小，使形狀寬度控制換行，而不會自動縮小文字或調整形狀尺寸。形狀尺寸以點為單位。最後，範例再加入另一個段落，並將文字框內所有段落的行數相加。

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

依據此文字與尺寸，縮小形狀會增加行數，而以短字串取代文字則會減少行數。實際行數可能因字型是否可用與取代、字型大小、邊距、縮排、換行與自動調整設定而有所不同。在檢查範本時，請使用目標環境的字型與版面設定。僅行數本身無法判斷文字是否溢出其容器。可用高度、行高、段落與行間距以及自動調整行為也會影響；即使是一行文字，若停用換行，也可能超過可用寬度。

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.addFromHtml] 可將 HTML 標記轉換為文字框中的段落與文字片段。

1. 建立 [Presentation] 類別的實例。
2. 存取投影片，並新增一個 [AutoShape]。
3. 存取形狀的 [TextFrame]，並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳遞給 [ParagraphCollection.addFromHtml]。
6. 儲存已修改的簡報。

此 Python 範例將 HTML 匯入文字框：

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

使用 [ParagraphCollection.exportToHtml] 可將選取的段落範圍匯出為 HTML。

1. 建立 [Presentation] 類別的實例，並載入所需的簡報。
2. 存取投影片，並找出包含文字的 [AutoShape]。
3. 存取形狀的 [TextFrame]。
4. 呼叫 [ParagraphCollection.exportToHtml]，傳入起始段落索引與要匯出的段落數量。
5. 將回傳的 HTML 字串寫入檔案。

此 Python 範例將第一個文字形狀的所有段落匯出：

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

[Paragraph.getImage] 可直接渲染單一段落並回傳圖像物件。使用其 `save` 方法將結果儲存為檔案或串流。無需渲染包含的形狀或手動裁切位圖。  
如果段落在其父集合中找不到、沒有有效的渲染邊界，或無法渲染，[Paragraph.getImage] 可能會回傳 `None`。請在儲存前檢查結果，並於使用完畢後釋放回傳的圖像。

#### **以預設比例渲染段落**

假設我們有一個名為 sample.pptx 的簡報檔，包含一張投影片，第一個形狀是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例以預設比例渲染一般文字形狀中的第二個段落，並以 PNG 格式儲存回傳的圖像。`finally` 區塊確保圖像能正確釋放。

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

![段落圖像](paragraph_to_image_output.png)

#### **在表格儲存格中以縮放比例渲染段落**

使用接受 `scale_x` 與 `scale_y` 參數的 [Paragraph.getImage] 重載，以設定水平與垂直縮放係數。以下範例建立一個表格，於其第一個儲存格中以兩倍預設寬高渲染段落，並將結果儲存為 PNG 圖像。

```python
import jpide
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

`1` 的縮放係數會維持該軸的預設像素大小。例如，同時使用 `2` 會產生寬度與高度約為預設兩倍的圖像，像素數量為原來的四倍。較大的係數通常可產生較銳利的文字，適用於放大或高解析度輸出，但也會增加記憶體使用與檔案大小。低於 `1` 的係數會產生較小且細節較少的圖像。使用相同的係數可保留段落的長寬比；不同的水平與垂直係數則會獨立拉伸輸出。  
在輸出必須包含形狀的填充、邊框或其他視覺環境時，使用 [Shape.getImage] 來渲染整個形狀仍然有用。若僅需段落圖像，請使用 [Paragraph.getImage]。

## **常見問題**

**我能完全停用文字框內的換行嗎？**

可以。將 [TextFrameFormat.setWrapText] 設為停用，即可關閉換行，使行不會在文字框邊緣斷行。

**如何取得特定段落在投影片上的精確邊界？**

使用 [Paragraph.getRect] 取得段落的邊界矩形。 [Portion.getRect] 可取得單一文字片段的邊界。

**段落對齊（左、右、置中或兩端對齊）在何處設定？**

[ParagraphFormat.setAlignment] 為段落層級設定，會套用於整段文字，不受單一文字片段格式的影響。

**我能為段落的一部分設定校對語言嗎？**

可以。對個別文字片段設定 [BasePortionFormat.setLanguageId]，即可讓同一段落包含多種語言的文字。