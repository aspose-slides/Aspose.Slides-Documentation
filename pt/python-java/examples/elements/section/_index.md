---
title: Seção
type: docs
weight: 90
url: /pt/python-java/examples/elements/section/
keywords:
- exemplo de código
- seção
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Gerencie seções de apresentação no Aspose.Slides para Python via Java: adicione, acesse, remova e renomeie seções com exemplos de código em Python."
---
Exemplos de gerenciamento de seções de apresentação—adicionar, acessar, remover e renomear programaticamente usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM e, em seguida, importa a API após a JVM estar em execução.

## **Adicionar uma Seção**

Crie uma seção que comece em um slide específico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Especifique o slide que marca o início da seção.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Acessar uma Seção**

Leia as informações da seção de uma apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Acesse uma seção por índice.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Remover uma Seção**

Exclua uma seção adicionada anteriormente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Remova a primeira seção.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Renomear uma Seção**

Altere o nome de uma seção existente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```