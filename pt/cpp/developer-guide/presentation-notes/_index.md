---
title: Gerenciar notas de apresentação em C++
linktitle: Notas de apresentação
type: docs
weight: 110
url: /pt/cpp/presentation-notes/
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
- C++
- Aspose.Slides
description: "Personalize as notas da apresentação com Aspose.Slides para C++. Trabalhe perfeitamente com notas do PowerPoint e OpenDocument para aumentar sua produtividade."
---
## **Visão geral**

Aspose.Slides oferece suporte à remoção de notas de slides de uma apresentação. Neste tópico, apresentaremos esse recurso, incluindo como remover notas e como aplicar um estilo às notas de slides em uma apresentação. Aspose.Slides permite remover notas de qualquer slide e também aplicar estilos às notas existentes. Os desenvolvedores podem remover notas das seguintes maneiras:

- Remover notas de um slide específico em uma apresentação.
- Remover notas de todos os slides de uma apresentação.

## **Remover notas de um slide específico**
As notas de um slide específico podem ser removidas conforme o exemplo abaixo:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Remover notas de todos os slides**
As notas de todos os slides de uma apresentação podem ser removidas conforme o exemplo abaixo:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Adicionar um estilo de notas**
A propriedade **NotesStyle** foi adicionada à interface **IMasterNotesSlide** e à classe **MasterNotesSlide**, respectivamente. Essa propriedade especifica o estilo do texto das notas. A implementação é demonstrada no exemplo abaixo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**Qual entidade da API fornece acesso às notas de um slide específico?**

As notas são acessadas por meio do gerenciador de notas do slide: o slide possui um [NotesSlideManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/notesslidemanager/) e um [método](https://reference.aspose.com/slides/pt/cpp/aspose.slides/notesslidemanager/get_notesslide/) que retorna o objeto de notas, ou `null` se não houver notas.

**Existem diferenças no suporte a notas entre as versões do PowerPoint com as quais a biblioteca funciona?**

A biblioteca tem como alvo uma ampla gama de formatos do Microsoft PowerPoint (97 ou posterior) e ODP; as notas são suportadas nesses formatos sem depender de uma cópia instalada do PowerPoint.