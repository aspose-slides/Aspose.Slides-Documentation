---
title: Dia
type: docs
weight: 10
url: /hu/java/examples/elements/slide/
keywords:
- kódpélda
- dia
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Diák vezérlése az Aspose.Slides for Java-ban: létrehozás, klónozás, átrendezés, átméretezés, háttér beállítása és átmenetek alkalmazása Java-val PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk példák sorozatát mutatja be, amelyek bemutatják, hogyan lehet dolgozni diákkal a **Aspose.Slides for Java** használatával. Megtanulja, hogyan lehet hozzáadni, elérni, klónozni, átrendezni és eltávolítani diákat a `Presentation` osztály segítségével.

Az alábbi minden példa egy rövid magyarázatot és egy Java kódrészletet tartalmaz.

## **Dia hozzáadása**

Új dia hozzáadásához először ki kell választani egy elrendezést. Ebben a példában a `Blank` elrendezést használjuk, és egy üres diát adunk hozzá a bemutatóhoz.

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

> 💡 **Megjegyzés:** Minden diaelrendezés egy mester diából származik, amely meghatározza az általános tervezést és a helyőrző struktúrát. Az alábbi kép bemutatja, hogyan vannak a mester diák és a hozzájuk tartozó elrendezések rendszerezve a PowerPointban.

![Mester és elrendezés kapcsolat](master-layout-slide.png)

## **Diák elérése index szerint**

A diákat az indexük alapján érheti el, vagy megtalálhatja egy dia indexét egy hivatkozás alapján. Ez hasznos a diák iterálásához vagy konkrét diák módosításához.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Adj egy másik üres diát.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Diák elérése index szerint.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Szerezze meg a dia indexét egy hivatkozásból, majd elérje index szerint.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia klónozása**

Ez a példa bemutatja, hogyan lehet egy meglévő diát klónozni. A klónozott dia automatikusan a dia gyűjtemény végére kerül.

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

## **Diák átrendezése**

A diák sorrendjét megváltoztathatja egy dia új indexre mozgatásával. Ebben az esetben egy klónozott diát áthelyezünk az első pozícióba.

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

## **Dia eltávolítása**

Dia eltávolításához egyszerűen hivatkozzon rá és hívja a `remove` metódust. Ez a példa egy második diát ad hozzá, majd eltávolítja az eredetit, csak az újat hagyva meg.

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