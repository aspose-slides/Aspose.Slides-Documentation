---
title: ActiveX
type: docs
weight: 200
url: /de/androidjava/examples/elements/activex/
keywords:
- Codebeispiel
- ActiveX
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Siehe Aspose.Slides für Android ActiveX-Beispiele: Einfügen, Konfigurieren und Steuern von ActiveX-Objekten in PPT- und PPTX-Präsentationen mit klarem Java-Code."
---
Dieser Artikel zeigt, wie man ActiveX‑Steuerelemente zu einer Präsentation hinzufügt, darauf zugreift, sie entfernt und konfiguriert, wobei **Aspose.Slides for Android via Java** verwendet wird.

## **ActiveX‑Steuerelement hinzufügen**

Fügen Sie ein neues ActiveX‑Steuerelement ein und setzen Sie optional seine Eigenschaften.

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
            // Auf das erste ActiveX-Steuerelement zugreifen.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX‑Steuerelement entfernen**

Löschen Sie ein vorhandenes ActiveX‑Steuerelement von der Folie.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Das erste ActiveX-Steuerelement entfernen.
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

        // Windows Media Player-Steuerelement hinzufügen und Eigenschaften konfigurieren.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```