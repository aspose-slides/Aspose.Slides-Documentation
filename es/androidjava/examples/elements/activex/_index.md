---
title: ActiveX
type: docs
weight: 200
url: /es/androidjava/examples/elements/activex/
keywords:
- ejemplo de código
- ActiveX
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Vea los ejemplos de ActiveX de Aspose.Slides para Android: inserte, configure y controle objetos ActiveX en presentaciones PPT y PPTX con código Java claro."
---
Este artículo muestra cómo añadir, acceder, eliminar y configurar controles ActiveX en una presentación usando **Aspose.Slides for Android via Java**.

## **Agregar un control ActiveX**

Inserte un nuevo control ActiveX y, opcionalmente, establezca sus propiedades.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Agregar un nuevo control ActiveX.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Opcionalmente establecer algunas propiedades.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un control ActiveX**

Lea información del primer control ActiveX en la diapositiva.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Acceder al primer control ActiveX.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un control ActiveX**

Elimine un control ActiveX existente de la diapositiva.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Eliminar el primer control ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Establecer propiedades ActiveX**

Agregue un control y configure varias propiedades ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Añadir un control Windows Media Player y configurar propiedades.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```