---
title: Конвертация PPT и PPTX в PDF на Python | Расширенные параметры
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
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
description: "Пошаговое руководство по конвертации PPT, PPTX и ODP в PDF высокого качества, соответствующего WCAG, на Python с Aspose.Slides — включает защиту паролем, выбор слайдов и контроль качества изображений."
showReadingTime: true
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP) в формат PDF с помощью Python дает несколько преимуществ, включая обеспечение совместимости на разных устройствах и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как преобразовать презентации в PDF‑документы, использовать различные параметры управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Установка**

```bash
pip install aspose.slides
```

Пакет содержит необходимую среду выполнения, поэтому Microsoft PowerPoint не требуется устанавливать на машине, выполняющей конвертацию.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF в Python, достаточно передать имя файла в качестве аргумента класса [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/) и затем сохранить презентацию как PDF, используя метод [Save](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/#methods). Класс [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/) предоставляет метод [Save](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/#methods), который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python напрямую записывает информацию об API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides for Python заполняет поле Application значением '*Aspose.Slides*', а поле PDF Producer — значением вида '*Aspose.Slides v XX.XX*'. **Note** что вы не можете заставить Aspose.Slides for Python изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам:

* Конвертировать целые презентации в PDF
* Конвертировать отдельные слайды презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально точное соответствие содержимого полученных PDF оригинальным презентациям. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартная операция конвертации PowerPoint в PDF выполняется с использованием параметров по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки при максимальном качестве. Ниже приведён пример кода на Python, показывающий, как конвертировать PowerPoint в PDF:

_Шаги: Конвертация PowerPoint в PDF в Python_

Следующий пример кода объясняет эти конвертации с использованием Python через .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Шаги: Конвертировать PowerPoint в PDF с помощью Python через .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Шаги: Конвертировать PPT в PDF с помощью Python через .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Шаги: Конвертировать PPTX в PDF с помощью Python через .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертировать ODP в PDF с помощью Python через .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертировать PPS в PDF с помощью Python через .NET</strong></a>

_Шаги кода:_

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и передайте ему файл PowerPoint.
  * _.ppt_ расширение для загрузки **PPT** файла в класс _Presentation_.
  * _.pptx_ расширение для загрузки **PPTX** файла в класс _Presentation_.
  * _.odp_ расширение для загрузки **ODP** файла в класс _Presentation_.
  * _.pps_ расширение для загрузки **PPS** файла в класс _Presentation_.
- Сохраните _Presentation_ в формат **PDF**, вызвав метод **Save** и указав перечисление **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющего файл PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Сохраняет презентацию в формате PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн‑конвертер **PowerPoint в PDF** https://products.aspose.app/slides/ru/conversion/ppt-to-pdf, демонстрирующий процесс преобразования презентации в PDF. Для практической проверки описанной процедуры вы можете выполнить тест с этим конвертером.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides.export/pdfoptions/) — которые позволяют настроить результирующий PDF, защитить PDF паролем или задать ход процесса конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растрированных изображений, определить способ обработки метафайлов, установить уровень сжатия текста, задать DPI для изображений и т.д.

Ниже пример кода, демонстрирующий преобразование презентации PowerPoint в PDF с несколькими пользовательскими параметрами:

```python
import aspose.slides as slides

# Создает экземпляр класса PdfOptions
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

# Создает экземпляр класса Presentation, представляющего документ PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Сохраняет презентацию в виде PDF‑документа
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Конвертация PowerPoint в PDF с скрытыми слайдами**

Если в презентации есть скрытые слайды, вы можете использовать пользовательский параметр — свойство `show_hidden_slides` из класса [PdfOptions](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides.export/pdfoptions/) — чтобы указать Aspose.Slides включать скрытые слайды как страницы в результирующий PDF.

Этот пример кода на Python показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющего файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Создает экземпляр класса PdfOptions
pdfOptions = slides.export.PdfOptions()

# Добавляет скрытые слайды
pdfOptions.show_hidden_slides = True

# Сохраняет презентацию в PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Конвертация PowerPoint в защищённый паролем PDF**

Этот пример кода на Python демонстрирует, как преобразовать PowerPoint в PDF, защищённый паролем (используя параметры защиты из класса [PdfOptions](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Создает объект Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Создает экземпляр класса PdfOptions
pdfOptions = slides.export.PdfOptions()

# Устанавливает пароль PDF и разрешения доступа
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Сохраняет презентацию в PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот пример кода на Python показывает, как конвертировать отдельные слайды презентации PowerPoint в PDF:

```python
import aspose.slides as slides

# Создает объект Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Задаёт массив позиций слайдов
slides_array = [ 1, 3 ]

# Сохраняет презентацию в PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот пример кода на Python показывает, как конвертировать PowerPoint, когда для него указан пользовательский размер слайда, в PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Создает экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Создает новую презентацию с изменённым размером слайда.
    with slides.Presentation() as resized_presentation:

        # Устанавливает пользовательский размер слайда.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Клонирует первый слайд из оригинальной презентации и удаляет пустой слайд по умолчанию.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Сохраняет изменённую презентацию в PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Конвертация PowerPoint в PDF в режиме заметок слайда**

Этот пример кода на Python показывает, как конвертировать PowerPoint в PDF‑заметки:

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющего файл PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# Настраивает параметры PDF с макетом заметок
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Сохраняет презентацию в PDF с заметками
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот пример кода на Python демонстрирует операцию конвертации PowerPoint в PDF, при которой получаются несколько PDF‑файлов, каждый из которых соответствует разному стандарту соответствия:

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

Поддержка Aspose.Slides для операций конвертации PDF также распространяется на возможность преобразования PDF в наиболее популярные форматы файлов. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Note:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как одну фигурку. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигурки.

## **FAQ**

### Может ли Aspose.Slides for Python удалить информацию о приложении из PDF?

Нет, Aspose.Slides for Python автоматически добавляет информацию об API и номер версии в выходной PDF. Эта информация не подлежит изменению или удалению.

### Как включить в конвертацию только определённые слайды?

Вы можете указать индексы слайдов, которые нужно конвертировать, передав массив позиций слайдов в метод `save`.

### Можно ли защитить PDF паролем во время конвертации?

Да, перед сохранением презентации в PDF вы можете задать пароль и определить права доступа, используя класс `PdfOptions`.

### Поддерживает ли Aspose.Slides конвертацию PDF в другие форматы?

Да, Aspose.Slides поддерживает конвертацию PDF в такие форматы, как HTML, изображений (JPG, PNG), SVG, TIFF и XML.

### Как убедиться, что мой PDF соответствует стандартам доступности?

Установите свойство `compliance` в `PdfOptions` в значение `PDF_A1A`, `PDF_A1B` или `PDF_UA` для обеспечения соответствия требованиям доступности.

### Можно ли включить скрытые слайды в итоговый PDF?

Да, установив свойство `show_hidden_slides` в `PdfOptions` в `True`, скрытые слайды будут включены в PDF.

### Как настроить качество и разрешение изображений при конвертации?

Используйте свойства `jpeg_quality` и `sufficient_resolution` в `PdfOptions` для управления качеством и разрешением изображений в полученном PDF.

### Автоматически ли Aspose.Slides обрабатывает замену шрифтов?

Aspose.Slides обнаруживает замену шрифтов во время конвертации, и вы можете обработать их, используя свойство `warning_callback` в `SaveOptions` (в текущей версии ограничено).