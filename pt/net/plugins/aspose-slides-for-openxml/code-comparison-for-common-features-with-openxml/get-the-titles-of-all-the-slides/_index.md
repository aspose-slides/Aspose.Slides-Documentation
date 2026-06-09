---
title: Obter os títulos de todos os slides
type: docs
weight: 120
url: /pt/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Obter uma lista dos títulos de todos os slides na apresentação.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Abrir a apresentação como somente leitura.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Obter uma lista dos títulos de todos os slides na apresentação.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Obter um objeto PresentationPart a partir do objeto PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Obter um objeto Presentation a partir do objeto PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Obter o título de cada slide na ordem dos slides.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Obter o título do slide.

                string title = GetSlideTitle(slidePart);

                // Um título vazio também pode ser adicionado.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Obter a string do título do slide.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Declarar um separador de parágrafo.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Encontrar todas as formas de título.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Obter o texto em cada parágrafo desta forma.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Adicionar uma quebra de linha.

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// Determina se a forma é uma forma de título.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Qualquer forma de título.

            case PlaceholderValues.Title:

            // Um título centralizado.

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

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

    // Verificar se o objeto de documento é nulo.
    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obter a parte de apresentação do documento.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obter a contagem de slides a partir dos SlideParts.
    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retornar a contagem de slides para o método anterior.
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
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)