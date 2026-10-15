---
title: Správa textových odstavců PowerPointu v Pythonu
linktitle: Spravovat odstavec
type: docs
weight: 40
url: /cs/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- zavěšené odsazení
- odrážka odstavce
- číslovaný seznam
- odrážkový seznam
- vlastnosti odstavce
- importovat HTML
- text do HTML
- odstavec do HTML
- odstavec do obrázku
- text do obrázku
- exportovat odstavec
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Python via .NET vytvářet a formátovat odstavce, části, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců."
---
## **Přehled**

Aspose.Slides pro Python via .NET představuje text jako hierarchii textových rámců, odstavců a částí:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) představuje běh textu v odstavci. Každá část může mít vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými fonty, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytváření a formátování odstavců**

Vytvářejte odstavce v textovém rámci tvaru a použijte části k formátování jednotlivých běhů textu. Tato sekce ukazuje, jak kombinovat více částí v každém odstavci a použít různé barvy, velikosti fontů a styly.

### **Vytvoření odstavců s více částmi**

Následující příklad v Pythonu vytváří tři odstavce, z nichž každý obsahuje tři běhy textu ve své kolekci [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). Znovu použije výchozí odstavec a jeho prázdnou část, pak přidá zbývající odstavce a části. Formátování se aplikuje přes [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): první část v každém odstavci je červená, tučná a 15 bodů; druhá je modrá, kurzíva a 18 bodů. Třetí část si ponechává výchozí formátování:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Vytvoření odrážkových a číslovaných seznamů**

Organizujte text odstavců do seznamů se symboly, čísly nebo vlastními obrázky. Příklady v této sekci pokrývají formátování odrážek, víceúrovňové seznamy a vlastní počáteční čísla.

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují prohlížení souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Tento příklad v Pythonu přidá symbolickou odrážku a číslovanou položku do stejného textového rámce. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) vybírá typ odrážky, zatímco [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) poskytuje symbol a [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) vybírá styl číslování. Obě položky používají černé odrážky s výškou 100 % a odsazením odstavce 25 bodů:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Použití obrázkových odrážek**

Obrázkové odrážky vám umožňují použít vlastní obrázek místo symbolu nebo čísla.

Příklad vyžaduje soubor `bullets.png` v pracovním adresáři. Tento příklad v Pythonu přidá obrázek do kolekce obrázků prezentace jako [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) a použije jej jako odrážku odstavce. Nastaví [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) na použití obrázkové odrážky a přiřadí obrázek pomocí [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) je nastaven na 100 % pro velikost odrážky relativně k textu odstavce:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Vytvoření víceúrovňového seznamu**

Nastavte [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) pro umístění odstavců na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

Tento příklad v Pythonu přiřadí hodnoty [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) od 0 do 3 čtyřem odstavcům, čímž vytvoří hierarchii v jednom textovém rámci. Každý odstavec používá symbolickou odrážku, přičemž [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) se střídá mezi kulatou odrážkou a pomlčkou pro rozlišení sousedních úrovní:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Zahájení číslovaných položek seznamu na vlastní hodnoty**

Použijte [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) pro nastavení počátečního čísla zobrazovaného pro číslovaný odstavec.

Tento příklad v Pythonu nastaví [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) na použití číslování pro tři odstavce a přiřadí hodnoty [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 2, 3 a 7. Počáteční hodnota je konfigurována samostatně pro každý odstavec, což umožňuje vynechat čísla:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Řízení rozvržení odstavce a koncových vlastností**

Upravte okraje a odsazení odstavců k řízení polohy první řádky a zalomených řádků. Můžete také formátovat koncový znak odstavce odděleně od viditelných částí textu.

### **Nastavení odsazení první řádky**

Použijte vlastnost [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) k řízení odsazení první řádky odstavce. Tato vlastnost posunuje pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posouvá první řádek doprava, zatímco zbylé řádky zůstávají zarovnané k tělu odstavce.

Použijte [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) když potřebujete posunout celý odstavec. Použijte [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) když potřebujete posunout pouze první řádek.

Následující příklad dává třem odstavcům stejný [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 20 bodů a hodnoty [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 0, 20 a 40 bodů. První řádky začínají na postupně větších odsazeních, zatímco zalomené řádky zachovávají stejný levý okraj:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

### **Nastavení zavěšeného odsazení**

Zavěšené odsazení je rozvržení odstavce, kde první řádek začíná vlevo od zbývajících řádků. V Aspose.Slides vytvoříte tento efekt pomocí vlastnosti [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Nastavte `indent` na zápornou hodnotu, aby se první řádek posunul doleva vzhledem k tělu odstavce.

V praxi [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) určuje levou pozici těla odstavce a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření zavěšeného odsazení nastavte kladnou hodnotu `margin_left` a zápornou hodnotu `indent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde musí být zalomené řádky zarovnány pod tělo odstavce místo pod první znak první řádky.

Následující příklad v Pythonu spojuje hodnoty [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 40 a 60 bodů s hodnotami [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) -20 a -30 bodů. V každém odstavci první řádek začíná vlevo od zalomených řádků; druhý odstavec má hlubší zavěšené odsazení:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Zavěšené odsazení odstavců](hanging_indent.png)

### **Nastavení koncových vlastností běhu odstavce**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) řídí formátování koncového znaku odstavce. Příklad načte `Test.pptx`, který musí obsahovat alespoň jeden snímek, a vytvoří [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) s [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) nastaveným na 48 bodů a [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) nastaveným na Times New Roman. Tento formát přiřadí koncovému znaku druhého odstavce, přičemž viditelné části textu zůstávají nezměněny:

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Počítání vykreslených řádků**

Pro pravidla odstavců, která ovlivňují automatické zalamování a interpunkci na konci řádku, viz [Řízení zalamování řádků](/slides/cs/python-net/text-formatting/#control-line-breaking) a [Řízení zavěšené interpunkce](/slides/cs/python-net/text-formatting/#control-hanging-punctuation).

Použijte [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) k počítání řádků obsazených odstavcem po rozložení textu, včetně automatického zalamování. To je užitečné při kontrole délky textu a rozložení v šablonách prezentací.

Odstavec je jedna položka v [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) a může zabírat několik vykreslených řádků. Výslovný zalomení řádku v odstavci vynutí nový řádek, aniž by vytvořil další odstavec. Automatické zalamování vytváří řádky na základě dostupné šířky, aniž by do textu vkládalo výslovné znaky konce řádku. Počítání odstavců nebo znaků konce řádku tedy nedává počet vykreslených řádků.

Následující příklad vytvoří tvar s textem, spočítá jeho řádky, zúží tvar a pak nahradí text kratším řetězcem. Příklad povolí [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) a zakáže [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/), aby šířka tvaru řídila zalamování bez automatického zmenšování textu nebo změny velikosti tvaru. Každé měření používá [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Rozměry tvaru jsou v bodech. Nakonec příklad přidá další odstavec a sečte počty řádků napříč textovým rámcem.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

S tímto textem a těmito rozměry zúžení tvaru zvyšuje počet řádků, zatímco nahrazení textu krátkým řetězcem jej snižuje. Přesné počty se mohou lišit podle dostupnosti a substituce fontů, velikosti fontu, okrajů, odsazení, zalamování a nastavení automatického přizpůsobení. Použijte fonty a nastavení rozvržení zamýšlené pro cílové prostředí při kontrole šablony.

Počet řádků sám o sobě neurčuje, zda text přesahuje svůj kontejner. Důležitá je také dostupná výška, výšky řádků, mezery mezi odstavci a řádky a chování automatického přizpůsobení; i jediný řádek může překročit dostupnou šířku, pokud je zalamování zakázáno.

## **Import a export obsahu odstavců**

Použijte HTML k vložení textu do prezentace nebo k exportu existujících odstavců pro použití mimo ni. Tato sekce také ukazuje, jak vykreslovat jednotlivé odstavce jako obrázky, včetně odstavců v buňkách tabulky.

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) pro převod HTML značek na odstavce a části v textovém rámci.

Tento příklad v Pythonu načte HTML ze souboru `file.html` v pracovním adresáři a předá značky metodě [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Vyčistí výchozí odstavec textového rámce, aby rámec obsahoval pouze importovaný obsah. Obdélníkový tvar ponechává 10bodový okraj na každé straně snímku:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Export textu odstavce do HTML**

Použijte [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) k exportu vybraného rozsahu odstavců jako HTML. Při opětovném použití textu prezentace na webu můžete chtít zachovat lokální zvýraznění bez přenášení fontu, velikosti nebo stylů textového pole prezentace. Nastavte [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) pro řízení, jak daleko exportér sleduje dědičnost formátování.

Stáhněte [vzorkovou prezentaci](text-inheritance.pptx) a umístěte ji do pracovního adresáře aplikace. Její první snímek obsahuje jeden textový tvar s textem "Inherited text; explicit red 18pt". Vstup záměrně používá několik úrovní formátování:

- Výchozí styl textu prezentace poskytuje Calibri a velikost 28 pt.
- První úroveň stylu textu v textovém rámci poskytuje modrý text a kurzívu.
- Odstavec explicitně nastavuje tučný text.
- Druhá část, "explicit red 18pt", explicitně nastavuje červený text a velikost 18 pt.

Následující kompletní příklad exportuje stejné odstavce třikrát. Předá [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) metodě exportu a zapíše každý výsledek jako samostatný soubor UTF-8 HTML:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

Vygenerované HTML obsahuje následující CSS pro první část, "Inherited text; ". Tabulka uvádí relevantní deklarace; ostatní vygenerované vlastnosti jsou vynechány pro přehlednost.

| Výstup | Relevantní CSS pro první část | Vzhled |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Modrý, tučný, kurzívní text o velikosti 28 pt v Calibri, pokud je tento font k dispozici. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Modrý, tučný, kurzívní text; okolní stránka nebo prohlížeč poskytuje rodinu fontů a velikost. |
| `ParagraphOnly.html` | `font-weight:bold` | Tučný text; okolní stránka nebo prohlížeč poskytuje rodinu fontů, velikost, barvu a kurzívní styl. |

Druhá část zachovává `color:#ff0000`, `font-size:18pt` a `font-weight:bold` ve všech třech výstupech. Také zachovává kurzívu s `ALL` a `TEXT_BOX`, ale ne s `PARAGRAPH_ONLY`. Omezení dědičnosti tedy neodstraňuje formátování explicitně přiřazené odstavci nebo části.

Otevřete soubory ve stejném prohlížeči pro jejich porovnání. Ve dvou omezených režimech jsou vynechané CSS vlastnosti řešeny styly cílové stránky nebo výchozími nastaveními prohlížeče, takže výsledný vzhled závisí na tom, kde je HTML použito.

### **Vykreslení odstavce jako obrázku**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) vykreslí jednotlivý odstavec přímo a vrátí [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Výsledek uložte do souboru nebo proudu pomocí [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Nemusíte vykreslovat obsahující tvar ani ručně ořezávat bitmapu.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) může vrátit `None`, pokud odstavec nelze najít v nadřazené kolekci, nemá platné vykreslovací ohraničení nebo jej nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce ve výchozím měřítku**

Příklad používá `sample.pptx`, prezentaci s jedním snímkem, jehož první tvar je textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vybere druhý odstavec s indexem 1 a zavolá [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) bez parametrů měřítka. Ověří, že tvar obsahuje požadovaný odstavec a že vykreslení vrátí obrázek, předtím než zavolá [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) k uložení ve formátu PNG. Správce kontextu uvolní zdroje obrázku po použití.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

#### **Vykreslení odstavce v buňce tabulky se škálováním**

Použijte přetížení [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/), které přijímá parametry `scale_x` a `scale_y` pro nastavení horizontálního a vertikálního měřítka. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce dvakrát ve výchozí šířce a výšce a uloží výsledek jako PNG obrázek.

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Faktor měřítka `1` zachová tuto osu na výchozí velikosti pixelu. Například `2` pro oba faktory vytvoří obrázek, jehož šířka a výška jsou přibližně dvojnásobkem výchozích rozměrů, což vede ke čtyřnásobnému počtu pixelů. Větší faktory obecně poskytují ostřejší text pro zoom nebo výstup ve vysokém rozlišení, ale také zvyšují spotřebu paměti a velikost souboru. Faktory pod `1` vytvářejí menší obrázky s méně detaily. Použijte stejné faktory pro zachování poměru stran odstavce; různé horizontální a vertikální faktory roztačí výstup nezávisle.

Vykreslení celého tvaru pomocí [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) zůstává užitečné, když výstup musí zahrnovat výplň, okraj nebo jiné vizuální kontexty tvaru. Pro obrázek pouze odstavce použijte [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **Často kladené otázky**

**Mohu úplně zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) pro zakázání zalamování, aby řádky nebyly rozděleny na okrajích textového rámce.

**Jak mohu získat přesné rozměry konkrétního odstavce na snímku?**

Použijte [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) pro získání ohraničujícího obdélníku odstavce. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) poskytuje rozměry jednotlivé části.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) je nastavení na úrovni odstavce a platí pro celý odstavec bez ohledu na formátování jednotlivých částí. Pro svislé zarovnání částí s různými velikostmi fontů v rámci řádku viz [Zarovnání fontů v řádku](/slides/cs/python-net/text-formatting/#align-fonts-within-a-line).

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) pro jednotlivé části, aby jeden odstavec mohl obsahovat text ve více jazycích.