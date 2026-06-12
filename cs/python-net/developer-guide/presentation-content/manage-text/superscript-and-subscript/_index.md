---
title: Správa horního a dolního indexu v Pythonu
linktitle: Horní a dolní index
type: docs
weight: 80
url: /cs/python-net/superscript-and-subscript/
keywords:
- horní index
- dolní index
- přidat horní index
- přidat dolní index
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Ovládněte horní a dolní index v Aspose.Slides pro Python prostřednictvím .NET a posuňte své prezentace s profesionálním formátováním textu pro maximální dopad."
---
## **Přehled**

Aspose.Slides poskytuje funkce pro vkládání textu s horním a dolním indexem do vašich prezentací PowerPoint (PPT, PPTX) a OpenDocument (ODP). Ať už potřebujete zvýraznit chemické vzorce, matematické rovnice nebo anotovat obsah poznámkami pod čarou, tyto specializované možnosti formátování pomáhají zachovat srozumitelnost a přesnost. V tomto článku se naučíte, jak plynule použít styly horního a dolního indexu a zajistit profesionální výsledky na každém snímku.

## **Přidání textu s horním a dolním indexem**

Můžete přidat text s horním a dolním indexem do libovolné části odstavce. V Aspose.Slides použijte vlastnost `escapement` třídy [PortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/), abyste to ovládali.

`escapement` je procento v rozmezí **-100% až 100%**:

- **> 0** → horní index (např. 25% = mírné zvýšení; 100% = plný horní index)
- **0** → základní řád (žádný horní/dolní index)
- **< 0** → dolní index (např. -25% = mírné snížení; -100% = plný dolní index)

Kroky:

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a získejte snímek.
2. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) a přistupte k jeho [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
3. Vymažte existující odstavce.
4. Pro horní index: vytvořte odstavec a část, nastavte `portion.portion_format.escapement` na hodnotu mezi **0 a 100**, nastavte text a přidejte část.
5. Pro dolní index: vytvořte další odstavec a část, nastavte `escapement` na hodnotu mezi **-100 a 0**, nastavte text a přidejte část.
6. Uložte prezentaci jako PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Získat snímek.
    slide = presentation.slides[0]

    # Vytvořit textové pole.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Vytvořit odstavec pro text s horním indexem.
    superscript_paragraph = slides.Paragraph()

    # Vytvořit textovou část s běžným textem.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Vytvořit textovou část s horním indexem.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Vytvořit odstavec pro text s dolním indexem.
    subscript_paragraph = slides.Paragraph()

    # Vytvořit textovou část s běžným textem.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Vytvořit textovou část s dolním indexem.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Přidat odstavce do textového pole.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu použít horní/dolní index v tabulkách a dalších kontejnerech, nejen v běžných textových polích?**

Ano. Můžete formátovat text jako horní nebo dolní index uvnitř libovolného objektu, který poskytuje [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) (včetně buněk tabulky). Formátování se vztahuje na textové části v rámci tohoto rámce.

**Zůstanou horní a dolní indexy zachovány při exportu do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides zachovává formátování horního a dolního indexu při exportu do běžných formátů, jako jsou [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/cs/python-net/convert-powerpoint-to-html/) a [rastrové obrázky](/slides/cs/python-net/convert-powerpoint-to-png/), protože vykreslovací pipeline respektuje formátování textu na úrovni částí.

**Mohu kombinovat horní/dolní index s hypertextovými odkazy ve stejném textovém fragmentu?**

Ano. [Hyperlinky](/slides/cs/python-net/manage-hyperlinks/) jsou přiřazeny na úrovni části (fragmentu), takže část může mít současně hypertextový odkaz a být formátována jako horní nebo dolní index.