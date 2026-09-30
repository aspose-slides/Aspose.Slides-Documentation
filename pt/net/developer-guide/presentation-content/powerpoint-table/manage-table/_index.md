---
title: Gerenciar Tabelas de Apresentação no .NET
linktitle: Gerenciar Tabela
type: docs
weight: 10
url: /pt/net/manage-table/
keywords:
- adicionar tabela
- criar tabela
- acessar tabela
- proporção
- alinhar texto
- formatação de texto
- estilo de tabela
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Criar e editar tabelas em slides do PowerPoint com Aspose.Slides para .NET. Descubra exemplos de código C# simples para simplificar seus fluxos de trabalho com tabelas."
---
## **Introdução**

As tabelas no PowerPoint organizam informações em linhas e colunas, facilitando a leitura e a comparação de valores.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , a interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , a classe [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) , a interface [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em apresentações.

## **Criar uma Tabela do Zero**

Crie uma tabela especificando sua posição, larguras das colunas e alturas das linhas. Depois de adicioná‑la a um slide, você pode formatar bordas das células, mesclar células e inserir texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Defina um array com as larguras das colunas em pontos.
4. Defina um array com as alturas das linhas em pontos.
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ao slide usando o método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) .
6. Percorra cada [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) para aplicar formatação nas bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela.
8. Acesse a célula mesclada por meio da propriedade [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) .
9. Defina o texto na célula mesclada.
10. Salve a apresentação modificada.

O exemplo abaixo cria uma tabela com três colunas e cinco linhas em (100, 50) pontos. Ele aplica bordas vermelhas com largura de 5 pontos, mescla as duas primeiras células da primeira linha e salva o resultado como `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, os índices das células são baseados em zero e usam a ordem (coluna, linha). A primeira célula tem índice (0, 0).

Por exemplo, as células em uma tabela com 4 colunas e 4 linhas são numeradas da seguinte forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este exemplo cria a tabela 4 × 4 ilustrada acima, com larguras de coluna e alturas de linha de 70 pontos e bordas vermelhas de 5 pontos. As coordenadas ilustram os índices das células; o exemplo deixa as células vazias e salva a tabela como `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Acessar uma Tabela Existente**

As tabelas são armazenadas na coleção de formas de um slide. Percorra as formas para localizar uma tabela, então use a interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) para ler ou atualizar suas células.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide que contém a tabela pelo seu índice.
3. Percorra os objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) e pare quando uma tabela for encontrada. Se o slide contiver várias tabelas, use [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) para identificar a que você precisa.
4. Atualize o texto na célula alvo.
5. Salve a apresentação modificada.

O exemplo abaixo abre `UpdateExistingTable.pptx` e encontra a primeira tabela no primeiro slide. Ele define a célula na coluna 0, linha 1 para `New` e salva o resultado como `table1_out.pptx`. A entrada deve conter ao menos um slide, e a primeira tabela naquele slide deve ter ao menos uma coluna e duas linhas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Para redimensionar uma linha em uma tabela existente e entender por que sua altura real pode exceder o mínimo solicitado, veja [Controlar Altura da Linha](/slides/pt/net/manage-rows-and-columns/#control-row-height).

## **Encontrar a Célula que Possui um Quadro de Texto**

Quando um código genérico de processamento de texto recebe um [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) de uma tabela, use a propriedade [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) para recuperar a [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) proprietária. Para um quadro de texto de célula de tabela, [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) está definido e [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) é `null`, embora a própria tabela seja uma forma.

As coordenadas da célula estão disponíveis nas propriedades somente leitura [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) e [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) . [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) também é somente leitura: fornece navegação para o proprietário, mas não altera a propriedade. Sempre verifique se a célula retornada é `null` antes de usá‑la.

Para um exemplo completo que identifica proprietários de células de tabela e de formas, incluindo formas associadas a nós de SmartArt, veja [Pesquisar e Substituir Texto](/slides/pt/net/search-and-replace-text/) .

## **Alinhar Texto em uma Tabela**

Você pode controlar o ancoramento vertical e a direção do texto de células individuais da tabela. O exemplo nesta seção centraliza o texto na primeira célula e o gira 270 graus.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Adicione um objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ao slide.
4. Acesse um objeto [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) da tabela.
5. Acesse o primeiro [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) e defina seu texto e cor.
6. Defina o [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) e o [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) da célula.
7. Salve a apresentação modificada.

Este exemplo cria uma tabela 4 × 4 com larguras de coluna de 120 pontos e alturas de linha de 100 pontos. Ele formata o texto na célula (0, 0), adiciona valores às células restantes da primeira linha e salva o resultado como `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Definir Formatação de Texto no Nível da Tabela**

Use [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) para aplicar formatação de texto a todas as células de uma tabela. Suas sobrecargas aceitam formatação de porção, parágrafo e quadro de texto, permitindo definir essas propriedades sem percorrer as células individualmente.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Acesse um objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) do slide.
4. Defina o [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) para o texto.
5. Defina o [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) e o [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) .
6. Defina o [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) .
7. Salve a apresentação modificada.

O exemplo abaixo abre `table.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Ele define o tamanho da fonte para 25 pontos, alinha os parágrafos à direita com margem direita de 20 pontos e torna o texto vertical. A apresentação formatada é salva como `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Obter Propriedades de Estilo da Tabela**

Use [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) para ler ou atribuir um estilo predefinido a uma tabela. Este exemplo aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) a uma tabela, exibe o nome do preset e atribui o mesmo preset a uma segunda tabela. Ambas as tabelas são salvas em `table-style.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Bloquear Proporção da Tabela**

A proporção da tabela é a razão entre sua largura e sua altura. Use [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) para bloquear essa proporção para uma tabela.

O exemplo abaixo abre `pres.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Ele exibe o estado atual do bloqueio, habilita o bloqueio da proporção, exibe o estado atualizado (`True`) e salva o resultado como `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Posso ativar a direção de leitura da direita para a esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela expõe a propriedade [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) , e os parágrafos possuem [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) . Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como posso impedir que os usuários movam ou redimensionem uma tabela no arquivo final?**

Use [bloqueios de forma](/slides/pt/net/applying-protection-to-presentation/) para desativar mover, redimensionar, selecionar, etc. Esses bloqueios também se aplicam a tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [preenchimento de imagem](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).