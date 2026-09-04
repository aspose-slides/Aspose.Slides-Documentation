---
title: Openen van presentaties in Python
linktitle: Openen van presentaties
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
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties in Python kunt openen, openings-wachtwoorden kunt opgeven en het geheugenverbruik kunt verminderen met Aspose.Slides voor Python via .NET."
---
## **Inleiding**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/nl/python-net/) kan PowerPoint‑ en OpenDocument‑presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kun je de structuur inspecteren, dia’s bewerken, bronnen beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de klasse [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/). Je kunt bijvoorbeeld een openings‑wachtwoord opgeven, grote binaire objecten buiten het geheugen houden, of ingebedde binaire data weglaten.

## **Presentaties openen**

Om een bestaande presentatie te openen, geef je het bestandspad door aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/). Gebruik een `with`‑statement zodat bestands‑handles, tijdelijke data en andere bronnen tijdig worden vrijgegeven.

Het volgende Python‑voorbeeld laat zien hoe je een presentatie opent en het aantal dia’s opvraagt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Presentaties openen die met een wachtwoord zijn beveiligd**

Een openings‑wachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, wijs je het juiste wachtwoord toe aan [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/) en geef je de opties door aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/). Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Voor wachtwoorddetectie, -validatie en versleutelings‑workflows, zie [Password‑Protect Presentations](/slides/nl/python-net/password-protected-presentation/). Als een versleutelde presentatie bewust is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen zonder wachtwoord worden gelezen; zie [Manage Presentation Properties](/slides/nl/python-net/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/blob_management_options/) bepaalt hoe Aspose.Slides omgaat met grote binaire objecten zoals afbeeldingen, audio en video. Je kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑data die in het geheugen wordt bewaard beperken.

Deze Python‑code toont het laden van een grote presentatie (bijvoorbeeld 2 GB):

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

Met `PresentationLockingBehavior.KEEP_LOCKED` blijft het bronbestand vergrendeld totdat het `Presentation`‑object wordt verwijderd. Verplaats, overschrijf of verwijder het bronbestand niet zolang dat object nog leeft.

Aspose.Slides kan de inhoud van een invoerstroom kopiëren tijdens het laden. Voor grote presentaties is een bestandspad over het algemeen efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/python-net/manage-blob/) voor extra opslag‑ en geheugembeheeropties.

{{% /alert %}}

## **Presentaties laden zonder ingebedde binaire objecten**

Een presentatie kan ingebedde binaire data bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA‑projecten, beschikbaar via [Presentation.vba_project](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/vba_project/);
- ingebedde OLE‑data, beschikbaar via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- ActiveX‑controldata, beschikbaar via [Control.active_x_control_binary](https://reference.aspose.com/slides/nl/python-net/aspose.slides/control/active_x_control_binary/).

Stel [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) in op `True` om deze binaire data te verwijderen tijdens het laden. Sla de geladen presentatie op om het opgeschoonde resultaat te bewaren.

Deze optie vermindert de blootstelling aan ongewenste ingebedde payloads, maar vormt geen volledige malware‑detectie‑ of content‑sanitiserings‑systeem.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hoe kan ik zien dat een bestand corrupt is en niet kan worden geopend?**

Aspose.Slides geeft tijdens het laden een parse‑ of formatexceptie. Verwerk die fout apart van een fout met een onjuist wachtwoord zodat de applicatie de oorzaak nauwkeurig kan melden.

**Wat gebeurt er als verplichte lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar renderen en exporteren kan lettertypen vervangen. Je kunt [lettertype‑substitutie configureren](/slides/nl/python-net/font-substitution/) of [aangepaste lettertypen aanbieden](/slides/nl/python-net/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio‑ en videot bestanden worden beschikbaar via het presentatie‑objectmodel. Externe bronnen worden opgezocht volgens het standaard‑resource‑laadgedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.