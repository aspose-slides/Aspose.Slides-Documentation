---
title: Verwalten von Präsentationsformen in .NET
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/net/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID abrufen
- alternativer Text der Form
- Form-Anpassungspunkt
- voreingestellte Formanpassung
- Formgeometrie
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
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für .NET identifizieren, anpassen, duplizieren, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for .NET stellt die Formen auf einer Folie als geordnete [IShapeCollection](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die hinterste Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Zuerst wird erklärt, wie man eine Form zuverlässig identifiziert und voreingestellte Formanpassungspunkte ändert, dann wird gezeigt, wie man Formen klont, entfernt, ausblendet und neu anordnet. Die abschließenden Abschnitte behandeln Layout‑Ebene‑Formatierung, SVG‑Export, Ausrichtung und Spiegel‑Einstellungen. Jeder Abschnitt ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Workflow erfordert.

## **Formen identifizieren und finden**

Sammlungsindizes sind praktisch, wenn eine bekannte Datei verarbeitet wird, aber sie sind keine stabilen Kennungen. Das Hinzufügen, Entfernen oder Neuordnen einer Form kann ihren Index ändern. Wählen Sie eine Kennung gemäß der Art, wie die Präsentation erstellt und gepflegt wird:

- [Name](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/name/) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahlfenster von PowerPoint einsehen. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollte eine Namenskonvention definiert werden, wenn Code darauf angewiesen ist.
- [AlternativeText](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/alternativetext/) ist nützlich, wenn eine Barrierefreiheits‑Beschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Er ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit neu geschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie nicht stillschweigend bedeutungsvollen Barrierefreiheits‑Text als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/officeinteropshapeid/) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der Shape‑ID entspricht, die von PowerPoint‑Interop verwendet wird. Verwenden Sie ihn, wenn Sie mit PowerPoint integrieren oder während der Lebensdauer einer Form eine eindeutige Referenz benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält eine eigene ID.

Die verwandte [UniqueId](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/uniqueid/)‑Eigenschaft hat Präsentations‑Bereich, ist jedoch für Add‑Ins gedacht und kann neu zugewiesen werden. Sie sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn eine langfristige Identität wichtig ist, speichern Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Ein praktisches Beispiel zum Lesen und Aktualisieren des alternativen Text‑Titels und der Beschreibung finden Sie unter [Manage Alternative Text Titles and Descriptions](/slides/de/net/presentation-accessibility/). Verwenden Sie alternativen Text, um die Bedeutung der visuellen Darstellung für Leser zu erklären, und halten Sie ihn getrennt von Formnamen, die vom Code zum Suchen von Formen verwendet werden.

Das folgende Beispiel sucht nach `Name` mit einem ordinalen Vergleich und gibt die folienbezogene Interop‑ID aus. Wenn die Vorlage die erwartete Form nicht enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt fortzufahren.

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

Wenn ein Vorgang funktionsspezifisch ist, prüfen Sie die Schnittstelle, bevor Sie typenspezifische Mitglieder verwenden. Dieses Beispiel aktualisiert Text und alternativen Text nur, wenn das benannte Objekt ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) ist.

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

## **Voreingestellte Formanpassungen identifizieren und ändern**

Voreingestellte Geometrieformen können Anpassungspunkte offenlegen, die Eigenschaften wie Eckgröße, Pfeil‑Proportionen oder Bogenwinkel steuern. Greifen Sie über die schreibgeschützte [IGeometryShape.Adjustments](https://reference.aspose.com/slides/de/net/aspose.slides/igeometryshape/adjustments/)‑Sammlung darauf zu. Die Sammlung selbst wird von der Form bereitgestellt, aber jedes [IAdjustValue](https://reference.aspose.com/slides/de/net/aspose.slides/iadjustvalue/) enthält einen Wert, der geändert werden kann.

Verlassen Sie sich nicht ausschließlich auf einen festen Sammlungs‑Index. Durchlaufen Sie die Anpassungen und prüfen Sie die schreibgeschützte [Type](https://reference.aspose.com/slides/de/net/aspose.slides/adjustvalue/type/)‑Eigenschaft, deren [ShapeAdjustmentType](https://reference.aspose.com/slides/de/net/aspose.slides/shapeadjustmenttype/)‑Wert beschreibt, was die Anpassung steuert. Die schreibgeschützte [Name](https://reference.aspose.com/slides/de/net/aspose.slides/adjustvalue/name/)‑Eigenschaft liefert zusätzliche Identifikationsinformationen und ist besonders nützlich, wenn ein Vorgaben‑Set mehr als eine Anpassung mit demselben semantischen Typ enthält.

Verwenden Sie die Werte‑Eigenschaft, die der Bedeutung der Anpassung entspricht:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | Größe abgerundeter Ecken | [RawValue](https://reference.aspose.com/slides/de/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Dicke eines Pfeilschwanzes | `RawValue` |
| `ArrowheadLength` | Länge einer Pfeilspitze | `RawValue` |
| `ArrowheadWidth` | Breite einer Pfeilspitze | `RawValue` |
| `StartAngle` | Startwinkel eines Kuchen- oder Bogensegments | [AngleValue](https://reference.aspose.com/slides/de/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Endwinkel eines Kuchen- oder Bogensegments | `AngleValue` |

`Type` und `Name` können nicht zugewiesen werden. `RawValue` ist ein les‑/schreibbarer Integer in den nativen Geometrie‑Einheiten der Vorgabe, während `AngleValue` ein les‑/schreibbarer Winkel in Grad ist. Anzahl, Reihenfolge, Bedeutung und gültiger Wertebereich der Anpassungen hängen vom voreingestellten [ShapeType](https://reference.aspose.com/slides/de/net/aspose.slides/igeometryshape/shapetype/) ab. Ein für eine Vorgabe gültiger Wert kann für eine andere ungültig sein oder eine andere Wirkung haben.

Wenn `Type` `ShapeAdjustmentType.Custom` ist, erkennt die API keine standardisierte semantische Bedeutung. Prüfen Sie `Name`, den Vorgabetyp und den bestehenden Wert und lassen Sie die Anpassung unverändert, sofern die erwartete Bedeutung und der Werte‑Bereich nicht bekannt sind. Auch bei erkannten Typen sollte geprüft werden, ob derselbe Typ mehr als einmal vorkommt, bevor ein Wert gewählt wird. Der Artikel [Connector](/slides/de/net/connector/) zeigt diese Situation mit Biegeschneidungen von Verbindern.

Das folgende vollständige Beispiel erstellt Standard‑ und modifizierte Versionen von drei voreingestellten Formen. Es durchläuft jede Anpassung, gibt deren `Name` und `Type` aus, ändert größenbezogene Werte über `RawValue`, ändert Winkel über `AngleValue` und speichert das Ergebnis. Die linke Spalte behält die Standardgeometrie; die rechte Spalte zeigt das angepasste abgerundete Rechteck, den Vier‑Weg‑Pfeil und das Kuchen‑Diagramm.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Fügt Kopfzeilen für die Standard- und angepassten Formspalten hinzu.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Die semantische Typ‑Prüfung vor einer Werte‑Änderung macht den Code eindeutig hinsichtlich seiner Absicht und verhindert Annahmen, dass ein bestimmter Sammlungs‑Index dieselbe Bedeutung bei unterschiedlichen Vorgaben hat.

## **Die Formsammlung ändern**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge der Formen ändert, dürfen Sie nicht mehr auf zuvor erfasste Indizes vertrauen.

### **Eine Form klonen**

[AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addclone/) erstellt eine unabhängige Kopie und fügt sie an das Ziel‑Sammlung an. [InsertClone](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/insertclone/) erstellt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon ohne Größenänderung; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erstellt eine Ziel‑Folie, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone beeinflussen nicht die Quell‑Form.

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

Das Klonen kopiert den Inhalt und die Formatierung der Form, einschließlich ihres Namens und alternativen Textes. Weisen Sie dem Klon neue logische Kennungen zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Sammlungs‑Element mit neuer Form‑Identität.

### **Formen entfernen**

[Remove](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/remove/) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Durchlaufung von hinten nach vorne iterieren, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest `slide.Shapes[i]`, nicht ein festes Sammlungs‑Element, und wirft die Form nicht unnötig um.

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

Nach dem Entfernen ändern sich die Form‑Anzahl und die Indizes nachfolgender Formen. Verweise auf nicht betroffene Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Verbinder, Animationen und andere Präsentations‑Features, die auf das entfernte Objekt verweisen könnten; das Entfernen einer sichtbaren Form kann mehr als das Aussehen der Folie verändern.

### **Eine Form ausblenden**

Das Setzen von [Hidden](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/hidden/) auf `true` lässt die Form in der Sammlung, verhindert aber ihr Auftreten in der normalen Bildschirmpräsentation. Ihr Index, die Formatierung und der Inhalt bleiben für den Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

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

Ausblenden ist keine Löschung oder Sicherheit. Das Objekt kann weiterhin von einem Benutzer oder Code gefunden und wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Den Z‑Order ändern**

Überlappende Formen werden in Sammlungs‑Reihenfolge gemalt. [Reorder](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/reorder/) verschiebt eine bestehende Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist der hinterste; `Count - 1` ist der vorderste.

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

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben zum letzten Index bringt es nach vorne. Finalisieren Sie den Z‑Order, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, da diese Vorgänge neue Sammlungs‑Elemente anhängen oder einfügen und die beabsichtigte Stapelung ändern können.

## **Formen in Layout‑Folien inspizieren**

Normale Folien, Layout‑Folien und Master‑Folien besitzen separate Form‑Sammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Inspizieren Sie Layout‑Formen, wenn Sie die von einem Layout bereitgestellte Formatierung verstehen oder ändern müssen.

Das folgende Beispiel liest jede Layout‑Formes [FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/fillformat/) und [LineFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/lineformat/) ohne anzunehmen, dass jede Form ein `AutoShape` ist.

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

[WriteAsSvg](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/writeassvg/) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält nur die Form, nicht den gesamten Folien‑Hintergrund oder benachbarte Formen.

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

Halten Sie die Präsentation während des Renderns offen. Die Ausgabe hängt von der Formatierung der Form und von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn freigeben.

## **Formen ausrichten**

Die [SlideUtil.AlignShapes](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/alignshapes/)‑Überladungen richten entweder alle Formen oder ausgewählte Sammlungs‑Indizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/net/aspose.slides/shapesalignmenttype/) gibt die Kante, Mittellinie oder den Verteilungs‑Modus an. Setzen Sie `alignToSlide` auf `true`, um die Folienränder zu verwenden; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen an der oberen Kante der Folie aus. Die zurückgegebenen Form‑Referenzen werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes umgewandelt.

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

Ausrichtung ändert Positionen, nicht den Z‑Order. Relativ‑Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung genügend Formen benötigt, um Abstände zu definieren. Rekalkulieren Sie Indizes, wenn Sie die Sammlung vor dem Aufruf der Methode ändern.

## **Eine Form spiegeln**

Die [ShapeFrame](https://reference.aspose.com/slides/de/net/aspose.slides/shapeframe/)‑Klasse speichert Position, Größe, horizontale und vertikale Spiegel‑Einstellungen sowie Drehung. Ihre `FlipH`‑ und `FlipV`‑Werte verwenden [NullableBool](https://reference.aspose.com/slides/de/net/aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` bewahrt den nicht spezifizierten/Standard‑Zustand.

Die Eingabe‑Präsentation unten enthält eine nicht gespiegelte Form.

![The shape before flipping](shape_to_be_flipped.png)

Das Beispiel behält alle anderen Frame‑Werte bei und ersetzt nur die beiden Spiegel‑Einstellungen. Das ist wichtig, weil das Zuweisen eines neuen [Frame](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/frame/) den gesamten Frame ersetzt.

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

Die gespeicherte Form wird horizontal und vertikal gespiegelt, wobei Position, Größe und Drehung erhalten bleiben.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Soll ich einen Sammlungs‑Index als Form‑Kennung verwenden?**

Nur für kurzlebige Verarbeitung, bei der die Sammlung nicht geändert wird, bevor der Index verwendet wird. Bevorzugen Sie für erstellte Vorlagen eine validierte `Name`‑ oder `AlternativeText`‑Konvention bzw. `OfficeInteropShapeId` für folienbezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form ihren Z‑Order?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu geordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`AddClone` hängt den Klon an das Ende der Sammlung an, was dem Vordergrund des Z‑Orders entspricht. Verwenden Sie `InsertClone`, um den Anfangs‑Index zu wählen, oder `Reorder`, nachdem alle Formen hinzugefügt wurden.

**Kann ich einen festen Index verwenden, um eine voreingestellte Formanpassung zu identifizieren?**

Nur nach Validierung der genauen Vorgabe und des Sammlungs‑Layouts. Bevorzugen Sie das Durchlaufen von `IGeometryShape.Adjustments` und das Prüfen von `IAdjustValue.Type`; verwenden Sie `IAdjustValue.Name` als zusätzliche Information, wenn derselbe semantische Typ mehr als einmal vorkommt.