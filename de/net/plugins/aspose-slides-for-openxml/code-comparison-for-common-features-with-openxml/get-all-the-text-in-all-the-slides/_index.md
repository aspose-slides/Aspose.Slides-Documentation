---
title: Holen Sie sich den gesamten Text in allen Folien
type: docs
weight: 100
url: /de/net/get-all-the-text-in-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Holen Sie sich den gesamten Text in einer Folie.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Anzahl der Folien = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Folie #{0} enthält: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Öffnen Sie die Präsentation als schreibgeschützt.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Geben Sie die Präsentation an die nächste CountSlides-Methode weiter

        // und geben Sie die Folienanzahl zurück.

        return CountSlides(presentationDocument);

    }

}

// Zählen Sie die Folien in der Präsentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Prüfen Sie auf ein null-Dokumentobjekt.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Holen Sie sich den Präsentationsteil des Dokuments.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Holen Sie sich die Folienanzahl aus den SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Geben Sie die Folienanzahl an die vorherige Methode zurück.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Holen Sie sich die Beziehungs-ID der ersten Folie.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Holen Sie sich den Folienteil aus der Beziehungs-ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Erstellen Sie ein StringBuilder-Objekt.

        StringBuilder paragraphText = new StringBuilder();

        // Holen Sie sich den inneren Text der Folie:

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
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Holen Sie sich den gesamten Text in einer Folie.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Anzahl der Folien = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Folie #{0} enthält: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //Instanziieren Sie die PresentationEx-Klasse, die PPTX darstellt

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //Instanziieren Sie die PresentationEx-Klasse, die PPTX darstellt

    using (Presentation pres = new Presentation(docName))

    {

        //Zugriff auf die Folie

        ISlide sld = pres.Slides[index];

        //Iterieren Sie durch Formen, um den Platzhalter zu finden

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //Holen Sie sich den Text jedes Platzhalters

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Beispielcode herunterladen**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Holen%20Sie%20sich%20den%20gesamten%20Text%20in%20allen%20Folien%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Holen%20Sie%20sich%20den%20gesamten%20Text%20in%20allen%20Folien%20\(Aspose.Slides\).zip)