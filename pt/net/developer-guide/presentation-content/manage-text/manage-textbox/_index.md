---
title: Gerenciar Caixas de Texto em Apresentações em .NET
linktitle: Gerenciar Caixa de Texto
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
- adicionar hiperlink
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Criar, identificar, formatar e atualizar caixas de texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para .NET."
---
## **Introdução**

No Aspose.Slides para .NET, o texto dos slides é armazenado em quadros de texto que pertencem a formas. A interface [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) representa a forma mais comum que contém texto e expõe seu texto através da propriedade [IAutoShape.TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Observação" %}}

Todo auto shape implementa [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/), mas nem toda forma é um auto shape ou suporta um quadro de texto. Ao processar uma apresentação existente, verifique se uma forma implementa `IAutoShape` antes de acessar seu texto.

{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

Para criar uma caixa de texto, adicione um auto shape a um slide, adicione texto ao seu quadro de texto e salve a apresentação. O exemplo a seguir cria uma caixa de texto retangular:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

As coordenadas e dimensões passadas para [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addautoshape/) são medidas em pontos. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/addtextframe/) inicializa o quadro de texto com o texto fornecido.

## **Verificar se a Forma é uma Caixa de Texto**

Use a propriedade [AutoShape.IsTextBox](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/istextbox/) para determinar se um auto shape é tratado como uma caixa de texto. Isso é útil quando uma apresentação contém tanto auto shapes que carregam texto quanto auto shapes puramente gráficos.

![Uma caixa de texto e uma forma](istextbox.png)

O exemplo a seguir inspeciona cada auto shape em uma apresentação:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Um auto shape recém‑adicionado não é considerado uma caixa de texto até que contenha texto não vazio. Você pode fornecer esse texto por meio de [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/addtextframe/) ou [ITextFrame.Text](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/text/). Definir ou atribuir uma string vazia deixa `IsTextBox` definido como `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

As duas primeiras chamadas imprimem `True`; as duas últimas imprimem `False`.

## **Encontrar a Forma que Possui um Quadro de Texto**

Um código genérico de processamento de texto pode receber um [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) sem saber qual objeto da apresentação o contém. Use a propriedade somente‑leitura [ITextFrame.ParentShape](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentshape/) para navegar de volta ao seu [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) proprietário.

Para um quadro de texto pertencente a um auto shape ou outra forma que contenha texto, `ParentShape` contém o proprietário e [ITextFrame.ParentCell](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentcell/) é `null`. Verifique o valor retornado antes de acessá‑lo. Para identificar tanto proprietários de forma quanto de célula de tabela, incluindo formas associadas a nós de SmartArt, consulte [Search and Replace Text](/slides/pt/net/search-and-replace-text/).

## **Adicionar Colunas a uma Caixa de Texto**

A propriedade [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/columncount/) divide o quadro de texto em colunas, enquanto [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/columnspacing/) define o espaço entre colunas em pontos. Ambas as configurações pertencem a [ITextFrameFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/) e podem ser alteradas através do quadro de texto de uma caixa de texto existente. O texto é redistribuído entre as colunas dentro da mesma forma; não continua em outra forma.

O exemplo a seguir cria uma caixa de texto com três colunas e 10 pontos entre elas, salva a apresentação e lê as configurações armazenadas do arquivo de saída:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Extrair Texto de Colunas Individuais**

Use [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/splittextbycolumns/) para obter o texto atribuído a cada coluna visual em um quadro de texto existente. O método retorna uma string para cada coluna, na ordem de leitura baseada em colunas. Um quadro de texto de coluna única produz um array com um elemento, e uma coluna vazia é representada por uma string vazia. As strings contêm apenas texto simples; a formatação em nível de porção não é preservada.

Isso é útil quando você precisa:

- Extrair texto preservando a ordem de leitura baseada em colunas.
- Indexar ou comparar o conteúdo de slides com múltiplas colunas.
- Exportar cada coluna para um arquivo separado, campo de banco de dados ou outro destino.
- Inspecionar como o texto é redistribuído após alterar [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/columnspacing/), a fonte ou o tamanho do quadro de texto.

O método relata o texto distribuído dentro do [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) atual; não flui automaticamente texto entre formas ou caixas de texto separadas. A distribuição em colunas pode depender das fontes disponíveis e de outras configurações de layout de texto, portanto, certifique‑se de que as fontes necessárias estejam disponíveis quando resultados consistentes forem importantes.

O exemplo a seguir carrega uma apresentação, encontra o primeiro auto shape de múltiplas colunas com um quadro de texto, lê sua contagem de colunas configurada e grava o texto de cada coluna em um arquivo separado. Formas que não fornecem um quadro de texto são ignoradas.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Atualizar Texto**

Para atualizar texto em toda a apresentação, itere pelos slides e formas, selecione auto shapes e então edite suas porções de texto. Trabalhar no nível de porção permite alterar tanto o texto quanto a formatação de caracteres.

O exemplo a seguir substitui cada ocorrência de `years` por `months` no texto de auto shapes e torna cada porção afetada em negrito:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Essa travessia atualiza texto apenas em auto shapes. Texto armazenado em tabelas, gráficos, SmartArt ou formas agrupadas requer a travessia das coleções desses objetos.

## **Adicionar uma Caixa de Texto com um Hiperlink**

Um hiperlink pode ser atribuído a uma porção de texto específica, de modo que somente esse texto funcione como link clicável. Use [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) para associar a porção a uma URL externa.

O exemplo a seguir cria texto com link e o salva em uma apresentação:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **Perguntas Frequentes**

**Qual é a diferença entre uma caixa de texto e um placeholder de texto em um slide mestre ou de layout?**

Um [placeholder](/slides/pt/net/manage-placeholder/) pode herdar sua posição e formatação de um [master slide](https://reference.aspose.com/slides/pt/net/aspose.slides/masterslide/) ou [layout slide](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutslide/). Uma caixa de texto regular é uma forma independente no slide onde foi criada e não adquire o comportamento de placeholder quando o layout muda.

**Como posso substituir texto sem alterar o texto em gráficos, tabelas ou SmartArt?**

Limite a travessia às formas que implementam [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/), como mostrado no exemplo de Atualizar Texto. Gráficos, tabelas e SmartArt armazenam texto em seus próprios modelos de objeto, portanto não são modificados por esse loop.