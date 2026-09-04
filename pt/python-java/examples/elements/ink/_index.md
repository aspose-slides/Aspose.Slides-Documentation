---
title: Tinta
type: docs
weight: 180
url: /pt/python-java/examples/elements/ink/
keywords:
- exemplo de código
- tinta
- acessar tinta
- remover tinta
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Acesse e remova formas de tinta em apresentações do Aspose.Slides for Python via Java, incluindo arquivos PPT, PPTX e ODP."
---
Este artigo fornece exemplos de acesso a formas de tinta existentes e sua remoção usando **Aspose.Slides for Python via Java**.

Instale o pacote como descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, e então importa a API após a JVM estar em execução.

{{% alert color="info" title="Note" %}}
As formas de tinta representam a entrada do usuário a partir de dispositivos especializados. Aspose.Slides não pode criar novos traços de tinta programaticamente, mas você pode ler e modificar a tinta existente.
{{% /alert %}}

## **Acessar tinta**

Leia as tags da primeira forma de tinta em um slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Use tag_name conforme necessário.
finally:
    presentation.dispose()
```

## **Remover tinta**

Exclua uma forma de tinta do slide se houver uma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```