---
title: Excluir um Slide
type: docs
weight: 80
url: /pt/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Obtenha o objeto de apresentação e passe-o para o próximo método DeleteSlide.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Abra o documento de origem como leitura/gravação.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Passe o documento de origem e o índice do slide a ser excluído para o próximo método DeleteSlide.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Exclua o slide especificado da apresentação.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Use o exemplo CountSlides para obter o número de slides na apresentação.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Obtenha a parte de apresentação do documento de apresentação. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenha a apresentação da parte de apresentação.

    Presentation presentation = presentationPart.Presentation;

    // Obtenha a lista de IDs de slides na apresentação.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Obtenha o ID do slide especificado

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Obtenha o ID de relacionamento do slide.

    string slideRelId = slideId.RelationshipId;

    // Remova o slide da lista de slides.

    slideIdList.RemoveChild(slideId);

    //

    // Remova as referências ao slide de todos os shows personalizados.

    if (presentation.CustomShowList != null)

    {

        // Percorra a lista de shows personalizados.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Declare uma lista ligada de entradas de lista de slides.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Encontre a referência do slide a ser removida do show personalizado.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Remova todas as referências ao slide do show personalizado.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Salve a apresentação modificada.

    presentation.Save();

    // Obtenha a parte do slide para o slide especificado.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Remova a parte do slide.

    presentationPart.DeletePart(slidePart);

}

// Obtenha o objeto de apresentação e passe-o para o próximo método CountSlides.

public static int CountSlides(string presentationFile)

{

    // Abra a apresentação como somente leitura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passe a apresentação para o próximo método CountSlide

        // e retorne a contagem de slides.

        return CountSlides(presentationDocument);

    }

}

// Conte os slides na apresentação.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verifique se o objeto de documento é nulo.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtenha a parte de apresentação do documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenha a contagem de slides a partir dos SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retorne a contagem de slides ao método anterior.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Instanciar um objeto PresentationEx que representa um arquivo PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Acessar um slide usando seu índice na coleção de slides

        ISlide slide = pres.Slides[slideIndex];


        //Remover um slide usando sua referência

        pres.Slides.Remove(slide);


        //Gravar a apresentação como um arquivo PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)