---
title: Alterar a cor de preenchimento de uma forma em uma apresentação
type: docs
weight: 40
url: /pt/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **Apresentação OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Alterar a cor de preenchimento de uma forma.

// O arquivo de teste deve conter uma forma preenchida como a primeira forma no primeiro slide.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Obter o ID de relacionamento do primeiro slide.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Obter a parte do slide a partir do ID de relacionamento.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Obter a árvore de formas que contém a forma a ser alterada.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Obter a primeira forma na árvore de formas.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Obter o estilo da forma.

                ShapeStyle style = shape.ShapeStyle;

                // Obter a referência de preenchimento.

                Drawing.FillReference fillRef = style.FillReference;

                // Definir a cor de preenchimento como SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Salvar o slide modificado.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
Precisamos seguir os seguintes passos para preencher as formas na apresentação:

- Crie uma instância da classe Presentation.
- Obtenha a referência de um slide usando seu Índice.
- Adicione um IShape ao slide.
- Defina o Tipo de Preenchimento da Shape como Solid.
- Defina a cor da Shape.
- Grave a apresentação modificada como um arquivo PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Instanciar a classe PrseetationEx que representa o PPTX 

using (Presentation pres = new Presentation())

{

    //Obter o primeiro slide

    ISlide sld = pres.Slides[0];

    //Adicionar forma automática do tipo retângulo

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Definir o tipo de preenchimento como Sólido

    shp.FillFormat.FillType = FillType.Solid;

    //Definir a cor do retângulo

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Gravar o arquivo PPTX no disco

    pres.Save(FileName, SaveFormat.Pptx);

}
``` 
## **Baixar Exemplo de Código em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)