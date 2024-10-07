---
title: Schriftarten verwalten - PowerPoint Java API
linktitle: Schriftarten verwalten
type: docs
weight: 10
url: /java/manage-fonts/
description: Präsentationen enthalten normalerweise sowohl Text als auch Bilder. In diesem Artikel wird gezeigt, wie Sie die Schriftarteigenschaften von Textabsätzen auf Folien mithilfe der PowerPoint Java API konfigurieren.
---

## **Schriftartbezogene Eigenschaften verwalten**
{{% alert color="primary" %}} 

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensstilen zu entsprechen. Die Textformatierung hilft den Nutzern, das Erscheinungsbild des Präsentationsinhalts zu variieren. In diesem Artikel wird gezeigt, wie Sie Aspose.Slides für Java verwenden, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um die Schriftarteigenschaften eines Absatzes mithilfe von Aspose.Slides für Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) -Klasse.
1. Erhalten Sie eine Referenz auf die Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Placeholder) -Formen in der Folie zu und casten Sie sie zu [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Holen Sie sich den [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph) aus dem [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame), das von [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape) bereitgestellt wird.
1. Rechtfertigen Sie den Absatz.
1. Greifen Sie auf den Text [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) eines [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph) zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FontData) und legen Sie die **Schriftart** des Textes [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) entsprechend fest.
   1. Stellen Sie die Schriftart auf fett.
   1. Stellen Sie die Schriftart auf kursiv.
1. Legen Sie die Schriftfarbe mithilfe des [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FillFormat) fest, das vom [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) -Objekt bereitgestellt wird.
1. Speichern Sie die modifizierte Präsentation in einer PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben. Sie nimmt eine schlichte Präsentation und formatiert die Schriftarten auf einer der Folien. Die folgenden Screenshots zeigen die Eingabedatei und wie die Code-Snippets sie ändern. Der Code ändert die Schriftart, die Farbe und den Schriftstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Der gleiche Text mit aktualisierter Formatierung**|

```java
// Erstellen Sie ein Präsentationsobjekt, das eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Zugriff auf eine Folie mithilfe ihrer Folienposition
	ISlide slide = pres.getSlides().get_Item(0);

	// Zugriff auf den ersten und zweiten Placeholder in der Folie und casten Sie es als AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Zugriff auf den ersten Paragraph
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Rechtfertigen Sie den Absatz
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Zugriff auf den ersten Portion
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Neue Schriftarten definieren
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Neue Schriftarten dem Portion zuweisen
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Schrift auf fett setzen
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Schrift auf kursiv setzen
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Schriftfarbe setzen
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Speichern Sie die PPTX auf der Festplatte
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Textschriftarteigenschaften festlegen**
{{% alert color="primary" %}} 

Wie im Abschnitt **Schriftartbezogene Eigenschaften verwalten** erwähnt, wird ein [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. In diesem Artikel wird gezeigt, wie Sie Aspose.Slides für Java verwenden, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene andere Eigenschaften der Schriftfamilie festzulegen.

{{% /alert %}} 

Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) -Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape) vom Typ **Rechteck** hinzu.
1. Entfernen Sie den Füllstil, der mit der [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape) -Form verbunden ist.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) der [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape) zu.
1. Fügen Sie etwas Text in das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) ein.
1. Greifen Sie auf das [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) -Objekt zu, das mit dem [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) verknüpft ist.
1. Definieren Sie die zu verwendende Schriftart für das [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Legen Sie weitere Schriftarteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe mithilfe der relevanten Eigenschaften fest, die vom [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) -Objekt bereitgestellt werden.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides für Java festgelegten Schriftarteigenschaften**|

```java
// Erstellen Sie ein Präsentationsobjekt, das eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
	// Erste Folie abrufen
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Eine AutoShape vom Typ Rechteck hinzufügen
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Entfernen Sie alle Füllstile, die mit der AutoShape verbunden sind
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Zugriff auf das TextFrame, das mit der AutoShape verbunden ist
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Zugriff auf den Portion, der mit dem TextFrame verknüpft ist
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Setzen Sie die Schriftart für den Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Stellen Sie die Fett-Eigenschaft der Schriftart ein
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Stellen Sie die Kursiv-Eigenschaft der Schriftart ein
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Stellen Sie die Unterstrichen-Eigenschaft der Schriftart ein
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Stellen Sie die Höhe der Schriftart ein
	port.getPortionFormat().setFontHeight(25);
	
	// Stellen Sie die Farbe der Schriftart ein
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Speichern Sie die Präsentation auf der Festplatte
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```