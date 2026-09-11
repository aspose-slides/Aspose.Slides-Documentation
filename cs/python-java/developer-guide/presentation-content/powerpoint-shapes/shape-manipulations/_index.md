---
title: Spravovat tvary v prezentaci v Pythonu přes Java
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/python-java/shape-manipulations/
keywords:
- tvar PowerPoint
- tvar prezentace
- tvar na snímku
- najít tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat ID interop tvaru
- alternativní text tvaru
- bod úpravy tvaru
- přednastavená úprava tvaru
- geometrie tvaru
- formáty rozložení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- převrátit tvar
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak identifikovat, upravovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary v prezentaci pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Aspose.Slides pro Python přes Java představuje tvary na snímku jako uspořádanou [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/). Kolekce je zároveň místem, kde najdete a upravujete tvary, a zdrojem jejich pořadí překrývání: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené body úprav tvaru, poté ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Poslední sekce pokrývají formátování na úrovni rozložení, export do SVG, zarovnání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít jen operace, které váš pracovní postup vyžaduje.

## **Identifikace a vyhledání tvarů**

Indexy v kolekci jsou pohodlné při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle způsobu, jakým je prezentace vytvářena a udržována:

- [Name](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getName) je užitečný pro šablony řízené vývojáři a snadno se kontroluje v podokně Výběr v PowerPointu. Jména lze upravovat a nejsou garantována jako jedinečná, takže pokud na nich kód závisí, stanovte konvenci pojmenování.
- [AlternativeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getAlternativeText) je užitečný, když popis přístupnosti nebo autorově štítek již tvar identifikuje. Je viditelný uživatelům, může být lokalizován nebo přepsán pro přístupnost a není garantován jako jedinečný. Nepřepisujte tichým způsobem smysluplný text přístupnosti jako klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getOfficeInteropShapeId) je jen pro čtení identifikátor, který je jedinečný v rámci snímku a odpovídá ID tvaru používanému interopem PowerPointu. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá vlastní ID.

Související metoda [getUniqueId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getUniqueId) vrací identifikátor s rozsahem celé prezentace, ale tento identifikátor je určen pro doplňky a může být přidělen znovu. Neměl by být považován za trvalý externí klíč. Pokud je dlouhodobá identita podstatná, uložte mapování v aplikačních datech a ověřte, že očekávaný tvar ještě existuje.

Následující příklad hledá podle jména s přesnou shodou a vypisuje interopní ID v rámci snímku. Když šablona neobsahuje očekávaný tvar, kód vypíše tento výsledek místo pokračování se špatným objektem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Když je operace specifická pro typ tvaru, před použitím typově specifických členů zkontrolujte typ. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Identifikace a úprava přednastavených úprav tvaru**

Tvary s přednastavenou geometrií mohou odhalovat body úprav, které řídí například velikost rohu, proporce šipky nebo úhly oblouku. Přistupujte k nim přes kolekci jen pro čtení [GeometryShape.getAdjustments](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/#getAdjustments). Kolekce je poskytována tvarem, ale každý [AdjustValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/) obsahuje hodnotu, kterou lze změnit.

Nespoléhejte se jen na pevný index kolekce. Projděte úpravy a prozkoumejte metodu jen pro čtení [getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getType), jejíž hodnota [ShapeAdjustmentType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/) popisuje, co úprava ovládá. Metoda jen pro čtení [getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getName) poskytuje doplňující identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte metodu hodnoty, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota ke změně |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Velikost zaoblených rohů | [setRawValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Tloušťka ocasu šipky | [setRawValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Délka hrotu šipky | [setRawValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Šířka hrotu šipky | [setRawValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Počáteční úhel výseče nebo oblouku | [setAngleValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Koncový úhel výseče nebo oblouku | [setAngleValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getType) a [getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getName) vrací jen pro čtení informace. [getRawValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getRawValue) a [setRawValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setRawValue) pracují s celým číslem v nativních jednotkách geometrie přednastavení, zatímco [getAngleValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getAngleValue) a [setAngleValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setAngleValue) pracují s úhlem ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na přednastaveném [ShapeType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/#getShapeType). Hodnota platná pro jedno přednastavení může být neplatná nebo mít jiný účinek pro jiné.

Když [getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getType) vrací [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeadjustmenttype/#Custom), API nerozpozná standardní sémantický význam. Prohlédněte si [getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getName), typ přednastavení a existující hodnotu a ponechte úpravu beze změny, pokud neznáte očekávaný význam a rozsah. I pro rozpoznané typy zkontrolujte, zda se stejný typ nevyskytuje vícekrát, než vyberete hodnotu. Článek [Connector](/slides/cs/python-java/connector/) ukazuje tuto situaci u úprav ohybu konektoru.

Následující kompletní příklad vytváří výchozí a upravené verze tří přednastavených tvarů. Prochází každou úpravu, vypisuje její název a typ, mění hodnoty související s velikostí pomocí [setRawValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setRawValue), mění úhly pomocí [setAngleValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#setAngleValue) a ukládá výsledek. Levý sloupec zachovává výchozí geometrie; pravý sloupec ukazuje upravený zaoblený obdélník, čtyřcestnou šipku a výseč.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidá záhlaví pro výchozí a upravené sloupce tvarů.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kontrola sémantického typu před změnou hodnoty dělá kód explicitním ohledně záměru a zabraňuje předpokladu, že konkrétní index kolekce má stejný význam napříč různými přednastavenými tvary.

## **Úprava kolekce tvarů**

Metody pro přidání, klonování, odstranění a změnu pořadí působí na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, neodkazujte se nadále na indexy zachycené před touto operací.

### **Klonovat tvar**

[addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addClone) vytvoří nezávislou kopii a připojí ji ke cílové kolekci. [insertClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#insertClone) také vytvoří kopii, ale umístí ji na zadaný index z‑řádu. Přetížení, která přijímají souřadnice, přesunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit.

Příklad vytváří cílový snímek, klonuje označený obdélník dopředu a vloží druhý klon dozadu. Změny v libovolném klonu neovlivní zdrojový tvar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Klonování kopíruje obsah a formátování tvaru, včetně jeho jména a alternativního textu. Přidělte novým logickým identifikátorům klon, pokud musí být tyto hodnoty jedinečné. Zdroje používané komplexními tvary jsou spravovány prezentací, ale klon zůstává novou položkou v kolekci s novou identitou tvaru.

### **Odstranit tvary**

[remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#remove) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během indexované iterace procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným jménem. Čte tvar na aktuálním indexu, nikoli pevnou položku kolekce, a nepřetypovává tvar zbytečně.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Po odstranění se počet tvarů a indexy následných tvarů mění. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Zvažte také konektory, animace a další funkce prezentace, které mohou odkazovat na odebraný objekt; odstranění viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrýt tvar**

Nastavení [Hidden](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setHidden) na `True` ponechá tvar v kolekci, ale zabrání jeho zobrazení v normální prezentaci. Jeho index, formátování a obsah zůstávají dostupné kódu, takže skrývání je vhodné pro volitelné prvky, které mohou být později obnoveny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Skrývání není smazání ani zabezpečení. Objekt může být stále objeven a odkryt uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změnit Z‑pořadí**

Překrývající se tvary jsou vykreslovány v pořadí kolekce. [reorder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#reorder) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; kolekce [size](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#size) minus jedna je přední.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Obdélník je vytvořen jako první a zpočátku leží za elipsou. Přesunutí na poslední index jej postaví dopředu. Uzavřete Z‑pořadí po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky do kolekce a mohou změnit zamýšlený stack.

## **Prohlédnout tvary na rozložení snímků**

Normální snímky, rozložení a hlavní snímky mají oddělené kolekce tvarů. Tvar v kolekci rozložení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte rozložení, když potřebujete pochopit nebo změnit formátování poskytované rozložením.

Následující příklad čte pro každý tvar rozložení jeho [FillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getFillFormat) a [LineFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getLineFormat) aniž by předpokládal, že každý tvar je [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Úprava rozložení může ovlivnit více snímků, které jej používají. Před změnou tvaru v rozložení zjistěte, zda normální snímek dědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek, který toto rozložení používá.

## **Exportovat tvar do SVG**

Metoda `writeAsSvg` třídy [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje pouze tvar, nikoli celé pozadí snímku ani sousední tvary.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na zdrojích, jako jsou fonty a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít.

## **Zarovnat tvary**

Přetížení [SlideUtil.alignShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideutil/#alignShapes) zarovnává buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim distribuce. Nastavte `align_to_slide` na `True`, chcete‑li použít okraje snímku; nastavte na `False`, chcete‑li zarovnat vybrané tvary vůči sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Vrácené odkazy na tvary jsou převedeny na jejich aktuální indexy těsně před zarovnáním.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zarovnání mění pozice, nikoli Z‑pořadí. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco vodorovná nebo svislá distribuce potřebuje dostatek tvarů k definování mezery. Při úpravě kolekce před voláním metody přepočítejte indexy.

## **Převrátit tvar**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeframe/) ukládá pozici, velikost, vodorovné a svislé nastavení převrácení a rotaci. Její hodnoty [getFlipH](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeframe/#getFlipH) a [getFlipV](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeframe/#getFlipV) používají [NullableBool](https://reference.aspose.com/slides/cs/python-java/aspose.slides/nullablebool/): `True` povolí převrácení, `False` jej zakáže a `NotDefined` zachová nedefinovaný/defaultní stav.

Vstupní prezentace níže obsahuje jeden nepřevrácený tvar.

![The shape before flipping](shape_to_be_flipped.png)

Příklad zachová všechny ostatní hodnoty rámce a nahradí pouze dvě nastavení převrácení. To je důležité, protože přiřazení nového [Frame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setFrame) nahradí celý rámec.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Uložený tvar je zrcadlen vodorovně i svisle, přičemž si zachovává svou pozici, velikost a rotaci.

![The shape after flipping](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce nezmění před použitím indexu. Upřednostněte ověřený konvent [Name](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getName) nebo [AlternativeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getAlternativeText) pro šablony vytvářené autory, nebo [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getOfficeInteropShapeId) pro práci s interopem na úrovni snímku.

**Odstraňuje skrytí tvaru jeho Z‑pořadí?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, přeskupit, upravit nebo znovu zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

[addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addClone) přidá klon na konec kolekce, což je přední část Z‑pořadí. Použijte [insertClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#insertClone) k volbě počátečního indexu nebo [reorder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#reorder) po přidání všech tvarů.

**Mohu použít pevný index k identifikaci úpravy přednastaveného tvaru?**

Pouze po validaci konkrétního přednastavení a rozložení kolekce. Upřednostněte iteraci přes [GeometryShape.getAdjustments](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/#getAdjustments) a kontrolu [AdjustValue.getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getType); použijte [AdjustValue.getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/adjustvalue/#getName) jako doplňující informaci, když se stejný sémantický typ objeví vícekrát.