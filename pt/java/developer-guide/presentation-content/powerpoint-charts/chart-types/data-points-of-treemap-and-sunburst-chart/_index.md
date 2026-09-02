---
title: Personalizar pontos de dados em gráficos Treemap e Sunburst em Java
linktitle: Pontos de dados em gráficos Treemap e Sunburst
type: docs
url: /pt/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- gráfico hierárquico
- ponto de dado
- rótulo de dados
- cor de ramo
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda a criar dados hierárquicos e personalizar níveis, rótulos e cores em gráficos Treemap e Sunburst com Aspose.Slides para Java."
---
## **Visão geral**

Gráficos de Treemap e Sunburst exibem o mesmo tipo de dados hierárquicos, mas utilizam layouts diferentes. Um Treemap desenha a hierarquia como retângulos aninhados cujas áreas representam os valores das folhas. Um Sunburst a desenha como anéis concêntricos: grupos de nível superior ficam próximos ao centro, e as categorias de folha ficam no anel externo.

No Aspose.Slides for Java, cada valor numérico é um [IChartDataPoint](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/). Seu método [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) fornece acesso à folha e aos seus grupos pais. Este artigo explica esse mapeamento e mostra como criar e formatar ambos os tipos de gráfico a partir dos mesmos dados de exemplo.

![Um gráfico Treemap com ramificações Consumer e Business](treemap-hierarchy.png)

![Um gráfico Sunburst com a mesma hierarquia Consumer e Business](sunburst-hierarchy.png)

## **Entender categorias, pontos de dados e níveis**

O exemplo usado abaixo tem três níveis de categoria e uma série numérica:

| Ramo | Caule | Folha | Receita |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Cada linha cria uma categoria folha e um ponto de dado. Os níveis de agrupamento de categoria descrevem o caminho daquela folha até seus pais. Para a primeira linha, o caminho é `Consumer > Computers > Laptops`.

Os índices retornados por [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) vão da folha para cima:

| Índice `getDataPointLevels()` | Nível lógico | Representação Treemap | Representação Sunburst |
| ---: | --- | --- | --- |
| `0` | Folha | Retângulo de valor | Segmento do anel externo |
| `1` | Caule | Retângulo ou cabeçalho do pai | Segmento do anel intermediário |
| `2` | Ramo | Retângulo ou cabeçalho do nível superior | Segmento do anel interno |

Essa ordem é a mesma para ambos os tipos de gráfico, embora seus layouts visuais diferam. Um segmento pai é compartilhado por várias folhas. Para formatá‑lo, use o nível correspondente do primeiro ponto de dado naquele grupo. Por exemplo, o ramo `Consumer` começa com o ponto `Laptops`, enquanto o caule `Software` começa com o ponto `Licenses`. Manter referências a esses pontos é mais claro e seguro do que usar expressões não explicadas como `dataPoints.get_Item(0)` ou `dataPoints.get_Item(6)`.

## **Criar e personalizar ambos os tipos de gráfico**

O exemplo completo a seguir cria um Treemap no primeiro slide e um Sunburst no segundo slide. Ele constrói a hierarquia, exibe o valor para `Tablets`, aplica cores fixas a níveis selecionados, formata um rótulo de ramo e salva a apresentação.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Adicionar as categorias de folha. Um item de agrupamento é definido somente quando um novo grupo começa;
        // as categorias subsequentes permanecem nesse grupo até que outro item seja definido.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Exibir a categoria e o valor na folha Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatar o ramo Consumer através da primeira folha desse ramo.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Formatar o caule Software através da primeira folha desse caule.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout afeta os rótulos de pais do Treemap; Sunburst usa segmentos de anel.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

As células de categoria e as células de valor usam a mesma linha da planilha, portanto suas posições nas coleções permanecem alinhadas. Quando você trabalha com um gráfico existente em vez de criar um, examine primeiro as linhas de categoria e armazene referências nomeadas aos pontos de dados e níveis que pretende formatar.

## **Comportamento e considerações práticas**

### **Diferenças entre Treemap e Sunburst**

- Um Treemap usa área para comunicar valor e retângulos aninhados para comunicar hierarquia. O método [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) controla como os rótulos dos pais aparecem nesse tipo de gráfico.
- Um Sunburst usa ângulo para comunicar valor e profundidade do anel para comunicar hierarquia. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) não controla os rótulos dos anéis.
- Ambos os tipos de gráfico usam os mesmos níveis de agrupamento de categoria e a mesma ordem folha‑para‑pai retornada por [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), de modo que o código de construção de dados e de formatação de níveis pode ser compartilhado.
- Valores de pais são calculados a partir de suas folhas descendentes. Não adicione pontos numéricos separados para ramos ou caules.

### **Ordenação e ordem dos segmentos**

O motor de layout do gráfico determina a posição final dos retângulos e segmentos de anel. Agrupe linhas de categoria relacionadas antes de adicioná‑las, mas não dependa de uma posição de retângulo ou ângulo inicial específicos. Se a sequência tem significado, inclua‑a nos rótulos ou use um tipo de gráfico com eixo de categoria explícito.

### **Tema e cores fixas**

Níveis de gráfico não formatados herdam cores do tema da apresentação. O exemplo usa preenchimentos RGB explícitos para saída previsível. Se o gráfico deve seguir alterações de tema, use cores de esquema em vez de valores RGB fixos e evite sobrescrever todos os níveis. Também verifique o contraste do rótulo após mudar o preenchimento de um ramo ou caule.

### **Rótulos e espaço disponível**

O PowerPoint pode ocultar ou truncar rótulos quando um segmento é muito pequeno. Aumentar o tamanho do gráfico, encurtar nomes de categoria ou exibir menos campos de rótulo geralmente produz um resultado mais claro. Um rótulo pode combinar o nome da categoria, o nome da série e o valor através de [IDataLabelFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idatalabelformat/), mas habilitar todos os campos costuma tornar gráficos hierárquicos difíceis de ler.

### **Exportação e renderização**

Salvar como PPTX mantém o gráfico editável. Quando o Aspose.Slides renderiza a apresentação para PDF ou imagem, os preenchimentos e configurações de rótulo suportados são renderizados com o gráfico. Substituição de fontes e pequenas diferenças no espaço de layout disponível podem mudar quebras de linha ou visibilidade de rótulos, portanto instale as fontes necessárias e verifique os destinos de exportação importantes.

## **FAQ**

**Por que a alteração de um nível pai afeta várias folhas?**

Um ramo ou caule é um segmento visual compartilhado. Seu [IChartDataPointLevel](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapointlevel/) pode ser alcançado através de uma folha descendente, mas a formatação pertence ao segmento pai compartilhado, não apenas àquela folha.

**Por que falta um rótulo de dados?**

Primeiro habilite os campos necessários no objeto [IDataLabelFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idatalabelformat/) do rótulo. Em seguida, verifique se o segmento tem espaço suficiente. O layout de rótulo pai do Treemap, as dimensões do gráfico, o comprimento do rótulo, o tamanho da fonte e o número de campos habilitados afetam se um rótulo pode ser exibido.

**Posso definir a ordem exata ou as coordenadas dos segmentos?**

Você pode controlar a ordem das linhas de origem e manter cada grupo contíguo, mas não pode atribuir retângulos de Treemap ou ângulos de Sunburst exatos. O motor de layout do gráfico os calcula a partir da hierarquia, valores e espaço disponível.

**Por que as cores mudam após a alteração do tema da apresentação?**

Preenchimentos baseados em tema são projetados para seguir a paleta da apresentação. Aplique cores RGB explícitas aos níveis que devem permanecer fixos ou mantenha cores de esquema quando a adaptação a um novo tema for preferida.

**A formatação personalizada será preservada em exportações para PDF e imagem?**

Sim, os preenchimentos de gráfico e configurações de rótulo suportados são incluídos durante a renderização. Para resultados consistentes entre sistemas, disponibilize as fontes necessárias e teste o tamanho final da exportação, pois o ajuste de rótulo depende do layout.

## **Veja também**

- [Create Treemap charts](/slides/pt/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/pt/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/pt/java/export-chart/)
- [Manage presentation themes](/slides/pt/java/presentation-theme/)