---
title: Verwalten von PowerPoint-Textabsätzen in .NET
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählung verwalten
- Absatz-Einzug
- Hängender Einzug
- Absatz-Aufzählung
- Nummerierte Liste
- Aufzählungsliste
- Absatz-Eigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für .NET – optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP‑Präsentationen in C#."
---
## **Einführung**

Aspose.Slides stellt alle Schnittstellen und Klassen bereit, die Sie benötigen, um in C# mit PowerPoint-Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) Schnittstelle bereit, die es Ihnen ermöglicht, Objekte hinzuzufügen, die einen Absatz darstellen. Ein `ITextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides stellt die [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/) Schnittstelle bereit, die es Ihnen ermöglicht, Objekte hinzuzufügen, die Portionen darstellen. Ein `IParagraph`‑Objekt kann eine oder mehrere Portionen enthalten (Sammlung von iPortions‑Objekten).
* Aspose.Slides stellt die [IPortion](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/) Schnittstelle bereit, die es Ihnen ermöglicht, Objekte hinzuzufügen, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Textrahmen mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Greifen Sie über dessen Index auf die Referenz der betreffenden Folie zu.
3. Fügen Sie der Folie ein Rechteck‑[IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
4. Ermitteln Sie das mit dem [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) verknüpfte `ITextFrame`.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/)-Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [IPortion](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/)-Objekte (zwei Portion‑Objekte für den Standardabsatz) und fügen Sie jedes `IPortion`‑Objekt der IPortion‑Sammlung des jeweiligen `IParagraph` hinzu.
7. Legen Sie für jede Portion einen Text fest.
8. Wenden Sie auf jede Portion die gewünschten Formatierungsoptionen mithilfe der vom `IPortion`‑Objekt bereitgestellten Formatierungseigenschaften an.
9. Speichern Sie die geänderte Präsentation.

```c#
// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
using (Presentation pres = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = pres.Slides[0];

    // Fügt eine rechteckige IAutoShape hinzu
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Greift auf das AutoShape‑TextFrame zu
    ITextFrame tf = ashp.TextFrame;

    // Erstellt Absätze und Portionen mit verschiedenen Textformaten
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Speichert die geänderte Präsentation
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Absatz‑Aufzählungen verwalten**
Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Greifen Sie über dessen Index auf die Referenz der betreffenden Folie zu.
3. Fügen Sie dem ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides/paragraph/).
8. Legen Sie den Aufzählungs `Type` für den Absatz auf `Symbol` fest und setzen Sie das Aufzählungszeichen.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für die Aufzählung fest.
12. Legen Sie eine Höhe für die Aufzählung fest.
13. Fügen Sie den neuen Absatz der Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten 7 bis 13.
15. Speichern Sie die Präsentation.

```c#
// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide slide = pres.Slides[0];


    // Fügt ein Autoshape hinzu und greift darauf zu
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das TextFrame des Autoshapes zu
    ITextFrame txtFrm = aShp.TextFrame;

    // Entfernt den Standard‑Absatz
    txtFrm.Paragraphs.RemoveAt(0);

    // Erstellt einen Absatz
    Paragraph para = new Paragraph();

    // Legt den Aufzählungsstil und das Symbol des Absatzes fest
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Setzt den Text des Absatzes
    para.Text = "Welcome to Aspose.Slides";

    // Legt den Einzug der Aufzählung fest
    para.ParagraphFormat.Indent = 25;

    // Legt die Farbe der Aufzählung fest
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // legt IsBulletHardColor auf true fest, um eine eigene Aufzählungsfarbe zu verwenden

    // Legt die Höhe der Aufzählung fest
    para.ParagraphFormat.Bullet.Height = 100;

    // Fügt den Absatz dem TextFrame hinzu
    txtFrm.Paragraphs.Add(para);

    // Erstellt den zweiten Absatz
    Paragraph para2 = new Paragraph();

    // Legt den Aufzählungstyp und -stil des Absatzes fest
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Fügt den Absatztext hinzu
    para2.Text = "This is numbered bullet";

    // Legt den Einzug der Aufzählung fest
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // legt IsBulletHardColor auf true fest, um eine eigene Aufzählungsfarbe zu verwenden

    // Legt die Höhe der Aufzählung fest
    para2.ParagraphFormat.Bullet.Height = 100;

    // Fügt den Absatz dem TextFrame hinzu
    txtFrm.Paragraphs.Add(para2);


    // Speichert die geänderte Präsentation
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Bild‑Aufzählungen verwalten**
Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Greifen Sie über dessen Index auf die Referenz der betreffenden Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/) des Autoshapes zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides/paragraph/).
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungs‑Typ auf [Picture](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) und legen Sie das Bild fest.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für die Aufzählung fest.
12. Legen Sie eine Höhe für die Aufzählung fest.
13. Fügen Sie den neuen Absatz der Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang anhand der vorherigen Schritte.
15. Speichern Sie die geänderte Präsentation.

```c#
// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
Presentation presentation = new Presentation();

// Greift auf die erste Folie zu
ISlide slide = presentation.Slides[0];

// Instanziert das Bild für Aufzählungen
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Fügt ein Autoshape hinzu und greift darauf zu
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Greift auf das TextFrame des Autoshapes zu
ITextFrame textFrame = autoShape.TextFrame;

// Entfernt den Standard‑Absatz
textFrame.Paragraphs.RemoveAt(0);

// Erstellt einen neuen Absatz
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Legt den Aufzählungsstil und das Bild des Absatzes fest
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Legt die Höhe der Aufzählung fest
paragraph.ParagraphFormat.Bullet.Height = 100;

// Fügt den Absatz dem TextFrame hinzu
textFrame.Paragraphs.Add(paragraph);

// Schreibt die Präsentation als PPTX‑Datei
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Schreibt die Präsentation als PPT‑Datei
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Mehrstufige Aufzählungen verwalten**
Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Greifen Sie über dessen Index auf die Referenz der betreffenden Folie zu.
3. Fügen Sie dem neuen Folie ein [autoshape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/) des Autoshapes zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides/paragraph/) und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

```c#
// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide slide = pres.Slides[0];
    
    // Fügt ein Autoshape hinzu und greift darauf zu
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das TextFrame des erstellten Autoshapes zu
    ITextFrame text = aShp.AddTextFrame("");
    
    // Löscht den Standard‑Absatz
    text.Paragraphs.Clear();

    // Fügt den ersten Absatz hinzu
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Legt die Aufzählungsebene fest
    para1.ParagraphFormat.Depth = 0;

    // Fügt den zweiten Absatz hinzu
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Legt die Aufzählungsebene fest
    para2.ParagraphFormat.Depth = 1;

    // Fügt den dritten Absatz hinzu
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Legt die Aufzählungsebene fest
    para3.ParagraphFormat.Depth = 2;

    // Fügt den vierten Absatz hinzu
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Legt die Aufzählungsebene fest
    para4.ParagraphFormat.Depth = 3;

    // Fügt die Absätze zur Sammlung hinzu
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Speichert die Präsentation als PPTX‑Datei
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Einen Absatz mit benutzerdefinierter nummerierter Liste verwalten**
Die [IBulletFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/) Schnittstelle bietet die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/numberedbulletstartwith) und weitere, die es Ihnen ermöglichen, Absätze mit benutzerdefinierter Nummerierung oder Formatierung zu verwalten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/) des Autoshapes zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides/paragraph/) und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/numberedbulletstartwith) auf 2.
7. Erstellen Sie die zweite Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Greift auf das TextFrame des erstellten Autoshapes zu
	ITextFrame textFrame = shape.TextFrame;

	// Entfernt den vorhandenen Standard‑Absatz
	textFrame.Paragraphs.RemoveAt(0);

	// Erste Liste
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Ersten Zeileneinzug für einen Absatz festlegen**

Verwenden Sie die Eigenschaft [IParagraphFormat.Indent](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/indent/) um den ersten Zeileneinzug eines Absatzes zu steuern. Diese Eigenschaft verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/marginleft/) wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [IParagraphFormat.Indent](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/indent/) wenn Sie nur die erste Zeile verschieben möchten.

Das folgende Beispiel erstellt mehrere Absätze und wendet unterschiedliche `Indent`‑Werte an, um zu zeigen, wie sich der erste Zeileneinzug auf das Layout auswirkt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) .
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie mehrere Absätze und setzen Sie für sie unterschiedliche [Indent](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/indent/)‑Werte.
6. Fügen Sie die Absätze dem Textrahmen hinzu.
7. Speichern Sie die geänderte Präsentation.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der erste Zeileneinzug der Absätze](first_line_indent.png)

## **Hängenden Einzug für einen Absatz festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Eigenschaft [IParagraphFormat.Indent](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/indent/). Setzen Sie `Indent` auf einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/marginleft/) die linke Position des Absatzkörpers, und [IParagraphFormat.Indent](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/indent/) definiert die Position der ersten Zeile relativ zu diesem Rand. Für einen hängenden Einzug setzen Sie einen positiven `MarginLeft`‑Wert und einen negativen `Indent`‑Wert.

Dieses Format ist nützlich für Bibliografien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper ausgerichtet sein sollen und nicht unter dem ersten Zeichen der ersten Zeile.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) .
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie Absätze und setzen Sie für jeden Absatz einen positiven [MarginLeft](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/marginleft/)‑Wert.
6. Setzen Sie einen negativen [Indent](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/indent/)‑Wert, um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze dem Textrahmen hinzu.
8. Speichern Sie die geänderte Präsentation.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der hängende Einzug der Absätze](hanging_indent.png)

## **End‑Absatz‑Lauf‑Eigenschaften verwalten**

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse.
2. Ermitteln Sie die Referenz für die Folie, die den Absatz enthält, über dessen Position.
3. Fügen Sie der Folie ein rechteckiges [autoshape](https://reference.aspose.com/slides/de/net/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/) mit zwei Absätzen hinzu.
5. Setzen Sie die `FontHeight` und den Schriftarttyp für die Absätze.
6. Setzen Sie die End‑Eigenschaften für die Absätze.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **HTML‑Text in Absätze importieren**
Aspose.Slides bietet erweiterte Unterstützung für das Importieren von HTML‑Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse.
2. Greifen Sie über dessen Index auf die Referenz der betreffenden Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/net/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standard‑Absatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader ein.
7. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides/paragraph/).
8. Fügen Sie den Inhalt der HTML‑Datei aus dem gelesenen TextReader zur [ParagraphCollection](https://reference.aspose.com/slides/de/net/aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

```c#
// Erstellt eine leere Präsentationsinstanz
using (Presentation pres = new Presentation())
{
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    ISlide slide = pres.Slides[0];

    // Fügt das AutoShape hinzu, das den HTML‑Inhalt beherbergen soll
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Fügt dem Shape ein TextFrame hinzu
    ashape.AddTextFrame("");

    // Entfernt alle Absätze im hinzugefügten TextFrame
    ashape.TextFrame.Paragraphs.Clear();

    // Lädt die HTML‑Datei mit einem StreamReader
    TextReader tr = new StreamReader("file.html");

    // Fügt den Text aus dem HTML‑StreamReader in das TextFrame ein
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Speichert die Präsentation
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Absatztext nach HTML exportieren**
Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (enthalten in Absätzen) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über dessen Index auf die Referenz der betreffenden Folie zu.
3. Greifen Sie auf das Shape zu, das den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/) des Shapes zu.
5. Erzeugen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Start‑Index an den StreamWriter weiter und exportieren Sie die gewünschten Absätze.

```c#
// Lädt die Präsentationsdatei
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Greift auf die standardmäßige erste Folie der Präsentation zu
    ISlide slide = pres.Slides[0];

    // Greift auf den gewünschten Index zu
    int index = 0;

    // Greift auf das hinzugefügte Shape zu
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Schreibt Absatzdaten nach HTML, indem der Startindex des Absatzes und die Anzahl der zu kopierenden Absätze angegeben werden
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Einen Absatz als Bild speichern**

In diesem Abschnitt zeigen wir zwei Beispiele, die demonstrieren, wie ein Textabsatz, dargestellt durch die [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/) Schnittstelle, als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes eines Shapes, das den Absatz enthält, mittels der `GetImage`‑Methoden der [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/) Schnittstelle, die Berechnung der Begrenzungsrechtecke des Absatzes innerhalb des Shapes und das Exportieren als Bitmap‑Bild. Diese Vorgehensweise ermöglicht das Extrahieren spezifischer Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Nehmen wir an, wir haben eine Präsentationsdatei namens **sample.pptx** mit einer Folie, wobei das erste Shape ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild des Shapes der ersten Folie der Präsentation und berechnen anschließend die Begrenzungen des zweiten Absatzes im TextFrame des Shapes. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet und im PNG‑Format gespeichert. Diese Methode ist besonders nützlich, wenn Sie einen bestimmten Absatz als separates Bild speichern möchten und dabei die genauen Abmessungen und die Formatierung des Textes beibehalten wollen.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Speichert das Shape im Speicher als Bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Erstellt ein Shape-Bitmap aus dem Speicher.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Berechnet die Grenzen des zweiten Absatzes.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Berechnet die Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Bereitet ein Bitmap für den Absatz vor.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Zeichnet den Absatz aus dem Shape‑Bitmap in das Absatz‑Bitmap neu.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Das Ergebnis:

![Das Absatz‑Bild](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatzbild hinzufügen. Das Shape wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht ein Bild mit höherer Auflösung. Die Absatz‑Grenzen werden anschließend unter Berücksichtigung der Skalierung berechnet. Skalierung ist besonders hilfreich, wenn ein detailreicheres Bild benötigt wird, beispielsweise für den Einsatz in hochwertigem Druckmaterial.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Speichert das Shape im Speicher als Bitmap mit Skalierung.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Erstellt ein Shape‑Bitmap aus dem Speicher.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Berechnet die Grenzen des zweiten Absatzes.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Berechnet die Größe für das Ausgabebild (Mindestgröße – 1x1 Pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Bereitet ein Bitmap für den Absatz vor.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Zeichnet den Absatz vom Shape‑Bitmap in das Absatz‑Bitmap neu.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**Kann ich das Zeilenumbruchverhalten in einem Textrahmen vollständig deaktivieren?**

Ja. Verwenden Sie die Einstellung für den Zeilenumbruch des Textrahmens ([WrapText](https://reference.aspose.com/slides/de/net/aspose.slides/textframeformat/wraptext/)), um den Umbruch auszuschalten, sodass Zeilen nicht an den Rändern des Rahmens getrennt werden.

**Wie kann ich die genauen Positionen eines bestimmten Absatzes auf der Folie ermitteln?**

Sie können das Begrenzungs‑Rechteck des Absatzes (und sogar eines einzelnen Portion) abrufen, um seine präzise Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/de/net/aspose.slides/paragraphformat/alignment/) ist eine Absatz‑Ebene‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/de/net/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreibprüfungssprache nur für einen Teil eines Absatzes (z. B. ein Wort) festlegen?**

Ja. Die Sprache wird auf Portion‑Ebene festgelegt ([PortionFormat.LanguageId](https://reference.aspose.com/slides/de/net/aspose.slides/baseportionformat/languageid/)), sodass mehrere Sprachen innerhalb eines einzigen Absatzes coexistieren können.