---
title: Экспорт презентаций в HTML с внешне связанными изображениями
type: docs
weight: 100
url: /ru/python-java/exporting-presentations-to-html-with-externally-linked-images/
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
- Java
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в HTML на Python с использованием Aspose.Slides, при котором изображения и другие ресурсы сохраняются как внешние связанные файлы."
---
## **Обзор**

По умолчанию Aspose.Slides экспортирует презентацию в автономный HTML‑файл. Изображения и другие ресурсы записываются непосредственно в HTML, обычно в виде данных Base64. Это удобно, когда нужен один переносимый файл, но не всегда является лучшим форматом для веб‑сайта, CMS или серверного конвейера преобразования.

Используйте внешне связанные ресурсы, когда вы хотите:
- уменьшить размер HTML‑документа;
- кешировать изображения, шрифты, аудио или видео отдельно в браузере или CDN;
- просматривать, заменять, сжимать или пост‑обрабатывать сгенерированные ресурсы после экспорта;
- сохранять структуру вывода ближе к тому, что ожидает веб‑приложение.

Для общего рабочего процесса конвертации HTML см. [Convert PowerPoint Presentations to HTML](/slides/ru/python-java/convert-powerpoint-to-html/). Эта статья фокусируется на части экспорта, связанной с ресурсами.

## **Как работает экспорт связанных ресурсов**

`ILinkEmbedController` позволяет вашему приложению решать для каждого ресурса, встраивать ли данные в HTML или сохранять их внешне и записывать ссылку.

Интерфейс имеет три метода:
- `ILinkEmbedController.getObjectStoringLocation` определяет, должен ли ресурс быть связан или встроен.
- `ILinkEmbedController.getUrl` возвращает URL, который будет записан в сгенерированный HTML или в другой связанный ресурс.
- `ILinkEmbedController.saveExternal` записывает данные связанного ресурса на диск или в другое хранилище.

Путь в файловой системе и URL в браузере — это отдельные понятия. Например, приведённый ниже пример записывает файлы ресурсов в `html-output/assets` на диске, тогда как HTML содержит относительные URL, такие как `assets/resource-1.svg`. Браузер разрешает эти URL относительно файла, содержащего ссылку. Следовательно, ссылка из `presentation.html` на SVG‑файл использует `assets/resource-1.svg`, а ссылка из этого SVG‑файла на изображение, сохранённое в той же папке `assets`, использует `resource-4.jpg`.

## **Экспорт HTML со связанными ресурсами**

Следующий пример на Python создаёт каталог вывода, сохраняет в нём HTML‑файл и хранит связанные ресурсы в подпапке `assets`. Контроллер связывает общие изображения, шрифты, аудио, видео и CSS‑ресурсы, когда Aspose.Slides предоставляет или может вывести безопасное расширение файла. Ресурсы, которые не распознаны, остаются встроенными.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

После экспорта папка вывода имеет следующую структуру:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Точные файлы зависят от содержания презентации и параметров экспорта. Например, растровые изображения обычно экспортируются как JPEG или PNG. Aspose.Slides может выбрать другой кодек изображения, чем использовался в исходной презентации, если это приводит к меньшему или более подходящему файлу. Изображения с прозрачностью экспортируются как PNG.

## **Выбор URL для развертывания**

В примере используется относительный префикс URL: `assets/`. Если `presentation.html` открывается из `html-output/presentation.html`, браузер загружает `html-output/assets/resource-1.svg`.

Когда один связанный ресурс ссылается на другой связанный ресурс, пример использует параметр `referrer` в `ILinkEmbedController.getUrl` и возвращает только имя файла. Например, если `resource-1.svg` и `resource-4.jpg` находятся в папке `assets`, SVG‑файл должен ссылаться на `resource-4.jpg`, а не на `assets/resource-4.jpg`.

Используйте другой префикс URL, когда файлы развертываются в другом месте:
- Используйте `assets/`, когда каталог ресурсов находится рядом с HTML‑файлом.
- Используйте `../assets/`, когда каталог ресурсов находится на один уровень выше HTML‑файла.
- Используйте `https://cdn.example.com/presentations/job-123/assets/`, когда файлы загружаются в CDN или на статический файловый сервер.

URL, возвращаемый `ILinkEmbedController.getUrl`, должен соответствовать окончательному размещению файла, записанного `ILinkEmbedController.saveExternal`. В серверных приложениях используйте уникальный каталог вывода или префикс объектного хранилища для каждой задачи конвертации, чтобы избежать перезаписи файлов от другого экспорта.

## **Когда следует вместо этого встраивать**

HTML с встроенными данными Base64 всё ещё полезен, когда вывод должен быть одним файлом, например вложением письма, офлайн‑просмотром или документом, который будет перемещён без отдельной папки ресурсов. Связанные ресурсы лучше подходят, когда HTML будет обслуживаться веб‑приложением, храниться в CMS, оптимизироваться конвейером сборки или кешироваться браузерами независимо от HTML.

## **FAQ**

**Можно ли вынести наружу только изображения и оставить остальные ресурсы встроенными?**

Да. В `ILinkEmbedController.getObjectStoringLocation` возвращайте [LinkEmbedDecision.Link](https://reference.aspose.com/slides/ru/python-java/aspose.slides/linkembeddecision/#Link) только для тех типов содержимого, которые вы хотите сохранять в отдельные файлы, и возвращайте [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/linkembeddecision/#Embed) для всех остальных.

**Почему расширение экспортированного изображения отличается от исходной презентации?**

Aspose.Slides может перекодировать растровые изображения при экспорте в HTML, чтобы уменьшить размер или улучшить совместимость с браузерами. Например, изображение из исходного файла может быть записано как JPEG или PNG в зависимости от результата рендеринга.

**Работают ли относительные URL после перемещения HTML‑файла?**

Относительные URL работают только при сохранении той же относительной структуры папок. Если HTML ссылается на `assets/resource-1.png`, папка `assets` должна оставаться рядом с HTML‑файлом, если только вы не генерируете другой префикс URL.

**Должны ли серверные приложения повторно использовать один и тот же каталог вывода?**

Нет. Используйте уникальный каталог вывода или префикс хранилища для каждой задачи конвертации. Это предотвращает конфликты имён файлов и не позволяет одному экспорту перезаписать ресурсы, созданные другим экспортом.