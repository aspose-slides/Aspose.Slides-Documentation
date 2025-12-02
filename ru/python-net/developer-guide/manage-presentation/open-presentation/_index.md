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
description: "Открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) легко с помощью Aspose.Slides для Python через .NET - быстро, надёжно, полностью функционально."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получить информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передайте путь к файлу в его конструктор.

Следующий пример на Python показывает, как открыть презентацию и получить количество слайдов:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation и передайте путь к файлу в его конструктор.
with slides.Presentation("sample.pptx") as presentation:
    # Выведите общее количество слайдов в презентации.
    print(presentation.slides.length)
```


## **Открытие защищённых паролем презентаций**

Когда необходимо открыть презентацию, защищённую паролем, передайте пароль через свойство [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) класса [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) для дешифрования и загрузки. Ниже приведён пример кода на Python, демонстрирующий эту операцию:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Выполните операции над расшифрованной презентацией.
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет параметры — в частности свойство [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) в классе [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) — чтобы помочь вам загружать большие презентации.

В следующем примере на Python показана загрузка большой презентации (например, объемом 2 ГБ):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Выберите поведение KeepLocked — файл презентации будет оставаться заблокированным на протяжении жизни
# экземпляра Presentation, но его не требуется загружать в память или копировать во временный файл.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 МБ

with slides.Presentation(file_path, load_options) as presentation:
    # Большая презентация загружена и готова к использованию, при этом расход памяти остается низким.

    # Внесите изменения в презентацию.
    presentation.slides[0].name = "Large presentation"

    # Сохраните презентацию в другой файл. При этом расход памяти остаётся низким.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Не делайте этого! Будет выброшено исключение ввода‑вывода, поскольку файл заблокирован, пока объект презентации не будет уничтожен.
    os.remove(file_path)

# Здесь это допустимо. Исходный файл больше не заблокирован объектом презентации.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить загрузку. Поэтому, когда необходимо загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей крупные объекты (видео, аудио, изображения высокого разрешения и т.д.), вы можете использовать [BLOB management](/slides/ru/python-net/manage-blob/) для снижения потребления памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/), позволяющий управлять внешними ресурсами. В следующем примере на Python показано, как использовать интерфейс `IResourceLoadingCallback`:
```python
# [TODO[not_supported_yet]: реализация python интерфейсов .NET]
```


## **Загрузка презентаций без встроенных двоичных объектов**

Презентация PowerPoint может содержать следующие типы встроенных двоичных объектов:

- VBA‑проект (доступный через [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- Встроенные данные OLE‑объекта (доступные через [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Двоичные данные ActiveX‑контроля (доступные через [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

С помощью свойства [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) вы можете загрузить презентацию без каких‑либо встроенных двоичных объектов.

Это свойство полезно для удаления потенциально вредоносного двоичного контента. В следующем примере на Python показано, как загрузить презентацию без какого‑либо встроенного двоичного контента:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Выполните операции над презентацией.
```


## **FAQ**

**Как определить, что файл повреждён и его нельзя открыть?**

Во время загрузки будет выброшено исключение парсинга/валидации формата. Такие ошибки обычно указывают на недействительную структуру ZIP‑файла или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют необходимые шрифты?**

Файл откроется, но позже при [rendering/export](/slides/ru/python-net/convert-presentation/) шрифты могут быть заменены. [Configure font substitutions](/slides/ru/python-net/font-substitution/) или [add the required fonts](/slides/ru/python-net/custom-font/) в среду выполнения.

**Что происходит с встроенными медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиафайлы указаны через внешние пути, убедитесь, что эти пути доступны в вашей среде; в противном случае при [rendering/export](/slides/ru/python-net/convert-presentation/) медиа могут быть пропущены.