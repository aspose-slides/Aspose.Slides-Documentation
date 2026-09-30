---
title: Gerenciar Linhas e Colunas em Tabelas PowerPoint no .NET
linktitle: Linhas e Colunas
type: docs
weight: 20
url: /pt/net/manage-rows-and-columns/
keywords:
- linha da tabela
- coluna da tabela
- primeira linha
- cabeçalho da tabela
- clonar linha
- clonar coluna
- copiar linha
- copiar coluna
- remover linha
- remover coluna
- formatação de texto da linha
- formatação de texto da coluna
- estilo da tabela
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides para .NET e acelere a edição de apresentações e atualizações de dados."
---
## **Introdução**

Aspose.Slides for .NET permite que você gerencie a estrutura e formatação de tabelas em apresentações do PowerPoint através da classe [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) e da interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Você pode designar uma linha de cabeçalho, clonar ou remover linhas e colunas e aplicar formatação de texto a uma linha ou coluna inteira.

Este artigo explica essas operações com exemplos em C#. Ele também mostra como recuperar o preset de estilo de uma tabela para que você possa reutilizá‑lo. Os índices de linhas e colunas da tabela são baseados em zero.

## **Controlar a Altura da Linha**

Use [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) para definir a altura mínima de uma linha em pontos. É um limite inferior, não uma altura fixa. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) retorna a altura real e é somente leitura. Acesse a linha via [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

O exemplo carrega [row-height-input.pptx](row-height-input.pptx), que contém uma tabela como a primeira forma no primeiro slide. Sua primeira linha começa em 70 pontos. As células usam texto Arial de 18 pt, com quebra de linha e margens superior e inferior de 6 pt; o texto mais longo na segunda coluna quebra em várias linhas. O exemplo aumenta o mínimo para 100 pt, depois diminui para 20 pt, imprime a altura real após cada alteração e salva ambos os resultados.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Com a apresentação fornecida, aumentar o mínimo adiciona espaço à linha. Diminuí‑lo remove esse espaço extra, mas a altura real permanece maior que 20 pt porque o texto e as margens das células precisam de mais espaço. Reduzir apenas o mínimo não pode forçar a linha abaixo do espaço exigido pelo seu conteúdo.

Vários fatores afetam a altura real:

- **Texto e tamanho da fonte:** texto mais longo, quebras de linha explícitas ou uma fonte maior podem exigir mais espaço vertical.
- **Quebra de linha e largura da coluna:** com quebra de linha habilitada, uma [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) mais estreita pode gerar mais linhas. Uma coluna mais larga pode reduzir o espaço necessário verticalmente.
- **Margens da célula:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) e [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) adicionam espaço vertical. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) e [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) reduzem a largura disponível para o texto e podem causar quebra de linha adicional.

Para esta tabela sem células mescladas, a célula que necessita de mais espaço vertical determina o limite inferior orientado por conteúdo para toda a linha. Para encurtar a linha, pode ser necessário encurtar o texto, reduzir o tamanho da fonte ou as margens, ou alargar uma coluna.

As imagens abaixo mostram a mesma tabela na mesma escala. Nesta execução, as alturas reais foram 70, 100 e 55,2 pt: a linha final permaneceu mais alta que seu mínimo de 20 pt. Medições exatas de texto podem variar conforme as fontes disponíveis no seu ambiente. Baixe os resultados salvos: [mínimo aumentado](row-height-increased.pptx) e [mínimo diminuído](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Diminuído: mínimo 20 pt, real 55.2 pt |
| --- | --- | --- |
| ![Tabela original com a primeira linha de 70 pontos.](row-height-before.png) | ![Tabela após aumentar o mínimo da primeira linha para 100 pontos.](row-height-increased.png) | ![Tabela após diminuir o mínimo da primeira linha para 20 pontos; o texto quebrado mantém a linha mais alta que o mínimo.](row-height-decreased.png) |

## **Definir a Primeira Linha como Cabeçalho**

Use a propriedade [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) para marcar a primeira linha para formatação de cabeçalho. Sua aparência depende do estilo de tabela aplicado à tabela.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Acesse a tabela armazenada como a primeira forma no slide.
4. Habilite a formatação de cabeçalho para a primeira linha.
5. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide. Ele habilita a formatação de cabeçalho para a primeira linha e salva `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Clonar uma Linha ou Coluna da Tabela**

Clone linhas ou colunas para reutilizar seu conteúdo e formatação. Você pode anexar uma cópia ao final da tabela ou inseri‑la em uma posição específica.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e alturas das linhas.
4. Adicione uma tabela com o método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Clone as linhas necessárias.
6. Clone as colunas necessárias.
7. Salve a apresentação modificada.

O exemplo requer `Test.pptx` com ao menos um slide. Ele cria uma tabela com três colunas e cinco linhas, com dimensões especificadas em pontos. Anexa cópias da primeira linha e coluna, depois insere cópias da segunda linha e coluna no índice 3 (a quarta posição). A tabela resultante tem sete linhas e cinco colunas. O argumento `false` desabilita a clonagem em linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Remover uma Linha ou Coluna de uma Tabela**

Remova linhas ou colunas que não são mais necessárias em uma tabela. Remover um item desloca os índices das linhas ou colunas que o seguem.

1. Crie uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e alturas das linhas.
4. Adicione uma tabela com o método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Remova a segunda linha e a segunda coluna.
6. Salve a apresentação modificada.

Este exemplo cria uma tabela 3 × 3 e remove a linha e a coluna no índice 1, resultando em uma tabela 2 × 2 em `TestTable_out.pptx`. As dimensões estão em pontos. O argumento `false` desabilita a remoção de linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Definir Formatação de Texto no Nível da Linha da Tabela**

Aplique formatação de texto a uma linha inteira para manter a consistência das células. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Defina [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) para a primeira linha.
4. Defina [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) e [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) para a primeira linha.
5. Defina [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) para a segunda linha.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide e ao menos duas linhas. Ele aplica texto de 25 pt, alinhamento à direita e margem direita de parágrafo de 20 pt à primeira linha, depois define texto vertical na segunda linha.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Definir Formatação de Texto no Nível da Coluna da Tabela**

Aplique formatação de texto a uma coluna inteira para manter a consistência das células. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Defina [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) para a primeira coluna.
4. Defina [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) e [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) para a primeira coluna.
5. Defina [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) para a segunda coluna.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide e ao menos duas colunas. Ele aplica texto de 25 pt, alinhamento à direita e margem direita de parágrafo de 20 pt à primeira coluna, depois define texto vertical na segunda coluna.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Obter Propriedades de Estilo da Tabela**

Use a propriedade [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) para recuperar o preset aplicado a uma tabela e reutilizá‑lo em outra tabela. Isso identifica o preset em vez de substituições individuais de formatação de célula.

O exemplo cria uma tabela, aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), e lê o preset de volta. Ele imprime `DarkStyle1` e salva a tabela em `table.pptx`.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Posso aplicar temas/estilos do PowerPoint a uma tabela que já foi criada?**

Sim. A tabela herda o tema do slide/layout/master e você ainda pode sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso ordenar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem classificação ou filtros embutidos. Classifique seus dados em memória primeiro e, em seguida, repopule as linhas da tabela nessa ordem.

**Posso ter colunas listradas mantendo cores personalizadas em células específicas?**

Sim. Ative colunas listradas e depois sobrescreva células específicas com formatação local; a formatação ao nível da célula tem precedência sobre o estilo da tabela.