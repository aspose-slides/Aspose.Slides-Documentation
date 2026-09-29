---
title: Gerenciar Pastas de Trabalho de Gráficos em Apresentações Usando PHP
linktitle: Pasta de Trabalho de Gráfico
type: docs
weight: 70
url: /pt/php-java/chart-workbook/
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
- PHP
- Aspose.Slides
description: "Descubra o Aspose.Slides para PHP via Java: gerencie facilmente pastas de trabalho de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele demonstra como ler e gravar dados de gráfico por meio de fluxos de pastas de trabalho, usar células de pasta de trabalho como rótulos de dados de gráfico, acessar coleções de planilhas e especificar o tipo de fonte de dados para valores de gráfico.

Também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráfico. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

Para células de pasta de trabalho que representam dados ausentes, veja [Controlar a exibição de células vazias](/slides/pt/php-java/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação em gráfico de linhas dos modos de exibição disponíveis.

## **Incluir dados de linhas e colunas ocultas**

Use [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/setplotvisiblecellsonly/) para controlar se um gráfico traça dados de linhas e colunas de planilha ocultas. Defina como `true` para traçar apenas células visíveis, ou `false` para incluir tanto células visíveis quanto ocultas. Essa configuração controla a plotagem do gráfico; não oculta nem exibe linhas ou colunas da planilha.

Baixe [hidden-source-data.pptx](hidden-source-data.pptx) e coloque-o no diretório de trabalho. Seu primeiro slide contém um gráfico de colunas como a primeira forma. A planilha incorporada, `Sheet1`, contém o seguinte intervalo de origem, `A1:C4`. A linha 3 e a coluna C estão ocultas, mas suas células ainda contêm valores.

| Linha da planilha | A: Mês | B: Varejo | C: Atacado (coluna oculta) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Acesse as células de origem através de [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getchartdataworkbook/) e leia [ChartDataCell::isHidden](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatacell/ishidden/) para inspecionar seu status de ocultação. Esse método relata o status de ocultação sem alterá‑lo. Neste arquivo, B2 está visível, B3 pertence à linha oculta e C2 pertence à coluna oculta; o exemplo imprime `false`, `true` e `true`, respectivamente.

Neste exemplo, atualize os dados do gráfico após alterar a configuração de plotagem: mantenha a pasta de trabalho incorporada com [readWorkbookStream](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/readworkbookstream/) e recarregue-a com [writeWorkbookStream](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/writeworkbookstream/). Ao incluir todas as células, use também [setRange](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/setrange/) para restaurar o intervalo completo, incluindo a categoria de fevereiro ocultada. Simplesmente mudar a flag não é suficiente para atualizar os dados de gráfico em cache e os rótulos de categoria deste exemplo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Atualize os dados do gráfico a partir da pasta de trabalho incorporada.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Restaurar o intervalo de origem completo, incluindo categorias ocultas.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

O exemplo salva `hidden_cells_true.pptx` com apenas os valores de Varejo visíveis (10 e 20), e `hidden_cells_false.pptx` com todos os seis valores. As imagens abaixo ilustram os dois modos de plotagem. A linha 3 e a coluna C permanecem ocultas em ambas as pastas de trabalho incorporadas.

| Somente células visíveis (`true`) | Todas as células (`false`) |
| --- | --- |
| ![Somente células visíveis: valores de Varejo 10 e 20 para Janeiro e Março.](hidden_cells_True.png) | ![Todas as células: valores de Varejo e Atacado para Janeiro, Fevereiro e Março.](hidden_cells_False.png) |

Uma célula oculta contendo um valor é diferente de uma célula vazia. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/setdisplayblanksas/) controla como valores ausentes são exibidos; não inclui nem exclui dados de origem ocultos. Consulte [Controlar a exibição de células vazias](/slides/pt/php-java/chart-series/#control-the-display-of-empty-cells) para um exemplo.

## **Ler e gravar dados de gráfico a partir de uma pasta de trabalho**

Aspose.Slides for PHP via Java fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/readworkbookstream/) e [writeWorkbookStream](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/writeworkbookstream/) que permitem ler e gravar pastas de trabalho de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Nota** que os dados do gráfico precisam estar organizados da mesma forma ou ter uma estrutura semelhante à origem.

Este exemplo abre `chart.pptx`, que deve conter um gráfico como a primeira forma em seu primeiro slide. Ele lê a pasta de trabalho incorporada para um array de bytes, limpa as séries e categorias existentes e grava a mesma pasta de trabalho de volta. As alterações permanecem na memória; o exemplo não salva a apresentação.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Validar o layout do gráfico após modificação da pasta de trabalho**

Ao substituir uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [Chart::validateChartLayout](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/validatechartlayout/) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a pasta de trabalho atualizada de volta ao gráfico. Este exemplo requer `chart.pptx` com um gráfico como a primeira forma em seu primeiro slide. O comentário indica onde a edição da pasta de trabalho ocorreria; o exemplo executável grava a pasta de trabalho original de volta e valida o layout na memória.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Modifique os bytes da pasta de trabalho aqui, por exemplo, usando Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Limpar as coleções remove referências de dados obsoletas antes que a pasta de trabalho seja gravada de volta. Reconstrua quaisquer mapeamentos de séries e categorias necessários para a pasta de trabalho atualizada antes de usar o gráfico.

## **Definir uma célula de pasta de trabalho como rótulo de dados do gráfico**

Você pode usar texto de células de pasta de trabalho como rótulos de dados do gráfico. Os passos a seguir mostram como vincular os rótulos em um gráfico de bolhas às células em sua pasta de trabalho de dados.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse o primeiro slide pelo seu índice baseado em zero.
3. Adicione um gráfico de bolhas com dados padrão.
4. Acesse as séries do gráfico.
5. Defina a célula da pasta de trabalho como um rótulo de dados.
6. Salve a apresentação.

Este exemplo abre `chart2.pptx`, que deve conter ao menos um slide, e adiciona um gráfico de bolhas com dados padrão. Ele usa as células A10:A12 na planilha 0 para os três primeiros rótulos na primeira série, habilita rótulos a partir de células e salva o resultado em `resultchart.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gerenciar planilhas**

O método [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/getworksheets/) fornece acesso às planilhas em uma pasta de trabalho de gráfico. Este exemplo cria um gráfico de pizza com dados padrão e imprime o nome de cada planilha no console.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Especificar o tipo de fonte de dados**

Este exemplo cria um gráfico de colunas 3D com dados padrão e define dois nomes de série usando fontes de dados diferentes. O primeiro nome usa um literal de string; o segundo usa a célula C1 na planilha 0. A enumeração [DataSourceType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/datasourcetype/) seleciona a origem para cada nome. O resultado é salvo em `pres.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Detectar formatos de pasta de trabalho incorporada não suportados**

Aspose.Slides não suporta o formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método `getEmbeddedWorkbookType` em [ChartData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/workbooktype/) para detectar formatos não suportados e pular esses gráficos. Este exemplo inspeciona as formas no primeiro slide de `sample.pptx`, ignora formas que não são gráficos e imprime uma mensagem diagnóstica para cada gráfico com uma pasta de trabalho .xlsb incorporada.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Leia ou modifique os dados da pasta de trabalho do gráfico suportados aqui.
    }
} finally {
    $presentation->dispose();
}
```

## **Pasta de trabalho externa**

Aspose.Slides oferece suporte ao uso de pastas de trabalho externas como fonte de dados para gráficos.

### **Criar uma pasta de trabalho externa**

Use [readWorkbookStream](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/readworkbookstream/) e [setExternalWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/setexternalworkbook/) para exportar uma pasta de trabalho de gráfico incorporada para um arquivo e vincular o gráfico a essa pasta de trabalho externa.

Este exemplo cria um gráfico de pizza com dados padrão, grava sua pasta de trabalho em `externalWorkbook1.xlsx` e conclui a gravação do arquivo antes de atribuir o arquivo como fonte de dados do gráfico. Ele salva a apresentação vinculada em `externalWorkbook.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Definir uma pasta de trabalho externa**

Usando o método [setExternalWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/setexternalworkbook/), você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho da pasta de trabalho externa (se esta tiver sido movida).

Embora você não possa editar os dados em pastas de trabalho armazenadas em locais ou recursos remotos, ainda pode usar essas pastas de trabalho como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente para um caminho completo.

Este exemplo requer `externalWorkbook.xlsx` no diretório de trabalho. Sua planilha chamada `Sheet1` deve conter um nome de série em B1, nomes de categoria em A2:A4 e valores numéricos em B2:B4. O exemplo cria um gráfico de pizza, vincula a pasta de trabalho e usa [setRange](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/setrange/) para mapear A1:B4 para uma série e três categorias. Ele salva o resultado em `Presentation_with_externalWorkbook.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O parâmetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/setexternalworkbook/) controla se a pasta de trabalho é carregada.

* Quando `updateChartData` é `false`, somente o caminho da pasta de trabalho é atualizado. Os dados do gráfico não são carregados nem atualizados a partir da pasta de trabalho de destino, portanto a pasta de trabalho pode estar indisponível.
* Quando `updateChartData` é `true`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

O exemplo a seguir atribui um URL de espaço reservado com `updateChartData` definido como `false`. Ele mantém os dados padrão do gráfico de pizza e salva a apresentação sem carregar a pasta de trabalho indisponível.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Obter o caminho da pasta de trabalho fonte de dados externa de um gráfico**

Para identificar a pasta de trabalho vinculada a um gráfico, primeiro verifique se o gráfico usa uma fonte de dados externa. Se usar, você pode recuperar o caminho da pasta de trabalho seguindo estas etapas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse o primeiro slide pelo seu índice baseado em zero.
3. Verifique se a primeira forma é um gráfico.
4. Leia o tipo de fonte de dados do gráfico.
5. Se a fonte for uma pasta de trabalho externa, leia seu caminho.

Este exemplo abre `externalWorkbook.pptx`, criado no exemplo anterior, e inspeciona a primeira forma no primeiro slide. Se for um gráfico vinculado a uma pasta de trabalho externa, o exemplo imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getexternalworkbookpath/) no console. Em seguida, salva uma cópia da apresentação em `Result.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Editar dados do gráfico**

Você pode editar os dados em pastas de trabalho externas da mesma forma que faz alterações no conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este exemplo requer `presentation.pptx` com um gráfico como a primeira forma no primeiro slide e uma pasta de trabalho externa acessível. Ele define o valor baseado em célula do primeiro ponto de dados na primeira série como 100 e salva a apresentação em `presentation_out.pptx`. Editar valores de célula pode atualizar o arquivo XLSX externo vinculado, portanto use uma cópia se precisar preservar a pasta de trabalho original.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Recuperar uma pasta de trabalho do cache do gráfico**

Se um gráfico usar uma pasta de trabalho externa que esteja ausente ou indisponível, o Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados armazenados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/), chame [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) e defina [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) como `true` antes de abrir a apresentação.

O exemplo PHP a seguir abre `presentation.pptx`, cuja primeira forma no primeiro slide deve ser um gráfico que referencia uma pasta de trabalho externa indisponível, e acessa os dados recuperados através de [Chart::getChartData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/getchartdata/) e [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Leia ou modifique os dados da pasta de trabalho recuperada aqui.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, o Aspose.Slides lança uma exceção. Ative a recuperação apenas quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**

Sim. Um gráfico possui um [data source type](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getdatasourcetype/) e um [path to an external workbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getexternalworkbookpath/); se a fonte for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Os caminhos relativos para pastas de trabalho externas são suportados, e como eles são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente para um caminho absoluto. A apresentação armazena o caminho absoluto no arquivo PPTX, portanto mover a pasta de trabalho pode exigir a atualização do link.

**Posso usar pastas de trabalho localizadas em recursos/rede compartilhada?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. No entanto, editar pastas de trabalho remotas diretamente do Aspose.Slides não é suportado — elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Editar dados de gráfico baseados em células também pode atualizar o arquivo XLSX local vinculado. Use uma cópia da pasta de trabalho se o original precisar permanecer inalterado.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

O Aspose.Slides não aceita uma senha ao vincular. Uma abordagem comum é remover a proteção previamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.