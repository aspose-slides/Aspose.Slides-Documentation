---
title: 在 .NET 中為簡報新增浮水印
linktitle: 浮水印
type: docs
weight: 40
url: /zh-hant/net/watermark/
keywords:
- 浮水印
- 文字浮水印
- 圖像浮水印
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
description: "在 .NET 中管理 PowerPoint 與 OpenDocument 簡報的文字與圖像浮水印，以標示草稿、機密資訊、版權等。"
---
## **簡介**

**浮水印** 在簡報中是一種文字或圖像標記，可套用於單一投影片或整份簡報的所有投影片。通常，浮水印用於表示簡報為草稿（例如「Draft」浮水印）、包含機密資訊（例如「Confidential」浮水印）、指明所屬公司（例如「Company Name」浮水印）、辨識簡報作者等。浮水印有助於透過表明簡報不應被複製來防止版權侵害。浮水印同時適用於 PowerPoint 與 OpenDocument 簡報格式。在 Aspose.Slides 中，您可以在 PowerPoint PPT、PPTX 以及 OpenDocument ODP 檔案格式中加入浮水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/net/) 中，有多種方法可以在 PowerPoint 或 OpenDocument 文件中建立浮水印，並調整其設計與行為。共同點是，若要加入文字浮水印，應使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 介面；若要加入圖片浮水印，則使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pictureframe/) 類別或以圖片填充浮水印形狀。`PictureFrame` 實作了 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape) 介面，讓您能使用形狀物件的所有彈性設定。由於 `ITextFrame` 不是形狀且其設定受限，會被包裝成一個 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape) 物件。

浮水印的套用方式有兩種：套用於單一投影片或套用於整份簡報的所有投影片。使用投影片母片（Slide Master）可將浮水印套用至所有投影片——浮水印會被加入至投影片母片，於該處完整設計，並套用至所有投影片，同時不會影響個別投影片上浮水印的修改權限。

浮水印通常被視為不允許其他使用者編輯。為防止浮水印（或更確切地說是浮水印的父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。特定形狀可以在一般投影片或投影片母片上被鎖定。當浮水印形狀在投影片母片上被鎖定時，所有簡報投影片的該形狀亦會被鎖定。

您可以為浮水印設定名稱，以便未來若需刪除時，能依名稱在投影片的形狀集合中找到它。

浮水印的設計方式不限，但通常會具備一些共通特性，例如置中對齊、旋轉、前置等。我們將在下方範例中說明如何使用這些特性。

## **文字浮水印**

### **將文字浮水印加入投影片**

在 PPT、PPTX 或 ODP 中加入文字浮水印時，您可以先在投影片上新增一個形狀，然後在該形狀中加入文字框。文字框由 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe) 介面表示。此類型並未繼承自具有彈性定位屬性的 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)；因此，會將 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe) 物件包裝在 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 物件中。要將浮水印文字加入形狀，請使用下方示範的 [AddTextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/methods/addtextframe) 方法。

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// 將浮水印加入投影片。
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="另請參閱" %}} 
- [如何使用 TextFrame 類別？](/slides/zh-hant/net/text-formatting/)
{{% /alert %}}

### **將文字浮水印加入簡報**

如果您想將文字浮水印加入整份簡報（即一次性套用於所有投影片），請將其加入 [MasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masterslide/)。其餘邏輯與在單一投影片中加入浮水印相同——建立一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 物件，然後使用 [AddTextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/methods/addtextframe) 方法將浮水印加入其中。

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// 將浮水印加入母片。
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="另請參閱" %}} 
- [如何使用投影片母片？](/slides/zh-hant/net/slide-master/)
{{% /alert %}}

### **設定浮水印形狀透明度**

預設情況下，矩形形狀會套用填充色與線條色。這意味著加入浮水印時，可能會出現實心背景或框線，進而分散投影片內容的注意力。為確保浮水印保持低調且不影響簡報的視覺設計，您可以將形狀完全設為透明。

以下程式碼透過移除填充色與邊框色，使形狀變為透明：

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **設定文字浮水印的字型**

在將文字浮水印套用至投影片之前，先自訂其外觀以符合整體設計是很重要的。您可以變更字型與大小，以確保浮水印既清晰可讀又具美觀。自訂字型亦有助於強化品牌識別或僅僅是配合簡報風格。

以下程式碼片段示範如何透過選取特定的拉丁字型並設定適當的字型高度，來調整浮水印的字型設定：

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **設定浮水印文字顏色**

在套用浮水印之前，必須確保文字顏色適當設定，使其能與投影片內容融合而不顯得突兀。調整顏色的透明度（alpha）以及紅、綠、藍分量，可建立一個細緻、半透明且不干擾的浮水印。此方式有助於維持觀眾對主要簡報內容的關注，同時保護您的內容。

要設定浮水印文字的顏色，請使用以下程式碼：

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **將文字浮水印置中**

正確地將文字浮水印置中，可顯著提升簡報的整體美感，確保浮水印在投影片尺寸任意的情況下皆位於對稱位置。此作法不僅讓投影片呈現專業外觀，也確保浮水印不會干擾投影片的主要內容。

以下程式碼片段示範如何計算投影片的中心位置，並相應地放置文字浮水印：

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

![文字浮水印](text_watermark.png)

## **圖片浮水印**

### **將圖片浮水印加入簡報**

在許多情況下，圖片浮水印可提供獨特的品牌元素或比文字浮水印更具視覺吸引力的替代方案。加入浮水印前，請確保圖片檔案已備妥（例如提供透明度的 PNG）。以下範例示範如何從檔案系統載入圖片、將其加入簡報，並透過形狀的填充屬性將其設為浮水印。

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **鎖定浮水印以防編輯**

若需防止浮水印被編輯，可在形狀上使用 [IAutoShape.ShapeLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/properties/shapelock) 屬性。透過此屬性，您可保護形狀免於被選取、調整大小、重新定位、與其他元素群組、鎖定其文字編輯等多種操作：

```cs
// 鎖定浮水印形狀以防止修改.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **將浮水印置於前景**

在 Aspose.Slides 中，可透過 [IShapeCollection.Reorder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/reorder/#reorder) 方法設定形狀的 Z 順序。要執行此操作，需從簡報的投影片清單呼叫此方法，並傳入形狀參考與其順序編號。如此即可將形狀移至前景或送至背後。若需要將浮水印放在簡報前方，此功能特別有用：

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **設定浮水印旋轉**

調整浮水印的旋轉角度可大幅提升簡報的視覺衝擊與低調感。例如，斜對角的浮水印不會過於侵入，同時仍能提供強大的未授權使用防護。以下範例根據投影片尺寸計算適當的角度，使浮水印呈對角線排列於投影片上。此動態計算確保浮水印在不同投影片大小下皆保持有效。

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **為浮水印設定名稱**

Aspose.Slides 允許您為形狀設定名稱。使用形狀名稱，可在未來存取該形狀以進行修改或刪除。要為浮水印形狀設定名稱，請將其指派給 [IAutoShape.Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/name) 屬性：

```cs
watermarkShape.Name = "watermark";
```

## **移除浮水印**

若要移除浮水印形狀，請使用 [IAutoShape.Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/name) 屬性於投影片形狀中尋找它。之後，將浮水印形狀傳入 [IShapeCollection.Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/remove/) 方法：

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **即時範例**

您可能想查看 **Aspose.Slides 免費** 的 [Add Watermark](https://products.aspose.app/slides/zh-hant/watermark) 與 [Remove Watermark](https://products.aspose.app/slides/zh-hant/watermark/remove-watermark) 線上工具。

![線上添加與移除浮水印工具](online_tools.png)

## **常見問題**

**什麼是浮水印？為什麼要使用它？**

浮水印是套用於投影片上的文字或圖像覆蓋層，可協助保護智慧財產、提升品牌辨識度，或防止簡報被未授權使用。

**我可以將浮水印加入簡報的所有投影片嗎？**

可以，Aspose.Slides 允許您以程式方式將浮水印加入簡報的每一張投影片。您可以遍歷所有投影片，逐一套用浮水印設定。

**如何調整浮水印的透明度？**

您可透過修改形狀的填充設定（[FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/fillformat/)）來調整浮水印的透明度，確保浮水印細緻且不會分散投影片內容的注意力。

**支援哪些影像格式作為浮水印？**

Aspose.Slides 支援多種影像格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自訂文字浮水印的字型與樣式嗎？**

可以，您可以選擇任意字型、大小與樣式，以符合簡報的設計並保持品牌一致性。

**如何變更浮水印的位置或方向？**

您可透過程式修改形狀的座標、大小與旋轉屬性，以調整浮水印的位置或方向。