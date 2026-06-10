---
title: Egy bekezdés áthelyezése egy prezentációból a másikba
type: docs
weight: 130
url: /hu/net/move-a-paragraph-from-one-presentation-to-another/
---
## **OpenXML Prezentáció**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Áthelyez egy bekezdés tartományt egy TextBody alakzatban a forrás dokumentumban
// egy másik TextBody alakzatba a cél dokumentumban.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// A forrásfájlt megnyitja olvasás/írás módban.
using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // A célfájlt megnyitja olvasás/írás módban.
    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // Lekéri az első diát a forrás prezentációban.
        SlidePart slide1 = GetFirstSlide(sourceDoc);
        // Lekéri az első TextBody alakzatot benne.
        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();
        // Lekéri az első bekezdést a TextBody alakzatban.
        // Megjegyzés: a "Drawing" a DocumentFormat.OpenXml.Drawing névtér álneve
        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();
        // Lekéri az első diát a cél prezentációban.
        SlidePart slide2 = GetFirstSlide(targetDoc);
        // Lekéri az első TextBody alakzatot benne.
        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();
        // Klónozza a forrás bekezdést és beilleszti a klónozott bekezdést a cél TextBody alakzatba.
        // A "true" átadása mély klónt hoz létre, amely a
        // Paragraph objektumot és minden közvetlenül vagy közvetve rá hivatkozó elemet másolja.
        textBody2.Append(p1.CloneNode(true));
        // Eltávolítja a forrás bekezdést a forrásfájlból.
        textBody1.RemoveChild<Drawing.Paragraph>(p1);
        // Lecseréli az eltávolított bekezdést egy helykitöltőre.
        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());
        // Elmenti a diát a forrásfájlban.
        slide1.Slide.Save();
        // Elmenti a diát a célfájlban.
        slide2.Slide.Save();
    }

}

}

// Lekéri az első dia részét a prezentáció dokumentumban.
public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Lekéri az első dia kapcsolatazonosítóját
PresentationPart part = presentationDocument.PresentationPart;
SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();
string relId = slideId.RelationshipId;

// Lekéri a dia részt a kapcsolatazonosító alapján.
SlidePart slidePart = (SlidePart)part.GetPartById(relId);
return slidePart;

}
``` 
## **Aspose.Slides**
Nem ritka, hogy a fejlesztőknek szöveget kell kinyerniük egy prezentációból. Ehhez a prezentáció összes diajának minden alakzatából ki kell nyerni a szöveget. Ez a cikk bemutatja, hogyan lehet a Microsoft PowerPoint PPTX prezentációkból szöveget kinyerni az Aspose.Slides használatával. Legyen szó egy diáról vagy egy egész prezentációról, az Aspose.Slides a PresentationScanner osztályt és a hozzá tartozó statikus metódusokat használja. Mindegyik a [Aspose.Slides.Util](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil) névtérben található.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Áthelyez egy bekezdés tartományt egy TextBody alakzatban a forrás dokumentumban
// egy másik TextBody alakzatba a cél dokumentumban.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //PPTX-et képviselő Presentation osztály példányosítása//PPTX-et képviselő Presentation osztály példányosítása
    Presentation sourcePres = new Presentation(sourceFile);
    //Az első forma elérése az első dián
    IShape shp = sourcePres.Slides[0].Shapes[0];
    if (shp.Placeholder != null)
    {
        //Szöveg lekérése a helykitöltőből
        Text = ((IAutoShape)shp).TextFrame.Text;
        ((IAutoShape)shp).TextFrame.Text = "";
    }

    Presentation destPres = new Presentation(targetFile);
    //Az első forma elérése az első dián
    IShape destshp = sourcePres.Slides[0].Shapes[0];
    if (destshp.Placeholder != null)
    {
        //Szöveg lekérése a helykitöltőből
        ((IAutoShape)destshp).TextFrame.Text += Text;
    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);
    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);
}

}   
``` 
## **Futtató Kódpélda Letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Minta Kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)