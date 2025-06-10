---
title: Преобразуйте PPT и PPTX в PDF на Python | Расширенные параметры
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
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Пошаговое руководство по конвертации PPT и PPTX в PDF высокого качества, соответствующих стандартам доступности WCAG, на Python с помощью Aspose.Slides — включает защиту паролем, выбор слайдов и контроль качества изображений."
---

## **Обзор**

Конвертация документов PowerPoint в формат PDF предлагает несколько преимуществ, включая обеспечение совместимости на разных устройствах и сохранение разметки и форматирования вашей презентации. Эта статья покажет вам, как конвертировать презентации в PDF-документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF-документы паролем, обнаруживать замены шрифтов, выбирать слайды для конвертации и применять стандарты соблюдения к выходным документам.

## **Конвертации PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* PPT
* PPTX
* ODP

Чтобы конвертировать презентацию в PDF на Python, вам просто нужно передать имя файла как аргумент в классе [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) и затем сохранить презентацию как PDF, используя метод [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods). Класс [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) предоставляет метод [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods), который обычно используется для конвертации презентации в PDF.

{{%  alert title="ЗАМЕТКА"  color="warning"   %}} 

Aspose.Slides для Python напрямую записывает информацию об API и номер версии в выходные документы. Например, когда он конвертирует презентацию в PDF, Aspose.Slides для Python заполняет поле Application значением '*Aspose.Slides*' и поле PDF Producer значением в форме '*Aspose.Slides v XX.XX*'. **Обратите внимание**, что вы не можете заставить Aspose.Slides для Python изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* всю презентацию в PDF
* определенные слайды в презентации в PDF
* презентацию 

Aspose.Slides экспортирует презентации в PDF таким образом, что содержимое полученных PDF-документов очень похоже на содержимое оригинальных презентаций. Эти известные элементы и атрибуты часто правильно отображаются при конвертации презентации в PDF:

* изображения
* текстовые поля и другие фигуры
* тексты и их форматирование
* абзацы и их форматирование
* гиперссылки
* колонтитулы
* маркеры
* таблицы

## **Конвертировать PowerPoint в PDF**

Стандартная операция конвертации PowerPoint в PDF выполняется с использованием параметров по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки на максимальных уровнях качества. Этот код на Python показывает, как конвертировать PowerPoint в PDF:

_Шаги: Конвертация PowerPoint в PDF на Python_

Следующий пример кода объясняет эти конвертации с помощью Python через .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Шаги: Конвертировать PowerPoint в PDF с использованием Python через .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Шаги: Конвертировать PPT в PDF с использованием Python через .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Шаги: Конвертировать PPTX в PDF с использованием Python через .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертировать ODP в PDF с использованием Python через .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертировать PPS в PDF с использованием Python через .NET</a></strong>

_Шаги кода:_

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и предоставьте ему файл PowerPoint.
  * _.ppt_ расширение для загрузки **PPT** файла в класс _Presentation_.
  * _.pptx_ расширение для загрузки **PPTX** файла в класс _Presentation_.
  * _.odp_ расширение для загрузки **ODP** файла в класс _Presentation_.
  * _.pps_ расширение для загрузки **PPS** файла в класс _Presentation_.
- Сохраните _Presentation_ в формате **PDF**, вызвав метод **Save** и использовав перечисление **SaveFormat.PDF**.
  

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Сохраняет презентацию как PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Для живой реализации процедуры, описанной здесь, вы можете протестировать конвертер.

{{% /alert %}}

## Конвертировать PowerPoint в PDF с параметрами

Aspose.Slides предлагает настраиваемые опции — свойства класса [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/), которые позволяют вам настроить PDF (результат процесса конвертации), защитить PDF паролем или даже определить, как должен проходить процесс конвертации.

### **Конвертация PowerPoint в PDF с настраиваемыми параметрами**

Используя настраиваемые параметры конвертации, вы можете установить предпочтительное качество для растровых изображений, определить, как должны обрабатываться метафайлы, установить уровень сжатия для текста, установить DPI для изображений и т. д.

Пример кода ниже демонстрирует операцию, в которой PowerPoint-презентация конвертируется в PDF с несколькими настраиваемыми опциями:

```python
import aspose.slides as slides

# Создает экземпляр класса PdfOptions
pdf_options = slides.export.PdfOptions()

# Устанавливает качество для JPG изображений
pdf_options.jpeg_quality = 90

# Устанавливает DPI для изображений
pdf_options.sufficient_resolution = 300

# Устанавливает поведение для метафайлов
pdf_options.save_metafiles_as_png = True

# Устанавливает уровень сжатия текста для текстового содержания
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Определяет режим соблюдения PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Создает экземпляр класса Presentation, представляющий документ PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Сохраняет презентацию как PDF-документ
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Конвертировать PowerPoint с скрытыми слайдами в PDF**

Если презентация содержит скрытые слайды, вы можете использовать настраиваемый параметр — свойство `show_hidden_slides` класса [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/), чтобы указать Aspose.Slides включить скрытые слайды как страницы в результирующем PDF.

Этот код на Python показывает, как конвертировать PowerPoint-презентацию в PDF с включенными скрытыми слайдами:

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Создает экземпляр класса PdfOptions
pdfOptions = slides.export.PdfOptions()

# Включает скрытые слайды
pdfOptions.show_hidden_slides = True

# Сохраняет презентацию как PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Конвертировать PowerPoint в защищенный паролем PDF**

Этот код на Python показывает, как конвертировать PowerPoint в PDF, защищенный паролем (с использованием параметров защиты из класса [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Создает экземпляр класса PdfOptions
pdfOptions = slides.export.PdfOptions()

# Устанавливает пароль PDF и разрешения доступа
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Сохраняет презентацию как PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет свойство `warning_callback` в классе [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/), чтобы вы могли обнаружить замены шрифтов в процессе конвертации презентации в PDF. 

Этот код на Python показывает, как обнаружить замены шрифтов:  

```python
[TODO[SLIDESPYNET-91]: обратные вызовы пока не поддерживаются]
```

{{%  alert color="primary"  %}} 

Для получения дополнительной информации о замене шрифтов смотрите статью [Замена шрифтов](https://docs.aspose.com/slides/python-net/font-substitution/).

{{% /alert %}} 

## **Конвертировать выбранные слайды PowerPoint в PDF**

Этот код на Python показывает, как конвертировать конкретные слайды в PowerPoint-презентации в PDF:

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Устанавливает массив позиций слайдов
slides_array = [ 1, 3 ]

# Сохраняет презентацию как PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Конвертировать PowerPoint в PDF с настраиваемым размером слайда**

Этот код на Python показывает, как конвертировать PowerPoint, когда размер его слайдов указан, в PDF:

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий файл PowerPoint 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Устанавливает тип и размер слайда 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Конвертировать PowerPoint в PDF в виде заметок слайдов**

Этот код на Python показывает, как конвертировать PowerPoint в PDF с заметками:

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Сохраняет презентацию в PDF с заметками
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Стандарты доступности и соблюдения для PDF**

Aspose.Slides позволяет вам использовать процедуру конвертации, которая соответствует [Руководящим принципам доступности веб-контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любые из этих стандартов соблюдения: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код на Python демонстрирует операцию конвертации PowerPoint в PDF, в которой получены несколько PDF-документов на основе различных стандартов соблюдения:

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

{{% alert title="Заметка" color="warning" %}} 

Поддержка Aspose.Slides операций конвертации PDF распространяется на возможность конвертировать PDF в самые популярные форматы файлов. Вы можете выполнить конвертацию [PDF в HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Также поддерживаются другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) и [PDF в XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/).

{{% /alert %}}