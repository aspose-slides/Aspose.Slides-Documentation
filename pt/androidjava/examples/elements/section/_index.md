---
title: Seção
type: docs
weight: 90
url: /pt/androidjava/examples/elements/section/
keywords:
- exemplo de código
- seção
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Gerencie seções de slides no Aspose.Slides para Android: crie, renomeie, reordene e agrupe slides com exemplos Java para PPT, PPTX e ODP."
---
Exemplos de gerenciamento de seções de apresentação — adicionar, acessar, remover e renomear programaticamente usando **Aspose.Slides for Android via Java**.

## **Adicionar uma Seção**

Crie uma seção que comece em um slide específico.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Especifique o slide que marca o início da seção.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar uma Seção**

Leia informações da seção de uma apresentação.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Acesse uma seção por índice.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Remover uma Seção**

Exclua uma seção adicionada anteriormente.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Remova a primeira seção.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Renomear uma Seção**

Altere o nome de uma seção existente.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```