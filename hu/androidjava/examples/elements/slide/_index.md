---
title: Dia
type: docs
weight: 10
url: /hu/androidjava/examples/elements/slide/
keywords:
- kód példa
- dia
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje a diákat az Aspose.Slides for Android-ban: hozza létre, klónozza, rendezze újra, méretezze, állítson be háttereket, és alkalmazzon áttűnéseket Java-val PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk példákkal mutatja be, hogyan lehet a diákkal dolgozni az **Aspose.Slides for Android via Java** használatával. Megtanulja, hogyan kell diát hozzáadni, elérni, klónozni, újrarendezni és eltávolítani a `Presentation` osztály segítségével.

Az alábbi minden példa rövid magyarázatot tartalmaz, amelyet egy Java kódrészlet követ.

## **Dia hozzáadása**

Új dia hozzáadásához először ki kell választani egy elrendezést. Ebben a példában a `Blank` elrendezést használjuk, és egy üres diát adunk a prezentációhoz.

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

> 💡 **Megjegyzés:** Minden diaelrendezés egy mesterdiából származik, amely meghatározza az általános megjelenést és a helyfoglalók struktúráját. Az alábbi kép szemlélteti, hogyan vannak a mesterdiák és a hozzájuk tartozó elrendezések szervezve a PowerPointban.

![Mester és elrendezés kapcsolata](master-layout-slide.png)

## **Diák elérése index alapján**

A diákat elérheti index szerint, vagy megtalálhatja egy dia indexét egy hivatkozás alapján. Ez hasznos a diák bejárásához vagy konkrét diák módosításához.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Adj hozzá egy újabb üres diát.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Diák elérése index alapján.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Szerezd meg a dia indexét egy hivatkozásból, majd index alapján érj hozzá.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia klónozása**

Ez a példa bemutatja, hogyan lehet egy létező diát klónozni. A klónozott dia automatikusan a diakollekció végére kerül.

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

## **Diák újrarendezése**

A diák sorrendjét megváltoztathatja egy dia új indexre mozgatásával. Ebben az esetben egy klónozott diát helyezünk az első pozícióba.

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

Dia eltávolításához egyszerűen hivatkozzon rá és hívja a `remove` metódust. Ez a példa egy második diát ad hozzá, majd eltávolítja az eredetit, így csak az új marad.

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