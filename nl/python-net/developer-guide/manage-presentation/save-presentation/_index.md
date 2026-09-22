---
title: Presentaties opslaan in Python
linktitle: Presentatie opslaan
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
- Strikt Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- voortgang opslaan
- Python
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties opslaan naar bestanden of streams in Python met Aspose.Slides, en PPTX-outputopties configureren."
---
## **Overzicht**

Nadat u een presentatie hebt gemaakt of een [een bestaande presentatie openen](/slides/nl/python-net/open-presentation/), gebruikt u de [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ipresentation/save/) methode om het resultaat te schrijven. Aspose.Slides for Python via .NET kan een presentatie opslaan naar een bestand of stream in PowerPoint, OpenDocument, PDF en andere formaten. De volgende secties behandelen de standaard opslaacties en de opties die beschikbaar zijn voor PPTX‑output.

## **Presentaties opslaan naar bestanden**

Om een presentatie op te slaan naar een bestand, geeft u het uitvoerpad en een [SaveFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ipresentation/save/) methode. De formatwaarde bepaalt het type bestand dat Aspose.Slides maakt.

Het volgende voorbeeld maakt een presentatie en slaat deze op als een PPTX‑bestand:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Voeg hier de inhoud van de presentatie toe of pas deze aan.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Presentaties opslaan in hun oorspronkelijke formaat**

Voor voorbeelden van bestand‑ en streamdetectie, het gedrag van nieuw aangemaakte presentaties en het onderscheid tussen bron‑ en uitvoerformaten, zie [Het oorspronkelijke presentatie‑formaat bepalen](/slides/nl/python-net/detect-presentation-source-format/).

In een batch‑verwerkingsapplicatie is het invoerformaat mogelijk niet van tevoren bekend. Na het laden van een bestand leest u het oorspronkelijke formaat uit de [Presentation.source_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/source_format/) eigenschap. Geef de resulterende [SourceFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sourceformat/) waarde door aan [SlideUtil.to_save_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/to_save_format/) om de bijbehorende [SaveFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/) waarde te verkrijgen, en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ipresentation/save/) om de gewijzigde presentatie te schrijven.

Het volgende volledige voorbeeld verwerkt elk bestand in een invoermap, werkt de titel bij en slaat het op naar een uitvoermap in het formaat waarin het is geladen:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/to_save_format/) map PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP en PowerPoint‑XML naar hun overeenkomstige presentatie‑opslaformaten. Het map alleen bronformaten van presentaties; het is niet bedoeld om exportformaten zoals PDF, HTML, TIFF of afbeeldingen te selecteren. Het doorgeven van een niet‑ondersteunde of ongeldige [SourceFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sourceformat/) waarde veroorzaakt een uitzondering.

Legacy‑PPT-, PPS‑ en POT‑bestanden gebruiken dezelfde binaire container. Wanneer zo’n presentatie uit een stream zonder bestandsextensie wordt geladen, kan een PPS‑ of POT‑bestand daarom worden geïdentificeerd als PPT. Als het behouden van deze legacy‑subtypes vereist is, bewaar dan de oorspronkelijke bestandsnaam of formatuitle metadata apart en gebruik deze bij het kiezen van de uitvoer‑bestandsnaam en het formaat.

## **Presentaties opslaan naar streams**

Om een presentatie te schrijven zonder te vertrouwen op een definitief bestandspad, geeft u een schrijfbare [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) stream en een [SaveFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ipresentation/save/) methode. Deze aanpak is nuttig wanneer de output moet worden geretourneerd vanuit een webservice, opgeslagen in een database of in het geheugen moet worden verwerkt.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

U kunt de weergave specificeren waarin PowerPoint een opgeslagen presentatie aanvankelijk opent. Stel de [ViewProperties.last_view](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/last_view/) eigenschap in op een [ViewType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewtype/) waarde vóór het opslaan.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Presentaties opslaan in het strikte Office Open XML‑formaat**

Om een PPTX‑bestand te maken dat overeenkomt met het Strict‑profiel van Office Open XML, maakt u een [PptxOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/) instantie en stelt u de [conformance](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/conformance/) eigenschap in op `Conformance.ISO_29500_2008_STRICT`. Geef vervolgens de opties door aan de [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ipresentation/save/) methode.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een standaard ZIP‑archief beperkt de gecomprimeerde en ongecomprimeerde grootte van elke entry, de totale archiefgrootte en het aantal entries. Omdat een PPTX‑bestand een ZIP‑archief is, kan een zeer grote presentatie deze limieten overschrijden. ZIP64‑extensies verhogen de toepasselijke grootte‑ en entry‑limieten.

Gebruik de [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) eigenschap om te bepalen of Aspose.Slides ZIP64‑extensies schrijft:

- `IF_NECESSARY` gebruikt ZIP64 alleen wanneer de presentatie de standaard ZIP‑limieten overschrijdt. Dit is de standaardmodus.
- `NEVER` schakelt ZIP64‑extensies uit.
- `ALWAYS` schrijft altijd ZIP64‑extensies.

Het volgende voorbeeld schakelt ZIP64‑extensies altijd in voor de uitvoerpresentatie:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Waarschuwing" %}}
Als `Zip64Mode.NEVER` wordt gebruikt en de presentatie niet binnen de standaard ZIP‑limieten past, zal de opslaan‑bewerking een [PptxException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxexception/) veroorzaken.
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Voor PPTX‑output kunt u de opslagsnelheid balanceren met de bestandsgrootte door de [PptxOptions.compression_level](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/compression_level/) eigenschap in te stellen. De [CompressionLevel](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/compressionlevel/) enumeratie biedt de volgende waarden:

- `NONE` slaat gegevens op zonder compressie.
- `LEVEL1` levert de snelste compressie en de grootste gecomprimeerde uitvoer.
- `LEVEL2` tot en met `LEVEL5` geven steeds de voorkeur aan een kleinere uitvoer boven opslagsnelheid.
- `LEVEL6` balanceert opslagsnelheid en bestandsgrootte. Dit is het standaardniveau.
- `LEVEL7` en `LEVEL8` geven nog meer de voorkeur aan een kleinere uitvoer boven opslagsnelheid.
- `LEVEL9` biedt de sterkste compressie en vereist de meeste verwerkingstijd.

Het volgende voorbeeld slaat een presentatie op zonder compressie:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Het volgende voorbeeld gebruikt het maximale compressieniveau:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Presentaties opslaan zonder het miniatuur‑beeld te vernieuwen**

Wanneer een presentatie wordt opgeslagen als PPTX, bepaalt de [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) eigenschap de miniatuur van het document:

- `True` genereert de miniatuur opnieuw tijdens de opslaan‑bewerking. Dit is de standaardwaarde.
- `False` behoudt de bestaande miniatuur. Als de presentatie geen miniatuur heeft, genereert Aspose.Slides er geen.

Het volgende voorbeeld slaat een presentatie op zonder het miniatuur‑beeld te vernieuwen:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Opmerking" %}}
Het uitschakelen van het vernieuwen van de miniatuur kan de tijd die nodig is om een PPTX‑bestand op te slaan verminderen.
{{% /alert %}}

{{% alert color="info" title="Opmerking" %}}
Aspose biedt een gratis [PowerPoint Splitter](https://products.aspose.app/slides/nl/splitter) gebouwd met de Aspose.Slides‑API. Het slaat geselecteerde dia's uit een presentatie op als afzonderlijke PPT‑ of PPTX‑bestanden.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides incrementeel of “snelle opslaan”?**

Nee. Elke opslaan‑bewerking schrijft een compleet uitvoerbestand in plaats van alleen de gewijzigde delen bij te werken.

**Kunnen meerdere threads dezelfde Presentation‑instantie opslaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) instantie [is not thread-safe](/slides/nl/python-net/multithreading/). Toegang en opslaan van elke instantie mag slechts door één thread tegelijk gebeuren.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden wanneer ik een presentatie opsla?**

[Hyperlinks](/slides/nl/python-net/manage-hyperlinks/) blijven in de presentatie. Aspose.Slides kopieert geen extern gelinkte bestanden, dus de opgeslagen presentatie moet nog steeds toegang hebben tot hun locaties.

**Kan ik document‑metadata zoals auteur, titel, bedrijf en aanmaakdatum opslaan?**

Ja. Stel de juiste [documenteigenschappen](/slides/nl/python-net/presentation-properties/) in vóór het opslaan, en Aspose.Slides schrijft ze naar het uitvoerbestand.