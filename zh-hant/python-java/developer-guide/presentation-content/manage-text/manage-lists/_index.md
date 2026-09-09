---
title: 使用 Python via Java 管理簡報中的項目符號與編號清單
linktitle: 管理清單
type: docs
weight: 60
url: /zh-hant/python-java/manage-lists/
keywords:
- 項目符號
- 項目符號清單
- 編號清單
- 符號項目符號
- 圖片項目符號
- 自訂項目符號
- 多層級清單
- 建立項目符號
- 新增項目符號
- 新增清單
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Python via Java 在 PowerPoint 與 OpenDocument 簡報中建立與格式化項目符號清單、圖片項目符號、多層級清單與編號清單。"
---
## **概述**

Aspose.Slides for Python via Java 讓您在 PowerPoint 與 OpenDocument 簡報中建立與格式化項目符號與編號清單。清單項目是一個段落，其項目符號設定由段落格式控制。

使用 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/#getParagraphFormat) 方法存取段落層級的清單設定。主要入口是 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getBullet)，它會回傳一個 [BulletFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/) 物件。透過此物件，您可以設定項目符號類型、符號、圖片、顏色、大小、編號樣式以及起始編號。

This article shows how to:

- 建立具有自訂符號的項目符號清單
- 建立圖片項目符號
- 透過設定段落深度建立多層級清單
- 建立編號清單
- 檢查並變更現有簡報中的清單格式

## **建立項目符號清單**

要建立項目符號清單，將 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/) 物件加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/)，並將 [BulletFormat.setType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/#setType) 設為 [BulletType.Symbol](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bullettype/#Symbol)。之後您可以使用 [BulletFormat.setChar](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/#setChar)、[BulletFormat.getColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/#getColor) 與 [BulletFormat.setHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/#setHeight) 來控制項目符號的外觀。

以下 Python 程式碼示範如何在投影片上建立項目符號清單：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![符號項目符號](symbol_bullets.png)

## **建立編號清單**

當項目順序很重要時，請使用編號清單。將 [BulletFormat.setType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/#setType) 設為 [BulletType.Numbered](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bullettype/#Numbered)。您也可以使用 [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) 來選擇編號格式，或在清單起始編號不是 1 時使用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith)。

以下 Python 程式碼示範如何在投影片上建立編號清單：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![編號項目符號](numbered_bullets.png)

## **建立圖片項目符號**

Aspose.Slides 允許您將一般的項目符號替換為影像。圖片項目符號最適合使用簡單且在小尺寸下仍可辨識的圖像，例如圖示或小型透明 PNG 檔案。

{{% alert color="info" title="Note" %}}
如果您打算將一般項目符號替換為影像，請選擇具有透明背景的簡易圖形。此類影像適合作為自訂項目符號。

請留意影像會被縮小到非常小的尺寸。因此，我們強烈建議選擇在清單項目符號中仍能保持清晰且具視覺效果的圖像。
{{% /alert %}}

要建立圖片項目符號，先將影像加入 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages)，並把返回的影像物件指派給 [BulletFormat.getPicture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/#getPicture)。在指派影像之前，先將 [BulletFormat.setType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bulletformat/#setType) 設為 [BulletType.Picture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bullettype/#Picture)。

假設我們有一個名為 "image.png" 的影像：

![用於項目符號的圖片](picture_for_bullets.png)

以下 Python 程式碼示範如何在投影片上建立圖片項目符號：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![圖片項目符號](picture_bullets.png)

## **建立多層級清單**

使用 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setDepth) 可以將清單項目放置於不同層級。層級 0 為最上層，層級 1 為其下的子層，依此類推。

以下 Python 程式碼示範如何建立多層級項目符號清單：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![多層級清單](multilevel_list.png)

## **變更現有清單**

若要變更現有簡報中的清單格式，請存取目標段落並更新其 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getBullet) 設定。建立清單時使用的相同屬性也可用於檢查或修改從 PPT、PPTX 或 ODP 檔案載入的清單。

以下 Python 程式碼將文字框中的第一個段落變更為使用編號清單樣式：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**是否可以將項目符號與編號清單匯出為 PDF 或影像？**

是。當目標格式支援相應的文字版面配置與項目符號功能時，Aspose.Slides 會保留清單格式。

**我可以編輯現有簡報中的清單嗎？**

是。載入簡報，存取目標段落，檢查或更新其 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getBullet) 設定，然後儲存簡報。

**清單可以包含非拉丁文字嗎？**

是。清單項目的文字可以包含 Unicode 字元，您因此可以在多語言簡報中建立清單。請確保簡報中使用的字型支援您所需的字元。