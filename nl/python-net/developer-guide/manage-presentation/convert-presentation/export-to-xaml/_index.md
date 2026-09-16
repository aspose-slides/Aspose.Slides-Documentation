---
title: Presentaties exporteren naar XAML met Python
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/python-net/export-to-xaml/
keywords:
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- PowerPoint naar XAML
- OpenDocument naar XAML
- presentatie naar XAML
- PPT naar XAML
- PPTX naar XAML
- ODP naar XAML
- PPT opslaan als XAML
- PPTX opslaan als XAML
- ODP opslaan als XAML
- PPT exporteren naar XAML
- PPTX exporteren naar XAML
- ODP exporteren naar XAML
- Python
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML met Python via Aspose.Slides - snelle, Office-vrije oplossing die uw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties kunt exporteren naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe je een presentatie kunt opslaan als XAML met de standaardinstellingen, en demonstreert hoe je de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook een aantal veelgestelde vragen over fallback‑lettertypen, compatibiliteit met XAML‑stacks en het gedrag bij het exporteren van verborgen dia's.

## **Over XAML**

XAML is een op XML gebaseerd opmaaktal dat wordt gebruikt om gebruikersinterfaces te beschrijven in frameworks zoals WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin.Forms.

Je kunt met XAML‑bestanden werken in een visuele ontwerper of de opmaak rechtstreeks schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Het volgende Python‑voorbeeld toont hoe je een presentatie naar XAML exporteert met de standaardinstellingen:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Standaard worden de geëxporteerde dia's opgeslagen in een `pres`‑submap van de huidige werkmap van het proces, zoals geretourneerd door [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). De map wordt automatisch aangemaakt en eventuele vereiste afbeeldingen worden daar ook opgeslagen.

De naam van de uitvoermap wordt afgeleid van de bestandsnaam van de bron zonder extensie. Voor `pres.pptx` krijgen de uitvoerbestanden de namen `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, enzovoort. Zelfs als je een absoluut pad opgeeft voor de invoerpresentatie, wordt de uitvoermap relatief ten opzichte van de huidige werkmap aangemaakt, in plaats van naast het invoerbestand.

## **Presentaties exporteren naar XAML met aangepaste opties**

Gebruik de klasse [XamlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/) om te bepalen hoe Aspose.Slides een presentatie exporteert naar XAML.

Om verborgen dia's in de XAML‑output op te nemen, stel je de eigenschap [export_hidden_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in op `True`, zoals getoond in het volgende Python‑voorbeeld:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Alle gegenereerde XAML‑artefacten vastleggen**

Een XAML‑export kan een XAML‑document produceren voor elke geëxporteerde dia, plus afzonderlijke afbeeldingen en ondersteunende bronnen. Bewaar al deze bestanden bij het opslaan of verzenden van een export.

De onderstaande voorbeelden gebruiken de standaard bestandsopslag in een tijdelijke map en verzamelen vervolgens de gegenereerde bestanden.

### **Begrijp de exportlevenscyclus**

- Start de export met de XAML‑specifieke overload van [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) die XAML‑opties accepteert. Lees de gegenereerde bestanden pas nadat deze met succes is teruggekeerd.
- Bewaar het relatieve pad van elk artefact, omdat XAML mogelijk bronnen via relatieve paden aanroept.
- Lees artefacten als bytes. Afbeeldingen en andere binaire bronnen mogen niet als tekst worden gedecodeerd.
- Rapporteer algeheel succes alleen nadat de collectie en eventuele daaropvolgende opslagoperatie voltooid zijn. Laat opslagfouten naar de aanroeper doorwerken en ruim gedeeltelijke output op als de persistentie mislukt.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) default is `False`, waardoor verborgen‑dia XAML‑documenten worden uitgesloten. Als je het instelt op `True`, worden ze en alle benodigde bronnen voor hun export meegenomen. Het aantal bronnen hangt af van de presentatie; ga niet uit van één bestand per dia.

{{% alert color="warning" title="Warning" %}}
De voorbeelden wijzigen tijdelijk de huidige werkmap van het proces, wat alle threads beïnvloedt. Voer elke export uit in een dedicated worker‑proces, of zorg ervoor dat geen ander werk in het proces afhankelijk is van de huidige map tijdens de export. Een unieke tijdelijke map alleen maakt gelijktijdige exports in hetzelfde proces niet veilig.
{{% /alert %}}

### **Exporteren naar geheugen en de artefacten inspecteren**

Dit volledige voorbeeld laadt `pres.pptx`, exporteert het naar een tijdelijke map, verzamelt elk artefact in een woordenboek van relatieve namen en bytes, en print de naam, het type en het aantal bytes. Het behoudt de gegenereerde mapstructuur en verwijdert de tijdelijke bestanden na de collectie. Het invoerpad wordt opgelost voordat de werkmap wordt gewijzigd.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Decodeer alleen XAML, en alleen wanneer tekstinspectie nodig is.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Extensiecontroles zijn nuttig voor inspectie; bewaar alle artefacten, inclusief onbekende resource‑typen. Laat de bytes ongewijzigd wanneer je ze opslaat of verzendt. Decodeer alleen XAML die tekstueel verwerkt moet worden. Deze aanpak gebruikt tijdelijke schijfruimte evenals geheugen voor de verzamelde export.

### **Verzamelde artefacten verpakken in een ZIP‑archief**

Dit zelfstandige voorbeeld verzamelt de export, valideert de namen en schrijft de originele bytes naar een ZIP‑archief. Een unieke archiefnaam scheidt export‑taken. ZIP‑items gebruiken schuine strepen en behouden relatieve mappen. Onveilige namen of namen die na normalisatie in conflict komen, weigeren het gehele pakket voordat het wordt geschreven.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # De ZIP-directory is afgerond voordat succes wordt gemeld.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Het voorbeeld gebruikt [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) om één lokaal archief te schrijven nadat de tijdelijke export is verzameld. Voor externe opslag vervang je de stap van het schrijven van het archief door uploads van de verzamelde bytes. Gebruik een export‑taak‑identificatie plus de volledige relatieve artefactnaam als object‑sleutel, of sla de taak‑identificatie, relatieve naam en binaire data op in een database‑rij. Publiceer de taak pas nadat alle uploads voltooid zijn of de databasetransactie is gecommit. Ruim gedeeltelijke output op als de persistentie mislukt.

Voor grote presentaties verwerk je de tijdelijke bestanden één voor één na de export in plaats van alle bytes in een woordenboek te verzamelen. Dit voorkomt een extra in‑memory kopie van de volledige export, maar elimineert niet de geheugenvereisten van de exporteur zelf.

### **Resource‑namen behouden en referenties verifiëren**

- Normaliseer pad‑scheidingstekens wanneer de bestemming dit vereist, maar behoud relatieve mappen. Bewaar niet alleen de uiteindelijke bestandsnaam, tenzij elke gegenereerde naam uniek is en de resource‑referenties geldig blijven.
- Pas bestemmingsspecifieke naamsvalidatie toe. Bij het schrijven van losse bestanden, verwerp absolute paden en pad‑traversalsegmenten, los de bestemming op, en controleer dat deze onder de beoogde exportmap blijft. Gebruik een door de applicatie beheerde map zonder symbolische links die het schrijven kunnen omleiden.
- Gebruik een aparte opslag‑namespace voor elke exporttaak. Detecteer conflicten na normalisatie van scheidingstekens en volgens de hoofdlettergevoeligheidsregels van de bestemming.
- Parse vóór publicatie elk XAML‑document als XML en inspecteer de bestandsgebaseerde resource‑referenties, zoals de `Source`‑ of `ImageSource`‑attributen van een afbeelding. Los elke relatieve URI op ten opzichte van de map van het bijbehorende XAML‑artefact, normaliseer de resulterende opslagnaam, en bevestig dat de corresponderende woordenboek‑sleutel, ZIP‑item of opgeslagen object bestaat. Behandel externe URI's en XAML‑markup‑expressies apart van relatieve bestandsnamen.

Bijvoorbeeld, als `pres/Slide_1.xaml` verwijst naar `images/image1.png`, moet de opgeslagen resource beschikbaar zijn als `pres/images/image1.png`. Alleen `image1.png` behouden zou die relatie breken. Voor objectopslag behoud je dezelfde structuur onder de taak‑prefix en maak je die resource‑URL's toegankelijk voor de XAML‑gebruiker. Open het voltooide ZIP‑archief opnieuw om de itemnamen en resource‑bytes te verifiëren, en laad representatieve dia's in de doel‑XAML‑omgeving om te bevestigen dat afbeeldingen correct worden opgezocht.

## **FAQ**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op het apparaat?**

Stel [default_regular_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) in [XamlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/) in — dit wordt gebruikt als fallback‑lettertype tijdens de export wanneer het origineel ontbreekt. Dit garandeert niet dat de gegenereerde XAML naar het fallback‑lettertype verwijst of dat het lettertype beschikbaar is op de doelmachine. Zorg ervoor dat de door de XAML genoemde lettertypen beschikbaar zijn in de omgeving waarin deze wordt weergegeven.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks gebruikt worden?**

Aspose.Slides exporteert WPF‑XAML via de publieke API. Compatibiliteit met andere XAML‑stacks, zoals UWP en Xamarin.Forms, wordt niet gegarandeerd. Test de gegenereerde markup in je doelomgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard geëxporteerd worden?**

Standaard worden verborgen dia's niet opgenomen. Je kunt dit gedrag regelen via [export_hidden_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in [XamlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/) — houd het uitgeschakeld als je ze niet hoeft te exporteren.