---
title: 将演示文稿导出为带有外部链接图像的HTML
type: docs
weight: 50
url: /cpp/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

本文描述了一种高级技术，允许控制哪些资源被嵌入到生成的HTML文件中，以及哪些资源被外部保存并从HTML文件中引用。

{{% /alert %}} 
## **背景**
默认的HTML导出行为是将任何资源嵌入到HTML文件中。这种方法导致生成一个易于查看和分发的单一HTML文件。所有必要的资源都是base64编码在里面。但这种方法有两个缺点：

- 输出文件的大小因base64编码而显著增大。替换文件中包含的图像将变得困难。

在本文中，我们将看到如何使用**Aspose.Slides for C++**更改默认行为，以便将图像链接到外部，而不是嵌入在HTML文件中。我们将使用[ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller)接口，该接口包含三个方法来控制资源的嵌入和保存过程。我们可以在准备导出时将此接口传递给[HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)类构造函数。

以下是实现[ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller)接口的**LinkController**类的完整代码。如前所述，**LinkController**必须实现[ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller)接口。此接口指定了三个方法：

- **LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, String semanticName, String contentType, String recomendedExtension)** 当导出程序遇到资源并需要决定如何存储它时调用。最重要的参数是‘id’——整个导出操作的资源唯一标识符，以及‘contentType’——包含资源的MIME类型。如果我们决定链接资源，则应从此方法返回LinkEmbedDecision::Link。否则，应该返回LinkEmbedDecision::Embed以嵌入资源。
- **String GetUrl(int32_t id, int32_t referrer)**
  用于获取资源URL，其形式是如何在生成的文件中使用的，例如用于```<img src="%method_result_here%">```标签。资源由‘id’标识。
- **SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData)** 
  序列中的最后一个方法，当涉及到将资源外部存储时调用。我们具有资源标识符和作为字节数组的资源内容。我们可以决定如何处理提供的资源数据。

``` cpp
/// <summary>
/// 此类负责决定哪些资源被外部保存。
/// 它必须实现Aspose::Slides::Export::ILinkEmbedController接口。
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
        // 在这里我们决定如何将图像外部存储。
        // id是整个导出操作中每个对象的唯一标识符。

        String template_;

        // s_templates字典包含我们将要外部存储的内容类型及其对应的文件名模板。
        if (s_templates->TryGetValue(contentType, template_))
        {
            // 将此资源存储到导出列表
            m_externalImages->Add(id, template_);
            return LinkEmbedDecision::Link;
        }

        // 其余所有资源（如果有的话）将被嵌入
        return LinkEmbedDecision::Embed;
    }

    String GetUrl(int32_t id, int32_t referrer) override
    {
        // 在这里我们构造资源引用字符串以形成标签：<img src="%result%">
        // 我们需要检查字典以过滤掉不必要的资源。
        // 通过检查，我们提取相应的文件名模板。
        String template_;
        if (m_externalImages->TryGetValue(id, template_))
        {
            // 假设我们将资源文件存储在HTML文件附近。
            // 图像标签将如下所示：<img src="image-1.png">，其中包含适当的资源Id和扩展名。
            String fileUrl = String::Format(template_, id);
            return fileUrl;
        }

        // 对于其余嵌入的资源，必须返回null
        return nullptr;
    }

    void SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData) override
    {
        // 在这里我们实际将资源文件保存到磁盘。
        // 再次检查字典。如果此处未找到id，则意味着在GetObjectStoringLocation或GetUrl方法中出现错误。
        if (m_externalImages->ContainsKey(id))
        {
            // 现在我们使用存储在字典中的文件名，并根据需要将其与路径结合起来。

            // 使用存储的模板和Id构造文件名。
            String fileName = String::Format(m_externalImages->idx_get(id), id);
            
            // 与位置目录结合
            const String savePath = m_savePath != nullptr ? m_savePath : String::Empty;
            String filePath = Path::Combine(savePath, fileName);

            auto fs = System::MakeObject<FileStream>(filePath, FileMode::Create);
            fs->Write(entityData, 0, entityData->get_Length());
        }
        else
        {
            throw Exception(u"出现错误");
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

编写完**LinkController**类后，我们将使用它与[HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)类一起导出演示文稿为带有外部链接图像的HTML，使用以下代码。

``` cpp
const String templatePath = u"../templates/image.pptx";
auto pres = System::MakeObject<Presentation>(templatePath);

auto htmlOptions = System::MakeObject<HtmlOptions>(System::MakeObject<LinkController>(GetOutPath()));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(System::MakeObject<SVGOptions>()));
// 此行用于移除HTML中的幻灯片标题显示。
// 如果您希望显示幻灯片标题，请注释掉它。
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));

pres->Save(GetOutPath() + u"/output.html", SaveFormat::Html, htmlOptions);
```

我们将**SlideImageFormat::Svg**传递给**set_SlideImageFormat**方法，这意味着生成的HTML文件将包含SVG数据以绘制演示文稿内容。

至于内容类型，这取决于演示文稿中包含的实际图像数据。如果演示文稿中有光栅位图，则类代码必须准备处理“image/jpeg”和“image/png”内容类型。导出的光栅位图的实际内容类型可能与存储在演示文稿中的图像的内容类型不匹配。Aspose.Slides for C++内部算法执行大小优化，并使用JPEG或PNG编解码器，以生成较小的数据大小。包含alpha通道（透明度）的图像始终编码为PNG。