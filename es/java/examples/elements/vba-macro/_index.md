---
title: Macro VBA
type: docs
weight: 150
url: /es/java/examples/elements/vba-macro/
keywords:
- ejemplo de código
- VBA
- macro
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Automatice presentaciones con Aspose.Slides for Java: cree, ejecute, importe y proteja macros VBA en PPT, PPTX y ODP mediante ejemplos claros de Java."
---
Este artículo demuestra cómo agregar, acceder y eliminar macros VBA usando **Aspose.Slides for Java**.

## **Agregar una macro VBA**

Cree una presentación con un proyecto VBA y un módulo de macro sencillo.

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

## **Acceder a una macro VBA**

Recupere el primer módulo del proyecto VBA.

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

## **Eliminar una macro VBA**

Elimine un módulo del proyecto VBA.

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