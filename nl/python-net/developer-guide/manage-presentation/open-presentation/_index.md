---
title: Open presentaties in Python
linktitle: Open presentaties
type: docs
weight: 20
url: /nl/python-net/open-presentation/
keywords:
- PowerPoint openen
- presentatie openen
- PPTX openen
- PPT openen
- ODP openen
- presentatie laden
- PPTX laden
- PPT laden
- ODP laden
- beveiligde presentatie
- grote presentatie
- externe bron
- binair object
- Python
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) en OpenDocument (.odp) presentaties moeiteloos met Aspose.Slides voor Python via .NET—snel, betrouwbaar, volledig uitgerust."
---
## **Inleiding**

Naast het maken van PowerPoint-presentaties vanaf nul, stelt Aspose.Slides u ook in staat om bestaande presentaties te openen. Nadat u een presentatie hebt geladen, kunt u informatie erover ophalen, de inhoud van dia's bewerken, nieuwe dia's toevoegen, bestaande dia's verwijderen en meer.

## **Open presentaties**

Om een bestaande presentatie te openen, maakt u een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse en geeft u het bestandspad door aan de constructor.

Het volgende Python-voorbeeld laat zien hoe u een presentatie opent en het aantal dia's opvraagt:

```python
import aspose.slides as slides

# Instantieer de Presentation-klasse en geef een bestandspad door aan de constructor.
with slides.Presentation("sample.pptx") as presentation:
    # Print het totale aantal dia's in de presentatie.
    print(presentation.slides.length)
```

## **Open wachtwoordbeveiligde presentaties**

Wanneer u een wachtwoordbeveiligde presentatie moet openen, geeft u het wachtwoord door via de [password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/) eigenschap van de [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/) klasse om deze te ontsleutelen en te laden. De volgende Python-code toont deze bewerking:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Voer bewerkingen uit op de gedecodeerde presentatie.
```

## **Open grote presentaties**

Aspose.Slides biedt opties—met name de [blob_management_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/blob_management_options/) eigenschap in de [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/) klasse—om u te helpen grote presentaties te laden.

Deze Python-code laat zien hoe u een grote presentatie laadt (bijvoorbeeld 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Kies het KeepLocked-gedrag—het presentiebestand blijft vergrendeld voor de levensduur van 
# de Presentation-instantie, maar het hoeft niet in het geheugen geladen te worden of gekopieerd naar een tijdelijk bestand.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # De grote presentatie is geladen en kan worden gebruikt, terwijl het geheugenverbruik laag blijft.

    # Breng wijzigingen aan in de presentatie.
    presentation.slides[0].name = "Large presentation"

    # Sla de presentatie op naar een ander bestand. Het geheugenverbruik blijft laag tijdens deze bewerking.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Doe dit niet! Er wordt een I/O‑exception gegooid omdat het bestand vergrendeld blijft tot het presentatie‑object wordt vrijgegeven.
    os.remove(file_path)

# Het is hier wel toegestaan. Het bronbestand is niet meer vergrendeld door het presentatie‑object.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van een stream kopiëren. Het laden van een grote presentatie vanuit een stream zorgt ervoor dat de presentatie gekopieerd wordt, wat het laden kan vertragen. Daarom raden wij u ten zeerste aan om, wanneer u een grote presentatie moet laden, het bestandspad van de presentatie te gebruiken in plaats van een stream.

Wanneer u een presentatie maakt die grote objecten bevat (video, audio, afbeeldingen met hoge resolutie, enz.), kunt u [BLOB-management](/slides/nl/python-net/manage-blob/) gebruiken om het geheugenverbruik te verminderen.
{{%/alert %}}

## **Presentaties laden zonder ingebedde binaire objecten**

Een PowerPoint-presentatie kan de volgende typen ingebedde binaire objecten bevatten:

- VBA-project (toegankelijk via [Presentation.vba_project](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/vba_project/));
- OLE-object ingebedde gegevens (toegankelijk via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- ActiveX-besturings-binaire gegevens (toegankelijk via [Control.active_x_control_binary](https://reference.aspose.com/slides/nl/python-net/aspose.slides/control/active_x_control_binary/)).

Met behulp van de [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) eigenschap kunt u een presentatie laden zonder enige ingebedde binaire objecten.

Deze eigenschap is nuttig om potentieel kwaadwillende binaire inhoud te verwijderen. Het volgende Python-voorbeeld toont hoe u een presentatie laadt zonder enige ingebedde binaire inhoud:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Voer bewerkingen uit op de presentatie.
```

## **FAQ**

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

U krijgt tijdens het laden een parsing-/formaatvalidatie-exception. Dergelijke fouten vermelden vaak een ongeldige ZIP-structuur of beschadigde PowerPoint-records.

**Wat gebeurt er als vereiste lettertypen ontbreken bij het openen?**

Het bestand wordt geopend, maar later kan bij [renderen/exporteren](/slides/nl/python-net/convert-presentation/) het lettertype worden vervangen. [Configureer lettertype-substituties](/slides/nl/python-net/font-substitution/) of [voeg de vereiste lettertypen toe](/slides/nl/python-net/custom-font/) aan de runtime-omgeving.

**Wat gebeurt er met ingebedde media (video/audio) bij het openen?**

Ze worden beschikbaar als presentatieresources. Als media via externe paden worden gerefereerd, zorg er dan voor dat die paden toegankelijk zijn in uw omgeving; anders kan bij [renderen/exporteren](/slides/nl/python-net/convert-presentation/) de media worden weggelaten.