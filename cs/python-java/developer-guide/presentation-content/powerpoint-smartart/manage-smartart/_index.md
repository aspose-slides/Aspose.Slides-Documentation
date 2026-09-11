---
title: Správa SmartArt v PowerPoint prezentacích pomocí Pythonu
linktitle: Správa SmartArt
type: docs
weight: 10
url: /cs/python-java/manage-smartart/
keywords:
- SmartArt
- Text SmartArt
- typ rozvržení
- skrytá vlastnost
- organizační schéma
- obrázkové organizační schéma
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se vytvářet a upravovat PowerPoint SmartArt pomocí Aspose.Slides pro Python přes Java s jasnými ukázkami kódu, které urychlují návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu vytvořený z uzlů, tvarů uzlů a rozvržení. Pomocí Aspose.Slides pro Python prostřednictvím Javy můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, kontrolovat skryté uzly, konfigurovat rozvržení organizačních schémat a vytvářet obrázkové organizační schémata.

## **Získání textu ze SmartArt objektu**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro přečtení viditelného textu projděte [SmartArt.getAllNodes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/#getAllNodes) a poté přečtěte [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) vrácený metodou [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartshape/#getTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Změna typu rozvržení SmartArt objektu**

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří objekt SmartArt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, změní jej na hodnotu `BasicProcess` a uloží prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontrola, zda je SmartArt uzel skrytý**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnode/#isHidden) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou existovat ve struktuře, i když vybrané rozvržení je nezobrazuje jako viditelné prvky diagramu.

Následující příklad přidá uzel do objektu SmartArt, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartlayouttype/) `RadialCycle`, a zkontroluje stav skrytí uzlu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Získání nebo nastavení rozvržení organizačního schématu**

Pro diagramy SmartArt, které používají rozvržení organizačního schématu, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) a [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) definují, jak jsou podřízené uzly uspořádány pod rodičovským uzlem. Například můžete nastavit, aby se podřízené uzly věšely vlevo, vpravo nebo na obou stranách, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/organizationchartlayouttype/).

Následující příklad vytvoří organizační schéma a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vytvoření obrázkového organizačního schématu**

Obrázkové organizační schéma je rozvržení SmartArt určené pro hierarchické diagramy, které zahrnují zástupné obrázky. Při přidávání objektu SmartArt na snímek použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Podporuje SmartArt zrcadlení nebo obrácení pro RTL jazyky?**

Ano. Metoda [SmartArt.setReversed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/#setReversed) přepíná směr diagramu z levého na pravý na pravý na levý, nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/python-java/shape-manipulations/) pomocí [ShapeCollection.addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addClone) nebo [klonovat celý snímek](/slides/cs/python-java/clone-slides/), který SmartArt obsahuje. Oba přístupy zachovají velikost, pozici i formátování.

**Jak mohu vykreslit SmartArt do rastrového obrazu pro náhled nebo export na web?**

[Renderujte snímek](/slides/cs/python-java/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní SmartArt objekt na snímku, pokud jich je několik?**

Nastavte jedinečnou hodnotu pomocí [Shape.getAlternativeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getAlternativeText) nebo [Shape.getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getName) na tvar SmartArt, vyhledejte tuto hodnotu v [BaseSlide.getShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getShapes) a poté ověřte, že odpovídající tvar je [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).