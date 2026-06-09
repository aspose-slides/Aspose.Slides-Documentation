---
title: Personalizar áreas de plotagem de gráficos em C++
linktitle: Área de plotagem
type: docs
url: /pt/cpp/chart-plot-area/
keywords:
- gráfico
- área de plotagem
- largura da área de plotagem
- altura da área de plotagem
- tamanho da área de plotagem
- modo de layout
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Descubra como personalizar áreas de plotagem de gráficos em apresentações PowerPoint com Aspose.Slides para C++. Melhore os visuais dos seus slides sem esforço."
---
## **Visão geral**

Este artigo mostra como trabalhar com a área de plotagem de um gráfico no Aspose.Slides. Ele explica como obter a posição e o tamanho reais da área de plotagem validando o layout do gráfico e, em seguida, lendo seus valores de X, Y, largura e altura.

Ele também demonstra como configurar o modo de layout da área de plotagem quando o layout é definido manualmente, usando `LayoutTargetType` para definir se a área de plotagem é calculada por sua região interna ou por sua região externa juntamente com os eixos e rótulos dos eixos.

## **Obter Largura e Altura da Área de Plotagem de um Gráfico**
Aspose.Slides para C++ fornece uma API simples para .

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Chame o método IChart::ValidateChartLayout() antes para obter os valores reais.
1. Obtém a localização X real (esquerda) do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
1. Obtém a posição superior real do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
1. Obtém a largura real do elemento do gráfico.
1. Obtém a altura real do elemento do gráfico.

```cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Salvar apresentação com gráfico
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Definir o Modo de Layout da Área de Plotagem de um Gráfico**
Aspose.Slides para C++ fornece uma API simples para definir o modo de layout da área de plotagem do gráfico. A propriedade **LayoutTargetType** foi adicionada às classes **ChartPlotArea** e **IChartPlotArea**. Se o layout da área de plotagem for definido manualmente, esta propriedade especifica se o layout da área de plotagem será por dentro (não incluindo eixo e rótulos dos eixos) ou por fora (incluindo eixo e rótulos dos eixos). Existem dois valores possíveis que são definidos no enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que o tamanho da área de plotagem determinará o tamanho da área de plotagem, não incluindo as marcas de escala e os rótulos dos eixos.
- **LayoutTargetType.Outer** - especifica que o tamanho da área de plotagem determinará o tamanho da área de plotagem, as marcas de escala e os rótulos dos eixos.

O código de exemplo é mostrado abaixo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**Em que unidades são retornados ActualX, ActualY, ActualWidth e ActualHeight?**

Em pontos; 1 polegada = 72 pontos. Estas são unidades de coordenadas do Aspose.Slides.

**Como a Área de Plotagem difere da Área do Gráfico em termos de conteúdo?**

A Área de Plotagem é a região de desenho dos dados (séries, linhas de grade, linhas de tendência, etc.); a Área do Gráfico inclui os elementos ao redor (título, legenda, etc.). Em gráficos 3D, a Área de Plotagem também inclui as paredes/chão e os eixos.

**Como são interpretados X, Y, Largura e Altura da Área de Plotagem quando o layout é manual?**

Eles são frações (0–1) do tamanho total do gráfico; neste modo, o posicionamento automático é desativado e as frações que você define são usadas.

**Por que a posição da Área de Plotagem mudou após adicionar/mover a legenda?**

A legenda fica na área do gráfico fora da Área de Plotagem, mas afeta o layout e o espaço disponível, portanto a Área de Plotagem pode deslocar‑se quando o posicionamento automático está em vigor. (Isso é um comportamento padrão dos gráficos do PowerPoint.)