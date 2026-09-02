---
title: Сохранение презентаций в Python
linktitle: Сохранить презентации
type: docs
weight: 80
url: /ru/python-net/save-presentation/
keywords:
- сохранить PowerPoint
- сохранить OpenDocument
- сохранить презентацию
- сохранить слайд
- сохранить PPT
- сохранить PPTX
- сохранить ODP
- презентация в файл
- презентация в поток
- предустановленный тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- Python
- Aspose.Slides
description: "Узнайте, как сохранять презентации в Python с помощью Aspose.Slides — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---
## **Обзор**

[Open a Presentation in Python](/slides/ru/python-net/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, вам потребуется сохранить её после завершения работы. С Aspose.Slides для Python вы можете сохранять в **файл** или **поток**. Эта статья объясняет различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `save` класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Передайте в метод имя файла и формат сохранения. Ниже приведён пример, показывающий, как сохранить презентацию с помощью Aspose.Slides для Python.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющий файл презентации.
with slides.Presentation() as presentation:
    
    # Выполните здесь некоторую работу...

    # Сохраните презентацию в файл.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав объект выходного потока в метод `save` класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Презентацию можно записать в различные типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющий файл презентации.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Сохраните презентацию в поток.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Сохранение презентаций с предустановленным типом просмотра**

Aspose.Slides для Python позволяет задать начальное представление, которое PowerPoint будет использовать при открытии сгенерированной презентации, через класс [ViewProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/). Установите свойство `last_view` значением из перечисления [ViewType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pptxoptions/) и задайте его свойство conformance при сохранении. Если установить `Conformance.ISO_29500_2008_STRICT`, выходной файл будет сохранён в строгом формате Office Open XML.

Пример ниже создаёт презентацию и сохраняет её в строгом формате Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Создайте экземпляр класса Presentation, представляющий файл презентации.
with slides.Presentation() as presentation:
    # Сохраните презентацию в строгом формате Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML является ZIP‑архивом, который накладывает ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве до 65 535 (2^16‑1). Расширения формата ZIP64 увеличивают эти ограничения до 2^64.

Свойство [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) позволяет выбирать, когда использовать расширения формата ZIP64 при сохранении файла Office Open XML.

Это свойство поддерживает следующие режимы:

- `IF_NECESSARY` использует расширения ZIP64 только если презентация превышает указанные выше ограничения. Это режим по умолчанию.
- `NEVER` никогда не использует расширения ZIP64.
- `ALWAYS` всегда использует расширения ZIP64.

Ниже показан код, демонстрирующий, как сохранить презентацию в файл PPTX с включёнными расширениями ZIP64:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}
При сохранении с `Zip64Mode.NEVER` выбрасывается [PptxException](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pptxexception/), если презентацию невозможно сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

При работе с крупными презентациями вы можете регулировать уровень сжатия, чтобы сбалансировать размер файла и время обработки. В зависимости от требований вы можете предпочесть более быструю обработку или меньший размер выходного файла.

Aspose.Slides предоставляет свойство [PptxOptions.compression_level](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pptxoptions/compression_level/), которое позволяет указать уровень сжатия, используемый при сохранении презентации в формате Office Open XML.

Доступны следующие уровни сжатия:

- [**NONE**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Сжатие не применяется. Файлы сохраняются без изменений.
- [**LEVEL1**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Самое быстрое сжатие с наименьшим коэффициентом сжатия.
- [**LEVEL2**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Быстрое сжатие с чуть лучшим коэффициентом, чем **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Обеспечивает лучшее сжатие, чем **LEVEL2**, с умеренным влиянием на время обработки.
- [**LEVEL4**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Обеспечивает лучшее сжатие, чем **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Улучшенное сжатие по сравнению с **LEVEL4** с дополнительным временем обработки.
- [**LEVEL6**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Стандартное сжатие, предлагающее хороший баланс между скоростью обработки и размером файла. Это *уровень сжатия по умолчанию*.
- [**LEVEL7**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Обеспечивает лучшее сжатие, чем **LEVEL6**, но с более медленной обработкой.
- [**LEVEL8**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Обеспечивает лучшее сжатие, чем **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/): Максимальное сжатие. Даёт наименьший размер файла за счёт самого длительного времени обработки.

Ниже приведён пример, демонстрирующий, как сохранить презентацию в файл PPTX *без сжатия*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Этот пример показывает, как сохранить презентацию в файл PPTX с *максимальным сжатием*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Сохранение презентаций без обновления миниатюры**

Свойство [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) управляет генерацией миниатюры при сохранении презентации в PPTX:

- Если установлено `True`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установлено `False`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не будет генерироваться.

В коде ниже презентация сохраняется в PPTX без обновления её миниатюры.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="ИНФОРМАЦИЯ" color="info" %}}
Эта опция помогает сократить время, необходимое для сохранения презентации в формате PPTX.
{{% /alert %}}

{{% alert title="ИНФОРМАЦИЯ" color="info" %}}
Aspose разработала [бесплатное приложение PowerPoint Splitter]https://products.aspose.app/slides/ru/splitter, использующее собственный API. Приложение позволяет разбить презентацию на несколько файлов, сохраняя выбранные слайды как новые файлы PPTX или PPT.
{{% /alert %}}

## **FAQ**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), при котором записываются только изменения?**

Нет. При каждом сохранении создаётся полный целевой файл; инкрементное «быстрое сохранение» не поддерживается.

**Можно ли безопасно сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/python-net/multithreading/); сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Гиперссылки](/slides/ru/python-net/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли задать/сохранить метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Стандартные [свойства документа](/slides/ru/python-net/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.