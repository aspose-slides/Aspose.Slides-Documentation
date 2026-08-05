---
title: Personalizar eixos de gráfico em apresentações usando C++
linktitle: Eixo de Gráfico
type: docs
url: /pt/cpp/chart-axis/
keywords:
- eixo de gráfico
- eixo vertical
- eixo horizontal
- personalizar eixo
- manipular eixo
- gerenciar eixo
- propriedades do eixo
- valor máximo
- valor mínimo
- linha do eixo
- formato de data
- título do eixo
- posição do eixo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Descubra como usar Aspose.Slides for C++ para personalizar eixos de gráfico em apresentações PowerPoint para relatórios e visualizações."
---
## **Visão Geral**

Este artigo explica como personalizar eixos de gráficos no Aspose.Slides. Ele mostra como obter valores reais dos eixos, trocar dados entre eixos, ocultar o eixo vertical ou horizontal em gráficos de linhas, mudar o tipo do eixo de categoria, definir o formato de data para os valores do eixo de categoria, girar o título de um eixo, definir a posição do eixo e exibir um rótulo de unidade no eixo de valores.

## **Obter os Valores Máximos no Eixo Vertical**
Aspose.Slides for C++ permite que você obtenha os valores mínimo e máximo em um eixo vertical. Siga estas etapas:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) classe.
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Obtenha o valor máximo real no eixo.
5. Obtenha o valor mínimo real no eixo.
6. Obtenha a unidade maior real do eixo.
7. Obtenha a unidade menor real do eixo.
8. Obtenha a escala da unidade maior real do eixo.
9. Obtenha a escala da unidade menor real do eixo.

Este código de exemplo—uma implementação das etapas acima—mostra como obter os valores necessários em C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Salva a apresentação
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Trocar os Dados entre os Eixos**
Aspose.Slides permite que você troque rapidamente os dados entre eixos—os dados representados no eixo vertical (eixo y) são transferidos para o eixo horizontal (eixo x) e vice‑versa.

Este código C++ mostra como realizar a troca de dados entre eixos em um gráfico:

``` cpp
// Cria apresentação vazia
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Troca linhas e colunas
chart->get_ChartData()->SwitchRowColumn();

// Salva a apresentação
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Desativar o Eixo Vertical para Gráficos de Linha**

Este código C++ mostra como ocultar o eixo vertical em um gráfico de linhas:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Desativar o Eixo Horizontal para Gráficos de Linha**

Este código mostra como ocultar o eixo horizontal em um gráfico de linhas:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Alterar um Eixo de Categoria**

Usando o método **set_CategoryAxisType()**, você pode especificar o tipo de eixo de categoria desejado (**date** ou **text**). Este código em C++ demonstra a operação:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Definir o Formato de Data para Valores do Eixo de Categoria**
Aspose.Slides for C++ permite definir o formato de data para um valor de eixo de categoria. A operação é demonstrada neste código C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Definir o Ângulo de Rotação para o Título de um Eixo**
Aspose.Slides for C++ permite definir o ângulo de rotação para o título de um eixo de gráfico. Este código C++ demonstra a operação:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Definir a Posição do Eixo em um Eixo de Categoria ou Valor**
Aspose.Slides for C++ permite definir a posição do eixo em um eixo de categoria ou valor. Este código C++ mostra como executar a tarefa:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Ativar o Rótulo de Unidade de Exibição no Eixo de Valor de um Gráfico**
Aspose.Slides for C++ permite configurar um gráfico para exibir um rótulo de unidade no eixo de valor do gráfico. Este código C++ demonstra a operação:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Como definir o valor em que um eixo cruza o outro (cruzamento de eixo)?**

Os eixos fornecem uma [configuração de cruzamento](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/axis/set_crosstype/): você pode escolher cruzar em zero, no valor máximo da categoria/valor ou em um valor numérico específico. Isso é útil para deslocar o eixo X para cima ou para baixo ou para enfatizar uma linha de base.

**Como posicionar os rótulos de marcação em relação ao eixo (ao lado, fora, dentro)?**

Defina a [posição do rótulo](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/axis/set_majortickmark/) como "cross", "outside" ou "inside". Isso afeta a legibilidade e ajuda a economizar espaço, especialmente em gráficos pequenos.