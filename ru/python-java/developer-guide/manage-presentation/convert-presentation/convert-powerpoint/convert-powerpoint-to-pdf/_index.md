---
title: Преобразовать PPT и PPTX в PDF в Python через Java [Включены расширенные возможности]
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
description: "Преобразуйте презентации PowerPoint PPT/PPTX в качественные, индексируемые PDF в Python через Java, используя Aspose.Slides, с быстрыми примерами кода и расширенными параметрами конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF в Python через Java предлагает несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к выводимым документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете преобразовать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Класс [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Примечание" %}}

Aspose.Slides for Python via Java вставляет информацию о своей API и номер версии в выводимые документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением вида "*Aspose.Slides v XX.XX*". **Обратите внимание**, что вы не можете указать Aspose.Slides изменить или удалить эту информацию из выводимых документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая близкое соответствие полученных PDF оригиналам. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартная конверсия использует параметры экспорта PDF по умолчанию. Используйте пользовательские параметры, когда необходимо управлять качеством изображений, содержимым страниц или соответствием PDF.

Ниже приведён пример, который загружает презентацию и сохраняет все видимые слайды в PDF, используя параметры экспорта по умолчанию.

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

Aspose предлагает бесплатный онлайн‑конвертер [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) — которые позволяют настраивать получаемый PDF, защищать его паролем или задавать порядок выполнения конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать желаемое качество растровых изображений, указать способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже пример экспортирует презентацию в PDF 1.5 с качеством JPEG 90, разрешением изображений 300 DPI, метафайлы сохраняются как PNG, и включено сжатие текста Flate.

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

### **Автоматический выбор сжатия изображений**

Когда в презентации содержится множество фотографий или скриншотов, уменьшение размера экспортируемого PDF упрощает отправку по электронной почте или загрузку. Вызовите [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) с `True`, чтобы автоматически выбрать наиболее подходящий алгоритм сжатия для каждого изображения при экспорте PDF.

Ниже пример загружает существующую презентацию, включает автоматический выбор сжатия изображений и сохраняет её как PDF‑документ. Все остальные параметры экспорта PDF сохраняются со значениями по умолчанию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Этот параметр выбирает алгоритм сжатия для каждого изображения. Понижение значения, передаваемого в [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality), снижает качество JPEG‑изображения, а уменьшение значения, передаваемого в [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution), позволяет понизить разрешение изображений, что может уменьшить детализацию. Включение автоматического выбора сжатия само по себе не изменяет ни один из этих параметров.

Выбор алгоритмов сжатия изображений требует дополнительных вычислительных ресурсов и памяти. Размер уменьшения зависит от изображений презентации и параметров экспорта; фиксированное сокращение не гарантировано для каждой презентации.

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если в презентации присутствует вложенная рабочая книга Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным книги, а также просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) с `True`, чтобы сохранить встроенные OLE‑файлы в виде вложений в результирующий PDF.

Значение по умолчанию `False`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но встроенный файл не включается в виде вложения. Установка параметра в `True` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не превращается в интерактивный лист Excel на странице PDF.

Ниже пример загружает презентацию, уже содержащую вложенную рабочую книгу Excel, и экспортирует её в PDF с прикреплённой книгой.

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

Для проверки результата:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например в Adobe Acrobat Reader.
2. Откройте панель **Attachments** и найдите вложенную рабочую книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, либо откройте напрямую, если просмотрщик позволяет.

{{% alert color="info" title="Примечание" %}}

Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает вложенные файлы, PDF/A‑2 позволяет только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая рабочие книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. Данный пример использует настройки соответствия PDF по умолчанию и не демонстрирует экспорт PDF/A.

{{% /alert %}}

### **Конвертировать PowerPoint в PDF с скрытыми слайдами**

Если в презентации есть скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) из класса [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) для включения скрытых слайдов как страниц в результирующий PDF.

Ниже пример экспортирует презентацию в PDF, включая любые скрытые слайды.

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

### **Конвертировать PowerPoint в PDF, защищённый паролем**

Ниже пример экспортирует презентацию в PDF, открытие которого требует пароль `password`. Разрешения доступа позволяют печатать, включая печать высокого качества.

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

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Ниже пример экспортирует презентацию в PDF и выводит предупреждения о замене шрифтов в консоль. Предупреждение выводится только тогда, когда при экспорте происходит подстановка недоступного шрифта. Используйте прокси JPype для получения обратных вызовов предупреждений из Java API. Преобразуйте строку описания из Java в строку Python перед проверкой её префикса:

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

{{% alert color="info" title="Примечание" %}}

Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/python-java/font-substitution/).

{{% /alert %}}

### **Обработка шрифтов без отдельного полужирного начертания**

Презентация может применять полужирное оформление к тексту, даже если у шрифта нет отдельного полужирного начертания. Текст всё равно может выглядеть полужирным благодаря синтетическому полужирному шрифту, который искусственно утолщает обычные глифы. Если такой текст выглядит слишком тяжёлым или иначе отличается от желаемого вида в PDF, попробуйте вызвать [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) с `True`. Этот параметр рендерит затронутый текст как растровое изображение при экспорте PDF и может улучшить его внешний вид для некоторых шрифтов. Значение по умолчанию `False`.

В образце презентации два текстовых блока: один с обычным текстом, другой с полужирным оформлением того же шрифта, у которого нет отдельного полужирного начертания. Ниже пример загружает презентацию, включает растеризацию неподдерживаемых стилей шрифта и экспортирует её в PDF:

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

Ниже показаны превью вывода с отключённым и включённым параметром. В этом примере полужирный текст имеет более тяжёлые штрихи при отключённом параметре. При включённом параметре штрихи стали светлее; обычный текст остался без изменений. Сравните результаты перед выбором настройки для вашей презентации.

| Параметр отключён (`False`, значение по умолчанию) | Параметр включён (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В данном примере включение параметра преобразует только полужирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, а его края выглядят мягче при 800 % увеличении. Обычный текст остаётся индексируемым. При отключённом параметре обе строки остаются текстом.

Этот параметр растеризует текст, отформатированный как полужирный, когда у его шрифта нет отдельного полужирного начертания. Вместо этого [Font substitution](/slides/ru/python-java/font-substitution/) выбирает другой шрифт, если оригинальный недоступен.

## **Конвертировать выбранные слайды PowerPoint в PDF**

Номера слайдов, передаваемые в [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), нумеруются с 1. В этом примере экспортируются слайды 1 и 3, если они существуют:

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

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот пример экспортирует первый слайд на страницу размером 612 × 792 points (US Letter). Он клонирует слайд в новую презентацию с указанным размером и масштабирует содержимое слайда, чтобы оно поместилось.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpython.startJVM()

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

## **Конвертировать PowerPoint в PDF в режиме заметок слайда**

Ниже пример экспортирует презентацию в PDF, размещая заметки докладчика под каждым слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

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

## **Доступность и стандарты соответствия PDF**

При подготовке доступных PDF следует обращаться к [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Используйте [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) для выбора выходного стандарта: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов в соответствии с различными стандартами соответствия:

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

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложные графики, такие как SmartArt, диаграммы и формулы, как одну фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конверсию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) для установки пароля и определения разрешений доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) с `True` в классе [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Сохраняет ли Aspose.Slides высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) и [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) в классе [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) для обеспечения высокого качества изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, для доступности или архивации. Выберите подходящий стандарт и проверьте результат в соответствии с вашими требованиями.

## **Дополнительные ресурсы**

- [Aspose.Slides for Python via Java Documentation](/slides/ru/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)