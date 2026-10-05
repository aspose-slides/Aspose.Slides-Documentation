---
title: Преобразование PPT & PPTX в PDF на Python | Расширенные параметры
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
description: "Пошаговое руководство по преобразованию PPT, PPTX и ODP в высококачественные PDF, соответствующие WCAG, на Python с Aspose.Slides — включает защиту паролем, выбор слайдов и контроль качества изображений."
showReadingTime: true
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP) в формат PDF в Python предоставляет несколько преимуществ, включая обеспечение совместимости на разных устройствах и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как преобразовать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Преобразование PowerPoint в PDF**

С помощью Aspose.Slides вы можете преобразовать презентации этих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF в Python, достаточно передать имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и затем сохранить презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) раскрывает метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python вставляет информацию о своём API и номер версии в выходные документы. Например, при преобразовании презентации в PDF Aspose.Slides for Python заполняет поле Application значением '*Aspose.Slides*', а поле PDF Producer значением в формате '*Aspose.Slides v XX.XX*'. **Примечание** что вы не можете указать Aspose.Slides for Python изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам преобразовать:

* Полные презентации в PDF
* Определённые слайды презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что содержимое полученных PDF почти полностью соответствует оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые блоки и формы
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Преобразовать PowerPoint в PDF**

Стандартный процесс преобразования PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки при максимальном уровне качества.

Следующий пример загружает презентацию и сохраняет все видимые слайды в PDF, используя настройки экспорта по умолчанию.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose предоставляет бесплатный онлайн [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Для живой реализации описанной здесь процедуры вы можете выполнить тест с этим конвертером.
{{% /alert %}}

## **Преобразовать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), которые позволяют настроить PDF (полученный в результате процесса конвертации), защитить PDF паролем или даже задать, как должен проходить процесс конвертации.

### **Преобразовать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочитаемую настройку качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, задать DPI для изображений и т.д.

Следующий пример экспортирует презентацию в PDF 1.5 с качеством JPEG, установленным в 90, разрешением изображения 300 DPI, метафайлы сохраняются как PNG, и применяется сжатие текста Flate.

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

### **Сохранить вложенные OLE‑файлы как вложения PDF**

Если в презентации есть встроенная рабочая книга Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным книги, а также просматривать слайды. Установите [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) в `True`, чтобы сохранить вложенные OLE‑файлы как вложения в результирующем PDF.

Значение по умолчанию — `False`: превью‑изображение или значок объекта OLE отображается на странице PDF, но его вложенный файл не включается как вложение. Установка параметра в `True` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить вложенный файл отдельно. Объект OLE не становится интерактивной таблицей Excel на странице PDF.

Следующий пример загружает презентацию, уже содержащую встроенную рабочую книгу Excel, и экспортирует её в PDF с прикреплённой книгой.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Чтобы проверить результат:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Вложения** просмотрщика и найдите встроенную рабочую книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, либо откройте напрямую, если просмотрщик это позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает вложенные файлы, PDF/A‑2 допускает только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая рабочие книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. Этот пример использует параметр соответствия PDF по умолчанию и не демонстрирует экспорт PDF/A.
{{% /alert %}}

### **Преобразовать PowerPoint в PDF со скрытыми слайдами**

Если в презентации есть скрытые слайды, вы можете использовать пользовательский параметр — свойство [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) класса [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), чтобы указать Aspose.Slides включать скрытые слайды как страницы в получаемом PDF.

Следующий пример экспортирует презентацию в PDF, включая любые скрытые слайды.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Преобразовать PowerPoint в защищённый паролем PDF**

Следующий пример экспортирует презентацию в PDF, требующий пароль `password` для открытия. Права доступа позволяют печатать, включая печать высокого качества.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Преобразовать выбранные слайды PowerPoint в PDF**

Следующий пример экспортирует слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве начинаются с единицы, и входная презентация должна содержать как минимум три слайда.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Преобразовать PowerPoint в PDF с пользовательским размером слайда**

Следующий пример копирует первый слайд из презентации в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Он масштабирует содержимое слайда для соответствия и экспортирует один слайд в PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Удалить пустой слайд, который был создан в новой презентации.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Преобразовать PowerPoint в PDF в режиме заметок к слайдам**

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

Aspose.Slides позволяет использовать процедуру преобразования, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

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
Поддержка Aspose.Slides для операций преобразования PDF позволяет конвертировать PDF в самые популярные форматы файлов. Вы можете выполнить [PDF в HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) конверсии. Другие операции преобразования PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть отмечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **Вопросы и ответы**

**Может ли Aspose.Slides for Python удалить информацию о приложении из PDF?**

Нет, Aspose.Slides for Python автоматически включает информацию об API и номер версии в выходной PDF. Эта информация не может быть изменена или удалена.

**Как включить только определённые слайды в конвертацию PDF?**

Вы можете указать индексы слайдов, которые хотите конвертировать, передав массив позиций слайдов в метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Можно ли защитить PDF паролем во время конвертации?**

Да, вы можете установить пароль и определить права доступа, используя класс [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) перед сохранением презентации как PDF.

**Поддерживает ли Aspose.Slides конвертацию PDF в другие форматы?**

Да, Aspose.Slides поддерживает конвертацию PDF в такие форматы, как HTML, форматы изображений (JPG, PNG), SVG, TIFF и XML.

**Как гарантировать соответствие моего PDF стандартам доступности?**

Установите свойство [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) в классе [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) в значение `PDF_A1A`, `PDF_A1B` или `PDF_UA`, чтобы обеспечить соответствие рекомендациям по доступности.

**Можно ли включить скрытые слайды в итоговый PDF?**

Да, установив свойство [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) в классе [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) в `True`, скрытые слайды будут включены в PDF.

**Как настроить качество и разрешение изображений при конвертации?**

Используйте свойства [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) и [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) в классе [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) для управления качеством и разрешением изображений в получаемом PDF.

**Автоматически ли Aspose.Slides обрабатывает замену шрифтов?**

Aspose.Slides обнаруживает замену шрифтов во время конвертации, и вы можете обработать её с помощью свойства `warning_callback` в `SaveOptions` (в настоящее время ограничено).

## **Дополнительные ресурсы**

- [Aspose.Slides for Python via .NET Documentation](/slides/ru/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)