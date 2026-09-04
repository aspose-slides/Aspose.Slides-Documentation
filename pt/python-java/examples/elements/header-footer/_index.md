---
title: Cabeçalho e Rodapé
type: docs
weight: 220
url: /pt/python-java/examples/elements/header-footer/
keywords:
- exemplo de código
- cabeçalho
- rodapé
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Controle cabeçalhos e rodapés de slides com Aspose.Slides for Python via Java: adicione datas, números de slide e texto personalizado em apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como adicionar rodapés e atualizar marcadores de data e hora usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM e, em seguida, importa a API após a JVM estar em execução.

## **Adicionar um Rodapé**

Adicione texto à área de rodapé de um slide e torne-o visível.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Atualizar Data e Hora**

Modifique o marcador de data e hora em um slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```