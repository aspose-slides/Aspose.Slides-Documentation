---
title: Verwalten von PowerPoint-Textabsätzen in Java
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
  - Text hinzufügen
  - Absatz hinzufügen
  - Text verwalten
  - Absatz verwalten
  - Aufzählungszeichen verwalten
  - Absatzeinzug
  - Hängeeinzug
  - Absatz-Aufzählungszeichen
  - nummerierte Liste
  - Aufzählungsliste
  - Absatzeigenschaften
  - HTML importieren
  - Text zu HTML
  - Absatz zu HTML
  - Absatz zu Bild
  - Text zu Bild
  - Absatz exportieren
  - PowerPoint
  - Präsentation
  - Java
  - Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Java Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML-Inhalte und Absatz-Bilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für Java stellt Text als eine Hierarchie von Textrahmen, Absätzen und Portionen dar:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) stellt den Textbehälter in einer Form dar und bietet Zugriff auf ihre Absatzsammlung.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) stellt einen Absatz in einem Textrahmen dar und bietet Zugriff auf seine Portionen und die Absatzformatierung.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) stellt einen Textlauf innerhalb eines Absatzes dar. Jede Portion kann ihren eigenen Text und Zeichenformatierung besitzen.

Ein Absatz kann daher Text mit unterschiedlichen Schriften, Farben, Größen und weiterer Formatierung enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

Erstellen Sie Absätze im Textrahmen einer Form und verwenden Sie Portionen, um einzelne Textläufe zu formatieren. Dieser Abschnitt zeigt, wie mehrere Portionen innerhalb jedes Absatzes kombiniert und unterschiedliche Farben, Schriftgrößen und Stile angewendet werden.

### **Absätze mit mehreren Portionen erstellen**

Das folgende Java‑Beispiel erstellt drei Absätze, von denen jeder drei Textläufe in der von [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) zurückgegebenen Sammlung enthält. Es verwendet den Standardabsatz und seine leere Portion erneut und fügt anschließend die übrigen Absätze und Portionen hinzu. Die Formatierung wird über [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) angewendet: Die erste Portion jedes Absatzes ist rot, fett und 15 pt; die zweite ist blau, kursiv und 18 pt. Die dritte Portion behält die Standardformatierung bei:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aufzählungen und nummerierte Listen erstellen**

Organisieren Sie Absatztext in Listen mit Symbolen, Nummern oder benutzerdefinierten Bildern. Die Beispiele in diesem Abschnitt behandeln Aufzählungsformatierung, mehrstufige Listen und benutzerdefinierte Startnummern.

### **Aufzählung oder nummerierte Liste erstellen**

Aufzählungszeichen und Nummerierung erleichtern das Scannen zusammengehöriger Elemente. In Aspose.Slides werden Listeneinstellungen über [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) definiert.

Dieses Java‑Beispiel fügt einem Textrahmen ein Symbol‑Aufzählungszeichen und ein nummeriertes Element hinzu. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) wählt den Aufzählungs‑Typ, während [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) das Symbol liefert und [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) den Nummerierungsstil auswählt. Beide Elemente verwenden schwarze Aufzählungszeichen mit einer Höhe von 100 % und einem Absatz‑Einzug von 25 pt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bild‑Aufzählungszeichen verwenden**

Bild‑Aufzählungszeichen ermöglichen die Verwendung eines benutzerdefinierten Bildes anstelle eines Symbols oder einer Zahl.

Dieses Java‑Beispiel fügt der Bildsammlung der Präsentation ein Bild als [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) hinzu und verwendet es als Absatz‑Aufzählungszeichen. Es ruft [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) auf, um ein Bild‑Aufzählungszeichen zu verwenden, und weist das Bild über [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) zu. [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) wird auf 100 % gesetzt, um das Aufzählungszeichen relativ zum Absatztext zu skalieren:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Mehrstufige Liste erstellen**

Setzen Sie [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-), um Absätze auf verschiedenen Ebenen einer Liste zu platzieren. Die oberste Ebene hat die Tiefe `0`.

Dieses Java‑Beispiel weist vier Absätzen Werte von 0 bis 3 für [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) zu und erstellt so eine Hierarchie innerhalb eines Textrahmens. Jeder Absatz verwendet ein Symbol‑Aufzählungszeichen, wobei [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) zwischen einem runden Aufzählungszeichen und einem Bindestrich wechselt, um benachbarte Ebenen zu unterscheiden:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Nummerierte Listeneinträge mit benutzerdefinierten Werten beginnen**

Verwenden Sie [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-), um die Anfangsnummer für einen nummerierten Absatz festzulegen.

Dieses Java‑Beispiel setzt [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) auf Nummerierung für drei Absätze und weist [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) die Werte 2, 3 und 7 zu. Der Startwert wird für jeden Absatz separat konfiguriert, sodass die angezeigten Nummern Lücken überspringen können:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Absatzlayout und Endeigenschaften steuern**

Passen Sie Absatz‑Abstände und Einzüge an, um die Position der ersten Zeile und der umbrochenen Zeilen zu steuern. Sie können das Absatz‑Endzeichen auch separat von den sichtbaren Textportionen formatieren.

### **Erste‑Zeilen‑Einzug festlegen**

Verwenden Sie die Methode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-), um den Erstzeileneinzug eines Absatzes zu steuern. Diese Einstellung verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-), wenn Sie den gesamten Absatz verschieben möchten. Verwenden Sie [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-), wenn Sie nur die erste Zeile verschieben wollen.

Das folgende Beispiel gibt drei Absätzen denselben [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) von 20 pt und [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) Werte von 0, 20 und 40 pt. Die ersten Zeilen beginnen bei progressiv größeren Versätzen, während umbrochene Zeilen denselben linken Rand behalten:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Erstzeileneinzug der Absätze](first_line_indent.png)

### **Hängeeinzug festlegen**

Ein Hängeeinzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Eigenschaft [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Setzen Sie `Indent` auf einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) die linke Position des Absatzkörpers, und [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) die Position der ersten Zeile relativ zu diesem Rand. Um einen Hängeeinzug zu erzeugen, setzen Sie einen positiven `MarginLeft`‑Wert und einen negativen `Indent`‑Wert.

Diese Formatierung ist nützlich für Bibliographien, Verweise, Glossareinträge und andere Absätze, bei denen umbrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

Das folgende Java‑Beispiel kombiniert [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) Werte von 40 pt und 60 pt mit [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) Werten von -20 pt bzw. -30 pt. In jedem Absatz beginnt die erste Zeile links von den umbrochenen Zeilen; der zweite Absatz hat einen tieferen Hängeeinzug:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Hängeeinzug der Absätze](hanging_indent.png)

### **Endabsatz‑Lauf‑Eigenschaften festlegen**

Die Methode [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) steuert die Formatierung des Absatz‑Endzeichens. Das folgende Beispiel erstellt ein [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) mit [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) auf 48 pt und [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) auf Times New Roman. Es weist dieses Format dem Endzeichen des zweiten Absatzes zu, ohne die sichtbaren Textportionen zu verändern:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gerenderte Zeilen zählen**

Für Absatzregeln, die automatisches Umbrechen und Interpunktion am Zeilenende beeinflussen, siehe [Zeilenumbruch steuern](/slides/de/java/text-formatting/#control-line-breaking) und [Hängende Interpunktion steuern](/slides/de/java/text-formatting/#control-hanging-punctuation).

Verwenden Sie [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) zum Zählen der Zeilen, die ein Absatz nach der Textlayout‑Berechnung einnimmt, einschließlich automatischem Umbrechen. Das ist nützlich, wenn Sie Textlänge und Layout in Präsentationsvorlagen prüfen.

Ein Absatz ist ein Element in [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) und kann mehrere gerenderte Zeilen beanspruchen. Ein expliziter Zeilenumbruch innerhalb eines Absatzes erzeugt eine neue Zeile, ohne einen weiteren Absatz zu erstellen. Automatisches Umbrechen erzeugt Zeilen basierend auf der verfügbaren Breite, ohne explizite Zeilenumbruch‑Zeichen in den Text einzufügen. Das Zählen von Absätzen oder Zeilenumbruch‑Zeichen liefert daher nicht die gerenderte Zeilenzahl.

Das folgende Beispiel erstellt eine Textform, zählt ihre Zeilen, verengt die Form und ersetzt anschließend den Text durch eine kürzere Zeichenkette. Das Beispiel aktiviert das Umbrechen über [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) und deaktiviert Autofit über [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-), sodass die Formbreite das Umbrechen steuert, ohne den Text automatisch zu verkleinern oder die Form zu skalieren. Jede Messung verwendet [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--). Formabmessungen werden in Punkten angegeben. Abschließend fügt das Beispiel einen weiteren Absatz hinzu und summiert die Zeilenzahlen über den gesamten Textrahmen hinweg.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Mit diesem Text und diesen Abmessungen erhöht das Verengen der Form die Zeilenzahl, während das Ersetzen des Textes durch die kurze Zeichenkette sie reduziert. Exakte Zahlen können je nach verfügbarer Schrift, Ersatzschrift, Schriftgröße, Rändern, Einzügen, Umbrechen und Autofit‑Einstellungen variieren. Verwenden Sie die für die Zielumgebung vorgesehenen Schriften und Layout‑Einstellungen, wenn Sie eine Vorlage prüfen.

Die Zeilenzahl allein bestimmt nicht, ob Text über den Container hinausläuft. Auch die verfügbare Höhe, Zeilenhöhen, Absatz‑ und Zeilenabstände sowie das Verhalten von Autofit sind relevant; selbst eine einzelne Zeile kann die verfügbare Breite überschreiten, wenn das Umbrechen deaktiviert ist.

## **Absatzinhalt importieren und exportieren**

Verwenden Sie HTML, um Text in eine Präsentation zu übernehmen oder vorhandene Absätze für die Verwendung außerhalb zu exportieren. Dieser Abschnitt zeigt außerdem, wie einzelne Absätze als Bilder gerendert werden können, einschließlich Absätzen in Tabellenzellen.

### **HTML‑Text in Absätze importieren**

Verwenden Sie [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-), um HTML‑Markup in Absätze und Portionen eines Textrahmens zu konvertieren.

Dieses Java‑Beispiel liest HTML aus einer Datei und übergibt das Markup an [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). Es löscht den Standardabsatz des Textrahmens, sodass der Rahmen nur den importierten Inhalt enthält. Die rechteckige Form lässt an jeder Folienkante einen Rand von 10 pt.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Absatztext nach HTML exportieren**

Verwenden Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-), um einen ausgewählten Absatzbereich als HTML zu exportieren. Wenn Sie Präsentationstext auf einer Website wiederverwenden, möchten Sie möglicherweise lokale Hervorhebungen beibehalten, ohne die Schrift, Größe oder Textfeld‑Stile der Präsentation zu übernehmen. Setzen Sie [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-), um zu steuern, wie weit der Exporter der Formatierungserb­ung folgt.

Laden Sie [die Beispielpräsentation](text-inheritance.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Ihre erste Folie enthält ein Textfeld mit dem Text „Inherited text; explicit red 18pt“. Der Eingabe‑Text verwendet bewusst mehrere Formatierungsebenen:

- Der Standard‑Textstil der Präsentation liefert Calibri in Größe 28 pt.
- Der Textstil des Textrahmens der ersten Ebene liefert blauen Text und Kursivschrift.
- Der Absatz setzt fett gedruckten Text explizit.
- Die zweite Portion, „explicit red 18pt“, setzt roten Text und Größe 18 pt explizit.

Das folgende vollständige Beispiel exportiert dieselben Absätze dreimal. Es übergibt [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) an die Export‑Methode und schreibt jedes Ergebnis in eine separate UTF‑8‑HTML‑Datei:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Der erzeugte HTML‑Code enthält das folgende CSS für die erste Portion, „Inherited text; “. Die Tabelle listet die relevanten Deklarationen auf; weitere erzeugte Eigenschaften wurden zur Übersicht weggelassen.

| Ausgabe | Relevantes CSS für die erste Portion | Erscheinungsbild |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blauer, fetter, kursiver Text bei 28 pt in Calibri, falls diese Schrift verfügbar ist. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blauer, fetter, kursiver Text; die umgebende Seite oder der Browser liefert die Schriftart und Größe. |
| `ParagraphOnly.html` | `font-weight:bold` | Fetter Text; die umgebende Seite oder der Browser liefert Schriftart, Größe, Farbe und kursive Formatierung. |

Die zweite Portion behält `color:#ff0000`, `font-size:18pt` und `font-weight:bold` in allen drei Ausgaben bei. Sie behält außerdem Kursivschrift bei „All“ und „TextBox“, jedoch nicht bei „ParagraphOnly“. Das Einschränken der Vererbung entfernt also nicht die explizit einem Absatz oder einer Portion zugewiesene Formatierung.

Öffnen Sie die Dateien im selben Browser, um sie zu vergleichen. In den beiden eingeschränkten Modi werden weggelassene CSS‑Eigenschaften durch die Stile der Zielseite oder Standard‑Browser‑Stile aufgelöst, sodass das endgültige Aussehen vom Einsatzort des HTML abhängt.

### **Absatz als Bild rendern**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) rendert einen einzelnen Absatz direkt und gibt ein [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) zurück. Speichern Sie das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) in einer Datei oder einem Stream. Sie müssen nicht die umgebende Form rendern oder ein Bitmap manuell zuschneiden.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) kann `null` zurückgeben, wenn der Absatz in seiner übergeordneten Sammlung nicht gefunden wird, keine gültigen Render‑Grenzen hat oder nicht gerendert werden kann. Prüfen Sie das Ergebnis, bevor Sie es speichern, und geben Sie das zurückgegebene Bild nach Gebrauch frei.

#### **Absatz mit Standardskala rendern**

Das Beispiel verwendet eine Präsentation mit einer Folie, deren erste Form ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

Das folgende Beispiel wählt den zweiten Absatz (Index 1) aus und ruft [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) ohne Skalierungsparameter auf. Es prüft, ob die Form den erforderlichen Absatz enthält und ob das Rendern ein Bild liefert, bevor es [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) zum Speichern im PNG‑Format aufruft. Der `finally`‑Block gibt das Bild nach Gebrauch frei.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Das Absatzbild](paragraph_to_image_output.png)

#### **Absatz in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-), die die Parameter `float scaleX` und `float scaleY` akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in der ersten Zelle bei doppelter Standardbreite und -höhe und speichert das Ergebnis als PNG‑Bild.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Ein Skalierungsfaktor von `1` behält die jeweilige Achse bei ihrer Standard‑Pixelgröße. Zum Beispiel erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa doppelt so groß sind wie die Standardmaße, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen im Allgemeinen schärferen Text für Zoom‑ oder hochauflösende Ausgaben, erhöhen jedoch Speicherverbrauch und Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Absatzes zu bewahren; unterschiedliche horizontale und vertikale Faktoren strecken die Ausgabe unabhängig voneinander.

Das Rendern einer kompletten Form mit [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) bleibt sinnvoll, wenn die Ausgabe das Füll‑, Rahmen‑ oder andere visuelle Kontext‑Elemente der Form enthalten soll. Für ein reines Absatz‑Bild verwenden Sie [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Kann ich das Zeilenumbruch in einem Textrahmen komplett deaktivieren?**

Ja. Setzen Sie [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) auf, um das Umbrechen zu deaktivieren, sodass Zeilen nicht an den Rändern des Textrahmens umbrochen werden.

**Wie erhalte ich die genauen On‑Slide‑Grenzen eines bestimmten Absatzes?**

Verwenden Sie [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) zur Ermittlung des Begrenzungsrechtecks des Absatzes. [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatz‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) ist eine Absatz‑Ebene‑Einstellung und gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

Um Portionen mit unterschiedlichen Schriftgrößen innerhalb einer Zeile vertikal auszurichten, siehe [Align Fonts Within a Line](/slides/de/java/text-formatting/#align-fonts-within-a-line).

**Kann ich die Rechtschreib‑Sprache für einen Teil eines Absatzes festlegen?**

Ja. Setzen Sie [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) für einzelne Portionen, sodass ein Absatz Text in mehreren Sprachen enthalten kann.