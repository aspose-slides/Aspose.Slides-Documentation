---
title: Képkeretek kezelése prezentációkban .NET-ben
linktitle: Képkeret
type: docs
weight: 10
url: /hu/net/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- hivatkozott kép
- kép kinyerése
- raszteres kép
- SVG kép
- kép levágása
- levágott területek törlése
- kép tömörítése
- StretchOffset
- képkeret formázása
- relatív méretezés
- kép effektus
- arány
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, hivatkozás, levágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A képkeret egy dia alakzat, amely képet jelenít meg. Az Aspose.Slides-ban a képernyő erőforrása és a megjelenítő alakzat külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) a beágyazott képernyő erőforrásokat a [Images](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/images/) gyűjteményén keresztül kezeli, míg egy [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, elforgatását, levágását, képeffektusait és egyéb keretszintű beállításait.

Ez a szétválasztás hasznos, ha ugyanaz a kép többször is megjelenik. Adja hozzá a képet egyszer a prezentációhoz, tartsa meg a visszaadott [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumot, és használja ezt a képernyő erőforrást a képkeretek létrehozásakor.

A képkeretek raster képeket (például PNG vagy JPEG) és vektor SVG képeket is tartalmazhatnak. A kép helyett hivatkozott képekre is hivatkozhatnak, ahelyett, hogy a kép bájtjait a prezentációban tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű eldönteni, hogyan tárolja a képet, mielőtt formázást vagy optimalizálást végezne.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adja hozzá a képadatokat a prezentációhoz, és hozzon létre egy képkeretet a [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addpictureframe/) metódussal. A kép a prezentációcsomag része lesz, így a prezentáció önmagában is működik, amikor egy másik számítógépre helyezik át.

Az alábbi példa JPEG képet ad hozzá, a kép natív méreteiben hoz létre egy keretet, és vonalformázást valamint elforgatást alkalmaz:

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

A képkeret szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti pixeles méreteket, amelyek a beágyazott képernyő erőforrásban vannak tárolva. Ez a különbség későbbi levágás vagy tömörítés esetén válik fontosá.

## **Relatív méretezés használata**

[IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) relatív szélesség‑ és magasság‑arányt biztosít a kerethez. Az `1.0` érték az eredeti kép 100 %-ának felel meg. A relatív méretezés hasznos, ha a munkafolyamatnak a forráskép méretéhez viszonyított arányt kell megőriznie a végső méretek kézi kiszámítása helyett.

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

A relatív méretezés megváltoztatja a keret méretbeállításait; nem resample‑eli vagy tömöríti a beágyazott képet.

## **Beágyazott és hivatkozott képek**

A beágyazott kép a képadatokat a prezentációban tárolja, ezért a legbiztonságosabb választás a hordozhatóság és a kiszámítható megjelenítés szempontjából. A hivatkozott kép egy külső helyet tárol a [ISlidesPicture](https://reference.aspose.com/slides/hu/net/aspose.slides/islidespicture/) hivatkozási útvonalon keresztül, ahelyett, hogy a kép adatokat ugyanúgy beágyazná.

A hivatkozott képek csökkenthetik a PPTX-ben tárolt képadatok mennyiségét, de külső függőséget vezetnek be. A hivatkozott fájlnak elérhetőnek kell maradnia a prezentációt megnyitó vagy renderelő alkalmazás számára. Ha az útvonal megváltozik, a fájl áthelyezésre kerül, vagy a forrás nem áll rendelkezésre, a hivatkozott kép nem jelenhet meg a várt módon. Azoknál a prezentációknál, amelyeket e‑mailben kell elküldeni, archiválni vagy izolált környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Hivatkozott kép hozzáadása**

Az alábbi példa egy képkeretet hoz létre, és egy helyi képfájlra mutat. Csak a kép hivatkozásával foglalkozik; a videó hivatkozás egy külön média‑munkafolyamat, és szándékosan nincs összekeverve ebben a példában.

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

Használja a hivatkozásokat, amikor a külső fájlkezelés szándékos. Ne használja őket pusztán tömörítés helyettesítésére: egy kis PPTX törött kép‑függőségekkel általában kevésbé hasznos, mint egy nagyobb önálló prezentáció.

## **Képek kinyerése a képkeretekből**

Mielőtt képet nyerne ki egy meglévő prezentációból, ellenőrizze, hogy az alakzat ténylegesen egy [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/)‑e, és hogy tartalmaz‑e beágyazott képet. A hivatkozott képkeretek nem feltétlenül tartalmaznak olyan kép‑bájtokat, amelyeket ugyanúgy ki lehetne nyerni.

### **Raster kép kinyerése**

A modern kép‑API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/)‑t használja, és nem igényli a régebbi rendszer‑kép wrapper‑t. Az alábbi példa megtalálja az első beágyazott raster képet egy dián, és PNG‑ként menti el:

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

A [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) használatával a kinyert kép a kért kimeneti formátumba kerül konvertálásra. Ha a prezentációban tárolt kódolt bájtokra van szüksége, a konvertált raster fájl helyett használja a kép erőforrás bináris adatait.

### **SVG kép kinyerése**

SVG kép esetén a [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) egy [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) objektumot biztosít. Ez lehetővé teszi, hogy közvetlenül a SVG adatot szerezze meg, anélkül, hogy a képet először rasterizálná.

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

Az SVG tartalom SVG‑ként való megőrzése biztosítja a vektor forrást a prezentációban. A PNG vagy JPEG‑s raster exportok kötelezően pixelre renderelik a vektort. A PDF vagy SVG dia‑export is egy renderelési művelet, így az exportált grafika nem tekinthető bite‑pontos másolatnak az eredeti beágyazott SVG‑ből; használja a beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) adatot, ha a vektor forrásra van szükség.

## **Kép levágása**

A levágás megváltoztatja, hogy a kép mely része látható a kereten belül. A [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/) levágási értékei a forráskép méreteinek százalékai. A levágás eleinte nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet változtatja.

Az alábbi példa biztonságosan megtalál egy képkeretet, és alkalmazza a levágási értékeket:

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

Mivel a rejtett képadatok még mindig jelen vannak, a levágást később módosíthatja anélkül, hogy elveszítené az eredeti pixeleket. Ha a fájlméret fontosabb, mint a visszavonhatóság, a levágott területek fizikailag eltávolíthatók a következő szakaszban leírt módon.

## **Levágott képadatok eltávolítása**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) eltávolítja a képadatokat a jelenlegi levágási téglalapon kívül, és visszaadja a keletkezett kép‑erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után a eltávolított pixelek már nem állnak rendelkezésre későbbi visszalevágáshoz.

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

A metódus új kép‑erőforrást adhat a prezentációhoz. Ha az eredeti képet más képkeretek is használják, azoknak továbbra is a meglévő erőforrásra van szükségük, így a levágott területek törlése nem feltétlenül csökkenti a képek teljes számát. WMF vagy EMF tartalom levágása ezzel a módszerrel a levágott eredményt PNG‑re rasterizálja.

## **Raster képek tömörítése**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/compressimage/) csökkenti a raster kép felbontását a kép megjelenített méretéhez viszonyítva. Ugyanebben a műveletben eltávolíthatja a levágott területeket is. A metódus `true`‑t ad vissza, ha a kép mérete módosult vagy levágás történt, és `false`‑t, ha nem volt szükség változtatásra.

Használjon előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/net/aspose.slides.export/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

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

Speciális cél esetén egy saját, pozitív DPI érték is megadható enum érték helyett.

A tömörítés raster képekre vonatkozik. SVG és metafájl tartalom nem csökken ezen a raster‑tömörítési munkafolyamaton. Ne feledje, hogy az alacsonyabb felbontás és a törölt levágott területek már nem állíthatók vissza a optimalizált prezentációból. Válasszon célfelbontást a legnagyobb tényleges megjelenítési vagy exportálási méret alapján, ne pedig a legkisebb DPI‑t globálisan alkalmazza.

## **Kép‑transzformációs hatások kezelése**

A fényerő, kontraszt, színátalakítások, elmosás, alfa‑hatások, rendelt láncok, ellenőrzés, eltávolítás és round‑trip ellenőrzés teljes munkafolyamatairól lásd a [Image Transform Effects](/slides/hu/net/image-transform-effects/) oldalon.

## **Képkeret geometria zárolása**

Az [IPictureFrameLock](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframelock/) beállítások szabályozzák, hogy mely szerkesztési műveletek vannak letiltva egy képkeretnél. Például az arányzár a méretezés során megtartja az alakzat arányait.

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

A zár a képkeret alakzatára vonatkozik. Nem kényszeríti a forrásképet, hogy ugyanarra az arányra legyen resample‑olva vagy végleg módosítva.

## **StretchOffset értékek módosítása**

Amikor a kép kitöltési módja „stretch”, a [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/) stretch‑offset értékei a kitöltési téglalapot a képkeret határoló keretéhez képest definiálják. A pozitív százalékok a szélről beljebb hoznak, a negatív százalékok pedig kifelé.

Ez különbözik a levágástól. A levágási értékek határozzák meg, hogy a forráskép mely része látható; a stretch‑offsetok a látható kitöltés téglalapját módosítják.

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

Használja a stretch‑offsetokat a kitöltés elhelyezéséhez. Használja a levágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a képtárolás és a képkeret‑formázás különállóként kezelődik:

- **Beágyazott képek** önmagukban tartalmazzák a prezentációt, és a legmegbízhatóbbak megosztás és szerver‑oldali renderelés esetén, de a nagy raster képek megnövelik a PPTX méretét és a memóriahasználatot.
- **Hivatkozott képek** kisebb csomagot eredményezhetnek, de a prezentáció a külső fájlok elérhetőségétől függ.
- **Levágás** eleinte nem destruktív. A rejtett pixelek addig be vannak ágyazva, amíg a levágott területeket kifejezetten nem törlik vagy nem távolítják el tömörítés közben.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlnagy raster képek esetén, de a forrásfelbontás feláldozásával jár. A kívánt dián megjelenő méret ismeretében kell alkalmazni.
- **SVG képek** esetén a vektor megőrzése érdekében SVG‑ként kell megtartani őket. A beágyazott SVG közvetlen kinyerése akkor szükséges, ha a vektor forrásra van szükség. A raster dia‑exportok mindig a diaszöveget pixelekre konvertálják.
- **Ismétlődő képek** esetén a meglévő [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) erőforrás újrafelhasználása ajánlott, ahelyett, hogy ugyanazt a fájlt többször betöltené a munkafolyamatba.

Nagy prezentációk esetén a képek optimalizálása általában akkor a leghatékonyabb, ha szelektíven történik: tartsa a logókat és diagramokat vektor tartalomként, tömörítse a fényképeket a tényleges megjelenítési méretüknek megfelelően, csak akkor távolítsa el a levágott pixeleket, ha a későbbi szerkesztés nem szükséges, és kerüljön a külső hivatkozásokat, hacsak a függőségkezelés nem része a telepítési tervnek.

## **GYIK**

**Mi a különbség a képkeret és a kép‑erőforrás között?**

Az [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) egy a prezentációhoz társított kép‑erőforrást képviseli. Egy [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) egy dia alakzata, amely egy képet jelenít meg, és a keretszintű geometriát és formázást tárolja, mint például méret, elforgatás, levágási értékek, effektusok és zárolások.

**Beágyazzam vagy hivatkozzak a képekre?**

Beágyazza a képeket, ha a prezentációnak hordozhatónak, archiváltnak vagy külső források nélkül rendereltnek kell lennie. Hivatkozzon képekre csak akkor, ha a képfájlok kívül tartása szándékos, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti-e a levágás a PPTX fájlméretét?**

Nem önmagában. A szokásos levágási beállítások elrejtik a forráskép részeit, de a pixelek továbbra is tárolódnak. Használja a [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) vagy a kép‑tömörítést levágott‑terület-eltávolítással, ha ezeket a pixeleket véglegesen el akarja távolítani.

**Visszaállítható a képminőség a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a levágott területek eltávolítása adatvesztést eredményez. Tartsa meg az eredeti forrásképet a prezentáción kívül, ha később magas felbontású szerkesztésre lehet szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsa az SVG tartalmat SVG‑ként, ha a vektor pontossága fontos. A beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) közvetlenül kinyerhető. A dia raster formátumba (PNG vagy JPEG) való renderelése a SVG‑t pixelekre alakítja.

**Hogyan kerülhető el a nem biztonságos cast használata meglévő diák olvasásakor?**

Ellenőrizze a forma típusát, mielőtt képkeret‑specifikus tagokat használna. Az [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) mintázat‑illesztés vagy a forma‑gyűjtemény ezen interfész alapján való szűrése elkerüli az érvénytelen cast‑eket, és lehetővé teszi, hogy a kód olyan diákat is kezeljen, amelyek nem tartalmaznak képkeretet.