---
title: Verwalten von Aufzählungs- und nummerierten Listen in Präsentationen in .NET
linktitle: Listen verwalten
type: docs
weight: 70
url: /de/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs‑, Bild‑, mehrstufige und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für .NET erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für .NET ermöglicht das Erstellen und Formatieren von Aufzählungs‑ und nummerierten Listen in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listeneintrag ist ein Absatz, dessen Aufzählungseinstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die Eigenschaft [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) , um Listeneinstellungen auf Absatzebene zuzugreifen. Der Haupteinstiegspunkt ist [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), der ein [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellen
- eine Bildaufzählung erstellen
- eine mehrstufige Liste erstellen, indem die Absatztiefe festgelegt wird
- eine nummerierte Liste erstellen
- die Listformatierung in einer bestehenden Präsentation untersuchen und ändern
- tatsächliche Listensymbole und Nummern zusammen mit dem Absatztext auslesen

## **Aufzählungsliste erstellen**

Um eine Aufzählungsliste zu erstellen, fügen Sie [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) Objekte zu einem [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) hinzu und setzen [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) auf [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Anschließend können Sie [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/) und [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) festlegen, um das Aussehen der Aufzählungszeichen zu steuern.

Der folgende C#‑Code demonstriert, wie man in einer Folie eine Aufzählungsliste erstellt:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Symbolaufzählungen](symbol_bullets.png)

## **Nummerierte Liste erstellen**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) auf [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Sie können außerdem ein Nummerierungsformat mit [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) auswählen oder [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) festlegen, wenn die Liste mit einem anderen Wert als 1 beginnen soll.

Der folgende C#‑Code zeigt, wie man in einer Folie eine nummerierte Liste erstellt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die nummerierten Aufzählungen](numbered_bullets.png)

## **Bildaufzählung erstellen**

Aspose.Slides ermöglicht es, ein normales Aufzählungszeichen durch ein Bild zu ersetzen. Bildaufzählungen funktionieren am besten mit einfachen Bildern, die auch in kleiner Größe lesbar bleiben, wie Symbol‑Icons oder kleine transparente PNG‑Dateien.

{{% alert color="info" title="Note" %}}
Idealerweise sollten Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, eine einfache Grafik mit transparentem Hintergrund wählen. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungszeichen.

Beachten Sie, dass das Bild auf eine sehr kleine Größe skaliert wird. Deshalb empfehlen wir dringend, ein Bild auszuwählen, das auch als Aufzählungszeichen in einer Liste klar und visuell wirksam bleibt.
{{% /alert %}}

Um eine Bildaufzählung zu erstellen, fügen Sie ein Bild zu [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) hinzu und weisen das zurückgegebene Bildobjekt [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) zu. Setzen Sie [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) auf [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine "image.png":

![Ein Bild für die Aufzählungen](picture_for_bullets.png)

Der folgende C#‑Code zeigt, wie man Bildaufzählungen in einer Folie erstellt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Bildaufzählungen](picture_bullets.png)

## **Mehrstufige Liste erstellen**

Verwenden Sie [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/), um Listenelemente auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw.

Der folgende C#‑Code zeigt, wie man eine mehrstufige Aufzählungsliste erstellt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die mehrstufige Liste](multilevel_list.png)

## **Eine bestehende Liste ändern**

Um die Listformatierung in einer bestehenden Präsentation zu ändern, greifen Sie auf den Zielabsatz zu und aktualisieren dessen [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) Einstellungen. Die selben Eigenschaften, die zum Erstellen von Listen verwendet werden, können zum Untersuchen oder Modifizieren von Listen verwendet werden, die aus einer PPT‑, PPTX‑ oder ODP‑Datei geladen wurden.

Der folgende C#‑Code ändert den ersten Absatz in einem Text‑Frame, sodass er einen nummerierten Listenstil verwendet:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **Tatsächliche Aufzählungswerte auslesen**

Beim Extrahieren von Präsentationsinhalten sollten Listensymbole zusammen mit dem Absatztext beibehalten werden. Rufen Sie [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) auf und greifen Sie auf [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) zu, um das effektive Aufzählungsformat zu erhalten. Prüfen Sie dessen [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/), bevor Sie [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) auslesen.

Für nummerierte Listen unterscheiden Sie diese drei Werte:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) bestimmt das Format, z. B. arabische Zahlen gefolgt von einem Punkt oder Kleinbuchstaben gefolgt von einem Punkt.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) gibt die Startnummer für eine Gruppe nummerierter Absätze an.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) liefert das formatierte Symbol für einen bestimmten Absatz. Beispielsweise gibt das zweite Element in einer Liste, die bei 5 beginnt, `6.` zurück.

Bewahren Sie [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) bei jedem Absatz, um dessen Verschachtelungsgrad beizubehalten. Das tatsächliche Symbol kodiert nicht die gesamte Hierarchie: ein verschachteltes Element kann `c.` zurückgeben, anstatt eines kombinierten Labels wie `6.c.`.

Das folgende eigenständige Beispiel erstellt Listen, speichert sie in einer Präsentation und lädt die Präsentation erneut, um für jeden Absatz den Text, die Tiefe, den Aufzählungstyp und den tatsächlichen Wert auszugeben. Das kleine blaue Bildsymbol wird aus eingebettetem SVG erstellt.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Erstelle einen Bildmarker ohne externe Bilddatei.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

Die Quelllisten werden unten angezeigt.

![Listen, die bei 5 beginnen, verschachtelte Buchstaben- und römische Zahlen‑Elemente, ein Symbol‑Marker, ein Absatz ohne Aufzählungszeichen und ein blauer Bild‑Marker](actual_bullet_values.png)

Der Bericht entspricht den in PowerPoint angezeigten Markern:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Für [BulletType.None und BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) gibt [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) `null` zurück, nicht eine leere Zeichenkette. Behandeln Sie diese Typen separat: Erstere hat keinen Marker, während letzterer das separate Extrahieren des Aufzählungsbildes erfordert. Eine Bildaufzählung kann nicht allein durch das Extrahieren eines Textmarkers reproduziert werden.

## **FAQ**

**Können Aufzählungs‑ und nummerierte Listen in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides bewahrt die Listformatierung, wenn das Zielformat das entsprechende Textlayout und die Aufzählungsfunktionen unterstützt.

**Kann ich Listen in bestehenden Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den Zielabsatz zu, prüfen oder aktualisieren Sie dessen [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listeneinträgen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.