---
title: Gerenciar Pastas de Trabalho de Gráficos em Apresentações Usando Java
linktitle: Pasta de Trabalho de Gráfico
type: docs
weight: 70
url: /pt/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Descubra o Aspose.Slides para Java: gerencie pastas de trabalho de gráficos no PowerPoint e nos formatos OpenDocument de forma fácil para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráficos por meio de fluxos de pastas de trabalho, usar células da pasta de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para os valores do gráfico.

Ele também aborda o trabalho com pastas de trabalho externas como fontes de dados dos gráficos. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

Para células da pasta de trabalho que representam dados ausentes, veja [Controlar a Exibição de Células Vazias](/slides/pt/java/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação em gráfico de linhas dos modos de exibição disponíveis.

## **Incluir Dados de Linhas e Colunas Ocultas**

Use [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) para controlar se um gráfico plota dados de linhas e colunas de planilha ocultas. Defina como `true` para plotar somente células visíveis, ou `false` para incluir tanto células visíveis quanto ocultas. Esta configuração controla a plotagem do gráfico; não oculta ou exibe linhas ou colunas da planilha.

Baixe [hidden-source-data.pptx](hidden-source-data.pptx) e coloque-o no diretório de trabalho. Seu primeiro slide contém um gráfico de colunas como a primeira forma. A planilha incorporada, `Sheet1`, contém o intervalo de origem `A1:C4`. A linha 3 e a coluna C estão ocultas, mas suas células ainda contêm valores.

| Linha da planilha | A: Mês | B: Varejo | C: Atacado (coluna oculta) |
| --- | --- | --- | --- |
| 2 | Janeiro | 10 | 30 |
| 3 (linha oculta) | Fevereiro | 40 | 60 |
| 4 | Março | 20 | 50 |

Acesse as células de origem através de [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) e leia [IChartDataCell.isHidden](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatacell/#isHidden--) para inspecionar seu status de ocultação. Este método reporta o status de ocultação sem alterá‑lo. Neste arquivo, B2 está visível, B3 pertence à linha oculta e C2 pertence à coluna oculta; o exemplo imprime `false`, `true` e `true`, respectivamente.

Para este exemplo, atualize os dados do gráfico após mudar a configuração de plotagem: retenha a pasta de trabalho incorporada com [readWorkbookStream](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#readWorkbookStream--) e recarregue‑a com [writeWorkbookStream](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Ao incluir todas as células, use também [setRange](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) para restaurar o intervalo completo, incluindo a categoria de fevereiro ocultada. Apenas mudar a bandeira não é suficiente para atualizar os dados em cache deste exemplo e os rótulos de categoria.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Atualizar os dados do gráfico a partir da pasta de trabalho incorporada.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Restaurar o intervalo de origem completo, incluindo as categorias ocultas.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

O exemplo salva `hidden_cells_true.pptx` contendo somente os valores de Varejo visíveis (10 e 20), e `hidden_cells_false.pptx` com todos os seis valores. As imagens abaixo ilustram os dois modos de plotagem. A linha 3 e a coluna C permanecem ocultas em ambas as pastas de trabalho incorporadas.

| Somente células visíveis (`true`) | Todas as células (`false`) |
| --- | --- |
| ![Somente células visíveis: valores de Varejo 10 e 20 para Janeiro e Março.](hidden_cells_True.png) | ![Todas as células: valores de Varejo e Atacado para Janeiro, Fevereiro e Março.](hidden_cells_False.png) |

Uma célula oculta que contém um valor é diferente de uma célula vazia. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) controla como valores ausentes são exibidos; não inclui ou exclui dados de origem ocultos. Veja [Controlar a Exibição de Células Vazias](/slides/pt/java/chart-series/#control-the-display-of-empty-cells) para um exemplo.

## **Ler e Gravar Dados de Gráficos a partir de uma Pasta de Trabalho**

Aspose.Slides for Java fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#readWorkbookStream--) e [writeWorkbookStream](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) que permitem ler e gravar pastas de trabalho de dados de gráficos (contendo dados de gráficos editados com Aspose.Cells). **Note** que os dados do gráfico precisam estar organizados da mesma maneira ou ter uma estrutura similar à origem.

Este exemplo abre `chart.pptx`, que deve conter um gráfico como a primeira forma em seu primeiro slide. Ele lê a pasta de trabalho incorporada para um array de bytes, limpa as séries e categorias existentes e grava a mesma pasta de trabalho de volta. As alterações permanecem na memória; o exemplo não salva a apresentação.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Validar Layout do Gráfico Após Modificação da Pasta de Trabalho**

Ao substituir uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa divergência pode fazer com que [IChart.validateChartLayout](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#validateChartLayout--) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a pasta de trabalho atualizada de volta no gráfico. Este exemplo requer `chart.pptx` com um gráfico como a primeira forma em seu primeiro slide. O comentário indica onde a edição da pasta de trabalho ocorreria; o exemplo executável grava a pasta de trabalho original de volta e valida o layout na memória.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Modifique os bytes da pasta de trabalho aqui, por exemplo, usando Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Limpar as coleções remove referências de dados obsoletas antes que a pasta de trabalho seja gravada. Reconstrua quaisquer mapeamentos de séries e categorias necessários para a pasta de trabalho atualizada antes de usar o gráfico.

## **Definir uma Célula da Pasta de Trabalho como Rótulo de Dados do Gráfico**

Você pode usar texto de células da pasta de trabalho como rótulos de dados do gráfico. As etapas a seguir mostram como vincular os rótulos em um gráfico de bolhas a células em sua pasta de dados.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) .
2. Acesse o primeiro slide pelo seu índice baseado em zero.
3. Adicione um gráfico de bolhas com dados padrão.
4. Acesse as séries do gráfico.
5. Defina a célula da pasta de trabalho como um rótulo de dados.
6. Salve a apresentação.

Este exemplo abre `chart2.pptx`, que deve conter ao menos um slide, e adiciona um gráfico de bolhas com dados padrão. Ele usa as células A10:A12 na planilha 0 para os três primeiros rótulos da primeira série, habilita rótulos a partir de células e salva o resultado em `resultchart.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gerenciar Planilhas**

O método [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) fornece acesso às planilhas em uma pasta de trabalho de gráfico. Este exemplo cria um gráfico de pizza com dados padrão e imprime cada nome de planilha no console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Especificar o Tipo de Fonte de Dados**

Este exemplo cria um gráfico de colunas 3D com dados padrão e define dois nomes de séries usando diferentes fontes de dados. O primeiro nome usa um literal de string; o segundo usa a célula C1 na planilha 0. A enumeração [DataSourceType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/datasourcetype/) seleciona a origem para cada nome. O resultado é salvo em `pres.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Detectar Formatos de Pasta de Trabalho Incorporados Não Compatíveis**

Aspose.Slides não suporta o formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) em [IChartData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/) junto com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/workbooktype/) para detectar formatos não suportados e pular esses gráficos. Este exemplo inspeciona as formas no primeiro slide de `sample.pptx`, ignora formas que não são gráficos e imprime uma mensagem de diagnóstico para cada gráfico com uma pasta de trabalho .xlsb incorporada.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Leia ou modifique os dados de pasta de trabalho de gráfico suportados aqui.
    }
} finally {
    presentation.dispose();
}
```

## **Pasta de Trabalho Externa**

Aspose.Slides suporta o uso de pastas de trabalho externas como fonte de dados para gráficos.

### **Criar uma Pasta de Trabalho Externa**

Use [readWorkbookStream](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#readWorkbookStream--) e [setExternalWorkbook](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) para exportar uma pasta de trabalho de gráfico incorporada para um arquivo e vincular o gráfico a essa pasta de trabalho externa.

Este exemplo cria um gráfico de pizza com dados padrão, grava sua pasta de trabalho em `externalWorkbook1.xlsx` e conclui a gravação do arquivo antes de atribuir o arquivo como a fonte de dados do gráfico. Ele salva a apresentação vinculada em `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Definir uma Pasta de Trabalho Externa**

Usando o método [setExternalWorkbook](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Este método também pode ser usado para atualizar o caminho da pasta de trabalho externa (se esta tiver sido movida).

Embora você não possa editar os dados em pastas de trabalho armazenadas em locais remotos ou recursos, ainda pode usá‑las como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente em um caminho completo.

Este exemplo requer `externalWorkbook.xlsx` no diretório de trabalho. Sua planilha denominada `Sheet1` deve conter um nome de série em B1, nomes de categoria em A2:A4 e valores numéricos em B2:B4. O exemplo cria um gráfico de pizza, vincula a pasta de trabalho e usa [setRange](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) para mapear A1:B4 para uma série e três categorias. Ele salva o resultado em `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O parâmetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) controla se a pasta de trabalho é carregada.

* Quando `updateChartData` é `false`, somente o caminho da pasta de trabalho é atualizado. Os dados do gráfico não são carregados nem atualizados a partir da pasta de trabalho alvo, de modo que a pasta de trabalho pode estar indisponível.
* Quando `updateChartData` é `true`, os dados do gráfico são atualizados a partir da pasta de trabalho alvo.

O exemplo a seguir atribui uma URL fictícia com `updateChartData` definido como `false`. Ele mantém os dados padrão do gráfico de pizza e salva a apresentação sem carregar a pasta de trabalho indisponível.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Obter o Caminho da Pasta de Trabalho da Fonte de Dados Externa de um Gráfico**

Para identificar a pasta de trabalho vinculada a um gráfico, primeiro verifique se o gráfico usa uma fonte de dados externa. Se usar, você pode recuperar o caminho da pasta de trabalho seguindo estas etapas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) .
2. Acesse o primeiro slide pelo seu índice baseado em zero.
3. Verifique se a primeira forma é um gráfico.
4. Leia o tipo de fonte de dados do gráfico.
5. Se a fonte for uma pasta de trabalho externa, leia seu caminho.

Este exemplo abre `externalWorkbook.pptx`, criado no exemplo anterior, e inspeciona a primeira forma no primeiro slide. Se for um gráfico vinculado a uma pasta de trabalho externa, o exemplo imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) no console. Em seguida, salva uma cópia da apresentação em `Result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Editar Dados do Gráfico**

Você pode editar os dados em pastas de trabalho externas da mesma forma que altera o conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este exemplo requer `presentation.pptx` com um gráfico como a primeira forma no primeiro slide e uma pasta de trabalho externa acessível. Ele define o valor baseado em célula do primeiro ponto de dados da primeira série como 100 e salva a apresentação em `presentation_out.pptx`. A edição de valores de células pode atualizar o arquivo XLSX externo vinculado, portanto use uma cópia se precisar preservar a pasta de trabalho original.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Recuperar uma Pasta de Trabalho do Cache do Gráfico**

Se um gráfico usar uma pasta de trabalho externa que está ausente ou indisponível, Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/), chame [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), e defina [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) como `true` antes de abrir a apresentação.

O exemplo Java a seguir abre `presentation.pptx`, cuja primeira forma no primeiro slide deve ser um gráfico referenciando uma pasta de trabalho externa indisponível, e acessa os dados recuperados através de [IChart.getChartData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#getChartData--) e [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Leia ou modifique os dados da pasta de trabalho recuperada aqui.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança uma exceção. Habilite a recuperação somente quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **Perguntas Frequentes**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**

Sim. Um gráfico possui um [tipo de fonte de dados](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartdata/#getDataSourceType--) e um [caminho para uma pasta de trabalho externa](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se a fonte for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Os caminhos relativos para pastas de trabalho externas são suportados, e como eles são armazenados?**

Sim. Se você especificar um caminho relativo, ele é convertido automaticamente em um caminho absoluto. A apresentação armazena o caminho absoluto no arquivo PPTX, de modo que mover a pasta de trabalho pode exigir a atualização do vínculo.

**Posso usar pastas de trabalho localizadas em recursos ou compartilhamentos de rede?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. Contudo, a edição direta de pastas de trabalho remotas a partir do Aspose.Slides não é suportada – elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). A edição de dados de gráfico baseados em célula também pode atualizar o arquivo XLSX local vinculado. Use uma cópia da pasta de trabalho se o original precisar permanecer inalterado.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao vincular. Uma abordagem comum é remover a proteção previamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.