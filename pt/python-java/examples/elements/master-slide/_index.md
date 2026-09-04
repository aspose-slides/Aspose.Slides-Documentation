---
title: Slide Mestre
type: docs
weight: 30
url: /pt/python-java/examples/elements/master-slide/
keywords:
- exemplo de código
- slide mestre
- adicionar slide mestre
- acessar slide mestre
- remover slide mestre
- slide mestre não usado
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Gerencie slides mestre com Aspose.Slides for Python via Java: crie, acesse, remova e limpe mestres em apresentações PowerPoint e OpenDocument."
---
Os slides mestre formam o nível superior da hierarquia de herança de slides no PowerPoint. Um **slide mestre** define elementos de design comuns, como planos de fundo, logotipos e formatação de texto. **Slides de layout** herdam dos slides mestre, e **slides normais** herdam dos slides de layout.

Este artigo demonstra como criar, modificar e gerenciar slides mestre usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM e, em seguida, importa a API após a JVM estar em execução.

## **Adicionar um Slide Mestre**

Este exemplo mostra como criar um novo slide mestre clonando o padrão. Em seguida, adiciona uma faixa com o nome da empresa a todos os slides por meio da herança de layout.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Clone o slide mestre padrão.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Adicione uma faixa com o nome da empresa no topo do slide mestre.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Atribua o novo slide mestre a um slide de layout.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Atribua o slide de layout ao primeiro slide da apresentação.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Slides mestre oferecem uma maneira de aplicar branding consistente ou elementos de design compartilhados em todos os slides. Alterações feitas em um mestre são refletidas automaticamente nos slides de layout e nos slides normais dependentes.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Formas e formatações adicionadas a um slide mestre são herdadas pelos slides de layout e, por sua vez, por todos os slides normais que utilizam esses layouts. A imagem abaixo ilustra como uma caixa de texto adicionada a um slide mestre é renderizada automaticamente no slide final.
{{% /alert %}}

![Exemplo de Herança de Mestre](master-slide-banner.png)

## **Acessar um Slide Mestre**

Você pode acessar slides mestre através da coleção de mestres da apresentação. Este exemplo recupera o primeiro slide mestre e altera seu tipo de plano de fundo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Remover um Slide Mestre**

Um slide mestre pode ser removido por índice ou por referência depois de não ser mais usado. Este exemplo atribui um slide mestre clonado à apresentação e então remove o mestre original por índice.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Remova o slide mestre original não utilizado por índice.
    presentation.getMasters().removeAt(0)

    # Alternativamente, remova um slide mestre não utilizado por referência:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Remover Slides Mestres Não Utilizados**

Algumas apresentações contêm slides mestre que não estão em uso. Remover esses slides pode ajudar a reduzir o tamanho do arquivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Remova todos os slides mestre não utilizados, incluindo aqueles marcados como Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```