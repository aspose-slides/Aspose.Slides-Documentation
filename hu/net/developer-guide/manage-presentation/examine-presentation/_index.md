---
title: Prezentációs információk lekérése és frissítése .NET-ben
linktitle: Prezentációs információk
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
description: "Fedezze fel a diákat, a szerkezetet és a metaadatokat PowerPoint és OpenDocument prezentációkban .NET használatával, így gyorsabb betekintést és intelligensebb tartalom-ellenőrzést érhet el."
---
## **Áttekintés**

Az Aspose.Slides képes felismerni egy prezentáció formátumát, és elolvasni a dokumentum metaadatait anélkül, hogy teljes prezentációs objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell osztályozni, leltárt építeni, vagy a tulajdonságokat megvizsgálni szeretnénk, mielőtt eldöntenénk, hogy betöltjük és feldolgozzuk a prezentáció tartalmát.

Ez a cikk a könnyű ellenőrzést mutatja be a [PresentationFactory](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/) és az [IPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/) használatával, valamint a célzott frissítéseket az [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) segítségével.

## **Prezentáció formátumának ellenőrzése**

Használja a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) metódust egy fájl ellenőrzéséhez anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt hozna létre. Az [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/loadformat/) tulajdonság jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

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

## **Könnyű prezentációs leltár felépítése**

Amikor sok prezentációs fájlt dolgoz fel, gyakran szükség van egy kompakt leltárra az ellenőrzéshez, indexeléshez vagy dokumentumkezelő rendszerhez. Ebben a helyzetben használja a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) metódust egy [IPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/) objektum megszerzéséhez, majd hívja meg az [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/readdocumentproperties/) metódust a dokumentum metaadatok olvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt, és nem igényli a teljes prezentációs objektummodell bejárását.

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) által nyújtott kiterjesztett tulajdonságok a következő leltárértékeket biztosítják:

| Tulajdonság | Leltár érték |
|---|---|
| [Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/slides/hu/) | Az összes dia száma. |
| [HiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/hiddenslides/) | A rejtett diák száma. |
| [Notes](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/notes/) | A megjegyzéseket tartalmazó diák száma. |
| [Paragraphs](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/paragraphs/) | Az elérhető bekezdések teljes száma. |
| [Words](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/words/) | A szavak teljes száma. |
| [MultimediaClips](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/multimediaclips/) | Az audio- és videoklipek teljes száma. |

Az alábbi példa beolvasza ezeket az értékeket anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat ki. Emellett az [HeadingPairs](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/headingpairs/) és a [TitlesOfParts](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/titlesofparts/) kombinálásával jeleníti meg a tartalomcsoportokat, például betűtípusok, témák és diacímek.

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

Minden [IHeadingPair](https://reference.aspose.com/slides/hu/net/aspose.slides/iheadingpair/) egy csoportnevet és a csoportban lévő elemek számát tartalmazza. Az [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/titlesofparts/) lapos, rendezett tömb, ezért a címek számát a megfelelő mennyiségben kell felhasználni minden egyes címpár által meghatározott sorrendben.

### **Tárolt metaadatok és formátumkorlátozások**

Az [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/readdocumentproperties/) által visszaadott leltártulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a prezentációs objektummodellt ezen értékek újraszámolásához. A hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavultak lehetnek, ha az utolsó mentést végző alkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, megjegyzések, rejtett diák, bekezdések, szavak és multimédiás elemek számához, valamint a címpárokhoz és a részcímekhez. A rendelkezésre állás attól függ, mely tulajdonságokat írta a dokumentumkészítő.
- **PPT:** A bináris formátum tárolhatja a megfelelő dokumentumszerkesztő tulajdonságokat. Ha egy tulajdonság hiányzik vagy nem frissült a dokumentumkészítő által, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza a diák alapján történő újraszámolás helyett.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat tartalmaznak, például oldal-, bekezdés- és szavakszámot, de ezek az értékek nem felelnek meg minden PowerPoint-specifikus kiterjesztett tulajdonságnak. A rejtett dia, megjegyzésdia, multimédia, címpár és részcím metaadatai előfordulhatnak, hogy nem érhetők el, és a leltártulajdonságok alapértelmezett értékekkel térhetnek vissza. Ne tekintse a null értéket vagy az üres tömböt megbízható bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat-megoldást leltárakhoz és előzetes ellenőrzésekhez. Töltse be a prezentációt és ellenőrizze a valós idejű objektummodellt, ha az eredménynek tükröznie kell a memóriában lévő változásokat, vagy ha a tényleges prezentációs tartalmat kell ellenőrizni.

## **Prezentációs tulajdonságok frissítése**

Az [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/readdocumentproperties/) által visszaadott tulajdonságok módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt hoznánk létre. Alkalmazza a változtatásokat az [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) metódussal, majd írja ki a kötött prezentációt az [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/writebindedpresentation/) metódussal.

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

A következő képen láthatóak a frissített dokumentumtulajdonságok.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások kapcsán tekintse meg a következő cikkeket:

- [Password-Protect Presentations](/slides/hu/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/net/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok beágyazottak-e, és melyek azok?**

Töltse be a prezentációt, és használja a [Presentation.FontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/fontsmanager/) osztályt. Hívja meg a [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getembeddedfonts/) metódust a beágyazott betűtípusok lekéréséhez, valamint a [FontsManager.GetFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getfonts/) metódust a prezentációban használt betűtípusokhoz. Hasonlítsa össze a két eredményt a megjelenítéshez szükséges, de nem beágyazott betűtípusok megtalálásához.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákot tartalmaz-e, és hányat?**

Ha a tárolt dokumentummetaadatok elegendőek, olvassa be az [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/hiddenslides/) értéket a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) és az [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/readdocumentproperties/) segítségével. Ez egy könnyű leltárhoz alkalmas megoldás. Ha a prezentáció memóriában módosult, a tárolt metaadat hiányozhat vagy elavult lehet, ilyenkor lépjen végig a [Presentation.Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjteményén, és ellenőrizze minden dia [Slide.Hidden](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/hidden/) tulajdonságát.

**Felismerhetem-e, hogy egyedi dia méret és orientáció van-e használatban, és eltérnek-e az alapértelmezettől?**

Igen. Töltse be a prezentációt, és olvassa be a [Presentation.SlideSize](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slidesize/) tulajdonságot. Ellenőrizze az [ISlideSize.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/hu/net/aspose.slides/islidesize/size/) és [ISlideSize.Orientation](https://reference.aspose.com/slides/hu/net/aspose.slides/islidesize/orientation/) értékeket, hogy összehasonlítsa a jelenlegi beállításokat a várt előre beállított méretekkel és orientációval.

**Van-e gyors módja annak, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/) objektumot, és ellenőrizze a [ChartData.DataSourceType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/) tulajdonságot. Külső munkafüzet esetén olvassa be a [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/) értéket. Az adatforrás típusa és az útvonal jelzi a külső hivatkozást, de a cél elérhetőségének ellenőrzése külön erőforrás-ellenőrzést igényel.

**Hogyan értékelhetem a „nehéz” diákot, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Nincs egyetlen komplexitási tulajdonság sem. Járja be a [Presentation.Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjteményt, valamint minden dia [IBaseSlide.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/shapes/) kollekcióját. Használja a formák számát, valamint a nagy méretű képek, effektusok, animációk vagy multimédia jelenlétét szűrőjelzésként, és végezzen mérési renderelést vagy exportot, mielőtt egy diát megerősített teljesítménybottlenecknek tekintene.