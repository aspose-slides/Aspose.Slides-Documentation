---
title: VBA-macro
type: docs
weight: 150
url: /nl/androidjava/examples/elements/vba-macro/
keywords:
- codevoorbeeld
- VBA
- macro
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Automatiseer presentaties met Aspose.Slides voor Android: maak, voer uit, importeer en beveilig VBA-macro's in PPT, PPTX en ODP met duidelijke Java-voorbeelden."
---
Dit artikel laat zien hoe u VBA-macro's kunt toevoegen, openen en verwijderen met **Aspose.Slides for Android via Java**.

## **Voeg een VBA-macro toe**

Maak een presentatie met een VBA-project en een eenvoudige macro‑module.

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

## **Toegang tot een VBA-macro**

Haal de eerste module op uit het VBA-project.

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

## **Verwijder een VBA-macro**

Verwijder een module uit het VBA-project.

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