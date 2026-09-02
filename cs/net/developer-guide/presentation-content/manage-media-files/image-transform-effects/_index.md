---
title: Správa efektů transformace obrázku v prezentacích s .NET
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
- tónování
- HSL
- nahrazení barvy
- rozostření
- průhlednost
- alfa efekt
- řetězec efektů
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrázku. Pro rámeček obrázku začněte s rámcem [ISlidesPicture](https://reference.aspose.com/slides/cs/net/aspose.slides/islidespicture/) a přistupte k [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/cs/net/aspose.slides/islidespicture/imagetransform/). Vrácená [IImageTransformOperationCollection](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/) vám umožní přidávat, procházet, kontrolovat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek ukazuje kompletní pracovní postup pro jas a kontrast, barevné transformace, rozostření, průhlednost, řazené řetězce efektů, efektivní hodnoty, odstraňování a ověření PPTX round‑trip.

## **Pochopte vlastnictví efektů a opakované použití obrázku**

Obrazový zdroj a obrázek, který jej zobrazuje, jsou různé objekty:

- [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) ukládá nebo odkazuje na zdrojová data obrázku, která vlastní prezentace.
- [ISlidesPicture](https://reference.aspose.com/slides/cs/net/aspose.slides/islidespicture/) patří k výplni obrázku a odkazuje na zdroj obrázku, přičemž uchovává kolekci transformací obrázku.
- [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování úrovně rámce.

Proto operace transformace obrázku nemodifikují bajty v [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/). Když je stejný `IPPImage` předán metodě [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addpictureframe/) vícekrát, každý nový rámeček obrázku získá vlastní `ISlidesPicture` a vlastní kolekci transformací. Použití odstínu šedi na jednom rámečku neovlivní ostatní rámečky, i když všechny používají stejný vložený obrazový zdroj.

Stejný model `ISlidesPicture.ImageTransform` používají také další výplně obrázků, např. tvar nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázků.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Držte se těchto rozsahů, i když konkrétní verze knihovny neodmítne každou mimo‑rozsahovou hodnotu okamžitě; cílový formát prezentace může během uložení nebo při otevření souboru PowerPointem normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechá komponentu beze změny. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Žádné číselné parametry. Alfa zůstává beze změny. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dvě barvy pro tmavé a světlé pixely. RGB a alfa kanály v `System.Drawing.Color` používají hodnoty od `0` do `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Odstín je od `0` (včetně) do `360` (vyloučeno) stupňů; množství je od `-100` do `100` procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Odstín je od `0` (včetně) do `360` (vyloučeno) stupňů; sytost a luminance jsou od `-100` do `100` procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Náhradní barva používá kanálové hodnoty od `0` do `255`. Existující alfa hodnoty zůstávají beze změny. |
| [AddBlurEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` je logická hodnota určující, zda může rozostřený obsah přesahovat původní ohraničení. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro obyčejné škálování neprůhlednosti: `0` je plně průhledné a `100` zachovává existující alfa. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` až `100`, procenta neprůhlednosti. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` až `100`, procenta alfa prahu. Hodnoty pod prahem se stanou průhlednými; hodnoty na nebo nad prahem se stanou neprůhlednými. |

Pro pevnou alfa modulaci jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednosti odpovídá hodnotě modulace alfa 65 %.

## **Použijte jas a kontrast**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) vrací operaci [IBrightnessContrast](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/ibrightnesscontrast/). Její skalární nastavení se předává při vytvoření operace. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/brightnesscontrast/geteffective/) vrací vypočítané pouze pro čtení hodnoty, které lze zkontrolovat nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté zobrazí náhled bez úpravy vloženého obrázku:

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

[BrightnessContrast](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010 pro efekt obrázku a není tak přenositelné jako standardní efekt DrawingML luminance. Pokud má jas a kontrast zůstat po PPTX round‑trip editovatelné, použijte [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) a výsledek ověřte po opětovném otevření souboru. Sekce omezení formátů toto rozlišení vysvětluje podrobněji.

## **Použijte transformace barev**

Barevné efekty lze použít nezávisle na různých rámecích obrázku, které znovu používají jeden zdroj obrázku. Následující příklad vytvoří pět rámečků a použije odstín šedi, duotón, tónování, úpravu HSL a nahrazení barvy.

[IDuotone](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iduotone/) obsahuje dva nezávisle editovatelné parametry barvy: `Color1` mapuje tmavé pixely, zatímco `Color2` mapuje světlé pixely. To z něj činí užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) nahrazuje barvu každého pixelu jednou pevnou barvou a zachovává alfa kanál. Liší se od [AddColorChangeEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), který mapuje jednu zdrojovou barvu na jinou a vystavuje oba formáty zdrojové i cílové barvy.

## **Přidejte rozostření, průhlednost a alfa efekty**

[AddBlurEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) ovlivňuje všechny barevné kanály, včetně alfa. Nastavte `grow` na `true`, pokud rozostřený okraj může přesáhnout původní okraje obrázku.

Pro jednotnou průhlednost použijte [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Násobí každou existující hodnotu alfa, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) naopak přiřadí jednu hodnotu alfa všem pixelům. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) převádí alfa na dvě úrovně podle prahu.

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

Další operace alfa bez parametrů zahrnují [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), který učiní každou nenulovou alfu plně neprůhlednou; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), který učiní každou alfu pod 100 % plně průhlednou; a [AddAlphaInverseEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), který mění alfu na `100% - alfa`.

## **Sestavte řazený řetězec efektů**

Každá metoda `Add...Effect` přidá novou operaci na konec kolekce. Vykreslovací engine používá kolekci jako řazený potrubní pás: výstup operace 0 se stane vstupem operace 1 a tak dále. V důsledku toho může stejná sada operací v jiném pořadí vytvořit odlišný obrázek.

Například odstín šedi následovaný tónováním nejprve odstraní chromatickou informaci a pak přetónuje výsledek luminance. Tónování následované odstínem šedi zase odstraní tónování. Podobně náhrada alfa může přepsat hodnoty alfa vypočítané dřívějšími operacemi, zatímco modulace alfa zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec čtyř operací, uloží jej jako PPTX, otevře prezentaci znovu, zkontroluje typy operací i jejich pořadí a vykreslí výsledek po opětovném otevření:

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

Kolekce nevyžaduje kompatibilní matici, která by omezovala barvy, alfa a rozostření na samostatné řetězce. Mohou být kombinovány, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraní RGB variaci vytvořenou předchozími barevnými efekty; odstín šedi po duotónu odstraní dvě vybrané barvy; a efekty alfa ceiling, floor, replacement nebo bi‑level mohou zrušit detaile alfa vytvořené dříve. Sestavujte řetězec podle požadované sekvence zpracování pixelů, nikoli jako neuspořádané příznaky formátování.

## **Prozkoumejte editovatelné a efektivní hodnoty**

Editovatelná operace je objekt uložený v `ISlidesPicture.ImageTransform`. V závislosti na efektu může přímo vystavovat zapisovatelné členy. Například [IBlur](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iblur/) vystavuje zapisovatelný `Radius` a `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/ialphamodulatefixed/) vystavuje zapisovatelný `Amount` a [IAlphaBiLevel](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/ialphabilevel/) vystavuje zapisovatelný `Threshold`. Barevné efekty jako [IDuotone](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iduotone/) vystavují mutable objekty [IColorFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/icolorformat/).

Některé rozhraní operací, včetně [IBrightnessContrast](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/itint/) a [IAlphaReplace](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/ialphareplace/), neexponují své vytvářející skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte novou na požadovanou pozici.

Efektivní data vrácená metodou `GetEffective()` jsou vypočítaná a pouze pro čtení. Hodí se k rozpoznání tématem závislých barev a ke čtení normalizovaných hodnot, které vykreslovací engine používá, ale nejsou dalším editovatelným povrchem. Následující příklad prochází řetězec a kontroluje efektivní hodnoty tam, kde API je poskytuje:

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

Efekty bez parametrů, jako odstín šedi, alfa ceiling a alfa inverse, stále mají objekt s efektivními daty, ale není co tisknout jako skalární nastavení. Jejich přítomnost a pozice v kolekci jsou důležité informace.

## **Odstraňte nebo vymažte transformace obrázku**

Použijte [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) k odebrání jedné operace podle indexu. Protože se indexy po odebrání posouvají, nejprve najděte cílovou operaci a až po procházení ji odstraňte. Metodu `Clear()` použijte k odstranění celého řetězce.

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

Odstranění nebo vymazání transformací mění jen formátování obrázku. Neodstraňuje, nekomeprimuje ani jinak nemění znovu použité zdroje [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).

## **Zvažte formáty prezentací a cílové exporty**

Transformace obrázku pocházejí z DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX však nekaždá operace má stejnou přenositelnost:

- Standardní operace DrawingML jako luminance, odstín šedi, duotón, tónování, HSL, rozostření a běžné alfa operace mají nejlepší šanci přežít PPTX round‑trip. Vždy po uložení souboru otevřete znovu a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010, nikoli standardní operace DrawingML luminance. Lze jej použít pro renderování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelným [IBrightnessContrast](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/ibrightnesscontrast/). Pro trvalé úpravy jasu a kontrastu upřednostněte [AddLuminanceEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/).
- Binární formát PPT předchází plnému modelu efektů DrawingML. Ukládání do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako formát pro ověření komplexního editovatelného řetězce.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů použije podporovaný řetězec pro vytvořený vzhled. Tyto výstupy neobsahují editovatelnou `IImageTransformOperationCollection`; rastrové formáty výsledek zploští do pixelů a dokumentové/vektorové exporty ukládají vlastní reprezentaci renderování.
- Efekty nečiní propojený obrázek samostatně uložitelným. Renderování propojeného obrázku stále závisí na dostupnosti propojeného zdroje při načítání prezentace.

Různí spotřebitelé prezentací mohou renderovat okrajové případy odlišně, zvláště když jsou kombinovány několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy otestujte jak editovatelný round‑trip, tak finální exportní formát se stejnou verzí Aspose.Slides používanou ve výrobě.

## **Často kladené otázky**

**Mění efekty transformace obrázku vložená data obrázku?**

Ne. Operace patří k `ISlidesPicture` používanému výplní obrázku. Bajty podkladového `IPPImage` zůstávají beze změny.

**Budou dva rámečky obrázku, které používají stejný obrázek, sdílet své efekty?**

Ne. Opakované použití `IPPImage` snižuje duplicitní data obrázku, ale každý rámeček obrázku má obvykle vlastní `ISlidesPicture` a vlastní kolekci transformací obrázku.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom řazeném řetězci. Zvažte, jak každá operace ovlivňuje výstup předchozí, protože operace náhrady a prahu mohou zrušit dřívější barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty pouze pro čtení?**

Efektivní data představují vypočítané hodnoty použité pro renderování, včetně rozpoznaných barev. Upravit můžete operaci uloženou v kolekci transformací, pokud má zapisovatelné členy; jinak ji odstraňte a přidejte novou s novými parametry.

**Jaký formát použít k zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Starší PPT nemůže reprezentovat celý model efektů DrawingML a renderované exportní formáty zachovávají pouze vzhled, ne editovatelné operace transformace.