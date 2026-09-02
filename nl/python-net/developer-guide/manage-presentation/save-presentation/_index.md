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
description: "Ontdek hoe u presentaties in Python kunt opslaan met Aspose.Slides—exporteer naar PowerPoint of OpenDocument terwijl de lay-outs, lettertypes en effecten behouden blijven."
---
## **Overzicht**

[Open een presentatie in Python](/slides/nl/python-net/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande wijzigt, je wilt deze opslaan wanneer je klaar bent. Met Aspose.Slides for Python kun je opslaan naar een **bestand** of **stream**. Dit artikel bespreekt de verschillende manieren om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op als bestand door de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het volgende voorbeeld laat zien hoe je een presentatie opslaat met Aspose.Slides for Python.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:
    
    # Voer hier wat werk uit...

    # Sla de presentatie op naar een bestand.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse. Een presentatie kan naar veel verschillende stream‑types worden geschreven. In het onderstaande voorbeeld maken we een nieuwe presentatie en slaan we die op naar een bestands‑stream.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Sla de presentatie op naar de stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

Aspose.Slides for Python laat je de initiële weergave instellen die PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/)‑klasse. Stel de eigenschap `last_view` in op een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewtype/)‑enumeratie.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Aspose.Slides maakt het mogelijk om een presentatie op te slaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/)‑klasse en stel de eigenschap `conformance` in bij het opslaan. Als je `Conformance.ISO_29500_2008_STRICT` instelt, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het onderstaande voorbeeld maakt een presentatie en slaat die op in het Strict Office Open XML‑formaat.

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

Een Office Open XML‑bestand is een ZIP‑archief dat limieten van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en bovendien een limiet van 65 535 (2^16‑1) bestanden. ZIP64‑formatextensies verhogen deze limieten naar 2^64.

De eigenschap [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) stelt je in staat te kiezen wanneer ZIP64‑formatextensies worden gebruikt bij het opslaan van een Office Open XML‑bestand.

Deze eigenschap biedt de volgende modi:

- `IF_NECESSARY` gebruikt ZIP64‑formatextensies alleen als de presentatie de bovenstaande limieten overschrijdt. Dit is de standaardmodus.
- `NEVER` gebruikt nooit ZIP64‑formatextensies.
- `ALWAYS` gebruikt altijd ZIP64‑formatextensies.

De volgende code laat zien hoe je een presentatie opslaat als PPTX‑bestand met ingeschakelde ZIP64‑formatextensies:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Wanneer je opslaat met `Zip64Mode.NEVER`, wordt er een [PptxException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxexception/) gegooid als de presentatie niet kan worden opgeslagen in ZIP32‑formaat.
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Bij het werken met grote presentaties kun je het compressieniveau aanpassen om de bestandsgrootte en verwerkingstijd in balans te brengen. Afhankelijk van je eisen kun je kiezen voor snellere verwerking of kleinere uitvoerbestanden.

Aspose.Slides biedt de eigenschap [PptxOptions.compression_level](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/compression_level/), waarmee je het compressieniveau kunt opgeven dat wordt gebruikt bij het opslaan van een presentatie in Office Open XML‑formaat.

De volgende compressieniveaus zijn beschikbaar:

- [**NONE**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): Er wordt geen compressie toegepast. Bestanden worden ongewijzigd opgeslagen.
- [**LEVEL1**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): De snelste compressie met de laagste compressieverhouding.
- [**LEVEL2**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): Snellere compressie met een iets betere compressieverhouding dan **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): Biedt betere compressie dan **LEVEL2** met een gematigde impact op de verwerkingstijd.
- [**LEVEL4**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): Biedt betere compressie dan **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): Verbeterde compressie ten opzichte van **LEVEL4** met extra verwerkingstijd.
- [**LEVEL6**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): Standaardcompressie die een goede balans biedt tussen verwerkingssnelheid en bestandsgrootte. Dit is het *standaardcompressieniveau*.
- [**LEVEL7**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): Biedt betere compressie dan **LEVEL6** met tragere verwerking.
- [**LEVEL8**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): Biedt betere compressie dan **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/): Maximale compressie. Produceert de kleinste bestandsgrootte ten koste van de langste verwerkingstijd.

Het volgende voorbeeld toont hoe je een presentatie opslaat als PPTX‑bestand *zonder compressie*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Dit voorbeeld laat zien hoe je een presentatie opslaat als PPTX‑bestand met *maximale compressie*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

De eigenschap [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) regelt de generatie van miniaturen bij het opslaan van een presentatie naar PPTX:

- Indien ingesteld op `True`, wordt de miniatuur ververst tijdens het opslaan. Dit is de standaard.
- Indien ingesteld op `False`, wordt de bestaande miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen gegenereerd.

In de onderstaande code wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te vernieuwen.

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
Aspose heeft een [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van zijn eigen API. De app laat je een presentatie splitsen in meerdere bestanden door geselecteerde dia’s op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt “snelle opslaan” (incrementeel opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt elke keer het volledige doelbestand; incrementeel “snelle opslaan” wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie is niet thread‑safe; sla deze op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/python-net/manage-hyperlinks/) worden behouden. Extern gelinkte bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd – zorg ervoor dat de verwezen paden toegankelijk blijven.

**Kan ik documentmetadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/python-net/presentation-properties/) worden ondersteund en bij het opslaan naar het bestand weggeschreven.