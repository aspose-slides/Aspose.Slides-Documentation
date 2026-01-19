---
title: Получить весь текст на слайде
type: docs
weight: 110
url: /ru/net/get-all-the-text-in-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Get all the text in a slide.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Open the presentation as read-only.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Pass the presentation and the slide index

        // to the next GetAllTextInSlide method, and

        // then return the array of strings it returns. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Verify that the presentation document exists.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Verify that the slide index is not out of range.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Get the presentation part of the presentation document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Verify that the presentation part and presentation exist.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Get the Presentation object from the presentation part.

        Presentation presentation = presentationPart.Presentation;

        // Verify that the slide ID list exists.

        if (presentation.SlideIdList != null)

        {

            // Get the collection of slide IDs from the slide ID list.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // If the slide ID is in range...

            if (slideIndex < slideIds.Count)

            {

                // Get the relationship ID of the slide.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Get the specified slide part from the relationship ID.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Pass the slide part to the next method, and

                // then return the array of strings that method

                // returns to the previous method.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Else, return null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Verify that the slide part exists.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Create a new linked list of strings.

    LinkedList<string> texts = new LinkedList<string>();

    // If the slide exists...

    if (slidePart.Slide != null)

    {

        // Iterate through all the paragraphs in the slide.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Create a new string builder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Iterate through the lines of the paragraph.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Append each line to the previous lines.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Add each paragraph to the linked list.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Return an array of strings.

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Get all the text in a slide.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Create a new linked list of strings.

List<string> texts = new List<string>();

//Instantiate PresentationEx class that represents PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    //Access the slide

    ISlide sld = pres.Slides[slideIndex];

    //Iterate through shapes to find the placeholder

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //get the text of each placeholder

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Return an array of strings.

return texts;

}

``` 
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)