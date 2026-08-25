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
- duotone
- nyans
- HSL
- färgbyte
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

Aspose.Slides representerar bildjusteringar som en ordnad samling av bildtransformeringsoperationer. För en bildram, börja med ramens [ISlidesPicture](https://reference.aspose.com/slides/sv/net/aspose.slides/islidespicture/) och kom åt [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/sv/net/aspose.slides/islidespicture/imagetransform/). Den returnerade [IImageTransformOperationCollection](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/) låter dig lägga till, enumerera, inspektera, ta bort och rensa effekter utan att skriva om de ursprungliga bildbytena.

Denna artikel visar ett komplett arbetsflöde för ljusstyrka och kontrast, färgtransformeringar, oskärpa, transparens, ordnade effektkedjor, effektiva värden, borttagning och PPTX‑rundresan verifiering.

## **Förstå effektägarskap och bildåteranvändning**

En bildresurs och bilden som visar den är olika objekt:

- [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) lagrar eller refererar källdata för bilden som ägs av presentationen.
- [ISlidesPicture](https://reference.aspose.com/slides/sv/net/aspose.slides/islidespicture/) tillhör en bildfyllning och refererar en bildresurs samtidigt som den lagrar bildtransformeringssamlingen.
- [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) är bildens form som äger den relevanta bildfyllningen, geometri, beskärningsinställningar och annan ram‑nivåformatering.

Därför ändrar bildtransformeringsoperationer inte bytena i [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/). När samma `IPPImage` skickas till [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addpictureframe/) fler än en gång, får varje ny bildram sin egen `ISlidesPicture` och sin egen transform‑samling. Att applicera gråskala på en ram gör inte de andra ramarna gråskala, även om alla återanvänder samma inbäddade bildresurs.

Samma `ISlidesPicture.ImageTransform`‑modell används också av andra bildfyllningar, såsom en form eller bildbakgrund. Exemplen nedan fokuserar på bildramar.

## **Använd giltiga parametervärden och enheter**

De demonstrerade metoderna använder följande semantiska intervall och enheter. Håll värdena inom dessa intervall även om en viss biblioteksversion inte omedelbart avvisar varje värde utanför intervallet; målpresentationens format kan normalisera, utelämna eller avvisa ogiltiga data vid sparning eller när PowerPoint öppnar filen.

| Operation | Parametrar | Giltigt intervall och enhet |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` till `100`, procent; `0` lämnar komponenten oförändrad. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Ingen | Inga numeriska parametrar. Alfa förblir oförändrad. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Två färger för mörka respektive ljusa pixlar. RGB‑ och alfabitar i `System.Drawing.Color` använder `0` till `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Nyans är `0` inkl. till `360` excl., i grader; mängd är `-100` till `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Nyans är `0` inkl. till `360` excl., i grader; mättnad och luminans är `-100` till `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Ersättningsfärgen använder kanalvärden från `0` till `255`. Befintliga alfabitar förblir oförändrade. |
| [AddBlurEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radie är icke‑negativ och mäts i punkter; `grow` är en boolesk som styr om oskarpt innehåll får sträcka sig utanför de ursprungliga gränserna. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Icke‑negativ procent. Använd `0` till `100` för vanlig opacitets‑skalning: `0` är helt transparent och `100` bevarar befintlig alfa. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` till `100`, procent opacitet. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` till `100`, procent alfatröskel. Värden under blir transparenta; värden på eller över blir ogenomskinliga. |

För fast alfa‑modulering är transparens och opacitet komplementära. Till exempel motsvarar 35 % transparens en alfa‑moduleringsmängd på 65 %.

## **Applicera ljusstyrka och kontrast**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) returnerar en [IBrightnessContrast](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/ibrightnesscontrast/)‑operation. Dess skalära inställningar anges när operationen skapas. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/brightnesscontrast/geteffective/) returnerar beräknade skrivskyddade värden som kan inspekteras eller loggas.

Följande exempel ökar ljusstyrkan med 15 % och kontrasten med 20 % och renderar sedan en förhandsgranskning utan att ändra den inbäddade bilden:

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

[BrightnessContrast](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/brightnesscontrast/) är en Office 2010‑bild‑effekt‑förlängning och är mindre portabel än den standardiserade DrawingML‑luminans‑effekten. När ljusstyrka och kontrast måste förbli redigerbara efter en PPTX‑rundresa, använd [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) och verifiera resultatet efter att filen har öppnats på nytt. Avsnittet om formatbegränsningar förklarar denna skillnad mer i detalj.

## **Applicera färgtransformeringar**

Färg‑effekter kan appliceras oberoende på olika bildramar som återanvänder en bildresurs. Följande exempel skapar fem ramar och applicerar gråskala, duotone, nyans, HSL‑justering och färg‑ersättning.

[IDuotone](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iduotone/) innehåller två oberoende redigerbara färgparametrar: `Color1` mappar mörka pixlar, medan `Color2` mappar ljusa pixlar. Detta gör den till ett bra exempel på en effekt vars inställningar är mer komplexa än ett enda skalärt värde.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) ersätter varje pixels färg med en fast färg samtidigt som alfa bevaras. Den skiljer sig från [AddColorChangeEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), som mappar en källfärg till en annan och exponerar både käll‑ och mål‑färgformat.

## **Lägg till oskärpa, transparens och alfa‑effekter**

[AddBlurEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) påverkar alla färgkanaler, inklusive alfa. Sätt `grow` till `true` när den oskarpa kanten kan sträcka sig utanför den ursprungliga bildens gränser.

För enhetlig transparens, använd [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Den multiplicerar varje befintligt alfabitar, så delvis transparenta pixlar förblir proportionellt olika. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) tilldelar i stället ett alfabitarvärde till alla pixlar. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) konverterar alfa till två nivåer baserat på en tröskel.

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

Andra alfa‑operationer utan parametrar inkluderar [AddAlphaCeilingEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), som gör varje icke‑noll alfa fullt ogenomskinlig; [AddAlphaFloorEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), som gör varje alfa under 100 % helt transparent; och [AddAlphaInverseEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), som ändrar alfa till `100% - alpha`.

## **Bygg en ordnad effektkedja**

Varje `Add...Effect`‑metod lägger till en ny operation i slutet av samlingen. Renderaren använder samlingen som en ordnad pipeline: utdata från operation 0 blir indata till operation 1, och så vidare. Därför kan samma operationer i olika ordning ge olika bildresultat.

Till exempel tar gråskala följt av nyans först bort kromatisk information och färgar sedan om luminansresultatet. Nyans följt av gråskala tar bort nyansen igen. På liknande sätt kan alfa‑ersättning åsidosätta alfa‑värden beräknade av tidigare operationer, medan alfa‑modulering bevarar deras relativa skillnader.

Följande exempel bygger en kedja med fyra operationer, sparar den som PPTX, öppnar presentationen på nytt, kontrollerar både operationstyperna och deras ordning, och renderar det återöppnade resultatet:

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

Samlingen påtvingar ingen kompatibilitetsmatris som begränsar färg‑, alfa‑ och oskärpe‑operationer till separata kedjor. De kan kombineras, men kombinationerna är inte alltid meningsfulla. En fast färg‑ersättning tar bort RGB‑variation som skapats av tidigare färgeffekter; gråskala efter duotone tar bort de två valda färgerna; och alfa‑tak, golv, ersättning eller två‑nivå‑operationer kan kasta bort alfa‑detaljer som skapats tidigare. Bygg kedjan enligt den önskade pixel‑bearbetningssekvensen snarare än att betrakta dess element som oordnade formateringsflaggor.

## **Inspektera redigerbara och effektiva värden**

En redigerbar operation är objektet lagrat i `ISlidesPicture.ImageTransform`. Beroende på effekt kan den exponera skrivbara medlemmar direkt. Till exempel exponerar [IBlur](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iblur/) skrivbara `Radius` och `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/ialphamodulatefixed/) exponerar skrivbar `Amount`, och [IAlphaBiLevel](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/ialphabilevel/) exponerar skrivbar `Threshold`. Färg‑effekter såsom [IDuotone](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iduotone/) exponerar muterbara [IColorFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/icolorformat/)‑objekt.

Vissa operation‑gränssnitt, inklusive [IBrightnessContrast](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/itint/), och [IAlphaReplace](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/ialphareplace/), exponerar inte sina skapande‑skalare som skrivbara egenskaper. För att ändra dessa inställningar, ta bort operationen och lägg till en ersättare på rätt position.

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

Parameterlösa effekter såsom gråskala, alfa‑tak och alfa‑invers har fortfarande ett effekt‑datobjekt, men det finns inga skalära inställningar att skriva ut. Deras närvaro och position i samlingen är den viktiga informationen.

## **Ta bort eller rensa bildtransformeringar**

Använd [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) för att ta bort en operation efter index. Eftersom index skiftar efter borttagning, sök först efter målet och ta bort det efter enumeration. Använd `Clear()` för att ta bort hela kedjan.

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

Att ta bort eller rensa transformeringar ändrar endast bildformateringen. Det raderar, recomprimerar eller på annat sätt ändrar inte den återanvända [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)‑resursen.

## **Överväg presentationsformat och exportmål**

Bildtransformeringar har sitt ursprung i DrawingML, så PPTX är det föredragna redigerbara formatet för effektkedjor. Även med PPTX har inte varje operation identisk portabilitet:

- Standard‑DrawingML‑operationer såsom luminans, gråskala, duotone, nyans, HSL, oskärpa och vanliga alfa‑operationer har störst chans att överleva en PPTX‑rundresa. Öppna alltid den genererade filen på nytt och inspektera samlingen när bevarande är ett krav.
- [BrightnessContrast](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/brightnesscontrast/) är en Office 2010‑förlängning snarare än standard‑DrawingML‑luminans‑operationen. Den kan användas för rendering i minnet, men garanteras inte att förbli en redigerbar [IBrightnessContrast](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/ibrightnesscontrast/) efter sparning och återöppning av PPTX. Föredra [AddLuminanceEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) för beständig ljusstyrke‑ och kontrast‑justering.
- Det binära PPT‑formatet föregick den fullständiga DrawingML‑effektmodellen. Sparning till PPT kan utelämna ej stödda operationer, reducera en kedja till ett stödt delmängd, eller approximera utseendet. Använd inte PPT som verifieringsformat för en komplex redigerbar kedja.
- Rendering till PNG, JPEG, TIFF, PDF, SVG, HTML eller andra visuella utdata applicerar den stödda kedjan på det renderade utseendet. Dessa utdata innehåller ingen redigerbar `IImageTransformOperationCollection`; rasterformat plattar ut resultatet till pixlar, och dokument‑/vektorexporter lagrar sin egen renderingsrepresentation.
- Effekter gör inte en länkad bild självständig. Rendering av en länkad bild beror fortfarande på att den länkade resursen är tillgänglig när presentationen laddas.

Olika presentationskonsumenter kan rendera kantfall på olika sätt, särskilt när flera alfa‑ eller färg‑kvantisering‑operationer kombineras. För kritiska utdata, testa både den redigerbara rundresan och slutlig exportformat med samma Aspose.Slides‑version som används i produktion.

## **Vanliga frågor**

**Modifierar bildtransformeringseffekter den inbäddade bilddata?**

Nej. Operationerna tillhör den `ISlidesPicture` som används av bildfyllningen. De underliggande `IPPImage`‑bytena förblir oförändrade.

**Kommer två bildramar som återanvänder samma bild att dela sina effekter?**

Nej. Återanvändning av en `IPPImage` undviker duplicerad bilddata, men varje bildram har normalt en separat `ISlidesPicture` och bildtransformeringssamling.

**Kan färg‑, oskärpa‑ och alfa‑effekter kombineras?**

Ja. Samlingen accepterar dem i en ordnad kedja. Tänk på vad varje operation gör med resultatet från den föregående eftersom ersättnings‑ och tröskel‑operationer kan kasta bort tidigare färg‑ eller alfabitar.

**Varför är effektiva värden skrivskyddade?**

Effektiva data representerar beräknade värden som används för rendering, inklusive lösta färger. Redigera den operation som lagras i transform‑samlingen där skrivbara medlemmar finns; annars ta bort den och lägg till en ersättare med nya skapande‑parametrar.

**Vilket format bör jag använda för att bevara en transform‑kedja?**

Använd PPTX och verifiera filen genom att öppna den igen. Äldre PPT kan inte representera hela DrawingML‑effektmodellen, och renderade exportformat bevarar bara utseendet, inte redigerbara transform‑operationer.