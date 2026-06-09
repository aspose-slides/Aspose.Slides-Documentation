---
title: Gerenciar séries de dados de gráficos em apresentações no .NET
linktitle: Séries de dados
type: docs
url: /pt/net/chart-series/
keywords:
- séries de gráfico
- sobreposição de séries
- cor da série
- cor da categoria
- nome da série
- ponto de dados
- espaço da série
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a gerenciar séries de gráficos em C# para PowerPoint (PPT/PPTX) com exemplos de código práticos e boas práticas para melhorar suas apresentações de dados."
---
## **Visão geral**

Este artigo descreve o papel de [ChartSeries](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartseries/) no Aspose.Slides for .NET, focando em como os dados são estruturados e visualizados em apresentações. Esses objetos fornecem os elementos fundamentais que definem conjuntos individuais de pontos de dados, categorias e parâmetros de aparência em um gráfico. Ao trabalhar com [ChartSeries](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartseries/), os desenvolvedores podem integrar fontes de dados subjacentes de forma perfeita e manter controle total sobre como as informações são exibidas, resultando em apresentações dinâmicas e orientadas por dados que transmitem claramente insights e análises.

Uma série é uma linha ou coluna de números plotados em um gráfico.

![série-de-gráfico-powerpoint](chart-series-powerpoint.png)

## **Definir a Sobreposição da Série de Gráfico**

A propriedade [IChartSeriesOverlap](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/properties/overlap) controla como barras e colunas se sobrepõem em um gráfico 2D ao especificar um intervalo de -100 a 100. Como essa propriedade está associada ao grupo de séries e não a uma série individual, ela é somente leitura no nível da série. Para configurar valores de sobreposição, use a propriedade `ParentSeriesGroup.Overlap` de leitura/gravação, que aplica a sobreposição especificada a todas as séries naquele grupo.

Abaixo está um exemplo em C# que demonstra como criar uma apresentação, adicionar um gráfico de colunas agrupadas, acessar a primeira série do gráfico, configurar a definição de sobreposição e, em seguida, salvar o resultado como um arquivo PPTX:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicionar um gráfico de colunas agrupadas com dados padrão.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Definir a sobreposição da série.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Salvar o arquivo de apresentação no disco.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A sobreposição da série](series_overlap.png)

## **Alterar a Cor de Preenchimento da Série**

Aspose.Slides facilita a personalização das cores de preenchimento das séries de gráfico, permitindo que você destaque pontos de dados específicos e crie gráficos visualmente atraentes. Isso é realizado por meio do objeto [IFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/iformat/), que oferece vários tipos de preenchimento, configurações de cores e outras opções avançadas de estilo. Após adicionar um gráfico a um slide e acessar a série desejada, basta obter a série e aplicar a cor de preenchimento apropriada. Além de preenchimentos sólidos, você também pode usar preenchimentos em gradiente ou padrão para maior flexibilidade de design. Depois de definir as cores conforme suas necessidades, salve a apresentação para finalizar a aparência atualizada.

O exemplo de código C# a seguir mostra como alterar a cor da primeira série:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicionar um gráfico de colunas agrupadas com dados padrão.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Definir a cor da primeira série.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Salvar o arquivo de apresentação no disco.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A cor da série](series_color.png)

## **Alterar o Nome da Série** 

Aspose.Slides oferece uma maneira simples de modificar os nomes das séries de gráfico, facilitando a rotulagem dos dados de forma clara e significativa. Ao acessar a célula da planilha relevante nos dados do gráfico, os desenvolvedores podem personalizar a forma como as informações são apresentadas. Essa modificação é particularmente útil quando os nomes das séries precisam ser atualizados ou esclarecidos com base no contexto dos dados. Após renomear a série, a apresentação pode ser salva para persistir as alterações. 

Abaixo está um trecho de código C# que demonstra esse processo em ação.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicionar um gráfico de colunas agrupadas com dados padrão.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Definir o nome da primeira série.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Salvar o arquivo de apresentação no disco.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

O código C# a seguir mostra uma maneira alternativa de alterar o nome da série:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicionar um gráfico de colunas agrupadas com dados padrão.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Definir o nome da primeira série.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Salvar o arquivo de apresentação no disco.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O nome da série](series_name.png)

## **Obter a Cor de Preenchimento Automática da Série**

Aspose.Slides for .NET permite obter a cor de preenchimento automática para séries de gráfico dentro de uma área de plotagem. Após criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/), você pode obter uma referência ao slide desejado por índice e, em seguida, adicionar um gráfico usando o tipo preferido (como `ChartType.ClusteredColumn`). Ao acessar as séries no gráfico, é possível obter a cor de preenchimento automática.

O código C# abaixo demonstra esse processo em detalhes.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicionar um gráfico de colunas agrupadas com dados padrão.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Obter a cor de preenchimento da série.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Saída:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Definir Cor de Preenchimento Invertida para uma Série de Gráfico**

Quando sua série de dados contém valores positivos e negativos, colorir todas as colunas ou barras da mesma forma pode dificultar a leitura do gráfico. Aspose.Slides for .NET permite atribuir uma cor de preenchimento invertida — um preenchimento separado aplicado automaticamente a pontos de dados que ficam abaixo de zero — para que valores negativos se destaquem à primeira vista. Nesta seção, você aprenderá como habilitar essa opção, escolher uma cor apropriada e salvar a apresentação atualizada.

O exemplo de código a seguir demonstra a operação:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Adicionar novas categorias.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Adicionar uma nova série.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Preencher os dados da série.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Definir as configurações de cor para a série.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A cor de preenchimento sólido invertida](inverted_solid_fill_color.png)

É possível inverter a cor de preenchimento para um único ponto de dados em vez de toda a série. Basta acessar o `IChartDataPoint` desejado e definir sua propriedade `InvertIfNegative` como true.

O exemplo de código a seguir mostra como fazer isso:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Inverter a cor se o ponto de dados no índice 2 for negativo.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Limpar Valores de Pontos de Dados Específicos**

Às vezes, um gráfico contém valores de teste, outliers ou entradas obsoletas que precisam ser removidas sem recriar toda a série. Aspose.Slides for .NET permite direcionar qualquer ponto de dados por índice, limpar seu conteúdo e atualizar instantaneamente o gráfico, fazendo com que os pontos restantes se reposicionem e os eixos sejam redimensionados automaticamente.

O exemplo de código a seguir demonstra a operação:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Definir a Largura do Espaço da Série**

A largura do espaço controla a quantidade de espaço vazio entre colunas ou barras adjacentes — espaços maiores enfatizam categorias individuais, enquanto espaços menores criam um aspecto mais denso e compacto. Por meio do Aspose.Slides for .NET você pode ajustar esse parâmetro para uma série inteira, obtendo exatamente o equilíbrio visual que sua apresentação requer sem alterar os dados subjacentes.

O exemplo de código a seguir mostra como definir a largura do espaço para uma série:

```cs
ushort gapWidth = 30;

// Criar uma apresentação vazia.
using (Presentation presentation = new Presentation())
{
    // Acessar o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adicionar um gráfico com dados padrão.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Salvar a apresentação no disco.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Definir o valor de GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Salvar a apresentação no disco.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A largura do espaço](gap_width.png)

## **Perguntas Frequentes**

**Existe um limite para quantas séries um único gráfico pode conter?**

Aspose.Slides não impõe um limite fixo ao número de séries que você adiciona. O limite prático é determinado pela legibilidade do gráfico e pela memória disponível para sua aplicação.

**E se as colunas dentro de um agrupamento estiverem muito próximas ou muito afastadas?**

Ajuste a configuração `GapWidth` para essa série (ou para o grupo de séries pai). Aumentar o valor amplia o espaço entre as colunas, enquanto diminuí‑lo as aproxima.