---
title: Open Presentaties in Python
linktitle: Open Presentaties
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
description: "Leer hoe je PowerPoint- en OpenDocument‑presentaties opent in Python, openings‑wachtwoorden opgeeft en het geheugenverbruik vermindert met Aspose.Slides for Python via .NET."
---
## **Introductie**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/nl/python-net/) kan PowerPoint- en OpenDocument‑presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kun je de structuur inspecteren, dia’s bewerken, middelen beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/) klasse. Bijvoorbeeld kun je een openingswachtwoord opgeven, grote binaire objecten buiten het geheugen houden, of ingebedde binaire gegevens weglaten.

## **Open Presentaties**

Na het laden van een bestand of stream kun je [de oorspronkelijke presentatie‑indeling bepalen](/slides/nl/python-net/detect-presentation-source-format/) om te kiezen hoe je applicatie deze verwerkt.

Om een bestaande presentatie te openen, geef je het bestandspad door aan de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) constructor. Gebruik een `with`‑statement zodat bestands‑handles, tijdelijke gegevens en andere middelen direct worden vrijgegeven.

Het volgende Python‑voorbeeld laat zien hoe je een presentatie opent en het aantal dia’s ophaalt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Openen van wachtwoord‑beveiligde presentaties**

Een openingswachtwoord versleutelt de presentatie‑inhoud. Om de volledige presentatie te laden, wijs je het juiste wachtwoord toe aan [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/) en geef je de opties door aan de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Voor wachtwoorddetectie, -validatie en versleutelings‑workflows, zie [Password-Protect Presentations](/slides/nl/python-net/password-protected-presentation/). Als een versleutelde presentatie opzettelijk is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen worden gelezen zonder wachtwoord; zie [Manage Presentation Properties](/slides/nl/python-net/presentation-properties/).

## **Openen van grote presentaties**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/blob_management_options/) bepaalt hoe Aspose.Slides binaire grote objecten zoals afbeeldingen, audio en video afhandelt. Je kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen worden bewaard beperken.

Deze Python‑code laat zien hoe een grote presentatie geladen wordt (bijvoorbeeld 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Met `PresentationLockingBehavior.KEEP_LOCKED` blijft het bronbestand vergrendeld totdat het `Presentation`‑object wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet zolang dat object leeft.

Aspose.Slides kan de inhoud van een invoer‑stream kopiëren tijdens het laden. Voor grote presentaties is een bestandspad daarom meestal efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/python-net/manage-blob/) voor extra opslag‑ en geheugen‑beheeropties.
{{% /alert %}}

## **Laad presentaties zonder ingebedde binaire objecten**

Een presentatie kan ingebedde binaire gegevens bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA‑projecten, beschikbaar via [Presentation.vba_project](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/vba_project/);
- ingebedde OLE‑gegevens, beschikbaar via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- ActiveX‑controlegegevens, beschikbaar via [Control.active_x_control_binary](https://reference.aspose.com/slides/nl/python-net/aspose.slides/control/active_x_control_binary/).

Stel [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) in op `True` om deze binaire gegevens tijdens het laden te verwijderen. Sla de geladen presentatie op om het opgeschoonde resultaat te behouden.

Deze optie verkleint de blootstelling aan ongewenste ingebedde payloads, maar is geen volledig malware‑detectie‑ of inhoud‑sanitisatiesysteem.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

Aspose.Slides geeft tijdens het laden een parse‑ of formaat‑exceptie. Behandel die fout afzonderlijk van een foutmelding over een onjuist wachtwoord, zodat de applicatie de oorzaak nauwkeurig kan melden.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen vervangen. Je kunt [font‑substitutie configureren](/slides/nl/python-net/font-substitution/) of [aangepaste lettertypen leveren](/slides/nl/python-net/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video zijn beschikbaar via het presentatie‑objectmodel. Externe bronnen worden opgelost volgens het standaard gedrag voor het laden van middelen en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.