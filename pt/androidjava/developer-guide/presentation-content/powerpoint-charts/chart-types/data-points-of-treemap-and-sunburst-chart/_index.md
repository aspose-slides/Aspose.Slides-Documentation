---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst no Android
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/androidjava/data-points-of-treemap-and-sunburst-chart/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda como criar dados hierárquicos e personalizar níveis, rótulos e cores em gráficos Treemap e Sunburst com Aspose.Slides para Android via Java."
---
## **Visão Geral**

Os gráficos Treemap e Sunburst exibem o mesmo tipo de dados hierárquicos, mas utilizam layouts diferentes. Um Treemap desenha a hierarquia como retângulos aninhados cujas áreas representam os valores das folhas. Um Sunburst desenha‑a como anéis concêntricos: grupos de nível superior ficam próximos ao centro e as categorias das folhas ficam no anel externo.

No Aspose.Slides for Android via Java, cada valor numérico é um [IChartDataPoint](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatapoint/). Seu método [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) fornece acesso à folha e aos seus grupos pais. Este artigo explica esse mapeamento e mostra como criar e formatar ambos os tipos de gráfico a partir dos mesmos dados de exemplo.

![Um gráfico Treemap com ramificações Consumer e Business](treemap-hierarchy.png)

![Um gráfico Sunburst com a mesma hierarquia Consumer e Business](sunburst-hierarchy.png)

## **Entender Categorias, Pontos de Dados e Níveis**

O exemplo usado abaixo tem três níveis de categoria e uma série numérica:

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

Cada linha cria uma categoria de folha e um ponto de dados. Os níveis de agrupamento de categoria descrevem o caminho dessa folha até seus pais. Para a primeira linha, o caminho é `Consumer > Computers > Laptops`.

Os índices retornados por [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) vão da folha para cima:

| índice `getDataPointLevels()` | Nível lógico | Representação Treemap | Representação Sunburst |
| ---: | --- | --- | --- |
| `0` | Folha | Retângulo de valor | Segmento do anel externo |
| `1` | Tronco | Retângulo ou cabeçalho pai | Segmento do anel médio |
| `2` | Ramo | Retângulo ou cabeçalho de nível superior | Segmento do anel interno |

Essa ordem é a mesma para ambos os tipos de gráfico, embora seus layouts visuais diferam. Um segmento pai é compartilhado por várias folhas. Para formatá‑lo, use o nível correspondente do primeiro ponto de dados naquele grupo. Por exemplo, o ramo `Consumer` começa com o ponto `Laptops`, enquanto o tronco `Software` começa com o ponto `Licenses`. Manter referências a esses pontos é mais claro e seguro do que usar expressões não explicadas como `dataPoints.get_Item(0)` ou `dataPoints.get_Item(6)`.

## **Criar e Personalizar Ambos os Tipos de Gráfico**

O exemplo completo abaixo cria um Treemap no primeiro slide e um Sunburst no segundo slide. Ele constrói a hierarquia, exibe o valor para `Tablets`, aplica cores fixas a níveis selecionados, formata um rótulo de ramo e salva a apresentação.

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

        // Adicione as categorias de folhas. Um item de agrupamento é definido somente quando um novo grupo começa;
        // as categorias seguintes permanecem nesse grupo até que outro item seja definido.
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

        // Exiba a categoria e o valor na folha Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formate o ramo Consumer através da primeira folha desse ramo.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Formate o tronco Software através da primeira folha desse tronco.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
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

As células de categoria e as células de valor usam a mesma linha da planilha, de modo que suas posições nas coleções permanecem alinhadas. Quando você trabalha com um gráfico existente em vez de criar um, inspecione primeiro as linhas de categoria e armazene referências nomeadas aos pontos de dados e níveis que pretende formatar.

## **Comportamento e Considerações Práticas**

### **Diferenças entre Treemap e Sunburst**

- Um Treemap usa área para comunicar o valor e retângulos aninhados para comunicar a hierarquia. O método IChartSeries.setParentLabelLayout controla como os rótulos dos pais aparecem neste tipo de gráfico.
- Um Sunburst usa ângulo para comunicar o valor e profundidade do anel para comunicar a hierarquia. IChartSeries.setParentLabelLayout não controla os rótulos dos anéis.
- Ambos os tipos de gráfico usam os mesmos níveis de agrupamento de categoria e a mesma ordem folha‑para‑pai retornada por IChartDataPoint.getDataPointLevels, portanto o código de construção de dados e formatação de níveis pode ser compartilhado.
- Os valores dos pais são calculados a partir de suas folhas descendentes. Não adicione pontos numéricos separados para ramos ou troncos.

### **Ordenação e Ordem dos Segmentos**

O mecanismo de layout do gráfico determina a posição final dos retângulos e segmentos de anel. Agrupe linhas de categoria relacionadas antes de adicioná‑las, mas não dependa de uma posição de retângulo ou ângulo inicial específico. Se a sequência tiver significado, inclua‑a nos rótulos ou use um tipo de gráfico com eixo de categoria explícito.

### **Tema e Cores Fixas**

Níveis de gráfico não formatados herdados as cores do tema da apresentação. O exemplo usa preenchimentos RGB explícitos para saída previsível. Se o gráfico precisar seguir alterações de tema, use cores de esquema em vez de valores RGB fixos e evite substituir cada nível. Também verifique o contraste dos rótulos após mudar o preenchimento de um ramo ou tronco.

### **Rótulos e Espaço Disponível**

O PowerPoint pode ocultar ou truncar rótulos quando um segmento é muito pequeno. Aumentar o tamanho do gráfico, encurtar nomes de categoria ou mostrar menos campos de rótulo costuma produzir um resultado mais claro. Um rótulo pode combinar o nome da categoria, o nome da série e o valor através de [IDataLabelFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idatalabelformat/), mas habilitar todos os campos frequentemente torna gráficos hierárquicos difíceis de ler.

### **Exportação e Renderização**

Salvar como PPTX mantém o gráfico editável. Quando Aspose.Slides renderiza a apresentação para PDF ou imagem, os preenchimentos e configurações de rótulo suportados são renderizados com o gráfico. Substituição de fontes e pequenas diferenças no espaço de layout disponível podem mudar a quebra de linha ou a visibilidade do rótulo, portanto instale as fontes necessárias e verifique os destinos de exportação principais.

## **FAQ**

**Por que a alteração de um nível pai afeta várias folhas?**

Um ramo ou tronco é um segmento visual compartilhado. Seu [IChartDataPointLevel](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartdatapointlevel/) pode ser acessado através de uma folha descendente, mas a formatação pertence ao segmento pai compartilhado, não apenas àquela folha.

**Por que um rótulo de dados está ausente?**

Primeiro habilite os campos necessários no objeto [IDataLabelFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idatalabelformat/) do rótulo. Depois verifique se o segmento tem espaço suficiente. O layout de rótulo de pai do Treemap, as dimensões do gráfico, o comprimento do rótulo, o tamanho da fonte e o número de campos habilitados afetam se um rótulo pode ser exibido.

**Posso definir a ordem exata ou coordenadas dos segmentos?**

Você pode controlar a ordem das linhas‑fonte e manter cada grupo contíguo, mas não pode atribuir retângulos Treemap ou ângulos Sunburst exatos. O mecanismo de layout do gráfico os calcula a partir da hierarquia, dos valores e do espaço disponível.

**Por que as cores mudam após alterações no tema da apresentação?**

Preenchimentos baseados em tema são projetados para seguir a paleta da apresentação. Aplique cores RGB explícitas aos níveis que devem permanecer fixas ou mantenha cores de esquema quando a adaptação a um novo tema for preferida.

**A formatação personalizada será preservada em exportações para PDF e imagem?**

Sim, preenchimentos de gráfico e configurações de rótulo suportados são incluídos durante a renderização. Para resultados consistentes entre sistemas, disponibilize as fontes necessárias e teste o tamanho final da exportação, pois o ajuste de rótulo depende do layout.

## **Veja Também**

- [Criar gráficos Treemap](/slides/pt/androidjava/create-chart/#create-tree-map-charts)
- [Criar gráficos Sunburst](/slides/pt/androidjava/create-chart/#create-sunburst-charts)
- [Exportar gráficos de apresentação](/slides/pt/androidjava/export-chart/)
- [Gerenciar temas de apresentação](/slides/pt/androidjava/presentation-theme/)