---
title: Конвертировать презентации в несколько форматов на Python
linktitle: Конвертировать презентацию
type: docs
weight: 70
url: /ru/python-java/convert-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Конвертируйте презентации PowerPoint и OpenDocument в PPTX, PDF, HTML, изображения, XPS, TIFF и другие форматы с помощью Aspose.Slides for Python via Java."
---
## **Обзор**

Aspose.Slides for Python via Java может загружать презентации PowerPoint и OpenDocument и сохранять или рендерить их в многие другие форматы без необходимости Microsoft PowerPoint, OpenOffice или LibreOffice. Вы можете конвертировать устаревшие файлы PPT в современные PPTX, экспортировать презентации в документы фиксированного макета, такие как PDF и XPS, публиковать слайды как HTML или рендерить слайды в виде изображений для предварительного просмотра, миниатюр и архивов.

Большинство конвертаций документов используют один и тот же общий рабочий процесс: загрузить исходный файл, выбрать требуемый выходной формат и при необходимости применить параметры, специфичные для формата. Для форматов изображений каждый слайд рендерится отдельно, а затем сохраняется как растровое или векторное изображение. Посвящённые статьи, ссылки на которые указаны ниже, содержат детали реализации для каждого случая.

## **Выберите сценарий конвертации**

Используйте статьи ниже для полных примеров на Python и параметров, специфичных для формата.

| Сценарий | Когда использовать | Статья |
| --- | --- | --- |
| PPT/PPTX/ODP в PPTX | Модернизация устаревших файлов PPT, нормализация существующих файлов PPTX или конвертация презентаций OpenDocument в PowerPoint PPTX. | [Конвертировать PPT в PPTX](/slides/ru/python-java/convert-ppt-to-pptx/), [Конвертировать ODP в PPTX](/slides/ru/python-java/convert-odp-to-pptx/), [Сохранить презентации](/slides/ru/python-java/save-presentation/) |
| PPTX в PPT | Сохранить современную презентацию PowerPoint в более старом бинарном формате PPT для совместимости со старыми рабочими процессами. | [Конвертировать PPTX в PPT](/slides/ru/python-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP в PDF | Создать переносимые, поисковые документы фиксированного макета для обмена, печати или архивирования. | [Конвертировать PowerPoint в PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP в PDF с примечаниями | Экспортировать примечания докладчика вместе с содержимым слайдов. | [Конвертировать PowerPoint в PDF с примечаниями](/slides/ru/python-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP в HTML | Публиковать презентации как HTML‑страницы и управлять изображениями, шрифтами, примечаниями и параметрами адаптивного макета. | [Конвертировать PowerPoint в HTML](/slides/ru/python-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP в HTML5 | Экспортировать слайды в HTML5 для просмотра в браузере с сохранением форматирования и интерактивности. | [Экспортировать презентации в HTML5](/slides/ru/python-java/export-to-html5/) |
| PPT/PPTX/ODP в PNG | Рендерить каждый слайд в PNG‑изображение для предварительного просмотра, миниатюр или веб‑вывода. | [Конвертировать PowerPoint в PNG](/slides/ru/python-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP в JPG | Рендерить слайды в JPG‑изображения и управлять их размерами и качеством. | [Конвертировать PowerPoint в JPG](/slides/ru/python-java/convert-powerpoint-to-jpg/) |
| Слайд в SVG | Экспортировать отдельные слайды в масштабируемую векторную графику. | [Рендерить слайд как SVG](/slides/ru/python-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP в XPS | Генерировать документы XPS фиксированного макета. | [Конвертировать PowerPoint в XPS](/slides/ru/python-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP в TIFF | Сохранить презентацию как многостраничный TIFF‑файл для печати, сканирования, факса или архивных процессов. | [Конвертировать PowerPoint в TIFF](/slides/ru/python-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP в TIFF с примечаниями | Сохранить слайды с примечаниями докладчика в TIFF. | [Конвертировать PowerPoint в TIFF с примечаниями](/slides/ru/python-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX в Word | Конвертировать слайды в документ Word, когда нужен вывод в виде документа. | [Конвертировать PowerPoint в Word](/slides/ru/python-java/convert-powerpoint-to-word/) |
| PPT/PPTX в Markdown | Извлечь содержимое презентации в Markdown для документации и текстовых рабочих процессов. | [Конвертировать PowerPoint в Markdown](/slides/ru/python-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP в XML | Создать текстовый XML‑файл презентации PowerPoint для анализа, сравнения, отладки или XML‑ориентированных процессов. | [Конвертировать PowerPoint в XML](/slides/ru/python-java/convert-powerpoint-to-xml/) |
| PPT/PPTX в анимированный GIF | Создать анимированный GIF из слайдов. | [Конвертировать PowerPoint в анимированный GIF](/slides/ru/python-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX в видео | Организовать рабочий процесс экспорта презентации в виде видео. | [Конвертировать PowerPoint в видео](/slides/ru/python-java/convert-powerpoint-to-video/) |
| Презентация в XAML | Экспортировать слайды в XAML для использования в приложениях WPF. | [Экспортировать презентации в XAML](/slides/ru/python-java/export-to-xaml/) |

Для более полного списка поддерживаемых форматов ввода и вывода см. [Поддерживаемые форматы файлов](/slides/ru/python-java/supported-file-formats/).

## **Конвертация PowerPoint и OpenDocument**

Aspose.Slides for Python via Java поддерживает конвертацию из широко используемых форматов презентаций, таких как PPT, PPTX, PPS, PPSX, POT, POTX и ODP. Один и тот же API конвертации используется для файлов PowerPoint и OpenDocument, поэтому рабочий процесс, сохраняющий PPTX в PDF, обычно можно применить к файлу ODP, изменив только входной файл.

При конвертации файлов ODP помните, что приложения PowerPoint и OpenDocument не поддерживают каждый макет и каждый параметр форматирования одинаково. Если файл ODP был создан в LibreOffice или OpenOffice Impress, проверьте результат и используйте параметры, описанные в [Конвертировать OpenDocument презентации](/slides/ru/python-java/convert-openoffice-odp/), когда требуется руководство, специфичное для формата.

## **Конвертация PPT в PPTX**

PPT — старый бинарный формат PowerPoint, в то время как PPTX — современный формат Office Open XML. Aspose.Slides for Python via Java поддерживает высокоточную конвертацию PPT в PPTX с сохранением сложных структур презентации, таких как шаблоны, макеты, слайды, диаграммы, сгруппированные фигуры, заполнители, текстовые рамки, текстуры и заливка изображениями.

Подробности см. в [Конвертировать PPT в PPTX](/slides/ru/python-java/convert-ppt-to-pptx/) и [PPT vs PPTX](/slides/ru/python-java/ppt-vs-pptx/).

## **Экспорт фиксированного макета**

PDF, XPS и TIFF полезны, когда вывод должен выглядеть одинаково на разных устройствах и не должен редактироваться как презентация. Посвящённые статьи по PDF, XPS и TIFF объясняют, как управлять соответствием требованиям, скрытыми слайдами, примечаниями, качеством изображений, сжатием, форматом пикселей и размером вывода.

## **Экспорт в HTML и изображения**

Экспорт в HTML и HTML5 полезен для просмотра в браузере, публикации в вебе и лёгкого обмена. Экспорт изображений нужен, когда каждый слайд должен стать отдельным предварительным просмотром, миниатюрой или растровым ресурсом. Используйте статьи по PNG, JPG и SVG для получения рекомендаций по рендерингу, специфичным для формата.

## **FAQ**

**Нужен ли Microsoft PowerPoint для конвертации презентаций?**

Нет. Aspose.Slides for Python via Java — это автономная библиотека и не требует Microsoft PowerPoint или автоматизации Office.

**Можно ли пакетно конвертировать множество презентаций?**

Да. Загружайте каждую презентацию, сохраняйте её в требуемый формат и освобождайте объект презентации после обработки. Для параллельной обработки используйте отдельные экземпляры презентаций и следуйте рекомендациям по [многопоточности](/slides/ru/python-java/multithreading/).

**Можно ли экспортировать только выбранные слайды?**

Да. Несколько методов экспорта позволяют передать индексы слайдов или рендерить отдельные слайды в зависимости от формата вывода. См. соответствующую статью для целевого формата.

**Можно ли включить скрытые слайды при экспорте в PDF или XPS?**

Да. Используйте параметры экспорта скрытых слайдов, описанные в статьях по [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/) и [XPS](/slides/ru/python-java/convert-powerpoint-to-xps/).

**Можно ли создать вывод PDF/A?**

Да. Настройки соответствия PDF доступны при экспорте в PDF. См. [Конвертировать PowerPoint в PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/) для деталей.

**Как обрабатываются шрифты при конвертации?**

Aspose.Slides может использовать встроенные шрифты, резервные шрифты и настройки замены шрифтов. См. [Встроенный шрифт](/slides/ru/python-java/embedded-font/), [Резервный шрифт](/slides/ru/python-java/fallback-font/) и [Замена шрифтов](/slides/ru/python-java/font-substitution/).