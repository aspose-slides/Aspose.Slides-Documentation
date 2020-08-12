---
title: Render Slide As SVG Image
type: docs
weight: 50
url: /net/render-slide-as-svg-image/
---

**Aspose.Slides for .NET** is used to create presentation files, complete with slides. These slides can be viewed by opening presentations using Microsoft PowerPoint. But sometimes, developers may also need to view slides as **SVG** images in their favorite image viewer. In such cases, Aspose.Slides for .NET lets you export an individual slide to an **SVG** image.

To generate an **SVG** image from any desired slide with **Aspose.Slides.Pptx** for .NET, please follow the steps below:

- Create an instance of the **Presentation** class.
- Obtain the desired slide's reference by using its ID or index(here we are using slide index 2).
- Get the SVG image in a memory stream.
- Save the memory stream to file.

```

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Creating Slide SVG Image.svg";

//Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation(srcFileName))

{

    //Access the second slide

    ISlide sld = pres.Slides[1];

    //Create a memory stream object

    MemoryStream SvgStream = new MemoryStream();

    //Generate SVG image of slide and save in memory stream

    sld.WriteAsSvg(SvgStream);

    SvgStream.Position = 0;

    //Save memory stream to file

    using (Stream fileStream = System.IO.File.OpenWrite(destFileName))

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

Below is the result of code:

![todo:image_alt_text](/download/thumbnails/9113703/1609792700)
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Creating%20Slide%20SVG%20Image%20%28Aspose.Slides%29.zip)
