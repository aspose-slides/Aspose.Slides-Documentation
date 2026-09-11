---
title: Specificeer Standaardlettertypen voor Presentaties in Python via Java
linktitle: Standaardlettertype
type: docs
weight: 30
url: /nl/python-java/default-font/
keywords:
- standaardlettertype
- regulier lettertype
- normaal lettertype
- Aziatisch lettertype
- PDF-export
- XPS-export
- afbeeldingsexport
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Standaardlettertypen instellen in Aspose.Slides voor Python via Java om een correcte conversie van PowerPoint (PPT, PPTX) en OpenDocument (ODP) naar PDF, XPS en afbeeldingen te garanderen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om standaardlettertypen op te geven die worden gebruikt wanneer een presentatie wordt gerenderd. Dit is handig bij het genereren van diavoorbeeldminiaturen of bij het exporteren van een presentatie naar formaten zoals PDF en XPS. Standaardlettertypen worden geconfigureerd via [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/) vóór het laden van de presentatie.

De [setDefaultRegularFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) methode definieert het standaardlettertype voor gewone tekst, terwijl de [setDefaultAsianFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) het standaardlettertype voor Aziatische tekst bepaalt. Nadat deze opties zijn ingesteld, kan de presentatie worden geladen en gerenderd met de opgegeven lettertypen.

## **Standaardlettertypen gebruiken voor het renderen van een presentatie**

Aspose.Slides stelt u in staat om standaardlettertypen in te stellen voor het renderen van een presentatie naar PDF, XPS of miniaturen. Deze sectie toont hoe u standaardlettertypen voor gewone en Aziatische tekst definieert met Aspose.Slides voor Python via Java:

1. Maak een instantie van [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/).
2. Gebruik [setDefaultRegularFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) om uw gewenste lettertype op te geven. Het volgende voorbeeld gebruikt Wingdings.
3. Gebruik [setDefaultAsianFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) om uw gewenste lettertype op te geven. Het volgende voorbeeld gebruikt eveneens Wingdings.
4. Laad de presentatie met [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) met de laadopties.
5. Genereer de diavoorbeeldminiatuur, PDF en XPS om de resultaten te verifiëren.

Het volgende voorbeeld implementeert deze stappen:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Gebruik laadopties om het standaard reguliere en Aziatische lettertype te definiëren.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Laad de presentatie.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Genereer een diavoorbeeldminiatuur.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Sla de afbeelding op schijf.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Genereer een PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Genereer een XPS-document.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Wat beïnvloeden de standaard reguliere en Aziatische lettertypen precies—alleen export, of ook miniaturen, PDF, XPS, HTML en SVG?**

Ze nemen deel aan de renderpipeline voor alle ondersteunde uitvoerformaten. Dit omvat diavoorbeeldminiaturen, [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/python-java/convert-powerpoint-to-xps/), [rasterafbeeldingen](/slides/nl/python-java/convert-powerpoint-to-png/), [HTML](/slides/nl/python-java/convert-powerpoint-to-html/), en [SVG](/slides/nl/python-java/render-a-slide-as-an-svg-image/), omdat Aspose.Slides dezelfde layout‑ en glyph‑resolutielogica gebruikt voor deze doelwitten.

**Worden standaardlettertypen toegepast bij het eenvoudig lezen en opslaan van een PPTX zonder enige rendering?**

Nee. Standaardlettertypen zijn relevant wanneer tekst moet worden gemeten en getekend. Een eenvoudige open‑save van een presentatie wijzigt geen opgeslagen lettertype‑runs of de structuur van het bestand. Standaardlettertypen komen in beeld tijdens bewerkingen die tekst renderen of opnieuw opmaken.

**Als ik mijn eigen lettertype‑mappen toevoeg of lettertypen vanuit het geheugen lever, worden die dan in aanmerking genomen bij het kiezen van standaardlettertypen?**

Ja. [Aangepaste lettertype‑bronnen](/slides/nl/python-java/custom-font/) breiden de catalogus van beschikbare families en glyphs uit die de engine kan gebruiken. Standaardlettertypen en eventuele [fallback‑regels](/slides/nl/python-java/fallback-font/) zullen eerst tegen die bronnen worden afgehandeld, wat zorgt voor een meer betrouwbare dekking op servers en in containers.

**Zullen standaardlettertypen de tekstopmeting (kerning, advances) beïnvloeden en daardoor regeleinden en afbreken?**

Ja. Het wijzigen van het lettertype verandert de glyph‑metingen en kan regeleinden, afbreking en paginering tijdens het renderen beïnvloeden. Voor stabiliteit van de layout, [embed de originele lettertypen](/slides/nl/python-java/embedded-font/) of selecteer metrisch compatibele standaard‑ en fallback‑families.

**Is er nog enig nut aan het instellen van standaardlettertypen als alle gebruikte lettertypen in de presentatie zijn ingesloten?**

Vaak is het niet nodig, omdat [ingesloten lettertypen](/slides/nl/python-java/embedded-font/) al zorgen voor een consistente weergave. Standaardlettertypen blijven echter nuttig als vangnet voor tekens die niet gedekt worden door de ingesloten subset of wanneer een bestand ingesloten en niet‑ingesloten tekst mixt.