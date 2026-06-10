---
title: Mesterdia
type: docs
weight: 30
url: /hu/python-net/examples/elements/master-slide/
keywords:
- mesterdia
- mesterdia hozzáadása
- mesterdia elérése
- mesterdia eltávolítása
- nem használt mesterdia
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Kezeld a mesterdiákat Pythonban az Aspose.Slides segítségével: hozd létre, szerkeszd, klónozd és formázd a témákat, háttereket, helyőrzőket, hogy egységesítsd a diákot PowerPointban és OpenDocumentben."
---
A mesterdiák alkotják a diák öröklési hierarchiájának legfelső szintjét a PowerPointban. Egy **mesterdia** meghatározza a közös tervezési elemeket, például háttérképeket, logókat és szövegformázást. **Elrendezési diák** öröklik a mesterdiaiakról, és a **normál diák** az elrendezési diákból örökölnek.

Ez a cikk bemutatja, hogyan hozhatók létre, módosíthatók és kezelhetők a mesterdiák az Aspose.Slides for Python via .NET használatával.

## **Mesterdia hozzáadása**

Ez a példa azt mutatja be, hogyan hozhatunk létre egy új mesterdiát az alapértelmezett klónozásával.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Klónozza az alapértelmezett mesterdiát.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** A mesterdiák lehetővé teszik a következetes márkajelzés vagy közös tervezési elemek alkalmazását az összes diasoron. A mesteren végzett módosítások automatikusan megjelennek a függő elrendezési és normál diákon.

> 💡 **Tip 2:** A mesterdiára hozzáadott alakzatok vagy formázások öröklődnek az elrendezési diákra, és ezáltal minden olyan normál diára, amely ezeket az elrendezéseket használja.

Az alábbi kép szemlélteti, hogyan jelenik meg automatikusan egy mesterdiára felvett szövegdoboz a végső dián.

![Mesteröröklési példa](master-slide-banner.png)

## **Mesterdia elérése**

A mesterdiák a `Presentation.masters` gyűjtemény segítségével érhetők el. Íme, hogyan kérhetők le és dolgozhatunk velük:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Eléri az első mesterdiát.
        first_master_slide = presentation.masters[0]
```

## **Mesterdia eltávolítása**

A mesterdiák eltávolíthatók index vagy referencia alapján.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Index szerint eltávolítás.
        presentation.masters.remove_at(0)

        # Vagy referenciával eltávolítás.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Nem használt mesterdiák eltávolítása**

Egyes előadásokat nem használt mesterdiák tartalmaznak. Ezek eltávolítása segíthet csökkenteni a fájlméretet.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Távolítsa el az összes nem használt mesterdiát (még azokat is, amelyeket Preserve-nek jelöltek).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** Használd a `remove_unused(True)` függvényt a nem használt mesterdiák megtisztításához és az előadás méretének minimalizálásához.