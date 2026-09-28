---
title: Поддерживаемые форматы файлов
type: docs
weight: 96
url: /ru/net/supported-file-formats/
keywords:
- поддерживаемые форматы файлов
- загрузка презентации
- импорт PDF
- импорт HTML
- сохранение презентации
- отображение слайдов
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
- .NET
- C#
- Aspose.Slides
description: "Посмотрите, какие форматы файлов Aspose.Slides для .NET может загружать, импортировать, сохранять и отображать, а также какой API читает или записывает каждый из них."
---
## **Обзор**

Aspose.Slides для .NET открывает и сохраняет презентации PowerPoint и OpenDocument. Он также импортирует контент PDF и HTML в слайды, сохраняет презентации в документные, веб- и графические форматы и отображает отдельные слайды и фигуры как изображения. В этой статье перечислены поддерживаемые форматы и указаны API, которые их читают или записывают.

Оба пакета NuGet, Aspose.Slides.NET и Aspose.Slides.NET6.CrossPlatform, поддерживают одинаковые форматы; см. [Установку](/slides/ru/net/installation/) для выбора между ними. Для обзора функций редактирования см. [Обзор функций](/slides/ru/net/features-overview/).

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
- PowerPoint для Microsoft 365 (ранее Office 365)

{{% alert color="info" title="Примечание" %}}

Презентации, сохранённые в PowerPoint 95 и более ранних версиях, открыть нельзя. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/) распознаёт файл PowerPoint 95 и сообщает `LoadFormat.Ppt95`, но конструктор [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/presentation/) выбрасывает [PptUnsupportedFormatException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptunsupportedformatexception/) для него.

{{% /alert %}}

## **Поддерживаемые форматы файлов**

В таблице используются четыре операции:

- **Load**: конструктор [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/presentation/) открывает файл как редактируемую презентацию.
- **Import**: метод [SlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/slidecollection/) создаёт слайды из содержимого файла и добавляет их в существующую презентацию. Конструктор Presentation такие файлы не загружает как презентации.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) записывает презентацию в файл или поток. Каждый формат, кроме XAML, выбирается значением [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/).
- **Render**: метод отрисовки выводит слайд или фигуру как изображение. Форматы, которые только отрисовываются, не являются значениями SaveFormat.

|**Формат**|**Описание**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Презентация PowerPoint 97‑2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Шаблон PowerPoint 97‑2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Слайд‑шоу PowerPoint 97‑2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Презентация PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Шаблон PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Слайд‑шоу PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Презентация PowerPoint с поддержкой макросов|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Шаблон PowerPoint с поддержкой макросов|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Слайд‑шоу PowerPoint с поддержкой макросов|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Презентация OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Плоская XML‑презентация OpenDocument|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Шаблон OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Презентация PowerPoint XML|Load|Save|`SaveFormat.Xml`; загруженные файлы сообщают `SourceFormat.Xml` (значения `LoadFormat` нет)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (один слайд)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (анимированный, все слайды); `ImageFormat.Gif` (один слайд)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.Save(IXamlOptions)`, один файл XAML на слайд; нет значения `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Load и Import**

- **Load:** Передайте путь к файлу или поток в конструктор [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/presentation/). Формат определяется по содержимому; [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/) задаёт параметры, такие как пароль. Чтобы проверить файл перед открытием, вызовите [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/), который возвращает значение [LoadFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/loadformat/). Для PowerPoint XML он возвращает `LoadFormat.Unknown`, но конструктор открывает такой файл, и [Presentation.SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sourceformat/) затем возвращает `SourceFormat.Xml`. См. [Открытие презентаций](/slides/ru/net/open-presentation/) и [Определение исходного формата презентации](/slides/ru/net/detect-presentation-source-format/).
- **Import:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/ru/net/aspose.slides/slidecollection/addfrompdf/) добавляет один слайд на каждую страницу PDF в конец презентации. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/slidecollection/addfromhtml/) добавляет слайды, созданные из HTML, а [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/ru/net/aspose.slides/slidecollection/insertfromhtml/) вставляет их в указанную позицию. Конструктор Presentation импорт не выполняет: он бросает [PptUnsupportedFormatException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptunsupportedformatexception/) для PDF и не преобразует HTML‑разметку в содержимое слайдов. См. [Импорт презентаций из PDF или HTML](/slides/ru/net/import-presentation/).

## **Save и Render**

- **Save:** [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) записывает презентацию в формате, заданном значением [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/). Перегрузки, принимающие объект параметров, управляют выводом, например [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/ru/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/tiffoptions/), и [GifOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/gifoptions/). Перегрузки, получающие массив номеров слайдов (начиная с 1), записывают только указанные слайды; они поддерживают PDF, XPS, TIFF, HTML, HTML5, SWF, GIF и Markdown, но не форматы презентаций или PowerPoint XML. XAML имеет отдельную перегрузку, принимающую [IXamlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/ixamloptions/). См. [Сохранение презентаций](/slides/ru/net/save-presentation/), [Преобразование презентаций](/slides/ru/net/convert-presentation/), и [Экспорт презентаций в XAML](/slides/ru/net/export-to-xaml/).
- **Render:** [Slide.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage/) и [Shape.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/getimage/) возвращают [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/), а [IImage.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/save/) записывает его как PNG, JPEG, BMP, GIF или TIFF, выбираемый значением [ImageFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/getimages/) отрисовывает все слайды или выбранные сразу. [Slide.WriteAsSvg](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/writeassvg/) и [Shape.WriteAsSvg](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/writeassvg/) записывают SVG, а [Slide.WriteAsEmf](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/writeasemf/) записывает EMF. См. [Преобразование слайдов презентации в изображения](/slides/ru/net/convert-slide/) и [Отрисовка слайда как SVG‑изображения](/slides/ru/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Предупреждение" %}}

ImageFormat также содержит значения `Emf`, `Wmf`, `Icon`, `Exif` и `MemoryBmp`, но IImage.Save не создаёт файлы этих форматов: записываемый файл содержит данные PNG. Чтобы получить EMF‑изображение слайда, используйте Slide.WriteAsEmf.

{{% /alert %}}

## **FAQ**

**Можно ли преобразовать презентацию PPT в PPTX или ODP?**

Да. Откройте файл PPT конструктором Presentation и сохраните его с `SaveFormat.Pptx` или `SaveFormat.Odp`. См. [Преобразование PPT в PPTX](/slides/ru/net/convert-ppt-to-pptx/).

**Можно ли открыть PDF или HTML как презентацию?**

Нет. Создайте или откройте презентацию, импортируйте страницы PDF или содержимое HTML с помощью методов коллекции слайдов, описанных выше, а затем сохраните её в любом поддерживаемом формате.

**Можно ли загрузить экспортированный PNG или SVG как редактируемую презентацию?**

Нет. Вывод изображения фиксирует внешний вид слайда, а не его текст, фигуры или диаграммы. Сохраняйте исходную презентацию, если планируете последующее редактирование.

**Можно ли сохранять документы PDF/A или PDF/UA?**

Да. Установите [PdfOptions.Compliance](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/compliance/) в значение [PdfCompliance](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfcompliance/): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b или PDF/UA.

**Можно ли проверить, защищён ли файл паролем, перед открытием?**

Да. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/) анализирует файл без создания объекта Presentation, а его свойство [IsPasswordProtected](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/ispasswordprotected/) сообщает, нужен ли пароль. См. [Парольная защита презентаций](/slides/ru/net/password-protected-presentation/).

**Поддерживают ли два пакета NuGet разные форматы?**

Нет. Aspose.Slides.NET и Aspose.Slides.NET6.CrossPlatform имеют одинаковые значения LoadFormat и SaveFormat, а также одинаковые методы импорта и отрисовки. Они различаются только платформами исполнения и требованиями этих платформ; см. [Установку](/slides/ru/net/installation/).