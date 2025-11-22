---
title: Сохранение презентаций в Python
linktitle: Сохранение презентаций
type: docs
weight: 80
url: /ru/python-net/save-presentation/
keywords:
- сохранение PowerPoint
- сохранение OpenDocument
- сохранение презентации
- сохранение слайда
- сохранение PPT
- сохранение PPTX
- сохранение ODP
- презентация в файл
- презентация в поток
- предопределённый тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- Python
- Aspose.Slides
description: "Узнайте, как сохранять презентации в Python с помощью Aspose.Slides — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---

## **Обзор**

[Открыть презентацию в Python](/slides/ru/python-net/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, по завершении её нужно сохранить. С помощью Aspose.Slides для Python вы можете сохранять в **файл** или **поток**. В этой статье рассматриваются различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `save` класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Передайте имя файла и формат сохранения в метод. Ниже приведён пример сохранения презентации с Aspose.Slides для Python.
```py
import aspose.slides as slides

# Создайте объект класса Presentation, представляющий файл презентации.
with slides.Presentation() as presentation:
    
    # Выполните здесь необходимые действия...

    # Сохраните презентацию в файл.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав выходной поток в метод `save` класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Презентацию можно записать в различные типы потоков. В примере ниже создаётся новая презентация, добавляется текст в форму и сохраняется в поток.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Сохраните презентацию в поток.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```


## **Сохранение презентаций с предопределённым типом представления**

Aspose.Slides для Python позволяет установить начальное представление, которое PowerPoint использует при открытии сгенерированной презентации, через класс [ViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/). Установите свойство `last_view` значением из перечисления [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/).
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```


## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) и задайте его свойство `conformance` при сохранении. Если установить `Conformance.ISO_29500_2008_STRICT`, выходной файл будет сохранён в строгом формате Office Open XML.

Ниже пример создания презентации и сохранения её в строгом формате Office Open XML.
```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:
    # Сохраните презентацию в строгом формате Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```


## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP‑архив, который накладывает ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве 65 535 (2^16‑1). Расширения формата ZIP64 повышают эти ограничения до 2^64.

Свойство [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) позволяет выбирать, когда использовать расширения ZIP64 при сохранении файла Office Open XML.

Это свойство поддерживает следующие режимы:

- `IF_NECESSARY` использует расширения ZIP64 только если презентация превышает указанные ограничения. Это режим по умолчанию.
- `NEVER` никогда не использует расширения ZIP64.
- `ALWAYS` всегда использует расширения ZIP64.

Ниже код, демонстрирующий сохранение презентации в формате PPTX с включёнными расширениями ZIP64:
```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}
При сохранении с `Zip64Mode.NEVER` генерируется исключение [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций без обновления миниатюры**

Свойство [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) управляет генерацией миниатюры при сохранении презентации в PPTX:

- Если установлено `True`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установлено `False`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не будет создана.

В коде ниже презентация сохраняется в PPTX без обновления её миниатюры.
```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="Информация" color="info" %}}
Эта опция помогает сократить время, необходимое для сохранения презентации в формате PPTX.
{{% /alert %}}

{{% alert title="Информация" color="info" %}}
Aspose разработала бесплатное приложение [PowerPoint Splitter](https://products.aspose.app/slides/splitter), использующее собственный API. Приложение позволяет разбивать презентацию на несколько файлов, сохраняя выбранные слайды как новые файлы PPTX или PPT.
{{% /alert %}}

## **FAQ**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), когда записываются только изменения?**

Нет. При каждом сохранении создаётся полный целевой файл; инкрементальное «быстрое сохранение» не поддерживается.

**Можно ли безопасно сохранять один и тот же экземпляр Presentation из нескольких потоков?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) **не является потокобезопасным**; сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Гиперссылки](/slides/ru/python-net/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли задавать/сохранять метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Стандартные [свойства документа](/slides/ru/python-net/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.