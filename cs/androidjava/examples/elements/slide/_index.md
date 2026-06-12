---
title: Snímek
type: docs
weight: 10
url: /cs/androidjava/examples/elements/slide/
keywords:
- ukázka kódu
- snímek
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Řídit snímky v Aspose.Slides for Android: vytvářet, duplikovat, měnit pořadí, měnit velikost, nastavovat pozadí a aplikovat přechody pomocí Javy pro prezentace PPT, PPTX a ODP."
---
Tento článek poskytuje řadu příkladů, které ukazují, jak pracovat se snímky pomocí **Aspose.Slides for Android via Java**. Naučíte se, jak přidávat, přistupovat, duplikovat, měnit pořadí a odstraňovat snímky pomocí třídy `Presentation`.

Každý níže uvedený příklad obsahuje stručné vysvětlení a následně úryvek kódu v jazyce Java.

## **Přidat snímek**

Chcete‑li přidat nový snímek, musíte nejprve vybrat rozvržení. V tomto příkladu používáme rozvržení `Blank` a přidáme prázdný snímek do prezentace.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Poznámka:** Každé rozvržení snímku je odvozeno od hlavního snímku, který určuje celkový design a strukturu zástupných prvků. Níže uvedený obrázek ilustruje, jak jsou v PowerPointu hlavní snímky a jejich přidružená rozvržení uspořádány.

![Vztah mezi hlavními snímky a rozvrženími](master-layout-slide.png)

## **Přístup k snímkům podle indexu**

Můžete přistupovat k snímkům pomocí jejich indexu nebo najít index snímku na základě reference. To je užitečné pro iteraci přes snímky nebo úpravu konkrétních snímků.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Přidejte další prázdný snímek.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Přístup k snímkům podle indexu.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Získejte index snímku z reference a pak jej přistupte podle indexu.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Klonovat snímek**

Tento příklad ukazuje, jak klonovat existující snímek. Klonovaný snímek je automaticky přidán na konec kolekce snímků.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Přeskupit snímky**

Můžete změnit pořadí snímků přesunutím jednoho na nový index. V tomto případě přesuneme klonovaný snímek na první pozici.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit snímek**

Chcete‑li odstranit snímek, jednoduše na něj odkažte a zavolejte `remove`. Tento příklad přidá druhý snímek a poté odstraní původní, takže zůstane pouze nový.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```