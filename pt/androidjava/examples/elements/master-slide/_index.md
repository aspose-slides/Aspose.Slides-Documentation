---
title: Slide Mestre
type: docs
weight: 30
url: /pt/androidjava/examples/elements/master-slide/
keywords:
- exemplo de código
- slide mestre
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Explore exemplos de slide mestre do Aspose.Slides para Android: crie, edite e estilize mestres, marcadores de posição e temas em PPT, PPTX e ODP com código Java claro."
---
Os slides mestre formam o nível superior da hierarquia de herança de slides no PowerPoint. Um **slide mestre** define elementos de design comuns, como fundos, logotipos e formatação de texto. **Slides de layout** herdam dos slides mestre, e **slides normais** herdam dos slides de layout.

Este artigo demonstra como criar, modificar e gerenciar slides mestre usando Aspose.Slides para Android via Java.

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

> 💡 **Nota 1:** Slides mestre fornecem uma maneira de aplicar branding consistente ou elementos de design compartilhados em todos os slides. Qualquer alteração feita no mestre será refletida automaticamente nos slides de layout e nos slides normais dependentes.

> 💡 **Nota 2:** Quaisquer formas ou formatações adicionadas a um slide mestre são herdadas pelos slides de layout e, por sua vez, por todos os slides normais que utilizam esses layouts.
> A imagem abaixo ilustra como uma caixa de texto adicionada em um slide mestre é renderizada automaticamente no slide final.

![Exemplo de Herança de Slide Mestre](master-slide-banner.png)

## **Acessar um Slide Mestre**

Você pode acessar slides mestre usando a coleção de mestres da apresentação. Veja como recuperar e trabalhar com eles:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Altere o tipo de fundo.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Slide Mestre**

Slides mestre podem ser removidos por índice ou por referência.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Remova um slide mestre por índice.
        presentation.getMasters().removeAt(0);

        // Remova um slide mestre por referência.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover Slides Mestre Não Utilizados**

Algumas apresentações contêm slides mestre que não estão em uso. Remover esses slides pode ajudar a reduzir o tamanho do arquivo.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Remova todos os slides mestres não utilizados (mesmo os marcados como Preservar).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```