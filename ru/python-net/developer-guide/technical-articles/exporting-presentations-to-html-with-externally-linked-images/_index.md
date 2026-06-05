---
title: Экспорт презентаций в HTML с внешними связанными изображениями в Python
linktitle: Экспорт презентаций в HTML с внешними связанными изображениями
type: docs
weight: 100
url: /ru/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- экспорт слайда
- экспорт PPT
- экспорт PPTX
- экспорт ODP
- PowerPoint в HTML
- OpenDocument в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- ODP в HTML
- связанное изображение
- внешне связанное изображение
- связанный ресурс
- внешний ресурс
- Python
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в HTML в Python с использованием Aspose.Slides, при котором изображения сохраняются как внешние связанные файлы."
---
## **Обзор**

По умолчанию Aspose.Slides экспортирует презентацию в автономный HTML‑файл. Изображения и другие ресурсы записываются непосредственно в HTML, обычно в виде данных Base64. Это удобно, когда нужен один переносимый файл, но не всегда оптимально для веб‑сайта, CMS или серверного конвейера конверсии.

Используйте внешние ссылки на изображения, когда необходимо:

- уменьшить размер HTML‑документа;
- кэшировать изображения отдельно в браузере или CDN;
- проверять, заменять, сжимать или пост‑обрабатывать сгенерированные изображения после экспорта;
- сохранить структуру вывода ближе к той, которую ожидает веб‑приложение.

Для общего процесса конверсии в HTML см. [Преобразовать презентации PowerPoint в HTML](/slides/ru/python-net/convert-powerpoint-to-html/). В этой статье рассматривается только часть экспорта, связанная с ссылками на изображения.

## **Как работает экспорт с внешними изображениями**

В .NET и Java интерфейс [ILinkEmbedController](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/ilinkembedcontroller/) представляет обратный вызов, который экспортер использует для решения, встраивать ресурс или ссылаться на него. В Python через .NET классы Python в настоящее время не могут напрямую реализовать этот .NET‑интерфейс, поэтому практический процесс выглядит так:

1. Экспортировать презентацию в HTML с помощью [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/).
1. Использовать [SlideImageFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/slideimageformat/) совместно с [SVGOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/), чтобы слайды в HTML представлялись как SVG.
1. Переместить данные изображений Base64 из URL‑ов `data:` в отдельные файлы.
1. Заменить исходные URL‑ы `data:` относительными ссылками, например `assets/resource-1.jpg`.

Путь в файловой системе и URL в браузере — разные понятия. Например, в примере ниже изображения сохраняются в `html-output/assets` на диске, а HTML содержит относительные URL‑ы типа `assets/resource-1.jpg`. Браузер разрешает такие ссылки относительно HTML‑файла, где они находятся.

## **Экспорт HTML с внешними изображениями**

Следующий пример на Python создаёт выходной каталог, сохраняет туда HTML‑файл, сохраняет извлечённые изображения в подпапку `assets` и меняет URL‑ы изображений Base64 на относительные ссылки. Пример извлекает общие форматы Base64‑изображений, когда Aspose.Slides предоставляет безопасное расширение файла. URL‑ы данных, которые не распознаны, остаются встроенными.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

После экспорта папка вывода может иметь следующую структуру:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Точные файлы зависят от содержимого презентации и параметров экспорта. Например, растровые изображения обычно экспортируются как JPEG или PNG. Aspose.Slides может выбрать иной кодек изображения, чем использовался в исходной презентации, если это приводит к более маленькому или более подходящему файлу. Изображения с прозрачностью экспортируются как PNG.

## **Выбор URL‑ов для развёртывания**

В примере используется относительный префикс URL: `assets/`. Если `presentation.html` открывается из `html-output/presentation.html`, браузер загрузит `html-output/assets/resource-1.jpg`.

Используйте другое имя каталога ресурсов или измените сгенерированные ссылки, когда файлы развёртываются в другом месте:

- Используйте `assets/`, когда каталог ресурсов находится рядом с HTML‑файлом.
- Используйте `../assets/`, когда каталог ресурсов на один уровень выше HTML‑файла.
- Используйте `https://cdn.example.com/presentations/job-123/assets/`, когда файлы загружаются в CDN или на статический файловый сервер.

В серверных приложениях используйте уникальный каталог вывода или префикс в объектном хранилище для каждой задачи конверсии, чтобы не перезаписывать файлы от другого экспорта.

## **Когда лучше встраивать**

HTML с встроенными Base64‑данными всё ещё полезен, когда вывод должен быть единым файлом, например вложением в письмо, офлайн‑просмотром или документом, который будет перемещён без сопроводительной папки ресурсов. Внешние изображения более подходят, когда HTML будет обслуживаться веб‑приложением, храниться в CMS, оптимизироваться сборочным конвейером или кэшироваться браузерами независимо от HTML.

## **FAQ**

**Можно ли вынести только изображения и оставить остальные ресурсы встроенными?**

Да. Пример извлекает только Base64‑URL‑ы `image/*`, перечисленные в `EXTENSIONS_BY_CONTENT_TYPE`. Остальные URL‑ы данных остаются встроенными.

**Почему расширение экспортированного изображения отличается от исходного в презентации?**

Aspose.Slides может перекодировать растровые изображения при экспорте в HTML, чтобы улучшить размер или совместимость с браузерами. Например, изображение из исходного файла может быть записано как JPEG или PNG в зависимости от результата рендеринга.

**Работают ли относительные URL‑ы после перемещения HTML‑файла?**

Относительные URL‑ы работают только при сохранении одинаковой относительной структуры папок. Если HTML ссылается на `assets/resource-1.png`, папка `assets` должна оставаться рядом с HTML‑файлом, если только вы не зададите иной префикс URL.

**Должны ли серверные приложения повторно использовать один и тот же каталог вывода?**

Нет. Используйте уникальный каталог вывода или префикс хранилища для каждой задачи конверсии. Это исключает столкновения имён файлов и предотвращает перезапись ресурсов, созданных другим экспортом.