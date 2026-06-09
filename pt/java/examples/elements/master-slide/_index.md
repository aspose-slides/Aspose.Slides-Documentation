---
title: Slide Mestre
type: docs
weight: 30
url: /pt/java/examples/elements/master-slide/
keywords:
- exemplo de código
- slide mestre
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Explore exemplos de slides mestres do Aspose.Slides para Java: crie, edite e estilize mestres, marcadores de posição e temas em PPT, PPTX e ODP com código Java claro."
---
Slides mestres formam o nível superior da hierarquia de herança de slides no PowerPoint. Um **slide mestre** define elementos de design comuns, como planos de fundo, logotipos e formatação de texto. **Slides de layout** herdam de slides mestres, e **slides normais** herdam de slides de layout.

Este artigo demonstra como criar, modificar e gerenciar slides mestres usando Aspose.Slides para Java.

## **Adicionar um Slide Mestre**

Este exemplo mostra como criar um novo slide mestre clonando o padrão. Em seguida, adiciona um banner com o nome da empresa a todos os slides por meio da herança de layout.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Clone o slide mestre padrão.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Adicione um banner com o nome da empresa ao topo do slide mestre.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Atribua o novo slide mestre a um slide de layout.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Atribua o slide de layout ao primeiro slide da apresentação.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Slides mestres fornecem uma maneira de aplicar uma identidade visual consistente ou elementos de design compartilhados em todos os slides. Qualquer alteração feita no mestre será refletida automaticamente nos slides de layout e nos slides normais dependentes.

> 💡 **Nota 2:** Qualquer forma ou formatação adicionada a um slide mestre é herdada pelos slides de layout e, por sua vez, por todos os slides normais que utilizam esses layouts.  
> A imagem abaixo ilustra como uma caixa de texto adicionada em um slide mestre é renderizada automaticamente no slide final.

![Exemplo de Herança de Mestre](master-slide-banner.png)

## **Acessar um Slide Mestre**

Você pode acessar slides mestres usando a coleção master da apresentação. Veja como recuperá-los e trabalhar com eles:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Alterar o tipo de fundo.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Slide Mestre**

Slides mestres podem ser removidos tanto por índice quanto por referência.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Remover um slide mestre por índice.
        presentation.getMasters().removeAt(0);

        // Remover um slide mestre por referência.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover Slides Mestres Não Utilizados**

Algumas apresentações contêm slides mestres que não estão em uso. Remover esses slides pode ajudar a reduzir o tamanho do arquivo.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Remover todos os slides mestres não usados (mesmo os marcados como Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```