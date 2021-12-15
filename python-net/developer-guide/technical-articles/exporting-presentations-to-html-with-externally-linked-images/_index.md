---
title: Exporting Presentations to HTML with Externally Linked Images
type: docs
weight: 100
url: /python-net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

This article describes an advanced technique that allows controlling which resources are embedded into the resulting HTML file and which are saved externally and referenced from the HTML file.

{{% /alert %}} 
## **Background**
The default HTML export behavior is to embed any resource into the HTML file. Such approach results in a single HTML file that is easy to view and distribute. All necessary resources are base64-encoded inside. But such approach has two drawbacks:

- The size of output is significantly larger because of the base64 encoding.* It is difficult to replace the images contained in the file.

In this article we will see how we can change the default behavior using the **Aspose.Slides for Python via .NET** to link the images externally rather than embedding in the HTML file. We will use **ILinkEmbedController** interface which contains three methods to control the resource embedding and saving process. We can pass this interface to HtmlOptions class constructor when preparing the export.

Following is the complete code of **LinkController** class which implements the **ILinkEmbedController** interface. As mentioned before, the LinkController must implement ILinkEmbedController interface. This interface specifies three methods:

- **public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)** It is called when the exporter encounters a resource and needs to decide how to store it. The most important parameters are ‘id’ – the resource unique identifier for the entire export operation and ‘contentType’ – contains the resource MIME type. If we decide to link the resource we should return LinkEmbedDecision.Link from this method. Otherwise LinkEmbedDecision.Embed should be returned to embed the resource.
- **public string GetUrl(int id, int referrer)** 
  It is called to get the resource URL in the form how it is used in the resulting file, say for a <img src=”%method_result_here%”> tag. The resource is identified by ‘id’.
- **public void SaveExternal(int id, byte[] entityData)** 
  The final method of the sequence, it is called when it comes to storing the resource externally. We have the resource identifier and the resource contents as a byte array. It’s up to us what to do with the provided resource data.

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

After writing the **LinkController** class, now we will use it with **HTMLOptions** class to export the presentation to HTML having externally linked images using the following code.

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

We assigned **SlideImageFormat.Svg** to the **SlideImageFormat** property which means the resulting HTML file will contain SVG data inside to draw the presentation contents.

As for the content types, it depends on the actual image data contained in the presentation. If there are raster bitmaps in the presentation then the class code must be ready to process both ‘image/jpeg’ and ‘image/png’ content types. The actual content type of raster bitmap images exported may not match that of images stored in the presentation. The Aspose.Slides internal algorithms perform size optimization and use either JPG or PNG codec whichever generates smaller data size. Images containing alpha-channel (transparency) are always encoded to PNG.