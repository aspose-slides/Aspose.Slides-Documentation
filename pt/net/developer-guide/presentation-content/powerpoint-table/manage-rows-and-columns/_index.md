---
title: Gerenciar Linhas e Colunas em Tabelas do PowerPoint no .NET
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
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides para .NET e acelere a edição de apresentações e a atualização de dados."
---
## **Introdução**

Para permitir que você gerencie as linhas e colunas de uma tabela em uma apresentação PowerPoint, o Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/net/aspose.slides/table/) a interface [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) e muitos outros tipos. 

## **Definir a Primeira Linha como Cabeçalho**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e carregue a apresentação. 
2. Obtenha a referência de um slide por seu índice. 
3. Crie um objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) e atribua null a ele. 
4. Itere por todos os objetos [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) para encontrar a tabela correspondente. 
5. Defina a primeira linha da tabela como seu cabeçalho. 

Este código C# mostra como definir a primeira linha de uma tabela como cabeçalho:

```c#
// Instancia a classe Presentation
Presentation pres = new Presentation("table.pptx");

// Acessa o primeiro slide
ISlide sld = pres.Slides[0];

// Inicializa a TableEx nula
ITable tbl = null;

// Itera pelos shapes e define uma referência para a tabela
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Define a primeira linha da tabela como seu cabeçalho
tbl.FirstRow = true;

// Salva a apresentação no disco
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Clonar uma Linha ou Coluna de Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e carregue a apresentação, 
2. Obtenha a referência de um slide por seu índice. 
3. Defina um array de `columnWidth`. 
4. Defina um array de `rowHeight`. 
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) ao slide usando o método [AddTable](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addtable/). 
6. Clone a linha da tabela. 
7. Clone a coluna da tabela. 
8. Salve a apresentação modificada. 

Este código C# mostra como clonar a linha ou coluna de uma tabela do PowerPoint:

```c#
 // Instancia a classe Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Acessa o primeiro slide
    ISlide sld = presentation.Slides[0];

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Adiciona um shape de tabela ao slide
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Adiciona algum texto à célula 1 da linha 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Adiciona algum texto à célula 2 da linha 1
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Clona a Linha 1 no final da tabela
    table.Rows.AddClone(table.Rows[0], false);

    // Adiciona algum texto à célula 1 da linha 2
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Adiciona algum texto à célula 2 da linha 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Clona a Linha 2 como a 4ª linha da tabela
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Clona a primeira coluna no final
    table.Columns.AddClone(table.Columns[0], false);

    // Clona a segunda coluna no índice da 4ª coluna
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Salva a apresentação no disco 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Remover uma Linha ou Coluna de uma Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e carregue a apresentação, 
2. Obtenha a referência de um slide por seu índice. 
3. Defina um array de `columnWidth`. 
4. Defina um array de `rowHeight`. 
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) ao slide usando o método [AddTable](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addtable/). 
6. Remova a linha da tabela. 
7. Remova a coluna da tabela. 
8. Salve a apresentação modificada. 

Este código C# mostra como remover uma linha ou coluna de uma tabela:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Definir Formatação de Texto no Nível de Linha da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e carregue a apresentação, 
2. Obtenha a referência de um slide por seu índice. 
3. Acesse o objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) relevante a partir do slide. 
4. Defina a [FontHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/fontheight/) das células da primeira linha. 
5. Defina o [Alignment](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/alignment/) e o [MarginRight](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/marginright/) das células da primeira linha. 
6. Defina o [TextVerticalType](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat/textverticaltype/) das células da segunda linha. 
7. Salve a apresentação modificada. 

Este código C# demonstra a operação.

```c#
// Cria uma instância da classe Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Vamos supor que o primeiro shape no primeiro slide seja uma tabela

// Define a altura da fonte das células da primeira linha
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Define o alinhamento de texto e a margem direita das células da primeira linha
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Define o tipo vertical do texto das células da segunda linha
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Salva a apresentação no disco
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Definir Formatação de Texto no Nível de Coluna da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e carregue a apresentação, 
2. Obtenha a referência de um slide por seu índice. 
3. Acesse o objeto [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) relevante a partir do slide. 
4. Defina a [FontHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/fontheight/) das células da primeira coluna. 
5. Defina o [Alignment](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/alignment/) e o [MarginRight](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/marginright/) das células da primeira coluna. 
6. Defina o [TextVerticalType](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat/textverticaltype/) das células da segunda coluna. 
7. Salve a apresentação modificada. 

Este código C# demonstra a operação: 

```c#
// Cria uma instância da classe Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Vamos supor que o primeiro shape no primeiro slide seja uma tabela

// Define a altura da fonte das células da primeira coluna
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Define o alinhamento de texto e a margem direita das células da primeira coluna em uma única chamada
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Define o tipo vertical do texto das células da segunda coluna
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Salva a apresentação no disco
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Obter Propriedades de Estilo da Tabela**

Aspose.Slides permite recuperar as propriedades de estilo de uma tabela para que você possa usar esses detalhes em outra tabela ou em outro lugar. Este código C# mostra como obter as propriedades de estilo de um estilo predefinido de tabela: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // alterar o tema de estilo pré-definido padrão 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Perguntas Frequentes**

**Posso aplicar temas/estilos do PowerPoint a uma tabela já criada?**

Sim. A tabela herda o tema do slide/layout/master e você ainda pode sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso ordenar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem ordenação ou filtros incorporados. Ordene seus dados na memória primeiro e, em seguida, repovoar as linhas da tabela nessa ordem.

**Posso ter colunas em faixa (listradas) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas em faixa e, em seguida, sobrescreva células específicas com formatação local; a formatação a nível de célula tem precedência sobre o estilo da tabela.