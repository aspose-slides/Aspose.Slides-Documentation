---
title: Képtranszformációs hatások kezelése prezentációkban .NET segítségével
linktitle: Képtranszformációs hatások
type: docs
weight: 11
url: /hu/net/image-transform-effects/
keywords:
- képtranszformáció
- képhatás
- fényerő
- kontraszt
- szürkeárnyalat
- kétárnyalatos
- színárnyalat
- HSL
- színcsere
- elmosás
- átlátszóság
- alfa hatás
- hatáslánc
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alkalmazza, láncolja, ellenőrizze, távolítsa el és ellenőrizze a képtranszformációs hatásokat képkeretekhez az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Aspose.Slides a képbeállításokat a képtranszformációs műveletek rendezett gyűjteményeként jeleníti meg. Egy képkerethez kezdje a keret [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) használatával, és érje el a [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/). A visszaadott [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) lehetővé teszi, hogy műveleteket hozzáadjon, felsorolja, ellenőrizze, eltávolítsa és törölje a hatásokat anélkül, hogy újraírná az eredeti kép bájtjait.

Ez a cikk bemutat egy teljes munkafolyamatot a fényerő és kontraszt, színátalakítások, elmosás, átlátszóság, rendezett hatásláncok, tényleges értékek, eltávolítás és PPTX körtúra-ellenőrzést.

## **Az effektusok tulajdonlása és a kép újrafelhasználása**

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) tárolja vagy hivatkozik a prezentációhoz tartozó forráskép adataira.  
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) egy képkitöltéshez tartozik, és egy képernyő erőforrásra hivatkozik, miközben tárolja a képtranszformációs gyűjteményt.  
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) a dia alakzat, amely a megfelelő képkitöltést, geometriát, vágási beállításokat és egyéb keretszintű formázásokat birtokolja.

Ezért a képtranszformációs műveletek nem módosítják a [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) bájtjait. Ha ugyanazt a `IPPImage`-t több mint egyszer adjuk át a [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) metódusnak, minden új képkeret saját `ISlidesPicture`-t és saját transzformációs gyűjteményt kap. Az egyik kereten a szürkeárnyalatos hatás alkalmazása nem teszi a többi keretet szürkeárnyalatosra, még ha mindegyik ugyanazt a beágyazott képernyő erőforrást is újrahasználja.

Ugyanez a `ISlidesPicture.ImageTransform` modell más képkitöltéseknél is használható, például alakzat vagy dia háttér. Az alábbi példák a képkeretekre összpontosítanak.

## **Érvényes paramétertartományok és egységek használata**

A bemutatott metódusok a következő szemantikai tartományokat és egységeket használják. Tartsuk a értékeket ebben a tartományban, még ha egy adott könyvtárverzió nem is utasítja el azonnal az érvénytelen értékeket; a célprezentáció formátuma normalizálhat, elhagyhat vagy elutasíthat érvénytelen adatokat mentéskor vagy amikor a PowerPoint megnyitja a fájlt.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` és `100` közötti, százalék; `0` változatlanul hagyja az összetevőt. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Nincsenek numerikus paraméterek. Az alfa változatlan. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Két szín a sötét és világos pixelekhez. Az `System.Drawing.Color` RGB és alfa csatornái `0` és `255` között vannak. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | A színárnyalat `0`-tól (záró) `360`-ig (kizáró) fokban van megadva; az összeg `-100` és `100` között, százalék. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | A színárnyalat `0`-tól (záró) `360`-ig (kizáró) fokban; a telítettség és a fényerő `-100` és `100` között, százalék. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | A helyettesítő szín csatornaértékei `0` és `255` között vannak. A meglévő alfa értékek változatlanok. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | A sugár nemnegatív és pontban mérhető; a `grow` logikai érték, amely azt szabályozza, hogy a elmosott tartalom túlnyúlhat-e az eredeti határokon. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nemnegatív százalék. Használja a `0` és `100` közötti értéket az átlátszatlanság szabványos skálázásához: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` és `100` közötti, százalékos átlátszatlanság. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` és `100` közötti, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél nagyobb vagy egyenlő értékek átlátszatlanná. |

A rögzített alfa moduláció esetén az átlátszóság és átlátszatlanság kiegészítőek. Például a 35 % átlátszóság a 65 % alfa‑modulációs összegnek felel meg.

## **Fényerő és kontraszt alkalmazása**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) egy [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) műveletet ad vissza. A skalár beállítások a művelet létrehozásakor kerülnek megadásra. Az [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) kiszámított, csak olvasható értékeket ad vissza, amelyeket ellenőrizhet vagy naplózhat.

A következő példa 15 % fényerővel és 20 % kontraszttal növeli a képet, majd előnézetet renderel anélkül, hogy módosítaná a beágyazott képet:

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

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) egy Office 2010 kép‑effektus kiterjesztés, és kevésbé hordozható, mint a szabványos DrawingML fényerő hatás. Ha a fényerőt és kontrasztot a PPTX körtúra után is szerkeszthetőnek kell maradnia, használja az [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)‑t, és ellenőrizze az eredményt a fájl újranyitása után. A formátumkorlátozások szakasz részletesen kifejti ezt a különbséget.

## **Színátalakítások alkalmazása**

A szín‑effekteket függetlenül alkalmazhatja különböző képkeretekre, amelyek ugyanazt a képernyő erőforrást újrahasználják. A következő példa öt keretet hoz létre, és szürkeárnyalatot, duotone‑t, színárnyalatot, HSL‑állítást és színcserét alkalmaz.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) két függetlenül szerkeszthető színparamétert tartalmaz: a `Color1` a sötét pixeleket, a `Color2` a világos pixeleket térképezi. Ez egy jó példa egy olyan effektusra, amelynek beállításai összetettebbek, mint egy egyszerű skalár érték.

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

[AAddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) minden pixel színét egy fix színre cseréli, miközben megőrzi az alfat. Ez eltér a [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), amely egy forrás színt egy másikra képezi, és mind a forrás, mind a cél színformátumokat megmutatja.

### **Luminancia küszöb alkalmazása**

Egy luminancia küszöb megkönnyítheti a gyenge nyomok megkülönböztetését egy beolvasott oldalon a háttértől. A [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) megőrzi a köztes szürke árnyalatokat. A [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) a luminanciát fekete vagy fehér színre képezi, míg a [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) egy átlátszósági küszöböt alkalmaz.

A luminancia küszöb 0 % és 100 % között terjed, mindkettő beleértve. A küszöbnél alacsonyabb pixelek feketék lesznek. A küszöbnél egyenlő vagy nagyobb pixelek fehérek lesznek. A küszöb emelése több árnyalatot tesz feketévé, mivel több pixel esik a határ alá.

Töltse le a [grayscale-swatches.png](grayscale-swatches.png) fájlt a munkakönyvtárba. Minden címke az eredeti szürke szintet adja meg 0‑tól 255‑ig terjedő skálán. A példa az eredetit helyezi két másolat mellé, és minden másolat küszöbét elmenti a prezentációba.

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

Nyissa meg a kimeneti prezentációt PowerPointban a három keret összehasonlításához. A 96 címkéjű színmintában körülbelül 38 % luminancia van (96 a 255‑ből). 20 % küszöbnél fehér, 60 % küszöbnél fekete lesz.

![Eredeti szürkeárnyalatos minták a fekete‑fehér eredményekkel 20 % és 60 % luminancia küszöbök mellett](luminance-threshold.png)

## **Elmosás, átlátszóság és alfa‑effektek hozzáadása**

[AAddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) minden színcsatornára, beleértve az alfat is, hat. Állítsa a `grow` értékét `true`‑ra, ha a elmosott él túlnyúlhat az eredeti kép határain.

Egyenletes átlátszósághoz használja a [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Ez minden meglévő alfa értéket megszorozza, így a részben átlátszó pixelek arányosan különbözőek maradnak. A [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) ehelyett egyetlen alfa értéket ad minden pixelnek. A [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) alfa‑értékeket két szintre konvertál egy küszöb alapján.

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

Egyéb paraméter nélküli alfa‑műveletek közé tartozik a [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), amely minden nemnulla alfat teljesen átlátszatlanná teszi; a [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), amely minden 100 %-nál kisebb alfat teljesen átlátszóvá teszi; és a [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), amely az alfat `100% - alfa` értékre változtatja.

## **Rendezett effektuslánc felépítése**

Minden `Add...Effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezetéknek tekinti: a 0‑s művelet kimenete a 1‑es bemenetévé válik, és így tovább. Ennek következtében ugyanazok a műveletek más sorrendben más képet eredményezhetnek.

Például a szürkeárnyalatot követő színárnyalat először eltávolítja a kromatikus információt, majd színez vissza a luminancia eredményt. A színárnyalatot követő szürkeárnyalat ismét eltávolítja a színárnyalatot. Hasonlóképpen, az alfa‑cserélés felülírhatja a korábbi műveletek által számított alfa értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségét.

A következő példa egy négy műveletből álló láncot épít, PPTX‑ként menti, újra megnyitja a prezentációt, ellenőrzi mind a művelet típusait, mind a sorrendet, majd rendereli az újra megnyitott eredményt:

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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely a szín, alfa és elmosás műveleteket külön láncokra korlátozná. Kombinálhatók, de a kombinációk nem mindig hasznosak. A fix színcsere eltávolítja a korábbi szín‑effektusok által létrehozott RGB‑variációt; a szürkeárnyalat a duotone után eltávolítja a két kiválasztott színt; és az alfa‑ceil, floor, replace vagy bi‑level műveletek eldobhatják a korábban létrehozott alfa‑részleteket. Építse a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne pedig rendezetlen formázási jelzőként kezelje.


<!-- visual-explanation:image-transform-effects:start -->
[![Eredeti szürkeárnyalatos minták a fekete‑fehér eredményekkel 20 % és 60 % luminancia küszöbök mellett](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Szerkeszthető és tényleges értékek vizsgálata**

Egy szerkeszthető művelet az a objektum, amely a `ISlidesPicture.ImageTransform`‑ben van tárolva. Az effektustól függően közvetlenül elérhetőek lehetnek írási tagok. Például a [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) írható `Radius` és `Grow` tagokat mutat, az [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) írható `Amount` tagot, az [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) írható `Threshold` tagot. A [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) szerkeszthető [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) objektumokat mutat.

Néhány művelet‑interfész, beleértve az [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/), és [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), nem teszi írási tulajdonságként elérhetővé a létrehozáskor megadott skalárokat. Ezeknek a beállításoknak a módosításához távolítsa el a műveletet, és adjon hozzá egy újat a kívánt pozíción.

A `GetEffective()` által visszaadott tényleges adat számított és csak olvasható. Hasznos a témától függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy újabb szerkesztési felület. A következő példa felsorolja a láncot, és megvizsgálja a tényleges értékeket, ahol a megfelelő API biztosítja őket:

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

Paraméter nélküli effektek, mint a szürkeárnyalat, alfa‑ceil, és alfa‑inverse is rendelkeznek tényleges‑adat objektummal, de nincs skalár beállítás, amit ki lehetne nyomtatni. A jelenlétük és a gyűjteményben betöltött helyük a fontos információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja az [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) metódust egy művelet index szerinti eltávolításához. Mivel az indexek eltávolítás után eltolódnak, először keresse meg a célt, majd az enumerálás után távolítsa el. A `Clear()`‑el eltávolíthatja az egész láncot.

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

A transzformációk eltávolítása vagy törlése csak a kép formázását változtatja. Nem törli, tömöríti vagy egyéb módon módosítja a újrahasznált [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) erőforrást.

## **A prezentáció formátumok és export célpontok figyelembevétele**

A képtranszformációk a DrawingML‑ben erednek, így a PPTX a preferált szerkeszthető formátum az effektusláncok számára. Még PPTX esetén sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminancia, szürkeárnyalat, duotone, tint, HSL, elmosás és a közös alfa műveletek, a legnagyobb eséllyel maradnak meg egy PPTX körtúra során. Mindig nyissa meg a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés követelmény.
- A [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) egy Office 2010 kiterjesztés, nem a szabványos DrawingML luminancia művelet. Memóriában történő renderelésre használható, de nem garantált, hogy szerkeszthető [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) marad a PPTX mentése és újranyitása után. Inkább a [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)‑t részesítse előnyben a tartós fényerő‑kontraszt beállításokhoz.
- A bináris PPT formátum megelőzi a teljes DrawingML effektusmodellt. PPT‑re mentés esetén a nem támogatott műveletek elhagyhatók, a lánc egy támogatott részhalmazra csökkenthető, vagy a megjelenés közelítőleg reprodukálható. Ne használja a PPT‑t ellenőrzési formátumként egy összetett szerkeszthető lánchoz.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy egyéb vizuális kimenetekre renderelés esetén a támogatott lánc alkalmazásra kerül a megjelenésre. Ezek a kimenetek nem tartalmaznak szerkeszthető `IImageTransformOperationCollection`‑t; a raszter formátumok a végeredményt pixelekre lapítják, a dokumentum/vektor exportok saját renderelési reprezentációt tárolnak.
- Az effektusok nem teszik a linked képet önállóvá. A linked kép renderelése továbbra is attól függ, hogy a linked erőforrás elérhető legyen a prezentáció betöltésekor.

A különböző prezentáció fogyasztók élhelyzeteket eltérően renderelhetnek, különösen ha több alfa vagy szín‑kvantálási művelet van kombinálva. Kritikus kimenet esetén tesztelje mind a szerkeszthető körtúra, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, amelyet a termelésben használnak.

## **GYIK**

**Módosítják a képtranszformációs effektusok a beágyazott kép adatokat?**

Nem. A műveletek az képkitöltéshez használt `ISlidesPicture`‑hez tartoznak. A mögöttes `IPPImage` bájtok változatlanok maradnak.

**Megosztják-e a két képkeret, amely ugyanazt a képet újrahasználja, az effektusaikat?**

Nem. Az `IPPImage` újrahasználata megakadályozza a képadat kettőzést, de minden képkeret általában saját `ISlidesPicture`‑t és képtranszformációs gyűjteményt kap.

**Kombinálhatók a szín, elmosás és alfa effektek?**

Igen. A gyűjtemény egy rendezett láncban fogadja őket. Vegye figyelembe, hogy az egyes műveletek az előző kimenetére milyen hatással vannak, mivel a csere‑ és küszöb‑műveletek eltávolíthatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért csak olvashatóak a tényleges értékek?**

A tényleges adatok a rendereléshez használt számított értékeket jelentik, beleértve a feloldott színeket. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol írási tagok elérhetők; egyébként távolítsa el, és adjon hozzá egy újat az új létrehozási paraméterekkel.

**Melyik formátumot használjam a transzformációs lánc megőrzéséhez?**

Használjon PPTX‑et, és ellenőrizze a fájlt a újranyitással. Az örökölt PPT nem képes a teljes DrawingML effektusmodellt ábrázolni, és a renderelt export formátumok csak a megjelenést őrzik meg, nem pedig a szerkeszthető transzformációs műveleteket.