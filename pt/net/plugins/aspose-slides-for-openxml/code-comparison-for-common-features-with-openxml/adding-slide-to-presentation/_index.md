---
title: Adicionar Slide à Apresentação
type: docs
weight: 20
url: /pt/net/adding-slide-to-presentation/
---
## **Apresentação OpenXML**
Na funcionalidade abaixo, por padrão, um slide é adicionado à apresentação. Aqui estamos adicionando um novo slide no índice 2 contendo algum texto nele.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Inserir um slide na apresentação especificada.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Abra o documento de origem como leitura/escrita. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Passe o documento de origem, a posição e o título do slide a ser inserido para o próximo método.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Insira o slide especificado na apresentação na posição especificada.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Verifique se a apresentação não está vazia.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Declare e instancie um novo slide.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Construa o conteúdo do slide.            

    // Especifique as propriedades não visuais do novo slide.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Especifique as propriedades de forma do grupo do novo slide.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Declare e instancie a forma de título do novo slide.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Especifique as propriedades de forma necessárias para a forma de título. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Especifique o texto da forma de título.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Declare e instancie a forma de corpo do novo slide.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Especifique as propriedades de forma necessárias para a forma de corpo.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Especifique o texto da forma de corpo.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Crie a parte de slide para o novo slide.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Salve a nova parte de slide.

    slide.Save(slidePart);

    // Modifique a lista de IDs de slides na parte da apresentação.

    // A lista de IDs de slides não deve ser nula.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Encontre o maior ID de slide na lista atual.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // Obtenha o ID do slide anterior.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Use o mesmo layout de slide do slide anterior.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Insira o novo slide na lista de slides após o slide anterior.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Salve a apresentação modificada.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Cada arquivo de apresentação PowerPoint contém um **slide Main Master** e outros **slides Normais**. Isso significa que um arquivo de apresentação contém pelo menos um ou mais slides. É importante saber que arquivos de apresentação sem slides não são suportados pelo Aspose.Slides para .NET. Cada slide tem posição específica e um **Id único**. O **Id do slide** pode variar de 0 a 255 para slides master e de 256 a 65535 para slides normais.

Aspose.Slides para .NET permite que os desenvolvedores adicionem slides vazios às apresentações usando o método **AddEmptySlide** exposto pelo objeto **Presentation**. Para adicionar um slide vazio na apresentação, siga os passos abaixo:

- Crie uma instância da classe Presentation
- Chame o método AddEmptySlide exposto pelo objeto Presentation
- Faça algum trabalho com o slide vazio recém-adicionado
- Adicione outro slide e insira texto nele.
- Finalmente, grave o arquivo PPT usando o método Write exposto pelo objeto Presentation

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Instanciar a classe PresentationEx que representa o arquivo PPT
Presentation pres = new Presentation();

//Um slide em branco é adicionado por padrão, ao criar
//a apresentação a partir do construtor padrão
//Adicionar um slide vazio à apresentação e obter a referência de
//esse slide vazio
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Gravar a saída no disco
pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)