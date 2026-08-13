---
title: Verwalten von Aufzählungs- und nummerierten Listen in Präsentationen in Java
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/java/manage-lists/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- nummerierte Liste
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs-, Bild-, mehrstufige und nummerierte Listen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides for Java ermöglicht das Erstellen und Formatieren von Aufzählungs‑ und Nummerierungslisten in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listeneintrag ist ein Absatz, dessen Aufzählungseinstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides.iparagraph/#getParagraphFormat--)‑Methode, um auf listenbezogene Einstellungen auf Absatzebene zuzugreifen. Der zentrale Einstiegspunkt ist [IParagraphFormat.getBullet](https://reference.aspose.com/slides/de/java/com.aspose.slides.iparagraphformat/#getBullet--), der ein [IBulletFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/)‑Objekt zurückgibt. Mit diesem Objekt können Sie Aufzählungstyp, Symbol, Bild, Farbe, Größe, Nummerierungsstil und Startnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellt
- eine Bild‑Aufzählung erstellt
- eine mehrstufige Liste erstellt, indem die Absatz‑Tiefe gesetzt wird
- eine nummerierte Liste erstellt
- die Listformatierung in einer bestehenden Präsentation inspiziert und ändert

## **Eine Aufzählungsliste erstellen**

Um eine Aufzählungsliste zu erstellen, fügen Sie [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides.iparagraph/)‑Objekte zu einem [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides.itextframe/) hinzu und setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/#setType-byte-) auf [BulletType.Symbol](https://reference.aspose.com/slides/de/java/com.aspose.slides.bullettype/#Symbol). Anschließend können Sie [IBulletFormat.setChar](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/#getColor--) und [IBulletFormat.setHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/#setHeight-float-) setzen, um das Aussehen der Aufzählungszeichen zu steuern.

Der folgende Java‑Code demonstriert, wie man in einer Folie eine Aufzählungsliste erstellt:

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

![The symbol bullets](symbol_bullets.png)

## **Eine nummerierte Liste erstellen**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/#setType-byte-) auf [BulletType.Numbered](https://reference.aspose.com/slides/de/java/com.aspose.slides.bullettype/#Numbered). Sie können außerdem ein Nummerierungsformat mit [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/#setNumberedBulletStyle-byte-) auswählen oder [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/#setNumberedBulletStartWith-short-) setzen, wenn die Liste bei einem anderen Wert als 1 beginnen soll.

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

![The numbered bullets](numbered_bullets.png)

## **Ein Bild‑Aufzählungszeichen erstellen**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungszeichen durch ein Bild zu ersetzen. Bild‑Aufzählungszeichen funktionieren am besten mit einfachen Bildern, die auch in kleiner Größe lesbar bleiben, z. B. Icons oder kleine transparente PNG‑Dateien.

{{% alert color="info" %}}
Idealerweise wählen Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, eine einfache Grafik mit transparentem Hintergrund. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungszeichen.
{{% /alert %}}

Um ein Bild‑Aufzählungszeichen zu erstellen, fügen Sie ein Bild zu [Presentation.getImages](https://reference.aspose.com/slides/de/java/com.aspose.slides.presentation/#getImages--) hinzu und weisen Sie das zurückgegebene Bildobjekt [IBulletFormat.getPicture](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/#getPicture--) zu. Setzen Sie [IBulletFormat.setType](https://reference.aspose.com/slides/de/java/com.aspose.slides.ibulletformat/#setType-byte-) auf [BulletType.Picture](https://reference.aspose.com/slides/de/java/com.aspose.slides.bullettype/#Picture), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine „image.png“:

![A picture for the bullets](picture_for_bullets.png)

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

![The picture bullets](picture_bullets.png)

## **Eine mehrstufige Liste erstellen**

Verwenden Sie [IParagraphFormat.setDepth](https://reference.aspose.com/slides/de/java/com.aspose.slides.iparagraphformat/#setDepth-short-), um Listenelemente auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw.

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

![The multilevel list](multilevel_list.png)

## **Eine vorhandene Liste ändern**

Um die Listformatierung in einer bestehenden Präsentation zu ändern, greifen Sie auf den Zielabsatz zu und aktualisieren Sie dessen [IParagraphFormat.getBullet](https://reference.aspose.com/slides/de/java/com.aspose.slides.iparagraphformat/#getBullet--)‑Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können zum Inspizieren oder Anpassen von Listen verwendet werden, die aus einer PPT‑, PPTX‑ oder ODP‑Datei geladen wurden.

Der folgende Java‑Code ändert den ersten Absatz in einem Textfeld, sodass er einen nummerierten Listenstil verwendet:

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

## **FAQ**

### Können Aufzählungs‑ und Nummerierungslisten in PDF oder Bilder exportiert werden?

Ja. Aspose.Slides behält die Listformatierung bei, sofern das Zielformat die entsprechenden Text‑Layout‑ und Aufzählungs‑Funktionen unterstützt.

### Kann ich Listen in bestehenden Präsentationen bearbeiten?

Ja. Laden Sie die Präsentation, greifen Sie auf den Zielabsatz zu, inspizieren oder aktualisieren Sie dessen [IParagraphFormat.getBullet](https://reference.aspose.com/slides/de/java/com.aspose.slides.iparagraphformat/#getBullet--)‑Einstellungen und speichern Sie die Präsentation.

### Können Listen nicht‑lateinischen Text enthalten?

Ja. Der Text von Listenelementen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.