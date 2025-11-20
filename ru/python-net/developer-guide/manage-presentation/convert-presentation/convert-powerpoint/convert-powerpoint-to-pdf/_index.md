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
description: "Пошаговое руководство по конвертации PPT, PPTX и ODP в высококачественные PDF, соответствующие WCAG, на Python с Aspose.Slides — включает защиту паролем, выбор слайдов и контроль качества изображений."
showReadingTime: true
---

## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP) в формат PDF с помощью Python предоставляет несколько преимуществ, среди которых обеспечение совместимости на разных устройствах и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Конвертация PowerPoint в PDF**

Используя Aspose.Slides, вы можете конвертировать презентации в этих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF в Python, достаточно передать имя файла в качестве аргумента класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) и затем сохранить презентацию как PDF с помощью метода [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods). Класс [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) предоставляет метод [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods), который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python напрямую записывает информацию об API и номер версии в выводимых документах. Например, при конвертации презентации в PDF Aspose.Slides for Python заполняет поле Application значением '*Aspose.Slides*', а поле PDF Producer — значением в форме '*Aspose.Slides v XX.XX*'. **Примечание**: вы не можете попросить Aspose.Slides for Python изменить или удалить эту информацию из выводимых документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Весь набор слайдов в PDF
* Конкретные слайды презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие содержимого полученных PDF оригинальным презентациям. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартная операция конвертации PowerPoint в PDF выполняется с использованием параметров по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимальными уровнями качества. Этот код на Python показывает, как конвертировать PowerPoint в PDF:

_Шаги: Конвертация PowerPoint в PDF на Python_

Следующий пример кода объясняет эти конверсии с использованием Python через .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Шаги: Конвертация PowerPoint в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Шаги: Конвертация PPT в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Шаги: Конвертация PPTX в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертация ODP в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертация PPS в PDF с помощью Python через .NET</a></strong>

**Шаги кода:**

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передайте ему файл PowerPoint.
  * Расширение _.ppt_ для загрузки файла **PPT** в класс _Presentation_.
  * Расширение _.pptx_ для загрузки файла **PPTX** в класс _Presentation_.
  * Расширение _.odp_ для загрузки файла **ODP** в класс _Presentation_.
  * Расширение _.pps_ для загрузки файла **PPS** в класс _Presentation_.
- Сохраните _Presentation_ в формат **PDF**, вызвав метод **Save** и используя перечисление **SaveFormat.PDF**.
```python
import aspose.slides as slides

# Создаёт экземпляр класса Presentation, представляющего файл PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Сохраняет презентацию в формате PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```


{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн **конвертер PowerPoint в PDF**(https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Для живой реализации описанной здесь процедуры вы можете протестировать конвертер.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) — которые позволяют настроить получаемый PDF (в результате процесса конвертации), защитить PDF паролем или даже задать порядок выполнения конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочитаемое качество растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, задать DPI для изображений и т.д.

Пример кода ниже демонстрирует операцию, при которой презентация PowerPoint конвертируется в PDF с несколькими пользовательскими параметрами:
```python
import aspose.slides as slides

# Создаёт экземпляр класса PdfOptions
pdf_options = slides.export.PdfOptions()

# Устанавливает качество для JPG‑изображений
pdf_options.jpeg_quality = 90

# Устанавливает DPI для изображений
pdf_options.sufficient_resolution = 300

# Устанавливает поведение для метафайлов
pdf_options.save_metafiles_as_png = True

# Устанавливает уровень сжатия текста для текстового контента
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Определяет режим соответствия PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Создаёт экземпляр класса Presentation, представляющего документ PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Сохраняет презентацию как PDF‑документ
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


### **Конвертация PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, можно использовать пользовательскую опцию — свойство `show_hidden_slides` класса [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) — чтобы указать Aspose.Slides включить скрытые слайды как страницы в получаемом PDF.

Этот код на Python показывает, как конвертировать презентацию PowerPoint в PDF с включенными скрытыми слайдами:
```python
import aspose.slides as slides

# Создаёт экземпляр класса Presentation, представляющего файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Создаёт экземпляр класса PdfOptions
pdfOptions = slides.export.PdfOptions()

# Добавляет скрытые слайды
pdfOptions.show_hidden_slides = True

# Сохраняет презентацию в PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```


### **Конвертация PowerPoint в защищённый паролем PDF**

Этот код на Python показывает, как конвертировать PowerPoint в PDF, защищённый паролем (с использованием параметров защиты из класса [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)):
```python
import aspose.slides as slides

# Создаёт объект Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Создаёт объект класса PdfOptions
pdfOptions = slides.export.PdfOptions()

# Устанавливает пароль PDF и разрешения доступа
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Сохраняет презентацию как PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```


### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет свойство `warning_callback` в классе [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) для возможности обнаружения замен шрифтов в процессе конвертации презентации в PDF.

Этот код на Python показывает, как обнаружить замены шрифтов:
```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```


{{%  alert color="primary"  %}} 

Для получения дополнительной информации о замене шрифтов смотрите статью [Font Substitution](https://docs.aspose.com/slides/python-net/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот код на Python показывает, как конвертировать определённые слайды презентации PowerPoint в PDF:
```python
import aspose.slides as slides

# Создаёт объект Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Устанавливает массив позиций слайдов
slides_array = [ 1, 3 ]

# Сохраняет презентацию в PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```


## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот код на Python показывает, как конвертировать PowerPoint, когда размер слайда задан, в PDF:
```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Создаёт экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
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


## **Конвертация PowerPoint в PDF в режиме заметок слайдов**

Этот код на Python показывает, как конвертировать PowerPoint в PDF‑заметки:
```python
import aspose.slides as slides

# Создаёт экземпляр класса Presentation, представляющего файл PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Сохраняет презентацию в PDF‑заметки
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```


## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код на Python демонстрирует операцию конвертации PowerPoint в PDF, при которой получаются несколько PDF, каждый из которых соответствует различным стандартам соответствия:
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

Поддержка Aspose.Slides в операциях конвертации PDF также позволяет преобразовывать PDF в самые популярные форматы файлов. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) конвертации. Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

## **FAQ**

**Может ли Aspose.Slides for Python удалить информацию о приложении из PDF?**

Нет, Aspose.Slides for Python автоматически включает информацию об API и номер версии в выходной PDF. Эта информация не может быть изменена или удалена.

**Как включить только определённые слайды в конвертацию PDF?**

Вы можете указать индексы слайдов, которые хотите конвертировать, передав массив позиций слайдов в метод `save`.

**Можно ли защитить PDF паролем во время конвертации?**

Да, вы можете установить пароль и определить разрешения доступа, используя класс `PdfOptions`, перед сохранением презентации в PDF.

**Поддерживает ли Aspose.Slides конвертацию PDF в другие форматы?**

Да, Aspose.Slides поддерживает конвертацию PDF в такие форматы, как HTML, форматы изображений (JPG, PNG), SVG, TIFF и XML.

**Как убедиться, что мой PDF соответствует стандартам доступности?**

Установите свойство `compliance` в `PdfOptions` в значение стандартов, таких как `PDF_A1A`, `PDF_A1B` или `PDF_UA`, чтобы обеспечить соответствие рекомендациям по доступности.

**Можно ли включить скрытые слайды в PDF?**

Да, установив свойство `show_hidden_slides` в `PdfOptions` в `True`, скрытые слайды будут включены в PDF.

**Как настроить качество и разрешение изображений при конвертации?**

Используйте свойства `jpeg_quality` и `sufficient_resolution` в `PdfOptions` для управления качеством и разрешением изображений в получаемом PDF.

**Обрабатывает ли Aspose.Slides замену шрифтов автоматически?**

Aspose.Slides обнаруживает замену шрифтов во время конвертации, и вы можете обработать её с помощью свойства `warning_callback` в `SaveOptions` (в настоящее время ограничено).

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для .NET](https://docs.aspose.com/slides/python-net/)
- [Справочник API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)