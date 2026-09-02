---
title: Конвертация презентаций в несколько форматов на JavaScript
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

Aspose.Slides for Node.js via Java может загружать презентации PowerPoint и OpenDocument и сохранять или рендерить их во многие другие форматы без Microsoft PowerPoint, OpenOffice или LibreOffice. Вы можете конвертировать устаревшие файлы PPT в современные PPTX, экспортировать презентации в документы фиксированного макета, такие как PDF и XPS, публиковать слайды как HTML или рендерить слайды в виде файлов изображений для превью, миниатюр и архивов.

Большинство конвертаций документов используют один и тот же общий рабочий процесс: загрузить исходный файл, выбрать требуемый формат вывода и при необходимости применить параметры, специфичные для формата. Для форматов изображений каждый слайд рендерится отдельно, а затем сохраняется как растровое или векторное изображение. Ниже приведённые специализированные статьи содержат подробности реализации для каждого случая.

## **Выберите сценарий конвертации**

Используйте статьи ниже для полных примеров JavaScript и параметров, специфичных для форматов.

| Сценарий | Когда использовать | Статья |
| --- | --- | --- |
| PPT/PPTX/ODP в PPTX | Модернизация устаревших файлов PPT, нормализация существующих файлов PPTX или конвертация презентаций OpenDocument в PowerPoint PPTX. | [Конвертировать PPT в PPTX](/slides/ru/nodejs-java/convert-ppt-to-pptx/), [Конвертировать ODP в PPTX](/slides/ru/nodejs-java/convert-odp-to-pptx/), [Сохранить презентации](/slides/ru/nodejs-java/save-presentation/) |
| PPTX в PPT | Сохранить современную презентацию PowerPoint в старый бинарный формат PPT для совместимости со старыми рабочими процессами. | [Конвертировать PPTX в PPT](/slides/ru/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP в PDF | Создать переносимые, индексируемые документы фиксированного макета для обмена, печати или архивирования. | [Конвертировать PowerPoint в PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP в PDF с заметками | Экспортировать примечания выступающего вместе с содержимым слайдов. | [Конвертировать PowerPoint в PDF с заметками](/slides/ru/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP в HTML | Публиковать презентации как HTML-страницы и управлять изображениями, шрифтами, заметками и параметрами адаптивного макета. | [Конвертировать PowerPoint в HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP в HTML5 | Экспортировать слайды в HTML5 для просмотра в браузере с сохранением форматирования и интерактивности. | [Конвертировать презентации в HTML5](/slides/ru/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP в PNG | Рендерировать каждый слайд в PNG‑изображение для превью, миниатюр или веб‑вывода. | [Конвертировать PowerPoint в PNG](/slides/ru/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP в JPG | Рендерировать слайды в JPG‑изображения и управлять размерами и качеством изображений. | [Конвертировать PowerPoint в JPG](/slides/ru/nodejs-java/convert-powerpoint-to-jpg/) |
| Слайд в SVG | Экспортировать отдельные слайды как масштабируемую векторную графику. | [Рендерить слайд как SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP в XPS | Создавать документы XPS фиксированного макета. | [Конвертировать PowerPoint в XPS](/slides/ru/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP в TIFF | Сохранить презентацию как многостраничный TIFF‑файл для печати, сканирования, факса или архивных процессов. | [Конвертировать PowerPoint в TIFF](/slides/ru/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP в TIFF с заметками | Сохранить слайды с заметками выступающего в TIFF. | [Конвертировать PowerPoint в TIFF с заметками](/slides/ru/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX в Markdown | Извлечь содержимое презентации в Markdown для документации и текстовых рабочих процессов. | [Конвертировать PowerPoint в Markdown](/slides/ru/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP в XML | Создать текстовую PowerPoint XML‑презентацию для проверки, сравнения, устранения неполадок или XML‑ориентированных рабочих процессов. | [Конвертировать PowerPoint в XML](/slides/ru/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX в анимированный GIF | Создать анимированный GIF из слайдов. | [Конвертировать PowerPoint в анимированный GIF](/slides/ru/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX в видео | Создать процесс экспорта в видео из слайдов презентации. | [Конвертировать PowerPoint в видео](/slides/ru/nodejs-java/convert-powerpoint-to-video/) |
| Презентация в XAML | Экспортировать слайды в XAML для сценариев UI на JavaScript или Java. | [Экспортировать презентации в XAML](/slides/ru/nodejs-java/export-to-xaml/) |

Для более полного списка входных и выходных форматов см. [Поддерживаемые форматы файлов](/slides/ru/nodejs-java/supported-file-formats/).

## **Конвертация PowerPoint и OpenDocument**

Aspose.Slides for Node.js via Java поддерживает конвертацию из часто используемых форматов презентаций, таких как PPT, PPTX, PPS, PPSX, POT, POTX и ODP. Один и тот же API конвертации используется для файлов PowerPoint и OpenDocument, поэтому рабочий процесс, сохраняющий файл PPTX в PDF, обычно можно применить к файлу ODP, изменив только входной файл.

При конвертации файлов ODP помните, что приложения PowerPoint и OpenDocument не поддерживают каждый элемент макета и форматирования одинаково. Если ODP‑файл был создан в LibreOffice или OpenOffice Impress, проверьте полученный результат и используйте параметры, описанные в статье [Конвертировать OpenDocument презентации](/slides/ru/nodejs-java/convert-openoffice-odp/), когда требуется руководство, специфичное для формата.

## **Конвертация PPT в PPTX**

PPT — это старый бинарный формат PowerPoint, а PPTX — современный формат Office Open XML. Aspose.Slides for Node.js via Java поддерживает высокоточное преобразование PPT в PPTX с сохранением сложных структур презентации, таких как шаблоны, макеты, слайды, диаграммы, сгруппированные объекты, заполнители, текстовые рамки, текстуры и заливки изображениями.

Подробности см. в статьях [Конвертировать PPT в PPTX](/slides/ru/nodejs-java/convert-ppt-to-pptx/) и [PPT vs PPTX](/slides/ru/nodejs-java/ppt-vs-pptx/).

## **Экспорт фиксированного макета**

PDF, XPS и TIFF полезны, когда вывод должен выглядеть одинаково на разных устройствах и не должен редактироваться как презентация. Специализированные статьи о PDF, XPS и TIFF объясняют, как управлять соответствием стандартам, скрытыми слайдами, заметками, качеством изображений, сжатием, форматом пикселей и размером вывода.

## **Экспорт HTML и изображений**

Экспорт в HTML и HTML5 полезен для просмотра в браузере, веб‑публикаций и лёгкого обмена. Экспорт изображений полезен, когда каждый слайд должен стать отдельным превью, миниатюрой или растровым ресурсом. Используйте статьи о PNG, JPG и SVG для получения рекомендаций по рендерингу под каждый формат.

## **Часто задаваемые вопросы**

**Нужен ли мне Microsoft PowerPoint для конвертации презентаций?**

Нет. Aspose.Slides for Node.js via Java — автономная библиотека и не требует Microsoft PowerPoint или автоматизации Office.

**Могу ли я пакетно конвертировать многие презентации?**

Да. Загружайте каждую презентацию, сохраняйте её в требуемый формат и освобождайте объект презентации после обработки. Для параллельной обработки используйте отдельные экземпляры презентаций и следуйте рекомендациям по [многопоточности](/slides/ru/nodejs-java/multithreading/).

**Могу ли я экспортировать только выбранные слайды?**

Да. Несколько методов экспорта позволяют передать индексы слайдов или рендерить отдельные слайды, в зависимости от формата вывода. Смотрите специализированную статью для нужного формата.

**Могу ли я включить скрытые слайды при экспорте в PDF или XPS?**

Да. Используйте параметры экспорта скрытых слайдов, описанные в статьях о [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) и [XPS](/slides/ru/nodejs-java/convert-powerpoint-to-xps/).

**Могу ли я создать вывод PDF/A?**

Да. Для экспорта PDF доступны настройки соответствия стандарту PDF. Подробнее см. в статье [Конвертировать PowerPoint в PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/).

**Как шрифты обрабатываются при конвертации?**

Aspose.Slides может использовать встроенные шрифты, резервные шрифты и настройки замены шрифтов. Смотрите статьи [Embedded Font](/slides/ru/nodejs-java/embedded-font/), [Fallback Font](/slides/ru/nodejs-java/fallback-font/) и [Font Substitution](/slides/ru/nodejs-java/font-substitution/).