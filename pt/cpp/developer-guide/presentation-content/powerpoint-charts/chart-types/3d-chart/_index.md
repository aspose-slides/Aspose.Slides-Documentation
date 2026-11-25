---
title: Personalizar Gráficos 3D em Apresentações Usando C++
linktitle: Gráfico 3D
type: docs
url: /pt/cpp/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Crie gráficos 3D em apresentações PowerPoint com Aspose.Slides para C++. Ajuste rotação, proporções de altura, profundidade do gráfico e espaçamento entre séries com exemplos em C++."
---
## **Visão geral**

Aspose.Slides for C++ permite personalizar a visualização de um gráfico 3D através de [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Este artigo demonstra como ajustar rotação, proporções de altura, profundidade, eixos em ângulo reto e espaçamento entre séries, e então salvar a apresentação no formato PPTX.

## **Definir a rotação e profundidade de um gráfico 3D**

O exemplo abaixo cria uma [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e usa [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) para adicionar um gráfico de colunas empilhadas 3D ao seu primeiro slide. Ele substitui as séries e categorias padrão por duas séries contendo três valores cada. O índice da planilha `0` identifica a primeira planilha de dados do gráfico; a linha `0` contém os nomes das séries e a coluna `0` contém os rótulos das categorias.

Os métodos [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) e [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) definem a rotação do gráfico para 40 e 270 graus, respectivamente. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) define sua profundidade em 150 % de sua largura, enquanto [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) habilita eixos em ângulo reto ao invés de perspectiva. A apresentação resultante contém o gráfico preenchido com essas configurações de visualização 3D.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Aplicar preenchimento de imagem à superfície de um gráfico 3D**

É possível preencher a [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), [back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/), e [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) de um gráfico 3D independentemente. Defina o [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) da superfície como `Picture` e atribua uma imagem. Para ajustar uma única cópia da imagem na superfície, defina tanto o [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) quanto o [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) da superfície como `Stretch`.

Salve [arrow.png](arrow.png) no diretório de trabalho. O exemplo gira o gráfico e eleva o valor máximo no eixo vertical para que o piso fique visível entre as colunas. Em seguida, clona o slide duas vezes e aplica a seta a uma superfície diferente em cada slide. Todos os três gráficos mantêm os mesmos dados, ângulo de visualização e plano de fundo.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O Microsoft PowerPoint exibe os três slides da seguinte forma.

| Parede lateral | Parede traseira | Piso |
| --- | --- | --- |
| ![Seta apontando para o gráfico ao longo da parede lateral](side-wall.png) | ![Seta apontando para a direita na parede traseira](back-wall.png) | ![Seta apontando para a direita no piso entre as colunas](floor.png) |

## **Ajustar as proporções de altura de um gráfico 3D**

Use [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) para definir a altura de um gráfico 3D como porcentagem de sua largura. Isso altera as proporções da cena 3D sem redimensionar o objeto do gráfico no slide.

O exemplo a seguir cria um gráfico [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) com os dados padrão: três séries e quatro categorias. Ele salva três apresentações com proporções de altura de 50 %, 100 % e 200 %. A posição, largura e altura do gráfico permanecem fixas. Os dados, rotação, profundidade, espaçamento entre séries e formatação são idênticos nos três arquivos; somente a porcentagem de altura muda.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

As imagens a seguir, do exemplo equivalente em .NET, foram exportadas usando o Microsoft PowerPoint e ilustram as mesmas configurações de altura. Uma porcentagem menor produz uma cena mais plana, enquanto uma porcentagem maior produz uma cena mais alta dentro do mesmo objeto de gráfico. O PowerPoint também pode ajustar intervalos de marcações dos eixos e posicionamento de rótulos para se adequar à cena.

| Altura: 50 % | Altura: 100 % | Altura: 200 % |
| --- | --- | --- |
| ![Gráfico de colunas 3D com altura definida em 50 % da sua largura](height_percent_50.png) | ![Gráfico de colunas 3D com altura definida em 100 % da sua largura](height_percent_100.png) | ![Gráfico de colunas 3D com altura definida em 200 % da sua largura](height_percent_200.png) |

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Altura da cena 3D como porcentagem de sua largura. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Altura do objeto de gráfico no slide, em pontos. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profundidade da cena 3D como porcentagem de sua largura. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |

A configuração de altura afeta gráficos de colunas e barras 3D, incluindo variantes de cilindro, cone e pirâmide, bem como gráficos de linha, área, pizza e superfície 3D. A comparação acima usa o tipo verificado `Column3D`. A configuração não altera a aparência de um gráfico 2D `ClusteredColumn` ou de um gráfico `BubbleWith3D`; esses nomes são membros da enumeração [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Para outras configurações de aparência de gráficos, consulte [Chart Formatting](/slides/pt/cpp/chart-formatting/).

## **Ajustar o intervalo entre séries**

Use [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) para controlar a distância entre séries de dados ao longo do eixo de profundidade de um gráfico 3D, expressa como porcentagem da largura do marcador. Use valores de **0 a 500**, inclusive: `0` elimina o intervalo, enquanto valores maiores aumentam o espaçamento. Com a profundidade do gráfico fixa, aumentar o intervalo torna os marcadores mais finos ao longo do eixo de profundidade.

Acesse o grupo através de [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). A configuração se aplica a todas as séries naquele grupo, não apenas à série usada para acessá‑lo. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) devolve a configuração do grupo pai.

Essa configuração afeta gráficos de colunas e barras 3D, incluindo suas variantes de cilindro, cone e pirâmide, bem como gráficos de linha e área 3D. A aparência depende de as séries estarem organizadas em profundidade, agrupadas ou empilhadas. Para uma comparação clara dos intervalos entre séries separadas, use `ChartType::Column3D` da enumeração [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Esses métodos controlam diferentes aspectos do gráfico:

| Método | Efeito |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Espaçamento entre grupos adjacentes de barras ou colunas, como porcentagem da largura da barra ou coluna. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profundidade geral do gráfico, como porcentagem da largura do gráfico. |

O exemplo autocontido a seguir usa os dados padrão do gráfico, que contêm três séries e quatro categorias. Ele salva duas apresentações com dados, rotação, intervalo de largura e profundidade do gráfico idênticos; apenas o intervalo de profundidade varia.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

As imagens a seguir, do exemplo equivalente em .NET, foram exportadas usando o Microsoft PowerPoint e ilustram as mesmas configurações de intervalo de profundidade.

| Intervalo de profundidade: 0 % | Intervalo de profundidade: 500 % |
| --- | --- |
| ![Gráfico de colunas 3D sem intervalo entre séries ao longo do eixo de profundidade](gap_depth_0.png) | ![Gráfico de colunas 3D com intervalo de 500 % entre séries ao longo do eixo de profundidade](gap_depth_500.png) |

## **Alterar o tipo de série 3D e a forma da barra**

Em um gráfico de cilindro agrupado, a primeira série começa com barras cilíndricas. O exemplo lê [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) e [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) antes e depois de cada alteração.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| Alteração da primeira série | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Criar o gráfico | `ClusteredCylinder` | `Cylinder` |
| Chamar [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) com `ClusteredCone` | `ClusteredCone` | `Cone` |
| Chamar [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) com `Box` | `ClusteredColumn3D` | `Box` |

Definir a forma como `Box` também altera o tipo de série para `ClusteredColumn3D`. Se seu código fizer ramificação com base no tipo de série, chame `series->get_Type()` após mudar a forma. Um valor armazenado antes da mudança ainda selecionaria a ramificação `ClusteredCone`.

![Comparação no PowerPoint mostrando a primeira série como cilindros, cones e colunas retangulares da esquerda para a direita](series-shapes.png)

## **FAQ**

**Quais tipos de gráfico suportam modo 3D no Aspose.Slides?**

Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, além de tipos 3D relacionados expostos pela enumeração [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Para uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) na referência da API da sua versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a Web?**

Sim. Você pode exportar um gráfico para imagem com [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) ou [renderizar o slide inteiro](/slides/pt/cpp/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização raster ou deseja incorporar o gráfico em documentos, painéis ou páginas da Web sem exigir o PowerPoint.

**Qual o desempenho da criação e renderização de gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter melhores resultados, mantenha os efeitos 3D mínimos, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série sempre que possível e renderize para uma saída de tamanho apropriado (resolução e dimensões) que corresponda ao dispositivo de exibição ou impressão alvo.