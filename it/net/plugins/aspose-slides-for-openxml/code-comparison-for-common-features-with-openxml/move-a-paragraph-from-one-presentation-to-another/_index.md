---
title: Sposta un paragrafo da una presentazione a un'altra
type: docs
weight: 130
url: /it/net/move-a-paragraph-from-one-presentation-to-another/
---
## **Presentazione OpenXML**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Sposta un intervallo di paragrafi in una forma TextBody nel documento sorgente
// verso un\'altra forma TextBody nel documento di destinazione.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Apri il file sorgente in lettura/scrittura.
using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))
{
    // Apri il file di destinazione in lettura/scrittura.
    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))
    {
        // Ottieni la prima diapositiva nella presentazione sorgente.
        SlidePart slide1 = GetFirstSlide(sourceDoc);
        // Ottieni la prima forma TextBody al suo interno.
        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();
        // Ottieni il primo paragrafo nella forma TextBody.
        // Nota: "Drawing" è l'alias dello spazio dei nomi DocumentFormat.OpenXml.Drawing
        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();
        // Ottieni la prima diapositiva nella presentazione di destinazione.
        SlidePart slide2 = GetFirstSlide(targetDoc);
        // Ottieni la prima forma TextBody al suo interno.
        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();
        // Clona il paragrafo sorgente e inserisci il paragrafo clonato nella forma TextBody di destinazione.
        // Passare "true" crea un clone profondo, che crea una copia del 
        // oggetto Paragraph e di tutto ciò che è direttamente o indirettamente referenziato da quell'oggetto.
        textBody2.Append(p1.CloneNode(true));
        // Rimuovi il paragrafo sorgente dal file sorgente.
        textBody1.RemoveChild<Drawing.Paragraph>(p1);
        // Sostituisci il paragrafo rimosso con un segnaposto.
        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());
        // Salva la diapositiva nel file sorgente.
        slide1.Slide.Save();
        // Salva la diapositiva nel file di destinazione.
        slide2.Slide.Save();
    }
}
}

// Ottieni la parte della diapositiva della prima diapositiva nel documento della presentazione.
public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)
{
    // Ottieni l'ID della relazione della prima diapositiva
    PresentationPart part = presentationDocument.PresentationPart;
    SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();
    string relId = slideId.RelationshipId;
    // Ottieni la parte della diapositiva tramite l'ID della relazione.
    SlidePart slidePart = (SlidePart)part.GetPartById(relId);
    return slidePart;
}
``` 
## **Aspose.Slides**
Non è raro che gli sviluppatori debbano estrarre il testo da una presentazione. Per farlo, è necessario estrarre il testo da tutte le forme di tutte le diapositive di una presentazione. Questo articolo spiega come estrarre il testo dalle presentazioni Microsoft PowerPoint PPTX utilizzando Aspose.Slides. Che si tratti di estrarre il testo da una singola diapositiva o da un'intera presentazione, Aspose.Slides utilizza la classe PresentationScanner e i metodi statici che espone. Sono tutti raggruppati nello spazio dei nomi [Aspose.Slides.Util](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Sposta un intervallo di paragrafi in una forma TextBody nel documento sorgente
// verso un'altra forma TextBody nel documento di destinazione.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Instanzia la classe Presentation che rappresenta PPTX//Instanzia la classe Presentation che rappresenta PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Accedi alla prima forma nella prima diapositiva

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Ottieni il testo dal segnaposto

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Accedi alla prima forma nella prima diapositiva

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Ottieni il testo dal segnaposto

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **Scarica esempio di codice eseguibile**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Codice di esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)