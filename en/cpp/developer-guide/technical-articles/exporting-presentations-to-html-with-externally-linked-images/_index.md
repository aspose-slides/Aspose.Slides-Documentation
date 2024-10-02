---
title: Exporting Presentations to HTML with Externally Linked Images
type: docs
weight: 50
url: /cpp/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

This article describes an advanced technique that allows controlling which resources are embedded into the resulting HTML file and which are saved externally and referenced from the HTML file.

{{% /alert %}} 
## **Background**
The default HTML export behavior is to embed any resource into the HTML file. Such approach results in a single HTML file that is easy to view and distribute. All necessary resources are base64-encoded inside. But such approach has two drawbacks:

- The size of output is significantly larger because of the base64 encoding. It is difficult to replace the images contained in the file.

In this article we will see how we can change the default behavior using the **Aspose.Slides for C++** to link the images externally rather than embedding in the HTML file. We will use the [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller) interface which contains three methods to control the resource embedding and saving process. We can pass this interface to the[HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) class constructor when preparing the export.

Following is the complete code of the **LinkController** class which implements the [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller) interface. As mentioned before, the **LinkController** must implement the [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller) interface. This interface specifies three methods:

- **LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, String semanticName, String contentType, String recomendedExtension)** It is called when the exporter encounters a resource and needs to decide how to store it. The most important parameters are ‘id’ – the resource unique identifier for the entire export operation and ‘contentType’ – contains the resource MIME type. If we decide to link the resource we should return LinkEmbedDecision::Link from this method. Otherwise, LinkEmbedDecision::Embed should be returned to embed the resource.
- **String GetUrl(int32_t id, int32_t referrer)**
  It is called to get the resource URL in the form how it is used in the resulting file, say for a ```<img src=%method_result_here%>``` tag. The resource is identified by ‘id’.
- **SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData)** 
  The final method of the sequence, it is called when it comes to storing the resource externally. We have the resource identifier and the resource contents as a byte array. It’s up to us what to do with the provided resource data.

``` cpp
/// <summary>
/// This class is responsible for making decisions about the resources saved externally.
/// It must implement the Aspose::Slides::Export::ILinkEmbedController interface.
/// </summary>
class LinkController : public ILinkEmbedController
{
public:
    LinkController()
    {
        m_externalImages = System::MakeObject<Dictionary<int32_t, String>>();
    }
    LinkController::LinkController(String savePath) : LinkController()
    {
        m_savePath = savePath;
    }

    LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, 
        String semanticName, String contentType, String recomendedExtension) override
    {
        // Here we make the decision about storing images externally.
        // The id is unique identifier of each object during the whole export operation.

        String template_;

        // The s_templates dictionary contains content types we are going to store externally and the corresponding file name template.
        if (s_templates->TryGetValue(contentType, template_))
        {
            // Storing this resource to the export list
            m_externalImages->Add(id, template_);
            return LinkEmbedDecision::Link;
        }

        // All other resources, if any, will be embedded
        return LinkEmbedDecision::Embed;
    }

    String GetUrl(int32_t id, int32_t referrer) override
    {
        // Here we construct the resource reference string to form the tag: <img src="%result%">
        // We need to check the dictionary to filter out unnecessary resources.
        // Along with checking we extract the corresponding file name template.
        String template_;
        if (m_externalImages->TryGetValue(id, template_))
        {
            // Assuming we are going to store resource files just near the HTML file.
            // The image tag will look like <img src="image-1.png"> with the appropriate resource Id and extension.
            String fileUrl = String::Format(template_, id);
            return fileUrl;
        }

        // null must be returned for the resources remaining embedded
        return nullptr;
    }

    void SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData) override
    {
        // Here we actually save the resource files to disk.
        // Once again, checking the dictionary. If the id is not found here it is a sign of an error in GetObjectStoringLocation or GetUrl methods.
        if (m_externalImages->ContainsKey(id))
        {
            // Now we use the file name stored in the dictionary and combine it with a path as required.

            // Constructing the file name using the stored template and the Id.
            String fileName = String::Format(m_externalImages->idx_get(id), id);
            
            // Combining with the location directory
            const String savePath = m_savePath != nullptr ? m_savePath : String::Empty;
            String filePath = Path::Combine(savePath, fileName);

            auto fs = System::MakeObject<FileStream>(filePath, FileMode::Create);
            fs->Write(entityData, 0, entityData->get_Length());
        }
        else
        {
            throw Exception(u"Something is wrong");
        }
    }

private:
    String m_savePath;
    SharedPtr<Dictionary<int32_t, String>> m_externalImages;
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

After writing the **LinkController** class, now we will use it with [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) class to export the presentation to HTML having externally linked images using the following code.

``` cpp
const String templatePath = u"../templates/image.pptx";
auto pres = System::MakeObject<Presentation>(templatePath);

auto htmlOptions = System::MakeObject<HtmlOptions>(System::MakeObject<LinkController>(GetOutPath()));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(System::MakeObject<SVGOptions>()));
// This line is needed to remove the slide title display in HTML.
// Comment it out if your prefer slide title displayed.
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));

pres->Save(GetOutPath() + u"/output.html", SaveFormat::Html, htmlOptions);
```

We pass **SlideImageFormat::Svg** to the **set_SlideImageFormat** method which means the resulting HTML file will contain SVG data inside to draw the presentation contents.

As for the content types, it depends on the actual image data contained in the presentation. If there are raster bitmaps in the presentation then the class code must be ready to process both ‘image/jpeg’ and ‘image/png’ content types. The actual content type of the exported raster bitmaps may not match the content type of the images stored in the presentation. The Aspose.Slides for C++ internal algorithms perform size optimization and use either JPG or PNG codec whichever generates smaller data size. Images containing alpha-channel (transparency) are always encoded to PNG.
