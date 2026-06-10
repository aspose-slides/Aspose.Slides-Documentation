---
title: Prezentációk mentése Pythonban
linktitle: Prezentációk mentése
type: docs
weight: 80
url: /hu/python-net/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- prezentáció mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- prezentáció fájlba
- prezentáció folyamra
- előre definiált nézet típus
- szigorú Office Open XML formátum
- Zip64 mód
- miniatűr frissítése
- mentési folyamat
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan menthet prezentációkat Pythonban az Aspose.Slides használatával – exportálás PowerPoint vagy OpenDocument formátumba, miközben megőrzik a elrendezéseket, betűtípusokat és effektusokat."
---
## **Áttekintés**

[Open a Presentation in Python](/slides/hu/python-net/open-presentation/) leírja, hogyan lehet a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt használni bemutató megnyitásához. Ez a cikk bemutatja, hogyan hozhatunk létre és menthetünk prezentációkat. A [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály a prezentáció tartalmát tartalmazza. Akár új prezentációt hoz létre, akár meglévőt módosít, a végén el kell mentenie azt. Az Aspose.Slides for Python segítségével **fájlba** vagy **folyamba** menthet. Ez a cikk ismerteti a prezentáció mentésének különböző módjait.

## **Prezentációk mentése fájlokba**

Mentse a prezentációt egy fájlba a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály `save` metódusának meghívásával. Adja meg a fájl nevét és a mentési formátumot a metódusnak. Az alábbi példa bemutatja, hogyan menthetünk egy prezentációt az Aspose.Slides for Python segítségével.

```py
import aspose.slides as slides

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:
    
    # Végezzen itt valamilyen műveletet...

    # Mentse a prezentációt egy fájlba.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Prezentációk mentése folyamokba**

A prezentációt egy folyamra menthetjük, ha egy kimeneti folyamot adunk át a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály `save` metódusának. A prezentáció számos folamtípusra írható. Az alábbi példában egy új prezentációt hozunk létre, szöveget adunk egy alakzathoz, és a folyamra mentjük.

```py
import aspose.slides as slides

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # A prezentációt a folyamra menti.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Prezentációk mentése előre definiált nézet típussal**

Az Aspose.Slides for Python lehetővé teszi, hogy beállítsa a PowerPoint által a generált prezentáció megnyitásakor használt kezdeti nézetet a [ViewProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/) osztályon keresztül. Állítsa be a `last_view` tulajdonságot a [ViewType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewtype/) felsorolás egyik értékére.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációt a szigorú Office Open XML formátumban mentsünk. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/) osztályt, és mentéskor állítsa be a `conformance` tulajdonságát. Ha `Conformance.ISO_29500_2008_STRICT` értéket ad meg, a kimeneti fájl a szigorú Office Open XML formátumban kerül mentésre.

Az alábbi példa egy prezentációt hoz létre, és a szigorú Office Open XML formátumban menti.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:
    # A prezentációt a szigorú Office Open XML formátumban menti.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 byte) korlátot szab a bármely fájl tömörítetlen méretére, a tömörített méretére és az archívum teljes méretére, valamint legfeljebb 65 535 (2^16‑1) fájl tárolására. A ZIP64 formátumkiegészítések ezeket a korlátokat 2^64‑re emelik.

A [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) tulajdonság lehetővé teszi, hogy meghatározza, mikor használja a ZIP64 formátumkiegészítéseket Office Open XML fájl mentésekor.

Ez a tulajdonság a következő módokat kínálja:

- `IF_NECESSARY` csak akkor használ ZIP64 formátumkiegészítéseket, ha a prezentáció meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- `NEVER` soha nem használ ZIP64 formátumkiegészítéseket.
- `ALWAYS` mindig használ ZIP64 formátumkiegészítéseket.

Az alábbi kód bemutatja, hogyan menthetünk egy prezentációt PPTX formátumban, a ZIP64 formátumkiegészítésekkel engedélyezve:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Ha `Zip64Mode.NEVER` beállítással ment, akkor egy [PptxException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxexception/) kerül dobásra, ha a prezentációt nem lehet ZIP32 formátumban menteni.
{{% /alert %}}

## **Prezentációk mentése a miniatűr frissítése nélkül**

A [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) tulajdonság szabályozza a miniatűr generálását, amikor egy prezentációt PPTX‑ként ment:

- Ha `True` értékre van állítva, a miniatűr mentéskor frissül. Ez az alapértelmezett.
- Ha `False` értékre van állítva, a jelenlegi miniatűr megmarad. Ha a prezentációnak nincs miniatűre, akkor nem generálódik.

Az alábbi kódban a prezentációt PPTX‑ként mentjük a miniatűr frissítése nélkül.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Ez a beállítás segít csökkenteni a PPTX formátumba történő mentés idejét.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Az Aspose kifejlesztett egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) saját API-jával. Az alkalmazás lehetővé teszi, hogy egy prezentációt több fájlra bontson úgy, hogy a kiválasztott diák új PPTX vagy PPT fájlokként kerülnek mentésre.
{{% /alert %}}

## **GYIK**

**Támogatott a „gyors mentés” (inkrementális mentés), amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nincs támogatva.

**Biztonságos-e több szálról ugyanazt a Presentation példányt menteni?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példány [nem szálbiztos](/slides/hu/python-net/multithreading/); csak egy szálról mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal mentéskor?**

[Hyperlinks](/slides/hu/python-net/manage-hyperlinks/) megmaradnak. A külsőleg hivatkozott fájlok (például relatív útvonalú videók) nem kerülnek automatikusan másolásra – gondoskodjon arról, hogy a hivatkozott útvonalak elérhetők maradjanak.

**Beállíthatom/menthetem a dokumentum metaadatait (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [dokumentumtulajdonságok](/slides/hu/python-net/presentation-properties/) támogatottak, és mentéskor a fájlba kerülnek.