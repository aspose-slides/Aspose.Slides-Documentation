---
title: VBA-makro
type: docs
weight: 150
url: /sv/java/examples/elements/vba-macro/
keywords:
- kodexempel
- VBA
- makro
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Automatisera presentationer med Aspose.Slides för Java: skapa, köra, importera och skydda VBA‑makron i PPT, PPTX och ODP med tydliga Java‑exempel."
---
Denna artikel visar hur du lägger till, får åtkomst till och tar bort VBA‑makron med **Aspose.Slides for Java**.

## **Lägg till ett VBA-makro**

Skapa en presentation med ett VBA‑projekt och en enkel makro‑modul.

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

## **Få åtkomst till ett VBA-makro**

Hämta den första modulen från VBA‑projektet.

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

## **Ta bort ett VBA-makro**

Ta bort en modul från VBA‑projektet.

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