---
title: "Verwalten von Superskript und Tiefgestellt in Präsentationen unter Android"
linktitle: "Superskript und Tiefgestellt"
type: docs
weight: 80
url: /de/androidjava/superscript-and-subscript/
keywords:
- Superskript
- Tiefgestellt
- Superskript hinzufügen
- Tiefgestellt hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Meistern Sie Superskript und Tiefgestellt in Aspose.Slides für Android via Java und heben Sie Ihre Präsentationen mit professioneller Textformatierung für maximale Wirkung."
---

## **Superskript- und Tiefgestellt‑Text verwalten**
Sie können Superskript‑ und Tiefgestellt‑Text in jeden Absatzabschnitt einfügen. Um Superskript‑ oder Tiefgestellt‑Text in einem Aspose.Slides‑Textfeld hinzuzufügen, muss die Methode [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) der Klasse [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat) verwendet werden.

Diese Eigenschaft gibt den Superskript‑ oder Tiefgestellt‑Text zurück oder setzt ihn (Wert von -100 % (Tiefgestellt) bis 100 % (Superskript)). Zum Beispiel:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie über ihren Index.
- Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) hinzu.
- Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) zu, das mit dem [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) verknüpft ist.
- Löschen Sie vorhandene Absätze
- Erstellen Sie ein neues Absatzobjekt für Superskript‑Text und fügen Sie es der [IParagraphs collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) des [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) hinzu.
- Erstellen Sie ein neues Portion‑Objekt
- Setzen Sie die Escapement‑Eigenschaft der Portion auf einen Wert zwischen 0 und 100, um Superskript hinzuzufügen. (0 bedeutet kein Superskript)
- Legen Sie Text für [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) fest und fügen Sie ihn dann zur Portion‑Sammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt für Tiefgestellt‑Text und fügen Sie es der IParagraphs‑Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portion‑Objekt
- Setzen Sie die Escapement‑Eigenschaft der Portion auf einen Wert zwischen 0 und -100, um Tiefgestellt hinzuzufügen. (0 bedeutet kein Tiefgestellt)
- Legen Sie Text für [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) fest und fügen Sie ihn dann zur Portion‑Sammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten angegeben.
```java
// Instanziiere eine Presentation-Klasse, die ein PPTX darstellt
Presentation pres = new Presentation();
try {
    // Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);

    // Textfeld erstellen
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Absatz für Superskript-Text erstellen
    IParagraph superPar = new Paragraph();

    // Portion mit normalem Text erstellen
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Portion mit Superskript-Text erstellen
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Absatz für Tiefgestellt-Text erstellen
    IParagraph paragraph2 = new Paragraph();

    // Portion mit normalem Text erstellen
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Portion mit Tiefgestellt-Text erstellen
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

**Wird Superskript und Tiefgestellt beim Exportieren in PDF oder andere Formate beibehalten?**

Ja, Aspose.Slides bewahrt die Superskript‑ und Tiefgestellt‑Formatierung beim Export von Präsentationen nach PDF, PPT/PPTX, Bildern und anderen unterstützten Formaten korrekt. Die spezielle Formatierung bleibt in allen Ausgabedateien erhalten.

**Können Superskript und Tiefgestellt mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb einer einzelnen Portion. Sie können Fett, Kursiv, Unterstreichen aktivieren und gleichzeitig Superskript oder Tiefgestellt anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) konfigurieren.

**Funktionieren Superskript‑ und Tiefgestellt‑Formatierungen für Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen- und Diagrammelementen. Beim Arbeiten mit SmartArt müssen Sie die entsprechenden Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)) und deren Textcontainer zugreifen und dann die [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/)‑Eigenschaften analog konfigurieren.