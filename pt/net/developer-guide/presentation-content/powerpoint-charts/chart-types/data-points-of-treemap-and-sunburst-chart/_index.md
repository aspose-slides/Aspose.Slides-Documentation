---
title: Personalizar pontos de dados em gráficos Treemap e Sunburst no .NET
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico treemap
- gráfico sunburst
- gráfico hierárquico
- ponto de dado
- rótulo de dado
- cor de ramo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a criar dados hierárquicos e personalizar níveis, rótulos e cores em gráficos Treemap e Sunburst com Aspose.Slides para .NET."
---
## **Visão geral**

Os gráficos Treemap e Sunburst exibem o mesmo tipo de dados hierárquicos, mas utilizam layouts diferentes. Um Treemap representa a hierarquia como retângulos aninhados cujas áreas correspondem aos valores das folhas. Um Sunburst a representa como anéis concêntricos: os grupos de nível superior ficam próximos ao centro, e as categorias de folha ficam no anel externo.

No Aspose.Slides para .NET, cada valor numérico é um [IChartDataPoint](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/). Sua coleção [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) fornece acesso à folha e aos seus grupos pai. Este artigo explica esse mapeamento e demonstra como criar e formatar ambos os tipos de gráfico a partir dos mesmos dados de exemplo.

![Um gráfico Treemap com ramos Consumer e Business](treemap-hierarchy.png)

![Um gráfico Sunburst com a mesma hierarquia Consumer e Business](sunburst-hierarchy.png)

## **Entender categorias, pontos de dados e níveis**

O exemplo usado abaixo possui três níveis de categoria e uma série numérica:

| Branch | Stem | Leaf | Revenue |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Cada linha cria uma categoria folha e um ponto de dado. Os níveis de agrupamento de categoria descrevem o caminho dessa folha até seus pais. Para a primeira linha, o caminho é `Consumer > Computers > Laptops`.

Os índices em [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) vão da folha para cima:

| `DataPointLevels` index | Logical level | Representação Treemap | Representação Sunburst |
| ---: | --- | --- | --- |
| `0` | Leaf | Retângulo de valor | Segmento do anel externo |
| `1` | Stem | Retângulo ou cabeçalho do pai | Segmento do anel médio |
| `2` | Branch | Retângulo ou cabeçalho de nível superior | Segmento do anel interno |

Essa ordem é a mesma para ambos os tipos de gráfico, embora seus layouts visuais diferam. Um segmento pai é compartilhado por várias folhas. Para formatá‑lo, use o nível correspondente do primeiro ponto de dado naquele grupo. Por exemplo, o ramo `Consumer` começa com o ponto `Laptops`, enquanto o tronco `Software` começa com o ponto `Licenses`. Manter referências a esses pontos é mais claro e seguro do que usar expressões não explicitas como `dataPoints[0]` ou `dataPoints[6]`.

## **Criar e personalizar ambos os tipos de gráfico**

O exemplo completo a seguir cria um Treemap no primeiro slide e um Sunburst no segundo slide. Ele constrói a hierarquia, exibe o valor para `Tablets`, aplica cores fixas aos níveis selecionados, formata o rótulo de um ramo e salva a apresentação.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Add the leaf categories. A grouping item is set only when a new group begins;
    // the following categories remain in that group until another item is set.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Show the category and value on the Tablets leaf.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Format the Consumer branch through the first leaf in that branch.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Format the Software stem through the first leaf in that stem.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout affects Treemap parent labels; Sunburst uses ring segments.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

As células de categoria e as células de valor usam a mesma linha da planilha, portanto suas posições nas coleções permanecem alinhadas. Quando você trabalha com um gráfico existente em vez de criar um novo, inspecione primeiro as linhas de categoria e armazene referências nomeadas aos pontos de dado e níveis que pretende formatar.

## **Comportamento e considerações práticas**

### **Diferenças entre Treemap e Sunburst**

- Um Treemap usa área para comunicar valor e retângulos aninhados para comunicar hierarquia. A propriedade [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/parentlabellayout/) controla como os rótulos dos pais aparecem neste tipo de gráfico.
- Um Sunburst usa ângulo para comunicar valor e profundidade de anel para comunicar hierarquia. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/parentlabellayout/) não controla os rótulos dos anéis.
- Ambos os tipos de gráfico utilizam os mesmos níveis de agrupamento de categoria e a mesma ordem folha‑para‑pai em `DataPointLevels`, de modo que o código de construção de dados e de formatação de níveis pode ser compartilhado.
- Valores dos pais são calculados a partir de suas folhas descendentes. Não adicione pontos numéricos separados para ramos ou troncos.

### **Ordenação e ordem dos segmentos**

O mecanismo de layout do gráfico determina a posição final dos retângulos e dos segmentos de anel. Agrupe linhas de categoria relacionadas antes de adicioná‑las, mas não dependa de uma posição de retângulo ou ângulo inicial específicos. Se a sequência tiver significado, inclua‑a nos rótulos ou use um tipo de gráfico com eixo de categoria explícito.

### **Tema e cores fixas**

Níveis de gráfico não formatados herdam cores do tema da apresentação. O exemplo usa preenchimentos RGB explícitos para obter saída previsível. Se o gráfico precisar seguir mudanças de tema, use cores de esquema em vez de valores RGB fixos e evite sobrescrever todos os níveis. Também verifique o contraste dos rótulos após alterar o preenchimento de um ramo ou tronco.

### **Rótulos e espaço disponível**

O PowerPoint pode ocultar ou truncar rótulos quando um segmento é muito pequeno. Aumentar o tamanho do gráfico, abreviar nomes de categoria ou exibir menos campos de rótulo costuma gerar um resultado mais claro. Um rótulo pode combinar nome da categoria, nome da série e valor através de [IDataLabelFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/idatalabelformat/), mas habilitar todos os campos frequentemente dificulta a leitura de gráficos hierárquicos.

### **Exportação e renderização**

Salvar como PPTX mantém o gráfico editável. Quando o Aspose.Slides renderiza a apresentação para PDF ou imagem, os preenchimentos e configurações de rótulo suportados são renderizados com o gráfico. Substituição de fontes e pequenas diferenças no espaço de layout disponível podem alterar quebras de linha ou visibilidade dos rótulos, portanto instale as fontes necessárias e verifique os alvos de exportação importantes.

## **FAQ**

**Por que a alteração de um nível pai afeta várias folhas?**

Um ramo ou tronco é um segmento visual compartilhado. Seu [IChartDataPointLevel](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapointlevel/) pode ser acessado por meio de uma folha descendente, mas a formatação pertence ao segmento pai compartilhado, não apenas àquela folha.

**Por que um rótulo de dado está ausente?**

Primeiro habilite os campos necessários no objeto [IDataLabelFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/idatalabelformat/) do rótulo. Em seguida, verifique se o segmento possui espaço suficiente. O layout de rótulo do pai em Treemap, as dimensões do gráfico, o comprimento do rótulo, o tamanho da fonte e o número de campos habilitados influenciam se o rótulo pode ser exibido.

**Posso definir a ordem exata ou as coordenadas dos segmentos?**

Você pode controlar a ordem das linhas‑fonte e manter cada grupo contíguo, mas não pode atribuir retângulos Treemap ou ângulos Sunburst exatos. O mecanismo de layout calcula‑os a partir da hierarquia, dos valores e do espaço disponível.

**Por que as cores mudam após a alteração do tema da apresentação?**

Preenchimentos baseados em tema são projetados para seguir a paleta da apresentação. Aplique cores RGB explícitas aos níveis que precisam permanecer fixos ou mantenha cores de esquema quando for preferível adaptar‑se a um novo tema.

**A formatação personalizada será preservada em exportações PDF e de imagem?**

Sim, os preenchimentos e configurações de rótulo suportados são incluídos durante a renderização. Para resultados consistentes entre sistemas, disponibilize as fontes necessárias e teste o tamanho final da exportação, pois o ajuste de rótulos depende do layout.

## **Veja também**

- [Create Treemap charts](/slides/pt/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/pt/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/pt/net/export-chart/)
- [Manage presentation themes](/slides/pt/net/presentation-theme/)