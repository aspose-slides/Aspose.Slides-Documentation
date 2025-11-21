---
title: PowerPoint-Textabsätze in .NET verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/net/manage-paragraph/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatzeinzug
- Hängender Einzug
- Absatz-Aufzählungszeichen
- Nummerierte Liste
- Aufzählungsliste
- Absatzeigenschaften
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
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für .NET — optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX‑ und ODP‑Präsentationen in C#."
---

Aspose.Slides stellt alle Schnittstellen und Klassen bereit, die Sie benötigen, um in C# mit PowerPoint-Texten, -Absätzen und -Portionen zu arbeiten.

* Aspose.Slides stellt die Schnittstelle [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) bereit, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `ITextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erzeugt).
* Aspose.Slides stellt die Schnittstelle [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) bereit, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `IParagraph`‑Objekt kann eine oder mehrere Portionen enthalten (eine Sammlung von iPortions‑Objekten).
* Aspose.Slides stellt die Schnittstelle [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) bereit, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Textrahmen hinzufügen, der 3 Absätze enthält, und jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein Rechteck‑[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
4. Rufen Sie das mit dem [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) verknüpfte ITextFrame ab.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)‑Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/)‑Objekte (zwei Portion‑Objekte für den Standardabsatz) und fügen Sie jedes `IPortion`‑Objekt der IPortion‑Sammlung jedes `IParagraph` hinzu.
7. Legen Sie für jede Portion einen Text fest.
8. Wenden Sie die gewünschten Formatierungsfunktionen auf jede Portion an, indem Sie die vom `IPortion`‑Objekt bereitgestellten Formatierungseigenschaften verwenden.
9. Speichern Sie die geänderte Präsentation.

```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = pres.Slides[0];

    // Fügt eine Rechteck-IAutoShape hinzu
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Greift auf das TextFrame der AutoShape zu
    ITextFrame tf = ashp.TextFrame;

    // Erstellt Absätze und Portionen mit unterschiedlichen Textformaten
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


## **Absatz-Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufzählungsabsätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der ausgewählten Folie eine [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) der Autoshape zu. 
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) .
8. Setzen Sie den Aufzählungs‑`Type` des Absatzes auf `Symbol` und legen Sie das Aufzählungszeichen fest.
9. Legen Sie den Absatz‑`Text` fest.
10. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für die Aufzählung fest.
12. Legen Sie eine Höhe für die Aufzählung fest.
13. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten 7 bis 13.
15. Speichern Sie die Präsentation.

```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide slide = pres.Slides[0];


    // Fügt eine AutoShape hinzu und greift darauf zu
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das TextFrame der AutoShape zu
    ITextFrame txtFrm = aShp.TextFrame;

    // Entfernt den Standardabsatz
    txtFrm.Paragraphs.RemoveAt(0);

    // Erstellt einen Absatz
    Paragraph para = new Paragraph();

    // Setzt den Aufzählungsstil und das Symbol für den Absatz
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Setzt den Absatztext
    para.Text = "Welcome to Aspose.Slides";

    // Setzt den Aufzählungseinzug
    para.ParagraphFormat.Indent = 25;

    // Setzt die Aufzählungsfarbe
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // setzt IsBulletHardColor auf true, um eine eigene Aufzählungsfarbe zu verwenden

    // Setzt die Aufzählungshöhe
    para.ParagraphFormat.Bullet.Height = 100;

    // Fügt dem TextFrame einen Absatz hinzu
    txtFrm.Paragraphs.Add(para);

    // Erstellt einen zweiten Absatz
    Paragraph para2 = new Paragraph();

    // Setzt den Aufzählungstyp und -stil für den Absatz
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Fügt den Absatztext hinzu
    para2.Text = "This is numbered bullet";

    // Setzt den Aufzählungseinzug
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // setzt IsBulletHardColor auf true, um eine eigene Aufzählungsfarbe zu verwenden

    // Setzt die Aufzählungshöhe
    para2.ParagraphFormat.Bullet.Height = 100;

    // Fügt dem TextFrame einen Absatz hinzu
    txtFrm.Paragraphs.Add(para2);


    // Speichert die geänderte Präsentation
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Bild-Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie eine [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) der Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) .
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) .
8. Setzen Sie den Aufzählungs‑Typ auf [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) und legen Sie das Bild fest.
9. Legen Sie den Absatz‑`Text` fest.
10. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für die Aufzählung fest.
12. Setzen Sie eine Höhe für die Aufzählung.
13. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang anhand der vorherigen Schritte.
15. Speichern Sie die geänderte Präsentation.

```c#
// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
Presentation presentation = new Presentation();

// Greift auf die erste Folie zu
ISlide slide = presentation.Slides[0];

// Instanziert das Bild für Aufzählungszeichen
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Fügt eine AutoShape hinzu und greift darauf zu
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Greift auf das TextFrame der AutoShape zu
ITextFrame textFrame = autoShape.TextFrame;

// Entfernt den Standardabsatz
textFrame.Paragraphs.RemoveAt(0);

// Erstellt einen neuen Absatz
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Setzt den Absatz‑Aufzählungsstil und das Bild
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Setzt die Aufzählungshöhe
paragraph.ParagraphFormat.Bullet.Height = 100;

// Fügt den Absatz dem TextFrame hinzu
textFrame.Paragraphs.Add(paragraph);

// Speichert die Präsentation als PPTX‑Datei
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Speichert die Präsentation als PPT‑Datei
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Mehrstufige Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie in der neuen Folie eine [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) der Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die Klasse [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide slide = pres.Slides[0];
    
    // Fügt eine AutoShape hinzu und greift darauf zu
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Greift auf das TextFrame der erstellten AutoShape zu
    ITextFrame text = aShp.AddTextFrame("");
    
    // Löscht den Standardabsatz
    text.Paragraphs.Clear();

    // Fügt den ersten Absatz hinzu
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Setzt die Aufzählungsebene
    para1.ParagraphFormat.Depth = 0;

    // Fügt den zweiten Absatz hinzu
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Setzt die Aufzählungsebene
    para2.ParagraphFormat.Depth = 1;

    // Fügt den dritten Absatz hinzu
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Setzt die Aufzählungsebene
    para3.ParagraphFormat.Depth = 2;

    // Fügt den vierten Absatz hinzu
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Setzt die Aufzählungsebene
    para4.ParagraphFormat.Depth = 3;

    // Fügt die Absätze zur Sammlung hinzu
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Speichert die Präsentation als PPTX-Datei
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Absatz mit benutzerdefinierter nummerierter Liste verwalten**

Die Schnittstelle [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) stellt die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) und weitere bereit, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können.

1. Erstellen Sie eine Instanz der Klasse [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie eine [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) der Autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die Klasse [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) auf 2.
7. Erstellen Sie die zweite Absatzinstanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Greift auf das TextFrame der erstellten AutoShape zu
	ITextFrame textFrame = shape.TextFrame;

	// Entfernt den standardmäßig vorhandenen Absatz
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


## **Absatz‑Einzug festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein Rechteck‑[autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie dem Rechteck‑autoshape ein [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) mit drei Absätzen hinzu.
5. Blenden Sie die Rechtecklinien aus.
6. Setzen Sie den Einzug für jeden [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) über dessen BulletOffset‑Eigenschaft.
7. Speichern Sie die geänderte Präsentation als PPT‑Datei.

```c#
// Instanziiert die Presentation-Klasse
Presentation pres = new Presentation();

// Holt die erste Folie
ISlide sld = pres.Slides[0];

// Fügt ein Rechteck-Shape hinzu
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// Fügt dem Rechteck ein TextFrame hinzu
ITextFrame tf = rect.AddTextFrame("This is first line \rThis is second line \rThis is third line");

// Setzt den Text so, dass er in die Form passt
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Versteckt die Linien des Rechtecks
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// Holt den ersten Absatz im TextFrame und setzt dessen Einzug
IParagraph para1 = tf.Paragraphs[0];

// Setzt den Aufzählungsstil und das Symbol des Absatzes
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

Dieser C#‑Code zeigt, wie Sie den hängenden Einzug für einen Absatz festlegen:  
```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Example"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Set Hanging Indent for Paragraph"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "This C# code shows you how to set the hanging indent for a paragraph: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **End‑Paragraph‑Run‑Eigenschaften für Absatz verwalten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Holen Sie die Referenz der Folie, die den Absatz enthält, über deren Position.
3. Fügen Sie der Folie ein Rechteck‑[autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) mit zwei Absätzen hinzu.
5. Setzen Sie die `FontHeight` und den Schrifttyp für die Absätze.
6. Setzen Sie die End‑Eigenschaften für die Absätze.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie eine [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader.
7. Erstellen Sie die erste Absatzinstanz über die Klasse [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) .
8. Fügen Sie den HTML‑Dateiinhalt aus dem gelesenen TextReader zur [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

```c#
// Erstellt leere Präsentationsinstanz
using (Presentation pres = new Presentation())
{
    // Greift auf die standardmäßige erste Folie der Präsentation zu
    ISlide slide = pres.Slides[0];

    // Fügt das AutoShape hinzu, um den HTML-Inhalt zu beherbergen
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Fügt dem Shape ein Textframe hinzu
    ashape.AddTextFrame("");

    // Löscht alle Absätze im hinzugefügten Textframe
    ashape.TextFrame.Paragraphs.Clear();

    // Lädt die HTML-Datei mittels StreamReader
    TextReader tr = new StreamReader("file.html");

    // Fügt den Text aus dem HTML-StreamReader in das Textframe ein
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Speichert die Präsentation
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Absatztexte nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (die in Absätzen enthalten sind) nach HTML.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Greifen Sie auf die Form zu, die den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Startindex an den StreamWriter weiter und exportieren Sie die gewünschten Absätze.

```c#
// Lädt die Präsentationsdatei
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Greift auf die standardmäßige erste Folie der Präsentation zu
    ISlide slide = pres.Slides[0];

    // Greift auf den benötigten Index zu
    int index = 0;

    // Greift auf das hinzugefügte Shape zu
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Schreibt Absatzdaten ins HTML, indem Startindex und Anzahl der zu kopierenden Absätze angegeben werden
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```


## **Einen Absatz als Bild speichern**

In diesem Abschnitt untersuchen wir zwei Beispiele, die zeigen, wie ein Textabsatz, der durch die Schnittstelle [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) repräsentiert wird, als Bild gespeichert werden kann. Beide Beispiele beinhalten das Abrufen des Bildes einer Form, die den Absatz enthält, mithilfe der `GetImage`‑Methoden der Schnittstelle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), das Berechnen der Grenzen des Absatzes innerhalb der Form und das Exportieren als Bitmap‑Bild. Diese Vorgehensweisen erlauben es, spezifische Textteile aus PowerPoint‑Präsentationen zu extrahieren und als separate Bilder zu speichern, was in verschiedenen Szenarien nützlich sein kann.

Angenommen, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild der Form aus der ersten Folie der Präsentation und berechnen anschließend die Grenzen des zweiten Absatzes im Textrahmen der Form. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet, das im PNG‑Format gespeichert wird. Diese Methode ist besonders nützlich, wenn Sie einen bestimmten Absatz als separates Bild speichern möchten, wobei die genauen Abmessungen und die Formatierung des Textes erhalten bleiben.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Speichert die Form im Speicher als Bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Erstellt ein Form-Bitmap aus dem Speicher.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Berechnet die Grenzen des zweiten Absatzes.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Berechnet die Größe des Ausgabebildes (Mindestgröße - 1x1 Pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Bereitet ein Bitmap für den Absatz vor.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Zeichnet den Absatz vom Form-Bitmap in das Absatz-Bitmap neu.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


![The paragraph image](paragraph_to_image_output.png)

**Example 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatzbild hinzufügen. Die Form wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch wird beim Export des Absatzes ein Ausgabebild mit höherer Auflösung ermöglicht. Die Absatzgrenzen werden anschließend unter Berücksichtigung des Maßstabs berechnet. Skalierung kann besonders nützlich sein, wenn ein detaillierteres Bild benötigt wird, beispielsweise für den Einsatz in hochwertigen Druckmaterialien.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


## **FAQ**

**Kann ich den Zeilenumbruch in einem Textfeld vollständig deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Einstellung des Textfelds ([WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)), um den Umbruch zu deaktivieren, sodass Zeilen nicht an den Rändern des Rahmens umbrechen.

**Wie kann ich die genauen Folien‑Grenzen eines bestimmten Absatzes erhalten?**

Sie können das Begrenzungs‑Rechteck des Absatzes (und sogar einer einzelnen Portion) abrufen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/alignment/) ist eine Einstellung auf Absatz‑Ebene in [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreibprüfungssprache nur für einen Teil eines Absatzes (z. B. ein Wort) festlegen?**

Ja. Die Sprache wird auf Portion‑Ebene ([PortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/)) festgelegt, sodass mehrere Sprachen innerhalb eines Absatzes koexistieren können.