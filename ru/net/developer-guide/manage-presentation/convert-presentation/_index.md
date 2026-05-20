---
title: Конвертация презентаций в различные форматы в .NET
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
description: "Конвертируйте презентации PowerPoint и OpenDocument в PPTX, PDF, HTML, изображения, XPS, TIFF и другие форматы с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET может загружать презентации PowerPoint и OpenDocument и сохранять или выводить их в многие другие форматы без Microsoft PowerPoint, OpenOffice или LibreOffice. Вы можете преобразовать устаревшие файлы PPT в современные PPTX, экспортировать презентации в фиксированные документы, такие как PDF и XPS, публиковать слайды как HTML или рендерить их в виде файлов изображений для превью, миниатюр и архивов.

Большинство конвертаций документов используют один и тот же общий рабочий процесс: загрузить исходный файл, выбрать требуемый формат вывода и при необходимости применить параметры, специфичные для формата. Для форматов изображений каждый слайд рендерится отдельно, а затем сохраняется как растровое или векторное изображение. Специальные статьи, указанные ниже, содержат детали реализации для каждого случая.

## **Выбор сценария конвертации**

Используйте нижеуказанные статьи для полного примера на C# и параметров, специфичных для формата.

| Сценарий | Когда использовать | Статья |
| --- | --- | --- |
| PPT/PPTX/ODP в PPTX | Модернизация устаревших файлов PPT, нормализация существующих файлов PPTX или конвертация презентаций OpenDocument в PowerPoint PPTX. | [Преобразовать PPT в PPTX](/slides/ru/net/convert-ppt-to-pptx/), [Преобразовать ODP в PPTX](/slides/ru/net/convert-odp-to-pptx/), [Сохранить презентации](/slides/ru/net/save-presentation/) |
| PPTX в PPT | Сохранить современную презентацию PowerPoint в старый двоичный формат PPT для совместимости со старыми процессами. | [Преобразовать PPTX в PPT](/slides/ru/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP в PDF | Создать переносимые, индексируемые документы фиксированного макета для обмена, печати или архивирования. | [Преобразовать PowerPoint в PDF](/slides/ru/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP в PDF с заметками | Экспортировать заметки докладчика вместе с содержимым слайдов. | [Преобразовать PowerPoint в PDF с заметками](/slides/ru/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP в HTML | Публиковать презентации как HTML‑страницы и управлять изображениями, шрифтами, заметками и параметрами адаптивного макета. | [Преобразовать PowerPoint в HTML](/slides/ru/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP в HTML5 | Экспортировать слайды в HTML5 для просмотра в браузере с сохранением форматирования и интерактивности. | [Экспортировать презентации в HTML5](/slides/ru/net/export-to-html5/) |
| PPT/PPTX/ODP в PNG | Рендерить каждый слайд в PNG‑изображение для превью, миниатюр или веб‑вывода. | [Преобразовать PowerPoint в PNG](/slides/ru/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP в JPG | Рендерить слайды в JPG‑изображения и управлять их размерами и качеством. | [Преобразовать PowerPoint в JPG](/slides/ru/net/convert-powerpoint-to-jpg/) |
| Слайд в SVG | Экспортировать отдельные слайды как масштабируемую векторную графику. | [Рендерить слайд как SVG](/slides/ru/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP в XPS | Создать документы фиксированного макета XPS. | [Преобразовать PowerPoint в XPS](/slides/ru/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP в TIFF | Сохранить презентацию как многостраничный файл TIFF для печати, сканирования, факса или архивных процессов. | [Преобразовать PowerPoint в TIFF](/slides/ru/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP в TIFF с заметками | Сохранить слайды с заметками докладчика в TIFF. | [Преобразовать PowerPoint в TIFF с заметками](/slides/ru/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX в Word | Преобразовать слайды в документ Word, когда требуется вывод в виде текста. | [Преобразовать PowerPoint в Word](/slides/ru/net/convert-powerpoint-to-word/) |
| PPT/PPTX в Markdown | Извлечь содержимое презентации в Markdown для документации и текстовых процессов. | [Преобразовать PowerPoint в Markdown](/slides/ru/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX в анимированный GIF | Создать анимированный GIF из слайдов. | [Преобразовать PowerPoint в анимированный GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX в видео | Организовать рабочий процесс экспорта презентации в видео. | [Преобразовать PowerPoint в видео](/slides/ru/net/convert-powerpoint-to-video/) |
| Презентация в XAML | Экспортировать слайды в XAML для сценариев UI .NET. | [Экспортировать презентации в XAML](/slides/ru/net/export-to-xaml/) |

Для более широкого списка входных и выходных форматов см. [Поддерживаемые форматы файлов](/slides/ru/net/supported-file-formats/).

## **Конвертация PowerPoint и OpenDocument**

Aspose.Slides for .NET поддерживает конвертацию из часто используемых форматов презентаций, таких как PPT, PPTX, PPS, PPSX, POT, POTX и ODP. Один и тот же API конвертации используется как для файлов PowerPoint, так и для OpenDocument, поэтому рабочий процесс, сохраняющий PPTX в PDF, обычно можно применить к файлу ODP, изменив только входной файл.

При конвертации ODP‑файлов помните, что приложения PowerPoint и OpenDocument не поддерживают каждую компоновку и форматирование одинаково. Если ODP‑файл был создан в LibreOffice или OpenOffice Impress, проверьте результат и используйте параметры, описанные в [Преобразовать OpenDocument презентации](/slides/ru/net/convert-openoffice-odp/), когда требуется руководство по конкретному формату.

## **Конвертация PPT в PPTX**

PPT — старый двоичный формат PowerPoint, в то время как PPTX — современный формат Office Open XML. Aspose.Slides for .NET обеспечивает высокоточное преобразование PPT в PPTX с сохранением сложных структур презентации, таких как шаблоны, макеты, слайды, диаграммы, сгруппированные фигуры, заполнители, текстовые кадры, текстуры и заливка изображениями.

Подробности см. в [Преобразовать PPT в PPTX](/slides/ru/net/convert-ppt-to-pptx/) и [PPT vs PPTX](/slides/ru/net/ppt-vs-pptx/).

## **Экспорт фиксированного макета**

PDF, XPS и TIFF полезны, когда вывод должен выглядеть одинаково на всех устройствах и не подлежит редактированию как презентация. Используйте [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/xpsoptions/) и [TiffOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/tiffoptions/) для управления соответствием стандартам, скрытыми слайдами, заметками, качеством изображений, сжатием, форматом пикселей и размером вывода.

## **Экспорт HTML и изображений**

Экспорт в HTML и HTML5 полезен для просмотра в браузере, веб‑публикаций и лёгкого обмена. Экспорт изображений пригоден, когда каждый слайд должен стать отдельным превью, миниатюрой или растровым ресурсом. Используйте статьи о PNG, JPG и SVG для получения рекомендаций по рендерингу, специфичному для формата.

## **Часто задаваемые вопросы**

**Нужен ли Microsoft PowerPoint для конвертации презентаций?**

Нет. Aspose.Slides for .NET — автономная библиотека и не требует Microsoft PowerPoint или автоматизации Office.

**Можно ли пакетно конвертировать множество презентаций?**

Да. Загружайте каждую презентацию, сохраняйте её в требуемый формат и освобождайте объект `Presentation` после обработки. Для параллельной обработки используйте отдельные экземпляры презентаций и следуйте рекомендациям по [multithreading](/slides/ru/net/multithreading/).

**Можно ли экспортировать только выбранные слайды?**

Да. Несколько методов экспорта позволяют передать индексы слайдов или рендерить отдельные слайды, в зависимости от формата вывода. См. соответствующую статью для нужного формата.

**Можно ли включить скрытые слайды при экспорте в PDF или XPS?**

Да. Используйте свойство `ShowHiddenSlides` в [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) или [XpsOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/xpsoptions/).

**Можно ли создать PDF/A?**

Да. Параметры соответствия PDF доступны через [PdfOptions.Compliance](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/compliance/) и [PdfCompliance](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfcompliance/).

**Как обрабатываются шрифты при конвертации?**

Aspose.Slides может использовать встроенные шрифты, резервные шрифты и настройки подстановки шрифтов. См. [Embedded Font](/slides/ru/net/embedded-font/), [Fallback Font](/slides/ru/net/fallback-font/) и [Font Substitution](/slides/ru/net/font-substitution/).