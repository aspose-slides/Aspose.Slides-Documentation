---
title: Vytváření tvarů čar v prezentacích pomocí Pythonu
linktitle: Čára
type: docs
weight: 50
url: /cs/python-net/line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- jednoduchá čára
- nastavit čáru
- přizpůsobit čáru
- styl čárkování
- hlava šipky
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET. Objevte vlastnosti, metody a příklady."
---
## **Přehled**

Aspose.Slides for Python via .NET podporuje přidávání různých typů tvarů do snímků. V tomto tématu začneme pracovat s tvary přidáváním čar do snímků. Pomocí Aspose.Slides mohou vývojáři nejen vytvářet jednoduché čáry, ale také kreslit na snímcích některé dekorativní čáry.

## **Vytvořit jednoduché čáry**

Pomocí Aspose.Slides přidejte jednoduchou čáru do snímku jako jednoduchý oddělovač nebo spojku. Pro přidání jednoduché čáry do vybraného snímku v prezentaci postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) typu `LINE` pomocí metody `add_auto_shape` na objektu [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/).
1. Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu je do prvního snímku prezentace přidána čára.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Vytvořit čáry ve tvaru šipek**

Aspose.Slides umožňuje nastavit vlastnosti čáry, aby byly vizuálně atraktivnější. Níže nakonfigurujeme několik vlastností čáry tak, aby vypadala jako šipka. Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) typu `LINE` pomocí metody `add_auto_shape` na objektu [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/).
1. Nastavte [styl čáry](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linestyle/).
1. Nastavte šířku čáry.
1. Nastavte [styl čárkování](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linedashstyle/).
1. Nastavte [styl šípky](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linearrowheadstyle/) a délku pro počáteční bod čáry.
1. Nastavte styl šípky a délku pro koncový bod čáry.
1. Uložte prezentaci jako soubor PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Aplikujte formátování na čáru.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu převést běžnou čáru na spojku, aby se „přichytávala“ k tvarům?**

Ne. Běžná čára ( [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) typu [LINE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapetype/) ) se automaticky nepřemění na spojku. Pro přichycení k tvarům použijte speciální typ [Connector](https://reference.aspose.com/slides/cs/python-net/aspose.slides/connector/) a [odpovídající API](/slides/cs/python-net/connector/) pro spojení.

**Co mám dělat, pokud jsou vlastnosti čáry zděděny z motivu a obtížně zjistím konečné hodnoty?**

[Přečtěte si efektivní vlastnosti](/slides/cs/python-net/shape-effective-properties/) pomocí tříd [ILineFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ilinefillformateffectivedata/) . Tyto třídy již zohledňují dědičnost a styly motivu.

**Mohu uzamknout čáru proti úpravám (přesouvání, změně velikosti)?**

Ano. Tvary poskytují [objekty zamykání](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/auto_shape_lock/), které vám umožní [zakázat operace úprav](/slides/cs/python-net/applying-protection-to-presentation/).