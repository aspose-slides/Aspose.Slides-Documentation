---
title: Integrar Dados do Excel em Apresentações PowerPoint
linktitle: Integração do Excel
type: docs
weight: 330
url: /pt/net/excel-integration/
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
- .NET
- C#
- Aspose.Slides
description: "Leia dados de pastas de trabalho do Excel no Aspose.Slides usando a API ExcelDataWorkbook. Carregue planilhas e células e use os valores para gerar apresentações PowerPoint orientadas por dados."
---
## **Introdução**

Apresentações do PowerPoint são uma forma poderosa de exibir e comunicar informações. Elas são frequentemente usadas em conjunto com pastas de trabalho do Excel, onde o Excel serve como uma excelente fonte de dados estruturados e o PowerPoint se destaca na visualização desses dados para o público.

Existem muitos cenários práticos em que combinar Excel e PowerPoint é essencial: mala direta, preenchimento de tabelas de dados, geração de um slide por registro de dados (geração em lote de slides), criação de materiais de treinamento e consolidação de vários relatórios do Excel em uma única apresentação, entre outros.

Até agora, implementar tais recursos com a API Aspose.Slides exigia depender de soluções de terceiros como Aspose.Cells. Embora essas ferramentas sejam robustas, podem ser excessivamente complexas e caras para usuários que precisam apenas de funcionalidade básica de integração de dados.

## **Como funciona**

Para facilitar o trabalho com dados do Excel e torná‑lo mais fluido, o Aspose.Slides introduziu novas classes para ler dados de pastas de trabalho do Excel e importar conteúdo para uma apresentação. Esse recurso abre possibilidades poderosas para usuários da API que desejam usar o Excel como fonte de dados em seus fluxos de trabalho de apresentação.

A nova funcionalidade foi projetada para acesso geral a dados e não está integrada ao Modelo de Objeto de Documento de Apresentação (DOM). Isso significa que *não permite editar ou salvar arquivos do Excel* — seu único propósito é abrir pastas de trabalho e navegar pelo seu conteúdo para recuperar dados de célula.

No coração desse recurso está a nova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/pt/net/aspose.slides.excel/exceldataworkbook/). Essa classe permite carregar uma pasta de trabalho do Excel a partir de um arquivo local ou de um fluxo. Uma vez carregada, ela fornece várias sobrecargas do método [GetCell](https://reference.aspose.com/slides/pt/net/aspose.slides.excel/exceldataworkbook/getcell/), que podem ser usadas para recuperar células específicas por sua posição (por exemplo, índices de linha e coluna ou intervalos nomeados).

Cada chamada ao [GetCell](https://reference.aspose.com/slides/pt/net/aspose.slides.excel/exceldataworkbook/getcell/) devolve uma instância da classe [ExcelDataCell](https://reference.aspose.com/slides/pt/net/aspose.slides.excel/exceldatacell/). Esse objeto representa uma única célula na pasta de trabalho do Excel e fornece acesso ao seu valor de forma simples e intuitiva.

#### **Importar um gráfico do Excel**

O próximo passo para expandir a funcionalidade é a classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/pt/net/aspose.slides.import/excelworkbookimporter/). Essa classe utilitária oferece recursos para importar conteúdo de uma pasta de trabalho do Excel para uma apresentação. Ela contém várias sobrecargas do método [AddChartFromWorkbook](https://reference.aspose.com/slides/pt/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), que ajudam a recuperar o gráfico selecionado da pasta de trabalho do Excel especificada e adicioná‑lo ao final da coleção de formas indicada nas coordenadas especificadas.

Em resumo, trata‑se de uma API leve e direta para leitura de dados do Excel — exatamente o que muitos desenvolvedores precisam sem a sobrecarga de uma biblioteca completa de processamento de planilhas.

## **Vamos codar**

### **Exemplo de cenário de mala direta**

No exemplo a seguir, implementaremos um cenário simples de Mala Direta gerando várias apresentações com base nos dados armazenados em uma pasta de trabalho do Excel.

Para começar, precisamos de duas coisas:
1. Uma pasta de trabalho do Excel contendo os dados

![Exemplo de dados do Excel](example1_image0.png)

2. Modelo de apresentação do PowerPoint

![Exemplo de modelo PowerPoint](example1_image1.png)

```csharp
// Carregar a pasta de trabalho do Excel com dados de funcionários.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Carregar o modelo de apresentação.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Percorrer as linhas do Excel (excluindo o cabeçalho na linha 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Criar uma nova apresentação para cada registro de funcionário.
    using Presentation employeePresentation = new Presentation();

    // Remover o slide em branco padrão.
    employeePresentation.Slides.RemoveAt(0);

    // Clonar o slide modelo na nova apresentação.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Obter parágrafos da forma alvo (presume que o índice da forma 1 está sendo usado).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Substituir os marcadores de posição pelos dados do Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Salvar a apresentação personalizada em um arquivo separado.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Resultado](example1_image2.png)

### **Exemplo de tabela do Excel**

No segundo exemplo, simplesmente copiamos dados de uma tabela do Excel e os exibimos em um slide do PowerPoint de forma mais visualmente atraente.

Neste exemplo, reutilizamos a mesma pasta de trabalho do Excel do primeiro exemplo, que contém uma tabela simples de funcionários.

```csharp
// Carregar a pasta de trabalho do Excel contendo os dados dos funcionários.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Criar uma nova apresentação do PowerPoint.
using Presentation presentation = new Presentation();

// Adicionar uma forma de tabela ao primeiro slide.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Preencher a tabela do PowerPoint com dados da pasta de trabalho do Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Salvar a apresentação resultante em um arquivo.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Resultado](example2_image0.png)

### **Exemplo de importação de um gráfico do Excel**

Neste exemplo, importamos um gráfico da primeira planilha da pasta de trabalho do Excel usada no exemplo anterior. O gráfico será vinculado à pasta de trabalho externa na apresentação resultante.

Primeiro, adicionamos um gráfico de pizza à pasta de trabalho do Excel com base na tabela de funcionários.

![Exemplo de gráfico do Excel](example3_image0.png)

```csharp
// Criar uma nova apresentação do PowerPoint.
using Presentation presentation = new Presentation();

// Obter a coleção de formas do primeiro slide.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importar o gráfico chamado "Chart 1" da primeira planilha da pasta de trabalho e adicioná-lo à coleção de formas.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Salvar a apresentação resultante em um arquivo.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Resultado](example3_image1.png)

### **Exemplo de importação de todos os gráficos do Excel**

Imagine que você tem uma pasta de trabalho do Excel cheia de gráficos e precisa importá‑los todos para uma apresentação. Cada gráfico deve ser colocado em um novo slide.

O código a seguir itera por todas as planilhas no arquivo Excel de origem, extrai os gráficos de cada planilha e adiciona cada gráfico a um slide separado usando um layout de slide em branco. Na apresentação resultante, apenas os dados do gráfico serão incorporados, não a pasta de trabalho inteira.

```csharp
// Carregar a pasta de trabalho do Excel contendo os dados dos funcionários.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Criar uma nova apresentação do PowerPoint.
using Presentation presentation = new Presentation();

// Recuperar o layout de slide em branco.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Obter os nomes de todas as planilhas contidas na pasta de trabalho do Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Recuperar um dicionário que mapeia índices de gráficos para nomes de gráficos da planilha.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Adicionar um novo slide usando o layout em branco.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importar o gráfico especificado da pasta de trabalho do Excel para a coleção de formas do slide.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Salvar a apresentação resultante em um arquivo.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **Resumo**

Esse mecanismo, disponível diretamente no Aspose.Slides, combina o trabalho com dados do Excel e apresentações em um único local. Ele permite criar slides com gráficos visuais e dados apresentados como tabelas do Excel — sem bibliotecas adicionais ou integrações complexas.