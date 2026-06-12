---
title: Převod prezentací PowerPoint do Markdownu v Pythonu
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/python-net/convert-powerpoint-to-markdown/
keywords:
- převést PowerPoint do Markdownu
- převést OpenDocument do Markdownu
- převést prezentaci do Markdownu
- převést snímek do Markdownu
- převést PPT do Markdownu
- převést PPTX do Markdownu
- převést ODP do Markdownu
- převést PowerPoint do MD
- převést OpenDocument do MD
- převést prezentaci do MD
- převést snímek do MD
- převést PPT do MD
- převést PPTX do MD
- převést ODP do MD
- PowerPoint
- OpenDocument
- prezentace
- Markdown
- Python
- Aspose.Slides
description: "Převést snímky PowerPoint a OpenDocument — PPT, PPTX, ODP — do čistého Markdownu pomocí Aspose.Slides pro Python prostřednictvím .NET, automatizovat dokumentaci a zachovat formátování."
---
## **Úvod**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint do Markdownu, což může být užitečné pro pracovní postupy dokumentace, generování statických webů, migraci obsahu a publikování textu pod správou verzí. API podporuje přímý export z prezentací PPT a PPTX do souborů MD a poskytuje další možnosti, jak řídit, jak bude obsah snímků reprezentován v výsledném Markdown dokumentu.

Můžete exportovat prezentace jako prostý Markdown, vybrat si z několika variant Markdownu, jako je CommonMark a GitHub Flavored Markdown, a nastavit, jak budou během exportu zpracovávány obrázky. Pro prezentace, které obsahují vizuální obsah, vám Aspose.Slides také umožní uložit obrázky do samostatné složky a odkazovat na ně v generovaném Markdown souboru.

{{% alert color="warning" %}}
Export z PowerPointu do Markdownu je ve výchozím nastavení **bez obrázků**. Pokud chcete exportovat dokument PowerPoint obsahující obrázky, musíte nastavit `export_type = MarkdownExportType.VISUAL` a zadat `base_path`, kam budou uloženy obrázky odkazované v Markdown dokumentu.
{{% /alert %}}

## **Převod prezentací do Markdownu**

Níže uvedený příklad ukazuje nejjednodušší způsob, jak převést prezentaci PowerPoint do Markdownu pomocí Aspose.Slides pro Python přes .NET s výchozím nastavením.

1. Vytvořte instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pro načtení prezentace.
1. Zavolejte `save` pro export jako soubor Markdown.

Použijte níže uvedený Python úryvek pro provedení převodu:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Převod prezentací do varianty Markdownu**

Aspose.Slides vám umožňuje převádět prezentace do formátů Markdown, včetně základního Markdownu, CommonMark, GitHub-flavored Markdownu, Trello, XWiki, GitLabu a dalších 17 variant Markdownu.

Následující Python příklad ukazuje, jak převést prezentaci PowerPoint do CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

23 podporovaných variant Markdownu je uvedeno v enumeraci [Flavor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) třídy [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Převod prezentací s obrázky do Markdownu**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) poskytuje vlastnosti a výčty, které umožňují nastavit výsledný soubor Markdown. Například výčet [MarkdownExportType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) řídí, jak jsou obrázky zpracovávány: `SEQUENTIAL`, `TEXT_ONLY` nebo `VISUAL`.

### **Převod obrázků sekvenčně**

Pokud chcete, aby se obrázky vygenerovaném Markdownu objevily jednotlivě—jeden po druhém—vyberte možnost `SEQUENTIAL`. Níže uvedený Python příklad ukazuje, jak převést prezentaci s obrázky do Markdownu.

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

### **Převod obrázků vizuálně**

Pokud chcete, aby se obrázky vyskytly společně v výsledném Markdownu, vyberte možnost `VISUAL`. V tomto režimu jsou obrázky uloženy do aktuálního adresáře aplikace (a Markdown dokument používá relativní cesty), nebo můžete zadat vlastní výstupní cestu a název složky.

Níže uvedený Python příklad demonstruje tuto operaci:

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

## **Často kladené otázky**

**Přežijí hypertextové odkazy export do Markdownu?**

Ano. Textové [hyperlinks](/slides/cs/python-net/manage-hyperlinks/) jsou zachovány jako standardní odkazy v Markdownu. Přechody snímků [transitions](/slides/cs/python-net/slide-transition/) a [animations](/slides/cs/python-net/powerpoint-animation/) nejsou převedeny.

**Mohu urychlit konverzi spuštěním ve více vláknech?**

Můžete paralelizovat napříč soubory, ale [don’t share](/slides/cs/python-net/multithreading/) stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) mezi vlákny. Používejte samostatné instance/procesy pro každý soubor, abyste předešli soutěži.

**Co se stane s obrázky—kde jsou uloženy a jsou cesty relativní?**

[Images](/slides/cs/python-net/image/) jsou exportovány do samostatné složky a Markdown soubor na ně odkazuje pomocí relativních cest ve výchozím nastavení. Můžete nastavit základní výstupní cestu a název složky s prostředky, aby struktura repozitáře byla předvídatelná.