---
title: Экспорт презентаций в HTML с внешне связанными изображениями
type: docs
weight: 50
url: /ru/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- экспорт слайда
- экспорт PPT
- экспорт PPTX
- экспорт ODP
- PowerPoint в HTML
- OpenDocument в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- ODP в HTML
- связанное изображение
- внешне связанное изображение
- связанный ресурс
- внешний ресурс
- C++
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в HTML на C++ с использованием Aspose.Slides, при котором изображения и другие ресурсы сохраняются как внешние связанные файлы."
---
## **Обзор**

По умолчанию Aspose.Slides экспортирует презентацию в автономный HTML‑файл. Изображения и другие ресурсы записываются непосредственно в HTML, обычно в виде данных Base64. Это удобно, когда нужен один переносимый файл, но не всегда является лучшим форматом для веб‑сайта, CMS или серверного конвейера конвертации.

Используйте внешние связанные ресурсы, когда вы хотите:

- уменьшить размер HTML‑документа;
- кешировать изображения, шрифты, аудио или видео отдельно в браузере или CDN;
- проверять, заменять, сжимать или пост‑обрабатывать сгенерированные ресурсы после экспорта;
- поддерживать структуру вывода ближе к тому, что ожидает веб‑приложение.

Для общего процесса конвертации в HTML см. статью [Convert PowerPoint Presentations to HTML](/slides/ru/cpp/convert-powerpoint-to-html/). Эта статья сосредоточена на части экспорта, связанной с ресурсами.

## **Как работает экспорт со связанными ресурсами**

[ILinkEmbedController](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ilinkembedcontroller/) позволяет вашему приложению решать для каждого ресурса, встраивать данные в HTML или сохранять их внешне и записывать ссылку.

У интерфейса есть три метода:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) определяет, должен ли ресурс быть связан или встроен.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) возвращает URL, который будет записан в сгенерированный HTML или в другой связанный ресурс.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) записывает данные связанного ресурса на диск или в другое хранилище.

Путь в файловой системе и URL в браузере — это отдельные понятия. Например, пример ниже записывает файлы ресурсов в `html-output/assets` на диске, тогда как HTML содержит относительные URL‑ы вроде `assets/resource-1.svg`. Браузер разрешает эти URL‑ы относительно файла, содержащего ссылку. Поэтому ссылка из `presentation.html` к SVG‑файлу использует `assets/resource-1.svg`, а ссылка из этого SVG‑файла к изображению, сохранённому в той же папке `assets`, использует `resource-4.jpg`.

## **Экспорт HTML с связанными ресурсами**

Следующий пример на C++ создаёт каталог вывода, сохраняет в нём HTML‑файл и хранит связанные ресурсы в подпапке `assets`. Контроллер связывает обычные изображения, шрифты, аудио, видео и CSS‑ресурсы, когда Aspose.Slides предоставляет или может вывести безопасное расширение файла. Неопознанные ресурсы остаются встроенными.

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
```

После экспорта в выходной папке будет такая структура:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Точные файлы зависят от содержания презентации и параметров экспорта. Например, растровые изображения обычно экспортируются как JPEG или PNG. Aspose.Slides может выбрать иной кодек изображения, чем использовался в исходной презентации, если это даёт меньший или более подходящий файл. Изображения с прозрачностью экспортируются как PNG.

## **Выбор URL‑ов для развертывания**

Пример использует относительный префикс URL: `assets/`. Если `presentation.html` открыт из `html-output/presentation.html`, браузер загрузит `html-output/assets/resource-1.svg`.

Когда один связанный ресурс ссылается на другой связанный ресурс, пример использует параметр `referrer` в [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) и возвращает только имя файла. Например, если `resource-1.svg` и `resource-4.jpg` находятся в папке `assets`, SVG‑файл должен ссылаться на `resource-4.jpg`, а не на `assets/resource-4.jpg`.

Используйте другой префикс URL, когда файлы развернуты в другом месте:

- Используйте `assets/`, когда каталог с ресурсами находится рядом с HTML‑файлом.
- Используйте `../assets/`, когда каталог с ресурсами находится на один уровень выше HTML‑файла.
- Используйте `https://cdn.example.com/presentations/job-123/assets/`, когда файлы загружены в CDN или на статический файловый сервер.

URL, возвращаемый [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ilinkembedcontroller/geturl/), должен соответствовать окончательному месту размещения файла, записанного [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). В серверных приложениях используйте уникальный каталог вывода или префикс хранилища для каждой задачи конвертации, чтобы избежать перезаписи файлов от другого экспорта.

## **Когда лучше встраивать**

Встроенный Base64 HTML по‑прежнему полезен, когда вывод должен быть одним файлом, например вложением в электронную почту, офлайн‑предпросмотром или документом, который будет перемещён без папки с ресурсами. Связанные ресурсы лучше подходят, когда HTML будет обслуживаться веб‑приложением, храниться в CMS, оптимизироваться конвейером сборки или кешироваться браузерами независимо от HTML.

## **FAQ**

**Могу ли я вынести наружу только изображения и оставить остальные ресурсы встроенными?**

Да. В [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) возвращайте `LinkEmbedDecision::Link` только для тех типов контента, которые хотите сохранять отдельными файлами, и `LinkEmbedDecision::Embed` для всего остального.

**Почему расширение экспортированного изображения отличается от оригинального в презентации?**

Aspose.Slides может перекодировать растровые изображения при экспорте в HTML, чтобы уменьшить размер или повысить совместимость с браузерами. Например, изображение из исходного файла может быть записано как JPEG или PNG в зависимости от результата рендеринга.

**Работают ли относительные URL после перемещения HTML‑файла?**

Относительные URL работают только при сохранении той же относительной структуры папок. Если HTML ссылается на `assets/resource-1.png`, папка `assets` должна оставаться рядом с HTML‑файлом, если только вы не генерируете иной префикс URL.

**Должны ли серверные приложения переиспользовать один и тот же каталог вывода?**

Нет. Используйте уникальный каталог вывода или префикс хранилища для каждой задачи конвертации. Это устраняет конфликты имён файлов и предотвращает перезапись ресурсов, созданных другим экспортом.