---
title: Personalizar pontos de dados em gráficos Treemap e Sunburst usando JavaScript
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- gráfico hierárquico
- ponto de dados
- rótulo de dados
- cor de ramo
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como criar dados hierárquicos e personalizar níveis, rótulos e cores em gráficos Treemap e Sunburst com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Os gráficos de Treemap e Sunburst exibem o mesmo tipo de dados hierárquicos, mas utilizam layouts diferentes. Um Treemap desenha a hierarquia como retângulos aninhados cujas áreas representam os valores das folhas. Um Sunburst a desenha como anéis concêntricos: os grupos de nível superior ficam perto do centro e as categorias de folhas estão no anel externo.

Na Aspose.Slides for Node.js via Java, cada valor numérico é um [ChartDataPoint](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/). Seu método [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) fornece acesso à folha e aos grupos pais. Este artigo explica esse mapeamento e mostra como criar e formatar ambos os tipos de gráficos a partir dos mesmos dados de exemplo.

![Um gráfico Treemap com ramos Consumer e Business](treemap-hierarchy.png)

![Um gráfico Sunburst com a mesma hierarquia Consumer e Business](sunburst-hierarchy.png)

## **Entender categorias, pontos de dados e níveis**

O exemplo usado abaixo possui três níveis de categoria e uma série numérica:

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

Cada linha cria uma categoria folha e um ponto de dados. Os níveis de agrupamento de categoria descrevem o caminho da folha até seus pais. Para a primeira linha, o caminho é `Consumer > Computers > Laptops`.

Os índices retornados por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) vão da folha para cima:

| `getDataPointLevels()` índice | Nível lógico | Representação Treemap | Representação Sunburst |
| ---: | --- | --- | --- |
| `0` | Folha | Retângulo de valor | Segmento de anel externo |
| `1` | Tronco | Retângulo pai ou cabeçalho | Segmento de anel médio |
| `2` | Ramo | Retângulo ou cabeçalho de nível superior | Segmento de anel interno |

Essa ordem é a mesma para ambos os tipos de gráfico, embora seus layouts visuais difiram. Um segmento pai é compartilhado por várias folhas. Para formatá‑lo, use o nível correspondente do primeiro ponto de dados naquele grupo. Por exemplo, o ramo `Consumer` começa com o ponto `Laptops`, enquanto o tronco `Software` começa com o ponto `Licenses`. Manter referências a esses pontos é mais claro e seguro do que usar expressões não explicadas como `dataPoints.get_Item(0)` ou `dataPoints.get_Item(6)`.

## **Criar e personalizar ambos os tipos de gráficos**

O exemplo completo a seguir cria um Treemap no primeiro slide e um Sunburst no segundo slide. Ele constrói a hierarquia, exibe o valor para `Tablets`, aplica cores fixas a níveis selecionados, formata um rótulo de ramo e salva a apresentação.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Adicionar as categorias de folha. Um item de agrupamento é definido somente quando um novo grupo começa;
        // as categorias seguintes permanecem nesse grupo até que outro item seja definido.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Mostrar a categoria e o valor na folha Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatar o ramo Consumer através da primeira folha desse ramo.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Formatar o tronco Software através da primeira folha desse tronco.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout afeta os rótulos de pais do Treemap; Sunburst usa segmentos de anel.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

As células de categoria e as células de valor utilizam a mesma linha da planilha, de modo que suas posições nas coleções permanecem alinhadas. Ao trabalhar com um gráfico existente em vez de criar um, examine primeiro as linhas de categoria e armazene referências nomeadas aos pontos de dados e níveis que pretende formatar.

## **Comportamento e considerações práticas**

### **Diferenças entre Treemap e Sunburst**

- Um Treemap usa área para comunicar valor e retângulos aninhados para comunicar hierarquia. O método [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) controla como os rótulos dos pais aparecem neste tipo de gráfico.
- Um Sunburst usa ângulo para comunicar valor e profundidade de anel para comunicar hierarquia. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) não controla os rótulos dos anéis.
- Ambos os tipos de gráfico utilizam os mesmos níveis de agrupamento de categoria e a mesma ordem folha‑para‑pai retornada por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), portanto o código de construção de dados e formatação de níveis pode ser compartilhado.
- Os valores dos pais são calculados a partir das folhas descendentes. Não adicione pontos numéricos separados para ramos ou troncos.

### **Ordenação e ordem dos segmentos**

O mecanismo de layout do gráfico determina a posição final dos retângulos e dos segmentos de anel. Agrupe linhas de categoria relacionadas antes de adicioná‑las, mas não dependa de uma posição de retângulo ou ângulo inicial específicos. Se a sequência tiver significado, inclua‑a nos rótulos ou use um tipo de gráfico com eixo de categoria explícito.

### **Tema e cores fixas**

Níveis de gráfico não formatados herdam cores do tema da apresentação. O exemplo usa preenchimentos RGB explícitos para resultados previsíveis. Se o gráfico precisar seguir alterações de tema, use cores de esquema em vez de valores RGB fixos e evite sobrescrever cada nível. Também verifique o contraste dos rótulos ao alterar o preenchimento de um ramo ou tronco.

### **Rótulos e espaço disponível**

O PowerPoint pode ocultar ou truncar rótulos quando um segmento é muito pequeno. Aumentar o tamanho do gráfico, encurtar nomes de categoria ou mostrar menos campos de rótulo costuma produzir um resultado mais claro. Um rótulo pode combinar o nome da categoria, o nome da série e o valor através de [DataLabelFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datalabelformat/), mas habilitar todos os campos costuma tornar gráficos hierárquicos difíceis de ler.

### **Exportação e renderização**

Salvar como PPTX mantém o gráfico editável. Quando Aspose.Slides renderiza a apresentação para PDF ou imagem, os preenchimentos suportados e as configurações de rótulo são renderizados com o gráfico. Substituição de fontes e pequenas diferenças no espaço de layout disponível podem mudar a quebra de linha ou a visibilidade do rótulo, portanto instale as fontes necessárias e verifique os destinos de exportação importantes.

## **Perguntas frequentes**

**Por que alterar um nível pai afeta várias folhas?**

Um ramo ou tronco é um segmento visual compartilhado. Seu [ChartDataPointLevel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapointlevel/) pode ser acessado através de uma folha descendente, mas a formatação pertence ao segmento pai compartilhado, e não somente àquela folha.

**Por que um rótulo de dados está faltando?**

Primeiro habilite os campos requeridos no objeto [DataLabelFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datalabelformat/) do rótulo. Em seguida, verifique se o segmento tem espaço suficiente. O layout de rótulo pai do Treemap, as dimensões do gráfico, o comprimento do rótulo, o tamanho da fonte e o número de campos habilitados influenciam se o rótulo pode ser exibido.

**Posso definir a ordem exata ou as coordenadas dos segmentos?**

Você pode controlar a ordem das linhas de origem e manter cada grupo contíguo, mas não pode atribuir retângulos Treemap ou ângulos Sunburst exatos. O mecanismo de layout do gráfico os calcula a partir da hierarquia, dos valores e do espaço disponível.

**Por que as cores mudam após a alteração do tema da apresentação?**

Preenchimentos baseados em tema são projetados para seguir a paleta da apresentação. Aplique cores RGB explícitas aos níveis que devem permanecer fixos ou mantenha cores de esquema quando a adaptação a um novo tema for preferida.

**A formatação personalizada será preservada nas exportações para PDF e imagem?**

Sim, os preenchimentos de gráfico e as configurações de rótulo suportados são incluídos durante a renderização. Para resultados consistentes entre sistemas, disponibilize as fontes necessárias e teste o tamanho final da exportação, pois o ajuste de rótulo depende do layout.

## **Veja também**

- [Criar gráficos Treemap](/slides/pt/nodejs-java/create-chart/#creating-tree-map-charts)
- [Criar gráficos Sunburst](/slides/pt/nodejs-java/create-chart/#creating-sunburst-charts)
- [Exportar gráficos de apresentação](/slides/pt/nodejs-java/export-chart/)
- [Gerenciar temas de apresentação](/slides/pt/nodejs-java/presentation-theme/)