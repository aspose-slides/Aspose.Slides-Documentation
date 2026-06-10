---
title: Szövegdoboz
type: docs
weight: 40
url: /hu/java/examples/elements/text-box/
keywords:
- kód példa
- szövegdoboz
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Szövegdobozok kezelése az Aspose.Slides for Java-ban: szöveg hozzáadása, formázása, igazítása, sortördelése, automatikus méretezése és stílusozása Java-val PPT, PPTX és ODP prezentációkhoz."
---
Az Aspose.Slides‑ben egy **szövegdoboz** egy `AutoShape`‑ként jelenik meg. Gyakorlatilag bármely alakzat tartalmazhat szöveget, de egy tipikus szövegdoboz nem rendelkezik kitöltéssel vagy szegéllyel, és csak szöveget jelenít meg.

Ez az útmutató elmagyarázza, hogyan lehet programozott módon szövegdobozokat hozzáadni, elérni és eltávolítani.

## **Szövegdoboz hozzáadása**

A szövegdoboz egyszerűen egy `AutoShape`, amely nem rendelkezik kitöltéssel vagy szegéllyel, és formázott szöveget tartalmaz. Íme, hogyan hozható létre egy:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Hozzon létre egy téglalap alakzatot (alapértelmezés szerint kitöltve szegéllyel, szöveg nélkül).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Távolítsa el a kitöltést és a szegélyt, hogy tipikus szövegdoboznak tűnjön.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Állítsa be a szöveg formázását.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Rendelje hozzá a tényleges szövegtartalmat.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Megjegyzés:** Bármely `AutoShape`, amely nem üres `TextFrame`‑et tartalmaz, funkcionálhat szövegdobozként.

## **Szövegdobozok elérése tartalom alapján**

Az összes olyan szövegdoboz megtalálásához, amely egy adott kulcsszót (például "Slide") tartalmaz, járja be az alakzatokat, és ellenőrizze a szövegüket:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Csak az AutoShape-ok tartalmazhatnak szerkeszthető szöveget.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Végezze el a megfelelő szövegdoboz feldolgozását.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Szövegdobozok eltávolítása tartalom alapján**

Ez a példa megtalálja és törli az első dián található összes szövegdobozt, amely egy adott kulcsszót tartalmaz:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Tipp:** Mindig készítsen másolatot az alakzatgyűjteményről, mielőtt módosítaná azt az iteráció során, hogy elkerülje a gyűjtemény módosítási hibákat.