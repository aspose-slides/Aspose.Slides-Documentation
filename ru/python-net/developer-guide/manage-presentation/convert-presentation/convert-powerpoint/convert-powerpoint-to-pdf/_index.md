---
title: Конвертировать PPT & PPTX в PDF на Python | Расширенные параметры
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/python-net/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- презентация
- PowerPoint в PDF
- PPT в PDF
- PPTX в PDF
- сохранить PowerPoint как PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Пошаговое руководство по конвертации PPT, PPTX и ODP в PDF высокого качества, соответствующие требованиям WCAG, на Python с помощью Aspose.Slides — включает защиту паролем, выбор слайдов и контроль качества изображений."
showReadingTime: true
---
## **Обзор**

Конвертирование презентаций PowerPoint (PPT, PPTX, ODP) в формат PDF в Python предоставляет несколько преимуществ, включая обеспечение совместимости на разных устройствах и сохранение макета и форматирования вашей презентации. В этом руководстве демонстрируется, как преобразовать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF документы паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

Используя Aspose.Slides, вы можете конвертировать презентации этих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF в Python, достаточно передать имя файла в качестве аргумента классу [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/) и затем сохранить презентацию как PDF, используя метод [Save](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/#methods). Класс [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/) раскрывает метод [Save](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/#methods), который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python напрямую записывает информацию об API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides for Python заполняет поле Application значением '*Aspose.Slides*', а поле PDF Producer — значением в форме '*Aspose.Slides v XX.XX*'. **Примечание** — нельзя заставить Aspose.Slides for Python изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Конкретные слайды презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально точное совпадение содержимого полученных PDF с оригинальными презентациями. Элементы и атрибуты отображаются точно, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартная операция конвертации PowerPoint в PDF выполняется с использованием параметров по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки при максимальном качестве. Этот пример кода на Python показывает, как конвертировать PowerPoint в PDF:

_Шаги: Конвертация PowerPoint в PDF в Python_

Следующий пример кода объясняет эти конвертации с использованием Python через .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Шаги: Конвертировать PowerPoint в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Шаги: Конвертировать PPT в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Шаги: Конвертировать PPTX в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертировать ODP в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертировать PPS в PDF с помощью Python через .NET</a></strong>

_Шаги кода:_

- Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и передать ему файл PowerPoint.  
  * Расширение _.ppt_ — загрузка **PPT** файла в класс _Presentation_.  
  * Расширение _.pptx_ — загрузка **PPTX** файла в класс _Presentation_.  
  * Расширение _.odp_ — загрузка **ODP** файла в класс _Presentation_.  
  * Расширение _.pps_ — загрузка **PPS** файла в класс _Presentation_.  
- Сохранить _Presentation_ в формате **PDF**, вызвав метод **Save** и используя перечисление **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Создаёт экземпляр класса Presentation, представляющего файл PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Сохраняет презентацию в формате PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн‑конвертер **PowerPoint в PDF** ([https://products.aspose.app/slides/ru/conversion/ppt-to-pdf](https://products.aspose.app/slides/ru/conversion/ppt-to-pdf)), демонстрирующий процесс конвертации презентации в PDF. Для живой реализации описанной здесь процедуры вы можете протестировать конвертер.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides.export/pdfoptions/), которые позволяют настроить получаемый PDF, заблокировать PDF паролем или даже задать порядок выполнения процесса конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, задать DPI для изображений и т.д.

Ниже приведён пример кода, в котором презентация PowerPoint конвертируется в PDF с несколькими пользовательскими параметрами:

```python
import aspose.slides as slides

# Создаёт экземпляр класса PdfOptions
pdf_options = slides.export.PdfOptions()

# Устанавливает качество JPG‑изображений
pdf_options.jpeg_quality = 90

# Устанавливает DPI для изображений
pdf_options.sufficient_resolution = 300

# Задает поведение для метафайлов
pdf_options.save_metafiles_as_png = True

# Устанавливает уровень сжатия текста для текстового содержимого
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Определяет режим соответствия PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Создаёт экземпляр класса Presentation, представляющего документ PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Сохраняет презентацию как PDF‑документ
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Конвертировать PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать пользовательский параметр — свойство `show_hidden_slides` класса [PdfOptions](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides.export/pdfoptions/), чтобы указать Aspose.Slides включить скрытые слайды как страницы в получаемом PDF.

Этот пример кода на Python показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```python
import aspose.slides as slides

# Создаёт экземпляр класса Presentation, представляющего файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Создаёт экземпляр класса PdfOptions
pdfOptions = slides.export.PdfOptions()

# Добавляет скрытые слайды
pdfOptions.show_hidden_slides = True

# Сохраняет презентацию в формате PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Конвертировать PowerPoint в PDF, защищённый паролем**

Этот пример кода на Python показывает, как конвертировать PowerPoint в PDF, защищённый паролем (используя параметры защиты из класса [PdfOptions](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Создаёт объект Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Создаёт экземпляр класса PdfOptions
pdfOptions = slides.export.PdfOptions()

# Устанавливает пароль PDF и разрешения доступа
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Сохраняет презентацию в формате PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет свойство `warning_callback` класса [SaveOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveoptions/) для обнаружения замен шрифтов в процессе конвертации презентации в PDF.

Этот пример кода на Python показывает, как обнаружить замену шрифтов:

```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```

{{%  alert color="primary"  %}} 

Более подробную информацию о замене шрифтов см. в статье [Font Substitution](https://docs.aspose.com/slides/ru/python-net/font-substitution/).

{{% /alert %}} 

## **Конвертировать выбранные слайды PowerPoint в PDF**

Этот пример кода на Python показывает, как конвертировать конкретные слайды презентации PowerPoint в PDF:

```python
import aspose.slides as slides

# Создаёт объект Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Устанавливает массив позиций слайдов
slides_array = [ 1, 3 ]

# Сохраняет презентацию в формате PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот пример кода на Python показывает, как конвертировать PowerPoint, у которого указан размер слайда, в PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Создаёт объект Presentation, представляющий файл PowerPoint или OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Создаёт новую презентацию с изменённым размером слайда.
    with slides.Presentation() as resized_presentation:

        # Устанавливает пользовательский размер слайда.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Клонирует первый слайд из исходной презентации.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Сохраняет изменённую презентацию в PDF с заметками.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Конвертировать PowerPoint в PDF в режиме заметок слайда**

Этот пример кода на Python показывает, как конвертировать PowerPoint в PDF‑заметки:

```python
import aspose.slides as slides

# Создаёт объект класса Presentation, представляющего файл PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Сохраняет презентацию в PDF‑заметках
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Рекомендациям по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот пример кода на Python демонстрирует операцию конвертации PowerPoint в PDF, в которой получаются несколько PDF‑файлов на основе разных стандартов соответствия:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Поддержка Aspose.Slides для операций конвертации PDF расширяется возможностью конвертировать PDF в самые популярные форматы файлов. Вы можете выполнять конвертации [PDF to HTML](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-jpg/), и [PDF to PNG](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF to SVG](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-tiff/), и [PDF to XML](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-xml/) — тоже поддерживаются.

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложные графические элементы, такие как SmartArt, диаграммы и формулы, как одну фигурку. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигурки.

## **Вопросы и ответы**

**Может ли Aspose.Slides for Python удалить информацию о приложении из PDF?**

Нет, Aspose.Slides for Python автоматически включает информацию об API и номер версии в выходной PDF. Эта информация не может быть изменена или удалена.

**Как включить только определённые слайды при конвертации в PDF?**

Можно указать индексы слайдов, которые необходимо конвертировать, передав массив позиций слайдов в метод `save`.

**Можно ли защитить PDF паролем во время конвертации?**

Да, можно задать пароль и определить разрешения доступа, используя класс `PdfOptions` перед сохранением презентации в PDF.

**Поддерживает ли Aspose.Slides конвертацию PDF в другие форматы?**

Да, Aspose.Slides поддерживает конвертацию PDF в такие форматы, как HTML, графические форматы (JPG, PNG), SVG, TIFF и XML.

**Как убедиться, что мой PDF соответствует стандартам доступности?**

Установите свойство `compliance` в `PdfOptions` в значение `PDF_A1A`, `PDF_A1B` или `PDF_UA` для соответствия рекомендациям по доступности.

**Можно ли включить скрытые слайды в PDF?**

Да, установив свойство `show_hidden_slides` в `PdfOptions` в `True`, скрытые слайды будут включены в PDF.

**Как настроить качество и разрешение изображений при конвертации?**

Используйте свойства `jpeg_quality` и `sufficient_resolution` в `PdfOptions` для управления качеством и разрешением изображений в получаемом PDF.

**Aspose.Slides автоматически обрабатывает замену шрифтов?**

Aspose.Slides обнаруживает замену шрифтов во время конвертации, и вы можете обрабатывать её, используя свойство `warning_callback` в `SaveOptions` (в текущей версии ограничено).

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для .NET](https://docs.aspose.com/slides/ru/python-net/)
- [Справочник API Aspose.Slides](https://reference.aspose.com/slides/ru/python-net/)
- [Бесплатные онлайн конвертеры Aspose](https://products.aspose.app/slides/ru/conversion)