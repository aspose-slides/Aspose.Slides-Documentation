---
title: PowerPoint-Textabsätze auf Android verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatz-Einzug
- Hängender Einzug
- Absatz-Aufzählungszeichen
- nummerierte Liste
- Aufzählungsliste
- Absatz-Eigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Android via Java Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML‑Inhalte und Absatz‑Bilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für Android via Java stellt Text als Hierarchie von Textfeldern, Absätzen und Portionen dar:

* [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) repräsentiert den Textcontainer in einer Form und bietet Zugriff auf ihre Absatzsammlung.
* [IParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/) repräsentiert einen Absatz in einem Textfeld und bietet Zugriff auf seine Portionen und Absatzformatierung.
* [IPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/) repräsentiert einen Textlauf innerhalb eines Absatzes. Jede Portion kann eigenen Text und Zeichenformatierung besitzen.

Ein Absatz kann daher Text mit verschiedenen Schriften, Farben, Größen und anderen Formatierungen enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

### **Absätze mit mehreren Portionen erstellen**

Die folgenden Schritte erstellen ein Textfeld mit drei Absätzen, die jeweils drei Portionen enthalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie eine rechteckige [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) der Form zu.
5. Verwenden Sie den Standardabsatz und fügen Sie dem Textfeld zwei weitere [IParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/)‑Objekte hinzu.
6. Fügen Sie ausreichend [IPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/)‑Objekte hinzu, damit jeder Absatz drei Portionen enthält. Der Standardabsatz enthält bereits eine leere Portion.
7. Setzen Sie den Text jeder Portion.
8. Wenden Sie Zeichenformatierungen über [IPortion.getPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#getPortionFormat--) an.
9. Speichern Sie die geänderte Präsentation.

Dieses Android‑via‑Java‑Beispiel implementiert die Schritte:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Erstellen einer Aufzählungs‑ oder nummerierten Liste**

Aufzählungszeichen und Nummerierungen erleichtern das Durchsuchen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [IBulletFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/) definiert.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie über den Index auf die relevante Folie zu.
3. Fügen Sie der ausgewählten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) der Form zu.
5. Entfernen Sie den Standardabsatz aus dem Textfeld.
6. Erstellen Sie ein [Paragraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/paragraph/) für ein Symbol‑Aufzählungszeichen.
7. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setType-int-) auf [BulletType.Symbol](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/bullettype/) und geben Sie das Aufzählungszeichen‑Zeichen an.
8. Setzen Sie den Absatztext, Einzug, Aufzählungszeichenfarbe und Aufzählungszeichenhöhe.
9. Fügen Sie den Absatz dem Textfeld hinzu.
10. Erstellen Sie einen zweiten Absatz und setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setType-int-) auf [BulletType.Numbered](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/bullettype/).
11. Konfigurieren Sie den nummerierten Aufzählungsstil und fügen Sie den Absatz dem Textfeld hinzu.
12. Speichern Sie die Präsentation.

Dieses Android‑via‑Java‑Beispiel erstellt ein Symbol‑Aufzählungszeichen und ein nummeriertes Aufzählungszeichen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Bild‑Aufzählungszeichen lassen Sie ein benutzerdefiniertes Bild anstelle eines Symbols oder einer Nummer verwenden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie über den Index auf die relevante Folie zu.
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) hinzu und greifen Sie auf dessen [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) zu.
4. Entfernen Sie den Standardabsatz aus dem Textfeld.
5. Laden Sie das Aufzählungsbild und fügen Sie es der Bildsammlung der Präsentation als [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) hinzu.
6. Erstellen Sie ein [Paragraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/paragraph/) und setzen Sie dessen Text.
7. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setType-int-) auf [BulletType.Picture](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/bullettype/).
8. Weisen Sie das Bild über [IBulletFormat.getPicture](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#getPicture--) zu und setzen Sie die Aufzählungszeichenhöhe.
9. Fügen Sie den Absatz dem Textfeld hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieses Android‑via‑Java‑Beispiel erstellt ein Bild‑Aufzählungszeichen:

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

Setzen Sie [IParagraphFormat.setDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-), um Absätze auf verschiedenen Ebenen einer Liste zu platzieren. Die oberste Ebene hat eine Tiefe von `0`.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) und greifen Sie eine Folie ab.
2. Fügen Sie eine [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) hinzu und leeren Sie den Standardabsatz aus dessen Textfeld.
3. Erstellen Sie vier Absätze und konfigurieren Sie deren Aufzählungssymbole.
4. Setzen Sie deren [IParagraphFormat.setDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-)‑Werte auf `0`, `1`, `2` und `3`.
5. Fügen Sie die Absätze dem Textfeld hinzu und speichern Sie die Präsentation.

Dieses Android‑via‑Java‑Beispiel erstellt eine vierstufige Aufzählungsliste:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Verwenden Sie [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-), um die anfängliche Nummer für einen nummerierten Absatz festzulegen.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) und fügen Sie einer Folie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) hinzu.
2. Löschen Sie den Standardabsatz aus dem Textfeld der Form.
3. Erstellen Sie drei nummerierte Absätze.
4. Setzen Sie [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) für die jeweiligen Absätze auf `2`, `3` bzw. `7`.
5. Fügen Sie die Absätze dem Textfeld hinzu und speichern Sie die Präsentation.

Dieses Android‑via‑Java‑Beispiel weist jedem Absatz eine benutzerdefinierte Startnummer zu:

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

## **Absatzlayout und End‑Eigenschaften steuern**

### **Ersten Zeileneinzug festlegen**

Verwenden Sie [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-), um den Erstzeileneinzug eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-), wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-), wenn Sie nur die erste Zeile verschieben möchten.

Das folgende Beispiel erstellt mehrere Absätze und wendet verschiedene [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-)‑Werte an, um zu demonstrieren, wie der Erstzeileneinzug das Layout beeinflusst.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie die Ziel‑Folie ab.
3. Fügen Sie der Folie eine rechteckige [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie mehrere Absätze und setzen Sie unterschiedliche [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-)‑Werte für sie.
6. Fügen Sie die Absätze dem Textfeld hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieses Code‑Beispiel zeigt, wie Sie einen Absatz‑Einzug festlegen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Hängenden Einzug festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Übergeben Sie einen negativen Wert, um die erste Zeile nach links relativ zum Absatzkörper zu verschieben.

In der Praxis definiert [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) die linke Position des Absatzkörpers und [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, übergeben Sie einen positiven Wert an `setMarginLeft` und einen negativen Wert an `setIndent`.

Dieses Format ist nützlich für Bibliografien, Referenzen, Glossareinträge und andere Absätze, bei denen umbrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie die Ziel‑Folie ab.
3. Fügen Sie der Folie eine rechteckige [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie Absätze und übergeben Sie für jeden Absatz einen positiven Wert an [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-).
6. Übergeben Sie einen negativen Wert an [IParagraphFormat.setIndent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-), um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze dem Textfeld hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieses Code‑Beispiel zeigt, wie Sie einen hängenden Einzug für einen Absatz festlegen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Der hängende Einzug der Absätze](hanging_indent.png)

### **Endabsatz‑Lauf‑Eigenschaften festlegen**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) steuert die Formatierung der Absatzendmarke. Das folgende Beispiel weist der Endmarke des zweiten Absatzes eine Schriftgröße und eine lateinische Schrift zu:

1. Laden Sie eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) und greifen Sie eine Folie ab.
2. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) hinzu und leeren Sie dessen Standardabsatz.
3. Erstellen Sie zwei Absätze und fügen Sie Textportionen hinzu.
4. Erstellen Sie ein [PortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portionformat/) für die Endmarke des zweiten Absatzes.
5. Setzen Sie [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) und [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Weisen Sie das Format mit [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) zu und speichern Sie die Präsentation.

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

## **Absatzinhalt importieren und exportieren**

### **HTML‑Text in Absätze importieren**

Verwenden Sie [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-), um HTML‑Markup in Absätze und Portionen in einem Textfeld zu konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/).
2. Greifen Sie eine Folie ab und fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) hinzu.
3. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
4. Lesen Sie die Quell‑HTML‑Datei ein.
5. Übergeben Sie die HTML‑Zeichenkette an [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Speichern Sie die geänderte Präsentation.

Dieses Android‑via‑Java‑Beispiel importiert HTML in ein Textfeld:

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

Verwenden Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-), um einen ausgewählten Absatzbereich als HTML zu exportieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie die Folie ab und finden Sie das [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/), das den Text enthält.
3. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) der Form zu.
4. Rufen Sie [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) mit dem Start‑Absatzindex und der Anzahl der zu exportierenden Absätze auf.
5. Schreiben Sie die zurückgegebene HTML‑Zeichenkette in eine Datei.

Dieses Android‑via‑Java‑Beispiel exportiert alle Absätze aus dem ersten Textobjekt:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
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

### **Einen Absatz als Bild rendern**

[IParagraph.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/#getImage--) rendert einen einzelnen Absatz direkt und gibt ein [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) zurück. Speichern Sie das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) in einer Datei oder einem Stream. Sie müssen die umgebende Form nicht rendern oder ein Bitmap manuell zuschneiden.

[IParagraph.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/#getImage--) kann `null` zurückgeben, wenn der Absatz in seiner übergeordneten Sammlung nicht gefunden wird, keine gültigen Rendergrenzen hat oder nicht gerendert werden kann. Überprüfen Sie das Ergebnis, bevor Sie es speichern, und geben Sie das zurückgegebene Bild nach dem Gebrauch frei.

#### **Einen Absatz im Standardmaßstab rendern**

Angenommen, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, bei der das erste Objekt ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

Das folgende Beispiel rendert den zweiten Absatz in einem regulären Textfeld im Standardmaßstab und speichert das zurückgegebene Bild im PNG‑Format. Der `finally`‑Block sorgt dafür, dass das Bild korrekt freigegeben wird.

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

#### **Einen Absatz in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [IParagraph.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-), die die Parameter `float scaleX` und `float scaleY` akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in der ersten Zelle mit dem doppelten Standard‑Breiten‑ und Höhenwert und speichert das Ergebnis als PNG‑Bild.

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

Ein Skalierungsfaktor von `1` hält diese Achse bei ihrer Standardpixelgröße. Zum Beispiel erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa doppelt so groß sind wie die Standardabmessungen, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen im Allgemeinen schärferen Text für Zoom‑ oder Hochauflösungs‑Ausgaben, erhöhen jedoch den Speicherverbrauch und die Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie identische Faktoren, um das Seitenverhältnis des Absatzes beizubehalten; unterschiedliche horizontale und vertikale Faktoren strecken das Ergebnis unabhängig voneinander.

Das Rendern einer gesamten Form mit [IShape.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getImage--) bleibt nützlich, wenn die Ausgabe das Füll‑, Rand‑ oder sonstige visuelle Kontext der Form enthalten muss. Für ein reines Absatz‑Bild verwenden Sie [IParagraph.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Kann ich das Zeilenumbruch innerhalb eines Textfeldes vollständig deaktivieren?**

Ja. Setzen Sie [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) auf, um das Umbrechen zu deaktivieren, sodass Zeilen nicht an den Rändern des Textfeldes umbrechen.

**Wie kann ich die genauen Folien‑Grenzen eines bestimmten Absatzes erhalten?**

Verwenden Sie [IParagraph.getRect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/#getRect--), um das Begrenzungsrechteck des Absatzes abzurufen. [IPortion.getRect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#getRect--) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatz‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) ist eine Absatz‑Ebene‑Einstellung und gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich die Korrektur‑Sprache für einen Teil eines Absatzes festlegen?**

Ja. Setzen Sie [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) für einzelne Portionen, sodass ein Absatz Text in mehreren Sprachen enthalten kann.