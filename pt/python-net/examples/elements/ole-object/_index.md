---
title: ObjetoOLE
type: docs
weight: 210
url: /pt/python-net/examples/elements/ole-object/
keywords:
- objeto OLE
- adicionar objeto OLE
- acessar objeto OLE
- remover objeto OLE
- atualizar objeto OLE
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Trabalhe com objetos OLE em Python usando Aspose.Slides: insira ou atualize arquivos incorporados, defina ícones ou links, extraia conteúdo, controle o comportamento para PPT, PPTX e ODP."
---
Demonstrar a incorporação de um arquivo como um objeto OLE e a atualização de seus dados usando **Aspose.Slides for Python via .NET**.

## **Adicionar um Objeto OLE**

Incorporar um arquivo PDF na apresentação.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Carregar dados PDF para incorporar.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Adicionar um quadro de objeto OLE ao slide.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar um Objeto OLE**

Recuperar o primeiro quadro de objeto OLE em um slide.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Obter o primeiro quadro de objeto OLE no slide.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Remover um Objeto OLE**

Excluir um objeto OLE incorporado do slide.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Pressupondo que a primeira forma seja um objeto OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Atualizar Dados do Objeto OLE**

Substituir os dados incorporados em um objeto OLE existente.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Pressupondo que a primeira forma seja um objeto OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Atualizar o objeto OLE com os novos dados incorporados.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```