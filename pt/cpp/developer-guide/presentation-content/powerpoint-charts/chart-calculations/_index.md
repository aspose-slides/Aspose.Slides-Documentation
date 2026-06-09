---
title: Otimizar Cálculos de Gráficos para Apresentações em C++
linktitle: Cálculos de Gráficos
type: docs
weight: 50
url: /pt/cpp/chart-calculations/
keywords:
- cálculos de gráficos
- elementos do gráfico
- posição do elemento
- posição real
- elemento filho
- elemento pai
- valores do gráfico
- valor real
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Entenda os cálculos de gráficos, atualizações de dados e controle de precisão no Aspose.Slides para C++ para PPT e PPTX, com exemplos práticos de código C++."
---
## **Visão Geral**

O Aspose.Slides fornece APIs para trabalhar com cálculos de gráficos e dados de layout em apresentações. Este artigo mostra como obter os valores reais dos elementos do gráfico, incluindo a posição e o tamanho reais dos elementos que implementam `IActualLayout` e os valores reais dos eixos do gráfico. Também explica que esses valores são preenchidos após a validação do layout do gráfico.

Além disso, o artigo demonstra como obter a posição real dos elementos de gráfico pai e como ocultar componentes do gráfico, como o título, os eixos, a legenda e as linhas de grade. Juntos, esses exemplos ajudam você a inspecionar as informações de layout do gráfico e controlar a visibilidade dos elementos do gráfico em apresentações do PowerPoint programaticamente.

## **Calcular Valores Reais dos Elementos do Gráfico**
O Aspose.Slides for C++ fornece uma API simples para obter essas propriedades. Isso ajudará você a calcular os valores reais dos elementos do gráfico. Os valores reais incluem a posição dos elementos que implementam a interface IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) e os valores reais dos eixos (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Salvando apresentação
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Calcular a Posição Real dos Elementos de Gráfico Pai**
O Aspose.Slides for C++ fornece uma API simples para obter essas propriedades. Os métodos de IActualLayout fornecem informações sobre a posição real do elemento de gráfico pai. É necessário chamar o método IChart::ValidateChartLayout() previamente para preencher as propriedades com os valores reais.

``` cpp
// Criando apresentação vazia
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Ocultar Elementos do Gráfico**
Este tópico ajuda você a entender como ocultar informações do gráfico. Usando o Aspose.Slides for C++ você pode ocultar **Título, Eixo Vertical, Eixo Horizontal** e **Linhas de Grade** do gráfico. O exemplo de código abaixo mostra como usar essas propriedades.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Definir um Intervalo de Dados para um Gráfico**
O Aspose.Slides for C++ forneceu a API mais simples para definir o intervalo de dados de um gráfico da maneira mais fácil. Para definir o intervalo de dados de um gráfico:

- Abra uma instância da classe Presentation que contém o gráfico.
- Obtenha a referência de um slide usando seu Índice.
- Percorra todas as formas para encontrar o gráfico desejado.
- Acesse os dados do gráfico e defina o intervalo.
- Salve a apresentação modificada como um arquivo PPTX.

Os exemplos de código a seguir mostram como atualizar um gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**Os livros de Excel externos funcionam como fonte de dados, e como isso afeta o recálculo?**

Sim. Um gráfico pode referenciar um livro externo: quando você conecta ou atualiza a fonte externa, as fórmulas e valores são obtidos desse livro, e o gráfico reflete as atualizações durante as operações de abertura/edição. A API permite que você [especificar o livro de trabalho externo](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) caminho e gerencie os dados vinculados.

**Posso calcular e exibir linhas de tendência sem implementar a regressão eu mesmo?**

Sim. [Linhas de tendência](/slides/pt/cpp/trend-line/) (linear, exponencial e outras) são adicionadas e atualizadas pelo Aspose.Slides; seus parâmetros são recalculados a partir dos dados da série automaticamente, portanto você não precisa implementar seus próprios cálculos.

**Se uma apresentação tem vários gráficos com links externos, posso controlar qual livro cada gráfico usa para os valores calculados?**

Sim. Cada gráfico pode apontar para seu próprio [livro externo](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/setexternalworkbook/), ou você pode criar/substituir um livro externo por gráfico independentemente dos outros.