---
title: Get all the text in all the slides
type: docs
weight: 100
url: /net/get-all-the-text-in-all-the-slides/
---

## **OpenXML SDK**
```

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

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

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Get the relationship ID of the first slide.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Get the slide part from the relationship ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Build a StringBuilder object.

        StringBuilder paragraphText = new StringBuilder();

        // Get the inner text of the slide:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

```
## **Aspose.Slides**
```

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //Instantiate PresentationEx class that represents PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //Instantiate PresentationEx class that represents PPTX

    using (Presentation pres = new Presentation(docName))

    {

        //Access the slide

        ISlide sld = pres.Slides[index];

        //Iterate through shapes to find the placeholder

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //get the text of each placeholder

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

```
## **Download Sample Code**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip)
