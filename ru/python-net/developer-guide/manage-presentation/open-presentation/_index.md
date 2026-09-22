---
title: Открытие презентаций в Python
linktitle: Открыть презентации
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
- крупная презентация
- внешний ресурс
- бинарный объект
- Python
- Aspose.Slides
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument в Python, задавать пароли открытия и уменьшать использование памяти с помощью Aspose.Slides for Python via .NET."
---
## **Введение**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/ru/python-net/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете исследовать её структуру, редактировать слайды, управлять ресурсами и сохранять её в исходном или другом поддерживаемом формате.

Поведение загрузки можно настроить с помощью класса [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/). Например, вы можете задать пароль открытия, хранить крупные бинарные объекты вне памяти или опустить встроенные бинарные данные.

## **Открытие презентаций**

После загрузки файла или потока вы можете [определить его исходный формат презентации](/slides/ru/python-net/detect-presentation-source-format/), чтобы выбрать способ обработки приложением.

Чтобы открыть существующую презентацию, передайте её путь к файлу в конструктор [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Используйте оператор `with`, чтобы файловые дескрипторы, временные данные и другие ресурсы освобождались своевременно.

Следующий пример на Python показывает, как открыть презентацию и получить количество слайдов:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Открытие защищённых паролем презентаций**

Пароль открытия шифрует содержимое презентации. Чтобы загрузить всю презентацию, задайте правильный пароль в [LoadOptions.password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/password/) и передайте параметры в конструктор [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Загрузка завершается с ошибкой, если пароль отсутствует или неверен.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Для обнаружения пароля, его проверки и процессов шифрования см. [Защита презентаций паролем](/slides/ru/python-net/password-protected-presentation/). Если зашифрованная презентация была сохранена с публичными свойствами документа, эти свойства можно прочитать без пароля; см. [Управление свойствами презентации](/slides/ru/python-net/presentation-properties/).

## **Открытие крупных презентаций**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/blob_management_options/) управляет тем, как Aspose.Slides обрабатывает большие бинарные объекты, такие как изображения, аудио и видео. Вы можете оставить исходный файл заблокированным, разрешить временные файлы и ограничить объём BLOB‑данных, сохраняемых в памяти.

Этот пример на Python демонстрирует загрузку крупной презентации (например, 2 ГБ):

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
При использовании `PresentationLockingBehavior.KEEP_LOCKED` исходный файл остаётся заблокированным, пока объект `Presentation` не будет удалён. Не перемещайте, не перезаписывайте и не удаляйте исходный файл, пока этот объект существует.

Aspose.Slides может копировать содержимое входного потока во время загрузки. Для крупных презентаций путь к файлу обычно более эффективен, чем поток. См. [Manage BLOBs](/slides/ru/python-net/manage-blob/) для дополнительных вариантов хранения и управления памятью.
{{% /alert %}}

## **Загрузка презентаций без встроенных бинарных объектов**

Презентация может содержать встроенные бинарные данные, которые приложение не нуждается или не хочет сохранять. Примеры включают:
- проекты VBA, доступные через [Presentation.vba_project](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/vba_project/);
- встроенные данные OLE, доступные через [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- данные элементов управления ActiveX, доступные через [Control.active_x_control_binary](https://reference.aspose.com/slides/ru/python-net/aspose.slides/control/active_x_control_binary/).

Установите [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) в `True`, чтобы удалить эти бинарные данные во время загрузки. Сохраните загруженную презентацию, чтобы зафиксировать очищенный результат.

Эта опция уменьшает риск нежелательных встроенных нагрузок, но не является полной системой обнаружения вредоносного ПО или очистки контента.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Как определить, что файл повреждён и его нельзя открыть?**

Aspose.Slides генерирует исключение парсинга или формата во время загрузки. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно сообщить причину.

**Что происходит, если отсутствуют требуемые шрифты?**

Презентацию всё равно можно загрузить, но при рендеринге и экспорте могут быть заменены шрифты. Вы можете [настроить замену шрифтов](/slides/ru/python-net/font-substitution/) или [предоставить пользовательские шрифты](/slides/ru/python-net/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружает ли загрузка презентации также её встроенные медиа?**

Встроенные аудио и видео становятся доступными через объектную модель презентации. Внешние ресурсы разрешаются в соответствии с поведением загрузки ресурсов по умолчанию и могут быть недоступны, если их расположение недоступно.