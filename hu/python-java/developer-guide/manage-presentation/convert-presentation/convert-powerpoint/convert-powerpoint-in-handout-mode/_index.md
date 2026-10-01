---
title: PowerPoint prezentációk konvertálása kézbeosztási módban Python használatával
linktitle: Kézbeosztási mód
type: docs
weight: 150
url: /hu/python-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- kézbeosztási mód
- kézbeosztás
- PPT
- PPTX
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "PowerPoint prezentációkat kézbeosztássá konvertálja Pythonon keresztül Java-ban. Több diát rendez oldalanként, és exportál PDF-be az Aspose.Slides segítségével."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy a prezentációkat kézbeosztású módban exportálja, több diát egyetlen oldalra rendezve. Ez hasznos a prezentációs anyagok nyomtatásához konferenciákon, szemináriumokon és hasonló eseményeken.

Állítsa be az elrendezést a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) metóduson keresztül. A kézbeosztási elrendezéseket támogatja a [PdfOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/), a [RenderingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/), a [HtmlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/) és a [TiffOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tiffoptions/). Használjon egy [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handoutlayoutingoptions/) objektumot az elrendezés és a megjelenítési beállítások megadásához.

A kézbeosztási oldal méreteinek és tájolásának export előtt történő beállításához lásd a [Megjegyzés oldal mérete](/slides/hu/python-java/notes-size/) oldalt.

## **Kézbeosztási módú exportálás**

A prezentáció kézbeosztási módban történő exportálásához hozza létre a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handoutlayoutingoptions/) példányt, és rendelje hozzá a cél exportálási beállításokhoz a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) használatával.

Az alábbi példa betölti a `sample.pptx` fájlt, és PDF‑ként exportálja négy diát oldalanként vízszintes sorrendben. Tartalmaz diaszámokat és kereteket a diák körül, és kizárja a megjegyzéseket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Töltsön be egy prezentációt.
presentation = Presentation("sample.pptx")
try:
    # Állítsa be a kézbeosztási elrendezést.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Exportálja a prezentációt PDF-be a kiválasztott elrendezéssel.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
A kézbeosztási elrendezési beállítások a támogatott kimeneti formátumokra, például PDF, HTML, TIFF és renderelt képek esetén vonatkoznak. Nem rendezik át a diák sorrendjét a forrás prezentációban.
{{% /alert %}}

## **GYIK**

**Mi a maximális diaképek száma oldalanként a kézbeosztási módban?**

Az Aspose.Slides legfeljebb kilenc képet támogat oldalanként. A [HandoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handouttype/) előbeállításai egy, két, három, négy, hat vagy kilenc diát kínálnak oldalanként. A négy, hat és kilenc diás előbeállítások vízszintes és függőleges sorrendet is biztosítanak.

**Definiálhatok egy egyéni rácsot, például öt vagy nyolc diát oldalanként?**

Nem. A képek számát és sorrendjét a beépített [HandoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handouttype/) értékek határozzák meg. Az egyéni rácsok nincsenek támogatva ezekkel a kézbeosztási elrendezési beállításokkal.

**Tartalmazhatok rejtett diákat a kézbeosztási kimenetben?**

Igen. Engedélyezze a rejtett diák megjelenítését az exportálási beállításokban a cél formátumhoz. PDF esetén hívja meg a [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metódust `True` értékkel a prezentáció mentése előtt.