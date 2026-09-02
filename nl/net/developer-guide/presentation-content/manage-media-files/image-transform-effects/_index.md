---
title: Beheer beeldtransformatie‑effecten in presentaties met .NET
linktitle: Beeldtransformatie‑effecten
type: docs
weight: 11
url: /nl/net/image-transform-effects/
keywords:
- beeldtransformatie
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
- alfa‑effect
- effectketen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas beeldtransformatie‑effecten toe, koppel ze, inspecteer, verwijder en verifieer ze voor afbeelding‑frames met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt afbeeldingsaanpassingen als een geordende verzameling van beeldtransformatie‑operaties. Voor een afbeelding‑frame begin je met het frame’s [ISlidesPicture](https://reference.aspose.com/slides/nl/net/aspose.slides/islidespicture/) en krijg je toegang tot [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/nl/net/aspose.slides/islidespicture/imagetransform/). De geretourneerde [IImageTransformOperationCollection](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/) laat je effecten toevoegen, opsommen, inspecteren, verwijderen en wissen zonder de oorspronkelijke afbeeldingsbytes opnieuw te schrijven.

Dit artikel laat een volledige workflow zien voor helderheid en contrast, kleurtransformaties, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX‑round‑trip‑verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) slaat de bronafbeeldingsdata op of verwijst ernaar en behoort tot de presentatie.
- [ISlidesPicture](https://reference.aspose.com/slides/nl/net/aspose.slides/islidespicture/) maakt deel uit van een afbeeldingsvulling en verwijst naar een afbeeldingsbron terwijl het de beeldtransformatie‑verzameling opslaat.
- [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) is de dia‑vorm die de betreffende afbeeldingsvulling, geometrie, bijsnijdinstellingen en andere frame‑niveau‑opmaak bezit.

Daarom wijzigen beeldtransformatie‑operaties de bytes in [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) niet. Wanneer dezelfde `IPPImage` meer dan één keer wordt doorgegeven aan [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addpictureframe/), krijgt elk nieuw afbeelding‑frame zijn eigen `ISlidesPicture` en eigen transformatie‑verzameling. Het toepassen van grijstinten op één frame maakt de andere frames niet grijs, zelfs als ze dezelfde ingesloten afbeeldingsbron hergebruiken.

Hetzelfde `ISlidesPicture.ImageTransform`‑model wordt ook gebruikt door andere afbeeldingsvullingen, zoals een vorm‑ of dia‑achtergrond. De onderstaande voorbeelden richten zich op afbeelding‑frames.

## **Gebruik geldige parameter‑bereiken en eenheden**

De aangetoonde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, zelfs als een bepaalde bibliotheekversie niet onmiddellijk elke out‑of‑range‑waarde afwijst; het doel‑presentatieformaat kan tijdens opslaan of bij het openen in PowerPoint normaliseren, weglaten of ongeldige data afwijzen.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat het onderdeel onveranderd. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Geen | Geen numerieke parameters. Alpha blijft onveranderd. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfacanalen in `System.Drawing.Color` gebruiken `0` tot `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue is `0` inclusief tot `360` exclusief, in graden; amount is `-100` tot `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue is `0` inclusief tot `360` exclusief, in graden; saturatie en luminantie zijn `-100` tot `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | De vervangende kleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfabwaarden blijven onveranderd. |
| [AddBlurEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius is niet‑negatief en wordt gemeten in points; `grow` is een Boolean die bepaalt of vervaagd materiaal buiten de originele grenzen mag uitsteken. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Niet‑negatieve procent. Gebruik `0` tot `100` voor gewone doorzichtigheids‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alfa. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` tot `100`, procent doorzichtigheid. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` tot `100`, procent alfabdrempel. Waarden eronder worden transparant; waarden op of boven de drempel worden ondoorzichtig. |

Voor vaste alfa‑modulatie zijn transparantie en ondoorzichtigheid complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alfa‑modulatie‑waarde van 65 %.

## **Helderheid en contrast toepassen**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) retourneert een [IBrightnessContrast](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/ibrightnesscontrast/)‑operatie. De scalare instellingen worden meegegeven wanneer de operatie wordt aangemaakt. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/brightnesscontrast/geteffective/) retourneert berekende alleen‑lezen‑waarden die geïnspecteerd of gelogd kunnen worden.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, waarna een voorbeeld wordt gerenderd zonder de ingesloten afbeelding te wijzigen:

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

[BrightnessContrast](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/brightnesscontrast/) is een Office‑2010‑afbeeldingseffect‑extensie en minder draagbaar dan het standaard DrawingML‑luminantie‑effect. Wanneer helderheid en contrast na een PPTX‑round‑trip bewerkbaar moeten blijven, gebruik dan [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) en verifieer het resultaat na het heropenen van het bestand. De sectie “format limitations” legt dit onderscheid uitgebreider uit.

## **Kleurtransformaties toepassen**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeelding‑frames die dezelfde afbeeldingsbron hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijstinten, duotoon, tint, HSL‑aanpassing en kleurvervanging toe.

[IDuotone](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iduotone/) bevat twee onafhankelijk bewerkbare kleur‑parameters: `Color1` mappt donkere pixels, terwijl `Color2` lichte pixels mappt. Dit maakt het een bruikbaar voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkele scalare waarde.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) vervangt elke pixel‑kleur door één vaste kleur terwijl alfa behouden blijft. Het verschilt van [AddColorChangeEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), dat één bronkleur naar een andere mappt en zowel bron‑ als doel‑kleurformaten blootlegt.

## **Vervaging, transparantie en alfa‑effecten toevoegen**

[AddBlurEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) beïnvloedt alle kleurkanalen, inclusief alfa. Stel `grow` in op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeelding‑grenzen kan uitsteken.

Voor uniforme transparantie, gebruik [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Het vermenigvuldigt elke bestaande alfabwaarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) wijst in plaats daarvan één alfabwaarde toe aan alle pixels. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) zet alfa om naar twee niveaus gebaseerd op een drempel.

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

Andere alfa‑operaties zonder parameters zijn onder meer [AddAlphaCeilingEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), die elke niet‑nul alfa volledig ondoorzichtig maakt; [AddAlphaFloorEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), die elke alfa onder 100 % volledig transparant maakt; en [AddAlphaInverseEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), die alfa verandert naar `100% - alpha`.

## **Een geordende effectketen bouwen**

Elke `Add...Effect`‑methode voegt een nieuwe operatie toe aan het einde van de verzameling. De renderer gebruikt de verzameling als een geordende pijplijn: de output van operatie 0 wordt de input van operatie 1, enzovoort. Daardoor kan dezelfde reeks operaties in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijstinten gevolgd door tint verwijdert eerst chromatische informatie en kleurt dan het luminantie‑resultaat opnieuw. Tint gevolgd door grijstinten verwijdert de tint weer. Op dezelfde manier kan alfa‑vervanging alfa‑waarden die door eerdere operaties zijn berekend overschrijven, terwijl alfa‑modulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, heropent de presentatie, controleert zowel de operatietypen als hun volgorde, en rendert het heropende resultaat:

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

De verzameling legt geen compatibiliteitsmatrix op die kleuren-, alfa- en vervagings‑operaties tot gescheiden ketens beperkt. Ze kunnen gecombineerd worden, maar combinaties zijn niet altijd nuttig. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is geproduceerd; grijstinten na duotoon verwijderen de twee geselecteerde kleuren; en alfa‑ceiling, floor, replace‑ of bi‑level‑operaties kunnen alfa‑details die eerder zijn gecreëerd weggooien. Bouw de keten volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items te beschouwen als ongeordende opmaak‑vlaggen.

## **Bewerkbare en effectieve waarden inspecteren**

Een bewerkbare operatie is het object dat in `ISlidesPicture.ImageTransform` is opgeslagen. Afhankelijk van het effect kan het direct schrijfbare leden blootleggen. Bijvoorbeeld, [IBlur](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iblur/) blootlegt schrijfbare `Radius` en `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/ialphamodulatefixed/) blootlegt schrijfbare `Amount`, en [IAlphaBiLevel](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/ialphabilevel/) blootlegt schrijfbare `Threshold`. Kleureffecten zoals [IDuotone](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iduotone/) blootleggen mutable [IColorFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/icolorformat/)‑objecten.

Sommige operatie‑interfaces, waaronder [IBrightnessContrast](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/itint/) en [IAlphaReplace](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/ialphareplace/), exposen hun creatiescalars niet als schrijfbare properties. Om die instellingen te wijzigen, verwijder je de operatie en voeg je een vervanging toe op de gewenste positie.

Effectieve data die door `GetEffective()` wordt geretourneerd, is berekend en alleen‑lezen. Het is nuttig voor het oplossen van thema‑afhankelijke kleuren en het lezen van de genormaliseerde waarden die de renderer gebruikt, maar het vormt geen extra bewerkingsoppervlak. Het volgende voorbeeld loopt de keten af en inspecteert effectieve waarden waar de corresponderende API ze levert:

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

Parameter‑vrije effecten zoals grijstinten, alfa‑ceiling en alfa‑inverse hebben nog steeds een effective‑data‑object, maar er zijn geen scalare instellingen om af te drukken. Hun aanwezigheid en positie in de verzameling zijn de belangrijke informatie.

## **Transformaties verwijderen of wissen**

Gebruik [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) om één operatie op index te verwijderen. Omdat indexen verschuiven na verwijdering, zoek eerst het doel en verwijder het daarna na de opsomming. Gebruik `Clear()` om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties verandert alleen de afbeelding‑opmaak. Het verwijdert, recomprimeert of wijzigt de hergebruikte [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) bron niet.

## **Presentatieformaten en exportdoelen overwegen**

Beeldtransformaties stammen uit DrawingML, dus PPTX is het voorkeursbare bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke operatie identieke draagbaarheid:

- Standaard DrawingML‑operaties zoals luminantie, grijstinten, duotoon, tint, HSL, vervaging en gangbare alfa‑operaties hebben de grootste kans om een PPTX‑round‑trip te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de verzameling wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/brightnesscontrast/) is een Office‑2010‑extensie in plaats van de standaard DrawingML‑luminantie‑operatie. Het kan worden gebruikt voor in‑memory rendering, maar er is geen garantie dat het na opslaan en heropenen van PPTX blijft bestaan als een bewerkbare [IBrightnessContrast](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/ibrightnesscontrast/). Geef de voorkeur aan [AddLuminanceEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) voor persistente helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde operaties weglaten, een keten reduceren tot een ondersteunde subset, of een benadering van het uiterlijk geven. Gebruik PPT niet als verificatieformaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele output past de ondersteunde keten toe op het gerenderde uiterlijk. Deze uitvoer bevat geen bewerkbare `IImageTransformOperationCollection`; rasterformaten flatten het resultaat tot pixels, en document‑/vector‑exports slaan hun eigen weergave‑representatie op.
- Effecten maken een gekoppelde afbeelding niet zelf‑voorzienend. Het renderen van een gekoppelde afbeelding blijft afhankelijk van de beschikbaarheid van de gekoppelde bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen edge‑cases anders renderen, vooral wanneer meerdere alfa‑ of kleur‑kwantisering‑operaties gecombineerd worden. Voor kritieke output, test zowel de bewerkbare round‑trip als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigten beeldtransformatie‑effecten de ingebedde afbeeldingsdata?**

Nee. De operaties behoren tot de `ISlidesPicture` die door de afbeelding‑vulling wordt gebruikt. De onderliggende `IPPImage`‑bytes blijven ongewijzigd.

**Delen twee afbeelding‑frames die dezelfde afbeelding hergebruiken hun effectinstellingen?**

Nee. Het hergebruiken van een `IPPImage` voorkomt dubbele afbeeldingsdata, maar elk afbeelding‑frame heeft normaal gezien een apart `ISlidesPicture` en een eigen beeldtransformatie‑verzameling.

**Kunnen kleur‑, vervaging‑ en alfa‑effecten gecombineerd worden?**

Ja. De verzameling accepteert ze in één geordende keten. Houd rekening met wat elke operatie met de output van de vorige doet, want vervangings‑ en drempel‑operaties kunnen eerdere kleur‑ of alfabdetails weggooien.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data vertegenwoordigt berekende waarden die voor rendering worden gebruikt, inclusief opgeloste kleuren. Bewerk de operatie die in de transformatie‑verzameling is opgeslagen waar schrijfbare leden bestaan; anders verwijder je de operatie en voeg je een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transformatie‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Het legacy‑PPT‑formaat kan het volledige DrawingML‑effectmodel niet weergeven, en geëxporteerde formaten behouden alleen het uiterlijk, niet de bewerkbare transformatie‑operaties.