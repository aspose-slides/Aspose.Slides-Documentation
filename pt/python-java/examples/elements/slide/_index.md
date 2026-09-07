---
title: Slide
type: docs
weight: 10
url: /pt/python-java/examples/elements/slide/
keywords:
- exemplo de código
- slide
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Gerencie slides no Aspose.Slides para Python via Java: adicione, acesse, clone, reorganize e remova slides com exemplos de código Python para apresentações PowerPoint e OpenDocument."
---
Este artigo fornece exemplos que demonstram como adicionar, acessar, clonar, reorganizar e remover slides usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Instalação](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, depois importa a API após a JVM estar em execução.

## **Adicionar um Slide**

Para adicionar um novo slide, primeiro selecione um layout. Este exemplo usa um layout em branco para adicionar um slide vazio à apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Cada layout de slide é derivado de um slide mestre, que define o design geral e a estrutura de marcadores de posição. A imagem abaixo ilustra como os slides mestres e seus layouts associados são organizados no PowerPoint.
{{% /alert %}}

![Relacionamento entre Mestre e Layout](master-layout-slide.png)

## **Acessar Slides por Índice**

Acesse slides usando seu índice baseado em zero, ou encontre o índice de um slide com base em uma referência. Isso é útil para iterar ou modificar slides específicos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Adicione outro slide vazio.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Acesse slides por índice.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Obtenha o índice de um slide a partir de uma referência e, em seguida, acesse-o por índice.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Clonar um Slide**

Clone um slide existente. O slide clonado é adicionado automaticamente ao final da coleção de slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Reordenar Slides**

Altere a ordem dos slides movendo um para um novo índice. Este exemplo move um slide clonado para a primeira posição.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Remover um Slide**

Remova um slide passando sua referência para a coleção de slides. Este exemplo adiciona um segundo slide e depois remove o original, permanecendo apenas o novo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```