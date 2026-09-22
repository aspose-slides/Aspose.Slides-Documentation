---
title: Bepaal het oorspronkelijke presentatieformaat in Python
linktitle: Bronformaat
type: docs
weight: 35
url: /nl/python-net/detect-presentation-source-format/
keywords:
- bronformaat
- presentatieformaat detecteren
- PowerPoint
- OpenDocument
- presentatie
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Lees het oorspronkelijke formaat van een geladen presentatie in Python met Aspose.Slides voor Python via .NET, vergelijk detectie‑API’s en verwerk bestanden, streams en legacy‑formaten."
---
## **Overzicht**

Na het laden van een presentatie, lees de alleen‑lezen [Presentation.source_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/source_format/) eigenschap om het oorspronkelijke formaat te bepalen. Gebruik deze wanneer de daaropvolgende verwerking afhangt van het formaat waarmee de huidige instantie is geladen.

Het bronformaat verschilt van de [SaveFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/) die voor een uitvoerbestand is geselecteerd. Opslaan naar een ander formaat verandert het bronformaat van de bestaande instantie niet.

## **Lees het bronformaat van een bestand**

Dit voorbeeld vereist een bestaand bestand `sample.pptx`. Het laadt het bestand en selecteert een toepassingsverwerkingsbeleid met behulp van [Presentation.source_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/source_format/), in plaats van de bestandsnaam. Verander het invoerpad om andere formaten te proberen. Het voorbeeld drukt het geselecteerde beleid af; vervang de berichten door uw toepassingslogica.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Herken de ondersteunde waarden**

De [SourceFormat] enumeratie onderscheidt de volgende presentatieformaten. De onderstaande extensies zijn conventionele extensies, geen reconstructie van de oorspronkelijke bestandsnaam.

| SourceFormat-waarde | Extensie | Formaat |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint‑presentatie 97–2003 |
| `PPTX` | `.pptx` | Office Open XML‑presentatie |
| `PPTM` | `.pptm` | Macro‑ingeschakelde Office Open XML‑presentatie |
| `PPS` | `.pps` | PowerPoint‑diavoorstelling 97–2003 |
| `PPSX` | `.ppsx` | Office Open XML‑diavoorstelling |
| `PPSM` | `.ppsm` | Macro‑ingeschakelde Office Open XML‑diavoorstelling |
| `POT` | `.pot` | PowerPoint‑sjabloon 97–2003 |
| `POTX` | `.potx` | Office Open XML‑sjabloon |
| `POTM` | `.potm` | Macro‑ingeschakelde Office Open XML‑sjabloon |
| `ODP` | `.odp` | OpenDocument‑presentatie |
| `OTP` | `.otp` | OpenDocument‑presentatiesjabloon |
| `FODP` | `.fodp` | Flat XML ODF‑presentatie |
| `XML` | `.xml` | PowerPoint‑XML‑presentatie |

## **Lees het bronformaat van een stream**

Dit voorbeeld vereist een bestaand bestand `sample.pps`. Het lezen van de bytes in een geheugen‑stream modelleert invoer die zonder bestandsnaam wordt ontvangen, bijvoorbeeld een database‑waarde of een geüploade byte‑array. De [Presentation]‑constructor ontvangt alleen de stream.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS en POT gebruiken hetzelfde onderliggende binaire formaat. Bij het laden via een bestandspad kan de extensie helpen om een diavoorstelling of sjabloon te onderscheiden. Zonder bestandsnaam kan legacy PPS‑ en POT‑inhoud gemeld worden als `SourceFormat.PPT`; het PPS‑voorbeeld hierboven meldt `PPT`.

Als uw toepassing het onderscheid moet behouden, bewaar dan de oorspronkelijke bestandsnaam of subtype‑metadata apart. Een extensie is een nuttige aanwijzing voor deze legacy‑subtypes, maar mag niet de enige basis zijn om willekeurige presentatiesinhoud te identificeren.

## **Vergelijk detectie vóór en na het laden**

Gebruik [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) en [PresentationInfo.load_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/load_format/) wanneer u een bestand moet inspecteren voordat u het volledige presentatiemodel laadt. Gebruik [Presentation.source_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/source_format/) wanneer de instantie al bestaat.

Dit voorbeeld vereist `sample.pptx` en drukt `PPTX` af voor beide controles. In productie kiest u de API die past bij uw verwerkingsfase; een al geladen presentatie heeft geen tweede inspectie nodig alleen om het bronformaat te verkrijgen.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

De resultaten hebben verschillende enumeratietypen: [LoadFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadformat/) en [SourceFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sourceformat/). Vergelijk ze niet door hun numerieke waarden te casten of aan te nemen dat elk formaat identieke detectieresultaten oplevert. In de hieronder beschreven controle opslaan‑en‑opnieuw‑laden werd PowerPoint XML gemeld als `LoadFormat.UNKNOWN` vóór het laden en `SourceFormat.XML` na het laden.

## **Houd bron- en uitvoerformaten gescheiden**

Dit voorbeeld vereist `sample.pptx` en schrijft `converted.odp`. Het drukt `PPTX` af zowel vóór als na het opslaan van de oorspronkelijke instantie. Alleen de nieuwe instantie die geladen wordt uit de ODP‑uitvoer meldt `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Een presentatie die van nul is gemaakt met `slides.Presentation()` meldt `SourceFormat.PPTX`. Het heeft geen invoerbestand: dit is de standaardwaarde voor een nieuw gemaakte instantie, niet het bewijs dat er een PPTX‑bestand is geladen. Houd bij of uw toepassing de instantie heeft gemaakt of geladen, indien dat onderscheid van belang is.

## **Koppel een bronformaat aan een extensie**

Het volgende voorbeeld vereist `sample.pptx`. Het koppelt elke momenteel ondersteunde [SourceFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sourceformat/) waarde aan een conventionele extensie, zonder de invoer‑bestandsnaam te analyseren. De fallback voorkomt dat stilzwijgend een extensie wordt toegewezen aan een niet‑herkende waarde.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Deze koppeling converteert geen bestand of herstelt een legacy PPS/POT‑subtype dat verloren ging tijdens het laden van een stream. Voor het daadwerkelijke opslaan selecteert u expliciet een [SaveFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/), of gebruikt u de conversie die wordt getoond in [Save Presentations in Their Original Format](/slides/nl/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Verifieer formaten door opslaan en opnieuw openen**

Dit zelfstandige voorbeeld maakt een presentatie en schrijft drie bestanden in de werkmap, waarbij bestanden met dezelfde namen overschreven worden. Het opent elk resultaat zowel via pad als via een geheugen‑stream opnieuw. Voor PPTX en ODP rapporteren beide routes het opgeslagen formaat. Voor PPS rapporteert laden via pad `PPS`, terwijl laden van dezelfde bytes zonder bestandsnaam `PPT` rapporteert.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Dezelfde controle met alle bovenstaande formaten leverde deze resultaten op voor gegenereerde presentaties met bijpassende extensies:

| Opgeslagen formaat | SourceFormat van een bestandspad | SourceFormat van een naamloze stream |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` respectievelijk | Zelfde als bestandspad |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` respectievelijk | Zelfde als bestandspad |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` respectievelijk | Zelfde als bestandspad |
| ODP, OTP | `ODP`, `OTP` respectievelijk | Zelfde als bestandspad |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

In deze controles was de enige normalisatie van bronformaat PPS/POT naar `PPT` voor naamloze streams. De tabel beschrijft formatidentificatie, niet het behouden van elke presentatiefunctie tijdens conversie.

## **FAQ**

**Verandert het opslaan naar ODP het bronformaat van een presentatie die is geladen vanuit PPTX?**

Nee. De bestaande instantie meldt nog steeds `PPTX`. Een instantie die geladen wordt uit het opgeslagen ODP‑bestand meldt `ODP`.

**Kan een stream altijd een legacy‑presentatie, diavoorstelling en sjabloon van elkaar onderscheiden?**

Nee. PPT, PPS en POT delen hetzelfde binaire formaat. Bewaar de bestandsnaam of subtype‑metadata apart wanneer dat onderscheid vereist is.

**Welke API moet ik gebruiken als de presentatie al geladen is?**

Lees [Presentation.source_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/source_format/). Gebruik [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) voor inspectie vóór het laden.