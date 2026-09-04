---
title: Slide de Layout
type: docs
weight: 20
url: /pt/python-java/examples/elements/layout-slide/
keywords:
- exemplo de código
- slide de layout
- adicionar slide de layout
- acessar slide de layout
- remover slide de layout
- slide de layout não usado
- clonar slide de layout
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Gerencie slides de layout com Aspose.Slides para Python via Java: adicione, acesse, remova, limpe e clone layouts em apresentações PowerPoint e OpenDocument."
---
Este artigo demonstra como trabalhar com **layout slides** usando Aspose.Slides para Python via Java. Um layout slide define o design e a formatação herdados pelos slides normais. Você pode adicionar, acessar, clonar e remover layout slides, bem como limpar os que não são usados para reduzir o tamanho da apresentação.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, e depois importa a API após a JVM estar em execução.

## **Adicionar um Layout Slide**

Crie um layout slide personalizado para definir formatação reutilizável. O exemplo a seguir adiciona uma caixa de texto a um novo layout e, em seguida, cria dois slides que o utilizam.

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Crie um slide de layout com um tipo de layout em branco e um nome personalizado.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Adicione uma caixa de texto ao slide de layout.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Adicione dois slides que herdam o texto do layout.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Nota 1:** Layout slides funcionam como modelos para slides individuais. Você pode definir elementos comuns uma vez e reutilizá‑los em muitos slides.

> 💡 **Nota 2:** Ao adicionar formas ou texto a um layout slide, todos os slides baseados naquele layout exibem o conteúdo compartilhado automaticamente.

> A captura de tela abaixo mostra dois slides que herdam uma caixa de texto do mesmo layout slide.

![Slides Herdando Conteúdo de Layout](layout-slide-result.png)

## **Acessar um Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Acesse um slide de layout por índice.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Acesse um slide de layout por tipo.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Remover um Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Remover Layout Slides Não Utilizados**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Clonar um Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Resumo:** Layout slides ajudam a manter formatação consistente em toda a apresentação. Aspose.Slides permite que você crie, gerencie, reutilize e limpe layouts conforme necessário.