---
title: Конвертация презентаций в несколько форматов в .NET
linktitle: Конвертировать презентацию
type: docs
weight: 70
url: /ru/net/convert-presentation/
keywords:
- конвертировать презентацию
- экспортировать презентацию
- PPT в PPTX
- PPTX в PPT
- ODP в PPTX
- PPT в PDF
- PPTX в PDF
- ODP в PDF
- PPT в HTML
- PPTX в HTML
- ODP в HTML
- PPT в PNG
- PPTX в PNG
- ODP в PNG
- PPTX в JPG
- ODP в JPG
- PPT в XPS
- PPTX в XPS
- ODP в XPS
- PPT в TIFF
- PPTX в TIFF
- ODP в TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Конвертировать презентации PowerPoint и OpenDocument в PPTX, PDF, HTML, изображения, XPS, TIFF и другие форматы с помощью Aspose.Slides for .NET."
---
## **Обзор**

Aspose.Slides for .NET может загружать презентации PowerPoint и OpenDocument и сохранять или преобразовывать их в многие другие форматы без Microsoft PowerPoint, OpenOffice или LibreOffice. Вы можете конвертировать устаревшие файлы PPT в современные PPTX, экспортировать презентации в документы фиксированного макета, такие как PDF и XPS, публиковать слайды в виде HTML или рендерить их в файлы изображений для предварительного просмотра, миниатюр и архивов.

Большинство конвертаций документов используют общий рабочий процесс: загрузить исходный файл, выбрать требуемый формат вывода и при необходимости применить параметры, специфичные для формата. Для форматов изображений каждый слайд рендерится отдельно, а затем сохраняется как растровое или векторное изображение. Специальные статьи, указанные ниже, предоставляют детали реализации для каждого случая.

## **Выберите сценарий конвертации**

Используйте статьи ниже для полных примеров на C# и параметров, специфичных для формата.

| Сценарий | Когда использовать | Статья |
| --- | --- | --- |
| PPT/PPTX/ODP в PPTX | Модернизация устаревших файлов PPT, нормализация существующих файлов PPTX или конвертация презентаций OpenDocument в PowerPoint PPTX. | [Convert PPT to PPTX](/slides/ru/net/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/ru/net/convert-odp-to-pptx/),[Save Presentations](/slides/ru/net/save-presentation/) |
| PPTX в PPT | Сохранить современную презентацию PowerPoint в более старый двоичный формат PPT для совместимости со старыми процессами. | [Convert PPTX to PPT](/slides/ru/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP в PDF | Создать портативные, поисковые, фиксированные документы для обмена, печати или архивирования. | [Convert PowerPoint to PDF](/slides/ru/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP в PDF с примечаниями | Экспортировать заметки докладчика вместе с содержимым слайдов. | [Convert PowerPoint to PDF with Notes](/slides/ru/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP в HTML | Публиковать презентации как HTML‑страницы и управлять изображениями, шрифтами, заметками и параметрами адаптивного макета. | [Convert PowerPoint to HTML](/slides/ru/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP в HTML5 | Экспортировать слайды в HTML5 для просмотра в браузере с сохранением форматирования и интерактивности. | [Convert Presentations to HTML5](/slides/ru/net/export-to-html5/) |
| PPT/PPTX/ODP в PNG | Рендерить каждый слайд в PNG‑изображение для предварительного просмотра, миниатюр или веб‑вывода. | [Convert PowerPoint to PNG](/slides/ru/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP в JPG | Рендерить слайды в JPG‑изображения и управлять их размерами и качеством. | [Convert PowerPoint to JPG](/slides/ru/net/convert-powerpoint-to-jpg/) |
| Слайд в SVG | Экспортировать отдельные слайды как масштабируемую векторную графику. | [Render Slide as SVG](/slides/ru/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP в XPS | Создать фиксированные XPS‑документы. | [Convert PowerPoint to XPS](/slides/ru/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP в TIFF | Сохранить презентацию как многостраничный TIFF‑файл для печати, сканирования, факса или архивных процессов. | [Convert PowerPoint to TIFF](/slides/ru/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP в TIFF с примечаниями | Сохранить слайды с заметками докладчика в TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/ru/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX в Word | Конвертировать слайды в документ Word, когда требуется вывод в документальном стиле. | [Convert PowerPoint to Word](/slides/ru/net/convert-powerpoint-to-word/) |
| PPT/PPTX в Markdown | Извлечь содержимое презентации в Markdown для документирования и текстовых процессов. | [Convert PowerPoint to Markdown](/slides/ru/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP в XML | Создать текстовый PowerPoint XML Presentation для инспекции, сравнения, отладки или XML‑ориентированных процессов. | [Convert PowerPoint to XML](/slides/ru/net/convert-powerpoint-to-xml/) |
| PPT/PPTX в анимированный GIF | Создать анимированный GIF из слайдов. | [Convert PowerPoint to Animated GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX в видео | Сформировать процесс экспорта в видео из слайдов презентации. | [Convert PowerPoint to Video](/slides/ru/net/convert-powerpoint-to-video/) |
| Презентация в XAML | Экспортировать слайды в XAML для сценариев UI в .NET. | [Export Presentations to XAML](/slides/ru/net/export-to-xaml/) |

Для более полного списка поддерживаемых входных и выходных форматов см. [Supported File Formats](/slides/ru/net/supported-file-formats/).

## **Конвертация PowerPoint и OpenDocument**

Aspose.Slides for .NET поддерживает конвертацию из широко используемых форматов презентаций, таких как PPT, PPTX, PPS, PPSX, POT, POTX и ODP. Один и тот же API конвертации используется как для файлов PowerPoint, так и для OpenDocument, поэтому рабочий процесс, сохраняющий файл PPTX в PDF, обычно можно применить к файлу ODP, изменив лишь входной файл.

При конвертации ODP‑файлов помните, что приложения PowerPoint и OpenDocument не поддерживают каждую компоновку и форматирование одинаково. Если ODP‑файл был создан в LibreOffice или OpenOffice Impress, проверьте результат и используйте параметры, описанные в [Convert OpenDocument Presentations](/slides/ru/net/convert-openoffice-odp/), когда требуется руководство по конкретному формату.

## **Конвертация PPT в PPTX**

PPT — это старый двоичный формат PowerPoint, тогда как PPTX — современный формат Office Open XML. Aspose.Slides for .NET обеспечивает высокоточная конвертация PPT в PPTX с сохранением сложных структур презентации, таких как мастера, макеты, слайды, диаграммы, группы фигур, заполнители, текстовые кадры, текстуры и заливки изображениями.

Подробности смотрите в [Convert PPT to PPTX](/slides/ru/net/convert-ppt-to-pptx/) и [PPT vs PPTX](/slides/ru/net/ppt-vs-pptx/).

## **Экспорт в фиксированный макет**

PDF, XPS и TIFF полезны, когда вывод должен выглядеть одинаково на всех устройствах и не подлежит редактированию как презентация. Используйте [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/xpsoptions/) и [TiffOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/tiffoptions/) для управления соответствием стандартам, скрытыми слайдами, примечаниями, качеством изображений, сжатием, пиксельным форматом и размером вывода.

## **Экспорт в HTML и изображения**

Экспорт в HTML и HTML5 полезен для просмотра в браузере, публикации в сети и легкого обмена. Экспорт изображений удобен, когда каждый слайд должен стать отдельным предварительным просмотром, миниатюрой или растровым ресурсом. Используйте статьи о PNG, JPG и SVG для получения рекомендаций по рендерингу, специфическим для формата.

## **FAQ**

**Нужен ли мне Microsoft PowerPoint для конвертации презентаций?**

Нет. Aspose.Slides for .NET — это автономная библиотека, не требующая Microsoft PowerPoint или автоматизации Office.

**Можно ли пакетно конвертировать множество презентаций?**

Да. Загружайте каждую презентацию, сохраняйте её в требуемый формат и освобождайте объект `Presentation` после обработки. Для параллельной обработки используйте отдельные экземпляры презентаций и следуйте рекомендациям [multithreading](/slides/ru/net/multithreading/).

**Можно ли экспортировать только выбранные слайды?**

Да. Несколько методов экспорта позволяют передать индексы слайдов или рендерить отдельные слайды, в зависимости от формата вывода. См. специальную статью для нужного формата.

**Можно ли включить скрытые слайды при экспорте в PDF или XPS?**

Да. Используйте свойство `ShowHiddenSlides` в [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) или [XpsOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/xpsoptions/).

**Можно ли создать вывод PDF/A?**

Да. Параметры соответствия PDF доступны через [PdfOptions.Compliance](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/compliance/) и [PdfCompliance](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfcompliance/).

**Как обрабатываются шрифты при конвертации?**

Aspose.Slides может использовать встроенные шрифты, резервные шрифты и настройки подстановки шрифтов. См. [Embedded Font](/slides/ru/net/embedded-font/), [Fallback Font](/slides/ru/net/fallback-font/) и [Font Substitution](/slides/ru/net/font-substitution/).