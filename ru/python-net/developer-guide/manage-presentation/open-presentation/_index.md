---
title: Открытие презентаций в Python
linktitle: Открытие презентаций
type: docs
weight: 20
url: /ru/python-net/open-presentation/
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
- двоичный объект
- Python
- Aspose.Slides
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument в Python, задавать пароли для открытия и снижать использование памяти с помощью Aspose.Slides for Python via .NET."
---
## **Введение**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/ru/python-net/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете исследовать её структуру, редактировать слайды, управлять ресурсами и сохранять её в оригинальном или другом поддерживаемом формате.

Поведение загрузки можно настроить с помощью класса [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/). Например, можно указать пароль для открытия, хранить большие двоичные объекты вне памяти или исключить встроенные двоичные данные.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, передайте её путь к файлу в конструктор [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Используйте оператор `with`, чтобы дескрипторы файлов, временные данные и другие ресурсы освобождались мгновенно.

Следующий пример на Python показывает, как открыть презентацию и получить количество слайдов:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Открытие презентаций, защищённых паролем**

Пароль открытия шифрует содержимое презентации. Чтобы загрузить полностью презентацию, присвойте правильный пароль свойству [LoadOptions.password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/password/) и передайте параметры в конструктор [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Загрузка завершится ошибкой, если пароль отсутствует или неверен.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Для обнаружения пароля, его проверки и рабочих процессов шифрования см. [Password-Protect Presentations](/slides/ru/python-net/password-protected-presentation/). Если зашифрованная презентация была намеренно сохранена с публичными свойствами документа, эти свойства можно прочитать без пароля; см. [Manage Presentation Properties](/slides/ru/python-net/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/blob_management_options/) управляет тем, как Aspose.Slides обрабатывает большие двоичные объекты, такие как изображения, аудио и видео. Вы можете удерживать исходный файл заблокированным, разрешать временные файлы и ограничивать объём BLOB‑данных, сохраняемых в памяти.

Этот код на Python демонстрирует загрузку большой презентации (например, 2 ГБ):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
С `PresentationLockingBehavior.KEEP_LOCKED` исходный файл остаётся заблокированным, пока объект `Presentation` не будет уничтожен. Не перемещайте, перезаписывайте и не удаляйте исходный файл, пока этот объект жив.
{{% /alert %}}

Aspose.Slides может копировать содержимое входного потока во время загрузки. Для больших презентаций путь к файлу обычно более эффективен, чем поток. Смотрите [Manage BLOBs](/slides/ru/python-net/manage-blob/) для дополнительных вариантов хранения и управления памятью.

## **Загрузка презентаций без встроенных двоичных объектов**

Презентация может содержать встроенные двоичные данные, которые приложению не нужны или которые он не хочет сохранять. Примеры:

- VBA‑проекты, доступные через [Presentation.vba_project](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/vba_project/);
- встроенные OLE‑данные, доступные через [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- данные ActiveX‑контролей, доступные через [Control.active_x_control_binary](https://reference.aspose.com/slides/ru/python-net/aspose.slides/control/active_x_control_binary/).

Установите [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) в `True`, чтобы удалить эти двоичные данные при загрузке. Сохраните загруженную презентацию, чтобы зафиксировать очищенный результат.

Этот параметр уменьшает риск нежелательных встроенных нагрузок, но не является полноценной системой обнаружения вредоносного кода или очистки содержимого.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Как определить, что файл повреждён и его нельзя открыть?**

Aspose.Slides генерирует исключение парсинга или формата во время загрузки. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно указать причину.

**Что происходит, если требуемые шрифты отсутствуют?**

Презентацию всё равно можно загрузить, но при рендеринге и экспорте шрифты могут быть заменены. Вы можете [configure font substitution](/slides/ru/python-net/font-substitution/) или [provide custom fonts](/slides/ru/python-net/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружает ли загрузка презентации также её встроенные медиа?**

Встроенные аудио и видео становятся доступны через объектную модель презентации. Внешние ресурсы разрешаются согласно поведению загрузки ресурсов по умолчанию и могут быть недоступны, если их местоположения недоступны.