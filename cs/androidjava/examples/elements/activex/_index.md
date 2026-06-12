---
title: ActiveX
type: docs
weight: 200
url: /cs/androidjava/examples/elements/activex/
keywords:
- ukázka kódu
- ActiveX
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Prohlédněte si příklady ActiveX pro Aspose.Slides pro Android: vkládání, konfiguraci a řízení objektů ActiveX v prezentacích PPT a PPTX pomocí přehledného Java kódu."
---
Tento článek ukazuje, jak přidávat, přistupovat k, odstraňovat a konfigurovat ActiveX ovládací prvky v prezentaci pomocí **Aspose.Slides for Android via Java**.

## **Přidat ActiveX ovládací prvek**

Vložte nový ActiveX ovládací prvek a volitelně nastavte jeho vlastnosti.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Přidat nový ActiveX ovládací prvek.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Volitelně nastavit některé vlastnosti.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k ActiveX ovládacímu prvku**

Přečtěte informace z prvního ActiveX ovládacího prvku na snímku.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Přístup k prvnímu ActiveX ovládacímu prvku.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit ActiveX ovládací prvek**

Odstraňte existující ActiveX ovládací prvek ze snímku.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Odstranit první ActiveX ovládací prvek.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Nastavit vlastnosti ActiveX**

Přidejte ovládací prvek a nastavte několik vlastností ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Přidat ovládací prvek Windows Media Player a nastavit vlastnosti.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```