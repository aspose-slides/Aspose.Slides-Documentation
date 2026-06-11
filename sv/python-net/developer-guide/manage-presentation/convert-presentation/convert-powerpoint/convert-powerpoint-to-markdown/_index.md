---
title: Konvertera PowerPoint-presentationer till Markdown i Python
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/python-net/convert-powerpoint-to-markdown/
keywords:
- konvertera PowerPoint till Markdown
- konvertera OpenDocument till Markdown
- konvertera presentation till Markdown
- konvertera bild till Markdown
- konvertera PPT till Markdown
- konvertera PPTX till Markdown
- konvertera ODP till Markdown
- konvertera PowerPoint till MD
- konvertera OpenDocument till MD
- konvertera presentation till MD
- konvertera bild till MD
- konvertera PPT till MD
- konvertera PPTX till MD
- konvertera ODP till MD
- PowerPoint
- OpenDocument
- presentation
- Markdown
- Python
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder—PPT, PPTX, ODP—till ren Markdown med Aspose.Slides för Python via .NET, automatisera dokumentation och bevara formatering."
---
## **Introduktion**

Aspose.Slides låter dig konvertera PowerPoint-presentationer till Markdown, vilket kan vara användbart för dokumentationsarbetsflöden, statisk webbplatsgenerering, innehållsmigration och versionskontrollerad textpublicering. API:et stöder direkt export från PPT- och PPTX-presentationer till MD-filer och erbjuder ytterligare alternativ för att styra hur bildinnehåll representeras i det resulterande Markdown-dokumentet.

Du kan exportera presentationer som ren Markdown, välja bland flera Markdown-varianter såsom CommonMark och GitHub Flavored Markdown, och konfigurera hur bilder hanteras vid export. För presentationer som innehåller visuellt innehåll låter Aspose.Slides dig även spara bilder i en separat mapp och referera till dem från den genererade Markdown-filen.

{{% alert color="warning" %}}
PowerPoint‑till‑Markdown‑export är **utan bilder** som standard. Om du vill exportera ett PowerPoint‑dokument som innehåller bilder måste du sätta `export_type = MarkdownExportType.VISUAL` och ange `base_path`, där bilderna som refereras i Markdown‑dokumentet sparas.
{{% /alert %}}

## **Konvertera presentationer till Markdown**

Exemplet nedan visar det enklaste sättet att konvertera en PowerPoint-presentation till Markdown med Aspose.Slides för Python via .NET med standardinställningar.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för att läsa in presentationen.
1. Anropa `save` för att exportera den som en Markdown‑fil.

Använd Python‑kodsnutten nedan för att utföra konverteringen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Konvertera presentationer till Markdown‑variant**

Aspose.Slides låter dig konvertera presentationer till Markdown‑format, inklusive grundläggande Markdown, CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab och 17 andra Markdown‑varianter.

Följande Python‑exempel visar hur man konverterar en PowerPoint-presentation till CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

De 23 stödda Markdown‑varianterna listas i enumerationen [Flavor](https://reference.aspose.com/slides/sv/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) i klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Konvertera presentationer som innehåller bilder till Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)‑klassen erbjuder egenskaper och enumerationer som låter dig konfigurera den resulterande Markdown‑filen. Till exempel styr enumen [MarkdownExportType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) hur bilder hanteras: `SEQUENTIAL`, `TEXT_ONLY` eller `VISUAL`.

### **Konvertera bilder sekventiellt**

Om du vill att bilder ska visas individuellt—en efter en—i den genererade Markdown‑filen, välj alternativet `SEQUENTIAL`. Python‑exemplet nedan visar hur man konverterar en presentation med bilder till Markdown.

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

### **Konvertera bilder visuellt**

Om du vill att bilderna ska visas tillsammans i den resulterande Markdown‑filen, välj alternativet `VISUAL`. I detta läge sparas bilderna till programmets aktuella katalog (och Markdown‑dokumentet använder relativa sökvägar), eller så kan du ange en egen utskrivningssökväg och mappnamn.

Python‑exemplet nedan demonstrerar denna operation:

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

**Behåller hyperlänkar exporten till Markdown?**

Ja. Text-[hyperlänkar](/slides/sv/python-net/manage-hyperlinks/) bevaras som standard‑Markdown‑länkar. Slide-[övergångar](/slides/sv/python-net/slide-transition/) och [animationer](/slides/sv/python-net/powerpoint-animation/) konverteras inte.

**Kan jag snabba upp konverteringen genom att köra den i flera trådar?**

Du kan parallellisera över filer, men [dela inte](/slides/sv/python-net/multithreading/) samma [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans mellan trådar. Använd separata instanser/processer per fil för att undvika konkurrens.

**Vad händer med bilderna—var sparas de och är sökvägarna relativa?**

[Bilder](/slides/sv/python-net/image/) exporteras till en dedikerad mapp, och Markdown‑filen refererar till dem med relativa sökvägar som standard. Du kan konfigurera den grundläggande utskrivningssökvägen och namn på tillgångsmappen för att behålla en förutsägbar lagringsstruktur.