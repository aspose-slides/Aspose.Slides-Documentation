---
title: Integrar Dados do Excel em Apresentações PowerPoint
linktitle: Integração Excel
type: docs
weight: 330
url: /pt/cpp/excel-integration/
keywords:
- Excel
- pasta de trabalho
- ler Excel
- integrar Excel
- fonte de dados
- mala direta
- importar tabela
- Excel para PowerPoint
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Leia dados de pastas de trabalho do Excel no Aspose.Slides usando a API ExcelDataWorkbook. Carregue planilhas e células e use os valores para gerar apresentações PowerPoint orientadas a dados."
---
## **Introdução**

Apresentações do PowerPoint são uma forma poderosa de exibir e comunicar informações. Elas são frequentemente usadas em conjunto com pastas de trabalho do Excel, onde o Excel serve como uma excelente fonte de dados estruturados e o PowerPoint se destaca ao visualizar esses dados para o público.

Existem muitos cenários práticos em que combinar Excel e PowerPoint é essencial: mala direta, preenchimento de tabelas de dados, geração de um slide por registro de dados (geração em lote de slides), criação de materiais de treinamento e consolidação de múltiplos relatórios do Excel em uma única apresentação, entre outros.

Até agora, implementar esses recursos com a API Aspose.Slides exigia o uso de soluções de terceiros como Aspose.Cells. Embora essas ferramentas sejam robustas, podem ser excessivamente complexas e caras para usuários que precisam apenas de funcionalidade básica de integração de dados.

## **Como Funciona**

Para tornar o trabalho com dados do Excel mais fácil e simplificado, o Aspose.Slides introduziu novas classes para ler dados de pastas de trabalho do Excel e importar conteúdo para uma apresentação. Esse recurso abre poderosas novas possibilidades para os usuários da API que desejam usar o Excel como fonte de dados em seus fluxos de trabalho de apresentação.

A nova funcionalidade foi projetada para acesso geral a dados e não está integrada ao Modelo de Objeto de Documento da Apresentação (DOM). Isso significa que *não permite editar ou salvar arquivos do Excel* — seu único objetivo é abrir pastas de trabalho e navegar pelo conteúdo delas para recuperar os dados das células.

No núcleo desse recurso está a nova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/pt/cpp/aspose.slides.excel/exceldataworkbook/). Essa classe permite carregar uma pasta de trabalho do Excel a partir de um arquivo local ou de um fluxo. Depois de carregada, ela fornece várias sobrecargas do método [GetCell](https://reference.aspose.com/slides/pt/cpp/aspose.slides.excel/exceldataworkbook/getcell/), que podem ser usadas para recuperar células específicas pela sua posição (por exemplo, índices de linha e coluna ou intervalos nomeados).

Cada chamada a [GetCell](https://reference.aspose.com/slides/pt/cpp/aspose.slides.excel/exceldataworkbook/getcell/) retorna uma instância da classe [ExcelDataCell](https://reference.aspose.com/slides/pt/cpp/aspose.slides.excel/exceldatacell/). Esse objeto representa uma única célula na pasta de trabalho do Excel e oferece acesso ao seu valor de forma simples e intuitiva.

#### **Importar um Gráfico do Excel**

O próximo passo para estender a funcionalidade é a classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/excelworkbookimporter/). Essa classe utilitária fornece funcionalidade para importar conteúdo de uma pasta de trabalho do Excel para uma apresentação. Ela contém várias sobrecargas do método [AddChartFromWorkbook](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), que ajudam a recuperar o gráfico selecionado da pasta de trabalho do Excel especificada e adicioná‑lo ao final da coleção de formas fornecida nas coordenadas especificadas.

Em resumo, trata‑se de uma API leve e direta para leitura de dados do Excel — exatamente o que muitos desenvolvedores precisam, sem a sobrecarga de uma biblioteca completa de processamento de planilhas.

## **Vamos Codificar**

### **Exemplo de Cenário de Mala Direta**

Para começar, precisamos de duas coisas:
1. Uma pasta de trabalho do Excel contendo os dados

![Exemplo de dados do Excel](example1_image0.png)

2. Modelo de apresentação PowerPoint

![Exemplo de modelo de PowerPoint](example1_image1.png)

```cpp
// Carregue a pasta de trabalho do Excel com os dados dos funcionários.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Carregue o modelo de apresentação.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Percorra as linhas do Excel (excluindo o cabeçalho na linha 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Crie uma nova apresentação para cada registro de funcionário.
    auto employeePresentation = MakeObject<Presentation>();

    // Remova o slide em branco padrão.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Clone o slide modelo na nova apresentação.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Obtenha os parágrafos da forma alvo (presume-se que o índice da forma 1 seja usado).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Substitua os marcadores de posição pelos dados do Excel.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Salve a apresentação personalizada em um arquivo separado.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Resultado](example1_image2.png)

### **Exemplo de Tabela do Excel**

No segundo exemplo, simplesmente copiamos dados de uma tabela do Excel e os exibimos em um slide do PowerPoint em um formato visualmente mais atraente.

Neste exemplo, reutilizamos a mesma pasta de trabalho do Excel do primeiro exemplo, que contém uma tabela simples de funcionários.

```cpp
// Carregue a pasta de trabalho do Excel contendo os dados dos funcionários.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Crie uma nova apresentação PowerPoint.
auto presentation = MakeObject<Presentation>();

// Adicione uma forma de tabela ao primeiro slide.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Preencha a tabela do PowerPoint com dados da pasta de trabalho do Excel.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Salve a apresentação resultante em um arquivo.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Resultado](example2_image0.png)

### **Exemplo de Importação de Gráfico do Excel**

Neste exemplo, importamos um gráfico da primeira planilha da pasta de trabalho do Excel usada no exemplo anterior. O gráfico será vinculado ao workbook externo na apresentação resultante.

Primeiro, adicionamos um gráfico de Pizza à pasta de trabalho do Excel com base na tabela de funcionários.

![Exemplo de Gráfico do Excel](example3_image0.png)

```cpp
// Crie uma nova apresentação PowerPoint.
auto presentation = MakeObject<Presentation>();

// Obtenha a coleção de formas do primeiro slide.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Importe o gráfico chamado "Chart 1" da primeira planilha da pasta de trabalho e adicione-o à coleção de formas.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Salve a apresentação resultante em um arquivo.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Resultado](example3_image1.png)

### **Exemplo de Importação de Todos os Gráficos do Excel**

Imagine que você tem uma pasta de trabalho do Excel cheia de gráficos e precisa importá‑los todos para uma apresentação. Cada gráfico deve ser colocado em um novo slide.

O código a seguir itera por todas as planilhas do arquivo Excel de origem, extrai os gráficos de cada planilha e adiciona cada gráfico a um slide separado usando um layout de slide em branco. Na apresentação resultante, apenas os dados do gráfico serão incorporados, não a pasta de trabalho inteira.

```cpp
// Carregue a pasta de trabalho do Excel contendo os dados dos funcionários.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Crie uma nova apresentação PowerPoint.
auto presentation = MakeObject<Presentation>();

// Recupere o layout de slide em branco.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Obtenha os nomes de todas as planilhas contidas na pasta de trabalho do Excel.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Recupere um dicionário que mapeia índices de gráficos para nomes de gráficos da planilha.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Adicione um novo slide usando o layout em branco.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Importe o gráfico especificado da pasta de trabalho do Excel para a coleção de formas do slide.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Salve a apresentação resultante em um arquivo.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Resumo**

Esse mecanismo, disponível diretamente no Aspose.Slides, combina o trabalho com dados do Excel e apresentações em um só lugar. Ele permite criar slides com gráficos visuais e dados apresentados como tabelas do Excel — sem bibliotecas adicionais ou integrações complexas.