---
title: Képkockák kezelése prezentációkban .NET-ben
linktitle: Képkocka
type: docs
weight: 10
url: /hu/net/picture-frame/
keywords:
- képkocka
- képkocka hozzáadása
- képkocka létrehozása
- beágyazott kép
- kapcsolt kép
- kép kinyerése
- raszteres kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkocka formázása
- relatív skálázás
- képhatás
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Képkockák létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A képkocka egy dián lévő alakzat, amely egy képet jelenít meg. Az Aspose.Slides-ben a képernyőforrás és a megjelenítő alakzat külön objektumok: egy [Prezentáció](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) rendelkezik beágyazott képernyőforrásokkal a [Images](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/images/) gyűjteménye segítségével, míg egy [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgatását, vágását, képhatásait és egyéb kereti beállításait.

Ez a szétválasztás akkor hasznos, ha ugyanazt a képet többször is meg kell jeleníteni. Add hozzá a képet egyszer a prezentációhoz, őrizd meg a visszakapott [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/)-t, és használd azt a képernyőforrást képkockák létrehozásakor.

A képkockák raszteres képeket (például PNG vagy JPEG) és vektoros SVG képeket is tartalmazhatnak. Továbbá hivatkozhatnak kapcsolt képekre is ahelyett, hogy a képadatokat a prezentációba tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű eldönteni, hogyan legyen a kép tárolva, mielőtt a formázás vagy optimalizálás megtörténik.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén add hozzá a képadatokat a prezentációhoz, és hozz létre egy képkockát az [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addpictureframe/) segítségével. A kép a prezentáció csomagjának részévé válik, így a prezentáció önmagában is használható, amikor egy másik számítógépre kerül.

Az alábbi példa JPEG képet ad hozzá, a kép natív méreteiben hoz létre egy keretet, és vonalformázást valamint forgatást alkalmaz:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

A képkocka szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti pixeles méreteket, amelyek a beágyazott képernyőforrásban tárolódnak. Ez a különbség fontos lesz, ha később vágod vagy tömöríted a képet.

## **Relatív méretezés használata**

Az [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) relatív szélesség‑ és magasság‑skálázást tesz lehetővé a kerethez. Az `1.0` érték az eredeti kép 100%-ának felel meg. A relatív skálázás hasznos, ha egy munkafolyamatnak a forráskép méretéhez viszonyítva kell megőrizni a méretarányt a végső méretek kézi kiszámítása helyett.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

A relatív skálázás a keret skálázási beállításait módosítja; nem újramintavételezi vagy tömöríti a beágyazott képet.

## **Beágyazott és kapcsolt képek**

A beágyazott kép a képadatokat a prezentáción belül tárolja, ezért a hordozhatóság és a kiszámítható megjelenítés szempontjából a legbiztonságosabb választás. A kapcsolt kép a [ISlidesPicture](https://reference.aspose.com/slides/hu/net/aspose.slides/islidespicture/) hivatkozási útvonalán keresztül tárolja a külső helyet, ahelyett, hogy a képadatokat ugyanúgy beágyazná.

A kapcsolt képek csökkenthetik a PPTX‑ben tárolt képadatok mennyiségét, de külső függőséget is bevezetnek. A kapcsolt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely megnyitja vagy rendereli a prezentációt. Ha az útvonal megváltozik, a fájl áthelyeződik, vagy a forrás nem áll rendelkezésre, a kapcsolt kép nem jelenhet meg a várt módon. Olyan prezentációk esetén, amelyeket e‑mailben kell küldeni, archiválni vagy elszigetelt környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Kapcsolt kép hozzáadása**

Az alábbi példa létrehoz egy képkockát, és egy helyi képfájlra mutat. Csak a képhivatkozást kezeli; a videó‑hivatkozás egy külön médiamunkafolyamat, és tudatosan nincs összekeverve ebben a példában.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Használd a hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használd őket pusztán tömörítés helyettesítésére: egy kis PPTX törött képfüggőségekkel általában kevésbé hasznos, mint egy nagyobb, önmagában álló prezentáció.

## **Képek kinyerése képkockákból**

Mielőtt képet nyernél ki egy meglévő prezentációból, ellenőrizd, hogy a alakzat valóban egy [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/)‑e, és hogy beágyazott képet tartalmaz. A kapcsolt képkockák nem feltétlenül tartalmaznak olyan képadatokat, amelyeket ugyanúgy ki lehetne nyerni.

### **Raszteres kép kinyerése**

A modern kép‑API közvetlenül az [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/)-t használja, és nem igényli a régebbi rendszer‑kép‑burkolót. Az alábbi példa megtalálja a dián az első beágyazott raszteres képet, és PNG‑ként menti el:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Az [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) használata a kinyert képet a kért kimeneti formátumba konvertálja. Ha a prezentációban tárolt kódolt bájtokra van szükséged a konvertált raszteres fájl helyett, használd a képforrás bináris adatát.

### **SVG kép kinyerése**

SVG kép esetén az [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) egy [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) objektumot biztosít. Ennek köszönhetően közvetlenül lekérheted az SVG‑adatokat anélkül, hogy előbb rasterizálnád a képet.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Az SVG tartalom SVG‑ként való megtartása megőrzi a vektoros forrást a prezentáción belül. A PNG vagy JPEG‑hez hasonló raszteres exportoknak szükségük van a vektor tartalom pixelre konvertálására. A PDF vagy SVG diák exportja is egy renderelési művelet, így az exportált grafika nem tekinthető az eredeti beágyazott SVG pontos bájt‑másolatának; a beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) adatot kell használni, amikor a vektorforrásra van szükség.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. A [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/) vágási értékei a forráskép méretének százalékai. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet módosítja.

Az alábbi példa biztonságosan megtalál egy képkockát, és alkalmazza a vágási értékeket:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Mivel a rejtett képadatok továbbra is jelen vannak, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszafordíthatóság, a vágott területek fizikai eltávolítása a következő szakaszban lehetséges.

## **Vágott képadatok eltávolítása**

Az [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) eltávolítja a képadatokat a jelenlegi vágási téglalap kívül, és visszaadja a keletkezett képforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizálás: a prezentáció mentése után a törölt pixelek már nem állnak rendelkezésre egy későbbi „vágás visszavonása” művelethez.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

A metódus új képforrást adhat a prezentációhoz. Ha az eredeti képet más képkockák is használják, azoknak továbbra is a meglévő forrásra van szükségük, így a vágott területek törlése nem feltétlenül csökkenti a képek összes számát. A WMF vagy EMF tartalom ezzel a módszerrel történő vágása a vágott eredményt PNG‑be rasterizálja.

## **Raszteres képek tömörítése**

Az [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/compressimage/) a raszteres kép felbontását csökkenti a képmérettől függően, ahogyan a kép megjelenik. Ugyanabban a műveletben eltávolíthatja a vágott területeket is. A metódus `true`‑t ad vissza, ha a képet átméretezték vagy levágták, és `false`‑t, ha változtatás nem volt szükséges.

Használj előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/net/aspose.slides.export/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Egy saját, pozitív DPI érték is megadható enum helyett, ha egy meghatározott célfelbontás szükséges.

A tömörítés raszteres képekre vonatkozik. Az SVG és a metafájl tartalom nem csökken ezzel a raszteres tömörítési munkafolyamattal. Ne feledd, hogy az alacsonyabb felbontású és törölt vágott területek már nem állíthatók vissza az optimalizált prezentációból. A célfelbontást a legnagyobb megtekintési vagy exportméret alapján válaszd ki, nem pedig a legkisebb DPI globális alkalmazásával.

## **Képhasználati hatások ellenőrzése**

A képhasználati hatásokat a keret által használt képen tárolják. A kép transzformációs gyűjtemény tartalmazhat olyan hatásokat, mint a fix alfa moduláció az átlátszósághoz és a luminancia a fényerő/kontraszt beállításához. Az alábbi példa biztonságosan beolvassa mindkét hatást az első képkockáról egy dián:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Ezek a hatások megváltoztatják, hogyan renderelődik a kép a keretben; nem írják felül az eredeti beágyazott kép bájtjait.

## **Képkocka geometriájának zárolása**

Az [IPictureFrameLock](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframelock/) beállítások határozzák meg, mely szerkesztési műveletek vannak letiltva egy képkockán. Például az arányzár megőrzi az alakzat arányait méretezés közben.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

A zárolás a képkocka alakzatra vonatkozik. Nem kényszeríti a forrásképet, hogy újramintavételezve vagy állandóan módosítva legyen ugyanarra az arányra.

## **StretchOffset értékek módosítása**

Ha a kép kitöltés módja „stretch”, a [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/) stretch‑offset értékei a kitöltő téglalapot definiálják a képkocka határoló keretéhez képest. A pozitív százalékok egy belső margót hoznak létre, míg a negatív százalékok egy kiterjesztést eredményeznek.

Ez eltér a vágástól. A vágási értékek meghatározzák, hogy a forráskép mely része látható; a stretch offsetek a látható kép kitöltésének téglalapját módosítják.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Használd a stretch offseteket a kitöltés elhelyezéséhez. Használd a vágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a kép tárolását és a képkocka formázását külön kezeljük:

- **Beágyazott képek** önmagukban tartalmazzák a prezentációt, és a legmegbízhatóbbak megosztáskor és szerveroldali rendereléskor, de a nagy raszteres képek növelik a PPTX méretét és a memóriahasználatot.
- **Kapcsolt képek** kisebb csomagméretet eredményezhetnek, de a prezentáció azon kívülálló fájlok elérhetőségétől függ.
- **Vágás** kezdetben nem destruktív. A rejtett pixelek a vágott területek explicit törléséig vagy tömörítés közbeni eltávolításáig beágyazva maradnak.
- **Tömörítés** jelentősen csökkentheti a fájlméretet túlnagy raszteres képek esetén, de a forrásfelbontást feláldozza. A vágott méret ismeretében kell alkalmazni.
- **SVG képek** esetén maradjanak SVG‑ként, ha a vektor megőrzése fontos. Kinyerheted a beágyazott SVG‑t közvetlenül, amikor a vektorforrásra van szükség. A raszteres diák exportja mindig a renderelt diát konvertálja pixelekre.
- **Ismétlődő képek** esetén használj meglévő [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) forrásokat, ahelyett, hogy ugyanazt a fájlt többször töltenéd be a munkafolyamatba.

Nagy prezentációk esetén a képoptimalizálás általában szelektív módon a leghatékonyabb: logókat és diagramokat tarts vektoros tartalomként, fényképeket a valós megjelenítési méretük szerint tömöríts, a vágott pixeleket csak akkor távolítsd el, ha későbbi szerkesztésre nincs szükség, és kerüld a külső hivatkozásokat, hacsak a függőségkezelés nem része a telepítési tervnek.

## **Gyakran ismételt kérdések**

**Mi a különbség egy képkocka és egy képernyőforrás között?**

Az [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) egy a prezentációhoz kapcsolódó képernyőforrást jelenti. Az [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) egy dián található alakzat, amely megjelenít egy képet, és tárolja a keretre vonatkozó geometriát és formázást, például méretet, forgatást, vágási értékeket, hatásokat és zárolásokat.

**Beágyazzam vagy kapcsoljam a képeket?**

Beágyazd a képeket, ha a prezentáció hordozhatósága, archiválása vagy külső erőforrások nélküli renderelése a cél. Kapcsold a képeket csak akkor, ha szándékosan kívül akarod tartani a képfájlokat a PPTX‑ből, és a külső helyek megbízhatóan fenntarthatók.

**Csökkenti-e a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de a pixelek megmaradnak. Használd az [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) vagy a képtömörítést vágott‑terület‑eltávolítással, ha a pixeleket végleg el lehet távolítani.

**Vissza tudom állítani a képminőséget tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raszteres felbontást, és a vágott területek eltávolítása adatveszteséget jelent. Ha később nagy felbontású szerkesztésre lehet szükség, tartsd meg az eredeti forrásképet a prezentáción kívül.

**Hogyan kell kezelni az SVG képeket?**

Tartsd az SVG tartalmat SVG‑ként, ha a vektor pontossága számít. A beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) közvetlenül kinyerhető. Egy diát PNG vagy JPEG‑re exportálni rasterizálja az SVG‑t a diakép részeként.

**Hogyan kerüljük el a nem biztonságos cast-eket meglévő diák olvasásakor?**

Ellenőrizd az alakzat típusát, mielőtt képkocka‑specifikus tagokhoz férnél hozzá. Az [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) mintázat‑illesztés vagy a shape‑gyűjtemény szűrése ezzel az interfésszel megakadályozza a hibás cast‑eket, és lehetővé teszi, hogy a kód kezelje a képkockákat nem tartalmazó diákot.