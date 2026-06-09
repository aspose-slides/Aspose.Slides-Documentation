---
title: Obter todo o texto em um slide
type: docs
weight: 110
url: /pt/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Obter todo o texto em um slide.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Abrir a apresentação como somente leitura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passar a apresentação e o índice do slide
        // para o próximo método GetAllTextInSlide, e
        // então retornar o array de strings que ele retorna. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Verificar se o documento da apresentação existe.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Verificar se o índice do slide não está fora do intervalo.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Obter a parte da apresentação do documento da apresentação.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Verificar se a parte da apresentação e a apresentação existem.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Obter o objeto Presentation a partir da parte da apresentação.

        Presentation presentation = presentationPart.Presentation;

        // Verificar se a lista de IDs de slides existe.

        if (presentation.SlideIdList != null)

        {

            // Obter a coleção de IDs de slides da lista de IDs de slides.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Se o ID do slide estiver no intervalo...

            if (slideIndex < slideIds.Count)

            {

                // Obter o ID de relacionamento do slide.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Obter a parte do slide especificada a partir do ID de relacionamento.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Passar a parte do slide para o próximo método, e
                // então retornar o array de strings que esse método
                // retorna ao método anterior.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Caso contrário, retornar null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Verificar se a parte do slide existe.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Criar uma nova lista ligada de strings.

    LinkedList<string> texts = new LinkedList<string>();

    // Se o slide existir...

    if (slidePart.Slide != null)

    {

        // Percorrer todos os parágrafos no slide.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Criar um novo StringBuilder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Percorrer as linhas do parágrafo.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Anexar cada linha às linhas anteriores.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Adicionar cada parágrafo à lista ligada.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Retornar um array de strings.

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

// Obter todo o texto em um slide.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Criar uma nova lista ligada de strings.

List<string> texts = new List<string>();

//Instanciar a classe PresentationEx que representa PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    //Acessar o slide

    ISlide sld = pres.Slides[slideIndex];

    //Iterar pelas formas para encontrar o placeholder

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //obter o texto de cada placeholder

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Retornar um array de strings.

return texts;

}

``` 
## **Baixar código de exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)