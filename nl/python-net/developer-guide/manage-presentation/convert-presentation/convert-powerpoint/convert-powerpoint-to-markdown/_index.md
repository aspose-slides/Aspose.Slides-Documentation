---
title: PowerPoint‑presentaties converteren naar Markdown in Python
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar MD
- presentatie naar MD
- dia naar MD
- PPT naar MD
- PPTX naar MD
- PowerPoint opslaan als Markdown
- presentatie opslaan als Markdown
- dia opslaan als Markdown
- PPT opslaan als MD
- PPTX opslaan als MD
- PPT exporteren naar MD
- PPTX exporteren naar MD
- Markdown‑afbeeldingsexport
- CDN‑afbeeldingslinks
- PowerPoint
- presentatie
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Converteer PPT- en PPTX‑presentaties naar Markdown in Python en bepaal waar geëxporteerde afbeeldingen worden opgeslagen en hoe de gegenereerde Markdown ernaar verwijst."
---
## **Overzicht**

Aspose.Slides for Python via .NET kan PPT- en PPTX‑presentaties converteren naar Markdown voor documentatie, statische sites, content‑migratie en versie‑beheersystemen. Je kunt een Markdown‑variant kiezen, bepalen hoe de inhoud van de dia’s wordt gerenderd en beslissen waar geëxporteerde afbeeldingen worden opgeslagen en hoe de gegenereerde Markdown ernaar verwijst.

Standaard gebruikt de Markdown‑export alleen tekstoutput. Om visuele inhoud te exporteren, stel je de [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownsaveoptions/export_type/) eigenschap in op de `SEQUENTIAL`‑ of `VISUAL`‑waarde uit de [MarkdownExportType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownexporttype/) enumeratie. `SEQUENTIAL` rendert dia‑elementen afzonderlijk en in volgorde, terwijl `VISUAL` gegroepeerde elementen samenhoudt om hun visuele relatie te behouden. De waarde `TEXT_ONLY` genereert geen afbeeldingsbronnen.

## **Een presentatie naar Markdown converteren**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse en roep vervolgens de [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ipresentation/save/) methode aan met de `MD`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/) enumeratie.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Selecteer een Markdown‑variant**

De eigenschap [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownsaveoptions/flavor/) bepaalt welke Markdown‑specificatie wordt gebruikt voor de output. De enumeratie [Flavor](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/flavor/) bevat CommonMark, GitHub Flavored Markdown en andere ondersteunde varianten.

Het volgende voorbeeld exporteert een presentatie als CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Afbeeldingen exporteren met het standaard lokaal‑opslaggedrag**

De klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownsaveoptions/) biedt twee eigenschappen voor lokaal opgeslagen afbeeldingen:

- [base_path](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownsaveoptions/base_path/) specificeert de basisdirectory voor het Markdown‑document en de bijbehorende bronnen.
- [images_save_folder_name](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) geeft de subdirectory voor afbeeldingen aan. De standaardwaarde is `Images`.

Het volgende voorbeeld rendert visuele inhoud, schrijft afbeeldingen naar `output/assets` en maakt relatieve afbeeldingsverwijzingen in het Markdown‑document:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides maakt de afbeeldings‑subdirectory aan wanneer de export afbeeldingsbronnen produceert, maar de applicatie moet `base_path` aanmaken voordat het Markdown‑bestand wordt opgeslagen.

## **Markdown en afbeeldingen voorbereiden voor publicatie**

Aspose.Slides for Python via .NET biedt de .NET‑callbacks voor het opslaan van afbeeldingen niet aan om elke gegenereerde afbeeldingslink tijdens export te vervangen. Exporteer in plaats daarvan het Markdown‑document en de afbeeldingsmap naar een publicatiemap en publiceer die map zonder de relatieve structuur te wijzigen.

Het volgende voorbeeld bereidt `cdn-origin/presentations/quarterly-report` voor als een aangekoppelde of gesynchroniseerde publicatiemap. Het voorbeeld voert zelf geen netwerk‑upload uit: de gegenereerde links worden geldig zodra de map is gepubliceerd op de beoogde site of CDN‑locatie.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Publiceer `presentation.md` samen met de `assets`‑directory. Het Markdown‑document gebruikt relatieve afbeeldingsverwijzingen, zodat beide items dezelfde relatie moeten behouden op de bestemming. Als een publicatiesysteem absolute externe URL’s vereist, herschrijf dan de gegenereerde links in een aparte nabewerkingsstap nadat alle afbeeldingsbestanden zijn gepubliceerd.

## **FAQ**

**Kunnen Python‑callbacks individuele afbeeldingsbestanden en -links aanpassen tijdens Markdown‑export?**

Nee. Aspose.Slides for Python via .NET biedt de .NET‑callbacks `ImageSaving` en `SvgImageSaving` niet aan. Configureer de lokale output met [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownsaveoptions/base_path/) en [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), publiceer vervolgens of verwerk de gegenereerde bronnen na de export.

**Waar worden geëxporteerde afbeeldingen opgeslagen?**

De locatie van de afbeeldingen wordt bepaald door [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownsaveoptions/base_path/) en [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Het Markdown‑document verwijst naar die afbeeldingen met relatieve paden.

**Welke pad‑scheidingsteken moet worden gebruikt in afbeeldingslinks?**

Gebruik schuine strepen (`/`) in Markdown‑links en URL’s. Gebruik `os.path.join` alleen voor bestandssysteem‑paden, en normaliseer iedere link die tijdens nabewerking wordt aangemaakt apart.

**Worden hyperlinks behouden tijdens Markdown‑export?**

Ja. Tekst-[hyperlinks](/slides/nl/python-net/manage-hyperlinks/) blijven behouden als standaard Markdown‑links. Dia-[overgangen](/slides/nl/python-net/slide-transition/) en -[animaties](/slides/nl/python-net/powerpoint-animation/) worden niet omgezet.

**Kunnen presentaties parallel naar Markdown worden geconverteerd?**

Je kunt verschillende presentaties parallel verwerken, maar deel dezelfde [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) instantie niet tussen threads. Volg de [multithreading guidelines](/slides/nl/python-net/multithreading/) en gebruik voor elk bestand een aparte instantie.