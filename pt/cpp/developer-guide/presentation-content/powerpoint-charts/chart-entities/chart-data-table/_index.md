---
title: Personalizar tabelas de dados de gráficos em apresentações usando C++
linktitle: Tabela de Dados
type: docs
url: /pt/cpp/chart-data-table/
keywords:
- dados de gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Personalize fontes, bordas e chaves de legenda da tabela de dados de gráficos em apresentações PowerPoint usando Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides for C++ permite exibir a tabela de dados de um gráfico e personalizar a formatação de texto, bordas e chaves da legenda. Este artigo explica como habilitar a tabela, formatar seu texto, controlar cada tipo de borda e mostrar ou ocultar as chaves da legenda. Os exemplos salvam os gráficos configurados em arquivos PPTX.

## **Definir propriedades da fonte**

Para exibir a tabela de dados de um gráfico, passe `true` para [IChart::set_HasDataTable](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Use [IChart::get_ChartDataTable](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/get_chartdatatable/) para acessar a tabela e configurar sua formatação de texto.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Adicione um gráfico de colunas agrupadas ao primeiro slide.
3. Habilite a tabela de dados do gráfico.
4. Ative o texto em negrito com [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/set_fontbold/) e passe `20` para [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/set_fontheight/) para texto de 20 pontos.
5. Salve a apresentação modificada.

O exemplo a seguir requer `test.pptx` no diretório de trabalho com ao menos um slide. Ele adiciona um gráfico com dados padrão na posição (50, 50), com largura de 600 pontos e altura de 400 pontos. O `output.pptx` salvo contém o gráfico com a tabela de dados habilitada e as configurações de fonte especificadas aplicadas.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Personalizar bordas da tabela de dados**

Habilite a tabela com [IChart::set_HasDataTable](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/set_hasdatatable/) e acesse-a através de [IChart::get_ChartDataTable](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/get_chartdatatable/). Você pode controlar três tipos de bordas de forma independente:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) controla as bordas horizontais das células.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) controla as bordas verticais das células.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) controla a borda externa da tabela.

Passe `true` para cada definidor para exibir suas bordas ou `false` para ocultá‑las. O exemplo a seguir cria um gráfico de colunas agrupadas com dados padrão, exibe as bordas horizontais e a borda externa, e oculta as bordas verticais. Não requer arquivo de entrada. A posição e o tamanho do gráfico são especificados em pontos.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

A comparação abaixo usa os mesmos dados do gráfico e a mesma configuração de chave de legenda nos quatro casos. Começando com todas as bordas ativadas, cada variante restante desativa apenas uma configuração de borda. A variante inferior esquerda corresponde às configurações de borda do exemplo.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Mostrar ou ocultar chaves da legenda**

As chaves da legenda são pequenos marcadores coloridos ao lado dos nomes das séries na tabela de dados. Elas ajudam o leitor a associar cada linha da tabela a uma série do gráfico. Passe `true` para [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) para mostrar esses marcadores ou `false` para ocultá‑los.

A legenda separada do gráfico é controlada por [IChart::set_HasLegend](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/set_haslegend/). Essas configurações são independentes: ocultar a legenda separada não oculta as chaves dentro da tabela de dados, e ocultar as chaves da tabela não oculta a legenda separada.

O exemplo a seguir cria um gráfico com dados padrão, habilita sua tabela de dados e mostra as chaves da legenda dentro dela enquanto oculta a legenda separada. Todas as bordas da tabela são explicitamente habilitadas. Nenhuma apresentação de entrada é necessária. Para ocultar apenas as chaves da tabela, passe `false` para [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

A comparação abaixo mostra a mesma tabela com chaves da legenda ativadas e desativadas. Todas as bordas permanecem habilitadas, e a legenda separada do gráfico está oculta em ambos os casos.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **FAQ**

**Posso mostrar chaves da legenda na tabela de dados de um gráfico?**

Sim. Passe `true` para [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) para exibir as chaves da legenda ou `false` para ocultá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. Aspose.Slides renderiza o gráfico e sua tabela de dados exibida como parte do slide ao exportar para [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/pt/cpp/convert-powerpoint-to-html/) ou [imagens](/slides/pt/cpp/convert-powerpoint-to-png/).

**Posso trabalhar com tabelas de dados em gráficos carregados de um modelo?**

Sim. Para um gráfico carregado de uma apresentação ou modelo existente, use [IChart::get_HasDataTable](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/get_hasdatatable/) para verificar se a tabela de dados está exibida e [IChart::set_HasDataTable](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/set_hasdatatable/) para alterar sua visibilidade.

**Como posso encontrar gráficos que têm a tabela de dados habilitada?**

Itere sobre as formas em cada slide, identifique os gráficos e verifique o resultado de [IChart::get_HasDataTable](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Um valor `true` indica que a tabela de dados está habilitada.