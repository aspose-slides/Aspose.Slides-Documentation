---
title: Získat celý text ve snímku
type: docs
weight: 110
url: /cs/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Získat celý text ve snímku.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Otevřít prezentaci jen pro čtení.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Předat prezentaci a index snímku

        // do další metody GetAllTextInSlide a

        // poté vrátit pole řetězců, které tato metoda vrátí. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Ověřit, že existuje dokument prezentace.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Ověřit, že index snímku není mimo rozsah.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Získat část prezentace z dokumentu prezentace.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ověřit, že část prezentace a samotná prezentace existují.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Získat objekt Presentation z části prezentace.

        Presentation presentation = presentationPart.Presentation;

        // Ověřit, že existuje seznam ID snímků.

        if (presentation.SlideIdList != null)

        {

            // Získat kolekci ID snímků ze seznamu ID snímků.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Pokud je ID snímku v rozsahu...

            if (slideIndex < slideIds.Count)

            {

                // Získat ID vztahu (relationship ID) snímku.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Získat specifikovanou část snímku z ID vztahu.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Předat část snímku do další metody a

                // poté vrátit pole řetězců, které tato metoda

                // vrátí předchozí metodě.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Jinak vrátit null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Ověřit, že část snímku existuje.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Vytvořit nový propojený seznam řetězců.

    LinkedList<string> texts = new LinkedList<string>();

    // Pokud snímek existuje...

    if (slidePart.Slide != null)

    {

        // Projít všechny odstavce ve snímku.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Vytvořit nový StringBuilder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Projít řádky odstavce.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Připojit každý řádek k předchozím řádkům.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Přidat každý odstavec do propojeného seznamu.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Vrátit pole řetězců.

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

// Získat celý text ve snímku.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Vytvořit nový propojený seznam řetězců.

List<string> texts = new List<string>();

// Vytvořit instanci třídy PresentationEx, která představuje PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    // Přístup k snímku

    ISlide sld = pres.Slides[slideIndex];

    // Procházet tvary a najít zástupný prvek

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // získat text každého zástupného prvku

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Vrátit pole řetězců.

return texts;

}

```
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)