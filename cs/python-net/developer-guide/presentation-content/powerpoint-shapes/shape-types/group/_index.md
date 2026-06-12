---
title: Skupinové tvary prezentace v Pythonu
linktitle: Skupina tvarů
type: docs
weight: 40
url: /cs/python-net/group/
keywords:
- skupinový tvar
- skupina tvarů
- přidat skupinu
- alternativní text
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se seskupovat a rozrušovat tvary v PowerPointu a sadách OpenDocument pomocí Aspose.Slides pro Python—rychlý průvodce krok za krokem s volným kódem."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat se skupinovými tvary v Aspose.Slides. Ukazuje, jak přidat skupinový tvar na snímek, umístit do něj tvary a uložit aktualizovanou prezentaci. Také demonstruje, jak získat přístup k tvarům uloženým ve skupině a přečíst jejich hodnoty `alternative_text`. Navíc článek stručně popisuje související funkce skupinových tvarů, jako jsou vnořené skupiny, z‑order a možnosti zamykání.

## **Přidání skupinových tvarů**

Aspose.Slides podporuje práci se skupinovými tvary na snímku. Tato funkce vám umožní vytvářet bohatší prezentace tím, že zacházíte s více tvary jako s jediným objektem. Můžete přidávat nové skupinové tvary, přistupovat k existujícím, naplňovat je podřízenými tvary a číst nebo měnit jejich vlastnosti. Pro přidání skupinového tvaru na snímek:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle indexu.
3. Přidejte na snímek [GroupShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/).
4. Přidejte tvary do nového skupinového tvaru.
5. Uložte upravenou prezentaci jako soubor PPTX.

Níže uvedený příklad ukazuje, jak přidat skupinový tvar na snímek.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte skupinový tvar na snímek.
    group_shape = slide.shapes.add_group_shape()

    # Přidejte tvary do skupinového tvaru.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Uložte soubor PPTX na disk.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k vlastnosti Alt Text**

Tato část vysvětluje, jak pomocí Aspose.Slides načíst Alt Text tvarů obsažených ve skupinovém tvaru na snímku. Pro získání Alt Textu tvarů:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), která představuje soubor PPTX.
2. Získejte odkaz na snímek podle jeho indexu.
3. Přistupte ke kolekci tvarů snímku.
4. Přistupte k [GroupShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/).
5. Přečtěte vlastnost Alt Text.

Níže uvedený příklad získá Alt Text tvarů obsažených ve skupinových tvarech.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation pro otevření souboru PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Přístup ke skupinovému tvaru.
            for child_shape in shape.shapes:
                # Přístup k vlastnosti Alt Text.
                print(child_shape.alternative_text)
```

## **Často kladené otázky**

**Je podporováno vnořené seskupování (skupina uvnitř skupiny)?**

Ano. [GroupShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/) má vlastnost [parent_group](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/parent_group/), která přímo naznačuje podporu hierarchie (skupina může být podskupinou jiné skupiny).

**Jak mohu řídit z‑order skupiny vzhledem k dalším objektům na snímku?**

Použijte vlastnost [z_order_position](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/z_order_position/) třídy [GroupShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/), abyste zjistili její pozici v obrazovém zásobníku.

**Mohu zabránit přesunu/upravování/odskupování?**

Ano. Sekce zamykání skupiny je zpřístupněna prostřednictvím [group_shape_lock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/group_shape_lock/), což vám umožní omezit operace s objektem.