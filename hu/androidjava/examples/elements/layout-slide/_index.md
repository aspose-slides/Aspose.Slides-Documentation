---
title: Elrendezési dia
type: docs
weight: 20
url: /hu/androidjava/examples/elements/layout-slide/
keywords:
- kód példa
- elrendezési dia
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Mester elrendezési diák az Aspose.Slides for Android-ban: válasszon, alkalmazzon és testreszabjon diaelrendezéseket, helyőrzőket és mastereket Java példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan dolgozhat az Aspose.Slides for Android Java‑on keresztül a **Layout Slides** használatával. Az elrendezési dia meghatározza a normál diák által örökölt tervezést és formázást. Hozzáadhat, elérhet, klónozhat és eltávolíthat elrendezési diát, valamint megtisztíthatja a nem használtakat a prezentáció méretének csökkentése érdekében.

## **Elrendezési dia hozzáadása**

Létrehozhat egy egyéni elrendezési diát az újrahasználható formázás meghatározásához. Például hozzáadhat egy szövegmezőt, amely a layout használatával minden dián megjelenik.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Hozzon létre egy elrendezési diát egy üres elrendezéstípussal és egy egyéni névvel.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Adjon hozzá egy szövegmezőt az elrendezési diához.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Adjon hozzá két diát ezzel az elrendezéssel; mindkettő örökölni fogja a szöveget az elrendezésből.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Az elrendezési diák sablonként működnek az egyes diák számára. A közös elemeket egyszer meghatározhatja, és sok dián újra felhasználhatja.

> 💡 **Note 2:** Amikor alakzatokat vagy szöveget ad hozzá egy elrendezési diához, az azon alapuló összes dia automatikusan megjeleníti ezt a megosztott tartalmat.  
> Az alábbi képernyőfelvétel két diát mutat, amelyek mindegyike ugyanabból az elrendezési diából örököl egy szövegmezőt.

![Diák, amelyek elrendezési tartalmat örökölnek](layout-slide-result.png)

## **Elrendezési dia elérése**

Az elrendezési diák index vagy elrendezéstípus (például `Blank`, `Title`, `SectionHeader`, stb.) szerint érhetők el.

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Hozzáférés egy elrendezési diához index alapján.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Hozzáférés egy elrendezési diához típus szerint.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Elrendezési dia eltávolítása**

Eltávolíthat egy adott elrendezési diát, ha már nincs rá szükség.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Szerezzen be egy elrendezési diát típus szerint és távolítsa el.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Nem használt elrendezési diák eltávolítása**

A prezentáció méretének csökkentése érdekében érdemes eltávolítani azokat az elrendezési diákat, amelyeket egyetlen normál dia sem használ.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Automatikusan eltávolítja az összes olyan elrendezési diát, amelyet egyetlen dia sem hivatkozik.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Elrendezési dia klónozása**

Megkettőzheti egy elrendezési dia másolatát az `addClone` metódus segítségével.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Szerezzen be egy meglévő elrendezési diát típus szerint.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Klónozza az elrendezési diát a elrendezési diák gyűjteményének végére.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Összefoglalás:** Az elrendezési diák hatékony eszközök a diák közötti konzisztens formázás kezeléséhez. Az Aspose.Slides teljes irányítást biztosít az elrendezési diák létrehozása, kezelése és optimalizálása felett.