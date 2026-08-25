---
title: Gerenciar Seções de Slides em Apresentações com Java
linktitle: Seção de Slide
type: docs
weight: 90
url: /pt/java/slide-section/
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
- Java
- Aspose.Slides
description: "Gerenciar seções de slides com Aspose.Slides for Java: criar, renomear, reordenar, recuperar e processar slides de seção em apresentações PPTX."
---
## **Introdução**

Seções organizam slides consecutivos em grupos nomeados sem alterar o conteúdo dos slides. Com Aspose.Slides for Java, você pode criar, reordenar, renomear, inspecionar e remover seções através do método [Presentation.getSections](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSections--) .

As seções são especialmente úteis quando:

- uma apresentação grande precisa ser dividida em tópicos ou capítulos lógicos;
- diferentes grupos de slides são atribuídos a colaboradores diferentes;
- slides precisam ser processados, movidos ou mesclados como grupos.

Escolha nomes de seção concisos que descrevam o propósito dos slides agrupados. Como as seções fazem parte da estrutura da apresentação, use as APIs de seção para determinar a associação em vez de derivá‑la a partir das posições dos slides.

## **Criar e Gerenciar Seções**

Use [ISectionCollection.addSection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) para criar uma seção especificando seu nome e slide inicial. Aspose.Slides determina quais slides pertencem à seção a partir da estrutura de seções atual da apresentação.

O mesmo [ISectionCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isectioncollection/) também permite:

- mover uma seção junto com seus slides usando [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- remover apenas a definição da seção com [ISectionCollection.removeSection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), mantendo seus slides;
- remover uma seção e seus slides com [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- adicionar uma seção vazia ao final com [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) .

O exemplo a seguir cria duas seções, move uma delas, remove‑a juntamente com seus slides e anexa uma seção vazia:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Após essas operações, a apresentação contém a seção `Introduction` com seus slides e uma seção vazia `Appendix`. A seção `Results` e seus slides foram removidos.

## **Renomear Seções**

Para renomear uma seção, chame o método [ISection.setName](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#setName-java.lang.String-) dela. Os slides e a posição da seção permanecem inalterados.

O exemplo a seguir cria uma seção e altera seu nome:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Recuperar Slides de Seções**

O método [Presentation.getSections](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSections--) devolve um [ISectionCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isectioncollection/) que pode ser percorrido. Para cada [ISection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/), chame [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#getSlidesListOfSection--) para obter os slides que atualmente pertencem a ela. O método devolve um [ISectionSlideCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isectionslidecollection/), que fornece contagem, acesso indexado e iteração.

O exemplo a seguir cria duas seções preenchidas e uma seção vazia, então imprime o [nome](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#getName--), o [identificador](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#getSectionId--), o [slide inicial](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#getStartedFromSlide--), a contagem de slides e os números dos slides de cada seção. Ele usa [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) para ler o primeiro slide e uma instrução `for` aprimorada para processar cada slide. Para a seção vazia, a coleção devolvida tem tamanho zero, o método não é chamado e a iteração não realiza operações.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

A associação a seções é determinada pela estrutura de seções da apresentação. Não calcule manualmente o intervalo de uma seção a partir de [ISection.getStartedFromSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#getStartedFromSlide--), índices de slides e o slide inicial da próxima seção.

Edições estruturais podem alterar tanto os slides retornados para uma seção quanto seus números de slide. Isso inclui reordenar slides, clonar um slide em uma seção, mover uma seção juntamente com seus slides, remover slides e remover seções. O próximo exemplo chama [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#getSlidesListOfSection--) após cada mudança desse tipo, em vez de manter suposições sobre os limites anteriores da seção.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Chame [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#getSlidesListOfSection--) novamente sempre que slides ou seções forem reordenados, clonados, movidos ou removidos. Isso mantém o processamento subsequente alinhado com a estrutura atual da apresentação.

O formato PPT (PowerPoint 97–2003) não preserva metadados de seção. Use este fluxo de trabalho com um formato que suporte seções, como PPTX; converter para PPT remove a estrutura de seções necessária para iteração posterior.

## **FAQ**

**As seções são preservadas ao salvar no formato PPT (PowerPoint 97–2003)?**

Não. O formato PPT não suporta metadados de seção, portanto o agrupamento por seção é perdido ao salvar em *.ppt*.

**É possível “ocultar” uma seção inteira?**

Não. Uma seção não possui estado de visibilidade. Para ocultar seu conteúdo, chame [ISlide.setHidden](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islide/#setHidden-boolean-) para cada slide da seção.

**Como posso encontrar a seção que contém um determinado slide?**

Percorra a coleção devolvida por [Presentation.getSections](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSections--), chame [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#getSlidesListOfSection--) para cada seção e compare os slides retornados com o slide alvo. Para uma seção não vazia, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isection/#getStartedFromSlide--) devolve seu primeiro slide; para uma seção vazia, devolve `null`.