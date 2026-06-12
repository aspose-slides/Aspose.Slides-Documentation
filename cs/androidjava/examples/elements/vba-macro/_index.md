---
title: VBA makro
type: docs
weight: 150
url: /cs/androidjava/examples/elements/vba-macro/
keywords:
- příklad kódu
- VBA
- makro
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Automatizujte prezentace pomocí Aspose.Slides pro Android: vytvářejte, spouštějte, importujte a zabezpečujte makra VBA v formátech PPT, PPTX a ODP pomocí přehledných příkladů v jazyce Java."
---
Tento článek ukazuje, jak přidávat, získávat přístup k a odstraňovat makra VBA pomocí **Aspose.Slides for Android via Java**.

## **Přidat makro VBA**

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

## **Přístup k makru VBA**

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

## **Odstranit makro VBA**

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