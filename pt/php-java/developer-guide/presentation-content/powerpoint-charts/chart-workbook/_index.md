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
description: "Descubra o Aspose.Slides para PHP via Java: gerencie facilmente pastas de trabalho de gráficos nos formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráficos através de fluxos de pastas de trabalho, usar células de pasta de trabalho como rótulos de dados de gráfico, acessar coleções de planilhas e especificar o tipo de fonte de dados para valores de gráfico.

Ele também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráficos. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

Para células de pasta de trabalho que representam dados ausentes, consulte [Controlar a Exibição de Células Vazias](/slides/pt/php-java/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação de gráfico de linhas dos modos de exibição disponíveis.

## **Incluir Dados de Linhas e Colunas Ocultas**

Use [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) para controlar se um gráfico plota dados de linhas e colunas de planilha ocultas. Defina como `true` para plotar apenas células visíveis, ou `false` para incluir tanto células visíveis quanto ocultas. Essa configuração controla a plotagem do gráfico; ela não oculta ou exibe linhas ou colunas da planilha.

A [apresentação de exemplo](hidden-source-data.pptx) contém um gráfico de colunas como a primeira forma no primeiro slide. A planilha incorporada, `Sheet1`, contém o intervalo de origem a seguir, `A1:C4`. A linha 3 e a coluna C estão ocultas, mas suas células ainda contêm valores.

| Linha da planilha | A: Mês | B: Varejo | C: Atacado (coluna oculta) |
| --- | --- | --- | --- |
| 2 | Janeiro | 10 | 30 |
| 3 (linha oculta) | Fevereiro | 40 | 60 |
| 4 | Março | 20 | 50 |

Acesse as células de origem através de [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) e leia [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) para inspecionar seu status de ocultação. Esse método relata o status de ocultação sem alterá‑lo. Neste exemplo, B2 está visível, B3 pertence à linha oculta e C2 pertence à coluna oculta; o exemplo imprime `false`, `true` e `true`, respectivamente.

Para este exemplo, atualize os dados do gráfico após alterar a configuração de plotagem: retenha a pasta de trabalho incorporada com [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) e recarregue‑a com [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Ao incluir todas as células, use também [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) para restaurar o intervalo completo, incluindo a categoria de fevereiro oculta. Simplesmente mudar a flag não é suficiente para atualizar os dados em cache do gráfico e os rótulos de categoria deste exemplo.

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

            // Atualizar os dados do gráfico a partir da pasta de trabalho incorporada.
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

O exemplo salva duas versões da apresentação: uma contendo apenas os valores de Varejo visíveis (10 e 20) e outra com todos os seis valores. As imagens abaixo ilustram os dois modos de plotagem. A linha 3 e a coluna C permanecem ocultas em ambas as pastas de trabalho incorporadas.

| Apenas células visíveis (`true`) | Todas as células (`false`) |
| --- | --- |
| ![Apenas células visíveis: valores de Varejo 10 e 20 para Janeiro e Março.](hidden_cells_True.png) | ![Todas as células: valores de Varejo e Atacado para Janeiro, Fevereiro e Março.](hidden_cells_False.png) |

Uma célula oculta que contém um valor é diferente de uma célula vazia. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) controla como valores ausentes são exibidos; ele não inclui ou exclui dados de origem ocultos. Consulte [Controlar a Exibição de Células Vazias](/slides/pt/php-java/chart-series/#control-the-display-of-empty-cells) para um exemplo.

## **Recuperar o Intervalo de Dados de um Gráfico**

Antes de atualizar os dados da pasta de trabalho em uma apresentação existente, inspecione os intervalos de origem para identificar quais células da planilha cada gráfico usa. O método [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) retorna o intervalo de dados atual como uma fórmula qualificada pela planilha, como `Sheet1!$A$1:$D$5`. Aqui, `Sheet1` é o nome da planilha, `!` separa‑o do intervalo de células, e `$A$1:$D$5` identifica as células de A1 a D5, inclusive. Os sinais de dólar indicam referências absolutas de linha e coluna.

O método lê o intervalo atual sem alterar o gráfico ou sua pasta de trabalho. Se o gráfico não usar uma pasta de trabalho como fonte de dados, ele lança uma exceção. Para mais informações, veja a [Referência da API ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Este exemplo abre uma apresentação e verifica as formas diretamente em cada slide em busca de gráficos. Ele imprime o nome de cada gráfico e seu intervalo de origem. Se um gráfico não usar uma pasta de trabalho, ele imprime uma mensagem e continua para o próximo gráfico.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ler e Gravar Dados de Gráfico a partir de uma Pasta de Trabalho**

Aspose.Slides for PHP via Java fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) e [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) que permitem ler e gravar pastas de trabalho de dados de gráficos (contendo dados de gráfico editados com Aspose.Cells). **Nota** que os dados do gráfico precisam estar organizados da mesma forma ou ter uma estrutura semelhante à fonte.

Este exemplo usa uma apresentação com um gráfico como a primeira forma no primeiro slide. Ele lê a pasta de trabalho incorporada para um array de bytes, limpa as séries e categorias existentes e grava a mesma pasta de trabalho de volta. As alterações permanecem em memória; o exemplo não salva a apresentação.

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

### **Validar o Layout do Gráfico Após Modificação da Pasta de Trabalho**

Ao substituir uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a pasta de trabalho atualizada de volta no gráfico. Este exemplo usa um gráfico que é a primeira forma no primeiro slide. O comentário indica onde a edição da pasta de trabalho ocorreria; o exemplo executável grava a pasta de trabalho original de volta e valida o layout na memória.

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

Limpar as coleções remove referências a dados obsoletos antes que a pasta de trabalho seja gravada de volta. Reconstrua quaisquer mapeamentos de séries e categorias necessários para a pasta de trabalho atualizada antes de usar o gráfico.

## **Definir Formatos Numéricos Customizados para Células da Pasta de Trabalho**

Use [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) para controlar como valores numéricos aparecem na pasta de trabalho incorporada ao gráfico. Por exemplo, um relatório pode precisar exibir uma taxa de conversão como percentual com quatro casas decimais e um coeficiente com cinco casas decimais. Mantenha ambos os valores numéricos para que permaneçam disponíveis para cálculos e plotagem de gráficos.

Um formato numérico altera a exibição, não o valor armazenado. O formato `0.0000%` exibe `0.125` como `12.5000%`; ele não substitui o número armazenado por `12.5`. Da mesma forma, `0.00000` exibe `0.1234567` como `0.12346` sem arredondar o valor armazenado. Se o formato customizado for uma cadeia vazia (`""`), o formato retornado por [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) será usado.

O exemplo a seguir cria um gráfico de colunas e acessa suas células através de [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). Na planilha 0, B2 contém a taxa de conversão e C2 contém o coeficiente. Ambas as células fornecem valores ao gráfico. O exemplo também habilita rótulos de valor vinculados aos formatos de origem.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Os formatos de célula da pasta de trabalho são independentes dos formatos definidos diretamente nos eixos do gráfico ou nos rótulos de dados. Neste exemplo, cada rótulo exibe o valor da célula de origem porque [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) está definido como `true`, e segue o formato numérico de origem porque [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) está definido como `true`. Após salvar e reabrir a apresentação, os rótulos exibem `12.5000%` e `0.12346`, conforme mostrado abaixo. O eixo vertical usa seu próprio formato numérico, atribuído com [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) como `0.00`, com [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) definido como `false`.

Para formatar um rótulo de dados de forma independente, defina sua flag de vínculo à fonte como `false` e atribua um formato com [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Isso não altera o formato da célula da pasta de trabalho. Por exemplo, um formato de rótulo independente `0.00` exibe o primeiro valor como `0.13`, enquanto B2 ainda exibe `12.5000%`. Veja [Rótulos de Dados do Gráfico](/slides/pt/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) para formatação direta de rótulos.

A imagem abaixo foi renderizada a partir da apresentação salva após reabri‑la:

![Gráfico de colunas com rótulos vinculados à origem mostrando 12.5000% e 0.12346 e eixo numérico formatado de forma independente.](custom-cell-formats.png)

## **Definir uma Célula da Pasta de Trabalho como Rótulo de Dados do Gráfico**

Você pode usar o texto de células da pasta de trabalho como rótulos de dados do gráfico.

Este exemplo adiciona um gráfico de bolhas com dados padrão ao primeiro slide de uma apresentação existente. Ele usa as células A10:A12 na planilha 0 para os três primeiros rótulos da primeira série, habilita rótulos a partir de células e salva a apresentação atualizada.

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

## **Gerenciar Planilhas**

O método [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) fornece acesso às planilhas em uma pasta de trabalho de gráfico. Este exemplo cria um gráfico de pizza com dados padrão e imprime o nome de cada planilha no console.

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

## **Especificar o Tipo de Fonte de Dados**

Este exemplo cria um gráfico de colunas 3D com dados padrão e define dois nomes de série usando fontes de dados diferentes. O primeiro nome usa um literal de string; o segundo usa a célula C1 na planilha 0. O enumerador [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) seleciona a fonte para cada nome. O exemplo salva a apresentação com os nomes de série atualizados.

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

## **Detectar Formatos de Pasta de Trabalho Incorporados Não Suportados**

Aspose.Slides não oferece suporte ao formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método `getEmbeddedWorkbookType` em [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) juntamente com o enumerador [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) para detectar formatos não suportados e pular esses gráficos. Este exemplo inspeciona as formas no primeiro slide de uma apresentação existente, ignora formas que não são gráficos e imprime uma mensagem diagnóstica para cada gráfico com uma pasta de trabalho .xlsb incorporada.

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

        // Ler ou modificar dados de pasta de trabalho de gráfico suportados aqui.
    }
} finally {
    $presentation->dispose();
}
```

## **Pasta de Trabalho Externa**

Aspose.Slides suporta o uso de pastas de trabalho externas como fonte de dados para gráficos.

### **Criar uma Pasta de Trabalho Externa**

Use [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) e [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) para exportar uma pasta de trabalho de gráfico incorporada para um arquivo e vincular o gráfico a essa pasta de trabalho externa.

Este exemplo cria um gráfico de pizza com dados padrão e exporta sua pasta de trabalho. Ele conclui a gravação do arquivo antes de atribuir a pasta de trabalho externa como fonte de dados do gráfico, então salva a apresentação vinculada.

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

### **Definir uma Pasta de Trabalho Externa**

Usando o método [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho da pasta de trabalho externa (se o arquivo tiver sido movido).

Embora você não possa editar os dados em pastas de trabalho armazenadas em locais remotos ou recursos, ainda pode usar essas pastas de trabalho como fonte de dados externa. Se o caminho relativo para uma pasta de trabalho externa for fornecido, ele será convertido automaticamente para um caminho completo.

Este exemplo usa uma pasta de trabalho externa cuja planilha chamada `Sheet1` contém um nome de série em B1, nomes de categoria em A2:A4 e valores numéricos em B2:B4. O exemplo cria um gráfico de pizza, vincula a pasta de trabalho e usa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) para mapear A1:B4 para uma série e três categorias. Ele salva a apresentação com o gráfico vinculado.

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

O parâmetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) controla se a pasta de trabalho é carregada.

* Quando `updateChartData` é `false`, somente o caminho da pasta de trabalho é atualizado. Os dados do gráfico não são carregados ou atualizados a partir da pasta de trabalho de destino, de modo que a pasta de trabalho pode estar indisponível.
* Quando `updateChartData` é `true`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

O exemplo a seguir atribui uma URL placeholder com `updateChartData` definido como `false`. Ele mantém os dados padrão do gráfico de pizza e salva a apresentação sem carregar a pasta de trabalho indisponível.

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

### **Obter o Caminho da Pasta de Trabalho Fonte de Dados Externa de um Gráfico**

Para identificar a pasta de trabalho vinculada a um gráfico, verifique se o gráfico usa uma fonte de dados externa e recupere seu caminho de pasta de trabalho.

Este exemplo inspeciona a primeira forma no primeiro slide de uma apresentação com uma pasta de trabalho externa vinculada. Se for um gráfico vinculado a uma pasta de trabalho externa, o exemplo imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) no console. Em seguida, salva uma cópia da apresentação.

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

### **Editar Dados do Gráfico**

Você pode editar os dados em pastas de trabalho externas da mesma forma que altera o conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este exemplo usa um gráfico que é a primeira forma no primeiro slide e está vinculado a uma pasta de trabalho externa acessível. Ele define o valor baseado em célula do primeiro ponto de dados da primeira série como 100 e salva a apresentação atualizada. Editar valores de célula pode atualizar o arquivo XLSX externo vinculado, portanto use uma cópia se precisar preservar a pasta de trabalho original.

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

### **Recuperar uma Pasta de Trabalho a partir do Cache do Gráfico**

Se um gráfico usa uma pasta de trabalho externa que está ausente ou indisponível, Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), chame [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) e defina [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) como `true` antes de abrir a apresentação.

O exemplo PHP a seguir recupera dados de pasta de trabalho para um gráfico que é a primeira forma no primeiro slide e referencia uma pasta de trabalho externa indisponível. Ele acessa os dados recuperados através de [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) e [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Ler ou modificar os dados da pasta de trabalho recuperada aqui.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança uma exceção. Habilite a recuperação somente quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**

Sim. Um gráfico tem um [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) e um [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); se a fonte for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para pastas de trabalho externas são suportados, e como eles são armazenados?**

Sim. Se você especificar um caminho relativo, ele é convertido automaticamente para um caminho absoluto. A apresentação armazena o caminho absoluto no arquivo PPTX, portanto mover a pasta de trabalho pode exigir a atualização do link.

**Posso usar pastas de trabalho localizadas em recursos ou compartilhamentos de rede?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. No entanto, editar pastas de trabalho remotas diretamente a partir do Aspose.Slides não é suportado — elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Editar dados de gráfico baseados em célula também pode atualizar o arquivo XLSX local vinculado. Use uma cópia da pasta de trabalho se o original precisar permanecer inalterado.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita uma senha ao criar o vínculo. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio vínculo. Se todos apontarem para o mesmo arquivo, atualizar esse arquivo será refletido em cada gráfico na próxima vez que os dados forem carregados.