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
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie uma apresentação PowerPoint PPT, PPTX e ODP Hello World em .NET com Aspose.Slides usando tanto as APIs legadas quanto as modernas em um guia simples."
---
{{% alert color="info" %}} 

Um novo [Aspose.Slides for .NET API](/slides/pt/net/) foi lançado e agora este único produto oferece a capacidade de gerar documentos PowerPoint do zero e editar os existentes.

{{% /alert %}} 
## **Suporte a Código Legado**
Para usar o código legado desenvolvido com versões do Aspose.Slides for .NET anteriores à 13.x, você precisa fazer algumas pequenas alterações no seu código e ele continuará funcionando como antes. Todas as classes que estavam presentes no antigo Aspose.Slides for .NET nos namespaces Aspose.Slide e Aspose.Slides.Pptx agora foram mescladas em um único namespace Aspose.Slides. Confira o trecho de código simples a seguir para criar um documento de apresentação Hello World na API legada do Aspose.Slides e siga as etapas que descrevem como migrar para a nova API mesclada.
## **Abordagem Legada do Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Instanciar um objeto Presentation que representa um arquivo PPT
Presentation pres = new Presentation();

//Criar um objeto License
License license = new License();

//Definir a licença do Aspose.Slides for .NET para evitar as limitações de avaliação
license.SetLicense("Aspose.Slides.lic");

//Adicionar um slide vazio à apresentação e obter a referência de
//esse slide vazio
Slide slide = pres.AddEmptySlide();

//Adicionar um retângulo (X=2400, Y=1800, Largura=1000 & Altura=500) ao slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Ocultar as linhas do retângulo
rect.LineFormat.ShowLines = false;

//Adicionar um quadro de texto ao retângulo com "Hello World" como texto padrão
rect.AddTextFrame("Hello World");

//Remover o primeiro slide da apresentação que é sempre adicionado por
//Aspose.Slides for .NET por padrão ao criar a apresentação
pres.Slides.RemoveAt(0);

//Gravar a apresentação como um arquivo PPT
pres.Write("C:\\hello.ppt");
```



## **Abordagem do Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar Presentation
Presentation pres = new Presentation();

// Obter o primeiro slide
ISlide sld = (ISlide)pres.Slides[0];

// Adicionar um AutoShape do tipo Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Adicionar ITextFrame ao Rectangle
ashp.AddTextFrame("Hello World");

// Alterar a cor do texto para preto (que é branco por padrão)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Alterar a cor da linha do rectangle para branco
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remover qualquer formatação de preenchimento na forma
ashp.FillFormat.FillType = FillType.NoFill;

// Salvar a apresentação no disco
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```