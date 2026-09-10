---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst em Python
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- gráfico hierárquico
- ponto de dado
- rótulo de dado
- cor de ramo
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda como criar dados hierárquicos e personalizar níveis, rótulos e cores em gráficos Treemap e Sunburst com Aspose.Slides for Python via Java."
---
## **Visão Geral**

Os gráficos Treemap e Sunburst exibem o mesmo tipo de dados hierárquicos, mas utilizam layouts diferentes. Um Treemap desenha a hierarquia como retângulos aninhados cujas áreas representam os valores das folhas. Um Sunburst a desenha como anéis concêntricos: os grupos de nível superior ficam próximos ao centro, e as categorias folha estão no anel externo.

No Aspose.Slides for Python via Java, cada valor numérico é um [ChartDataPoint](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/). Seu método [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) fornece acesso à folha e aos seus grupos pais. Este artigo explica esse mapeamento e mostra como criar e formatar ambos os tipos de gráfico a partir dos mesmos dados de exemplo.

![Um gráfico Treemap com os ramos Consumer e Business](treemap-hierarchy.png)

![Um gráfico Sunburst com a mesma hierarquia Consumer e Business](sunburst-hierarchy.png)

## **Entender Categorias, Pontos de Dados e Níveis**

O exemplo usado abaixo possui três níveis de categoria e uma série numérica:

| Ramo | Subgrupo | Folha | Receita |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Cada linha cria uma categoria folha e um ponto de dados. Os níveis de agrupamento de categoria descrevem o caminho dessa folha até seus pais. Para a primeira linha, o caminho é `Consumer > Computers > Laptops`.

Os índices retornados por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) vão da folha para cima:

| `getDataPointLevels()` índice | Nível lógico | Representação Treemap | Representação Sunburst |
| ---: | --- | --- | --- |
| `0` | Folha | Retângulo de valor | Segmento do anel externo |
| `1` | Subgrupo | Retângulo ou cabeçalho pai | Segmento do anel médio |
| `2` | Ramo | Retângulo ou cabeçalho de nível superior | Segmento do anel interno |

Essa ordem é a mesma para ambos os tipos de gráfico, embora seus layouts visuais diferam. Um segmento pai é compartilhado por várias folhas. Para formatá‑lo, use o nível correspondente do primeiro ponto de dados naquele grupo. Por exemplo, o ramo `Consumer` começa com o ponto `Laptops`, enquanto o subgrupo `Software` começa com o ponto `Licenses`. Manter referências a esses pontos é mais claro e seguro do que usar expressões não explicitas como `data_points.get_Item(0)` ou `data_points.get_Item(6)`.

## **Criar e Personalizar Ambos os Tipos de Gráfico**

O exemplo completo a seguir cria um Treemap no primeiro slide e um Sunburst no segundo slide. Ele constrói a hierarquia, exibe o valor para `Tablets`, aplica cores fixas a níveis selecionados, formata um rótulo de ramo e salva a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Adicione as categorias folha. Um item de agrupamento é definido somente quando um novo grupo começa;
        # as categorias seguintes permanecem nesse grupo até que outro item seja definido.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Exiba a categoria e o valor na folha Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Formate o ramo Consumer através da primeira folha desse ramo.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Formate o caule Software através da primeira folha desse caule.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout afeta os rótulos pai do Treemap; Sunburst usa segmentos de anel.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

As células de categoria e as células de valor utilizam a mesma linha da planilha, portanto suas posições nas coleções permanecem alinhadas. Quando você trabalha com um gráfico existente em vez de criar um novo, inspecione primeiro as linhas de categoria e armazene referências nomeadas aos pontos de dados e níveis que pretende formatar.

## **Comportamento e Considerações Práticas**

### **Diferenças entre Treemap e Sunburst**

- Um Treemap usa área para comunicar valor e retângulos aninhados para comunicar hierarquia. O método [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#setParentLabelLayout) controla como os rótulos dos pais aparecem neste tipo de gráfico.
- Um Sunburst usa ângulo para comunicar valor e profundidade de anel para comunicar hierarquia. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#setParentLabelLayout) não controla os rótulos dos anéis.
- Ambos os tipos de gráfico utilizam os mesmos níveis de agrupamento de categoria e a mesma ordem folha‑para‑pai retornada por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), portanto o código de construção de dados e de formatação de níveis pode ser compartilhado.
- Os valores dos pais são calculados a partir de suas folhas descendentes. Não adicione pontos numéricos separados para ramos ou subgrupos.

### **Ordenação e Ordem dos Segmentos**

O mecanismo de layout do gráfico determina a posição final dos retângulos e dos segmentos de anel. Organize linhas de categoria relacionadas juntas antes de adicioná‑las, mas não dependa de uma posição de retângulo ou ângulo inicial específicos. Se a sequência possuir significado, inclua‑a nos rótulos ou use um tipo de gráfico com eixo de categoria explícito.

### **Tema e Cores Fixas**

Níveis de gráfico não formatados herdam cores do tema da apresentação. O exemplo usa preenchimentos RGB explícitos para resultados previsíveis. Se o gráfico precisar seguir alterações de tema, use cores de esquema em vez de valores RGB fixos e evite sobrescrever todos os níveis. Também verifique o contraste dos rótulos após mudar o preenchimento de um ramo ou subgrupo.

### **Rótulos e Espaço Disponível**

O PowerPoint pode ocultar ou truncar rótulos quando um segmento é muito pequeno. Aumentar o tamanho do gráfico, encurtar nomes de categoria ou mostrar menos campos de rótulo geralmente produz um resultado mais claro. Um rótulo pode combinar o nome da categoria, o nome da série e o valor através de [DataLabelFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datalabelformat/), mas habilitar todos os campos costuma tornar gráficos hierárquicos difíceis de ler.

### **Exportação e Renderização**

Salvar em PPTX mantém o gráfico editável. Quando o Aspose.Slides renderiza a apresentação para PDF ou imagem, os preenchimentos e configurações de rótulo suportados são renderizados junto ao gráfico. Substituição de fontes e pequenas diferenças no espaço de layout disponível podem alterar quebras de linha ou a visibilidade dos rótulos, portanto instale as fontes necessárias e verifique os alvos de exportação importantes.

## **Perguntas Frequentes**

**Por que alterando um nível pai afeta várias folhas?**

Um ramo ou subgrupo é um segmento visual compartilhado. Seu [ChartDataPointLevel](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapointlevel/) pode ser alcançado através de uma folha descendente, mas a formatação pertence ao segmento pai compartilhado, e não somente àquela folha.

**Por que um rótulo de dado está ausente?**

Primeiro habilite os campos necessários no objeto [DataLabelFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datalabelformat/) do rótulo. Em seguida, verifique se o segmento tem espaço suficiente. O layout de rótulo pai do Treemap, as dimensões do gráfico, o comprimento do rótulo, o tamanho da fonte e o número de campos habilitados afetam se o rótulo pode ser exibido.

**Posso definir a ordem exata ou as coordenadas dos segmentos?**

Você pode controlar a ordem das linhas‑fonte e manter cada grupo contíguo, mas não pode atribuir retângulos exatos do Treemap ou ângulos exatos do Sunburst. O mecanismo de layout do gráfico os calcula a partir da hierarquia, valores e espaço disponível.

**Por que as cores mudam após a alteração do tema da apresentação?**

Preenchimentos baseados em tema são projetados para seguir a paleta da apresentação. Aplique cores RGB explícitas aos níveis que devem permanecer fixos ou mantenha cores de esquema quando a adaptação a um novo tema for preferida.

**A formatação personalizada será preservada em exportações PDF e de imagem?**

Sim, os preenchimentos de gráfico e configurações de rótulo suportados são incluídos durante a renderização. Para resultados consistentes entre sistemas, disponibilize as fontes necessárias e teste o tamanho final da exportação, pois o ajuste de rótulo depende do layout.

## **Veja Também**

- [Create Treemap charts](/slides/pt/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/pt/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/pt/python-java/export-chart/)
- [Manage presentation themes](/slides/pt/python-java/presentation-theme/)