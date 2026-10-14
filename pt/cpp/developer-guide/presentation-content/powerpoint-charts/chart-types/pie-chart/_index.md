---
title: Personalizar gráficos de pizza em apresentações usando C++
linktitle: Gráfico de Pizza
type: docs
url: /pt/cpp/pie-chart/
keywords:
- gráfico de pizza
- gerenciar gráfico
- personalizar gráfico
- opções de gráfico
- configurações de gráfico
- opções de plotagem
- cor da fatia
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Crie e personalize gráficos de pizza em C++ com Aspose.Slides. Configure plotagens secundárias, exiba rótulos de dados e aplique cores automáticas nas fatias no PowerPoint."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de plotagem secundária para gráficos Pie of Pie e Bar of Pie, e como habilitar a coloração automática das fatias para um gráfico de pizza padrão.

Os exemplos se concentram em tarefas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar as configurações de série e rótulo, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de Plotagem Secundária para Gráficos Pie of Pie e Bar of Pie**

Aspose.Slides for C++ oferece suporte a opções de plotagem secundária para gráficos Pie of Pie e Bar of Pie. Essas opções controlam o tamanho da plotagem secundária e como os pontos de dados são divididos entre as duas plotagens.

O exemplo a seguir cria um gráfico Pie of Pie em uma nova apresentação e exibe os valores dos pontos de dados como rótulos. O [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) método define o tamanho da plotagem secundária para 149% da plotagem principal. [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) seleciona a divisão baseada em porcentagem, e [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) define o limite para 53%.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

// Display values and configure the secondary plot.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_SecondPieSize(149);
seriesGroup->set_PieSplitBy(PieSplitType::ByPercentage);
seriesGroup->set_PieSplitPosition(53);

presentation->Save(u"pie_of_pie.pptx", SaveFormat::Pptx);
```

### **Selecionar Categorias para a Plotagem Secundária**

Use divisão personalizada quando desejar agrupar categorias específicas na plotagem secundária independentemente de seus valores percentuais. Por exemplo, um relatório de vendas pode exibir Online e Events juntos para que os leitores comparem esses dois canais, mesmo que eles representem 35% e 10% das vendas totais.

Chame [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) com [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) e selecione os pontos através de [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/). O método [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/) da coleção aceita um índice baseado em zero na série. Neste exemplo, o índice 1 seleciona Online e o índice 3 seleciona Events. Partners também é adicionado temporariamente, então excluído usando [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IPieSplitCustomPointCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 200);

// Substitua os dados padrão por vendas por canal.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"Retail", u"Online", u"Partners", u"Events" };
auto values = std::vector<int>{ 40, 35, 15, 10 };
auto seriesNameCell = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_PieSplitBy(PieSplitType::Custom);
seriesGroup->set_IsColorVaried(true);

// Selecione Online e Events pelos seus índices baseados em zero na série.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// Exclua Partners da seleção sem excluir seus dados de origem.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Online (35) e Events (10) aparecem como fatias separadas na plotagem secundária. Na plotagem principal, eles são representados por uma única fatia combinada com valor 45, ao lado de Retail (40) e Partners (15). Remover Partners da seleção personalizada mantém‑o na plotagem principal; não remove a categoria ou seu valor dos dados de origem do gráfico.

A imagem a seguir mostra a apresentação salva no PowerPoint:

![Gráfico Pie of Pie com Online e Events na plotagem secundária e seu valor combinado de 45 na plotagem principal](pie_of_pie_custom.png)

## **Definir Cores Automáticas das Fatias do Gráfico de Pizza**

Aspose.Slides for C++ pode atribuir automaticamente cores diferentes às fatias de um gráfico de pizza. O exemplo a seguir cria um gráfico de pizza com um título centralizado e substitui os dados padrão por três categorias trimestrais e seus valores. O método [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) exibe os valores 20, 50 e 30 como rótulos, enquanto [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) habilita uma cor distinta para cada fatia.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 100, 100, 400, 400);

// Adicionar um título de gráfico centralizado.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// Substitua os dados padrão usando a primeira planilha.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"First Qtr", u"2nd Qtr", u"3rd Qtr" };
auto values = std::vector<int>{ 20, 50, 30 };
auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, System::ObjectExt::Box(System::String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

// Show values and assign different colors to the slices.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **Perguntas frequentes**

**As variações Pie of Pie e Bar of Pie são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) uma plotagem secundária para gráficos de pizza, incluindo os tipos Pie of Pie e Bar of Pie.

**Posso exportar apenas o gráfico como uma imagem (por exemplo, PNG)?**

Sim, você pode [exportar o gráfico propriamente como uma imagem](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (como PNG) sem exportar a apresentação inteira.