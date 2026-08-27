---
title: Konvertera PowerPoint-presentationer till Markdown i Python
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/python-net/convert-powerpoint-to-markdown/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till MD
- presentation till MD
- bild till MD
- PPT till MD
- PPTX till MD
- spara PowerPoint som Markdown
- spara presentation som Markdown
- spara bild som Markdown
- spara PPT som MD
- spara PPTX som MD
- exportera PPT till MD
- exportera PPTX till MD
- Markdown‑bildexport
- CDN‑bildlänkar
- PowerPoint
- presentation
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till Markdown i Python och kontrollera var exporterade bilder sparas samt hur den genererade Markdown-referensen hanterar dem."
---
## **Översikt**

Aspose.Slides for Python via .NET kan konvertera PPT- och PPTX-presentationer till Markdown för dokumentation, statiska webbplatser, innehållsmigrering och versionskontrollflöden. Du kan välja en Markdown‑variant, kontrollera hur bildinnehåll renderas och bestämma var exporterade bilder lagras samt hur den genererade Markdown‑referensen hanterar dem.

Som standard använder Markdown‑export text‑endast‑utdata. För att exportera visuellt innehåll, sätt egenskapen [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownsaveoptions/export_type/) till värdet `SEQUENTIAL` eller `VISUAL` från uppräkningen [MarkdownExportType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` renderar bildobjekt separat och i ordning, medan `VISUAL` behåller grupperade objekt tillsammans för att bevara deras visuella relation. Värdet `TEXT_ONLY` genererar inga bildresurser.

## **Konvertera en presentation till Markdown**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/), och anropa sedan metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ipresentation/save/) med värdet `MD` från uppräkningen [SaveFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Välj en Markdown‑variant**

Egenskapen [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownsaveoptions/flavor/) styr vilken Markdown‑specifikation som används för utskriften. Uppräkningen [Flavor](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/flavor/) innehåller CommonMark, GitHub Flavored Markdown och andra stödda varianter.

Följande exempel exporterar en presentation som CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Exportera bilder med standardbeteendet för lokal sparning**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownsaveoptions/) tillhandahåller två egenskaper för lokalt sparade bilder:

- [base_path](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownsaveoptions/base_path/) anger baskatalogen för Markdown‑dokumentet och dess resurser.
- [images_save_folder_name](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) anger bildundermappen. Standardvärdet är `Images`.

Följande exempel renderar visuellt innehåll, skriver bilder till `output/assets` och skapar relativa bildreferenser i Markdown‑dokumentet:

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

Aspose.Slides skapar bildundermappen när exporten genererar bildresurser, men applikationen måste skapa `base_path` innan Markdown‑filen sparas.

## **Förbered Markdown och bilder för publicering**

Aspose.Slides for Python via .NET exponerar inte .NET‑callback‑funktionerna för bildsparning för att ersätta varje genererad bildlänk under export. Exportera istället Markdown‑dokumentet och dess bildmapp till en publiceringskatalog och publicera sedan den katalogen utan att förändra dess relativa struktur.

Följande exempel förbereder `cdn-origin/presentations/quarterly-report` som en monterad eller synkroniserad publiceringskatalog. Exemplet utför ingen nätverksuppladdning: de genererade länkarna blir giltiga efter att katalogen har publicerats på den avsedda platsen eller CDN‑platsen.

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

Publicera `presentation.md` tillsammans med `assets`‑katalogen. Markdown‑dokumentet använder relativa bildreferenser, så båda objekten måste behålla samma förhållande på destinationen. Om ett publiceringssystem kräver absoluta externa URL‑er, skriv om de genererade länkarna som ett separat efterbearbetningssteg efter att alla bildfiler har publicerats.

## **FAQ**

**Kan Python‑callback‑funktioner anpassa enskilda bildfiler och länkar under Markdown‑export?**

Nej. Aspose.Slides for Python via .NET exponerar inte .NET‑callback‑funktionerna `ImageSaving` och `SvgImageSaving`. Konfigurera den lokala utdata med [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownsaveoptions/base_path/) och [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), publicera sedan eller efterbearbeta de genererade resurserna.

**Var sparas exporterade bilder?**

Bildplatsen styrs av [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownsaveoptions/base_path/) och [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Markdown‑dokumentet refererar till dessa bilder med relativa sökvägar.

**Vilken sökvägsseparator bör bildlänkar använda?**

Använd snedstreck (`/`) i Markdown‑länkar och URL‑er. Använd `os.path.join` endast för filsystemssökvägar och normalisera eventuella länkar som skapas under efterbearbetning separat.

**Behålls hyperlänkar under Markdown‑export?**

Ja. Text-[hyperlänkar](/slides/sv/python-net/manage-hyperlinks/) bevaras som standard‑Markdown‑länkar. Bild-[övergångar](/slides/sv/python-net/slide-transition/) och [animationer](/slides/sv/python-net/powerpoint-animation/) konverteras inte.

**Kan presentationer konverteras till Markdown parallellt?**

Du kan bearbeta olika presentationsfiler parallellt, men dela inte samma [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans mellan trådar. Följ [multithreading‑riktlinjerna](/slides/sv/python-net/multithreading/) och använd en separat instans för varje fil.