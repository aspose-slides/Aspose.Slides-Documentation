---
title: Hantera bildtransformeringseffekter i presentationer med .NET
linktitle: Bildtransformeringseffekter
type: docs
weight: 11
url: /sv/net/image-transform-effects/
keywords:
- bildtransformering
- bildeffekt
- ljusstyrka
- kontrast
- gråskala
- duoton
- nyans
- HSL
- färgersättning
- oskärpa
- transparens
- alfaeffekt
- effektkedja
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Applicera, kedja, inspektera, ta bort och verifiera bildtransformeringseffekter för bildramar med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides representerar bildjusteringar som en ordnad samling av bildtransformeringsoperationer. För en bildram, börja med ramens [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) och få åtkomst till [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/). Den returnerade [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) låter dig lägga till, enumerera, inspektera, ta bort och rensa effekter utan att skriva om de ursprungliga bildbytena.

Denna artikel demonstrerar ett komplett arbetsflöde för ljusstyrka och kontrast, färgtransformeringar, oskärpa, transparens, ordnade effektkedjor, effektiva värden, borttagning och PPTX‑rundresan‑verifiering.

## **Förstå äganderätt för effekter och återanvändning av bilder**

En bildresurs och bilden som visar den är olika objekt:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) lagrar eller refererar källdatabilden som ägs av presentationen.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) tillhör en bildfyllning och refererar till en bildresurs samtidigt som den lagrar samlingen av bildtransformeringar.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) är bildformen på bilden som äger den relevanta bildfyllningen, geometri, beskärningsinställningar och annan ram‑nivå‑formatering.

Därför modifierar bildtransformeringsoperationer inte bytena i [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). När samma `IPPImage` skickas till [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) mer än en gång, får varje ny bildram sin egen `ISlidesPicture` och sin egen transform‑samling. Att applicera gråskala på en ram gör inte de andra ramarna gråskala, även om alla återanvänder samma inbäddade bildresurs.

Samma `ISlidesPicture.ImageTransform`‑modell används också av andra bildfyllningar, såsom en form eller bildbakgrund. Exemplen nedan fokuserar på bildramar.

## **Använd giltiga parameterintervall och enheter**

De demonstrerade metoderna använder följande semantiska intervall och enheter. Håll dig inom dessa intervall även om en viss biblioteksversion inte omedelbart förkastar varje värde utanför intervallet; målformatet för presentationen kan normalisera, utelämna eller förkasta ogiltig data vid sparande eller när PowerPoint öppnar filen.

| Operation | Parametrar | Giltigt intervall och enhet |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` till `100`, procent; `0` lämnar komponenten oförändrad. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Inga numeriska parametrar. Alfa förblir oförändrad. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Två färger för mörka respektive ljusa pixlar. RGB‑ och alfan kanaler i `System.Drawing.Color` använder `0` till `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Nyans är `0` inkl. till `360` excl., i grader; mängd är `-100` till `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Nyans är `0` inkl. till `360` excl., i grader; färgmättnad och luminans är `-100` till `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Ersättningsfärgen använder kanalvärden från `0` till `255`. Befintliga alfavärden förblir oförändrade. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radien är icke‑negativ och mäts i punkter; `grow` är en Boolean som styr om oskarpt innehåll får utvidgas utanför de ursprungliga gränserna. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Icke‑negativ procent. Använd `0` till `100` för vanlig opacitets‑skalning: `0` är helt transparent och `100` bevarar befintlig alfa. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` till `100`, procent opacitet. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` till `100`, procent alfatreshold. Värden under blir transparenta; värden på eller över blir ogenomskinliga. |

För fast alfa‑modulering är transparens och opacitet komplementära. Till exempel motsvarar 35 % transparens ett alfa‑moduleringsvärde på 65 %.

## **Applicera ljusstyrka och kontrast**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) returnerar en [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)‑operation. Dess skalära inställningar anges när operationen skapas. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) returnerar beräknade skrivskyddade värden som kan inspekteras eller loggas.

Följande exempel ökar ljusstyrkan med 15 % och kontrasten med 20 %, och renderar sedan en förhandsgranskning utan att ändra den inbäddade bilden:

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

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) är en Office‑2010‑bild‑effekt‑utökning och är mindre portabel än den standardiserade DrawingML‑luminans‑effekten. När ljusstyrka och kontrast måste förbli redigerbara efter en PPTX‑rundresa, använd [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) och verifiera resultatet efter att filen öppnats igen. Avsnittet om formatbegränsningar förklarar detta i mer detalj.

## **Applicera färgtransformeringar**

Färgeffekter kan appliceras oberoende på olika bildramar som återanvänder en bildresurs. Följande exempel skapar fem ramar och applicerar gråskala, duoton, nyans, HSL‑justering och färgersättning.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) innehåller två oberoende redigerbara färgparametrar: `Color1` mappar mörka pixlar, medan `Color2` mappar ljusa pixlar. Detta gör den till ett användbart exempel på en effekt vars inställningar är mer komplexa än ett enda skalärt värde.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) ersätter varje pixels färg med en fast färg samtidigt som alfa bevaras. Den skiljer sig från [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), som mappar en källfärg till en annan och exponerar både käll‑ och mål‑färgformat.

### **Applicera en luminans‑threshold**

En luminans‑threshold kan göra svaga märken på en skannad sida lättare att urskilja från bakgrunden. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) bevarar mellansteg av grått. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) mappar luminans till svart eller vitt, medan [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) tillämpar en tröskel på opacitet.

Luminans‑thresholden sträcker sig från 0 % till 100 %, inklusivt. Pixlar under tröskeln blir svarta. Pixlar på eller över blir vita. Att höja tröskeln gör fler nyanser svarta eftersom fler faller under avbrottet.

Ladda ner [grayscale-swatches.png](grayscale-swatches.png) till arbetskatalogen. Varje etikett visar den ursprungliga grå nivån på en skala från 0 till 255. Exemplet placerar originalet bredvid två kopior och sparar varje kopias tröskel i presentationen.

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

Öppna den resulterande presentationen i PowerPoint för att jämföra de tre ramarna. Swatchen som är märkt 96 har cirka 38 % luminans (96 av 255). Den blir vit vid 20 %‑thresholden och svart vid 60 %‑thresholden.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Lägg till oskärpa, transparens och alfa‑effekter**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) påverkar alla färgkanaler, inklusive alfa. Sätt `grow` till `true` när den oskarpa kanten kan sträcka sig utanför de ursprungliga bildgränserna.

För enhetlig transparens, använd [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Den multiplicerar varje befintligt alfavärde, så delvis transparenta pixlar förblir proportionellt olika. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) tilldelar i stället ett alfavärde till alla pixlar. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) konverterar alfa till två nivåer baserat på en tröskel.

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

Andra parametrar‑fria alfa‑operationer inkluderar [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), som gör varje icke‑noll alfa fullt ogenomskinlig; [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), som gör varje alfa under 100 % helt transparent; och [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), som byter alfa till `100% - alpha`.

## **Bygg en ordnad effektkedja**

Varje `Add...Effect`‑metod lägger till en ny operation i slutet av samlingen. Renderaren använder samlingen som en ordnad pipeline: resultatet från operation 0 blir indata för operation 1, och så vidare. Följaktligen kan samma operationer i en annan ordning ge en annan bild.

Till exempel tar gråskala följt av nyans först bort kromatisk information och färglägger sedan luminansresultatet. Nyans följt av gråskala tar bort nyansen igen. På samma sätt kan alfaversättnings‑operationer skriva över alfa‑värden beräknade av tidigare operationer, medan alfa‑modulering bevarar deras relativa skillnader.

Följande exempel bygger en kedja med fyra operationer, sparar den som PPTX, öppnar presentationen igen, kontrollerar både operationstyper och deras ordning, och renderar det återöppnade resultatet:

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

Samlingen påtvingar inte en kompatibilitets‑matris som begränsar färg‑, alfa‑ och oskärpa‑operationer till separata kedjor. De kan kombineras, men kombinationer är inte alltid användbara. En fast färgersättning tar bort RGB‑variation som skapats av tidigare färgeffekter; gråskala efter duoton tar bort de två valda färgerna; och alfa‑ceiling, floor, replacement eller bi‑level‑operationer kan kassera alfa‑detalj som skapats tidigare. Bygg kedjan enligt den önskade pixel‑bearbetningssekvensen snarare än att behandla dess element som oordnade formateringsflaggor.

<!-- visual-explanation:image-transform-effects:start -->
[![Samma bild passerar genom gråskala och sedan nyans, och nyans och sedan gråskala. De två slutgiltiga gråskalebilderna har olika toner.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*I denna illustrativa Aspose.Slides för .NET 26.11‑rendering lämnar en 220°‑nyans vid 25 % den gråskalade bilden oförändrad. Att applicera samma nyans före gråskala ger olika toner.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspektera redigerbara och effektiva värden**

En redigerbar operation är objektet som lagras i `ISlidesPicture.ImageTransform`. Beroende på effekten kan den exponera skrivbara medlemmar direkt. Till exempel exponerar [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) skrivbara `Radius` och `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) exponerar skrivbar `Amount`, och [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) exponerar skrivbar `Threshold`. Färgeffekter som [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) exponerar muterbara [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/)‑objekt.

Vissa operations‑gränssnitt, inklusive [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/) och [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), exponerar inte sina skapande‑skalare som skrivbara egenskaper. För att ändra dessa inställningar, ta bort operationen och lägg till en ersättare på den önskade positionen.

Effektiva data som returneras av `GetEffective()` är beräknade och skrivskyddade. De är användbara för att lösa temaberoende färger och läsa de normaliserade värden som renderaren använder, men de är inte en annan redigeringsyta. Följande exempel enumererar kedjan och inspekterar effektiva värden där motsvarande API tillhandahåller dem:

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

Parametrar‑fria effekter som gråskala, alfa‑ceiling och alfa‑inverse har fortfarande ett effektivt‑data‑objekt, men det finns inga skalära inställningar att skriva ut. Deras närvaro och position i samlingen är den viktiga informationen.

## **Ta bort eller rensa bildtransformeringar**

Använd [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) för att ta bort en operation efter index. Eftersom index skiftar efter borttagning, sök först efter målet och ta sedan bort det efter enumeration. Använd `Clear()` för att ta bort hela kedjan.

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

Att ta bort eller rensa transformeringar ändrar bara bildformateringen. Det raderar inte, komprimerar om eller förändrar på annat sätt den återanvända [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)‑resursen.

## **Överväg presentationsformat och exportmål**

Bildtransformeringar har sitt ursprung i DrawingML, så PPTX är det föredragna redigerbara formatet för effektkedjor. Även med PPTX har inte varje operation identisk portabilitet:

- Standard‑DrawingML‑operationer såsom luminans, gråskala, duoton, nyans, HSL, oskärpa och vanliga alfa‑operationer har störst chans att överleva en PPTX‑rundresa. Öppna alltid den genererade filen igen och inspektera samlingen när bevarande är ett krav.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) är en Office‑2010‑utökning snarare än standard‑DrawingML‑luminans‑operationen. Den kan användas för rendering i minnet, men den garanteras inte att förbli en redigerbar [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) efter sparande och återöppning av PPTX. Föredra [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) för bestående ljusstyrke‑ och kontrastjusteringar.
- Det binära PPT‑formatet föregick den fullständiga DrawingML‑effektmodellen. Sparning till PPT kan utelämna ej‑stödda operationer, reducera en kedja till ett stödjat delmängd, eller approximera utseendet. Använd inte PPT som verifieringsformat för en komplex redigerbar kedja.
- Rendering till PNG, JPEG, TIFF, PDF, SVG, HTML eller annat visuellt utdata applicerar den stödjade kedjan på den renderade bilden. Dessa utdata innehåller ingen redigerbar `IImageTransformOperationCollection`; rasterformat plattar ut resultatet till pixlar, och dokument‑/vektor‑exporter lagrar sin egen renderingsrepresentation.
- Effekter gör inte en länkad bild självbärande. Rendering av en länkad bild beror fortfarande på att den länkade resursen är tillgänglig när presentationen läses in.

Olika presentationskonsumenter kan rendera kantfall olika, särskilt när flera alfa‑ eller färg‑kvantisering‑operationer kombineras. För kritisk output, testa både den redigerbara rundresan och det slutliga exportformatet med samma Aspose.Slides‑version som används i produktion.

## **FAQ**

**Modifierar bildtransformeringseffekter den inbäddade bilddatan?**

Nej. Operationerna tillhör den `ISlidesPicture` som används av bildfyllningen. De underliggande `IPPImage`‑bytena förblir oförändrade.

**Delar två bildramar som återanvänder samma bild sina effekter?**

Nej. Återanvändning av en `IPPImage` undviker duplicerad bilddata, men varje bildram har normalt en separat `ISlidesPicture` och bildtransformeringssamling.

**Kan färg‑, oskärpa‑ och alfa‑effekter kombineras?**

Ja. Samlingen accepterar dem i en ordnad kedja. Överväg vad varje operation gör med resultatet från den föregående eftersom ersättnings‑ och tröskel‑operationer kan kassera tidigare färg‑ eller alfatDetaljer.

**Varför är effektiva värden skrivskyddade?**

Effektiva data representerar beräknade värden som används för rendering, inklusive lösta färger. Redigera den operation som lagras i transform‑samlingen där skrivbara medlemmar finns; annars ta bort den och lägg till en ersättare med nya skapande‑parametrar.

**Vilket format bör jag använda för att bevara en transform‑kedja?**

Använd PPTX och verifiera filen genom att öppna den igen. Äldre PPT kan inte representera hela DrawingML‑effektmodellen, och renderade exportformat bevarar bara utseendet snarare än redigerbara transform‑operationer.