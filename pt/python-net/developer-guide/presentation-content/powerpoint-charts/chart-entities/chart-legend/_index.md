---
title: Personalizar Legendas de Gráficos em Apresentações com Python
linktitle: Legenda do Gráfico
type: docs
url: /pt/python-net/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides para Python via .NET para otimizar apresentações PowerPoint e OpenDocument com formatação de legenda sob medida."
---
## **Visão geral**

Aspose.Slides for Python fornece controle total sobre legendas de gráficos, permitindo que você torne os rótulos de dados claros e prontos para apresentação. Você pode mostrar ou ocultar a legenda, escolher sua posição no slide e ajustar o layout para evitar sobreposição com a área de plotagem. A API permite estilizar texto e marcadores, refinar o preenchimento e o plano de fundo, e formatar bordas e preenchimentos para combinar com o seu tema. Os desenvolvedores também podem acessar legendas individuais para renomear ou filtrar, garantindo que apenas as séries mais relevantes sejam exibidas. Com esses recursos, seus gráficos permanecem legíveis, consistentes e alinhados com os padrões de design da apresentação.

## **Posicionamento da Legenda**

Usando Aspose.Slides, você pode controlar rapidamente onde a legenda do gráfico aparece e como ela se ajusta ao layout do slide. Aprenda a posicionar a legenda com precisão.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide.
1. Adicione um gráfico ao slide.
1. Defina as propriedades da legenda.
1. Salve a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos a posição e o tamanho da legenda do gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:

    # Obtenha uma referência ao slide.
    slide = presentation.slides[0]

    # Adicione um gráfico de colunas agrupadas ao slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Defina as propriedades da legenda.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Salve a apresentação no disco.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir o Tamanho da Fonte da Legenda**

A legenda de um gráfico deve ser tão legível quanto os dados que explica. Esta seção mostra como ajustar o tamanho da fonte da legenda para combinar com a tipografia da sua apresentação e melhorar a acessibilidade.

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Crie um gráfico.
1. Defina o tamanho da fonte.
1. Salve a apresentação no disco.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir o Tamanho da Fonte para uma Entrada de Legenda**

Aspose.Slides permite aprimorar a aparência das legendas de gráficos formatando entradas individuais. O exemplo abaixo mostra como focalizar um item específico da legenda e definir suas propriedades sem alterar o restante da legenda.

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Crie um gráfico.
1. Acesse uma entrada de legenda.
1. Defina as propriedades da entrada.
1. Salve a apresentação no disco.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Posso ativar a legenda para que o gráfico aloque espaço automaticamente em vez de sobrepor a área de plotagem?**

Sim. Use o modo sem sobreposição ([overlay](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/legend/overlay/) = `false`); neste caso, a área de plotagem será reduzida para acomodar a legenda.

**Posso criar rótulos de legenda com várias linhas?**

Sim. Rótulos longos quebram automaticamente quando o espaço é insuficiente; quebras de linha forçadas são suportadas por meio de caracteres de nova linha no nome da série.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Não defina cores/preenchimentos/fontes explícitos para a legenda ou seu texto. Eles herdarão do tema e serão atualizados corretamente quando o design mudar.