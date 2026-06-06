---
title: Verwalten von Aufzählungs- und Nummerierungslisten in Präsentationen mit JavaScript
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/nodejs-java/manage-lists/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol-Aufzählungszeichen
- Bild-Aufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs-, Bild-, mehrstufige und nummerierte Listen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Node.js über Java erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für Node.js über Java ermöglicht das Erstellen und Formatieren von Aufzählungs‑ und Nummerierungslisten in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listeneintrag ist ein Absatz, dessen Aufzählungseinstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die Klasse [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/), um die listenbezogenen Einstellungen auf Absatzebene zuzugreifen. Der zentrale Einstiegspunkt ist `Paragraph.getParagraphFormat().getBullet()`, der ein [BulletFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bulletformat/)-Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie Sie:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellen
- ein Bild‑Aufzählungszeichen erstellen
- eine mehrstufige Liste durch Festlegen der Absatz‑Tiefe erstellen
- eine nummerierte Liste erstellen
- die Listformatierung in einer vorhandenen Präsentation inspizieren und ändern

## **Erstellen einer Aufzählungsliste**

Um eine Aufzählungsliste zu erstellen, fügen Sie [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/)-Objekte zu einem [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) hinzu und setzen `BulletFormat.setType` auf [BulletType.Symbol](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bullettype/). Anschließend können Sie `BulletFormat.setChar`, `BulletFormat.getColor` und `BulletFormat.setHeight` verwenden, um das Aussehen des Aufzählungszeichens zu steuern.

Der folgende JavaScript‑Code demonstriert, wie Sie in einer Folie eine Aufzählungsliste erstellen:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Symbol‑Aufzählungszeichen](symbol_bullets.png)

## **Erstellen einer nummerierten Liste**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie `BulletFormat.setType` auf [BulletType.Numbered](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bullettype/). Sie können außerdem ein Nummerierungsformat mit `BulletFormat.setNumberedBulletStyle` wählen oder `BulletFormat.setNumberedBulletStartWith` festlegen, wenn die Liste nicht bei 1 beginnen soll.

Der folgende JavaScript‑Code zeigt, wie Sie in einer Folie eine nummerierte Liste erstellen:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die nummerierten Aufzählungszeichen](numbered_bullets.png)

## **Erstellen eines Bild‑Aufzählungszeichens**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungszeichen durch ein Bild zu ersetzen. Bild‑Aufzählungszeichen funktionieren am besten mit einfachen Grafiken, die auch in kleiner Größe gut lesbar bleiben, z. B. Icons oder kleine transparente PNG‑Dateien.

{{% alert color="primary" %}}
Idealerweise wählen Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, eine einfache Grafik mit transparentem Hintergrund. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungszeichen.
  
Beachten Sie, dass das Bild auf eine sehr kleine Größe skaliert wird. Aus diesem Grund empfehlen wir dringend, ein Bild auszuwählen, das auch in kleiner Darstellung klar und optisch wirksam bleibt.
{{% /alert %}}

Um ein Bild‑Aufzählungszeichen zu erstellen, fügen Sie ein Bild zu einer [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) mit `Presentation.getImages().addImage` hinzu und weisen Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)-Objekt `BulletFormat.getPicture().setImage` zu. Setzen Sie `BulletFormat.setType` auf [BulletType.Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/bullettype/), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine „image.png“:

![Ein Bild für die Aufzählungszeichen](picture_for_bullets.png)

Der folgende JavaScript‑Code zeigt, wie Sie in einer Folie Bild‑Aufzählungszeichen erstellen:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Das Ergebnis:

![Die Bild‑Aufzählungszeichen](picture_bullets.png)

## **Erstellen einer mehrstufigen Liste**

Verwenden Sie `ParagraphFormat.setDepth`, um Listenelemente auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 liegt darunter usw.

Der folgende JavaScript‑Code zeigt, wie Sie eine mehrstufige Aufzählungsliste erstellen:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die mehrstufige Liste](multilevel_list.png)

## **Ändern einer vorhandenen Liste**

Um die Listformatierung in einer bestehenden Präsentation zu ändern, greifen Sie auf den gewünschten Absatz zu und aktualisieren dessen `ParagraphFormat.getBullet`‑Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können zum Inspizieren oder Modifizieren von Listen, die aus einer PPT‑, PPTX‑ oder ODP‑Datei geladen wurden, verwendet werden.

Der folgende JavaScript‑Code ändert den ersten Absatz in einem TextFrame, sodass er einen nummerierten Listenstil verwendet:

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Können Aufzählungs‑ und Nummerierungslisten in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides behält die Listformatierung bei, wenn das Zielformat die entsprechenden Textlayout‑ und Aufzählungsfunktionen unterstützt.

**Kann ich Listen in vorhandenen Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den gewünschten Absatz zu, inspizieren oder aktualisieren Sie dessen `ParagraphFormat.getBullet`‑Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listenelementen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.