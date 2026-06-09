---
title: Caixa de Texto
type: docs
weight: 40
url: /pt/python-net/examples/elements/text-box/
keywords:
- caixa de texto
- adicionar caixa de texto
- acessar caixa de texto
- remover caixa de texto
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Crie e formate caixas de texto em Python com Aspose.Slides: defina fontes, alinhamento, quebra de linha, ajuste automático e links para aprimorar slides para PowerPoint e OpenDocument."
---
No Aspose.Slides, uma **caixa de texto** é representada por um `AutoShape`. Quase qualquer forma pode conter texto, mas uma caixa de texto típica não tem preenchimento nem borda e exibe apenas texto.

Este guia explica como adicionar, acessar e remover caixas de texto programaticamente.

## **Adicionar uma Caixa de Texto**

Uma caixa de texto é simplesmente um `AutoShape` sem preenchimento nem borda e com algum texto formatado. Veja como criar uma:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Crie uma forma retangular (por padrão preenchida com borda e sem texto).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Remova o preenchimento e a borda para que pareça uma caixa de texto típica.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Defina a formatação do texto.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Atribua o conteúdo real do texto.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Observação:** Qualquer `AutoShape` que contenha um `TextFrame` não vazio pode funcionar como uma caixa de texto.

## **Acessar Caixas de Texto por Conteúdo**

Para encontrar todas as caixas de texto que contenham uma palavra-chave específica (por exemplo "Slide"), percorra as formas e verifique seu texto:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Apenas AutoShapes podem conter texto editável.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Faça algo com a caixa de texto correspondente.
                    pass
```

## **Remover Caixas de Texto por Conteúdo**

Este exemplo encontra e exclui todas as caixas de texto no primeiro slide que contenham uma palavra-chave específica:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Encontre as formas a remover que são AutoShapes contendo a palavra "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Remova cada forma correspondente do slide.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Dica:** Sempre crie uma cópia da coleção de formas antes de modificá-la durante a iteração para evitar erros de modificação da coleção.