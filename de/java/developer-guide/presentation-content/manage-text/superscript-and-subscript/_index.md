---
title: Superskript und Tiefschrift in Präsentationen mit Java verwalten
linktitle: Superskript und Tiefschrift
type: docs
weight: 80
url: /de/java/superscript-and-subscript/
keywords:
- superskript
- tiefschrift
- superskript hinzufügen
- tiefschrift hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Beherrschen Sie Superskript und Tiefschrift in Aspose.Slides für Java und heben Sie Ihre Präsentationen mit professioneller Textformatierung für maximale Wirkung hervor."
---

## **Super- und Tiefschrift verwalten**
Sie können superscript‑ und subscript‑Text in jedem Absatzteil hinzufügen. Um superscript‑ oder subscript‑Text im Aspose.Slides‑Textfeld zu setzen, muss die Methode [**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) der Klasse [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat) verwendet werden.

Diese Eigenschaft gibt den superscript‑ oder subscript‑Text zurück oder setzt ihn (Wert von –100 % (Tiefstellung) bis 100 % (Hochstellung)). Zum Beispiel:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Holen Sie sich den Verweis auf eine Folie über ihren Index.
- Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) hinzu.
- Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) zu, das dem [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) zugeordnet ist.
- Löschen Sie vorhandene Absätze.
- Erstellen Sie ein neues Absatzobjekt für superscript‑Text und fügen Sie es der [IParagraphs collection](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--) des [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) hinzu.
- Erstellen Sie ein neues Portion‑Objekt.
- Setzen Sie die Escapement‑Eigenschaft für die Portion zwischen 0 und 100, um superscript hinzuzufügen. (0 bedeutet kein superscript)
- Setzen Sie einen Text für [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) und fügen Sie diesen dann zur Portion‑Sammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt für subscript‑Text und fügen Sie es der IParagraphs‑Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portion‑Objekt.
- Setzen Sie die Escapement‑Eigenschaft für die Portion zwischen 0 und –100, um subscript hinzuzufügen. (0 bedeutet kein subscript)
- Setzen Sie einen Text für [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) und fügen Sie diesen dann zur Portion‑Sammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte ist unten dargestellt.
```java
// Instanziieren Sie eine Presentation‑Klasse, die eine PPTX darstellt
Presentation pres = new Presentation();
try {
    // Folie holen
    ISlide slide = pres.getSlides().get_Item(0);

    // Textfeld erstellen
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Absatz für Hochstellungstext erstellen
    IParagraph superPar = new Paragraph();

    // Portion mit normalem Text erstellen
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Portion mit Hochstellungstext erstellen
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Absatz für Tiefstellungstext erstellen
    IParagraph paragraph2 = new Paragraph();

    // Portion mit normalem Text erstellen
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Portion mit Tiefstellungstext erstellen
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Absätze zum Textfeld hinzufügen
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wird superscript und subscript beim Exportieren in PDF oder andere Formate beibehalten?**

Ja, Aspose.Slides behält superscript‑ und subscript‑Formatierungen beim Exportieren von Präsentationen nach PDF, PPT/PPTX, Bildern und anderen unterstützten Formaten korrekt bei. Die spezielle Formatierung bleibt in allen Ausgabedateien erhalten.

**Können superscript und subscript mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb einer einzigen Portion. Sie können Fett, Kursiv, Unterstreichen aktivieren und gleichzeitig superscript oder subscript anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) konfigurieren.

**Funktionieren superscript und subscript bei Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen und Diagrammelementen. Bei der Arbeit mit SmartArt müssen Sie auf die entsprechenden Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/java/com.aspose.slides/smartartnode/)) und deren Textcontainer zugreifen und dann die [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/)‑Eigenschaften analog konfigurieren.