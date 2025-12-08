---
title: Преобразование презентаций PowerPoint в Markdown на Python
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/python-net/convert-powerpoint-to-markdown/
keywords:
- конвертировать PowerPoint в Markdown
- конвертировать OpenDocument в Markdown
- конвертировать презентацию в Markdown
- конвертировать слайд в Markdown
- конвертировать PPT в Markdown
- конвертировать PPTX в Markdown
- конвертировать ODP в Markdown
- конвертировать PowerPoint в MD
- конвертировать OpenDocument в MD
- конвертировать презентацию в MD
- конвертировать слайд в MD
- конвертировать PPT в MD
- конвертировать PPTX в MD
- конвертировать ODP в MD
- PowerPoint
- OpenDocument
- презентация
- Markdown
- Python
- Aspose.Slides
description: "Преобразуйте слайды PowerPoint и OpenDocument — PPT, PPTX, ODP — в чистый Markdown с помощью Aspose.Slides для Python через .NET, автоматизируйте создание документации и сохраняйте форматирование."
---

## **Преобразование презентаций в Markdown**

Пример ниже показывает самый простой способ преобразовать презентацию PowerPoint в Markdown с помощью Aspose.Slides for Python via .NET с настройками по умолчанию.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для загрузки презентации.
1. Вызовите `save` для экспорта её в файл Markdown.

Используйте нижеприведённый фрагмент кода на Python для выполнения преобразования:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```


## **Преобразование презентаций в варианты Markdown**

Aspose.Slides позволяет преобразовывать презентации в форматы Markdown, включая базовый Markdown, CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab и ещё 17 вариантов Markdown.

Ниже приведён пример на Python, показывающий, как преобразовать презентацию PowerPoint в CommonMark:
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```


23 поддерживаемых варианта Markdown перечислены в перечислении [Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Преобразование презентаций, содержащих изображения, в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие настроить итоговый файл Markdown. Например, перечисление [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) управляет способом обработки изображений: `SEQUENTIAL`, `TEXT_ONLY` или `VISUAL`.

### **Последовательное преобразование изображений**

Если требуется, чтобы изображения выводились по отдельности — одно за другим — в сгенерированном Markdown, выберите параметр `SEQUENTIAL`. Пример на Python ниже показывает, как преобразовать презентацию с изображениями в Markdown.
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


### **Визуальное преобразование изображений**

Если необходимо, чтобы изображения выводились вместе в итоговом Markdown, выберите параметр `VISUAL`. В этом режиме изображения сохраняются в текущий каталог приложения (а документ Markdown использует относительные пути) либо можно указать пользовательский путь вывода и имя папки.

Ниже приведён пример на Python, демонстрирующий эту операцию:
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

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [hyperlinks](/slides/ru/python-net/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. Переходы слайдов [transitions](/slides/ru/python-net/slide-transition/) и [animations](/slides/ru/python-net/powerpoint-animation/) не конвертируются.

**Можно ли ускорить преобразование, запустив его в нескольких потоках?**

Можно параллелить обработку по файлам, но [don’t share](/slides/ru/python-net/multithreading/) один и тот же объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — куда они сохраняются и являются ли пути относительными?**

[Images](/slides/ru/python-net/image/) экспортируются в отдельную папку, а файл Markdown по умолчанию ссылается на них относительными путями. Можно настроить базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.