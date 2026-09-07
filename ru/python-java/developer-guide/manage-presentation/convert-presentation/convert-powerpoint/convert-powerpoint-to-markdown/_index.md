---
title: Конвертировать презентации PowerPoint в Markdown в Python через Java
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/python-java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в Markdown в Python через Java и управлять тем, где сохраняются и как ссылаются экспортированные bitmap, metafile и SVG изображения."
---
## **Обзор**

Aspose.Slides for Python via Java может конвертировать презентации PPT и PPTX в Markdown для документации, статических сайтов, миграции контента и процессов контроля версий. Вы можете выбрать вариант Markdown, управлять тем, как отображается содержимое слайдов, и решить, где будут храниться экспортированные изображения и как сгенерированный Markdown будет на них ссылаться.

По умолчанию экспорт в Markdown использует только текстовый вывод. Чтобы экспортировать визуальное содержимое, задайте тип экспорта с помощью метода [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/#setExportType) со значением `Sequential` или `Visual` из перечисления [MarkdownExportType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownexporttype/). `Sequential` рендерит элементы слайдов отдельно и последовательно, тогда как `Visual` сохраняет сгруппированные элементы вместе, чтобы сохранить их визуальные отношения. Значение `TextOnly` не создает ресурсы изображений, поэтому обратные вызовы сохранения изображений не вызываются в этом режиме.

## **Конвертирование презентации в Markdown**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и затем вызовите метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с значением `Md` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Каждый пример читает `presentation.pptx` из текущего рабочего каталога. Установите Aspose.Slides for Python via Java и совместимую Java‑runtime перед запуском примеров. Запускайте JVM один раз на каждый процесс Python.

## **Выбор варианта Markdown**

Метод [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/#setFlavor) определяет спецификацию Markdown, используемую для вывода. Перечисление [Flavor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/flavor/) включает CommonMark, GitHub Flavored Markdown и другие поддерживаемые варианты.

Следующий пример экспортирует презентацию в формате CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Экспорт изображений с поведением сохранения по умолчанию**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/) предоставляет два метода для настройки локального сохранения изображений:

- [setBasePath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/#setBasePath) задаёт базовый каталог для Markdown‑документа и его ресурсов.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) задаёт подпапку для изображений. Значение по умолчанию — `Images`.

Следующий пример рендерит визуальное содержимое, записывает изображения в `output/assets` и создаёт относительные ссылки на изображения в документе Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Это поведение также служит резервным вариантом, когда пользовательский обработчик сохранения изображений возвращает `False`.

## **Настройка сохранения изображений и ссылок в Markdown**

Используйте метод [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/) для регистрации обратного вызова для bitmap‑ и metafile‑ресурсов, генерируемых при экспорте в Markdown. Его обратный вызов `MarkdownImageSavingHandler` получает объект изображения, его значение [ImageFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imageformat/) и сгенерированную ссылку в виде одноэлементного массива `String[]`. Сохраните или загрузите изображение в указанном формате и замените `link[0]` на ссылку, которую необходимо поместить в вывод Markdown.

Ресурсы, выдаваемые в формате SVG, обрабатываются отдельно. Зарегистрируйте обратный вызов с помощью метода [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/). Его обратный вызов `MarkdownSvgImageSavingHandler` получает объект [SvgImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgimage/) и одноэлементный массив `String[] link`. У SVG нет аргумента `ImageFormat`; вместо этого запишите или загрузите его XML‑данные, получив их через метод [SvgImage.getSvgData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgimage/#getSvgData). В зависимости от режима экспорта и визуального группирования SVG в исходной презентации может быть растрирован или объединён с другим содержимым; полученный не‑SVG‑ресурс затем передаётся в обратный вызов сохранения изображения. Регистрация обоих обратных вызовов требуется, когда каждый экспортируемый визуальный ресурс нуждается в пользовательской обработке.

Значение, возвращаемое обработчиком, определяет, кто будет обрабатывать изображение:

- Верните `True`, если обработчик сохранил, загрузил, преобразовал или иначе обработал изображение и присвоил корректное значение `link[0]`. Aspose.Slides запишет это значение в документ Markdown и не выполнит локальное сохранение по умолчанию.
- Верните `False`, чтобы позволить Aspose.Slides сохранить изображение локально и сформировать ссылку согласно параметрам, установленным через [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/#setBasePath) и [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}

Обработчик, возвращающий `True`, берёт на себя ответственность за изображение. Если он возвращает `True`, но не задаёт корректную, непустую ссылку, экспорт завершится с `InvalidOperationException`.

{{% /alert %}}

В Python регистрируйте эти обратные вызовы с помощью `jpype.JProxy`, реализуя Java‑интерфейс обратного вызова через его метод `invoke`. Аргумент `link` — изменяемый массив строк Java: сконвертируйте `link[0]` в строку Python перед обработкой, затем запишите заменённый URL обратно в `link[0]`.

### **Сохранение изображений в каталог CDN‑origin и использование внешних URL**

Следующий пример рассматривает `cdn-origin/presentations/quarterly-report` как смонтированный или синхронизированный каталог CDN‑origin. Каждый обработчик извлекает сгенерированное имя файла, сохраняет изображение в эту пользовательскую папку и заменяет локальную ссылку на публичный CDN‑URL. Сам пример не выполняет загрузку в сеть: URL станет действительным только после монтирования каталога как CDN‑origin или публикации файлов в CDN. Для объектного хранилища замените запись в файловой системе на загрузку через SDK хранилища и присвойте `link[0]` только после успешной загрузки.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Обработчик bitmap‑изображений намеренно возвращает `False` для изображений меньше 128 × 128 пикселей, поэтому Aspose.Slides сохраняет такие изображения в `output/fallback-images` с поведением по умолчанию. Большие bitmap‑ и metafile‑ресурсы, а также SVG‑ресурсы обрабатываются пользовательским кодом. Например, локальная ссылка `fallback-images/image1.png` превращается в `https://cdn.example.com/presentations/quarterly-report/image1.png`. Обработчики используют пути операционной системы только при записи файлов; ссылки, записываемые в Markdown, используют прямой слеш и URL‑экранированные имена файлов. Применяйте то же правило при построении относительных ссылок: используйте `/`, а не разделитель каталога, специфичный для платформы.

## **FAQ**

**Можно ли одним обработчиком обрабатывать как растровые изображения, так и SVG?**

Нет. Используйте [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/) для bitmap‑ и metafile‑ресурсов и [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/) для SVG‑ресурсов. Первый передаёт объект изображения и значение [ImageFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imageformat/); второй — объект [SvgImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgimage/), данные которого можно получить через [SvgImage.getSvgData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgimage/#getSvgData). SVG‑исходник, растрированный во время экспорта, обрабатывается обработчиком сохранения изображений.

**Что происходит, когда обработчик сохранения изображения возвращает `False`?**

Aspose.Slides использует поведение сохранения по умолчанию. Местоположение изображения и сгенерированная ссылка управляются параметрами, установленными через [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/#setBasePath) и [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Может ли обработчик предоставить URL без локального сохранения изображения?**

Да. Обработчик может загрузить изображение в объектное хранилище или передать его другому сервису, присвоить полученный URL `link[0]` и вернуть `True`. Обработчик обязан полностью выполнить обработку; возврат `True` отключает локальное сохранение.

**Почему экспорт в Markdown выдаёт `InvalidOperationException` из обработчика?**

Это происходит, когда обработчик возвращает `True`, но не предоставляет корректную ссылку. Присвойте `link[0]` относительный путь или внешний URL, который должен быть записан в Markdown, перед возвратом `True`.

**Каким разделителем путей должны пользоваться ссылки на изображения?**

В ссылках Markdown и URL используйте прямой слеш (`/`). Для файловой системы используйте `pathlib.Path`, а затем отдельно формируйте/нормализуйте ссылку для Markdown.

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [hyperlinks](/slides/ru/python-java/manage-hyperlinks/) сохраняются как обычные ссылки Markdown. Переходы слайдов [transitions](/slides/ru/python-java/slide-transition/) и [animations](/slides/ru/python-java/powerpoint-animation/) не конвертируются.

**Можно ли конвертировать несколько презентаций в Markdown параллельно?**

Можно обрабатывать разные файлы презентаций параллельно, но не делитесь одним объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) между потоками. Следуйте [guidelines](/slides/ru/python-java/multithreading/) и используйте отдельный экземпляр для каждого файла.