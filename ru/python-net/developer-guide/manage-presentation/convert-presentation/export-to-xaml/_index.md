---
title: Экспорт презентаций в XAML с Python
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/python-net/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертация PowerPoint
- конвертация OpenDocument
- конвертация презентации
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- сохранить PPT как XAML
- сохранить PPTX как XAML
- сохранить ODP как XAML
- экспорт PPT в XAML
- экспорт PPTX в XAML
- экспорт ODP в XAML
- Python
- Aspose.Slides
description: "Конвертировать слайды PowerPoint и OpenDocument в XAML с помощью Python и Aspose.Slides — быстрое решение без Office, сохраняющее макет неизменным."
---
## **Обзор**

Эта статья объясняет, как экспортировать презентации PowerPoint в XAML с помощью Aspose.Slides. Она содержит краткое введение в XAML, показывает, как сохранить презентацию в XAML с настройками по умолчанию, и демонстрирует, как настроить экспорт через [XamlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export.xaml/xamloptions/), включая экспорт скрытых слайдов. В статье также даны ответы на несколько распространённых вопросов, связанных с резервными шрифтами, совместимостью стека XAML и поведением экспорта скрытых слайдов.

## **Об XAML**

XAML — это основанный на XML язык разметки, используемый для описания пользовательских интерфейсов в таких фреймворках, как WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin.Forms.

Вы можете работать с файлами XAML в визуальном дизайнере или писать и редактировать разметку напрямую.

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Следующий пример на Python показывает, как экспортировать презентацию в XAML с настройками по умолчанию:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

По умолчанию экспортированные слайды сохраняются в подпапке `pres` текущего рабочего каталога процесса, полученного с помощью [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). Папка создаётся автоматически, и любые необходимые изображения также сохраняются там.

Имя папки вывода берётся из имени исходного файла без расширения. Для `pres.pptx` файлы вывода называются `pres/Slide_1.xaml`, `pres/Slide_2.xaml` и т.д. Даже если вы передаёте абсолютный путь к входной презентации, папка вывода создаётся относительно текущего рабочего каталога, а не рядом с входным файлом.

## **Экспорт презентаций в XAML с пользовательскими параметрами**

Используйте класс [XamlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export.xaml/xamloptions/) для управления тем, как Aspose.Slides экспортирует презентацию в XAML.

Чтобы включить скрытые слайды в вывод XAML, установите свойство [export_hidden_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) в значение `True`, как показано в следующем примере на Python:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Сохранение всех сгенерированных XAML артефактов**

Экспорт XAML может создавать документ XAML для каждого экспортированного слайда, а также отдельные изображения и вспомогательные ресурсы. Сохраняйте все эти файлы при хранении или передаче экспорта.

Приведённые ниже примеры используют стандартный файловый сохранятор во временном каталоге, а затем собирают сгенерированные файлы.

### **Понимание жизненного цикла экспорта**

- Начинайте экспорт с XAML‑специфичной перегрузки [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/), принимающей параметры XAML. Читайте сгенерированные файлы только после успешного возврата функции.
- Сохраняйте относительный путь каждого артефакта, так как XAML может ссылаться на ресурсы с помощью относительных путей.
- Читайте артефакты как байты. Изображения и другие бинарные ресурсы не должны декодироваться как текст.
- Сообщайте об успешном завершении только после сбора и завершения любой последующей операции хранения. Позвольте ошибкам хранения достичь вызывающего кода и удаляйте частичный вывод, если сохранение не удалось.

[XamlOptions.export_hidden_slides] по умолчанию имеет значение `False`, что исключает XAML‑документы скрытых слайдов. Установка в `True` включает их и любые ресурсы, необходимые для их экспорта. Количество ресурсов зависит от презентации; не предполагаете один файл на слайд.

{{% alert color="warning" title="Warning" %}}
The examples temporarily change the process's current working directory, which affects all threads. Run each export in a dedicated worker process, or ensure that no other work in the process depends on the current directory during export. A unique temporary directory alone does not make concurrent exports in the same process safe.
{{% /alert %}}

### **Экспорт в память и проверка артефактов**

Этот полный пример загружает `pres.pptx`, экспортирует её во временный каталог, собирает каждый артефакт в словарь относительных имён и байтов, и выводит его имя, тип и количество байтов. Он сохраняет структуру каталога и удаляет временные файлы после сбора. Путь к входному файлу разрешается до изменения рабочего каталога.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Декодировать только XAML и только когда требуется текстовая проверка.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Проверка расширений полезна для инспекции; сохраняйте все артефакты, включая неизвестные типы ресурсов. Оставляйте байты без изменений при хранении или передаче. Декодируйте только XAML, требующий текстовой обработки. Этот подход использует как временное дисковое пространство, так и память для собранного экспорта.

### **Упаковка собранных артефактов в ZIP‑архив**

Этот независимый пример собирает экспорт, проверяет имена и записывает оригинальные байты в ZIP‑архив. Уникальное имя архива разделяет задачи экспорта. Записи ZIP используют прямые слэши и сохраняют относительные каталоги. Небезопасные имена или имена, конфликтующие после нормализации, отклоняют весь пакет до записи.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # Каталог ZIP был завершён перед сообщением об успехе.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Пример использует [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) для записи одного локального архива после сбора временного экспорта. Для удалённого хранилища замените этап записи архива загрузкой собранных байтов. Используйте идентификатор задачи экспорта плюс полное относительное имя артефакта в качестве ключа объекта, либо храните идентификатор задачи, относительное имя и бинарные данные в строке базы данных. Публикуйте задачу только после завершения всех загрузок или фиксации транзакции базы данных. Удаляйте частичный вывод, если сохранение не удалось.

Для больших презентаций обрабатывайте временные файлы по одному после экспорта, а не собирайте все их байты в словарь. Это избегает дополнительной копии всего экспорта в памяти, но не устраняет требования экспортёра к памяти.

### **Сохранение имен ресурсов и проверка ссылок**

- Нормализуйте разделители путей, если этого требует место назначения, но сохраняйте относительные каталоги. Не оставляйте только финальное имя файла, если только каждый сгенерированный путь не гарантировано уникален и ссылки на ресурсы остаются корректными.
- Применяйте проверку имён, специфичную для места назначения. При записи отдельных файлов отклоняйте абсолютные пути и сегменты перехода, разрешайте место назначения и проверяйте, что он остаётся внутри целевого каталога экспорта. Используйте контролируемый приложением каталог без символических ссылок, которые могут перенаправлять запись.
- Используйте отдельное пространство имён хранилища для каждой задачи экспорта. Обнаруживайте коллизии после нормализации разделителей и в соответствии с правилами чувствительности к регистру места назначения.
- Перед публикацией парсите каждый XAML‑документ как XML и проверяйте его ссылки на файловые ресурсы, такие как атрибуты `Source` или `ImageSource` изображений. Разрешайте каждый относительный URI относительно каталога содержащего XAML‑артефакта, нормализуйте полученное имя для хранения и подтверждайте, что соответствующий ключ словаря, запись ZIP или сохранённый объект существует. Обрабатывайте внешние URI и выражения разметки XAML отдельно от относительных имён файлов.

Например, если `pres/Slide_1.xaml` ссылается на `images/image1.png`, сохранённый ресурс должен быть доступен как `pres/images/image1.png`. Сохранение только `image1.png` нарушит эту связь. Для объектного хранилища сохраняйте тот же макет под префиксом задачи и делайте эти URL‑ы ресурсов доступными потребителю XAML. Перепроверьте завершённый ZIP, чтобы убедиться в правильных именах записей и байтах ресурсов, а также загрузите типичные слайды в целевой XAML‑окружении, чтобы подтвердить корректное разрешение изображений.

## **Часто задаваемые вопросы**

**Как обеспечить предсказуемый шрифт, если оригинальный шрифт недоступен на машине?**

Установите [default_regular_font](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) в [XamlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export.xaml/xamloptions/) — он используется в качестве резервного шрифта при экспорте, когда оригинальный шрифт отсутствует. Это не гарантирует, что сгенерированный XAML будет ссылаться на резервный шрифт или что шрифт будет доступен на целевой машине. Убедитесь, что шрифты, указанные в XAML, доступны в окружении, где он отображается.

**Предназначен ли экспортированный XAML только для WPF, или его можно использовать и в других стеках XAML?**

Aspose.Slides экспортирует XAML для WPF через публичный API. Совместимость с другими стеками XAML, такими как UWP и Xamarin.Forms, не гарантируется. Протестируйте сгенерированную разметку в целевом окружении.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [export_hidden_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) в [XamlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export.xaml/xamloptions/) — оставьте его отключённым, если экспорт скрытых слайдов не требуется.