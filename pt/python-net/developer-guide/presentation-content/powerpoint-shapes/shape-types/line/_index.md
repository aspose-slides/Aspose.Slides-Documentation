---
title: Criar formas de linha em apresentações com Python
linktitle: Linha
type: docs
weight: 50
url: /pt/python-net/line/
keywords:
- linha
- criar linha
- adicionar linha
- linha simples
- configurar linha
- personalizar linha
- estilo de traçado
- ponta de seta
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a manipular a formatação de linhas em apresentações PowerPoint e OpenDocument com Aspose.Slides for Python via .NET. Descubra propriedades, métodos e exemplos."
---
## **Visão geral**

Aspose.Slides for Python via .NET oferece suporte à adição de diferentes tipos de formas aos slides. Neste tópico, começaremos a trabalhar com formas adicionando linhas aos slides. Usando Aspose.Slides, os desenvolvedores podem não apenas criar linhas simples, mas também desenhar linhas mais elaboradas nos slides.

## **Criar linhas simples**

Use o Aspose.Slides para adicionar uma linha simples a um slide como um separador ou conector simples. Para adicionar uma linha simples a um slide selecionado em uma apresentação, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide por índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) do tipo `LINE` usando o método `add_auto_shape` no objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/).
4. Salve a apresentação como um arquivo PPTX.

No exemplo abaixo, uma linha é adicionada ao primeiro slide da apresentação.

```py
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma auto shape do tipo LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Criar linhas em forma de seta**

O Aspose.Slides permite que você configure propriedades da linha para torná‑las mais visualmente atraentes. Abaixo, configuramos algumas propriedades de uma linha para que ela se pareça com uma seta. Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide por índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) do tipo `LINE` usando o método `add_auto_shape` no objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/).
4. Defina o [estilo de linha](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linestyle/).
5. Defina a largura da linha.
6. Defina o [estilo de traçado](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linedashstyle/).
7. Defina o [estilo de ponta de seta](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linearrowheadstyle/) e o comprimento para o ponto inicial da linha.
8. Defina o estilo de ponta de seta e o comprimento para o ponto final da linha.
9. Salve a apresentação como um arquivo PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa o arquivo PPTX.
with slides.Presentation() as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma auto shape do tipo LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Aplicar formatação à linha.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Posso converter uma linha regular em um conector para que ela "encaixe" nas formas?**

Não. Uma linha regular (um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) do tipo [LINE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapetype/)) não se torna automaticamente um conector. Para fazê‑la encaixar nas formas, use o tipo [Connector](https://reference.aspose.com/slides/pt/python-net/aspose.slides/connector/) dedicado e as [APIs correspondentes](/slides/pt/python-net/connector/) para conexões.

**O que devo fazer se as propriedades de uma linha são herdadas do tema e é difícil determinar os valores finais?**

Leia as [propriedades efetivas](/slides/pt/python-net/shape-effective-properties/) através das classes [ILineFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ilinefillformateffectivedata/), que já consideram herança e estilos do tema.

**Posso bloquear uma linha contra edição (movimento, redimensionamento)?**

Sim. As formas fornecem [objetos de bloqueio](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/auto_shape_lock/) que permitem [impedir operações de edição](/slides/pt/python-net/applying-protection-to-presentation/).