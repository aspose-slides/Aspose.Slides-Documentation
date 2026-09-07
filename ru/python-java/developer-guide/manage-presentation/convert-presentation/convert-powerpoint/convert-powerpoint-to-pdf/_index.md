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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в Python через Java с использованием Aspose.Slides, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF в Python через Java предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save). Класс [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save), который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Примечание" %}}

Aspose.Slides for Python via Java вставляет информацию о своей версии API в выводимые документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в виде "*Aspose.Slides v XX.XX*". **Примечание**, что изменить или удалить эту информацию из выходных документов нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Весь набор слайдов в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что полученные PDF‑файлы максимально соответствуют исходным презентациям. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигурные объекты
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартная конвертация использует параметры экспорта PDF по умолчанию. Пользовательские параметры требуются, когда необходимо контролировать качество изображений, содержимое страниц или соответствие PDF‑стандартам.

Установите [Aspose.Slides for Python via Java](/slides/ru/python-java/installation/) и совместимую среду Java перед запуском примеров. Каждый пример читает файл `presentation.pptx` из текущего рабочего каталога; замените его своим файлом PPT, PPTX или ODP. Запускайте JVM один раз за процесс Python.

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

{{% alert color="info" title="Примечание" %}}

Aspose предлагает бесплатный онлайн‑конвертер **PowerPoint в PDF** https://products.aspose.app/slides/ru/conversion/ppt-to-pdf, демонстрирующий процесс преобразования презентации в PDF. Вы можете протестировать процесс с помощью этого конвертера.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет настраиваемые параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) — которые позволяют настроить получаемый PDF, установить пароль или указать, как должен проходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать предпочитаемый уровень качества растровых изображений, определить способ обработки метафайлов, установить уровень сжатия текста, задать DPI для изображений и многое другое.

Ниже показан пример кода, демонстрирующий конвертацию презентации PowerPoint в PDF с несколькими пользовательскими параметрами.

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

### **Конвертация PowerPoint в PDF со скрытыми слайдами**

Если в презентации есть скрытые слайды, используйте метод [setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды как страницы в результирующий PDF.

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

### **Конвертация PowerPoint в PDF с паролем**

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/):

```python
import jpype
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

### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время конвертации презентации в PDF.

Используйте прокси JPype для получения предупреждений из Java‑API. Преобразуйте строку описания из Java в строку Python перед проверкой её префикса:

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

{{% alert color="info" title="Примечание" %}}

Подробнее о получении обратных вызовов при замене шрифтов во время рендеринга см. [Получение предупреждающих вызовов для замены шрифтов](/slides/ru/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Дополнительная информация о замене шрифтов доступна в статье [Замена шрифтов](/slides/ru/python-java/font-substitution/).

{{% /alert %}}

## **Конвертация выбранных слайдов PowerPoint в PDF**

Номера слайдов, передаваемые в [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save), считаются начиная с 1. В данном примере экспортируются слайды 1 и 3, если они существуют:

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

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

В этом примере экспортируется первый слайд на страницу размером 612 × 792 пункта (US Letter). Слайд копируется в новую презентацию с указанным размером:

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

## **Конвертация PowerPoint в PDF в режиме «Заметки»**

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

## **Доступность и стандарты соответствия PDF**

При подготовке доступных PDF‑файлов руководствуйтесь [Руководством по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Используйте [PdfOptions.setCompliance](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setCompliance) для выбора стандарта вывода: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Пример кода, показывающий процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов с различными стандартами соответствия:

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

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите метод [setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) в классе [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы [setJpegQuality](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setJpegQuality) и [setSufficientResolution](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSufficientResolution) класса [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/), чтобы обеспечить высокое качество изображений в PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, для доступности или архивирования. Выберите нужный стандарт и проверьте результат в соответствии с вашими требованиями.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for Python via Java](/slides/ru/python-java/)
- [Справочник API Aspose.Slides for Python via Java](https://reference.aspose.com/slides/ru/python-java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/ru/conversion)