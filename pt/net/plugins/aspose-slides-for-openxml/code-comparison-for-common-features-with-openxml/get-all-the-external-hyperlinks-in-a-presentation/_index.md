---
title: Obter todos os hiperlinks externos em uma apresentação
type: docs
weight: 90
url: /pt/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **Apresentação OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Retorna todos os hiperlinks externos nos slides de uma apresentação.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Declarar uma lista de strings.

List<string> ret = new List<string>();

// Abrir o arquivo de apresentação como somente leitura.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Percorrer todas as partes de slide na parte da apresentação.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Percorrer todos os links na parte do slide.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Percorrer todos os relacionamentos externos na parte do slide.

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Se o ID do relacionamento coincide com o ID do link...

                if (relation.Id.Equals(link.Id))

                {

                    // Adicionar o URI do relacionamento externo à lista de strings.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Retornar a lista de strings.

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides for .NET permite que os desenvolvedores gerenciem os hiperlinks em uma apresentação nos níveis de apresentação, slide e quadro de texto. A classe **IHyperlinkQueries** ajuda a gerenciar hiperlinks em uma apresentação.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Instanciar um objeto Presentation que representa um arquivo PPTX

Presentation pres = new Presentation(FileName);

//Get the hyperlinks from presentation

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Baixar Exemplo de Código em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)