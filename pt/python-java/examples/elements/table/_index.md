---
title: Tabela
type: docs
weight: 120
url: /pt/python-java/examples/elements/table/
keywords:
- exemplo de código
- tabela
- adicionar tabela
- acessar tabela
- remover tabela
- mesclar células
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Trabalhe com tabelas no Aspose.Slides para Python via Java: adicione, acesse, remova e mescle células em apresentações PowerPoint e OpenDocument."
---
Exemplos de como adicionar tabelas, acessá‑las, removê‑las e mesclar células usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, e depois importa a API quando a JVM está em execução.

## **Adicionar uma Tabela**

Crie uma tabela simples com duas linhas e duas colunas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **Acessar uma Tabela**

Recupere a primeira forma de tabela no slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Acesse a primeira tabela no slide.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **Remover uma Tabela**

Exclua uma tabela de um slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **Mesclar Células da Tabela**

Mescle células adjacentes de uma tabela em uma única célula.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Mesclar células.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```