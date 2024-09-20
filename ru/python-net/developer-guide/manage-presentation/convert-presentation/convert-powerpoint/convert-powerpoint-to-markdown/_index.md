---
title: Конвертация PowerPoint в Markdown на Python
type: docs
weight: 140
url: /python-net/convert-powerpoint-to-markdown/
keywords: "Конвертация PowerPoint в Markdown, Конвертация ppt в md, PowerPoint, PPT, PPTX, Презентация, Markdown, Python, Aspose.Slides для Python через .NET"
description: "Конвертация PowerPoint в Markdown на Python"
---

{{% alert color="info" %}} 

Поддержка конверсии PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/python-net/aspose-slides-for-python-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown осуществляется **без изображений** по умолчанию. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, вам нужно установить `saveOptions.export_type = MarkdownExportType.VISUAL` и также указать `base_path`, куда будут сохранены изображения, на которые ссылается markdown-документ.

{{% /alert %}} 

## **Конвертация PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), чтобы представить объект презентации.
2. Используйте метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods), чтобы сохранить объект как markdown-файл.

Этот код на Python показывает, как конвертировать PowerPoint в markdown: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:  
    pres.save("pres.md", slides.export.SaveFormat.MD)
```

## Конвертация PowerPoint в вариант Markdown

Aspose.Slides позволяет конвертировать PowerPoint в markdown (с базовым синтаксисом), CommonMark, markdown с расширениями GitHub, Trello, XWiki, GitLab и 17 других вариантов markdown.

Этот код на Python показывает, как конвертировать PowerPoint в CommonMark: 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, Flavor
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    saveOptions = MarkdownSaveOptions()
    saveOptions.flavor = Flavor.COMMONMARK

    pres.save("pres.md", SaveFormat.MD, saveOptions)
```

23 поддерживаемых варианта markdown [перечислены в перечислении Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) из класса [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Конвертация презентации с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, которые позволяют вам использовать определенные параметры или настройки для результирующего markdown-файла. Например, перечисление [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) может быть установлено на значения, которые определяют, как изображения отображаются или обрабатываются: `Sequential`, `TextOnly`, `Visual`.

### **Последовательная конвертация изображений**

Если вы хотите, чтобы изображения отображались по одному в результирующем markdown, вам нужно выбрать последовательный вариант. Этот код на Python показывает, как конвертировать презентацию с изображениями в markdown: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    markdownSaveOptions = slides.export.MarkdownSaveOptions()
    markdownSaveOptions.show_hidden_slides = True
    markdownSaveOptions.show_slide_number = True
    markdownSaveOptions.flavor = slides.export.Flavor.GITHUB
    markdownSaveOptions.export_type = slides.export.MarkdownExportType.SEQUENTIAL
    markdownSaveOptions.new_line_type = slides.export.NewLineType.WINDOWS
    
    pres.save("doc.md", [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ], slides.export.SaveFormat.MD, markdownSaveOptions)
```

### **Визуальная конвертация изображений**

Если вы хотите, чтобы изображения отображались вместе в результирующем markdown, вам нужно выбрать визуальный вариант. В этом случае изображения будут сохранены в текущей директории приложения (и будет построен относительный путь для них в markdown-документе), или вы можете указать предпочитаемый путь и имя папки.

Этот код на Python демонстрирует операцию: 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, MarkdownExportType
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    outPath = "c:\\documents"

    saveOptions = MarkdownSaveOptions()
    saveOptions.export_type = MarkdownExportType.VISUAL
    saveOptions.images_save_folder_name = "md-images"
    saveOptions.base_path = outPath

    pres.save(outPath + "\\pres.md", SaveFormat.MD, saveOptions)
```