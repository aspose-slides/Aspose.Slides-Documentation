---
title: Získat veškerý text ve všech snímcích
type: docs
weight: 100
url: /cs/net/get-all-the-text-in-all-the-slides/
---
## **OpenXML SDK**
``` csharp

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

    // Otevřete prezentaci jen pro čtení.
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))
    {
        // Předá prezentaci další metodě CountSlides
        // a vrátí počet snímků.
        return CountSlides(presentationDocument);
    }
}

// Spočítejte snímky v prezentaci.
public static int CountSlides(PresentationDocument presentationDocument)
{
    // Zkontrolujte, zda není objekt dokumentu null.
    if (presentationDocument == null)
    {
        throw new ArgumentNullException("presentationDocument");
    }

    int slidesCount = 0;
    // Získá část prezentace dokumentu.
    PresentationPart presentationPart = presentationDocument.PresentationPart;
    // Získá počet snímků ze SlideParts.
    if (presentationPart != null)
    {
        slidesCount = presentationPart.SlideParts.Count();
    }
    // Vrátí počet snímků předchozí metodě.
    return slidesCount;
}

public static void GetSlideIdAndText(out string sldText, string docName, int index)
{
    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))
    {
        // Získá ID vztahu (relationship ID) prvního snímku.
        PresentationPart part = ppt.PresentationPart;
        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;
        string relId = (slideIds[index] as SlideId).RelationshipId;
        // Získá část snímku podle ID vztahu.
        SlidePart slide = (SlidePart)part.GetPartById(relId);
        // Vytvoří objekt StringBuilder.
        StringBuilder paragraphText = new StringBuilder();
        // Získá vnitřní text snímku:
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

    //Vytvořte instanci třídy PresentationEx, která představuje PPTX
    using (Presentation pres = new Presentation(presentationFile))
    {
        return pres.Slides.Count;
    }

}

public static string GetSlideText(string docName, int index)

{
    string sldText = "";
    //Vytvořte instanci třídy PresentationEx, která představuje PPTX
    using (Presentation pres = new Presentation(docName))
    {
        //Přístup k snímku
        ISlide sld = pres.Slides[index];
        //Iterujte přes tvary a najděte zástupný prvek
        foreach (Shape shp in sld.Shapes)
            if (shp.Placeholder != null)
            {
                //získat text každého zástupného prvku
                sldText += ((AutoShape)shp).TextFrame.Text;
            }
    }
    return sldText;
}

``` 
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)