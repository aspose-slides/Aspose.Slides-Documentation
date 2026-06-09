---
title: Conector
type: docs
weight: 190
url: /pt/python-net/examples/elements/connector/
keywords:
- conector
- adicionar conector
- acessar conector
- remover conector
- reconectar formas
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Desenhe e controle conectores em Python com Aspose.Slides: adicione, roteie, redirecione, defina pontos de conexão, setas e estilos para vincular formas em PPT, PPTX e ODP."
---
Mostra como conectar formas com conectores e alterar seus destinos usando **Aspose.Slides for Python via .NET**.

## **Adicionar um Conector**

Insira uma forma de conector entre dois pontos no slide.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Adicionar uma forma de conector dobrado.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar um Conector**

Recupere a primeira forma de conector adicionada a um slide.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Acessar o primeiro conector no slide.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Remover um Conector**

Exclua um conector do slide.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Assumindo que a primeira forma é um conector.
        connector = slide.shapes[0]

        # Remover o conector.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Reconectar Formas**

Anexe um conector a duas formas atribuindo alvos de início e fim.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Adicionar a primeira forma retangular.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Adicionar a segunda forma retangular.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Adicionar uma forma de conector dobrado.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Conectar o início do conector à primeira forma.
        connector.start_shape_connected_to = shape1
        # Conectar o final do conector à segunda forma.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```