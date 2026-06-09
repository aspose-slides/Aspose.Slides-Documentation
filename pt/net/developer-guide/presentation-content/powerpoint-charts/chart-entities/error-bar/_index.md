---
title: Personalizar Barras de Erro em Gráficos de Apresentação no .NET
linktitle: Barra de Erro
type: docs
url: /pt/net/error-bar/
keywords:
- barra de erro
- valor personalizado
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a adicionar e personalizar barras de erro em gráficos com Aspose.Slides para .NET—otimize a visualização de dados em apresentações PowerPoint."
---
## **Visão geral**

Este artigo explica como trabalhar com barras de erro em gráficos de apresentações usando o Aspose.Slides. Ele mostra como adicionar barras de erro a uma série de gráfico, configurar as definições de barras de erro X e Y e aplicar diferentes tipos de valor, como fixos, percentuais e valores personalizados.

Também demonstra como atribuir valores personalizados de barras de erro para pontos de dados individuais em uma série usando a respectiva coleção de pontos de dados. Além disso, o artigo inclui notas breves sobre como as barras de erro se comportam durante a exportação, sua compatibilidade com marcadores e rótulos de dados, e onde encontrar as classes e enums de referência da API relacionados.

## **Adicionar barras de erro**
O Aspose.Slides para .NET fornece uma API simples para gerenciar valores de barras de erro. O código de exemplo se aplica ao usar um tipo de valor personalizado. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção **DataPoints** da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Adicione um gráfico de bolhas no slide desejado.
3. Acesse a primeira série de gráfico e defina o formato da barra de erro X.
4. Acesse a primeira série de gráfico e defina o formato da barra de erro Y.
5. Definindo os valores e o formato das barras.
6. Grave a apresentação modificada em um arquivo PPTX.

```c#
// Criando apresentação vazia
using (Presentation presentation = new Presentation())
{
    // Criando um gráfico de bolhas
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Adicionando barras de erro e definindo seu formato
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Salvando a apresentação
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Adicionar valores personalizados de barra de erro**
O Aspose.Slides para .NET fornece uma API simples para gerenciar valores personalizados de barra de erro. O código de exemplo se aplica quando a propriedade **IErrorBarsFormat.ValueType** é igual a **Custom**. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção **DataPoints** da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Adicione um gráfico de bolhas no slide desejado.
3. Acesse a primeira série de gráfico e defina o formato da barra de erro X.
4. Acesse a primeira série de gráfico e defina o formato da barra de erro Y.
5. Acesse os pontos de dados individuais da série de gráfico e defina os valores da barra de erro para cada ponto de dados da série.
6. Definindo os valores e o formato das barras.
7. Grave a apresentação modificada em um arquivo PPTX.

```c#
// Criando apresentação vazia
using (Presentation presentation = new Presentation())
{
    // Criando um gráfico de bolhas
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Adicionando barras de erro personalizadas e definindo seu formato
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Acessando o ponto de dados da série de gráfico e definindo valores de barras de erro para ponto individual
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Definindo barras de erro para os pontos da série de gráfico
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Salvando a apresentação
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**O que acontece com as barras de erro ao exportar uma apresentação para PDF ou imagens?**

Elas são renderizadas como parte do gráfico e preservadas durante a conversão juntamente com o restante da formatação do gráfico, assumindo uma versão ou renderizador compatível.

**As barras de erro podem ser combinadas com marcadores e rótulos de dados?**

Sim. As barras de erro são um elemento separado e são compatíveis com marcadores e rótulos de dados; se os elementos se sobrepuserem, pode ser necessário ajustar a formatação.

**Onde posso encontrar a lista de propriedades e enums para trabalhar com barras de erro na API?**

Na referência da API: a classe [ErrorBarsFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/errorbarsformat/) e os enums relacionados [ErrorBarType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/errorbarvaluetype/).