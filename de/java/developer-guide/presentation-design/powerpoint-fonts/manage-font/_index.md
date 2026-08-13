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
description: "Steuern Sie Schriftarten in Java mit Aspose.Slides: betten Sie benutzerdefinierte Schriftarten ein, ersetzen Sie sie und laden Sie sie, um PPT-, PPTX- und ODP‑Präsentationen klar, markensicher und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Schriftarteigenschaften im Präsentationstext direkt aus Ihrem Code zu verwalten. Sie können über Formen, Textfelder, Absätze und Portionen auf Text in Folien zugreifen und dann die Formatierung auf den ausgewählten Text anwenden.

Dieser Artikel erklärt, wie Sie schriftbezogene Eigenschaften für vorhandenen Text in einer Präsentation konfigurieren, einschließlich Schriftfamilie, Fett- und Kursivstil, Absatzausrichtung und Schriftfarbe. Er zeigt außerdem, wie Sie ein Textfeld erstellen, Text hinzufügen und Schriftarteigenschaften wie Schriftfamilie, Fett, Kursiv, Unterstreichung, Schriftgröße und Farbe festlegen, bevor Sie das Ergebnis als PPTX-Datei speichern.

## **Verwalten von Schriftbezogenen Eigenschaften**
{{% alert color="info" %}} 

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensrichtlinien zu entsprechen. Die Textformatierung hilft Benutzern, das Aussehen und das Gefühl des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides for Java verwendet, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um Schriftarteigenschaften eines Absatzes mit Aspose.Slides for Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse.
1. Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/de/java/com.aspose.slides/placeholder/)-Formen in der Folie zu und casten Sie sie zu [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/).
1. Holen Sie den [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/) aus dem von [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/) bereitgestellten [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/).
1. Richten Sie den Absatz aus.
1. Greifen Sie auf den Text [Portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/portion/) eines [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/paragraph/) zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontdata/) und setzen Sie die **Font** der Text-[Portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/portion/) entsprechend.
   1. Setzen Sie die Schrift auf Fett.
   1. Setzen Sie die Schrift auf Kursiv.
1. Setzen Sie die Schriftfarbe mithilfe des von der [Portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/portion/) Objekt bereitgestellten [FillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/).
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte wird unten angegeben. Sie nimmt eine unveränderte Präsentation und formatiert die Schriften auf einer der Folien. Die nachfolgenden Screenshots zeigen die Eingabedatei und wie die Code‑Snippets sie verändern. Der Code ändert die Schriftart, die Farbe und den Schriftstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Derselbe Text mit aktualisierter Formatierung**|

```java
import com.aspose.slides.*;
import java.awt.Color;

//	Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("FontProperties.pptx");
try {
	//	Zugriff auf eine Folie über ihre Position
	ISlide slide = pres.getSlides().get_Item(0);

	//	Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	//	Zugriff auf den ersten Absatz
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	//	Absatz ausrichten (Blocksatz)
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	//	Zugriff auf den ersten Teil (Portion)
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	//	Neue Schriftarten definieren
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	//	Neue Schriftarten der Portion zuweisen
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	//	Schriftart auf Fett setzen
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	//	Schriftart auf Kursiv setzen
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	//	Schriftfarbe festlegen
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	//	PPTX auf Festplatte speichern
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Schriftarteigenschaften des Textes festlegen**
{{% alert color="info" %}} 

Wie im Abschnitt **Verwalten von Schriftbezogenen Eigenschaften** erwähnt, wird ein [Portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/portion/) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man Aspose.Slides for Java verwendet, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene weitere Eigenschaften der Schriftfamilienkategorie zu definieren.

{{% /alert %}} 

Um ein Textfeld zu erstellen und Schriftarteigenschaften des Textes darin festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)-Klasse.
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/) vom Typ **Rectangle** hinzu.
1. Entfernen Sie den mit der [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/) verbundenen Füllstil.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) der [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/) zu.
1. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) etwas Text hinzu.
1. Greifen Sie auf das mit dem [TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/textframe/) verbundene [Portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/portion/)-Objekt zu.
1. Definieren Sie die für das [Portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/portion/) zu verwendende Schriftart.
1. Setzen Sie weitere Schriftarteigenschaften wie Fett, Kursiv, Unterstreichung, Farbe und Höhe mithilfe der relevanten Eigenschaften, die vom [Portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/portion/)-Objekt bereitgestellt werden.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte wird unten angegeben.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides for Java gesetzten Schriftarteigenschaften**|

```java
import com.aspose.slides.*;
import java.awt.Color;

//	Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
	//	Erste Folie abrufen
	ISlide sld = pres.getSlides().get_Item(0);
	
	//	AutoShape vom Typ Rechteck hinzufügen
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	//	Alle Füllstile, die mit der AutoShape verknüpft sind, entfernen
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	//	Auf das mit der AutoShape verbundene TextFrame zugreifen
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	//	Auf die mit dem TextFrame verbundene Portion zugreifen
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	//	Schriftart für die Portion festlegen
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	//	Fett-Eigenschaft der Schriftart festlegen
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	//	Kursiv-Eigenschaft der Schriftart festlegen
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	//	Unterstreichungs-Eigenschaft der Schriftart festlegen
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	//	Höhe der Schriftart festlegen
	port.getPortionFormat().setFontHeight(25);
	
	//	Farbe der Schriftart festlegen
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	//	Präsentation auf Festplatte speichern
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```