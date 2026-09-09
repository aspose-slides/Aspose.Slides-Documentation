---
title: Spravovat Zoom prezentace v Pythonu přes Java
linktitle: Spravovat Zoom
type: docs
weight: 60
url: /cs/python-java/manage-zoom/
keywords:
- zoom
- zoom rámec
- zoom snímku
- zoom sekce
- zoom souhrnu
- přidat zoom
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte Zoom pomocí Aspose.Slides pro Python přes Java — přeskakujte mezi sekcemi, přidávejte náhledy a přechody v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Zoomy v PowerPointu vám umožňují přecházet na konkrétní snímky, sekce a části prezentace a zpět. Při prezentování může být tato možnost rychlé navigace napříč obsahem velmi užitečná.

![overview_image](overview.png)

* Pro shrnutí celé prezentace na jediném snímku použijte [Summary Zoom](#summary-zoom).
* Pro zobrazení jen vybraných snímků použijte [Slide Zoom](#slide-zoom).
* Pro zobrazení jedné sekce použijte [Section Zoom](#section-zoom).

## **Zoom snímku**

Zoom snímku může učinit vaši prezentaci dynamičtější a umožňuje vám volně přecházet mezi snímky v libovolném pořadí, aniž byste přerušovali tok prezentace. Zoomy snímku jsou skvělé pro krátké prezentace bez mnoha sekcí, ale můžete je použít i v různých prezentačních scénářích.

Zoomy snímku vám pomáhají podrobněji prozkoumat více informací, zatímco máte pocit, že pracujete na jedné plátně.

![overview_image](slidezoomsel.png)

Pro objekty zoomu snímku poskytuje Aspose.Slides výčtový typ [ZoomImageType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zoomimagetype/), třídu [ZoomFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zoomframe/) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).

### **Vytvoření zoom rámců**

Můžete přidat zoom rámec na snímek tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vytvořte nové snímky, ke kterým chcete propojit zoom rámce.
3. Přidejte identifikační text a pozadí k vytvořeným snímkům.
4. Přidejte zoom rámce (obsahující odkazy na vytvořené snímky) na první snímek.
5. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Přidá nové snímky do prezentace
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Vytvoří pozadí pro druhý snímek
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Vytvoří textové pole pro druhý snímek
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Vytvoří pozadí pro třetí snímek
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Vytvoří textové pole pro třetí snímek
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Přidá objekty ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Uloží prezentaci
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Vytvoření zoom rámců s vlastními obrázky**

S Aspose.Slides for Python via Java můžete vytvořit zoom rámec s jiným náhledem snímku tímto způsobem:
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vytvořte nový snímek, ke kterému chcete propojit zoom rámec.
3. Přidejte identifikační text a pozadí ke snímku.
4. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) přidáním obrázku do kolekce obrázků spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), který bude použit k vyplnění rámce.
5. Přidejte zoom rámce (obsahující odkaz na vytvořený snímek) na první snímek.
6. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Vytvoří pozadí pro druhý snímek
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Vytvoří textové pole pro druhý snímek
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Vytvoří nový obrázek pro zoom objekt
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Přidá objekt ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Uloží prezentaci
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formátování Zoom rámců**

V předchozích sekcích jsme vám ukázali, jak vytvořit jednoduché zoom rámce. Pro vytvoření složitějších zoom rámců musíte změnit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na zoom rámec použít.

Můžete ovládat formátování zoom rámce na snímku tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vytvořte nové snímky, ke kterým chcete propojit zoom rámce.
3. Přidejte identifikační text a pozadí k vytvořeným snímkům.
4. Přidejte zoom rámce (obsahující odkazy na vytvořené snímky) na první snímek.
5. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) přidáním obrázku do kolekce obrázků spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), který bude použit k vyplnění rámce.
6. Nastavte vlastní obrázek pro první objekt zoom rámce.
7. Změňte formát čáry pro druhý objekt zoom rámce.
8. Odstraňte pozadí z obrázku druhého objektu zoom rámce.
9. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Přidá nové snímky do prezentace
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Vytvoří pozadí pro druhý snímek
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Vytvoří textové pole pro druhý snímek
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Vytvoří pozadí pro třetí snímek
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Vytvoří textové pole pro třetí snímek
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Přidá objekty ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Vytvoří nový obrázek pro zoom objekt
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Nastaví vlastní obrázek pro objekt first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  Nastaví formát zoom rámce pro objekt second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Nastavení pro nezobrazovat pozadí pro objekt second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  Uloží prezentaci
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom sekce**

Zoom sekce je odkaz na sekci ve vaší prezentaci. Můžete použít zoomy sekce k návratu na sekce, které chcete opravdu zdůraznit. Nebo je můžete použít k zvýraznění toho, jak se jednotlivé části vaší prezentace spojují.

![overview_image](seczoomsel.png)

Pro objekty zoomu sekce poskytuje Aspose.Slides třídu [SectionZoomFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectionzoomframe/) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).

### **Vytvoření zoom rámců sekce**

Můžete přidat zoom rámec sekce na snímek tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vytvořte nový snímek.
3. Přidejte výrazné pozadí k vytvořenému snímku.
4. Vytvořte novou sekci, ke které chcete propojit zoom rámec.
5. Přidejte zoom rámec sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 1", slide)

    #  Přidá objekt SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Uloží prezentaci
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Vytvoření zoom rámců sekce s vlastními obrázky**

Pomocí Aspose.Slides for Python via Java můžete vytvořit zoom rámec sekce s jiným náhledem snímku tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vytvořte nový snímek.
3. Přidejte výrazné pozadí k vytvořenému snímku.
4. Vytvořte novou sekci, ke které chcete propojit zoom rámec.
5. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) přidáním obrázku do kolekce obrázků spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), který bude použit k vyplnění rámce.
6. Přidejte zoom rámec sekce (obsahující odkaz na vytvořenou sekci) na první snímek.
7. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 1", slide)

    #  Vytvoří nový obrázek pro zoom objekt
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Přidá objekt SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Uloží prezentaci
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formátování zoom rámců sekce**

Pro vytvoření složitějších zoom rámců sekce musíte změnit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na zoom rámec sekce použít.

Můžete ovládat formátování zoom rámce sekce na snímku tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vytvořte nový snímek.
3. Přidejte výrazné pozadí k vytvořenému snímku.
4. Vytvořte novou sekci, ke které chcete propojit zoom rámec.
5. Přidejte zoom rámec sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6. Změňte velikost a pozici vytvořeného objektu zoom sekce.
7. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) přidáním obrázku do kolekce obrázků spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), který bude použit k vyplnění rámce.
8. Nastavte vlastní obrázek pro vytvořený objekt zoom sekce.
9. Nastavte možnost *návratu na původní snímek z propojené sekce*.
10. Odstraňte pozadí z obrázku objektu zoom sekce.
11. Změňte formát čáry pro objekt zoom sekce.
12. Změňte dobu trvání přechodu.
13. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 1", slide)

    #  Přidá objekt SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Formátování pro SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Uloží prezentaci
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Shrnutí Zoom**

Shrnutí Zoom funguje jako vstupní stránka, kde jsou všechny části vaší prezentace zobrazeny najednou. Když prezentujete, můžete pomocí zoomu přecházet z jednoho místa v prezentaci na jiné v libovolném pořadí. Můžete být kreativní, přeskočit dopředu nebo se vrátit k částem prezentace bez přerušení toku.

![overview_image](sumzoomsel.png)

Pro objekty shrnutí Zoom poskytuje Aspose.Slides třídy [SummaryZoomFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/summaryzoomsection/) a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/summaryzoomsectioncollection/) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).

### **Vytvoření shrnutí Zoom**

Můžete přidat zoom rámec shrnutí na snímek tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vytvořte nové snímky s výrazným pozadím a nové sekce pro vytvořené snímky.
3. Přidejte zoom rámec shrnutí na první snímek.
4. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 1", slide)

    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 2", slide)

    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 3", slide)

    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 4", slide)

    #  Přidá objekt SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Uloží prezentaci
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Přidání a odebrání sekce shrnutí Zoom**

Všechny sekce v zoom rámci shrnutí jsou zastoupeny objekty [SummaryZoomSection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/summaryzoomsection/), které jsou uloženy v objektu [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/summaryzoomsectioncollection/). Můžete přidávat nebo odebírat objekt sekce shrnutí Zoom přes třídu [SummaryZoomSectionCollection] tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vytvořte nové snímky s výrazným pozadím a nové sekce pro vytvořené snímky.
3. Přidejte zoom rámec shrnutí do prvního snímku.
4. Přidejte nový snímek a sekci do prezentace.
5. Přidejte vytvořenou sekci do zoom rámce shrnutí.
6. Odeberte první sekci ze zoom rámce shrnutí.
7. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 1", slide)

    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 2", slide)

    #  Přidá objekt SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Přidá sekci do Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Odebere sekci ze Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Uloží prezentaci
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formátování sekcí shrnutí Zoom**

Pro vytvoření složitějších objektů sekce shrnutí Zoom musíte změnit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na objekt sekce shrnutí Zoom použít.

Můžete ovládat formátování objektu sekce shrnutí Zoom v zoom rámci tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vytvořte nové snímky s výrazným pozadím a nové sekce pro vytvořené snímky.
3. Přidejte zoom rámec shrnutí na první snímek.
4. Získejte první objekt sekce shrnutí Zoom z [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/summaryzoomsectioncollection/).
5. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) přidáním obrázku do kolekce obrázků spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), který bude použit k vyplnění rámce.
6. Nastavte vlastní obrázek pro objekt sekce shrnutí Zoom.
7. Nastavte možnost *návratu na původní snímek z propojené sekce*.
8. Změňte formát čáry pro objekt sekce shrnutí Zoom.
9. Změňte dobu trvání přechodu.
10. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 1", slide)

    # Přidá nový snímek do prezentace
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Přidá novou sekci do prezentace
    presentation.getSections().addSection("Section 2", slide)

    #  Přidá objekt SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Získá první objekt SummaryZoomSection
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Formátování pro objekt SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Uloží prezentaci
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu ovládat návrat na „rodičovský“ snímek po zobrazení cíle?**

Ano. [ZoomFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zoomframe/) nebo [SectionZoomFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectionzoomframe/) podporují návrat na původní snímek pomocí [setReturnToParent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zoomobject/#setReturnToParent), což po povolení po návštěvě cílového obsahu vrací diváky zpět.

**Mohu upravit „rychlost“ nebo dobu trvání přechodu Zoom?**

Ano. Zoom umožňuje nastavit dobu trvání přechodu pomocí [setTransitionDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zoomobject/#setTransitionDuration), takže můžete řídit, jak dlouho trvá animace skoku.

**Existují omezení, kolik objektů Zoom může prezentace obsahovat?**

Neexistuje pevně daný limit API, který by byl dokumentován. Praktická omezení závisí na celkové složitosti prezentace a výkonu prohlížeče. Můžete přidat mnoho zoom rámců, ale zvažte velikost souboru a dobu renderování.