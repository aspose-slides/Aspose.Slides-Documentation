---
title: PowerPoint szöveg animálása Pythonban
linktitle: Animált szöveg
type: docs
weight: 60
url: /hu/python-net/animated-text/
keywords:
- animált szöveg
- szöveg animáció
- animált bekezdés
- bekezdés animáció
- animációs effektus
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Készítsen dinamikus animált szöveget PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Python .NET-en keresztül, könnyen követhető, optimalizált kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan animálhatja a szöveget PowerPoint‑bemutatókban az Aspose.Slides for Python segítségével. Megtanulja, hogyan adhat hozzá effektusokat az egyes bekezdésekhez, hogyan állíthatja be a kiváltókat, és hogyan olvashatja vissza a meglévő animációs sorozatokat. A végére képes lesz újrahasználható szöveg‑animációs munkafolyamatokat létrehozni, amelyek szabványos PPTX formátumba exportálhatók és helyesen lejátszhatók PowerPointban.

## **Bekezdés‑animációs effektusok hozzáadása**

Az [add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) metódus a [Sequence](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/) osztályban lehetővé teszi, hogy animációs effektust alkalmazzon egyetlen bekezdésre. Az alábbi példakód bemutatja, hogyan kell ezt megtenni:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Válassza ki a bekezdést a hatás hozzáadásához.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Adjon hozzá egy Repülés animációs hatást a kiválasztott bekezdéshez.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Bekezdés‑animációs effektusok lekérése**

Lehet, hogy meg szeretné határozni, mely animációs effektusok vannak alkalmazva egy bekezdésre – például, ha ezeket az effektusokat egy másik bekezdésre vagy alakzatra szeretné másolni.

Az Aspose.Slides for Python lehetővé teszi, hogy lekérje az összes animációs effektust, amely a szövegdoboz (alakzat) bekezdéseire van alkalmazva. Az alábbi példakód megmutatja, hogyan lehet lekérni egy bekezdés animációs effektusait:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **GYIK**

**Hogyan különbözik a szöveg animáció a diaátmenetektől, és kombinálhatóak-e?**

A szöveg animációk az objektum viselkedését szabályozzák időben a dián, míg a [transitions](/slides/hu/python-net/slide-transition/) a diák átváltását irányítják. Függetlenek egymástól, és együtt használhatók; a lejátszási sorrendet az animációs idővonal és a átmenet beállításai szabják meg.

**Megmaradnak a szöveg animációk PDF vagy képek exportálásakor?**

Nem. A PDF és a raszteres képek statikusak, ezért a diát mozgás nélkül, egyetlen állapotban láthatja. A mozgás megtartásához használjon [video](/slides/hu/python-net/convert-powerpoint-to-video/) vagy [HTML](/slides/hu/python-net/export-to-html5/) exportot.

**Működnek a szöveg animációk elrendezésekben és a dia mesterben?**

Az elrendezés/mester objektumokra alkalmazott effektusok öröklődnek a diákra, de azok időzítése és a dia‑szintű animációkkal való kölcsönhatása a dián végleges sorozattól függ.