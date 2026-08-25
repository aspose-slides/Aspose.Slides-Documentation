---
title: 在 .NET 簡報中管理圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/net/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 內嵌影像
- 連結影像
- 擷取影像
- 點陣影像
- SVG 影像
- 裁切影像
- 刪除已裁切區域
- 壓縮影像
- StretchOffset
- 圖片框格式設定
- 相對比例縮放
- 影像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在簡報中建立、格式化、連結、裁切、擷取與壓縮圖片框。"
---
## **概觀**

圖片框是用來顯示影像的投影片形狀。在 Aspose.Slides 中，影像資源與顯示它的形狀是分開的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 透過其 [Images](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/images/) 集合擁有內嵌的影像資源，而 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 控制影像的位置、大小、線條格式、旋轉、裁切、圖片效果以及其他框架層級的設定。

此分離在同一張影像需要顯示多次時非常有用。將影像加入簡報一次，保留回傳的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/)，在建立圖片框時重複使用該影像資源。

圖片框可以包含 PNG、JPEG 等點陣圖，也可以包含 SVG 向量圖。它們也可以指向連結的影像，而不是將影像位元組儲存在簡報中。選擇哪種方式會影響可攜性、檔案大小、擷取與匯出行為，因此在套用格式或最佳化之前，先決定影像的儲存方式是很重要的。

## **加入與格式化內嵌影像**

對於內嵌影像，將影像資料加入簡報，並使用 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addpictureframe/) 建立圖片框。影像會成為簡報套件的一部份，讓簡報在搬移至其他電腦時仍保持自給自足。

以下範例加入 JPEG 影像，依影像原始尺寸建立框架，並套用線條格式與旋轉：

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

圖片框控制顯示的幾何形狀；變更框架大小不會改變儲存在內嵌影像資源中的原始像素維度。此區別在之後裁切或壓縮影像時變得重要。

## **使用相對比例縮放**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 提供框架的相對寬度與高度縮放。`1.0` 的值對應於原始圖片大小的 100%。當工作流程需要保留與來源影像大小的關係，而非手動計算最終尺寸時，相對縮放非常有用。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

相對縮放會變更框架的縮放設定；它不會重新取樣或壓縮內嵌影像。

## **內嵌與連結影像**

內嵌圖片將影像資料儲存在簡報內，因而是最安全的可攜性與可預測渲染選擇。連結圖片則透過 [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidespicture/) 的連結路徑指向外部位置，而非將影像資料嵌入。

連結影像可以減少 PPTX 中的影像資料量，但會產生外部相依性。連結檔案必須在開啟或渲染簡報的應用程式仍可存取。若路徑變更、檔案移動或資源無法取得，連結圖片可能無法如預期顯示。對於必須透過電郵、存檔或在隔離環境中渲染的簡報，內嵌影像通常較為可靠。

### **新增連結影像**

以下範例建立圖片框，並指向本機影像檔。它僅處理影像連結；影片連結屬於另一個媒體工作流程，故未混入此範例。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

在有意進行外部檔案管理時使用連結。不要僅將其當作壓縮的替代方案：一個帶有破損影像相依性的較小 PPTX 通常比一個較大且自給自足的簡報更沒用。

## **從圖片框擷取影像**

在從現有簡報擷取影像之前，先確認形狀實際上是 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 且包含內嵌影像。連結圖片框可能不含可直接擷取的影像位元組。

### **擷取點陣圖**

現代影像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/)，不再需要舊的系統影像封裝。以下範例在投影片上找到第一個內嵌點陣圖片，並將其儲存為 PNG：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

透過 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 儲存會將擷取的影像轉換為指定的輸出格式。如果需要的是儲存在簡報中的編碼位元組，而非已轉換的點陣檔，請直接使用影像資源的二進位資料。

### **擷取 SVG 影像**

對於 SVG 圖片，[IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 會公開一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 物件。這讓您能直接取得 SVG 資料，而不必先將圖片光柵化。

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

將 SVG 內容保留為 SVG 可以在簡報中保存向量來源。PNG 或 JPEG 等點陣匯出必然會將向量內容渲染為像素。PDF 或 SVG 投影片匯出同樣是渲染操作，因此匯出的圖形不應被視為原始內嵌 SVG 的逐位元拷貝；當需要原始向量資源時，請使用內嵌的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 資料。

## **裁切影像**

裁切會變更影像在框架內可見的區域。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/) 上的裁切值是相對於來源影像尺寸的百分比。裁切不會立即從內嵌影像中刪除隱藏的像素，只是改變可見區域。

以下範例安全地取得圖片框，並套用裁切值：

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

因為隱藏的影像資料仍然存在，之後仍可變更裁切而不會遺失原始像素。若檔案大小比可逆性更重要，可如下一節所述實際移除裁切區域。

## **移除已裁切的影像資料**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 會移除當前裁切矩形之外的影像資料，並返回新的影像資源。此操作可減少檔案大小，但屬於破壞性最佳化：簡報儲存後，移除的像素將無法再進行取消裁切。

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

此方法可能會在簡報中加入新的影像資源。如果原始影像同時被其他圖片框使用，這些框仍需保留其現有資源，因此刪除裁切區域不一定會減少總影像數量。使用此方法裁切 WMF 或 EMF 內容會將裁切結果光柵化為 PNG。

## **壓縮點陣影像**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/compressimage/) 會相對於圖片顯示尺寸降低點陣影像的解析度。它也可以在同一次操作中移除已裁切的區域。當影像被重新調整大小或裁切時，方法會回傳 `true`；若未需要變更則回傳 `false`。

當標準目標解析度足以時，可使用預定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/picturescompression/) 值：

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

若需要特定目標，可傳入自訂的正 DPI 數值取代列舉。

壓縮僅適用於點陣影像。SVG 與圖形檔案不會因此光柵壓縮工作流程而縮小。另外，請記得較低的解析度與已刪除的裁切區域無法從最佳化後的簡報中復原。應根據影像實際被檢視或匯出的最大尺寸來選擇目標解析度，而非全域套用最低 DPI。

## **管理影像變換效果**

完整涵蓋亮度、對比、顏色變換、模糊、Alpha 效果、排序鏈、檢查、移除與往返驗證的工作流程，請參考 [Image Transform Effects](/slides/zh-hant/net/image-transform-effects/)。

## **鎖定圖片框幾何形狀**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframelock/) 設定控制哪些編輯操作會被停用。例如，長寬比鎖定在調整大小時會保留形狀的比例。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

此鎖定套用於圖片框形狀本身，並不會強制將來源影像重新取樣或永久改為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/) 上的 stretch‑offset 值定義相對於圖片框邊界盒的填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁切不同。裁切值決定來源影像哪一部份可見；stretch offset 則改變可見圖片填充被拉伸的矩形。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

使用 stretch offset 來放置填充。若目標是隱藏來源影像的邊緣，請使用裁切屬性。

## **儲存、檔案大小與匯出考量**

將影像儲存與圖片框格式分開處理時，主要的取捨較易管理：

- **內嵌影像** 使簡報自給自足，最適合分享與伺服器端渲染，但大型點陣影像會增加 PPTX 大小與記憶體使用。
- **連結影像** 可讓套件保持較小，但簡報依賴外部檔案必須在指定路徑或位置保持可用。
- **裁切** 最初為非破壞性。隱藏的像素會保留在內嵌影像中，直到明確刪除裁切區域或在壓縮時移除。
- **壓縮** 能大幅減少過大點陣影像的檔案大小，但會犧牲來源解析度。應在確定投影片上最終尺寸後再執行。
- **SVG 影像** 若向量保留很重要，應保持為 SVG。需要向量資源時，直接擷取內嵌的 SVG。光柵化的投影片匯出始終將渲染結果轉為像素。
- **重複使用的影像** 應盡可能重用既有的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 資源，而不是在簡報工作流程中多次載入同一檔案。

對於大型簡報，影像最佳化通常在選擇性執行時最有效：將商標與圖表保留為向量內容，依實際顯示尺寸壓縮照片，只在不需要日後編輯時移除裁切像素，且除非部署設計已考慮相依性管理，否則避免使用外部連結。

## **常見問答**

**圖片框與影像資源有何不同？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 代表與簡報關聯的影像資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 則是投影片上的形狀，用於顯示影像並存儲框架層級的幾何與格式設定，例如大小、旋轉、裁切值、效果與鎖定。

**應該內嵌還是連結影像？**

當簡報必須具備可攜性、存檔或在無外部資源存取的環境中渲染時，請內嵌影像。只有在有意將影像檔案保留在 PPTX 之外且能可靠維護外部位置時，才使用連結影像。

**裁切會減少 PPTX 檔案大小嗎？**

僅靠裁切本身不會。一般的裁切設定會隱藏來源影像的部分，但仍保留底層像素。若要永久移除這些像素，請使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 或在壓縮時同時移除裁切區域。

**壓縮後能恢復影像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁切區域會丟棄影像資料。如果日後需要高解析度編輯，請在簡報外保留原始來源影像。

**SVG 影像該如何處理？**

在向量保真度重要時，保持 SVG 內容為 SVG。內嵌的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 可直接擷取。將投影片渲染為 PNG 或 JPEG 等點陣格式會將 SVG 光柵化。

**如何避免在讀取現有投影片時發生不安全的型別轉換？**

在使用圖片框專屬成員之前，先檢查形狀類型。使用與 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 的模式匹配或依介面過濾形狀集合，可避免無效的轉換，並讓程式碼能正確處理不含圖片框的投影片。