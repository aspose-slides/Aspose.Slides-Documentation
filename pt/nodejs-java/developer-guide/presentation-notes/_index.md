---
title: Gerenciar notas de apresentação em JavaScript
linktitle: Notas de apresentação
type: docs
weight: 110
url: /pt/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalize notas de apresentação em JavaScript com Aspose.Slides para Node.js. Trabalhe perfeitamente com notas do PowerPoint e OpenDocument para aumentar sua produtividade."
---
## **Visão geral**

Aspose.Slides suporta a remoção de slides de notas de uma apresentação. Neste tópico, apresentaremos esse recurso, incluindo como remover notas e como aplicar um estilo aos slides de notas em uma apresentação. Aspose.Slides permite remover notas de qualquer slide e também aplicar estilo às notas existentes. Os desenvolvedores podem remover notas das seguintes maneiras:

- Remover notas de um slide específico em uma apresentação.
- Remover notas de todos os slides em uma apresentação.

Para ler ou alterar as dimensões da página de notas, mudar a orientação e verificar o comportamento de exportação, veja [Tamanho da página de notas](/slides/pt/nodejs-java/notes-size/).

## **Remover notas de um slide**
As notas de um slide específico podem ser removidas como mostrado no exemplo abaixo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Removendo notas do primeiro slide
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Salvando a apresentação no disco
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remover notas de uma apresentação**
As notas de todos os slides em uma apresentação podem ser removidas como mostrado no exemplo abaixo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Removendo notas de todos os slides
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Salvando a apresentação no disco
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionar NotesStyle**
O método [getNotesStyle](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) foi adicionado à classe [MasterNotesSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/MasterNotesSlide) e à classe [MasterNotesSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/MasterNotesSlide) respectivamente. Esta propriedade especifica o estilo do texto das notas. A implementação é demonstrada no exemplo abaixo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Obter estilo de texto do MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Definir marcador de símbolo para os parágrafos do primeiro nível
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**Qual entidade da API fornece acesso às notas de um slide específico?**

As notas são acessadas através do gerenciador de notas do slide: o slide possui um [NotesSlideManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notesslidemanager/) e um [método](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) que retorna o objeto de notas, ou `null` se não houver notas.

**Existem diferenças no suporte a notas entre as versões do PowerPoint com as quais a biblioteca funciona?**

A biblioteca tem como alvo uma ampla gama de formatos do Microsoft PowerPoint (97–mais recentes) e ODP; as notas são suportadas nesses formatos sem depender de uma cópia instalada do PowerPoint.