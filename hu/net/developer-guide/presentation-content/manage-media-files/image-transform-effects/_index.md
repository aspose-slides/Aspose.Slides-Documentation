---
title: Képtranszformációs effektusok kezelése prezentációkban .NET segítségével
linktitle: Képtranszformációs effektusok
type: docs
weight: 11
url: /hu/net/image-transform-effects/
keywords:
- képtranszformáció
- képhatás
- fényerő
- kontraszt
- szürkeárnyalatos
- duotone
- színárnyalat
- HSL
- színcsere
- elmosás
- átlátszóság
- alfa effektus
- hatáslánc
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alkalmazza, láncba fogja, ellenőrizze, távolítsa el és ellenőrizze a képtranszformációs effektusokat képkockákhoz az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides a képi állításokat rendezett gyűjteményként képzi meg a képtranszformációs műveletekből. Egy képkockához kezdje a képkocka [ISlidesPicture](https://reference.aspose.com/slides/hu/net/aspose.slides/islidespicture/) objektumával, és érje el a [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/hu/net/aspose.slides/islidespicture/imagetransform/)-t. A visszaadott [IImageTransformOperationCollection](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/) lehetővé teszi műveletek hozzáadását, felsorolását, vizsgálatát, eltávolítását és a hatások törlését az eredeti kép bájtjainak újraírása nélkül.

Ez a cikk bemutat egy teljes munkafolyamatot fényerő‑kontraszt, színátalakítások, elmosás, átlátszóság, rendezett hatásláncok, hatékony értékek, eltávolítás és PPTX round‑trip ellenőrzés esetén.

## **Az effektus tulajdonjogának és a kép újrahasználatának megértése**

Egy kép erőforrás és a megjelenítő kép két külön objektum:

- [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) tárolja vagy hivatkozik a prezentáció által birtokolt forráskép adataira.
- [ISlidesPicture](https://reference.aspose.com/slides/hu/net/aspose.slides/islidespicture/) egy képkitöltéshez tartozik, hivatkozik egy kép erőforrásra, miközben tárolja a képtranszformációk gyűjteményét.
- [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) a dia alakja, amely a megfelelő képkitöltést, geometriát, vágási beállításokat és egyéb keret‑szintű formázást birtokolja.

Ezért a képtranszformációs műveletek **nem** módosítják a [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) bájtjait. Amikor ugyanazt az `IPPImage`‑t többször adja át a [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addpictureframe/) metódusnak, minden új képkocka kap egy saját `ISlidesPicture`‑t és egy saját transzformáció‑gyűjteményt. A szürkeárnyalatos hatás egy kerethez nem teszi szürkeárnyalatosá a többi keretet, még ha mindegyik ugyanazt az beágyazott kép erőforrást használja is.

Ugyanez az `ISlidesPicture.ImageTransform` modell más képkitöltéseknél is használatos, például alakzat vagy dia háttér esetén. Az alábbi példák a képkockákra fókuszálnak.

## **Érvényes paramétertartományok és mértékegységek használata**

A bemutatott módszerek a következő szemantikai tartományokat és mértékegységeket alkalmazzák. Tartsa a értékeket ezekben a tartományokban, még akkor is, ha egy adott könyvtárverzió nem utasítja el azonnal a tartományon kívüli értékeket; a célprezentáció formátuma normalizálhatja, elhagyhatja vagy elutasíthatja a hibás adatokat mentéskor vagy amikor a PowerPoint megnyitja a fájlt.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` és `100` között, százalék; `0` meghagyja az alkotóelemet változatlanul. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Nincsenek numerikus paraméterek. Az alfa változatlan marad. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Két szín a sötét és a világos pixelekhez. A `System.Drawing.Color` RGB és alfa csatornái `0`‑tól `255`‑ig terjednek. |
| [AddTintEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | A árnyalat `0` (inkluzív) és `360` (exkluzív) fok között; az érték `-100` és `100` között, százalék. |
| [AddHSLEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | A árnyalat `0`‑tól `360`‑ig fokban; a telítettség és a fényerő `-100`‑tól `100`‑ig, százalék. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig terjednek. A meglévő alfa értékek változatlanok. |
| [AddBlurEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | A sugár nemnegatív és pontban mérhető; a `grow` logikai érték, amely meghatározza, hogy a elmosott tartalom túlnyúlhat-e az eredeti határokon. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nemnegatív százalék. Az `0`‑tól `100`‑ig terjedő értékek a szokásos átlátszatlanság skálázást jelentik: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszatlanság. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél nagyobb vagy egyenlő értékek átlátszatlanná. |

Fix alfa‑moduláció esetén az átlátszóság és az átlátszatlanság kiegészítik egymást. Például a 35 % átlátszóság a 65 % alfa‑modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) egy [IBrightnessContrast](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/ibrightnesscontrast/) műveletet ad vissza. Skáláris beállításait a művelet létrehozásakor adjuk meg. Az [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/brightnesscontrast/geteffective/) számított, csak‑olvasásra szánt értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 % fényerőt és 20 % kontrasztot ad hozzá, majd előnézetet renderel anélkül, hogy módosítaná a beágyazott képet:

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

[BrightnessContrast](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/brightnesscontrast/) egy Office 2010 képeffekt‑kiterjesztés, és kevésbé hordozható, mint a szabványos DrawingML fényerő‑effekt. Amikor a fényerő és a kontraszt szerkeszthető maradjon egy PPTX round‑trip után, használja a [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)‑et, és ellenőrizze az eredményt a fájl újbóli megnyitása után. A formátumkorlátozások szakaszban részletesebben kifejtésre kerül ez a különbség.

## **Színátalakítások alkalmazása**

A színeffektek önállóan alkalmazhatók különböző képkockákra, amelyek ugyanazt a kép erőforrást használják. Az alábbi példa öt keretet hoz létre, és rájuk alkalmazza a szürkeárnyalatos, duotone, árnyalat, HSL‑korrekció és színcserét.

[IDuotone](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iduotone/) két önállóan szerkeszthető színparamétert tartalmaz: a `Color1` a sötét pixeleket, a `Color2` a világos pixeleket rendeli hozzá. Ez egy olyan effektus példája, amelynek beállításai komplexebbek egy egyszerű skalár értéknél.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) minden pixel színét egy fix színre cseréli, miközben megőrzi az alfat. Ez különbözik a [AddColorChangeEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)-től, amely egy forrás‑színt egy másikra térképezi, és mindkét színformátumot ki is téri.

## **Elmosás, átlátszóság és alfa‑effektek hozzáadása**

[AddBlurEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) minden színcsatornát, köztük az alfat, érint. Állítsa a `grow` értékét `true`‑ra, ha az elmosott él meghaladhatja az eredeti kép határait.

Egységes átlátszóság esetén használja a [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)-et. Ez minden meglévő alfa‑értéket megszoroz, így a részben átlátszó pixelek arányosan eltérőek maradnak. Az [AddAlphaReplaceEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) ehelyett egyetlen alfa‑értéket rendel minden pixelhez. Az [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) az alfat két szintre konvertálja egy küszöb alapján.

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

Más, paraméter‑mentes alfa‑műveletek: a [AddAlphaCeilingEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) minden nem‑nulla alfat teljesen átlátszatlanná teszi; a [AddAlphaFloorEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) minden 100 % alatti alfat teljesen átlátszóvá alakítja; valamint az [AddAlphaInverseEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), amely az alfat `100% - alfa` értékre változtatja.

## **Rendezett effektuslánc felépítése**

Minden `Add...Effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezeték‑ként használja: a 0‑ás művelet kimenete lesz az 1‑es bemenete, stb. Ennek következtében ugyanazok a műveletek más sorrendben eltérő képet eredményezhetnek.

Például a szürkeárnyalatos hatás után az árnyalat először eltávolítja a kromatikus információt, majd a luminancia eredményt színezi újra. Az árnyalat után a szürkeárnyalatos hatás visszavonja az árnyalatot. Hasonlóképpen, az alfa‑helyettesítés felülírhatja a korábbi műveletek által számított alfa‑értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségeit.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX‑ként menti, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és a sorrendet, majd rendereli a újra‑megnyitott eredményt:

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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely szín‑, alfa‑ és elmosási műveleteket külön láncokra korlátozna. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy fix színcsere eltávolítja az előző színeffektusok által létrehozott RGB‑variációkat; a duotone után a szürkeárnyalatos hatás eltávolítja a kiválasztott két színt; az alfa‑ceiling, floor, replace vagy bi‑level műveletek az előbb létrehozott alfa‑részleteket eldobhatják. Építse fel a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne tekintse elemeit rendezetlen formázási jelzőnek.

## **Szerkeszthető és hatékony értékek vizsgálata**

A szerkeszthető művelet az `ISlidesPicture.ImageTransform`‑ben tárolt objektum. Az effektustól függően közvetlenül is elérhetőek a írható tagok. Például az [IBlur](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iblur/) írható `Radius` és `Grow` mezőket kínál, az [IAlphaModulateFixed](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/ialphamodulatefixed/) írható `Amount`‑ot, az [IAlphaBiLevel](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/ialphabilevel/) pedig írható `Threshold`‑et. Az [IDuotone](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iduotone/) szín‑effektusok módosítható [IColorFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/icolorformat/) objektumokat adnak.

Néhány művelet‑interfész, például az [IBrightnessContrast](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/itint/) és az [IAlphaReplace](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/ialphareplace/), nem teszi elérhetővé a létrehozási skalárokat írásra. Ezek beállításainak módosításához távolítsa el a műveletet, és adjon hozzá egy újat a kívánt pozícióban.

A `GetEffective()`‑vel visszakapott hatékony adatok számított és csak‑olvasásra szántak. Hasznosak a témafüggő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem jelentenek újabb szerkesztési felületet. Az alábbi példa felsorolja a láncot, és a megfelelő API‑k által biztosított hatékony értékeket vizsgálja:

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

Paraméter‑mentes hatások, mint a szürkeárnyalatos, alfa‑ceiling vagy alfa‑inverse, szintén rendelkeznek hatékony‑adat objektummal, de nincs kiírandó skalár beállítás. Jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja a [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/)‑et egy művelet index szerinti eltávolításához. Mivel az indexek az eltávolítás után eltolódnak, először keresse meg a célt, majd a felsorolás után távolítsa el. A `Clear()`‑el az egész láncot törölheti.

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

A transzformációk eltávolítása vagy törlése csak a kép formázását módosítja. Nem törli, nem tömöríti újra és nem változtatja meg a újra‑használt [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) erőforrást.

## **Prezentációs formátumok és exportcélok figyelembevétele**

A képtranszformációk a DrawingML‑ből származnak, ezért a PPTX a leginkább szerkeszthető formátum a hatásláncok számára. Még PPTX esetén sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek – például luminance, szürkeárnyalatos, duotone, tint, HSL, blur és általános alfa‑műveletek – a legnagyobb eséllyel maradnak meg egy PPTX round‑trip során. Mindig nyissa meg újra a generált fájlt, és vizsgálja meg a gyűjteményt, ha a megőrzés kötelező.
- A [BrightnessContrast](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/brightnesscontrast/) egy Office 2010‑kiterjesztés, nem a szabványos DrawingML luminance művelet. Memóriabeli rendereléshez használható, de nem garantált, hogy mentés és újbóli megnyitás után szerkeszthető [IBrightnessContrast](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/ibrightnesscontrast/) marad. Inkább a [AddLuminanceEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)‑et részesítse előnyben a tartós fényerő‑kontraszt beállításokhoz.
- A bináris PPT formátum előzi a teljes DrawingML effektus‑modellt. PPT‑be mentés esetén a nem támogatott műveletek elhagyhatók, a lánc egy támogatott részhalmazra csökken, vagy a megjelenés csak közelítően jelenik meg. Ne használja a PPT‑t ellenőrzési formátumként egy összetett szerkeszthető lánc esetén.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy egyéb vizuális kimenetek a támogatott láncot alkalmazzák a megjelenéshez. Ezek a kimenetek nem tartalmaznak szerkeszthető `IImageTransformOperationCollection`‑t; a raszteres formátumok a végeredményt pixelekké lapítják, a dokumentum‑/vektoralapú exportok saját renderelési reprezentációt tárolnak.
- Az effektusok nem teszik a hivatkozott képet önállóvá. Egy hivatkozott kép renderelése továbbra is a hivatkozott erőforrás elérhetőségétől függ, amikor a prezentáció betöltődik.

Különböző prezentáció‑fogyasztók eltérően renderelhetik a szélsőséges eseteket, különösen ha több alfa‑ vagy szín‑kvantálási műveletet kombinálnak. Kritikus kimenet esetén tesztelje mind a szerkeszthető round‑tripet, mind a végleges exportformátumot az éles környezetben használt Aspose.Slides verzióval.

## **GYIK**

**Módosítják a képtranszformációs effektusok a beágyazott képadatokat?**

Nem. A műveletek az `ISlidesPicture`‑hez tartoznak, amely a képkitöltést használja. Az alapjául szolgáló `IPPImage` bájtjai változatlanok maradnak.

**Két olyan képkocka, amely ugyanazt a képet használja, megosztja az effektusokat?**

Nem. Az `IPPImage` újrafelhasználása elkerüli a duplikált képadatokat, de minden képkocka általában saját `ISlidesPicture`‑t és saját képtranszformációs gyűjteményt kap.

**Kombinálhatók a szín‑, elmosási és alfa‑effektek?**

Igen. A gyűjtemény egyetlen rendezett láncban fogadja őket. Fontolja meg, hogy az egyes műveletek hogyan befolyásolják az előző kimenetét, mivel a helyettesítő és küszöb‑műveletek eldobhatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért csak‑olvasásra szántak a hatékony értékek?**

A hatékony adatok a rendereléshez használt számított értékeket tartalmazzák, köztük a feloldott színeket. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol írható tagok vannak; egyébként távolítsa el, és adjon hozzá egy újat a kívánt létrehozási paraméterekkel.

**Melyik formátumot használjam a transzformációs lánc megőrzéséhez?**

Használjon PPTX‑et, és ellenőrizze a fájlt újbóli megnyitással. Az örökölt PPT nem képes a teljes DrawingML effektus‑modellt megjeleníteni, a renderelt exportformátumok pedig csak a megjelenést, nem pedig a szerkeszthető transzformációs műveleteket őrzik meg.