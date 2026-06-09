---
title: Gerenciar Seções de Slides em Apresentações Usando JavaScript
linktitle: Seção de Slide
type: docs
weight: 90
url: /pt/nodejs-java/slide-section/
keywords:
- criar seção
- adicionar seção
- editar seção
- alterar seção
- nome da seção
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Simplifique as seções de slides no PowerPoint e OpenDocument com Aspose.Slides para Node.js — divida, renomeie e reordene para otimizar fluxos de trabalho PPTX e ODP."
---
## **Introdução**

Com Aspose.Slides for Node.js via Java, você pode organizar uma Apresentação PowerPoint em seções. Você pode criar seções que contêm slides específicos.

Você pode querer criar seções e usá‑las para organizar ou dividir slides em uma apresentação em partes lógicas nas seguintes situações:

- Quando você está trabalhando em uma apresentação grande com outras pessoas ou uma equipe — e precisa atribuir certos slides a um colega ou a alguns membros da equipe. 
- Quando você está lidando com uma apresentação que contém muitos slides — e está tendo dificuldade em gerenciar ou editar seu conteúdo de uma só vez.

Idealmente, você deve criar uma seção que agrupe slides semelhantes — os slides têm algo em comum ou podem existir em um grupo baseado em uma regra — e dar à seção um nome que descreva os slides contidos nela. 

## **Criando Seções em Apresentações**

Para adicionar uma seção que agrupará slides em uma apresentação, Aspose.Slides for Node.js via Java fornece o método [addSection()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) que permite especificar o nome da seção que você deseja criar e o slide a partir do qual a seção começa.

Este código de exemplo mostra como criar uma seção em uma apresentação em JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 será encerrada em newSlide2 e depois dela a section2 começará
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alterando os Nomes das Seções**

Depois de criar uma seção em uma apresentação PowerPoint, você pode decidir alterar seu nome. 

Este código de exemplo mostra como mudar o nome de uma seção em uma apresentação em JavaScript usando Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**As seções são preservadas ao salvar no formato PPT (PowerPoint 97–2003)?**

Não. O formato PPT não suporta metadados de seção, portanto o agrupamento de seções é perdido ao salvar em .ppt.

**Uma seção inteira pode ser “ocultada”?**

Não. Apenas slides individuais podem ser ocultados. Uma seção, enquanto entidade, não possui estado “oculto”.

**Posso encontrar rapidamente uma seção por um slide e, inversamente, o primeiro slide de uma seção?**

Sim. Uma seção é definida exclusivamente pelo seu slide inicial; dado um slide, você pode determinar a qual seção ele pertence e, para uma seção, pode acessar seu primeiro slide.