---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst no Python
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico Treemap
- gráfico Sunburst
- gráfico hierárquico
- ponto de dados
- rótulo de dados
- cor de ramo
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como criar dados hierárquicos e personalizar níveis, rótulos e cores em gráficos Treemap e Sunburst com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Os gráficos Treemap e Sunburst exibem o mesmo tipo de dados hierárquicos, mas utilizam layouts diferentes. Um Treemap desenha a hierarquia como retângulos aninhados cujas áreas representam os valores das folhas. Um Sunburst a desenha como anéis concêntricos: os grupos de nível superior ficam próximos ao centro e as categorias de folha estão no anel externo.

No Aspose.Slides for Python via .NET, cada valor numérico é um [ChartDataPoint](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapoint/). Sua coleção [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) fornece acesso à folha e aos seus grupos pai. Este artigo explica esse mapeamento e mostra como criar e formatar ambos os tipos de gráfico a partir dos mesmos dados de exemplo.

![Um gráfico Treemap com ramos Consumer e Business](treemap-hierarchy.png)

![Um gráfico Sunburst com a mesma hierarquia Consumer e Business](sunburst-hierarchy.png)

## **Entender Categorias, Pontos de Dados e Níveis**

O exemplo usado abaixo tem três níveis de categoria e uma série numérica:

| Ramo | Segmento | Folha | Receita |
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

Os índices em [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) percorrem da folha para cima:

| `data_point_levels` index | Nível lógico | Representação Treemap | Representação Sunburst |
| ---: | --- | --- | --- |
| `0` | Folha | Retângulo de valor | Segmento do anel externo |
| `1` | Segmento | Retângulo pai ou cabeçalho | Segmento do anel intermediário |
| `2` | Ramo | Retângulo de nível superior ou cabeçalho | Segmento do anel interno |

Essa ordem é a mesma para ambos os tipos de gráfico, embora seus layouts visuais diferam. Um segmento pai é compartilhado por várias folhas. Para formatá‑lo, use o nível correspondente do primeiro ponto de dados daquele grupo. Por exemplo, o ramo `Consumer` começa com o ponto `Laptops`, enquanto o segmento `Software` começa com o ponto `Licenses`. Manter referências a esses pontos é mais claro e seguro do que usar expressões não explicadas como `data_points[0]` ou `data_points[6]`.

## **Criar e Personalizar Ambos os Tipos de Gráfico**

O exemplo completo a seguir cria um Treemap no primeiro slide e um Sunburst no segundo slide. Ele constrói a hierarquia, exibe o valor para `Tablets`, aplica cores fixas a níveis selecionados, formata um rótulo de ramo e salva a apresentação.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Adicionar as categorias de folhas. Um item de agrupamento é definido apenas quando um novo grupo começa;
    # as categorias seguintes permanecem nesse grupo até que outro item seja definido.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Mostrar a categoria e o valor na folha Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Formatar o ramo Consumer através da primeira folha desse ramo.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Formatar o segmento Software através da primeira folha desse segmento.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout afeta os rótulos de pai do Treemap; Sunburst usa segmentos de anel.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

As células de categoria e as células de valor usam a mesma linha da planilha, de modo que suas posições nas coleções permanecem alinhadas. Quando você trabalha com um gráfico existente em vez de criar um, inspecione primeiro as linhas de categoria e armazene referências nomeadas aos pontos de dados e níveis que pretende formatar.

## **Comportamento e Considerações Práticas**

### **Diferenças entre Treemap e Sunburst**

- Um Treemap usa área para comunicar o valor e retângulos aninhados para comunicar a hierarquia. A propriedade [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartseries/parent_label_layout/) controla como os rótulos dos pais aparecem neste tipo de gráfico.
- Um Sunburst usa ângulo para comunicar o valor e a profundidade do anel para comunicar a hierarquia. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartseries/parent_label_layout/) não controla os rótulos dos anéis.
- Ambos os tipos de gráfico utilizam os mesmos níveis de agrupamento de categoria e a mesma ordem folha‑para‑pai em `data_point_levels`, de modo que o código de construção de dados e de formatação de níveis pode ser compartilhado.
- Os valores dos pais são calculados a partir de suas folhas descendentes. Não adicione pontos numéricos separados para ramos ou segmentos.

### **Ordenação e Ordem dos Segmentos**

O mecanismo de layout do gráfico determina o posicionamento final dos retângulos e dos segmentos de anel. Agrupe linhas de categoria relacionadas antes de adicioná‑las, mas não dependa de uma posição específica de retângulo ou ângulo inicial. Se a sequência possuir significado, inclua‑a nos rótulos ou use um tipo de gráfico com eixo de categoria explícito.

### **Tema e Cores Fixas**

Níveis de gráfico não formatados herdam cores do tema da apresentação. O exemplo usa preenchimentos RGB explícitos para saída previsível. Se o gráfico deve seguir alterações de tema, use cores de esquema em vez de valores RGB fixos e evite sobrescrever todos os níveis. Também verifique o contraste do rótulo após alterar o preenchimento de um ramo ou segmento.

### **Rótulos e Espaço Disponível**

O PowerPoint pode ocultar ou truncar rótulos quando um segmento é muito pequeno. Aumentar o tamanho do gráfico, encurtar nomes de categoria ou mostrar menos campos de rótulo geralmente produz um resultado mais claro. Um rótulo pode combinar nome da categoria, nome da série e valor através de [DataLabelFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabelformat/), mas habilitar todos os campos costuma dificultar a leitura de gráficos hierárquicos.

### **Exportação e Renderização**

Salvar como PPTX mantém o gráfico editável. Quando Aspose.Slides renderiza a apresentação para PDF ou imagem, os preenchimentos e configurações de rótulo suportados são renderizados com o gráfico. Substituição de fontes e pequenas diferenças no espaço de layout disponível podem alterar quebras de linha ou visibilidade de rótulos, portanto instale as fontes necessárias e verifique os destinos de exportação importantes.

## **Perguntas Frequentes**

**Por que alterar um nível pai afeta várias folhas?**

Um ramo ou segmento é um elemento visual compartilhado. Seu [ChartDataPointLevel](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapointlevel/) pode ser acessado por meio de uma folha descendente, mas a formatação pertence ao segmento pai compartilhado, não apenas àquela folha.

**Por que um rótulo de dados está ausente?**

Primeiro habilite os campos necessários no objeto [DataLabelFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabelformat/) do rótulo. Em seguida, verifique se o segmento tem espaço suficiente. O layout de rótulo pai do Treemap, as dimensões do gráfico, o comprimento do rótulo, o tamanho da fonte e o número de campos habilitados influenciam se o rótulo pode ser exibido.

**Posso definir a ordem exata ou as coordenadas dos segmentos?**

Você pode controlar a ordem das linhas de origem e manter cada grupo contíguo, mas não pode atribuir retângulos Treemap exatos nem ângulos Sunburst precisos. O mecanismo de layout do gráfico os calcula a partir da hierarquia, dos valores e do espaço disponível.

**Por que as cores mudam após a mudança do tema da apresentação?**

Preenchimentos baseados em tema são projetados para seguir a paleta da apresentação. Aplique cores RGB explícitas aos níveis que devem permanecer fixos, ou mantenha cores de esquema quando a adaptação a um novo tema for preferida.

**A formatação personalizada será preservada em exportações PDF e de imagem?**

Sim, os preenchimentos de gráfico e as configurações de rótulo suportados são incluídos durante a renderização. Para resultados consistentes entre sistemas, disponibilize as fontes necessárias e teste o tamanho final da exportação, pois o ajuste de rótulos depende do layout.

## **Veja Também**

- [Criar gráficos Treemap](/slides/pt/python-net/create-chart/#create-tree-map-charts)
- [Criar gráficos Sunburst](/slides/pt/python-net/create-chart/#create-sunburst-charts)
- [Exportar gráficos de apresentação](/slides/pt/python-net/export-chart/)
- [Gerenciar temas de apresentação](/slides/pt/python-net/presentation-theme/)