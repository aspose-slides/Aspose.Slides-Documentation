---
title: 在 .NET 中管理簡報的圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/net/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 內嵌圖片
- 連結圖片
- 擷取圖片
- 點陣圖
- SVG 圖片
- 裁切圖片
- 刪除裁切區域
- 壓縮圖片
- StretchOffset
- 圖片框格式化
- 相對縮放
- 圖片效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在簡報中建立、格式化、連結、裁切、擷取與壓縮圖片框。"
---
## **概述**

圖片框是一種在投影片上顯示圖片的形狀。在 Aspose.Slides 中，圖片資源與顯示它的形狀是分開的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 透過其 [Images](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/images/) 集合擁有內嵌圖片資源，而一個 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 則控制圖片的位置、大小、線條格式、旋轉、裁切、圖片效果以及其他框級設定。

當同一張圖片需要顯示多次時，這種分離非常有用。只需將圖片加入簡報一次，保留回傳的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/)，在建立圖片框時重複使用該圖片資源。

圖片框可以包含 PNG、JPEG 等點陣圖，也可以包含 SVG 向量圖。它們也可以參照連結圖片，而不是將圖片位元組儲存於簡報內。此選擇會影響可移植性、檔案大小、擷取與匯出行為，因此在套用格式或最佳化之前，先決定圖片的儲存方式是很重要的。

## **新增與格式化內嵌圖片**

對於內嵌圖片，將圖片資料加入簡報，然後使用 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addpictureframe/) 建立圖片框。圖片會成為簡報套件的一部份，因而在移至其他電腦時仍保持自給自足。

以下範例加入 JPEG 圖片、以圖片原始尺寸建立框，並套用線條格式與旋轉：

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

圖片框控制顯示的幾何形狀；變更框的尺寸不會改變內嵌圖片資源中儲存的原始像素尺寸。此區別在之後裁切或壓縮圖片時相當重要。

## **使用相對縮放**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 提供相對寬度與高度的縮放設定。`1.0` 代表 100% 的原始圖片大小。當工作流程需要保留與來源圖片尺寸的比例關係，而不是手動計算最終尺寸時，相對縮放非常有用。

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

相對縮放只會變更框的縮放設定；不會重新取樣或壓縮內嵌圖片。

## **內嵌與連結圖片**

內嵌圖片將圖像資料儲存於簡報內，是可移植性與可預測呈現的最安全選擇。連結圖片則透過 [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidespicture/) 的連結路徑指向外部位置，而不是將圖像資料內嵌。

連結圖片可以減少 PPTX 中的圖像資料量，但會產生外部相依性。開啟或呈現簡報的應用程式必須能存取該連結檔案。若路徑變更、檔案移動或資源無法取得，連結圖片可能無法如預期顯示。對於必須以電子郵件傳送、保存或在孤立環境中呈現的簡報，內嵌圖片通常較為可靠。

### **新增連結圖片**

以下範例建立圖片框並指向本機圖檔。此範例僅處理圖片連結；影片連結屬於其他媒體工作流程，故未混入此例。

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

當外部檔案管理是有意為之時才使用連結。不要僅將其當作壓縮的替代方案：一個因斷裂相依性而無法顯示的輕量 PPTX，通常比一個較大且自給自足的簡報更沒用。

## **從圖片框擷取圖片**

在從現有簡報擷取圖片之前，先確認形狀實際上是 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 且包含內嵌圖片。連結圖片框可能不含可直接擷取的圖像位元組。

### **擷取點陣圖**

新版圖像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/)，不需舊的系統圖像封裝。以下範例在投影片上找到第一個內嵌點陣圖並以 PNG 儲存：

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

透過 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 儲存會將擷取的圖像轉換為要求的輸出格式。如果需要的是簡報中儲存的編碼位元組而非已轉換的點陣檔，請直接使用圖像資源的二進位資料。

### **擷取 SVG 圖片**

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

將 SVG 內容保留為 SVG 可以在簡報中保留向量來源。PNG、JPEG 等光柵匯出必然將向量內容渲染成像素。PDF 或 SVG 投影片匯出同樣是渲染動作，因此匯出的圖形不應被視為原始內嵌 SVG 的逐位元拷貝；在需要原始向量資源時，請使用內嵌的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 資料。

## **裁切圖片**

裁切會改變在框內可見的圖像區域。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/) 的裁切值是相對於來源圖片尺寸的百分比。裁切不會立即從內嵌圖片中刪除隱藏的像素，只是改變可見區域。

以下範例安全地找到圖片框並套用裁切值：

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

因為隱藏的圖像資料仍然存在，之後仍可變更裁切而不會遺失原始像素。若檔案大小比可逆性更重要，則可如下一節所述實際移除裁切區域。

## **移除裁切圖像資料**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 會移除目前裁切矩形之外的圖像資料，並回傳結果圖像資源。此操作可減少檔案大小，但屬於破壞性最佳化：簡報儲存後，被移除的像素將無法再進行取消裁切的操作。

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

此方法可能會在簡報中新增一個圖像資源。若原始圖片同時被其他圖片框使用，這些框仍需要其既有資源，因此刪除裁切區域不一定會減少圖像總數。使用此方法裁切 WMF 或 EMF 內容會將裁切結果光柵化為 PNG。

## **壓縮點陣圖**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/compressimage/) 會根據圖片顯示的尺寸降低點陣圖解析度，亦可同時移除裁切區域。當圖像被重新調整大小或裁切時，方法會回傳 `true`；若未需變更則回傳 `false`。

當標準目標解析度足夠時，可使用預先定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/picturescompression/) 值：

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

若需要特定目標解析度，也可以傳入自訂的正 DPI 數值取代列舉。

壓縮僅適用於點陣圖。SVG 與圖形檔內容不會受到此點陣壓縮工作流程的影響。同時要記得，較低的解析度與已刪除的裁切區域無法從最佳化後的簡報中回復。請根據圖像實際顯示或匯出的最大尺寸來選擇目標解析度，而不是全局套用最低 DPI。

## **檢查圖片效果**

圖片效果儲存在框所使用的圖片上。影像變換集合可以包含透明度的固定 alpha 調變以及亮度的明暗對比等效果。以下範例安全地從投影片上第一個圖片框讀取兩種效果：

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

這些效果會改變圖片在框中呈現的方式；不會重新寫入原始內嵌圖片的位元組。

## **鎖定圖片框幾何形狀**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframelock/) 設定控制哪些編輯操作會被禁用。例如，比例鎖定在調整大小時會保留形狀的比例。

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

此鎖定套用於圖片框形狀本身，並不會強制對來源圖片重新取樣或永久改變其比例。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/) 上的 stretch‑offset 值會相對於圖片框的邊界盒定義填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁切不同。裁切值決定來源圖片的哪個部分可見；stretch offset 則改變可見圖片填充被拉伸到的矩形。

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

使用 stretch offset 來調整填充位置；使用裁切屬性則是為了隱藏來源圖片的邊緣。

## **儲存、檔案大小與匯出考量**

當將圖像儲存與圖片框格式分開處理時，主要的取捨更容易掌握：

- **內嵌圖片** 使簡報自給自足，且在分享與伺服器端渲染時最可靠；但大型點陣圖會增加 PPTX 大小與記憶體使用量。
- **連結圖片** 可以縮小套件大小，但簡報依賴外部檔案必須保持於存放路徑或位置可存取。
- **裁切** 起初是非破壞性的。隱藏的像素會一直保留，直至明確刪除裁切區域或在壓縮時移除。
- **壓縮** 能大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上最終顯示尺寸後再執行。
- **SVG 圖片** 若向量保真度重要，應保持為 SVG。需要向量資源時直接擷取內嵌的 SVG。光柵匯出（如 PNG、JPEG）始終會將 SVG 轉換為像素。PDF 或 SVG 投影片匯出同樣是渲染動作。
- **重複圖片** 應盡可能重使用既有的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 資源，而不是在工作流程中多次載入相同檔案。

對於大型簡報，圖像最佳化最有效的做法通常是選擇性執行：將標誌與圖表保留為向量內容，根據實際顯示尺寸壓縮照片，僅在不需日後編輯時移除裁切像素，並避免使用外部連結，除非相依性管理是部署設計的一部份。

## **常見問答**

**圖片框與圖片資源有何差異？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 代表與簡報關聯的圖片資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 是投影片上的形狀，用於顯示圖片並儲存框級的幾何與格式，例如大小、旋轉、裁切值、效果與鎖定。

**應該內嵌還是連結圖片？**

當簡報必須具備可移植性、存檔或在沒有外部資源的情況下渲染時，請內嵌圖片。僅在有意將圖片檔案保留在 PPTX 之外且外部位置能可靠維護時才使用連結。

**裁切會減小 PPTX 檔案大小嗎？**

單純的裁切不會。一般裁切設定只會隱藏來源圖片的一部分，但仍保留底層像素。若想永久移除這些像素，請使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 或在壓縮時一起移除裁切區域。

**壓縮後能恢復圖片品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁切區域會捨棄圖像資料。若日後可能需要高解析度編輯，請在簡報之外保留原始來源圖片。

**SVG 圖片該如何處理？**

當向量保真度重要時，保持 SVG 內容為 SVG。內嵌的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 可直接擷取。將投影片渲染為 PNG、JPEG 等光柵格式時，SVG 會被光柵化。

**如何避免在讀取現有投影片時的 unsafe cast？**

在使用圖片框專屬成員之前，先檢查形狀類型。使用 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 的模式匹配或以該介面過濾形狀集合，可避免無效的轉型，並讓程式碼能妥善處理不含圖片框的投影片。