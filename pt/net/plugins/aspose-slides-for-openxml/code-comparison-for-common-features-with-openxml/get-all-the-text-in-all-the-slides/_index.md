---
title: Obter todo o texto em todos os slides
type: docs
weight: 100
url: /pt/net/get-all-the-text-in-all-the-slides/
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

    // Abrir a apresentação como somente leitura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passar a apresentação para o próximo método CountSlides

        // e retornar a contagem de slides.

        return CountSlides(presentationDocument);

    }

}

// Contar os slides na apresentação.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verificar se o objeto do documento é nulo.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obter a parte de apresentação do documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obter a contagem de slides das SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retornar a contagem de slides ao método anterior.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Obter o ID de relacionamento do primeiro slide.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Obter a parte do slide a partir do ID de relacionamento.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Construir um objeto StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Obter o texto interno do slide:

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

    //Instanciar a classe PresentationEx que representa PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //Instanciar a classe PresentationEx que representa PPTX

    using (Presentation pres = new Presentation(docName))

    {

        //Acessar o slide

        ISlide sld = pres.Slides[index];

        //Iterar através das formas para encontrar o placeholder

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //obter o texto de cada placeholder

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Baixar código de exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)