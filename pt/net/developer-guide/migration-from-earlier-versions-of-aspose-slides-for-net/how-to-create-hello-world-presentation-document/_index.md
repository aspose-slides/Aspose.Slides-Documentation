---
title: Como Criar Apresentações Hello World em .NET
linktitle: Apresentação Hello World
type: docs
weight: 10
url: /pt/net/how-to-create-hello-world-presentation-document/
keywords:
- migração
- olá mundo
- código legado
- código moderno
- abordagem legado
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
- description: "Crie uma apresentação PowerPoint PPT, PPTX e ODP Hello World em .NET com Aspose.Slides usando tanto APIs legadas quanto modernas em um guia simples."
---
{{% alert color="primary" %}} 

Uma nova [Aspose.Slides for .NET API](/slides/pt/net/) foi lançada e agora este único produto oferece a capacidade de gerar documentos PowerPoint do zero e editar os existentes.

{{% /alert %}} 
## **Suporte a Código Legado**
Para usar o código legado desenvolvido com Aspose.Slides for .NET em versões anteriores à 13.x, você precisa fazer algumas alterações menores no seu código e ele funcionará como antes. Todas as classes que estavam presentes no antigo Aspose.Slides for .NET nos namespaces Aspose.Slide e Aspose.Slides.Pptx agora foram mescladas em um único namespace Aspose.Slides. Por favor, examine o trecho de código simples a seguir para criar um documento de Apresentação Hello World na API legada do Aspose.Slides e siga os passos que descrevem como migrar para a nova API mesclada.
## **Abordagem Legada do Aspose.Slides for .NET**
```c#
//Instanciar um objeto Presentation que representa um arquivo PPT
Presentation pres = new Presentation();

//Create a License object
License license = new License();

//Set the license of Aspose.Slides for .NET to avoid the evaluation limitations
license.SetLicense("Aspose.Slides.lic");

//Adding an empty slide to the presentation and getting the reference of
//that empty slide
Slide slide = pres.AddEmptySlide();

//Adding a rectangle (X=2400, Y=1800, Width=1000 & Height=500) to the slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Hiding the lines of rectangle
rect.LineFormat.ShowLines = false;

//Adding a text frame to the rectangle with "Hello World" as a default text
rect.AddTextFrame("Hello World");

//Removing the first slide of the presentation which is always added by
//Aspose.Slides for .NET by default while creating the presentation
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```



## **Nova Abordagem do Aspose.Slides for .NET 13.x**
```c#
 // Instanciar Presentation
 Presentation pres = new Presentation();

 // Obter o primeiro slide
 ISlide sld = (ISlide)pres.Slides[0];

 // Adicionar um AutoShape do tipo Retângulo
 IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

 // Adicionar ITextFrame ao Retângulo
 ashp.AddTextFrame("Hello World");

 // Alterar a cor do texto para Preto (que é Branco por padrão)
 ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
 ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

 // Alterar a cor da linha do retângulo para Branco
 ashp.ShapeStyle.LineColor.Color = Color.White;

 // Remover qualquer formatação de preenchimento na forma
 ashp.FillFormat.FillType = FillType.NoFill;

 // Salvar a apresentação no disco
 pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```