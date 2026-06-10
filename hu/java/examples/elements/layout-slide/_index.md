---
title: Elrendezési dia
type: docs
weight: 20
url: /hu/java/examples/elements/layout-slide/
keywords:
- kód példa
- elrendezési dia
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java fő elrendezési diái: válasszon, alkalmazzon és testreszabjon diaképeket, helyőrzőket és mástereket Java példákkal PPT, PPTX és ODP bemutatókhoz."
---
Ez a cikk bemutatja, hogyan dolgozhat **Layout Slides** használatával az Aspose.Slides for Java-ban. Egy elrendezési dia meghatározza a normál diák által örökölt tervezést és formázást. Hozzáadhat, elérhet, klónozhat és eltávolíthat elrendezési diákat, valamint megtisztíthatja a nem használtakat a bemutató méretének csökkentése érdekében.

## **Elrendezési dia hozzáadása**

Létrehozhat egy egyéni elrendezési diát az újrahasználható formázás meghatározásához. Például hozzáadhat egy szövegdobozt, amely minden diához megjelenik, ha ezt az elrendezést használja.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Hozzon létre egy elrendezési diát üres elrendezéstípussal és egy egyéni névvel.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Adjon hozzá egy szövegdobozt az elrendezési diához.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Adjon hozzá két diát ezzel az elrendezéssel; mindkettő örökli a szöveget az elrendezésből.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Megjegyzés 1:** Az elrendezési diák egyedi diák sablonjaként működnek. Egyszer definiálhatja a közös elemeket, és sok dián újra felhasználhatja őket.
> 💡 **Megjegyzés 2:** Ha alakzatot vagy szöveget ad hozzá egy elrendezési diához, akkor az azon a dián alapuló összes dia automatikusan megjeleníti ezt a közös tartalmat.
> Az alábbi képernyőkép két diát mutat, amelyek mindegyike ugyanabból az elrendezési diából örököl egy szövegdobozt.

![Diák, amelyek az elrendezési tartalmat öröklik](layout-slide-result.png)

## **Elrendezési dia elérése**

Az elrendezési diák index vagy elrendezéstípus (például `Blank`, `Title`, `SectionHeader` stb.) szerint érhetők el.

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Index alapján elrendezési dia elérése.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Típus alapján elrendezési dia elérése.
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
        // Típus alapján elrendezési dia lekérdezése és eltávolítása.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Nem használt elrendezési diák eltávolítása**

A bemutató méretének csökkentése érdekében érdemes eltávolítani azokat az elrendezési diákat, amelyeket egyetlen normál dia sem használ.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Automatikusan eltávolítja az összes elrendezési diát, amelyet egyetlen dia sem használ.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Elrendezési dia klónozása**

Az elrendezési diát a `addClone` metódus használatával duplikálhatja.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Lekér egy meglévő elrendezési diát típus alapján.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Klónozza az elrendezési diát az elrendezési diágyűjtemény végére.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Összefoglalás:** Az elrendezési diák hatékony eszközök a diák közötti konzisztens formázás kezelésére. Az Aspose.Slides teljes irányítást biztosít az elrendezési diák létrehozása, kezelése és optimalizálása felett.