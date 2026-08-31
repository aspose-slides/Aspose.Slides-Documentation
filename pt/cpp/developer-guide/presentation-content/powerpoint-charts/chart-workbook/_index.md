---
title: Gerenciar Planilhas de Gráficos em Apresentações Usando C++
linktitle: Planilha de Gráfico
type: docs
weight: 70
url: /pt/cpp/chart-workbook/
keywords:
- planilha de gráfico
- dados de gráfico
- célula de planilha
- rótulo de dados
- planilha
- fonte de dados
- planilha externa
- dados externos
- cache de gráfico
- recuperação de planilha
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Descubra o Aspose.Slides para C++: gerencie facilmente planilhas de gráficos nos formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com livros de planilhas de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráficos através de fluxos de planilhas, usar células de planilha como rótulos de dados de gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para os valores do gráfico.

Também cobre o trabalho com planilhas externas como origens de dados de gráficos. Os exemplos demonstram como criar e atribuir uma planilha externa, recuperar o caminho de uma planilha externa vinculada a um gráfico e editar os dados do gráfico quando a planilha está disponível.

## **Ler e gravar dados de gráfico a partir de uma planilha**

Aspose.Slides fornece os métodos [ReadWorkbookStream](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) que permitem ler e gravar livros de planilhas de dados de gráficos (contendo dados de gráfico editados com Aspose.Cells). **Note** que os dados do gráfico precisam estar organizados da mesma maneira ou ter uma estrutura semelhante à fonte.

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **Validar layout do gráfico após modificação da planilha**

Quando você substitui uma planilha incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [IChart::ValidateChartLayout](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/validatechartlayout/) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a planilha atualizada de volta ao gráfico.

```cpp
// Após modificar o fluxo da planilha (por exemplo, usando Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// Limpar referências de dados existentes.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

Limpar as coleções garante que a estrutura dos dados do gráfico seja consistente com a nova planilha, permitindo que `ValidateChartLayout` seja concluído sem erros.

## **Definir uma célula de planilha como rótulo de dados do gráfico**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha a referência de um slide através de seu índice.
1. Adicione um gráfico de Bolhas com alguns dados.
1. Acesse as séries do gráfico.
1. Defina a célula da planilha como um rótulo de dados.
1. Salve a apresentação.

Este código C++ mostra como definir uma célula de planilha como rótulo de dados do gráfico:

``` cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Instancia uma classe Presentation que representa um arquivo de apresentação 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **Gerenciar planilhas**

Este código C++ demonstra uma operação onde o método [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) é usado para acessar uma coleção de planilhas:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Especificar o tipo de origem de dados**

Este código C++ mostra como especificar um tipo para uma origem de dados:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Detectar formatos de planilhas incorporadas não suportados**

Aspose.Slides não oferece suporte ao formato de planilha binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método `get_EmbeddedWorkbookType` em [IChartData](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdata/) junto com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // A planilha incorporada está no formato .xlsb, que não é suportado.
        continue;
    }

    // Ler ou modificar os dados da planilha do gráfico aqui.
}
```

## **Planilha externa**

{{% alert color="info"%}} 
Em [Aspose.Slides](https://releases.aspose.com/slides/pt/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, implementamos suporte para planilhas externas como origem de dados para gráficos.
{{% /alert %}} 

### **Criar uma planilha externa**

Usando os métodos **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, você pode criar uma planilha externa do zero ou tornar uma planilha interna externa.

Este código C++ demonstra o processo de criação da planilha externa:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **Definir uma planilha externa**

Usando o método **`IChartData::SetExternalWorkbook`**, você pode atribuir uma planilha externa a um gráfico como sua origem de dados. Esse método também pode ser usado para atualizar o caminho da planilha externa (se esta foi movida).

Embora não seja possível editar os dados em planilhas armazenadas em locais remotos ou recursos, você ainda pode usar essas planilhas como origem de dados externa. Se for fornecido um caminho relativo para a planilha externa, ele será convertido automaticamente para um caminho completo.

Este código C++ mostra como definir uma planilha externa:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

O parâmetro `updateChartData` (no método `SetExternalWorkbook`) é usado para especificar se uma planilha Excel será carregada ou não.

* Quando o valor de `updateChartData` é definido como `false`, somente o caminho da planilha é atualizado — os dados do gráfico não serão carregados nem atualizados a partir da planilha de destino. Use essa configuração quando a planilha de destino não existir ou estiver indisponível. 
* Quando o valor de `updateChartData` é definido como `true`, os dados do gráfico são atualizados a partir da planilha de destino.

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Obter o caminho da planilha de origem de dados externa de um gráfico**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha a referência de um slide através de seu índice.
1. Crie um objeto para a forma de gráfico.
1. Crie um objeto para o tipo de origem (`ChartDataSourceType`) que representa a origem de dados do gráfico.
1. Especifique a condição relevante com base no tipo de origem sendo o mesmo que o tipo de origem de planilha externa.

Este código C++ demonstra a operação:

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Editar dados do gráfico**

Você pode editar os dados em planilhas externas da mesma forma que altera o conteúdo de planilhas internas. Quando uma planilha externa não pode ser carregada, uma exceção é lançada.

Este código C++ é uma implementação do processo descrito:

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Recuperar uma planilha do cache do gráfico**

Se um gráfico usa uma planilha externa que está ausente ou indisponível, Aspose.Slides pode reconstruir a planilha do gráfico a partir dos dados armazenados em cache na apresentação. Crie um [LoadOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/), configure-o com [set_SpreadsheetOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), e chame [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) com `true` antes de abrir a apresentação.

O exemplo C++ a seguir abre uma apresentação cujo gráfico referencia uma planilha externa indisponível e acessa os dados recuperados através de [IChart::get_ChartData](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/get_chartdata/) e [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

Se a planilha externa estiver indisponível e a recuperação estiver desativada, Aspose.Slides lançará uma `System::InvalidOperationException`. Habilite a recuperação somente quando o uso dos dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na planilha externa após a última atualização da apresentação.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma planilha externa ou incorporada?**

Sim. Um gráfico tem um [tipo de origem de dados](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) e um [caminho para uma planilha externa](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); se a origem for uma planilha externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para planilhas externas são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente em um caminho absoluto. Isso facilita a portabilidade do projeto; entretanto, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar planilhas localizadas em recursos/redes compartilhadas?**

Sim, essas planilhas podem ser usadas como origem de dados externa. Contudo, a edição direta de planilhas remotas a partir do Aspose.Slides não é suportada — elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Não. A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) e o utiliza para leitura dos dados. O arquivo externo em si não é modificado ao salvar a apresentação.

**O que fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao criar o link. Uma abordagem comum é remover a proteção previamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/cpp/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma planilha externa?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.