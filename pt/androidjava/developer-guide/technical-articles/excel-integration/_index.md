---
title: Integrar Dados do Excel em Apresentações PowerPoint
linktitle: Integração Excel
type: docs
weight: 330
url: /pt/androidjava/excel-integration/
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
- Android
- Java
- Aspose.Slides
description: "Leia dados de pastas de trabalho do Excel no Aspose.Slides usando a API ExcelDataWorkbook. Carregue planilhas e células e use os valores para gerar apresentações PowerPoint orientadas a dados."
---
## **Introdução**

Apresentações do PowerPoint são uma forma poderosa de exibir e comunicar informações. Elas são frequentemente usadas em conjunto com pastas de trabalho do Excel, onde o Excel serve como uma excelente fonte de dados estruturados e o PowerPoint se destaca na visualização desses dados para o público.

Existem muitos cenários práticos em que combinar Excel e PowerPoint é essencial: mala direta, preenchimento de tabelas de dados, geração de um slide por registro de dados (geração em lote de slides), criação de materiais de treinamento e consolidação de múltiplos relatórios do Excel em uma única apresentação, entre outros.

Até agora, a implementação desses recursos com a API Aspose.Slides exigia depender de soluções de terceiros como Aspose.Cells. Embora essas ferramentas sejam robustas, podem ser excessivamente complexas e caras para usuários que precisam apenas de funcionalidade básica de integração de dados.

## **Como funciona**

Para facilitar o trabalho com dados do Excel e torná‑lo mais simplificado, o Aspose.Slides introduziu novas classes para leitura de dados de pastas de trabalho do Excel e importação de conteúdo em uma apresentação. Esse recurso abre novas possibilidades poderosas para usuários da API que desejam usar o Excel como fonte de dados em seus fluxos de trabalho de apresentação.

A nova funcionalidade foi projetada para acesso a dados de uso geral e não está integrada ao Modelo de Objeto de Documento da Apresentação (DOM). Isso significa que *não permite editar ou salvar arquivos do Excel* — seu único objetivo é abrir pastas de trabalho e navegar pelo seu conteúdo para recuperar dados de células.

No núcleo desse recurso está a nova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/exceldataworkbook/). Essa classe permite carregar uma pasta de trabalho do Excel a partir de um arquivo local ou de um fluxo. Depois de carregada, ela oferece várias sobrecargas do método [getCell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) que você pode usar para recuperar células específicas por sua posição (por exemplo, índices de linha e coluna ou intervalos nomeados).

Cada chamada ao [getCell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) retorna uma instância da classe [ExcelDataCell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/exceldatacell/). Esse objeto representa uma única célula na pasta de trabalho do Excel e fornece acesso ao seu valor de maneira simples e intuitiva.

#### **Importar um gráfico do Excel**

O próximo passo para ampliar a funcionalidade é a classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/excelworkbookimporter/). Essa classe utilitária fornece recursos para importar conteúdo de uma pasta de trabalho do Excel para uma apresentação. Ela contém várias sobrecargas do método [addChartFromWorkbook](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) que ajudam a recuperar o gráfico selecionado da pasta de trabalho do Excel especificada e adicioná‑lo ao final da coleção de formas fornecida nas coordenadas indicadas.

Em resumo, trata‑se de uma API leve e direta para leitura de dados do Excel — exatamente o que muitos desenvolvedores precisam sem a sobrecarga de uma biblioteca completa de processamento de planilhas.

## **Vamos codar**

### **Exemplo de cenário de mala direta**

No exemplo a seguir, implementaremos um cenário simples de Mala Direta gerando várias apresentações com base nos dados armazenados em uma pasta de trabalho do Excel.

Para começar, precisamos de duas coisas:
1. Uma pasta de trabalho do Excel contendo os dados

![Exemplo de dados do Excel](example1_image0.png)

2.  Modelo de apresentação do PowerPoint

![Exemplo de modelo do PowerPoint](example1_image1.png)

```java
// Carregar a pasta de trabalho do Excel com dados dos funcionários.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Carregar o modelo de apresentação.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iterar pelas linhas do Excel (excluindo o cabeçalho na linha 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Criar uma nova apresentação para cada registro de funcionário.
        Presentation employeePresentation = new Presentation();

        try {
            // Remover o slide em branco padrão.
            employeePresentation.getSlides().removeAt(0);

            // Clonar o slide do modelo na nova apresentação.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Obter parágrafos da forma alvo (presume-se que o índice da forma 1 seja usado).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Substituir os marcadores de posição pelos dados do Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Salvar a apresentação personalizada em um arquivo separado.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Resultado](example1_image2.png)

### **Exemplo de tabela do Excel**

No segundo exemplo, simplesmente copiamos dados de uma tabela do Excel e os exibimos em um slide do PowerPoint em um formato visualmente mais atraente.

Neste exemplo, reutilizamos a mesma pasta de trabalho do Excel do primeiro exemplo, que contém uma tabela simples de funcionários.

```java
// Carregar a pasta de trabalho do Excel contendo os dados dos funcionários.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Criar uma nova apresentação PowerPoint.
Presentation presentation = new Presentation();

try {
    // Adicionar uma forma de tabela ao primeiro slide.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Preencher a tabela do PowerPoint com dados da pasta de trabalho do Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Salvar a apresentação resultante em um arquivo.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Resultado](example2_image0.png)

### **Exemplo de importação de gráfico do Excel**

Neste exemplo, importamos um gráfico da primeira planilha da pasta de trabalho do Excel usada no exemplo anterior. O gráfico será vinculado à pasta de trabalho externa na apresentação resultante.

Primeiro, adicionamos um gráfico de pizza à pasta de trabalho do Excel com base na tabela de funcionários.

![Exemplo de gráfico do Excel](example3_image0.png)

```java
// Criar uma nova apresentação PowerPoint.
Presentation presentation = new Presentation();
try {
    // Obter a coleção de formas do primeiro slide.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importar o gráfico chamado "Chart 1" da primeira planilha da pasta de trabalho e adicioná-lo à coleção de formas.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Salvar a apresentação resultante em um arquivo.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Resultado](example3_image1.png)

### **Exemplo de importação de todos os gráficos do Excel**

Imagine que você tem uma pasta de trabalho do Excel cheia de gráficos e precisa importá‑los todos para uma apresentação. Cada gráfico deve ser colocado em um novo slide.

O código a seguir itera por todas as planilhas do arquivo Excel de origem, extrai os gráficos de cada planilha e adiciona cada gráfico a um slide separado usando um layout de slide em branco. Na apresentação resultante, apenas os dados do gráfico serão incorporados, não a pasta de trabalho completa.

```java
// Carregar a pasta de trabalho do Excel contendo os dados dos funcionários.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Criar uma nova apresentação PowerPoint.
Presentation presentation = new Presentation();
try {
    // Recuperar o layout de slide em branco.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Obter os nomes de todas as planilhas contidas na pasta de trabalho do Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Recuperar um mapa que associa índices de gráficos a nomes de gráficos para a planilha.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Adicionar um novo slide usando o layout em branco.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Importar o gráfico especificado da pasta de trabalho do Excel para a coleção de formas do slide.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Salvar a apresentação resultante em um arquivo.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Resumo**

Esse mecanismo, disponível diretamente no Aspose.Slides, combina o trabalho com dados do Excel e apresentações em um só lugar. Ele permite criar slides com gráficos visuais e dados apresentados como tabelas do Excel — sem bibliotecas adicionais ou integrações complexas.