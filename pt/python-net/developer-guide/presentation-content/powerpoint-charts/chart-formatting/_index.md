---
title: Formatar Gráficos em Apresentações com Python
linktitle: Formatação de Gráficos
type: docs
weight: 60
url: /pt/python-net/chart-formatting/
keywords:
- formatar gráfico
- formatação de gráfico
- entidade de gráfico
- propriedades de gráfico
- configurações de gráfico
- opções de gráfico
- propriedades de fonte
- borda arredondada
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a formatar gráficos no Aspose.Slides para Python via .NET e eleve sua apresentação PowerPoint ou OpenDocument com um estilo profissional e atraente."
---
## **Visão geral**

Este artigo explica como formatar gráficos em apresentações do PowerPoint usando o Aspose.Slides. Ele mostra como personalizar elementos principais do gráfico, como eixos, linhas de grade, títulos, legendas, a área de plotagem e os preenchimentos de parede, para melhorar a aparência e a legibilidade dos dados do gráfico.

Também demonstra como definir propriedades de fonte para o texto do gráfico, aplicar formatos numéricos pré-definidos e personalizados aos dados do gráfico e habilitar cantos arredondados para a área do gráfico. Juntos, esses exemplos mostram como controlar tanto o estilo visual quanto a apresentação dos dados dos gráficos em uma apresentação.

## **Formatar Elementos do Gráfico**

Aspose.Slides for Python permite que os desenvolvedores adicionem gráficos personalizados aos seus slides do zero. Esta seção explica como formatar vários elementos do gráfico, incluindo os eixos de categoria e de valores.

Aspose.Slides fornece uma API simples para gerenciar elementos de gráficos e aplicar formatação personalizada:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo seu índice.
1. Adicione um gráfico com dados padrão do tipo desejado (neste exemplo, `ChartType.LINE_WITH_MARKERS`).
1. Acesse o eixo de valores do gráfico e defina o seguinte:
   1. Defina o **formato de linha** para as linhas de grade principais do eixo de valores.
   1. Defina o **formato de linha** para as linhas de grade secundárias do eixo de valores.
   1. Defina o **formato numérico** para o eixo de valores.
   1. Defina as **unidades mín, máx, principais e secundárias** para o eixo de valores.
   1. Defina as **propriedades de texto** para os rótulos do eixo de valores.
   1. Defina o **título** para o eixo de valores.
   1. Defina o **formato de linha** para o eixo de valores.
1. Acesse o eixo de categoria do gráfico e defina o seguinte:
   1. Defina o **formato de linha** para as linhas de grade principais do eixo de categoria.
   1. Defina o **formato de linha** para as linhas de grade secundárias do eixo de categoria.
   1. Defina as **propriedades de texto** para os rótulos do eixo de categoria.
   1. Defina o **título** para o eixo de categoria.
   1. Defina o **posicionamento dos rótulos** para o eixo de categoria.
   1. Defina o **ângulo de rotação** para os rótulos do eixo de categoria.
1. Acesse a legenda do gráfico e defina suas **propriedades de texto**.
1. Exiba a legenda do gráfico sem sobrepor o gráfico.
1. Acesse o **eixo de valores secundário** do gráfico e defina o seguinte:
   1. Habilite o **eixo de valores** secundário.
   1. Defina o **formato de linha** para o eixo de valores secundário.
   1. Defina o **formato numérico** para o eixo de valores secundário.
   1. Defina as **unidades mín, máx, principais e secundárias** para o eixo de valores secundário.
1. Plote a primeira série do gráfico no eixo de valores secundário.
1. Defina a cor de preenchimento da parede traseira do gráfico.
1. Defina a cor de preenchimento da área de plotagem do gráfico.
1. Grave a apresentação modificada em um arquivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:

    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar um gráfico de exemplo.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Definir o título do gráfico.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Definir o formato da linha de grade principal para o eixo de valores.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Definir o formato da linha de grade secundária para o eixo de valores.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Definir o formato numérico do eixo de valores.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Definir o máximo, mínimo, unidade principal e unidade secundária do eixo de valores.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Definir propriedades de texto do eixo de valores.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Definir o título do eixo de valores.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Definir o formato da linha de grade principal para o eixo de categoria.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Definir o formato da linha de grade secundária para o eixo de categoria.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Definir propriedades de texto do eixo de categoria.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Definir o título do eixo de categoria.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Definir a posição do rótulo do eixo de categoria.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Definir o ângulo de rotação do rótulo do eixo de categoria.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Definir propriedades de texto da legenda.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Exibir a legenda do gráfico sobrepondo o gráfico.
    chart.legend.overlay = True
                
    # Definir a cor da parede traseira do gráfico.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Definir a cor da área de plotagem.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Salvar a apresentação.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Propriedades de Fonte do Gráfico**

Aspose.Slides for Python suporta a definição de propriedades relacionadas a fonte para gráficos. Siga os passos abaixo para configurar as propriedades de fonte do gráfico:

1. Instancie um objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Adicione um gráfico ao slide.
1. Defina a altura da fonte.
1. Salve a apresentação modificada.

Um código de exemplo é fornecido abaixo.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Formato Numérico**

Aspose.Slides for Python fornece uma API simples para gerenciar formatos de dados de gráficos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo seu índice.
1. Adicione um gráfico com dados padrão de qualquer tipo desejado.
1. Defina um formato numérico pré-definido a partir dos valores pré-definidos disponíveis.
1. Percorra as células de dados do gráfico em cada série e defina o formato numérico.
1. Salve a apresentação.
1. Defina um formato numérico personalizado.
1. Percorra as células de dados do gráfico em cada série e defina um formato numérico diferente.
1. Salve a apresentação.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar um gráfico de colunas agrupadas padrão.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Definir o formato numérico pré-definido.
    # Percorrer cada série do gráfico.
    for series in chart.chart_data.series:
        # Percorrer cada ponto de dados na série.
        for cell in series.data_points:
            # Definir o formato numérico.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Salvar a apresentação.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Os formatos numéricos pré-definidos disponíveis e seus índices correspondentes estão listados abaixo.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Definir Bordas Arredondadas para a Área do Gráfico**

Aspose.Slides for Python suporta a configuração da área do gráfico usando a propriedade `Chart.has_rounded_corners`.

1. Instancie um objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Adicione um gráfico ao slide.
3. Defina o tipo de preenchimento e a cor de preenchimento do gráfico.
4. Defina a propriedade rounded-corners como `True`.
5. Salve a apresentação modificada.

Um exemplo é fornecido abaixo.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso definir preenchimentos semitransparentes para colunas/áreas mantendo a borda opaca?**

Sim. A transparência do preenchimento e o contorno são configurados separadamente. Isso é útil para melhorar a legibilidade da grade e dos dados em visualizações densas.

**Como posso lidar com rótulos de dados quando eles se sobrepõem?**

Reduza o tamanho da fonte, desative componentes de rótulo não essenciais (por exemplo, categorias), defina o deslocamento/posição do rótulo, mostre rótulos apenas para pontos selecionados se necessário, ou altere o formato para "valor + legenda".

**Posso aplicar preenchimentos em gradiente ou padrão às séries?**

Sim. Tanto preenchimentos sólidos quanto em gradiente/padrão geralmente estão disponíveis. Na prática, use gradientes com moderação e evite combinações que reduzam o contraste com a grade e o texto.