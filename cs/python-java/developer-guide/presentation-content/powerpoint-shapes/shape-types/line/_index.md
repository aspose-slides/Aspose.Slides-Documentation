---
title: Přidání čárových tvarů do prezentací v Pythonu přes Java
linktitle: Čára
type: docs
weight: 50
url: /cs/python-java/line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- jednoduchá čára
- nastavit čáru
- upravit čáru
- styl čáry
- hlava šipky
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes Java. Objevte vlastnosti, metody a příklady."
---
## **Přehled**

Aspose.Slides umožňuje programově přidávat čarové tvary do snímků PowerPointu. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak přizpůsobit čáru tak, aby vypadala jako šipka.

Dozvíte se, jak přidat čáru do snímku, upravit její vizuální vzhled a uložit aktualizovanou prezentaci. Příklady se zaměřují na praktická nastavení formátování čáry, jako jsou styl, šířka, vzor čáry, možnosti šipky a barva výplně.

## **Vytvoření jednoduché čáry**

Chcete-li přidat jednoduchou čáru do vybraného snímku prezentace, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Získejte odkaz na snímek podle jeho indexu.
- Přidejte čarový tvar pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape) objektu [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).
- Zapište upravenou prezentaci jako soubor PPTX.

Následující příklad přidá čáru na první snímek prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte čárový tvar.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Uložte soubor PPTX na disk.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vytvoření čáry ve tvaru šipky**

Aspose.Slides for Python via Java také umožňuje vývojářům konfigurovat vlastnosti čáry tak, aby vypadala atraktivněji. Chcete-li nastavit čáru tak, aby vypadala jako šipka, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Získejte odkaz na snímek podle jeho indexu.
- Přidejte čarový tvar pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape) objektu [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).
- Nastavte [line style](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linestyle/) na jeden ze stylů nabízených Aspose.Slides for Python via Java.
- Nastavte šířku čáry.
- Nastavte [dash style](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linedashstyle/) na jeden ze stylů nabízených Aspose.Slides for Python via Java.
- Nastavte [arrowhead style](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linearrowheadstyle/) a [length](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linearrowheadlength/) na začátku čáry.
- Nastavte [arrowhead style](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linearrowheadstyle/) a [length](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linearrowheadlength/) na konci čáry.
- Zapište upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte čárový tvar.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Použijte formátování na čáru.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Uložte soubor PPTX na disk.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu převést běžnou čáru na spojovací prvek, aby se „přichytával“ k objektům?**

Ne. Běžná čára ([AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/)) se automaticky nestane spojovacím prvkem. Chcete-li, aby se přichytávala k objektům, použijte speciální typ [Connector](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connector/) a [corresponding APIs](/slides/cs/python-java/connector/) pro spojení.

**Co mám dělat, pokud jsou vlastnosti čáry děděny z motivu a je obtížné určit konečné hodnoty?**

Přečtěte si [efektivní vlastnosti](/slides/cs/python-java/shape-effective-properties/) čáry a její výplně – tyto již zohledňují dědičnost a styly motivu.

**Mohu uzamknout čáru proti úpravám (posunu, změně velikosti)?**

Ano. Tvary poskytují [objekty uzamčení](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#getAutoShapeLock), které vám umožňují [zakázat operace úprav](/slides/cs/python-java/applying-protection-to-presentation/).