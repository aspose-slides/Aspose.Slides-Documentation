---
title: Obter limites de parágrafos de apresentações em Python
linktitle: Parágrafo
type: docs
weight: 60
url: /pt/python-net/paragraph/
keywords:
- limites de parágrafo
- limites de trecho de texto
- coordenada de parágrafo
- coordenada de trecho
- tamanho do parágrafo
- tamanho do trecho de texto
- quadro de texto
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafos e trechos de texto no Aspose.Slides for Python via .NET para otimizar o posicionamento de texto em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos e trechos de texto no Aspose.Slides. Ele mostra como recuperar o retângulo de um parágrafo em um `TextFrame` usando `get_rect()`, como obter as coordenadas de parágrafo e trecho dentro de um quadro de texto de célula de tabela, e destaca detalhes importantes, como unidades de medida, o efeito da quebra de linha nos limites, a conversão para pixels e os valores de formatação efetiva de parágrafo.

## **Obter coordenadas de parágrafo e trecho no TextFrame**
Usando Aspose.Slides for Python via .NET, os desenvolvedores agora podem obter as coordenadas retangulares de Paragraph dentro da coleção de parágrafos do TextFrame. Também permite obter as coordenadas do trecho dentro da coleção de trechos de um parágrafo. Neste tópico, vamos demonstrar, com a ajuda de um exemplo, como obter as coordenadas retangulares do parágrafo junto com a posição do trecho dentro de um parágrafo.

## **Obter coordenadas retangulares do parágrafo**
O novo método **GetRect()** foi adicionado. Ele permite obter o retângulo dos limites do parágrafo.

```py
import aspose.slides as slides

# Instanciar um objeto Presentation que representa um arquivo de apresentação
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Obter tamanho do parágrafo e trecho dentro do quadro de texto de célula de tabela** ##

Para obter o tamanho e as coordenadas do [Trecho](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) ou do [Parágrafo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) em um quadro de texto de célula de tabela, você pode usar os métodos [IPortion.GetRect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iportion/) e [IParagraph.GetRect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iparagraph/).

Este código de exemplo demonstra a operação descrita:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **Perguntas frequentes**

**Em quais unidades as coordenadas retornadas para um parágrafo e trechos de texto são medidas?**

Em pontos, onde 1 polegada = 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se a [quebra de linha](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/wrap_text/) estiver habilitada no [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/), o texto será dividido para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando: pixels = points × (DPI / 72). O resultado depende do DPI escolhido para renderização/exportação.

**Como obtenho os parâmetros de formatação "efetiva" do parágrafo, levando em conta a herança de estilos?**

Use a [estrutura de dados de formatação efetiva de parágrafo](/slides/pt/python-net/shape-effective-properties/); ela devolve os valores consolidados finais para recuos, espaçamento, quebra de linha, RTL e mais.