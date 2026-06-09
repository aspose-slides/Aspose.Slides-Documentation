---
title: Macro VBA
type: docs
weight: 150
url: /pt/java/examples/elements/vba-macro/
keywords:
- exemplo de código
- VBA
- macro
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Automatize apresentações com Aspose.Slides for Java: crie, execute, importe e proteja macros VBA em PPT, PPTX e ODP usando exemplos claros em Java."
---
Este artigo demonstra como adicionar, acessar e remover macros VBA usando **Aspose.Slides for Java**.

## **Adicionar uma Macro VBA**

Crie uma apresentação com um projeto VBA e um módulo de macro simples.

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar uma Macro VBA**

Recupere o primeiro módulo do projeto VBA.

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover uma Macro VBA**

Exclua um módulo do projeto VBA.

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```