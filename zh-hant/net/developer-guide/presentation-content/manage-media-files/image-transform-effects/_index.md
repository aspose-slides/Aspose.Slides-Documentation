---
title: 使用 .NET 在簡報中管理影像變換效果
linktitle: 影像變換效果
type: docs
weight: 11
url: /zh-hant/net/image-transform-effects/
keywords:
- 影像變換
- 圖片效果
- 亮度
- 對比度
- 灰階
- 雙調
- 色調
- HSL
- 顏色取代
- 模糊
- 透明度
- Alpha 效果
- 效果鏈
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 套用、串聯、檢查、移除及驗證圖片框的影像變換效果。"
---
## **概覽**

Aspose.Slides 將圖片調整表示為有序的影像變換作業集合。對於圖片框，先從框架的 [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidespicture/) 開始，並存取 [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidespicture/imagetransform/)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/) 允許您在不重新寫入原始影像位元組的情況下加入、列舉、檢查、移除和清除效果。

本文章示範完整的工作流程，包括亮度與對比度、顏色轉換、模糊、透明度、有序效果鏈、有效值、移除，以及 PPTX 循環驗證。

## **了解效果所有權與影像重用**

影像資源與顯示它的圖片是不同的物件：

- [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 儲存或參照簡報所擁有的來源影像資料。
- [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidespicture/) 屬於圖片填充，參照影像資源，同時保存影像變換集合。
- [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 是投影片形狀，擁有相關的圖片填充、幾何、裁剪設定以及其他框架層級的格式。

因此，影像變換作業不會修改 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 中的位元組。當同一個 `IPPImage` 被多次傳遞給 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addpictureframe/) 時，每個新圖片框都會取得自己的 `ISlidesPicture` 與自己的變換集合。對其中一個框套用灰階不會使其他框變為灰階，即使它們共用相同的嵌入式影像資源。

相同的 `ISlidesPicture.ImageTransform` 模型也用於其他圖片填充，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用以下語意範圍與單位。即使特定函式庫版本不會立即拒絕每一個超出範圍的值，也請保持在這些範圍內；目標簡報格式可能會在儲存時或 PowerPoint 開啟檔案時正規化、省略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` 至 `100`，百分比；`0` 表示元件保持不變。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | 無 | 無數值參數。Alpha 保持不變。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 用於深色與淺色像素的兩種顏色。`System.Drawing.Color` 中的 RGB 與 Alpha 通道使用 `0` 至 `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相 `hue` 為包含 `0` 至不含 `360` 的度數；`amount` 為 `-100` 至 `100`，百分比。 |
| [AddHSLEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相 `hue` 為包含 `0` 至不含 `360` 的度數；飽和度與亮度為 `-100` 至 `100`，百分比。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 替換顏色的通道值使用 `0` 至 `255`。現有的 Alpha 值保持不變。 |
| [AddBlurEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半徑為非負值，單位為點；`grow` 為布林值，決定模糊內容是否可延伸至原始邊界之外。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負百分比。使用 `0` 至 `100` 進行一般的不透明度縮放：`0` 為完全透明，`100` 保留現有 Alpha。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` 至 `100`，百分比不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` 至 `100`，百分比 Alpha 閾值。低於此值的變為透明；等於或高於此值的變為不透明。 |

對於固定的 Alpha 調變，透明度與不透明度是互補的。例如，35% 的透明度對應於 65% 的 Alpha 調變量。

## **套用亮度與對比度**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) 會傳回一個 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/ibrightnesscontrast/) 作業。其純量設定在建立作業時即提供。[IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/brightnesscontrast/geteffective/) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比度提升 20%，然後在不修改嵌入式影像的情況下呈現預覽：

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 圖片效果的擴充，較標準 DrawingML 亮度效果的可移植性差。當亮度與對比度必須在 PPTX 循環後仍可編輯時，請使用 [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 並在重新開啟檔案後驗證結果。格式限制部分會更詳細說明此差異。

## **套用顏色轉換**

顏色效果可以獨立套用於重用同一影像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色取代。

[IDuotone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iduotone/) 包含兩個可獨立編輯的顏色參數：`Color1` 對應暗像素，`Color2` 對應亮像素。這使它成為一個設定較為複雜、超過單一純量值的範例。

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) 會將每個像素的顏色替換為固定顏色，同時保留 Alpha。它不同於 [AddColorChangeEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)，後者將一個來源顏色映射到另一個目標顏色，並同時公開來源與目標的顏色格式。

## **添加模糊、透明度與 Alpha 效果**

[AddBlurEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) 會影響所有顏色通道，包括 Alpha。當模糊邊緣可能超出原始圖片邊界時，將 `grow` 設為 `true`。

若需均勻透明度，請使用 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)。它會乘以每個現有的 Alpha 值，使部分透明像素保持比例差異。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) 則會將所有像素指派為同一 Alpha 值。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 會根據閾值將 Alpha 轉為兩個層級。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

其他無參數的 Alpha 作業包括 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)，會將每個非零 Alpha 設為完全不透明；[AddAlphaFloorEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)，會將低於 100% 的 Alpha 全部設為完全透明；以及 [AddAlphaInverseEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)，會將 Alpha 變為 `100% - alpha`。

## **建立有序的效果鏈**

每個 `Add...Effect` 方法皆會將新作業附加至集合的末端。渲染器將集合視為有序管線：作業 0 的輸出成為作業 1 的輸入，依此類推。因此，同樣的作業若以不同順序排列，可能產生不同的影像。

例如，先套用灰階再套用色調，會先移除色彩資訊再重新上色；相反地，先套用色調再套用灰階，會再次移除色調。類似地，Alpha 取代會覆寫先前作業計算的 Alpha，而 Alpha 調變則保留它們的相對差異。

以下範例建立四段作業鏈，儲存為 PPTX，重新開啟簡報，檢查作業類型與順序，並呈現重新開啟的結果：

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

此集合不會強制相容性矩陣以限制顏色、Alpha 與模糊作業必須分開鏈結。它們可以組合使用，但組合未必都有意義。固定的顏色取代會移除先前色彩效果產生的 RGB 變化；在雙調之後再套用灰階會移除兩種選取的顏色；Alpha ceiling、floor、replace 或 bi‑level 作業則可能捨棄先前產生的 Alpha 細節。請依據所需的像素處理順序建構鏈結，而非將其視為無序的格式旗標。

## **檢查可編輯與有效值**

可編輯的作業是儲存在 `ISlidesPicture.ImageTransform` 中的物件。根據效果的不同，它可能直接公開可寫成員。例如，[IBlur](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iblur/) 會公開可寫的 `Radius` 與 `Grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/ialphamodulatefixed/) 會公開可寫的 `Amount`，以及 [IAlphaBiLevel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/ialphabilevel/) 會公開可寫的 `Threshold`。像 [IDuotone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iduotone/) 這類顏色效果會公開可變更的 [IColorFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icolorformat/) 物件。

某些作業介面（包含 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/itint/)、以及 [IAlphaReplace](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/ialphareplace/)）不會將其建立時的純量以可寫屬性公開。若要變更這些設定，請先移除該作業，然後在所需位置加入新的作業取代。

`GetEffective()` 回傳的有效資料為計算後的唯讀值。它對於解析主題相關顏色與讀取渲染器使用的正規化值很有幫助，但並非另一個編輯介面。以下範例列舉鏈結並在相應的 API 提供時檢查有效值：

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

雖然無參數的效果（如灰階、Alpha ceiling、Alpha inverse）仍有有效資料物件，但沒有可列印的純量設定。它們在集合中的存在與位置即為重要資訊。

## **移除或清除影像變換**

使用 [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) 可依索引移除單一作業。因為移除後索引會移位，請先搜尋目標作業，再在列舉完畢後移除。使用 `Clear()` 可移除整個鏈結。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

移除或清除變換只會更改圖片格式，並不會刪除、重新壓縮或以其他方式改變被重用的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 資源。

## **考慮簡報格式與匯出目標**

影像變換源自 DrawingML，因此 PPTX 是效果鏈的首選可編輯格式。即使使用 PPTX，也不是每個作業都有相同的可移植性：

- 標準 DrawingML 作業（如亮度、灰階、雙調、色調、HSL、模糊與常見 Alpha 作業）最有可能在 PPTX 循環後仍保留。若需保留，請在產生檔案後重新開啟並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/brightnesscontrast/) 為 Office 2010 的擴充，而非標準 DrawingML 亮度作業。它可用於記憶體內渲染，但在儲存並重新開啟 PPTX 後不保證仍為可編輯的 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/ibrightnesscontrast/)。請使用 [AddLuminanceEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 以獲得持久的亮度與對比度調整。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的作業、將鏈結縮減為支援子集，或近似其外觀。不要將 PPT 用作複雜可編輯鏈結的驗證格式。
- 輸出為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺格式時，會將支援的鏈結套用至渲染結果。這些輸出不含可編輯的 `IImageTransformOperationCollection`；點陣格式會將結果平鋪成像素，文件/向量匯出則保存其自己的渲染表示。
- 效果不會使連結影像變成自包含。渲染連結圖片仍需在載入簡報時取得連結資源。

不同的簡報消費者可能會對邊緣案例有不同的呈現，特別是當多個 Alpha 或顏色量化作業結合時。對於關鍵輸出，請使用與生產環境相同的 Aspose.Slides 版本，測試可編輯的循環以及最終匯出格式。

## **常見問題**

**影像變換效果會修改嵌入的影像資料嗎？**

不會。這些作業屬於圖片填充使用的 `ISlidesPicture`。底層的 `IPPImage` 位元組保持不變。

**兩個重用同一影像的圖片框會共享它們的效果嗎？**

不會。重用 `IPPImage` 可避免重複的影像資料，但每個圖片框通常都有各自的 `ISlidesPicture` 與影像變換集合。

**顏色、模糊與 Alpha 效果可以結合使用嗎？**

可以。集合接受它們在同一有序鏈結中。請考慮每個作業對前一作業輸出的影響，因為取代與閾值作業可能會捨棄先前的顏色或 Alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表用於渲染的計算值，包括解析後的顏色。請在變換集合中編輯具有可寫成員的作業；若無可寫成員，則必須移除該作業並以新建立參數的取代作業重新加入。

**應使用哪種格式來保留變換鏈？**

使用 PPTX 並透過重新開啟驗證檔案。舊版 PPT 無法完整表示 DrawingML 效果模型，而渲染匯出格式僅保留外觀，無法保存可編輯的變換作業。