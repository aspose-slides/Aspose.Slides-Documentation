---
title: Exporting Presentations to HTML with Externally Linked Images
type: docs
weight: 100
url: /net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

The Presentation to HTML export procedure here allows you to determine specify the

1. resources that will be embedded into the resulting HTML file
2. the resources that will be saved externally and referenced from the HTML file.

{{% /alert %}} 

## **Background**

The default HTML export behavior is to embed all resources inside the HTML file through base64 encoding. Such an approach outputs a single HTML file, which is convenient for viewing and distribution. The default approach suffers from these limitations: 

* the outputted file is significantly larger than its constituents due to the base64 encoding. 
* the images or resources contained in the file are difficult to replace.

### **A Different Approach**

A different approach involving **[ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/)** avoids the listed limitations.  

The `LinkController` class implements the `ILinkEmbedController` interface. The interface is then passed to the [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/#constructor) class constructor. The ILinkEmbedController interface contains three methods that control the resource embedding and saving process:

**[GetObjectStoringLocation](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation)(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)**: This method is called when the exporter encounters a resource and must decide how to store the resource. *id* (resource unique identifier for the export operation) and *contentType* (containing the resource MIME type) are the most important parameters under the method. If you want to link the resource, you must return [LinkEmbedDecision.Link](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) enum from the method. Otherwise (to embed the resource), you must return [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/).

**[GetUrl](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/geturl)(int id, int referrer)**: This method is called to get the resource URL in the form the same way it is used the resulting file. The resource is identified by *id*.

**[SaveExternal](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/saveexternal)(int id, byte[] entityData)**: As the final method of the sequence, it is called when it is time for the resource to be stored externally. Since the resource identifier and the resource contents exist in a byte array, you can perform all kinds of tasks with the resource data.

This C# code for **LinkController** class implements the **ILinkEmbedController** interface:

```c#
class LinkController : ILinkEmbedController
{
    static LinkController()
    {
        s_templates.Add("image/jpeg", "image-{0}.jpg");
        s_templates.Add("image/png", "image-{0}.png");
    }

    /// <summary>
    /// Default parameterless constructor
    /// </summary>
    public LinkController()
    {
        m_externalImages = new Dictionary<int, string>();
    }

    /// <summary>
    /// Creates a class instance and sets the path where generated resource files will be saved to.
    /// </summary>
    /// <param name="savePath">Path to the location where generated resource files will be stored.</param>
    public LinkController(string savePath)
        : this()
    {
        SavePath = savePath;
    }

    /// <summary>
    /// A ILinkEmbedController member
    /// </summary>
    public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName,
        string contentType,
        string recomendedExtension)
    {
        // Here we make the decision about storing images externally.
        // The id is unique identifier of each object during the whole export operation.

        string template;

        // The s_templates dictionary contains content types we are going to store externally and the corresponding file name template.
        if (s_templates.TryGetValue(contentType, out template))
        {
            // Storing this resource to the export list
            m_externalImages.Add(id, template);
            return LinkEmbedDecision.Link;
        }

        // All other resources, if any, will be embedded
        return LinkEmbedDecision.Embed;
    }

    /// <summary>
    /// A ILinkEmbedController member
    /// </summary>
    public string GetUrl(int id, int referrer)
    {
        // Here we construct the resource reference string to form the tag: <img src="%result%">
        // We need to check the dictionary to filter out unnecessary resources.
        // Along with checking we extract the corresponding file name template.
        string template;
        if (m_externalImages.TryGetValue(id, out template))
        {
            // Assuming we are going to store resource files just near the HTML file.
            // The image tag will look like <img src="image-1.png"> with the appropriate resource Id and extension.
            var fileUrl = String.Format(template, id);
            return fileUrl;
        }

        // null must be returned for the resources remaining embedded
        return null;
    }

    /// <summary>
    /// A ILinkEmbedController member
    /// </summary>
    public void SaveExternal(int id, byte[] entityData)
    {
        // Here we actually save the resource files to disk.
        // Once again, checking the dictionary. If the id is not found here it is a sign of an error in GetObjectStoringLocation or GetUrl methods.
        if (m_externalImages.ContainsKey(id))
        {
            // Now we use the file name stored in the dictionary and combine it with a path as required.

            // Constructing the file name using the stored template and the Id.
            var fileName = String.Format(m_externalImages[id], id);

            // Combining with the location directory
            var filePath = Path.Combine(SavePath ?? String.Empty, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
                fs.Write(entityData, 0, entityData.Length);
        }
        else
            throw new Exception("Something is wrong");
    }

    /// <summary>
    /// Gets or sets the path where generated resource files will be saved to.
    /// </summary>
    public string SavePath { get; set; }

    /// <summary>
    /// A dictionary to store associations between resource ids and corresponding file names.
    /// </summary>
    private readonly Dictionary<int, string> m_externalImages;

    /// <summary>
    /// A dictionary to store associations between content types of resources we are going to store externally
    /// and corresponding file name templates.
    /// </summary>
    private static readonly Dictionary<string, string> s_templates = new Dictionary<string, string>();
}
```

After writing the **LinkController** class, we can now use it alongside **HTMLOptions** class to export the presentation to HTML with externally-linked images this way:

```c#
using (var pres = new Presentation(@"C:\data\input.pptx")) {

    var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());
    // This line is needed to remove the slide title display in HTML.
    // Comment it out if your prefer slide title is displayed.
    htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

    Console.WriteLine("Starting export");
    pres.Save(@"C:\data\out\output.html", SaveFormat.Html, htmlOptions);
}
```

We assigned `SlideImageFormat.Svg` to the `SlideImageFormat` property so that the resulting HTML file will contain SVG data to draw the presentation contents.

Content types: If the presentation contains raster bitmaps, then the class code must be prepared to process both 'image/jpeg' and 'image/png' content types. The content of the exported bitmap images may not match what was stored in the presentation. Aspose.Slides internal algorithms perform size optimization and use either JPG or PNG codec (depending on which generates a smaller data size). Images containing alpha-channel (transparency) are always encoded to PNG.

