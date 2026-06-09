---
title: Macro VBA
type: docs
weight: 150
url: /pt/androidjava/examples/elements/vba-macro/
keywords:
- exemplo de código
- VBA
- macro
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Automatize apresentações com Aspose.Slides para Android: crie, execute, importe e proteja macros VBA em PPT, PPTX e ODP usando exemplos claros em Java."
---
Este artigo demonstra como adicionar, acessar e remover macros VBA usando **Aspose.Slides for Android via Java**.

## **Adicionar uma macro VBA**

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

## **Acessar uma macro VBA**

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

## **Remover uma macro VBA**

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