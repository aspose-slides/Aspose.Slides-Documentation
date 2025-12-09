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
- бинарный объект
- Python
- Aspose.Slides
description: "Легко открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) с помощью Aspose.Slides для Python через .NET — быстро, надёжно, полностью функционально."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получить информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передайте путь к файлу в его конструктор.

```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation и передайте путь к файлу в его конструктор.
with slides.Presentation("sample.pptx") as presentation:
    # Выведите общее количество слайдов в презентации.
    print(presentation.slides.length)
```


## **Открытие презентаций, защищённых паролем**

Когда необходимо открыть презентацию, защищённую паролем, передайте пароль через свойство [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) класса [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) для расшифровки и загрузки. Следующий пример кода на Python демонстрирует эту операцию:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Выполните операции над дешифрованной презентацией.
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет варианты — в частности свойство [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) класса [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) — чтобы помочь загрузить большие презентации.

Этот код на Python демонстрирует загрузку большой презентации (например, 2 ГБ):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Выберите поведение KeepLocked — файл презентации будет оставаться заблокированным в течение времени жизни 
# экземпляра Presentation, но его не требуется загружать в память или копировать во временный файл.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # Большая презентация загружена и может быть использована, при этом потребление памяти остаётся низким.

    # Внесите изменения в презентацию.
    presentation.slides[0].name = "Large presentation"

    # Сохраните презентацию в другой файл. Потребление памяти остаётся низким во время этой операции.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Не делайте этого! Будет выброшено исключение ввода/вывода, потому что файл заблокирован до тех пор, пока объект презентации не будет освобождён.
    os.remove(file_path)

# Здесь это допустимо. Исходный файл больше не заблокирован объектом презентации.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить загрузку. Поэтому, когда необходимо загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей крупные объекты (видео, аудио, изображения высокого разрешения и т. д.), вы можете использовать [BLOB management](/slides/ru/python-net/manage-blob/) для снижения потребления памяти.
{{%/alert %}}

## **Контроль внешних ресурсов**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/), позволяющий управлять внешними ресурсами. Ниже приведён пример кода на Python, показывающий, как использовать интерфейс `IResourceLoadingCallback`:

```python
# [TODO[not_supported_yet]: реализация python интерфейсов .NET]
```


## **Загрузка презентаций без внедрённых бинарных объектов**

Презентация PowerPoint может содержать следующие типы внедрённых бинарных объектов:

- VBA‑проект (доступен через [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- Данные вложенного OLE‑объекта (доступны через [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Бинарные данные управления ActiveX (доступны через [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

С помощью свойства [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) можно загрузить презентацию без каких‑либо внедрённых бинарных объектов.

Это свойство полезно для удаления потенциально вредоносного бинарного содержимого. Ниже приведён пример кода на Python, демонстрирующий, как загрузить презентацию без любого внедрённого бинарного содержимого:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Выполните операции над презентацией.
```


## **Часто задаваемые вопросы**

**Как определить, что файл повреждён и его нельзя открыть?**

Во время загрузки будет выброшено исключение парсинга/проверки формата. Такие ошибки часто указывают на недействительную структуру ZIP или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют необходимые шрифты?**

Файл откроется, но позже при [rendering/export](/slides/ru/python-net/convert-presentation/) могут быть заменены шрифты. [Configure font substitutions](/slides/ru/python-net/font-substitution/) или [add the required fonts](/slides/ru/python-net/custom-font/) в среду выполнения.

**Что происходит с внедрёнными медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа ссылки указывают внешние пути, убедитесь, что эти пути доступны в вашей среде; иначе при [rendering/export](/slides/ru/python-net/convert-presentation/) медиа могут быть опущены.