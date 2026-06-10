---
title: Hiperhivatkozás
type: docs
weight: 130
url: /hu/androidjava/examples/elements/hyperlink/
keywords:
- kódpélda
- hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása és kezelése az Aspose.Slides for Android-ban: szöveg, alakzatok és képek hivatkozásai, célok és műveletek beállítása PPT, PPTX és ODP esetén Java példákkal."
---
Ez a cikk bemutatja a hivatkozások hozzáadását, elérését, eltávolítását és frissítését alakzatokon az **Aspose.Slides for Android via Java** használatával.

## **Hivatkozás hozzáadása**

Hozzon létre egy téglalap alakzatot, amely egy külső weboldalra mutató hivatkozással rendelkezik.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Hivatkozás elérése**

Olvassa be a hivatkozás információkat az alakzat szövegrészéből.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Hivatkozás eltávolítása**

Távolítsa el a hivatkozást az alakzat szövegéből.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Hivatkozás frissítése**

Módosítsa egy meglévő hivatkozás célját. Használja a `HyperlinkManager`-t a már hivatkozást tartalmazó szöveg módosításához, amely a PowerPoint hivatkozások biztonságos frissítését utánzva történik.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // A meglévő szövegben lévő hiperhivatkozás módosítása a HyperlinkManager segítségével kell történjen
        // a HyperlinkManager használatával, a tulajdonság közvetlen beállítása helyett.
        // Ez utánzata annak, ahogyan a PowerPoint biztonságosan frissíti a hiperhivatkozásokat.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```