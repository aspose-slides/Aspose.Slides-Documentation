---
title: Rozložení snímku
type: docs
weight: 20
url: /cs/java/examples/elements/layout-slide/
keywords:
- ukázka kódu
- rozložení snímku
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Mistrské rozložení snímků v Aspose.Slides pro Java: vybírejte, aplikujte a přizpůsobujte rozložení snímků, zástupce a hlavní snímky pomocí Java ukázek pro prezentace PPT, PPTX a ODP."
---
Tento článek demonstruje, jak pracovat s **Layout Slides** v Aspose.Slides pro Java. Rozložení snímku definuje návrh a formátování, které dědí běžné snímky. Můžete přidávat, přistupovat, klonovat a odstraňovat rozložení snímků a také vyčistit nepoužívané, abyste snížili velikost prezentace.

## **Přidat rozložení snímku**

Můžete vytvořit vlastní rozložení snímku pro definování opakovaně použitelného formátování. Například můžete přidat textové pole, které se zobrazí na všech snímcích používajících toto rozložení.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Vytvořte snímek rozložení s prázdným typem rozložení a vlastním názvem.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Přidejte textové pole do snímku rozložení.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Přidejte dva snímky s použitím tohoto rozložení; oba zdědí text z rozložení.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Poznámka 1:** Rozložení snímků fungují jako šablony pro jednotlivé snímky. Můžete definovat společné prvky jednou a znovu je použít napříč mnoha snímky.
> 
> 💡 **Poznámka 2:** Když přidáte tvary nebo text do rozložení snímku, všechny snímky založené na tomto rozložení automaticky zobrazí tento sdílený obsah. Níže uvedený snímek ukazuje dva snímky, každý dědí textové pole ze stejného rozložení snímku.

![Snímky dědící obsah rozložení](layout-slide-result.png)

## **Přístup k rozložení snímku**

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Přístup k rozložení snímku podle indexu.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Přístup k rozložení snímku podle typu.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit rozložení snímku**

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Získejte rozložení snímku podle typu a odstraňte jej.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit nepoužitá rozložení snímků**

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Automaticky odstraňuje všechna rozložení snímků, která nejsou referencována žádným snímkem.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Klonovat rozložení snímku**

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Získejte existující rozložení snímku podle typu.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Naklonujte rozložení snímku na konec kolekce rozložení snímků.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Shrnutí:** Rozložení snímků jsou výkonné nástroje pro správu konzistentního formátování napříč snímky. Aspose.Slides umožňuje plnou kontrolu nad vytvářením, správou a optimalizací rozložení snímků.