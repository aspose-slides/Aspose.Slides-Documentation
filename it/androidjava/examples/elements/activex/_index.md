---
title: ActiveX
type: docs
weight: 200
url: /it/androidjava/examples/elements/activex/
keywords:
- esempio di codice
- ActiveX
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Vedi gli esempi ActiveX di Aspose.Slides per Android: inserisci, configura e controlla gli oggetti ActiveX in presentazioni PPT e PPTX con un chiaro codice Java."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e configurare i controlli ActiveX in una presentazione utilizzando **Aspose.Slides for Android via Java**.

## **Aggiungi un controllo ActiveX**
Inserisci un nuovo controllo ActiveX e, facoltativamente, imposta le sue proprietà.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Aggiungi un nuovo controllo ActiveX.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Facoltativamente impostare alcune proprietà.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un controllo ActiveX**
Leggi le informazioni dal primo controllo ActiveX nella diapositiva.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Accedi al primo controllo ActiveX.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi un controllo ActiveX**
Elimina un controllo ActiveX esistente dalla diapositiva.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Rimuovi il primo controllo ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Imposta le proprietà ActiveX**
Aggiungi un controllo e configura diverse proprietà ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Aggiungi un controllo Windows Media Player e configura le proprietà.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```