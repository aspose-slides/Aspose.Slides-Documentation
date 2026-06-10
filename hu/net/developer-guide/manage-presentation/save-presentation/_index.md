---
title: Bemutatók mentése .NET-ben
linktitle: Bemutató mentése
type: docs
weight: 80
url: /hu/net/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- bemutató mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- bemutató fájlba
- bemutató folyamba
- előre definiált nézettípus
- szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentési előrehaladás
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan menthet bemutatókat .NET-ben az Aspose.Slides használatával – exportáljon PowerPoint vagy OpenDocument formátumba, miközben megőrzi a elrendezéseket, betűtípusokat és hatásokat."
---
## **Áttekintés**

[Open Presentations in C#](/slides/hu/net/open-presentation/) bemutatja, hogyan használhatja a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályt egy bemutató megnyitásához. Ez a cikk elmagyarázza, hogyan hozhat létre és menthet bemutatókat. A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály a bemutató tartalmát tartalmazza. Akár a semmiből hoz létre egy bemutatót, akár egy meglévőt módosít, a végén menteni kell. Az Aspose.Slides for .NET segítségével **fájlba** vagy **folyamba** menthet. Ez a cikk bemutatja a bemutató mentésének különböző módjait.

## **Bemutatók mentése fájlokba**

Mentse a bemutatót egy fájlba a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály `Save` metódusának meghívásával. Adja át a fájl nevét és a mentés formátumát a metódusnak. A következő példa megmutatja, hogyan menthet bemutatót az Aspose.Slides segítségével.

```cs
// A Presentation osztály példányosítása, amely egy bemutató fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Itt végezzen némi munkát...

    // Mentse a bemutatót egy fájlba.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Bemutatók mentése folyamokba**

A bemutatót egy folyamba mentheti, ha egy kimeneti folyamot ad át a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály `Save` metódusának. A bemutató többféle folyam típusba is írható. Az alábbi példában egy új bemutatót hozunk létre és egy fájlfolyamba mentjük.

```cs
// A Presentation osztály példányosítása, amely egy bemutató fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // A bemutatót a folyamra menti.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Bemutatók mentése előre meghatározott nézettípussal**

Az Aspose.Slides lehetővé teszi, hogy beállítsa a PowerPoint által a generált bemutató megnyitásakor használt kezdeti nézetet a [ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/) osztály segítségével. Állítsa a [LastView](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/lastview/) tulajdonságot a [ViewType](https://reference.aspose.com/slides/hu/net/aspose.slides/viewtype/) felsorolás egyik értékére.

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Bemutatók mentése szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy egy bemutatót a szigorú Office Open XML formátumban mentse. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pptxoptions/) osztályt, és állítsa be a konformitás tulajdonságát a mentéskor. Ha a `Conformance.Iso29500_2008_Strict` értéket állítja be, a kimeneti fájl a szigorú Office Open XML formátumban lesz mentve.

Az alábbi példa egy bemutatót hoz létre, és a szigorú Office Open XML formátumban ment el.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// A Presentation osztály példányosítása, amely egy bemutató fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // A bemutatót a szigorú Office Open XML formátumban menti.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Bemutatók mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 byte) korlátot szab a bővített méretre, a tömörített méretre és az archívum teljes méretére, valamint legfeljebb 65 535 (2^16‑1) fájlt engedélyez. A ZIP64 formátumkiterjesztések ezeknek a korlátoknak a 2^64‑re emelését teszik lehetővé.

Az [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipptxoptions/zip64mode/) tulajdonság lehetővé teszi, hogy kiválassza, mikor használjon ZIP64 formátumkiterjesztéseket Office Open XML fájl mentésekor.

Ez a tulajdonság a következő módokat biztosítja:

- `IfNecessary` csak akkor használ ZIP64 formátumkiterjesztéseket, ha a bemutató meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- `Never` soha nem használ ZIP64 formátumkiterjesztéseket.
- `Always` mindig használ ZIP64 formátumkiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthet egy bemutatót PPTX‑ként ZIP64 formátumkiterjesztésekkel engedélyezve:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}}
Amikor a `Zip64Mode.Never` beállítással ment, egy [PptxException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxexception/) kerül dobásra, ha a bemutató nem menthető ZIP32 formátumban.
{{% /alert %}}

## **Bemutatók mentése a bélyegkép frissítése nélkül**

A [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) tulajdonság vezérli a bélyegkép generálását PPTX mentésekor:

- Ha `true` értékre van állítva, a bélyegkép frissül a mentés során. Ez az alapértelmezett.
- Ha `false` értékre van állítva, a jelenlegi bélyegkép megmarad. Ha a bemutatónak nincs bélyegképe, nem generálódik újból.

Az alábbi kódban a bemutató PPTX‑ként kerül mentésre a bélyegkép frissítése nélkül.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Információ" color="info" %}}
Ez a beállítás segít csökkenteni a PPTX formátumban történő mentéshez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás frissítése százalékban**

Az [IProgressCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iprogresscallback/) interfészt a [ISaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isaveoptions/) interfész `ProgressCallback` tulajdonsága, valamint az absztrakt [SaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/) osztály használja. Egy [IProgressCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iprogresscallback/) megvalósítást rendelve a `ProgressCallback`‑hez, százalékos mentési előrehaladás‑értesítéseket kaphat.

Az alábbi kódrészletek mutatják, hogyan használja az `IProgressCallback`‑t.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Használja itt a százalékos előrehaladás értékét.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Információ" color="info" %}}
Az Aspose egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) fejlesztett ki saját API‑jával. Az alkalmazás lehetővé teszi a bemutató több fájlra bontását úgy, hogy a kiválasztott diák új PPTX vagy PPT fájlokként kerülnek mentésre.
{{% /alert %}}

## **GYIK**

**Támogatott a „gyors mentés” (inkrementális mentés), amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Biztonságos-e több szálról ugyanazt a Presentation példányt menteni?**

Nem. Egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példány **nem szálbiztos** (/slides/hu/net/multithreading/); egyetlen szálról kell menteni.

**Mi történik a hiperhivatkozásokkal és a külsőleg linkelt fájlokkal mentéskor?**

A [Hyperlinks](/slides/hu/net/manage-hyperlinks/) megmaradnak. A külső linkelt fájlok (például relatív útvonalú videók) automatikusan nem kerülnek másolásra – biztosítsa, hogy a hivatkozott útvonalak továbbra is elérhetők legyenek.

**Beállíthatók/menthetők a dokumentum metaadatai (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [document properties](/slides/hu/net/presentation-properties/) támogatott, és a mentéskor a fájlba kerülnek írásra.