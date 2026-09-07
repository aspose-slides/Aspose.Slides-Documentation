---
title: SmartArt
type: docs
weight: 140
url: /pt/python-java/examples/elements/smart-art/
keywords:
- exemplo de código
- SmartArt
- adicionar SmartArt
- acessar SmartArt
- remover SmartArt
- layout do SmartArt
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Trabalhe com SmartArt no Aspose.Slides para Python via Java: adicione, acesse, remova e altere layouts de diagramas em apresentações PowerPoint e OpenDocument."
---
Este artigo demonstra como adicionar gráficos SmartArt, acessá‑los, removê‑los e alterar layouts usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, e então importa a API após a JVM estar em execução.

## **Adicionar SmartArt**

Insira um gráfico SmartArt usando um dos layouts incorporados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **Acessar SmartArt**

Recupere o primeiro objeto SmartArt em um slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **Remover SmartArt**

Exclua uma forma SmartArt do slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Alterar layout do SmartArt**

Atualize o tipo de layout de um gráfico SmartArt existente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```