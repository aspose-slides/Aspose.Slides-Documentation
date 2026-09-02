---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst no PHP
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico Treemap
- gráfico Sunburst
- gráfico hierárquico
- ponto de dado
- rótulo de dado
- cor de ramo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como criar dados hierárquicos e personalizar níveis, rótulos e cores em gráficos Treemap e Sunburst com Aspose.Slides para PHP via Java."
---
## **Visão geral**

Os gráficos Treemap e Sunburst exibem o mesmo tipo de dados hierárquicos, mas utilizam layouts diferentes. Um Treemap desenha a hierarquia como retângulos aninhados cujas áreas representam os valores das folhas. Um Sunburst a desenha como anéis concêntricos: os grupos de nível superior ficam próximos ao centro e as categorias folha ficam no anel externo.

No Aspose.Slides para PHP via Java, cada valor numérico é um [ChartDataPoint](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapoint/). Seu método [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) fornece acesso à folha e aos seus grupos pais. Este artigo explica esse mapeamento e mostra como criar e formatar ambos os tipos de gráfico a partir dos mesmos dados de exemplo.

![Um gráfico Treemap com ramos Consumer e Business](treemap-hierarchy.png)

![Um gráfico Sunburst com a mesma hierarquia Consumer e Business](sunburst-hierarchy.png)

## **Entendendo categorias, pontos de dados e níveis**

O exemplo usado abaixo possui três níveis de categorias e uma série numérica:

| Ramo | Tronco | Folha | Receita |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Cada linha cria uma categoria folha e um ponto de dados. Os níveis de agrupamento de categorias descrevem o caminho daquela folha até seus pais. Para a primeira linha, o caminho é `Consumer > Computers > Laptops`.

Os índices retornados por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) vão da folha para cima:

| `getDataPointLevels()` índice | Nível lógico | Representação Treemap | Representação Sunburst |
| ---: | --- | --- | --- |
| `0` | Folha | Retângulo de valor | Segmento do anel externo |
| `1` | Tronco | Retângulo ou cabeçalho do pai | Segmento do anel intermediário |
| `2` | Ramo | Retângulo ou cabeçalho de nível superior | Segmento do anel interno |

Esta ordem é a mesma para ambos os tipos de gráfico, embora seus layouts visuais sejam diferentes. Um segmento pai é compartilhado por várias folhas. Para formatá‑lo, use o nível correspondente do primeiro ponto de dados naquele grupo. Por exemplo, o ramo `Consumer` começa com o ponto `Laptops`, enquanto o tronco `Software` começa com o ponto `Licenses`. Manter referências a esses pontos é mais claro e seguro do que usar expressões não explicadas como `$dataPoints->get_Item(0)` ou `$dataPoints->get_Item(6)`.

## **Criar e personalizar ambos os tipos de gráfico**

O exemplo completo a seguir cria um Treemap no primeiro slide e um Sunburst no segundo slide. Ele constrói a hierarquia, exibe o valor para `Tablets`, aplica cores fixas aos níveis selecionados, formata um rótulo de ramo e salva a apresentação.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Adicionar as categorias folha. Um item de agrupamento é definido somente quando um novo grupo começa;
        // as categorias seguintes permanecem naquele grupo até que outro item seja definido.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Mostrar a categoria e o valor na folha Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Formatar o ramo Consumer através da primeira folha desse ramo.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Formatar o tronco Software através da primeira folha desse tronco.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout afeta os rótulos de pai do Treemap; Sunburst usa segmentos de anel.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

As células de categoria e as células de valor utilizam a mesma linha da planilha, de modo que suas posições nas coleções permanecem alinhadas. Quando você trabalha com um gráfico já existente em vez de criar um novo, examine primeiro as linhas de categoria e armazene referências nomeadas aos pontos de dados e níveis que pretende formatar.

## **Comportamento e considerações práticas**

### **Diferenças entre Treemap e Sunburst**

- Um Treemap usa área para comunicar valor e retângulos aninhados para comunicar hierarquia. O método [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseries/#setParentLabelLayout) controla como os rótulos dos pais aparecem neste tipo de gráfico.
- Um Sunburst usa ângulo para comunicar valor e profundidade de anel para comunicar hierarquia. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseries/#setParentLabelLayout) não controla os rótulos dos anéis.
- Ambos os tipos de gráfico utilizam os mesmos níveis de agrupamento de categorias e a mesma ordem folha‑para‑pai retornada por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), de modo que o código de construção de dados e de formatação de níveis pode ser compartilhado.
- Os valores dos pais são calculados a partir de suas folhas descendentes. Não adicione pontos numéricos separados para ramos ou troncos.

### **Ordenação e ordem dos segmentos**

O mecanismo de layout do gráfico determina a posição final dos retângulos e dos segmentos dos anéis. Agrupe linhas de categoria relacionadas antes de adicioná‑las, mas não dependa de uma posição de retângulo ou ângulo inicial específico. Se a sequência tiver significado, inclua‑a nos rótulos ou use um tipo de gráfico com eixo de categoria explícito.

### **Tema e cores fixas**

Os níveis de gráfico não formatados herdam cores do tema da apresentação. O exemplo usa preenchimentos RGB explícitos para resultados previsíveis. Se o gráfico precisar seguir alterações de tema, use cores de esquema em vez de valores RGB fixos e evite sobrescrever todos os níveis. Também verifique o contraste dos rótulos após mudar o preenchimento de um ramo ou tronco.

### **Rótulos e espaço disponível**

O PowerPoint pode ocultar ou truncar rótulos quando um segmento é muito pequeno. Aumentar o tamanho do gráfico, abreviar nomes de categoria ou exibir menos campos de rótulo costuma gerar um resultado mais claro. Um rótulo pode combinar o nome da categoria, o nome da série e o valor por meio de [DataLabelFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/datalabelformat/), mas habilitar todos os campos frequentemente torna os gráficos hierárquicos difíceis de ler.

### **Exportação e renderização**

Salvar em PPTX mantém o gráfico editável. Quando o Aspose.Slides renderiza a apresentação para PDF ou imagem, os preenchimentos e configurações de rótulo suportados são renderizados com o gráfico. Substituição de fontes e pequenas diferenças no espaço de layout disponível podem mudar a quebra de linha ou a visibilidade dos rótulos; portanto, instale as fontes necessárias e verifique os destinos de exportação críticos.

## **FAQ**

**Por que a alteração de um nível pai afeta várias folhas?**

Um ramo ou tronco é um segmento visual compartilhado. Seu [ChartDataPointLevel](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdatapointlevel/) pode ser acessado através de uma folha descendente, mas a formatação pertence ao segmento pai compartilhado, não apenas àquela folha.

**Por que um rótulo de dados está ausente?**

Primeiro habilite os campos necessários no objeto [DataLabelFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/datalabelformat/) do rótulo. Em seguida verifique se o segmento possui espaço suficiente. O layout de rótulo pai do Treemap, as dimensões do gráfico, o comprimento do rótulo, o tamanho da fonte e o número de campos habilitados influenciam se o rótulo pode ser exibido.

**Posso definir a ordem exata ou coordenadas dos segmentos?**

Você pode controlar a ordem das linhas de origem e manter cada grupo contíguo, mas não pode atribuir retângulos exatos do Treemap ou ângulos exatos do Sunburst. O mecanismo de layout do gráfico os calcula a partir da hierarquia, dos valores e do espaço disponível.

**Por que as cores mudam após a alteração do tema da apresentação?**

Preenchimentos baseados em tema são projetados para seguir a paleta da apresentação. Aplique cores RGB explícitas nos níveis que devem permanecer fixos ou mantenha cores de esquema quando a adaptação ao novo tema for preferível.

**A formatação personalizada será preservada em exportações PDF e de imagem?**

Sim, os preenchimentos de gráfico e configurações de rótulo suportados são incluídos durante a renderização. Para resultados consistentes entre sistemas, disponibilize as fontes necessárias e teste o tamanho final da exportação, pois o ajuste de rótulo depende do layout.

## **Veja também**

- [Create Treemap charts](/slides/pt/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/pt/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/pt/php-java/export-chart/)
- [Manage presentation themes](/slides/pt/php-java/presentation-theme/)