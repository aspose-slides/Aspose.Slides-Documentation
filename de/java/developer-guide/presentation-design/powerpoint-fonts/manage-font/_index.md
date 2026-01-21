---
title: Schriftarten in Präsentationen mit Java verwalten
linktitle: Schriftarten verwalten
type: docs
weight: 10
url: /de/java/manage-fonts/
keywords:
- Schriftarten verwalten
- Schrifteigenschaften
- Absatz
- Textformatierung
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Steuern Sie Schriftarten in Java mit Aspose.Slides: betten Sie benutzerdefinierte Schriftarten ein, ersetzen Sie sie und laden Sie sie, um PPT-, PPTX- und ODP-Präsentationen klar, markenkonform und konsistent zu halten."
---

## **Schriftbezogene Eigenschaften verwalten**
{{% alert color="primary" %}} 

Präsentationen enthalten in der Regel sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, entweder um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensrichtlinien zu entsprechen. Die Textformatierung ermöglicht es Benutzern, das Aussehen und die Darstellung des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides for Java verwendet, um die Schrifteigenschaften von Textabsätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um die Schrifteigenschaften eines Absatzes mit Aspose.Slides for Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie, indem Sie deren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/)‑Formen in der Folie zu und casten Sie sie zu [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
1. Rufen Sie das [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) aus dem von [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) bereitgestellten [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) ab.
1. Richten Sie den Absatz aus.
1. Greifen Sie auf den Text‑[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) eines [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) und setzen Sie die **Font** des Text‑[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) entsprechend.
   1. Setzen Sie die Schrift auf Fett.
   1. Setzen Sie die Schrift auf Kursiv.
1. Setzen Sie die Schriftfarbe mithilfe des von dem [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)‑Objekt bereitgestellten [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/).
1. Speichern Sie die geänderte Präsentation in einer PPTX‑Datei.

Die Implementierung der obigen Schritte ist unten angegeben. Sie nimmt eine unveränderte Präsentation und formatiert die Schriften auf einer der Folien. Die nachfolgenden Screenshots zeigen die Eingabedatei und wie die Code‑Snippets diese ändern. Der Code ändert die Schrift, die Farbe und den Schriftstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Der gleiche Text mit aktualisierter Formatierung**|
```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Zugriff auf eine Folie über ihre Position
	ISlide slide = pres.getSlides().get_Item(0);

	// Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Zugriff auf den ersten Absatz
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Absatz im Blocksatz ausrichten
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Zugriff auf den ersten Teil
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definieren neuer Schriftarten
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Zuweisen neuer Schriftarten zum Teil
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Schrift auf Fett setzen
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Schrift auf Kursiv setzen
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Schriftfarbe setzen
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX auf Festplatte speichern
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Text-Schrifteigenschaften festlegen**
{{% alert color="primary" %}} 

Wie im Abschnitt **Schriftbezogene Eigenschaften verwalten** erwähnt, wird ein [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man Aspose.Slides for Java verwendet, um ein Textfeld mit etwas Text zu erstellen und anschließend eine bestimmte Schriftart sowie verschiedene weitere Eigenschaften der Schriftfamilie zu definieren.

{{% /alert %}} 

Um ein Textfeld zu erstellen und die Schrifteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse.
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) vom Typ **Rectangle** zur Folie hinzu.
1. Entfernen Sie den Füllstil, der mit dem [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) verknüpft ist.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) zu.
1. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) etwas Text hinzu.
1. Greifen Sie auf das mit dem [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) verknüpfte [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)‑Objekt zu.
1. Definieren Sie die Schriftart, die für das [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) verwendet werden soll.
1. Setzen Sie weitere Schrifteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe über die entsprechenden Eigenschaften des [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)‑Objekts.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte ist unten dargestellt.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides for Java festgelegten Schrifteigenschaften**|
```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
	// Erste Folie holen
	ISlide sld = pres.getSlides().get_Item(0);
	
	// AutoShape vom Typ Rectangle hinzufügen
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Alle mit dem AutoShape verbundenen Füllstile entfernen
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Auf den mit dem AutoShape verknüpften TextFrame zugreifen
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Auf den mit dem TextFrame verknüpften Portion zugreifen
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Schriftart für den Portion festlegen
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Fett-Eigenschaft der Schrift festlegen
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Kursiv-Eigenschaft der Schrift festlegen
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Unterstreichen-Eigenschaft der Schrift festlegen
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Schriftgröße festlegen
	port.getPortionFormat().setFontHeight(25);
	
	// Schriftfarbe festlegen
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Präsentation auf Datenträger speichern
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
