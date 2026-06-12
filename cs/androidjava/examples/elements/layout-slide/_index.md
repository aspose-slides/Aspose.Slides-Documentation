---
title: Rozložení snímku
type: docs
weight: 20
url: /cs/androidjava/examples/elements/layout-slide/
keywords:
- příklad kódu
- rozložení snímku
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte rozložení snímků v Aspose.Slides pro Android: vyberte, aplikujte a přizpůsobte rozložení snímků, zástupce a master snímky pomocí příkladů v Javě pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak pracovat s **Layout Slides** v Aspose.Slides pro Android pomocí Javy. Rozložení snímku definuje design a formátování, které dědí běžné snímky. Můžete přidávat, přistupovat, klonovat a odstraňovat rozložení snímků a také čistit nepoužívané, aby se snížila velikost prezentace.

## **Přidat rozložení snímku**

Můžete vytvořit vlastní rozložení snímku pro definování opakovaně použitelného formátování. Například můžete přidat textové pole, které se objeví na všech snímcích používajících toto rozložení.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Vytvořte rozložení snímku s typem prázdného rozložení a vlastním názvem.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Přidejte textové pole do rozložení snímku.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Přidejte dva snímky pomocí tohoto rozložení; oba budou dědit text z rozložení.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Poznámka 1:** Rozložení snímků funguje jako šablona pro jednotlivé snímky. Můžete definovat společné prvky jednou a znovu je použít na mnoha snímcích.

> 💡 **Poznámka 2:** Když přidáte tvary nebo text do rozložení snímku, všechny snímky založené na tomto rozložení automaticky zobrazí tento sdílený obsah.

> Níže uvedený snímek ukazuje dva snímky, z nichž každý dědí textové pole ze stejného rozložení snímku.

![Slides Inheriting Layout Content](layout-slide-result.png)

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

## **Odebrat rozložení snímku**

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Získejte rozložení snímku podle typu a odeberte jej.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Odebrat nepoužitá rozložení snímků**

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Automaticky odstraňuje všechna rozložení snímků, která nejsou odkazována žádným snímkem.
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

        // Klonujte rozložení snímku na konec kolekce rozložení snímků.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Shrnutí:** Rozložení snímků jsou výkonným nástrojem pro správu jednotného formátování napříč snímky. Aspose.Slides poskytuje úplnou kontrolu nad vytvářením, správou a optimalizací rozložení snímků.