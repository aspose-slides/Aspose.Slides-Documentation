---
title: 在 Python 中為簡報加入浮水印
linktitle: 浮水印
type: docs
weight: 40
url: /zh-hant/python-net/watermark/
keywords:
- 浮水印
- 文字浮水印
- 影像浮水印
- 新增浮水印
- 變更浮水印
- 移除浮水印
- 刪除浮水印
- 新增浮水印至 PPT
- 新增浮水印至 PPTX
- 新增浮水印至 ODP
- 從 PPT 移除浮水印
- 從 PPTX 移除浮水印
- 從 ODP 移除浮水印
- 從 PPT 刪除浮水印
- 從 PPTX 刪除浮水印
- 從 ODP 刪除浮水印
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Python 中於 PowerPoint 與 OpenDocument 簡報中管理文字與影像浮水印，以標示草稿、機密資訊、版權等多種情況。"
---
## **介紹**

**浮水印** 在簡報中是用於投影片或整個簡報的文字或影像標記。通常，浮水印用來表示簡報是草稿（例如「Draft」浮水印）、含有機密資訊（例如「Confidential」浮水印）、說明所屬公司（例如「Company Name」浮水印）、辨識簡報作者等。浮水印透過表明簡報不應被複製，協助防止版權侵害。浮水印同時支援 PowerPoint 與 OpenOffice 簡報格式。於 Aspose.Slides 中，您可以為 PowerPoint PPT、PPTX 以及 OpenOffice ODP 檔案格式加入浮水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/python-net/)，有多種方式可以在 PowerPoint 或 OpenOffice 文件中建立浮水印，並修改其設計與行為。共同點是，若要新增文字浮水印，應使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 類別；若要新增影像浮水印，則使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 類別或以影像填充浮水印形狀。`PictureFrame` 實作 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 類別，允許您使用形狀物件的所有彈性設定。由於 `TextFrame` 不是形狀且其設定受限，會被包裝成 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 物件。

浮水印的套用方式有兩種：套用於單一投影片或套用於所有簡報投影片。使用投影片母版 (Slide Master) 可將浮水印套用到所有簡報投影片——浮水印會加入投影片母版，在母版上完整設計後，套用至所有投影片，同時不影響個別投影片對浮水印的修改權限。

浮水印通常被視為不允許其他使用者編輯。為了防止浮水印（或其父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。特定形狀可以在普通投影片或投影片母版上被鎖定。當浮水印形狀在投影片母版上被鎖定時，所有簡報投影片的該形狀皆會被鎖定。

您可以為浮水印設定名稱，未來若要刪除浮水印時，可依名稱在投影片的形狀集合中找到它。

浮水印的設計方式多樣；然而，浮水印通常具備的共通特徵包括置中對齊、旋轉、前置等。我們將在以下範例中說明如何運用這些特性。

## **文字浮水印**

### **將文字浮水印新增至單一投影片**

若要在 PPT、PPTX 或 ODP 中新增文字浮水印，您可以先在投影片上加入形狀，然後在該形狀上加入文字框。文字框由 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 類別表示。此類別未繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/)，因此缺乏彈性定位的屬性。為了在形狀中使用文字框，會將 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 物件包裝在 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 物件中。使用以下方式的 [add_text_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/add_text_frame/#str) 方法，即可將浮水印文字加入形狀。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="另見" %}} 
- [如何使用 TextFrame 類別](/slides/zh-hant/python-net/text-formatting/)
{{% /alert %}}

### **將文字浮水印新增至整個簡報**

若要一次為整個簡報（即所有投影片）新增文字浮水印，請將其加入至 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslide/)。其餘邏輯與在單一投影片加入浮水印相同——建立一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 物件，然後使用 [add_text_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/add_text_frame/#str) 方法將浮水印加入其中。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="另見" %}} 
- [如何使用投影片母版](/slides/zh-hant/python-net/slide-master/)
{{% /alert %}}

### **設定浮水印形狀的透明度**

預設情況下，矩形形狀會設定填充色與線條顏色。以下程式碼可使形狀變為透明。

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **設定文字浮水印的字型**

您可以如下面範例所示變更文字浮水印的字型。

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **設定浮水印文字的顏色**

欲設定浮水印文字顏色，請使用以下程式碼：

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **置中文字浮水印**

您可以將浮水印置於投影片中央，做法如下：

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

以下圖示展示最終結果。

![文字浮水印](text_watermark.png)

## **影像浮水印**

### **將影像浮水印新增至簡報**

要在簡報投影片中加入影像浮水印，您可以執行下列程式碼：

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **防止浮水印被編輯**

若需防止浮水印被編輯，請於形狀上使用 [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/auto_shape_lock/) 屬性。透過此屬性，您可以保護形狀免於被選取、調整大小、重新定位、與其他元素群組、鎖定文字編輯等：

```py
# 鎖定浮水印形狀以防止修改
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **將浮水印移至最上層**

在 Aspose.Slides 中，可透過 [ShapeCollection.reorder](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) 方法設定形狀的 Z 序。您需要從簡報投影片清單呼叫此方法，並傳入形狀參考與其排序編號，即可將形狀提升至前景或送至背景。此功能在需要將浮水印放置於簡報最上層時特別有用：

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **設定浮水印的旋轉角度**

以下程式碼示範如何調整浮水印的旋轉，使其斜向跨越投影片：

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **為浮水印設定名稱**

Aspose.Slides 允許您為形狀設定名稱。透過形狀名稱，未來即可存取、修改或刪除該形狀。要為浮水印形狀設定名稱，請將其指派給 [AutoShape.name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/name/) 屬性：

```py
watermark_shape.name = "watermark"
```

## **移除浮水印**

若要移除浮水印形狀，先使用 [AutoShape.name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/name/) 方法在投影片形狀集合中找到它，然後將該形狀傳入 [ShapeCollection.remove](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/remove/#ishape) 方法：

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **線上範例**

您可以試用 **Aspose.Slides 免費** [加入浮水印](https://products.aspose.app/slides/zh-hant/watermark) 與 [移除浮水印](https://products.aspose.app/slides/zh-hant/watermark/remove-watermark) 線上工具。

![線上加入與移除浮水印的工具](online_tools.png)

## **常見問題集**

**什麼是浮水印，為什麼要使用它？**

浮水印是套用在投影片上的文字或影像覆層，可保護智慧財產、提升品牌識別度，或防止未經授權使用簡報。

**我可以將浮水印套用至簡報的所有投影片嗎？**

可以，Aspose.Slides 允許您將浮水印加入每一張投影片。您可以遍歷所有投影片，個別套用浮水印設定。

**如何調整浮水印的透明度？**

您可以透過修改形狀的填充設定（[FillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/)）來調整浮水印的透明度，確保浮水印不會干擾投影片內容。

**支援哪些影像格式作為浮水印？**

Aspose.Slides 支援多種影像格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自訂文字浮水印的字型與樣式嗎？**

可以，您可以選擇任意字型、大小與樣式，以符合簡報設計與品牌一致性。

**如何變更浮水印的位置或方向？**

您可以透過修改 [shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 的座標、大小與旋轉屬性，來調整浮水印的位置與方向。