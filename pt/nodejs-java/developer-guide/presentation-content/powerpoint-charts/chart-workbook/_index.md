---
title: Gerenciar pastas de trabalho de gráfico em apresentações usando JavaScript
linktitle: Pasta de trabalho de gráfico
type: docs
weight: 70
url: /pt/nodejs-java/chart-workbook/
keywords:
- pasta de trabalho de gráfico
- dados de gráfico
- célula de pasta de trabalho
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
description: "Descubra o Aspose.Slides para Node.js via Java: gerencie facilmente pastas de trabalho de gráfico em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráfico no Aspose.Slides. Ele mostra como ler e gravar dados de gráfico por meio de fluxos de pasta de trabalho, usar células de pasta de trabalho como rótulos de dados de gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para valores de gráfico.

Também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráfico. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

Para células de pasta de trabalho que representam dados ausentes, consulte [Control the Display of Empty Cells](/slides/pt/nodejs-java/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação de gráfico de linhas dos modos de exibição disponíveis.

## **Ler e gravar dados de gráfico a partir de uma pasta de trabalho**

Aspose.Slides fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) e [writeWorkbookStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) que permitem ler e gravar pastas de trabalho de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Observação** de que os dados do gráfico precisam ser organizados da mesma forma ou possuir uma estrutura semelhante à fonte.

Este código JavaScript demonstra uma operação de exemplo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Validar o layout do gráfico após modificação da pasta de trabalho**

Quando você substitui uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa discrepância pode fazer com que [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Chart#validateChartLayout--) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a pasta de trabalho atualizada de volta ao gráfico.

```javascript
// Após modificar o fluxo da pasta de trabalho (por exemplo, usando Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Limpar referências de dados existentes.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Limpar as coleções garante que a estrutura de dados do gráfico seja consistente com a nova pasta de trabalho, permitindo que `validateChartLayout` seja concluído sem erros.

## **Definir célula de pasta de trabalho como rótulo de dados de gráfico**

1. Crie uma instância da classe [Presentation](https://apireference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
2. Obtenha a referência de um slide por seu índice.
3. Adicione um gráfico de Bolha com alguns dados.
4. Acesse a série do gráfico.
5. Defina a célula da pasta de trabalho como um rótulo de dados.
6. Salve a apresentação.

Este código JavaScript mostra como definir uma célula da pasta de trabalho como um rótulo de dados de gráfico:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instancia uma classe de apresentação que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gerenciar planilhas**

Este código JavaScript demonstra uma operação onde o método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) é usado para acessar uma coleção de planilhas:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Especificar o tipo de origem de dados**

Este código JavaScript mostra como especificar um tipo para uma origem de dados:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Detectar formatos de pasta de trabalho incorporada não suportados**

Aspose.Slides não oferece suporte ao formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método `getEmbeddedWorkbookType` em [ChartData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/workbooktype/) para detectar formatos não suportados e ignorar esses gráficos.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // A pasta de trabalho incorporada está no formato .xlsb, que não é suportado.
            continue;
        }

        // Leia ou modifique os dados da pasta de trabalho do gráfico aqui.
    }
} finally {
    presentation.dispose();
}
```

## **Pasta de trabalho externa**

Aspose.Slides oferece suporte a pastas de trabalho externas como fonte de dados para gráficos.

### **Criar pasta de trabalho externa**

Usando os métodos **`readWorkbookStream`** e **`setExternalWorkbook`**, você pode criar uma pasta de trabalho externa do zero ou tornar uma pasta de trabalho interna externa.

Este código JavaScript demonstra o processo de criação de uma pasta de trabalho externa:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream retorna os bytes da pasta de trabalho como um Buffer do Node.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Definir pasta de trabalho externa**

Usando o método **`setExternalWorkbook`**, você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho da pasta de trabalho externa (se esta foi movida).

Embora você não possa editar os dados em pastas de trabalho armazenadas em locais remotos ou recursos, ainda pode usar essas pastas de trabalho como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente em um caminho completo.

Este código JavaScript mostra como definir uma pasta de trabalho externa:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

O segundo parâmetro do método `setExternalWorkbook`, `updateChartData`, especifica se a pasta de trabalho Excel será carregada ou não.

* Quando `updateChartData` está definido como `false`, apenas o caminho da pasta de trabalho é atualizado – os dados do gráfico não serão carregados nem atualizados a partir da pasta de trabalho de destino. Você pode usar esta configuração quando a pasta de trabalho de destino não existir ou não estiver disponível.
* Quando `updateChartData` está definido como `true`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Obter caminho da pasta de trabalho fonte de dados externa do gráfico**

1. Crie uma instância da classe [Presentation](https://apireference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
2. Obtenha a referência de um slide por seu índice.
3. Crie um objeto para a forma de gráfico.
4. Crie um objeto para o tipo de origem (`ChartDataSourceType`) que representa a fonte de dados do gráfico.
5. Especifique a condição relevante com base no tipo de origem sendo o mesmo que o tipo de fonte de dados da pasta de trabalho externa.

Este código JavaScript demonstra a operação:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Salva a apresentação
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Editar dados do gráfico**

Você pode editar os dados em pastas de trabalho externas da mesma forma que faz alterações no conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este código JavaScript é uma implementação do processo descrito:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Recuperar uma pasta de trabalho do cache do gráfico**

Se um gráfico usa uma pasta de trabalho externa que está ausente ou indisponível, Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados armazenados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/), configure-o com [SpreadsheetOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/spreadsheetoptions/), e chame [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) com `true` antes de abrir a apresentação.

O exemplo a seguir em JavaScript abre uma apresentação cujo gráfico referencia uma pasta de trabalho externa indisponível e acessa os dados recuperados através de [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Leia ou modifique os dados da pasta de trabalho recuperada aqui.
} finally {
    presentation.dispose();
}
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança uma exceção. Habilite a recuperação somente quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **Perguntas frequentes**

**É possível determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**

Sim. Um gráfico possui um [data source type](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) e um [path to an external workbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); se a origem for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Os caminhos relativos para pastas de trabalho externas são suportados e como são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente para um caminho absoluto. Isso é conveniente para a portabilidade do projeto; no entanto, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar pastas de trabalho localizadas em recursos/compartilhamentos de rede?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. Contudo, a edição direta de pastas de trabalho remotas a partir do Aspose.Slides não é suportada — elas podem ser usadas apenas como fonte.

**Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Não. A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) e o utiliza para ler os dados. O arquivo externo em si não é modificado quando a apresentação é salva.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao criar o vínculo. Uma abordagem comum é remover a proteção previamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/nodejs-java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio vínculo. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.