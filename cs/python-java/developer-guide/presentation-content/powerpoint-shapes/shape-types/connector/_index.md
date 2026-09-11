---
title: Správa konektorů v prezentacích v Pythonu přes Java
linktitle: Konektor
type: docs
weight: 10
url: /cs/python-java/connector/
keywords:
- konektor
- typ konektoru
- bod konektoru
- čára konektoru
- úhel konektoru
- místo připojení
- bod úpravy
- propojit tvary
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Python přes Java přidávat, připojovat, přesměrovávat, upravovat a zkoumat přímé, ohnuté a zakřivené konektory PowerPointu."
---
## **Přehled**

Konektor je čára, která může zůstat připojena ke dvěma tvarem, i když se kterýkoli z tvarů pohybuje. Jeho konce se připojují k místům připojení, která jsou v PowerPointu zobrazena zelenými tečkami. Některé ohnuté a zakřivené konektory také zobrazují body úpravy, označené oranžovými tečkami, které řídí pozici jednotlivých segmentů konektoru.

Aspose.Slides reprezentuje konektory pomocí třídy [Connector](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connector/). Můžete je vytvářet, připojovat jejich konce k tvarům, vybírat místa připojení, přesměrovávat je a upravovat geometrii konektorů, které mají body úpravy.

## **Typy konektorů**

Třída [ShapeType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/) obsahuje předvolby pro přímé, ohnuté a zakřivené konektory. Následující tabulka ukazuje dostupné geometrie konektorů a počet bodů úpravy definovaných pro každou předvolbu.

| Konektor | Obrázek | Počet bodů úpravy |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Počet a význam bodů úpravy jsou součástí vybrané předvolby konektoru. Nepředpokládejte, že dva různé typy konektorů zobrazují stejný uspořádání kolekce.

## **Propojit dva tvary**

K přidání konektoru použijte [ShapeCollection.addConnector](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addConnector) a k připojení jeho konců použijte [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connector/#setStartShapeConnectedTo) a [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connector/#setEndShapeConnectedTo). Po připojení obou konců [Connector.reroute](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connector/#reroute) vybere nejkratší cestu mezi tvary.

Následující příklad spojuje elipsu a obdélník pomocí ohnutého konektoru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Upozornění" %}}
Volání [reroute](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connector/#reroute) může změnit hodnoty [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) a [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Přidělte konkrétní místa připojení po přesměrování, pokud tato místa musí zůstat pevná.
{{% /alert %}}

## **Vybrat místo připojení**

Každý připojitelný tvar udává počet svých míst přes [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getConnectionSiteCount). Ověřte preferovaný nulový index místa před jeho přiřazením ke konci konektoru; počet míst se liší podle geometrie tvaru.

Následující příklad připojuje konektor k určitému místu na elipse, pokud toto místo existuje:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Upravit bod konektoru**

Konektory s body úpravy je zpřístupňují přes [GeometryShape.getAdjustments](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/#getAdjustments). Prozkoumejte každý [AdjustValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/) a před jeho změnou pomocí [setRawValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setRawValue) ověřte jeho hodnotu [getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getType). Obecná pravidla pro identifikaci přednastavených úprav tvaru jsou popsána v [Shape Manipulation](/slides/cs/python-java/shape-manipulations/).

Počet, pořadí, význam a platný rozsah hodnot úprav konektoru závisí na předvolbě konektoru. Typ úpravy je jen pro čtení, zatímco hodnota úpravy je zapisovatelná. Metoda pro čtení [getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getName) poskytuje další identifikaci, když konektor obsahuje více úprav stejného sémantického typu.

### **Obejít překážku**

V následujícím uspořádání prochází [BentConnector5](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#BentConnector5) mezi dvěma tvary třetí tvar:

![connector-obstruction](connector-obstruction.png)

Tento kód vytvoří překážkou omezený konektor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Posunutí svislého ohybu změní trasu tak, že konektor obchází překážku:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Místo předpokladu, že index v kolekci `1` vždy představuje svislý ohyb, tento příklad hledá [ConnectorBendPositionY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) a mění jej jen v případě, že je přítomen očekávaný sémantický typ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[BentConnector5](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#BentConnector5) má dvě úpravy [ConnectorBendPositionX](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) a jednu [ConnectorBendPositionY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Pokud se požadovaný typ vyskytuje vícekrát, prozkoumejte [getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getName) a známou geometrii dané předvolby před výběrem. Pokud úprava vrací [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#Custom), považujte její význam a rozsah za specifické pro předvolbu a neměňte ji, dokud není tento kontrakt znám.

## **Relace hodnot úprav k geometrii konektoru**

Pro ohnuté konektory lze hodnoty úprav použít k odhadu polohy jednotlivých segmentů. Tyto výpočty jsou specifické pro předvolbu konektoru:

- [BentConnector4](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#BentConnector4) obvykle expose jednu úpravu [ConnectorBendPositionX](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) a jednu [ConnectorBendPositionY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- Pro tyto pozice ohybu dělením hodnoty vrácené metodou [getRawValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getRawValue) číslem `100000.0` získáte zlomek šířky nebo výšky rámce konektoru, jak je ukázáno v příkladech níže.
- Rámec konektoru může být otočen nebo převrácen, takže souřadnice rámce je třeba před porovnáním se souřadnicemi snímku transformovat.

Následující příklady používají [getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getType) k identifikaci úprav. Nepoužívají indexy kolekce jako přenositelné identifikátory.

### **Neotočený konektor**

Počáteční uspořádání obsahuje dva textové tvary spojené [BentConnector4](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Tento příklad zkoumá konektor a získává jeho horizontální a vertikální úpravy ohybu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Pro změnu obou ohybů najděte každý očekávaný typ a upravte hodnoty až po nalezení obou:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledkem je konektor, jehož horizontální a vertikální segmenty se posunuly:

![connector-adjusted-1](connector-adjusted-1.png)

Jakmile jsou známé sémantické typy, lze jejich hodnoty převést na souřadnice rámce konektoru. Tento příklad nakreslí tenký obdélník přes vertikální segment řízený dvěma ohyby:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vodicí tvar označuje vypočtený segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Otočený nebo převrácený konektor**

Když je stejná geometie konektoru orientována svisle, hodnoty [Shape.getFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeframe/#getFlipH) a [ShapeFrame.getFlipV](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeframe/#getFlipV) ovlivňují převod souřadnic rámce konektoru na souřadnice snímku.

Tento příklad vytvoří a upraví svisle orientovaný konektor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Upravený konektor se zobrazuje svisle mezi tvary:

![connector-adjusted-3](connector-adjusted-3.png)

Pro libovolný úhel otáčení `alpha` otočte bod rámce konektoru `(x, y)` kolem středu rámce `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Následující kód řeší 90‑stupňovou orientaci použité v tomto příkladu a nakreslí červený vodicí prvek přes odpovídající segment konektoru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Červený vodicí prvek označuje vypočtený segment po transformaci souřadnic:

![connector-adjusted-4](connector-adjusted-4.png)

Tyto vzorce popisují předvolby použité v příkladech, nikoli univerzální model konektoru. Ověřte typy úprav, orientaci rámce a rozsahy hodnot před aplikací stejných výpočtů na jinou předvolbu.

## **Najít úhel směru konektoru**

Směr přímého konektoru lze vypočítat z jeho šířky a výšky s ohledem na horizontální a vertikální převrácení. Následující příklad uvádí úhel ve směru hodinových ručiček od kladné horizontální osy ve souřadnicích snímku:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jak zjistím, zda se konektor může připojit k tvaru?**

Zkontrolujte hodnotu [getConnectionSiteCount](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getConnectionSiteCount) tvaru. Kladný počet znamená, že tvar nabízí místa připojení. Před přiřazením ověřte vybraný index místa.

**Mohu identifikovat úpravu konektoru podle jeho indexu v kolekci?**

Index má význam jen pro známou předvolbu konektoru a uspořádání kolekce. Před úpravou hodnoty zkontrolujte [AdjustValue.getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getType) a použijte [AdjustValue.getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getName) jako doplňující informaci, pokud se stejný sémantický typ vyskytuje vícekrát.

**Co se stane, když je připojený tvar smazán?**

Odpovídající konektorový konec se odpojí. Konektor zůstane na snímku a může být smazán, umístěn jako volná čára nebo připojen k jinému tvaru.

**Zůstávají vazby konektorů zachovány při kopírování snímku?**

Vazby jsou obecně zachovány, když jsou připojené tvary kopírovány se snímkem. Pokud je konektor zkopírován bez jednoho ze svých cílových tvarů, je nutné postižený konec připojit znovu.