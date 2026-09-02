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
- vyhledat tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat ID interop tvaru
- alternativní text tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- převrátit tvar
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak identifikovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary prezentace pomocí Aspose.Slides pro Python via .NET."
---
## **Přehled**

Aspose.Slides for Python via .NET představuje tvary na snímku jako uspořádanou [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/). Kolekce je jak místem, kde najdete a upravujete tvary, tak zdrojem jejich pořadí vrstvení: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar, pak ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Závěrečné sekce se věnují formátování na úrovni rozvržení, exportu do SVG, zarovnávání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít jen operace, které váš pracovní postup vyžaduje.

## **Identifikace a vyhledávání tvarů**

Indexy v kolekci jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace vytvořena a udržována:

- [Shape.name](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/name/) je užitečný pro šablony řízené vývojáři a snadno se kontroluje v panelu výběru PowerPointu. Jména lze upravovat a nejsou zaručena jako jedinečná, proto si stanovte pojmenovací konvenci, pokud na nich kód závisí.
- [Shape.alternative_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/alternative_text/) je užitečný, když popis přístupnosti nebo autorovo označení již tvar identifikuje. Je viditelný pro uživatele, může být lokalizován nebo upraven pro přístupnost a není zaručeně jedinečný. Nepřevádějte tiše smysluplný text přístupnosti na databázový klíč.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/office_interop_shape_id/) je jen pro čtení a je jedinečný v rámci snímku; odpovídá ID tvaru používanému v PowerPoint interop. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz po celou životnost tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související vlastnost [Shape.unique_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/unique_id/) má rozsah prezentace, ale je určena pro doplňky a může být přeřazena. Neměla by být považována za trvalý externí klíč. Pokud je dlouhodobá identita zásadní, uložte mapování v aplikačních datech a ověřte, že očekávaný tvar stále existuje.

Následující příklad hledá podle `name` s přesnou shodou a uvádí ID interopu v rozsahu snímku. Když šablona neobsahuje očekávaný tvar, kód vypíše tento výsledek místo pokračování s nesprávným objektem.

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

Když je operace specifická pro určitý typ tvaru, zkontrolujte typ před použitím typově specifických členů. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).

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

## **Úprava kolekce tvarů**

Metody přidání, klonování, odebrání a změny pořadí operují přímo na kolekci. Pokud operace změní počet nebo pořadí tvarů, nepokračujte v používání indexů zachycených před touto operací.

### **Klonování tvaru**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_clone/) vytvoří nezávislou kopii a připojí ji k cílové kolekci. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/insert_clone/) také vytvoří kopii, ale umístí ji na zadaný index z‑order. Přetížení, která přijímají souřadnice, přesunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit.

Příklad vytvoří cílový snímek, klonuje označený obdélník dopředu a vloží druhý klon dozadu. Změny v libovolném klonu nemění původní tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho jména a alternativního textu. Při nutnosti jedinečnosti přiřaďte novým logickým identifikátorům klonu jiné hodnoty. Prostředky používané složitými tvary jsou spravovány prezentací, ale klon zůstává novou položkou kolekce s novou identitou tvaru.

### **Odebrání tvarů**

[ShapeCollection.remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/remove/) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během indexované iterace procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným jménem. Čte `slide.shapes[index]`, nikoli pevnou položku kolekce, a nepoužívá zbytečně přetypování tvaru.

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

Po odebrání se počet tvarů a indexy následných tvarů změní. Odkazy na nepodjaté tvary zůstávají spolehlivější než uložené indexy. Uvažujte také o konektorech, animacích a dalších prvcích prezentace, které mohou odkazovat na odebraný objekt; odebrání viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavení [Shape.hidden](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/hidden/) na `True` ponechá tvar v kolekci, ale zabrání jeho zobrazení v normálním režimu prezentace. Jeho index, formátování i obsah zůstanou kódu dostupné, takže skrytí je vhodné pro volitelné elementy, které mohou být později obnoveny.

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

Skrytí není smazání ani zabezpečení. Objekt může stále být objeven a odkrýván uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změna Z‑orderu**

Překrývající se tvary jsou vykreslovány v pořadí kolekce. [ShapeCollection.reorder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/reorder/) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `len(slide.shapes) - 1` je přední.

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

Obdélník je vytvořen jako první a zpočátku leží za elipsou. Přesunutí na poslední index jej umístí dopředu. Dokončete nastavení z‑orderu až po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky kolekce a mohou zamýšlený zásobník změnit.

## **Prohlížení tvarů na rozvrhových snímcích**

Normální snímky, rozvrhové snímky a hlavní snímky mají oddělené kolekce tvarů. Tvar v rozvrhové kolekci není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte rozvrhové tvary, pokud potřebujete pochopit nebo změnit formátování poskytnuté rozvržením.

Následující příklad čte u každého tvaru v rozvrhu [Shape.fill_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/fill_format/) a [Shape.line_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/line_format/) aniž by předpokládal, že každý tvar je `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Úprava rozvržení může ovlivnit více snímků, které ho používají. Před změnou tvaru v rozvržení zjistěte, zda normální snímek dědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek, který dané rozvržení používá.

## **Export tvaru do SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/write_as_svg/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje jen tvar, ne celé pozadí snímku ani sousední tvary.

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

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na prostředcích jako jsou fonty a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít.

## **Zarovnání tvarů**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/align_shapes/) má přetížení, která zarovnají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim distribuce. Nastavte `align_to_slide` na `True`, chcete-li použít okraje snímku; nastavte na `False`, chcete-li zarovnat vybrané tvary vůči sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Jejich aktuální indexy jsou vyřešeny těsně před zarovnáním.

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

Zarovnání mění pozice, ne z‑order. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální distribuce potřebuje dostatek tvarů k definování mezery. Při úpravě kolekce před voláním metody přepočítejte indexy.

## **Převrácení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides.shapeframe/) ukládá pozici, velikost, horizontální a vertikální nastavení převrácení a rotaci. Její hodnoty `flip_h` a `flip_v` používají [NullableBool](https://reference.aspose.com/slides/cs/python-net/aspose.slides/nullablebool/): `TRUE` zapne převrácení, `FALSE` jej vypne a `NOT_DEFINED` zachová nedefinovaný nebo výchozí stav.

Vstupní prezentace níže obsahuje jeden netransformovaný tvar.

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

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu nezmění. Upřednostněte ověřené konvence `name` nebo `alternative_text` pro šablony vytvořené autory, případně `office_interop_shape_id` pro práci v rozsahu snímku.

**Odstraňuje skrytí tvaru jeho položku ze z‑orderu?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo opět zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`add_clone` připojí klon na konec kolekce, což je přední část z‑orderu. Použijte `insert_clone` pro výběr počátečního indexu nebo `reorder` po přidání všech tvarů.