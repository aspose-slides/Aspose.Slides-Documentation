---
title: Spravujte horní a dolní index v prezentacích pomocí Pythonu přes Java
linktitle: Horní a dolní index
type: docs
weight: 80
url: /cs/python-java/superscript-and-subscript/
keywords:
- horní index
- dolní index
- přidat horní index
- přidat dolní index
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Ovládněte horní a dolní index v Aspose.Slides pro Python přes Java a pozvedněte své prezentace profesionálním formátováním textu pro maximální dopad."
---
## **Přehled**

Aspose.Slides poskytuje funkce pro začlenění textu s horním a dolním indexem do vašich prezentací PowerPoint (PPT, PPTX) a OpenDocument (ODP). Ať už potřebujete zvýraznit chemické vzorce, matematické rovnice nebo doplnit obsah poznámkami pod čarou, tyto specializované možnosti formátování pomáhají zachovat přehlednost a přesnost. V tomto článku se naučíte, jak bezproblémově použít styly horního a dolního indexu a zajistit profesionální výsledek na každém snímku.

## **Správa textu s horním a dolním indexem**

Můžete přidat text s horním a dolním indexem do libovolné části odstavce. Pro použití tohoto formátování v textovém rámci Aspose.Slides použijte metodu [setEscapement](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#setEscapement) třídy [PortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/).

Hodnota escapement se pohybuje od -100 % (dolní index) do 100 % (horní index). Například:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Získejte snímek podle jeho indexu.
- Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) typu [ShapeType.Rectangle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#Rectangle) na snímek.
- Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) spojenému s [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
- Vymažte existující odstavce.
- Vytvořte odstavec, který bude obsahovat text s horním indexem, a přidejte jej do [kolekce odstavců](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParagraphs) textového rámce.
- Vytvořte část.
- Použijte [setEscapement](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#setEscapement) k nastavení hodnoty od 0 do 100 pro horní index (0 znamená žádný horní index).
- Nastavte text [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) a přidejte jej do kolekce částí odstavce.
- Vytvořte odstavec, který bude obsahovat text s dolním indexem, a přidejte jej do [kolekce odstavců](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParagraphs) textového rámce.
- Vytvořte část.
- Použijte [setEscapement](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#setEscapement) k nastavení hodnoty od -100 do 0 pro dolní index (0 znamená žádný dolní index).
- Nastavte text [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) a přidejte jej do kolekce částí odstavce.
- Uložte prezentaci jako soubor PPTX.

Následující příklad implementuje tyto kroky:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Vytvořte prezentaci.
presentation = Presentation()
try:
    # Získejte snímek.
    slide = presentation.getSlides().get_Item(0)

    # Vytvořte textové pole.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Vytvořte odstavec pro text s horním indexem.
    superscript_paragraph = Paragraph()

    # Vytvořte část s normálním textem.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Vytvořte část s textem v horním indexu.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Vytvořte odstavec pro text s dolním indexem.
    subscript_paragraph = Paragraph()

    # Vytvořte část s normálním textem.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Vytvořte část s textem v dolním indexu.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Přidejte odstavce do textového pole.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Zůstanou horní a dolní indexy zachovány při exportu do PDF nebo jiných formátů?**

Ano, Aspose.Slides správně zachovává formátování horního a dolního indexu při exportu prezentací do PDF, PPT/PPTX, obrázků a dalších podporovaných formátů. Specializované formátování zůstává nedotčené ve všech výstupních souborech.

**Lze horní a dolní index kombinovat s dalšími styly formátování, jako jsou tučné nebo kurzíva?**

Ano, Aspose.Slides umožňuje kombinovat různé textové styly v rámci jedné části textu. Můžete zapnout tučné, kurzívu, podtržení a současně aplikovat horní nebo dolní index nastavením příslušných vlastností v [PortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/).

**Funguje formátování horního a dolního indexu pro text uvnitř tabulek, grafů nebo SmartArt?**

Ano, Aspose.Slides podporuje formátování ve většině objektů, včetně tabulek a prvků grafů. Při práci se SmartArt je třeba získat přístup k příslušným prvkům (například [SmartArtNode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnode/)) a jejich textovým kontejnerům a následně nastavit vlastnosti [PortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/) podobným způsobem.