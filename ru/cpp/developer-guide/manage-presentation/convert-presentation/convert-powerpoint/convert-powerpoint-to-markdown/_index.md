---
title: Конвертировать презентации PowerPoint в Markdown на C++
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/cpp/convert-powerpoint-to-markdown/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в MD
- презентация в MD
- слайд в MD
- PPT в MD
- PPTX в MD
- сохранить PowerPoint как Markdown
- сохранить презентацию как Markdown
- сохранить слайд как Markdown
- сохранить PPT как MD
- сохранить PPTX как MD
- экспортировать PPT в MD
- экспортировать PPTX в MD
- экспорт изображений в Markdown
- ссылки на изображения CDN
- PowerPoint
- презентация
- Markdown
- C++
- Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в Markdown на C++ и управлять тем, где сохраняются и на которые ссылаются экспортированные растровые, метафайлы и SVG‑изображения."
---
## **Обзор**

Aspose.Slides for C++ может конвертировать презентации PPT и PPTX в Markdown для документации, статических сайтов, миграции контента и рабочих процессов контроля версий. Вы можете выбрать вариант Markdown, управлять тем, как отображается содержимое слайдов, и решать, где хранить экспортированные изображения и как генерируемый Markdown будет на них ссылаться.

По умолчанию экспорт в Markdown использует только текстовый вывод. Чтобы экспортировать визуальное содержимое, установите метод [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) в значение `Sequential` или `Visual` из перечисления [MarkdownExportType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownexporttype/). `Sequential` выводит элементы слайда отдельно и в порядке их следования, тогда как `Visual` сохраняет сгруппированные элементы вместе, чтобы сохранить их визуальные отношения. Значение `TextOnly` не генерирует ресурсы изображений, поэтому события сохранения изображений не вызываются в этом режиме.

## **Конвертировать презентацию в Markdown**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и затем вызовите метод [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) с параметром `Md` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Выбор варианта Markdown**

Метод [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) управляет спецификацией Markdown, используемой для вывода. Перечисление [Flavor](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/flavor/) включает CommonMark, GitHub Flavored Markdown и другие поддерживаемые варианты.

Ниже приведён пример экспорта презентации в CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Экспорт изображений с поведением сохранения по умолчанию**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/) предоставляет два метода для настройки локального сохранения изображений:

- [set_BasePath](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) задаёт базовый каталог для документа Markdown и его ресурсов.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) задаёт подпапку для изображений. Значением по умолчанию является `Images`.

В следующем примере визуальное содержимое рендерится, изображения записываются в `output/assets`, а в документе Markdown создаются относительные ссылки на изображения:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Это поведение также используется как резервное, когда пользовательский обработчик сохранения изображения возвращает `false`.

## **Настройка сохранения изображений и ссылок Markdown**

Используйте событие `MarkdownSaveOptions::ImageSaving` для не‑SVG растровых и метафайлов, генерируемых при экспорте Markdown. Делегат [MarkdownImageSavingHandler](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) получает объект [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/), его [ImageFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imageformat/) и сгенерированную ссылку Markdown в параметре `System::String&`. Сохраните или загрузите изображение в указанном формате и замените `link` на ссылку, которая должна появиться в выводе Markdown.

Ресурсы, генерируемые в формате SVG, обрабатываются отдельно. Подпишитесь на событие `MarkdownSaveOptions::SvgImageSaving`, делегат [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) которого получает объект [ISvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/) и параметр `System::String& link`. У SVG нет аргумента `ImageFormat`; вместо этого запишите или загрузите его XML‑данные через метод [ISvgImage::get_SvgData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/get_svgdata/). В зависимости от режима экспорта и визуального групперования SVG в исходной презентации может быть растерен или объединён с другим содержимым; полученный не‑SVG ресурс затем передаётся в `ImageSaving`. Подпишитесь на оба события, когда каждый экспортируемый визуальный ресурс требует пользовательской обработки.

Возврат обработчика определяет, кто будет обрабатывать изображение:

- Верните `true`, если обработчик сохранил, загрузил, преобразовал или иначе обработал изображение и присвоил `link` действительное значение. Aspose.Slides запишет это значение в документ Markdown и не будет выполнять своё локальное сохранение.
- Верните `false`, чтобы позволить Aspose.Slides сохранить изображение локально и сформировать ссылку согласно [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) и [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Важно" %}}

Обработчик, возвращающий `true`, берёт на себя ответственность за изображение. Если он возвращает `true`, не задав действительную, непустую ссылку, экспорт завершается с `InvalidOperationException`.

{{% /alert %}}

### **Сохранение изображений в каталог CDN‑origin и использование внешних URL**

В следующем примере `cdn-origin/presentations/quarterly-report` рассматривается как смонтированный или синхронизированный каталог CDN‑origin. Каждый обработчик извлекает сгенерированное имя файла, сохраняет изображение в этот пользовательский каталог и заменяет локальную ссылку публичным URL CDN. Сам пример не выполняет сетевую загрузку: URL становится действительным только после монтирования каталога как CDN‑origin или публикации файлов в CDN. Для объектного хранилища замените запись в файловой системе на операцию загрузки SDK хранилища и присвойте `link` только после успешной загрузки.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Обработчик bitmap умышленно возвращает `false` для изображений размером менее 128 × 128 px, поэтому Aspose.Slides сохраняет такие изображения в `output/fallback-images` с поведением по умолчанию. Большие bitmap и метафайлы, а также SVG‑ресурсы обрабатываются пользовательским кодом. Например, локальная ссылка `fallback-images/image1.png` превращается в `https://cdn.example.com/presentations/quarterly-report/image1.png`. Обработчики используют системные пути только при записи файлов; ссылки в Markdown используют прямые слеши и URL‑экранированные имена файлов. Применяйте то же правило при построении относительных ссылок: используйте `/`, а не разделитель каталогов платформы.

## **FAQ**

**Можно ли одним обработчиком обрабатывать как растровые, так и SVG‑изображения?**

Нет. Используйте `MarkdownSaveOptions::ImageSaving` для генерируемых bitmap и метафайлов и `MarkdownSaveOptions::SvgImageSaving` для ресурсов в формате SVG. Первый предоставляет объект [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) и [ImageFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imageformat/); второй – объект [ISvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/) с данными SVG, которые можно получить через [ISvgImage::get_SvgData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/get_svgdata/). SVG, растеризованный во время экспорта, обрабатывается `ImageSaving`.

**Что происходит, когда обработчик сохранения изображения возвращает `false`?**

Aspose.Slides использует своё поведение сохранения по умолчанию. Расположение изображения и сгенерированная ссылка управляются параметрами [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) и [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Может ли обработчик предоставить URL без локального сохранения изображения?**

Да. Обработчик может загрузить изображение в объектное хранилище или передать его в другой сервис, присвоить полученный URL переменной `link` и вернуть `true`. При этом обработчик полностью отвечает за обработку; возврат `true` отключает сохранение по умолчанию.

**Почему при экспорте Markdown из обработчика возникает `InvalidOperationException`?**

Исключение возникает, когда обработчик возвращает `true`, но не предоставляет действительной ссылки. Присвойте относительный путь или внешний URL, который должен быть записан в Markdown, перед возвратом `true`.

**Какой разделитель пути следует использовать в ссылках на изображения?**

В ссылках Markdown и URL используйте прямые слеши. Для путей файловой системы используйте `Path::Combine`, а затем отдельно формируйте или нормализуйте ссылку Markdown.

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [hyperlinks](/slides/ru/cpp/manage-hyperlinks/) сохраняются как обычные ссылки Markdown. Переходы слайдов [transitions](/slides/ru/cpp/slide-transition/) и [animations](/slides/ru/cpp/powerpoint-animation/) не конвертируются.

**Можно ли конвертировать презентации в Markdown параллельно?**

Можно обрабатывать разные файлы презентаций одновременно, но не делите один экземпляр [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) между потоками. Следуйте [multithreading guidelines](/slides/ru/cpp/multithreading/) и используйте отдельный экземпляр для каждого файла.