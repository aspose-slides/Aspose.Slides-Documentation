---
title: Export Presentations to HTML with Externally Linked Images
type: docs
weight: 100
url: /net/exporting-presentations-to-html-with-externally-linked-images/
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
- .NET
- C#
- Aspose.Slides
description: "Export PowerPoint and OpenDocument presentations to HTML in .NET using Aspose.Slides with externally linked images—faster pages, code examples, and setup tips."
---

{{% alert color="primary" %}} 

The presentation-to-HTML export process lets you specify:

1. which resources are embedded in the resulting HTML file, and
1. which resources are saved externally and referenced from the HTML file.

{{% /alert %}} 

## **Background**

By default, HTML export embeds all resources directly in the HTML using Base64 encoding. This produces a single, self-contained HTML file that’s convenient for viewing and distribution. However, this approach has drawbacks:

* The resulting file is significantly larger than the original resources because of Base64 overhead.
* Embedded images and other assets are difficult to update or replace.

## **Alternative Approach**

An alternative approach using [ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/) avoids these limitations.

The `LinkController` class below implements [ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/) and is passed to the [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/#constructor_1) constructor. The interface exposes three methods that control how resources are embedded or linked during HTML export:

[GetObjectStoringLocation(id, entityData, semanticName, contentType, recommendedExtension)](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation): Called when the exporter encounters a resource and must decide where to store it. The most important parameters are `id` (the resource’s unique identifier for this export run) and `contentType` (the resource MIME type). Return [LinkEmbedDecision.Link](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) to link the resource, or [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) to embed it.

[GetUrl(id, referrer)](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/geturl/): Returns the URL that will appear in the resulting HTML for the resource identified by `id` (optionally considering the referrer object).

[SaveExternal(id, entityData)](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/saveexternal/): Called when a resource selected for linking needs to be written externally. Because the identifier and contents are provided (as a byte array), you can persist the resource however you like.

The C# `LinkController` implementation of [ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/) follows below.

```cs
class LinkController : ILinkEmbedController
{
    static LinkController()
    {
        s_templates.Add("image/jpeg", "image-{0}.jpg");
        s_templates.Add("image/png", "image-{0}.png");
    }

    /// <summary>
    /// Initializes a new instance of the LinkController class.
    /// </summary>
    public LinkController()
    {
        m_externalImages = new Dictionary<int, string>();
    }

    /// <summary>
    /// Initializes a new instance of the LinkController class and sets the path where generated resource files will be saved.
    /// </summary>
    /// <param name="savePath">Path to the location where generated resource files will be stored.</param>
    public LinkController(string savePath)
        : this()
    {
        SavePath = savePath;
    }

    /// <summary>
    /// Determines whether to embed the resource or store it externally.
    /// </summary>
    /// <param name="id">A unique identifier for each object during the export operation.</param>
    public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)
    {
        string template;

        // The s_templates dictionary maps content types to file name templates for resources stored externally.
        if (s_templates.TryGetValue(contentType, out template))
        {
            // Store this resource for external linking.
            m_externalImages.Add(id, template);
            return LinkEmbedDecision.Link;
        }

        // All other resources are embedded.
        return LinkEmbedDecision.Embed;
    }

    /// <summary>
    /// Builds the URL for a previously externalized resource.
    /// Constructs the resource reference to use in tags such as <img src="%result%">.
    /// Checks the dictionary to exclude resources that were not externalized.
    /// Also retrieves the corresponding file name template.
    /// </summary>
    public string GetUrl(int id, int referrer)
    {
        string template;
        if (m_externalImages.TryGetValue(id, out template))
        {
            // Assumes resource files are stored alongside the HTML file.
            // The image tag will look like <img src="image-1.png"> with the appropriate resource ID and extension.
            var fileUrl = String.Format(template, id);
            return fileUrl;
        }

        // Return null for resources that remain embedded.
        return null;
    }

    /// <summary>
    /// Saves an externalized resource to disk.
    /// Checks the dictionary again. If the ID is not found, it indicates an error in GetObjectStoringLocation or GetUrl.
    /// </summary>
    public void SaveExternal(int id, byte[] entityData)
    {
        if (m_externalImages.ContainsKey(id))
        {
            // Uses the stored file name template and combines it with the target path.
            // Constructs the file name using the stored template and the ID.
            var fileName = String.Format(m_externalImages[id], id);

            // Combines it with the destination directory.
            var filePath = Path.Combine(SavePath ?? String.Empty, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
                fs.Write(entityData, 0, entityData.Length);
        }
        else
            throw new Exception("Something is wrong.");
    }

    /// <summary>
    /// Gets or sets the path where generated resource files are saved.
    /// </summary>
    public string SavePath { get; set; }

    /// <summary>
    /// A dictionary mapping resource IDs to file name templates.
    /// </summary>
    private readonly Dictionary<int, string> m_externalImages;

    /// <summary>
    /// A dictionary mapping content types of externally stored resources to file name templates.
    /// </summary>
    private static readonly Dictionary<string, string> s_templates = new Dictionary<string, string>();
}
```

After implementing the `LinkController` class, you can use it with the [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/) class to export the presentation to HTML with externally linked images, as shown below:

```cs
using (var presentation = new Presentation(@"C:\data\input.pptx"))
{
    var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());
    // This line hides slide titles in the generated HTML.
    // Comment it out if you prefer slide titles to be displayed.
    htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

    presentation.Save(@"C:\data\out\output.html", SaveFormat.Html, htmlOptions);
}
```

We assigned `SlideImageFormat.Svg` to the `SlideImageFormat` property so that the resulting HTML file will contain SVG data to render the presentation’s contents.

Content types: If the presentation contains raster bitmaps, then the class code must be prepared to process both `image/jpeg` and `image/png` content types. The content of the exported bitmap images may not match what was stored in the presentation. Aspose.Slides’ internal algorithms perform size optimization and use either the JPEG or PNG codec (depending on which produces a smaller file size). Images containing an alpha channel (transparency) are always encoded as PNG.
