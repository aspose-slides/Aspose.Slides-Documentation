---
title: Bemutatók mentése Pythonban
linktitle: Bemutatók mentése
type: docs
weight: 80
url: /hu/python-net/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- bemutató mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- bemutató fájlba
- bemutató adatfolyamba
- előre definiált nézet típus
- Szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentés folyamat
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan menthet bemutatókat Pythonban az Aspose.Slides segítségével – exportáljon PowerPoint vagy OpenDocument formátumba, miközben megőrizze a elrendezéseket, betűtípusokat és effektusokat."
---
## **Áttekintés**

[Open a Presentation in Python](/slides/hu/python-net/open-presentation/) leírja, hogyan kell használni a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt egy bemutató megnyitásához. Ez a cikk bemutatja, hogyan hozhatók létre és menthetők a bemutatók. A [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály a bemutató tartalmát tartalmazza. Akár a semmiből hoz létre egy bemutatót, akár meglévőt módosít, a végén menteni kell. Az Aspose.Slides for Python segítségével **fájlba** vagy **adatfolyamba** menthet. Ez a cikk a bemutató mentésének különböző módjait ismerteti.

## **Bemutatók mentése fájlokba**

A bemutató fájlba menthető a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály `save` metódusának meghívásával. A metódusnak adja meg a fájlnevet és a mentési formátumot. Az alábbi példa bemutatja, hogyan menthetünk egy bemutatót az Aspose.Slides for Python segítségével.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel.
with slides.Presentation() as presentation:
    
    # Végrehajt néhány műveletet itt...

    # Mentse a bemutatót fájlba.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bemutatók mentése adatfolyamokba**

A bemutató adatfolyamba menthető egy kimeneti adatfolyam átadásával a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály `save` metódusához. A bemutató számos adatfolyam típusba írható. Az alábbi példában egy új bemutatót hozunk létre, és fájl adatfolyamba mentjük.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Mentse a bemutatót az adatfolyamra.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Bemutatók mentése előre definiált nézet típussal**

Az Aspose.Slides for Python lehetővé teszi, hogy beállítsa a PowerPoint által a generált bemutató megnyitásakor használt kezdeti nézetet a [ViewProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/) osztályon keresztül. Állítsa a `last_view` tulajdonságot a [ViewType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewtype/) felsorolás egyik értékére.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Bemutatók mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi a bemutató mentését a szigorú Office Open XML formátumban. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/) osztályt, és állítsa be a `conformance` tulajdonságot mentéskor. Ha a `Conformance.ISO_29500_2008_STRICT` értéket adja meg, a kimeneti fájl a szigorú Office Open XML formátumban lesz elmentve.

Az alábbi példa egy bemutatót hoz létre, és a szigorú Office Open XML formátumban menti el.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel.
with slides.Presentation() as presentation:
    # Mentse a bemutatót a szigorú Office Open XML formátumban.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Bemutatók mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab a kicsomagolt méretre, a tömörített méretre és az archívum teljes méretére, valamint legfeljebb 65 535 (2^16‑1) fájlt engedélyez. A ZIP64 formátumkiterjesztések ezen korlátokat 2^64‑re emelik.

A [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) tulajdonság lehetővé teszi, hogy megadja, mikor használjon ZIP64 formátumkiterjesztéseket Office Open XML fájl mentésekor.

Ez a tulajdonság a következő módokat biztosítja:

- `IF_NECESSARY` csak akkor használja a ZIP64 formátumkiterjesztéseket, ha a bemutató meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- `NEVER` soha nem használja a ZIP64 formátumkiterjesztéseket.
- `ALWAYS` mindig használja a ZIP64 formátumkiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthet egy bemutatót PPTX fájlként ZIP64 formátumkiterjesztésekkel engedélyezve:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Amikor a `Zip64Mode.NEVER` értékkel ment, egy [PptxException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxexception/) kerül dobásra, ha a bemutató nem menthető ZIP32 formátumban.
{{% /alert %}}

## **Bemutatók mentése Office Open XML formátumban tömörítési szintekkel**

Nagy bemutatók esetén beállíthatja a tömörítési szintet a fájlméret és a feldolgozási idő kiegyensúlyozásához. Igényeinek megfelelően választhat a gyorsabb feldolgozás vagy a kisebb kimeneti fájlok között.

Az Aspose.Slides biztosítja a [PptxOptions.compression_level](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/compression_level/) tulajdonságot, amely lehetővé teszi a tömörítési szint megadását Office Open XML formátumban történő mentéskor.

A rendelkezésre álló tömörítési szintek:

- [**NONE**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): Nincs tömörítés. A fájlok változatlanul kerülnek tárolásra.
- [**LEVEL1**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): A leggyorsabb tömörítés, a legalacsonyabb tömörítési aránnyal.
- [**LEVEL2**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): Gyorsabb tömörítés, mint a **LEVEL1**, enyhén jobb tömörítési arányt biztosít.
- [**LEVEL3**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): Jobb tömörítés, mint a **LEVEL2**, mérsékelt hatással a feldolgozási időre.
- [**LEVEL4**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): Jobb tömörítés, mint a **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): Javított tömörítés a **LEVEL4**-hez képest, de több feldolgozási időt igényel.
- [**LEVEL6**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): Standard tömörítés, jó egyensúlyt kínál a sebesség és a fájlméret között. Ez az *alapértelmezett tömörítési szint*.
- [**LEVEL7**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): Jobb tömörítés, mint a **LEVEL6**, de lassabb feldolgozással.
- [**LEVEL8**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): Jobb tömörítés, mint a **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/): Maximális tömörítés. A legkisebb fájlméretet érheti el, de a leghosszabb feldolgozási időt igényli.

Az alábbi példa bemutatja, hogyan menthet egy bemutatót PPTX fájlként *tömörítés nélkül*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Ez a példa *maximális tömörítéssel* menti a bemutatót PPTX fájlként:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Bemutatók mentése a bélyegkép frissítése nélkül**

A [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) tulajdonság szabályozza a bélyegkép generálását PPTX formátumba mentéskor:

- Ha `True`‑ra van állítva, a bélyegkép a mentés közben frissül. Ez az alapértelmezett.
- Ha `False`‑ra van állítva, a jelenlegi bélyegkép megmarad. Ha a bemutató nem rendelkezik bélyegképpel, nem lesz generálva új.

Az alábbi kódban a bemutató PPTX‑ként mentésre kerül a bélyegkép frissítése nélkül.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Ez a lehetőség segít csökkenteni a PPTX formátumba történő mentéshez szükséges időt.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Az Aspose egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) fejlesztett ki saját API‑jával. Az alkalmazás lehetővé teszi, hogy egy bemutatót több fájlra bontson úgy, hogy a kiválasztott diák új PPTX vagy PPT fájlként kerülnek mentésre.
{{% /alert %}}

## **GYIK**

**Támogatja a „gyors mentés” (inkrementális mentés) funkciót, amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Biztonságos-e több szálról ugyanazt a Presentation példányt menteni?**

Nem. Egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példány [nem szálbiztonságos](/slides/hu/python-net/multithreading/); csak egy szálból mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg linkelt fájlokkal mentéskor?**

A [Hyperlinks](/slides/hu/python-net/manage-hyperlinks/) megmaradnak. A külsőleg linkelt fájlok (például relatív útvonalú videók) nem másolódnak automatikusan – gondoskodjon arról, hogy a hivatkozott útvonalak továbbra is elérhetők legyenek.

**Beállítható/menthető a dokumentum metaadata (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [document properties](/slides/hu/python-net/presentation-properties/) támogatott, és a mentéskor be lesznek írva a fájlba.