---
title: Конвертировать PPT и PPTX в PDF на Python | Расширенные параметры
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
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Пошаговое руководство по конвертации PPT, PPTX и ODP в PDF высокого качества, соответствующие требованиям WCAG, на Python с Aspose.Slides — включает защиту паролем, выбор слайдов и контроль качества изображений."
showReadingTime: true
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP) в формат PDF с помощью Python предоставляет несколько преимуществ, включая обеспечение совместимости на разных устройствах и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF на Python, достаточно передать имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и затем сохранить презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python вставляет информацию о своём API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides for Python заполняет поле Application значением «*Aspose.Slides*», а поле PDF Producer – значением в форме «*Aspose.Slides v XX.XX*». **Note** что вы не можете заставить Aspose.Slides for Python изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие содержимого полученных PDF оригинальным презентациям. Элементы и атрибуты рендерятся точно при конвертации, включая:

* Изображения
* Текстовые блоки и формы
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать указанную презентацию в PDF, используя оптимальные настройки с максимальным качеством.

В следующем примере загрузка презентации и сохранение всех видимых слайдов в PDF происходит с использованием параметров экспорта по умолчанию.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}

Aspose предоставляет бесплатный онлайн‑[**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Для живой реализации описанной процедуры вы можете протестировать конвертер.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), позволяющие настроить получаемый PDF, защитить его паролем или задать особенности процесса конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете установить желаемый уровень качества растровых изображений, определить способ обработки метафайлов, задать уровень сжатия текста, разрешение DPI для изображений и т.д.

В следующем примере презентация экспортируется в PDF 1.5 с качеством JPEG, установленным в 90, разрешением изображений 300 DPI, метафайлы сохраняются как PNG, а текст сжимается алгоритмом Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Автоматический выбор сжатия изображений**

Когда презентация содержит множество фотографий или скриншотов, уменьшение размера экспортированного PDF упрощает его отправку по электронной почте и загрузку. Установите [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) в `True`, чтобы автоматически выбирать наиболее подходящий алгоритм сжатия для каждого изображения при экспорте в PDF.

В следующем примере загружается существующая презентация, включается автоматический выбор сжатия изображений и сохраняется как PDF‑документ. Все остальные параметры экспорта PDF сохраняют значения по умолчанию.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Этот параметр выбирает алгоритм сжатия для каждого изображения. Понижение [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) уменьшает качество JPEG‑изображений, а снижение [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) позволяет уменьшать разрешение изображений, что также снижает детализацию. Включение автоматического выбора сжатия само по себе не изменяет ни одного из этих параметров.

Выбор алгоритмов сжатия изображений требует дополнительных ресурсов процессора и памяти. Снижение размера зависит от изображений в презентации и параметров экспорта; фиксированного снижения для каждой презентации гарантировать нельзя.

### **Сохранить вложенные OLE‑файлы как вложения PDF**

Если в презентации есть вложенная книга Excel, вы можете захотеть, чтобы получатели PDF могли также получить доступ к данным книги. Установите [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) в `True`, чтобы сохранять вложенные OLE‑файлы как вложения в получаемом PDF.

Значение по умолчанию — `False`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но вложенный файл не включается как вложение. При установке параметра в `True` дополнительно включаются данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить файл отдельно. OLE‑объект не превращается в интерактивный лист Excel на странице PDF.

В следующем примере загрузка презентации, уже содержащей вложенную книгу Excel, и экспорт её в PDF со вложенной книгой.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Чтобы проверить результат:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** и найдите вложенную книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, или откройте напрямую, если просмотрщик позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}

Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает вложенные файлы, PDF/A‑2 разрешает только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. В этом примере используется значение соответствия PDF по умолчанию и не демонстрируется экспорт в PDF/A.

{{% /alert %}}

### **Конвертировать PowerPoint в PDF с включёнными скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете воспользоваться пользовательским параметром — свойством [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) класса [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), чтобы указать Aspose.Slides включать скрытые слайды как страницы в получаемом PDF.

В следующем примере презентация экспортируется в PDF с включением всех скрытых слайдов.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Конвертировать PowerPoint в PDF с паролем**

В следующем примере презентация экспортируется в PDF, требующий пароль `password` для открытия. Права доступа позволяют печать, включая печать высокого качества.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Обработка шрифтов без отдельного жирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного жирного начертания. Текст всё равно может выглядеть жирным за счёт синтетического утолщения, которое искусственно утолщает обычные глифы. Если такой текст выглядит слишком тяжёлым или иначе отличается от ожидаемого вида в PDF, попробуйте установить [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) в `True`. Этот параметр рендерит затронутый текст как bitmap при экспорте в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `False`.

Примерная презентация содержит два текстовых блока: один с обычным текстом и один с полужирным форматированием того же шрифта, у которого нет отдельного жирного начертания. В следующем примере презентация загружается, включается растеризация неподдерживаемых стилей шрифта и экспортируется в PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Ниже показаны превью вывода без включённого параметра и с включённым параметром. В этом примере при отключённом параметре полужирный текст имеет более тяжёлые штрихи. При включённом параметре штрихи легче; обычный текст остаётся без изменений. Сравните результаты перед тем, как выбрать настройки для своей презентации.

| Опция отключена (`False`, по умолчанию) | Опция включена (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В этом примере включение параметра превращает только полужирный текст в bitmap: его нельзя выделять, копировать или искать как текст без OCR, а его края выглядят более мягкими при увеличении 800 %. Обычный текст остаётся доступным для поиска. При отключённом параметре оба текста остаются текстовыми.

Этот параметр растеризует текст, отформатированный как полужирный, когда у шрифта нет отдельного жирного начертания. [Font substitution](/slides/ru/python-net/font-substitution/) вместо этого выбирает другой шрифт, если оригинал недоступен.

## **Конвертировать выбранные слайды PowerPoint в PDF**

В следующем примере экспортируются слайды 1 и 3 из презентации в PDF. Номера слайдов в массиве начинаются с 1, и входная презентация должна содержать как минимум три слайда.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

В следующем примере первый слайд презентации копируется в новую презентацию с размером слайда 612 × 792 points (8,5 × 11 дюймов). Содержание слайда масштабируется, чтобы поместиться, и экспортируется один единственный слайд в PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Убрать пустой слайд, который был создан в новой презентации.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Конвертировать PowerPoint в PDF в режиме «Заметки к слайду»**

В следующем примере презентация экспортируется в PDF, размещая заметки выступающего под каждым слайдом. Используйте презентацию, содержащую заметки, чтобы увидеть результат.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот Python‑код демонстрирует операцию конвертации PowerPoint в PDF, при которой получаются несколько PDF‑файлов, соответствующих разным стандартам:

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

{{% alert color="info" title="Note" %}}

Поддержка Aspose.Slides для операций конвертации PDF позволяет вам преобразовывать PDF в наиболее популярные форматы файлов. Вы можете выполнить [PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), и [PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) конвертации. Другие операции конвертации PDF в специализированные форматы — [PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), и [PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Note:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигурку. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигурки.

## **FAQ**

**Может ли Aspose.Slides for Python удалить информацию о приложении из PDF?**

Нет, Aspose.Slides for Python автоматически включает информацию об API и номер версии в выходной PDF. Эта информация не может быть изменена или удалена.

**Как включить в конвертацию только определённые слайды?**

Вы можете указать индексы слайдов, которые требуется конвертировать, передав массив позиций слайдов в метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Можно ли защитить PDF паролем во время конвертации?**

Да, вы можете задать пароль и определить разрешения доступа, используя класс [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) перед сохранением презентации в PDF.

**Поддерживает ли Aspose.Slides конвертацию PDF в другие форматы?**

Да, Aspose.Slides поддерживает конвертацию PDF в такие форматы, как HTML, форматы изображений (JPG, PNG), SVG, TIFF и XML.

**Как убедиться, что мой PDF соответствует требованиям доступности?**

Установите свойство [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) в классе [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) в значение `PDF_A1A`, `PDF_A1B` или `PDF_UA`, чтобы обеспечить соответствие рекомендациям по доступности.

**Могу ли я включить скрытые слайды в результирующий PDF?**

Да, установив свойство [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) в классе [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) в `True`, скрытые слайды будут включены в PDF.

**Как настроить качество и разрешение изображений при конвертации?**

Используйте свойства [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) и [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) в классе [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) для управления качеством и разрешением изображений в получаемом PDF.

**Автоматически ли Aspose.Slides обрабатывает замену шрифтов?**

Aspose.Slides обнаруживает замену шрифтов во время конвертации, и вы можете управлять этим с помощью свойства `warning_callback` в `SaveOptions` (в текущий момент ограничено).

## **Дополнительные ресурсы**

- [Aspose.Slides for Python via .NET Documentation](/slides/ru/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)