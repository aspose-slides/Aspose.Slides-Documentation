---
title: Prezentációs információk lekérése és frissítése .NET-ben
linktitle: Prezentációs információ
type: docs
weight: 30
url: /hu/net/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok szerkesztése
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel a diákat, a szerkezetet és a metaadatokat PowerPoint és OpenDocument prezentációkban .NET használatával a gyorsabb betekintés és az intelligensebb tartalomelemzés érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes meghatározni a prezentáció formátumát és beolvasni a dokumentum metaadatait anélkül, hogy teljes prezentációs objektummodellt hozna létre. Hasznos, ha fájlokat kell osztályozni, leltárt építeni, vagy tulajdonságokat ellenőrizni kell, mielőtt eldöntené, hogy betölti-e és feldolgozza-e a prezentáció tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/) és az [IPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/) segítségével, valamint a célzott frissítéseket az [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) használatával.

## **Ellenőrizze a prezentáció formátumát**

Ha már betöltött prezentációja van, tekintse meg a [Determine the Original Presentation Format](/slides/hu/net/detect-presentation-source-format/) cikket a betöltés utáni felismeréshez és a régi PPT, PPS és POT adatfolyamok korlátaihoz.

Használja a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) függvényt, hogy fájlt ellenőrizzen anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt hozna létre. Az [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/loadformat/) tulajdonság jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Könnyű prezentációs leltár összeállítása**

Ha sok prezentációs fájlt dolgoz fel, szüksége lehet egy tömör leltárra az ellenőrzéshez, indexeléshez vagy egy dokumentumkezelő rendszerhez. Ebben a forgatókönyvben használja a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) függvényt egy [IPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/) objektum megszerzéséhez, majd hívja az [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/readdocumentproperties/) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt, és nem igényli a teljes prezentációs objektummodell bejárását.

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) által nyújtott kiterjesztett tulajdonságok a következő leltárértékeket biztosítják:

| Tulajdonság | Leltár érték |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/slides/hu/) | Diák összes száma. |
| [HiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/hiddenslides/) | Rejtett diák száma. |
| [Notes](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/notes/) | Jegyzeteket tartalmazó diák száma. |
| [Paragraphs](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/paragraphs/) | Bekapcsolt bekezdések összes száma (ha elérhető). |
| [Words](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/words/) | Szavak összes száma. |
| [MultimediaClips](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/multimediaclips/) | Audio- és videoklipek összes száma. |

Az alábbi példa beolvassa ezeket az értékeket anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot hozna létre, és egy tömör leltárt ír ki. Emellett kombinálja a [HeadingPairs](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/headingpairs/) és a [TitlesOfParts](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/titlesofparts/) elemeket a betűtípusok, témák és dia címek tartalmi csoportjainak megjelenítéséhez.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Minden [IHeadingPair](https://reference.aspose.com/slides/hu/net/aspose.slides/iheadingpair/) egy csoportnevet és az adott csoportban lévő elemek számát adja meg. Az [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/titlesofparts/) egy lapos, rendezett tömb, ezért a fejlécpár által meghatározott egymást követő címek számát kell felhasználni.

### **Tárolt metaadatok és formátumkorlátok**

Az [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/readdocumentproperties/) által visszaadott leltártulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a prezentációs objektummodellt, hogy újraszámolja ezeket az értékeket erre a meghívásra. A hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavulhatnak, ha a fájlt utoljára mentő alkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédia darabszámához, valamint fejlécpárokhoz és részcímekhez. Az elérhetőség attól függ, mely tulajdonságokat írta a dokumentum előállítója.
- **PPT:** A bináris formátum tárolhat megfelelő dokumentum‑összegző tulajdonságokat. Ha egy tulajdonság hiányzik vagy a dokumentum előállítója nem frissítette, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza a diák alapján történő újraszámolás helyett.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat tartalmaznak, például oldal-, bekezdés- és szószámot, de ezek az értékek nem képeznek le minden PowerPoint‑specifikus kiterjesztett tulajdonságra. A rejtett dia, jegyzetdia, multimédia, fejlécpár és részcím metaadatok előfordulhatnak, de hiányozhatnak, és a leltártulajdonságok alapértelmezett értéket adhatnak vissza. A nulla értéket vagy az üres tömböt ne vegye tekintélyes bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat‑megközelítést leltárokhoz és előzetes ellenőrzésekhez. Töltse be a prezentációt, és vizsgálja meg a működő objektummodellt, ha az eredménynek tükröznie kell a memóriában történt változásokat, vagy ha a tényleges tartalom ellenőrzése szükséges.

## **Prezentációs tulajdonságok frissítése**

Az [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/readdocumentproperties/) által visszaadott tulajdonságok módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt hoznának létre. Alkalmazza a változtatásokat az [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) metódussal, majd írja ki a kötött prezentációt az [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/writebindedpresentation/) használatával.

Az alábbi kép az eredeti dokumentumtulajdonságokat mutatja.

![Original document properties of the PowerPoint presentation](input_properties.png)

Az alábbi példa megváltoztatja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Az alábbi kép a frissített dokumentumtulajdonságokat mutatja.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások kapcsán tekintse meg a következő cikkeket:

- [Password-Protect Presentations](/slides/hu/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/net/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak-e ágyazva, és melyek azok?**

Töltse be a prezentációt, és használja a [Presentation.FontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/fontsmanager/) osztályt. Hívja a [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getembeddedfonts/) metódust a beágyazott betűtípusok megszerzéséhez, valamint a [FontsManager.GetFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getfonts/) metódust a prezentáció által használt betűtípusokhoz. A két eredményt hasonlítsa össze, hogy megtalálja azokat a betűtípusokat, amelyek a megjelenítéshez szükségesek, de nincsenek beágyazva.

**Hogyan deríthetem gyorsan, hogy a fájl tartalmaz‑e rejtett diákot, és hány darab?**

Ha a tárolt dokumentummetaadatok elegendőek, olvassa a [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/hiddenslides/) értékét a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) és az [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/readdocumentproperties/) segítségével. Ez alkalmas egy könnyű leltárra. Ha a prezentáció memóriában módosult, a tárolt metaadat hiányozhat vagy elavult lehet, vagy élő értékeket kell ellenőrizni, ekkor járja be a [Presentation.Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjteményt, és minden dia [Slide.Hidden](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/hidden/) tulajdonságát ellenőrizze.

**Fel tudom-e ismerni, hogy egyéni dia méret és orientáció van‑e beállítva, és eltérnek‑e az alapértelmezettől?**

Igen. Töltse be a prezentációt, és olvassa a [Presentation.SlideSize](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slidesize/) értékét. Vizsgálja meg az [ISlideSize.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/hu/net/aspose.slides/islidesize/size/) és [ISlideSize.Orientation](https://reference.aspose.com/slides/hu/net/aspose.slides/islidesize/orientation/) tulajdonságokat, hogy összehasonlítsa a jelenlegi beállításokat az elvárt előre beállított értékekkel és méretekkel.

**Van‑e gyors módja annak, hogy megtudjam, a diagramok külső adatforrásra hivatkoznak‑e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/) elemet, és ellenőrizze a [ChartData.DataSourceType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/) tulajdonságot. Külső munkafüzet esetén olvassa a [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/) értékét. Az adatforrás típusa és elérési útja jelzi a külső hivatkozást, de annak rendelkezésre állását külön erőforrás‑ellenőrzéssel kell megerősíteni.

**Hogyan tudom felmérni a „nehéz” diákot, amelyek lassíthatják a renderelést vagy a PDF‑exportot?**

Nincs egyetlen „bonyolultság” tulajdonság. Járja be a [Presentation.Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjteményt, és minden dia [IBaseSlide.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/shapes/) kollekcióját. A forma‑szám, nagy képek, effektusok, animációk vagy multimédia jelenléte jelzésként szolgálhat, és egy reprezentatív renderelés vagy export mérésével határozhatja meg, hogy egy dia valóban teljesítmény‑szűkítő.