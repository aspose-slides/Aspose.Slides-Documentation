---
title: Arbeitslösung für Diagrammskalierung in PPTX
type: docs
weight: 60
url: /de/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammskalierung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Unerwartete Diagrammskalierung in PPTX beim Einsatz eingebetteter Excel-OLE-Objekte mit Aspose.Slides für .NET beheben. Lernen Sie zwei Methoden mit Code, um die Größen konsistent zu halten."
---

## **Hintergrund**

Es wurde beobachtet, dass Excel‑Diagramme, die als OLE‑Objekte in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettet sind, nach ihrer ersten Aktivierung auf einen nicht spezifizierten Maßstab skaliert werden. Dieses Verhalten führt zu einem deutlich sichtbaren visuellen Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des Diagramms. Das Aspose‑Team hat das Problem im Detail untersucht und eine Lösung gefunden. Dieser Artikel beschreibt die Ursachen des Problems und die entsprechende Behebung.

Im [vorherigen Artikel](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man mit Aspose.Cells für .NET ein Excel‑Diagramm erstellt und es mit Aspose.Slides für .NET in eine PowerPoint‑Präsentation einbettet. Um das [Objekt‑Vorschau‑Problem](/slides/de/net/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE‑Objekt‑Frame des Diagramms zugewiesen. In der erzeugten Präsentation wird das OLE‑Objekt‑Frame, das das Diagrammbild anzeigt, bei einem Doppelklick aktiviert und das Excel‑Diagramm wird geöffnet. Endbenutzer können dann beliebige Änderungen in der zugrundeliegenden Excel‑Arbeitsmappe vornehmen und anschließend zur entsprechenden Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Frames ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE‑Objekt‑Frames als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Skalierung**

Da die Excel‑Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, bei ihrer ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Der OLE‑Objekt‑Frame hat jedoch seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe über die Größe und erhalten das korrekte Seitenverhältnis im Rahmen des Einbettungsprozesses. Abhängig von den Unterschieden zwischen der Excel‑Fenstergröße und der Größe bzw. Position des OLE‑Objekt‑Frames kommt es zu einer Größenanpassung.

## **Funktionierende Lösung**

Es gibt zwei mögliche Szenarien für die Erstellung von PowerPoint‑Präsentationen mit Aspose.Slides für .NET.

**Szenario 1:** Erstellung einer Präsentation basierend auf einer vorhandenen Vorlage.

**Szenario 2:** Erstellung einer Präsentation von Grund auf.

Die hier vorgestellte Lösung gilt für beide Szenarien. Die Grundlage aller Lösungsansätze ist dieselbe: **die Fenstergröße des eingebetteten OLE‑Objekts muss der Größe des OLE‑Objekt‑Frames in der PowerPoint‑Folien entsprechen**. Im Folgenden werden die beiden Vorgehensweisen erläutert.

## **Erster Ansatz**

In diesem Ansatz lernen wir, wie man die Fenstergröße der eingebetteten Excel‑Arbeitsmappe so festlegt, dass sie der Größe des OLE‑Objekt‑Frames in der PowerPoint‑Folien entspricht.

**Szenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten Präsentationen darauf aufbauen. Es gibt ein Shape mit Index 2 in der Vorlage, an dem wir einen OLE‑Frame mit einer eingebetteten Excel‑Arbeitsmappe platzieren wollen. In diesem Szenario ist die Größe des OLE‑Objekt‑Frames vordefiniert – sie entspricht der Größe des Shapes mit Index 2 in der Vorlage. Wir müssen lediglich die Fenstergröße der Arbeitsmappe auf dieselbe Größe setzen. Der folgende Code‑Snippet erfüllt diesen Zweck:
```cs
// Definiere die Diagrammgröße mit einem Fenster. 
chart.SizeWithWindow = true;

// Setze die Fensterbreite der Arbeitsmappe in Zoll (geteilt durch 72, da PowerPoint 72 Pixel pro Zoll verwendet).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Setze die Fensterhöhe der Arbeitsmappe in Zoll.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Speichere die Arbeitsmappe in einen Speicher-Stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Erstelle einen OLE-Objekt-Frame mit den eingebetteten Excel-Daten.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Szenario 2**

Nehmen wir an, wir wollen eine Präsentation von Grund auf erstellen und dabei einen OLE‑Objekt‑Frame beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einfügen. Im folgenden Code‑Snippet erstellen wir einen OLE‑Objekt‑Frame mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Anschließend setzen wir das Excel‑Arbeitsmappe‑Fenster auf dieselbe Größe – 4 Zoll hoch und 9,5 Zoll breit.
```cs
// Unsere gewünschte Höhe.
int desiredHeight = 288; // 4 Zoll (4 * 72)

// Unsere gewünschte Breite.
int desiredWidth = 684;//9.5 Zoll (9.5 * 72)

// Definiere die Diagrammgröße mit einem Fenster.
chart.SizeWithWindow = true;

// Setze die Fensterbreite der Arbeitsmappe in Zoll.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Setze die Fensterhöhe der Arbeitsmappe in Zoll.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Speichere die Arbeitsmappe in einen Speicher-Stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Erstelle einen OLE-Objekt-Frame mit den eingebetteten Excel-Daten.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **Zweiter Ansatz**

In diesem Ansatz lernen wir, wie man die Diagrammgröße in der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der Größe des OLE‑Objekt‑Frames in der PowerPoint‑Folien entspricht. Dieser Ansatz ist sinnvoll, wenn die Diagrammgröße im Voraus bekannt ist und sich nie ändert.

**Szenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten Präsentationen darauf aufbauen. Es gibt ein Shape mit Index 2 in der Vorlage, an dem wir einen OLE‑Frame mit einer eingebetteten Excel‑Arbeitsmappe platzieren wollen. In diesem Szenario ist die Größe des OLE‑Frames vordefiniert – sie entspricht der Größe des Shapes mit Index 2 in der Vorlage. Wir müssen lediglich die Diagrammgröße in der Arbeitsmappe auf dieselbe Größe setzen. Der folgende Code‑Snippet erfüllt diesen Zweck:
```cs
// Definiere die Diagrammgröße ohne Fenster. 
chart.SizeWithWindow = false;

// Setze die Diagrammbreite in Pixel (multipliziere mit 96, da Excel 96 Pixel pro Zoll verwendet).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Setze die Diagrammhöhe in Pixel.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Definiere die Druckgröße des Diagramms.
chart.PrintSize = PrintSizeType.Custom;

// Speichere die Arbeitsmappe in einen Speicher-Stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Erstelle einen OLE-Objekt-Frame mit den eingebetteten Excel-Daten.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Szenario 2**

Nehmen wir an, wir wollen eine Präsentation von Grund auf erstellen und dabei einen OLE‑Objekt‑Frame beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einfügen. Im folgenden Code‑Snippet erstellen wir einen OLE‑Objekt‑Frame mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Zusätzlich setzen wir die zugehörige Diagrammgröße auf dieselben Abmessungen: Höhe 4 Zoll, Breite 9,5 Zoll.
```cs
 // Unsere gewünschte Höhe.
int desiredHeight = 288; // 4 Zoll (4 * 576)

// Unsere gewünschte Breite.
int desiredWidth = 684; // 9,5 Zoll (9,5 * 576)

// Definiere die Diagrammgröße ohne Fenster. 
chart.SizeWithWindow = false;

// Setze die Diagrammbreite in Pixel.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Setze die Diagrammhöhe in Pixel.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Save the workbook to a memory stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Create an OLE object frame with the embedded Excel data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **Fazit**

Es gibt zwei Ansätze zur Behebung des Diagramm‑Skalierungsproblems. Die Wahl des Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleich, unabhängig davon, ob die Präsentationen aus einer Vorlage oder neu erstellt werden. Außerdem gibt es keine Begrenzung für die Größe des OLE‑Objekt‑Frames in dieser Lösung.

## FAQ

**F: Warum ändert sich die Größe meines eingebetteten Excel‑Diagramms nach der Aktivierung in PowerPoint?**  
Dies geschieht, weil Excel beim ersten Aktivieren versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objekt‑Frame in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu wahren, was zu einer Skalierung führen kann.

**F: Gibt es eine Möglichkeit, dieses Skalierungsproblem vollständig zu verhindern?**  
Ja. Indem man die Fenstergröße der Excel‑Arbeitsmappe oder die Diagrammgröße an die Größe des OLE‑Objekt‑Frames anpasst, bevor man das Objekt einbettet, bleibt die Diagrammgröße konsistent.

**F: Welchen Ansatz soll ich wählen, die Fenstergröße der Arbeitsmappe oder die Diagrammgröße?**  
Verwenden Sie **Ansatz 1 (Fenstergröße)**, wenn Sie das Seitenverhältnis der Arbeitsmappe beibehalten und später eventuell eine Größenänderung zulassen möchten.  
Verwenden Sie **Ansatz 2 (Diagrammgröße)**, wenn die Diagrammabmessungen feststehen und nach dem Einbetten nicht mehr geändert werden.

**F: Funktionieren diese Methoden sowohl für vorlagenbasierte als auch für neue Präsentationen?**  
Ja. Beide Ansätze funktionieren gleichermaßen für Präsentationen, die aus Vorlagen oder von Grund auf erstellt werden.

**F: Gibt es ein Limit für die Größe des OLE‑Objekt‑Frames?**  
Nein. Der OLE‑Frame kann auf jede Größe gesetzt werden, solange er angemessen zum Arbeitsmappe‑ bzw. Diagramm‑Fenster skaliert wird.

**F: Kann ich diese Methoden mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**  
Die Beispiele sind für Excel‑Diagramme mit Aspose.Cells gedacht, aber die Grundprinzipien gelten auch für andere OLE‑kompatible Tabellenkalkulationsprogramme, sofern sie ähnliche Größenoptionen unterstützen.

## **Verwandte Abschnitte**

- [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE‑Objekte automatisch mit einem PowerPoint‑Add‑In aktualisieren](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)