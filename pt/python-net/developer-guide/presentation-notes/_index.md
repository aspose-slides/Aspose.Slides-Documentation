---
title: Gerenciar notas de apresentação em Python
linktitle: Notas de apresentação
type: docs
weight: 110
url: /pt/python-net/presentation-notes/
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
- Aspose.Slides
description: "Personalize notas de apresentação com Aspose.Slides para Python via .NET. Trabalhe de forma fluida com notas do PowerPoint e OpenDocument para aumentar sua produtividade."
---
## **Visão geral**

Aspose.Slides oferece suporte à remoção de slides de notas de uma apresentação. Neste tópico, apresentaremos esse recurso, incluindo como remover notas e como aplicar um estilo aos slides de notas em uma apresentação. Aspose.Slides permite remover notas de qualquer slide e também aplicar estilo às notas existentes. Os desenvolvedores podem remover notas das seguintes maneiras:

- Remover notas de um slide específico em uma apresentação.
- Remover notas de todos os slides em uma apresentação.

Para ler ou alterar as dimensões da página de notas, mudar a orientação e verificar o comportamento de exportação, veja [Notes Page Size](/slides/pt/python-net/notes-size/).

## **Remover notas de um slide**
As notas de um slide específico podem ser removidas conforme mostrado no exemplo abaixo:

```py
import aspose.slides as slides

# Instanciar um objeto Presentation que representa um arquivo de apresentação 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Removendo notas do primeiro slide
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # salvar apresentação no disco
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover notas de todos os slides**
As notas de todos os slides em uma apresentação podem ser removidas conforme mostrado no exemplo abaixo:

```py
import aspose.slides as slides

# Instanciar um objeto Presentation que representa um arquivo de apresentação 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Removendo notas de todos os slides
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # salvar apresentação no disco
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aplicar um estilo de notas**
A propriedade [notes_style](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslide/notes_style/) foi adicionada à classe [MasterNotesSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslide/). Essa propriedade especifica o estilo do texto das notas. A implementação é demonstrada no exemplo abaixo.

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa o arquivo de apresentação
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Obter o estilo de texto do MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Definir marcadores de símbolo para os parágrafos de primeiro nível
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # salvar o arquivo PPTX no disco
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Qual entidade da API fornece acesso às notas de um slide específico?**

As notas são acessadas através do gerenciador de notas do slide: o slide possui um [NotesSlideManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/notesslidemanager/) e uma [property](https://reference.aspose.com/slides/pt/python-net/aspose.slides/notesslidemanager/notes_slide/) que devolve o objeto de notas, ou `None` se não houver notas.

**Existem diferenças no suporte a notas entre as versões do PowerPoint com as quais a biblioteca funciona?**

A biblioteca tem como alvo uma ampla variedade de formatos do Microsoft PowerPoint (97‑mais recentes) e ODP; as notas são suportadas nesses formatos sem depender de uma cópia instalada do PowerPoint.