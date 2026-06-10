---
title: Elrendezési dia
type: docs
weight: 20
url: /hu/python-net/examples/elements/layout-slide/
keywords:
- elrendezési dia
- elrendezési dia hozzáadása
- elrendezési dia elérése
- elrendezési dia eltávolítása
- nem használt elrendezési dia
- elrendezési dia klónozása
- kódpéldák
- PowerPoint
- OpenDocument
- bemutató
- Python
- Aspose.Slides
description: "Használja a Python-t az elrendezési diák kezelésére az Aspose.Slides segítségével: hozzon létre, alkalmazzon, klónozzon, nevezzen át, és testreszabjon helyőrzőket és sablonokat a PPT, PPTX és ODP formátumú bemutatókban."
---
Ez a cikk bemutatja, hogyan lehet **Elrendezési diák** (Layout Slides) használni az Aspose.Slides for Python via .NET-ben. Egy elrendezési dia határozza meg a normál diák által örökölt tervezést és formázást. Hozzáadhat, elérhet, klónozhat és eltávolíthat elrendezési diákat, valamint megtisztíthatja a nem használtakat a bemutató méretének csökkentése érdekében.

## **Elrendezési dia hozzáadása**

Létrehozhat egy egyéni elrendezési diát a újrahasználható formázás meghatározásához.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Létrehoz egy elrendezési diát a megadott típussal és névvel.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tipp 1:** Az elrendezési diák sablonként szolgálnak az egyes diákhoz. A közös elemeket egyszer definiálhatja, és sok diában újra felhasználhatja őket.

> 💡 **Tipp 2:** Amikor alakzatot vagy szöveget ad hozzá egy elrendezési diához, az arra épülő összes dia automatikusan megjeleníti ezt a megosztott tartalmat.  
> Az alábbi képernyőkép két diát mutat, amelyek mindegyike ugyanarról az elrendezési diáról örököl egy szövegdobozt.

![Diaok öröklik az elrendezés tartalmát](layout-slide-result.png)


## **Elrendezési dia elérése**

Az elrendezési diák elérhetők index alapján vagy elrendezéstípus szerint (például `Blank`, `Title`, `SectionHeader`, stb.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Hozzáférés index alapján.
        first_layout_slide = presentation.layout_slides[0]

        # Hozzáférés elrendezéstípus alapján.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Elrendezési dia eltávolítása**

Eltávolíthat egy adott elrendezési diát, ha már nincs rá szükség.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Szerezz be egy elrendezési diát típus szerint és távolítsd el.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Nem használt elrendezési diák eltávolítása**

A bemutató méretének csökkentése érdekében érdemes eltávolítani azokat az elrendezési diákat, amelyeket egyetlen normál dia sem használ.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Automatikusan eltávolítja az összes elrendezési diát, amelyet egyetlen dia sem hivatkozik.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Elrendezési dia klónozása**

Megkettőzheti egy elrendezési diát az `AddClone` metódus segítségével.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Szerezzen be egy meglévő elrendezési diát típus szerint.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Klónozza az elrendezési diát a elrendezési diák gyűjteményének végére.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Összefoglalás:** Az elrendezési diák hatékony eszközök a következetes formázás kezelésére a diák között. Az Aspose.Slides teljes irányítást biztosít az elrendezési diák létrehozásához, kezeléséhez és optimalizálásához.