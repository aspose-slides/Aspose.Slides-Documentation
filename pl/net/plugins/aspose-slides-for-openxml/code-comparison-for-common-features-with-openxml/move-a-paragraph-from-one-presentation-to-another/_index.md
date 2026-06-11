---
title: Przenieś akapit z jednej prezentacji do drugiej
type: docs
weight: 130
url: /pl/net/move-a-paragraph-from-one-presentation-to-another/
---
## **OpenXML Prezentacja**
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
Nie jest rzadkością, że programiści muszą wyodrębnić tekst z prezentacji. Aby to zrobić, należy wyodrębnić tekst ze wszystkich kształtów na wszystkich slajdach w prezentacji. Ten artykuł wyjaśnia, jak wyodrębnić tekst z prezentacji Microsoft PowerPoint PPTX przy użyciu Aspose.Slides. Niezależnie od tego, czy wyodrębniasz tekst z jednego slajdu, czy całej prezentacji, Aspose.Slides używa klasy PresentationScanner oraz udostępnionych przez nią metod statycznych. Wszystkie znajdują się w przestrzeni nazw [Aspose.Slides.Util](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Przenosi zakres akapitu w kształcie TextBody w dokumencie źródłowym
// do innego kształtu TextBody w dokumencie docelowym.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Instantiate Presentation class that represents PPTX//Instantiate Presentation class that represents PPTX
    //Zainstancjuj klasę Presentation, która reprezentuje plik PPTX//Zainstancjuj klasę Presentation, która reprezentuje plik PPTX
    Presentation sourcePres = new Presentation(sourceFile);

    //Access first shape in first slide
    //Uzyskaj pierwszy kształt na pierwszym slajdzie
    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Get text from placeholder
        //Pobierz tekst z pola zastępczego
        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Access first shape in first slide
    //Uzyskaj pierwszy kształt na pierwszym slajdzie
    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Get text from placeholder
        //Pobierz tekst z pola zastępczego
        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
```
## **Pobierz działający przykład kodu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)