---
title: Vormen schalen in presentaties met Python
linktitle: Vormen schalen
type: docs
weight: 130
url: /nl/python-net/re-sizing-shapes-on-slide/
keywords:
- vorm aanpassen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Schakel eenvoudig de grootte van vormen bij op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via .NET - automatiseer dia-layoutaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Een van de meest gestelde vragen van Aspose.Slides‑for‑Python‑klanten is hoe ze vormen kunnen schalen zodat, wanneer de dia‑grootte verandert, de gegevens niet worden afgesneden. Dit korte technische artikel laat zien hoe dat moet.

## **Afmetingen van objecten aanpassen**

Om te voorkomen dat objecten scheef komen te staan wanneer de dia‑grootte verandert, werk je de positie en afmetingen van elk object bij zodat ze passen bij de nieuwe dia‑indeling.

```py
import aspose.slides as slides

# Laad het presentatiebestand.
with slides.Presentation("sample.pptx") as presentation:
    # Haal de oorspronkelijke dia‑grootte op.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Verander de dia‑grootte zonder bestaande vormen te schalen.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Haal de nieuwe dia‑grootte op.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Pas de grootte en positie van vormen op elke dia aan.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Schaald de grootte van de vorm.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Schaald de positie van de vorm.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Als een dia een tabel bevat, werkt de bovenstaande code niet correct. In dat geval moet elke cel in de tabel worden aangepast.
{{% /alert %}} 

Gebruik de volgende code om dia’s met tabellen aan te passen. Voor tabellen is het instellen van de breedte of hoogte een speciaal geval: je moet de hoogtes van de rijen en de breedtes van de kolommen afzonderlijk aanpassen om de totale afmeting van de tabel te wijzigen.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Haal de oorspronkelijke dia-grootte op.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Verander de dia-grootte zonder bestaande vormen te schalen.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Haal de nieuwe dia-grootte op.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Schaald de grootte van de vorm.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Schaald de positie van de vorm.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Schaald de grootte van de vorm.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Schaald de positie van de vorm.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Schaald de grootte van de vorm.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Schaald de positie van de vorm.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Veelgestelde vragen**

**Waarom worden objecten vervormd of afgesneden na het wijzigen van de dia‑grootte?**

Bij het wijzigen van de dia‑grootte behouden objecten hun oorspronkelijke positie en afmeting tenzij de schaal expliciet wordt aangepast. Dit kan leiden tot bijsnijden van inhoud of scheefgezette objecten.

**Werkt de meegeleverde code voor alle objecttypen?**

Het basisvoorbeeld werkt voor de meeste objecttypen (tekstvakken, afbeeldingen, grafieken, enz.). Voor tabellen moet je echter rijen en kolommen apart behandelen, omdat de hoogte en breedte van een tabel bepaald worden door de afmetingen van de individuele cellen.

**Hoe pas ik tabellen aan bij het wijzigen van een dia?**

Je moet door alle rijen en kolommen van de tabel itereren en hun hoogte en breedte proportioneel aanpassen, zoals getoond in het tweede code‑voorbeeld.

**Werkt dit aanpassen ook voor master‑dia’s en lay‑out‑dia’s?**

Ja, maar je moet ook door de [Masters](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/masters/) en [Layout slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/layout_slides/) itereren en dezelfde schaal‑logica toepassen op hun objecten om consistentie door de hele presentatie te waarborgen.

**Kan ik de oriëntatie van een dia (portrait/landscape) wijzigen tegelijk met het aanpassen?**

Ja. Je kunt [presentation.slide_size.orientation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/islidesize/orientation/) gebruiken om de oriëntatie te wijzigen. Zorg ervoor dat je de schaal‑logica dienovereenkomstig aanpast om de lay‑out te behouden.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

Aspose.Slides ondersteunt aangepaste afmetingen, maar zeer grote afmetingen kunnen de prestaties beïnvloeden of incompatibel zijn met sommige versies van PowerPoint.

**Hoe voorkom ik dat objecten met een vaste beeldverhouding vervormd raken?**

Controleer de eigenschap `aspect_ratio_locked` van het object voordat je schaalt. Als deze vergrendeld is, pas dan de breedte of hoogte proportioneel aan in plaats van ze afzonderlijk te schalen.