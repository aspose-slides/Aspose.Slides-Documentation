---
title: A teljes dia háttér lekérése egy prezentációból képként
linktitle: Teljes dia háttér
type: docs
weight: 95
url: /hu/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- dia
- háttér
- dia háttér
- végső háttér
- háttér képre
- PowerPoint
- OpenDocument
- prezentáció
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "A teljes dia hátterek kinyerése képként PowerPoint és OpenDocument prezentációkból az Aspose.Slides for Python .NET-en keresztül, egyszerűsítve a vizuális munkafolyamatokat."
---
## **Áttekintés**

PowerPoint prezentációkban a dia háttér több elemből állhat, beleértve a dia háttérképet, a prezentáció témáját, a színsémát és a mester- vagy elrendezésdia‑ra helyezett objektumokat.

Ez a cikk bemutatja, hogyan lehet kinyerni a teljes dia hátteret képként az Aspose.Slides használatával. Mivel nincs egyetlen beépített módszer erre, a megközelítés a kiválasztott dia klónozását jelenti egy ideiglenes prezentációba, a dia alakzatainak eltávolítását, majd a kapott háttér konvertálását képpé.

## **A teljes dia háttér megszerzése**

Aspose.Slides for Python nem biztosít egyszerű módszert a teljes prezentációs dia háttér képként történő kinyerésére, de az alábbi lépésekkel elvégezhető:
1. Töltsd be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály használatával.
1. Szerezd meg a dia méretét a prezentációból.
1. Válassz ki egy diát.
1. Hozz létre egy ideiglenes prezentációt.
1. Állítsd be ugyanazt a dia méretet az ideiglenes prezentációban.
1. Klónozd a kiválasztott diát az ideiglenes prezentációba.
1. Töröld az alakzatokat a klónozott diáról.
1. Konvertáld a klónozott diát képpé.

Az alábbi kódrészlet kinyeri a teljes prezentációs dia hátteret képként.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **GYIK**

**A mester dia összetett színátmenetei, textúrái vagy képpel kitöltött területei megmaradnak a létrehozott háttérképen?**

Igen. Az Aspose.Slides rendereli a diához, elrendezéshez vagy mesterhez rendelt színátmenet, kép és textúra kitöltéseket. Ha el szeretnéd különíteni a megjelenést az örökölt mesterektől, akkor [állíts be saját háttérrel](/slides/hu/python-net/presentation-background/) a jelenlegi diát az exportálás előtt.

**Hozzáadhatok vízjelet a létrehozott háttérképhez mentés előtt?**

Igen. Hozzáadhatsz [vízjelet](/slides/hu/python-net/watermark/) alakzatot vagy képet egy munkaközeli [dia másolatához](/slides/hu/python-net/clone-slides/) (a többi tartalom mögé helyezve), majd exportálhatod. Így olyan háttérképet kapsz, amelyben a vízjel be van égetve.

**Lekérhetem egy adott elrendezés vagy mester háttérképét anélkül, hogy meglévő diához kötöm?**

Igen. Elérheted a kívánt mestert vagy elrendezést, alkalmazhatod egy [ideiglenes diára](/slides/hu/python-net/clone-slides/) a szükséges mérettel, majd exportálhatod azt a diát, hogy megkapd az adott elrendezésből vagy mesterből származó hátteret.

**Vannak licencelési korlátozások, amelyek befolyásolják a kép exportálást?**

A renderelési funkciók teljes mértékben elérhetők [érvényes licenc](/slides/hu/python-net/licensing/) mellett. Értékelő módban a kimenet korlátozásokkal, például vízjellel jelenhet meg. Aktiváld a licencet egyszer a folyamatban, mielőtt kötegelt exportokat indítasz.