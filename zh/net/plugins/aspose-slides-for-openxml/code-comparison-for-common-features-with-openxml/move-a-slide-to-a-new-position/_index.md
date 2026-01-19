---
title: 将幻灯片移动到新位置
type: docs
weight: 140
url: /zh/net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Counting the slides in the presentation.

public static int CountSlides(string presentationFile)

{

    // Open the presentation as read-only.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Pass the presentation to the next CountSlides method

        // and return the slide count.

        return CountSlides(presentationDocument);

    }

}

// Count the slides in the presentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Check for a null document object.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Get the presentation part of document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Get the slide count from the SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Return the slide count to the previous method.

    return slidesCount;

}

// Move a slide to a different position in the slide order in the presentation.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Move a slide to a different position in the slide order in the presentation.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Call the CountSlides method to get the number of slides in the presentation.

    int slidesCount = CountSlides(presentationDocument);

    // Verify that both from and to positions are within range and different from one another.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Get the presentation part from the presentation document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // The slide count is not zero, so the presentation must contain slides.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Get the slide ID of the source slide.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Identify the position of the target slide after which to move the source slide.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // Remove the source slide from its current position.

    sourceSlide.Remove();

    // Insert the source slide at its new position after the target slide.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Save the modified presentation.

    presentation.Save();

} 

```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Move a slide to a different position in the slide order in the presentation.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Instantiate PresentationEx class to load the source PPTX file

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Get the slide whose position is to be changed

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //Set the new position for the slide

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //Write the PPTX to disk

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)