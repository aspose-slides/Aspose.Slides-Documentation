---
title: Animação
type: docs
weight: 100
url: /pt/python-java/examples/elements/animation/
keywords:
- exemplo de código
- animação
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Explore exemplos de animação do Aspose.Slides for Python via Java: adicione, acesse, remova e sequencie efeitos em apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como criar animações simples e gerenciar sua sequência usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, e então importa a API após a JVM estar em execução.

## **Adicionar uma Animação**
Crie uma forma retangular e aplique um efeito de desvanecimento acionado ao clicar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)

    # Aplicar um efeito de desvanecimento.
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```

## **Acessar uma Animação**
Recupere o primeiro efeito de animação da linha do tempo do slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # Acessar o primeiro efeito de animação.
    effect = slide.getTimeline().getMainSequence().get_Item(0)
    print("Effect type:", effect.getType())
finally:
    presentation.dispose()
```

## **Remover uma Animação**
Remova um efeito de animação da sequência.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # Remover o efeito.
    slide.getTimeline().getMainSequence().remove(effect)
finally:
    presentation.dispose()
```

## **Sequenciar Animações**
Adicione vários efeitos e controle a ordem em que as animações ocorrem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Ellipse, 200, 50, 100, 100)

    sequence = slide.getTimeline().getMainSequence()
    sequence.addEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
    sequence.addEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```