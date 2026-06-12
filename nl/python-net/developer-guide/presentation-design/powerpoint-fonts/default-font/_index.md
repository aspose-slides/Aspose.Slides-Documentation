---
title: "Standaardlettertypen aanpassen in presentaties met Python"
linktitle: "Standaardlettertype"
type: docs
weight: 30
url: /nl/python-net/default-font/
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
- Aspose.Slides
description: "Stel standaardlettertypen in Aspose.Slides voor Python in om een correcte conversie van PowerPoint (PPT, PPTX) en OpenDocument (ODP) naar PDF, XPS en afbeeldingen te garanderen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om standaardlettertypen op te geven die worden gebruikt wanneer een presentatie wordt gerenderd. Dit is handig bij het genereren van miniaturen van dia's of het exporteren van een presentatie naar formaten zoals PDF en XPS. Standaardlettertypen worden geconfigureerd via `LoadOptions` voordat de presentatie wordt geladen.

De eigenschap `default_regular_font` definieert het standaardlettertype voor gewone tekst, terwijl `default_asian_font` het standaardlettertype voor Aziatische tekst definieert. Nadat deze opties zijn ingesteld, kan de presentatie worden geladen en gerenderd met de opgegeven lettertypen.

## **Standaardlettertypen gebruiken voor het renderen van een presentatie**
Aspose.Slides laat u het standaardlettertype instellen voor het renderen van de presentatie naar PDF, XPS of miniaturen. Dit artikel toont hoe u DefaultRegularFont en DefaultAsianFont kunt definiëren voor gebruik als standaardlettertypen. Volg de onderstaande stappen om lettertypen uit externe mappen te laden met behulp van Aspose.Slides voor Python via de .NET API:

1. Maak een instantie van LoadOptions aan.  
1. Stel DefaultRegularFont in op het gewenste lettertype. In het volgende voorbeeld heb ik Wingdings gebruikt.  
1. Stel DefaultAsianFont in op het gewenste lettertype. Ik heb Wingdings gebruikt in het volgende voorbeeld.  
1. Laad de presentatie met Presentation en stel de load-options in.  
1. Genereer nu de dia-miniatuur, PDF en XPS om de resultaten te verifiëren.  

De implementatie van het bovenstaande wordt hieronder weergegeven.

```py
import aspose.slides as slides

# Gebruik load‑opties om de standaard reguliere en Aziatische lettertypen te definiëren# Gebruik load‑opties om de standaard reguliere en Aziatische lettertypen te definiëren
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Laad de presentatie
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Genereer dia-miniatuur
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Genereer PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Genereer XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**Wat beïnvloeden `default_regular_font` en `default_asian_font` precies — alleen export, of ook miniaturen, PDF, XPS, HTML en SVG?**

Ze nemen deel aan de renderpijplijn voor alle ondersteunde uitvoerformaten. Dit omvat dia-miniaturen, [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/nl/python-net/convert-powerpoint-to-xps/), [raster images](/slides/nl/python-net/convert-powerpoint-to-png/), [HTML](/slides/nl/python-net/convert-powerpoint-to-html/), en [SVG](/slides/nl/python-net/render-a-slide-as-an-svg-image/), omdat Aspose.Slides dezelfde layout- en glyfresolutielogica gebruikt voor deze doelen.

**Worden standaardlettertypen toegepast bij het simpelweg lezen en opslaan van een PPTX zonder enige rendering?**

Nee. Standaardlettertypen zijn van belang wanneer tekst moet worden gemeten en getekend. Een rechtstreekse open-save van een presentatie wijzigt de opgeslagen font runs of de structuur van het bestand niet. Standaardlettertypen komen in beeld tijdens bewerkingen die tekst renderen of opnieuw indelen.

**Als ik mijn eigen lettertype-mappen toevoeg of lettertypen vanuit het geheugen lever, worden ze dan in aanmerking genomen bij het kiezen van standaardlettertypen?**

Ja. [Custom font sources](/slides/nl/python-net/custom-font/) breiden de catalogus van beschikbare families en glyfen uit die de engine kan gebruiken. Standaardlettertypen en eventuele [fallback rules](/slides/nl/python-net/fallback-font/) zullen eerst tegen die bronnen worden afgewogen, wat zorgt voor een betrouwbaardere dekking op servers en in containers.

**Zullen standaardlettertypen invloed hebben op tekstmetriek (kerning, advances) en daardoor op regeleinden en afbreken?**

Ja. Het wijzigen van het lettertype verandert de glyfmetriek en kan regeleinden, afbreken en paginering tijdens het renderen beïnvloeden. Voor een stabiele layout, [embed the original fonts](/slides/nl/python-net/embedded-font/) of selecteer metrisch compatibele standaard- en fallback-families.

**Heeft het instellen van standaardlettertypen nog zin als alle in de presentatie gebruikte lettertypen zijn ingebed?**

Vaak is het niet nodig, omdat [embedded fonts](/slides/nl/python-net/embedded-font/) al zorgen voor een consistente weergave. Standaardlettertypen blijven echter nuttig als vangnet voor tekens die niet gedekt worden door de ingebedde subset of wanneer een bestand gemengde ingebedde en niet-ingebedde tekst bevat.