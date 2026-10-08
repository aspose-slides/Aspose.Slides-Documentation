---
title: Конвертация PPT и PPTX в PDF с помощью Python | Расширенные параметры
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
description: "Пошаговое руководство по конвертации PPT, PPTX и ODP в PDF высокого качества, соответствующие требованиям WCAG, с использованием Python и Aspose.Slides — включает защиту паролем, выбор слайдов и контроль качества изображений."
showReadingTime: true
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP) в формат PDF с помощью Python предоставляет несколько преимуществ, включая обеспечение совместимости на различных устройствах и сохранение макета и оформления вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять требования соответствия к результирующим документам.

## **Конверсия PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в этих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF в Python, достаточно передать имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и затем сохранить презентацию в PDF с помощью метода [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python вставляет информацию о своем API и номер версии в выходные документы. Например, когда он конвертирует презентацию в PDF, Aspose.Slides for Python заполняет поле Application значением '*Aspose.Slides*', а поле PDF Producer значением в виде '*Aspose.Slides v XX.XX*'. **Примечание** что вы не можете указать Aspose.Slides for Python изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Конкретные слайды в презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что содержимое полученных PDF-файлов максимально соответствует оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркированные списки
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки на максимальном уровне качества.

Следующий пример загружает презентацию и сохраняет все видимые слайды в PDF, используя параметры экспорта по умолчанию.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose предоставляет бесплатный онлайн [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Для живой реализации описанной здесь процедуры вы можете выполнить тест с конвертером.
{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), которые позволяют настроить PDF (полученный в результате процесса конвертации), защитить PDF паролем или даже задать порядок выполнения процесса конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, задать DPI для изображений и т.д.

Следующий пример экспортирует презентацию в PDF 1.5 с установкой качества JPEG в 90, разрешения изображения в 300 DPI, метафайлы сохраняются как PNG и применяется сжатие текста Flate.

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

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF могли получать доступ к данным книги, а также просматривать слайды. Установите [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) в `True`, чтобы сохранить встроенные OLE‑файлы как вложения в получаемом PDF.

Значение по умолчанию — `False`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но встроенный файл не включается как вложение. Установка параметра в `True` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивной таблицей Excel на странице PDF.

Следующий пример загружает презентацию, уже содержащую встроенную книгу Excel, и экспортирует её в PDF с вложенной книгой.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Для проверки результата:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** просмотрщика и найдите встроенную книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, либо откройте напрямую, если просмотрщик это позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A-1 запрещает встроенные файлы, PDF/A-2 допускает только вложения PDF/A, а PDF/A-3 допускает другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. Этот пример использует параметр соответствия PDF по умолчанию и не демонстрирует экспорт в PDF/A.
{{% /alert %}}

### **Конвертировать PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать пользовательский параметр — свойство [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) класса [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), чтобы указать Aspose.Slides включить скрытые слайды как страницы в получаемом PDF.

Следующий пример экспортирует презентацию в PDF, включая все скрытые слайды.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Конвертировать PowerPoint в защищённый паролем PDF**

Следующий пример экспортирует презентацию в PDF, который требует пароль `password` для открытия. Разрешения доступа позволяют печать, включая печать высокого качества.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Обрабатывать шрифты без отдельного полужирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного полужирного начертания. Текст всё равно может выглядеть полужирным за счёт синтетического усиления, которое искусственно утолщает обычные глифы. Если такой текст выглядит слишком тяжёлым или иначе отличается от желаемого отображения в PDF, попробуйте установить [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) в `True`. Эта опция рендерит затронутый текст как bitmap при экспорте в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `False`.

Пример презентации содержит два текстовых блока: один с обычным текстом и один с полужирным форматированием того же шрифта, у которого нет отдельного полужирного начертания. Следующий пример загружает презентацию, включаеt растеризацию неподдерживаемых стилей шрифтов и экспортирует её в PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Ниже показаны превью вывода с отключённой и включённой опцией. В этом примере полужирный текст имеет более тяжёлые штрихи при отключённой опции. При включённой опции его штрихи становятся тоньше; обычный текст остаётся без изменений. Сравните результаты перед выбором настройки для вашей презентации.

| Опция отключена (`False`, по умолчанию) | Опция включена (`True`) |
|---|---|
| ![PDF с растеризацией неподдерживаемого стиля шрифта отключена](unsupported-bold-disabled.png) | ![PDF с растеризацией неподдерживаемого стиля шрифта включена](unsupported-bold-enabled.png) |

В этом примере включение опции преобразует только полужирный текст в bitmap: его нельзя выделять, копировать или искать как текст без OCR, и его края выглядят мягче при увеличении 800 %. Обычный текст остаётся доступным для поиска. При отключённой опции обе строки остаются текстом.

Эта опция растеризует текст, отформатированный как полужирный, когда у шрифта нет отдельного полужирного начертания. [Замена шрифтов](/slides/ru/python-net/font-substitution/) вместо этого выбирает другой шрифт, если оригинальный недоступен.

## **Конвертировать выбранные слайды PowerPoint в PDF**

Следующий пример экспортирует слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве начинаются с единицы, и входная презентация должна содержать как минимум три слайда.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Следующий пример копирует первый слайд из презентации в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Он масштабирует содержимое слайда, чтобы оно помещалось, и экспортирует единственный слайд в PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Удалить пустой слайд, с которым была создана новая презентация.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Конвертировать PowerPoint в PDF в режиме заметок к слайдам**

Следующий пример экспортирует презентацию в PDF, размещая заметки докладчика каждого слайда под самим слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любые из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

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
Поддержка Aspose.Slides операций конвертации PDF позволяет конвертировать PDF в самые популярные форматы файлов. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **FAQ**

**Может ли Aspose.Slides for Python удалить информацию о приложении из PDF?**

Нет, Aspose.Slides for Python автоматически включает информацию об API и номер версии в выходной PDF. Эта информация не может быть изменена или удалена.

**Как включить только определённые слайды в конвертацию PDF?**

Вы можете указать индексы слайдов, которые хотите конвертировать, передав массив позиций слайдов в метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Можно ли защитить PDF паролем во время конвертации?**

Да, вы можете задать пароль и определить разрешения доступа, используя класс [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) перед сохранением презентации в PDF.

**Поддерживает ли Aspose.Slides конвертацию PDF в другие форматы?**

Да, Aspose.Slides поддерживает конвертацию PDF в такие форматы, как HTML, форматы изображений (JPG, PNG), SVG, TIFF и XML.

**Как убедиться, что мой PDF соответствует стандартам доступности?**

Установите свойство [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) в классе [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) в значения, такие как `PDF_A1A`, `PDF_A1B` или `PDF_UA`, чтобы обеспечить соответствие рекомендациям по доступности.

**Могу ли я включить скрытые слайды в вывод PDF?**

Да, установив свойство [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) в классе [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) в `True`, скрытые слайды будут включены в PDF.

**Как настроить качество и разрешение изображений при конвертации?**

Используйте свойства [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) и [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) в классе [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) для управления качеством и разрешением изображений в получаемом PDF.

**Обрабатывает ли Aspose.Slides замену шрифтов автоматически?**

Aspose.Slides обнаруживает замену шрифтов во время конвертации, и вы можете обрабатывать их, используя свойство `warning_callback` в `SaveOptions` (в текущей реализации ограничено).

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для Python через .NET](/slides/ru/python-net/)
- [Справочник API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)