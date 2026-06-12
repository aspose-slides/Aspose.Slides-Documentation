---
title: Přechod snímku
type: docs
weight: 110
url: /cs/androidjava/examples/elements/slide-transition/
keywords:
- příklad kódu
- přechod snímku
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Ovládejte přechody snímků v Aspose.Slides pro Android: přidávejte, upravujte a řaďte efekty a jejich trvání pomocí příkladů v Javě pro prezentace PPT, PPTX a ODP."
---
Tento článek demonstruje použití efektů přechodu snímků a časování s **Aspose.Slides for Android via Java**.

## **Přidat přechod snímku**

Použijte efekt postupného přechodu (fade) na první snímek.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Použít přechod typu fade.
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k přechodu snímku**

Přečtěte typ přechodu aktuálně přiřazený ke snímku.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Získat typ přechodu.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit přechod snímku**

Vymažte jakýkoli efekt přechodu nastavením typu na `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Odebrat přechod nastavením na None.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Nastavit dobu trvání přechodu**

Určete, jak dlouho je snímek zobrazen před automatickým postoupem.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // v milisekundách.
    } finally {
        presentation.dispose();
    }
}
```