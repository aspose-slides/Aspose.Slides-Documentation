---
title: PowerPoint-Absätze in C# verwalten
type: docs
weight: 40
url: /net/manage-paragraph/
keywords: 
- Absatz hinzufügen
- Absätze verwalten
- Absatz-Einzug
- Absatz-Eigenschaften
- HTML-Text
- Absatztext exportieren
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Erstellen und verwalten Sie Absätze, Text, Einzüge und Eigenschaften in PowerPoint-Präsentationen in C# oder .NET"
---

Aspose.Slides bietet alle Schnittstellen und Klassen, die Sie benötigen, um mit PowerPoint-Texten, Absätzen und Teilbereichen in C# zu arbeiten.

* Aspose.Slides bietet die [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) Schnittstelle, um Ihnen das Hinzufügen von Objekten zu ermöglichen, die einen Absatz darstellen. Ein `ITextFame`-Objekt kann einen oder mehrere Absätze haben (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides bietet die [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) Schnittstelle, um Ihnen das Hinzufügen von Objekten zu ermöglichen, die Teilbereiche darstellen. Ein `IParagraph`-Objekt kann einen oder mehrere Teilbereiche haben (Sammlung von iPortions-Objekten).
* Aspose.Slides bietet die [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) Schnittstelle, um Ihnen das Hinzufügen von Objekten zu ermöglichen, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`-Objekt ist in der Lage, Texte mit unterschiedlichen Formatierungseigenschaften durch seine zugrunde liegenden `IPortion`-Objekte zu behandeln.

## **Fügen Sie mehrere Absätze mit mehreren Teilbereichen hinzu**

Diese Schritte zeigen Ihnen, wie Sie ein Textfeld mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Teilbereiche enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie über den Index auf den entsprechenden Folienverweis zu.
3. Fügen Sie eine Rechteck-[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) zur Folie hinzu.
4. Holen Sie sich das mit dem [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) verbundene ITextFrame.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) Objekte und fügen Sie sie zur `IParagraphs`-Sammlung des [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
6. Erstellen Sie drei [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) Objekte für jeden neuen `IParagraph` (zwei Portion-Objekte für den Standardabsatz) und fügen Sie jedes `IPortion`-Objekt zur IPortion-Sammlung jedes `IParagraph` hinzu.
7. Setzen Sie für jedes Teil einen Text.
8. Wenden Sie Ihre bevorzugten Formatierungsmerkmale auf jedes Teil an, indem Sie die von dem `IPortion`-Objekt bereitgestellten Formatierungseigenschaften verwenden.
9. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code ist eine Implementierung der Schritte zum Hinzufügen von Absätzen, die Teilbereiche enthalten:

```c#
// Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = pres.Slides[0];

    // Fügt eine Rechteck-IAutoShape hinzu
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Greift auf das TextFrame des AutoShapes zu
    ITextFrame tf = ashp.TextFrame;

    // Erstellt Absätze und Teilbereiche mit unterschiedlichen Textformaten
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
    // Speichert die modifizierte Präsentation
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Absatz mit Aufzählungszeichen verwalten**
Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie über den Index auf den entsprechenden Folienverweis zu.
3. Fügen Sie ein [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) zur ausgewählten Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) des Autoshapes zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) Klasse.
7. Setzen Sie den Aufzählungstyp für den Absatz auf `Symbol` und legen Sie das Aufzählungssymbol fest.
8. Setzen Sie den Absatztext.
9. Setzen Sie den Absatz-Einzug für das Aufzählungszeichen.
10. Setzen Sie eine Farbe für das Aufzählungszeichen.
11. Setzen Sie eine Höhe für das Aufzählungszeichen.
12. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang gemäß den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie einen Absatz mit Aufzählungszeichen hinzufügen:

```c#
// Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide slide = pres.Slides[0];

    // Fügt und greift auf das Autoshape zu
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das TextFrame des Autoshapes zu
    ITextFrame txtFrm = aShp.TextFrame;

    // Entfernt den Standardabsatz
    txtFrm.Paragraphs.RemoveAt(0);

    // Erstellt einen Absatz
    Paragraph para = new Paragraph();

    // Setzt einen Absatz-Aufzählungsstil und Symbol
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Setzt einen Absatztext
    para.Text = "Willkommen bei Aspose.Slides";

    // Setzt den Einzug für das Aufzählungszeichen
    para.ParagraphFormat.Indent = 25;

    // Setzt die Farbe des Aufzählungszeichens
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // Setzen Sie IsBulletHardColor auf true, um die eigene Aufzählungsfarbe zu verwenden

    // Setzt die Höhe des Aufzählungszeichens
    para.ParagraphFormat.Bullet.Height = 100;

    // Fügt den Absatz zum Textfeld hinzu
    txtFrm.Paragraphs.Add(para);

    // Erstellt den zweiten Absatz
    Paragraph para2 = new Paragraph();

    // Setzt den Absatz-Aufzählungstyp und -stil
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Fügt den Absatztext hinzu
    para2.Text = "Dies ist eine nummerierte Aufzählung";

    // Setzt den Einzug für das Aufzählungszeichen
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // Setzen Sie IsBulletHardColor auf true, um die eigene Aufzählungsfarbe zu verwenden

    // Setzt die Höhe des Aufzählungszeichens
    para2.ParagraphFormat.Bullet.Height = 100;

    // Fügt den Absatz zum Textfeld hinzu
    txtFrm.Paragraphs.Add(para2);

    // Speichert die modifizierte Präsentation
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);
}
```

## **Bilder als Aufzählungszeichen verwalten**
Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie über den Index auf den entsprechenden Folienverweis zu.
3. Fügen Sie ein [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) zur Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) des Autoshapes zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungstyp auf [Bild](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) und legen Sie das Bild fest.
9. Setzen Sie den Absatztext.
10. Setzen Sie den Absatz-Einzug für das Aufzählungszeichen.
11. Setzen Sie eine Farbe für das Aufzählungszeichen.
12. Setzen Sie eine Höhe für das Aufzählungszeichen.
13. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang basierend auf den vorherigen Schritten.
15. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie Bilder als Aufzählungszeichen hinzufügen und verwalten:

```c#
// Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation presentation = new Presentation();

// Greift auf die erste Folie zu
ISlide slide = presentation.Slides[0];

// Erstellt das Bild für die Aufzählungszeichen
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Fügt und greift auf das Autoshape zu
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Greift auf das TextFrame des Autoshapes zu
ITextFrame textFrame = autoShape.TextFrame;

// Entfernt den Standardabsatz
textFrame.Paragraphs.RemoveAt(0);

// Erstellt einen neuen Absatz
Paragraph paragraph = new Paragraph();
paragraph.Text = "Willkommen bei Aspose.Slides";

// Setzt den Absatz-Aufzählungsstil und das Bild
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Setzt die Höhe des Aufzählungszeichens
paragraph.ParagraphFormat.Bullet.Height = 100;

// Fügt den Absatz zum Textfeld hinzu
textFrame.Paragraphs.Add(paragraph);

// Schreibt die Präsentation als PPTX-Datei
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Schreibt die Präsentation als PPT-Datei
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Mehrere Ebenen von Aufzählungszeichen verwalten**
Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Mehrstufige Aufzählungszeichen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie über den Index auf den entsprechenden Folienverweis zu.
3. Fügen Sie ein [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) in die neue Folie ein.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) des Autoshapes zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz mit der `Paragraph` Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz mit der `Paragraph` Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz mit der `Paragraph` Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie mehrere Ebenen von Aufzählungszeichen hinzufügen und verwalten:

```c#
// Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide slide = pres.Slides[0];
    
    // Fügt und greift auf das Autoshape zu
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das TextFrame des erstellten Autoshapes zu
    ITextFrame text = aShp.AddTextFrame("");
    
    // Löscht den Standardabsatz
    text.Paragraphs.Clear();

    // Fügt den ersten Absatz hinzu
    IParagraph para1 = new Paragraph();
    para1.Text = "Inhalt";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Setzt die Bullet-Tiefe
    para1.ParagraphFormat.Depth = 0;

    // Fügt den zweiten Absatz hinzu
    IParagraph para2 = new Paragraph();
    para2.Text = "Zweite Ebene";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Setzt die Bullet-Tiefe
    para2.ParagraphFormat.Depth = 1;

    // Fügt den dritten Absatz hinzu
    IParagraph para3 = new Paragraph();
    para3.Text = "Dritte Ebene";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Setzt die Bullet-Tiefe
    para3.ParagraphFormat.Depth = 2;

    // Fügt den vierten Absatz hinzu
    IParagraph para4 = new Paragraph();
    para4.Text = "Vierte Ebene";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Setzt die Bullet-Tiefe
    para4.ParagraphFormat.Depth = 3;

    // Fügt die Absätze zur Sammlung hinzu
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Schreibt die Präsentation als PPTX-Datei
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Absätze mit benutzerdefinierter Nummerierung verwalten**
Das [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) Schnittstelle bietet die [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) Eigenschaft und andere, die es Ihnen ermöglichen, Absätze mit benutzerdefinierter Nummerierung oder Formatierung zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie ein [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) zur Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) des Autoshapes zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) auf 2.
7. Erstellen Sie die zweite Absatzinstanz mit der `Paragraph` Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz mit der `Paragraph` Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung hinzufügen und verwalten:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Greift auf das TextFrame des erstellten Autoshapes zu
	ITextFrame textFrame = shape.TextFrame;

	// Entfernt den vorhandenen Standardabsatz
	textFrame.Paragraphs.RemoveAt(0);

	// Erste Liste
	var paragraph1 = new Paragraph { Text = "Aufzählung 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "Aufzählung 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "Aufzählung 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Absatz-Einzug festlegen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Greifen Sie über den Index auf den entsprechenden Folienverweis zu.
1. Fügen Sie eine Rechteck-[autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) zur Folie hinzu.
1. Fügen Sie dem Rechteck-Autoshape ein [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Linien des Rechtecks aus.
1. Setzen Sie den Einzug für jeden [Absatz](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) über deren BulletOffset-Eigenschaft.
1. Schreiben Sie die modifizierte Präsentation als PPT-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie einen Absatz-Einzug festlegen:

```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();

// Holt sich die erste Folie
ISlide sld = pres.Slides[0];

// Fügt eine Rechteckform hinzu
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// Fügt dem Rechteck ein TextFrame hinzu
ITextFrame tf = rect.AddTextFrame("Das ist die erste Zeile \rDas ist die zweite Zeile \rDas ist die dritte Zeile");

// Stellt den Text so ein, dass er in die Form passt
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Blendet die Linien des Rechtecks aus
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// Holt den ersten Absatz im TextFrame und setzt dessen Einzug
IParagraph para1 = tf.Paragraphs[0];

// Setzt den Absatz-Aufzählungsstil und das Symbol
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// Holt den zweiten Absatz im TextFrame und setzt dessen Einzug
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// Holt den dritten Absatz im TextFrame und setzt dessen Einzug
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// Schreibt die Präsentation auf die Festplatte
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```

## **Hängenden Einzug für Absatz festlegen**

Dieser C#-Code zeigt Ihnen, wie Sie den hängenden Einzug für einen Absatz festlegen:  

```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Beispiel"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Hängenden Einzug für Absatz festlegen"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "Dieser C#-Code zeigt Ihnen, wie Sie den hängenden Einzug für einen Absatz festlegen: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **End-Eigenschaften von Absatzlauf für Absätze verwalten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich den Verweis auf die Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie dem Folien eine Rechteck-[autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) mit zwei Absätzen hinzu.
1. Setzen Sie die `FontHeight` und den Schrifttyp für die Absätze.
1. Setzen Sie die End-Eigenschaften für die Absätze.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie die End-Eigenschaften für Absätze in PowerPoint festlegen:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Beispieltext"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Beispieltext 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **HTML-Text in Absätze importieren**
Aspose.Slides bietet verbesserte Unterstützung für den Import von HTML-Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie über den Index auf den entsprechenden Folienverweis zu.
3. Fügen Sie ein [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) zur Folie hinzu.
4. Fügen Sie dem Autoshape ein [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quell-HTML-Datei mit einem TextReader.
7. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) Klasse.
8. Fügen Sie den Inhalt der gelesenen HTML-Datei, die den TextReader gelesen hat, der [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code ist eine Implementierung der Schritte zum Importieren von HTML-Text in Absätze:

```c#
// Erstellt eine leere Präsentationsinstanz
using (Presentation pres = new Presentation())
{
    // Greift auf die Standarderste Folie der Präsentation zu
    ISlide slide = pres.Slides[0];

    // Fügt dem AutoShape, das den HTML-Inhalt beherbergt, hinzu
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Fügt dem Form einen TextFrame hinzu
    ashape.AddTextFrame("");

    // Löscht alle Absätze im hinzugefügten TextFrame
    ashape.TextFrame.Paragraphs.Clear();

    // Lädt die HTML-Datei mithilfe des StreamReaders
    TextReader tr = new StreamReader("file.html");

    // Fügt den Text aus dem HTML-StreamReader in das TextFrame ein
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Speichert die Präsentation
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Absatztext ins HTML exportieren**
Aspose.Slides bietet verbesserte Unterstützung für den Export von Texten (die in Absätzen enthalten sind) ins HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf den entsprechenden Folienverweis zu.
3. Greifen Sie auf die Form zu, die den Text enthält, der ins HTML exportiert wird.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML-Datei hinzu.
6. Geben Sie einen Startindex für den StreamWriter an und exportieren Sie Ihre bevorzugten Absätze.

Dieser C#-Code zeigt Ihnen, wie Sie den Absatztext einer PowerPoint-Präsentation ins HTML exportieren:

```c#
// Lädt die Präsentationsdatei
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Greift auf die Standarderste Folie der Präsentation zu
    ISlide slide = pres.Slides[0];

    // Greift auf den erforderlichen Index zu
    int index = 0;

    // Greift auf die hinzugefügte Form zu
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Schreibt die Absatzdaten ins HTML, indem der Startindex des Absatzes und die Anzahl der Absätze festgelegt werden, die kopiert werden sollen
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```