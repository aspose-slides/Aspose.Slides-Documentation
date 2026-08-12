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
- miniaturizált kép frissítése
- mentési előrehaladás
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan menthet prezentációkat .NET környezetben az Aspose.Slides segítségével—exportálás PowerPoint vagy OpenDocument formátumba, miközben megőrzik a layoutról, betűtípusokról és hatásokról."
---
## **Áttekintés**

[Open Presentations in C#](/slides/hu/net/open-presentation/) leírja, hogyan kell használni a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályt egy prezentáció megnyitásához. Ez a cikk bemutatja, hogyan hozhatunk létre és menthetünk prezentációkat. A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály tartalmazza a prezentáció tartalmát. Akár egy prezentációt hozunk létre nulláról, akár egy meglévőt módosítunk, a munka befejezésekor menteni kell. Az Aspose.Slides for .NET segítségével **fájlba** vagy **adatfolyamba** menthetünk. Ez a cikk a prezentációk mentésének különböző módjait ismerteti.

## **Prezentációk mentése fájlokba**

A prezentációt fájlba menthetjük a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály `Save` metódusának meghívásával. A metódusnak átadjuk a fájl nevét és a mentési formátumot. Az alábbi példa bemutatja, hogyan menthetünk egy prezentációt az Aspose.Slides segítségével.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Itt végezzen némi munkát...

    // Mentse a prezentációt egy fájlba.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Prezentációk mentése adatfolyamokba**

Egy prezentációt adatfolyamba menthetünk, ha egy kimeneti adatfolyamot adunk át a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály `Save` metódusának. A prezentáció számos adatfolyam típusba írható. Az alábbi példában egy új prezentációt hozunk létre, és fájl adatfolyamba mentjük.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Mentse a prezentációt az adatfolyamra.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Prezentációk mentése előre meghatározott nézettípussal**

Az Aspose.Slides lehetővé teszi az elsődleges nézet beállítását, amelyet a PowerPoint használ, amikor a létrehozott prezentáció megnyílik, a [ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/) osztályon keresztül. Állítsa be a [LastView](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/lastview/) tulajdonságot a [ViewType](https://reference.aspose.com/slides/hu/net/aspose.slides/viewtype/) felsorolás egy értékére.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi egy prezentáció mentését a szigorú Office Open XML formátumban. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pptxoptions/) osztályt, és állítsa be a megfelelőségi (conformance) tulajdonságát a mentéskor. Ha a `Conformance.Iso29500_2008_Strict` értéket állítja be, a kimeneti fájl a szigorú Office Open XML formátumban lesz mentve.

Az alábbi példa egy prezentációt hoz létre, és a szigorú Office Open XML formátumban menti el.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Mentse a prezentációt a szigorú Office Open XML formátumban.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Egy Office Open XML fájl ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab a kicsomagolt fájlméretre, a tömörített fájlméretre és az archívum teljes méretére, valamint legfeljebb 65 535 (2^16‑1) fájlt engedélyez. A ZIP64 formátumkiterjesztések ezeket a korlátokat 2^64‑re emelik.

A [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipptxoptions/zip64mode/) tulajdonság lehetővé teszi, hogy megadja, mikor használjon ZIP64 formátumkiterjesztéseket az Office Open XML fájl mentésekor.

Ez a tulajdonság az alábbi módokat biztosítja:

- `IfNecessary` csak akkor használja a ZIP64 formátumkiterjesztéseket, ha a prezentáció meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- `Never` soha nem használja a ZIP64 formátumkiterjesztéseket.
- `Always` mindig használja a ZIP64 formátumkiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthetünk egy prezentációt PPTX fájlként, a ZIP64 formátumkiterjesztésekkel engedélyezve:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Amikor a `Zip64Mode.Never` beállítással mentünk, akkor a [PptxException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxexception/) kerül dobásra, ha a prezentációt nem lehet ZIP32 formátumban menteni.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

Nagy prezentációk esetén beállíthatja a tömörítési szintet a fájlméret és a feldolgozási idő egyensúlyozásához. Az igényektől függően választhat gyorsabb feldolgozást vagy kisebb kimeneti fájlokat.

Az Aspose.Slides biztosítja az [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipptxoptions/compressionlevel/) tulajdonságot, amely lehetővé teszi a tömörítési szint megadását Office Open XML formátumban történő mentéskor.

Az elérhető tömörítési szintek:

- **None**: Nem alkalmaz tömörítést. A fájlok változatlanul tárolódnak.
- **Level1:** A leggyorsabb tömörítés, legalacsonyabb tömörítési arány.
- **Level2:** Gyorsabb tömörítés, valamivel jobb tömörítési arány, mint a **Level1**.
- **Level3:** Jobb tömörítés, mint a **Level2**, közepes hatással a feldolgozási időre.
- **Level4:** Jobb tömörítés, mint a **Level3**.
- **Level5:** Javított tömörítés a **Level4**-hez képest, további feldolgozási idővel.
- **Level6:** Standard tömörítés, amely jó egyensúlyt biztosít a feldolgozási sebesség és a fájlméret között. Ez a *alapértelmezett tömörítési szint*.
- **Level7:** Jobb tömörítés, mint a **Level6**, lassabb feldolgozással.
- **Level8:** Jobb tömörítés, mint a **Level7**.
- **Level9:** Maximális tömörítés. A legkisebb fájlméretet eredményezi, de a leghosszabb feldolgozási időt igényli.

Az alábbi példa bemutatja, hogyan menthetünk egy prezentációt PPTX fájlként *tömörítés nélkül*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Ez a példa megmutatja, hogyan menthetünk egy prezentációt PPTX fájlként *maximális tömörítéssel*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Prezentációk mentése a miniatűr frissítése nélkül**

A [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) tulajdonság szabályozza a miniatűr generálását PPTX formátumba történő mentéskor:

- Ha `true` értékre van állítva, a mentés során a miniatűr frissül. Ez az alapértelmezett.
- Ha `false` értékre van állítva, a meglévő miniatűr megmarad. Ha a prezentációnak nincs miniatűre, akkor egy sem jön létre.

Az alábbi kódban a prezentációt PPTX‑ként mentjük a miniatűr frissítése nélkül.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Ez a beállítás segít csökkenteni a PPTX formátumban történő mentéshez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás frissítései százalékban**

Az [IProgressCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iprogresscallback/) interfészt a [ISaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isaveoptions/) interfész `ProgressCallback` tulajdonsága, valamint az absztrakt [SaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/) osztály biztosítja. Egy [IProgressCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iprogresscallback/) megvalósítást adjon a `ProgressCallback`-nek, hogy a mentés előrehaladását százalékos formában kapja meg.

Az alábbi kódrészletek mutatják, hogyan kell használni az `IProgressCallback`-et.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Használja itt a folyamat százalékos értékét.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Az Aspose egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) fejlesztett ki saját API-ja segítségével. Az alkalmazás lehetővé teszi egy prezentáció több fájlra bontását, a kijelölt diák új PPTX vagy PPT fájlként való mentésével.
{{% /alert %}}

## **GYIK**

**Támogatja a „gyors mentést” (inkrementális mentés), amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nincs támogatva.

**Szálbiztonságos ugyanannak a Presentation példánynak a mentése több szálból?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példány **nem szálbiztos** (/slides/hu/net/multithreading/); egyetlen szálról kell menteni.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal mentéskor?**

A [Hyperlinks](/slides/hu/net/manage-hyperlinks/) megmaradnak. A külsőleg hivatkozott fájlok (például relatív útvonalakon elérhető videók) nem másolódnak automatikusan – biztosítani kell, hogy a hivatkozott útvonalak elérhetők maradjanak.

**Beállíthatók / menthetők dokumentum metaadatai (szerző, cím, cég, dátum)?**

Igen. A szabványos [document properties](/slides/hu/net/presentation-properties/) támogatott, és a mentéskor be lesznek írva a fájlba.