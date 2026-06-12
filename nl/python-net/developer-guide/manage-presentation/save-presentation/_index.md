---
title: Presentaties opslaan in Python
linktitle: Presentaties opslaan
type: docs
weight: 80
url: /nl/python-net/save-presentation/
keywords:
- PowerPoint opslaan
- OpenDocument opslaan
- presentatie opslaan
- dia opslaan
- PPT opslaan
- PPTX opslaan
- ODP opslaan
- presentatie naar bestand
- presentatie naar stream
- voorgedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- voortgang van opslaan
- Python
- Aspose.Slides
description: "Ontdek hoe u presentaties in Python kunt opslaan met Aspose.Slides—exporteren naar PowerPoint of OpenDocument terwijl lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open een presentatie in Python](/slides/nl/python-net/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande aanpast, je wilt deze opslaan wanneer je klaar bent. Met Aspose.Slides for Python kun je opslaan naar een **bestand** of **stream**. Dit artikel legt de verschillende manieren om een presentatie op te slaan uit.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het volgende voorbeeld laat zien hoe je een presentatie opslaat met Aspose.Slides for Python.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand representeert.
with slides.Presentation() as presentation:
    
    # Doe hier wat werk...

    # Sla de presentatie op naar een bestand.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse. Een presentatie kan naar veel verschillende stream‑typen worden geschreven. In het voorbeeld hieronder maken we een nieuwe presentatie, voegen tekst toe aan een vorm en slaan deze op naar een stream.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand representeert.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Sla de presentatie op naar de stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Presentaties opslaan met een vooraf gedefinieerd weergave‑type**

Aspose.Slides for Python laat je de initiële weergave instellen die PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/)‑klasse. Stel de eigenschap `last_view` in op een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewtype/)‑enumeratie.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Aspose.Slides laat je een presentatie opslaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/)‑klasse en stel de eigenschap `conformance` in tijdens het opslaan. Als je `Conformance.ISO_29500_2008_STRICT` instelt, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het voorbeeld hieronder maakt een presentatie en slaat deze op in het Strict Office Open XML‑formaat.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Sla de presentatie op in het Strict Office Open XML-formaat.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat een limiet van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en tevens een limiet van 65 535 (2^16‑1) bestanden. ZIP64‑formatextensies verhogen deze limieten naar 2^64.

De eigenschap [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) laat je kiezen wanneer ZIP64‑formatextensies worden gebruikt bij het opslaan van een Office Open XML‑bestand.

Deze eigenschap biedt de volgende modi:

- `IF_NECESSARY` gebruikt ZIP64‑formatextensies alleen als de presentatie de bovenstaande beperkingen overschrijdt. Dit is de standaardmodus.
- `NEVER` gebruikt nooit ZIP64‑formatextensies.
- `ALWAYS` gebruikt altijd ZIP64‑formatextensies.

De volgende code toont hoe je een presentatie opslaat als PPTX met ingeschakelde ZIP64‑formatextensies:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="OPMERKING" color="warning" %}}
Als je opslaat met `Zip64Mode.NEVER`, wordt er een [PptxException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxexception/) gegooid wanneer de presentatie niet in ZIP32‑formaat kan worden opgeslagen.
{{% /alert %}}

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

De eigenschap [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) bepaalt of de miniatuur wordt vernieuwd bij het opslaan van een presentatie naar PPTX:

- Als deze op `True` staat, wordt de miniatuur tijdens het opslaan vernieuwd. Dit is de standaardinstelling.
- Als deze op `False` staat, blijft de huidige miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen miniatuur gegenereerd.

In de code hieronder wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te vernieuwen.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Deze optie helpt de tijd te verkorten die nodig is om een presentatie op te slaan in PPTX‑formaat.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose heeft een [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van haar eigen API. De app maakt het mogelijk een presentatie in meerdere bestanden te splitsen door geselecteerde dia's op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt “fast save” (incrementeel opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt elke keer het volledige doelbestand aan; incrementeel “fast save” wordt niet ondersteund.

**Is het thread‑veilig om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie is **niet thread‑veilig**; sla deze op vanuit één enkele thread.

**Wat gebeurt er met hyperlink‑s en extern gelinkte bestanden bij het opslaan?**

[Hyperlink‑s](/slides/nl/python-net/manage-hyperlinks/) blijven behouden. Extern gelinkte bestanden (bijv. video‑s via relatieve paden) worden niet automatisch gekopieerd – zorg ervoor dat de gerefereerde paden toegankelijk blijven.

**Kan ik document‑metadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [document‑eigenschappen](/slides/nl/python-net/presentation-properties/) worden ondersteund en bij het opslaan naar het bestand weggeschreven.