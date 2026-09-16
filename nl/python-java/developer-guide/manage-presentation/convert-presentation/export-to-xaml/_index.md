---
title: Presentaties exporteren naar XAML in Python via Java
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/python-java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Export PowerPoint- en OpenDocument-presentaties naar XAML met Aspose.Slides voor Python via Java. Gebruik de standaardopties of neem verborgen dia's op."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt exporteren naar XAML met Aspose.Slides voor Python via Java. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie opslaat naar XAML met standaardinstellingen, en demonstreert hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook een aantal veelvoorkomende vragen over fallback‑lettertypen, compatibiliteit van XAML‑stacks en het gedrag bij het exporteren van verborgen dia's.

De voorbeelden vereisen Aspose.Slides voor Python via Java en een compatibele Java‑runtime. Plaats `pres.pptx` in de huidige werkmap. Elk voorbeeld start de JVM alleen als deze nog niet draait.

## **Over XAML**

XAML is een op XML gebaseerde opmaaktaal die wordt gebruikt om gebruikersinterfaces te beschrijven in frameworks zoals WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin.Forms.

U kunt met XAML‑bestanden werken in een visuele ontwerper of de markup direct schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Het volgende Python‑voorbeeld toont hoe u een presentatie exporteert naar XAML met de standaardinstellingen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Standaard worden de geëxporteerde dia's opgeslagen in een `pres`‑submap van de huidige werkmap van het proces. De map wordt automatisch aangemaakt en eventuele vereiste afbeeldingen worden daar ook opgeslagen.

De naam van de uitvoermap wordt afgeleid van de bestandsnaam van de bron zonder extensie. Voor `pres.pptx` krijgen de uitvoerbestanden de namen `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, enzovoort. Zelfs als u een absoluut pad naar de invoerpresentatie opgeeft, wordt de uitvoermap relatief aan de huidige werkmap aangemaakt, in plaats van naast het invoerbestand.

## **Presentaties exporteren naar XAML met aangepaste opties**

Gebruik de klasse [XamlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/) om te bepalen hoe Aspose.Slides een presentatie exporteert naar XAML.

Om de uitvoer op een aangepaste locatie op te slaan, implementeert u `IXamlOutputSaver` en geeft u een instantie van uw implementatie door aan de [setOutputSaver](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/#setOutputSaver)‑methode van [XamlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/).

Om verborgen dia's op te nemen in de XAML‑uitvoer, roept u [setExportHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) aan met `True`, zoals getoond in het volgende Python‑voorbeeld:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Alle gegenereerde XAML‑artefacten vastleggen**

Een XAML‑export kan een XAML‑document voor elke geëxporteerde dia genereren, plus afzonderlijke afbeeldingen en ondersteunende bronnen. Wijs een aangepaste `IXamlOutputSaver` toe aan [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/#setOutputSaver) om deze artefacten te ontvangen in plaats van de standaard bestandssysteem‑saver. Start de export met de XAML‑specifieke overload van [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) die XAML‑opties accepteert.

In Python gebruikt u `jpype.JProxy` om de Java‑interface `IXamlOutputSaver` te implementeren. Converteer het callback‑pad naar `str` en kopieer de Java‑byte‑array naar Python‑`bytes` voordat u terugkeert, zoals hieronder getoond.

### **Begrijp de levenscyclus van de callback**

De exporter roept `IXamlOutputSaver.save` afzonderlijk aan voor elk gegenereerd artefact:

- `path` identificeert het artefact en kan relatieve mappen bevatten. Bewaar deze informatie omdat XAML mogelijk bronnen via relatieve paden raadpleegt.
- `data` bevat de bytes van het artefact. Afbeeldingen en andere binaire bronnen mogen niet als tekst worden gedecodeerd.
- De saver is verantwoordelijk voor het bewaren of persisteren van de data voordat deze wordt geretourneerd. De voorbeelden kopiëren elke byte‑array naar door de applicatie beheerd geheugen.
- Beschouw de export als geslaagd alleen wanneer de presentatie‑opslaaktactie terugkeert en elke callback succesvol is voltooid. Sluit opslagfouten niet stil en start geen ongecontroleerde achtergrond‑writes. Als persisteren later plaatsvindt, rapporteer dan het algehele succes pas nadat die stap ook is gelukt.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) geldt ook voor een aangepaste saver. De standaardinstelling, `False`, sluit XAML‑documenten van verborgen dia's uit. Het doorgeven van `True` neemt ze op, evenals alle bronnen die nodig zijn voor hun export. Het aantal bronnen hangt af van de presentatie; ga niet uit van één callback per dia of een vaste callback‑volgorde.

### **Exporteren naar geheugen en de artefacten inspecteren**

Dit volledige voorbeeld laadt `pres.pptx`, verzamelt elk artefact in een Python‑dictionary van namen en onveranderlijke `bytes`‑waarden, en drukt de naam, het type en het aantal bytes af. Het behoudt de opgegeven namen precies. Dubbele namen markeren de collectie als ongeldig in plaats van stil een artefact te overschrijven. Het voorbeeld controleert dit vóór gebruik van de resultaten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Decodeer alleen XAML, en alleen wanneer tekstuele inspectie nodig is.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Extensiecontroles zijn nuttig voor inspectie; bewaar alle artefacten, inclusief onbekende brontypen. Laat de bytes ongewijzigd wanneer u ze opslaat of verzendt. Gebruik `bytes.decode` met UTF‑8 alleen voor XAML dat tekstverwerking vereist.

### **Verzamel de artefacten in een ZIP‑archief**

Dit zelfstandige voorbeeld verzamelt de export, valideert de namen en schrijft de originele bytes naar een ZIP‑archief. Een unieke archiefnaam scheidt gelijktijdige export‑taken. ZIP‑items gebruiken schuine strepen en behouden relatieve mappen. Onveilige namen of namen die na normalisatie botsen, leiden tot afwijzing van het volledige pakket voordat het wordt geschreven.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Sluiten finaliseert de ZIP-directory voordat succes gerapporteerd wordt.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

Het voorbeeld gebruikt Python’s `zipfile.ZipFile` om één lokaal archief te schrijven; de exporter zelf schrijft geen losse XAML‑ of afbeeldingsbestanden. Voor externe opslag vervangt u de stap van archiefschrijven door uploads van de verzamelde byte‑arrays. Gebruik een export‑taak‑identifier plus de volledige relatieve artefactnaam als blob‑sleutel, of sla het taak‑identifier, de relatieve naam en de binaire data op in een database‑rij. Publiceer de taak pas nadat alle uploads voltooid zijn of de databasetransactie is gecommit. Ruim gedeeltelijke uitvoer op als persisteren mislukt.

Voor grote presentaties kan een aangepaste saver elk artefact direct naar de applicatieopslag persisteren om te voorkomen dat een extra kopie van de volledige export in het applicatie‑geheugen wordt bewaard. Houd elke callback synchroon vanuit het perspectief van de exporter: retourneer pas nadat de bestemming de bytes heeft geaccepteerd, en laat fouten naar de aanroeper doorgaan.

### **Behoud bron‑namen en verifieer referenties**

- Normaliseer pad‑scheidingstekens wanneer de bestemming dit vereist, maar behoud relatieve mappen. Gebruik niet alleen `pathlib.Path.name` tenzij elke gegenereerde naam bekend uniek is en bron‑referenties geldig blijven.
- Pas bestemmingsspecifieke naambewaking toe. Bij het schrijven van losse bestanden, wijs pad‑namen die beginnen bij de root en traversalsegmenten af, los de bestemming op met `pathlib.Path.resolve`, en controleer dat deze onder de beoogde export‑map blijft, inclusief de map‑scheidingsteken in de containment‑check. Gebruik een door de applicatie gecontroleerde map zonder symbolische links die schrijven kunnen omleiden.
- Gebruik een aparte saver en opslag‑namespace voor elke export‑taak. Detecteer botsingen na normalisatie van scheidingstekens en volgens de hoofdlettergevoeligheidsregels van de bestemming.
- Voordat u publiceert, parseer elk XAML‑document als XML en inspecteer de bestands‑gebaseerde bron‑referenties, zoals de `Source`‑ of `ImageSource`‑attributen van afbeeldingen. Los elke relatieve URI op ten opzichte van de map van het omvattende XAML‑artefact, normaliseer de resulterende opslag‑naam, en bevestig dat de overeenkomstige map‑sleutel, ZIP‑item of opgeslagen object bestaat. Behandel externe URI's en XAML‑markup‑expressies apart van relatieve bestandsnamen.

Bijvoorbeeld, als `pres/Slide_1.xaml` verwijst naar `images/image1.png`, moet de opgeslagen bron beschikbaar zijn als `pres/images/image1.png`. Alleen `image1.png` bewaren zou die relatie verbreken. Voor object‑opslag behoudt u dezelfde structuur onder de taak‑prefix en maakt u die bron‑URL's toegankelijk voor de XAML‑consument. Open het voltooide ZIP‑archief opnieuw om de item‑namen en resource‑bytes te verifiëren, en laad representatieve dia's in de doel‑XAML‑omgeving om te bevestigen dat afbeeldingen correct worden opgezocht.

## **Veelgestelde vragen**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op de machine?**

Roep [setDefaultRegularFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) aan in [XamlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/) — dit wordt gebruikt als fallback‑lettertype tijdens de export wanneer het origineel ontbreekt. Dit garandeert niet dat de gegenereerde XAML naar het fallback‑lettertype verwijst of dat het lettertype beschikbaar is op de doelmachine. Zorg ervoor dat de door de XAML gerefereerde lettertypen beschikbaar zijn in de omgeving waarin het wordt weergegeven.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan ze ook in andere XAML‑stacks worden gebruikt?**

Aspose.Slides exporteert WPF‑XAML via zijn publieke API. Compatibiliteit met andere XAML‑stacks, zoals UWP en Xamarin.Forms, is niet gegarandeerd. Test de gegenereerde markup in uw doelomgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia's niet meegenomen. U kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/) — houd het uitgeschakeld als u ze niet hoeft te exporteren.