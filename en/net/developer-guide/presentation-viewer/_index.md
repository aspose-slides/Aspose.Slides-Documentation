---
title: Presentation Viewer
type: docs
weight: 50
url: /net/presentation-viewer/
keywords: "View PowerPoint presentation, view ppt, view PPTX, C#, Csharp, Aspose.Slides for .NET"
description: "View PowerPoint presentation in C# or .NET "
---



Aspose.Slides for .NET is used to create presentation files, complete with slides. These slides can be viewed by opening presentations using Microsoft PowerPoint. But sometimes, developers may also need to view slides as images in their favorite image viewer or create their own presentation viewer. In such cases, Aspose.Slides for .NET lets you export an individual slide to an image. This article describes how to do it. 
## **Live Example**
You can try [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) free app to see what you can implement with Aspose.Slides API:

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **Generate SVG Image from Slide**
To generate an SVG image from any desired slide with Aspose.Slides.PPTX for .NET, please follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Obtain the desired slide's reference by using its ID or index.
- Get the SVG image in a memory stream.
- Save the memory stream to file.

```c#
// Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("CreateSlidesSVGImage.pptx"))
{

    // Access the first slide
    ISlide sld = pres.Slides[0];

    // Create a memory stream object
    MemoryStream SvgStream = new MemoryStream();

    // Generate SVG image of slide and save in memory stream
    sld.WriteAsSvg(SvgStream);
    SvgStream.Position = 0;

    // Save memory stream to file
    using (Stream fileStream = System.IO.File.OpenWrite("Aspose_out.svg"))
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            fileStream.Write(buffer, 0, len);
        }

    }
    SvgStream.Close();
}
```


## **Generate SVG with Custom Shape IDS**
Aspose.Slides for .NET can be used to generate [SVG ](https://docs.fileformat.com/page-description-language/svg/)from slide with custom shape ID. For that, use ID property from [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape), which represents custom ID of shapes in generated SVG. CustomSvgShapeFormattingController can be used to set shape ID.

```c#
using (Presentation pres = new Presentation("pptxFileName.pptx"))
{
    using (FileStream stream = new FileStream(outputPath, FileMode.OpenOrCreate))
    {
        SVGOptions svgOptions = new SVGOptions
        {
            ShapeFormattingController = new CustomSvgShapeFormattingController()
        };

        pres.Slides[0].WriteAsSvg(stream, svgOptions);
    }
}
```



```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
	private int m_shapeIndex;
	
	public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
	{
		m_shapeIndex = shapeStartIndex;
	}

	public void FormatShape(ISvgShape svgShape, IShape shape)
	{
		svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
	}
}
```


## **Create Slides Thumbnail Image**
Aspose.Slides for .NET help you generate thumbnail images of the slides. To generate the thumbnail of any desired slide using Aspose.Slides for .NET:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

```c#
// Instantiate a Presentation class that represents the presentation file
using (Presentation pres = new Presentation("ThumbnailFromSlide.pptx"))
{

    // Access the first slide
    ISlide sld = pres.Slides[0];

    // Create a full scale image
    Bitmap bmp = sld.GetThumbnail(1f, 1f);

    // Save the image to disk in JPEG format
    bmp.Save("Thumbnail_out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

}
```


## **Create Thumbnail with User Defined Dimensions**
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

```c#
// Instantiate a Presentation class that represents the presentation file
using (Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx"))
{

    // Access the first slide
    ISlide sld = pres.Slides[0];

    // User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Getting scaled value  of X and Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;


    // Create a full scale image
    Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);

    // Save the image to disk in JPEG format
    bmp.Save("Thumbnail2_out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
}
```


## **Create Thumbnail from Slide in Notes Slides View**
To generate the thumbnail of any desired slide in Notes Slide View using Aspose.Slides for .NET:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale in Notes Slide view.
1. Save the thumbnail image in any desired image format.

The code snippet below produces a thumbnail of the first slide of a presentation in Notes Slide View.

```c#
// Instantiate a Presentation class that represents the presentation file
using (Presentation pres = new Presentation("ThumbnailFromSlideInNotes.pptx"))
{
    // Access the first slide
    ISlide sld = pres.Slides[0];

    // User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Getting scaled value  of X and Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

   
    // Create a full scale image                
    Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);
    // Save the image to disk in JPEG format
    bmp.Save("Notes_tnail_out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
}
```

