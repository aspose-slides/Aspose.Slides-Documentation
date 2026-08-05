---
title: Конвертация PPT и PPTX в PDF в Python | Расширенные параметры
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
description: "Пошаговое руководство по конвертации PPT, PPTX и ODP в PDF высокого качества с соблюдением требований WCAG на Python с Aspose.Slides — включает защиту паролем, выбор слайдов и контроль качества изображений."
showReadingTime: true
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP) в формат PDF в Python предоставляет несколько преимуществ, включая обеспечение совместимости на разных устройствах и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конверсии и применять стандарты соответствия к итоговым документам.

## **Конвертация PowerPoint в PDF**

Используя Aspose.Slides, вы можете конвертировать презентации в этих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF в Python, достаточно передать имя файла в качестве аргумента в классе [Presentation](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/) и затем сохранить презентацию как PDF, используя метод [Save](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides/presentation/#methods). Класс [Presentation] предоставляет метод [Save], который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python напрямую записывает информацию об API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides for Python заполняет поле Application значением '*Aspose.Slides*', а поле PDF Producer — значением в формате '*Aspose.Slides v XX.XX*'. **Примечание**: вы не можете заставить Aspose.Slides for Python изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Определённые слайды в презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая, что содержимое полученных PDF‑файлов максимально соответствует оригинальным презентациям. Элементы и атрибуты отображаются точно при конверсии, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Марки
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартная операция конвертации PowerPoint в PDF выполняется с использованием параметров по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки на максимальном уровне качества. Этот код на Python показывает, как конвертировать PowerPoint в PDF:

_Шаги: Конвертация PowerPoint в PDF в Python_

Следующий пример кода объясняет эти конверсии с использованием Python через .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Шаги: Конвертировать PowerPoint в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Шаги: Конвертировать PPT в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Шаги: Конвертировать PPTX в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертировать ODP в PDF с помощью Python через .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Шаги: Конвертировать PPS в PDF с помощью Python через .NET</a></strong>

_Шаги кода:_

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и передайте ему файл PowerPoint.
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

Aspose предоставляет бесплатный онлайн‑конвертер [**PowerPoint в PDF**](https://products.aspose.app/slides/ru/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Для практической реализации описанной здесь процедуры вы можете протестировать конвертер.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides.export/pdfoptions/), которые позволяют настроить PDF (полученный в результате конверсии), защитить PDF паролем или даже задать способ выполнения процесса конверсии.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конверсии вы можете задать предпочтительные настройки качества растровых изображений, указать способ обработки метафайлов, установить уровень сжатия текста, задать DPI для изображений и т.д.

Ниже приведён пример кода, демонстрирующий операцию, в которой презентация PowerPoint конвертируется в PDF с несколькими пользовательскими параметрами:

```python
import aspose.slides as slides

# Создаёт экземпляр класса PdfOptions
pdf_options = slides.export.PdfOptions()

# Устанавливает качество JPG‑изображений
pdf_options.jpeg_quality = 90

# Устанавливает DPI для изображений
pdf_options.sufficient_resolution = 300

# Устанавливает поведение метафайлов
pdf_options.save_metafiles_as_png = True

# Устанавливает уровень сжатия текста для текстового содержимого
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Определяет режим соответствия PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Создаёт экземпляр класса Presentation, представляющего документ PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Сохраняет презентацию в виде PDF‑документа
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Конвертировать PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать пользовательскую опцию — свойство `show_hidden_slides` класса [PdfOptions](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides.export/pdfoptions/), чтобы указать Aspose.Slides включить скрытые слайды в виде страниц в результирующий PDF.

Этот код на Python показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

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

### **Конвертировать PowerPoint в защищённый паролем PDF**

Этот код на Python показывает, как конвертировать PowerPoint в PDF, защищённый паролем (используя параметры защиты из класса [PdfOptions](https://docs.aspose.com/slides/ru/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Создаёт объект Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Создаёт экземпляр класса PdfOptions
pdfOptions = slides.export.PdfOptions()

# Устанавливает пароль PDF и разрешения доступа
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Сохраняет презентацию в PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Конвертировать выбранные слайды PowerPoint в PDF**

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

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот код на Python показывает, как конвертировать PowerPoint с указанным размером слайда в PDF:

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

## **Конвертировать PowerPoint в PDF в режиме заметок слайдов**

Этот код на Python показывает, как конвертировать PowerPoint в PDF‑заметки:

```python
import aspose.slides as slides

# Создаёт объект класса Presentation, представляющий файл PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Сохраняет презентацию в PDF-заметки
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конверсии, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код на Python демонстрирует операцию конвертации PowerPoint в PDF, в которой получаются несколько PDF‑файлов на основе разных стандартов соответствия:

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

Aspose предоставляет возможность конвертировать PDF в самые популярные форматы файлов. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/ru/python-net/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть отмечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **Часто задаваемые вопросы**

**Может ли Aspose.Slides for Python удалить информацию о приложении из PDF?**

Нет, Aspose.Slides for Python автоматически включает информацию об API и номер версии в выходной PDF. Эта информация не может быть изменена или удалена.

**Как включить только определённые слайды в конверсию PDF?**

Вы можете указать индексы слайдов, которые хотите конвертировать, передав массив позиций слайдов в метод `save`.

**Можно ли защитить PDF паролем во время конверсии?**

Да, вы можете установить пароль и определить права доступа, используя класс `PdfOptions` перед сохранением презентации в PDF.

**Поддерживает ли Aspose.Slides конвертацию PDF в другие форматы?**

Да, Aspose.Slides поддерживает конвертацию PDF в такие форматы, как HTML, форматы изображений (JPG, PNG), SVG, TIFF и XML.

**Как обеспечить соответствие моего PDF стандартам доступности?**

Установите свойство `compliance` в `PdfOptions` в значения `PDF_A1A`, `PDF_A1B` или `PDF_UA`, чтобы обеспечить соответствие рекомендациям по доступности.

**Можно ли включить скрытые слайды в PDF‑вывод?**

Да, установив свойство `show_hidden_slides` в `PdfOptions` в `True`, скрытые слайды будут включены в PDF.

**Как настроить качество и разрешение изображений во время конверсии?**

Используйте свойства `jpeg_quality` и `sufficient_resolution` в `PdfOptions` для управления качеством и разрешением изображений в результирующем PDF.

**Aspose.Slides автоматически обрабатывает замену шрифтов?**

Aspose.Slides автоматически обнаруживает замену шрифтов во время конверсии, и вы можете обработать их, используя свойство `warning_callback` в `SaveOptions` (в данный момент ограничено).

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для .NET](https://docs.aspose.com/slides/ru/python-net/)
- [Справочник API Aspose.Slides](https://reference.aspose.com/slides/ru/python-net/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/ru/conversion)