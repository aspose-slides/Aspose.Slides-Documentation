---
title: Diaátmenet
type: docs
weight: 110
url: /hu/androidjava/examples/elements/slide-transition/
keywords:
- kódpélda
- diaátmenet
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android fő diaátmenetei: hozzáadás, testreszabás és hatások és időtartamok sorozása Java példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja a diaváltási átmenetek és időzítések alkalmazását a **Aspose.Slides for Android via Java** segítségével.

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

        // Az átmenettípus elérése.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Diaátmenet eltávolítása**

Távolítsa el az összes átmeneti hatást a típus `None`-ra állítással.

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

Adja meg, hogy a dia mennyi ideig legyen látható, mielőtt automatikusan továbblép.

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