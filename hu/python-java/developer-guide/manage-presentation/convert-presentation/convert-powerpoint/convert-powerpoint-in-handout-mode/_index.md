---
title: PowerPoint bemutatók konvertálása kiosztási módban Python használatával
linktitle: Kiosztási mód
type: docs
weight: 150
url: /hu/python-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- kiosztási mód
- kiosztás
- PPT
- PPTX
- PowerPoint
- bemutató
- Python
- Java
- Aspose.Slides
description: "PowerPoint bemutatókat konvertál kézikönyvekké Python via Java segítségével. Több diát helyez el egy oldalon, majd PDF-be exportálja az Aspose.Slides használatával."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy a bemutatókat kiosztási módban exportálja, több diát egyetlen oldalon elrendezve. Ez hasznos a bemutató anyagok nyomtatásához konferenciákon, szemináriumokon és hasonló eseményeken.

A elrendezést a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) metódussal állíthatja be. A kiosztási elrendezéseket támogatja a [PdfOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/) és a [TiffOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tiffoptions/). Használjon [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handoutlayoutingoptions/) objektumot az elrendezés és a megjelenítési beállítások megadásához.

## **Kiosztási módú exportálás**

A bemutató kiosztási módban való exportálásához hozzon létre egy [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handoutlayoutingoptions/) példányt, és a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) használatával rendelje hozzá a cél exportálási beállításokhoz.

Az alábbi példa betölti a `sample.pptx` fájlt, és PDF‑ként exportálja négy dia oldalanként vízszintes sorrendben. Tartalmazza a diaszámokat és kereteket a diák körül, valamint kizárja a megjegyzéseket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Betölti a bemutatót.
presentation = Presentation("sample.pptx")
try:
    # Konfigurálja a kiosztási elrendezést.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Exportálja a bemutatót PDF-be a kiválasztott elrendezéssel.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
A kiosztási elrendezési beállítások a támogatott kimeneti formátumokra, például PDF, HTML, TIFF és a renderelt képekre vonatkoznak. Nem rendezik át a diákat a forrásbemutatóban.
{{% /alert %}}

## **GYIK**

**Mi a maximális diaképkockák száma oldalanként a kiosztási módban?**

Az Aspose.Slides legfeljebb kilenc diaképkockát támogat oldalanként. A [HandoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handouttype/) előre beállítottak egy, két, három, négy, hat vagy kilenc dia oldalanként kínálnak. A négy, hat és kilenc diás előre beállítások vízszintes és függőleges elrendezést is lehetővé teszik.

**Definiálhatok egy egyedi rácsot, például öt vagy nyolc dia oldalanként?**

Nem. A diaképkockák száma és sorrendje az előre meghatározott [HandoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handouttype/) értékekkel van szabályozva. Az egyedi rácsok nem támogatottak ezen kiosztási elrendezési beállításokkal.

**Tartalmazhatok rejtett diákat a kiosztási kimenetben?**

Igen. A rejtett diákat engedélyezheti a célformátum exportálási beállításaiban. PDF esetén hívja meg a [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metódust `True` értékkel a bemutató mentése előtt.