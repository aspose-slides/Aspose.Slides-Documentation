---
title: Gerenciar séries de dados de gráfico em apresentações usando C++
linktitle: Séries de Dados
type: docs
url: /pt/cpp/chart-series/
keywords:
- série de gráfico
- sobreposição de séries
- cor da série
- cor da categoria
- nome da série
- ponto de dados
- intervalo da série
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a gerenciar séries de gráficos em C++ para PowerPoint (PPT/PPTX) com exemplos práticos de código e boas práticas para aprimorar suas apresentações de dados."
---
## **Visão geral**

Este artigo descreve o papel de [ChartSeries](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartseries/) no Aspose.Slides, concentrando‑se em como os dados são estruturados e visualizados dentro das apresentações. Esses objetos fornecem os elementos fundamentais que definem conjuntos individuais de pontos de dados, categorias e parâmetros de aparência em um gráfico. Ao trabalhar com [ChartSeries](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartseries/), os desenvolvedores podem integrar perfeitamente as fontes de dados subjacentes e manter controle total sobre como as informações são exibidas, resultando em apresentações dinâmicas e orientadas por dados que transmitem claramente percepções e análises.

Uma série é uma linha ou coluna de números plotados em um gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir a sobreposição da série de dados**

Com o método [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) você pode especificar quanto as barras e colunas devem se sobrepor em um gráfico 2D (intervalo: -100 a 100). Essa propriedade se aplica a todas as séries do grupo de séries pai: este é um reflexo da propriedade de grupo apropriada.

Use o método `get_ParentSeriesGroup()::set_Overlap()` para definir o valor desejado para `Overlap`.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Adicione um gráfico de colunas agrupadas em um slide.
1. Acesse a primeira série de gráfico.
1. Acesse o `ParentSeriesGroup` da série de gráfico e defina o valor de sobreposição desejado para a série.
1. Grave a apresentação modificada em um arquivo PPTX.

Este código C++ mostra como definir a sobreposição para uma série de gráfico:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adiciona gráfico
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Define sobreposição da série
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Grava o arquivo da apresentação no disco
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Alterar a cor da série de dados**

Aspose.Slides for C++ permite que você altere a cor de uma série desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Adicione um gráfico no slide.
1. Acesse a série cuja cor você deseja alterar.
1. Defina o tipo de preenchimento e a cor de preenchimento desejados.
1. Salve a apresentação modificada.

Este código C++ mostra como alterar a cor de uma série:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Alterar a cor da categoria de uma série de dados**

Aspose.Slides for C++ permite que você altere a cor de uma categoria de série desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Adicione um gráfico no slide.
1. Acesse a categoria da série cuja cor você deseja alterar.
1. Defina o tipo de preenchimento e a cor de preenchimento desejados.
1. Salve a apresentação modificada.

Este código em C++ mostra como alterar a cor de uma categoria de série:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Alterar o nome da série de dados** 

Por padrão, os nomes da legenda de um gráfico são o conteúdo das células acima de cada coluna ou linha de dados.

Em nosso exemplo (imagem de amostra),

* as colunas são *Series 1, Series 2,* e *Series 3*;
* as linhas são *Category 1, Category 2, Category 3,* e *Category 4*.

Aspose.Slides for C++ permite atualizar ou alterar o nome de uma série em seus dados de gráfico e na legenda.

Este código C++ mostra como alterar o nome de uma série em seu `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Este código C++ mostra como alterar o nome de uma série na legenda através de `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Definir a cor de preenchimento da série de dados**

Aspose.Slides for C++ permite definir a cor de preenchimento automática para séries de gráfico dentro de uma área de plotagem desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão com base no tipo preferido (no exemplo abaixo, usamos `ChartType::ClusteredColumn`).
1. Acesse a série de gráfico e defina a cor de preenchimento para Automatic.
1. Salve a apresentação em um arquivo PPTX.

Este código C++ mostra como definir a cor de preenchimento automática para uma série de gráfico:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Cria um gráfico de colunas agrupadas
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Define o formato de preenchimento da série como automático
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Grava o arquivo da apresentação no disco
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Definir cores de preenchimento invertidas para a série de dados**
Aspose.Slides permite definir a cor de preenchimento invertida para séries de gráfico dentro de uma área de plotagem desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão com base no tipo preferido (no exemplo abaixo, usamos `ChartType::ClusteredColumn`).
1. Acesse a série de gráfico e defina o preenchimento para invertido.
1. Salve a apresentação em um arquivo PPTX.

Este código C++ demonstra a operação:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Definir preenchimento invertido para uma série de gráfico**
Aspose.Slides permite definir inversões através dos métodos `IChartDataPoint::set_InvertIfNegative()` e `ChartDataPoint.set_InvertIfNegative()`. Quando uma inversão é configurada usando esses métodos, o ponto de dados inverte suas cores ao receber um valor negativo.

Este código C++ demonstra a operação:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Limpar valores específicos de pontos de dados**
Aspose.Slides for C++ permite limpar os dados de `DataPoints` para uma série de gráfico específica desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Obtenha a referência de um gráfico pelo seu índice.
4. Percorra todos os `DataPoints` do gráfico e defina `XValue` e `YValue` como nulo.
5. Limpe todos os `DataPoints` para a série de gráfico específica.
6. Grave a apresentação modificada em um arquivo PPTX.

Este código C++ demonstra a operação:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Definir a largura do intervalo da série de dados**
Aspose.Slides for C++ permite definir a Largura do Intervalo de uma série através do método **`set_GapWidth()`** desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Acesse qualquer série de gráfico.
1. Defina a propriedade `GapWidth`.
1. Grave a apresentação modificada em um arquivo PPTX.

Este código em C++ mostra como definir a Largura do Intervalo de uma série:

```cpp
// Cria apresentação vazia
auto presentation = System::MakeObject<Presentation>();

// Acessa o primeiro slide da apresentação
auto slide = presentation->get_Slides()->idx_get(0);

// Adiciona um gráfico com dados padrão
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Define o índice da planilha de dados do gráfico
int32_t worksheetIndex = 0;

// Obtém a planilha de dados do gráfico
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Adiciona séries
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Adiciona categorias
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Obtém a segunda série do gráfico
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Preenche os dados da série
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Define o valor de GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Salva a apresentação no disco
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Existe um limite para quantas séries um único gráfico pode conter?**

Aspose.Slides não impõe um teto fixo ao número de séries que você adiciona. O limite prático é definido pela legibilidade do gráfico e pela memória disponível para sua aplicação.

**E se as colunas dentro de um grupo estiverem muito próximas ou muito distantes?**

Ajuste a configuração de largura do intervalo para essa série (ou seu grupo de séries pai). Aumentar o valor amplia o espaço entre as colunas, enquanto diminuí‑lo as aproxima.