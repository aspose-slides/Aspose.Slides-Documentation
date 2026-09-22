---
title: Сохранение презентаций в Python
linktitle: Сохранить презентацию
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
- предопределенный тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- Python
- Aspose.Slides
description: "Сохраните презентации PowerPoint и OpenDocument в файлы или потоки на Python с помощью Aspose.Slides и настройте параметры вывода PPTX."
---
## **Обзор**

После того как вы создадите презентацию или [откроете существующую](/slides/ru/python-net/open-presentation/), используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ipresentation/save/) для записи результата. Aspose.Slides for Python via .NET может сохранять презентацию в файл или поток в форматах PowerPoint, OpenDocument, PDF и других. В следующих разделах рассматриваются стандартные операции сохранения и доступные параметры вывода PPTX.

## **Сохранение презентаций в файлы**

Чтобы сохранить презентацию в файл, передайте путь к выходному файлу и значение [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ipresentation/save/). Значение формата определяет тип файла, который создаёт Aspose.Slides.

Следующий пример создаёт презентацию и сохраняет её как файл PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Добавьте или измените содержимое презентации здесь.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Сохранение презентаций в их исходном формате**

Для примеров определения формата файла и потока, поведения вновь созданных презентаций и различия между исходным и выходным форматами см. [Определение исходного формата презентации](/slides/ru/python-net/detect-presentation-source-format/).

В приложении пакетной обработки формат входных данных может быть неизвестен заранее. После загрузки файла прочитайте его исходный формат из свойства [Presentation.source_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/source_format/). Передайте полученное значение [SourceFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sourceformat/) в [SlideUtil.to_save_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.util/slideutil/to_save_format/) для получения соответствующего значения [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/), а затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ipresentation/save/) для записи изменённой презентации.

Следующий полный пример обрабатывает каждый файл во входном каталоге, обновляет его заголовок и сохраняет в выходной каталог в том же формате, в котором он был загружен:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.util/slideutil/to_save_format/) сопоставляет PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP и PowerPoint XML их соответствующим форматам сохранения презентаций. Он сопоставляет только исходные форматы презентаций; не предназначен для выбора форматов экспорта, таких как PDF, HTML, TIFF или изображения. Передача неподдерживаемого или неверного значения [SourceFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sourceformat/) вызывает исключение.

Устаревшие файлы PPT, PPS и POT используют один и тот же двоичный контейнер. Когда такая презентация загружается из потока без расширения файла, файл PPS или POT может быть определён как PPT. Если требуется сохранять эти устаревшие подтипы, сохраняйте оригинальное имя файла или метаданные формата отдельно и используйте их при выборе имени выходного файла и формата.

## **Сохранение презентаций в потоки**

Чтобы записать презентацию без указания конечного пути к файлу, передайте записываемый [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) поток и значение [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ipresentation/save/). Этот подход полезен, когда вывод необходимо вернуть из веб‑службы, сохранить в базе данных или обработать в памяти.

Следующий пример сохраняет новую презентацию в файловый поток:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Сохранение презентаций с предварительно заданным типом представления**

Можно указать представление, в котором PowerPoint будет открывать сохранённую презентацию. Установите свойство [ViewProperties.last_view](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/last_view/) в значение [ViewType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewtype/) перед сохранением.

Следующий пример задаёт представление Slide Master в качестве начального представления:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Сохранение презентаций в строгом формате Office Open XML**

Чтобы создать файл PPTX, соответствующий строгому профилю Office Open XML, создайте экземпляр [PptxOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pptxoptions/) и задайте его свойство [conformance](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pptxoptions/conformance/) значением `Conformance.ISO_29500_2008_STRICT`. Затем передайте параметры в метод [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Стандартный ZIP‑архив ограничивает сжатый и несжатый размер каждого элемента, общий размер архива и количество элементов. Поскольку файл PPTX является ZIP‑архивом, очень большая презентация может превысить эти ограничения. Расширения ZIP64 повышают соответствующие лимиты размера и количества элементов.

Используйте свойство [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) для управления тем, будет ли Aspose.Slides записывать расширения ZIP64:

- `IF_NECESSARY` использует ZIP64 только когда презентация превышает стандартные ограничения ZIP. Это режим по умолчанию.
- `NEVER` отключает расширения ZIP64.
- `ALWAYS` всегда записывает расширения ZIP64.

Следующий пример всегда включает расширения ZIP64 для выходной презентации:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Предупреждение" %}}
Если используется `Zip64Mode.NEVER` и презентация не помещается в стандартные ограничения ZIP, операция сохранения вызывает [PptxException](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

Для вывода PPTX можно балансировать скорость сохранения и размер файла, задав свойство [PptxOptions.compression_level](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pptxoptions/compression_level/). Перечисление [CompressionLevel](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/compressionlevel/) предоставляет следующие значения:

- `NONE` сохраняет данные без сжатия.
- `LEVEL1` обеспечивает самое быстрое сжатие и наибольший размер сжатого файла.
- `LEVEL2`‑`LEVEL5` постепенно отдают предпочтение меньшему размеру файлу в ущерб скорости сохранения.
- `LEVEL6` уравновешивает скорость сохранения и размер файла. Это уровень по умолчанию.
- `LEVEL7` и `LEVEL8` ещё сильнее отдают предпочтение меньшему размеру в ущерб скорости.
- `LEVEL9` обеспечивает максимальное сжатие и требует наибольшего времени обработки.

Следующий пример сохраняет презентацию без сжатия:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Следующий пример использует максимальный уровень сжатия:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Сохранение презентаций без обновления миниатюры**

При сохранении презентации как PPTX свойство [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) управляет её миниатюрой документа:

- `True` регенерирует миниатюру во время операции сохранения. Это значение по умолчанию.
- `False` сохраняет существующую миниатюру. Если у презентации нет миниатюры, Aspose.Slides не создаёт её.

Следующий пример сохраняет презентацию без обновления её миниатюры:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Примечание" %}}
Отключение обновления миниатюры может снизить время, необходимое для сохранения файла PPTX.
{{% /alert %}}

{{% alert color="info" title="Примечание" %}}
Aspose предоставляет бесплатный [PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), построенный на API Aspose.Slides. Он сохраняет выбранные слайды из презентации как отдельные файлы PPT или PPTX.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides инкрементное или «быстрое» сохранение?**

Нет. Каждая операция сохранения записывает полностью готовый файл, а не только изменённые части.

**Могут ли несколько потоков сохранять один и тот же объект Presentation?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) **не является потокобезопасным** (/slides/ru/python-net/multithreading/). Доступ и сохранение каждого экземпляра должны выполняться только из одного потока одновременно.

**Что происходит с гиперссылками и внешними файлами при сохранении презентации?**

[Гиперссылки](/slides/ru/python-net/manage-hyperlinks/) остаются в презентации. Aspose.Slides не копирует внешние файлы, поэтому сохранённая презентация должна сохранять возможность доступа к их расположениям.

**Могу ли я сохранить метаданные документа, такие как автор, название, компания и дата создания?**

Да. Установите соответствующие [свойства документа](/slides/ru/python-net/presentation-properties/) перед сохранением, и Aspose.Slides запишет их в выходной файл.