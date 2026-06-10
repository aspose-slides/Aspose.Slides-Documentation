---
title: Diákátmenetek kezelése prezentációkban Python használatával
linktitle: Diákátmenet
type: docs
weight: 90
url: /hu/python-net/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- fejlett diaátmenet
- morph átmenet
- átmenettípus
- átmenet hatás
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan testre szabhatja a diaátmeneteket az Aspose.Slides for Python-ban a .NET-en keresztül, lépésről lépésre útmutatóval PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Aspose.Slides for Python teljes irányítást biztosít a diaátmenetek felett, a átmenettípus kiválasztásától a időzítés és az események konfigurálásáig az automatizált prezentációs munkafolyamatok részeként. Beállíthatja, hogy a diák kattintásra vagy egy megadott késleltetés után lépjenek tovább, és finomíthatja a vizuális viselkedést például feketéből vágásokkal vagy irányított belépésekkel. A könyvtár támogatja a PowerPoint 2019‑ben bevezetett Morph átmenetet is, beleértve az objektum, szó vagy karakter szerint morph‑olási módokat, amelyek sima, koherens mozgást hoznak létre a diák között.

## **Diák átmenetek hozzáadása**

Az egyszerűbb megértés érdekében ez a példa bemutatja, hogyan használható az Aspose.Slides for Python az egyszerű diátmenetek kezelésére. A fejlesztők különböző diátmenet‑effekteket alkalmazhatnak a diákra, és testre szabhatják azok viselkedését. Egy egyszerű diátmenet létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Alkalmazzon egy diátmenetet a [TransitionType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/transitiontype/) felsorolt egyik effektusával.
3. Mentse el a módosított prezentációfájlt.

```py
import aspose.slides as slides

# A Presentation osztály példányosítása egy prezentációs fájl betöltéséhez.
with slides.Presentation("sample.pptx") as presentation:
    # Kör alakú átmenet alkalmazása az 1. diára.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Fésű alakú átmenet alkalmazása a 2. diára.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # A prezentáció mentése a lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Haladó diátmenetek hozzáadása**

Ebben a szakaszban egy egyszerű átmenet‑effektet alkalmaztunk egy diára. Az effektet pontosabbá és kifinomultabbá tenni, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Alkalmazzon egy diátmenetet a [TransitionType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/transitiontype/) felsorolt egyik effektusával.
3. Állítsa be az átmenetet, hogy **Advance On Click**, egy meghatározott idő elteltével, vagy mindkettő.
4. Mentse el a módosított prezentációfájlt.

Ha a **Advance On Click** engedélyezve van, a dia csak a felhasználó kattintására lép tovább. Ha a **Advance After Time** tulajdonság be van állítva, a dia automatikusan a megadott időintervallum után lép tovább.

```py
import aspose.slides as slides

# A Presentation osztály példányosítása egy prezentációs fájl megnyitásához.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Kör átmenet alkalmazása az 1. diára.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Kattintásra való előrehaladás engedélyezése és 3 másodperces automatikus előrehaladás beállítása.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Fésű átmenet alkalmazása a 2. diára.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Kattintásra való előrehaladás engedélyezése és 5 másodperces automatikus előrehaladás beállítása.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Zoom átmenet alkalmazása a 3. diára.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Kattintásra való előrehaladás engedélyezése és 7 másodperces automatikus előrehaladás beállítása.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # A prezentáció mentése a lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph átmenet**

Aspose.Slides for Python támogatja a [Morph transition](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/morphtransition/) átmenetet, amely animálja a sima mozgást az egyik dia és a következő között. Ez a szakasz elmagyarázza, hogyan használható a Morph átmenet. Hatékony használatához két dia szükséges, amelyek legalább egy közös objektumot tartalmaznak. A legegyszerűbb módszer egy dia duplikálása, majd a közös objektum áthelyezése a második diába.

Az alábbi kódrészlet bemutatja, hogyan klónozhat egy szöveget tartalmazó diát, és alkalmazhat Morph átmenetet a második diára.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Az első dia klónozása egy második dia létrehozásához, amely ugyanazokat a formákat tartalmazza a Morph folytonosságához.
    slide1 = presentation.slides.add_clone(slide0)

    # A második dián válassza ki ugyanazt a téglalapot, és módosítsa annak pozícióját és méretét.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Engedélyezze a Morph átmenetet a második dián, hogy a formaváltozások simán animálódjanak.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph átmenet típusai**

A [TransitionMorphType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/transitionmorphtype/) felsorolás (enum) a Morph diátmenetek különböző típusait képviseli.

Az alábbi kódrészlet bemutatja, hogyan lehet Morph átmenetet alkalmazni egy diára, és módosítani a morph típust:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Átmenet effektusok beállítása**

Az Aspose.Slides for Python lehetővé teszi átmenet‑effektek beállítását, például **From Black**, **From Left**, **From Right**, stb. Egy átmenet‑effekt beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát a diához.
3. Állítsa be a kívánt átmenet‑effektet.
4. Mentse el a prezentációt PPTX fájlként.

Az alábbi példában több átmenet‑effektet állítunk be.

```py
import aspose.slides as slides

# A Presentation osztály példányosítása egy prezentációs fájl megnyitásához.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Cut átmenet alkalmazása és a From Black engedélyezése.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # A prezentáció mentése a lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le tudom-e szabályozni a diátmenet lejátszási sebességét?**

Igen. Állítsa be a transzíció [speed](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/speed/) értékét a [TransitionSpeed](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/transitionspeed/) beállítással (például lassú/közepes/gyors).

**Csatolhatok hangot egy átmenethez, és beállíthatom-e a hurok módot?**

Igen. Beágyazhat hangot az átmenethez, és a viselkedését szabályozhatja a hang mód, a hurok stb. beállításokkal (például [sound](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), valamint a metaadatok, mint a [sound_is_built_in](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) és a [sound_name](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden diára alkalmazzam?**

Állítsa be a kívánt átmenettípust minden dia átmenet‑beállításában; az átmenetek diáronként kerülnek tárolásra, ezért ugyanazt a típust minden diára alkalmazva konzisztens eredményt kap.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Vizsgálja meg a dia [transition settings](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/slide_show_transition/) beállításait, és olvassa el a [transition type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét; ez megmutatja, pontosan melyik effekt van alkalmazva.