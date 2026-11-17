---
title: Beheer afbeeldingstransform‑effecten in presentaties met .NET
linktitle: Afbeeldingstransform‑effecten
type: docs
weight: 11
url: /nl/net/image-transform-effects/
keywords:
- afbeeldingstransform
- afbeeldingseffect
- helderheid
- contrast
- grijstinten
- duotoon
- tint
- HSL
- kleurvervanging
- vervaging
- transparantie
- alphaeffect
- effectketen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas afbeeldingstransform‑effecten toe, koppel ze, inspecteer, verwijder en verifieer ze voor picture frames met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt beeldaanpassingen als een geordende collectie van image transform‑operaties. Voor een picture frame, begin met de frame‑`[ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/)` en krijg toegang tot `[ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/)`. De geretourneerde `[IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/)` laat je effecten toevoegen, enumereren, inspecteren, verwijderen en wissen zonder de oorspronkelijke image‑bytes opnieuw te schrijven.

Dit artikel toont een volledige werkstroom voor helderheid en contrast, kleurtransformaties, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX‑rondreis‑verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeelding‑resource en de picture die deze weergeeft zijn verschillende objecten:

- `[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)` slaat de bronafbeeldingsgegevens op of verwijst ernaar, eigendom van de presentatie.
- `[ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/)` behoort tot een picture‑fill en verwijst naar een afbeelding‑resource terwijl de image‑transform‑collectie wordt opgeslagen.
- `[IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)` is de slide‑shape die de relevante picture‑fill, geometrie, crop‑instellingen en andere frame‑level opmaak bezit.

Daarom wijzigen image‑transform‑operaties de bytes in `[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)` niet. Wanneer dezelfde `IPPImage` meer dan één keer wordt doorgegeven aan `[IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/)`, krijgt elk nieuw picture‑frame zijn eigen `ISlidesPicture` en zijn eigen transform‑collectie. Het toepassen van grayscale op één frame maakt de andere frames niet grayscale, ook al hergebruiken ze allemaal dezelfde embedded afbeelding‑resource.

Hetzelfde `ISlidesPicture.ImageTransform`‑model wordt ook gebruikt door andere picture‑fills, zoals een shape of slide‑background. De voorbeelden hieronder richten zich op picture‑frames.

## **Gebruik geldige parameter‑bereiken en eenheden**

De gedemonstreerde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, zelfs als een bepaalde bibliotheekversie niet meteen elke out‑of‑range waarde afwijst; het doelpresentatie‑formaat kan normaliseren, weglaten of ongeldige data afwijzen tijdens het opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldige bereik en eenheid |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat het onderdeel onveranderd. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Geen numerieke parameters. Alpha wordt niet gewijzigd. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfacanalen in `System.Drawing.Color` gebruiken `0` tot `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; hoeveelheid (`amount`) is `-100` tot `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfabedragen blijven ongewijzigd. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Straal is niet‑negatief en wordt gemeten in punten; `grow` is een Boolean die bepaalt of vervaagde inhoud buiten de oorspronkelijke grenzen mag uitsteken. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Niet‑negatieve procenten. Gebruik `0` tot `100` voor gewone opaciteits‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alpha. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` tot `100`, procent opaciteit. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` tot `100`, procent alpha‑drempel. Waarden eronder worden transparant; waarden op of boven de drempel worden ondoorzichtig. |

Voor vaste alpha‑modulatie zijn transparantie en opaciteit complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alpha‑modulatie‑hoeveelheid van 65 %.

## **Helderheid en contrast toepassen**

`[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/)` retourneert een `[IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)`‑operatie. De scalaire instellingen worden meegegeven wanneer de operatie wordt aangemaakt. `[IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/)` retourneert berekende alleen‑lezen waarden die kunnen worden geïnspecteerd of gelogd.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, waarna een preview wordt gerenderd zonder de embedded afbeelding te wijzigen:

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

`[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/)` is een Office 2010 picture‑effect extensie en is minder draagbaar dan het standaard DrawingML luminance‑effect. Wanneer helderheid en contrast bewerkbaar moeten blijven na een PPTX‑rondreis, gebruik dan `[IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)` en verifieer het resultaat na het heropenen van het bestand. De sectie over format‑beperkingen legt dit onderscheid gedetailleerder uit.

## **Kleurtransformaties toepassen**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende picture‑frames die één afbeelding‑resource hergebruiken. Het volgende voorbeeld maakt vijf frames en past grayscale, duotone, tint, HSL‑aanpassing en kleurvervanging toe.

`[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/)` bevat twee onafhankelijk bewerkbare kleur‑parameters: `Color1` mappt donkere pixels, terwijl `Color2` lichte pixels mappt. Dit maakt het een bruikbaar voorbeeld van een effect waarvan de instellingen complexer zijn dan één enkele scalaire waarde.

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

`[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/)` vervangt de kleur van elke pixel door één vaste kleur terwijl alpha behouden blijft. Het verschilt van `[AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)`, dat één bronkleur naar een andere mappt en beide kleurformaten (bron en doel) blootlegt.

### **Een luminantie‑drempel toepassen**

Een luminantie‑drempel kan zwakke markeringen op een gescande pagina makkelijker onderscheidbaar maken ten opzichte van de achtergrond. `[AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/)` behoudt tussenliggende grijstinten. `[AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/)` mappt luminantie naar zwart of wit, terwijl `[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/)` een drempel op opaciteit toepast.

De luminantie‑drempel varieert van 0 % tot 100 %, inclusief. Pixels onder de drempel worden zwart. Pixels op of boven de drempel worden wit. Het verhogen van de drempel maakt meer tinten zwart omdat meer van hen onder de cutoff vallen.

Download `[grayscale-swatches.png](grayscale-swatches.png)` naar de werkmap. Elk label geeft het oorspronkelijke grijsniveau op een schaal van 0 tot 255 weer. Het voorbeeld plaatst het origineel naast twee kopieën en slaat de drempel van elke kopie op in de presentatie.

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

Open de uitvoer‑presentatie in PowerPoint om de drie frames te vergelijken. Het swatch‑label 96 heeft ongeveer 38 % luminantie (96 van 255). Het wordt wit bij de 20 % drempel en zwart bij de 60 % drempel.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Vervaag, transparantie en alpha‑effecten toevoegen**

`[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/)` beïnvloedt alle kleurkanalen, inclusief alpha. Zet `grow` op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeelding kan uitsteken.

Voor uniforme transparantie, gebruik `[AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)`. Het vermenigvuldigt elke bestaande alpha‑waarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. `[AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/)` kent daarentegen één alpha‑waarde toe aan alle pixels. `[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/)` converteert alpha naar twee niveaus op basis van een drempel.

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

Andere parameter‑vrije alpha‑operaties omvatten `[AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)`, die elke niet‑nul alpha volledig ondoorzichtig maakt; `[AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)`, die elke alpha onder 100 % volledig transparant maakt; en `[AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)`, die alpha omzet naar `100% - alpha`.

## **Een geordende effectketen opbouwen**

Elke `Add...Effect`‑methode voegt een nieuwe operatie toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de output van operatie 0 wordt de input van operatie 1, enzovoort. Daardoor kunnen dezelfde operaties in een andere volgorde een andere afbeelding opleveren.

Bijvoorbeeld, grayscale gevolgd door tint verwijdert eerst chromatische informatie en kleurt daarna het luminantie‑resultaat opnieuw. Tint gevolgd door grayscale verwijdert de tint weer. Evenzo kan alpha‑vervanging alpha‑waarden die door eerdere operaties zijn berekend overschrijven, terwijl alpha‑modulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de operatietypen als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alpha‑ en vervaging‑operaties tot aparte ketens beperkt. Ze kunnen worden gecombineerd, maar combinaties zijn niet altijd nuttig. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is gecreëerd; grayscale na duotone verwijdert de twee geselecteerde kleuren; en alpha‑ceiling, floor, replace of bi‑level operaties kunnen alpha‑detail die eerder is gemaakt weggooien. Bouw de keten op volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items te zien als ongeordende opmaak‑vlaggen.


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Bewerkbare en effectieve waarden inspecteren**

Een bewerkbare operatie is het object dat is opgeslagen in `ISlidesPicture.ImageTransform`. Afhankelijk van het effect kan het rechtstreeks schrijfbare leden blootleggen. Bijvoorbeeld, `[IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/)` exposeert schrijfbare `Radius` en `Grow`, `[IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/)` exposeert schrijfbare `Amount`, en `[IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/)` exposeert schrijfbare `Threshold`. Kleur‑effecten zoals `[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/)` exposeeren mutabele `[IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/)`‑objecten.

Sommige operatie‑interfaces, waaronder `[IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)`, `[IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/)`, `[ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/)` en `[IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/)`, exposen hun creatiescalars niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de operatie en voeg je een vervanging toe op de vereiste positie.

Effectieve data die door `GetEffective()` wordt geretourneerd, is berekend en alleen‑lezen. Het is nuttig om themagerelateerde kleuren op te lossen en de genormaliseerde waarden die de renderer gebruikt te lezen, maar het is geen extra bewerkingsoppervlak. Het volgende voorbeeld enumerateert de keten en inspecteert effectieve waarden waar de corresponderende API ze levert:

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

Parameter‑vrije effecten zoals grayscale, alpha ceiling en alpha inverse hebben nog steeds een effectieve‑data‑object, maar er zijn geen scalaire instellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Transformaties verwijderen of wissen**

Gebruik `[IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/)` om één operatie op basis van index te verwijderen. Omdat indexen verschuiven na verwijdering, zoek eerst het doel en verwijder het na enumeratie. Gebruik `Clear()` om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties wijzigt alleen de picture‑opmaak. Het verwijdert, recomprimeert of verandert de hergebruikte `[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)`‑resource niet.

## **Overweeg presentatief formaten en exportdoelen**

Image‑transformaties komen voort uit DrawingML, dus PPTX is het voorkeurs‑bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke operatie identieke draagbaarheid:

- Standaard DrawingML‑operaties zoals luminance, grayscale, duotone, tint, HSL, blur en gemeenschappelijke alpha‑operaties hebben de grootste kans om een PPTX‑rondreis te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- `[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/)` is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminance‑operatie. Het kan worden gebruikt voor in‑memory rendering, maar het is niet gegarandeerd dat het als bewerkbare `[IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)` blijft bestaan na opslaan en heropenen van PPTX. Geef de voorkeur aan `[AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)` voor blijvende helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde operaties weglaten, een keten reduceren tot een ondersteunde subset, of het uiterlijk benaderen. Gebruik PPT niet als verificatieformaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele output past de ondersteunde keten toe op het gerenderde uiterlijk. Die outputs bevatten geen bewerkbare `IImageTransformOperationCollection`; raster‑formaten flatten het resultaat naar pixels, en document/vector‑exports slaan hun eigen render‑representatie op.
- Effecten maken een gelinkte afbeelding niet zelf‑containend. Het renderen van een gelinkte picture blijft afhangen van de beschikbaarheid van de gelinkte resource wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen edge‑cases verschillend renderen, vooral wanneer meerdere alpha‑ of kleur‑kwantiserende operaties worden gecombineerd. Voor kritische output, test zowel de bewerkbare rondreis als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen image‑transform‑effecten de embedded afbeeldingsdata?**

Nee. De operaties behoren tot de `ISlidesPicture` die door de picture‑fill wordt gebruikt. De onderliggende `IPPImage`‑bytes blijven ongewijzigd.

**Delen twee picture‑frames die dezelfde afbeelding hergebruiken hun effect‑instellingen?**

Nee. Het hergebruiken van een `IPPImage` voorkomt dubbele afbeeldingsdata, maar elk picture‑frame heeft normaal gesproken een aparte `ISlidesPicture` en image‑transform‑collectie.

**Kunnen kleur‑, blur‑ en alpha‑effecten worden gecombineerd?**

Ja. De collectie accepteert ze in één geordende keten. Overweeg wat elke operatie doet met de output van de vorige, want vervangings‑ en drempel‑operaties kunnen eerdere kleur‑ of alpha‑details weggooien.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data vertegenwoordigt berekende waarden die voor rendering worden gebruikt, inclusief opgeloste kleuren. Bewerk de operatie die is opgeslagen in de transform‑collectie waar schrijfbare leden bestaan; anders verwijder je deze en voeg je een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transform‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Legacy PPT kan niet het volledige DrawingML‑effectmodel vertegenwoordigen, en gerenderde export‑formaten behouden alleen het uiterlijk, niet bewerkbare transform‑operaties.