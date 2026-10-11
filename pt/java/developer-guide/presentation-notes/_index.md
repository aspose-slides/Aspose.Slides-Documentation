---
title: Gerenciar notas de apresentação em Java
linktitle: Notas de Apresentação
type: docs
weight: 110
url: /pt/java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Personalize notas de apresentação com Aspose.Slides para Java. Trabalhe de forma fluida com notas do PowerPoint e OpenDocument para aumentar sua produtividade."
---
## **Visão geral**

Aspose.Slides oferece suporte à remoção de slides de notas de uma apresentação. Neste tópico, apresentaremos esse recurso, incluindo como remover notas e como aplicar um estilo aos slides de notas em uma apresentação. Aspose.Slides permite remover notas de qualquer slide e também aplicar formatação às notas existentes. Os desenvolvedores podem remover notas das seguintes maneiras:

- Remover notas de um slide específico em uma apresentação.
- Remover notas de todos os slides em uma apresentação.

Para ler ou alterar as dimensões da página de notas, mudar a orientação e verificar o comportamento de exportação, veja [Tamanho da Página de Notas](/slides/pt/java/notes-size/).

## **Remover notas de um slide**
As notas de um slide específico podem ser removidas conforme mostrado no exemplo abaixo:

```java
import com.aspose.slides.*;

// Instancie um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Removendo notas do primeiro slide
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Salvando a apresentação no disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remover notas de uma apresentação**
As notas de todos os slides em uma apresentação podem ser removidas conforme mostrado no exemplo abaixo:

```java
import com.aspose.slides.*;

// Instancie um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Removendo notas de todos os slides
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Salvando a apresentação no disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adicionar um estilo de notas**
O método [getNotesStyle](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) foi adicionado à interface [IMasterNotesSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IMasterNotesSlide) e à classe [MasterNotesSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/MasterNotesSlide) respectivamente. Esta propriedade especifica o estilo do texto das notas. A implementação é demonstrada no exemplo abaixo.

```java
import com.aspose.slides.*;

// Instancie um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Obtenha o estilo de texto do MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Defina marcador de símbolo para os parágrafos do primeiro nível
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Qual entidade da API fornece acesso às notas de um slide específico?**

As notas são acessadas por meio do gerenciador de notas do slide: o slide possui um [NotesSlideManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/notesslidemanager/) e um [método](https://reference.aspose.com/slides/pt/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) que retorna o objeto de notas, ou `null` se não houver notas.

**Existem diferenças no suporte a notas entre as versões do PowerPoint com as quais a biblioteca funciona?**

A biblioteca tem como alvo uma ampla variedade de formatos do Microsoft PowerPoint (97–mais recentes) e ODP; as notas são suportadas nesses formatos sem depender de uma cópia instalada do PowerPoint.