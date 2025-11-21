---
title: Поддерживаемые форматы файлов
type: docs
weight: 30
url: /ru/nodejs-java/supported-file-formats/
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
- Microsoft PowerPoint for MAC
- Office 365

## **Поддерживаемые форматы файлов**
Эта таблица содержит форматы файлов, которые Aspose.Slides for Node.js via Java может загружать и сохранять:

|**Формат**|**Описание**|**Загрузка**|**Сохранение**|**Примечание**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Презентация PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Шаблон PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Слайд-шоу PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Презентация PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Шаблон PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|Слайд-шоу PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Презентация PowerPoint с поддержкой макросов|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Слайд-шоу PowerPoint с поддержкой макросов|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Шаблон PowerPoint с поддержкой макросов|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Презентация OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|Шаблон презентации OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
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
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML Presentation| |{{< emoticons/tick >}}| |

## **FAQ**

**Могу ли я сохранять презентации в PDF, соответствующие архивным и доступным требованиям (PDF/A и PDF/UA)?**

Да. Aspose.Slides поддерживает экспорт в PDF с уровнями соответствия, такими как PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, а также PDF/UA через настройку [compliance](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setcompliance/) в [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**Поддерживает ли библиотека встраивание шрифтов при экспорте в PDF с тонкой настройкой того, что встраивается?**

Да. Вы можете управлять тем, будут ли шрифты полностью встраиваться или субсетироваться (только используемые глифы), задавать обработку распространённых системных шрифтов и настраивать поведение для ASCII‑текста через [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**Могу ли я определить, защищён ли файл паролем, прежде чем загружать его?**

Да. С помощью [factory-based inspection API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/) можно запросить файл презентации, чтобы узнать, защищён ли он паролем, не открывая его полностью.

**Есть ли механизмы резервных шрифтов и поддержка пользовательских шрифтов?**

Да. Библиотека поддерживает [loading](/slides/ru/nodejs-java/custom-font/) и [embedding](/slides/ru/nodejs-java/embedded-font/) пользовательских шрифтов и предоставляет правила [fallback](/slides/ru/nodejs-java/fallback-font/) для предотвращения отсутствия глифов во время рендеринга и конвертации.

**Могу ли я экспортировать слайды в XPS и есть ли параметры настройки вывода XPS?**

Да. [Export to XPS](/slides/ru/nodejs-java/convert-powerpoint-to-xps/) поддерживается, и вы можете скорректировать соответствующие [save options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) для управления качеством и содержимым документа XPS.