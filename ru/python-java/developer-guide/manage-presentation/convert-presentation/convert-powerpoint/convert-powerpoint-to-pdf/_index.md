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
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в PDF высокого качества, пригодный для поиска, в Python через Java используя Aspose.Slides, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и др.) в формат PDF в Python через Java предлагает несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные варианты для управления качеством изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Преобразования PowerPoint в PDF**

Используя Aspose.Slides, вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) , а затем сохраните презентацию в PDF, используя метод [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) . Класс [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) , который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java вставляет информацию о своем API и номер версии в выходные документы. Например, при преобразовании презентации в PDF, Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в формате "*Aspose.Slides v XX.XX*". **Примечание** что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты рендерятся точно при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Преобразовать PowerPoint в PDF**

Стандартное преобразование использует настройки экспорта PDF по умолчанию. Используйте пользовательские параметры, когда необходимо контролировать качество изображений, содержимое страниц или соответствие PDF.

Установите [Aspose.Slides for Python via Java](/slides/ru/python-java/installation/) и совместимую среду Java перед запуском примеров. Каждый пример читает `presentation.pptx` из текущего рабочего каталога; замените его вашим файлом PPT, PPTX или ODP. Запустите JVM один раз на процесс Python.

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
Aspose предлагает бесплатный онлайн‑[**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) , демонстрирующий процесс преобразования презентации в PDF. Вы можете протестировать этот конвертер для живой реализации описанной здесь процедуры.
{{% /alert %}}

## **Преобразовать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) — которые позволяют настроить получаемый PDF, защитить PDF паролем или задать порядок выполнения процесса конвертации.

### **Преобразовать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

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

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF имели доступ к данным книги, а также могли просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) с `True`, чтобы сохранить встроенные OLE‑файлы как вложения в результирующем PDF.

Значение по умолчанию — `False`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но встроенный файл не включается как вложение. Установка параметра в `True` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивной таблицей Excel на странице PDF.

Следующий пример загружает презентацию, уже содержащую встроенную книгу Excel, и экспортирует её в PDF с вложенной книгой.

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

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** и найдите встроенную книгу.
3. Сохраните вложение и откройте его в Excel для просмотра данных, или откройте непосредственно, если просмотрщик позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A-1 запрещает вложенные файлы, PDF/A-2 допускает только вложения PDF/A, а PDF/A-3 допускает другие типы файлов, включая книги Excel. Эти требования задаются стандартом, а не ограничениями Aspose.Slides. В данном примере используется настройка соответствия PDF по умолчанию и не демонстрирует экспорт PDF/A.
{{% /alert %}}

### **Преобразовать PowerPoint в PDF с включением скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) , чтобы включить скрытые слайды как страницы в результирующем PDF.

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

### **Преобразовать PowerPoint в PDF с паролем**

Следующий пример экспортирует презентацию в PDF, для открытия которого требуется пароль `password`. Доступные разрешения позволяют печать, включая печать высокого качества.

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

### **Обнаружить замену шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) класса [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) , позволяющий обнаруживать замену шрифтов во время процесса преобразования презентации в PDF.

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
Для получения дополнительной информации о замене шрифтов см. статью [**Замена шрифтов**](/slides/ru/python-java/font-substitution/).
{{% /alert %}}

### **Обработка шрифтов без отдельного полужирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного полужирного начертания. Текст всё равно может выглядеть полужирным за счёт синтетического увеличения толщины глифов. Когда такой текст выглядит слишком тяжёлым или отличается от желаемого вида в PDF, попробуйте вызвать [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) с `True`. Эта опция рендерит затронутый текст как растровое изображение при экспорте в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `False`.

В образце презентации два текстовых блока: один с обычным текстом и один с полужирным форматированием того же шрифта, у которого нет отдельного полужирного начертания. Ниже пример загружает презентацию, включает растеризацию неподдерживаемых стилей шрифтов и экспортирует её в PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Ниже показаны превью с отключённым и включённым параметром. В этом примере при отключённой опции полужирный текст имеет более тяжёлые линии. При включённой опции линии становятся тоньше; обычный текст остаётся без изменений. Сравните результаты перед выбором настройки для вашей презентации.

| Опция отключена (`False`, значение по умолчанию) | Опция включена (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В этом примере включение опции превращает только полужирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, а его края выглядят мягче при увеличении 800 %. Обычный текст остаётся поисковым. При отключённой опции обе строки остаются текстовыми.

Эта опция растеризует текст, отформатированный как полужирный, когда у шрифта нет отдельного полужирного начертания. [Замена шрифтов](/slides/ru/python-java/font-substitution/) вместо этого выбирает другой шрифт, когда оригинальный недоступен.

## **Преобразовать выбранные слайды PowerPoint в PDF**

Номера слайдов, передаваемые в [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) , нумеруются с 1. В этом примере экспортируются слайды 1 и 3, если они существуют:

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

## **Преобразовать PowerPoint в PDF с пользовательским размером слайда**

Этот пример экспортирует первый слайд на страницу размером 612 × 792 пунктов (US Letter). Он клонирует слайд в новую презентацию с указанным размером и масштабирует содержимое слайда для соответствия.

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

## **Преобразовать PowerPoint в PDF в режиме заметок слайда**

Следующий пример экспортирует презентацию в PDF, размещая нотатки докладчика под каждым слайдом. Используйте презентацию, содержащую нотатки докладчика, чтобы увидеть результат.

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

## **Стандарты доступности и соответствия PDF**

При подготовке доступных PDF‑файлов обратитесь к [Руководству по веб‑доступности (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Используйте [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) для выбора стандарта вывода: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

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

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы путей не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Могу ли я массово конвертировать несколько файлов PowerPoint в PDF?**

Да, Aspose.Slides поддерживает пакетное преобразование нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) с `True` в классе [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) , чтобы включить скрытые слайды в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) и [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) в классе [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) , чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, для доступности или архивирования. Выберите необходимый стандарт и проверьте результат в соответствии с вашими требованиями.

## **Дополнительные ресурсы**

- [Aspose.Slides for Python via Java Documentation](/slides/ru/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)