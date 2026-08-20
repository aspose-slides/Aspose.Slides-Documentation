---
title: Verwalten von Präsentationsformen in .NET
linktitle: Formbearbeitung
type: docs
weight: 40
url: /de/net/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form klonen
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID abrufen
- Alternativtext der Form
- Form-Layout-Formate
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für .NET identifizieren, klonen, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides für .NET stellt die Formen auf einer Folie als geordnete [IShapeCollection](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die hinterste Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Er erklärt zunächst, wie man eine Form zuverlässig identifiziert, und zeigt dann, wie man Formen klont, entfernt, ausblendet und neu anordnet. Die letzten Abschnitte behandeln Layout‑bezogene Formatierung, SVG‑Export, Ausrichtung und Spiegelungseinstellungen. Jeder Beispielcode ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Workflow erfordert.

## **Formen identifizieren und finden**

Sammlungsindizes sind praktisch, wenn eine bekannte Datei verarbeitet wird, aber sie sind keine stabilen Bezeichner. Das Hinzufügen, Entfernen oder Neuordnen einer Form kann ihren Index ändern. Wählen Sie einen Bezeichner entsprechend der Art und Weise, wie die Präsentation erstellt und gepflegt wird:

- [Name](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/name/) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahlbereich von PowerPoint inspizieren. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollte eine Namenskonvention etabliert werden, wenn Code von ihnen abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/alternativetext/) ist nützlich, wenn eine Barrierefreiheitsbeschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Er ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie nicht stillschweigend sinnvollen Barrierefreiheitstext als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/officeinteropshapeid/) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der von PowerPoint‑Interop verwendeten Shape‑ID entspricht. Verwenden Sie ihn bei der Integration mit PowerPoint oder wenn Sie während der Lebensdauer einer Form einen eindeutigen Verweis benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige [UniqueId](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/uniqueid/)‑Eigenschaft hat Gültigkeit auf Präsentationsebene, ist jedoch für Add‑Ins gedacht und kann neu zugewiesen werden. Sie sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn eine langfristige Identität essenziell ist, behalten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Das folgende Beispiel sucht nach `Name` mit einem ordinalen Vergleich und gibt die folienbezogene Interop‑ID zurück. Wenn die Vorlage die erwartete Form nicht enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt fortzufahren.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Wenn ein Vorgang spezifisch für einen Formtyp ist, prüfen Sie das Interface, bevor Sie typspezifische Member verwenden. Dieses Beispiel aktualisiert Text und Alternativtext nur, wenn das benannte Objekt ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) ist.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Shape‑Sammlung ändern**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge der Formen ändert, verlassen Sie sich nicht weiter auf Indizes, die vor diesem Vorgang erfasst wurden.

### **Eine Form klonen**

[AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addclone/) erstellt eine unabhängige Kopie und fügt sie am Ende der Zielsammlung ein. [InsertClone](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/insertclone/) erstellt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon ohne Größenänderung; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erzeugt eine Ziel‑Folie, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone verändern nicht die Quellform.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Klonen kopiert den Inhalt und die Formatierung der Form, einschließlich ihres Namens und Alternativtexts. Weisen Sie dem Klon neue logische Bezeichner zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Sammlungs‑Element mit neuer Form‑Identität.

### **Formen entfernen**

[Remove](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/remove/) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Beim Entfernen mehrerer Übereinstimmungen während einer indizierten Iteration sollten Sie von hinten nach vorne traversieren, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest `slide.Shapes[i]`, nicht ein festes Sammlungs‑Element, und es castet die Form nicht unnötig.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Nach dem Entfernen ändern sich die Form‑Anzahl und die Indizes nachfolgender Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Verbinder, Animationen und andere Präsentations‑Features, die sich auf das entfernte Objekt beziehen können; das Entfernen einer sichtbaren Form kann mehr als das Aussehen der Folie verändern.

### **Eine Form ausblenden**

Das Setzen von [Hidden](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/hidden/) auf `true` lässt die Form in der Sammlung, verhindert jedoch ihr Erscheinen in der normalen Bildschirmpräsentation. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für Code verfügbar, sodass Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Ausblenden ist kein Löschen oder eine Sicherheitsmaßnahme. Das Objekt kann weiterhin entdeckt und von einem Benutzer oder Code wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Z‑Reihenfolge ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gemalt. [Reorder](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/reorder/) verschiebt eine bestehende Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist der hinterste; `Count - 1` ist der vorderste.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben auf den letzten Index bringt es nach vorne. Finalisieren Sie die Z‑Reihenfolge, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, da diese Vorgänge neue Sammlungs‑Elemente anhängen oder einfügen und die beabsichtigte Stapelung verändern können.

## **Formen auf Layout‑Folien überprüfen**

Normale Folien, Layout‑Folien und Master‑Folien besitzen separate Form‑Sammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Untersuchen Sie Layout‑Formen, wenn Sie die von einem Layout bereitgestellte Formatierung verstehen oder ändern müssen.

Das folgende Beispiel liest für jede Layout‑Form das [FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/fillformat/) und das [LineFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/lineformat/) ohne anzunehmen, dass jede Form eine `AutoShape` ist.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Das Bearbeiten eines Layouts kann mehrere Folien beeinflussen, die es verwenden. Bevor Sie eine Layout‑Form ändern, bestimmen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout nutzt.

## **Eine Form als SVG exportieren**

[WriteAsSvg](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/writeassvg/) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält nur die Form, nicht den gesamten Folienhintergrund oder benachbarte Formen.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Halten Sie die Präsentation während des Renderns offen. Die Ausgabe hängt von der Formatierung der Form sowie von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn entsorgen.

## **Formen ausrichten**

Die [SlideUtil.AlignShapes](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/alignshapes/)‑Überladungen richten entweder alle Formen oder ausgewählte Sammlungs‑Indizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/net/aspose.slides/shapesalignmenttype/) gibt die Kante, Mittellinie oder Verteilungsart an. Setzen Sie `alignToSlide` auf `true`, um die Folienkanten zu benutzen; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen am oberen Rand der Folie aus. Die zurückgegebenen Form‑Referenzen werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes umgewandelt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Ausrichtung ändert Positionen, nicht die Z‑Reihenfolge. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung genügend Formen benötigt, um Abstände zu definieren. Berechnen Sie die Indizes neu, wenn Sie die Sammlung ändern, bevor Sie die Methode aufrufen.

## **Eine Form spiegeln**

Die [ShapeFrame](https://reference.aspose.com/slides/de/net/aspose.slides/shapeframe/)‑Klasse speichert Position, Größe, horizontale und vertikale Spiegelungseinstellungen sowie Drehung. Ihre `FlipH`‑ und `FlipV`‑Werte verwenden [NullableBool](https://reference.aspose.com/slides/de/net/aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` bewahrt den nicht festgelegten/Standard‑Zustand.

Die Eingabepräsentation unten enthält eine nicht gespiegelte Form.

![Die Form vor dem Spiegeln](shape_to_be_flipped.png)

Das Beispiel bewahrt alle anderen Frame‑Werte und ersetzt nur die beiden Spiegelungs‑Einstellungen. Das ist wichtig, weil das Zuweisen eines neuen [Frame](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/frame/) das komplette Frame ersetzt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

Die gespeicherte Form ist horizontal und vertikal gespiegelt, während Position, Größe und Drehung erhalten bleiben.

![Die Form nach dem Spiegeln](flipped_shape.png)

## **FAQ**

**Soll ich einen Sammlungs‑Index als Form‑Bezeichner verwenden?**

Nur für kurzlebige Verarbeitung, wenn die Sammlung sich vor der Verwendung des Index nicht ändert. Bevorzugen Sie eine validierte `Name`‑ oder `AlternativeText`‑Konvention für erstellte Vorlagen oder `OfficeInteropShapeId` für slide‑bezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form sie aus der Z‑Reihenfolge?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu angeordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`AddClone` fügt den Klon an das Ende der Sammlung, also an die Vorderseite der Z‑Reihenfolge, an. Verwenden Sie `InsertClone`, um den Anfangs‑Index zu wählen, oder `Reorder` nach dem Hinzufügen aller Formen.