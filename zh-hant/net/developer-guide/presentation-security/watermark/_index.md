---
title: 為 .NET 簡報新增浮水印
linktitle: 浮水印
type: docs
weight: 40
url: /zh-hant/net/watermark/
keywords:
- 浮水印
- 文字浮水印
- 圖片浮水印
- 新增浮水印
- 變更浮水印
- 移除浮水印
- 刪除浮水印
- 將浮水印新增至 PPT
- 將浮水印新增至 PPTX
- 將浮水印新增至 ODP
- 從 PPT 移除浮水印
- 從 PPTX 移除浮水印
- 從 ODP 移除浮水印
- 從 PPT 刪除浮水印
- 從 PPTX 刪除浮水印
- 從 ODP 刪除浮水印
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中管理 PowerPoint 與 OpenDocument 簡報的文字與圖片浮水印，以標示草稿、機密資訊、版權等。"
---
## **簡介**

**浮水印** 在簡報中是用於投影片或整個簡報的文字或圖像標記。通常，浮水印用來表示簡報為草稿（例如「草稿」浮水印）、包含機密資訊（例如「機密」浮水印）、指示所屬公司（例如「公司名稱」浮水印）、標示簡報作者等。浮水印可以透過顯示不應被複製的訊息，協助防止版權侵害。浮水印同時支援 PowerPoint 與 OpenDocument 簡報格式。於 Aspose.Slides 中，您可以在 PowerPoint PPT、PPTX 與 OpenDocument ODP 檔案中加入浮水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/net/)，提供多種方式在 PowerPoint 或 OpenDocument 文件中建立浮水印，並可修改其外觀與行為。共同點是：若要加入文字浮水印，應使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 介面；若要加入圖片浮水印，則使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 類別或以圖片填充浮水印形狀。`PictureFrame` 實作了 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape) 介面，讓您能使用形狀物件的全部彈性設定。由於 `ITextFrame` 不是形狀且設定受限，它會被包裝成一個 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape) 物件。

浮水印的套用方式有兩種：套用於單一投影片或套用於所有投影片。使用投影片母片（Slide Master）即可將浮水印套用至所有投影片——浮水印會被加入母片、在母片上完成設計，並套用至所有投影片，同時不會影響在個別投影片上修改浮水印的權限。

浮水印通常被視為不允許其他使用者編輯。為防止浮水印（或更確切說是浮水印的父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。可於一般投影片或投影片母片上鎖定特定形狀。當浮水印形狀在母片上被鎖定時，所有投影片的該形狀皆會被鎖定。

您可以為浮水印設定名稱，之後如需刪除時，可依名稱在投影片的形狀集合中找到它。

浮水印的設計方式多樣；不過，浮水印通常具備一些共通特徵，例如置中對齊、旋轉、置於最前等。以下範例將說明如何使用這些特性。

## **文字浮水印**

### **將文字浮水印新增至投影片**

要在 PPT、PPTX 或 ODP 中加入文字浮水印，首先需要在投影片上新增一個形狀，然後在該形狀上新增文字框。文字框由 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe) 介面表示。此類型未繼承自 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)，而 IShape 提供了大量屬性以彈性定位浮水印。因此，將 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe) 物件包裝在 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 物件中。要在形狀上加入浮水印文字，可使用 [AddTextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/methods/addtextframe) 方法，如下所示。

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// 將浮水印新增至投影片。
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="See also" %}} 
- [如何使用 TextFrame 類別?](/slides/zh-hant/net/text-formatting/)
{{% /alert %}}

### **將文字浮水印新增至整份簡報**

若要將文字浮水印新增至整個簡報（即一次套用至所有投影片），請將其加入 [MasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masterslide/)。其餘邏輯與在單一投影片上加入浮水印相同——建立一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 物件，然後使用 [AddTextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/methods/addtextframe) 方法將浮水印加入其中。

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// 將浮水印新增至母片。
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="See also" %}} 
- [如何使用投影片母片?](/slides/zh-hant/net/slide-master/)
{{% /alert %}}

### **設定浮水印形狀透明度**

預設情況下，矩形形狀會具備填充色與線條色。這表示加入浮水印時，可能會出現實心背景或邊框，進而分散投影片內容的注意力。為了確保浮水印保持低調且不干擾視覺設計，可將形狀的填充與邊框顏色皆移除，使其完全透明。

以下程式碼示範透過移除填充與邊框顏色，使形狀變為透明：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **設定文字浮水印的字型**

在將文字浮水印套用至投影片之前，先自訂其外觀，以符合整體設計風格。您可以變更字型與字體大小，確保浮水印既易讀又具美感。自訂字型也有助於加強品牌識別或配合簡報風格。

以下程式碼片段示範如何透過選取特定的拉丁字型並設定適當的字體高度，來調整浮水印的字型設定：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **設定浮水印文字顏色**

在套用浮水印之前，務必確保文字顏色設定得當，使其與投影片內容融合而不至於過於突兀。調整顏色的透明度（Alpha）以及紅、綠、藍三個分量，即可打造出微妙、半透明且仍可辨識的浮水印。此做法可在保護內容的同時，維持觀眾對主要簡報的專注。

設定浮水印文字顏色的程式碼如下：

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **將文字浮水印置中**

將文字浮水印正確置中，可顯著提升簡報的整體美感，確保浮水印在投影片任意尺寸下均保持對稱位置。此作法不僅讓投影片更具專業感，亦避免浮水印干擾投影片的主要內容。

下面的程式碼示範如何計算投影片的中心位置，並相應地放置文字浮水印：

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

下圖顯示最終效果。

![The text watermark](text_watermark.png)

## **圖片浮水印**

### **將圖片浮水印新增至簡報**

在許多情況下，圖片浮水印可提供獨特的品牌元素，或成為比文字浮水印更具視覺吸引力的替代方案。加入浮水印前，請先確保圖檔已備妥（例如支援透明度的 PNG）。以下範例示範如何從檔案系統載入圖像、將其加入簡報，並透過形狀的填充屬性將其設定為浮水印。

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **防止浮水印被編輯**

若需防止浮水印被編輯，可於形狀上使用 [IAutoShape.ShapeLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/properties/shapelock) 屬性。透過此屬性，您可以保護形狀不被選取、調整大小、重新定位、與其他元素群組、鎖定其文字編輯等：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// 鎖定浮水印形狀以防止修改。
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **將浮水印移至最前層**

在 Aspose.Slides 中，可透過 [IShapeCollection.Reorder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/reorder/#reorder) 方法設定形狀的 Z 軸順序。只要從簡報的投影片集合呼叫此方法，並傳入形狀參考與其順序編號，即可將形狀移至最前或送到最背後。此功能在需要將浮水印放在簡報最上層時特別有用：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **設定浮水印旋轉角度**

調整浮水印的旋轉角度，可大幅提升簡報的視覺衝擊與隱蔽性。例如，對角線的浮水印較不會干擾內容，同時仍具備有效的防護作用。以下範例依據投影片尺寸計算適當的角度，使浮水印斜跨投影片。此動態計算可確保在不同投影片大小下，浮水印皆保持預期效果。

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **為浮水印設定名稱**

Aspose.Slides 允許您為形狀設定名稱。利用形狀名稱，可在未來存取該形狀以進行修改或刪除。要為浮水印形狀設定名稱，請將其指派給 [IAutoShape.Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/name) 屬性：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **移除浮水印**

若要移除浮水印形狀，請先利用 [IAutoShape.Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/name) 屬性在投影片形狀集合中找到該形狀，然後將其傳入 [IShapeCollection.Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/remove/) 方法：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **線上範例**

您可以試用 **Aspose.Slides free** 的線上工具 [Add Watermark](https://products.aspose.app/slides/zh-hant/watermark) 與 [Remove Watermark](https://products.aspose.app/slides/zh-hant/watermark/remove-watermark)。

![Online tools to add and remove watermarks](online_tools.png)

## **常見問題集**

### 什麼是浮水印，為什麼要使用它？

浮水印是一種加於投影片上的文字或圖像覆蓋層，可協助保護智慧財產、提升品牌辨識度，或防止簡報未經授權的使用。

### 能否一次將浮水印加入簡報的所有投影片？

可以，Aspose.Slides 允許您以程式方式把浮水印加入簡報的每一張投影片，您只需遍歷所有投影片並個別套用浮水印設定。

### 如何調整浮水印的透明度？

您可以透過修改形狀的填充設定（[FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/fillformat/)）來調整浮水印的透明度，確保浮水印不會分散投影片內容的注意力。

### 支援哪些圖片格式作為浮水印？

Aspose.Slides 支援多種圖片格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

### 我可以自訂文字浮水印的字型與樣式嗎？

可以，您可以選擇任意字型、大小與樣式，以符合簡報設計並維持品牌一致性。

### 如何變更浮水印的位置或朝向？

您可以透過程式修改形狀的座標、大小與旋轉屬性，來調整浮水印的定位與方向。