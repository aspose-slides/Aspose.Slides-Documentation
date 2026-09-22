---
title: Сохранение презентаций в Python через Java
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/python-java/save-presentation/
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
- Строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- Python
- Java
- Aspose.Slides
description: "Сохраните презентации PowerPoint и OpenDocument в файлы или потоки в Python через Java с помощью Aspose.Slides, а также настройте вывод PPTX и отчёт о прогрессе."
---
## **Обзор**

После того как вы создадите презентацию или [откроете существующую](/slides/ru/python-java/open-presentation/), используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для записи результата. Aspose.Slides for Python via Java может сохранять презентацию в файл или поток в форматах PowerPoint, OpenDocument, PDF и других. В следующих разделах рассматриваются стандартные операции сохранения и варианты, доступные для вывода PPTX.

## **Сохранение презентаций в файлы**

Чтобы сохранить презентацию в файл, передайте путь к выходному файлу и значение [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save). Значение формата определяет тип файла, который создаёт Aspose.Slides.

Следующий пример создает презентацию и сохраняет её как файл PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Добавьте или измените содержимое презентации здесь.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Сохранение презентаций в исходном формате**

Для примеров обнаружения формата файлов и потоков, поведения вновь созданных презентаций и различия между исходным и выходным форматом см. [Determine the Original Presentation Format](/slides/ru/python-java/detect-presentation-source-format/).

В приложении пакетной обработки входной формат может быть неизвестен заранее. После загрузки файла прочитайте его исходный формат с помощью метода [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSourceFormat). Передайте полученное значение [SourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sourceformat/) в [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideutil/#toSaveFormat), чтобы получить соответствующее значение [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/), а затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для записи изменённой презентации.

Следующий полноценный пример обрабатывает каждый файл во входном каталоге, обновляет его заголовок и сохраняет его в выходном каталоге в том же формате, в котором он был загружен:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideutil/#toSaveFormat) сопоставляет PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP и PowerPoint XML их соответствующим форматам сохранения презентации. Он сопоставляет только форматы источника презентации; не предназначен для выбора форматов экспорта, таких как PDF, HTML, TIFF или изображения. Передача неподдерживаемого или недопустимого значения [SourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sourceformat/) приводит к [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Унаследованные файлы PPT, PPS и POT используют один и тот же бинарный контейнер. Когда такая презентация загружается из потока без расширения файла, файл PPS или POT может быть определён как PPT. Если необходимо сохранить эти устаревшие подтипы, сохраняйте исходное имя файла или метаданные формата отдельно и используйте их при выборе имени и формата выходного файла.

## **Сохранение презентаций в потоки**

Чтобы записать презентацию без указания конечного пути к файлу, передайте поток для записи и значение [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save). Такой подход полезен, когда результат необходимо вернуть из веб‑службы, сохранить в базе данных или обработать в памяти.

Следующий пример сохраняет новую презентацию в поток файла:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Сохранение презентаций с предустановленным типом представления**

Вы можете указать представление, в котором PowerPoint изначально откроет сохранённую презентацию. Используйте метод [ViewProperties.setLastView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#setLastView) с значением [ViewType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewtype/) перед сохранением.

Следующий пример задаёт представление Slide Master в качестве начального представления:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Сохранение презентаций в строгом формате Office Open XML**

Чтобы создать файл PPTX, соответствующий строгому профилю Office Open XML, создайте экземпляр [PptxOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/) и вызовите его метод [setConformance](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/#setConformance) с параметром [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ru/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Затем передайте параметры в метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Стандартный ZIP‑архив ограничивает сжатый и несжатый размер каждого элемента, общий размер архива и количество элементов. Поскольку файл PPTX является ZIP‑архивом, очень большая презентация может превысить эти ограничения. Расширения Zip64 повышают соответствующие лимиты по размеру и количеству элементов.

Используйте метод [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/#setZip64Mode) для управления тем, будет ли Aspose.Slides записывать расширения ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zip64mode/#IfNecessary) использует ZIP64 только когда презентация превышает стандартные ограничения ZIP. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zip64mode/#Never) отключает расширения ZIP64.
- [Always](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zip64mode/#Always) всегда записывает расширения ZIP64.

Следующий пример всегда включает расширения ZIP64 для выходной презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Если используется [Zip64Mode.Never](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zip64mode/#Never) и презентация не помещается в стандартные ограничения ZIP, операция сохранения бросает [PptxException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

Для вывода PPTX вы можете балансировать скорость сохранения и размер файла, используя метод [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Класс [CompressionLevel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/) предоставляет следующие значения:

- [None](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#None) не сжимает данные.
- [Level1](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level1) обеспечивает самое быстрое сжатие и наибольший размер сжатого файла.
- [Level2](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level2) — [Level5](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level5) постепенно отдают предпочтение меньшему размеру файла в ущерб скорости сохранения.
- [Level6](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level6) балансирует скорость сохранения и размер файла. Это уровень по умолчанию.
- [Level7](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level7) и [Level8](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level8) ещё сильнее отдают предпочтение уменьшенному размеру файла в ущерб скорости.
- [Level9](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level9) обеспечивает максимальное сжатие и требует наибольшего времени обработки.

Следующий пример сохраняет презентацию без сжатия:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

Следующий пример использует максимальный уровень сжатия:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Сохранение презентаций без обновления миниатюры**

При сохранении презентации как PPTX метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) управляет её документной миниатюрой:

- `True` регенерирует миниатюру во время операции сохранения. Это значение по умолчанию.
- `False` сохраняет существующую миниатюру. Если у презентации нет миниатюры, Aspose.Slides её не создаёт.

Следующий пример сохраняет презентацию без обновления её миниатюры:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Отключение обновления миниатюры может сократить время, необходимое для сохранения файла PPTX.
{{% /alert %}}

## **Отчёт о прогрессе сохранения в процентах**

Чтобы отслеживать процесс сохранения, зарегистрируйте обработчик прогресса Python через `jpype.JProxy` и передайте его в метод [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides затем вызывает метод `reporting` обработчика с значениями прогресса во время экспорта.

Следующий пример выводит в консоль прогресс экспорта PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose предоставляет бесплатный [PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), построенный на базе API Aspose.Slides. Он сохраняет выбранные слайды презентации как отдельные файлы PPT или PPTX.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Поддерживает ли Aspose.Slides инкрементальное или «быстрое» сохранение?**

Нет. Каждая операция сохранения пишет полностью сформированный файл, а не обновляет только изменённые части.

**Могут ли несколько потоков сохранять один и тот же объект Presentation?**

Нет. Объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) **не является потокобезопасным** (/slides/ru/python-java/multithreading/). Доступ к каждому экземпляру и его сохранение должны происходить только из одного потока одновременно.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении презентации?**

[Гиперссылки](/slides/ru/python-java/manage-hyperlinks/) остаются в презентации. Aspose.Slides не копирует внешние связанные файлы, поэтому сохраняемая презентация всё равно должна иметь доступ к их местоположениям.

**Могу ли я сохранить метаданные документа, такие как автор, название, компания и дата создания?**

Да. Установите соответствующие [свойства документа](/slides/ru/python-java/presentation-properties/) перед сохранением, и Aspose.Slides запишет их в выходной файл.