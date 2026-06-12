---
title: Dia‑indelingen toepassen of wijzigen in Python
linktitle: Dia‑indeling
type: docs
weight: 60
url: /nl/python-net/slide-layout/
keywords:
- dia‑indeling
- inhoudsindeling
- plaatshouder
- presentatie‑ontwerp
- dia‑ontwerp
- ongebruikte indeling
- voettekst‑zichtbaarheid
- titel‑dia
- titel en inhoud
- sectiekop
- twee inhoud
- vergelijking
- alleen titel
- lege indeling
- inhoud met bijschrift
- afbeelding met bijschrift
- titel en verticale tekst
- verticale titel en tekst
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Leer hoe u dia‑indelingen beheert en aanpast in Aspose.Slides voor Python via .NET. Ontdek indelingstypen, beheer van plaatshouders, voettekst‑zichtbaarheid en het manipuleren van indelingen aan de hand van code‑voorbeelden in Python."
---
## **Inleiding**

Een dia‑indeling definieert de rangschikking van plaatshouder‑vakken en de opmaak van de inhoud op een dia. Het bepaalt welke plaatshouders beschikbaar zijn en waar ze verschijnen. Dia‑indelingen helpen u presentaties snel en consistent te ontwerpen—of u nu iets eenvoudigs of complexere maakt. Enkele van de meest voorkomende dia‑indelingen in PowerPoint zijn:

**Titel‑dia‑indeling** – Bevat twee tekst‑plaatshouders: één voor de titel en één voor de ondertitel.

**Titel‑en‑inhoud‑indeling** – Heeft een kleiner titel‑plaatshouder bovenaan en een grotere eronder voor de hoofdinhoud (zoals tekst, opsommingstekens, grafieken, afbeeldingen en meer).

**Lege indeling** – Bevat geen plaatshouders, waardoor u volledige controle heeft om de dia vanaf nul te ontwerpen.

Dia‑indelingen maken deel uit van een dia‑master, die de bovenliggende dia is die indelingsstijlen voor de presentatie definieert. U kunt indelingsdia’s benaderen en aanpassen via de dia‑master—op type, naam of unieke ID. Alternatief kunt u een specifieke indelingsdia rechtstreeks in de presentatie bewerken.

Om met dia‑indelingen te werken in Aspose.Slides for Python, kunt u gebruiken:

- Eigenschappen zoals [layout_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/layout_slides/) en [masters](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/masters/) onder de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse
- Types zoals [LayoutSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/) en [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Om meer te leren over het werken met master‑dia’s, bekijk het artikel [Beheer PowerPoint‑dia‑masters in Python](/slides/nl/python-net/slide-master/).
{{% /alert %}}

## **Dia‑indelingen toevoegen aan presentaties**

Om het uiterlijk en de structuur van uw dia’s aan te passen, moet u mogelijk nieuwe indelingsdia’s aan een presentatie toevoegen. Aspose.Slides for Python maakt het mogelijk te controleren of een bepaalde indeling al bestaat, een nieuwe toe te voegen indien nodig, en deze te gebruiken om dia’s in te voegen op basis van die indeling.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Open de [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterlayoutslidecollection/).
1. Controleer of de gewenste indelingsdia al bestaat in de collectie. Zo niet, voeg dan de benodigde indelingsdia toe.
1. Voeg een lege dia toe op basis van de nieuwe indelingsdia.
1. Sla de presentatie op.

De volgende Python‑code laat zien hoe u een dia‑indeling toevoegt aan een PowerPoint‑presentatie:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse om het presentatie-bestand te openen.
with slides.Presentation("sample.pptx") as presentation:
    # Doorloop de verschillende layout-dia-typen om een layout-dia te selecteren.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Een situatie waarbij de presentatie niet alle layout-typen bevat.
        # Het presentatie-bestand bevat alleen lege en aangepaste layout-typen.
        # Layout-dia’s met aangepaste typen kunnen echter herkenbare namen hebben,
        # zoals "Title", "Title and Content", enz., die gebruikt kunnen worden voor het selecteren van een layout-dia.
        # U kunt ook vertrouwen op een set van plaatshouder-vormtypen.
        # Bijvoorbeeld, een titel-dia zou alleen het titel-plaatshoudertype moeten hebben, enzovoort.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Voeg een lege dia toe met behulp van de toegevoegde layout-dia.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Sla de presentatie op naar schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ongebruikte indelingsdia’s verwijderen**

Aspose.Slides biedt de [remove_unused_layout_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/)‑methode van de [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/)‑klasse om ongewenste en ongebruikte indelingsdia’s te verwijderen.

De volgende Python‑code toont hoe u een indelingsdia uit een PowerPoint‑presentatie verwijdert:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Plaatshouders toevoegen aan dia‑indelingen**

Aspose.Slides biedt de eigenschap [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/placeholder_manager/), waarmee u nieuwe plaatshouders aan een indelingsdia kunt toevoegen.

Deze manager bevat methoden voor de volgende plaatshouder‑typen:

| PowerPoint‑plaatshouder               | [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/)‑methode |
| ------------------------------------- | ------------------------------------------------------------ |
| ![Inhoud](content.png)                | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Inhoud (Verticaal)](contentV.png)   | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Tekst](text.png)                    | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Tekst (Verticaal)](textV.png)       | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Afbeelding](picture.png)            | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Grafiek](chart.png)                 | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Tabel](table.png)                   | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png)             | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png)                   | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online‑afbeelding](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

De volgende Python‑code laat zien hoe u nieuwe plaatshouder‑vormen toevoegt aan de **Lege indeling**‑dia:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Haal de lege indelingsdia op.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Haal de plaatshoudermanager van de indelingsdia op.
    placeholder_manager = layout.placeholder_manager

    # Voeg verschillende plaatshouders toe aan de lege indelingsdia.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Voeg een nieuwe dia toe met de lege indeling.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De plaatshouders op de indelingsdia](add_placeholders.png)

## **Voettekst‑zichtbaarheid instellen voor een indelingsdia**

In PowerPoint‑presentaties kunnen voettekst‑elementen zoals datum, dia‑nummer en aangepaste tekst worden getoond of verborgen afhankelijk van de dia‑indeling. Aspose.Slides for Python stelt u in staat de zichtbaarheid van deze voettekst‑plaatshouders te regelen. Dit is handig wanneer u bepaalde indelingen wilt laten zien met voettekstinformatie en andere juist minimalistisch wilt houden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een indelingsdia op via de index.
1. Zet de voettekst‑plaatshouder van de dia op zichtbaar.
1. Zet de dia‑nummer‑plaatshouder op zichtbaar.
1. Zet de datum‑tijd‑plaatshouder op zichtbaar.
1. Sla de presentatie op.

De volgende Python‑code toont hoe u de zichtbaarheid van een dia‑voettekst instelt en gerelateerde taken uitvoert:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Kind‑voettekst‑zichtbaarheid instellen voor een dia**

In PowerPoint‑presentaties kunnen voettekst‑elementen zoals datum, dia‑nummer en aangepaste tekst worden beheerd op het niveau van de master‑dia om consistentie over alle indelingsdia’s te waarborgen. Aspose.Slides for Python stelt u in staat de zichtbaarheid en inhoud van deze voettekst‑plaatshouders op de master‑dia in te stellen en deze instellingen door te geven aan alle onderliggende indelingsdia’s. Deze aanpak zorgt voor uniforme voettekstinformatie in de hele presentatie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar de master‑dia op via de index.
1. Zet de master‑ en alle kind‑voettekst‑plaatshouders op zichtbaar.
1. Zet de master‑ en alle kind‑dia‑nummer‑plaatshouders op zichtbaar.
1. Zet de master‑ en alle kind‑datum‑tijd‑plaatshouders op zichtbaar.
1. Sla de presentatie op.

De volgende Python‑code demonstreert deze bewerking:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wat is het verschil tussen een master‑dia en een indelingsdia?**

Een master‑dia bepaalt het algemene thema en de standaardopmaak, terwijl indelingsdia’s specifieke rangschikkingen van plaatshouders voor verschillende soorten inhoud definiëren.

**Kan ik een indelingsdia van de ene presentatie naar de andere kopiëren?**

Ja, u kunt een indelingsdia klonen vanuit de [layout_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/layout_slides/)‑collectie van een presentatie en deze met de `add_clone`‑methode in een andere invoegen.

**Wat gebeurt er als ik een indelingsdia verwijder die nog door een dia wordt gebruikt?**

Als u probeert een indelingsdia te verwijderen die nog minstens door één dia in de presentatie wordt gerefereerd, zal Aspose.Slides een [PptxEditException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxeditexception/) gooien. Gebruik in dat geval [remove_unused_layout_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) om veilig alleen ongebruikte indelingsdia’s te verwijderen.