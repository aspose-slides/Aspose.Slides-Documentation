---
title: Verwalten von Aufzählungs- und nummerierten Listen in Präsentationen in Java
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/java/manage-lists/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs‑, Bild‑, mehrstufige und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Java erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für Java ermöglicht das Erstellen und Formatieren von Aufzählungs‑ und nummerierten Listen in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listenelement ist ein Absatz, dessen Aufzählungs‑Einstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die Methode [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) , um Listeneinstellungen auf Absatzebene zu erhalten. Der Haupteinstiegspunkt ist [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) , der ein [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/)‑Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellen
- ein Bildaufzählungszeichen erstellen
- eine mehrstufige Liste erstellen, indem die Absatz‑Tiefe gesetzt wird
- eine nummerierte Liste erstellen
- die Listformatierung in einer bestehenden Präsentation prüfen und ändern
- die tatsächlichen Listenzeichen und Nummern zusammen mit dem Absatztext auslesen

## **Erstellen einer Aufzählungsliste**

Um eine Aufzählungsliste zu erstellen, fügen Sie [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/)‑Objekte zu einem [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) hinzu und setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) auf [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol). Anschließend können Sie [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--) und [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) festlegen, um das Aussehen der Aufzählungszeichen zu steuern.

Der folgende Java‑Code zeigt, wie man in einer Folie eine Aufzählungsliste erstellt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Symbol‑Aufzählungszeichen](symbol_bullets.png)

## **Erstellen einer nummerierten Liste**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) auf [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered). Sie können außerdem ein Nummerierungsformat mit [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) wählen oder [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) festlegen, wenn die Liste bei einem anderen Wert als 1 beginnen soll.

Der folgende Java‑Code zeigt, wie man in einer Folie eine nummerierte Liste erstellt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die nummerierten Aufzählungszeichen](numbered_bullets.png)

## **Erstellen eines Bildaufzählungszeichens**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungs‑Symbol durch ein Bild zu ersetzen. Bild‑Aufzählungszeichen funktionieren am besten mit einfachen Bildern, die auch in kleiner Größe gut lesbar bleiben, z. B. Icons oder kleine transparente PNG‑Dateien.

{{% alert color="info" title="Note" %}}
Idealerweise, wenn Sie das reguläre Aufzählungs‑Symbol durch ein Bild ersetzen möchten, sollten Sie eine einfache Grafik mit transparentem Hintergrund wählen. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungs‑Symbole.

Beachten Sie, dass das Bild auf eine sehr kleine Größe verkleinert wird. Aus diesem Grund empfehlen wir dringend, ein Bild auszuwählen, das auch in kleiner Darstellung klar und visuell wirksam bleibt, wenn es als Aufzählungszeichen in einer Liste verwendet wird.
{{% /alert %}}

Um ein Bild‑Aufzählungszeichen zu erstellen, fügen Sie ein Bild zu [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) hinzu und weisen Sie das zurückgegebene Bildobjekt [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) zu. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) auf [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine "image.png":

![Ein Bild für die Aufzählungszeichen](picture_for_bullets.png)

Der folgende Java‑Code zeigt, wie man Bild‑Aufzählungszeichen in einer Folie erstellt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Bild‑Aufzählungszeichen](picture_bullets.png)

## **Erstellen einer mehrstufigen Liste**

Verwenden Sie [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-), um Listenelemente auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw.

Der folgende Java‑Code zeigt, wie man eine mehrstufige Aufzählungsliste erstellt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die mehrstufige Liste](multilevel_list.png)

## **Ändern einer vorhandenen Liste**

Um die Listformatierung in einer bestehenden Präsentation zu ändern, greifen Sie auf den Zielabsatz zu und aktualisieren seine [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--)‑Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können auch zum Prüfen oder Ändern von Listen, die aus einer PPT‑, PPTX‑ oder ODP‑Datei geladen wurden, verwendet werden.

Der folgende Java‑Code ändert den ersten Absatz in einem Textbereich, so dass er einen nummerierten Listenstil verwendet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tatsächliche Aufzählungswerte auslesen**

Beim Extrahieren von Präsentationsinhalten sollten Listenkennzeichen zusammen mit dem Absatztext erhalten bleiben. Rufen Sie [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) auf und greifen Sie auf [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) zu, um das effektive Aufzählungsformat zu erhalten. Prüfen Sie dessen [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) bevor Sie [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) auslesen.

Für nummerierte Listen unterscheiden Sie diese drei Werte:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) bestimmt das Format, z. B. arabische Zahlen mit anschließendem Punkt oder Kleinbuchstaben mit Punkt.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) gibt die Startnummer für eine Gruppe nummerierter Absätze an.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) liefert das formatierte Zeichen für einen bestimmten Absatz. Beispiel: Das zweite Element in einer Liste, die bei 5 beginnt, gibt `6.` zurück.

Behalten Sie [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--) bei jedem Absatz bei, um dessen Verschachtelungsebene zu erhalten. Das tatsächliche Zeichen codiert nicht die gesamte Hierarchie: Ein verschachteltes Element kann `c.` zurückgeben, anstatt eines kombinierten Labels wie `6.c.`.

Das folgende eigenständige Beispiel erstellt Listen, speichert sie in einer Präsentation und lädt die Präsentation erneut, um für jeden Absatz den Text, die Tiefe, den Aufzählungstyp und den tatsächlichen Wert auszugeben. Das kleine blaue Bildzeichen wird aus einem Inline‑SVG erzeugt.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Erstelle ein Bild‑Aufzählungszeichen ohne externe Bilddatei.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Die Quelllisten werden unten angezeigt.

![Listen, die bei 5 beginnen, verschachtelte Buchstaben‑ und römische Nummern‑Elemente, ein Symbol‑Markierung, ein Absatz ohne Aufzählungszeichen und ein blaues Bild‑Markierung](actual_bullet_values.png)

Der Bericht stimmt mit den in PowerPoint angezeigten Markierungen überein:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Für [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) gibt [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null` zurück, nicht eine leere Zeichenkette. Diese Typen sollten separat behandelt werden: Der erstgenannte hat keinen Marker, während der letztere das separate Extrahieren des Aufzählungsbildes erfordert. Ein Bild‑Aufzählungszeichen kann nicht allein durch das Extrahieren eines Text‑Markers reproduziert werden.

## **FAQ**

**Können Aufzählungs‑ und nummerierte Listen in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides bewahrt die Listformatierung, wenn das Zielformat die entsprechende Textanordnung und Aufzählungsfunktionen unterstützt.

**Kann ich Listen in bestehenden Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den Zielabsatz zu, prüfen oder aktualisieren Sie dessen [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--)‑Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listenelementen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Achten Sie darauf, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.