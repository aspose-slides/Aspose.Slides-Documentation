---
title: Bepaal het oorspronkelijke presentatieformaat in Python via Java
linktitle: Bronformaat
type: docs
weight: 35
url: /nl/python-java/detect-presentation-source-format/
keywords:
- bronformaat
- detecteer presentatieformaat
- PowerPoint
- OpenDocument
- presentatie
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Lees het oorspronkelijke formaat van een geladen presentatie in Python via Java met Aspose.Slides voor Python via Java, vergelijk detectie-API's en verwerk bestanden, streams en legacy-formaten."
---
## **Overzicht**

Na het laden van een presentatie, roep de [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSourceFormat) methode aan om het oorspronkelijke formaat te bepalen. Gebruik deze wanneer verdere verwerking afhangt van het formaat waarin de huidige instantie is geladen.

Het bronformaat verschilt van het [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/) dat voor een uitvoerbestand is geselecteerd. Opslaan naar een ander formaat wijzigt het bronformaat van de bestaande instantie niet.

De voorbeelden vereisen Aspose.Slides for Python via Java en een compatibele Java‑runtime. Elk voorbeeld start de JVM als deze nog niet draait.

## **Lees het bronformaat van een bestand**

Dit voorbeeld vereist een bestaand `sample.pptx`‑bestand. Het laadt het bestand en selecteert een toepassingsverwerkingsbeleid met [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSourceFormat), in plaats van de bestandsnaam. Pas het invoerpad aan om andere formaten te testen. Het voorbeeld print het geselecteerde beleid; vervang de berichten door uw eigen logica.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Herken de ondersteunde waarden**

De [SourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sourceformat/)‑klasse definieert integer‑constanten die de volgende presentatieformaten onderscheiden. De hieronder vermelde extensies zijn conventionele extensies, geen reconstructie van de oorspronkelijke bestandsnaam.

| SourceFormat-waarde | Extensie | Formaat |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003‑presentatie |
| `Pptx` | `.pptx` | Office Open XML‑presentatie |
| `Pptm` | `.pptm` | Macro‑ingeschakelde Office Open XML‑presentatie |
| `Pps` | `.pps` | PowerPoint 97–2003‑diavoorstelling |
| `Ppsx` | `.ppsx` | Office Open XML‑diavoorstelling |
| `Ppsm` | `.ppsm` | Macro‑ingeschakelde Office Open XML‑diavoorstelling |
| `Pot` | `.pot` | PowerPoint 97–2003‑sjabloon |
| `Potx` | `.potx` | Office Open XML‑sjabloon |
| `Potm` | `.potm` | Macro‑ingeschakelde Office Open XML‑sjabloon |
| `Odp` | `.odp` | OpenDocument‑presentatie |
| `Otp` | `.otp` | OpenDocument‑presentatiesjabloon |
| `Fodp` | `.fodp` | Flat XML ODF‑presentatie |
| `Xml` | `.xml` | PowerPoint XML‑presentatie |

## **Lees het bronformaat van een stream**

Dit voorbeeld vereist een bestaand `sample.pps`‑bestand. Het inlezen van de bytes in een geheugen‑stream modelleert invoer zonder bestandsnaam, bijvoorbeeld een database‑waarde of een geüpload byte‑array. De [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑constructor ontvangt alleen de stream. Python leest de bestandsbytes en JPype zet ze om in een Java‑byte‑array voor de Java‑geheugen‑stream.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS en POT gebruiken hetzelfde onderliggende binaire formaat. Bij laden via een bestandspad kan de extensie helpen om een diavoorstelling of sjabloon te onderscheiden. Zonder bestandsnaam kan legacy‑PPS‑ en‑POT‑inhoud gerapporteerd worden als `SourceFormat.Ppt`; het PPS‑voorbeeld hierboven print de integer‑waarde van `SourceFormat.Ppt`.

Als uw applicatie dit onderscheid moet behouden, bewaar dan de oorspronkelijke bestandsnaam of sub‑type‑metadata apart. Een extensie is een handige hint voor deze legacy‑subtypen, maar mag niet de enige basis zijn om willekeurige presentati-inhoud te identificeren.

## **Vergelijk detectie vóór en na het laden**

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) en [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#getLoadFormat) wanneer u een bestand moet inspecteren voordat u het volledige presentatiemodel laadt. Gebruik [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSourceFormat) wanneer de instantie al bestaat.

Dit voorbeeld vereist `sample.pptx` en print de integer‑waarden van `LoadFormat.Pptx` respectievelijk `SourceFormat.Pptx`. In productie kiest u de API die past bij uw verwerkingsfase; een reeds geladen presentatie heeft geen tweede inspectie nodig alleen om het bronformaat te verkrijgen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

De resultaten gebruiken constanten uit verschillende klassen: [LoadFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadformat/) en [SourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sourceformat/). Vergelijk hun numerieke waarden niet en ga er niet vanuit dat elk formaat identieke detectieresultaten oplevert. PowerPoint XML kan vóór het laden gerapporteerd worden als `LoadFormat.Unknown` en na het laden als `SourceFormat.Xml`.

## **Houd bron- en uitvoerformaten gescheiden**

Dit voorbeeld vereist `sample.pptx` en schrijft `converted.odp`. Het print de integer‑waarde van `SourceFormat.Pptx` zowel vóór als na het opslaan van de oorspronkelijke instantie. Alleen de nieuwe instantie die wordt geladen uit de ODP‑output rapporteert `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Een presentatie die vanaf nul is gecreëerd met `Presentation()` rapporteert `SourceFormat.Pptx`. Ze heeft geen invoerbestand: dit is de standaardwaarde voor een nieuw aangemaakte instantie, niet een bewijs dat een PPTX‑bestand is geladen. Houd bij of uw applicatie de instantie heeft aangemaakt of geladen, als dat onderscheid relevant is.

## **Map een bronformaat naar een extensie**

Het volgende voorbeeld vereist `sample.pptx`. Het mappt elke momenteel ondersteunde [SourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sourceformat/)‑waarde naar een conventionele extensie, zonder de invoer‑bestandsnaam te parsen. Het fallback‑mechanisme voorkomt dat er stilzwijgend een extensie wordt toegekend aan een niet‑herkende waarde.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Deze mapping converteert geen bestand en herstelt ook geen legacy‑PPS/POT‑subtype dat verloren ging tijdens stream‑laden. Voor daadwerkelijk opslaan selecteert u een [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/) expliciet, of gebruik de conversie beschreven in [Save Presentations in Their Original Format](/slides/nl/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifieer formaten door op te slaan en opnieuw te openen**

Dit zelfstandige voorbeeld maakt een presentatie aan en schrijft drie bestanden in de werkmap, waarbij bestanden met dezelfde naam overschreven worden. Het opent elke output zowel via een pad als via een geheugen‑stream. Voor PPTX en ODP rapporteren beide routes het opgeslagen formaat. Voor PPS rapporteert laden via het pad `Pps`, terwijl laden van dezelfde bytes zonder bestandsnaam `Ppt` rapporteert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

De volgende tabel vat de bron‑formaat‑identificatie samen voor presentaties met overeenkomende extensies. Namen duiden constanten aan; de Python‑voorbeelden printen hun integer‑waarden:

| Opgeslagen formaat | SourceFormat van een bestandspad | SourceFormat van een naamloze stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectievelijk | Zelfde als bestandspad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectievelijk | Zelfde als bestandspad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectievelijk | Zelfde als bestandspad |
| ODP, OTP | `Odp`, `Otp` respectievelijk | Zelfde als bestandspad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT‑inhoud wordt geïdentificeerd als `Ppt` voor naamloze streams. De tabel beschrijft alleen format‑identificatie, niet het behoud van elke presentatiefunctie tijdens conversie.

## **FAQ**

**Verandert opslaan naar ODP het bronformaat van een presentatie die is geladen vanuit PPTX?**

Nee. De bestaande instantie rapporteert nog steeds `Pptx`. Een instantie die wordt geladen uit het opgeslagen ODP‑bestand rapporteert `Odp`.

**Kan een stream altijd een legacy‑presentatie, diavoorstelling en sjabloon van elkaar onderscheiden?**

Nee. PPT, PPS en POT delen hetzelfde binaire formaat. Bewaar de bestandsnaam of sub‑type‑metadata apart wanneer dat onderscheid vereist is.

**Welke API moet ik gebruiken als de presentatie al is geladen?**

Lees [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSourceFormat). Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) voor inspectie vóór het laden.