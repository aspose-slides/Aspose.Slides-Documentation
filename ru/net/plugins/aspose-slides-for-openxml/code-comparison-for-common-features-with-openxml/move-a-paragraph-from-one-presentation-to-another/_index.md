---
title: Переместить абзац из одной презентации в другую
type: docs
weight: 130
url: /ru/net/move-a-paragraph-from-one-presentation-to-another/
---

## **OpenXML Презентация**
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

        // Clone the source paragraph and insert the cloned. paragraph into the target TextBody shape.

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
Не редкость, когда разработчикам требуется извлечь текст из презентации. Для этого необходимо получить текст со всех фигур на всех слайдах презентации. В этой статье объясняется, как извлекать текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. Будь то извлечение текста с одного слайда или всей презентации, Aspose.Slides использует класс PresentationScanner и его статические методы. Все они находятся в пространстве имён [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Moves a paragraph range in a TextBody shape in the source document

// to another TextBody shape in the target document.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Instantiate Presentation class that represents PPTX//Instantiate Presentation class that represents PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Access first shape in first slide

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Get text from placeholder

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Access first shape in first slide

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Get text from placeholder

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   

``` 
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)