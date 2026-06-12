---
title: Přesunout odstavec z jedné prezentace do druhé
type: docs
weight: 130
url: /cs/net/move-a-paragraph-from-one-presentation-to-another/
---
## **OpenXML Prezentace**
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
Není neobvyklé, že vývojáři potřebují extrahovat text z prezentace. K tomu je třeba extrahovat text ze všech tvarů na všech snímcích v prezentaci. Tento článek vysvětluje, jak pomocí Aspose.Slides extrahovat text z prezentací Microsoft PowerPoint PPTX. Ať už extrahujete text z jednoho snímku nebo celé prezentace, Aspose.Slides používá třídu PresentationScanner a její statické metody. Všechny jsou umístěny v jmenném prostoru [Aspose.Slides.Util](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Přesune rozsah odstavce ve tvaru TextBody ve zdrojovém dokumentu
// do jiného tvaru TextBody v cílovém dokumentu.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Vytvořit instanci třídy Presentation, která představuje PPTX//Vytvořit instanci třídy Presentation, která představuje PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Přístup k prvnímu tvaru na první snímku

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Získat text z placeholderu

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Přístup k prvnímu tvaru na první snímku

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Získat text z placeholderu

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **Stáhnout spuštěný příklad kódu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)