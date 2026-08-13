---
title: Schriftarten in Präsentationen auf Android
linktitle: Schriftarten verwalten
type: docs
weight: 10
url: /de/androidjava/manage-fonts/
keywords:
- Schriftarten verwalten
- Schriftarteigenschaften
- Absatz
- Textformatierung
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Steuern Sie Schriftarten in Java mit Aspose.Slides für Android: betten Sie benutzerdefinierte Schriftarten ein, ersetzen Sie sie und laden Sie sie, um PPT-, PPTX- und ODP-Präsentationen klar, markenkonform und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Schriftarteigenschaften im Präsentationstext direkt aus Ihrem Code zu verwalten. Sie können auf Text in Folien über Shapes, TextFrames, Absätze und Portionen zugreifen und dann die Formatierung auf den ausgewählten Text anwenden.

Dieser Artikel erklärt, wie Schriftartbezogene Eigenschaften für vorhandenen Text in einer Präsentation konfiguriert werden, einschließlich Schriftfamilie, Fett‑ und Kursivstil, Absatzausrichtung und Schriftfarbe. Er zeigt außerdem, wie ein Textfeld erstellt, Text hinzugefügt und Schriftarteigenschaften wie Schriftfamilie, Fett, Kursiv, Unterstreichen, Schriftgröße und Farbe festgelegt werden, bevor das Ergebnis als PPTX‑Datei gespeichert wird.

## **Schriftartbezogene Eigenschaften verwalten**
{{% alert color="info" %}} 

Präsentationen enthalten in der Regel sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, entweder um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensrichtlinien zu entsprechen. Die Textformatierung hilft Benutzern, das Aussehen des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Aspose.Slides für Android über Java verwendet wird, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um Schriftarteigenschaften eines Absatzes mit Aspose.Slides für Android über Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholder/) Shapes in der Folie zu und casten Sie sie zu [AutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/autoshape/).
1. Rufen Sie das [Paragraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/paragraph/) aus dem [TextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textframe/) ab, das von [AutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/autoshape/) bereitgestellt wird.
1. Richten Sie den Absatz aus.
1. Greifen Sie auf den Text [Portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portion/) eines [Paragraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/paragraph/) zu.
1. Definieren Sie die Schriftart mithilfe von [FontData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontdata/) und setzen Sie die **Font** des Text [Portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portion/) entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   1. Setzen Sie die Schriftart auf kursiv.
1. Setzen Sie die Schriftfarbe mithilfe des [FillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/) , das vom [Portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portion/) Objekt bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte ist unten dargestellt. Sie nimmt eine unveränderte Präsentation und formatiert die Schriftarten auf einer der Folien. Die nachfolgenden Screenshots zeigen die Eingabedatei und wie die Code‑Snippets diese ändern. Der Code ändert die Schriftart, die Farbe und den Schriftstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Der gleiche Text mit aktualisierter Formatierung**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Zugriff auf eine Folie anhand ihrer Position
	ISlide slide = pres.getSlides().get_Item(0);

	// Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung in AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Zugriff auf den ersten Absatz
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Absatz ausrichten (Blocksatz)
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Zugriff auf den ersten Abschnitt
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Neue Schriftarten definieren
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Neue Schriftarten dem Abschnitt zuweisen
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Schriftart fett setzen
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Schriftart kursiv setzen
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Schriftfarbe setzen
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX auf die Festplatte speichern
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Text‑Schriftarteigenschaften festlegen**
{{% alert color="info" %}} 

Wie im **Schriftartbezogene Eigenschaften verwalten** erwähnt, wird ein [Portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portion/) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie Aspose.Slides für Android über Java verwendet wird, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene andere Eigenschaften der Schriftfamilienkategorie zu definieren.

{{% /alert %}} 

Um ein Textfeld zu erstellen und Schriftarteigenschaften des Textes darin festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/autoshape/) vom Typ **Rectangle** hinzu.
1. Entfernen Sie den Füllstil, der mit dem [AutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/autoshape/) verknüpft ist.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/autoshape/) zu.
1. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textframe/) etwas Text hinzu.
1. Greifen Sie auf das [Portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portion/) Objekt zu, das mit dem [TextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textframe/) verknüpft ist.
1. Definieren Sie die für das [Portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portion/) zu verwendende Schriftart.
1. Setzen Sie weitere Schriftarteigenschaften wie Fett, Kursiv, Unterstreichen, Farbe und Höhe mithilfe der entsprechenden Eigenschaften, die vom [Portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portion/) Objekt bereitgestellt werden.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte ist unten dargestellt.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides für Android über Java festgelegten Schriftarteigenschaften**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
	// Erste Folie holen
	ISlide sld = pres.getSlides().get_Item(0);
	
	// AutoShape vom Typ Rechteck hinzufügen
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Jeglichen Füllstil, der mit dem AutoShape verknüpft ist, entfernen
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Auf das TextFrame zugreifen, das dem AutoShape zugeordnet ist
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Auf den Portion zugreifen, der dem TextFrame zugeordnet ist
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Schriftart für den Portion festlegen
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Fetteigenschaft der Schrift festlegen
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Kursiveigenschaft der Schrift festlegen
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Unterstreichungseigenschaft der Schrift festlegen
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Höhe der Schrift festlegen
	port.getPortionFormat().setFontHeight(25);
	
	// Farbe der Schrift festlegen
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Präsentation auf die Festplatte speichern
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```