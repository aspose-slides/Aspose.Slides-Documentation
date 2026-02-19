---
title: VBA-Makro
type: docs
weight: 150
url: /de/androidjava/examples/elements/vba-macro/
keywords:
- Codebeispiel
- VBA
- Makro
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Automatisieren Sie Präsentationen mit Aspose.Slides für Android: Erstellen, ausführen, importieren und sichern Sie VBA-Makros in PPT, PPTX und ODP mithilfe klarer Java-Beispiele."
---
Dieser Artikel zeigt, wie man VBA‑Makros mithilfe von **Aspose.Slides for Android via Java** hinzufügt, darauf zugreift und sie entfernt.

## **VBA‑Makro hinzufügen**

Erstellen Sie eine Präsentation mit einem VBA‑Projekt und einem einfachen Makro‑Modul.

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

## **VBA‑Makro zugreifen**

Rufen Sie das erste Modul aus dem VBA‑Projekt ab.

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

## **VBA‑Makro entfernen**

Löschen Sie ein Modul aus dem VBA‑Projekt.

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