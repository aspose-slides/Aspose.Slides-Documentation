---
title: Открытие презентаций в Python через Java
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/python-java/open-presentation/
keywords:
- открыть PowerPoint
- открыть презентацию
- открыть PPTX
- открыть PPT
- открыть ODP
- загрузить презентацию
- загрузить PPTX
- загрузить PPT
- загрузить ODP
- защищённая презентация
- большая презентация
- внешний ресурс
- бинарный объект
- Python
- Java
- Aspose.Slides
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument в Python через Java, задавать пароли открытия, управлять загрузкой ресурсов и сокращать использование памяти с помощью Aspose.Slides для Python через Java."
---
## **Введение**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ru/python-java/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете исследовать её структуру, редактировать слайды, управлять ресурсами и сохранять её в оригинальном или другом поддерживаемом формате.

Поведение загрузки можно настроить с помощью класса [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/). Например, можно задать пароль открытия, хранить большие бинарные объекты вне памяти кучи Java, контролировать внешние ресурсы или опустить встроенные бинарные данные.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, передайте её путь к файлу в конструктор [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/). После использования освободите презентацию, чтобы дескрипторы файлов, временные данные и другие ресурсы были быстро освобождены.

Ниже показан пример на Python, показывающий, как открыть презентацию и получить количество слайдов:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Открытие презентаций, защищенных паролем**

Пароль открытия шифрует содержимое презентации. Чтобы загрузить полную презентацию, передайте правильный пароль в [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setPassword) и передайте параметры в конструктор [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/). Загрузка завершится ошибкой, если пароль отсутствует или неверный.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Для обнаружения паролей, проверки и процессов шифрования см. [Password-Protect Presentations](/slides/ru/python-java/password-protected-presentation/). Если зашифрованная презентация была намеренно сохранена с публичными свойствами документа, эти свойства можно прочитать без пароля; см. [Manage Presentation Properties](/slides/ru/python-java/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) возвращает параметры, контролирующие, как Aspose.Slides обрабатывает большие бинарные объекты, такие как изображения, аудио и видео. Вы можете держать исходный файл заблокированным, разрешать временные файлы и ограничивать количество BLOB‑данных, удерживаемых в памяти.

Ниже приведён код на Python, демонстрирующий загрузку большой презентации (например, 2 ГБ):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Примечание" %}}
С помощью [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) исходный файл остаётся заблокированным до тех пор, пока экземпляр презентации не будет освобождён. Не перемещайте, перезаписывайте и не удаляйте исходный файл, пока экземпляр жив.

Aspose.Slides может копировать содержимое входного потока во время загрузки. Для больших презентаций путь к файлу, как правило, более эффективен, чем поток. См. [Manage BLOBs](/slides/ru/python-java/manage-blob/) для дополнительных вариантов хранения и управления памятью.
{{% /alert %}}

## **Управление внешними ресурсами**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) принимает прокси JPype, реализующий Java‑интерфейс обратного вызова загрузки ресурсов. Обратный вызов может предоставить заменяющие данные, перенаправить ресурс, использовать загрузчик по умолчанию или пропустить ресурс. Это полезно, когда презентации содержат внешние изображения, которые необходимо обрабатывать согласно правилам безопасности или хранения, специфичным для приложения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Загрузка презентаций без встроенных бинарных объектов**

Презентация может содержать встроенные бинарные данные, которые приложение не нуждается или не хочет сохранять. Примеры включают:

- VBA‑проекты, доступные через [Presentation.getVbaProject](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getVbaProject);
- встроенные OLE‑данные, доступные через [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- данные ActiveX‑контролов, доступные через [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ru/python-java/aspose.slides/control/#getActiveXControlBinary).

Установите [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) в `True`, чтобы удалить эти бинарные данные при загрузке. Сохраните загруженную презентацию, чтобы зафиксировать очищенный результат.

Эта опция снижает риск нежелательных встроенных нагрузок, но не является полноценной системой обнаружения вредоносного кода или контент‑санитации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Как определить, что файл повреждён и не может быть открыт?**

Aspose.Slides генерирует исключение парсинга или формата во время загрузки. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно сообщить о причине.

**Что происходит, если необходимые шрифты отсутствуют?**

Презентацию всё‑равно можно загрузить, но при рендеринге и экспорте могут быть заменены шрифты. Вы можете [настроить замену шрифтов](/slides/ru/python-java/font-substitution/) или [предоставить пользовательские шрифты](/slides/ru/python-java/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружается ли встроенное медиа при загрузке презентации?**

Встроенное аудио и видео становятся доступными через объектную модель презентации. Внешние ресурсы разрешаются согласно настроенному поведению загрузки ресурсов и могут быть недоступны, если их местоположения недоступны.