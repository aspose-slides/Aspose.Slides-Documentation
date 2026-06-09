---
title: Gerenciar caixas de texto em apresentações no .NET
linktitle: Gerenciar caixa de texto
type: docs
weight: 20
url: /pt/net/manage-textbox/
keywords:
- caixa de texto
- quadro de texto
- adicionar texto
- atualizar texto
- criar caixa de texto
- verificar caixa de texto
- adicionar coluna de texto
- adicionar hyperlink
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "O Aspose.Slides for .NET facilita a criação, edição e clonagem de caixas de texto em arquivos PowerPoint e OpenDocument, aprimorando a automação de suas apresentações."
---
## **Introdução**

Os textos nos slides geralmente existem em caixas de texto ou formas. Portanto, para adicionar texto a um slide, você deve primeiro adicionar uma caixa de texto e, em seguida, colocar algum texto dentro da caixa de texto. 

Para permitir que você adicione uma forma que possa conter texto, o Aspose.Slides for .NET fornece a interface [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

O Aspose.Slides também fornece a interface [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape) para permitir que você adicione formas aos slides. No entanto, nem todas as formas adicionadas através da interface `IShape` podem conter texto. As formas adicionadas através da interface [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape) tipicamente contêm texto. 

Portanto, ao lidar com uma forma existente à qual você deseja adicionar texto, talvez queira verificar e confirmar que ela foi convertida através da interface `IAutoShape`. Só então você poderá trabalhar com [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/properties/textframe), que é uma propriedade da `IAutoShape`. Consulte a seção [Update Text](https://docs.aspose.com/slides/pt/net/manage-textbox/#update-text) nesta página. 

{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation). 
2. Obtenha a referência do primeiro slide por meio de seu índice. 
3. Adicione um objeto [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape) com [ShapeType](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometryshape/properties/shapetype) definido como `Rectangle` em uma posição especificada no slide e obtenha a referência para o objeto `IAutoShape` recém-adicionado. 
4. Adicione a propriedade `TextFrame` ao objeto `IAutoShape` que conterá um texto. No exemplo abaixo, adicionamos este texto: *Aspose TextBox*
5. Finalmente, grave o arquivo PPTX através do objeto `Presentation`. 

Este código C# —uma implementação das etapas acima—mostra como adicionar texto a um slide:

```c#
 // Instancia PresentationEx
 using (Presentation pres = new Presentation())
 {
 
     // Obtém o primeiro slide da apresentação
     ISlide sld = pres.Slides[0];
 
     // Adiciona um AutoShape com o tipo definido como Rectangle
     IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);
 
     // Adiciona TextFrame ao Rectangle
     ashp.AddTextFrame(" ");
 
     // Acessa o quadro de texto
     ITextFrame txtFrame = ashp.TextFrame;
 
     // Cria o objeto Paragraph para o quadro de texto
     IParagraph para = txtFrame.Paragraphs[0];
 
     // Cria um objeto Portion para o parágrafo
     IPortion portion = para.Portions[0];
 
     // Define o texto
     portion.Text = "Aspose TextBox";
 
     // Salva a apresentação no disco
     pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Verificar uma Forma de Caixa de Texto**

O Aspose.Slides fornece a propriedade [IsTextBox](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/istextbox/) da interface [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/), permitindo que você examine formas e identifique caixas de texto. 

![Text box and shape](istextbox.png)

Este código C# mostra como verificar se uma forma foi criada como caixa de texto: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

Observe que se você simplesmente adicionar uma forma automática usando o método `AddAutoShape` da interface [IShapeCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/), a propriedade `IsTextBox` da forma automática retornará `false`. No entanto, depois de adicionar texto à forma automática usando o método `AddTextFrame` ou a propriedade `Text`, a propriedade `IsTextBox` retornará `true`.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox é falso
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox é verdadeiro

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox é falso
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox é verdadeiro

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox é falso
    shape3.AddTextFrame("");
    // shape3.IsTextBox é falso

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox é falso
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox é falso
}
```

## **Adicionar Colunas a uma Caixa de Texto**

O Aspose.Slides fornece as propriedades [ColumnCount](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/properties/columncount) e [ColumnSpacing](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat/properties/columnspacing) (da interface [ITextFrameFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat) e da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat)) para permitir que você adicione colunas a caixas de texto. Você define o número de colunas em uma caixa de texto e, em seguida, especifica o espaçamento em pontos entre as colunas. 

Este código em C# demonstra a operação descrita: 

```c#
using (Presentation presentation = new Presentation())
{
	// Obtém o primeiro slide da apresentação
	ISlide slide = presentation.Slides[0];

	// Adiciona um AutoShape com tipo definido como Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Adiciona TextFrame ao Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Obtém o formato de texto do TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Define o número de colunas no TextFrame
	format.ColumnCount = 3;

	// Define o espaçamento entre as colunas
	format.ColumnSpacing = 10;

	// Salva a apresentação
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Adicionar Colunas a um Quadro de Texto**
O Aspose.Slides for .NET fornece a propriedade [ColumnCount](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/properties/columncount) (da interface [ITextFrameFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat)) que permite adicionar colunas em quadros de texto. Por meio dessa propriedade, você pode especificar o número desejado de colunas em um quadro de texto. 

Este código C# mostra como adicionar uma coluna dentro de um quadro de texto:

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Atualizar Texto**

O Aspose.Slides permite que você altere ou atualize o texto contido em uma caixa de texto ou todos os textos contidos em uma apresentação. 

Este código C# demonstra uma operação em que todos os textos de uma apresentação são atualizados ou alterados:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Verifica se a forma suporta quadro de texto (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Itera pelos parágrafos no quadro de texto
               {
                   foreach (IPortion portion in paragraph.Portions) //Itera por cada porção no parágrafo
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Altera o texto
                       portion.PortionFormat.FontBold = NullableBool.True; //Altera a formatação
                   }
               }
           }
       }
   }
  
   //Salva a apresentação modificada
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Adicionar uma Caixa de Texto com um Hyperlink** 

Você pode inserir um link dentro de uma caixa de texto. Quando a caixa de texto é clicada, os usuários são dirigidos a abrir o link. 

1. Crie uma instância da classe `Presentation`. 
2. Obtenha a referência do primeiro slide por meio de seu índice.  
3. Adicione um objeto `AutoShape` com `ShapeType` definido como `Rectangle` em uma posição especificada no slide e obtenha a referência do objeto AutoShape recém-adicionado.
4. Adicione um `TextFrame` ao objeto `AutoShape` que contém *Aspose TextBox* como texto padrão. 
5. Instancie a classe `IHyperlinkManager`. 
6. Atribua o objeto `IHyperlinkManager` à propriedade [HyperlinkClick](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/properties/hyperlinkclick) associada à porção desejada do `TextFrame`. 
7. Finalmente, grave o arquivo PPTX através do objeto `Presentation`. 

Este código C# —uma implementação das etapas acima—mostra como adicionar uma caixa de texto com um hyperlink a um slide:

```c#
// Instancia uma classe Presentation que representa um PPTX
Presentation pptxPresentation = new Presentation();

// Obtém o primeiro slide da apresentação
ISlide slide = pptxPresentation.Slides[0];

// Adiciona um objeto AutoShape com tipo definido como Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Converte a forma para AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Acessa a propriedade ITextFrame associada ao AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Adiciona algum texto ao quadro
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Define o hyperlink para o texto da porção
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Salva a apresentação PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Qual é a diferença entre uma caixa de texto e um placeholder de texto ao trabalhar com slides mestres?**

Um [placeholder](/slides/pt/net/manage-placeholder/) herda estilo/posição do [master](https://reference.aspose.com/slides/pt/net/aspose.slides/masterslide/) e pode ser sobrescrito nos [layouts](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutslide/), enquanto uma caixa de texto regular é um objeto independente em um slide específico e não muda quando você troca de layout.

**Como posso realizar uma substituição em massa de texto em toda a apresentação sem alterar o texto dentro de gráficos, tabelas e SmartArt?**

Limite sua iteração a auto-shapes que possuem quadros de texto e exclua objetos incorporados ([gráficos](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/), [tabelas](https://reference.aspose.com/slides/pt/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/smartart/)) percorrendo suas coleções separadamente ou ignorando esses tipos de objeto.