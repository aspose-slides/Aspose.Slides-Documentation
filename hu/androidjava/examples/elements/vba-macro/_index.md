---
title: VBA makró
type: docs
weight: 150
url: /hu/androidjava/examples/elements/vba-macro/
keywords:
- kód példa
- VBA
- makró
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Automatizálja a prezentációkat az Aspose.Slides for Android segítségével: hozzon létre, futtasson, importáljon és biztonságosítsa a VBA makrókat PPT, PPTX és ODP formátumban egyértelmű Java példákkal."
---
Ez a cikk bemutatja, hogyan lehet VBA makrókat hozzáadni, elérni és eltávolítani az **Aspose.Slides for Android via Java** használatával.

## **VBA makró hozzáadása**

Készítsen egy prezentációt VBA projekttel és egy egyszerű makrómodullal.

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

## **VBA makró elérése**

Szerezze be az első modult a VBA projekttől.

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

## **VBA makró eltávolítása**

Törölje a modult a VBA projektből.

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