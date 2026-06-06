---
title: Verwalten von Aufzählungs- und nummerierten Listen in Präsentationen auf Android
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/androidjava/manage-lists/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol-Aufzählungszeichen
- Bildaufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs-, Bild-, mehrstufige und nummerierte Listen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides for Android via Java ermöglicht das Erstellen und Formatieren von Aufzählungs‑ und nummerierten Listen in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listenelement ist ein Absatz, dessen Aufzählungseinstellungen über dessen Absatzformat gesteuert werden.

Verwenden Sie die [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--)‑Methode, um auf die listenbezogenen Einstellungen auf Absatzebene zuzugreifen. Der Haupteinstiegspunkt ist [IParagraphFormat.getBullet](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), das ein [IBulletFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/)‑Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellen
- eine Bildaufzählung erstellen
- eine mehrstufige Liste erstellen, indem die Absatztiefe festgelegt wird
- eine nummerierte Liste erstellen
- die Listformatierung in einer vorhandenen Präsentation prüfen und ändern

## **Aufzählungsliste erstellen**

Um eine Aufzählungsliste zu erstellen, fügen Sie Absätze zu einem [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) hinzu und setzen [IBulletFormat.setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) auf [BulletType.Symbol](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/bullettype/). Anschließend können Sie [IBulletFormat.setChar](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#getColor--) und [IBulletFormat.setHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) festlegen, um das Aussehen der Aufzählungszeichen zu steuern.

Der folgende Java‑Code demonstriert, wie man in einer Folie eine Aufzählungsliste erstellt:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
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

## **Nummerierte Liste erstellen**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) auf [BulletType.Numbered](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/bullettype/). Sie können auch ein Nummerierungsformat mit [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) auswählen oder [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) festlegen, wenn die Liste mit einem anderen Wert als 1 beginnen soll.

Der folgende Java‑Code zeigt, wie man in einer Folie eine nummerierte Liste erstellt:

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

![Die nummerierten Aufzählungszeichen](numbered_bullets.png)

## **Bildaufzählung erstellen**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungszeichen durch ein Bild zu ersetzen. Bildaufzählungen funktionieren am besten mit einfachen Grafiken, die in kleiner Größe lesbar bleiben, z. B. Symbolen oder kleinen transparenten PNG‑Dateien.

{{% alert color="primary" %}}
Idealerweise, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, sollten Sie eine einfache Grafik mit transparentem Hintergrund wählen. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungszeichen.

Beachten Sie, dass das Bild auf eine sehr kleine Größe skaliert wird. Aus diesem Grund empfehlen wir dringend, ein Bild auszuwählen, das auch in kleiner Größe klar und visuell wirksam als Aufzählungszeichen in einer Liste bleibt.
{{% /alert %}}

Um eine Bildaufzählung zu erstellen, fügen Sie ein Bild zu [Presentation.getImages](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getImages--) hinzu und weisen das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/)‑Objekt [IBulletFormat.getPicture](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#getPicture--) zu. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) auf [BulletType.Picture](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/bullettype/), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine "image.png":

![Ein Bild für die Aufzählungszeichen](picture_for_bullets.png)

Der folgende Java‑Code zeigt, wie man in einer Folie Bildaufzählungen erstellt:

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

Verwenden Sie [IParagraphFormat.setDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-), um Listenelemente auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw.

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

Um die Listformatierung in einer bestehenden Präsentation zu ändern, greifen Sie auf den Zielabsatz zu und aktualisieren dessen [IParagraphFormat.getBullet](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)‑Einstellungen. Die gleichen Methoden, die zum Erstellen von Listen verwendet werden, können zum Prüfen oder Ändern von Listen verwendet werden, die aus einer PPT-, PPTX- oder ODP-Datei geladen wurden.

Der folgende Java‑Code ändert den ersten Absatz in einem Text‑Frame, sodass er einen nummerierten Liststil verwendet:

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

**Können Aufzählungs‑ und nummerierte Listen in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides bewahrt die Listformatierung, wenn das Zielformat die entsprechenden Textlayout‑ und Aufzählungsfunktionen unterstützt.

**Kann ich Listen in bestehenden Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den Zielabsatz zu, prüfen oder aktualisieren Sie dessen [IParagraphFormat.getBullet](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)‑Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listenelementen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.