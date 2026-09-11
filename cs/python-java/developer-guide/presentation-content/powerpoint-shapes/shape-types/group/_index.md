---
title: Skupinové tvary v prezentaci v Pythonu přes Java
linktitle: Skupina tvarů
type: docs
weight: 40
url: /cs/python-java/group/
keywords:
- skupinový tvar
- skupina tvarů
- přidat skupinu
- alternativní text
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se seskupovat a rozdělovat tvary v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes Java - podrobný postup s volně dostupným Python kódem."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat se skupinovými tvary v Aspose.Slides. Ukazuje, jak přidat skupinový tvar do snímku, umístit do něj tvary a uložit aktualizovanou prezentaci. Také demonstruje, jak přistupovat k tvarům uloženým ve skupině a číst jejich alternativní text pomocí [getAlternativeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getAlternativeText). Kromě toho článek stručně pokrývá související možnosti skupinových tvarů, jako jsou vnořené skupiny, pořadí Z a možnosti uzamčení.

## **Přidání skupinového tvaru**

Aspose.Slides podporuje práci se skupinovými tvary na snímcích. Tato funkce pomáhá vývojářům vytvářet bohatší prezentace. Aspose.Slides pro Python přes Java podporuje přidávání a přístup ke skupinovým tvarům. Můžete naplnit skupinový tvar tvary nebo přistupovat k jeho vlastnostem. Pro přidání skupinového tvaru do snímku pomocí Aspose.Slides pro Python přes Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte skupinový tvar do snímku.
4. Přidejte tvary do skupinového tvaru.
5. Uložte upravenou prezentaci jako soubor PPTX.

Příklad níže přidává skupinový tvar do snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    # Získat první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přistupte ke kolekci tvarů snímku.
    slide_shapes = slide.getShapes()

    # Přidejte skupinový tvar na snímek.
    group_shape = slide_shapes.addGroupShape()

    # Přidejte tvary uvnitř skupinového tvaru.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Nastavte rámec skupinového tvaru.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Zapište soubor PPTX na disk.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přístup k alternativnímu textu**

Tato sekce ukazuje, jak získat alternativní text tvarů uvnitř skupiny na snímku. Pro přístup k tomuto textu pomocí Aspose.Slides pro Python přes Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), která představuje soubor PPTX.
2. Získejte odkaz na snímek podle jeho indexu.
3. Přistupte ke kolekci tvarů snímku.
4. Přistupte ke skupinovému tvaru.
5. Přečtěte alternativní text jejích tvarů pomocí [getAlternativeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getAlternativeText).

Příklad níže získává alternativní text tvarů uvnitř skupiny:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Získat první snímek.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Přistupte k tvaru v kolekci tvarů snímku.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Přistupte k tvarům uvnitř skupiny.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Přečtěte alternativní text.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **Časté dotazy**

**Je podporováno vnořené seskupování (skupina uvnitř skupiny)?**

Ano. [GroupShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/groupshape/) má metodu [getParentGroup](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getParentGroup), která naznačuje podporu hierarchie: skupina může být podřízená jiné skupině.

**Jak mohu ovládat z‑order skupiny vzhledem k ostatním objektům na snímku?**

Použijte metodu [getZOrderPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getZOrderPosition) objektu [GroupShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/groupshape/) k prozkoumání jeho pozice v zobrazovacím zásobníku.

**Mohu zabránit přesunu, úpravám nebo rozdělení skupiny?**

Ano. Zámky skupiny jsou přístupné přes [getGroupShapeLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/groupshape/#getGroupShapeLock), což vám umožní omezit operace s objektem.