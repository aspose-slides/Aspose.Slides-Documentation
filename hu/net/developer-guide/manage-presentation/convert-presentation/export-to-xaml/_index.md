---
title: Prezentációk exportálása XAML-be .NET-ben
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/net/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- PowerPoint XAML-be
- OpenDocument XAML-be
- prezentáció XAML-be
- PPT XAML-be
- PPTX XAML-be
- ODP XAML-be
- PPT mentése XAML-ként
- PPTX mentése XAML-ként
- ODP mentése XAML-ként
- PPT exportálása XAML-be
- PPTX exportálása XAML-be
- ODP exportálása XAML-be
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument diákat XAML-be .NET-ben az Aspose.Slides használatával—gyors, Office-mentes megoldás, amely megőrzi az elrendezést."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan exportálhatók a PowerPoint‑prezentációk XAML formátumba az Aspose.Slides használatával. Rövid bevezetést nyújt a XAML‑ról, bemutatja, hogyan menthető egy prezentáció XAML‑be alapértelmezett beállításokkal, valamint azt, hogyan testreszabható az export a [XamlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/) segítségével, beleértve a rejtett dia exportálását is. A cikk néhány gyakori kérdésre is válaszol a visszaeső betűtípusokkal, a XAML‑stack kompatibilitással és a rejtett dia exportálási viselkedésével kapcsolatban.

## **Az XAML-ről**

A XAML egy XML‑alapú jelölőnyelv, amelyet felhasználói felületek leírására használnak olyan keretrendszerekben, mint a WPF (Windows Presentation Foundation), az UWP (Universal Windows Platform) és a Xamarin.Forms.

A XAML‑fájlokkal dolgozhat vizuális tervezőben, vagy közvetlenül szerkesztheti a jelölést.

## **Prezentációk exportálása XAML‑be alapértelmezett beállításokkal**

A következő C# példa mutatja, hogyan exportálható egy prezentáció XAML‑be alapértelmezett beállításokkal:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Alapértelmezés szerint az exportált diák egy `pres` alkönyvtárba kerülnek a folyamat aktuális munkakönyvtárában, amelyet a [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory) ad vissza. A könyvtár automatikusan létrejön, és a szükséges képek is oda kerülnek.

A kimeneti könyvtár neve a forrásfájl nevéből származik kiterjesztés nélkül. A `pres.pptx` esetén a kimeneti fájlok `pres/Slide_1.xaml`, `pres/Slide_2.xaml` stb. néven jönnek létre. Még ha abszolút elérési utat ad meg a bemeneti prezentációnak is, a kimeneti könyvtár az aktuális munkakönyvtárhoz képest jön létre, nem pedig a bemeneti fájl mellé.

## **Prezentációk exportálása XAML‑be egyedi beállításokkal**

Használja az [IXamlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/ixamloptions/) interfészt annak szabályozására, hogyan exportálja az Aspose.Slides a prezentációt XAML‑be.

Az output egyedi helyre mentéséhez valósítsa meg az [IXamlOutputSaver](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/ixamloutputsaver/) interfészt, és rendelje hozzá az implementáció egy példányát a [OutputSaver](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/outputsaver/) tulajdonsághoz a [XamlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/) objektumban.

A rejtett diák XAML‑outputba való felvonásához állítsa a [ExportHiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) tulajdonságot `true`‑ra, ahogy az alábbi C# példában látható:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Az összes generált XAML‑eszköz gyűjtése**

Az XAML exportálás minden exportált diára külön XAML‑dokumentumot, valamint különálló képeket és támogató erőforrásokat hozhat létre. Rendeljen egy egyedi [IXamlOutputSaver](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/ixamloutputsaver/) objektumot a [XamlOptions.OutputSaver](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/outputsaver/) tulajdonsághoz, hogy ezeket az eszközöket a fájlrendszer helyett saját módon kapja meg. Indítsa el az exportálást az XAML‑specifikus [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) túlterheléssel, amely XAML beállításokat fogad.

### **A Callback életciklusának megértése**

Az exportáló a [IXamlOutputSaver.Save](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/ixamloutputsaver/save/) metódust hívja meg külön-külön minden generált eszközre:

- `path` azonosítja az eszközt, és tartalmazhat relatív könyvtárakat. Őrizze meg ezt az információt, mivel a XAML relatív útvonalakkal hivatkozhat erőforrásokra.
- `data` az eszköz bájtjait tartalmazza. A képeket és egyéb bináris erőforrásokat ne dekódolja szövegként.
- A mentő feladata, hogy a visszatérés előtt megtartsa vagy elmentse az adatot. A példák minden bájt tömböt az alkalmazás által kezelt memóriába másolnak.
- Az exportot csak akkor tekintse sikeresnek, ha a prezentáció mentési művelete befejeződik, és minden callback sikeresen végrehajtódik. Ne nyelje el a tárolási hibákat, és ne indítson megfigyelés nélküli háttérírásokat. Ha a perzisztálás később történik, az összesített sikerességet csak akkor jelentse, ha az a lépés is sikeres.

A [XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) szintén érvényes egyedi mentő esetén. Alapértelmezett értéke, `false`, kizárja a rejtett dia XAML‑dokumentumait. `true`‑ra állítva azok és a hozzájuk szükséges erőforrások is exportálásra kerülnek. Az erőforrások száma a prezentációtól függ; ne feltételezze, hogy minden diához pontosan egy callback tartozik, vagy hogy a callback-ek sorrendje fix.

### **Export memóriaba és az eszközök ellenőrzése**

Ez a teljes példa betölti a `pres.pptx` fájlt, összegyűjti az összes eszközt egy [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) gyűjteményben, és kiírja a nevét, típusát és bájtszámát. A megadott neveket pontosan megőrzi. Azonos nevek esetén a gyűjtés hibával leáll, ahelyett, hogy csendben felülírná az eszközt.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Csak a XAML-t dekódolja, és csak akkor, ha szöveges ellenőrzés szükséges.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Hívja meg a `InMemoryXamlExample.Run` metódust az alkalmazásából. A kiterjesztés‑ellenőrzések hasznosak az ellenőrzéshez; őrizze meg az összes eszközt, beleértve az ismeretlen erőforrás‑típusokat is. A bájtokat módosítás nélkül tárolja vagy továbbítsa. Az [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) metódust csak olyan XAML esetén használja, amelynek szöveges feldolgozásra van szüksége.

### **Az eszközök csomagolása ZIP‑archívumba**

Ez a független példa összegyűjti az exportot, ellenőrzi a neveket, és a forrásbájtokat ZIP‑archívumba írja. Egy egyedi archívumnév elválasztja a párhuzamos export feladatokat. A ZIP‑bejegyzések perjel‑elválasztókat használnak, és megőrzik a relatív könyvtárakat. Nem biztonságos vagy normalizálás után ütköző nevek a teljes csomag írása előtt elutasításra kerülnek.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // A ZIP könyvtár a siker jelentése előtt a felszabadítással lett véglegesítve.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Hívja meg a `ZipXamlExample.Run` metódust az alkalmazásából. A példa a [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) osztályt használja egy helyi archívum írásához; az exportáló magától nem ír ki laza XAML‑ vagy képfájlokat. Távoli tároláshoz cserélje le az archívum‑írást az összegyűjtött bájt‑tömbök feltöltésére. Használjon egy export‑feladatra jellemző azonosítót, valamint a teljes relatív eszköznevet blob‑kulcsként, vagy tárolja a feladatazonosítót, a relatív nevet és a bináris adatot egy adatbázis‑sorban. A feladatot csak akkor tegye közzé, ha az összes feltöltés befejeződött vagy a tranzakció commit‑álva lett. Ha a perzisztálás sikertelen, tisztítsa meg a részleges kimenetet.

Nagy prezentációk esetén egy egyedi mentő közvetlenül az alkalmazás tárolójába mentheti az egyes eszközöket, elkerülve egy teljes export másolatának megtartását az alkalmazás memóriájában. Az exportáló továbbra is memóriában gyűjti az összes generált eszközt, mielőtt meghívná a mentőt. Tartsa a callback‑eket szinkron módon az exportáló nézőpontjából: csak akkor térjen vissza, ha a célelfogadó elfogadta a bájtokat, és engedje, hogy a hibák elérjék a hívót.

### **Erőforrásnevek megőrzése és hivatkozások ellenőrzése**

- Normalizálja az útvonal‑elválasztókat, ha a célkönyvtár ezt megköveteli, de őrizze meg a relatív könyvtárakat. Ne használja kizárólag a [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) függvényt, kivéve ha minden generált név egyedi, és a hivatkozások érvényesek maradnak.
- Alkalmazzon cél‑specifikus névvalidációt. Lágyfájlok írásánal utasítsa el a gyökértelmezö́t útvonalakat és a traverszálási szegmenst, oldja fel a célt a [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) segítségével, és ellenőrizze, hogy a célkönyvtáron belül marad‑e. Használjon egy alkalmazás‑irányított könyvtárat szimbolikus linkek nélkül, amelyek átirányíthatnák az írásokat.
- Minden exportfeladathoz használjon külön mentőt és tárolási névtér‑kört. Észlelje az ütközéseket az elválasztó normalizálása után, valamint a cél esetleges nagy‑/kisbetű‑érzékenységének szabályai szerint.
- Közzététel előtt minden XAML‑dokumentumot XML‑ként parse‑olja, majd ellenőrizze a fájl‑alapú erőforrás‑hivatkozásokat, például a kép `Source` vagy `ImageSource` attribútumait. Oldja fel minden relatív URI‑t a tartalmazó XAML‑eszköz könyvtárához képest, normalizálja a kapott tárolási nevet, és ellenőrizze, hogy a megfelelő szótár‑kulcs, ZIP‑bejegyzés vagy tárolt objektum létezik. A külső URI‑kat és a XAML‑kifejezéseket kezelje külön a relatív fájlnevektől.

Például, ha a `pres/Slide_1.xaml` a `images/image1.png` képre hivatkozik, a tárolt erőforrásnak `pres/images/image1.png` néven kell elérhetőnek lennie. Ha csak `image1.png` marad, a kapcsolat megszakad. Objektumtárolás esetén tartsa meg ugyanazt a könyvtárszerkezetet a feladatelőtag alatt, és tegye elérhetővé ezeket az URL‑eket a XAML‑fogyasztó számára. Nyissa meg a kész ZIP‑archívumot, ellenőrizze a bejegyzés‑neveket és a forrás‑bájtot, majd töltse be a reprezentatív diákat a cél‑XAML környezetben, hogy megerősítse a képek helyes feloldását.

## **GYIK**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem érhető el a gépen?**

Állítsa be a [DefaultRegularFont](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/defaultregularfont/) értékét a [XamlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/) objektumban – ez a fallback betűtípus exportáláskor kerül felhasználásra, ha az eredeti hiányzik. Ez nem garantálja, hogy a generált XAML a fallback‑betűtípust használja, vagy hogy a betűtípus elérhető a céleszközön. Győződjön meg arról, hogy a XAML‑ban hivatkozott betűtípusok rendelkezésre állnak a megjelenítő környezetben.

**Az exportált XAML csak WPF‑hez szánt, vagy más XAML‑stackekben is használható?**

Az Aspose.Slides a WPF XAML‑t exportálja a publikus API‑ján keresztül. Más XAML‑stackekkel, például az UWP‑vel vagy a Xamarin.Forms‑szel való kompatibilitás nem garantált. Tesztelje a generált jelölést a célkörnyezetben.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálódjanak?**

Alapértelmezés szerint a rejtett diák nincsenek benne. Ezt a viselkedést a [ExportHiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) beállítással szabályozhatja a [XamlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/) objektumban – tartsa letiltva, ha nincs szükség a rejtett diák exportálására.