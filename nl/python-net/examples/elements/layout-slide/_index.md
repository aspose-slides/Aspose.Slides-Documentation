---
title: Layoutdia
type: docs
weight: 20
url: /nl/python-net/examples/elements/layout-slide/
keywords:
- layoutdia
- layoutdia toevoegen
- layoutdia benaderen
- layoutdia verwijderen
- ongebruikte layoutdia
- layoutdia klonen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Gebruik Python om layoutdia's te beheren met Aspose.Slides: maak, pas toe, kloon, hernoem en pas plaatshouders en thema's aan in presentaties voor PPT, PPTX en ODP."
---
Dit artikel laat zien hoe u kunt werken met **Layout Slides** in Aspose.Slides voor Python via .NET. Een layout‑slide definieert het ontwerp en de opmaak die normale slides erven. U kunt layout‑slides toevoegen, benaderen, klonen en verwijderen, en ongebruikte opschonen om de grootte van de presentatie te verkleinen.

## **Een layout slide toevoegen**

U kunt een aangepaste layout‑slide maken om herbruikbare opmaak te definiëren.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Maak een layoutdia met het opgegeven type en de naam.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Layout‑slides fungeren als sjablonen voor individuele slides. U kunt gemeenschappelijke elementen één keer definiëren en ze hergebruiken in veel slides.

> 💡 **Tip 2:** Wanneer u vormen of tekst toevoegt aan een layout‑slide, zullen alle slides die op die layout zijn gebaseerd automatisch deze gedeelde inhoud tonen.  
> De screenshot hieronder toont twee slides, elk een tekstvak erft van dezelfde layout‑slide.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Een layout slide benaderen**

Layout‑slides kunnen benaderd worden via een index of via het layout‑type (bijv. `Blank`, `Title`, `SectionHeader`, enz.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Toegang via index.
        first_layout_slide = presentation.layout_slides[0]

        # Toegang via layouttype.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Een layout slide verwijderen**

U kunt een specifieke layout‑slide verwijderen als deze niet meer nodig is.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Haal een layoutdia op basis van type en verwijder deze.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ongebruikte layout slides verwijderen**

Om de grootte van de presentatie te verkleinen, wilt u mogelijk layout‑slides verwijderen die door geen enkele normale slide worden gebruikt.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Verwijdert automatisch alle layoutdia's die niet door een slide worden gebruikt.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Een layout slide klonen**

U kunt een layout‑slide dupliceren met de `AddClone`‑methode.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Haal een bestaande layoutdia op basis van type.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Kloon de layoutdia naar het einde van de collectie van layoutdia's.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Samenvatting:** Layout‑slides zijn krachtige hulpmiddelen voor het beheren van consistente opmaak over slides heen. Aspose.Slides biedt volledige controle over het maken, beheren en optimaliseren van layout‑slides.