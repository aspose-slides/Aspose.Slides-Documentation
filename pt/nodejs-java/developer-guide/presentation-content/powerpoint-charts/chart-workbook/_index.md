---
title: Gerenciar pastas de trabalho de gráficos em apresentações usando JavaScript
linktitle: Pasta de trabalho de gráfico
type: docs
weight: 70
url: /pt/nodejs-java/chart-workbook/
keywords:
- pasta de trabalho de gráfico
- dados de gráfico
- célula da pasta de trabalho
- rótulo de dados
- planilha
- fonte de dados
- pasta de trabalho externa
- dados externos
- cache de gráfico
- recuperação de pasta de trabalho
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra o Aspose.Slides para Node.js via Java: gerencie facilmente pastas de trabalho de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráficos por meio de fluxos de pastas de trabalho, usar células da pasta de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de fonte de dados para os valores do gráfico.

Também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráficos. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

Para células de pasta de trabalho que representam dados ausentes, veja [Controlar a exibição de células vazias](/slides/pt/nodejs-java/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação de gráfico de linhas dos modos de exibição disponíveis.

## **Incluir dados de linhas e colunas ocultas**

Use [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) para controlar se um gráfico plota dados de linhas e colunas de planilha ocultas. Defina como `true` para plotar apenas células visíveis, ou `false` para incluir tanto células visíveis quanto ocultas. Esta configuração controla a plotagem do gráfico; não oculta nem exibe linhas ou colunas de planilha.

Baixe [hidden-source-data.pptx](hidden-source-data.pptx) e coloque-o no diretório de trabalho. Seu primeiro slide contém um gráfico de colunas como a primeira forma. A planilha incorporada, `Sheet1`, contém o seguinte intervalo de origem, `A1:C4`. A linha 3 e a coluna C estão ocultas, mas suas células ainda contêm valores.

| Linha da planilha | A: Mês | B: Varejo | C: Atacado (coluna oculta) |
| --- | --- | --- | --- |
| 2 | Janeiro | 10 | 30 |
| 3 (linha oculta) | Fevereiro | 40 | 60 |
| 4 | Março | 20 | 50 |

Acesse as células de origem através de [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) e leia [ChartDataCell.isHidden](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatacell/#isHidden) para inspecionar seu status de ocultação. Este método relata o status de ocultação sem alterá-lo. Neste arquivo, B2 está visível, B3 pertence à linha oculta e C2 pertence à coluna oculta; o exemplo imprime `false`, `true` e `true`, respectivamente.

Para este exemplo, atualize os dados do gráfico após alterar a configuração de plotagem: retenha a pasta de trabalho incorporada com [readWorkbookStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) e recarregue-a com [writeWorkbookStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). Ao incluir todas as células, use também [setRange](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#setRange) para restaurar o intervalo completo, incluindo a categoria de fevereiro ocultada. Simplesmente mudar a flag não é suficiente para atualizar os dados em cache do gráfico e os rótulos de categoria deste exemplo. O exemplo converte o buffer retornado do Node.js para um array de bytes Java antes de passá‑lo ao método de gravação.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Atualizar os dados do gráfico a partir da pasta de trabalho incorporada.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Restaurar o intervalo de origem completo, incluindo categorias ocultas.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        // A primeira forma não é um gráfico.
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

O exemplo salva `hidden_cells_true.pptx` contendo apenas os valores de Varejo visíveis (10 e 20), e `hidden_cells_false.pptx` com todos os seis valores. As imagens abaixo ilustram os dois modos de plotagem. A linha 3 e a coluna C permanecem ocultas em ambas as pastas de trabalho incorporadas.

| Apenas células visíveis (`true`) | Todas as células (`false`) |
| --- | --- |
| ![Apenas células visíveis: valores de Varejo 10 e 20 para Janeiro e Março.](hidden_cells_True.png) | ![Todas as células: valores de Varejo e Atacado para Janeiro, Fevereiro e Março.](hidden_cells_False.png) |

Uma célula oculta contendo um valor é diferente de uma célula vazia. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) controla como valores ausentes são exibidos; não inclui ou exclui dados de origem ocultos. Veja [Controlar a exibição de células vazias](/slides/pt/nodejs-java/chart-series/#control-the-display-of-empty-cells) para um exemplo.

## **Ler e gravar dados de gráfico a partir de uma pasta de trabalho**

Aspose.Slides for Node.js via Java fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) que permitem ler e gravar pastas de trabalho de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Nota** que os dados do gráfico precisam estar organizados da mesma forma ou ter uma estrutura semelhante à origem.

Este exemplo abre `chart.pptx`, que deve conter um gráfico como a primeira forma em seu primeiro slide. Ele lê a pasta de trabalho incorporada em um array de bytes, limpa as séries e categorias existentes, e grava a mesma pasta de trabalho de volta. As alterações permanecem na memória; o exemplo não salva a apresentação.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Validar layout do gráfico após modificação da pasta de trabalho**

Ao substituir uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/#validateChartLayout) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a pasta de trabalho atualizada de volta no gráfico. Este exemplo requer `chart.pptx` com um gráfico como a primeira forma em seu primeiro slide. O comentário marca onde a edição da pasta de trabalho ocorreria; o exemplo executável grava a pasta de trabalho original de volta e valida o layout na memória.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Modifique os bytes da pasta de trabalho aqui, por exemplo, usando Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Limpar as coleções remove referências de dados obsoletos antes que a pasta de trabalho seja gravada de volta. Reconstrua quaisquer mapeamentos de séries e categorias necessários para a pasta de trabalho atualizada antes de usar o gráfico.

## **Definir uma célula da pasta de trabalho como rótulo de dados do gráfico**

Você pode usar texto de células da pasta de trabalho como rótulos de dados do gráfico. As etapas a seguir mostram como vincular os rótulos em um gráfico de bolhas às células em sua pasta de dados.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o primeiro slide pelo seu índice baseado em zero.
3. Adicione um gráfico de bolhas com dados padrão.
4. Acesse as séries do gráfico.
5. Defina a célula da pasta de trabalho como um rótulo de dados.
6. Salve a apresentação.

Este exemplo abre `chart2.pptx`, que deve conter ao menos um slide, e adiciona um gráfico de bolhas com dados padrão. Ele usa as células A10:A12 na planilha 0 para os três primeiros rótulos na primeira série, habilita rótulos a partir de células e salva o resultado em `resultchart.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gerenciar planilhas**

O método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) fornece acesso às planilhas em uma pasta de trabalho de gráfico. Este exemplo cria um gráfico de pizza com dados padrão e imprime o nome de cada planilha no console.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Especificar o tipo de fonte de dados**

Este exemplo cria um gráfico de colunas 3D com dados padrão e define dois nomes de série usando diferentes fontes de dados. O primeiro nome usa um literal de string; o segundo usa a célula C1 na planilha 0. A enumeração [DataSourceType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datasourcetype/) seleciona a fonte para cada nome. O resultado é salvo em `pres.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Detectar formatos de pasta de trabalho incorporada não suportados**

Aspose.Slides não suporta o formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) em [ChartData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos. Este exemplo inspeciona as formas no primeiro slide de `sample.pptx`, ignora formas que não sejam gráficos e imprime uma mensagem de diagnóstico para cada gráfico com uma pasta de trabalho .xlsb incorporada.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Ler ou modificar os dados da pasta de trabalho do gráfico suportados aqui.
    }
} finally {
    presentation.dispose();
}
```

## **Pasta de trabalho externa**

Aspose.Slides suporta o uso de pastas de trabalho externas como fonte de dados para gráficos.

### **Criar uma pasta de trabalho externa**

Use [readWorkbookStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) e [setExternalWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) para exportar uma pasta de trabalho de gráfico incorporada para um arquivo e vincular o gráfico a essa pasta de trabalho externa.

Este exemplo cria um gráfico de pizza com dados padrão, grava sua pasta de trabalho em `externalWorkbook1.xlsx` e conclui a gravação do arquivo antes de atribuir o arquivo como fonte de dados do gráfico. Ele salva a apresentação vinculada em `externalWorkbook.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Definir uma pasta de trabalho externa**

Usando o método [setExternalWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook), você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Este método também pode ser usado para atualizar o caminho para a pasta de trabalho externa (se esta foi movida).

Embora você não possa editar os dados em pastas de trabalho armazenadas em locais ou recursos remotos, ainda pode usar tais pastas de trabalho como uma fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele é convertido automaticamente para um caminho absoluto.

Este exemplo requer `externalWorkbook.xlsx` no diretório de trabalho. Sua planilha chamada `Sheet1` deve conter um nome de série em B1, nomes de categorias em A2:A4 e valores numéricos em B2:B4. O exemplo cria um gráfico de pizza, vincula a pasta de trabalho e usa [setRange](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#setRange) para mapear A1:B4 para uma série e três categorias. Ele salva o resultado em `Presentation_with_externalWorkbook.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O parâmetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) controla se a pasta de trabalho é carregada.

* Quando `updateChartData` é `false`, somente o caminho da pasta de trabalho é atualizado. Os dados do gráfico não são carregados nem atualizados a partir da pasta de trabalho de destino, de modo que a pasta de trabalho pode estar indisponível.
* Quando `updateChartData` é `true`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

O exemplo a seguir atribui uma URL de espaço reservado com `updateChartData` definido como `false`. Ele mantém os dados padrão do gráfico de pizza e salva a apresentação sem carregar a pasta de trabalho indisponível.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Obter o caminho da pasta de trabalho da fonte de dados externa de um gráfico**

Para identificar a pasta de trabalho vinculada a um gráfico, primeiro verifique se o gráfico usa uma fonte de dados externa. Se usar, você pode recuperar o caminho da pasta de trabalho seguindo estas etapas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o primeiro slide pelo seu índice baseado em zero.
3. Verifique se a primeira forma é um gráfico.
4. Leia o tipo de fonte de dados do gráfico.
5. Se a fonte for uma pasta de trabalho externa, leia seu caminho.

Este exemplo abre `externalWorkbook.pptx`, criado no exemplo anterior, e inspeciona a primeira forma no primeiro slide. Se for um gráfico vinculado a uma pasta de trabalho externa, o exemplo imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) no console. Em seguida, salva uma cópia da apresentação em `Result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Editar dados do gráfico**

Você pode editar os dados em pastas de trabalho externas da mesma forma que faz alterações no conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este exemplo requer `presentation.pptx` com um gráfico como a primeira forma no primeiro slide e uma pasta de trabalho externa acessível. Ele define o valor baseado em célula do primeiro ponto de dados na primeira série como 100 e salva a apresentação em `presentation_out.pptx`. Editar valores de célula pode atualizar o arquivo XLSX externo vinculado, portanto use uma cópia se precisar preservar a pasta de trabalho original.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Recuperar uma pasta de trabalho do cache do gráfico**

Se um gráfico usa uma pasta de trabalho externa que está ausente ou indisponível, o Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/), chame [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), e defina [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) como `true` antes de abrir a apresentação.

O exemplo JavaScript a seguir abre `presentation.pptx`, cuja primeira forma no primeiro slide deve ser um gráfico que referencia uma pasta de trabalho externa indisponível, e acessa os dados recuperados via [Chart.getChartData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/#getChartData) e [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Leia ou modifique os dados da pasta de trabalho recuperada aqui.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, o Aspose.Slides lança uma exceção. Habilite a recuperação somente quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **Perguntas frequentes**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**  
Sim. Um gráfico possui um [data source type](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#getDataSourceType) e um [path to an external workbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); se a fonte for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Os caminhos relativos para pastas de trabalho externas são suportados, e como são armazenados?**  
Sim. Se você especificar um caminho relativo, ele é convertido automaticamente para um caminho absoluto. A apresentação armazena o caminho absoluto no arquivo PPTX, portanto mover a pasta de trabalho pode exigir a atualização do link.

**Posso usar pastas de trabalho localizadas em recursos/redes compartilhadas?**  
Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. Contudo, editar pastas de trabalho remotas diretamente pelo Aspose.Slides não é suportado — elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**  
A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). Editar dados de gráfico baseados em célula também pode atualizar o arquivo XLSX local vinculado. Use uma cópia da pasta de trabalho se o original precisar permanecer inalterado.

**O que devo fazer se o arquivo externo estiver protegido por senha?**  
O Aspose.Slides não aceita senha ao vincular. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**  
Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, atualizar esse arquivo será refletido em cada gráfico na próxima vez que os dados forem carregados.