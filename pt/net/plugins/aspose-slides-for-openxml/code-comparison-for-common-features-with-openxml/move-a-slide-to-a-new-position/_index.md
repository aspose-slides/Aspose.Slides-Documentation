---
title: Mover um slide para uma nova posição
type: docs
weight: 140
url: /pt/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Contando os slides na apresentação.

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

    // Obter a contagem de slides das SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retornar a contagem de slides ao método anterior.

    return slidesCount;

}

// Mover um slide para uma posição diferente na ordem dos slides na apresentação.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Mover um slide para uma posição diferente na ordem dos slides na apresentação.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Chamar o método CountSlides para obter o número de slides na apresentação.

    int slidesCount = CountSlides(presentationDocument);

    // Verificar se as posições de origem e destino estão dentro do intervalo e são diferentes entre si.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Obter a parte de apresentação do documento de apresentação.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // A contagem de slides não é zero, portanto a apresentação deve conter slides.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Obter o ID do slide de origem.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Identificar a posição do slide de destino após o qual mover o slide de origem.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // Remover o slide de origem da sua posição atual.

    sourceSlide.Remove();

    // Inserir o slide de origem em sua nova posição após o slide de destino.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Salvar a apresentação modificada.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Mover um slide para uma posição diferente na ordem dos slides na apresentação.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Instanciar a classe PresentationEx para carregar o arquivo PPTX de origem

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Obter o slide cuja posição será alterada

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //Definir a nova posição para o slide

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //Gravar o PPTX no disco

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)