---
title: Como Criar Apresentações Hello World em .NET
linktitle: Apresentação Hello World
type: docs
weight: 10
url: /pt/net/how-to-create-hello-world-presentation-document/
keywords:
- migração
- hello world
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
- description: "Crie uma apresentação PowerPoint PPT, PPTX e ODP Hello World em .NET com Aspose.Slides usando tanto as APIs legadas quanto as modernas em um guia simples."
---
{{% alert color="info" %}} 
Uma nova [Aspose.Slides for .NET API](/slides/pt/net/) foi lançada e agora este produto único oferece a capacidade de gerar documentos PowerPoint do zero e editar os existentes.
{{% /alert %}} 
## **Suporte a Código Legado**
Para usar o código legado desenvolvido com versões do Aspose.Slides for .NET anteriores à 13.x, você precisa fazer algumas pequenas alterações no seu código e ele funcionará como antes. Todas as classes que estavam presentes no antigo Aspose.Slides for .NET nos namespaces Aspose.Slide e Aspose.Slides.Pptx agora foram mescladas em um único namespace Aspose.Slides. Confira o trecho de código simples a seguir para criar um documento de Apresentação Hello World na API legada do Aspose.Slides e siga os passos que descrevem como migrar para a nova API mesclada.
## **Abordagem Legada do Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Instancia um objeto Presentation que representa um arquivo PPT
Presentation pres = new Presentation();

//Cria um objeto License
License license = new License();

//Define a licença do Aspose.Slides for .NET para evitar as limitações de avaliação
license.SetLicense("Aspose.Slides.lic");

//Adiciona um slide vazio à apresentação e obtém a referência de
//desse slide vazio
Slide slide = pres.AddEmptySlide();

//Adiciona um retângulo (X=2400, Y=1800, Largura=1000 & Altura=500) ao slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Oculta as linhas do retângulo
rect.LineFormat.ShowLines = false;

//Adiciona um quadro de texto ao retângulo com "Hello World" como texto padrão
rect.AddTextFrame("Hello World");

//Remove o primeiro slide da apresentação que sempre é adicionado por
//Aspose.Slides for .NET por padrão ao criar a apresentação
pres.Slides.RemoveAt(0);

//Grava a apresentação como um arquivo PPT
pres.Write("C:\\hello.ppt");
```



## **Abordagem do Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancia Presentation
Presentation pres = new Presentation();

// Obtém o primeiro slide
ISlide sld = (ISlide)pres.Slides[0];

// Adiciona um AutoShape do tipo Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Adiciona ITextFrame ao Rectangle
ashp.AddTextFrame("Hello World");

// Altera a cor do texto para Preto (que por padrão é Branco)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Altera a cor da linha do retângulo para Branco
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove qualquer formatação de preenchimento na forma
ashp.FillFormat.FillType = FillType.NoFill;

// Salva a apresentação no disco
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```