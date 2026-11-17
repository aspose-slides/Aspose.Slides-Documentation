---
title: Spravujte efekty transformace obrázku v prezentacích s .NET
linktitle: Efekty transformace obrázku
type: docs
weight: 11
url: /cs/net/image-transform-effects/
keywords:
- transformace obrázku
- efekt obrázku
- jas
- kontrast
- odstín šedi
- duotón
- nádech
- HSL
- náhrada barvy
- rozmazání
- průhlednost
- efekt alfa
- řetězec efektů
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrazu. Pro rámeček obrázku začněte s objektem [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) a přistupte k [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/). Vrácený [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) vám umožní přidávat, procházet, zkoumat, odstraňovat a čistit efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek demonstruje kompletní postup pro jas a kontrast, barevné transformace, rozmazání, průhlednost, řazené řetězce efektů, efektivní hodnoty, odstraňování a ověření PPTX round‑trip.

## **Pochopení vlastnictví efektů a znovupoužití obrázku**

Obrazový zdroj a obrázek, který ho zobrazuje, jsou různé objekty:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) ukládá nebo odkazuje na zdrojová data obrázku patřící prezentaci.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) patří k výplni obrázku a odkazuje na obrazový zdroj, zatímco uchovává kolekci transformací obrazu.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování úrovně rámce.

Proto operace transformace obrazu nemění bajty v [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). Když je stejný `IPPImage` předán metodě [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) více než jednou, každý nový rámeček obrázku získá vlastní `ISlidesPicture` a vlastní kolekci transformací. Aplikace odstínu šedi na jeden rámec neovlivní ostatní rámečky, i když všechny používají stejný vložený obrazový zdroj.

Stejný model `ISlidesPicture.ImageTransform` používají i jiné výplně obrázků, např. tvar nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázků.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Dodržujte tyto rozsahy, i když konkrétní verze knihovny neodmítne okamžitě každý neplatný vstup; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechává komponentu beze změny. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Žádné | Žádné číselné parametry. Alfa zůstává beze změny. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `System.Drawing.Color` používají hodnoty `0` až `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Odstín je `0` včetně až `360` vyloučeno, ve stupních; množství je `-100` až `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Odstín je `0` včetně až `360` vyloučeno, ve stupních; sytost a luminance jsou `-100` až `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující hodnoty alfa zůstávají beze změny. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` je Boolean, který určuje, zda rozmazaný obsah může přesahovat původní okraje. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování opacity: `0` je plně průhledné a `100` zachovává existující alfa. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` až `100`, procento opacity. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` až `100`, procento prahu alfa. Hodnoty pod prahem se stanou průhlednými; hodnoty na nebo nad prahem jsou neprůhledné. |

Pro pevnou modulaci alfa jsou průhlednost a opacity komplementární. Například 35 % průhlednost odpovídá modulaci alfa ve výši 65 %.

## **Použijte jas a kontrast**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) vrací operaci [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/). Její skalární nastavení jsou zadána při vytvoření operace. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) vrací vypočtené jen pro čtení hodnoty, které lze zkontrolovat nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté vykreslí náhled, aniž by upravil vložený obrázek:

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

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010 pro efekty obrázků a není tak přenositelné jako standardní efekt DrawingML luminance. Když je třeba, aby jas a kontrast zůstaly editovatelné po PPTX round‑trip, použijte [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) a ověřte výsledek po opětovném otevření souboru. Část o omezeních formátu vysvětluje tento rozdíl podrobněji.

## **Použijte barevné transformace**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázků, které znovu používají jeden obrazový zdroj. Následující příklad vytvoří pět rámečků a použije odstín šedi, duotón, nádech, úpravu HSL a nahrazení barvy.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) obsahuje dva nezávisle editovatelné barevné parametry: `Color1` mapuje tmavé pixely, zatímco `Color2` mapuje světlé pixely. To z něj dělá užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) nahrazuje barvu každého pixelu jednou pevnou barvou a zachovává alfu. Liší se od [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), který mapuje jednu zdrojovou barvu na jinou a odhaluje formáty obou zdrojových i cílových barev.

### **Použijte prahování luminance**

Prahování luminance může usnadnit rozpoznání slabých značek na naskenované stránce. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) zachovává mezistupně šedi. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) mapuje luminanci na černou nebo bílou, zatímco [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) aplikuje práh na průhlednost.

Prahování luminance se pohybuje od 0 % do 100 %, včetně. Pixely pod prahem se stanou černými. Pixely na nebo nad prahem se stanou bílými. Zvýšením prahu se více odstínů stane černými, protože více pixelů spadne pod limit.

Stáhněte [grayscale-swatches.png](grayscale-swatches.png) do pracovního adresáře. Každý štítek uvádí původní úroveň šedi na stupnici od 0 do 255. Příklad umístí originál vedle dvou kopií a uloží práh každé kopie v prezentaci.

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

Otevřete výstupní prezentaci v PowerPointu a porovnejte tři rámečky. Štítek s hodnotou 96 má asi 38 % luminance (96 z 255). Při prahu 20 % se zobrazí bílá a při prahu 60 % černá.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Přidejte rozmazání, průhlednost a alfa efekty**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) ovlivňuje všechny barevné kanály, včetně alfy. Nastavte `grow` na `true`, když rozmazaný okraj může přesáhnout původní okraje obrázku.

Pro jednotnou průhlednost použijte [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Násobí každou existující alfu, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) místo toho přiřadí jednu alfa hodnotu všem pixelům. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) převádí alfu na dvě úrovně podle prahu.

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

Další alfa operace bez parametrů zahrnují [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), který nastaví každou nenulovou alfu na plně neprůhlednou; [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), který nastaví každou alfu pod 100 % na plně průhlednou; a [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), který mění alfu na `100% - alpha`.

## **Vytvořte řazený řetězec efektů**

Každá metoda `Add...Effect` připojí novou operaci na konec kolekce. Vykreslovací engine používá kolekci jako uspořádaný pipeline: výstup operace 0 se stane vstupem operace 1 a tak dále. Výsledkem je, že stejné operace v jiném pořadí mohou vytvořit odlišný obrázek.

Například odstín šedi následovaný nádechem nejprve odstraní chromatickou informaci a pak obarví výsledek luminance. Nádech následovaný odstínem šedi nádech opět odstraní. Podobně může nahrazení alfy přepsat alfa hodnoty vypočítané dřívějšími operacemi, zatímco modulace alfy zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, znovu otevře prezentaci, ověří typy operací i jejich pořadí a vykreslí znovuotevřený výsledek:

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

Kolekce neukládá kompatibilní matici, která by omezovala barevné, alfa a rozmazávací operace na oddělené řetězce. Mohou být kombinovány, ale ne vždy jsou užitečné. Pevná náhrada barvy odstraní RGB variaci vytvořenou předchozími barevnými efekty; odstín šedi po duotóne odstraní dvě vybrané barvy; a operace alfa ceiling, floor, replacement nebo bi‑level mohou zahodit alfa detail vytvořený dříve. Sestavte řetězec podle požadované sekvence zpracování pixelů místo toho, abyste jeho položky považovali za nepřehledné formátovací příznaky.


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Prohlédněte editovatelné a efektivní hodnoty**

Editovatelná operace je objekt uložený v `ISlidesPicture.ImageTransform`. V závislosti na efektu může přímo odhalovat zapisovatelné členy. Například [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) odhaluje zapisovatelný `Radius` a `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) odhaluje zapisovatelný `Amount` a [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) odhaluje zapisovatelný `Threshold`. Barevné efekty jako [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) odhalují mutovatelné objekty [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/).

Některé rozhraní operací, včetně [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/) a [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), neodhalují své vytvořené skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odeberte operaci a přidejte náhradu na požadovanou pozici.

Efektivní data vrácená metodou `GetEffective()` jsou vypočtená a jen pro čtení. Hodí se k rozlišení barev závislých na motivu a ke čtení normalizovaných hodnot, které vykreslovací engine používá, ale nejsou dalším editačním rozhraním. Následující příklad prochází řetězec a kontroluje efektivní hodnoty, kde API poskytuje:

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

Efekty bez parametrů, jako odstín šedi, alfa ceiling a alfa inverse, stále mají objekt efektivních dat, ale neexistují žádná skalární nastavení, která by šlo vytisknout. Jejich přítomnost a pozice v kolekci jsou důležité informace.

## **Odstraňte nebo vymažte transformace obrazu**

Použijte [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) k odebrání jedné operace podle indexu. Protože se indexy po odebrání posunou, nejprve vyhledejte cíl a až po průchodu jej odstraňte. Použijte `Clear()` k odebrání celého řetězce.

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

Odstranění nebo vymazání transformací mění pouze formátování obrázku. Neodstraňuje, nekomprimuje ani jinak nemění znovu použitý zdroj [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).

## **Zvažte formáty prezentací a cílové exporty**

Transformace obrazu pocházejí z DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I u PPTX však ne všechny operace mají stejnou přenositelnost:

- Standardní operace DrawingML, jako luminance, odstín šedi, duotón, nádech, HSL, rozmazání a běžné alfa operace, mají nejlepší šanci přežít PPTX round‑trip. Vždy znovu otevřete vygenerovaný soubor a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010 a ne standardní operace DrawingML luminance. Lze jej použít pro renderování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelným [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/). Upřednostněte [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) pro trvalé úpravy jasu a kontrastu.
- Binární formát PPT předchází úplnému modelu efektů DrawingML. Ukládání do PPT může vynechat nepodporované operace, zkrátit řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů použije podporovaný řetězec na výsledný vzhled. Tyto výstupy neobsahují editovatelný `IImageTransformOperationCollection`; rastrové formáty výsledek rozloží do pixelů a exporty dokumentu/vektoru ukládají vlastní reprezentaci renderování.
- Efekty nečiní propojený obrázek samostatným. Renderování propojeného obrázku stále závisí na tom, že propojený zdroj bude dostupný při načítání prezentace.

Různí spotřebitelé prezentací mohou renderovat okrajové případy odlišně, zejména když jsou kombinovány několik alfa nebo barevných kvantizačních operací. Pro kritický výstup otestujte jak editovatelný round‑trip, tak finální exportní formát se stejnou verzí Aspose.Slides používanou v produkci.

## **Často kladené otázky**

**Upravují efekty transformace obrazu vložená data obrázku?**

Ne. Operace patří k `ISlidesPicture` použitému výplní obrázku. Podkladové bajty `IPPImage` zůstávají beze změny.

**Budou dva rámečky obrázků, které znovu používají stejný obrázek, sdílet své efekty?**

Ne. Znovupoužití `IPPImage` eliminuje duplicitní data obrázku, ale každý rámeček obrázku má obvykle samostatný `ISlidesPicture` a kolekci transformací obrazu.

**Lze kombinovat barevné, rozmazávací a alfa efekty?**

Ano. Kolekce je přijímá v jednom řazeném řetězci. Zvažte, co každá operace dělá s výstupem předchozí, protože náhrada a prahové operace mohou zahodit dřívější barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty jen pro čtení?**

Efektivní data představují vypočtené hodnoty používané při renderování, včetně rozřešených barev. Editujte operaci uloženou v kolekci transformací tam, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte náhradu s novými parametry vytvoření.

**Který formát použít k zachování řetězce transformací?**

Použijte PPTX a ověřte soubor opětovným otevřením. Starší PPT nemůže reprezentovat celý model efektů DrawingML a renderovací exportní formáty zachovávají jen vzhled, nikoli editovatelné operace transformace.