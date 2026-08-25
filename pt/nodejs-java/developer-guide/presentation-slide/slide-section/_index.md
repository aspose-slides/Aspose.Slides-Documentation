---
title: Gerenciar Seções de Slides em Apresentações com JavaScript
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
- recuperar slides da seção
- processar slides da seção
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie seções de slides com Aspose.Slides for Node.js via Java: crie, renomeie, reordene, recupere e processe slides de seção em apresentações PPTX."
---
## **Introdução**

Seções organizam slides consecutivos em grupos nomeados sem alterar o conteúdo do slide. Com Aspose.Slides for Node.js via Java, você pode criar, reordenar, renomear, inspecionar e remover seções através do método [Presentation.getSections](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSections).

Seções são especialmente úteis quando:

- uma apresentação grande precisa ser dividida em tópicos ou capítulos lógicos;
- diferentes grupos de slides são atribuídos a diferentes colaboradores;
- slides precisam ser processados, movidos ou mesclados como grupos.

Escolha nomes concisos para as seções que descrevam o propósito dos slides agrupados. Como as seções fazem parte da estrutura da apresentação, use as APIs de seção para determinar a associação em vez de derivá‑la a partir das posições dos slides.

## **Criar e Gerenciar Seções**

Use [SectionCollection.addSection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectioncollection/#addSection) para criar uma seção especificando seu nome e slide inicial. Aspose.Slides determina quais slides pertencem à seção a partir da estrutura de seções atual da apresentação.

O mesmo [SectionCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectioncollection/) também permite:

- mover uma seção junto com seus slides usando [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- remover apenas a definição da seção com [SectionCollection.removeSection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectioncollection/#removeSection), que mantém seus slides;
- remover uma seção e seus slides com [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- adicionar uma seção vazia ao final com [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

O exemplo a seguir cria duas seções, move uma delas, remove‑a junto com seus slides e adiciona uma seção vazia:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Após essas operações, a apresentação contém a seção `Introduction` com seus slides e uma seção vazia `Appendix`. A seção `Results` e seus slides foram removidos.

## **Renomear Seções**

Para renomear uma seção, chame seu método [Section.setName](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#setName). Os slides e a posição da seção permanecem inalterados.

O exemplo a seguir cria uma seção e altera seu nome:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Recuperar Slides de Seções**

O método [Presentation.getSections](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSections) devolve um [SectionCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectioncollection/) que pode ser acessado por índice. Para cada [Section](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/), chame [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getSlidesListOfSection) para obter os slides que atualmente pertencem a ela. O método devolve um [SectionSlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectionslidecollection/), que fornece contagem e acesso indexado.

O exemplo a seguir cria duas seções preenchidas e uma seção vazia, depois imprime o [name](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getStartedFromSlide), contagem de slides e números dos slides de cada seção. Ele usa [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) para ler tanto o primeiro slide quanto cada slide na coleção. Para a seção vazia, a coleção devolvida tem tamanho zero, o acesso indexado é ignorado e o laço não executa operações.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

A associação às seções é determinada pela estrutura de seções da apresentação. Não calcule manualmente o intervalo de uma seção a partir de [Section.getStartedFromSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getStartedFromSlide), índices de slides e o slide inicial da próxima seção.

Edições estruturais podem mudar tanto os slides retornados para uma seção quanto seus números de slide. Isso inclui reordenar slides, clonar um slide em uma seção, mover uma seção junto com seus slides, remover slides e remover seções. O próximo exemplo chama [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getSlidesListOfSection) após cada alteração em vez de manter suposições sobre os limites anteriores da seção.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Chame [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getSlidesListOfSection) novamente sempre que slides ou seções forem reordenados, clonados, movidos ou removidos. Isso mantém o processamento subsequente alinhado com a estrutura atual da apresentação.

O formato PPT (PowerPoint 97–2003) não preserva metadados de seção. Use esse fluxo de trabalho com um formato que suporte seções, como PPTX; converter para PPT remove a estrutura de seções necessária para iterações posteriores.

## **Perguntas Frequentes**

**As seções são preservadas ao salvar no formato PPT (PowerPoint 97–2003)?**

Não. O formato PPT não suporta metadados de seção, portanto o agrupamento de seções é perdido ao salvar em .ppt.

**É possível ocultar uma seção inteira?**

Não. Uma seção não tem estado de visibilidade. Para ocultar seu conteúdo, chame [Slide.setHidden](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#setHidden) para cada slide na seção.

**Como posso encontrar a seção que contém um slide?**

Acesse cada seção na coleção devolvida por [Presentation.getSections](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSections), chame [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getSlidesListOfSection) para cada seção e compare os slides retornados com o slide alvo. Para uma seção não vazia, [Section.getStartedFromSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getStartedFromSlide) devolve seu primeiro slide; para uma seção vazia, ele devolve `null`.