---
title: Gerenciar notas de apresentação em Python via Java
linktitle: Notas de Apresentação
type: docs
weight: 110
url: /pt/python-java/presentation-notes/
keywords:
- notas
- slide de notas
- adicionar notas
- remover notas
- estilo de notas
- notas mestre
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Personalize as notas da apresentação com Aspose.Slides para Python via Java. Trabalhe de forma contínua com notas do PowerPoint e OpenDocument para aumentar sua produtividade."
---
## **Visão geral**

Aspose.Slides oferece suporte à remoção de notas de slides de uma apresentação. Este tópico apresenta esse recurso, incluindo como remover notas e como aplicar um estilo a notas de slides em uma apresentação. Aspose.Slides permite remover notas de qualquer slide e aplicar estilos às notas existentes. Os desenvolvedores podem remover notas das seguintes maneiras:

- Remover notas de um slide específico em uma apresentação.
- Remover notas de todos os slides em uma apresentação.

## **Remover notas de um slide**

Notas de um slide específico podem ser removidas conforme o exemplo abaixo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancie um objeto Presentation que representa um arquivo de apresentação.
presentation = Presentation("presWithNotes.pptx")
try:
    # Remova as notas do primeiro slide.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Salve a apresentação no disco.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remover notas de uma apresentação**

Notas de todos os slides em uma apresentação podem ser removidas conforme o exemplo abaixo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancie um objeto Presentation que representa um arquivo de apresentação.
presentation = Presentation("presWithNotes.pptx")
try:
    # Remova as notas de todos os slides.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Salve a apresentação no disco.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adicionar estilo de notas**

O método [getNotesStyle](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslide/#getNotesStyle) da classe [MasterNotesSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslide/) fornece acesso ao estilo do texto das notas. A implementação é demonstrada no exemplo abaixo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Instancie um objeto Presentation que representa um arquivo de apresentação.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Obtenha o estilo de texto do slide mestre de notas.
        notes_style = notes_master.getNotesStyle()

        # Defina marcadores de símbolo para parágrafos de primeiro nível.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Qual entidade da API fornece acesso às notas de um slide específico?**

As notas são acessadas através do gerenciador de notas do slide: o slide possui um [NotesSlideManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notesslidemanager/) e um método [getNotesSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notesslidemanager/#getNotesSlide) que retorna o objeto de notas, ou `None` se não houver notas.

**Existem diferenças no suporte a notas entre as versões do PowerPoint com as quais a biblioteca funciona?**

A biblioteca tem como alvo uma ampla gama de formatos do Microsoft PowerPoint (97 e posteriores) e ODP; as notas são suportadas nesses formatos sem depender de uma cópia instalada do PowerPoint.