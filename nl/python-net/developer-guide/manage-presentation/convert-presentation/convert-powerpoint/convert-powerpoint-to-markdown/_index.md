---
title: PowerPoint-presentaties converteren naar Markdown in Python
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren naar Markdown
- OpenDocument converteren naar Markdown
- presentatie converteren naar Markdown
- dia converteren naar Markdown
- PPT converteren naar Markdown
- PPTX converteren naar Markdown
- ODP converteren naar Markdown
- PowerPoint converteren naar MD
- OpenDocument converteren naar MD
- presentatie converteren naar MD
- dia converteren naar MD
- PPT converteren naar MD
- PPTX converteren naar MD
- ODP converteren naar MD
- PowerPoint
- OpenDocument
- presentatie
- Markdown
- Python
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's—PPT, PPTX, ODP—naar nette Markdown met Aspose.Slides voor Python via .NET, automatiseer documentatie en behoud opmaak."
---
## **Inleiding**

Aspose.Slides stelt je in staat om PowerPoint‑presentaties te converteren naar Markdown, wat handig kan zijn voor documentatie‑workflows, statische site‑generatie, content‑migratie en versie‑gecontroleerd tekst‑publiceren. De API ondersteunt directe export van PPT‑ en PPTX‑presentaties naar MD‑bestanden en biedt extra opties om te bepalen hoe de inhoud van de dia’s wordt weergegeven in het resulterende Markdown‑document.

Je kunt presentaties exporteren als gewone Markdown, kiezen uit verschillende Markdown‑varianten zoals CommonMark en GitHub‑Flavored‑Markdown, en configureren hoe afbeeldingen worden verwerkt tijdens de export. Voor presentaties die visuele inhoud bevatten, laat Aspose.Slides je bovendien afbeeldingen opslaan in een aparte map en ze verwijzen vanuit het gegenereerde Markdown‑bestand.

{{% alert color="warning" %}}

PowerPoint‑naar‑Markdown‑export is standaard **zonder afbeeldingen**. Als je een PowerPoint‑document met afbeeldingen wilt exporteren, moet je `export_type = MarkdownExportType.VISUAL` instellen en `base_path` opgeven, waar de afbeeldingen die in het Markdown‑document worden verwezen, worden opgeslagen.

{{% /alert %}}

## **Presentaties Converteren naar Markdown**

Het onderstaande voorbeeld toont de eenvoudigste manier om een PowerPoint‑presentatie naar Markdown te converteren met Aspose.Slides voor Python via .NET met de standaardinstellingen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) instantie aan om de presentatie te laden.
1. Roep `save` aan om deze als een Markdown‑bestand te exporteren.

Gebruik de onderstaande Python‑codefragment om de conversie uit te voeren:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Presentaties Converteren naar Markdown‑Variant**

Aspose.Slides stelt je in staat om presentaties te converteren naar Markdown‑formaten, waaronder basic Markdown, CommonMark, GitHub‑flavored‑Markdown, Trello, XWiki, GitLab en nog 17 andere Markdown‑varianten.

Het volgende Python‑voorbeeld laat zien hoe je een PowerPoint‑presentatie naar CommonMark converteert:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

De 23 ondersteunde Markdown‑varianten staan opgesomd in de [Flavor](https://reference.aspose.com/slides/nl/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) enumeratie van de klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Presentaties met Afbeeldingen Converteren naar Markdown**

De klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) biedt eigenschappen en enumeraties waarmee je het resulterende Markdown‑bestand kunt configureren. Bijvoorbeeld, de enum [MarkdownExportType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) bepaalt hoe afbeeldingen worden behandeld: `SEQUENTIAL`, `TEXT_ONLY` of `VISUAL`.

### **Afbeeldingen Sequentieel Converteren**

Als je wilt dat afbeeldingen afzonderlijk—een voor een—in de gegenereerde Markdown verschijnen, kies dan de optie `SEQUENTIAL`. Het onderstaande Python‑voorbeeld laat zien hoe je een presentatie met afbeeldingen naar Markdown converteert.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Afbeeldingen Visueel Converteren**

Als je wilt dat de afbeeldingen samen in de resulterende Markdown verschijnen, kies dan de optie `VISUAL`. In deze modus worden afbeeldingen opgeslagen in de huidige map van de applicatie (en gebruikt het Markdown‑document relatief paden), of je kunt een aangepast uitvoerpad en mapnaam opgeven.

Het onderstaande Python‑voorbeeld demonstreert deze operatie:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **FAQ**

**Blijven hyperlinks behouden bij export naar Markdown?**

Ja. Tekst‑[hyperlinks](/slides/nl/python-net/manage-hyperlinks/) worden behouden als standaard Markdown‑links. Dia‑[transitions](/slides/nl/python-net/slide-transition/) en [animations](/slides/nl/python-net/powerpoint-animation/) worden niet geconverteerd.

**Kan ik de conversie versnellen door deze in meerdere threads uit te voeren?**

Je kunt paralleliseren over bestanden, maar [don’t share](/slides/nl/python-net/multithreading/) dezelfde [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) instantie over threads. Gebruik afzonderlijke instanties/processen per bestand om conflicten te vermijden.

**Wat gebeurt er met afbeeldingen — waar worden ze opgeslagen en zijn de paden relatief?**

[Images](/slides/nl/python-net/image/) worden geëxporteerd naar een aparte map, en het Markdown‑bestand verwijst standaard naar hen met relatieve paden. Je kunt het basisuitvoerpad en de mapnaam voor assets configureren om een voorspelbare repository‑structuur te behouden.