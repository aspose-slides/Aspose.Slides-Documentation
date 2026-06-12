---
title: Spravovat odrážkové a číslované seznamy v prezentacích v Pythonu
linktitle: Spravovat seznamy
type: docs
weight: 70
url: /cs/python-net/manage-lists/
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
description: "Naučte se, jak vytvářet a formátovat odrážkové, obrázkové, víceúrovňové a číslované seznamy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Aspose.Slides pro Python přes .NET vám umožňuje vytvářet a formátovat odrážkové i číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážek je řízeno prostřednictvím formátu odstavce.

Pomocí vlastnosti [Paragraph.paragraph_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/paragraph_format/) získáte nastavení seznamu na úrovni odstavce. Hlavní vstupní bod je [ParagraphFormat.bullet](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/bullet/), který vrací objekt [BulletFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/). S tímto objektem můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit víceúrovňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- prozkoumat a změnit formátování seznamu v existující prezentaci

## **Vytvoření odrážkového seznamu**

Chcete‑li vytvořit odrážkový seznam, přidejte objekty [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) a nastavte [BulletFormat.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/type/) na [BulletType.SYMBOL](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bullettype/). Poté můžete nastavit [BulletFormat.char](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/color/) a [BulletFormat.height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/height/) pro úpravu vzhledu odrážky.

Následující Python kód demonstruje, jak vytvořit odrážkový seznam na snímku:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
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

## **Vytvoření číslovaného seznamu**

Číslované seznamy použijte, když je pořadí položek důležité. Nastavte [BulletFormat.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/type/) na [BulletType.NUMBERED](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bullettype/). Můžete také zvolit formát číslování pomocí [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/numbered_bullet_style/) nebo nastavit [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/), když má seznam začít od hodnoty jiné než 1.

Následující Python kód ukazuje, jak vytvořit číslovaný seznam na snímku:

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

## **Vytvoření obrázkové odrážky**

Aspose.Slides umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe s jednoduchými obrázky, které zůstávají čitelné v malé velikosti, jako jsou ikony nebo malé průhledné PNG soubory.

{{% alert color="primary" %}}
Ideální je, pokud plánujete nahradit běžný symbol odrážky obrázkem, vybrat si jednoduchou grafiku s průhledným pozadím. Takové obrázky dobře fungují jako vlastní symboly odrážek.

Mějte na paměti, že obrázek bude zmenšen na velmi malou velikost. Z tohoto důvodu důrazně doporučujeme zvolit obrázek, který zůstane jasný a vizuálně účinný, když bude použit jako odrážka v seznamu.
{{% /alert %}}

Chcete‑li vytvořit obrázkovou odrážku, přidejte obrázek do [Presentation.images](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/images/) a přiřaďte vrácený objekt obrázku k [BulletFormat.picture](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/picture/). Nejprve nastavte [BulletFormat.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bulletformat/type/) na [BulletType.PICTURE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/bullettype/) před přiřazením obrázku.

Předpokládejme, že máme soubor „image.png“:

![Obrázek pro odrážky](picture_for_bullets.png)

Následující Python kód ukazuje, jak vytvořit obrázkové odrážky na snímku:

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

## **Vytvoření víceúrovňového seznamu**

Použijte [ParagraphFormat.depth](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/depth/) k umístění položek seznamu na různé úrovně. Úroveň 0 je nejvyšší, úroveň 1 je pod ní atd.

Následující Python kód ukazuje, jak vytvořit víceúrovňový odrážkový seznam:

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

## **Změna existujícího seznamu**

Chcete‑li změnit formátování seznamu v existující prezentaci, přistupte k cílovému odstavci a aktualizujte jeho nastavení [ParagraphFormat.bullet](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/bullet/). Stejné vlastnosti použité při vytváření seznamů lze použít k prozkoumání nebo úpravě seznamů načtených ze souboru PPT, PPTX nebo ODP.

Následující Python kód změní první odstavec v textovém rámci tak, aby používal číslovaný styl seznamu:

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

## **Časté dotazy**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamů, pokud cílový formát podporuje odpovídající rozložení textu a funkce odrážek.

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k cílovému odstavci, prozkoumejte nebo aktualizujte jeho nastavení [ParagraphFormat.bullet](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/bullet/) a prezentaci uložte.

**Mohou seznamy obsahovat text v ne‑latinských skriptech?**

Ano. Text položek seznamu může obsahovat znaky Unicode, takže můžete vytvářet seznamy ve vícejazyčných prezentacích. Ujistěte se, že použité fonty v prezentaci podporují požadované znaky.