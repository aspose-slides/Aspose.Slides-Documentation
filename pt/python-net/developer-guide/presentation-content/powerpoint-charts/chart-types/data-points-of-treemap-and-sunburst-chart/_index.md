---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst no Python
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico treemap
- gráfico sunburst
- ponto de dado
- cor do rótulo
- cor do ramo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Saiba como gerenciar pontos de dados em gráficos treemap e sunburst com Aspose.Slides para Python via .NET, compatível com os formatos PowerPoint e OpenDocument."
---
## **Introdução**

Entre os outros tipos de gráficos do PowerPoint, existem dois hierárquicos — **Treemap** e **Sunburst** (também conhecidos como Gráfico Sunburst, Diagrama Sunburst, Gráfico radial, Gráfico radial ou Gráfico de pizza multínível). Esses gráficos exibem dados hierárquicos organizados como uma árvore — das folhas até o topo de um ramo. As folhas são definidas pelos pontos de dados da série, e cada nível de agrupamento aninhado subsequente é definido pela categoria correspondente. Aspose.Slides for Python via .NET permite formatar pontos de dados de gráficos Sunburst e Treemap em Python.

Este é um gráfico Sunburst onde os dados na coluna Series1 definem os nós folha, enquanto as demais colunas definem pontos de dados hierárquicos:

![Exemplo de gráfico Sunburst](sunburst_example.png)

Vamos começar adicionando um novo gráfico Sunburst à apresentação:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Veja também" %}}
- [**Criar gráficos Sunburst**](/slides/pt/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Se precisar formatar pontos de dados do gráfico, use as APIs a seguir:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapointlevel/), e a propriedade [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Eles fornecem acesso à formatação de pontos de dados em gráficos Treemap e Sunburst. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) é usado para acessar categorias de vários níveis; ele representa um contêiner de objetos [ChartDataPointLevel](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapointlevel/). É essencialmente um wrapper ao redor de [ChartCategoryLevelsManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartcategorylevelsmanager/) com propriedades adicionais específicas para pontos de dados. O tipo [ChartDataPointLevel](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapointlevel/) expõe duas propriedades — [format](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapointlevel/format/) e [label](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdatapointlevel/label/) — que fornecem acesso às configurações correspondentes.

## **Exibir valores dos pontos de dados**

Esta seção mostra como exibir o valor de pontos de dados individuais em gráficos Treemap e Sunburst. Você verá como habilitar rótulos de valor para pontos selecionados.

Exiba o valor do ponto de dados "Leaf 4":

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Valor do ponto de dados](data_point_value.png)

## **Definir rótulos e cores para pontos de dados**

Esta seção mostra como definir rótulos e cores personalizados para pontos de dados individuais em gráficos Treemap e Sunburst. Você aprenderá a acessar um ponto de dados específico, atribuir um rótulo e aplicar um preenchimento sólido para destacar nós importantes.

Defina o rótulo de dados "Branch 1" para exibir o nome da série ("Series1") em vez do nome da categoria e, em seguida, defina a cor do texto para amarelo:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Rótulo e cor do ponto de dados](data_point_color.png)

## **Definir cores de ramos para pontos de dados**

Use cores de ramificação para controlar como nós pai e filho são agrupados visualmente em gráficos Treemap e Sunburst. Esta seção mostra como definir uma cor de ramificação personalizada para um ponto de dados específico, de modo a destacar subárvores importantes e melhorar a legibilidade do gráfico.

Mude a cor da ramificação "Stem 4":

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Cor da ramificação](branch_color.png)

## **Perguntas frequentes**

**Posso mudar a ordem (classificação) dos segmentos em Sunburst/Treemap?**

Não. O PowerPoint classifica os segmentos automaticamente (geralmente por valores decrescentes, no sentido horário). O Aspose.Slides reproduz esse comportamento: não é possível mudar a ordem diretamente; você deve fazê‑lo pré‑processando os dados.

**Como o tema da apresentação afeta as cores dos segmentos e rótulos?**

As cores dos gráficos herdam o [tema/paleta](/slides/pt/python-net/presentation-theme/) da apresentação, a menos que você defina preenchimentos/fontes explicitamente. Para resultados consistentes, fixe preenchimentos sólidos e formatação de texto nos níveis necessários.

**A exportação para PDF/PNG preservará as cores de ramificação personalizadas e as configurações de rótulo?**

Sim. Ao exportar a apresentação, as configurações do gráfico (preenchimentos, rótulos) são preservadas nos formatos de saída porque o Aspose.Slides renderiza com a formatação do gráfico aplicada.

**Posso calcular as coordenadas reais de um rótulo/elemento para posicionamento customizado de sobreposição sobre o gráfico?**

Sim. Depois que o layout do gráfico é validado, `actual_x`/`actual_y` estão disponíveis para os elementos (por exemplo, um [DataLabel](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabel/)), o que ajuda no posicionamento preciso de sobreposições.