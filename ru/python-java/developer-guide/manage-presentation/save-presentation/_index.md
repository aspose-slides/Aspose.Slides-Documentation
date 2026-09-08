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
- предопределённый тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- Python
- Java
- Aspose.Slides
description: "Сохранение презентаций PowerPoint и OpenDocument в файлы или потоки в Python через Java с Aspose.Slides, а также настройка вывода PPTX и отчётности о прогрессе."
---
## **Обзор**

После того как вы создадите презентацию или [откройте существующую](/slides/ru/python-java/open-presentation/), используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для записи результата. Aspose.Slides for Python via Java может сохранять презентацию в файл или поток в форматах PowerPoint, OpenDocument, PDF и других. Ниже приведены стандартные операции сохранения и параметры, доступные для вывода PPTX.

## **Сохранить презентации в файлы**

Чтобы сохранить презентацию в файл, передайте путь вывода и значение [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save). Значение формата определяет тип файла, создаваемого Aspose.Slides.

В следующем примере создаётся презентация и сохраняется как файл PPTX:

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

## **Сохранить презентации в их исходном формате**

В приложении пакетной обработки входной формат может быть неизвестен заранее. После загрузки файла прочитайте его исходный формат с помощью метода [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSourceFormat). Передайте полученное значение [SourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sourceformat/) в [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideutil/#toSaveFormat), чтобы получить соответствующее значение [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/), а затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для записи изменённой презентации.

В следующем полном примере обрабатывается каждый файл во входном каталоге, обновляется его заголовок и сохраняется в выходной каталог в том же формате, в котором был загружен:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ru/python-java/asposeslides/slideutil/#toSaveFormat) сопоставляет PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP и PowerPoint XML их соответствующим форматам сохранения презентаций. Он сопоставляет только форматы источника презентаций; он не предназначен для выбора форматов экспорта, таких как PDF, HTML, TIFF или изображения. Передача неподдерживаемого или недействительного значения [SourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sourceformat/) приводит к выбросу [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Унаследованные файлы PPT, PPS и POT используют один и тот же бинарный контейнер. Когда такая презентация загружается из потока без расширения файла, файл PPS или POT может быть определён как PPT. Если необходимо сохранять эти устаревшие подтипы, храните оригинальное имя файла или метаданные формата отдельно и используйте их при выборе имени и формата выходного файла.

## **Сохранить презентации в потоки**

Чтобы записать презентацию без указания конечного пути файла, передайте поток записи и значение [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save). Этот подход полезен, когда результат нужно вернуть из веб‑сервиса, сохранить в базе данных или обработать в памяти.

В следующем примере новая презентация сохраняется в файловый поток:

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

## **Сохранить презентации с предопределённым типом представления**

Можно указать представление, в котором PowerPoint изначально откроет сохранённую презентацию. Используйте метод [ViewProperties.setLastView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#setLastView) с значением [ViewType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewtype/) перед сохранением.

В следующем примере в качестве начального представления задаётся просмотр слайд‑мастера:

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

## **Сохранить презентации в строгом формате Office Open XML**

Чтобы создать файл PPTX, соответствующий строгому профилю Office Open XML, создайте экземпляр [PptxOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/) и используйте его метод [setConformance](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/#setConformance) со значением [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ru/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Затем передайте параметры в метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save).

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

## **Сохранить презентации в формате Office Open XML в режиме Zip64**

Стандартный ZIP‑архив ограничивает сжатый и несжатый размер каждой записи, общий размер архива и количество записей. Поскольку файл PPTX является ZIP‑архивом, очень большая презентация может превысить эти ограничения. Расширения ZIP64 повышают соответствующие ограничения размеров и количества записей.

Используйте метод [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/#setZip64Mode) для управления тем, будет ли Aspose.Slides записывать расширения ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zip64mode/#IfNecessary) использует ZIP64 только когда презентация превышает стандартные ограничения ZIP. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zip64mode/#Never) отключает расширения ZIP64.
- [Always](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zip64mode/#Always) всегда записывает расширения ZIP64.

В следующем примере всегда включаются расширения ZIP64 для выходной презентации:

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

## **Сохранить презентации в формате Office Open XML с уровнями сжатия**

Для вывода PPTX можно сбалансировать скорость сохранения и размер файла, используя метод [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Класс [CompressionLevel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/) предоставляет следующие значения:

- [None](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#None) сохраняет данные без сжатия.
- [Level1](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level1) обеспечивает самую быструю компрессию и наибольший размер сжатого файла.
- [Level2](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level2)‑[Level5](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level5) постепенно отдают предпочтение уменьшенному размеру вывода в ущерб скорости сохранения.
- [Level6](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level6) балансирует скорость сохранения и размер файла. Это уровень по умолчанию.
- [Level7](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level7) и [Level8](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level8) ещё сильнее отдают предпочтение меньшему размеру вывода.
- [Level9](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compressionlevel/#Level9) обеспечивает максимальное сжатие и требует наибольшее время обработки.

В следующем примере презентация сохраняется без сжатия:

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

В следующем примере используется максимальный уровень сжатия:

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

## **Сохранить презентации без обновления миниатюры**

При сохранении презентации как PPTX метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) управляет её миниатюрой документа:

- `True` регенерирует миниатюру во время операции сохранения. Это значение по умолчанию.
- `False` сохраняет существующую миниатюру. Если у презентации нет миниатюры, Aspose.Slides её не создаёт.

В следующем примере презентация сохраняется без обновления миниатюры:

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

## **Сохранять обновления прогресса в процентах**

Чтобы отслеживать процесс сохранения, зарегистрируйте обработчик прогресса на Python через `jpype.JProxy` и передайте его в метод [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides будет вызывать метод `reporting` обработчика с значениями прогресса во время экспорта.

В следующем примере прогресс экспорта PDF выводится в консоль:

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
Aspose предоставляет бесплатный [PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), построенный на основе Aspose.Slides API. Он сохраняет выбранные слайды из презентации в отдельные файлы PPT или PPTX.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides инкрементное или «быстрое сохранение»?**

Нет. Каждая операция сохранения записывает полный выходной файл, а не только изменённые части.

**Могут ли несколько потоков сохранять один и тот же объект Presentation?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/python-java/multithreading/). Доступ и сохранение каждого экземпляра следует выполнять только из одного потока за раз.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении презентации?**

[Гиперссылки](/slides/ru/python-java/manage-hyperlinks/) остаются в презентации. Aspose.Slides не копирует внешние связанные файлы, поэтому сохранённой презентации всё равно необходимо иметь доступ к их расположениям.

**Можно ли сохранять метаданные документа, такие как автор, заголовок, компания и дата создания?**

Да. Задайте соответствующие [свойства документа](/slides/ru/python-java/presentation-properties/) перед сохранением, и Aspose.Slides запишет их в выходной файл.