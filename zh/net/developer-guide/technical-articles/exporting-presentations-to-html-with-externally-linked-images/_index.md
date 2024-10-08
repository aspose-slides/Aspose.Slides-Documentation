---
title: 将演示文稿导出为带有外部链接图像的 HTML
type: docs
weight: 100
url: /net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

此演示文稿导出为 HTML 的过程允许您指定：

1. 将嵌入到生成的 HTML 文件中的资源
2. 将外部保存并从 HTML 文件中引用的资源。

{{% /alert %}} 

## **背景**

默认的 HTML 导出行为是通过 base64 编码将所有资源嵌入到 HTML 文件中。此方法输出一个单一的 HTML 文件，便于查看和分发。默认方法存在以下限制： 

* 输出的文件由于基于 base64 编码，大小显著大于其组成部分。
* 文件中包含的图像或资源难以替换。

### **另一种方法**

一种不同的方法涉及 **[ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/)** 避免了上述限制。  

`LinkController` 类实现了 `ILinkEmbedController` 接口。接着该接口被传递给 [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/#constructor) 类的构造函数。ILinkEmbedController 接口包含三个方法，控制资源嵌入和保存过程：

**[GetObjectStoringLocation](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation)(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)**：当导出器遇到资源并必须决定如何存储该资源时调用此方法。*id*（导出操作的资源唯一标识符）和 *contentType*（包含资源的 MIME 类型）是该方法下最重要的参数。如果您希望链接该资源，必须从该方法返回 [LinkEmbedDecision.Link](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) 枚举。否则（嵌入该资源），必须返回 [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/)。

**[GetUrl](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/geturl)(int id, int referrer)**：此方法被调用以按照生成文件的相同方式获取资源 URL。资源由 *id* 标识。

**[SaveExternal](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/saveexternal)(int id, byte[] entityData)**：作为序列中的最后一个方法，当资源需要外部存储时调用它。由于资源标识符和资源内容存在于字节数组中，您可以对资源数据执行各种操作。

以下是 **LinkController** 类实现 **ILinkEmbedController** 接口的 C# 代码：

```c#
class LinkController : ILinkEmbedController
{
    static LinkController()
    {
        s_templates.Add("image/jpeg", "image-{0}.jpg");
        s_templates.Add("image/png", "image-{0}.png");
    }

    /// <summary>
    /// 默认无参数构造函数
    /// </summary>
    public LinkController()
    {
        m_externalImages = new Dictionary<int, string>();
    }

    /// <summary>
    /// 创建类实例并设置生成的资源文件保存的路径。
    /// </summary>
    /// <param name="savePath">生成的资源文件将存储的位置路径。</param>
    public LinkController(string savePath)
        : this()
    {
        SavePath = savePath;
    }

    /// <summary>
    /// A ILinkEmbedController 成员
    /// </summary>
    public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName,
        string contentType,
        string recomendedExtension)
    {
        // 在这里我们决定 externals 存储图像。
        // id 是整个导出操作中每个对象的唯一标识符。

        string template;

        // s_templates 字典包含我们准备外部存储的内容类型及其对应的文件名模板。
        if (s_templates.TryGetValue(contentType, out template))
        {
            // 将该资源存储到导出列表中
            m_externalImages.Add(id, template);
            return LinkEmbedDecision.Link;
        }

        // 所有其他资源（如果有）将被嵌入
        return LinkEmbedDecision.Embed;
    }

    /// <summary>
    /// A ILinkEmbedController 成员
    /// </summary>
    public string GetUrl(int id, int referrer)
    {
        // 在这里我们构建资源引用字符串以形成标记: <img src="%result%">
        // 我们需要检查字典以过滤掉不必要的资源。
        // 在检查过程中提取相应的文件名模板。
        string template;
        if (m_externalImages.TryGetValue(id, out template))
        {
            // 假设我们将资源文件存储在 HTML 文件旁边。
            // 图像标记看起来像 <img src="image-1.png">，其中包含适当的资源 Id 和扩展名。
            var fileUrl = String.Format(template, id);
            return fileUrl;
        }

        // 对于仍然嵌入的资源，必须返回 null
        return null;
    }

    /// <summary>
    /// A ILinkEmbedController 成员
    /// </summary>
    public void SaveExternal(int id, byte[] entityData)
    {
        // 在这里我们实际将资源文件保存到磁盘。
        // 再次检查字典。如果该 id 在这里未找到，则表明 GetObjectStoringLocation 或 GetUrl 方法存在错误。
        if (m_externalImages.ContainsKey(id))
        {
            // 现在我们使用存储在字典中的文件名并将其与路径组合。

            // 使用存储的模板和 Id 构造文件名。
            var fileName = String.Format(m_externalImages[id], id);

            // 与位置目录组合
            var filePath = Path.Combine(SavePath ?? String.Empty, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
                fs.Write(entityData, 0, entityData.Length);
        }
        else
            throw new Exception("发生了错误");
    }

    /// <summary>
    /// 获取或设置生成的资源文件将保存的路径。
    /// </summary>
    public string SavePath { get; set; }

    /// <summary>
    /// 存储资源 Id 和对应文件名之间关系的字典。
    /// </summary>
    private readonly Dictionary<int, string> m_externalImages;

    /// <summary>
    /// 存储我们准备外部存储的资源内容类型
    /// 和对应文件名模板之间关系的字典。
    /// </summary>
    private static readonly Dictionary<string, string> s_templates = new Dictionary<string, string>();
}
```

编写 **LinkController** 类后，我们现在可以与 **HTMLOptions** 类一起使用它以这种方式将演示文稿导出为 HTML，并带有外部链接图像：

```c#
using (var pres = new Presentation(@"C:\data\input.pptx")) {

    var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());
    // 这行代码需要移除在 HTML 中显示幻灯片标题。
    // 如果您希望显示幻灯片标题，请注释掉它。
    htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

    Console.WriteLine("开始导出");
    pres.Save(@"C:\data\out\output.html", SaveFormat.Html, htmlOptions);
}
```

我们将 `SlideImageFormat.Svg` 指定给 `SlideImageFormat` 属性，以便生成的 HTML 文件将包含用于绘制演示文稿内容的 SVG 数据。

内容类型：如果演示文稿包含光栅位图，则类代码必须准备处理 'image/jpeg' 和 'image/png' 内容类型。导出位图图像的内容可能与存储在演示文稿中的内容不匹配。Aspose.Slides 内部算法执行大小优化，并使用 JPG 或 PNG 编解码器（具体取决于哪个产生更小的数据大小）。包含 alpha 通道（透明度）的图像始终编码为 PNG。