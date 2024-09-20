---
title: Открыть Презентацию
type: docs
weight: 20
url: /python-net/open-presentation/
keywords: "Открыть PowerPoint, PPTX, PPT, Открыть Презентацию, Загрузить Презентацию, Python"
description: "Открыть или загрузить презентацию PPT, PPTX, ODP в Python"
---

Кроме создания презентаций PowerPoint с нуля, Aspose.Slides позволяет вам открывать существующие презентации. После того как вы загрузите презентацию, вы сможете получить информацию о ней, редактировать содержание на слайдах, добавлять новые слайды или удалять существующие и т. д.

## Открыть Презентацию

Чтобы открыть существующую презентацию, вам просто нужно создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передать путь к файлу (презентации, которую вы хотите открыть) в его конструктор.

Этот код на Python показывает, как открыть презентацию и узнать, сколько слайдов она содержит:

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation и передает путь к файлу в его конструктор
with slides.Presentation("pres.pptx") as pres:
    # Выводит общее количество слайдов в презентации
    print(pres.slides.length)
```

## **Открыть Защищенную Паролем Презентацию**

Когда вам необходимо открыть презентацию, защищённую паролем, вы можете передать пароль через свойство `password` (из класса [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)), чтобы расшифровать презентацию и загрузить её. Этот код на Python демонстрирует эту операцию:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "PASSWORD"
with slides.Presentation("pres.pptx", load_options) as pres:
    ...
```

## Открыть Большую Презентацию

Aspose.Slides предоставляет параметры (в частности, свойство `blob_management_options`) в классе [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), чтобы позволить вам открывать большие презентации.

Этот код на Python демонстрирует операцию, в которой загружается большая презентация (например, размером 2 ГБ):

```python
import aspose.slides as slides
import os

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("pres.pptx", loadOptions) as pres:
    # Большая презентация была загружена и может быть использована, но потребление памяти всё еще низкое.

    # Вносит изменения в презентацию.
    pres.slides[0].name = "Очень большая презентация"

    # Презентация будет сохранена в другой файл. Потребление памяти остаётся низким во время операции
    pres.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Нельзя делать это! Будет вызвано исключение IO, поскольку файл заблокирован, пока объекты pres будут
    # не освобождены
    os.remove("pres.pptx")

# Здесь это можно делать. Исходный файл не заблокирован объектом pres.
os.remove("pres.pptx")
```

{{% alert color="info" title="Информация" %}}

Чтобы обойти определённые ограничения при взаимодействии с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приведёт к копированию содержимого презентации и вызовет медленную загрузку. Поэтому, когда вы собираетесь загружать большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не её поток.

Когда вы хотите создать презентацию, содержащую большие объекты (видео, аудио, большие изображения и т. д.), вы можете использовать [Blob facility](https://docs.aspose.com/slides/python-net/manage-blob/) для уменьшения потребления памяти.

{{%/alert %}} 


## Загрузить Презентацию

Aspose.Slides предоставляет [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) с единственным методом, позволяющим управлять внешними ресурсами. Этот код на Python показывает, как использовать интерфейс `IResourceLoadingCallback`:

```python
# [TODO[not_supported_yet]: реализация python .net интерфейсов]
```

<h2>Открыть и Сохранить Презентацию</h2>

<a name="python-net-open-save-presentation"><strong>Шаги: Открыть и Сохранить Презентацию в Python</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передайте файл, который вы хотите открыть.
2. Сохраните презентацию.

```python
import aspose.slides as slides

# Создаёт объект Presentation, представляющий файл PPT
with slides.Presentation() as presentation:
    
    #...выполните некоторые работы здесь...

    # Сохраните вашу презентацию в файл
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```