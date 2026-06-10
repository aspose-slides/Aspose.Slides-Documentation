---
title: SmartArt grafikák kezelése prezentációkban Python segítségével
linktitle: SmartArt grafikák
type: docs
weight: 20
url: /hu/python-net/manage-smartart-shape/
keywords:
- SmartArt objektum
- SmartArt grafika
- SmartArt stílus
- SmartArt szín
- SmartArt létrehozása
- SmartArt hozzáadása
- SmartArt szerkesztése
- SmartArt módosítása
- SmartArt elérése
- SmartArt elrendezéstípus
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Automatizálja a PowerPoint SmartArt létrehozását, szerkesztését és formázását Pythonból a .NET segítségével az Aspose.Slides használatával, tömör kódpéldákkal és a teljesítményre fókuszáló útmutatóval."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozott módon SmartArt grafikákat hozzon létre és kezeljen PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan adhat hozzá SmartArt alakzatot egy dián, hogyan érheti el a meglévő SmartArt alakzatokat, hogyan találhat SmartArt‑ot egy adott elrendezéstípus szerint, illetve hogyan frissítheti a megjelenését a SmartArt stílus vagy színstílus módosításával.

A példák bemutatják, hogyan dolgozhat SmartArt alakzatokkal a prezentáció dia alakzatgyűjteményén keresztül, ellenőrizheti, hogy egy alakzat SmartArt‑e, majd módosíthatja vagy ellenőrizheti annak tulajdonságait.

## **SmartArt alakzatok létrehozása**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy saját SmartArt alakzatokat adjunk hozzá diákhoz az elejétől. Az API egyszerűvé teszi ezt. A SmartArt alakzat hozzáadásához egy diához:

1. Hozzon létre egy példányt a [Presentation] osztályból.
1. Szerezze meg a cél diát az indexe alapján.
1. Adjon hozzá egy SmartArt alakzatot, megadva annak elrendezéstípusát.
1. Mentse a módosított prezentációt PPTX fájlként.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Példányosítsa a Presentation osztályt.
with slides.Presentation() as presentation:
    # Hozzáférés a prezentáció diájához.
    slide = presentation.slides[0]
    # SmartArt alakzat hozzáadása.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # A prezentáció mentése lemezen.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt alakzatok elérése diákon**

Az alábbi kód bemutatja, hogyan lehet elérni a SmartArt alakzatokat egy dián. A minta minden alakzatot végigjár a dián, és ellenőrzi, hogy az [SmartArt] objektum‑e.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Töltsön be egy prezentációs fájlt.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Iteráljon végig minden alakzaton az első dián.
    for shape in presentation.slides[0].shapes:
        # Ellenőrizze, hogy az alakzat SmartArt alakzat-e.
        if isinstance(shape, smartart.SmartArt):
            # Írja ki az alakzat nevét.
            print("Shape name:", shape.name)
```

## **SmartArt alakzatok elérése megadott elrendezéstípussal**

Az alábbi példa azt mutatja, hogyan érhet el egy SmartArt alakzatot egy megadott elrendezéstípussal. Vegye figyelembe, hogy egy SmartArt elrendezéstípusa nem módosítható – csak olvasható, és az alakzat létrehozásakor kerül beállításra.

1. Hozzon létre egy [Presentation] példányt, és töltse be a SmartArt alakzatot tartalmazó prezentációt.
1. Szerezzen referenciát az első diához az index alapján.
1. Iteráljon végig minden alakzaton az első dián.
1. Ellenőrizze, hogy az alakzat [SmartArt] objektum‑e.
1. Ha a SmartArt alakzat elrendezéstípusa megegyezik a szükségesével, hajtsa végre a szükséges műveleteket.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iteráljon végig minden alakzaton az első dián.
    for shape in presentation.slides[0].shapes:
        # Ellenőrizze, hogy az alakzat SmartArt alakzat-e.
        if isinstance(shape, smartart.SmartArt):
            # Ellenőrizze a SmartArt elrendezéstípust.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **SmartArt alakzat stílusának módosítása**

Az alábbi példa bemutatja, hogyan találhatók meg a SmartArt alakzatok, és hogyan módosítható a stílusuk:

1. Hozzon létre egy [Presentation] objektumot, és töltse be a SmartArt alakzat(ok)at tartalmazó fájlt.
1. Szerezzen referenciát az első diához az index alapján.
1. Iteráljon minden alakzaton az első dián.
1. Keresse meg a megadott stílussal rendelkező SmartArt alakzatot.
1. Rendelje hozzá az új stílust a SmartArt alakzathoz.
1. Mentse a prezentációt.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iteráljon végig minden alakzaton az első dián.
    for shape in presentation.slides[0].shapes:
        # Ellenőrizze, hogy az alakzat SmartArt alakzat-e.
        if isinstance(shape, smartart.SmartArt):
            # Ellenőrizze a SmartArt stílust.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Módosítsa a SmartArt stílust.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Mentse a prezentációt.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt alakzatok színstílusának módosítása**

Ez a példa bemutatja, hogyan módosítható egy SmartArt alakzat színstílusa. A minta kód megtalálja a megadott színstílusú SmartArt alakzatot, és frissíti azt.

1. Hozzon létre egy [Presentation] osztály példányt, és töltse be a SmartArt alakzat(ok)at tartalmazó prezentációt.
1. Szerezzen referenciát az első diához az index alapján.
1. Iteráljon minden alakzaton az első dián.
1. Ellenőrizze, hogy az alakzat [SmartArt] objektum‑e.
1. Keresse meg a megadott színstílussal rendelkező SmartArt alakzatot.
1. Állítsa be az új színstílust az adott SmartArt alakzatra.
1. Mentse a prezentációt.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iteráljon végig minden alakzaton az első dián.
    for shape in presentation.slides[0].shapes:
        # Ellenőrizze, hogy az alakzat SmartArt alakzat-e.
        if isinstance(shape, smartart.SmartArt):
            # Ellenőrizze a szín típusát.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Módosítsa a szín típusát.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Mentse a prezentációt.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Animálhatom a SmartArt‑ot egyetlen objektumként?**

Igen. A SmartArt egy alakzat, ezért a [standard animációkat](/slides/hu/python-net/powerpoint-animation/) alkalmazhatja az animációs API‑n keresztül (belépés, kilépés, hangsúlyozás, mozgásszakaszok), hasonlóan a többi alakzathoz.

**Hogyan találhatok egy konkrét SmartArt‑ot egy dián, ha nem ismerem a belső azonosítóját?**

Állítsa be és használja az Alternative Text (AltText) mezőt, majd keressen az alakzat után ezzel az értékkel – ez a javasolt módja a célalakzat megtalálásának.

**Csoportosíthatom a SmartArt‑ot más alakzatokkal?**

Igen. A SmartArt‑ot csoportosíthatja más alakzatokkal (képek, táblázatok stb.), majd [manipulálhatja a csoportot](/slides/hu/python-net/group/).

**Hogyan szerezhetek képet egy konkrét SmartArt‑ról (pl. előnézet vagy jelentés céljából)?**

Exportáljon egy bélyegképet/képet az alakzatról; a könyvtár képes [egyedi alakzatok renderelésére](/slides/hu/python-net/create-shape-thumbnails/) raszteres fájlokba (PNG/JPG/TIFF).

**Megmarad a SmartArt megjelenése, ha a teljes prezentációt PDF‑re konvertálom?**

Igen. A renderelő motor a magas hűségre törekszik a [PDF export](/slides/hu/python-net/convert-powerpoint-to-pdf/) során, különféle minőség‑ és kompatibilitási beállításokkal.