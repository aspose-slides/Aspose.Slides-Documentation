---
title: ActiveX
type: docs
weight: 200
url: /pl/java/examples/elements/activex/
keywords:
- przykład kodu
- ActiveX
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Zobacz przykłady ActiveX w Aspose.Slides for Java: wstawianie, konfigurowanie i sterowanie obiektami ActiveX w prezentacjach PPT i PPTX przy użyciu przejrzystego kodu Java."
---
Ten artykuł demonstruje, jak dodać, uzyskać dostęp, usunąć i skonfigurować kontrolki ActiveX w prezentacji przy użyciu **Aspose.Slides for Java**.

## **Dodaj kontrolkę ActiveX**

Wstaw nową kontrolkę ActiveX i opcjonalnie ustaw jej właściwości.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Dodaj nową kontrolkę ActiveX.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Opcjonalnie ustaw niektóre właściwości.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do kontrolki ActiveX**

Odczytaj informacje z pierwszej kontrolki ActiveX na slajdzie.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Uzyskaj dostęp do pierwszej kontrolki ActiveX.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń kontrolkę ActiveX**

Usuń istniejącą kontrolkę ActiveX ze slajdu.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Usuń pierwszą kontrolkę ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Ustaw właściwości ActiveX**

Dodaj kontrolkę i skonfiguruj kilka właściwości ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Dodaj kontrolkę Windows Media Player i skonfiguruj właściwości.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```