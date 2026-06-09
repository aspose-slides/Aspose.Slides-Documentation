---
title: Adicionando Texto Dinamicamente Usando VSTO e Aspose.Slides para .NET
linktitle: Adicionando Texto Dinamicamente
type: docs
weight: 20
url: /pt/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- adicionar texto
- migração
- VSTO
- automação do Office
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Veja como migrar da automação do Microsoft Office para o Aspose.Slides for .NET e adicionar texto dinâmico a apresentações PowerPoint (PPT, PPTX) em C#."
---
{{% alert color="primary" %}} 

Uma tarefa comum que os desenvolvedores precisam realizar é adicionar texto a slides dinamicamente. Este artigo mostra exemplos de código para adicionar texto dinamicamente usando [VSTO](/slides/pt/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) e [Aspose.Slides for .NET](/slides/pt/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Adding Text Dynamically**
Ambos os métodos seguem estas etapas:

1. Criar uma apresentação.
1. Adicionar um slide em branco.
1. Adicionar uma caixa de texto.
1. Definir algum texto.
1. Salvar a apresentação.
## **Exemplo de Código VSTO**
Os trechos de código abaixo resultam em uma apresentação com um slide simples e uma string de texto.

**A apresentação criada no VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Observação: PowerPoint é um namespace que foi definido acima desta forma
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **Exemplo de Aspose.Slides para .NET**
Os trechos de código abaixo usam Aspose.Slides para criar uma apresentação com um slide simples e uma string de texto.

**A apresentação criada usando Aspose.Slides para .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Criar uma apresentação
Presentation pres = new Presentation();

//Slide em branco é adicionado por padrão, ao criar
//apresentação a partir do construtor padrão
//Portanto, não precisamos adicionar nenhum slide em branco
ISlide sld = pres.Slides[1];

//Adicionar uma caixa de texto
//Para adicioná-la, primeiro adicionaremos um retângulo
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Ocultar sua linha
shp.LineFormat.Style = LineStyle.NotDefined;

//Em seguida, adicione uma moldura de texto dentro dela
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Definir um texto
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Gravar a saída no disco
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```