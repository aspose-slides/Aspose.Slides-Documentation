---
title: Převod prezentací PowerPoint do Markdownu v Pythonu
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/python-net/convert-powerpoint-to-markdown/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do MD
- prezentace do MD
- snímek do MD
- PPT do MD
- PPTX do MD
- uložit PowerPoint jako Markdown
- uložit prezentaci jako Markdown
- uložit snímek jako Markdown
- uložit PPT jako MD
- uložit PPTX jako MD
- exportovat PPT do MD
- exportovat PPTX do MD
- export obrázků do Markdownu
- CDN odkazy na obrázky
- PowerPoint
- prezentace
- Markdown
- Python
- Python přes .NET
- Aspose.Slides
description: "Převod prezentací PPT a PPTX do Markdownu v Pythonu a kontrola, kde jsou ukládány exportované obrázky a jak je generovaný Markdown na ně odkazuje."
---
## **Přehled**

Aspose.Slides for Python via .NET může převádět prezentace PPT a PPTX do Markdownu pro dokumentaci, statické weby, migraci obsahu a pracovní postupy s verzovacím systémem. Můžete si vybrat variantu Markdownu, řídit, jak je obsah snímků vykreslen, a rozhodnout, kde jsou ukládány exportované obrázky a jak je generovaný Markdown na ně odkazuje.

Ve výchozím nastavení export do Markdownu používá výstup pouze s textem. Pro export vizuálního obsahu nastavte vlastnost [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownsaveoptions/export_type/) na hodnotu `SEQUENTIAL` nebo `VISUAL` z výčtu [MarkdownExportType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` vykresluje položky snímků samostatně a v pořadí, zatímco `VISUAL` zachovává seskupené položky dohromady, aby se udržel jejich vizuální vztah. Hodnota `TEXT_ONLY` nevypisuje zdroje obrázků.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```
## **Převést prezentaci do Markdownu**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), a poté zavolejte metodu [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ipresentation/save/) s hodnotou `MD` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```
## **Vybrat variantu Markdownu**

Vlastnost [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownsaveoptions/flavor/) řídí specifikaci Markdownu použitého pro výstup. Výčet [Flavor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/flavor/) zahrnuje CommonMark, GitHub Flavored Markdown a další podporované varianty.

Následující příklad exportuje prezentaci ve formátu CommonMark:

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
## **Exportovat obrázky pomocí výchozího lokálního ukládání**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownsaveoptions/) poskytuje dvě vlastnosti pro lokálně ukládané obrázky:

- [base_path](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownsaveoptions/base_path/) určuje základní adresář pro Markdown dokument a jeho prostředky.
- [images_save_folder_name](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) určuje podadresář pro obrázky. Jeho výchozí hodnota je `Images`.

Následující příklad vykresluje vizuální obsah, zapisuje obrázky do `output/assets` a vytváří relativní odkazy na obrázky v Markdown dokumentu:

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
## **Připravit Markdown a obrázky pro publikaci**

Aspose.Slides for Python via .NET neexponuje .NET zpětné volání pro ukládání obrázků, která by umožňovala nahrazovat každý vygenerovaný odkaz na obrázek během exportu. Místo toho exportujte Markdown dokument a jeho složku s obrázky do publikovacího adresáře a poté tento adresář publikujte bez změny jeho relativní struktury.

Následující příklad připraví `cdn-origin/presentations/quarterly-report` jako připojený nebo synchronizovaný publikovací adresář. Vzorek samotný neprovádí žádné nahrávání do sítě: vygenerované odkazy se stanou platnými po publikaci adresáře na zamýšleném webu nebo CDN místě.

Publikujte `presentation.md` spolu se složkou `assets`. Markdown dokument používá relativní odkazy na obrázky, takže oba položky musí zachovat stejný vztah v cíli. Pokud publikační systém vyžaduje absolutní externí URL, přepište vygenerované odkazy v samostatném kroku po zpracování po publikaci všech souborů s obrázky.

## **Často kladené otázky**

**Mohou Python zpětné volání přizpůsobit jednotlivé soubory obrázků a odkazy během exportu do Markdownu?**

Ne. Aspose.Slides for Python via .NET neexponuje .NET zpětná volání `ImageSaving` a `SvgImageSaving`. Nakonfigurujte lokální výstup pomocí [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownsaveoptions/base_path/) a [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), poté publikujte nebo provádějte následné zpracování vygenerovaných zdrojů.

**Kde jsou exportované obrázky ukládány?**

Umístění obrázků řídí [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownsaveoptions/base_path/) a [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Markdown dokument odkazuje na tyto obrázky pomocí relativních cest.

**Jaký oddělovač cesty by měly odkazy na obrázky používat?**

V odkazech a URL v Markdownu používejte lomítka (`/`). `os.path.join` používejte jen pro cesty v souborovém systému a jakýkoli odkaz vytvořený během následného zpracování normalizujte samostatně.

**Jsou hypertextové odkazy při exportu do Markdownu zachovány?**

Ano. Textové [hyperlinky](/slides/cs/python-net/manage-hyperlinks/) jsou zachovány jako standardní Markdown odkazy. Přechody [snímků](/slides/cs/python-net/slide-transition/) a [animace](/slides/cs/python-net/powerpoint-animation/) nejsou převáděny.

**Lze prezentace převádět do Markdownu paralelně?**

Můžete zpracovávat různé soubory prezentací paralelně, ale nesdílejte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) mezi vlákny. Dodržujte [pokyny pro multithreading](/slides/cs/python-net/multithreading/) a použijte samostatnou instanci pro každý soubor.