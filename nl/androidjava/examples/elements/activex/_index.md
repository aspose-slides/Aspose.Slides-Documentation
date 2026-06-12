---
title: ActiveX
type: docs
weight: 200
url: /nl/androidjava/examples/elements/activex/
keywords:
- codevoorbeeld
- ActiveX
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Bekijk de ActiveX-voorbeelden van Aspose.Slides for Android: invoegen, configureren en besturen van ActiveX-objecten in PPT- en PPTX-presentaties met duidelijke Java-code."
---
Dit artikel toont hoe u ActiveX‑besturingselementen kunt toevoegen, openen, verwijderen en configureren in een presentatie met behulp van **Aspose.Slides for Android via Java**.

## **ActiveX‑besturingselement toevoegen**

Voeg een nieuw ActiveX‑besturingselement in en stel desgewenst de eigenschappen in.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Voeg een nieuw ActiveX-besturingselement toe.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Stel eventueel enkele eigenschappen in.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Toegang tot een ActiveX‑besturingselement**

Lees informatie uit het eerste ActiveX‑besturingselement op de dia.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Toegang tot het eerste ActiveX-besturingselement.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX‑besturingselement verwijderen**

Verwijder een bestaand ActiveX‑besturingselement van de dia.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Verwijder het eerste ActiveX-besturingselement.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX‑eigenschappen instellen**

Voeg een besturingselement toe en configureer verschillende ActiveX‑eigenschappen.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Voeg een Windows Media Player-besturingselement toe en configureer de eigenschappen.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```