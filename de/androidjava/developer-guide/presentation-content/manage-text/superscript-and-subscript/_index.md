---
title: Superskript und Subskript in Präsentationen auf Android verwalten
linktitle: Superskript und Subskript
type: docs
weight: 80
url: /de/androidjava/superscript-and-subscript/
keywords:
- Superskript
- Subskript
- Superskript hinzufügen
- Subskript hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Meistern Sie Superskript und Subskript in Aspose.Slides für Android via Java und heben Sie Ihre Präsentationen mit professioneller Textformatierung für maximale Wirkung hervor."
---

## **Superscript- und Subscript-Text verwalten**
Sie können Superscript- und Subscript-Text in jedem Absatzabschnitt hinzufügen. Um Superscript‑ oder Subscript‑Text in einem Aspose.Slides‑Textfeld zu verwenden, muss die Methode [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) der Klasse [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat) verwendet werden.

Diese Eigenschaft gibt den Superscript‑ bzw. Subscript‑Wert zurück oder setzt ihn (Wert von –100 % (Subscript) bis 100 % (Superscript)). Zum Beispiel:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) des Typs [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) hinzu.
- Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) zu, das mit dem [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) verknüpft ist.
- Löschen Sie vorhandene Absätze.
- Erstellen Sie ein neues Absatzobjekt zum Halten von Superscript‑Text und fügen Sie es der [IParagraphs collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) des [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) hinzu.
- Erstellen Sie ein neues Portion‑Objekt.
- Setzen Sie die Escapement‑Eigenschaft für die Portion zwischen 0 und 100, um Superscript hinzuzufügen. (0 bedeutet kein Superscript)
- Setzen Sie einen Text für [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) und fügen Sie ihn dann der Portion‑Collection des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt zum Halten von Subscript‑Text und fügen Sie es der IParagraphs‑Collection des ITextFrame hinzu.
- Erstellen Sie ein neues Portion‑Objekt.
- Setzen Sie die Escapement‑Eigenschaft für die Portion zwischen 0 und –100, um Subscript hinzuzufügen. (0 bedeutet kein Subscript)
- Setzen Sie einen Text für [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) und fügen Sie ihn dann der Portion‑Collection des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten gezeigt.
```java
// Instanziiere eine Presentation-Klasse, die eine PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Hole Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Erstelle Textfeld
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Erstelle Absatz für Superskript-Text
    IParagraph superPar = new Paragraph();

    // Erstelle Portion mit normalem Text
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Erstelle Portion mit Superskript-Text
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Erstelle Absatz für Subskript-Text
    IParagraph paragraph2 = new Paragraph();

    // Erstelle Portion mit normalem Text
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Erstelle Portion mit Subskript-Text
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Füge Absätze zum Textfeld hinzu
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wird Superscript‑ und Subscript‑Formatierung beim Exportieren in PDF oder andere Formate beibehalten?**

Ja, Aspose.Slides behält die Superscript‑ und Subscript‑Formatierung beim Exportieren von Präsentationen in PDF, PPT/PPTX, Bilder und andere unterstützte Formate korrekt bei. Die spezielle Formatierung bleibt in allen Ausgabedateien erhalten.

**Können Superscript‑ und Subscript‑Formatierung mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb eines einzelnen Textabschnitts. Sie können Fett, Kursiv, Unterstreichen aktivieren und gleichzeitig Superscript‑ oder Subscript‑Formatierung anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) konfigurieren.

**Funktioniert die Superscript‑ und Subscript‑Formatierung für Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen- und Diagrammelementen. Beim Arbeiten mit SmartArt müssen Sie auf die entsprechenden Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)) und deren Textcontainer zugreifen und dann die Eigenschaften von [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) in ähnlicher Weise konfigurieren.