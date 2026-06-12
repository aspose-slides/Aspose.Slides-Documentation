---
title: VBA-macro
type: docs
weight: 150
url: /nl/java/examples/elements/vba-macro/
keywords:
- codevoorbeeld
- VBA
- macro
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Automatiseer presentaties met Aspose.Slides voor Java: maak, voer uit, importeer en beveilig VBA-macro's in PPT, PPTX en ODP met duidelijke Java-voorbeelden."
---
Dit artikel toont hoe je VBA-macro's kunt toevoegen, benaderen en verwijderen met **Aspose.Slides for Java**.

## **Een VBA-macro toevoegen**

Maak een presentatie met een VBA‑project en een eenvoudige macro‑module.

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

## **Een VBA-macro benaderen**

Haal de eerste module uit het VBA‑project op.

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

## **Een VBA-macro verwijderen**

Verwijder een module uit het VBA‑project.

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