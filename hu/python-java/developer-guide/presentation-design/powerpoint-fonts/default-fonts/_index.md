---
title: Alapértelmezett prezentációs betűtípusok megadása Python segítségével Java-ban
linktitle: Alapértelmezett betűtípus
type: docs
weight: 30
url: /hu/python-java/default-font/
keywords:
- alapértelmezett betűtípus
- normál betűtípus
- normál betűtípus
- ázsiai betűtípus
- PDF export
- XPS export
- kép export
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Állítsa be az alapértelmezett betűtípusokat az Aspose.Slides for Python via Java-ban, hogy megfelelő legyen a PowerPoint (PPT, PPTX) és OpenDocument (ODP) konvertálás PDF-re, XPS-re és képekre."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy megadja az alapértelmezett betűtípusokat, amelyeket egy prezentáció renderelésekor használ. Ez hasznos diakép bélyegképek készítésekor vagy egy prezentáció exportálásakor olyan formátumokba, mint a PDF és az XPS. Az alapértelmezett betűtípusok a [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) segítségével állíthatók be, még a prezentáció betöltése előtt.

A [setDefaultRegularFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) metódus határozza meg az alapértelmezett betűtípust a normál szöveghez, míg a [setDefaultAsianFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) az ázsiai szöveghez. Miután ezeket a beállításokat megadta, a prezentáció betölthető és renderelhető a megadott betűtípusokkal.

## **Alapértelmezett betűtípusok használata egy prezentáció rendereléséhez**

Aspose.Slides lehetővé teszi, hogy alapértelmezett betűtípusokat állítson be egy prezentáció PDF‑, XPS‑ vagy bélyegkép‑rendereléséhez. Ez a szakasz bemutatja, hogyan definiálhat alapértelmezett betűtípusokat a normál és ázsiai szöveghez az Aspose.Slides for Python via Java segítségével:

1. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) példányt.
1. Használja a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) metódust a kívánt betűtípus megadásához. A következő példa a Wingdings‑et használja.
1. Használja a [setDefaultAsianFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) metódust a kívánt betűtípus megadásához. A következő példa szintén a Wingdings‑et használja.
1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) segítségével a betöltési beállításokkal.
1. Generáljon diakép bélyegképet, PDF‑et és XPS‑et a végeredmény ellenőrzéséhez.

A következő példa megvalósítja ezeket a lépéseket:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Használja a betöltési beállításokat az alapértelmezett normál és ázsiai betűtípusok meghatározásához.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Töltse be a prezentációt.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Generáljon diakép bélyegképet.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Mentse a képet lemezre.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Generáljon PDF-et.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Generáljon XPS dokumentumot.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **GYIK**

**Pontosan mire hatnak az alapértelmezett normál és ázsiai betűtípusok – csak az exportálásra, vagy a bélyegképekre, PDF‑re, XPS‑re, HTML‑re és SVG‑re is?**

Részt vesznek a renderelési csővezetékben minden támogatott kimenetnél. Ez magában foglalja a diakép bélyegképeket, a [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/), a [XPS](/slides/hu/python-java/convert-powerpoint-to-xps/), a [raszteres képeket](/slides/hu/python-java/convert-powerpoint-to-png/), a [HTML](/slides/hu/python-java/convert-powerpoint-to-html/), és az [SVG](/slides/hu/python-java/render-a-slide-as-an-svg-image/) formátumokat, mivel az Aspose.Slides ugyanazt a layout‑ és glyf‑feloldási logikát használja ezeknél a célpontoknál.

**Alkalmazzák az alapértelmezett betűtípusokat, ha csak egy PPTX‑et olvasunk be és mentünk anélkül, hogy renderelnénk?**

Nem. Az alapértelmezett betűtípusok akkor számítanak, amikor a szöveget mérni és kirajzolni kell. Egy egyszerű megnyitás‑mentés nem változtatja meg a tárolt betűtípus‑futamokat vagy a fájl struktúráját. Az alapértelmezett betűtípusok csak a renderelést vagy a szöveg újrafolyását igénylő műveleteknél lépnek életbe.

**Ha saját betűtípus‑mappákat adok hozzá, vagy memóriából biztosítok betűtípusokat, figyelembe veszik ezeket az alapértelmezett betűtípusok kiválasztásakor?**

Igen. A [Custom font sources](/slides/hu/python-java/custom-font/) bővíti a rendelkezésre álló családok és glyfek katalógusát, amelyet a motor használhat. Az alapértelmezett betűtípusok és a [fallback rules](/slides/hu/python-java/fallback-font/) először ezeken a forrásokon keresztül oldják fel a betűtípust, ezáltal megbízhatóbb lefedettséget biztosítanak szervereken és konténerekben.

**Befolyásolják-e az alapértelmezett betűtípusok a szöveg metrikáit (kerning, advance‑ek), és így a sortöréseket és a betördelést?**

Igen. A betűtípus megváltoztatása módosítja a glyf‑metrikákat, ami befolyásolhatja a sortöréseket, a betördelést és a lapozást renderelés közben. A layout stabilitásáért [ágyazzák be az eredeti betűtípusokat](/slides/hu/python-java/embedded-font/) vagy metrikailag kompatibilis alapértelmezett és tartalék családok kiválasztása javasolt.

**Van-e értelme alapértelmezett betűtípusokat beállítani, ha a prezentációban használt összes betűtípus be van ágyazva?**

Gyakran nincs szükség rá, mert a [embedded fonts](/slides/hu/python-java/embedded-font/) már biztosítja a konzisztens megjelenést. Az alapértelmezett betűtípusok mégis hasznosak védelmi hálóként olyan karakterek esetén, amelyek nincsenek lefedve a beágyazott részhalmazban, vagy ha egy fájl kevert beágyazott és nem beágyazott szöveget tartalmaz.