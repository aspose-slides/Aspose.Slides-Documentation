---
title: Szövegdobozok kezelése prezentációkban Androidon
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Szövegdobozok létrehozása, azonosítása, formázása és frissítése PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android via Java használatával."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java esetén a dia szövege szövegkeretekben van tárolva, amelyek alakzatokhoz tartoznak. Az [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) interfész a leggyakoribb szöveget tartalmazó alakzatot képviseli, és a szöveget a [IAutoShape.getTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) metóduson keresztül teszi elérhetővé.

{{% alert color="info" title="Note" %}}
Minden automatikus alakzat megvalósítja az [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) interfészt, de nem minden alakzat automatikus alakzat vagy támogat szövegkeretet. Egy meglévő prezentáció feldolgozása során ellenőrizze, hogy az alakzat implementálja-e az [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) interfészt, mielőtt a szövegéhez hozzáférne.
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

Szövegdoboz létrehozásához adjon egy automatikus alakzatot a diához, szöveget a szövegkerethez, majd mentse a prezentációt. Az alábbi példa egy téglalap alakú szövegdobozt hoz létre:

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

Az [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) metódusnak átadott koordinátákat és méreteket pontban mérik. Az [IAutoShape.addTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) inicializálja a szövegkeretet a megadott szöveggel.

## **Szövegdoboz alakzat ellenőrzése**

Használja az [IAutoShape.isTextBox](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#isTextBox--) metódust annak meghatározásához, hogy egy automatikus alakzat szövegdobozként legyen kezelve. Ez akkor hasznos, ha egy prezentáció szöveget tartalmazó és csak grafikai célú automatikus alakzatokat egyaránt tartalmaz.

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

Az újból hozzáadott automatikus alakzat csak akkor tekinthető szövegdoboznak, ha nem üres szöveget tartalmaz. Ezt a szöveget megadhatja az [IAutoShape.addTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) vagy az [ITextFrame.setText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) segítségével. Üres karakterlánc hozzáadása vagy hozzárendelése azt eredményezi, hogy az [IAutoShape.isTextBox](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#isTextBox--) `false` értéket ad:

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

Az első két hívás `true`-t, az utolsó két hívás `false`-t ír ki.

## **Az a forma megtalálása, amely a szövegkeretet birtokolja**

Általános szövegfeldolgozó kód kaphat egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)-et anélkül, hogy tudná, melyik prezentációs objektum tartalmazza azt. Használja a csak‑olvasható [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentShape--) metódust a tulajdonos [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/)-hez való visszafelé navigáláshoz.

Automatikus alakzat vagy más szöveget tartalmazó alakzat által birtokolt szövegkeret esetén az [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentShape--) visszaadja a tulajdonost, míg az [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null` értéket ad. A visszakapott értéket mindig ellenőrizze, mielőtt hozzáférne. Az alakzat‑ és táblacella‑tulajdonosok, valamint a SmartArt‑csomópontokhoz kapcsolódó alakzatok azonosításához lásd a [Search and Replace Text](/slides/hu/androidjava/search-and-replace-text/) szekciót.

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) metódus oszlopokra osztja a szövegkeretet, míg az [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) a pontban mérve beállítja az oszlopok közti távolságot. Mindkét beállítás az [ITextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/) része, és egy meglévő szövegdoboz szövegkeretén keresztül módosítható. A szöveg az oszlopok között ugyanazon alakzaton belül áramlik át; nem folytatódik egy másik alakzatba.

Az alábbi példa háromoszlopos szövegdobozt hoz létre 10 pont oszlopközökkel, elmenti a prezentációt, majd visszaolvassa a mentett beállításokat a kimeneti fájlból:

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

Használja az [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) metódust a meglévő szövegkeretben minden vizuális oszlophoz rendelt szöveg lekéréséhez. A metódus minden oszlophoz egy karakterláncot ad vissza, oszlop‑alapú olvasási sorrendben. Egy egyoszlopos szövegkeret egy elemű tömböt eredményez, egy üres oszlop pedig egy üres karakterlánccal van reprezentálva. A karakterláncok csak egyszerű szöveget tartalmaznak; a rész‑szintű formázás nem kerül megőrzésre.

Ez akkor hasznos, amikor:

- Szöveget szeretne kinyerni úgy, hogy megmaradjon a oszlop‑alapú olvasási sorrend.
- Többoszlopos diák tartalmát indexelni vagy összehasonlítani kívánja.
- Minden oszlopot külön fájlba, adatbázismezőbe vagy más célhelyre szeretné exportálni.
- Szeretné megvizsgálni, hogyan oszlik újra a szöveg a [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), a [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), a betűtípus vagy a szövegkeret mérete módosítása után.

A metódus a jelenlegi [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) belsejében elosztott szöveget jelenti; nem áramoltatja automatikusan a szöveget különálló alakzatok vagy szövegdobozok között. Az oszlopeloszlás függhet a rendelkezésre álló betűtípusoktól és egyéb szöveg‑elrendezési beállításoktól, ezért győződjön meg róla, hogy a szükséges betűtípusok elérhetők, ha konzisztens eredményekre van szükség.

Az alábbi példa betölti a prezentációt, megtalálja az első többoszlopos automatikus alakzatot szövegkerettel, kiolvassa a konfigurált oszlopszámot, majd minden oszlop szövegét külön fájlba írja. A szövegkeretet nem biztosító alakzatok kihagyásra kerülnek.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

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
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
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

A szöveg frissítéséhez járja be a diákat és alakzatokat, válassza ki az automatikus alakzatokat, majd szerkessze a szövegrészeiket. A rész‑szintű szerkesztés lehetővé teszi a szöveg és a karakterformázás módosítását egyaránt.

Az alábbi példa minden `years` előfordulást `months`‑ra cserél az automatikus alakzatok szövegében, és a módosított részeket félkövérre állítja:

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

Ez a bejárás csak az automatikus alakzatok szövegét frissíti. A táblák, diagramok, SmartArt vagy csoportos alakzatok szövege külön collection‑ökön keresztüli bejárást igényel.

## **Szövegdoboz hozzáadása hiperhivatkozással**

Egy hiperhivatkozás egy bizonyos szövegrészhez rendelhető, így csak az a szöveg lesz kattintható. Használja az [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) metódust a rész külső URL‑hez való kapcsolásához.

Az alábbi példa létrehoz egy hivatkozott szöveget, majd elmenti egy prezentációba:

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

**Mi a különbség egy szövegdoboz és egy szöveg‑helyőrző között egy mester‑ vagy elrendezés‑dián?**

A [placeholder](/slides/hu/androidjava/manage-placeholder/) örökölheti pozícióját és formázását egy [master slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterslide/) vagy [layout slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslide/)‑től. Egy szokásos szövegdoboz egy önálló alakzat a dián, ahol létrehozták, és nem kap helyőrző‑viselkedést a layout változásakor.

**Hogyan cserélhetem ki a szöveget anélkül, hogy a diagramok, táblák vagy SmartArt szövege megváltozna?**

Korlátozza a bejárást csak azokra az alakzatokra, amelyek implementálják az [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/)‑t, ahogyan az a Szöveg frissítése példában látható. A diagramok, táblák és SmartArt saját objektummodellben tárolják a szöveget, ezért azt a ciklus nem módosítja.