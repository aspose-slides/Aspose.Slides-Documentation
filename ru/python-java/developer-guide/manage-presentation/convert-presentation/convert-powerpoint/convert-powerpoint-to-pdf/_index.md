---
title: Конвертировать PPT и PPTX в PDF в Python через Java [Включены расширенные возможности]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/python-java/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в PDF
- презентацию в PDF
- PPT в PDF
- конвертировать PPT в PDF
- PPTX в PDF
- конвертировать PPTX в PDF
- сохранить PowerPoint как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Конвертировать презентации PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в Python через Java с использованием Aspose.Slides, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и др.) в формат PDF в Python через Java предлагает несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве демонстрируется, как конвертировать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертации PowerPoint в PDF**

Используя Aspose.Slides, вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и затем сохраните презентацию в PDF, используя метод [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Класс [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF, Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением в виде "*Aspose.Slides v XX.XX*". **Примечание** то, что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Аспose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Аспose.Slides экспортирует презентации в PDF, обеспечивая, что полученные PDF‑файлы максимально соответствуют оригинальным презентациям. Элементы и атрибуты точно отображаются при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартная конвертация использует настройки экспортирования PDF по умолчанию. Используйте пользовательские параметры, когда необходимо контролировать качество изображений, содержимое страниц или соответствие PDF.

Установите [Aspose.Slides for Python via Java](/slides/ru/python-java/installation/) и совместимую среду выполнения Java перед запуском примеров. Каждый пример читает `presentation.pptx` из текущего рабочего каталога; замените его вашим файлом PPT, PPTX или ODP. Запустите JVM один раз за процесс Python.

В следующем примере загружается презентация и сохраняются все видимые слайды в PDF с использованием настроек экспортирования по умолчанию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose предлагает бесплатный онлайн [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.
{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Аспose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), которые позволяют настроить полученный PDF, защитить PDF паролем или задать, как должен происходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

В следующем примере презентация экспортируется в PDF 1.5 с качеством JPEG, установленным на 90, разрешением изображения 300 DPI, метафайлы сохраняются как PNG и используется сжатие текста Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Сохранение встроенных OLE‑файлов в виде вложений PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным книги, а также просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) со значением `True`, чтобы сохранить вложенные OLE‑файлы во вложениях результирующего PDF.

Значение по умолчанию — `False`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но встроенный файл не включается как вложение. Установка опции в `True` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не превращается в интерактивный лист Excel на странице PDF.

В следующем примере загружается презентация, уже содержащая встроенную книгу Excel, и экспортируется в PDF с прикреплённой книгой.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Чтобы проверить результат:

1. Откройте экспортированный PDF в программе, поддерживающей вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** (Вложения) в просмотрщике и найдите встроенную книгу.
3. Сохраните вложение и откройте его в Excel, чтобы проверить данные, или откройте его напрямую, если просмотрщик позволяет. Превью на странице PDF отдельное от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A-1 запрещает встроенные файлы, PDF/A-2 позволяет только вложения PDF/A, а PDF/A-3 допускает другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. В этом примере используется настройка соответствия PDF по умолчанию и не демонстрирует экспорт в PDF/A.
{{% /alert %}}

### **Конвертация PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды в виде страниц в результирующий PDF.

В следующем примере презентация экспортируется в PDF с включением всех скрытых слайдов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Конвертация PowerPoint в защищённый паролем PDF**

В следующем примере презентация экспортируется в PDF, требующий пароль `password` для открытия. Права доступа позволяют печать, включая печать высокого качества.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Обнаружение замены шрифтов**

Аспose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

В следующем примере презентация экспортируется в PDF и выводит предупреждения о замене шрифтов в консоль. Предупреждение выводится только когда недоступный шрифт заменяется при экспортировании. Используйте прокси JPype для получения обратных вызовов предупреждений из Java API. Преобразуйте строку описания из Java в строку Python перед проверкой её префикса:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/python-java/font-substitution/).
{{% /alert %}}

## **Конвертация выбранных слайдов PowerPoint в PDF**

Номера слайдов, передаваемые в [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), начинаются с 1. В этом примере экспортируются слайды 1 и 3, если они существуют:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

В этом примере первый слайд экспортируется на страницу размером 612 × 792 пунктов (US Letter). Слайд клонируется в новую презентацию с указанным размером, и содержимое слайда масштабируется для соответствия.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Удалить пустой слайд, с которым была создана новая презентация.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Конвертация PowerPoint в PDF в виде заметок к слайдам**

В следующем примере презентация экспортируется в PDF, размещая заметки докладчика каждого слайда под самим слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Стандарты доступности и соответствия для PDF**

При подготовке доступных PDF обратитесь к [Руководствам по доступности веб‑контенту (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Используйте [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) для выбора выходного стандарта: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов в зависимости от различных стандартов соответствия:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигурой. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Могу ли я конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно выполнить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа в процессе конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) со значением `True` в классе [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы, такие как [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) и [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) в классе [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) для обеспечения высокого качества изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, для доступности или архивирования. Выберите необходимый стандарт и проверьте полученный результат в соответствии с вашими требованиями.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for Python via Java](/slides/ru/python-java/)
- [Справочник API Aspose.Slides for Python via Java](https://reference.aspose.com/slides/python-java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)