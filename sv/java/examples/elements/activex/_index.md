---
title: ActiveX
type: docs
weight: 200
url: /sv/java/examples/elements/activex/
keywords:
- kodexempel
- ActiveX
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Se Aspose.Slides for Java ActiveX-exempel: infoga, konfigurera och styra ActiveX-objekt i PPT- och PPTX-presentationer med tydlig Java-kod."
---
Den här artikeln visar hur man lägger till, får åtkomst till, tar bort och konfigurerar ActiveX‑kontroller i en presentation med **Aspose.Slides for Java**.

## **Lägg till en ActiveX‑kontroll**

Infoga en ny ActiveX‑kontroll och ange eventuellt dess egenskaper.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Lägg till en ny ActiveX-kontroll.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Ställ eventuellt in några egenskaper.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Få åtkomst till en ActiveX‑kontroll**

Läs information från den första ActiveX‑kontrollen på bilden.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Åtkomst till den första ActiveX-kontrollen.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en ActiveX‑kontroll**

Ta bort en befintlig ActiveX‑kontroll från bilden.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Ta bort den första ActiveX-kontrollen.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Ställ in ActiveX‑egenskaper**

Lägg till en kontroll och konfigurera flera ActiveX‑egenskaper.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Lägg till en Windows Media Player-kontroll och konfigurera egenskaper.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```