---
title: VBA makro
type: docs
weight: 150
url: /cs/java/examples/elements/vba-macro/
keywords:
- ukázka kódu
- VBA
- makro
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Automatizujte prezentace pomocí Aspose.Slides pro Java: vytvářejte, spouštějte, importujte a zabezpečujte VBA makra v PPT, PPTX a ODP pomocí jasných Java příkladů."
---
Tento článek ukazuje, jak přidávat, přistupovat k a odstraňovat VBA makra pomocí **Aspose.Slides for Java**.

## **Přidat VBA makro**

Vytvořte prezentaci s VBA projektem a jednoduchým modulem makra.

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

## **Přístup k VBA makru**

Získejte první modul z VBA projektu.

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

## **Odstranit VBA makro**

Odstraňte modul z VBA projektu.

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