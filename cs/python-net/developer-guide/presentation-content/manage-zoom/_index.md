---
title: "Spravujte zoomy v prezentacích pomocí Pythonu"
linktitle: "Zoom"
type: docs
weight: 60
url: /cs/python-net/manage-zoom/
keywords:
- zoom
- zoomový rámec
- zoom snímku
- zoom sekce
- zoom shrnutí
- přidat zoom
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte a přizpůsobte Zoom pomocí Aspose.Slides pro Python přes .NET — přecházejte mezi sekcemi, přidávejte náhledy a přechody v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Zoomy v PowerPointu vám umožňují přecházet na konkrétní snímky, sekce a části prezentace a zpět. Při prezentaci může být tato schopnost rychle se orientovat v obsahu velmi užitečná. 

![přehled](overview.png)

* Pro shrnutí celé prezentace na jediném snímku použijte [Summary Zoom](#Summary-Zoom).
* Pro zobrazení pouze vybraných snímků použijte [Slide Zoom](#Slide-Zoom).
* Pro zobrazení jedné sekce použijte [Section Zoom](#Section-Zoom).

## **Zoom snímku**

Zoom snímku může učinit vaši prezentaci dynamičtější, umožňuje vám volně přecházet mezi snímky v libovolném pořadí, aniž byste přerušili tok prezentace. Zoomy snímků jsou skvělé pro krátké prezentace bez mnoha sekcí, ale můžete je použít i v různých prezentačních scénářích.

Zoomy snímků vám pomáhají pronikat do více informací, jako byste byli na jediném plátně. 

![výběr zoomu snímku](slidezoomsel.png)

Pro objekty zoomu snímku poskytuje Aspose.Slides výčtový typ [ZoomImageType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/zoomimagetype/), třídu [ZoomFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/zoomframe/) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/).

### **Vytváření zoom rámců**
Zoomový rámec můžete na snímek přidat takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2.	Vytvořte nové snímky, na které chcete odkazovat. 
3.	Přidejte identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoomové rámy (obsahující odkazy na vytvořené snímky) do prvního snímku.
5.	Uložte upravenou prezentaci jako soubor PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Přidejte nové snímky do prezentace
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Vytvořte pozadí pro druhý snímek
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Vytvořte textové pole pro druhý snímek
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Vytvořte pozadí pro třetí snímek
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Vytvořte textové pole pro třetí snímek
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Přidejte objekty ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Uložte prezentaci
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Vytváření zoom rámců s vlastními obrázky**
S Aspose.Slides for Python via .NET můžete vytvořit zoomový rámec s obrázkem jiným než náhledovým obrázkem snímku takto: 
1.	Vytvořte instanci třídy `Presentation` .
2.	Vytvořte nový snímek, na který chcete odkazovat. 
3.	Přidejte identifikační text a pozadí k vytvořenému snímku.
4.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) přidáním obrázku do kolekce Images spojené s objektem Presentation, který bude použit k vyplnění rámce.
5.	Přidejte zoomové rámy (obsahující odkaz na vytvořený snímek) do prvního snímku.
6.	Uložte upravenou prezentaci jako soubor PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Přidejte nový snímek do prezentace
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Vytvořte pozadí pro druhý snímek
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Vytvořte textové pole pro třetí snímek
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Vytvořte nový obrázek pro objekt zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Přidejte objekt ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Uložte prezentaci
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formátování zoom rámců**
V předchozích částech (výše) jsme vám ukázali, jak vytvořit jednoduché zoomové rámy. Pro vytvoření složitějších zoomových rámců musíte upravit formátování rámců. Existuje několik nastavení formátování, která můžete na zoomový rámec použít. 

Formátování zoomového rámce na snímku můžete řídit takto:

1.	Vytvořte instanci třídy `Presentation` .
2.	Vytvořte nové snímky, na které chcete odkazovat.
3.	Přidejte identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoomové rámy (obsahující odkazy na vytvořené snímky) do prvního snímku.
5.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) přidáním obrázku do kolekce Images spojené s objektem Presentation, který bude použit k vyplnění rámce.
6.	Nastavte vlastní obrázek pro první objekt zoomového rámce.
7.	Změňte formát čáry pro druhý objekt zoomového rámce.
8.	Odstraňte pozadí z obrázku druhého objektu zoomového rámce.
5.	Uložte upravenou prezentaci jako soubor PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Přidejte nové snímky do prezentace
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Vytvořte pozadí pro druhý snímek
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Vytvořte textové pole pro druhý snímek
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Vytvořte pozadí pro třetí snímek
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Vytvořte textové pole pro třetí snímek
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Přidejte objekty ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Vytvořte nový obrázek pro objekt zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Nastavte vlastní obrázek pro objekt zoomFrame1
    zoomFrame1.image = image

    # Nastavte formát zoom rámce pro objekt zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Nezobrazujte pozadí pro objekt zoomFrame2
    zoomFrame2.show_background = False

    # Uložte prezentaci
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom sekce**

Zoom sekce je odkaz na sekci ve vaší prezentaci. Můžete použít zoomy sekcí k návratu na sekce, které chcete opravdu zdůraznit. Nebo je můžete použít k vyzdvižení toho, jak určité části prezentace spolu souvisejí. 

![výběr zoomu sekce](seczoomsel.png)

Pro objekty zoomu sekce poskytuje Aspose.Slides třídu [SectionZoomFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectionzoomframe/) a některé metody pod třídou [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/).

### **Vytváření zoom rámců sekce**

Zoomový rámec sekce můžete na snímek přidat takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2.	Vytvořte nový snímek. 
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, na kterou chcete odkazovat zoomový rámec. 
5.	Přidejte zoomový rámec sekce (obsahující odkazy na vytvořenou sekci) do prvního snímku.
6.	Uložte upravenou prezentaci jako soubor PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Přidá nový snímek do prezentace
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Přidá novou sekci do prezentace
    pres.sections.add_section("Section 1", slide)

    # Přidá objekt SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Uloží prezentaci
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Vytváření zoom rámců sekce s vlastními obrázky**

S Aspose.Slides for Python můžete vytvořit zoomový rámec sekce s jiným náhledovým obrázkem snímku takto: 

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, na kterou chcete odkazovat zoomový rámec. 
5.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) , který bude použit k vyplnění rámce.
6.	Přidejte zoomový rámec sekce (obsahující odkaz na vytvořenou sekci) do prvního snímku.
7.	Uložte upravenou prezentaci jako soubor PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Přidá nový snímek do prezentace
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Přidá novou sekci do prezentace
    pres.sections.add_section("Section 1", slide)

    # Vytvoří nový obrázek pro zoom objekt
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Přidá objekt SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Uloží prezentaci
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formátování zoom rámců sekce**

Pro vytvoření složitějších zoomových rámců sekce musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na zoomový rámec sekce použít. 

Formátování zoomového rámce sekce na snímku můžete řídit takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, na kterou chcete odkazovat zoomový rámec. 
5.	Přidejte zoomový rámec sekce (obsahující odkazy na vytvořenou sekci) do prvního snímku.
6.	Změňte velikost a umístění vytvořeného objektu zoom sekce.
7.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) , který bude použit k vyplnění rámce.
8.	Nastavte vlastní obrázek pro vytvořený objekt zoom sekce.
9.	Nastavte schopnost *návratu na původní snímek z propojené sekce*. 
10.	Odstraňte pozadí z obrázku objektu zoom sekce.
11.	Změňte formát čáry pro druhý objekt zoomového rámce.
12.	Změňte dobu trvání přechodu.
13.	Uložte upravenou prezentaci jako soubor PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Přidá nový snímek do prezentace
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Přidá novou sekci do prezentace
    pres.sections.add_section("Section 1", slide)

    # Přidá objekt SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formátování pro SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Uloží prezentaci
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Shrnutí Zoom**

Shrnutí Zoom je jako vstupní stránka, kde jsou najednou zobrazeny všechny části vaší prezentace. Při prezentaci můžete použít zoom k přesunu z jednoho místa prezentace na jiné v libovolném pořadí. Můžete být kreativní, přeskočit dopředu nebo se vrátit k částem prezentace, aniž byste přerušili její tok.

![přehled_obrázek](summaryzoom.png)

Pro objekty shrnutí Zoom poskytuje Aspose.Slides třídy [SummaryZoomFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/summaryzoomsection/) a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/summaryzoomsectioncollection/) a některé metody pod třídou [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/).

### **Vytváření shrnutí Zoom**

Shrnutí Zoom můžete na snímek přidat takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2.	Vytvořte nové snímky s identifikačním pozadím a nové sekce pro vytvořené snímky.
3.	Přidejte shrnutí Zoom rámec do prvního snímku.
4.	Uložte upravenou prezentaci jako soubor PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Vytvoří pole snímků
    for slideNumber in range(5):
        #Přidá nové snímky do prezentace
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Vytvoří pozadí pro snímek
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Vytvoří textové pole pro snímek
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Vytvoří zoom objekty pro všechny snímky v prvním snímku
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Nastaví vlastnost ReturnToParent pro návrat na první snímek
        zoomFrame.return_to_parent = True

    # Uloží prezentaci
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Přidávání a odebírání sekcí shrnutí Zoom**

Všechny sekce v rámci shrnutí Zoom jsou reprezentovány objekty [SummaryZoomSection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/summaryzoomsection/), které jsou uloženy v objektu [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/summaryzoomsectioncollection/). Sekci shrnutí Zoom můžete přidat nebo odebrat pomocí třídy [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/summaryzoomsectioncollection/) takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2.	Vytvořte nové snímky s identifikačním pozadím a nové sekce pro vytvořené snímky.
3.	Přidejte shrnutí Zoom rámec do prvního snímku.
4.	Přidejte nový snímek a sekci do prezentace.
5.	Přidejte vytvořenou sekci do rámce shrnutí Zoom.
6.	Odeberte první sekci z rámce shrnutí Zoom.
7.	Uložte upravenou prezentaci jako soubor PPTX.

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Přidá nový snímek do prezentace
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Přidá novou sekci do prezentace
    pres.sections.add_section("Section 1", slide)

    #Přidá nový snímek do prezentace
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Přidá novou sekci do prezentace
    pres.sections.add_section("Section 2", slide)

    # Přidá objekt SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Přidá nový snímek do prezentace
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Přidá novou sekci do prezentace
    section3 = pres.sections.add_section("Section 3", slide)

    # Přidá sekci do Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Odebere sekci ze Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Uloží prezentaci
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formátování sekcí shrnutí Zoom**

Pro vytvoření složitějších objektů sekce shrnutí Zoom musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na objekt sekce shrnutí Zoom použít. 

Formátování objektu sekce shrnutí Zoom v rámci shrnutí Zoom můžete řídit takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2.	Vytvořte nové snímky s identifikačním pozadím a nové sekce pro vytvořené snímky.
3.	Přidejte shrnutí Zoom rámec do prvního snímku.
4.	Získejte objekt sekce shrnutí Zoom pro první objekt z `SummaryZoomSectionCollection`.
5.	Vytvořte objekt `PPImage` přidáním obrázku do kolekce images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) , který bude použit k vyplnění rámce.
6.	Nastavte vlastní obrázek pro vytvořený objekt zoom sekce.
7.	Nastavte schopnost *návratu na původní snímek z propojené sekce*. 
8.	Změňte formát čáry pro druhý objekt zoomového rámce.
9.	Změňte dobu trvání přechodu.
10.	Uložte upravenou prezentaci jako soubor PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Přidá nový snímek do prezentace
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Přidá novou sekci do prezentace
    pres.sections.add_section("Section 1", slide)

    #Přidá nový snímek do prezentace
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Přidá novou sekci do prezentace
    pres.sections.add_section("Section 2", slide)

    # Přidá objekt SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Získá první objekt SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formátování pro objekt SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Uloží prezentaci
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu ovládat návrat na 'rodičovský' snímek po zobrazení cíle?**

Ano. [Zoom frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/zoomframe/) nebo [section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectionzoomframe/) má chování `return_to_parent`, které při povolení vrátí diváky zpět na výchozí snímek po návštěvě cílového obsahu.

**Mohu upravit 'rychlost' nebo dobu trvání přechodu Zoom?**

Ano. Zoom umožňuje nastavit `transition_duration`, takže můžete řídit, jak dlouho trvá animace přechodu.

**Existují omezení počtu Zoom objektů, které může prezentace obsahovat?**

Neexistuje pevně daný limit API. Praktická omezení závisí na celkové komplexnosti prezentace a výkonu prohlížeče. Můžete přidat mnoho Zoom rámců, ale zvažte velikost souboru a čas renderování.