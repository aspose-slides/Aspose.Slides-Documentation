---
title: Správa SmartArt v PowerPoint prezentacích pomocí Pythonu
linktitle: Správa SmartArt
type: docs
weight: 10
url: /cs/python-net/manage-smartart/
keywords:
- SmartArt
- text ze SmartArt
- typ rozvržení
- skrytá vlastnost
- organizační schéma
- obrázkové organizační schéma
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se vytvářet a upravovat SmartArt v PowerPointu pomocí Aspose.Slides pro Python přes .NET s jasnými ukázkami kódu, které urychlí návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram v PowerPointu vytvořený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides for Python via .NET můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, zkoumat skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu ze SmartArt objektu**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro přečtení viditelného textu projděte [SmartArt.all_nodes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/all_nodes/), poté přečtěte [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/), který vrací [SmartArtShape.text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **Změna typu rozvržení SmartArt objektu**

Rozvržení SmartArt řídí, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří SmartArt objekt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, změní ji na hodnotu `BASIC_PROCESS` a uloží prezentaci.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrola, zda je uzel SmartArt skrytý**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartartnode/is_hidden/) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou ve struktuře existovat i tehdy, když vybrané rozvržení nezobrazuje je jako viditelné prvky diagramu.

Následující příklad přidá uzel do SmartArt objektu, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`, a zkontroluje stav skrytí uzlu.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Získání nebo nastavení rozvržení organizačního diagramu**

Pro SmartArt diagramy, které používají rozvržení organizačního diagramu, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) určuje, jak jsou podřízené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit podřízené uzly tak, aby visely zleva, zprava nebo z obou stran, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupné obrázky. Při přidávání SmartArt objektu na snímek použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro RTL jazyky?**

Ano. Vlastnost [SmartArt.is_reversed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/is_reversed/) přepíná směr diagramu z levé‑pravé na pravou‑levou, nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/python-net/shape-manipulations/) pomocí [ShapeCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_clone/) nebo [klonovat celý snímek](/slides/cs/python-net/clone-slides/), který SmartArt obsahuje. Oba přístupy zachovávají velikost, umístění i formátování.

**Jak mohu vykreslit SmartArt do rastrového obrázku pro náhled nebo export na web?**

[Vykreslete snímek](/slides/cs/python-net/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní SmartArt objekt na snímku, pokud jich je několik?**

Nastavte jedinečnou hodnotu [Shape.alternative_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/alternative_text/) nebo [Shape.name](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/name/) na tvar SmartArt, vyhledejte tuto hodnotu v [Slide.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/shapes/), a poté ověřte, že odpovídající tvar je [SmartArt](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/).