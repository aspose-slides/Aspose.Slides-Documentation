---
title: ActiveX
type: docs
weight: 200
url: /hu/java/examples/elements/activex/
keywords:
- kód példa
- ActiveX
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse meg az Aspose.Slides for Java ActiveX példákat: ActiveX objektumok beszúrása, konfigurálása és vezérlése PPT és PPTX prezentációkban tiszta Java kóddal."
---
Ez a cikk bemutatja, hogyan lehet ActiveX vezérlőket hozzáadni, elérni, eltávolítani és konfigurálni egy prezentációban az **Aspose.Slides for Java** használatával.

## **ActiveX vezérlő hozzáadása**

Új ActiveX vezérlőt szúrjon be, és opcionálisan állítsa be a tulajdonságait.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Új ActiveX vezérlő hozzáadása.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Opcionálisan állíts be néhány tulajdonságot.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX vezérlő elérése**

Olvassa ki az információkat a dia első ActiveX vezérlőjéről.

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

        // Windows Media Player vezérlő hozzáadása és tulajdonságok beállítása.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```