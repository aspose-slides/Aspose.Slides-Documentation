---
title: VBA Macro
type: docs
weight: 150
url: /androidjava/examples/elements/vbamacro/
keywords:
- code example
- VBA
- macro
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Automate presentations with Aspose.Slides for Android: create, run, import, and secure VBA macros in PPT, PPTX, and ODP using clear Java examples."
---

This article demonstrates how to add, access, and remove VBA macros using **Aspose.Slides for Android via Java**.

## **Add a VBA Macro**

Create a presentation with a VBA project and a simple macro module.

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

## **Access a VBA Macro**

Retrieve the first module from the VBA project.

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

## **Remove a VBA Macro**

Delete a module from the VBA project.

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
