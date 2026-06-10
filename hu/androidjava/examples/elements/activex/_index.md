---
title: ActiveX
type: docs
weight: 200
url: /hu/androidjava/examples/elements/activex/
keywords:
- kód példa
- ActiveX
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Lásd az Aspose.Slides for Android ActiveX példákat: ActiveX objektumok beszúrása, konfigurálása és vezérlése PPT és PPTX prezentációkban egyértelmű Java kóddal."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni, elérni, eltávolítani és konfigurálni az ActiveX vezérlőket egy prezentációban az **Aspose.Slides for Android via Java** használatával.

## **ActiveX vezérlő hozzáadása**

Új ActiveX vezérlőt szúrjon be, és választhatóan állítsa be annak tulajdonságait.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Új ActiveX vezérlő hozzáadása.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Opcionálisan állítson be néhány tulajdonságot.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX vezérlő elérése**

Olvassa ki az információkat a diámon lévő első ActiveX vezérlőből.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Az első ActiveX vezérlő elérése.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX vezérlő eltávolítása**

Törölje a meglévő ActiveX vezérlőt a diáról.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Az első ActiveX vezérlő eltávolítása.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX tulajdonságok beállítása**

Adjon hozzá egy vezérlőt, és konfiguráljon több ActiveX tulajdonságot.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Windows Media Player vezérlő hozzáadása és tulajdonságok konfigurálása.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```