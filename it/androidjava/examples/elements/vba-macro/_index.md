---
title: Macro VBA
type: docs
weight: 150
url: /it/androidjava/examples/elements/vba-macro/
keywords:
- esempio di codice
- VBA
- macro
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Automatizza le presentazioni con Aspose.Slides per Android: crea, esegui, importa e proteggi le macro VBA in PPT, PPTX e ODP utilizzando chiari esempi Java."
---
Questo articolo dimostra come aggiungere, accedere e rimuovere macro VBA utilizzando **Aspose.Slides for Android via Java**.

## **Aggiungere una macro VBA**

Crea una presentazione con un progetto VBA e un semplice modulo di macro.

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

## **Accedere a una macro VBA**

Recupera il primo modulo dal progetto VBA.

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

## **Rimuovere una macro VBA**

Elimina un modulo dal progetto VBA.

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