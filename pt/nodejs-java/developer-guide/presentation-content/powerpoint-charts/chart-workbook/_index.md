---
title: Gerenciar Livros de Trabalho de Gráficos em Apresentações Usando JavaScript
linktitle: Livro de Trabalho de Gráfico
type: docs
weight: 70
url: /pt/nodejs-java/chart-workbook/
keywords:
- livro de trabalho de gráfico
- dados do gráfico
- célula do livro de trabalho
- rótulo de dados
- planilha
- fonte de dados
- livro de trabalho externo
- dados externos
- cache de gráfico
- recuperação de livro de trabalho
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra Aspose.Slides para Node.js via Java: gerencie facilmente livros de trabalho de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com livros de trabalho de gráfico no Aspose.Slides. Ele mostra como ler e gravar dados de gráfico através de streams de livro de trabalho, usar células do livro de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de fonte de dados para valores do gráfico.

Ele também cobre o trabalho com livros de trabalho externos como fontes de dados de gráfico. Os exemplos demonstram como criar e atribuir um livro de trabalho externo, recuperar o caminho de um livro de trabalho externo vinculado a um gráfico e editar os dados do gráfico quando o livro de trabalho está disponível.

Para células de livro de trabalho que representam dados ausentes, veja [Controlar a Exibição de Células Vazias](/slides/pt/nodejs-java/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação de gráfico de linhas dos modos de exibição disponíveis.

## **Incluir Dados de Linhas e Colunas Ocultas**

Use [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) para controlar se um gráfico traça dados de linhas e colunas de planilha ocultas. Defina como `true` para traçar apenas células visíveis, ou `false` para incluir tanto células visíveis quanto ocultas. Esta configuração controla a plotagem do gráfico; não oculta ou exibe linhas ou colunas da planilha.

A [apresentação de exemplo](hidden-source-data.pptx) contém um gráfico de colunas como a primeira forma no seu primeiro slide. A planilha incorporada, `Sheet1`, contém o seguinte intervalo de origem, `A1:C4`. A linha 3 e a coluna C estão ocultas, mas suas células ainda contêm valores.

| Linha da planilha | A: Mês | B: Varejo | C: Atacado (coluna oculta) |
| --- | --- | --- | --- |
| 2 | Janeiro | 10 | 30 |
| 3 (linha oculta) | Fevereiro | 40 | 60 |
| 4 | Março | 20 | 50 |

Acesse as células de origem através de [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) e leia [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) para inspecionar seu status de ocultação. Este método relata o status oculto sem alterá-lo. Neste arquivo, B2 está visível, B3 pertence à linha oculta e C2 pertence à coluna oculta; o exemplo imprime `false`, `true` e `true`, respectivamente.

Para este exemplo, atualize os dados do gráfico após mudar a configuração de plotagem: mantenha o livro de trabalho incorporado com [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) e recarregue‑o com [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). Ao incluir todas as células, também use [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) para restaurar o intervalo completo, incluindo a categoria de fevereiro ocultada. Simplesmente mudar a bandeira não é suficiente para atualizar os dados de gráfico em cache e os rótulos de categoria deste exemplo. O exemplo converte o buffer Node.js retornado em um array de bytes Java antes de passá‑lo ao método de gravação.

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

            // Atualizar os dados do gráfico a partir do livro de trabalho incorporado.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Restaurar o intervalo de origem completo, incluindo categorias ocultas.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

O exemplo salva duas versões da apresentação: uma com apenas os valores de Varejo visíveis (10 e 20) e outra com todos os seis valores. As imagens abaixo ilustram os dois modos de plotagem. A linha 3 e a coluna C permanecem ocultas em ambos os livros de trabalho incorporados.

| Apenas células visíveis (`true`) | Todas as células (`false`) |
| --- | --- |
| ![Apenas células visíveis: valores de Varejo 10 e 20 para Janeiro e Março.](hidden_cells_True.png) | ![Todas as células: valores de Varejo e Atacado para Janeiro, Fevereiro e Março.](hidden_cells_False.png) |

Uma célula oculta contendo um valor é diferente de uma célula vazia. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) controla como valores ausentes são exibidos; não inclui ou exclui dados de origem ocultos. Veja [Controlar a Exibição de Células Vazias](/slides/pt/nodejs-java/chart-series/#control-the-display-of-empty-cells) para um exemplo.

## **Recuperar o Intervalo de Dados de um Gráfico**

Antes de atualizar os dados do livro de trabalho em uma apresentação existente, inspecione os intervalos de origem para identificar quais células da planilha cada gráfico usa. O método [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) retorna o intervalo de dados atual como uma fórmula qualificada da planilha, como `Sheet1!$A$1:$D$5`. Aqui, `Sheet1` é o nome da planilha, `!` separa‑o do intervalo de células e `$A$1:$D$5` identifica as células de A1 a D5, inclusive. Os sinais de dólar indicam referências absolutas de linha e coluna.

O método lê o intervalo atual sem alterar o gráfico ou seu livro de trabalho. Se o gráfico não usar um livro de trabalho como fonte de dados, ele lança `InvalidOperationException`. Para mais informações, veja a [Referência da API ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Este exemplo abre uma apresentação e verifica as formas diretamente em cada slide para gráficos. Ele imprime o nome de cada gráfico e seu intervalo de origem. Se um gráfico não usar um livro de trabalho, ele imprime uma mensagem e continua para o próximo gráfico.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ler e Gravar Dados de Gráfico a partir de um Livro de Trabalho**

Aspose.Slides for Node.js via Java fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) e [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) que permitem ler e gravar livros de trabalho de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Nota** que os dados do gráfico precisam estar organizados da mesma maneira ou ter uma estrutura semelhante à origem.

Este exemplo usa uma apresentação com um gráfico como a primeira forma no seu primeiro slide. Ele lê o livro de trabalho incorporado em um array de bytes, limpa as séries e categorias existentes e grava o mesmo livro de volta. As alterações permanecem na memória; o exemplo não salva a apresentação.

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

### **Validar o Layout do Gráfico Após Modificação do Livro de Trabalho**

Quando você substitui um livro de trabalho incorporado por um modificado, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar o livro de trabalho atualizado de volta ao gráfico. Este exemplo usa um gráfico que é a primeira forma no primeiro slide. O comentário marca onde a edição do livro de trabalho ocorreria; o exemplo executável grava o livro de trabalho original de volta e valida o layout na memória.

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

        // Modifique os bytes do workbook aqui, por exemplo, usando Aspose.Cells.

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

Limpar as coleções remove referências de dados obsoletas antes que o livro de trabalho seja gravado de volta. Reconstrua quaisquer mapeamentos de séries e categorias necessários para o livro de trabalho atualizado antes de usar o gráfico.

## **Definir Formatos Numéricos Personalizados para Células do Livro de Trabalho**

Use [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) para controlar como os valores numéricos aparecem no livro de trabalho incorporado de um gráfico. Por exemplo, um relatório pode precisar de uma taxa de conversão exibida como percentual com quatro casas decimais e um coeficiente exibido com cinco casas decimais. Mantenha ambos os valores numéricos para que permaneçam disponíveis para cálculos e plotagem do gráfico.

Um formato numérico altera a exibição, não o valor armazenado. O formato `0.0000%` exibe `0.125` como `12.5000%`; não substitui o número armazenado por `12.5`. Da mesma forma, `0.00000` exibe `0.1234567` como `0.12346` sem arredondar o valor armazenado. Se o formato personalizado for uma string vazia (`""`), o formato retornado por [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) será usado.

O exemplo a seguir cria um gráfico de colunas e acessa suas células através de [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). Na planilha 0, B2 contém a taxa de conversão e C2 contém o coeficiente. Ambas as células fornecem valores ao gráfico. O exemplo também habilita rótulos de valor vinculados aos formatos de origem.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Os formatos de célula do livro de trabalho são separados dos formatos definidos diretamente nos eixos do gráfico ou nos rótulos de dados. Neste exemplo, cada rótulo exibe o valor da célula de origem porque [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) está definido como `true`, e segue o formato numérico da origem porque [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) está definido como `true`. Após salvar e reabrir a apresentação, os rótulos exibem `12.5000%` e `0.12346`, como mostrado abaixo. O eixo vertical usa seu próprio formato numérico, atribuído com [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) como `0.00`, com [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) definido como `false`.

Para formatar um rótulo de dados independentemente, defina sua bandeira de vínculo à origem como `false` e atribua um formato com [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). Isso não altera o formato da célula do livro de trabalho. Por exemplo, um formato de rótulo independente `0.00` exibe o primeiro valor como `0.13`, enquanto B2 ainda exibe `12.5000%`. Veja [Chart Data Labels](/slides/pt/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) para formatação direta de rótulos.

A imagem abaixo foi renderizada a partir da apresentação salva após reabri‑la:

![Gráfico de colunas com rótulos vinculados à origem mostrando 12.5000% e 0.12346 e um eixo numérico formatado independentemente.](custom-cell-formats.png)

## **Definir uma Célula de Livro de Trabalho como Rótulo de Dados do Gráfico**

Você pode usar texto de células de livro de trabalho como rótulos de dados do gráfico.

Este exemplo adiciona um gráfico de bolhas com dados padrão ao primeiro slide de uma apresentação existente. Ele usa as células A10:A12 na planilha 0 para os três primeiros rótulos da primeira série, habilita rótulos a partir de células e salva a apresentação atualizada.

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

## **Gerenciar Planilhas**

O método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) fornece acesso às planilhas em um livro de trabalho de gráfico. Este exemplo cria um gráfico de pizza com dados padrão e imprime cada nome de planilha no console.

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

## **Especificar o Tipo de Fonte de Dados**

Os valores dos pontos de série também podem ser armazenados diretamente como literais numéricos. Veja [Set Series Values Using Numeric Literals](/slides/pt/nodejs-java/chart-series/#set-series-values-using-numeric-literals) para um exemplo completo que os salva e os lê. O tipo de origem dos valores dos pontos é separado da configuração interna ou externa do livro de trabalho do gráfico; usar literais numéricos não remove, por si só, o livro de trabalho incorporado.

Este exemplo cria um gráfico de colunas 3D com dados padrão e define dois nomes de série usando fontes de dados diferentes. O primeiro nome usa um literal de string; o segundo usa a célula C1 na planilha 0. A enumeração [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) seleciona a fonte para cada nome. O exemplo salva a apresentação com os nomes de série atualizados.

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

## **Detectar Formatos de Livro de Trabalho Incorporado Não Suportados**

Aspose.Slides não suporta o formato de livro de trabalho binário do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método `getEmbeddedWorkbookType` em [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) para detectar formatos não suportados e pular esses gráficos. Este exemplo inspeciona as formas no primeiro slide de uma apresentação existente, ignora formas que não são gráficos e imprime uma mensagem de diagnóstico para cada gráfico com um livro de trabalho .xlsb incorporado.

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

        // Ler ou modificar os dados suportados do livro de trabalho do gráfico aqui.
    }
} finally {
    presentation.dispose();
}
```

## **Livro de Trabalho Externo**

Aspose.Slides oferece suporte ao uso de livros de trabalho externos como fonte de dados para gráficos.

### **Criar um Livro de Trabalho Externo**

Use [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) e [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) para exportar um livro de trabalho de gráfico incorporado para um arquivo e vincular o gráfico a esse livro de trabalho externo.

Este exemplo cria um gráfico de pizza com dados padrão e exporta seu livro de trabalho. Ele conclui a gravação do arquivo antes de atribuir o livro de trabalho externo como fonte de dados do gráfico, então salva a apresentação vinculada.

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

### **Definir um Livro de Trabalho Externo**

Usando o método [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), você pode atribuir um livro de trabalho externo a um gráfico como sua fonte de dados. Este método também pode ser usado para atualizar um caminho para o livro de trabalho externo (se o último foi movido).

Embora você não possa editar os dados em livros de trabalho armazenados em locais remotos ou recursos, ainda pode usar esses livros de trabalho como fonte de dados externa. Se for fornecido um caminho relativo para um livro de trabalho externo, ele será convertido automaticamente para um caminho completo.

Este exemplo usa um livro de trabalho externo cuja planilha nomeada `Sheet1` contém um nome de série em B1, nomes de categoria em A2:A4 e valores numéricos em B2:B4. O exemplo cria um gráfico de pizza, vincula o livro de trabalho e usa [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) para mapear A1:B4 para uma série e três categorias. Ele salva a apresentação com o gráfico vinculado.

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

O parâmetro `updateChartData` do método [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) controla se o livro de trabalho é carregado.

* Quando `updateChartData` é `false`, apenas o caminho do livro de trabalho é atualizado. Os dados do gráfico não são carregados ou atualizados a partir do livro de trabalho de destino, podendo o livro de trabalho estar indisponível.
* Quando `updateChartData` é `true`, os dados do gráfico são atualizados a partir do livro de trabalho de destino.

O exemplo a seguir atribui uma URL de placeholder com `updateChartData` definido como `false`. Ele mantém os dados padrão do gráfico de pizza e salva a apresentação sem carregar o livro de trabalho indisponível.

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

### **Obter o Caminho do Livro de Trabalho da Fonte de Dados Externa de um Gráfico**

Para identificar o livro de trabalho vinculado a um gráfico, verifique se o gráfico usa uma fonte de dados externa e recupere seu caminho de livro de trabalho.

Este exemplo inspeciona a primeira forma no primeiro slide de uma apresentação com um livro de trabalho externo vinculado. Se for um gráfico vinculado a um livro de trabalho externo, o exemplo imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) no console. Em seguida, salva uma cópia da apresentação.

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

### **Editar Dados do Gráfico**

Você pode editar os dados em livros de trabalho externos da mesma forma que faz alterações no conteúdo de livros de trabalho internos. Quando um livro de trabalho externo não pode ser carregado, uma exceção é lançada.

Este exemplo usa um gráfico que é a primeira forma no primeiro slide e está vinculado a um livro de trabalho externo acessível. Ele define o valor baseado em célula do primeiro ponto de dados da primeira série para 100 e salva a apresentação atualizada. Editar valores de célula pode atualizar o arquivo XLSX externo vinculado, portanto use uma cópia se precisar preservar o livro de trabalho original.

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

### **Recuperar um Livro de Trabalho do Cache do Gráfico**

Se um gráfico usa um livro de trabalho externo que está ausente ou indisponível, Aspose.Slides pode reconstruir o livro de trabalho do gráfico a partir dos dados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), chame [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/), e defina [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) como `true` antes de abrir a apresentação.

O exemplo JavaScript a seguir recupera os dados do livro de trabalho para um gráfico que é a primeira forma no primeiro slide e referencia um livro de trabalho externo indisponível. Ele acessa os dados recuperados através de [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) e [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Ler ou modificar os dados do workbook recuperado aqui.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Se o livro de trabalho externo estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança uma exceção. Habilite a recuperação somente quando usar os dados de gráfico em cache for uma solução aceitável, pois o cache pode não conter alterações feitas no livro de trabalho externo após a última atualização da apresentação.

## **Perguntas Frequentes**

**Posso determinar se um gráfico específico está vinculado a um livro de trabalho externo ou incorporado?**

Sim. Um gráfico tem um [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) e um [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); se a fonte for um livro de trabalho externo, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para livros de trabalho externos são suportados, e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente para um caminho absoluto. A apresentação armazena o caminho absoluto no arquivo PPTX, portanto mover o livro de trabalho pode exigir a atualização do link.

**Posso usar livros de trabalho localizados em recursos/rede compartilhada?**

Sim, esses livros de trabalho podem ser usados como fonte de dados externa. No entanto, editar livros de trabalho remotos diretamente do Aspose.Slides não é suportado — eles podem ser usados apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Editar os dados de gráfico baseados em célula também pode atualizar o arquivo XLSX local vinculado. Use uma cópia do livro de trabalho se o original precisar permanecer inalterado.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

O Aspose.Slides não aceita senha ao vincular. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar o mesmo livro de trabalho externo?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, atualizar esse arquivo será refletido em cada gráfico na próxima vez que os dados forem carregados.