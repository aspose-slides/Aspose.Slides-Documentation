---
title: Správa textových odstavců PowerPoint v Pythonu
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
- zahnuté odsazení
- odrážka odstavce
- číslovaný seznam
- odrážkový seznam
- vlastnosti odstavce
- importovat HTML
- text do HTML
- odstavec do HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se vytvářet a formátovat odstavce, části, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Aspose.Slides pro Python přes .NET představuje text jako hierarchii textových rámců, odstavců a částí:

* [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) představuje úsek textu v rámci odstavce. Každá část může mít svůj vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými písmy, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytvoření a formátování odstavců**

### **Vytvoření odstavců s více částmi**

Následující kroky vytvoří textový rámec se třemi odstavci, z nichž každý obsahuje tři části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte přístup k požadovanému snímku pomocí jeho indexu.
3. Přidejte k snímku obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru.
5. Použijte výchozí odstavec a přidejte dva další objekty [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) do textového rámce.
6. Přidejte dostatek objektů [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) pro každý odstavec, aby obsahoval tři části. Výchozí odstavec již obsahuje jednu prázdnou část.
7. Nastavte text každé části.
8. Použijte formátování na úrovni znaků prostřednictvím [Portion.portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/portion_format/).
9. Uložte upravenou prezentaci.

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

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují procházení souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [BulletFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte přístup k požadovanému snímku pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na vybraný snímek.
4. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru.
5. Odstraňte výchozí odstavec z textového rámce.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) pro symbol odrážky.
7. Nastavte [BulletFormat.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/type/) na [BulletType.SYMBOL](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bullettype/) a zadejte znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Vytvořte druhý odstavec a nastavte [BulletFormat.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/type/) na [BulletType.NUMBERED](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bullettype/).
11. Nakonfigurujte styl číslované odrážky a přidejte odstavec do textového rámce.
12. Uložte prezentaci.

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

Obrázkové odrážky vám umožní použít vlastní obrázek místo symbolu nebo čísla.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte přístup k požadovanému snímku pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) a získejte přístup k jeho [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
4. Odstraňte výchozí odstavec z textového rámce.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [BulletFormat.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/type/) na [BulletType.PICTURE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bullettype/).
8. Přiřaďte obrázek pomocí [BulletFormat.picture](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/picture/) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Uložte upravenou prezentaci.

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

### **Vytvoření vícestupňového seznamu**

Nastavte [ParagraphFormat.depth](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/depth/) aby se odstavce umístily na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a získejte snímek.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) a vymažte výchozí odstavec z jeho textového rámce.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich hodnoty [ParagraphFormat.depth](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/depth/) na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

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

Použijte [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) aby se nastavil počáteční číslo zobrazené pro číslovaný odstavec.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
2. Vymažte výchozí odstavec z textového rámce tvaru.
3. Vytvořte tři číslované odstavce.
4. Nastavte [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) na `2`, `3` a `7` pro příslušné odstavce.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

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

### **Nastavení odsazení první řádky**

Použijte vlastnost [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/) k ovládání odsazení první řádky odstavce. Tato vlastnost posouvá jen první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco ostatní řádky zůstanou zarovnány k tělu odstavce.

Použijte [ParagraphFormat.margin_left](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/margin_left/), když potřebujete posunout celý odstavec. Použijte [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/), když chcete posunout jen první řádek.

Příklad níže vytvoří několik odstavců a aplikuje různé hodnoty [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/) k demonstraci, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
4. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

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

### **Nastavení zahnutého odsazení**

Zahnuté odsazení je rozvržení odstavce, při kterém první řádek začíná vlevo od zbývajících řádků. V Aspose.Slides vytvoříte tento efekt pomocí vlastnosti [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/). Nastavte `indent` na zápornou hodnotu, aby se první řádek posunul vlevo vzhledem k tělu odstavce.

V praxi [ParagraphFormat.margin_left](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/margin_left/) určuje levý okraj těla odstavce a [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/) určuje polohu první řádky vzhledem k tomuto okraji. Pro vytvoření zahnutého odsazení nastavte kladnou hodnotu `margin_left` a zápornou hodnotu `indent`.

Toto formátování je užitečné pro bibliografické záznamy, odkazy, glosáře a další odstavce, kde mají zarovnané řádky pod tělem odstavce místo pod prvním znakem první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
4. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte pro každý odstavec kladnou hodnotu [ParagraphFormat.margin_left](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/margin_left/).
6. Nastavte zápornou hodnotu [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/) pro vytvoření efektu zahnutého odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

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

![Zahnuté odsazení odstavců](hanging_indent.png)

### **Nastavení koncových vlastností odstavců**

Vlastnost [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) řídí formátování koncového znaku odstavce. Následující příklad přiřadí velikost písma a latinský font koncovému znaku druhého odstavce:

1. Načtěte [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a získejte snímek.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte k nim textové části.
4. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/) pro koncový znak druhého odstavce.
5. Nastavte [PortionFormat.font_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/font_height/) a [PortionFormat.latin_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/latin_font/).
6. Přiřaďte formát k [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) a uložte prezentaci.

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

## **Import a export obsahu odstavců**

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphcollection/add_from_html/) k převodu HTML značek na odstavce a části v textovém rámci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte snímek a přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
3. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru a vymažte výchozí odstavec.
4. Načtěte zdrojový HTML soubor.
5. Předávejte řetězec HTML metodě [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Uložte upravenou prezentaci.

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

Použijte [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphcollection/export_to_html/) k exportu vybraného rozsahu odstavců jako HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte snímek a najděte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/), který obsahuje text.
3. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
4. Zavolejte [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphcollection/export_to_html/) s indexem počátečního odstavce a počtem odstavců k exportu.
5. Zapište vrácený HTML řetězec do souboru.

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Vykreslení odstavce jako obrázku**

[Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) poskytuje metodu `get_image` pro přímé vykreslení jednotlivého odstavce. Metoda vrací [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/), který můžete uložit do souboru nebo proudu pomocí [IImage.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/save/). Není nutné vykreslovat celý tvar nebo ručně ořezávat bitmapu.

Metoda `get_image` může vrátit `None`, pokud odstavec nelze najít v rodičovské kolekci, nemá platné vykreslovací ohraničení nebo jej nelze vykreslit. Zkontrolujte výsledek před uložením a použijte vrácený obrázek jako správce kontextu pro uvolnění jeho prostředků.

#### **Vykreslení odstavce ve výchozím měřítku**

Předpokládejme, že máme soubor prezentace nazvaný sample.pptx s jedním snímkem, kde je první tvar textovým polem obsahujícím tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vykreslí druhý odstavec v běžném textovém tvaru ve výchozím měřítku a uloží vrácený obrázek ve formátu PNG:

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

Předávejte horizontální a vertikální škálovací faktory metodě `get_image`, abyste řídili velikost vykresleného odstavce. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce dvakrát širší a vyšší než výchozí rozměry a uloží výsledek jako PNG obrázek:

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

Škálovací faktor `1` zachová danou osu v její výchozí velikosti v pixelech. Například faktor `2` pro oba směry vytvoří obrázek, jehož šířka i výška jsou přibližně dvojnásobné oproti výchozím rozměrům, což vede k čtyřnásobnému počtu pixelů. Větší faktory obecně poskytují ostřejší text při zvětšování nebo výstupu ve vysokém rozlišení, ale zároveň zvyšují paměťovou náročnost a velikost souboru. Faktory pod `1` produkují menší obrázky s menším detailem. Používejte stejné faktory, pokud chcete zachovat poměr stran odstavce; různé horizontální a vertikální faktory obrázek natáhnou nezávisle.

Vykreslování celého tvaru pomocí [Shape.get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/) zůstává užitečné, když výstup musí zahrnovat výplň, ohraničení nebo jiný vizuální kontext tvaru. Pro obrázek pouze s odstavcem použijte `Paragraph.get_image`.

## **Často kladené otázky**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/wrap_text/) pro zakázání zalamování, aby řádky neřezaly na okrajích textového rámce.

**Jak mohu získat přesné rozměry konkrétního odstavce na snímku?**

Použijte [Paragraph.get_rect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/get_rect/) pro získání obdélníku ohraničujícího odstavec. [Portion.get_rect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/get_rect/) poskytuje rozměry jednotlivé části.

**Kde je řízena zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/alignment/) je nastavení na úrovni odstavce a aplikuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [PortionFormat.language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/language_id/) pro jednotlivé části, takže jeden odstavec může obsahovat text v několika jazycích.