---
title: Gerenciar pastas de trabalho de gráfico em apresentações usando C++
linktitle: Pasta de Trabalho de Gráfico
type: docs
weight: 70
url: /pt/cpp/chart-workbook/
keywords:
- pasta de trabalho de gráfico
- dados de gráfico
- célula de pasta de trabalho
- rótulo de dados
- planilha
- origem de dados
- pasta de trabalho externa
- dados externos
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Descubra o Aspose.Slides para C++: gerencie facilmente pastas de trabalho de gráfico no PowerPoint e nos formatos OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráfico no Aspose.Slides. Ele mostra como ler e gravar dados de gráfico através de fluxos de pasta de trabalho, usar células da pasta de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para valores do gráfico.

Ele também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráfico. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

## **Ler e gravar dados de gráfico a partir de uma pasta de trabalho**

Aspose.Slides fornece os métodos [ReadWorkbookStream](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) que permitem ler e gravar pastas de trabalho de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Nota** que os dados do gráfico devem estar organizados da mesma maneira ou ter uma estrutura semelhante à fonte.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Este código C++ demonstra a operação de definir uma pasta de trabalho de dados de gráfico:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Definir uma célula de WorkBook como rótulo de dados do gráfico**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha a referência de um slide através de seu índice.
1. Adicione um gráfico de Bolhas com alguns dados.
1. Acesse as séries do gráfico.
1. Defina a célula do workbook como rótulo de dados.
1. Salve a apresentação.

Este código C++ mostra como definir uma célula de workbook como rótulo de dados do gráfico:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Instancia a classe Presentation que representa um arquivo de apresentação
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

## **Detectar formatos de pasta de trabalho incorporada não suportados**

Aspose.Slides não oferece suporte ao formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método `get_EmbeddedWorkbookType` em [IChartData](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdata/) junto com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
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
        // Pasta de trabalho incorporada está no formato .xlsb, que não é suportado.
        continue;
    }

    // Leia ou modifique os dados da pasta de trabalho do gráfico aqui.
}
```

## **Pasta de trabalho externa**

{{% alert color="primary" %}} 
Em [Aspose.Slides](https://releases.aspose.com/slides/pt/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, implementamos suporte para pastas de trabalho externas como fonte de dados para gráficos.
{{% /alert %}} 

### **Criar uma pasta de trabalho externa**

Usando os métodos **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, você pode criar uma pasta de trabalho externa do zero ou tornar uma pasta de trabalho interna externa.

Este código C++ demonstra o processo de criação da pasta de trabalho externa:

```c++
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

### **Definir uma pasta de trabalho externa**

Usando o método **`IChartData::SetExternalWorkbook`**, você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho para a pasta de trabalho externa (se esta foi movida).

Embora você não possa editar os dados em pastas de trabalho armazenadas em locais remotos ou recursos, ainda pode usar tais pastas de trabalho como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente para um caminho completo.

Este código C++ mostra como definir uma pasta de trabalho externa:

```c++
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

O parâmetro `updateChartData` (sob o método `SetExternalWorkbook`) é usado para especificar se uma pasta de trabalho Excel será carregada ou não. 

* Quando o valor de `updateChartData` estiver definido como `false`, somente o caminho da pasta de trabalho é atualizado — os dados do gráfico não serão carregados ou atualizados a partir da pasta de trabalho de destino. Você pode usar essa configuração quando a pasta de trabalho de destino não existir ou estiver indisponível. 
* Quando o valor de `updateChartData` estiver definido como `true`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Obter o caminho da pasta de trabalho de fonte de dados externa de um gráfico**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
1. Obtenha a referência de um slide através de seu índice.
1. Crie um objeto para a forma de gráfico.
1. Crie um objeto para o tipo de origem (`ChartDataSourceType`) que representa a fonte de dados do gráfico.
1. Especifique a condição relevante com base no tipo de origem sendo o mesmo que o tipo de fonte de dados da pasta de trabalho externa.

Este código C++ demonstra a operação:

```c++
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

Você pode editar os dados em pastas de trabalho externas da mesma forma que faz alterações no conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este código C++ é uma implementação do processo descrito:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**

Sim. Um gráfico possui um [tipo de fonte de dados](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) e um [caminho para uma pasta de trabalho externa](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); se a fonte for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para pastas de trabalho externas são suportados, e como eles são armazenados?**

Sim. Se você especificar um caminho relativo, ele é convertido automaticamente para um caminho absoluto. Isso é conveniente para portabilidade de projetos; no entanto, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar pastas de trabalho localizadas em recursos/rede compartilhada?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. Contudo, editar pastas de trabalho remotas diretamente do Aspose.Slides não é suportado—elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Não. A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) e o usa para leitura dos dados. O arquivo externo em si não é modificado ao salvar a apresentação.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita uma senha ao vincular. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/cpp/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.