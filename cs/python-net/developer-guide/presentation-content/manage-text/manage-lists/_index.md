---
title: Spravovat odrážkové a číslované seznamy v prezentacích v Pythonu
linktitle: Spravovat seznamy
type: docs
weight: 70
url: /cs/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- odrážka
- odrážkový seznam
- číslovaný seznam
- symbolická odrážka
- obrázková odrážka
- vlastní odrážka
- víceúrovňový seznam
- vytvořit odrážku
- přidat odrážku
- přidat seznam
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Získejte návod, jak vytvářet a formátovat odrážkové, obrázkové, víceúrovňové a číslované seznamy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Aspose.Slides pro Python via .NET vám umožňuje vytvářet a formátovat odrážkované a číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážky je řízeno formátem odstavce.

Použijte vlastnost [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) pro přístup k nastavením seznamu na úrovni odstavce. Hlavním vstupním bodem je [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/), který vrací objekt [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/). Pomocí tohoto objektu můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit vícestupňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- prozkoumat a změnit formátování seznamu v existující prezentaci
- číst skutečné značky seznamu a čísla vedle textu odstavce

## **Vytvořit odrážkový seznam**

Pro vytvoření odrážkového seznamu přidejte objekty [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) a nastavte [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) na [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). Poté můžete nastavit [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/), a [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) pro ovládání vzhledu odrážky.

Následující kód v Pythonu ukazuje, jak vytvořit odrážkový seznam na snímku:

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Symbolické odrážky](symbol_bullets.png)

## **Vytvořit číslovaný seznam**

Používejte číslované seznamy, když je pořadí položek důležité. Nastavte [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) na [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). Můžete také zvolit formát číslování pomocí [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) nebo nastavit [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/), pokud má seznam začít od hodnoty jiné než 1.

Následující kód v Pythonu ukazuje, jak vytvořit číslovaný seznam na snímku:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Číslované odrážky](numbered_bullets.png)

## **Vytvořit obrázkovou odrážku**

Aspose.Slides umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe u jednoduchých obrázků, které jsou čitelné i v malé velikosti, například ikon nebo malých průhledných PNG souborů.

{{% alert color="info" title="Note" %}}Ideálně, pokud plánujete nahradit běžný symbol odrážky obrázkem, je nejlepší zvolit jednoduchou grafiku s průhledným pozadím. Takové obrázky dobře fungují jako vlastní symboly odrážek.{{% /alert %}}

Mějte na paměti, že obrázek bude zmenšen na velmi malou velikost. Z tohoto důvodu důrazně doporučujeme vybrat obrázek, který zůstane jasný a vizuálně účinný, když je použit jako odrážka v seznamu.

Pro vytvoření obrázkové odrážky přidejte obrázek do [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) a přiřaďte vrácený objekt obrázku k [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). Nastavte [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) na [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) před přiřazením obrázku.

Předpokládejme, že máme soubor "image.png":

![Obrázek pro odrážky](picture_for_bullets.png)

Následující kód v Pythonu ukazuje, jak vytvořit obrázkové odrážky na snímku:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Obrázkové odrážky](picture_bullets.png)

## **Vytvořit víceúrovňový seznam**

Použijte [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) k umístění položek seznamu na různé úrovně. Úroveň 0 je nejvyšší úroveň, úroveň 1 je pod ní vnořená a tak dále. Hloubka řídí pouze odsazení; nastavte [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) u každého odstavce, pokud mají úrovně také obsahovat odrážky.

Následující kód v Pythonu ukazuje, jak vytvořit víceúrovňový seznam:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Víceúrovňový seznam](multilevel_list.png)

## **Změnit existující seznam**

Pro změnu formátování seznamu v existující prezentaci přistupte k cílovému odstavci a aktualizujte jeho nastavení [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/). Stejné vlastnosti použité při vytváření seznamů lze použít k prozkoumání nebo úpravě seznamů načtených ze souboru PPT, PPTX nebo ODP.

Následující kód v Pythonu mění první odstavec v textovém rámci tak, aby používal styl číslovaného seznamu:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Přečíst skutečné hodnoty odrážek**

Při extrahování obsahu prezentace uchovávejte značky seznamu vedle textu odstavce. Zavolejte [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) a přistupte k [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/), abyste získali efektivní formát odrážky. Zkontrolujte jeho [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/) před přečtením [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/).

Pro číslované seznamy rozlišujte tyto tři hodnoty:

- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) určuje formát, například arabské číslice následované tečkou nebo malá písmena následovaná tečkou.
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) určuje počáteční číslo pro skupinu číslovaných odstavců.
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) vrací formátovaný marker pro konkrétní odstavec. Například druhá položka v seznamu začínajícím od 5 vrátí `6.`.

Uchovejte [depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) u každého odstavce, aby se zachovala úroveň vnoření. Skutečný marker neobsahuje úplnou hierarchii: vnožená položka může vrátit `c.` místo kombinovaného štítku jako `6.c.`.

Následující samostatný příklad vytváří seznamy, ukládá je do prezentace a znovu načítá prezentaci, aby nahlásil text, hloubku, typ odrážky a skutečnou hodnotu každého odstavce. Malý modrý obrázkový marker je vytvořen z vloženého SVG.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # Vytvořit obrázkový marker bez externího souboru obrázku.
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

Zdrojové seznamy jsou zobrazeny níže.

![Seznamy začínající od 5, vnořené položky s písmeny a římskými čísly, symbolický marker, odstavec bez odrážky a modrý obrázkový marker](actual_bullet_values.png)

Zpráva odpovídá markerům zobrazeným v PowerPointu:

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

Pro [BulletType.NONE and BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) vrací `None`, nikoli prázdný řetězec. Tyto typy zpracovávejte odděleně: první nemá žádný marker, zatímco druhý vyžaduje samostatné extrahování obrázku odrážky. Obrázkovou odrážku nelze reprodukovat pouze extrahováním textového markeru.

## **Často kladené otázky**

**Can bulleted and numbered lists be exported to PDF or images?**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamu, pokud cílový formát podporuje odpovídající rozvržení textu a funkce odrážek.

**Can I edit lists in existing presentations?**

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k cílovému odstavci, prozkoumejte nebo aktualizujte jeho nastavení [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/), a uložte prezentaci.

**Can lists contain non-Latin text?**

**Mohou seznamy obsahovat ne-latinský text?**

Ano. Text položek seznamu může obsahovat Unicode znaky, takže můžete vytvářet seznamy ve vícejazyčných prezentacích. Ujistěte se, že použité fonty v prezentaci podporují potřebné znaky.