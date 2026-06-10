---
title: Diaátmenet
type: docs
weight: 110
url: /hu/java/examples/elements/slide-transition/
keywords:
- kód példa
- diaátmenet
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Mesteri diaátmenetek az Aspose.Slides for Java-ban: adjon hozzá, testreszabjon és sorozzon effektusokat és időtartamokat Java példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan alkalmazhatók diaátmeneti effektusok és időzítések a **Aspose.Slides for Java**-ban.

## **Diaátmenet hozzáadása**

Alkalmazzon elhalványuló átmenetet az első diára.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Alkalmazzon elhalványuló átmenetet.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Diaátmenet elérése**

Olvassa el a diára jelenleg beállított átmenettípust.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Az átmenet típusának lekérése.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Diaátmenet eltávolítása**

Távolítsa el minden átmeneti hatást a típus `None` beállításával.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Az átmenet eltávolítása a None beállításával.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Átmenet időtartamának beállítása**

Adja meg, meddig jelenik meg a dia, mielőtt automatikusan továbbhaladna.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // ezredmásodpercben.
    } finally {
        presentation.dispose();
    }
}
```