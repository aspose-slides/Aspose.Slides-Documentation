---
title: Поддерживаемые форматы файлов
type: docs
weight: 106
url: /ru/java/supported-file-formats/
keywords:
- поддерживаемые форматы файлов
- загрузка презентации
- импорт PDF
- импорт HTML
- сохранение презентации
- рендеринг слайдов
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- Java
- Aspose.Slides
description: "Узнайте, какие форматы файлов Aspose.Slides for Java может загружать, импортировать, сохранять и рендерить, а также какой API читает или записывает каждый из них."
---
## **Обзор**

Aspose.Slides for Java открывает и сохраняет презентации PowerPoint и OpenDocument. Он также импортирует содержимое PDF и HTML в слайды, сохраняет презентации в форматы документов, веб‑форматы и изображения, а также рендерит отдельные слайды и объекты как изображения. В этой статье перечислены все поддерживаемые форматы и указаны API, которые их читают или записывают.

Для обзора возможностей редактирования см. [Обзор функций](/slides/ru/java/features-overview/).

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
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}

Презентации, сохранённые в PowerPoint 95 и более ранних версиях, открыть нельзя. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) распознаёт файл PowerPoint 95 и сообщает `LoadFormat.Ppt95`, но конструктор [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) выдаёт [PptUnsupportedFormatException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptunsupportedformatexception/) для него.

{{% /alert %}}

## **Поддерживаемые форматы файлов**

В таблице используются четыре операции:

- **Load**: конструктор [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) открывает файл как редактируемую презентацию.
- **Import**: метод [SlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidecollection/) создаёт слайды из содержимого файла и добавляет их в существующую презентацию. Конструктор Presentation не преобразует эти файлы в слайды.
- **Save**: [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) записывает презентацию в файл или поток. Каждый формат, кроме XAML, выбирается значением [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/).
- **Render**: метод рендеринга рисует слайд или объект как изображение. Форматы, которые только рендерятся, не являются значениями SaveFormat.

|**Формат**|**Описание**|**Загрузка / Импорт**|**Сохранение / Рендер**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Презентация PowerPoint 97‑2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Шаблон PowerPoint 97‑2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Слайдшоу PowerPoint 97‑2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Презентация PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Шаблон PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Слайдшоу PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Презентация PowerPoint с поддержкой макросов|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Шаблон PowerPoint с поддержкой макросов|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Слайдшоу PowerPoint с поддержкой макросов|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Презентация OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Плоская XML‑презентация OpenDocument|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Шаблон презентации OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|XML‑презентация PowerPoint|Load|Save|`SaveFormat.Xml`; загруженные файлы сообщают `SourceFormat.Xml` (значения `LoadFormat` нет)|
|[PDF](https://docs.fileformat.com/pdf/)|Формат Portable Document Format|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff` (по одному слайду); `ImageFormat.Tiff` (один слайд)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (анимированный, все слайды); `ImageFormat.Gif` (один слайд)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.save(IXamlOptions)`, один XAML‑файл на слайд; нет значения `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG‑изображение|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap‑изображение|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Загрузка и импорт**

- **Загрузка:** Передайте путь к файлу или поток конструктору [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Формат определяется по содержимому; [LoadOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/) задаёт параметры, такие как пароль. Чтобы проверить файл перед открытием, вызовите [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), который возвращает значение [LoadFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadformat/). Он сообщает `LoadFormat.Unknown` для PowerPoint XML, но конструктор открывает такой файл, и [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSourceFormat--) затем возвращает `SourceFormat.Xml`. Смотрите [Open Presentations](/slides/ru/java/open-presentation/) и [Determine the Original Presentation Format](/slides/ru/java/detect-presentation-source-format/).
- **Импорт:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) добавляет по одному слайду на каждую страницу PDF в конец презентации. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) добавляет слайды, созданные из HTML, а [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) вставляет их в указанную позицию. Конструктор Presentation импорт не выполняет: он бросает [PptUnsupportedFormatException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptunsupportedformatexception/) для PDF‑файла и не преобразует HTML‑разметку в содержимое слайдов. Смотрите [Import Presentations from PDF or HTML](/slides/ru/java/import-presentation/).

## **Сохранение и визуализация**

- **Сохранение:** [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) записывает презентацию в формат, указанный значением [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/). Перегрузки, принимающие объект параметров, управляют выводом, например [PdfOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/ru/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tiffoptions/), и [GifOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/gifoptions/). Перегрузки, принимающие массив позиций слайдов (начиная с 1), записывают только указанные слайды; они поддерживают PDF, XPS, TIFF, HTML, HTML5, SWF, GIF и Markdown, но не форматы презентаций или PowerPoint XML. XAML имеет собственную перегрузку, [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), принимающую [IXamlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloptions/). Смотрите [Save Presentations](/slides/ru/java/save-presentation/), [Convert Presentations](/slides/ru/java/convert-presentation/), и [Export Presentations to XAML](/slides/ru/java/export-to-xaml/).
- **Визуализация:** [Slide.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#getImage-float-float-) и [Shape.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#getImage--) возвращают объект [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/), а [IImage.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/#save-java.lang.String-int-) записывает его как PNG, JPEG, BMP, GIF или TIFF, выбирая значение [ImageFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) рендерит все слайды или выбранные сразу. [Slide.writeAsSvg](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) и [Shape.writeAsSvg](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) записывают SVG, а [Slide.writeAsEmf](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) записывает EMF. Смотрите [Convert Presentation Slides to Images](/slides/ru/java/convert-slide/) и [Render Presentation Slides as SVG Images](/slides/ru/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat также содержит значения `Emf`, `Wmf`, `Icon`, `Exif` и `MemoryBmp`, но IImage.save не создаёт файлы этих форматов: записываемый файл содержит данные PNG. Чтобы получить EMF‑изображение слайда, используйте Slide.writeAsEmf.

{{% /alert %}}

## **FAQ**

**Можно ли конвертировать презентацию PPT в PPTX или ODP?**

Да. Откройте файл PPT конструктором Presentation и сохраните его с `SaveFormat.Pptx` или `SaveFormat.Odp`. Смотрите [Convert PPT to PPTX](/slides/ru/java/convert-ppt-to-pptx/).

**Можно ли открыть PDF или HTML как презентацию?**

Нет. Конструктор Presentation бросает PptUnsupportedFormatException для PDF‑файла и не преобразует HTML‑разметку в слайды. Создайте или откройте презентацию, импортируйте страницы PDF или содержимое HTML с помощью методов коллекции слайдов, описанных выше, а затем сохраните её в любом поддерживаемом формате.

**Можно ли загрузить экспортированное PNG или SVG как редактируемую презентацию?**

Нет. Вывод изображения фиксирует только внешний вид слайда, а не его текст, объекты или диаграммы. Сохраните исходную презентацию, если потребуется последующее редактирование.

**Можно ли сохранять документы PDF/A или PDF/UA?**

Да. Передайте значение [PdfCompliance](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfcompliance/) в метод [PdfOptions.setCompliance](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b или PDF/UA.

**Можно ли проверить, защищён ли файл паролем, перед его открытием?**

Да. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) исследует файл без создания объекта Presentation, а [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) сообщает, требуется ли пароль. Смотрите [Password-Protect Presentations](/slides/ru/java/password-protected-presentation/).