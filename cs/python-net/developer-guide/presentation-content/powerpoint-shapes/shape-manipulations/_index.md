---
title: Správa tvarů v prezentacích pomocí Pythonu
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/python-net/shape-manipulations/
keywords:
- Tvar PowerPoint
- Tvar prezentace
- Tvar na snímku
- Vyhledat tvar
- Klonovat tvar
- Odstranit tvar
- Skrýt tvar
- Změnit pořadí tvaru
- Získat interop ID tvaru
- Alternativní text tvaru
- Formáty rozvržení tvaru
- Tvar jako SVG
- Tvar do SVG
- Zarovnat tvar
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se vytvářet, upravovat a optimalizovat tvary v Aspose.Slides pro Python přes .NET a vytvářet vysoce výkonné prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento průvodce představuje manipulaci s tvary v Aspose.Slides pro Python přes .NET. Naučte se praktické postupy pro vyhledávání tvarů (včetně podle alternativního textu), duplikaci, mazání nebo skrytí, změnu pořadí, zarovnání a převrácení, čtení ID a formátování řízeného rozvržením a export jednotlivých tvarů do SVG pomocí API [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/).

## **Najít tvary na snímcích**

PowerPoint rozpoznává tvary pouze podle interních ID. Přidejte jedinečný alternativní text cílovému tvaru v PowerPointu, poté otevřete prezentaci pomocí Aspose.Slides pro Python, projděte tvary snímku a vyberte ten, jehož alternativní text odpovídá. Metoda `find_shape` tento přístup implementuje a vrací odpovídající tvar.

```py
import aspose.slides as slides

# Najde tvar na snímku podle jeho alternativního textu.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Vytvoří instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Najde tvar s alternativním textem "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Klonovat tvary**

Chcete‑li klonovat tvary ze zdrojového snímku do nového snímku v Aspose.Slides, postupujte takto:

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) ze zdrojového souboru.  
1. Získejte zdrojový snímek podle indexu a jeho kolekci tvarů.  
1. Načtěte prázdné rozvržení z master‑snímku.  
1. Přidejte prázdný snímek pomocí tohoto rozvržení a získejte jeho tvary.  
1. Naklonujte tvary do cílového snímku.  
1. Uložte prezentaci jako PPTX.

Následující ukázkový kód klonuje tvary z jednoho snímku do druhého.

```py
import aspose.slides as slides

# Vytvoří instanci třídy Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Uloží prezentaci na disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranit tvary**

Aspose.Slides umožňuje odebrat libovolný tvar ze snímku. Například chcete‑li smazat tvar z prvního snímku podle jeho alternativního textu, postupujte takto:

1. Vytvořte instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte soubor.  
1. Získejte první snímek z kolekce snímků.  
1. Najděte tvar podle hodnoty alternativního textu.  
1. Odeberte tvar z kolekce tvarů snímku.  
1. Uložte prezentaci na disk ve formátu PPTX.

```py
import aspose.slides as slides

# Najde tvar na snímku podle jeho alternativního textu.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Vytvoří instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Najde tvar s alternativním textem "User Defined".
    shape = find_shape(slide, "User Defined")
    # Odebere tvar.
    slide.shapes.remove(shape)
    # Uloží prezentaci na disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Skrýt tvary**

Aspose.Slides umožňuje skrýt libovolný tvar na snímku. Například chcete‑li skrýt tvar na prvním snímku podle jeho alternativního textu, postupujte takto:

1. Vytvořte instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte soubor.  
1. Získejte první snímek z kolekce snímků.  
1. Najděte tvar podle hodnoty alternativního textu.  
1. Skryjte tvar.  
1. Uložte prezentaci na disk ve formátu PPTX.

```py
# Najde tvar na snímku podle jeho alternativního textu.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Vytvoří instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Najde tvar s alternativním textem "User Defined".
    shape = find_shape(slide, "User Defined")
    # Skryje tvar.
    shape.hidden = True
    # Uloží prezentaci na disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Změnit pořadí tvarů**

Aspose.Slides umožňuje vývojářům změnit pořadí tvarů (z‑order). Změna pořadí určuje, který tvar bude před ostatními a který za nimi. Například chcete‑li změnit pořadí dvou tvarů na prvním snímku, postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).  
1. Získejte první snímek.  
1. Přidejte první tvar (např. obdélník).  
1. Přidejte druhý tvar (např. trojúhelník).  
1. Změňte pořadí tvarů přesunutím druhého tvaru na první pozici v kolekci.  
1. Uložte prezentaci na disk.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Přidá dva tvary na snímek.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Přesune druhý tvar na první pozici.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Získat Interop ID tvaru**

Aspose.Slides umožňuje získat jedinečný identifikátor tvaru v rozsahu snímku, na rozdíl od vlastnosti `unique_id`, která je jedinečná v celé prezentaci. Vlastnost `office_interop_shape_id` je k dispozici ve třídě [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/). Její hodnota odpovídá `Id` objektu `Microsoft.Office.Interop.PowerPoint.Shape`. Níže je ukázkový fragment kódu.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Získá jedinečný identifikátor tvaru v rámci snímku.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Nastavit alternativní text pro tvary**

Aspose.Slides umožňuje vývojářům nastavit alternativní text pro libovolný tvar. Alternativní text můžete použít k identifikaci a vyhledávání tvarů v prezentaci. Vlastnost alternativního textu lze číst i zapisovat jak z Aspose.Slides, tak z Microsoft PowerPoint. Označením tvarů touto vlastností je můžete později odstranit, skrýt nebo změnit jejich pořadí na snímku.

Pro nastavení alternativního textu tvaru postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).  
1. Získejte první snímek.  
1. Přidejte tvar na snímek.  
1. Nastavte alternativní text.  
1. Uložte prezentaci na disk.

```py
import aspose.slides as slides

# Vytvoří instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Přidá tvar.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Nastaví alternativní text pro tvar.
    shape.alternative_text = "User Defined"
    # Uloží prezentaci na disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k formátům rozvržení pro tvary**

Aspose.Slides poskytuje jednoduché API pro přístup k formátům rozvržení tvarů. Tato část ukazuje, jak získat formáty rozvržení.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Vykreslit tvary jako SVG**

Aspose.Slides podporuje vykreslování tvarů jako SVG. Metoda `write_as_svg` (a její přetížení) ve třídě [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) umožňuje uložit obsah tvaru jako SVG‑obrázek. Níže uvedený fragment kódu ukazuje, jak exportovat tvar do souboru SVG.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Získá první tvar na prvním snímku.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Zarovnat tvar**

Pomocí metody `align_shape` ve třídě [SlidesUtil](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/) můžete:

* Zarovnávat tvary vzhledem k okrajům snímku (viz Příklad 1).  
* Zarovnávat tvary vzhledem k sobě navzájem (viz Příklad 2).

Výčtová hodnota [ShapesAlignmentType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapesalignmenttype/) definuje dostupné možnosti zarovnání.

**Příklad 1**

Tento Python‑kód ukazuje, jak zarovnat tvary s indexy 1, 2 a 4 k hornímu okraji snímku:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Příklad 2**

Tento Python‑příklad ukazuje, jak zarovnat všechny tvary v kolekci vzhledem k nejnižšímu tvaru v této kolekci:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Vlastnosti překlápění**

V Aspose.Slides třída [ShapeFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapeframe/) poskytuje ovládání horizontálního a vertikálního zrcadlení tvarů pomocí vlastností `flip_h` a `flip_v`. Obě vlastnosti jsou typu [NullableBool](https://reference.aspose.com/slides/cs/python-net/aspose.slides/nullablebool/) a umožňují hodnoty `TRUE` (překlopit), `FALSE` (nepřeklopit) nebo `NOT_DEFINED` (použít výchozí chování). Tyto hodnoty jsou přístupné z [tvaru Frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/frame/).

Chcete‑li upravit nastavení překlápění, vytvoří se nová instance [ShapeFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapeframe/) s aktuální pozicí a velikostí tvaru, požadovanými hodnotami `flip_h` a `flip_v` a úhlem otočení. Přiřazením této instance k [tvaru Frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/frame/) a uložením prezentace se aplikují zrcadlové transformace a zapíšou do výstupního souboru.

Předpokládejme, že máme soubor sample.pptx, ve kterém první snímek obsahuje jediný tvar s výchozím nastavením překlápění, jak je zobrazено níže.

![The shape to be flipped](shape_to_be_flipped.png)

Následující ukázkový kód načte aktuální vlastnosti překlápění tvaru a přeloží jej horizontálně i vertikálně.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Získá horizontální vlastnost překlápění tvaru.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Získá vertikální vlastnost překlápění tvaru.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Překlápí horizontálně i vertikálně.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The flipped shape](flipped_shape.png)

## **Často kladené otázky**

**Mohu na snímku sloučit tvary (union/intersect/subtract) jako v desktopovém editoru?**

Neexistuje vestavěné API pro booleovské operace. Můžete to napodobit vytvořením požadovaného obrysu sami — např. vypočítat výslednou geometrii (pomocí [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/)) a vytvořit nový tvar s touto konturou, volitelně odstranit původní tvary.

**Jak mohu řídit pořadí vrstvení (z‑order), aby tvar vždy zůstal „nahoře“?**

Změňte pořadí vložení/přesunu v kolekci [shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/shapes/) snímku. Pro předvídatelné výsledky definujte z‑order po všech ostatních úpravách snímku.

**Mohu „uzamknout“ tvar, aby ho uživatelé nemohli v PowerPointu upravovat?**

Ano. Nastavte [ochranné příznaky na úrovni tvaru](/slides/cs/python-net/applying-protection-to-presentation/) (např. zamknutí výběru, přesunu, změny velikosti, úpravy textu). V potřebě můžete tuto ochranu replikovat v masteru nebo rozvržení. Upozorňujeme, že jde o ochranu na úrovni uživatelského rozhraní, nikoli o bezpečnostní prvek; pro vyšší zabezpečení kombinujte s omezeními na úrovni souboru, např. doporučením jen pro čtení nebo hesly ([read‑only recommendations or passwords](/slides/cs/python-net/password-protected-presentation/)).