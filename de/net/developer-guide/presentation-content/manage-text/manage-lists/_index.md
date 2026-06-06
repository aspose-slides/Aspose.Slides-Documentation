---
title: Aufzählungs‑ und nummerierte Listen in Präsentationen in .NET verwalten
linktitle: Listen verwalten
type: docs
weight: 70
url: /de/net/manage-lists/
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
description: "Erfahren Sie, wie Sie mit Aspose.Slides für .NET Aufzählungs‑, Bild‑, mehrstufige und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für .NET ermöglicht das Erstellen und Formatieren von Aufzählungs‑ und Nummerierungslisten in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listenelement ist ein Absatz, dessen Aufzählungseinstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/paragraphformat/) Eigenschaft, um Listeneinstellungen auf Absatzebene zuzugreifen. Der Haupteinstiegspunkt ist [IParagraphFormat.Bullet](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/bullet/), der ein [IBulletFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/) Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellt
- eine Bildaufzählung erstellt
- eine mehrstufige Liste erstellt, indem die Absatztiefe festgelegt wird
- eine nummerierte Liste erstellt
- Listformatierung in einer vorhandenen Präsentation überprüft und ändert

## **Eine Aufzählungsliste erstellen**

Um eine Aufzählungsliste zu erstellen, fügen Sie [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/)‑Objekte zu einem [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) hinzu und setzen Sie [IBulletFormat.Type](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/type/) auf [BulletType.Symbol](https://reference.aspose.com/slides/de/net/aspose.slides/bullettype/). Anschließend können Sie [IBulletFormat.Char](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/color/) und [IBulletFormat.Height](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/height/) festlegen, um das Erscheinungsbild der Aufzählungszeichen zu steuern.

Der folgende C#‑Code demonstriert, wie man in einer Folie eine Aufzählungsliste erstellt:

```csharp
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

![Die Symbol‑Aufzählungen](symbol_bullets.png)

## **Eine nummerierte Liste erstellen**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [IBulletFormat.Type](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/type/) auf [BulletType.Numbered](https://reference.aspose.com/slides/de/net/aspose.slides/bullettype/). Sie können außerdem ein Nummerierungsformat mit [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/numberedbulletstyle/) wählen oder [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/numberedbulletstartwith/) festlegen, wenn die Liste mit einem anderen Wert als 1 beginnen soll.

Der folgende C#‑Code zeigt, wie man in einer Folie eine nummerierte Liste erstellt:

```csharp
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

## **Eine Bildaufzählung erstellen**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungszeichen durch ein Bild zu ersetzen. Bildaufzählungen funktionieren am besten mit einfachen Bildern, die auch in kleiner Größe lesbar bleiben, z. B. Icons oder kleine transparente PNG‑Dateien.

{{% alert color="primary" %}}
Idealerweise wählen Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, eine einfache Grafik mit transparentem Hintergrund. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungszeichen.
{{% /alert %}}

Um eine Bildaufzählung zu erstellen, fügen Sie ein Bild zu [Presentation.Images](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/images/) hinzu und weisen Sie das zurückgegebene Bildobjekt [IBulletFormat.Picture](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/picture/) zu. Setzen Sie [IBulletFormat.Type](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/type/) auf [BulletType.Picture](https://reference.aspose.com/slides/de/net/aspose.slides/bullettype/), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine „image.png“:

![Ein Bild für die Aufzählungen](picture_for_bullets.png)

Der folgende C#‑Code zeigt, wie man Bildaufzählungen in einer Folie erstellt:

```csharp
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

![Die Bild‑Aufzählungen](picture_bullets.png)

## **Eine mehrstufige Liste erstellen**

Verwenden Sie [IParagraphFormat.Depth](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/depth/), um Listenelemente auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw.

Der folgende C#‑Code zeigt, wie man eine mehrstufige Aufzählungsliste erstellt:

```csharp
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

## **Eine vorhandene Liste ändern**

Um die Listformatierung in einer vorhandenen Präsentation zu ändern, greifen Sie auf den Zielabsatz zu und aktualisieren dessen [IParagraphFormat.Bullet](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/bullet/)‑Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können zum Prüfen oder Ändern von Listen verwendet werden, die aus einer PPT‑, PPTX‑ oder ODP‑Datei geladen wurden.

Der folgende C#‑Code ändert den ersten Absatz in einem Textfeld, sodass er einen nummerierten Listenstil verwendet:

```csharp
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

## **FAQ**

**Können Aufzählungs‑ und nummerierte Listen in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides erhält die Listformatierung, wenn das Zielformat die entsprechenden Textlayout‑ und Aufzählungs‑Features unterstützt.

**Kann ich Listen in vorhandenen Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den Zielabsatz zu, prüfen oder aktualisieren Sie dessen [IParagraphFormat.Bullet](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/bullet/)‑Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listenelementen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriften die benötigten Zeichen unterstützen.