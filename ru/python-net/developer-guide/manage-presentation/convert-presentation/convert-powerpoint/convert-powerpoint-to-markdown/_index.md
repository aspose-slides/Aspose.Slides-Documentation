---
title: Конвертировать презентации PowerPoint в Markdown с помощью Python
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/python-net/convert-powerpoint-to-markdown/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в MD
- презентация в MD
- слайд в MD
- PPT в MD
- PPTX в MD
- сохранить PowerPoint как Markdown
- сохранить презентацию как Markdown
- сохранить слайд как Markdown
- сохранить PPT как MD
- сохранить PPTX как MD
- экспортировать PPT в MD
- экспортировать PPTX в MD
- экспорт изображений в Markdown
- ссылки на изображения CDN
- PowerPoint
- презентация
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в Markdown на Python и управлять местом сохранения экспортированных изображений и тем, как сгенерированный Markdown ссылается на них."
---
## **Обзор**

Aspose.Slides for Python via .NET может конвертировать презентации PPT и PPTX в Markdown для документации, статических сайтов, миграции контента и рабочих процессов контроля версий. Вы можете выбрать вариант Markdown, управлять тем, как отображается содержимое слайдов, и решить, где хранить экспортированные изображения и как сгенерированный Markdown будет ссылаться на них.

По умолчанию экспорт в Markdown использует только текстовый вывод. Чтобы экспортировать визуальное содержимое, установите свойство [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownsaveoptions/export_type/) в значение `SEQUENTIAL` или `VISUAL` из перечисления [MarkdownExportType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` рендерит элементы слайда отдельно и по порядку, тогда как `VISUAL` сохраняет сгруппированные элементы вместе, чтобы сохранить их визуальное отношение. Значение `TEXT_ONLY` не создает ресурсы изображений.

## **Преобразовать презентацию в Markdown**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), а затем вызовите метод [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ipresentation/save/) с значением `MD` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Выбрать вариант Markdown**

Свойство [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownsaveoptions/flavor/) контролирует спецификацию Markdown, используемую для вывода. Перечисление [Flavor](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/flavor/) включает CommonMark, GitHub Flavored Markdown и другие поддерживаемые варианты.

Следующий пример экспортирует презентацию как CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Экспорт изображений с использованием поведения сохранения по умолчанию**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownsaveoptions/) предоставляет два свойства для локально сохраняемых изображений:

- [base_path](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownsaveoptions/base_path/) указывает базовый каталог для документа Markdown и его ресурсов.
- [images_save_folder_name](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) указывает подпапку изображений. Значение по умолчанию `Images`.

Следующий пример рендерит визуальное содержимое, записывает изображения в `output/assets` и создаёт относительные ссылки на изображения в документе Markdown:

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

Aspose.Slides создаёт подпапку изображений, когда экспорт создаёт ресурсы изображений, но приложение должно создать `base_path` перед сохранением файла Markdown.

## **Подготовить Markdown и изображения к публикации**

Aspose.Slides for Python via .NET не предоставляет .NET обратные вызовы сохранения изображений для замены каждой сгенерированной ссылки на изображение во время экспорта. Вместо этого экспортируйте документ Markdown и его папку с изображениями в каталог публикации, а затем публикуйте этот каталог, не меняя его относительную структуру.

Следующий пример готовит `cdn-origin/presentations/quarterly-report` как смонтированный или синхронизированный каталог публикации. Сам пример не выполняет сетевую загрузку: сгенерированные ссылки станут действительными после публикации каталога в целевом сайте или CDN.

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

Опубликуйте `presentation.md` вместе с каталогом `assets`. Документ Markdown использует относительные ссылки на изображения, поэтому оба элемента должны сохранять одинаковое отношение в месте назначения. Если система публикации требует абсолютных внешних URL, преобразуйте сгенерированные ссылки в отдельном постобработочном этапе после публикации всех файлов изображений.

## **FAQ**

**Можно ли с помощью обратных вызовов Python настроить отдельные файлы изображений и ссылки при экспорте в Markdown?**

Нет. Aspose.Slides for Python via .NET не предоставляет .NET `ImageSaving` и `SvgImageSaving` обратные вызовы. Настройте локальный вывод с помощью [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownsaveoptions/base_path/) и [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), затем публикуйте или постобрабатывайте сгенерированные ресурсы.

**Где сохраняются экспортированные изображения?**

Расположение изображения контролируется [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownsaveoptions/base_path/) и [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Документ Markdown ссылается на эти изображения через относительные пути.

**Какой разделитель пути следует использовать в ссылках на изображения?**

Используйте прямые слеши в ссылках Markdown и URL. `os.path.join` используйте только для путей файловой системы и нормализуйте любые ссылки, созданные во время постобработки, отдельно.

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [hyperlinks](/slides/ru/python-net/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. Переходы слайдов [transitions](/slides/ru/python-net/slide-transition/) и [animations](/slides/ru/python-net/powerpoint-animation/) не конвертируются.

**Можно ли преобразовывать несколько презентаций в Markdown параллельно?**

Вы можете обрабатывать разные файлы презентаций параллельно, но не разделяйте один экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) между потоками. Следуйте [multithreading guidelines](/slides/ru/python-net/multithreading/) и используйте отдельный экземпляр для каждого файла.