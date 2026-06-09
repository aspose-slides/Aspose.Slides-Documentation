---
title: Integrar Dados do Excel em Apresentações PowerPoint
linktitle: Integração Excel
type: docs
weight: 330
url: /pt/nodejs-java/excel-integration/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Leia dados de pastas de trabalho do Excel em JavaScript com Aspose.Slides. Carregue planilhas e células e use os valores para gerar apresentações PowerPoint orientadas a dados."
---
## **Introdução**

Apresentações do PowerPoint são uma maneira poderosa de exibir e comunicar informações. Elas são frequentemente usadas em conjunto com pastas de trabalho do Excel, onde o Excel serve como uma excelente fonte de dados estruturados e o PowerPoint se destaca em visualizar esses dados para o público.

Existem muitos cenários práticos em que combinar Excel e PowerPoint é essencial: mala direta, preenchimento de tabelas de dados, geração de um slide por registro de dados (geração em lote de slides), criação de materiais de treinamento e consolidação de vários relatórios do Excel em uma única apresentação, entre outros.

Até agora, implementar esses recursos com a API Aspose.Slides exigia a dependência de soluções de terceiros como o Aspose.Cells. Embora essas ferramentas sejam robustas, podem ser excessivamente complexas e caras para usuários que precisam apenas de funcionalidades básicas de integração de dados.

## **Como funciona**

Para facilitar e tornar mais eficiente o trabalho com dados do Excel, o Aspose.Slides introduziu novas classes para ler dados de pastas de trabalho do Excel e importar conteúdo para uma apresentação. Esse recurso abre poderosas novas possibilidades para os usuários da API que desejam utilizar o Excel como fonte de dados em seus fluxos de trabalho de apresentação.

A nova funcionalidade foi projetada para acesso a dados de uso geral e não está integrada ao Document Object Model (DOM) da apresentação. Isso significa que *não permite editar ou salvar arquivos do Excel* — seu único objetivo é abrir pastas de trabalho e navegar em seu conteúdo para recuperar os dados das células.

No núcleo desse recurso está a nova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/exceldataworkbook/). Essa classe permite carregar uma pasta de trabalho do Excel a partir de um arquivo local ou de um stream. Uma vez carregada, ela fornece várias sobrecargas do método [getCell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/exceldataworkbook/#getCell), que podem ser usadas para recuperar células específicas pela sua posição (por exemplo, índices de linha e coluna ou intervalos nomeados).

Cada chamada ao [getCell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/exceldataworkbook/#getCell) devolve uma instância da classe [ExcelDataCell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/exceldatacell/). Esse objeto representa uma única célula na pasta de trabalho do Excel e fornece acesso ao seu valor de forma simples e intuitiva.

#### **Importar um gráfico do Excel**

O próximo passo para ampliar a funcionalidade é a classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/excelworkbookimporter/). Essa classe utilitária fornece funcionalidade para importar conteúdo de uma pasta de trabalho do Excel para uma apresentação. Ela contém várias sobrecargas do método [addChartFromWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), que ajudam a recuperar o gráfico selecionado da pasta de trabalho do Excel especificada e adicioná‑lo ao final da coleção de formas fornecida nas coordenadas especificadas.

Em resumo, é uma API leve e direta para ler dados do Excel — exatamente o que muitos desenvolvedores precisam sem o overhead de uma biblioteca completa de processamento de planilhas.

## **Vamos codar**

### **Exemplo de cenário de mala direta**

No exemplo a seguir, implementaremos um cenário simples de mala direta gerando várias apresentações com base em dados armazenados em uma pasta de trabalho do Excel.

Para começar, precisamos de duas coisas:
1. Uma pasta de trabalho do Excel contendo os dados

![Excel data example](example1_image0.png)

2. Modelo de apresentação do PowerPoint

![PowerPoint template example](example1_image1.png)

```js
// Carregar a pasta de trabalho do Excel com dados dos funcionários.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Carregar o modelo de apresentação.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Percorrer as linhas do Excel (excluindo o cabeçalho na linha 0).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Criar uma nova apresentação para cada registro de funcionário.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Remover o slide em branco padrão.
            employeePresentation.getSlides().removeAt(0);

            // Clonar o slide modelo na nova apresentação.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Obter parágrafos da forma alvo (presume que o índice da forma 1 seja usado).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Substituir os marcadores de posição pelos dados do Excel.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Salvar a apresentação personalizada em um arquivo separado.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Result](example1_image2.png)

### **Exemplo de tabela do Excel**

No segundo exemplo, simplesmente copiamos dados de uma tabela do Excel e os exibimos em um slide do PowerPoint em um formato visualmente mais atraente.

Neste exemplo, reutilizamos a mesma pasta de trabalho do Excel do primeiro exemplo, que contém uma tabela simples de funcionários.

```js
// Carregar a pasta de trabalho do Excel que contém os dados dos funcionários.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Criar uma nova apresentação PowerPoint.
let presentation = new aspose.slides.Presentation();

try {
    // Adicionar uma forma de tabela ao primeiro slide.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Preencher a tabela do PowerPoint com dados da pasta de trabalho do Excel.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Salvar a apresentação resultante em um arquivo.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example2_image0.png)

### **Exemplo de importação de gráfico do Excel**

Neste exemplo, importamos um gráfico da primeira planilha da pasta de trabalho do Excel usada no exemplo anterior. O gráfico será vinculado à pasta de trabalho externa na apresentação resultante.

Primeiro, adicionamos um gráfico de pizza à pasta de trabalho do Excel com base na tabela de funcionários.

![Excel Chart example](example3_image0.png)

```js
// Criar uma nova apresentação PowerPoint.
let presentation = new aspose.slides.Presentation();
try {
    // Obter a coleção de formas do primeiro slide.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importar o gráfico chamado "Chart 1" da primeira planilha da pasta de trabalho e adicioná-lo à coleção de formas.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Salvar a apresentação resultante em um arquivo.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example3_image1.png)

### **Exemplo de importação de todos os gráficos do Excel**

Imagine que você tem uma pasta de trabalho do Excel cheia de gráficos e precisa importá‑los todos para uma apresentação. Cada gráfico deve ser colocado em um novo slide.

O código a seguir itera por todas as planilhas do arquivo Excel de origem, extrai os gráficos de cada planilha e adiciona cada gráfico a um slide separado usando um layout de slide em branco. Na apresentação resultante, apenas os dados do gráfico serão incorporados, não a pasta de trabalho inteira.

```js
// Carregar a pasta de trabalho do Excel que contém os dados dos funcionários.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Criar uma nova apresentação PowerPoint.
let presentation = new aspose.slides.Presentation();
try {
    // Recuperar o layout de slide em branco.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Obter os nomes de todas as planilhas contidas na pasta de trabalho do Excel.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Recuperar um mapa que associa índices de gráficos a nomes de gráficos para a planilha.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Adicionar um novo slide usando o layout em branco.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Importar o gráfico especificado da pasta de trabalho do Excel para a coleção de formas do slide.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Salvar a apresentação resultante em um arquivo.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Resumo**

Esse mecanismo, disponível diretamente no Aspose.Slides, combina o trabalho com dados do Excel e apresentações em um único local. Ele permite criar slides com gráficos visuais e dados apresentados como tabelas do Excel — sem bibliotecas adicionais ou integrações complexas.