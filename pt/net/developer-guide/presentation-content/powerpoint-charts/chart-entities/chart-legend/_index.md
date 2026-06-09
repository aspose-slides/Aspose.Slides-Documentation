---
title: Personalizar legendas de gráficos em apresentações no .NET
linktitle: Legenda de Gráfico
type: docs
url: /pt/net/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides para .NET para otimizar apresentações PowerPoint com formatação de legenda sob medida."
---
## **Visão geral**

Aspose.Slides oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para toda a legenda e aplicar formatação a uma entrada individual da legenda.

Também aborda vários comportamentos relacionados nas Perguntas Frequentes, incluindo o uso do modo não sobreposição para que a área de plotagem faça espaço para a legenda, permitir que rótulos longos de legenda quebrem em linhas ou usem quebras de linha, e permitir que a formatação da legenda herde do tema da apresentação quando configurações explícitas de texto e preenchimento não são aplicadas.

## **Posicionamento da legenda**
Para definir as propriedades da legenda. Siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
- Obtenha a referência do slide.
- Adicione um gráfico ao slide.
- Defina as propriedades da legenda.
- Salve a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos a posição e o tamanho da legenda do gráfico.

```c#
// Crie uma instância da classe Presentation
Presentation presentation = new Presentation();

// Obtenha a referência do slide
ISlide slide = presentation.Slides[0];

// Adicione um gráfico de colunas agrupadas no slide
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Defina as propriedades da legenda
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Salve a apresentação no disco
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **Definir o tamanho da fonte da legenda**
O Aspose.Slides for .NET permite que os desenvolvedores definam o tamanho da fonte da legenda. Siga as etapas abaixo: 

- Instancie a classe `Presentation`.
- Crie o gráfico padrão.
- Defina o Tamanho da Fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Salve a apresentação no disco.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Definir o tamanho da fonte de uma legenda individual**
O Aspose.Slides for .NET permite que os desenvolvedores definam o tamanho da fonte de entradas individuais da legenda. Siga as etapas abaixo: 

- Instancie a classe `Presentation`.
- Crie o gráfico padrão.
- Acesse a entrada da legenda.
- Defina o Tamanho da Fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Salve a apresentação no disco.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Perguntas Frequentes**

**Posso habilitar a legenda para que o gráfico aloque automaticamente espaço para ela em vez de sobrepor?**

Sim. Use o modo não sobreposição ([Overlay](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/legend/overlay/) = `false`); nesse caso, a área de plotagem será reduzida para acomodar a legenda.

**Posso criar rótulos de legenda com várias linhas?**

Sim. Rótulos longos são quebrados automaticamente quando o espaço é insuficiente; quebras de linha forçadas são suportadas via caracteres de nova linha no nome da série.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Não defina cores, preenchimentos ou fontes explícitas para a legenda ou seu texto. Eles herdarão do tema e serão atualizados corretamente quando o design mudar.