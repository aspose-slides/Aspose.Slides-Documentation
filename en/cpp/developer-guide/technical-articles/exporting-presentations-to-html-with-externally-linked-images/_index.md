---
title: Export Presentations to HTML with Externally Linked Images
type: docs
weight: 50
url: /cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- export PowerPoint
- export OpenDocument
- export presentation
- export slide
- export PPT
- export PPTX
- export ODP
- PowerPoint to HTML
- OpenDocument to HTML
- presentation to HTML
- slide to HTML
- PPT to HTML
- PPTX to HTML
- ODP to HTML
- linked image
- externally linked image
- linked resource
- external resource
- C++
- Aspose.Slides
description: "Export PowerPoint and OpenDocument presentations to HTML in C++ using Aspose.Slides with images and other resources saved as external linked files."
---

## **Overview**

By default, Aspose.Slides exports a presentation to a self-contained HTML file. Images and other resources are written directly into the HTML, usually as Base64 data. This is convenient when you need one portable file, but it is not always the best format for a website, a CMS, or a server-side conversion pipeline.

Use externally linked resources when you want to:

- reduce the size of the HTML document;
- cache images, fonts, audio, or video separately in a browser or CDN;
- inspect, replace, compress, or post-process generated resources after export;
- keep the output structure closer to what a web application expects.

For the general HTML conversion workflow, see [Convert PowerPoint Presentations to HTML](/slides/cpp/convert-powerpoint-to-html/). This article focuses on the resource-linking part of the export.

## **How Linked Resource Export Works**

[ILinkEmbedController](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/) lets your application decide, resource by resource, whether the exporter embeds the data in the HTML or saves it externally and writes a link.

The interface has three methods:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) decides whether a resource should be linked or embedded.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) returns the URL that will be written to the generated HTML or to another linked resource.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) writes the linked resource data to disk or to another storage target.

The file system path and the browser URL are separate concerns. For example, the sample below writes resource files to `html-output/assets` on disk, while the HTML contains relative URLs such as `assets/resource-1.svg`. A browser resolves those URLs relative to the file that contains the link. Therefore, a link from `presentation.html` to an SVG file uses `assets/resource-1.svg`, while a link from that SVG file to an image saved in the same `assets` folder uses `resource-4.jpg`.

## **Export HTML with Linked Resources**

The following C++ example creates an output directory, saves the HTML file there, and stores linked resources in an `assets` subdirectory. The controller links common image, font, audio, video, and CSS resources when Aspose.Slides provides or can infer a safe file extension. Resources that are not recognized remain embedded.

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

After the export, the output folder has this structure:

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

The exact files depend on the presentation content and export options. For example, raster images are commonly exported as JPEG or PNG. Aspose.Slides may choose a different image codec than the one used in the source presentation when that produces a smaller or more suitable file. Images with transparency are exported as PNG.

## **Choosing URLs for Deployment**

The sample uses a relative URL prefix: `assets/`. If `presentation.html` is opened from `html-output/presentation.html`, the browser loads `html-output/assets/resource-1.svg`.

When one linked resource refers to another linked resource, the sample uses the `referrer` parameter in [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) and returns only the file name. For example, if `resource-1.svg` and `resource-4.jpg` are both in the `assets` folder, the SVG file should refer to `resource-4.jpg`, not to `assets/resource-4.jpg`.

Use a different URL prefix when the files are deployed elsewhere:

- Use `assets/` when the asset directory is next to the HTML file.
- Use `../assets/` when the asset directory is one level above the HTML file.
- Use `https://cdn.example.com/presentations/job-123/assets/` when the files are uploaded to a CDN or static file server.

The URL returned by [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) must match the final deployed location of the file written by [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). In server applications, use a unique output directory or object-storage prefix for each conversion job to avoid overwriting files from another export.

## **When to Embed Instead**

Embedded Base64 HTML is still useful when the output must be a single file, such as an email attachment, an offline preview, or a document that will be moved without a supporting asset folder. Linked resources are a better fit when the HTML will be served by a web application, stored in a CMS, optimized by a build pipeline, or cached by browsers independently from the HTML.

## **FAQ**

**Can I externalize only images and keep other resources embedded?**

Yes. In [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), return `LinkEmbedDecision::Link` only for the content types you want to save as separate files, and return `LinkEmbedDecision::Embed` for everything else.

**Why does the exported image extension differ from the source presentation?**

Aspose.Slides may re-encode raster images during HTML export to improve size or browser compatibility. For example, an image from the source file may be written as JPEG or PNG depending on the rendered result.

**Do relative URLs work after I move the HTML file?**

Relative URLs work only when the same relative folder structure is preserved. If the HTML references `assets/resource-1.png`, the `assets` folder must stay next to the HTML file unless you generate a different URL prefix.

**Should server applications reuse the same output folder?**

No. Use a unique output directory or storage prefix for each conversion job. This avoids filename collisions and prevents one export from overwriting resources generated by another export.
