---
title: Snímek
type: docs
weight: 10
url: /cs/java/examples/elements/slide/
keywords:
  - příklad kódu
  - snímek
  - PowerPoint
  - OpenDocument
  - prezentace
  - Java
  - Aspose.Slides
description: "Ovládejte snímky v Aspose.Slides for Java: vytvářejte, klonujte, přeskupujte, měňte velikost, nastavujte pozadí a aplikujte přechody v Javě pro prezentace PPT, PPTX a ODP."
---
Tento článek poskytuje řadu příkladů, které ukazují, jak pracovat se snímky pomocí **Aspose.Slides for Java**. Naučíte se, jak přidávat, přistupovat, klonovat, přeskupovat a odstraňovat snímky pomocí třídy `Presentation`.

Každý níže uvedený příklad obsahuje stručné vysvětlení následované úryvkem kódu v jazyce Java.

## **Přidání snímku**

Pro přidání nového snímku musíte nejprve vybrat rozvržení. V tomto příkladu používáme rozvržení `Blank` a přidáváme prázdný snímek do prezentace.

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

> 💡 **Poznámka:** Každé rozvržení snímku je odvozeno od hlavního snímku, který definuje celkový návrh a strukturu zástupných prvků. Obrázek níže ukazuje, jak jsou hlavní snímky a jejich související rozvržení uspořádány v PowerPointu.

![Vztah mezi hlavním snímkem a rozvržením](master-layout-slide.png)

## **Přístup ke snímkům podle indexu**

Můžete přistupovat ke snímkům pomocí jejich indexu nebo najít index snímku na základě odkazu. To je užitečné pro procházení nebo úpravu konkrétních snímků.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Přidejte další prázdný snímek.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Přístup ke snímkům podle indexu.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Získejte index snímku z reference a poté přistupte k němu podle indexu.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Klonování snímku**

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

## **Přeskupení snímků**

Pořadí snímků můžete změnit přesunutím jednoho na nový index. V tomto případě přesuneme klonovaný snímek na první pozici.

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

## **Odstranění snímku**

Pro odstranění snímku jej jednoduše odkažte a zavolejte `remove`. Tento příklad přidá druhý snímek a poté odstraní původní, takže zůstane jen nový.

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