---
title: Конвертировать PPT и PPTX в PDF в Python через Java [Включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/python-java/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в PDF
- презентация в PDF
- PPT в PDF
- конвертировать PPT в PDF
- PPTX в PDF
- конвертировать PPTX в PDF
- сохранить PowerPoint как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в Python через Java с использованием Aspose.Slides, предоставляя быстрые примеры кода и расширенные параметры конвертации."
---
## **Overview**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF в Python через Java имеет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **PowerPoint to PDF Conversions**

С помощью Aspose.Slides вы можете преобразовать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF с помощью метода [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save). Класс [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save), который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java вставляет информацию о своей API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением вида "*Aspose.Slides v XX.XX*". **Note** that you cannot instruct Aspose.Slides to change or remove this information from output documents.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Весь документ в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая точное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты отображаются корректно при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Convert PowerPoint to PDF**

Стандартная конвертация использует параметры экспорта PDF по умолчанию. Пользовательские параметры применяются, когда необходимо контролировать качество изображений, содержание страниц или соответствие PDF требованиям.

Установите [Aspose.Slides for Python via Java](/slides/ru/python-java/installation/) и совместимую среду Java перед запуском примеров. Каждый пример читает файл `presentation.pptx` из текущей рабочей директории; замените его вашим файлом PPT, PPTX или ODP. JVM следует запускать один раз за процесс Python.

Этот код конвертирует презентацию в PDF:

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

Aspose предлагает бесплатный онлайн‑конвертер **PowerPoint to PDF** (https://products.aspose.app/slides/ru/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете протестировать процесс с помощью этого конвертера для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) — которые позволяют настроить результирующий PDF, защитить PDF паролем или задать порядок выполнения процесса конвертации.

### **Convert PowerPoint to PDF with Custom Options**

С использованием пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, определить способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующий, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convert PowerPoint to PDF with Hidden Slides**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) для включения скрытых слайдов в виде страниц в результирующий PDF.

Этот код показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convert PowerPoint to a Password-Protected PDF**

Этот пример демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/):

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Detect Font Substitutions**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Используйте прокси JPype для получения предупреждений от Java API. Преобразуйте строку описания из Java в строку Python перед проверкой её префикса:

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


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Для получения дополнительной информации о получении обратных вызовов при замене шрифтов во время рендеринга см. [Getting Warning Callbacks for Font Substitution](/slides/ru/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для более детального описания замены шрифтов см. статью [Font Substitution](/slides/ru/python-java/font-substitution/).

{{% /alert %}}

## **Convert Selected Slides in PowerPoint to PDF**

Номера слайдов, передаваемые в [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save), считаются от 1. В этом примере экспортируются слайды 1 и 3, если они существуют:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **Convert PowerPoint to PDF with Custom Slide Size**

Этот пример экспортирует первый слайд на страницу размером 612 × 792 пункта (US Letter). Слайд копируется в новую презентацию с указанным размером:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **Convert PowerPoint to PDF in Notes Slide View**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Accessibility and Compliance Standards for PDF**

При подготовке доступных PDF‑документов следует обращаться к [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Используйте [PdfOptions.setCompliance](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setCompliance) для выбора стандарта вывода: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов на основе разных стандартов соответствия:

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

> **Note:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельное содержание и могут быть помечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **FAQ**

**Можно ли пакетно конвертировать несколько файлов PowerPoint в PDF?**

Да, Aspose.Slides поддерживает пакетную конвертацию множества файлов PPT или PPTX в PDF. Вы можете перебрать файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод [setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений с помощью методов [setJpegQuality](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setJpegQuality) и [setSufficientResolution](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSufficientResolution) класса [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/), обеспечивая высококачественные изображения в PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, для обеспечения доступности или архивирования. Выберите нужный стандарт и проверьте результат на соответствие требованиям.

## **Additional Resources**

- [Aspose.Slides for Python via Java Documentation](/slides/ru/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/ru/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ru/conversion)