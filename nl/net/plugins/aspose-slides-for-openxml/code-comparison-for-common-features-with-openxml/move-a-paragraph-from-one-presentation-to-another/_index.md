---
title: Verplaats een alinea van de ene presentatie naar de andere
type: docs
weight: 130
url: /nl/net/move-a-paragraph-from-one-presentation-to-another/
---
## **OpenXML-presentatie**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Verplaatst een alinea‑bereik in een TextBody‑vorm in het brondocument
// naar een andere TextBody‑vorm in het doeldocument.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Open het bronbestand als lees/schrijf.
using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))
{

    // Open het doelbestand als lees/schrijf.
    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))
    {

        // Haal de eerste dia op in de bronpresentatie.
        SlidePart slide1 = GetFirstSlide(sourceDoc);
        // Haal de eerste TextBody‑vorm op in die dia.
        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();
        // Haal de eerste alinea op in de TextBody‑vorm.
        // Opmerking: "Drawing" is de alias van de namespace DocumentFormat.OpenXml.Drawing
        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();
        // Haal de eerste dia op in de doelpresentatie.
        SlidePart slide2 = GetFirstSlide(targetDoc);
        // Haal de eerste TextBody‑vorm op in die dia.
        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();
        // Kloon de bronalinea en voeg de gekloonde alinea in de doel‑TextBody‑vorm in.
        // Het doorgeven van "true" maakt een diepe kloon, die een kopie maakt van de 
        // Paragraph‑object en alles wat direct of indirect door dat object wordt gerefereerd.
        textBody2.Append(p1.CloneNode(true));
        // Verwijder de bronalinea uit het bronbestand.
        textBody1.RemoveChild<Drawing.Paragraph>(p1);
        // Vervang de verwijderde alinea door een tijdelijke aanduiding.
        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());
        // Sla de dia op in het bronbestand.
        slide1.Slide.Save();
        // Sla de dia op in het doelbestand.
        slide2.Slide.Save();
    }
}

}

// Haal het dia‑deel op van de eerste dia in het presentatiedocument.

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Haal de relatie‑ID op van de eerste dia
PresentationPart part = presentationDocument.PresentationPart;
SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();
string relId = slideId.RelationshipId;

// Haal het dia‑deel op via de relatie‑ID.
SlidePart slidePart = (SlidePart)part.GetPartById(relId);
return slidePart;

}
``` 
## **Aspose.Slides**
Het is niet ongebruikelijk dat ontwikkelaars de tekst uit een presentatie moeten extraheren. Om dat te doen, moet je de tekst extraheren uit alle vormen op alle dia's in een presentatie. Dit artikel legt uit hoe je tekst uit Microsoft PowerPoint PPTX-presentaties kunt extraheren met behulp van Aspose.Slides. Of je nu tekst uit één dia of uit een volledige presentatie wilt extraheren, Aspose.Slides gebruikt de PresentationScanner-klasse en de statische methoden die deze biedt. Ze zijn allemaal verpakt onder de namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Verplaatst een alinea‑bereik in een TextBody‑vorm in het brondocument
// naar een andere TextBody‑vorm in het doeldocument.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Instantieer de Presentation‑klasse die PPTX vertegenwoordigt//Instantieer de Presentation‑klasse die PPTX vertegenwoordigt
    Presentation sourcePres = new Presentation(sourceFile);

    //Toegang tot eerste vorm op eerste dia
    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Haal tekst op uit placeholder
        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Toegang tot eerste vorm op eerste dia
    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Haal tekst op uit placeholder
        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **Download werkend codevoorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)