---
title: Schriftarten verwalten - PowerPoint Java API
linktitle: Schriftarten verwalten
type: docs
weight: 10
url: /androidjava/manage-fonts/
description: Präsentationen enthalten in der Regel sowohl Text als auch Bilder. Dieser Artikel zeigt, wie man die Schriftarteigenschaften von Textabsätzen auf Folien mit der PowerPoint Java API konfiguriert.
---

## **Verwalten von Schriftarteigenschaften**
{{% alert color="primary" %}} 

Präsentationen enthalten in der Regel sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensstilen zu entsprechen. Die Textformatierung hilft den Benutzern, das Erscheinungsbild des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides für Android über Java verwendet, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um die Schriftarteigenschaften eines Absatzes mit Aspose.Slides für Android über Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Placeholder) Formen in der Folie zu und casten Sie sie in [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. Holen Sie sich den [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph) aus dem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame), der von [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) bereitgestellt wird.
1. Rechtsfertigen Sie den Absatz.
1. Greifen Sie auf den Text[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) eines [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph) zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FontData) und setzen Sie die **Font** des Text[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   1. Setzen Sie die Schriftart auf kursiv.
1. Setzen Sie die Schriftfarbe mithilfe des [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FillFormat), das vom [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) Objekt bereitgestellt wird.
1. Speichern Sie die modifizierte Präsentation in einer PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben. Sie nimmt eine unverzierte Präsentation und formatiert die Schriftarten auf einer der Folien. Die folgenden Screenshots zeigen die Eingabedatei und wie die Codeschnipsel sie ändern. Der Code ändert die Schriftart, die Farbe und den Schriftstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Der gleiche Text mit aktualisierter Formatierung**|

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Zugriff auf eine Folie unter Verwendung ihrer Folienposition
	ISlide slide = pres.getSlides().get_Item(0);

	// Zugriff auf den ersten und zweiten Platzhalter in der Folie und Casten als AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Zugriff auf den ersten Absatz
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Absatz rechtsfertigen
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Zugriff auf den ersten Teil
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Neue Schriftarten definieren
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Neue Schriftarten dem Teil zuweisen
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Schriftart auf Fett setzen
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Schriftart auf Kursiv setzen
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

Wie in **Verwalten von Schriftarteigenschaften** erwähnt, wird ein [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) verwendet, um Texte mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man Aspose.Slides für Android über Java verwendet, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene andere Eigenschaften der Schriftfamilie zu definieren.

{{% /alert %}} 

Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Texts festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) des Typs **Rechteck** hinzu.
1. Entfernen Sie den Füllstil, der mit der [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) verbunden ist.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) der [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) zu.
1. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) etwas Text hinzu.
1. Greifen Sie auf das [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) Objekt zu, das mit dem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) verbunden ist.
1. Definieren Sie die Schriftart, die für das [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) verwendet werden soll.
1. Setzen Sie andere Schriftarteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe mithilfe der relevanten Eigenschaften, die vom [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) Objekt bereitgestellt werden.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen Schriftarteigenschaften, die von Aspose.Slides für Android über Java gesetzt wurden**|

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
	// Erste Folie abrufen
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Eine AutoShape des Typ Rechteck hinzufügen
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Entfernen Sie alle Füllstile, die mit dem AutoShape verbunden sind
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Zugriff auf das TextFrame, das mit der AutoShape verbunden ist
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Zugriff auf das Portion, das mit dem TextFrame verbunden ist
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Setzen Sie die Schriftart für das Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Setzen Sie die Fett-Eigenschaft der Schriftart
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Setzen Sie die Kursiv-Eigenschaft der Schriftart
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Setzen Sie die Unterstrich-Eigenschaft der Schriftart
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Setzen Sie die Höhe der Schriftart
	port.getPortionFormat().setFontHeight(25);
	
	// Setzen Sie die Farbe der Schriftart
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Speichern Sie die Präsentation auf der Festplatte
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```