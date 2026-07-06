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
- prezentáció folyamba
- előre meghatározott nézettípus
- Szigorú Office Open XML formátum
- Zip64 mód
- miniaturák frissítése
- mentési előrehaladás
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan lehet .NET-ben prezentációkat menteni az Aspose.Slides használatával – exportálás PowerPoint vagy OpenDocument formátumba, miközben megmaradnak a elrendezések, betűtípusok és hatások."
---
## **Áttekintés**

[Prezentációk megnyitása C#-ban](/slides/hu/net/open-presentation/) leírja, hogyan kell használni a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályt egy prezentáció megnyitásához. Ez a cikk elmagyarázza, hogyan hozhatunk létre és menthetünk prezentációkat. A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály tartalmazza a prezentáció tartalmát. Akár egy prezentációt hoz létre a semmiből, akár egy meglévőt módosít, a befejezés után menteni szeretné. Az Aspose.Slides for .NET segítségével **fájlba** vagy **folyamba** menthet. Ez a cikk bemutatja a különböző módokat egy prezentáció mentésére.

## **Prezentációk mentése fájlokba**

Mentse a prezentációt egy fájlba a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály `Save` metódusának meghívásával. Adja át a metódusnak a fájlnevet és a mentési formátumot. A következő példa megmutatja, hogyan menthet egy prezentációt az Aspose.Slides segítségével.

```cs
// A Presentation osztály példányosítása, amely egy prezentációfájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Végezzen itt némi munkát...

    // Mentse a prezentációt egy fájlba.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Prezentációk mentése folyamokba**

Prezentációt menthet folyamba úgy, hogy egy kimeneti streamet ad át a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály `Save` metódusának. A prezentáció számos stream típusba írható. Az alábbi példában új prezentációt hozunk létre, és fájlfolyamba mentjük.

```cs
// A Presentation osztály példányosítása, amely egy prezentációfájlt képvisel.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Mentse a prezentációt a streambe.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Prezentációk mentése előre meghatározott nézettípussal**

Az Aspose.Slides lehetővé teszi, hogy beállítsa a kezdeti nézetet, amelyet a PowerPoint használ a generált prezentáció megnyitásakor a [ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/) osztályon keresztül. Állítsa be a [LastView](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/lastview/) tulajdonságot a [ViewType](https://reference.aspose.com/slides/hu/net/aspose.slides/viewtype/) felsorolás egy értékére.

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációt a szigorú Office Open XML formátumban mentse. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pptxoptions/) osztályt, és állítsa be a megfelelőség tulajdonságát mentéskor. Ha a `Conformance.Iso29500_2008_Strict` értéket állítja be, a kimeneti fájl a szigorú Office Open XML formátumban kerül mentésre.

Az alábbi példa létrehoz egy prezentációt, és a szigorú Office Open XML formátumban menti.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// A Presentation osztály példányosítása, amely egy prezentációfájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Mentse a prezentációt a szigorú Office Open XML formátumban.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab a bármely fájl kitömörített méretére, a tömörített méretére és az archívum teljes méretére, valamint legfeljebb 65 535 (2^16‑1) fájlt engedélyez. A ZIP64 formátumkiterjesztések ezeket a korlátokat 2^64‑re emelik.

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipptxoptions/zip64mode/) tulajdonság lehetővé teszi, hogy kiválassza, mikor használja a ZIP64 formátumkiterjesztéseket Office Open XML fájl mentésekor.

Ez a tulajdonság a következő módokat biztosítja:

- `IfNecessary` csak akkor használja a ZIP64 formátumkiterjesztéseket, ha a prezentáció meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- `Never` soha nem használ ZIP64 formátumkiterjesztéseket.
- `Always` mindig használ ZIP64 formátumkiterjesztéseket.

A következő kód bemutatja, hogyan menthet egy prezentációt PPTX fájlként a ZIP64 formátumkiterjesztések engedélyezésével:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Ha a `Zip64Mode.Never` beállítással ment, akkor [PptxException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxexception/) kerül dobásra, ha a prezentációt nem lehet ZIP32 formátumban menteni.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

Nagy prezentációk esetén beállíthatja a tömörítési szintet a fájlméret és a feldolgozási idő egyensúlyozásához. Az igényeitől függően lehet, hogy a gyorsabb feldolgozást vagy a kisebb kimeneti fájlokat részesíti előnyben.

Az Aspose.Slides biztosítja az [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipptxoptions/compressionlevel/) tulajdonságot, amely lehetővé teszi a Office Open XML formátumban történő mentéskor használandó tömörítési szint megadását.

A következő tömörítési szintek érhetők el:

- **None**: Nem alkalmaz tömörítést. A fájlok változatlanul tárolódnak.
- **Level1:** A leggyorsabb tömörítés a legalacsonyabb tömörítési aránnyal.
- **Level2:** Gyorsabb tömörítés, amely valamivel jobb tömörítési arányt biztosít, mint a **Level1**.
- **Level3:** Jobb tömörítést nyújt, mint a **Level2**, mérsékelt hatással a feldolgozási időre.
- **Level4:** Jobb tömörítést biztosít, mint a **Level3**.
- **Level5:** Javított tömörítést nyújt a **Level4**-hez képest, többlet feldolgozási idővel.
- **Level6:** Standard tömörítés, amely jó egyensúlyt nyújt a feldolgozási sebesség és a fájlméret között. Ez a *alapértelmezett tömörítési szint*.
- **Level7:** Jobb tömörítést biztosít, mint a **Level6**, de lassabb feldolgozással.
- **Level8:** Jobb tömörítést nyújt, mint a **Level7**.
- **Level9:** Maximális tömörítés. A legkisebb fájlméretet eredményezi, de a leghosszabb feldolgozási idő árán.

A következő példa bemutatja, hogyan menthet egy prezentációt PPTX fájlként *tömörítés nélkül*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Ez a példa megmutatja, hogyan menthet egy prezentációt PPTX fájlként *maximális tömörítéssel*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Prezentációk mentése a miniatűr frissítése nélkül**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) tulajdonság irányítja a miniatűr generálását, amikor egy prezentációt PPTX-be ment.

- Ha `true` értékre van állítva, a miniatűr mentés közben frissül. Ez az alapértelmezett.
- Ha `false` értékre van állítva, az aktuális miniatűr megmarad. Ha a prezentációnak nincs miniatűre, akkor nem generálódik.

Az alábbi kódban a prezentáció frissítés nélküli miniatűrrel kerül mentésre PPTX-be.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Ez a lehetőség segít csökkenteni a PPTX formátumú prezentáció mentéséhez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás frissítései százalékban**

Az [IProgressCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iprogresscallback/) interfészt a [ISaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isaveoptions/) interfész és az absztrakt [SaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/) osztály által biztosított `ProgressCallback` tulajdonságon keresztül használják. Rendeljen egy [IProgressCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iprogresscallback/) megvalósítást a `ProgressCallback`-hez, hogy a mentési előrehaladás frissítéseit százalékban kapja meg.

A következő kódrészletek bemutatják, hogyan kell használni az `IProgressCallback`-et.

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
        // Használja itt a haladás százalékos értékét.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Az Aspose saját API-ja segítségével fejlesztett egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter). Az alkalmazás lehetővé teszi, hogy egy prezentációt több fájlra bontson, a kiválasztott diák új PPTX vagy PPT fájlokként történő mentésével.
{{% /alert %}}

## **GYIK**

**Támogatott a „gyors mentés” (inkrementális mentés), amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Vagy szálbiztonságos ugyanazt a Presentation példányt több szálról menteni?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példány [nem szálbiztonságos](/slides/hu/net/multithreading/); csak egy szálról mentse.

**Mi történik a hivatkozásokkal és a külsőleg hivatkozott fájlokkal mentéskor?**

[Hyperlinks](/slides/hu/net/manage-hyperlinks/) megmaradnak. A külső hivatkozott fájlok (pl. relatív útvonalú videók) nem másolódnak automatikusan – gondoskodjon arról, hogy a hivatkozott útvonalak hozzáférhetőek maradjanak.

**Beállíthatom/menthetem a dokumentum metaadatokat (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [document properties](/slides/hu/net/presentation-properties/) támogatott, és mentéskor a fájlba kerülnek.