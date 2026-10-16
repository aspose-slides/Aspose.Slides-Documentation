---
title: Adicionar Linhas de Tendência a Gráficos de Apresentação em C++
linktitle: Linha de Tendência
type: docs
url: /pt/cpp/trend-line/
keywords:
- gráfico
- linha de tendência
- linha de tendência exponencial
- linha de tendência linear
- linha de tendência logarítmica
- linha de tendência de média móvel
- linha de tendência polinomial
- linha de tendência potência
- linha de tendência personalizada
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Adicione e personalize rapidamente linhas de tendência em gráficos PowerPoint com Aspose.Slides para C++ — um guia prático para envolver seu público."
---
## **Visão geral**

Este artigo explica como adicionar linhas de tendência a gráficos de apresentação usando o Aspose.Slides. Ele mostra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linhas de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e potência.

Ele também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui um breve FAQ sobre os valores de projeção da linha de tendência para frente e para trás e se as linhas de tendência são preservadas durante a exportação para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar uma Linha de Tendência**

Use [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) para adicionar uma linha de tendência a uma série de gráfico, selecionando seu tipo com [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). O exemplo cria um gráfico de colunas agrupadas com dados padrão e adiciona duas linhas de tendência a cada uma das suas três séries.

A linha de tendência exponencial oculta sua equação e o valor de R‑quadrado por meio de [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) e [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/), enquanto a linha de tendência linear é vermelha. A linha de tendência logarítmica usa [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) para um rótulo personalizado. A média móvel usa [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) para calcular a média de três pontos de dados e [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) para um nome personalizado.

A linha de tendência polinomial usa [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) para definir seu grau como três e estende uma categoria para frente por meio de [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). A linha de tendência potência estende uma categoria para trás por meio de [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **Definir o Intercepto da Linha de Tendência**

Use [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) para fixar o valor Y de uma linha de tendência em X = 0. Essa configuração é suportada para linhas de tendência lineares, exponenciais e polinomiais.

Por exemplo, um modelo de custo de produção pode precisar iniciar com custos fixos conhecidos de 100, mesmo quando medições em volumes de produção diferentes de zero sugerem uma linha de base distinta. Para uma linha de tendência linear, fixar o intercepto restringe a equação `y = ax + b` para `b = 100`; a inclinação é ajustada aos dados sob essa restrição. Isso não desloca simplesmente uma linha já ajustada. As configurações de cruzamento dos eixos controlam onde os eixos do gráfico se encontram, não os coeficientes da linha de tendência ajustada.

O exemplo a seguir cria um gráfico de dispersão (XY) com volumes de produção de 1 a 4 e custos de 170, 200, 230 e 260. Ele salva o gráfico com o intercepto automático padrão, define o intercepto para 100 e salva um segundo PPTX. Os dois arquivos diferem apenas na configuração do intercepto. A linha de tendência exibe sua equação e se estende de volta a X = 0.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

Com cálculo automático, esses dados produzem `y = 30x + 140`. Definir o intercepto para 100, em vez disso, produz aproximadamente `y = 43.33x + 100`: o valor ajustado em zero corresponde à linha de base conhecida, enquanto a linha deixa de passar por todos os pontos de dados.

| Interceptação automática | Interceptação fixa de 100 |
| --- | --- |
| ![Linha de tendência linear com interceptação calculada automaticamente de 140](intercept-automatic.png) | ![Linha de tendência linear com interceptação fixa de 100](intercept-fixed.png) |

Ambas as imagens usam os mesmos dados e escalas de eixo. As linhas de tendência são estendidas de volta a X = 0 para mostrar seus interceptos.

Por padrão, a propriedade contém `std::numeric_limits<double>::quiet_NaN()`, que representa um intercepto não especificado em vez de zero. O intercepto é então calculado automaticamente a partir dos dados.

## **Adicionar uma Linha Personalizada**

Uma linha personalizada é uma forma desenhada sobre o gráfico em vez de uma linha de tendência calculada a partir dos dados da série. Este exemplo usa [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) para adicionar uma linha horizontal ao slide sobre o gráfico. A posição da linha é especificada em coordenadas do slide, medidas em pontos, de modo que ela começa na borda esquerda do gráfico e fica a meio caminho da altura do gráfico. Sua largura corresponde à largura do gráfico. O formato de linha retornado por [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) dá à linha uma cor vermelha sólida.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **FAQ**

**O que significam 'forward' e 'backward' para uma linha de tendência?**

São os comprimentos da linha de tendência projetados para frente/para trás: para gráficos de dispersão (XY) — em unidades de eixo; para gráficos que não são de dispersão — em número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. Aspose.Slides converte apresentações para [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/) ou [SVG](/slides/pt/cpp/render-a-slide-as-an-svg-image/) e renderiza gráficos como imagens; as linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Também há um método disponível para [exportar uma imagem do gráfico](/slides/pt/cpp/shape-thumbnails/) em si.