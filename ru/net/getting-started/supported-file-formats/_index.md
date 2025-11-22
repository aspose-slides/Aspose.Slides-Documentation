---
title: Поддерживаемые форматы файлов
type: docs
weight: 30
url: /ru/net/supported-file-formats/
---

## **Поддерживаемые версии Microsoft PowerPoint**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint для Mac
- Office 365

## **Поддерживаемые форматы файлов**
Эта таблица содержит форматы файлов, которые Aspose.Slides for .NET может загружать и сохранять:

|**Формат**|**Описание**|**Загрузка**|**Сохранение**|**Примечания**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Презентация PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Шаблон PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Показ PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Презентация PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Шаблон PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|Показ PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Презентация PowerPoint с поддержкой макросов|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Показ PowerPoint с поддержкой макросов|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Шаблон PowerPoint с поддержкой макросов|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Презентация OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|Шаблон презентации OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Формат изображений с тегами| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Расширенный формат метафайла| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Формат PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|Презентация PowerPoint XML| |{{< emoticons/tick >}}| |

## **Часто задаваемые вопросы**

**Могу ли я сохранять презентации в PDF, соответствующие стандартам архивирования и доступности (PDF/A и PDF/UA)?**

Да. Aspose.Slides поддерживает экспорт в PDF с уровнями соответствия, такими как PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, а также PDF/UA с помощью параметра [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) в [PDF export options](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

**Поддерживает ли библиотека встраивание шрифтов при экспорте в PDF с тонкой настройкой того, какие шрифты встраиваются?**

Да. Вы можете контролировать, будут ли шрифты полностью встроены или только их подмножество (используемые глифы), задавать правила обработки распространённых системных шрифтов и настраивать поведение для ASCII‑текста через [PDF export options](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

**Могу ли я определить, защищён ли файл паролем, прежде чем полностью его загрузить?**

Да. С помощью [factory-based inspection API](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) можно запросить информацию о файле презентации и узнать, защищён ли он паролем, не открывая его полностью.

**Существуют ли механизмы резервных шрифтов и поддержка пользовательских шрифтов?**

Да. Библиотека поддерживает [загрузка](/slides/ru/net/custom-font/) и [встраивание](/slides/ru/net/embedded-font/) пользовательских шрифтов и предоставляет правила [fallback](/slides/ru/net/fallback-font/) для предотвращения отсутствия глифов при рендеринге и конвертации.

**Могу ли я экспортировать слайды в XPS и есть ли параметры настройки вывода XPS?**

Да. [Export to XPS](/slides/ru/net/convert-powerpoint-to-xps/) поддерживается, и вы можете корректировать соответствующие [save options](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) для управления качеством и содержимым документа XPS.