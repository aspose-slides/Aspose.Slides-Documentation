---
title: Mover um parágrafo de uma apresentação para outra
type: docs
weight: 130
url: /pt/net/move-a-paragraph-from-one-presentation-to-another/
---
## **Apresentação OpenXML**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Move um intervalo de parágrafo em uma forma TextBody no documento de origem
// para outra forma TextBody no documento de destino.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Abra o arquivo de origem para leitura/escrita.

using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // Abra o arquivo de destino para leitura/escrita.

    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // Obtenha o primeiro slide na apresentação de origem.

        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // Obtenha a primeira forma TextBody nele.

        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // Obtenha o primeiro parágrafo na forma TextBody.

        // Observação: "Drawing" é o alias do namespace DocumentFormat.OpenXml.Drawing

        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // Obtenha o primeiro slide na apresentação de destino.

        SlidePart slide2 = GetFirstSlide(targetDoc);

        // Obtenha a primeira forma TextBody nele.

        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // Clone o parágrafo de origem e insira o parágrafo clonado na forma TextBody de destino.

        // Passar "true" cria um clone profundo, que cria uma cópia do 

        // objeto Paragraph e tudo que é referenciado direta ou indiretamente por esse objeto.

        textBody2.Append(p1.CloneNode(true));

        // Remova o parágrafo de origem do arquivo de origem.

        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // Substitua o parágrafo removido por um placeholder.

        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // Salve o slide no arquivo de origem.

        slide1.Slide.Save();

        // Salve o slide no arquivo de destino.

        slide2.Slide.Save();

    }

}

}

// Obtenha a parte do slide do primeiro slide no documento de apresentação.

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Obtenha o ID de relacionamento do primeiro slide

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Obtenha a parte do slide pelo ID de relacionamento.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}
``` 
## **Aspose.Slides**
Não é incomum que desenvolvedores precisem extrair o texto de uma apresentação. Para isso, é necessário extrair o texto de todas as formas em todos os slides de uma apresentação. Este artigo explica como extrair texto de apresentações Microsoft PowerPoint PPTX usando o Aspose.Slides. Seja extraindo texto de um único slide ou de uma apresentação inteira, o Aspose.Slides usa a classe PresentationScanner e os métodos estáticos que ela expõe. Todos eles estão agrupados no namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Move um intervalo de parágrafo em uma forma TextBody no documento de origem
// para outra forma TextBody no documento de destino.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Instanciar a classe Presentation que representa PPTX//Instanciar a classe Presentation que representa PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Acessar a primeira forma no primeiro slide

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Obter texto do placeholder

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Acessar a primeira forma no primeiro slide

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Obter texto do placeholder

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **Baixar Exemplo de Código Executável**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)