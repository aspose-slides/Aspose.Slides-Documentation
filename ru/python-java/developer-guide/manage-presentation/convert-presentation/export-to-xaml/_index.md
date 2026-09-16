---
title: Экспорт презентаций в XAML на Python через Java
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/python-java/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- преобразование PowerPoint
- преобразование OpenDocument
- преобразование презентации
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
- Java
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в XAML с помощью Aspose.Slides for Python via Java. Используйте параметры по умолчанию или включайте скрытые слайды."
---
## **Обзор**

Эта статья объясняет, как экспортировать презентации PowerPoint в XAML с помощью Aspose.Slides for Python via Java. В ней содержится краткое введение в XAML, показано, как сохранить презентацию в XAML с настройками по умолчанию, и продемонстрировано, как настроить экспорт с помощью [XamlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/), включая экспорт скрытых слайдов. Статья также отвечает на несколько часто задаваемых вопросов, связанных с резервными шрифтами, совместимостью стека XAML и поведением экспорта скрытых слайдов.

Примеры требуют Aspose.Slides for Python via Java и совместимую среду выполнения Java. Поместите `pres.pptx` в текущий рабочий каталог. Каждый пример запускает JVM только в том случае, если она ещё не запущена.

## **О XAML**

XAML — это основанный на XML язык разметки, используемый для описания пользовательских интерфейсов в таких фреймворках, как WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin.Forms.

Вы можете работать с файлами XAML в визуальном дизайнере или писать и редактировать разметку напрямую.

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Следующий пример на Python демонстрирует, как экспортировать презентацию в XAML с параметрами по умолчанию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

По умолчанию экспортированные слайды сохраняются в подпапке `pres` текущего рабочего каталога процесса. Папка создаётся автоматически, и все необходимые изображения также сохраняются там.

Имя папки вывода берётся из имени исходного файла без расширения. Для `pres.pptx` файлы вывода будут называться `pres/Slide_1.xaml`, `pres/Slide_2.xaml` и т.д. Даже если вы передаёте абсолютный путь к входной презентации, папка вывода создаётся относительно текущего рабочего каталога, а не рядом с входным файлом.

## **Экспорт презентаций в XAML с пользовательскими параметрами**

Используйте класс [XamlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/) для управления тем, как Aspose.Slides экспортирует презентацию в XAML.

Чтобы сохранить вывод в пользовательское расположение, реализуйте `IXamlOutputSaver` и передайте экземпляр вашей реализации в метод [setOutputSaver](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/#setOutputSaver) класса [XamlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/).

Чтобы включить скрытые слайды в вывод XAML, вызовите [setExportHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) с параметром `True`, как показано в следующем примере на Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Сбор всех сгенерированных артефактов XAML**

Экспорт XAML может создавать документ XAML для каждого экспортированного слайда, а также отдельные изображения и вспомогательные ресурсы. Назначьте пользовательский `IXamlOutputSaver` в [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/#setOutputSaver), чтобы получать эти артефакты вместо использования стандартного сохранителя файловой системы. Запустите экспорт с помощью перегруженного метода XAML‑специфичного [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save), принимающего параметры XAML.

В Python используйте `jpype.JProxy` для реализации Java‑интерфейса `IXamlOutputSaver`. Преобразуйте путь обратного вызова в `str` и скопируйте массив байтов Java в Python `bytes` перед возвратом, как показано ниже.

### **Понимание жизненного цикла обратного вызова**

Экспортёр вызывает `IXamlOutputSaver.save` отдельно для каждого сгенерированного артефакта:

- `path` идентифицирует артефакт и может включать относительные каталоги. Сохраните эту информацию, так как XAML может ссылаться на ресурсы с использованием относительных путей.
- `data` содержит байты артефакта. Изображения и другие бинарные ресурсы не должны декодироваться как текст.
- Сохранитель отвечает за сохранение или долговременное хранение данных перед возвратом. В примерах каждый массив байтов копируется во владение приложения.
- Считайте экспорт успешным только тогда, когда операция сохранения презентации завершилась, и каждый обратный вызов выполнился успешно. Не подавляйте ошибки хранения и не начинайте незаметные фоновые записи. Если сохранение происходит позже, сообщайте об общей успешности только после успешного завершения и этого шага.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) также применяется к пользовательскому сохранителю. Значение по умолчанию, `False`, исключает XAML‑документы скрытых слайдов. Передача `True` включает их и все ресурсы, необходимые для их экспорта. Количество ресурсов зависит от презентации; не полагайтесь на один обратный вызов на слайд или фиксированный порядок вызовов.

### **Экспорт в память и проверка артефактов**

Этот полный пример загружает `pres.pptx`, собирает каждый артефакт в словарь Python, где ключи — имена, а значения — неизменяемые `bytes`, и выводит его имя, тип и количество байт. Имена сохраняются точно такими, как переданы. Дублирующиеся имена помечают коллекцию как недействительную вместо тихой перезаписи артефакта. Пример проверяет это перед использованием результатов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Декодировать только XAML и только когда требуется текстовый анализ.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Проверка расширений полезна для инспекции; сохраняйте все артефакты, включая неизвестные типы ресурсов. Оставляйте байты без изменений при хранении или передаче. Используйте `bytes.decode` с UTF-8 только для XAML, требующего текстовой обработки.

### **Упаковка собранных артефактов в ZIP‑архив**

Этот отдельный пример собирает экспорт, проверяет имена и записывает оригинальные байты в ZIP‑архив. Уникальное имя архива разделяет параллельные задачи экспорта. Записи ZIP используют прямые слеши и сохраняют относительные каталоги. Небезопасные имена или имена, конфликтующие после нормализации, отклоняют весь пакет до записи.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Закрытие завершает каталог ZIP перед сообщением об успехе.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

В примере используется `zipfile.ZipFile` из Python для записи одного локального архива; сам экспортёр не записывает отдельные файлы XAML или изображения. Для удалённого хранилища замените этап записи архива загрузкой собранных массивов байтов. Используйте идентификатор задачи экспорта плюс полное относительное имя артефакта в качестве ключа блоба, или храните идентификатор задачи, относительное имя и бинарные данные в строке базы данных. Публикуйте задачу только после завершения всех загрузок или фиксации транзакции базы данных. Очистите частичный вывод, если сохранение завершилось ошибкой.

Для больших презентаций пользовательский сохранитель может сохранять каждый артефакт непосредственно в хранилище приложения, чтобы избежать создания дополнительной копии всего экспорта в памяти. Делайте каждый обратный вызов синхронным с точки зрения экспортёра: возвращайте управление только после того, как получатель принял байты, и позволяйте ошибкам достигать вызывающего кода.

### **Сохранение имён ресурсов и проверка ссылок**

- Нормализуйте разделители путей, когда это требует пункт назначения, но сохраняйте относительные каталоги. Не используйте только `pathlib.Path.name`, если только каждый сгенерированный путь не известен как уникальный и ссылки на ресурсы остаются корректными.
- Применяйте проверку имён, специфичную для места назначения. При записи отдельных файлов отклоняйте абсолютные пути и сегменты перехода, разрешайте пункт назначения с помощью `pathlib.Path.resolve` и проверяйте, что он остаётся внутри целевого каталога экспорта, включая разделитель каталога в проверке вложенности. Используйте каталог, контролируемый приложением, без символических ссылок, которые могут перенаправлять записи.
- Используйте отдельный сохранитель и пространство имён хранилища для каждой задачи экспорта. Обнаруживайте конфликты после нормализации разделителей и в соответствии с правилами чувствительности к регистру пункта назначения.
- Перед публикацией разберите каждый документ XAML как XML и проверьте ссылки на файловые ресурсы, такие как атрибуты изображения `Source` или `ImageSource`. Разрешите каждый относительный URI относительно каталога, содержащего артефакт XAML, нормализуйте получившееся имя хранилища и убедитесь, что соответствующий ключ карты, запись ZIP или сохранённый объект существует. Обрабатывайте внешние URI и выражения разметки XAML отдельно от относительных имён файлов.

Например, если `pres/Slide_1.xaml` ссылается на `images/image1.png`, сохранённый ресурс должен быть доступен как `pres/images/image1.png`. Хранение только `image1.png` нарушит эту связь. Для объектного хранилища сохраняйте ту же структуру под префиксом задачи и делайте эти URL‑ы ресурсов доступными для потребителя XAML. Откройте завершённый ZIP заново, чтобы проверить имена записей и байты ресурсов, и загрузите типичные слайды в целевую среду XAML, чтобы убедиться, что изображения корректно разрешаются.

## **FAQ**

**Как обеспечить предсказуемость шрифтов, если оригинальный шрифт недоступен на машине?**

Вызовите [setDefaultRegularFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) в [XamlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/) — он используется как запасной шрифт при экспорте, если оригинальный отсутствует. Это не гарантирует, что сгенерированный XAML будет ссылаться на запасной шрифт или что шрифт будет доступен на целевой машине. Убедитесь, что шрифты, указанные в XAML, доступны в среде, где он отображается.

**Предназначен ли экспортированный XAML только для WPF, или его можно использовать и в других стеках XAML?**

Aspose.Slides экспортирует WPF XAML через свой публичный API. Совместимость с другими стеками XAML, такими как UWP и Xamarin.Forms, не гарантируется. Проверьте сгенерированную разметку в целевой среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [setExportHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) в [XamlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/) — оставляйте его отключённым, если не требуется экспортировать их.