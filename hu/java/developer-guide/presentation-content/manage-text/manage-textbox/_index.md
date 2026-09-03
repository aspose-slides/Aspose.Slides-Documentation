---
title: Szövegdobozok kezelése prezentációkban Java használatával
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/java/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Szövegdobozok létrehozása, azonosítása, formázása és frissítése PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával."
---
## **Bevezetés**

Az Aspose.Slides for Java‑ban a dia szövegét olyan szövegkeretekben tárolják, amelyek alakzatokhoz tartoznak. Az [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) interfész képviseli a leggyakoribb szöveget tartalmazó alakzatot, és a szövegét a [IAutoShape.getTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#getTextFrame--) metóduson keresztül teszi elérhetővé.

{{% alert color="info" title="Megjegyzés" %}}
Minden automatikus alakzat implementálja az [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/), de nem minden alakzat automatikus alakzat, vagy támogat szövegkeretet. Létező prezentáció feldolgozásakor ellenőrizze, hogy egy alakzat implementálja-e az [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) interfészt, mielőtt hozzáférne a szövegéhez.
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

Szövegdoboz létrehozásához adjon hozzá egy automatikus alakzatot a diára, szúrjon be szöveget a szövegkeretébe, és mentse a prezentációt. Az alábbi példa egy téglalap alakú szövegdobozt hoz létre:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) metódusnak átadott koordinátákat és méreteket pontban mérik. Az [IAutoShape.addTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) inicializálja a szövegkeretet a megadott szöveggel.

## **Szövegdoboz alakzat ellenőrzése**

Használja az [IAutoShape.isTextBox](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#isTextBox--) metódust annak meghatározására, hogy egy automatikus alakzat szövegdobozként van‑e kezelve. Ez hasznos, ha egy prezentáció szöveget tartalmazó és kizárólag grafikus automatikus alakzatokat is tartalmaz.

![Egy szövegdoboz és egy alakzat](istextbox.png)

Az alábbi példa minden automatikus alakzatot vizsgál meg egy prezentációban:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Egy frissen hozzáadott automatikus alakzat nem tekintendő szövegdoboznak, amíg nem tartalmaz nem üres szöveget. A szöveget megadhatja az [IAutoShape.addTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) vagy az [ITextFrame.setText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#setText-java.lang.String-) használatával. Üres karakterlánc hozzáadása vagy hozzárendelése azt eredményezi, hogy az [IAutoShape.isTextBox](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#isTextBox--) `false`‑t ad vissza:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Az első két hívás `true`‑t, az utolsó két hívás `false`‑t ír ki.

## **A szövegkeretet birtokló alakzat megtalálása**

Általános szövegfeldolgozó kód kaphat egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)‑t anélkül, hogy tudná, melyik prezentációs objektum tartalmazza. Használja a csak‑olvasásra szánt [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentShape--) metódust a tulajdonos [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/)‑hez való visszalépéshez.

Automatikus alakzat vagy más szöveget tartalmazó alakzat birtokában lévő szövegkeret esetén az [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentShape--) visszaadja a tulajdonost, az [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentCell--) pedig `null`‑t. A visszaadott értéket ellenőrizze, mielőtt használja. A forma‑ és táblázat‑cellában lévő tulajdonosok, köztük a SmartArt‑csomópontokhoz kapcsolódó alakzatok azonosításához lásd a [Szöveg keresése és cseréje](/slides/hu/java/search-and-replace-text/) oldalát.

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) metódus oszlopokra osztja a szövegkeretet, míg az [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) beállítja az oszlopok közti hézagot pontban. Mindkét beállítás az [ITextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/) része, és megváltoztatható egy meglévő szövegdoboz szövegkeretén keresztül. A szöveg áramlik az oszlopok között ugyanabban az alakzatban; nem folytatódik egy másik alakzatra.

Az alábbi példa háromoszlopos szövegdobozt hoz létre 10 pontos oszlopközökkel, menti a prezentációt, és visszaolvassa a beállításokat a kimeneti fájlból:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Szöveg kinyerése egyedi oszlopokból**

Használja az [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#splitTextByColumns--) metódust a meglévő szövegkeretben szereplő vizuális oszlopok szövegének lekéréséhez. A metódus minden oszlophoz egy karakterláncot ad vissza, oszlop‑alapú olvasási sorrendben. Egy egyoszlopos szövegkeret egy elemmel rendelkező tömböt eredményez, a üres oszlop egy üres karakterlánccal van jelölve. A karakterláncok csak egyszerű szöveget tartalmaznak; a rész‑szintű formázás nem kerül megőrzésre.

Ez akkor hasznos, ha:
- Kinyerni a szöveget, miközben megőrzöd az oszlop‑alapú olvasási sorrendet.
- Indexelni vagy összehasonlítani a többoszlopos diák tartalmát.
- Minden oszlopot külön fájlba, adatbázis‑mezőbe vagy más célhelyre exportálni.
- Megvizsgálni, hogy a szöveget hogyan osztja újra az oszlopszám ([ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setColumnCount-int-)), a távolság ([ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-)), a betűtípus vagy a szövegkeret méretének módosítása után.

A metódus a jelenlegi [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)‑ben elosztott szöveget jelenti; nem áramoltja automatikusan a szöveget különálló alakzatok vagy szövegdobozok között. Az oszlopelrendezés függhet a rendelkezésre álló betűkészletektől és egyéb szöveg‑elrendezési beállításoktól, ezért ügyeljen arra, hogy a szükséges betűkészletek elérhetők legyenek, ha a konzisztens eredmények fontosak.

Az alábbi példa betölt egy prezentációt, megtalálja az első többoszlopos automatikus alakzatot szövegkerettel, kiolvassa a konfigurált oszlopszámot, és minden oszlop szövegét külön fájlba írja. A szövegkeretet nem biztosító alakzatok kihagyásra kerülnek:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Szöveg frissítése**

A szöveg frissítéséhez a teljes prezentációban járja be a diákat és az alakzatokat, válassza ki az automatikus alakzatokat, majd szerkessze a szövegrétegeiket. A rész‑szintű munka lehetővé teszi a szöveg és a karakterformázás egyidejű módosítását.

Az alábbi példa minden `years` előfordulást `months`‑ra cserél az automatikus alakzat‑szövegben, és a módosított részeket félkövérre állítja:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez a bejárás csak az automatikus alakzatok szövegét módosítja. A táblákban, diagramokban, SmartArt‑ban vagy csoportos alakzatokban tárolt szöveghez a megfelelő objektumok saját gyűjteményeinek bejárása szükséges.

## **Szövegdoboz hozzáadása hiperhivatkozással**

Egy hiperhivatkozás egy adott szövegrétegre rendelhető, így csak ez a szöveg válik kattinthatóvá. Használja az [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) metódust a rész külső URL‑hez való társításához.

Az alábbi példa hivatkozott szöveget hoz létre, és elmenti egy prezentációba:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi a különbség egy szövegdoboz és egy szöveg‑helyfoglaló között a mester‑ vagy elrendezés‑dián?**

Egy [placeholder](/slides/hu/java/manage-placeholder/) örökölheti a pozícióját és formázását egy [master slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterslide/) vagy [layout slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslide/)‑tól. Egy hagyományos szövegdoboz független alakzat a dián, ahol létre lett hozva, és nem kap placeholder viselkedést, ha az elrendezés megváltozik.

**Hogyan cserélhetem le a szöveget anélkül, hogy a diagramok, táblák vagy SmartArt szövegét módosítanám?**

Korlátozza a bejárást azokra az alakzatokra, amelyek implementálják az [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/)‑t, ahogy az a Szöveg frissítése példában látható. A diagramok, táblák és SmartArt a saját objektummodeljükben tárolják a szöveget, ezért ez a ciklus nem módosítja őket.