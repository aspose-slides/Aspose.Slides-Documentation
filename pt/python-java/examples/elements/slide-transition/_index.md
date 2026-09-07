---
title: Transição de Slide
type: docs
weight: 110
url: /pt/python-java/examples/elements/slide-transition/
keywords:
- exemplo de código
- transição de slide
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aplicar e remover transições de slide e definir temporizações de avanço automático de slides com exemplos de código Aspose.Slides para Python via Java para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como aplicar efeitos de transição de slides e temporizações com **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, e então importa a API após a JVM estar em execução.

## **Adicionar uma Transição de Slide**
Aplique um efeito de transição de fade ao primeiro slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aplicar uma transição de fade.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Acessar uma Transição de Slide**
Leia o tipo de transição atualmente atribuído a um slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Acessar o tipo de transição.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Remover uma Transição de Slide**
Remova qualquer efeito de transição. JPype expõe a constante Java chamada `None` como `None_` porque `None` é uma palavra reservada no Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Remover o efeito de transição.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Definir Duração da Transição**
Especifique por quanto tempo o slide é exibido antes de avançar automaticamente. Este exemplo avança após dois segundos e também permite avançar com um clique do mouse. Essa temporização controla o avanço do slide, não a velocidade do efeito de transição.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # Em milissegundos.
finally:
    presentation.dispose()
```