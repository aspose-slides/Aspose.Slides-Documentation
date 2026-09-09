---
title: Správa odrážkových a číslovaných seznamů v prezentacích pomocí Pythonu přes Java
linktitle: Správa seznamů
type: docs
weight: 60
url: /cs/python-java/manage-lists/
keywords:
- odrážka
- odrážkový seznam
- číslovaný seznam
- symbolová odrážka
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
- Java
- Aspose.Slides
description: "Naučte se, jak vytvářet a formátovat odrážkové seznamy, obrázkové odrážky, víceúrovňové seznamy a číslované seznamy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Aspose.Slides for Python via Java vám umožňuje vytvářet a formátovat odrážkové i číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážky je řízeno prostřednictvím formátu odstavce.

Použijte metodu [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/#getParagraphFormat) pro přístup k nastavením seznamu na úrovni odstavce. Hlavním vstupním bodem je [ParagraphFormat.getBullet](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#getBullet), který vrací objekt [BulletFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/). S tímto objektem můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit víceúrovňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- zkontrolovat a změnit formátování seznamu v existující prezentaci

## **Vytvoření odrážkového seznamu**

Pro vytvoření odrážkového seznamu přidejte objekty [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) a nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setType) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bullettype/#Symbol). Poté můžete použít [BulletFormat.setChar](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#getColor) a [BulletFormat.setHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setHeight) pro řízení vzhledu odrážky.

Následující kód v Pythonu ukazuje, jak vytvořit odrážkový seznam na snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The symbol bullets](symbol_bullets.png)

## **Vytvoření číslovaného seznamu**

Používejte číslované seznamy, když je pořadí položek důležité. Nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setType) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bullettype/#Numbered). Můžete také vybrat formát číslování pomocí [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) nebo použít [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), pokud má seznam začít jinou hodnotou než 1.

Následující kód v Pythonu ukazuje, jak vytvořit číslovaný seznam na snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The numbered bullets](numbered_bullets.png)

## **Vytvoření obrázkové odrážky**

Aspose.Slides umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe s jednoduchými obrázky, které zůstávají čitelné i při malé velikosti, například ikony nebo malé průhledné soubory PNG.

{{% alert color="info" title="Note" %}}
Pokud plánujete nahradit běžný symbol odrážky obrázkem, zvolte jednoduchou grafiku s průhledným pozadím. Takové obrázky fungují dobře jako vlastní symboly odrážek.

Mějte na paměti, že obrázek bude zmenšen na velmi malou velikost. Z tohoto důvodu důrazně doporučujeme vybrat obrázek, který zůstane jasný a vizuálně účinný, když bude použit jako odrážka v seznamu.
{{% /alert %}}

Pro vytvoření obrázkové odrážky přidejte obrázek pomocí [Presentation.getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) a přiřaďte vrácený objekt obrázku k [BulletFormat.getPicture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#getPicture). Nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bulletformat/#setType) na [BulletType.Picture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/bullettype/#Picture) před přiřazením obrázku.

Předpokládejme, že máme obrázek s názvem "image.png":

![A picture for the bullets](picture_for_bullets.png)

Následující kód v Pythonu ukazuje, jak vytvořit obrázkové odrážky na snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The picture bullets](picture_bullets.png)

## **Vytvoření víceúrovňového seznamu**

Použijte [ParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setDepth) k umístění položek seznamu na různé úrovně. Úroveň 0 je nejvyšší úroveň, úroveň 1 je pod ní a tak dále.

Následující kód v Pythonu ukazuje, jak vytvořit víceúrovňový odrážkový seznam:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The multilevel list](multilevel_list.png)

## **Změna existujícího seznamu**

Pro změnu formátování seznamu v existující prezentaci přistupte k požadovanému odstavci a aktualizujte jeho nastavení [ParagraphFormat.getBullet](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#getBullet). Stejné vlastnosti použité při vytváření seznamů lze použít i k prohlížení či úpravě seznamů načtených ze souboru PPT, PPTX nebo ODP.

Následující kód v Pythonu mění první odstavec v textovém rámci tak, aby použil styl číslovaného seznamu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamu, pokud cílový formát podporuje odpovídající rozvržení textu a funkce odrážek.

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k požadovanému odstavci, zkontrolujte nebo aktualizujte jeho [ParagraphFormat.getBullet](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#getBullet) nastavení a prezentaci uložte.

**Mohou seznamy obsahovat ne‑latinový text?**

Ano. Text položek seznamu může obsahovat Unicode znaky, takže můžete vytvářet seznamy ve vícejazyčných prezentacích. Ujistěte se, že použité fonty v prezentaci podporují potřebné znaky.