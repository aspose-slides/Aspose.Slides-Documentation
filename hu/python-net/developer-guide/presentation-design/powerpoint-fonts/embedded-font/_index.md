---
title: Betűtípusok beágyazása prezentációkba Pythonban
linktitle: Betűtípus beágyazása
type: docs
weight: 40
url: /hu/python-net/embedded-font/
keywords:
- betűtípus hozzáadása
- betűtípus beágyazása
- betűtípus beágyazás
- beágyazott betűtípus lekérése
- beágyazott betűtípus hozzáadása
- beágyazott betűtípus eltávolítása
- beágyazott betűtípus tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "TrueType betűtípusok beágyazása PowerPoint és OpenDocument prezentációkba az Aspose.Slides for Python via .NET segítségével, biztosítva a pontos megjelenítést minden platformon."
---
## **Bevezetés**

**A betűtípusok beágyazása a PowerPointban** biztosítja, hogy a bemutatója megőrizze a kívánt megjelenését különböző rendszereken. Akár egyedi betűtípusokat használ a kreativitáshoz, akár szabványosakat, a betűtípusok beágyazása megakadályozza a szöveg és az elrendezés problémáit.

Ha a munkájában kreativitás miatt harmadik fél vagy nem szabványos betűtípust használt, akkor még több oka van a betűtípus beágyazására. Ellenkező esetben (beágyazott betűtípusok nélkül) a diákon lévő szövegek vagy számok, az elrendezés, a stílus stb. megváltozhatnak, vagy zavaró téglalapokká alakulhatnak.

Használja a [FontsManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/), a [FontData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontdata/), és a [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) osztályokat a beágyazott betűtípusok kezeléséhez.

## **Beágyazott betűtípusok lekérése és eltávolítása**

A beágyazott betűtípusok egyszerű lekérdezése vagy eltávolítása a prezentációból a [get_embedded_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) és a [remove_embedded_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/remove_embedded_font/) metódusokkal valósítható meg.

Ez a Python kód bemutatja, hogyan lehet lekérni és eltávolítani a beágyazott betűtípusokat egy prezentációból:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Renderelje a diát, amely egy szövegkeretet tartalmaz, és a beágyazott 'FunSized' betűtípust használja.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Szerezze meg az összes beágyazott betűtípust.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Keresse meg a 'Calibri' betűtípust.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Távolítsa el a 'Calibri' betűtípust.
    fonts_manager.remove_embedded_font(font_data)

    # Renderelje a diát; a 'Calibri' betűtípust egy meglévő fogja helyettesíteni.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Mentse a prezentációt a beágyazott 'Calibri' betűtípus nélkül a lemezre.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Beágyazott betűtípusok hozzáadása**

Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/embedfontcharacters/) felsorolás és az [add_embedded_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/add_embedded_font/) metódus két túlterhelése segítségével kiválaszthatja a kívánt (beágyazási) szabályt a betűtípusok prezentációba történő beágyazásához. Ez a Python kód bemutatja, hogyan lehet beágyazni és hozzáadni a betűtípusokat egy prezentációhoz:

```python
import aspose.slides as slides

# Töltsön be egy prezentációt.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Mentse a prezentációt a lemezre.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Beágyazott betűtípusok tömörítése**

Optimalizálja a fájlméretet a beágyazott betűtípusok tömörítésével a [compress_embedded_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) használatával.

Példa kód a tömörítésre:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Hogyan tudhatom, hogy egy adott betűtípus a prezentációban a beágyazás ellenére is helyettesítésre kerül a megjelenítés során?**

Ellenőrizze a [helyettesítési információkat](/slides/hu/python-net/font-substitution/) a betűtípus-kezelőben, valamint a [fallback/helyettesítési szabályokat](/slides/hu/python-net/fallback-font/): ha a betűtípus nem érhető el vagy korlátozott, egy helyettesítő lesz használva.

**Éri-e meg a "rendszer" betűtípusok, például az Arial/Calibri beágyazása?**

Általában nem – ezek szinte mindig elérhetők. Azonban „vékony” környezetekben (Docker, egy előre telepített betűtípusok nélküli Linux szerver) a rendszerbetűtípusok beágyazása kiküszöbölheti a váratlan helyettesítések kockázatát.