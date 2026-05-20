---
title: Конвертировать презентации в несколько форматов на JavaScript
linktitle: Конвертировать презентацию
type: docs
weight: 70
url: /ru/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать презентации PowerPoint и OpenDocument в PPTX, PDF, HTML, изображения, XPS, TIFF и другие форматы с помощью Aspose.Slides for Node.js via Java."
---
## **Обзор**

Aspose.Slides for Node.js via Java может загружать презентации PowerPoint и OpenDocument и сохранять или рендерить их во множество других форматов без Microsoft PowerPoint, OpenOffice или LibreOffice. Вы можете конвертировать устаревшие файлы PPT в современные PPTX, экспортировать презентации в документы фиксированного макета, такие как PDF и XPS, публиковать слайды как HTML или рендерить слайды в виде изображений для предварительных просмотров, миниатюр и архивов.

Большинство конвертаций документов используют один и тот же общий рабочий процесс: загрузить исходный файл, выбрать требуемый формат вывода и при необходимости применить параметры, специфичные для формата. Для графических форматов каждый слайд рендерится отдельно, а затем сохраняется как растровое или векторное изображение. Специальные статьи, указанные ниже, предоставляют детали реализации для каждого случая.

## **Выберите сценарий конвертации**

Используйте статьи ниже для полных примеров JavaScript и параметров, специфичных для формата.

| Сценарий | Используйте, когда необходимо | Статья |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Модернизировать устаревшие файлы PPT, нормализовать существующие файлы PPTX или конвертировать презентации OpenDocument в PowerPoint PPTX. | [Convert PPT to PPTX](/slides/ru/nodejs-java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/ru/nodejs-java/convert-odp-to-pptx/), [Save Presentations](/slides/ru/nodejs-java/save-presentation/) |
| PPTX to PPT | Сохранить современную презентацию PowerPoint в старый двоичный формат PPT для совместимости со старыми рабочими процессами. | [Convert PPTX to PPT](/slides/ru/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Создать переносимые, поисковые, документы фиксированного макета для совместного использования, печати или архивирования. | [Convert PowerPoint to PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Экспортировать заметки докладчика вместе с содержимым слайдов. | [Convert PowerPoint to PDF with Notes](/slides/ru/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Публиковать презентации в виде HTML-страниц и управлять изображениями, шрифтами, заметками и параметрами адаптивного макета. | [Convert PowerPoint to HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Экспортировать слайды в HTML5 для просмотра в браузере с сохранением форматирования и интерактивности. | [Convert Presentations to HTML5](/slides/ru/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Отображать каждый слайд в виде изображения PNG для предварительных просмотров, миниатюр или веб-вывода. | [Convert PowerPoint to PNG](/slides/ru/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Отображать слайды в виде изображений JPG и управлять размерами и качеством изображения. | [Convert PowerPoint to JPG](/slides/ru/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Экспортировать отдельные слайды в виде масштабируемой векторной графики. | [Render Slide as SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Создавать документы XPS фиксированного макета. | [Convert PowerPoint to XPS](/slides/ru/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Сохранять презентацию в виде многостраничного файла TIFF для печати, сканирования, факса или архивных процессов. | [Convert PowerPoint to TIFF](/slides/ru/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Сохранять слайды с заметками докладчика в TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/ru/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Извлекать содержимое презентации в Markdown для документации и текстовых рабочих процессов. | [Convert PowerPoint to Markdown](/slides/ru/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Создавать анимированный GIF из слайдов. | [Convert PowerPoint to Animated GIF](/slides/ru/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Создавать процесс экспорта презентации в виде видео. | [Convert PowerPoint to Video](/slides/ru/nodejs-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Экспортировать слайды в XAML для сценариев UI на JavaScript или Java. | [Export Presentations to XAML](/slides/ru/nodejs-java/export-to-xaml/) |

Для более полного списка входных и выходных форматов см. [Поддерживаемые форматы файлов](/slides/ru/nodejs-java/supported-file-formats/).

## **Конвертация PowerPoint и OpenDocument**

Aspose.Slides for Node.js via Java поддерживает конвертацию из часто используемых форматов презентаций, таких как PPT, PPTX, PPS, PPSX, POT, POTX и ODP. Один и тот же API конвертации используется для файлов PowerPoint и OpenDocument, поэтому рабочий процесс, сохраняющий файл PPTX в PDF, обычно можно применить к файлу ODP, изменив только входной файл.

При конвертации ODP‑файлов помните, что приложения PowerPoint и OpenDocument не поддерживают каждый макет и параметр форматирования одинаково. Если ODP‑файл был создан в LibreOffice или OpenOffice Impress, проверьте результат и используйте параметры, описанные в [Конвертация презентаций OpenDocument](/slides/ru/nodejs-java/convert-openoffice-odp/), когда требуется руководство по конкретному формату.

## **Конвертация PPT в PPTX**

PPT — это старый двоичный формат PowerPoint, тогда как PPTX — современный формат Office Open XML. Aspose.Slides for Node.js via Java поддерживает высокоточная конвертацию PPT в PPTX с сохранением сложных структур презентации, таких как мастеры, макеты, слайды, диаграммы, сгруппированные объекты, заполнители, текстовые рамки, текстуры и заливки изображениями.

Для подробностей см. [Convert PPT to PPTX](/slides/ru/nodejs-java/convert-ppt-to-pptx/) и [PPT vs PPTX](/slides/ru/nodejs-java/ppt-vs-pptx/).

## **Экспорт фиксированного макета**

PDF, XPS и TIFF полезны, когда вывод должен выглядеть одинаково на разных устройствах и не должен редактироваться как презентация. Специальные статьи по PDF, XPS и TIFF объясняют, как управлять соответствием, скрытыми слайдами, заметками, качеством изображений, сжатием, форматом пикселей и размером вывода.

## **Экспорт HTML и изображений**

Экспорт в HTML и HTML5 полезен для просмотра в браузере, веб‑публикации и лёгкого обмена. Экспорт изображений полезен, когда каждый слайд должен стать отдельным предварительным просмотром, миниатюрой или растровым ресурсом. Используйте статьи по PNG, JPG и SVG для рекомендаций по рендерингу, специфичным для формата.

## **Часто задаваемые вопросы**

**Нужен ли мне Microsoft PowerPoint для конвертации презентаций?**

Нет. Aspose.Slides for Node.js via Java — это автономная библиотека и не требует Microsoft PowerPoint или автоматизации Office.

**Могу ли я пакетно конвертировать много презентаций?**

Да. Загрузите каждую презентацию, сохраните её в требуемый формат и после обработки освободите объект презентации. Для параллельной обработки используйте отдельные экземпляры презентаций и следуйте рекомендациям по [многопоточность](/slides/ru/nodejs-java/multithreading/).

**Могу ли я экспортировать только выбранные слайды?**

Да. Несколько методов экспорта позволяют передать индексы слайдов или рендерить отдельные слайды, в зависимости от формата вывода. См. специальную статью для выбранного формата.

**Могу ли я включать скрытые слайды при экспорте в PDF или XPS?**

Да. Используйте настройки экспорта скрытых слайдов, описанные в статьях по конвертации [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) и [XPS](/slides/ru/nodejs-java/convert-powerpoint-to-xps/).

**Могу ли я создавать вывод PDF/A?**

Да. Настройки соответствия PDF доступны при экспорте в PDF. Подробнее см. [Convert PowerPoint to PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/).

**Как обрабатываются шрифты при конвертации?**

Aspose.Slides может использовать встроенные шрифты, резервные шрифты и настройки замены шрифтов. См. [Embedded Font](/slides/ru/nodejs-java/embedded-font/), [Fallback Font](/slides/ru/nodejs-java/fallback-font/) и [Font Substitution](/slides/ru/nodejs-java/font-substitution/).