---
title: ActiveX
type: docs
weight: 200
url: /de/java/examples/elements/activex/
keywords:
- Codebeispiel
- ActiveX
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Siehe Aspose.Slides for Java ActiveX‑Beispiele: Einfügen, Konfigurieren und Steuern von ActiveX‑Objekten in PPT‑ und PPTX‑Präsentationen mit klarem Java‑Code."
---
Dieser Artikel demonstriert, wie man ActiveX‑Steuerelemente zu einer Präsentation hinzufügt, darauf zugreift, sie entfernt und konfiguriert, wobei **Aspose.Slides for Java** verwendet wird.

## **Ein ActiveX‑Steuerelement hinzufügen**

Fügen Sie ein neues ActiveX‑Steuerelement ein und setzen Sie optional dessen Eigenschaften.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Ein neues ActiveX-Steuerelement hinzufügen.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Optional einige Eigenschaften setzen.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Auf ein ActiveX‑Steuerelement zugreifen**

Lesen Sie Informationen vom ersten ActiveX‑Steuerelement auf der Folie.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Zugriff auf das erste ActiveX-Steuerelement.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ein ActiveX‑Steuerelement entfernen**

Löschen Sie ein vorhandenes ActiveX‑Steuerelement von der Folie.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Entfernt das erste ActiveX-Steuerelement.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX‑Eigenschaften festlegen**

Fügen Sie ein Steuerelement hinzu und konfigurieren Sie mehrere ActiveX‑Eigenschaften.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Fügt ein Windows Media Player-Steuerelement hinzu und konfiguriert Eigenschaften.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```