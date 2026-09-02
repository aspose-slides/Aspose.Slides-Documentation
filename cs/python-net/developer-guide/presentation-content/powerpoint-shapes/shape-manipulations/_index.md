---
title: Správa tvarů prezentace v Pythonu
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/python-net/shape-manipulations/
keywords:
- tvar PowerPoint
- tvar prezentace
- tvar na snímku
- najít tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat interop ID tvaru
- alternativní text tvaru
- bod úpravy tvaru
- přednastavená úprava tvaru
- geometrie tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- převrátit tvar
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak identifikovat, upravovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary prezentace pomocí Aspose.Slides pro Python prostřednictvím .NET."
---
## **Přehled**

Aspose.Slides pro Python prostřednictvím .NET představuje tvary na snímku jako uspořádanou [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/). Kolekce je jak místem, kde najdete a upravujete tvary, tak zdrojem jejich pořadí vrstvení: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené body úprav tvaru, poté ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Závěrečné sekce pokrývají formátování na úrovni rozvržení, export do SVG, zarovnání a nastavení převrácení. Každý příklad je samostatný, takže můžete použít jen operace, které váš pracovní postup vyžaduje.

## **Identifikace a vyhledání tvarů**

Indexy kolekce jsou pohodlné při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Vyberte identifikátor podle toho, jak je prezentace vytvořena a udržována:

- [Shape.name](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/name/) je užitečný pro šablony řízené vývojářem a snadno se kontroluje v panelu výběru PowerPointu. Jména lze upravovat a nejsou zaručena jako jedinečná, takže si stanovte pojmenovací konvenci, pokud na nich kód závisí.
- [Shape.alternative_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/alternative_text/) je užitečný, když již popis přístupnosti nebo autorovo označení identifikuje tvar. Je viditelný uživatelům, může být lokalizován nebo přepsán pro přístupnost a není zaručeno jako jedinečný. Nepřevádějte tiše významný text přístupnosti na klíč databáze.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/office_interop_shape_id/) je jen pro čtení identifikátor, který je jedinečný v rámci snímku a odpovídá ID tvaru používanému PowerPoint interop. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačnou referenci během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související vlastnost [Shape.unique_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/unique_id/) má rozsah prezentace, ale je určena pro doplňky a může být přidělena znovu. Neměla by být považována za trvalý externí klíč. Pokud je dlouhodobá identita podstatná, uložte mapování v aplikačních datech a ověřte, že očekávaný tvar stále existuje.

Následující příklad hledá podle `name` s přesnou shodou a hlásí interop ID v rámci snímku. Když šablona neobsahuje očekávaný tvar, kód nahlásí tento výsledek místo pokračování s nesprávným objektem.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Když je operace specifická pro typ tvaru, zkontrolujte typ před použitím typových členů. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Identifikace a úprava přednastavených úprav tvaru**

Tvarové geometrie s přednastavením mohou odhalit body úprav, které řídí např. velikost rohu, proporce šipky nebo úhly oblouku. Přistupujte k nim přes kolekci jen pro čtení [GeometryShape.adjustments](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/adjustments/). Kolekce samotná je poskytována tvarem, ale každý [AdjustValue](https://reference.aspose.com/slides/cs/python-net/aspose.slides/adjustvalue/) obsahuje hodnotu, kterou lze změnit.

Nespoléhejte se jen na pevný index kolekce. Procházejte úpravy a kontrolujte jen pro čtení vlastnost [AdjustValue.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/adjustvalue/type/), jejíž hodnota [ShapeAdjustmentType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapeadjustmenttype/) popisuje, co úprava ovlivňuje. Jen pro čtení vlastnost [AdjustValue.name](https://reference.aspose.com/slides/cs/python-net/aspose.slides/adjustvalue/name/) poskytuje doplňující identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte hodnotovou vlastnost, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota ke změně |
|---|---|---|
| `CORNER_SIZE` | Velikost zaoblených rohů | [raw_value](https://reference.aspose.com/slides/cs/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Tloušťka ocasu šipky | `raw_value` |
| `ARROWHEAD_LENGTH` | Délka špičky šipky | `raw_value` |
| `ARROWHEAD_WIDTH` | Šířka špičky šipky | `raw_value` |
| `START_ANGLE` | Počáteční úhel výseče nebo oblouku | [angle_value](https://reference.aspose.com/slides/cs/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Koncový úhel výseče nebo oblouku | `angle_value` |

`type` a `name` nelze přiřadit. `raw_value` je jen pro čtení / zápis celé číslo v jednotkách původní geometrie, zatímco `angle_value` je jen pro čtení / zápis úhel ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na přednastavení [GeometryShape.shape_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/shape_type/). Hodnota, která je platná pro jedno přednastavení, může být neplatná nebo mít jiný účinek pro jiné.

Když je `type` `ShapeAdjustmentType.CUSTOM`, API nepozná standardní sémantický význam. Prohlédněte `name`, typ přednastavení a existující hodnotu a ponechte úpravu beze změny, pokud není znám očekávaný význam a rozsah. I pro rozpoznané typy zkontrolujte, zda se stejný typ neobjevuje vícekrát, než vyberete hodnotu. Článek [Connector](/slides/cs/python-net/connector/) ukazuje tuto situaci s úpravami zakřivení konektoru.

Následující úplný příklad vytváří výchozí a upravené verze tří přednastavených tvarů. Prochází každou úpravu, hlásí její `name` a `type`, mění hodnoty související s velikostí pomocí `raw_value`, mění úhly pomocí `angle_value` a ukládá výsledek. Levý sloupec zachovává výchozí geometrii; pravý sloupec ukazuje upravený zaoblený obdélník, čtyřcestnou šipku a výseč.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte záhlaví pro sloupce výchozího a upraveného tvaru.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Kontrola sémantického typu před změnou hodnoty činí kód explicitním v úmyslu a zabraňuje předpokladu, že konkrétní index kolekce má stejný význam napříč různými přednastavenými tvary.

## **Úprava kolekce tvarů**

Metody přidání, klonování, odebrání a změny pořadí fungují na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, nepokračujte v používání indexů zachycených před touto operací.

### **Klonovat tvar**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_clone/) vytvoří samostatnou kopii a připojí ji k cílové kolekci. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/insert_clone/) také vytvoří kopii, ale umístí ji na zadaný z‑order index. Přetížení, která přijímají souřadnice, přesunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také měnit.

Příklad vytvoří cílový snímek, klonuje označený obdélník do popředí a vloží druhý klon do pozadí. Změny v jednom klonu nemění zdrojový tvar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Klonování kopíruje obsah a formátování tvaru, včetně jeho názvu a alternativního textu. Přidělte novým klonům logické identifikátory, pokud musí být tyto hodnoty jedinečné. Zdroje použité složitými tvary spravuje prezentace, ale klon zůstává novou položkou kolekce s novou identitou tvaru.

### **Odstranit tvary**

[ShapeCollection.remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/remove/) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během indexované iterace procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným jménem. Čte `slide.shapes[index]`, ne pevný prvek kolekce, a nepotřebně nepřetypovává tvar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Po odstranění se počet tvarů a indexy následných tvarů změní. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Zvažte také konektory, animace a další prvky prezentace, které mohou odkazovat na odstraněný objekt; odstranění viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrýt tvar**

Nastavení [Shape.hidden](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/hidden/) na `True` ponechává tvar v kolekci, ale zabraňuje jeho zobrazení v běžném režimu prezentace. Jeho index, formátování i obsah zůstávají dostupné kódu, takže skrývání je vhodné pro volitelné prvky, které mohou být později obnoveny.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Skrývání není smazání ani zabezpečení. Objekt může být stále objeven a odskrýt uživatelem nebo kódem a nadále patří do souboru prezentace.

### **Změnit Z‑order**

Překrývající se tvary jsou vykreslovány podle pořadí v kolekci. [ShapeCollection.reorder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/reorder/) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `len(slide.shapes) - 1` je přední.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Obdélník je vytvořen první a zpočátku leží za elipsou. Přesunutím na konečný index se dostane dopředu. Dokončete z‑order po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky kolekce a mohou zamýšlený zásobník změnit.

## **Prozkoumat tvary na rozvržených snímcích**

Normální snímky, snímky rozvržení a hlavní snímky mají oddělené kolekce tvarů. Tvar v kolekci rozvržení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prozkoumejte tvary rozvržení, když potřebujete pochopit nebo změnit formátování poskytnuté rozvržením.

Následující příklad čte pro každý tvar rozvržení [Shape.fill_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/fill_format/) a [Shape.line_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/line_format/) aniž by předpokládal, že každý tvar je `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Úprava rozvržení může ovlivnit více snímků, které jej používají. Před změnou tvaru rozvržení určete, zda normální snímek dědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek používající toto rozvržení.

## **Exportovat tvar do SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/write_as_svg/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje tvar, nikoli celé pozadí snímku nebo sousední tvary.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na zdrojích, jako jsou písma a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít.

## **Zarovnat tvary**

[Přetížení SlideUtil.align_shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/align_shapes/) zarovnává buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim rozdělení. Nastavte `align_to_slide` na `True` pro použití okrajů snímku; nastavte jej na `False` pro zarovnání vybraných tvarů vůči sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Jejich aktuální indexy jsou vyhodnoceny těsně před zarovnáním.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Zarovnání mění pozice, nikoli z‑order. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální rozdělení potřebuje dostatek tvarů pro definování rozestupu. Přepočítejte indexy, pokud před voláním metody měníte kolekci.

## **Převrátit tvar**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapeframe/) ukládá pozici, velikost, nastavení horizontálního a vertikálního převrácení a rotaci. Její hodnoty `flip_h` a `flip_v` používají [NullableBool](https://reference.aspose.com/slides/cs/python-net/aspose.slides/nullablebool/): `TRUE` zapíná převrácení, `FALSE` jej vypíná a `NOT_DEFINED` zachovává nedefinovaný nebo výchozí stav.

Vstupní prezentace níže obsahuje jeden nepřevrácený tvar.

![The shape before flipping](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje jen dvě nastavení převrácení. To je důležité, protože přiřazení nového [Shape.frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/frame/) nahrazuje celý rámec.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

Uložený tvar je zrcadlen horizontálně i vertikálně při zachování pozice, velikosti a rotace.

![The shape after flipping](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, když se kolekce před použitím indexu nezmění. Upřednostněte ověřený `name` nebo konvenci `alternative_text` pro vytvořené šablony, nebo `office_interop_shape_id` pro práci s interopem na úrovni snímku.

**Odstraňuje skrytí tvaru jeho pozici v z‑order?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, editovat nebo opět zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`add_clone` přidá klon na konec kolekce, což je přední část z‑orderu. Použijte `insert_clone` pro volbu počátečního indexu nebo `reorder` po přidání všech tvarů.

**Mohu použít pevný index pro identifikaci přednastavené úpravy tvaru?**

Pouze po ověření přesného přednastavení a rozvržení kolekce. Upřednostněte iteraci přes `GeometryShape.adjustments` a kontrolu `AdjustValue.type`; použijte `AdjustValue.name` jako doplňující informaci, když se stejný sémantický typ objeví vícekrát.