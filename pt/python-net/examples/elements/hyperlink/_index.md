---
title: Hipervínculo
type: docs
weight: 130
url: /pt/python-net/examples/elements/hyperlink/
keywords:
- hipervínculo
- adicionar hipervínculo
- acessar hipervínculo
- remover hipervínculo
- atualizar hipervínculo
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Adicionar, editar e remover hipervínculos em Python com Aspose.Slides: texto de link, formas, slides, URLs e e‑mail; definir destinos e ações para PPT, PPTX e ODP."
---
Demonstrar a adição, o acesso, a remoção e a atualização de hyperlinks em formas usando **Aspose.Slides for Python via .NET**.

## **Adicionar um Hyperlink**

Crie uma forma retangular com um hyperlink apontando para um site externo.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar um Hyperlink**

Leia as informações do hyperlink a partir da parte de texto de uma forma.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Remover um Hyperlink**

Remova o hyperlink do texto de uma forma.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Atualizar um Hyperlink**

Altere o destino de um hyperlink existente. Use `HyperlinkManager` para modificar o texto que já contém um hyperlink, o que imita como o PowerPoint atualiza hyperlinks de forma segura.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Alterar um hyperlink dentro de texto existente deve ser feito via
        # HyperlinkManager ao invés de definir a propriedade diretamente.
        # Isso imita como o PowerPoint atualiza hyperlinks de forma segura.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```