---
title: Správa textových odstavců PowerPointu v Pythonu pomocí Java
linktitle: Spravovat odstavec
type: docs
weight: 40
url: /cs/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
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
- text na HTML
- odstavec na HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Python přes Java vytvářet a formátovat odstavce, části, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců."
---
## **Přehled**

Aspose.Slides for Python via Java představuje text jako hierarchii textových rámců, odstavců a částí:

* [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) představuje úsek textu v odstavci. Každá část může mít vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými fonty, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytvoření a formátování odstavců**

### **Vytvoření odstavců s více částmi**

Následující kroky vytvoří textový rámec se třemi odstavci, z nichž každý obsahuje tři části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte přístup k požadovanému snímku pomocí jeho indexu.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) na snímek.
4. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) tvaru.
5. Použijte výchozí odstavec a přidejte dva další objekty [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) do textového rámce.
6. Přidejte dostatek objektů [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) tak, aby každý odstavec obsahoval tři části. Výchozí odstavec již obsahuje jednu prázdnou část.
7. Nastavte text pro každou část.
8. Použijte formátování na úrovni znaků pomocí [Portion.getPortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getPortionFormat).
9. Uložte upravenou prezentaci.

Tento příklad v Pythonu implementuje kroky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vytvoření odrážkových a číslovaných seznamů**

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují prohlížení souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [BulletFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte přístup k požadovanému snímku pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) na vybraný snímek.
4. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) tvaru.
5. Odstraňte výchozí odstavec z textového rámce.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) pro symbolickou odrážku.
7. Nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setType) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bullettype/#Symbol) a zadejte znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Vytvořte druhý odstavec a nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setType) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bullettype/#Numbered).
11. Nakonfigurujte styl číslované odrážky a přidejte odstavec do textového rámce.
12. Uložte prezentaci.

Tento příklad v Pythonu vytváří symbolickou odrážku a číslovanou odrážku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Použití obrázkových odrážek**

Obrázkové odrážky vám umožňují použít vlastní obrázek místo symbolu nebo čísla.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte přístup k požadovanému snímku pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) a získejte přístup k jeho [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/).
4. Odstraňte výchozí odstavec z textového rámce.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setType) na [BulletType.Picture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bullettype/#Picture).
8. Přiřaďte obrázek pomocí [BulletFormat.getPicture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#getPicture) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Uložte upravenou prezentaci.

Tento příklad v Pythonu vytváří obrázkovou odrážku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Vytvoření víceúrovňového seznamu**

Nastavte [ParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setDepth) pro umístění odstavců na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a získejte přístup k snímku.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) a vymažte výchozí odstavec z jeho textového rámce.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich hodnoty [ParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setDepth) na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento příklad v Pythonu vytváří čtyřúrovňový odrážkový seznam:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zahájení číslovaných položek seznamu na vlastní hodnoty**

Použijte [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) pro nastavení počátečního čísla zobrazeného u číslovaného odstavce.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) na snímek.
2. Vymažte výchozí odstavec z textového rámce tvaru.
3. Vytvořte tři číslované odstavce.
4. Nastavte [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) na `2`, `3` a `7` pro příslušné odstavce.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento příklad v Pythonu přiřazuje vlastní počáteční číslo ke každému odstavci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Řízení rozvržení odstavců a koncových vlastností**

### **Nastavení odsazení první řádky**

Použijte [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setIndent) pro řízení odsazení první řádky odstavce. Tato metoda posouvá pouze první řádek vůči levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbylé řádky zůstávají zarovnané k tělu odstavce.

Použijte [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setMarginLeft), když potřebujete posunout celý odstavec. Použijte [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setIndent), když potřebujete posunout jen první řádek.

Níže uvedený příklad vytvoří několik odstavců a použije různé hodnoty [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setIndent), aby ukázal, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte přístup k cílovému snímku.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) na snímek.
4. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setIndent).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit odsazení odstavce:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Odsazení první řádky odstavců](first_line_indent.png)

### **Nastavení zavěšeného odsazení**

Zavěšené odsazení je rozvržení odstavce, při kterém první řádek začíná vlevo od zbylých řádků. V Aspose.Slides tento efekt vytvoříte pomocí [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setIndent). Použijte zápornou hodnotu pro posun první řádky doleva vzhledem k tělu odstavce.

V praxi [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setMarginLeft) určuje levou pozici těla odstavce a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setIndent) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření zavěšeného odsazení předáte kladnou hodnotu [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setMarginLeft) a zápornou hodnotu [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setIndent).

Toto formátování je užitečné pro bibliografie, reference, položky glosáře a další odstavce, kde musí být zarážky řádků zarovnané pod tělo odstavce místo pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte přístup k cílovému snímku.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) na snímek.
4. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a pro každý z nich předáte kladnou hodnotu [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setMarginLeft).
6. Předáte zápornou hodnotu [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setIndent) pro vytvoření efektu zavěšeného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit zavěšené odsazení pro odstavec:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Zavěšené odsazení odstavců](hanging_indent.png)

### **Nastavení koncových vlastností odstavce**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) řídí formátování koncového znaku odstavce. Následující příklad přiřadí velikost písma a latinské písmo ke koncovému znaku druhého odstavce:

1. Načtěte [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a získejte přístup k snímku.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte k nim textové části.
4. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/) pro koncový znak druhého odstavce.
5. Nastavte [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setFontHeight) a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. Přiřaďte formát pomocí [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) a uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Počítání vykreslených řádků**

Použijte [Paragraph.getLinesCount](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/#getLinesCount) k spočítání řádků, které odstavec zabírá po rozvržení textu, včetně automatického zalamování. To je užitečné při kontrole délky textu a rozvržení v šablonách prezentací.

Odstavec je jednou položkou v [TextFrame.getParagraphs](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParagraphs) a může zabírat několik vykreslených řádků. Výslovný zalomení řádku uvnitř odstavce vynutí nový řádek, aniž by vytvořil nový odstavec. Automatické zalamování vytváří řádky na základě dostupné šířky, aniž by do textu vkládalo explicitní zalomení řádku. Počítání odstavců nebo znaků pro zalomení řádku tedy nedává počet vykreslených řádků.

Následující příklad vytvoří textový tvar, spočítá jeho řádky, zúží tvar a poté nahradí text kratším řetězcem. Zalamování je povoleno a automatické přizpůsobení je vypnuto, takže šířka tvaru řídí zalamování bez automatického zmenšování textu nebo změny velikosti tvaru. Rozměry tvaru jsou v bodech. Nakonec příklad přidá další odstavec a sečte počty řádků napříč textovým rámcem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

S tímto textem a těmito rozměry zúžení tvaru zvýší počet řádků, zatímco nahrazení textu krátkým řetězcem jej sníží. Přesné počty se mohou lišit podle dostupnosti a náhrady fontů, velikosti písma, okrajů, odsazení, zalamování a nastavení automatického přizpůsobení. Používejte fonty a nastavení rozvržení určené pro cílové prostředí při kontrole šablony.

Počet řádků sám o sobě nestanovuje, zda text přesahuje svůj kontejner. Důležitá je také dostupná výška, výšky řádků, mezery mezi odstavci a řádky a chování automatického přizpůsobení; i jediný řádek může překročit dostupnou šířku, když je zalamování vypnuto.

## **Import a export obsahu odstavců**

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphcollection/#addFromHtml) pro převod HTML značkování na odstavce a části v textovém rámci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte přístup k snímku a přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
3. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) tvaru a vymažte výchozí odstavec.
4. Načtěte zdrojový HTML soubor.
5. Předávejte HTML řetězec metodě [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Uložte upravenou prezentaci.

Tento příklad v Pythonu importuje HTML do textového rámce:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Export textu odstavce do HTML**

Použijte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphcollection/#exportToHtml) pro export vybraného rozsahu odstavců jako HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte přístup k snímku a najděte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/), který obsahuje text.
3. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) tvaru.
4. Zavolejte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphcollection/#exportToHtml) s indexem počátečního odstavce a počtem odstavců k exportu.
5. Zapište vrácený HTML řetězec do souboru.

Tento příklad v Pythonu exportuje všechny odstavce z prvního textového tvaru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Vykreslení odstavce jako obrázku**

[Paragraph.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) vykreslí jednotlivý odstavec přímo a vrátí objekt obrázku. Výsledek uložte do souboru nebo proudu pomocí metody `save`. Nemusíte vykreslovat obalující tvar ani ručně ořezávat bitmapu.

[Paragraph.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) může vrátit `None`, pokud odstavec nelze najít v nadřazené kolekci, nemá platné vykreslovací ohraničení nebo jej nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce v základním měřítku**

Předpokládejme, že máme soubor prezentace s názvem sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vykreslí druhý odstavec v běžném textovém tvaru v základním měřítku a uloží vrácený obrázek ve formátu PNG. Blok `finally` zajistí, že obrázek bude správně uvolněn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

![Obrázek odstavce](paragraph_to_image_output.png)

#### **Vykreslení odstavce v buňce tabulky se škálováním**

Použijte přetížení [Paragraph.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) , které přijímá parametry `scale_x` a `scale_y` k nastavení horizontálního a vertikálního měřítka. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce na dvojnásobnou výchozí šířku a výšku a uloží výsledek jako PNG obrázek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

Měřítkový faktor `1` zachovává tuto osu v její výchozí velikosti v pixelech. Například `2` pro oba faktory vytvoří obrázek, jehož šířka a výška jsou přibližně dvojnásobkem výchozích rozměrů, což vede k čtyřnásobnému počtu pixelů. Větší faktory obecně poskytují ostřejší text při zvětšování nebo výstupu ve vysokém rozlišení, ale také zvyšují využití paměti a velikost souboru. Faktory pod `1` vytvářejí menší obrázky s méně detaily. Použijte stejné faktory pro zachování poměru stran odstavce; různé horizontální a vertikální faktory roztažení výstup nezávisle.

Vykreslení celého tvaru pomocí [Shape.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) zůstává užitečné, když výstup musí zahrnovat výplň, okraj nebo jiný vizuální kontext tvaru. Pro obrázek jen odstavce použijte [Paragraph.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/).

## **Časté dotazy**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**  
Ano. Nastavte [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setWrapText) tak, aby zakázal zalamování, takže řádky se nebudou lámat na okrajích textového rámce.

**Jak mohu získat přesné rozměry konkrétního odstavce na snímku?**  
Použijte [Paragraph.getRect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/#getRect) pro získání ohraničujícího obdélníku odstavce. [Portion.getRect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getRect) poskytuje rozměry jednotlivé části.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**  
[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setAlignment) je nastavení na úrovni odstavce a vztahuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk pravopisu pro část odstavce?**  
Ano. Nastavte [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId) pro jednotlivé části, takže jeden odstavec může obsahovat text v několika jazycích.