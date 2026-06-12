---
title: Správa textových odstavců PowerPoint v Pythonu
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/python-net/manage-paragraph/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- závěsné odsazení
- odrážka odstavce
- číslovaný seznam
- seznam s odrážkami
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
description: "Ovládněte formátování odstavců pomocí Aspose.Slides pro Python přes .NET—optimalizujte zarovnání, mezery a styl v prezentacích PowerPoint a OpenDocument v Pythonu, aby zaujaly diváky."
---
## **Úvod**

Aspose.Slides poskytuje třídy, které potřebujete pro práci s textem PowerPoint v Pythonu.

* Aspose.Slides poskytuje třídu [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) pro vytváření objektů textových rámců. Objekt `TextFrame` může obsahovat jeden nebo více odstavců (každý odstavec je oddělen znakem návratu řádku).
* Aspose.Slides poskytuje třídu [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) pro vytváření objektů odstavců. Objekt `Paragraph` může obsahovat jeden nebo více částí textu.
* Aspose.Slides poskytuje třídu [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) pro vytváření objektů částí textu a určení jejich vlastností formátování.

Objekt `Paragraph` může zpracovávat text s různými vlastnostmi formátování pomocí svých podkladových objektů `Portion`.

## **Přidání více odstavců obsahujících více částí textu**

Tyto kroky ukazují, jak přidat textový rámec, který obsahuje tři odstavce, každý se třemi částmi:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte odkaz na cílový snímek podle jeho indexu.
1. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
1. Získejte [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) spojený s [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
1. Vytvořte dva objekty [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) a přidejte je do kolekce odstavců [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) (spolu s výchozím odstavcem to dává tři odstavce).
1. Pro každý odstavec vytvořte tři objekty [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) a přidejte je do kolekce částí tohoto odstavce.
1. Nastavte text pro každou část.
1. Použijte libovolné požadované formátování na každou část textu pomocí vlastností nabízených třídou [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/).
1. Uložte upravenou prezentaci.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation pro vytvoření nového souboru PPTX.
with slides.Presentation() as presentation:

    # Přístup k prvnímu snímku.
    slide = presentation.slides[0]

    # Přidejte obdélníkový AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Přístup k TextFrame AutoShape.
    text_frame = shape.text_frame

    # Vytvořte odstavce a části; formátování je aplikováno níže.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Uložte PPTX na disk.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Správa odstavcových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odstavce s odrážkami jsou často snazší na čtení a pochopení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Přistupte k cílovému snímku podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
1. Získejte [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru.
1. Odstraňte výchozí odstavec z [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/).
1. Nastavte typ odrážky odstavce na `SYMBOL` a určete znak odrážky.
1. Nastavte text odstavce.
1. Nastavte odsazení odrážky pro odstavec.
1. Nastavte barvu odrážky.
1. Nastavte velikost odrážky (výšku).
1. Přidejte odstavec do kolekce odstavců [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Přidejte druhý odstavec a opakujte kroky 7–12.
1. Uložte prezentaci.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci prezentace.
with slides.Presentation() as presentation:

    # Přístup k prvnímu snímku.
    slide = presentation.slides[0]

    # Přidejte a přistupujte k AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Přístup k textovému rámci vytvořeného AutoShape.
    text_frame = shape.text_frame

    # Odstraňte výchozí odstavec.
    text_frame.paragraphs.remove_at(0)

    # Vytvořte odstavec.
    paragraph = slides.Paragraph()

    # Nastavte styl a znak odrážky odstavce.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Nastavte text odstavce.
    paragraph.text = "Welcome to Aspose.Slides"

    # Nastavte odsazení odrážky.
    paragraph.paragraph_format.indent = 25

    # Nastavte barvu odrážky.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Nastavte výšku odrážky.
    paragraph.paragraph_format.bullet.height = 100

    # Přidejte odstavec do textového rámce.
    text_frame.paragraphs.add(paragraph)

    # Vytvořte druhý odstavec.
    paragraph2 = slides.Paragraph()

    # Nastavte typ a styl odrážky odstavce.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Nastavte text odstavce.
    paragraph2.text = "This is numbered bullet"

    # Nastavte odsazení odrážky.
    paragraph2.paragraph_format.indent = 25

    # Nastavte barvu odrážky.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Nastavte výšku odrážky.
    paragraph2.paragraph_format.bullet.height = 100

    # Přidejte odstavec do textového rámce.
    text_frame.paragraphs.add(paragraph2)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Správa obrázkových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Obrázkové odrážky jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Přistupte k cílovému snímku podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
1. Získejte [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru.
1. Odstraňte výchozí odstavec z [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/).
1. Načtěte obrázek do [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/).
1. Nastavte typ odrážky na [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) a přiřaďte obrázek.
1. Nastavte text odstavce.
1. Nastavte odsazení odstavce pro odrážku.
1. Nastavte barvu odrážky.
1. Nastavte výšku odrážky.
1. Přidejte nový odstavec do kolekce odstavců [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Přidejte druhý odstavec a opakujte kroky 8–12.
1. Uložte prezentaci.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Přístup k prvnímu snímku.
    slide = presentation.slides[0]

    # Načtěte obrázek odrážky.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Přidejte a přistupujte k AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Přístup k TextFrame vytvořeného AutoShape.
    text_frame = auto_shape.text_frame

    # Odstraňte výchozí odstavec.
    text_frame.paragraphs.remove_at(0)

    # Vytvořte nový odstavec.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Nastavte typ odrážky odstavce na Obrázek a přiřaďte obrázek.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Nastavte výšku odrážky.
    paragraph.paragraph_format.bullet.height = 100

    # Přidejte odstavec do textového rámce.
    text_frame.paragraphs.add(paragraph)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Uložte prezentaci jako soubor PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Správa víceúrovňových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Víceúrovňové odrážky jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Přistupte k cílovému snímku podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
1. Získejte [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) patřícímu k [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
1. Odstraňte výchozí odstavec z [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) a nastavte jeho hloubku na 0.
1. Vytvořte druhý odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) a nastavte jeho hloubku na 1.
1. Vytvořte třetí odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) a nastavte jeho hloubku na 2.
1. Vytvořte čtvrtý odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) a nastavte jeho hloubku na 3.
1. Přidejte nové odstavce do kolekce odstavců [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Uložte prezentaci.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci prezentace.
with slides.Presentation() as presentation:

    # Přístup k prvnímu snímku.
    slide = presentation.slides[0]
    
    # Přidejte AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Přístup k TextFrame vytvořeného AutoShape.
    text_frame = auto_shape.text_frame
    
    # Vymažte výchozí odstavec.
    text_frame.paragraphs.clear()

    # Přidejte první odstavec.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Nastavte úroveň odrážky.
    paragraph1.paragraph_format.depth = 0

    # Přidejte druhý odstavec.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Nastavte úroveň odrážky.
    paragraph2.paragraph_format.depth = 1

    # Přidejte třetí odstavec.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Nastavte úroveň odrážky.
    paragraph3.paragraph_format.depth = 2

    # Přidejte čtvrtý odstavec.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Nastavte úroveň odrážky.
    paragraph4.paragraph_format.depth = 3

    # Přidejte odstavce do kolekce.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Správa odstavců s vlastní číslovanými seznamy**

Třída [BulletFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/) poskytuje vlastnost `numbered_bullet_start_with` (a další) pro řízení vlastního číslování a formátování odstavců.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Přistupte k snímku, který bude obsahovat odstavce.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
1. Získejte [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru.
1. Odstraňte výchozí odstavec z [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Vytvořte první [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) a nastavte `numbered_bullet_start_with` na 2.
1. Vytvořte druhý [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) a nastavte `numbered_bullet_start_with` na 3.
1. Vytvořte třetí [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) a nastavte `numbered_bullet_start_with` na 7.
1. Přidejte odstavce do kolekce [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Uložte prezentaci.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Přidejte a přistupte k AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Přístup k TextFrame vytvořeného AutoShape.
    text_frame = shape.text_frame

    # Odstraňte výchozí existující odstavec.
    text_frame.paragraphs.remove_at(0)

    # Vytvořte první číslovanou položku (začíná 2, úroveň hloubky 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Vytvořte druhou číslovanou položku (začíná 3, úroveň hloubky 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Vytvořte třetí číslovanou položku (začíná 7, úroveň hloubky 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení odsazení první řádky pro odstavec**

Použijte vlastnost [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/) která řídí odsazení první řádky odstavce. Tato vlastnost posouvá pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco ostatní řádky zůstávají zarovnány k tělu odstavce.

Použijte [ParagraphFormat.margin_left](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/margin_left/) když potřebujete posunout celý odstavec. Použijte [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/) když potřebujete posunout jen první řádek.

Níže uvedený příklad vytvoří několik odstavců a použije různé hodnoty `indent`, aby ukázal, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Přistupte k cílovému snímku.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) k tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

![Odsazení první řádky odstavců](first_line_indent.png)

## **Nastavení závěsného odsazení pro odstavec**

Závěsné odsazení je rozvržení odstavce, kdy první řádek začíná vlevo od zbývajících řádků. V Aspose.Slides vytvoříte tento efekt pomocí vlastnosti [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/). Nastavte `indent` na zápornou hodnotu, aby se první řádek posunul doleva vůči tělu odstavce.

V praxi [ParagraphFormat.margin_left](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/margin_left/) určuje levý pozici těla odstavce a [ParagraphFormat.indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření závěsného odsazení nastavte kladnou hodnotu `margin_left` a zápornou hodnotu `indent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde zabalené řádky musí být zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Přistupte k cílovému snímku.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) k tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte kladnou hodnotu [margin_left](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/margin_left/) pro každý odstavec.
6. Nastavte zápornou hodnotu [indent](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/indent/) pro vytvoření efektu závěsného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

![Závěsné odsazení odstavců](hanging_indent.png)

## **Správa formátu části konce odstavce**

Když potřebujete řídit stylizaci „konce“ odstavce (formátování aplikované po poslední části textu), použijte vlastnost `end_paragraph_portion_format`. Níže uvedený příklad použije větší písmo Times New Roman na konec druhého odstavce.

1. Vytvořte nebo otevřete soubor [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte cílový snímek podle indexu.
1. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
1. Použijte [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru a vytvořte dva odstavce.
1. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/) nastavený na 48‑pt Times New Roman a použijte jej jako formát koncové části odstavce.
1. Přiřaďte jej k `end_paragraph_portion_format` odstavce (aplikuje se na konec druhého odstavce).
1. Uložte upravenou prezentaci jako soubor PPTX.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Import HTML textu do odstavců**

Aspose.Slides poskytuje rozšířenou podporu pro import HTML textu do odstavců.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Přistupte k cílovému snímku podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) na snímek.
1. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
1. Odstraňte výchozí odstavec z [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Přečtěte zdrojový soubor HTML.
1. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/).
1. Přidejte HTML obsah do kolekce odstavců [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
1. Uložte upravenou prezentaci.

```python
import aspose.slides as slides

# Vytvořte prázdnou instanci Presentation.
with slides.Presentation() as presentation:

    # Přístup k prvnímu snímku prezentace.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Přidejte AutoShape pro umístění HTML obsahu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Vymažte všechny odstavce v přidaném textovém rámci.
    shape.text_frame.paragraphs.clear()

    # Načtěte soubor HTML.
    with open("file.html", "rt") as html_stream:
        # Přidejte text ze souboru HTML do textového rámce.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Uložte prezentaci.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Export textu odstavce do HTML**

Aspose.Slides poskytuje rozšířenou podporu pro export textu do HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte cílovou prezentaci.
2. Přistupte k požadovanému snímku podle jeho indexu.
3. Vyberte tvar, který obsahuje text k exportu.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru.
5. Otevřete souborový tok pro zápis výstupu HTML.
6. Zadejte počáteční index a exportujte požadované odstavce.

```python
import aspose.slides as slides

# Načtěte soubor prezentace.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Přístup k prvnímu snímku prezentace.
    slide = presentation.slides[0]

    # Cílový index tvaru.
    index = 0

    # Přístup k tvaru podle indexu.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Zapište data odstavců do HTML zadáním počátečního indexu odstavce a celkového počtu odstaveců k exportu.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Uložení odstavce jako obrázku**

V této sekci prozkoumáme dva příklady, které ukazují, jak uložit textový odstavec, reprezentovaný třídou [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/), jako obrázek. Oba příklady zahrnují získání obrázku tvaru obsahujícího odstavec pomocí metod `get_image` ze třídy [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/), výpočet ohraničení odstavce uvnitř tvaru a export jako bitmapový obrázek. Tyto přístupy vám umožní extrahovat konkrétní části textu z prezentací PowerPoint a uložit je jako samostatné obrázky, což může být užitečné pro další využití v různých scénářích.

Předpokládejme, že máme soubor prezentace s názvem sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

**Příklad 1**

V tomto příkladu získáme druhý odstavec jako obrázek. K tomu extrahujeme obrázek tvaru z prvního snímku prezentace a poté spočítáme ohraničení druhého odstavce v textovém rámci tvaru. Odstavec je následně překreslen na nový bitmapový obrázek, který je uložen ve formátu PNG. Tento postup je zvláště užitečný, když potřebujete uložit konkrétní odstavec jako samostatný obrázek při zachování přesných rozměrů a formátování textu.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Uložte tvar do paměti jako bitmapu.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Vytvořte bitmapu tvaru z paměti.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Vypočítejte ohraničení druhého odstavce.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Ořízněte bitmapu tvaru, aby obsahovala pouze bitmapu odstavce.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

![Obrázek odstavce](paragraph_to_image_output.png)

**Příklad 2**

V tomto příkladu rozšiřujeme předchozí postup přidáním faktorů měřítka k obrázku odstavce. Tvar je extrahován z prezentace a uložen jako obrázek se škálovacím faktorem `2`. To umožňuje výstup s vyšším rozlišením při exportu odstavce. Ohraničení odstavce je pak vypočteno s ohledem na měřítko. Škálování může být zvláště užitečné, když je zapotřebí podrobný obrázek, například pro použití v materiálech s vysokou kvalitou tisku.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Uložte tvar do paměti jako bitmapu.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Vytvořte bitmapu tvaru z paměti.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Vypočítejte ohraničení druhého odstavce.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Ořízněte bitmapu tvaru, aby obsahovala pouze bitmapu odstavce.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Použijte nastavení zalamování textového rámce ([wrap_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/wrap_text/)) a vypněte zalamování, aby se řádky nepřerušovaly na okrajích rámce.

**Jak mohu získat přesné souřadnice na snímku konkrétního odstavce?**

Můžete získat ohraničující obdélník odstavce (a dokonce i jednotlivé části), abyste znali jeho přesnou polohu a velikost na snímku.

**Kde se řídí zarovnání odstavce (levé/pravé/centrované/justify)?**

[Alignment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/alignment/) je nastavení na úrovni odstavce v [ParagraphFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/); vztahuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu pouze pro část odstavce (např. jedno slovo)?**

Ano. Jazyk se nastavuje na úrovni části ([PortionFormat.language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/language_id/)), takže v jednom odstavci mohou koexistovat více jazyků.