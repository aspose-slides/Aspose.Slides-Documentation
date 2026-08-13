---
title: Оптимизация управления изображениями в презентациях с использованием C++
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/cpp/image/
keywords:
- добавить изображение
- добавить рисунок
- добавить битмап
- заменить изображение
- заменить рисунок
- из веба
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- внешние ресурсы SVG
- резольвер SVG
- связанные SVG-изображения
- шрифты SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Упростите управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для C++, оптимизируя производительность и автоматизируя ваш рабочий процесс."
---
## **Введение**

Изображения делают презентации более увлекательными и визуально привлекательными. В Microsoft PowerPoint вы можете вставлять рисунки на слайды из файлов, интернета или других источников. Аналогично, Aspose.Slides позволяет добавлять изображения в слайды презентации несколькими способами. 

{{% alert title="Tip" color="info" %}} 
Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Если вы хотите добавить изображение в виде рамки рисунка — особенно если планируете изменять его размер, применять эффекты или использовать другие стандартные параметры форматирования — см. [Рамка рисунка](/slides/ru/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Вы можете конвертировать изображения из одного формата в другой. См. следующие страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/ru/cpp/conversion/image-to-jpg/), [JPG в изображение](https://products.aspose.com/slides/ru/cpp/conversion/jpg-to-image/), [JPG в PNG](https://products.aspose.com/slides/ru/cpp/conversion/jpg-to-png/), [PNG в JPG](https://products.aspose.com/slides/ru/cpp/conversion/png-to-jpg/), [PNG в SVG](https://products.aspose.com/slides/ru/cpp/conversion/png-to-svg/), и [SVG в PNG](https://products.aspose.com/slides/ru/cpp/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides поддерживает изображения в популярных форматах, таких как JPEG, PNG, BMP, GIF и др. 

## **Добавление изображений, хранящихся локально, в слайды**

Вы можете добавить одно или несколько изображений, хранящихся на вашем компьютере, в слайд презентации. Ниже приведён пример кода на C++, показывающий, как добавить изображение в слайд:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Добавление изображений из веба в слайды**

Если изображение, которое вы хотите добавить в слайд, не хранится на вашем компьютере, вы можете добавить его напрямую из интернета. 

Ниже приведён пример кода на C++, показывающий, как добавить изображение из веба в слайд:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Добавление изображений в мастер слайдов**

Мастер слайдов хранит и контролирует информацию, такую как тема и макет для слайдов, использующих его. Когда вы добавляете изображение в мастер слайдов, оно появляется на каждом слайде, основанном на этом мастере. 

Ниже приведён пример кода на C++, показывающий, как добавить изображение в мастер слайдов:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Добавление изображений в качестве фоновых рисунков слайдов**

Вы можете использовать рисунок в качестве фона для одного или нескольких слайдов. Для получения подробностей см. *[Установка изображений в качестве фоновых рисунков слайдов](/slides/ru/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**

Содержимое SVG можно добавить в презентацию с помощью класса [SvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/svgimage/). Полученный объект [ISvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/) затем можно добавить в коллекцию изображений презентации и использовать для создания рамки рисунка. 

Ниже приведён пример на C++, импортирующий автономную строку SVG. Все изображения, стили и другие ресурсы, используемые этим SVG, встраиваются непосредственно в содержимое SVG. 

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Импорт контента SVG с внешними ресурсами**

SVG‑файлы, экспортированные из средств проектирования, редакторов диаграмм, систем иконок и веб‑конвейеров, могут ссылаться на ресурсы, хранящиеся за пределами документа SVG. Например, SVG может содержать ссылку на изображение вроде `images/photo.png`, значение CSS `url(...)` или URL шрифта. 

Для импорта такого контента SVG создайте реализацию [IExternalResourceResolver](https://reference.aspose.com/slides/ru/cpp/aspose.slides.import/iexternalresourceresolver/) и передайте её, вместе с базовым URI, в соответствующий конструктор `SvgImage`. Базовый URI указывает расположение документа SVG и используется для разрешения относительных ссылок. 

Интерфейс [ISvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/) предоставляет доступ к информации об импортированном SVG: 

- `get_SvgContent()` возвращает разметку SVG в виде строки. 
- `get_SvgData()` возвращает содержимое SVG в виде массива байтов. 
- `get_BaseUri()` возвращает базовый URI, используемый для относительных ссылок. 
- `get_ExternalResourceResolver()` возвращает резольвер, назначенный SVG‑изображению. 

### **Реализация внешнего ресурсного резольвера**

У резольвера есть два метода: 

- [ResolveUri](https://reference.aspose.com/slides/ru/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) объединяет базовый URI и относительную ссылку на ресурс и возвращает абсолютный URI. Возвращайте пустую строку, когда ссылка не может быть разрешена или не допускается. 
- [GetEntity](https://reference.aspose.com/slides/ru/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) возвращает читаемый поток для абсолютного URI ресурса. Возвращайте `nullptr`, когда ресурс отсутствует, заблокирован или недоступен. При необходимости также может быть возвращён запасной поток. 

Ниже приведён резольвер, который загружает связанные ресурсы только из разрешённого локального каталога. Сетевые ресурсы и пути за пределами разрешённого каталога блокируются. Для неразрешённых ссылок на изображения возвращается необязательное запасное изображение. 

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Этот резольвер намеренно разрешает только локальные файлы.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Использовать запасной вариант только для ресурсов изображений. Возврат потока изображения
        // для отсутствующего шрифта или таблицы стилей был бы недопустим.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Разрешение связанных ресурсов при импорте SVG**

Предположим, что `assets/diagram.svg` содержит относительную ссылку, например: 

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ниже приведён пример на C++, который передаёт URI SVG‑файла в качестве базового URI и предоставляет пользовательский резольвер. Резольвер преобразует относительную ссылку на изображение в абсолютный URI и возвращает поток, содержащий связанный ресурс, пока Aspose.Slides обрабатывает SVG. 

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// Базовый URI представляет расположение SVG‑документа.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Класс `SvgImage` также предоставляет перегрузки, принимающие данные SVG в виде массива байтов или потока, вместе с внешним ресурсным резольвером и базовым URI. 

{{% alert title="Important" color="warning" %}} 
Ресурсный резольвер делает внешние ресурсы доступными во время обработки и рендеринга SVG в Aspose.Slides. Он не изменяет исходную разметку SVG и не встраивает автоматически разрешённые ресурсы. 

Когда объект `ISvgImage` добавляется в коллекцию изображений презентации, файл PPTX может содержать как оригинальное представление SVG, так и растровое запасное изображение. Связанный ресурс может появиться в сгенерированном запасном изображении, тогда как относительная ссылка, например `images/photo.png`, остаётся неизменной в сохранённом SVG. Приложение, которое рендерит нативное представление SVG, может поэтому опустить связанный контент, если оригинальный внешний ресурс недоступен. 
{{% /alert %}}

### **Создание переносимого SVG‑изображения**

Чтобы создать SVG‑изображение, не зависящее от внешних файлов, сделайте SVG автономным перед созданием `SvgImage`. Например, замените URL‑ы связанных изображений на URI `data:`, содержащие данные изображения: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

После того как все необходимые ресурсы будут встроены в содержимое SVG, создайте `SvgImage`, добавьте его в коллекцию изображений презентации и вставьте в рамку рисунка, как показано в предыдущем примере. 

### **Обработка отсутствующих или заблокированных ресурсов**

Возвращайте пустую строку из `ResolveUri`, когда URI ресурса недействителен, запрещён или не может быть разрешён. Возвращайте `nullptr` из `GetEntity`, когда ресурс невозможно прочитать. При возможности Aspose.Slides продолжает обработку SVG без этого ресурса. 

Для отсутствующего ресурса может быть возвращён запасный поток, но его содержимое должно соответствовать типу запрашиваемого ресурса. Например, возвращайте поток изображения только для отсутствующего изображения, а не для шрифта или таблицы стилей. 

{{% alert title="Security" color="warning" %}} 
Не разрешайте произвольные пути к файлам или неограниченные сетевые URL из недоверенных SVG‑файлов. Ограничьте разрешённые схемы, каталоги и хосты. Для сетевых ресурсов также применяйте тайм‑ауты соединений, ограничения размера ответа и проверку содержимого. 
{{% /alert %}}

## **Конвертация SVG в набор фигур**
Aspose.Slides может конвертировать SVG в набор фигур, аналогично соответствующей функции в PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Эта функциональность предоставляется перегрузкой метода [AddGroupShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/) интерфейса [IShapeCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/), который принимает объект [ISvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/) в качестве первого аргумента. 

Ниже приведён пример кода на C++, показывающий, как использовать этот метод для конвертации SVG‑файла в набор фигур:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Имя файла исходного SVG
auto svgFileName = System::String(u"sample.svg");

// Имя выходного файла презентации
auto outPptxPath = System::String(u"presentation.pptx");

// Создать новую презентацию
auto presentation = System::MakeObject<Presentation>();

// Прочитать содержимое SVG‑файла
auto svgContent = File::ReadAllText(svgFileName);

// Создать объект SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Получить размер слайда
auto slideSize = presentation->get_SlideSize()->get_Size();

// Преобразовать SVG‑изображение в группу фигур и масштабировать её до размера слайда
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Сохранить презентацию в формате PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Добавление изображений в формате EMF в слайды**
Aspose.Slides для C++ позволяет генерировать EMF‑изображения из листов Excel с помощью Aspose.Cells и добавлять их в слайды презентации. 

Ниже приведён пример кода на C++, показывающий, как это сделать:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells for C++ должен быть запущен до использования любых его типов.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Отрисовать лист как EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells возвращает отрисованную страницу в виде буфера, который Aspose.Slides добавляет как изображение.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Замена изображений в коллекции изображений**
Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации, включая изображения, используемые фигурами слайдов. В этом разделе описываются несколько способов обновления изображений в коллекции. Вы можете заменить изображение, используя необработанные байтовые данные, экземпляр [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) или другое изображение, уже существующее в коллекции. 

Выполните следующие шаги: 

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). 
2. Загрузите новое изображение из файла в массив байтов. 
3. Замените целевое изображение новым, используя массив байтов. 
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) и замените целевое изображение этим объектом. 
5. В третьем подходе замените целевое изображение изображением, которое уже существует в коллекции изображений презентации. 
6. Запишите изменённую презентацию в файл PPTX. 

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Первый способ.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Второй способ.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Третий способ.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Сохраните презентацию в файл.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}} 
С помощью бесплатного конвертера Aspose [Text to GIF](https://products.aspose.app/slides/ru/text-to-gif) вы можете легко анимировать текст и создавать GIF‑изображения из текста. 
{{% /alert %}}

## **FAQ**

**Сохраняется ли исходное разрешение изображения после вставки?**  
Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [рисунок](/slides/ru/cpp/picture-frame/) масштабируется на слайде и от любой компрессии, применяемой при сохранении. 

**Какой лучший способ заменить один и тот же логотип на десятках слайдов одновременно?**  
Разместите логотип на мастер‑слайде или в макете и замените его в коллекции изображений презентации — изменения распространятся на все элементы, использующие этот ресурс. 

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**  
Да. Вы можете конвертировать SVG в группу фигур, после чего отдельные части становятся редактируемыми с помощью стандартных свойств фигур. 

**Как установить рисунок фоном для нескольких слайдов одновременно?**  
[Назначьте изображение фоном](/slides/ru/cpp/presentation-background/) на мастер‑слайде или соответствующем макете — любые слайды, использующие этот мастер/макет, унаследуют фон. 

**Как не допустить, чтобы презентация стала слишком большой из‑за большого количества рисунков?**  
Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте сжатие при сохранении и размещайте повторяющиеся графические элементы на мастере, где это уместно.