---
title: Gerenciar Tabelas de Apresentação em .NET
linktitle: Gerenciar Tabela
type: docs
weight: 10
url: /pt/net/manage-table/
keywords:
- adicionar tabela
- criar tabela
- acessar tabela
- proporção de aspecto
- alinhar texto
- formatação de texto
- estilo de tabela
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie e edite tabelas em slides do PowerPoint com Aspose.Slides para .NET. Descubra exemplos simples de código C# para otimizar seu fluxo de trabalho com tabelas."
---
## **Introdução**

Uma tabela no PowerPoint é uma maneira eficiente de exibir e apresentar informações. As informações em uma grade de células (organizadas em linhas e colunas) são simples e fáceis de entender.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/net/aspose.slides/table/) , a interface [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) , a classe [Cell](https://reference.aspose.com/slides/pt/net/aspose.slides/cell/) , a interface [ICell](https://reference.aspose.com/slides/pt/net/aspose.slides/icell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em todos os tipos de apresentações. 

## **Criar uma Tabela do Zero**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) .
2. Obtenha a referência de um slide através do seu índice. 
3. Defina um array de `columnWidth` .
4. Defina um array de `rowHeight` .
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) ao slide usando o método [AddTable](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addtable/) .
6. Itere por cada [ICell](https://reference.aspose.com/slides/pt/net/aspose.slides/icell/) para aplicar formatação nas bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela. 
8. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) de um [ICell](https://reference.aspose.com/slides/pt/net/aspose.slides/icell/) .
9. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) .
10. Salve a apresentação modificada.

Este código C# mostra como criar uma tabela em uma apresentação:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancia uma classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();

// Acessa o primeiro slide
ISlide sld = pres.Slides[0];

// Define colunas com larguras e linhas com alturas
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Adiciona uma forma de tabela ao slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Define o formato da borda para cada célula
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}

// Mescla as células 1 e 2 da linha 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Adiciona algum texto à célula mesclada
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Salva a apresentação no disco
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, a numeração das células é simples e baseada em zero. A primeira célula em uma tabela tem índice 0,0 (coluna 0, linha 0). 

Por exemplo, as células de uma tabela com 4 colunas e 4 linhas são numeradas da seguinte forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código C# cria a tabela padrão 4 × 4 numerada acima e define o formato da borda para cada uma de suas células:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancia uma classe Presentation que representa um arquivo PPTX
using (Presentation pres = new Presentation())
{

    // Acessa o primeiro slide
    ISlide sld = pres.Slides[0];

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adiciona uma forma de tabela ao slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Define o formato da borda para cada célula
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Salva a apresentação no disco
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Acessar uma Tabela Existente**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) .

2. Obtenha uma referência ao slide que contém a tabela através do seu índice. 

3. Crie um objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) e defina‑o como null.

4. Itere por todos os objetos [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) até que a tabela seja encontrada.

   Se você suspeitar que o slide em questão contém uma única tabela, pode simplesmente verificar todas as formas que ele contém. Quando uma forma é identificada como uma tabela, você pode fazer cast para um objeto [Table](https://reference.aspose.com/slides/pt/net/aspose.slides/table/) . Mas se o slide contiver várias tabelas, é melhor procurar a tabela necessária através de seu [AlternativeText](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/alternativetext/) .

5. Use o objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) para trabalhar com a tabela. No exemplo abaixo, adicionamos uma nova linha à tabela.

6. Salve a apresentação modificada.

Este código C# mostra como acessar e trabalhar com uma tabela existente:

```c#
using Aspose.Slides;

// Instancia uma classe Presentation que representa um arquivo PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Acessa o primeiro slide
    ISlide sld = pres.Slides[0];

    // Inicializa a TableEx nula
    ITable tbl = null;

    // Itera pelas formas e define uma referência para a tabela encontrada
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Define o texto para a primeira coluna da segunda linha
    tbl[0, 1].TextFrame.Text = "New";

    // Salva a apresentação modificada no disco
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Encontrar a Célula que Possui um TextFrame**

Quando um código genérico de processamento de texto recebe um [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) de uma tabela, use a propriedade [ITextFrame.ParentCell](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentcell/) para obter o [ICell](https://reference.aspose.com/slides/pt/net/aspose.slides/icell/) proprietário. Para um TextFrame de célula de tabela, [ITextFrame.ParentCell](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentcell/) está definido e [ITextFrame.ParentShape](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentshape/) é `null`, embora a tabela em si seja uma forma.

As coordenadas da célula estão disponíveis nas propriedades somente leitura [ICell.FirstColumnIndex](https://reference.aspose.com/slides/pt/net/aspose.slides/icell/firstcolumnindex/) e [ICell.FirstRowIndex](https://reference.aspose.com/slides/pt/net/aspose.slides/icell/firstrowindex/) . [ITextFrame.ParentCell](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/parentcell/) também é somente leitura: fornece navegação para o proprietário, mas não altera a propriedade. Sempre verifique se a célula retornada é `null` antes de usá‑la.

Para um exemplo completo que identifica proprietários de células de tabela e formas, incluindo formas associadas a nós de SmartArt, veja [Search and Replace Text](/slides/pt/net/search-and-replace-text/) .

## **Alinhar Texto em uma Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) .
2. Obtenha a referência de um slide através do seu índice. 
3. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) ao slide. 
4. Acesse um objeto [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) da tabela. 
5. Acesse o [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/) do [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) .
6. Alinhe o texto verticalmente.
7. Salve a apresentação modificada.

Este código C# mostra como alinhar o texto em uma tabela:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Cria uma instância da classe Presentation
Presentation presentation = new Presentation();

// Obtém o primeiro slide 
ISlide slide = presentation.Slides[0];

// Define colunas com larguras e linhas com alturas
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adiciona a forma de tabela ao slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Acessa o quadro de texto
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Cria o objeto Paragraph para o quadro de texto
IParagraph paragraph = txtFrame.Paragraphs[0];

// Cria o objeto Portion para o parágrafo
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Alinha o texto verticalmente
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Salva a apresentação no disco
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Definir Formatação de Texto no Nível da Tabela**

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) classe.
2. Obtenha a referência de um slide através do seu índice. 
3. Acesse um objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) do Slide.
4. Defina o [FontHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/fontheight/) para o texto. 
5. Defina o [Alignment](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/alignment/) e [MarginRight](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/marginright/) . 
6. Defina o [TextVerticalType](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat/textverticaltype/) .
7. Salve a apresentação modificada. 

Este código C# mostra como aplicar suas opções de formatação preferidas ao texto em uma tabela:

```c#
using Aspose.Slides;

// Cria uma instância da classe Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Vamos supor que a primeira forma no primeiro slide seja uma tabela

// Define a altura da fonte das células da tabela
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Define o alinhamento de texto e a margem direita das células da tabela em uma única chamada
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Define o tipo vertical de texto das células da tabela
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Obter Propriedades de Estilo da Tabela**

Aspose.Slides permite recuperar as propriedades de estilo de uma tabela para que você possa usar esses detalhes em outra tabela ou em outro local. Este código C# mostra como obter as propriedades de estilo a partir de um estilo predefinido de tabela: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // altera o tema padrão do preset de estilo 

    // Obtém o preset de estilo da tabela.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Aplica o preset de estilo obtido a outra tabela.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Bloquear Proporção de Aspecto de uma Tabela**

A proporção de aspecto de uma forma geométrica é a razão entre seus tamanhos em diferentes dimensões. Aspose.Slides fornece a propriedade `AspectRatioLocked` para permitir que você bloqueie a configuração de proporção de aspecto para tabelas e outras formas. 

Este código C# mostra como bloquear a proporção de aspecto para uma tabela:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // inverter

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela expõe a propriedade [RightToLeft](https://reference.aspose.com/slides/pt/net/aspose.slides/table/righttoleft/) , e os parágrafos possuem [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraphformat/righttoleft/) . Usar ambas garante a ordem RTL correta e a renderização dentro das células.

**Como posso impedir que usuários movam ou redimensionem uma tabela no arquivo final?**

Use os [shape locks](/slides/pt/net/applying-protection-to-presentation/) para desabilitar movimentação, redimensionamento, seleção etc. Esses bloqueios também se aplicam a tabelas.

**É suportado inserir uma imagem dentro de uma célula como fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).