---
title: Správa SmartArt v prezentacích PowerPoint pomocí Pythonu
linktitle: Spravovat SmartArt
type: docs
weight: 10
url: /cs/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt text
- typ rozložení
- skrytá vlastnost
- organizační diagram
- obrázkový organizační diagram
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se vytvářet a upravovat PowerPoint SmartArt pomocí Aspose.Slides pro Python přes .NET s jasnými ukázkovými kódy, které urychlují návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu vytvořený z uzlů, tvarů uzlů a rozložení. Pomocí Aspose.Slides pro Python přes .NET můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozložení, prohlížet skryté uzly, konfigurovat rozložení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu z objektu SmartArt**

Uzol SmartArt může obsahovat jeden nebo více tvarů. Pro čtení textu z tvarů uzlu iterujte přes [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), pak přečtěte [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) který vrací [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

Příklad vyžaduje prezentaci s alespoň jedním snímkem a objektem SmartArt jako prvním tvarem na tomto snímku. Vypíše každý dostupný textový rámec do konzoly.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **Změna typu rozložení objektu SmartArt**

Rozložení SmartArt řídí, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří objekt SmartArt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, změní ji na hodnotu `BASIC_PROCESS` a uloží prezentaci. Pozice a velikost předávané metodě [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) jsou měřeny v bodech. Nastavte [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/), chcete-li změnit rozložení.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrola, zda je uzel SmartArt skrytý**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou existovat ve struktuře, i když vybrané rozložení nezobrazuje je jako viditelné prvky diagramu.

Následující příklad přidá uzel do objektu SmartArt, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`, a zkontroluje stav skrytí přidaného uzlu. Vypíše zprávu, pokud je uzel skrytý, a uloží diagram.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Získání nebo nastavení rozložení organizačního diagramu**

U diagramů SmartArt, které používají rozložení organizačního diagramu, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) určuje, jak jsou podřízené uzly uspořádány pod rodičovským uzlem. Například můžete nastavit podřízené uzly, aby visely zleva, zprava nebo z obou stran, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozložení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`. Index založený na nule `0` vybere první uzel nejvyšší úrovně; jeho podřízené uzly použijí vybrané uspořádání. Upravená prezentace je poté uložena.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozložení SmartArt navržené pro hierarchické diagramy, které obsahují zástupné obrázky. Použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` při přidávání objektu SmartArt na snímek. Tento příklad uloží diagram se zástupnými obrázky; nezaplní však zástupné obrázky obrázky.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Převod starých diagramů na skupiny tvarů**

Při modernizaci existující prezentace můžete potřebovat aktualizovat organizační diagram původně vytvořený v PowerPointu 97-2003. Aspose.Slides představuje tyto staré diagramy jako objekty [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Použijte [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/), chcete-li převést diagram na skupinu tvarů, abyste mohli upravovat jednotlivé vizuální prvky. Podrobnosti najdete v [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/).

Převod přidá novou skupinu do kolekce tvarů, aniž by odstranil původní diagram. Po úspěšném převodu odstraňte originál pomocí [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/), abyste se vyhnuli duplicitnímu obsahu. Před převodem sesbírejte staré diagramy do seznamu, aby přidávání a odstraňování tvarů nepřerušilo iteraci.

Následující příklad otevře prezentaci, prohledá každý snímek, převede diagramy na skupiny tvarů a uloží aktualizovanou prezentaci jako PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

Uložená prezentace obsahuje editovatelné skupiny tvarů místo převedených starých diagramů, přičemž žádné původní diagramy již nebývají. Otevřete PPTX v PowerPointu a upravujte jednotlivé prvky v každé skupině, například jejich text, výplň nebo pozici.

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro RTL jazyky?**

Ano. Vlastnost [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) přepíná směr diagramu zleva-doprava na zprava-doleva, nebo zpět, pokud vybrané rozložení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/python-net/shape-manipulations/) pomocí [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) nebo [klonovat celý snímek](/slides/cs/python-net/clone-slides/), který SmartArt obsahuje. Oba přístupy zachovávají velikost, pozici a formátování.

**Jak mohu renderovat SmartArt do rastrového obrazu pro náhled nebo export na web?**

[Vykreslete snímek](/slides/cs/python-net/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní objekt SmartArt na snímku, pokud jich je několik?**

Nastavte výrazný [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) nebo [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) na tvar SmartArt, vyhledejte tuto hodnotu v [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), a pak ověřte, že odpovídající tvar je [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).