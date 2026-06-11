---
title: Flytta ett stycke från en presentation till en annan
type: docs
weight: 130
url: /sv/net/move-a-paragraph-from-one-presentation-to-another/
---
## **OpenXML-presentation**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Moves a paragraph range in a TextBody shape in the source document
// to another TextBody shape in the target document.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{
 // Open the source file as read/write.
using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))
{
    // Open the target file as read/write.
    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))
    {
        // Get the first slide in the source presentation.
        SlidePart slide1 = GetFirstSlide(sourceDoc);
        // Get the first TextBody shape in it.
        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();
        // Get the first paragraph in the TextBody shape.
        // Note: "Drawing" is the alias of namespace DocumentFormat.OpenXml.Drawing
        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();
        // Get the first slide in the target presentation.
        SlidePart slide2 = GetFirstSlide(targetDoc);
        // Get the first TextBody shape in it.
        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();
        // Clone the source paragraph and insert the cloned paragraph into the target TextBody shape.
        // Passing "true" creates a deep clone, which creates a copy of the 
        // Paragraph object and everything directly or indirectly referenced by that object.
        textBody2.Append(p1.CloneNode(true));
        // Remove the source paragraph from the source file.
        textBody1.RemoveChild<Drawing.Paragraph>(p1);
        // Replace the removed paragraph with a placeholder.
        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());
        // Save the slide in the source file.
        slide1.Slide.Save();
        // Save the slide in the target file.
        slide2.Slide.Save();
    }
}
}

// Get the slide part of the first slide in the presentation document.
public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)
{
 // Get relationship ID of the first slide
PresentationPart part = presentationDocument.PresentationPart;
SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();
string relId = slideId.RelationshipId;
 // Get the slide part by the relationship ID.
SlidePart slidePart = (SlidePart)part.GetPartById(relId);
return slidePart;
}
``` 
## **Aspose.Slides**
Det är inte ovanligt att utvecklare behöver extrahera texten från en presentation. För att göra det måste du extrahera text från alla former på alla bilder i en presentation. Denna artikel förklarar hur du extraherar text från Microsoft PowerPoint PPTX-presentationer med hjälp av Aspose.Slides. Oavsett om du extraherar text från en enda bild eller en hel presentation använder Aspose.Slides PresentationScanner‑klassen och de statiska metoder den exponerar. Alla är samlade under namnutrymmet [Aspose.Slides.Util](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Flyttar ett styckeintervall i en TextBody-form i källdokumentet
// till en annan TextBody-form i måldokumentet.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Instansiera Presentation-klassen som representerar PPTX//Instansiera Presentation-klassen som representerar PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Åtkomst till den första formen i den första bilden

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Hämta text från platshållaren

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Åtkomst till den första formen i den första bilden

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Hämta text från platshållaren

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **Ladda ner körande kodexempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)