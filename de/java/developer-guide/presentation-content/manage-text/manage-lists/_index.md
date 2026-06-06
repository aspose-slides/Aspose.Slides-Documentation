---
title: Verwalten von Aufzählungs‑ und Nummerierungslisten in Präsentationen in Java
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/java/manage-lists/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
- benutzerdefiniertes Aufzählungszeichen
- mehrstufige Liste
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

Aspose.Slides für Java ermöglicht das Erstellen und Formatieren von Aufzählungs‑ und Nummerierungslisten in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listenelement ist ein Absatz, dessen Aufzählungseinstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/#getParagraphFormat--)‑Methode, um auf listenbezogene Absatz‑Einstellungen zuzugreifen. Der zentrale Einstiegspunkt ist [IParagraphFormat.getBullet](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#getBullet--), der ein [IBulletFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/)‑Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellt
- einen Bildbullet erstellt
- eine mehrstufige Liste erstellt, indem die Absatztiefe festgelegt wird
- eine nummerierte Liste erstellt
- die Listformatierung in einer vorhandenen Präsentation überprüft und ändert

## **Aufzählungsliste erstellen**

Um eine Aufzählungsliste zu erstellen, fügen Sie [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/)‑Objekte zu einem [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) hinzu und setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setType-byte-) auf [BulletType.Symbol](https://reference.aspose.com/slides/de/java/com.aspose.slides/bullettype/#Symbol). Anschließend können Sie [IBulletFormat.setChar](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#getColor--) und [IBulletFormat.setHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setHeight-float-) festlegen, um das Erscheinungsbild der Aufzählungszeichen zu steuern.

```java
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

![Die Symbolaufzählungen](symbol_bullets.png)

## **Nummerierte Liste erstellen**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setType-byte-) auf [BulletType.Numbered](https://reference.aspose.com/slides/de/java/com.aspose.slides/bullettype/#Numbered). Sie können außerdem ein Nummerierungsformat mit [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) auswählen oder [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) festlegen, wenn die Liste mit einem anderen Wert als 1 beginnen soll.

Der folgende Java‑Code zeigt, wie man eine nummerierte Liste in einer Folie erstellt:

```java
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

![Die nummerierten Aufzählungen](numbered_bullets.png)

## **Bildbullet erstellen**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungszeichen durch ein Bild zu ersetzen. Bildbullets funktionieren am besten mit einfachen Grafiken, die in kleiner Größe lesbar bleiben, z. B. Icons oder kleine transparente PNG‑Dateien.

{{% alert color="primary" %}}
Ideal ist es, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, ein einfaches Bild mit transparentem Hintergrund zu wählen. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungssymbole.

Beachten Sie, dass das Bild auf eine sehr kleine Größe herunter skaliert wird. Deshalb empfehlen wir dringend, ein Bild auszuwählen, das auch in kleiner Größe klar und visuell wirksam bleibt, wenn es als Aufzählungszeichen in einer Liste verwendet wird.
{{% /alert %}}

Um einen Bildbullet zu erstellen, fügen Sie ein Bild zu [Presentation.getImages](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getImages--) hinzu und weisen Sie das zurückgegebene Bildobjekt [IBulletFormat.getPicture](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#getPicture--) zu. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibulletformat/#setType-byte-) auf [BulletType.Picture](https://reference.aspose.com/slides/de/java/com.aspose.slides/bullettype/#Picture), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine "image.png":

![Ein Bild für die Aufzählungen](picture_for_bullets.png)

Der folgende Java‑Code zeigt, wie man Bildbullets in einer Folie erstellt:

```java
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

![Die Bildaufzählungen](picture_bullets.png)

## **Mehrstufige Liste erstellen**

Verwenden Sie [IParagraphFormat.setDepth](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setDepth-short-), um Listenelemente auf unterschiedlichen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw.

Der folgende Java‑Code zeigt, wie man eine mehrstufige Aufzählungsliste erstellt:

```java
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

## **Vorhandene Liste ändern**

Um die Listformatierung in einer vorhandenen Präsentation zu ändern, greifen Sie auf den Zielabsatz zu und aktualisieren dessen [IParagraphFormat.getBullet](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#getBullet--)‑Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können auch zum Überprüfen oder Ändern von Listen verwendet werden, die aus einer PPT‑, PPTX‑ oder ODP‑Datei geladen wurden.

```java
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

## **FAQ**

**Können Aufzählungs‑ und Nummerierungslisten in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides bewahrt die Listformatierung, wenn das Zielformat die entsprechenden Textlayout‑ und Aufzählungsfunktionen unterstützt.

**Kann ich Listen in vorhandenen Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den Zielabsatz zu, prüfen oder aktualisieren Sie dessen [IParagraphFormat.getBullet](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#getBullet--)‑Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listenelementen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.