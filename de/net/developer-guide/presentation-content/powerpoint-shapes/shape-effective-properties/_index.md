---
title: Effektive Formeigenschaften aus Präsentationen in .NET abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/net/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Licht‑Rig
- Abrundungsform
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für .NET effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint‑Darstellung zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene gesetzt werden, zum Beispiel:

1. Portionseigenschaften auf einer Folie.
1. Textstil‑Prototypformen auf einem Layout‑ oder Master‑Slide, wenn die Textfeld‑Form der Portion einen hat.
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides das endgültige „wie gerenderte“ Format benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `GetEffective` auf dem lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) mit einem Textfeld und mindestens einer Portion ist.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Effektive Formatierungsdaten repräsentieren die aktuell berechnete Formatierung nach Anwendung der Vererbung. In der aktuellen Implementierung können einige effektive Datenobjekte, wie zum Beispiel [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/iportionformateffectivedata/), intern zwischengespeichert werden. Ein erneuter Aufruf von `GetEffective` nach Änderungen an übergeordneten oder vererbten Formaten kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für eine spätere Wiederverwendung behalten müssen, kopieren Sie die benötigten Eigenschaften, wie Schriftgröße, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/icameraeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/icameraeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/) liefert.

Der folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften der Kamera erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Effektive Eigenschaften eines Licht‑Rigs abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften eines Licht‑Rigs. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ilightrigeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Licht‑Rig‑Eigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ilightrigeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/) liefert.

Der folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften des Licht‑Rigs erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Effektive Eigenschaften einer Formkanten‑Abrundung abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formkanten‑Abrundung. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ishapebeveleffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Gesichts‑Relief‑Eigenschaften für eine Form enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ishapebeveleffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/) liefert.

Der folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften der oberen Abrundung einer Form erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Effektive Eigenschaften eines Textfelds abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds erhalten. Das Interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformateffectivedata/) enthält effektive Textfeld‑Formatierungseigenschaften.

Der folgende Code‑Beispiel zeigt, wie man effektive Textfeld‑Formatierungseigenschaften erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) mit einem Textfeld ist.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Effektive Eigenschaften eines Textstils abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils erhalten. Das Interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/itextstyleeffectivedata/) enthält effektive Textstileigenschaften.

Der folgende Code‑Beispiel zeigt, wie man effektive Textstileigenschaften erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) mit einem Textfeld ist.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Den effektiven Schriftgrößenwert erhalten**

Mit Aspose.Slides können Sie die effektive Schriftgröße erhalten. Der folgende Code demonstriert, wie sich die effektive Schriftgröße einer Portion ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Effektives Füllformat für eine Tabelle erhalten**

Mit Aspose.Slides können Sie effektive Füllformatierung für verschiedene Tabellenteile erhalten. Das Interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformateffectivedata/) enthält effektive Füllformatierungs‑Eigenschaften. Die Zellenformatierung hat höhere Priorität als die Zeilenformatierung, die Zeilenformatierung hat höhere Priorität als die Spaltenformatierung, und die Spaltenformatierung hat höhere Priorität als die Formatierung der gesamten Tabelle.

Infolgedessen werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/icellformateffectivedata/) zum Zeichnen der Tabellenzelle verwendet. Der folgende Code‑Beispiel zeigt, wie man effektive Füllformatierung für verschiedene Tabellenteile erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/) ist.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

### Gibt `GetEffective` einen Schnappschuss zurück?

Nicht immer. Effektive Daten repräsentieren die berechnete Formatierung nach Anwendung der Vererbung, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachfolgender Aufruf von `GetEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss betrachtet werden sollte.

### Wann sollte ich effektive Eigenschaften erneut auslesen?

Rufen Sie `GetEffective` erneut auf, nachdem Sie lokale Formatierungen, übergeordnete Stile, Layout‑Formatierungen, Master‑Formatierungen oder Präsentations‑Standardwerte geändert haben. Der nächste Aufruf wertet die Formatierungshierarchie neu aus und gibt das aktuelle effektive Ergebnis zurück.

### Wirkt sich das Ändern oder Entfernen eines Layout‑/Master‑Slides auf bereits abgerufene effektive Eigenschaften aus?

Ja, die Änderung wird beim nächsten Aufruf von `GetEffective` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Nach erneutem Aufruf von `GetEffective` wertet Aspose.Slides den Formatierungsbaum neu aus und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

### Kann ich Werte über effektive Datenobjekte ändern?

Nein. Effektive Datenobjekte stellen berechnete Werte bereit. Änderungen sollten in den lokalen Formatierungsobjekten vorgenommen werden, und anschließend sollten die effektiven Werte erneut abgerufen werden.

### Was passiert, wenn eine Eigenschaft weder auf Form‑, Layout‑/Master‑ noch auf globale Ebene gesetzt ist?

Der effektive Wert wird durch den Standard‑Mechanismus ermittelt, der die Vorgaben von PowerPoint und Aspose.Slides enthält. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

### Kann ich aus einem effektiven Schriftwert erkennen, welche Ebene die Größe oder Schriftart bereitgestellt hat?

Nicht direkt. Effektive Daten geben den endgültigen Wert zurück. Um die Quelle zu finden, prüfen Sie die lokalen Werte auf Portion‑, Absatz‑, Textfeld‑ und Textstil‑Ebenen im Layout, Master und auf Präsentationsebene, um zu sehen, wo die erste explizite Definition vorkommt.

### Warum sehen effektive Werte manchmal identisch zu den lokalen aus?

Weil der lokale Wert letztlich final war (keine höhere Ebene musste vererbt werden). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

### Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach vollständiger Vererbung benötigen, z. B. zum Ausrichten von Farben, Einzügen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen beibehalten wollen, kopieren Sie die benötigten Eigenschaften in Ihr eigenes Objekt. Wenn Sie die Formatierung auf einer bestimmten Ebene ändern möchten, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu prüfen.