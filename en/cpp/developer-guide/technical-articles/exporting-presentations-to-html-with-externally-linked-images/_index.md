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
- C++
- Aspose.Slides
description: "Export PowerPoint and OpenDocument presentations to HTML in C++ using Aspose.Slides with externally linked images—faster pages, code examples, and setup tips."
---

{{% alert color="primary" %}}

The presentation-to-HTML export process lets you specify:

1. which resources are embedded in the resulting HTML file, and
1. which resources are saved externally and referenced from the HTML file.

{{% /alert %}}

## **Background**

An alternative approach using [ILinkEmbedController](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/) avoids these limitations.

The `LinkController` class below implements [ILinkEmbedController](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/) and is passed to the [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/htmloptions/#htmloptionshtmloptionssystemsharedptrilinkembedcontroller-constructor) constructor. The interface exposes three methods that control how resources are embedded or linked during HTML export:

[GetObjectStoringLocation(id, entityData, semanticName, contentType, recommendedExtension)](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation): Called when the exporter encounters a resource and must decide where to store it. The most important parameters are `id` (the resource’s unique identifier for this export run) and `contentType` (the resource MIME type). Return [LinkEmbedDecision.Link](https://reference.aspose.com/slides/cpp/aspose.slides.export/linkembeddecision/) to link the resource, or [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/cpp/aspose.slides.export/linkembeddecision/) to embed it.

[GetUrl(id, referrer)](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/geturl/): Returns the URL that will appear in the resulting HTML for the resource identified by `id` (optionally considering the referrer object).

[SaveExternal(id, entityData)](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/): Called when a resource selected for linking needs to be written externally. Because the identifier and contents are provided (as a byte array), you can persist the resource however you like.

The C# `LinkController` implementation of [ILinkEmbedController](https://reference.aspose.com/slides/cpp/aspose.slides.export/ilinkembedcontroller/) follows below.

```cpp
class LinkController : public ILinkEmbedController
{
public:
    // Initializes a new instance of the LinkController class.
    LinkController()
    {
        m_externalImages = System::MakeObject<Dictionary<int32_t, String>>();
    }

    // Initializes a new instance of the LinkController class and sets the path where generated resource files will be saved.
    // savePath - Path to the location where generated resource files will be stored.
    LinkController::LinkController(String savePath) : LinkController()
    {
        m_savePath = savePath;
    }

    // Determines whether to embed the resource or store it externally.
    // id - A unique identifier for each object during the export operation.
    LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, 
        String semanticName, String contentType, String recomendedExtension) override
    {
        String template_;

        // The s_templates dictionary maps content types to file name templates for resources stored externally.
        if (s_templates->TryGetValue(contentType, template_))
        {
            // Store this resource for external linking.
            m_externalImages->Add(id, template_);
            return LinkEmbedDecision::Link;
        }

        // All other resources are embedded.
        return LinkEmbedDecision::Embed;
    }

    // Builds the URL for a previously externalized resource.
    // Constructs the resource reference to use in tags such as <img src="%result%">.
    // Checks the dictionary to exclude resources that were not externalized.
    // Also retrieves the corresponding file name template.
    String GetUrl(int32_t id, int32_t referrer) override
    {
        String template_;
        if (m_externalImages->TryGetValue(id, template_))
        {
            // Assumes resource files are stored alongside the HTML file.
            // The image tag will look like <img src="image-1.png"> with the appropriate resource ID and extension.
            String fileUrl = String::Format(template_, id);
            return fileUrl;
        }

        // Return null for resources that remain embedded.
        return nullptr;
    }

    // Saves an externalized resource to disk.
    // Checks the dictionary again. If the ID is not found, it indicates an error in GetObjectStoringLocation or GetUrl.
    void SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData) override
    {
        // Here we actually save the resource files to disk.
        // Once again, checking the dictionary. If the id is not found here it is a sign of an error in GetObjectStoringLocation or GetUrl methods.
        if (m_externalImages->ContainsKey(id))
        {
            // Uses the stored file name template and combines it with the target path.
            // Constructs the file name using the stored template and the ID.
            String fileName = String::Format(m_externalImages->idx_get(id), id);
            
            // Combines it with the destination directory.
            const String savePath = m_savePath != nullptr ? m_savePath : String::Empty;
            String filePath = Path::Combine(savePath, fileName);

            auto fs = System::MakeObject<FileStream>(filePath, FileMode::Create);
            fs->Write(entityData, 0, entityData->get_Length());
        }
        else
        {
            throw Exception(u"Something is wrong.");
        }
    }

private:
    // The path where generated resource files are saved.
    String m_savePath;

    // A dictionary mapping resource IDs to file name templates.
    SharedPtr<Dictionary<int32_t, String>> m_externalImages;

    // A dictionary mapping content types of externally stored resources to file name templates.
    static SharedPtr<Dictionary<String, String>> s_templates;

    static struct __StaticConstructor__
    {
        __StaticConstructor__()
        {
            s_templates->Add(u"image/jpeg", u"image-{0}.jpg");
            s_templates->Add(u"image/png", u"image-{0}.png");
        }
    } s_constructor__;
};
```

After implementing the `LinkController` class, you can use it with the [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/htmloptions/) class to export the presentation to HTML with externally linked images, as shown below:

```cpp
auto presentation = MakeObject<Presentation>(u"C:\\data\\input.pptx");

auto htmlOptions = MakeObject<HtmlOptions>(MakeObject<LinkController>(u"C:\\data\\out\\"));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(MakeObject<SVGOptions>()));
// This line hides slide titles in the generated HTML.
// Comment it out if you prefer slide titles to be displayed.
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));

presentation->Save(u"C:\\data\\out\\output.html", SaveFormat::Html, htmlOptions);
presentation->Dispose();
```

We assigned `SlideImageFormat::Svg` to the `SlideImageFormat` property so that the resulting HTML file will contain SVG data to render the presentation’s contents.

Content types: If the presentation contains raster bitmaps, then the class code must be prepared to process both `image/jpeg` and `image/png` content types. The content of the exported bitmap images may not match what was stored in the presentation. Aspose.Slides’ internal algorithms perform size optimization and use either the JPEG or PNG codec (depending on which produces a smaller file size). Images containing an alpha channel (transparency) are always encoded as PNG.
