---
title: Hivatkozás
type: docs
weight: 130
url: /hu/java/examples/elements/hyperlink/
keywords:
- kód példa
- hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása és kezelése az Aspose.Slides for Java-ban: szövegre, alakzatokra és képekre mutató hivatkozások, célok és műveletek beállítása PPT, PPTX és ODP fájlokhoz Java példákkal."
---
Ez a cikk bemutatja a hivatkozások hozzáadását, elérését, eltávolítását és frissítését alakzatokon a **Aspose.Slides for Java** használatával.

## **Hivatkozás hozzáadása**

Hozzon létre egy téglalap alakzatot, amely hivatkozással mutat egy külső weboldalra.

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

Olvassa ki a hivatkozási információkat az alakzat szövegrésszel kapcsolatban.

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

Törölje a hivatkozást az alakzat szövegéből.

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

Módosítsa egy meglévő hivatkozás célját. Használja a `HyperlinkManager`‑t a szöveg módosításához, amely már tartalmaz hivatkozást, ez a PowerPoint módjára biztonságosan frissíti a hivatkozásokat.

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

        // A meglévő szövegben lévő hivatkozás módosítása a HyperlinkManager használatával kell történjen
        // HyperlinkManager-t kell használni a tulajdonság közvetlen beállítása helyett.
        // Ez a PowerPoint módjára biztonságosan frissíti a hivatkozásokat.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```