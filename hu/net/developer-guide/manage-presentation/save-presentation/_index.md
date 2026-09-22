---
title: Prezentációk mentése .NET-ben
linktitle: Prezentáció mentése
type: docs
weight: 80
url: /hu/net/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- prezentáció mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- prezentáció fájlba
- prezentáció adatfolyamba
- előre meghatározott nézettípus
- Szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentési előrehaladás
- .NET
- C#
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk mentése fájlokba vagy adatfolyamokba C#‑ben az Aspose.Slides for .NET segítségével, valamint a PPTX kimenet és a mentési jelentés konfigurálása."
---
## **Áttekintés**

Miután létrehoz egy prezentációt vagy [nyit egy meglévőt](/slides/hu/net/open-presentation/), használja a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódust az eredmény írásához. Az Aspose.Slides for .NET képes egy prezentációt fájlba vagy adatfolyamba menteni PowerPoint, OpenDocument, PDF és más formátumokban. Az alábbi szakaszok a szabványos mentési műveleteket és a PPTX kimenethez elérhető beállításokat tárgyalják.

## **Prezentációk mentése fájlokba**

A prezentáció fájlba mentéséhez adja meg a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) értéket a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódusnak. A formátumérték határozza meg, milyen típusú fájlt hoz létre az Aspose.Slides.

A következő példa egy prezentációt hoz létre, és PPTX fájlként menti el:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Adjon hozzá vagy módosítson prezentáció tartalmat itt.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Prezentációk mentése az eredeti formátumban**

A fájl- és adatfolyam-detektálási példák, az újból létrehozott prezentációk viselkedése, valamint a forrás‑ és kimeneti formátumok megkülönböztetése tekintetében lásd a [Determine the Original Presentation Format](/slides/hu/net/detect-presentation-source-format/) oldalt.

Kötegelt feldolgozást végző alkalmazásban a bemeneti formátum nem ismert előre. Egy fájl betöltése után olvassa ki az eredeti formátumot az [IPresentation.SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/sourceformat/) tulajdonságból. Az így kapott [SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/sourceformat/) értéket adja át a [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/tosaveformat/) metódusnak a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) érték megszerzéséhez, majd használja a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódust a módosított prezentáció írásához.

A következő teljes példa minden fájlt feldolgoz egy bemeneti könyvtárban, frissíti a címét, és a betöltött formátumnak megfelelően menti el egy kimeneti könyvtárba:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/tosaveformat/) a PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és PowerPoint XML formátumokat a megfelelő prezentáció mentési formátumokra képezi le. Csak a prezentáció forrásformátumait térképezi; nem exportálási formátumok, például PDF, HTML, TIFF vagy képek kiválasztására szolgál. Nem támogatott vagy érvénytelen [SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/sourceformat/) érték átadása [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception) kivételt eredményez.

Az örökölt PPT, PPS és POT fájlok ugyanazt a bináris tárolót használják. Ha egy ilyen prezentációt kiterjesztés nélküli adatfolyamból töltenek be, egy PPS vagy POT fájlt ezért PPT‑nek lehet azonosítani. Ha ezen örökölt al típusok megőrzése szükséges, tartsa meg az eredeti fájlnevet vagy formátum metaadatait, és használja őket a kimeneti fájlnév és formátum kiválasztásakor.

## **Prezentációk mentése adatfolyamokba**

A prezentáció írásához, anélkül hogy végső fájlútvonalra támaszkodna, adjon át egy írható [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) objektumot és egy [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) értéket a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódusnak. Ez a megközelítés hasznos, ha a kimenetet egy webszolgáltatásból kell visszaadni, adatbázisban tárolni vagy memóriában feldolgozni.

A következő példa egy új prezentációt fájl adatfolyamba ment:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Prezentációk mentése előre meghatározott nézettípussal**

Megadhatja azt a nézetet, amellyel a PowerPoint először megnyitja a mentett prezentációt. A [ViewProperties.LastView](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/lastview/) tulajdonságot állítsa be egy [ViewType](https://reference.aspose.com/slides/hu/net/aspose.slides/viewtype/) értékre a mentés előtt.

A következő példa a Dia‑mester nézetet állítja be kezdeti nézetként:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Egy PPTX fájl létrehozásához, amely megfelel az Office Open XML szigorú profiljának, hozzon létre egy [PptxOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pptxoptions/) példányt, és állítsa be a [Conformance](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pptxoptions/conformance/) tulajdonságát `Conformance.Iso29500_2008_Strict` értékre. Ezután adja át az opciókat a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódusnak.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

A szabványos ZIP archívum korlátozza az egyes bejegyzések tömörített és tömörítetlen méretét, a teljes archívum méretét és a bejegyzések számát. Mivel egy PPTX fájl ZIP archívum, egy nagyon nagy prezentáció túllépheti ezeket a korlátokat. A ZIP64 kiterjesztések emelik a vonatkozó méret‑ és bejegyzésszám‑korlátokat.

A [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pptxoptions/zip64mode/) tulajdonsággal szabályozhatja, hogy az Aspose.Slides ZIP64 kiterjesztéseket írjon‑e:

- `IfNecessary` csak akkor használ ZIP64‑et, ha a prezentáció meghaladja a szabványos ZIP korlátokat. Ez az alapértelmezett mód.
- `Never` letiltja a ZIP64 kiterjesztéseket.
- `Always` mindig ír ZIP64 kiterjesztéseket.

A következő példa mindig engedélyezi a ZIP64 kiterjesztéseket a kimeneti prezentációhoz:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Figyelmeztetés" %}}
Ha a `Zip64Mode` értéke `Never`, és a prezentáció nem fér bele a szabványos ZIP korlátokba, a mentési művelet [PptxException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

PPTX kimenetnél a mentési sebesség és a fájlméret egyensúlyozásához állítsa be a [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pptxoptions/compressionlevel/) tulajdonságot. A [CompressionLevel](https://reference.aspose.com/slides/hu/net/aspose.slides.export/compressionlevel/) enumeráció a következő értékeket kínálja:

- `None` adatot tömörítés nélkül tárol.
- `Level1` a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- `Level2`‑től `Level5` fokozatosan a kisebb kimenetet részesítik előnyben a mentési sebességgel szemben.
- `Level6` egyensúlyt teremt a mentési sebesség és a fájlméret között. Ez az alapértelmezett szint.
- `Level7` és `Level8` tovább a kisebb kimenet felé hajlik a sebesség rovására.
- `Level9` a legerősebb tömörítést nyújtja, és a legtöbb feldolgozási időt igényli.

A következő példa tömörítés nélkül ment egy prezentációt:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

A következő példa a maximális tömörítési szintet használja:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Prezentációk mentése a bélyegkép frissítése nélkül**

Amikor egy prezentációt PPTX‑ként ment, a [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pptxoptions/refreshthumbnail/) tulajdonság szabályozza a dokumentum bélyegképét:

- `true` a mentés során újragenerálja a bélyegképet. Ez az alapértelmezett érték.
- `false` megőrzi a meglévő bélyegképet. Ha a prezentációnak nincs bélyegképe, az Aspose.Slides nem generál újat.

A következő példa a bélyegkép frissítése nélkül ment egy prezentációt:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Megjegyzés" %}}
A bélyegkép frissítésének letiltása csökkentheti a PPTX fájl mentéséhez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás jelentése százalékban**

A mentési művelet nyomon követéséhez valósítsa meg az [IProgressCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iprogresscallback/) interfészt, és rendelje hozzá a [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isaveoptions/progresscallback/) tulajdonsághoz. Az Aspose.Slides ekkor a [IProgressCallback.Reporting](https://reference.aspose.com/slides/hu/net/aspose.slides/iprogresscallback/reporting/) metódust hívja meg a haladási értékekkel az exportálás során.

A következő példa a PDF exportálás előrehaladását írja ki a konzolra:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose egy ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) alkalmazást kínál, amely az Aspose.Slides API‑val készült. Kiválasztott diák exportálásával külön PPT vagy PPTX fájlokat hoz létre a prezentációból.
{{% /alert %}}

## **GYIK**

**Támogatja-e az Aspose.Slides az inkrementális vagy „gyors mentést”?**

Nem. Minden mentési művelet egy komplett kimeneti fájlt ír, nem csak a módosult részeket.

**Több szál képes ugyanazt a Presentation példányt menteni?**

Nem. Egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példány [nem szálbiztos](/slides/hu/net/multithreading/). Minden példányt csak egy szál használhat egyszerre.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal, amikor egy prezentációt mentek?**

A [Hyperlinks](/slides/hu/net/manage-hyperlinks/) megmaradnak a prezentációban. Az Aspose.Slides nem másolja a külső fájlokat, ezért a mentett prezentációnak továbbra is el kell érnie az eredeti helyeket.

**Menthetők-e a dokumentum metaadatai, például a szerző, cím, cég és létrehozás dátuma?**

Igen. A megfelelő [document properties](/slides/hu/net/presentation-properties/) beállítása után a mentéskor az Aspose.Slides beírja őket a kimeneti fájlba.