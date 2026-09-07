---
title: PowerPoint előadások konvertálása TIFF-be jegyzetekkel Pythonban
linktitle: PowerPoint TIFF-be jegyzetekkel
type: docs
weight: 100
url: /hu/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint TIFF-be
- prezentáció TIFF-be
- dia TIFF-be
- PPT TIFF-be
- PPTX TIFF-be
- PPT mentése TIFF-ként
- PPTX mentése TIFF-ként
- PPT exportálása TIFF-be
- PPTX exportálása TIFF-be
- PowerPoint jegyzetekkel
- prezentáció jegyzetekkel
- dia jegyzetekkel
- PPT jegyzetekkel
- PPTX jegyzetekkel
- TIFF jegyzetekkel
- Python
- Java
- Aspose.Slides
description: "PowerPoint előadásokat konvertál TIFF-be jegyzetekkel az Aspose.Slides for Python via Java segítségével. Tanulja meg, hogyan exportálhatja a diákat hangjegyzetekkel hatékonyan."
---
## **Bevezetés**

Aspose.Slides for Python via Java egyszerű megoldást nyújt a PowerPoint és OpenDocument prezentációk (PPT, PPTX és ODP) jegyzetekkel együtt TIFF formátumba konvertálására. Ez a formátum széles körben használatos magas minőségű képek tárolására, nyomtatásra és dokumentumok archiválására. Használja a [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályon, hogy a diákat és a hangjegyzeteiket egyetlen többszörös oldalas TIFF fájlba exportálja.

## **Prezentáció konvertálása TIFF-be jegyzetekkel**

A PowerPoint vagy OpenDocument prezentáció TIFF-be jegyzetekkel történő mentése az Aspose.Slides for Python via Java segítségével a következő lépéseket igényli:

1. Hozza létre a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányát: Töltse be a PowerPoint vagy OpenDocument fájlt.
1. Állítsa be a kimeneti elrendezési beállításokat: Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) osztályt a jegyzetek és megjegyzések megjelenítésének meghatározásához.
1. Mentse a prezentációt TIFF-be: Adja át a beállított lehetőségeket a [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak.

Tegyük fel, hogy van egy "speaker_notes.pptx" fájlunk a következő diával:

![A prezentáció dia hangjegyzetekkel](slide_with_notes.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # A teljes hangjegyzetek megjelenítése minden diánál alul.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # A TIFF felbontás és a jegyzetek elrendezésének beállítása.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # A prezentáció mentése TIFF-be hangjegyzetekkel.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Az eredmény:

![A TIFF kép hangjegyzetekkel](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Tekintse meg az Aspose [Ingyenes PowerPoint poszter konvertert](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Módosíthatom a jegyzetek területének pozícióját az eredmény TIFF-ben?**

Igen. Állítsa be a [setNotesPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metódust a [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomTruncated) értékkel, hogy a jegyzeteket egy oldalon helyezze el, esetleg levágva őket, vagy a [NotesPositions.BottomFull](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomFull) értékkel, hogy szükség esetén további oldalakon is megjelenítse az összes jegyzetet. A jegyzetek nélküli diák exportálásához hagyja el a jegyzetelrendezés konfigurációját, ahogy a [Convert PowerPoint to TIFF](/slides/hu/python-java/convert-powerpoint-to-tiff/) példában látható.

**Hogyan csökkenthetem a jegyzetes TIFF fájl méretét anélkül, hogy a képminőség romlana?**

Használjon veszteségmentes [LZW compression](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tiffcompressiontypes/#LZW) a [setCompressionType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tiffoptions/#setCompressionType) metóduson keresztül. A felbontás vagy a színmélység csökkentése tovább csökkentheti a fájl méretét, de befolyásolhatja a képminőséget és a jegyzetek olvashatóságát. További beállításokért tekintse meg a [TIFF export settings](/slides/hu/python-java/convert-powerpoint-to-tiff/) oldalt.

**A jegyzetekben használt betűtípus befolyásolja az eredményt, ha az eredeti betűtípusok hiányoznak a rendszerből?**

Igen. A hiányzó betűtípusok [betűtípus helyettesítés](/slides/hu/python-java/font-selection-sequence/) folyamatot indítanak, ami megváltoztathatja a szöveg metrikáit és megjelenését. [Szállítson be a szükséges betűtípusokat](/slides/hu/python-java/custom-font/) a kívánt betűstílusok megőrzéséhez.