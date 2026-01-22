---
title: Schriftarten in Präsentationen auf Android verwalten
linktitle: Schriftarten verwalten
type: docs
weight: 10
url: /de/androidjava/manage-fonts/
keywords:
- Schriftarten verwalten
- Schriftart-Eigenschaften
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

## **Verwalten von schriftenbezogenen Eigenschaften**
{{% alert color="primary" %}} 

Präsentationen enthalten in der Regel sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, entweder um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensrichtlinien zu entsprechen. Die Textformatierung hilft den Benutzern, das Aussehen und die Gestaltung des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides für Android über Java verwendet, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um die Schriftarteigenschaften eines Absatzes mit Aspose.Slides für Android über Java zu verwalten:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)-Klasse.
1. Rufen Sie die Referenz einer Folie anhand ihres Index ab.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/)-Formen in der Folie zu und casten Sie sie zu [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. Erhalten Sie das [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/)-Objekt aus dem von [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) bereitgestellten [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
1. Richten Sie den Absatz aus.
1. Greifen Sie auf den Text-[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)-Abschnitt eines [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) und setzen Sie die **Font** des Text-[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) entsprechend.
   1. Setzen Sie die Schriftart auf Fett.
   1. Setzen Sie die Schriftart auf Kursiv.
1. Setzen Sie die Schriftfarbe mit dem von der [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)‑Objekt bereitgestellten [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Die Umsetzung der obigen Schritte ist unten dargestellt. Sie übernimmt eine einfache Präsentation und formatiert die Schriften auf einer der Folien. Die nachfolgenden Screenshots zeigen die Eingabedatei und wie die Code‑Schnipsel diese verändern. Der Code ändert die Schrift, die Farbe und den Schriftstil.

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
	// Zugriff auf eine Folie über ihre Folienposition
	ISlide slide = pres.getSlides().get_Item(0);

	// Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
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

	// Schriftart auf Fett setzen
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Schriftart auf Kursiv setzen
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Schriftfarbe festlegen
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


## **Textschriftart-Eigenschaften festlegen**
{{% alert color="primary" %}} 

Wie im Abschnitt **Verwalten von schriftenbezogenen Eigenschaften** erwähnt, wird ein [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man Aspose.Slides für Android über Java verwendet, um ein Textfeld mit etwas Text zu erstellen und anschließend eine bestimmte Schriftart sowie verschiedene weitere Eigenschaften der Schriftfamilienkategorie zu definieren.

{{% /alert %}} 

Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Textes festzulegen:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)-Klasse.
1. Rufen Sie die Referenz einer Folie anhand ihres Index ab.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/)-Objekt vom Typ **Rectangle** hinzu.
1. Entfernen Sie den mit dem [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) verknüpften Füllstil.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) zu.
1. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) etwas Text hinzu.
1. Greifen Sie auf das mit dem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) verbundene [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)-Objekt zu.
1. Definieren Sie die für das [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) zu verwendende Schriftart.
1. Setzen Sie weitere Schriftarteigenschaften wie Fett, Kursiv, Unterstrichen, Farbe und Höhe über die entsprechenden Eigenschaften des [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)-Objekts.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Die Umsetzung der obigen Schritte ist unten dargestellt.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides für Android über Java gesetzten Schriftarteigenschaften**|
```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
	// Erste Folie erhalten
	ISlide sld = pres.getSlides().get_Item(0);
	
	// AutoShape vom Typ Rechteck hinzufügen
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Jeglichen Füllstil, der dem AutoShape zugeordnet ist, entfernen
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Auf das mit dem AutoShape verbundene TextFrame zugreifen
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Auf den mit dem TextFrame verbundenen Portion zugreifen
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Schriftart für den Portion festlegen
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Fett-Eigenschaft der Schriftart setzen
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Kursiv-Eigenschaft der Schriftart setzen
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Unterstreichungs-Eigenschaft der Schriftart setzen
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Schriftgröße festlegen
	port.getPortionFormat().setFontHeight(25);
	
	// Farbe der Schrift festlegen
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Präsentation auf dem Datenträger speichern
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
