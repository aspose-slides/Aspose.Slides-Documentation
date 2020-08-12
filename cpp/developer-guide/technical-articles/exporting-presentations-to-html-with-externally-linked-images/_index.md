---
title: Exporting Presentations to HTML with Externally Linked Images
type: docs
weight: 50
url: /cpp/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

This article describes an advanced technique that allows controlling which resources are embedded into the resulting HTML file and which are saved externally and referenced from the HTML file.

{{% /alert %}} 
#### **Background**
The default HTML export behavior is to embed any resource into the HTML file. Such approach results in a single HTML file that is easy to view and distribute. All necessary resources are base64-encoded inside. But such approach has two drawbacks:

- The size of output is significantly larger because of the base64 encoding.* It is difficult to replace the images contained in the file.

In this article we will see how we can change the default behavior using the **Aspose.Slides for C++** to link the images externally rather than embedding in the HTML file. We will use **ILinkEmbedController** interface which contains three methods to control the resource embedding and saving process. We can pass this interface to HtmlOptions class constructor when preparing the export.

Following is the complete code of **LinkController** class which implements the **ILinkEmbedController** interface. As mentioned before, the LinkController must implement ILinkEmbedController interface. This interface specifies three methods:

- **public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)** It is called when the exporter encounters a resource and needs to decide how to store it. The most important parameters are ‘id’ – the resource unique identifier for the entire export operation and ‘contentType’ – contains the resource MIME type. If we decide to link the resource we should return LinkEmbedDecision.Link from this method. Otherwise LinkEmbedDecision.Embed should be returned to embed the resource.
- **public string GetUrl(int id, int referrer)** 
  It is called to get the resource URL in the form how it is used in the resulting file, say for a <img src=”%method_result_here%”> tag. The resource is identified by ‘id’.
- **public void SaveExternal(int id, byte[] entityData)** 
  The final method of the sequence, it is called when it comes to storing the resource externally. We have the resource identifier and the resource contents as a byte array. It’s up to us what to do with the provided resource data.

[**C#**](/pages/createpage.action?spaceKey=slidescpp&title=C&linkCreation=true&fromPageId=60228440)

```

 /// <summary>

/// This class is responsible for making decisions about the resources saved externally.

/// It must implement the Aspose.Slides.Export.ILinkEmbedController interface.

/// </summary>

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

		:this()

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

After writing the **LinkController** class, now we will use it with **HTMLOptions** class to export the presentation to HTML having externally linked images using the following code.

[**C#**](/pages/createpage.action?spaceKey=slidescpp&title=C&linkCreation=true&fromPageId=60228440)

```

 using (var pres = new Presentation(@"C:\data\input.pptx"))

{

	var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));

	htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());

	// This line is needed to remove the slide title display in HTML.

	// Comment it out if your prefer slide title displayed.

	htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

	Console.WriteLine("Starting export");

	pres.Save(@"C:\data\out\output.html, SaveFormat.Html, htmlOptions);

}

```

We have assign **SlideImageFormat.Svg** to the **SlideImageFormat** property which means the resulting HTML file will contain SVG data inside to draw the presentation contents.

As for the content types, it depends on the actual image data contained in the presentation. If there are raster bitmaps in the presentation then the class code must be ready to process both ‘image/jpeg’ and ‘image/png’ content types. The actual content type of raster bitmap images exported may not match that of images stored in the presentation. The Aspose.Slides internal algorithms perform size optimization and use either JPG or PNG codec whichever generates smaller data size. Images containing alpha-channel (transparency) are always encoded to PNG.
