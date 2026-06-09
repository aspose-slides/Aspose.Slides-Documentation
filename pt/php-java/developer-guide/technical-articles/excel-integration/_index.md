---
title: Integrar Dados do Excel em Apresentações do PowerPoint
linktitle: Integração do Excel
type: docs
weight: 330
url: /pt/php-java/excel-integration/
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
- PHP
- Aspose.Slides
description: "Leia dados de pastas de trabalho do Excel usando Aspose.Slides para PHP via Java. Carregue planilhas e células e use os valores para gerar apresentações do PowerPoint orientadas a dados."
---
## **Introdução**

Apresentações do PowerPoint são uma forma poderosa de exibir e comunicar informações. Elas são frequentemente usadas em conjunto com pastas de trabalho do Excel, onde o Excel serve como uma excelente fonte de dados estruturados e o PowerPoint se destaca na visualização desses dados para o público.

Existem muitos cenários práticos em que combinar Excel e PowerPoint é essencial: mala direta, preenchimento de tabelas de dados, geração de um slide por registro de dados (geração em lote de slides), criação de materiais de treinamento e consolidação de múltiplos relatórios do Excel em uma única apresentação, entre outros.

Até agora, implementar esses recursos com a API Aspose.Slides exigia depender de soluções de terceiros como Aspose.Cells. Embora essas ferramentas sejam robustas, podem ser excessivamente complexas e custosas para usuários que precisam apenas de funcionalidade básica de integração de dados.

## **Como funciona**

Para facilitar o trabalho com dados do Excel e torná‑lo mais simplificado, o Aspose.Slides introduziu novas classes para ler dados de pastas de trabalho do Excel e importar conteúdo para uma apresentação. Esse recurso abre novas possibilidades poderosas para os usuários da API que desejam usar o Excel como fonte de dados em seus fluxos de trabalho de apresentação.

A nova funcionalidade foi projetada para acesso a dados de uso geral e não está integrada ao Modelo de Objetos de Documento da Apresentação (DOM). Isso significa que *não permite editar ou salvar arquivos do Excel* — seu único objetivo é abrir pastas de trabalho e percorrer seu conteúdo para recuperar os dados das células.

No cerne desse recurso está a nova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/exceldataworkbook/). Essa classe permite carregar uma pasta de trabalho do Excel a partir de um arquivo local ou de um stream. Depois de carregada, ela fornece várias sobrecargas do método [getCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/exceldataworkbook/#getCell), que você pode usar para recuperar células específicas pela sua posição (por exemplo, índices de linha e coluna ou intervalos nomeados).

Cada chamada ao método [getCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/exceldataworkbook/#getCell) retorna uma instância da classe [ExcelDataCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/exceldatacell/). Esse objeto representa uma única célula na pasta de trabalho do Excel e fornece acesso ao seu valor de forma simples e intuitiva.

#### **Importar um gráfico do Excel**

O próximo passo para estender a funcionalidade é a classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/excelworkbookimporter/). Essa classe utilitária oferece funcionalidades para importar conteúdo de uma pasta de trabalho do Excel para uma apresentação. Ela contém várias sobrecargas do método [addChartFromWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), que ajudam a recuperar o gráfico selecionado da pasta de trabalho do Excel especificada e adicioná‑lo ao final da coleção de formas fornecida nas coordenadas especificadas.

Em resumo, trata‑se de uma API leve e direta para leitura de dados do Excel — exatamente o que muitos desenvolvedores precisam sem a sobrecarga de uma biblioteca completa de processamento de planilhas.

## **Vamos codar**

### **Exemplo de cenário de Mala Direta**

No exemplo a seguir, implementaremos um cenário simples de Mala Direta gerando múltiplas apresentações com base nos dados armazenados em uma pasta de trabalho do Excel.

Para começar, precisamos de duas coisas:
1. Uma pasta de trabalho do Excel contendo os dados

![Exemplo de dados do Excel](example1_image0.png)

2. Modelo de apresentação do PowerPoint

![Exemplo de modelo do PowerPoint](example1_image1.png)

```php
// Carregar a pasta de trabalho Excel com dados de funcionários.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Carregar o modelo de apresentação.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Percorrer as linhas do Excel (excluindo o cabeçalho na linha 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Criar uma nova apresentação para cada registro de funcionário.
        $employeePresentation = new Presentation();

        try {
            // Remover o slide vazio padrão.
            $employeePresentation->getSlides()->removeAt(0);

            // Clonar o slide do modelo na nova apresentação.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Obter parágrafos da forma alvo (presume que o índice da forma 1 está sendo usado).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Substituir os marcadores de posição pelos dados do Excel.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Salvar a apresentação personalizada em um arquivo separado.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Resultado](example1_image2.png)

### **Exemplo de tabela do Excel**

No segundo exemplo, copiamos simplesmente os dados de uma tabela do Excel e os exibimos em um slide do PowerPoint em um formato visualmente mais atraente.

Neste exemplo, reutilizamos a mesma pasta de trabalho do Excel do primeiro exemplo, que contém uma tabela simples de funcionários.

```php
// Carregar a pasta de trabalho Excel contendo os dados dos funcionários.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Criar uma nova apresentação PowerPoint.
$presentation = new Presentation();

try {
    // Adicionar uma forma de tabela ao primeiro slide.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Preencher a tabela do PowerPoint com dados da pasta de trabalho Excel.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Salvar a apresentação resultante em um arquivo.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Resultado](example2_image0.png)

### **Exemplo de importação de um gráfico do Excel**

Neste exemplo, importamos um gráfico da primeira planilha da pasta de trabalho do Excel usada no exemplo anterior. O gráfico será vinculado ao workbook externo na apresentação resultante.

Primeiro, adicionamos um gráfico de Pizza ao workbook do Excel com base na tabela de funcionários.

![Exemplo de gráfico do Excel](example3_image0.png)

```php
// Criar uma nova apresentação PowerPoint.
$presentation = new Presentation();
try {
    // Obter a coleção de formas do primeiro slide.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Importar o gráfico chamado "Chart 1" da primeira planilha da pasta de trabalho e adicioná-lo à coleção de formas.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Salvar a apresentação resultante em um arquivo.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Resultado](example3_image1.png)

### **Exemplo de importação de todos os gráficos do Excel**

Imagine que você tem uma pasta de trabalho do Excel repleta de gráficos e precisa importá‑los todos para uma apresentação. Cada gráfico deve ser colocado em um novo slide.

O código a seguir itera sobre todas as planilhas no arquivo Excel de origem, extrai os gráficos de cada planilha e adiciona cada gráfico a um slide separado usando um layout de slide em branco. Na apresentação resultante, somente os dados do gráfico serão incorporados, não a pasta de trabalho inteira.

```php
// Carregar a pasta de trabalho Excel contendo os dados dos funcionários.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Criar uma nova apresentação PowerPoint.
$presentation = new Presentation();
try {
    // Recuperar o layout de slide em branco.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Obter os nomes de todas as planilhas contidas na pasta de trabalho Excel.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Recuperar um mapa que associa índices de gráficos a nomes de gráficos para a planilha.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Adicionar um novo slide usando o layout em branco.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Importar o gráfico especificado da pasta de trabalho Excel para a coleção de formas do slide.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Salvar a apresentação resultante em um arquivo.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Resumo**

Esse mecanismo, disponível diretamente no Aspose.Slides, combina o trabalho com dados do Excel e apresentações em um único local. Ele permite criar slides com gráficos visuais e dados apresentados como tabelas do Excel — sem bibliotecas adicionais ou integrações complexas.