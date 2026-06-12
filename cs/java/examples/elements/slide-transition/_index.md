---
title: Přechod snímku
type: docs
weight: 110
url: /cs/java/examples/elements/slide-transition/
keywords:
- příklad kódu
- přechod snímku
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Ovládejte přechody snímků v Aspose.Slides pro Java: přidávejte, přizpůsobujte a řaďte efekty a délky trvání pomocí Java příkladů pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak použít efekty přechodů snímků a časování s **Aspose.Slides for Java**.

## **Přidat přechod snímku**

Použijte efekt rozplynutí na první snímek.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Použít přechod rozplynutím.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Získání přechodu snímku**

Přečtěte typ přechodu aktuálně přiřazený snímku.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Přístup k typu přechodu.
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

        // Odstranit přechod nastavením None.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Nastavit délku trvání přechodu**

Určete, jak dlouho bude snímek zobrazen před automatickým přechodem.

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