---
title: Personalizar áreas de plotagem de gráficos de apresentação em .NET
linktitle: Área de Plotagem
type: docs
url: /pt/net/chart-plot-area/
keywords:
- gráfico
- área de plotagem
- largura da área de plotagem
- altura da área de plotagem
- tamanho da área de plotagem
- modo de layout
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra como personalizar áreas de plotagem de gráficos em apresentações PowerPoint com Aspose.Slides para .NET. Melhore os visuais de seus slides sem esforço."
---
## **Visão geral**

Este artigo mostra como trabalhar com a área de plotagem de um gráfico no Aspose.Slides. Ele explica como obter a posição e o tamanho reais da área de plotagem validando o layout do gráfico e, em seguida, lendo seus valores de X, Y, largura e altura.

Também demonstra como configurar o modo de layout da área de plotagem quando o layout é definido manualmente, usando `LayoutTargetType` para definir se a área de plotagem é calculada pela sua região interna ou pela sua região externa junto com os eixos e os rótulos dos eixos.

## **Obter Largura e Altura da Área de Plotagem de um Gráfico**
Aspose.Slides for .NET fornece uma API simples para . 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Chame o método IChart.ValidateChartLayout() antes para obter os valores reais.
1. Obtém a localização X real (esquerda) do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
1. Obtém a posição superior real do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
1. Obtém a largura real do elemento do gráfico.
1. Obtém a altura real do elemento do gráfico.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Salvar apresentação com gráfico
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```




## **Definir o Modo de Layout da Área de Plotagem de um Gráfico**
Aspose.Slides for .NET fornece uma API simples para definir o modo de layout da área de plotagem do gráfico. A propriedade **LayoutTargetType** foi adicionada às classes **ChartPlotArea** e **IChartPlotArea**. Se o layout da área de plotagem for definido manualmente, esta propriedade especifica se a área de plotagem deve ser disposta por dentro (não incluindo eixo e rótulos dos eixos) ou por fora (incluindo eixo e rótulos dos eixos). Existem dois valores possíveis que são definidos no enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que o tamanho da área de plotagem deve determinar o tamanho da área de plotagem, não incluindo as marcas de escala e os rótulos dos eixos.
- **LayoutTargetType.Outer** - especifica que o tamanho da área de plotagem deve determinar o tamanho da área de plotagem, as marcas de escala e os rótulos dos eixos.

Um exemplo de código é fornecido abaixo.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **Perguntas frequentes**

**Em que unidades são retornados ActualX, ActualY, ActualWidth e ActualHeight?**

Em pontos; 1 polegada = 72 pontos. Estas são unidades de coordenada do Aspose.Slides.

**Como a Área de Plotagem difere da Área do Gráfico em termos de conteúdo?**

A Área de Plotagem é a região de desenho dos dados (séries, linhas de grade, linhas de tendência etc.); a Área do Gráfico inclui os elementos circundantes (título, legenda etc.). Em gráficos 3D, a Área de Plotagem também inclui as paredes/chão e os eixos.

**Como X, Y, Largura e Altura da Área de Plotagem são interpretados quando o layout é manual?**

São frações (0–1) do tamanho total do gráfico; neste modo, o posicionamento automático está desativado e as frações definidas são usadas.

**Por que a posição da Área de Plotagem mudou após adicionar/mover a legenda?**

A legenda fica na área do gráfico fora da Área de Plotagem, mas afeta o layout e o espaço disponível, de modo que a Área de Plotagem pode deslocar-se quando o posicionamento automático está em vigor. (Esse é o comportamento padrão dos gráficos do PowerPoint.)