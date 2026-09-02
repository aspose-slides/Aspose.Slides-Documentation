---
title: Ermitteln effektiver Formeigenschaften aus Präsentationen in .NET
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/net/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtanlage
- Abgeschrägte Form
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für .NET verwenden, um lokale, geerbte und effektive Formformatierungen in PowerPoint-Präsentationen zu unterscheiden."
---
## **Verstehen lokaler, geerbter und effektiver Eigenschaften**

Die Formatierung in PowerPoint kann von mehreren Stellen stammen. Der direkt auf einem Objekt gespeicherte Wert ist sein **lokaler Wert**. Ist dieser Wert nicht gesetzt, prüft PowerPoint die übergeordneten Formatierungsquellen, wie z. B. die Absatz‑Standardeinstellungen, einen Textstil, ein Layout‑ oder Folienmaster, ein Design oder Präsentations‑Standardwerte. Diese Werte sind **geerbte Werte**. Der nach der Auflösung der gesamten Hierarchie verbleibende Wert ist der **effektive Wert** – der Wert, der zum Rendern des Objekts verwendet wird.

Zum Beispiel definiert ein Textabschnitt möglicherweise nicht seine eigene Schriftgröße. Sein lokaler [FontHeight](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/fontheight/) ist dann `float.NaN`, was „hier nicht gesetzt“ bedeutet. Der Abschnitt kann eine Höhe von seinem Absatz, dem Standard‑Textstil der Präsentation oder einer anderen anwendbaren Quelle erben. Der Aufruf von [GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/iportionformat/geteffective/) für das Abschnittsformat gibt die endgültig aufgelöste Höhe zurück.

Verwenden Sie die beiden Arten von Formatierungsdaten für unterschiedliche Zwecke:
- Lesen oder ändern Sie ein lokales Formatobjekt, wie z. B. [IPortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iportionformat/), wenn Sie steuern müssen, wo ein Wert definiert ist.
- Lesen Sie ein effektives Datenobjekt, wie z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/iportionformateffectivedata/), wenn Sie das endgültige, gerenderte Ergebnis benötigen. Effektive Daten sind schreibgeschützt.

## **Vergleichen lokaler, geerbter und effektiver Werte**

Das folgende vollständige Beispiel erstellt eine Form und wendet Schriftgrößen auf Präsentations‑, Absatz‑ und Abschnittsebene an. Jeder Schritt gibt die auf diesen Ebenen definierten Werte sowie den resultierenden effektiven Wert für denselben Textabschnitt aus. Es zeigt auch, warum effektive Daten nach Formatierungsänderungen erneut gelesen werden müssen.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Definiere geerbte Werte auf zwei unterschiedlichen Ebenen.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Ein lokaler Wert im Abschnitt überschreibt beide geerbten Werte.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Das Ändern eines geerbten Wertes überschreibt nicht einen bereits vorhandenen lokalen Wert.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Lösche den lokalen Wert. Der Abschnitt erbt nun wieder vom Absatz.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Lösche den Absatzwert. Der Präsentationsstandard liefert nun das Ergebnis.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Lese effektive Daten nach den vorherigen Änderungen.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Die Priorität in diesem Beispiel liegt zunächst auf der lokalen Formatierung des Abschnitts, dann auf der Absatz‑Formatierung und anschließend auf dem Standard der Präsentation. Andere Objekte können unterschiedliche Vererbungsketten haben, aber das Prinzip bleibt gleich: ein spezifischerer expliziter Wert gewinnt, und [GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/iportionformat/geteffective/) liefert das Endergebnis.

## **Ermitteln effektiver Texteigenschaften**

Die Textformatierung ist auf mehrere Objekte verteilt:
- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/geteffective/) löst Text‑Frame‑Eigenschaften wie Ränder, Verankerung, Autofit und vertikale Text­ausrichtung auf.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/de/net/aspose.slides/itextstyle/geteffective/) löst die Absatzformatierung für jede Ebene des Textstils auf.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/geteffective/) löst Absatz‑Eigenschaften wie Ausrichtung, Einrückung und Aufzählungszeichen auf.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/de/net/aspose.slides/iportionformat/geteffective/) löst Zeichen‑Eigenschaften wie Schriftgröße, Schriftart, Farbe, Fett‑ und Kursivschrift auf.

Für das nächste Beispiel muss `text-formatting.pptx` mindestens eine Folie und eine [AutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/autoshape/) mit einem nicht leeren Text‑Frame enthalten. Die AutoShape kann an beliebiger Position in der Shape‑Collection erscheinen; der Code sucht nach einem geeigneten Objekt und prüft es, bevor es verwendet wird.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Ermitteln effektiver 3D‑Eigenschaften**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/geteffective/) gibt ein [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformateffectivedata/)‑Objekt zurück, das alle aufgelösten 3D‑Einstellungen zusammenfasst. Seine Eigenschaften [Camera](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformateffectivedata/beveltop/) und [BevelBottom](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) stellen die entsprechenden effektiven Daten bereit. Das gleichzeitige Auslesen dieser zusammengehörigen Einstellungen erleichtert das Verständnis des endgültigen 3D‑Erscheinungsbildes einer Form.

Für dieses Beispiel muss `shape-3d.pptx` mindestens eine Form auf der ersten Folie enthalten. Wenden Sie 3D‑Kamera-, Beleuchtungs‑ oder Abschrägungs‑Einstellungen auf diese Form an, wenn die Ausgabe Werte anzeigen soll, die von den Vorgabewerten abweichen.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Ermitteln effektiver Tabellenformatierung**

Die Tabellenformatierung kann aus dem Tabellenstil sowie aus Formaten stammen, die auf die gesamte Tabelle, eine Spalte, eine Zeile oder eine einzelne Zelle angewendet werden. Bei Konflikten zwischen explizit definierten Füllungen hat die Priorität Zelle, Zeile, Spalte und schließlich die gesamte Tabelle. Das effektive Format einer Zelle ist das endgültige Format, das zum Zeichnen dieser Zelle verwendet wird.

Für dieses Beispiel muss `table-formatting.pptx` mindestens eine Tabelle auf der ersten Folie enthalten. Die Tabelle muss mindestens eine Zeile und eine Spalte haben. Der Code sucht nach einem [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/), anstatt anzunehmen, dass `Shapes[0]` eine Tabelle ist.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Wenn Sie die Farbe und nicht nur den Fülltyp benötigen, prüfen Sie zuerst den effektiven [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformateffectivedata/filltype/), und lesen Sie dann die für diesen Typ zutreffende Eigenschaft – zum Beispiel [SolidFillColor](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) für eine einfarbige Füllung.

## **Erneutes Auslesen effektiver Daten nach Änderungen**

Effektive Daten beschreiben die Formatierungshierarchie zum Zeitpunkt ihrer Auflösung. Rufen Sie `GetEffective` erneut auf, nachdem Sie etwas geändert haben, das an dieser Hierarchie teilnehmen kann, einschließlich:
- der lokalen Formatierung des Objekts;
- Absatz‑ oder Text‑Frame‑Standardeinstellungen;
- eines Tabellenstils, einer Tabelle, einer Spalte, einer Zeile oder eines Zellenformats;
- Layout‑ oder Master‑Folien‑Formatierung;
- Design‑Daten oder Präsentations‑Standardwerte;
- dem Layout oder Master, das einer Folie zugewiesen ist.

Behalten Sie ein effektives Datenobjekt nicht als dauerhaftes Snapshot. Aspose.Slides kann einige effektive Daten intern zwischenspeichern, und ein späterer Aufruf von `GetEffective` kann diese Daten aktualisieren. Wenn Sie Werte vor und nach einer Änderung vergleichen müssen, kopieren Sie die skalaren Werte, die Sie benötigen – z. B. eine Schriftgröße, Farbe, Ausrichtung oder Abschrägungsbreite – in eigene Variablen, bevor Sie die Änderung vornehmen.

Um einen Wert zu ändern, aktualisieren Sie das entsprechende lokale Formatobjekt und rufen dann `GetEffective` auf, um das Ergebnis zu überprüfen. Effektive Datenobjekte selbst sind schreibgeschützt.

## **FAQ**

**Wie kann ich feststellen, welche Ebene einen effektiven Wert geliefert hat?**

Effektive Daten enthalten den Endwert, nicht dessen Quelle. Untersuchen Sie die zutreffenden lokalen Objekte von der spezifischsten Ebene nach außen. Für Text können das der Abschnitt, Absatz, Text‑Frame, Layout, Master, Design und die Präsentations‑Standardwerte sein. Nicht definierte Werte wie `float.NaN` oder `null` zeigen an, dass die Suche auf eine weitere Ebene fortgesetzt wird.

**Was passiert, wenn keine Ebene eine Eigenschaft definiert?**

Aspose.Slides löst den entsprechenden PowerPoint‑ oder Bibliotheksstandard auf. Dieser aufgelöste Wert erscheint in den effektiven Daten, obwohl kein lokales Objekt ihn explizit definiert.

**Warum ist ein effektiver Wert manchmal gleich dem lokalen Wert?**

Der lokale Wert hat die Vererberechnung gewonnen. Das ist zu erwarten, wenn die Eigenschaft explizit am Objekt gesetzt ist und keine spezifischere Regel sie überschreibt.

**Wann sollte ich lokale Daten anstelle von effektiven Daten verwenden?**

Verwenden Sie lokale Daten, um eine bestimmte Formatierungsebene zu prüfen oder zu bearbeiten. Verwenden Sie effektive Daten, wenn Sie das endgültige Erscheinungsbild nach Vererbung, Designregeln und angewandten Stilen benötigen. Das [vollständiges Vergleichsbeispiel](#compare-local-inherited-and-effective-values) demonstriert beides im selben Ablauf.