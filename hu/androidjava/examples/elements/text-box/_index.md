---
title: Szövegdoboz
type: docs
weight: 40
url: /hu/androidjava/examples/elements/text-box/
keywords:
- kódrészlet
- szövegdoboz
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Szövegdobozok kezelése az Aspose.Slides for Android-ban: szöveg hozzáadása, formázása, igazítása, tördelése, automatikus méretezése és stílusozása Java-val PPT, PPTX és ODP prezentációkhoz."
---

Az Aspose.Slides-ben egy **szövegdoboz** egy `AutoShape` segítségével valósul meg. Szinte bármely alakzat tartalmazhat szöveget, de egy tipikus szövegdoboz nincs kitöltése vagy kerete, és csak a szöveget jeleníti meg.

Ez az útmutató bemutatja, hogyan lehet programozottan hozzáadni, elérni és eltávolítani a szövegdobozokat.

## **Szövegdoboz hozzáadása**

A szövegdoboz egyszerűen egy `AutoShape`, amelynek nincs kitöltése vagy kerete, és formázott szöveget tartalmaz. Íme, hogyan hozható létre:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Hozzon létre egy négyszög alakzatot (alapértelmezés szerint kitöltve kerettel és szöveg nélkül).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Távolítsa el a kitöltést és a keretet, hogy tipikus szövegdoboznak nézzen ki.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Állítsa be a szövegformázást.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Állítsa be a tényleges szövegtartalmat.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Megjegyzés:** Bármely `AutoShape`, amely nem üres `TextFrame`-et tartalmaz, szövegdobozként funkcionálhat.

## **Szövegdobozok elérése tartalom alapján**

Az összes olyan szövegdoboz megtalálásához, amely egy adott kulcsszót (például "Slide") tartalmaz, iteráljon végig az alakzatokon, és ellenőrizze a szövegüket:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Csak az AutoShape-ek tartalmazhatnak szerkeszthető szöveget.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Tegyen valamit a megfelelő szövegdobozzal.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Szövegdobozok eltávolítása tartalom alapján**

Ez a példa megtalálja és törli az első dián lévő összes szövegdobozt, amely egy adott kulcsszót tartalmaz:

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

> 💡 **Tanács:** Mindig készítsen másolatot az alakzatgyűjteményről, mielőtt módosítaná azt iteráció közben, hogy elkerülje a gyűjtemény módosítási hibákat.