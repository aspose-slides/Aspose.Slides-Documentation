---
title: 使用 .NET 管理簡報中的圖像變換效果
linktitle: 圖像變換效果
type: docs
weight: 11
url: /zh-hant/net/image-transform-effects/
keywords:
- 圖像變換
- 圖片效果
- 亮度
- 對比度
- 灰階
- 雙色調
- 色調
- HSL
- 顏色替換
- 模糊
- 透明度
- Alpha 效果
- 效果鏈
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 套用、串聯、檢查、移除並驗證圖片框的圖像變換效果。"
---
## **概觀**

Aspose.Slides 將圖片調整表示為有序的圖像變換操作集合。對於圖片框，首先取得框架的 [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) 並存取 [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) 讓您可以在不重新寫入原始圖像位元組的情況下，新增、列舉、檢查、移除以及清除效果。

本文示範了關於亮度與對比度、顏色轉換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 往返驗證的完整工作流程。

## **了解效果的擁有權與圖像重用**

圖像資源與顯示它的圖片是不同的物件：

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 儲存或參照由簡報擁有的來源圖像資料。
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) 屬於圖片填充，參考圖像資源，同時保存圖像變換集合。
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) 是擁有相關圖片填充、幾何形狀、裁剪設定以及其他框架層級格式設定的投影片形狀。

因此，圖像變換操作不會修改 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 中的位元組。當相同的 `IPPImage` 多次傳遞給 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) 時，每個新圖片框都會收到自己的 `ISlidesPicture` 與自己的變換集合。對其中一個框套用灰階不會讓其他框也變為灰階，即使它們都重用相同的內嵌圖像資源。

相同的 `ISlidesPicture.ImageTransform` 模型也會被其他圖片填充使用，例如形狀或投影片背景。以下範例專注於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用下列語意範圍與單位。即使特定函式庫版本不會立即拒絕每個超出範圍的值，也請將數值保持在這些範圍內；目標簡報格式可能在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持元件不變。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | 無 | 無數值參數。Alpha 保持不變。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 兩種顏色分別用於暗像素與亮像素。`System.Drawing.Color` 中的 RGB 與 Alpha 通道使用 `0` 到 `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相 `hue` 為包含 `0` 至不含 `360` 的度數；`amount` 為 `-100` 到 `100` 的百分比。 |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相 `hue` 為包含 `0` 至不含 `360` 的度數；飽和度與亮度為 `-100` 到 `100` 的百分比。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 替換顏色的通道值使用 `0` 到 `255`；現有 Alpha 值保持不變。 |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半徑為非負，以點為單位；`grow` 為布林值，控制模糊內容是否可延伸超出原始邊界。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負百分比。使用 `0` 到 `100` 進行一般不透明度縮放：`0` 表示完全透明，`100` 保留現有 Alpha。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` 到 `100`，百分比 Alpha 門檻。低於此值的像素變為透明，等於或高於此值的像素變為不透明。 |

對於固定 Alpha 調變，透明度與不透明度是互補的。例如，35% 透明度對應的 Alpha 調變量為 65%。

## **套用亮度與對比度**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) 會回傳一個 [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) 操作。其純量設定在建立操作時提供。[IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提高 15%，對比度提高 20%，然後在不修改內嵌圖像的情況下呈現預覽：

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

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 圖片效果擴充，不如標準 DrawingML 亮度效果具可移植性。當亮度與對比度必須在 PPTX 往返後仍保持可編輯時，請使用 [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 並在重新開啟檔案後驗證結果。格式限制部分會更詳細說明此差異。

## **套用顏色轉換**

顏色效果可以獨立套用於重用同一圖像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙色調、色調、HSL 調整與顏色替換。

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) 包含兩個可獨立編輯的顏色參數：`Color1` 對應暗像素，`Color2` 對應亮像素。這使它成為一個設定比單一純量更複雜的效果範例。

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) 會將每個像素的顏色替換為固定顏色，同時保留 Alpha。它不同於 [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)，後者會將一個來源顏色映射到另一個顏色，並同時公開來源與目標的顏色格式。

### **套用亮度門檻**

亮度門檻可以讓掃描頁面上淡淡的痕跡更易於與背景區分。[AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) 會保留中間的灰階層次。[AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) 會將亮度映射為黑或白，而 [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 則對不透明度套用門檻。

亮度門檻的範圍為 0% 到 100%，含端點。低於門檻的像素變為黑色；等於或高於門檻的像素變為白色。提升門檻會使更多色階變黑，因為更多像素落在截斷點以下。

下載 [grayscale-swatches.png](grayscale-swatches.png) 到工作目錄。每個標籤顯示 0 到 255 之間的原始灰階等級。範例將原始圖放在兩個副本旁邊，並在簡報中儲存每個副本的門檻。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

在 PowerPoint 中開啟輸出簡報以比較三個框。標記為 96 的樣本大約有 38% 亮度（96 / 255）。在 20% 門檻時變白，在 60% 門檻時變黑。

![原始灰階樣本與亮度門檻 20% 與 60% 的黑白結果並排](luminance-threshold.png)

## **新增模糊、透明度與 Alpha 效果**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) 會影響所有顏色通道，包括 Alpha。當模糊邊緣可能超出原始圖片邊界時，將 `grow` 設為 `true`。

若需均勻透明度，請使用 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)。它會將每個既有 Alpha 值相乘，使部分透明的像素保持比例差異。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) 則會將所有像素指派為同一 Alpha 值。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 會根據門檻將 Alpha 轉為兩個層級。

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

其他無參數的 Alpha 操作包括 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)，會使所有非零 Alpha 完全不透明；[AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)，會使所有低於 100% 的 Alpha 完全透明；以及 [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)，會將 Alpha 變為 `100% - alpha`。

## **建立有序效果鏈**

每個 `Add...Effect` 方法會將新操作附加到集合的末端。渲染器將集合視為有序管線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，相同的操作如果以不同順序排列，會產生不同的圖像。

例如，先執行灰階再色調會先移除色彩資訊，然後為亮度結果重新上色。先執行色調再灰階則會再次移除色調。同理，Alpha 替換可覆寫先前操作計算的 Alpha 值，而 Alpha 調變則保留它們的相對差異。

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

集合並未強加相容性矩陣限制顏色、Alpha 與模糊操作必須分開鏈接。它們可以結合使用，但組合未必都有實用價值。固定顏色替換會移除先前顏色效果產生的 RGB 變化；在雙色調之後再執行灰階會移除兩個選定的顏色；Alpha 天花板、底部、替換或二階效果則可能丟棄先前建立的 Alpha 細節。請依照所需的像素處理順序構建鏈，而非將項目視為無序的格式旗標。

<!-- visual-explanation:image-transform-effects:start -->
[![相同圖像先經過灰階再色調，與先經過色調再灰階。兩個最終的灰階圖像呈現不同色調。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
*在此 Aspose.Slides for .NET 26.11 渲染示例中，220° 色調以 25% 施加於灰階圖像時，灰階圖像保持不變。將相同色調於灰階之前套用會產生不同的色調。*
<!-- visual-explanation:image-transform-effects:end -->

## **檢查可編輯與有效值**

可編輯的操作是儲存在 `ISlidesPicture.ImageTransform` 中的物件。依據效果的不同，它可能會直接公開可寫入的成員。例如，[IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) 會公開可寫入的 `Radius` 與 `Grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) 會公開可寫入的 `Amount`，以及 [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) 會公開可寫入的 `Threshold`。像 [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) 這樣的顏色效果會公開可變的 [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) 物件。

某些操作介面（包括 [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/)、以及 [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/)）不會將其建立時的純量以可寫屬性公開。若要變更這些設定，須先移除該操作，然後在適當位置加入替代操作。

`GetEffective()` 回傳的有效資料是計算後的唯讀值。它對於解析主題相關顏色以及讀取渲染器使用的正規化值很有用，但並非另一個編輯介面。以下範例列舉鏈並在相應的 API 提供時檢查有效值：

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

即使是無參數的效果（如灰階、Alpha 天花板、Alpha 反相）仍會有有效資料物件，只是沒有可列印的純量設定。它們的存在與在集合中的位置即為重要資訊。

## **移除或清除圖像變換**

使用 [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) 依索引移除單一操作。因為移除後索引會改變，請先搜尋目標，再在列舉後移除。使用 `Clear()` 可移除整個鏈。

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

移除或清除變換僅會改變圖片格式，並不會刪除、重新壓縮或以其他方式更改重用的 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 資源。

## **考慮簡報格式與匯出目標**

圖像變換起源於 DrawingML，因此 PPTX 是效果鏈的首選可編輯格式。即使使用 PPTX，也不是每個操作都具有相同的可移植性：

- 標準 DrawingML 操作（如亮度、灰階、雙色調、色調、HSL、模糊以及常見的 Alpha 操作）最有可能在 PPTX 往返後仍然保留。若有保存需求，請務必重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的擴充，而非標準 DrawingML 亮度操作。它可用於記憶體內渲染，但無法保證在儲存並重新開啟 PPTX 後仍以可編輯的 [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) 形式存在。請偏好使用 [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 以永久保持亮度與對比度調整。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作、將鏈縮減為支援的子集，或以近似方式呈現。不要將 PPT 作為複雜可編輯鏈的驗證格式。
- 渲染為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用於渲染結果。這些輸出不會包含可編輯的 `IImageTransformOperationCollection`；點陣圖格式會將結果平坦化為像素，文件/向量匯出則保存其自己的渲染表示。
- 效果不會使已連結的圖像變成自包含。渲染已連結的圖片仍然依賴於載入簡報時可取得的連結資源。

不同的簡報消費端可能在邊緣案例上有不同的呈現，尤其是結合多個 Alpha 或顏色量化操作時。對於關鍵輸出，請使用相同的 Aspose.Slides 版本，同時測試可編輯的往返與最終匯出格式。

## **常見問題**

**影像變換效果會修改內嵌圖像資料嗎？**

不會。這些操作屬於圖片填充使用的 `ISlidesPicture`，底層的 `IPPImage` 位元組保持不變。

**兩個重用同一圖像的圖片框會共享其效果嗎？**

不會。重用 `IPPImage` 可避免重複的圖像資料，但每個圖片框通常都有各自的 `ISlidesPicture` 與圖像變換集合。

**可以組合顏色、模糊與 Alpha 效果嗎？**

可以。集合接受它們在同一有序鏈中。請考慮每個操作對前一個輸出的影響，因為替換與門檻操作可能會丟棄先前的顏色或 Alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括已解析的顏色。請在變換集合中編輯具有可寫成員的操作；若無可寫成員，則必須移除該操作並以新建立參數加入替代。

**應該使用哪種格式才能保留變換鏈？**

使用 PPTX，並在重新開啟檔案後驗證。舊版 PPT 不能完整表示 DrawingML 效果模型，而渲染的匯出格式僅保留外觀，並不保留可編輯的變換操作。