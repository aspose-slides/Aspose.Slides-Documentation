---
title: Gerenciar notas de apresentação em .NET
linktitle: Notas da apresentação
type: docs
weight: 110
url: /pt/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Personalize as notas da apresentação com Aspose.Slides para .NET. Trabalhe perfeitamente com notas de PowerPoint e OpenDocument para aumentar sua produtividade."
---
## **Visão geral**

O Aspose.Slides oferece suporte à remoção de slides de notas de uma apresentação. Neste tópico, apresentaremos esse recurso, incluindo como remover notas e como aplicar um estilo aos slides de notas em uma apresentação. O Aspose.Slides permite remover notas de qualquer slide e também aplicar estilos às notas existentes. Os desenvolvedores podem remover notas das seguintes maneiras:

- Remover notas de um slide específico em uma apresentação.
- Remover notas de todos os slides em uma apresentação.

Para ler ou alterar as dimensões da página de notas, mudar a orientação e verificar o comportamento de exportação, veja [Tamanho da página de notas](/slides/pt/net/notes-size/).

## **Remover notas de um slide**

Notas de um slide específico podem ser removidas como mostrado no exemplo abaixo:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar um objeto Presentation que representa um arquivo de apresentação
Presentation presentation = new Presentation("AccessSlides.pptx");

// Removendo notas do primeiro slide
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Salvar a apresentação no disco
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Remover notas de todos os slides**

Notas de todos os slides de uma apresentação podem ser removidas como mostrado no exemplo abaixo:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar um objeto Presentation que representa um arquivo de apresentação 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Removendo notas de todos os slides
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Salvar a apresentação no disco
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Adicionar estilo de notas**

Propriedade NotesStyle foi adicionada à interface [IMasterNotesSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasternotesslide) e à classe [MasterNotesSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/masternotesslide) respectivamente. Essa propriedade especifica o estilo do texto das notas. A implementação é demonstrada no exemplo abaixo.

```c#
using Aspose.Slides;

// Instanciar a classe Presentation que representa o arquivo de apresentação
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Obter o estilo de texto do MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Definir marcador de símbolo para os parágrafos do primeiro nível
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Salvar o arquivo PPTX no disco
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **Perguntas frequentes**

### Qual entidade da API fornece acesso às notas de um slide específico?

As notas são acessadas por meio do gerenciador de notas do slide: o slide possui um [NotesSlideManager](https://reference.aspose.com/slides/pt/net/aspose.slides/notesslidemanager/) e uma [property](https://reference.aspose.com/slides/pt/net/aspose.slides/notesslidemanager/notesslide/) que retornam o objeto de notas, ou `null` se não houver notas.

### Existem diferenças no suporte a notas entre as versões do PowerPoint com as quais a biblioteca funciona?

A biblioteca tem como alvo uma ampla variedade de formatos do Microsoft PowerPoint (97‑mais recentes) e ODP; as notas são suportadas nesses formatos sem depender de uma cópia instalada do PowerPoint.