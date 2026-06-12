---
title: Přidání elips do prezentací v Pythonu
linktitle: Elipsa
type: docs
weight: 30
url: /cs/python-net/ellipse/
keywords:
- elipsa
- tvar
- přidat elipsu
- vytvořit elipsu
- kreslit elipsu
- formátovaná elipsa
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se vytvářet, formátovat a manipulovat s elipsovými tvary v Aspose.Slides pro Python via .NET v prezentacích PPT, PPTX a ODP — včetně ukázkového kódu."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat elipsové tvary do snímků PowerPointu. Popisuje vytvoření jednoduché elipsy, vytvoření formátované elipsy a uložení aktualizované prezentace jako souboru PPTX. Také se dotýká souvisejících otázek, jako je práce s polohou a velikostí elipsy, ovládání pořadí vrstev a aplikace animačních efektů.

## **Vytvoření elipsy**
V tomto tématu představíme vývojářům, jak přidávat elipsové tvary do svých snímků pomocí Aspose.Slides pro Python via .NET. Aspose.Slides pro Python via .NET poskytuje jednodušší sadu API pro kreslení různých typů tvarů pomocí několika řádků kódu. Pro přidání jednoduché elipsy do vybraného snímku prezentace postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/)class
1. Získejte odkaz na snímek pomocí jeho Indexu
1. Přidejte AutoShape typu Ellipse pomocí metody AddAutoShape, kterou poskytuje objekt IShapes
1. Uložte upravenou prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme přidali elipsu na první snímek.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX
with slides.Presentation() as pres:
    # Získat první snímek
    sld = pres.slides[0]

    # Přidat automatický tvar typu elipsa
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Zapsat soubor PPTX na disk
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Vytvoření formátované elipsy**
Pro přidání lépe formátované elipsy na snímek postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/)class.
1. Získejte odkaz na snímek pomocí jeho Indexu.
1. Přidejte AutoShape typu Ellipse pomocí metody AddAutoShape, kterou poskytuje objekt IShapes.
1. Nastavte typ výplně elipsy na Solid.
1. Nastavte barvu elipsy pomocí vlastnosti SolidFillColor.Color, kterou poskytuje objekt FillFormat spojený s objektem IShape.
1. Nastavte barvu čar elipsy.
1. Nastavte šířku čar elipsy.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali formátovanou elipsu na první snímek prezentace.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX
with slides.Presentation() as pres:
    # Získat první snímek
    sld = pres.slides[0]

    # Přidat automatický tvar typu elipsa
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Použít nějaké formátování na tvar elipsy
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Použít nějaké formátování na čáru elipsy
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Zapsat soubor PPTX na disk
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jak nastavit přesnou polohu a velikost elipsy vzhledem k jednotkám snímku?**

Souřadnice a rozměry jsou obvykle specifikovány **v bodech**. Pro předvídatelné výsledky provádějte výpočty na základě velikosti snímku a před přiřazením hodnot převádějte požadované milimetry nebo palce na body.

**Jak mohu umístit elipsu nad nebo pod jiné objekty (ovládání pořadí vrstev)?**

Upravte pořadí kreslení objektu tak, že jej přenesete dopředu nebo dozadu. To umožní, aby elipsa překrývala jiné objekty nebo odhalovala ty pod ní.

**Jak animovat vzhled nebo zdůraznění elipsy?**

[Apply](/slides/cs/python-net/shape-animation/) vstupní, důrazové nebo odcházející efekty na tvar a nakonfigurujte spouštěče a časování, aby bylo určeno, kdy a jak se animace přehrává.