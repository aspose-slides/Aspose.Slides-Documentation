---
title: Arbeitslösung für Diagrammgrößenänderung in PPTX
type: docs
weight: 60
url: /de/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammgrößenänderung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Behebt unerwartete Diagrammgrößenänderungen in PPTX bei Verwendung eingebetteter Excel-OLE-Objekte mit Aspose.Slides für .NET. Erfahren Sie zwei Methoden mit Code, um die Größen konsistent zu halten."
---

## **Hintergrund**

Es wurde beobachtet, dass in PowerPoint-Präsentationen eingebettete Excel-Diagramme als OLE-Objekte über Aspose-Komponenten nach ihrer ersten Aktivierung auf einen nicht angegebenen Maßstab skaliert werden. Dieses Verhalten führt zu einem sichtbaren Unterschied in der Präsentation zwischen dem Vor- und Nach-Aktivierungszustand des Diagramms. Das Aspose-Team hat das Problem detailliert untersucht und eine Lösung gefunden. Dieser Artikel beschreibt die Ursachen des Problems und die entsprechende Lösung.

Im [vorherigen Artikel](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man mit Aspose.Cells für .NET ein Excel-Diagramm erstellt und es mit Aspose.Slides für .NET in eine PowerPoint-Präsentation einbettet. Um das [Objektvorschau-Problem](/slides/de/net/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE-Objektrahmen des Diagramms zugewiesen. In der erzeugten Präsentation wird das Excel-Diagramm aktiviert, wenn Sie den OLE-Objektrahmen, der das Diagrammbild anzeigt, doppelklicken. Endbenutzer können beliebige Änderungen an der zugrunde liegenden Excel-Arbeitsmappe vornehmen und dann durch Klicken außerhalb der aktivierten Arbeitsmappe zur entsprechenden Folie zurückkehren. Die Größe des OLE-Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE-Objektrahmens als auch der eingebetteten Excel-Arbeitsmappe.

## **Ursache der Größenänderung**

Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie bei der ersten Aktivierung, ihre ursprüngliche Größe beizubehalten. Der OLE-Objektrahmen hat jedoch seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe die Größe und erhalten im Einbettungsprozess die korrekten Proportionen. Abhängig von den Unterschieden zwischen der Fenstergröße von Excel und der Größe bzw. Position des OLE-Objektrahmens kommt es zur Größenänderung.

## **Funktionierende Lösung**

Es gibt zwei mögliche Szenarien zur Erstellung von PowerPoint-Präsentationen mit Aspose.Slides für .NET.

**Szenario 1:** Erstellung einer Präsentation basierend auf einer vorhandenen Vorlage.  
**Szenario 2:** Erstellung einer Präsentation von Grund auf.

Die hier bereitgestellte Lösung gilt für beide Szenarien. Die Grundlage aller Lösungsansätze ist dieselbe: **Die Fenstergröße des eingebetteten OLE-Objekts muss dem OLE-Objektrahmen in der PowerPoint-Folie entsprechen**. Im Folgenden werden die beiden Ansätze zu dieser Lösung erläutert.

## **Erster Ansatz**

In diesem Ansatz lernen wir, wie die Fenstergröße der eingebetteten Excel-Arbeitsmappe so eingestellt wird, dass sie der Größe des OLE-Objektrahmens in der PowerPoint-Folie entspricht.

**Szenario 1**  
Angenommen, wir haben eine Vorlage definiert und möchten darauf basierend Präsentationen erstellen. Nehmen wir an, es gibt in der Vorlage ein Shape mit Index 2, an dem wir einen OLE-Rahmen mit einer eingebetteten Excel-Arbeitsmappe platzieren wollen. In diesem Szenario ist die Größe des OLE-Objektrahmens vordefiniert – sie entspricht der Größe des Shapes mit Index 2 in der Vorlage. Wir müssen lediglich die Fenstergröße der Arbeitsmappe an die Größe dieses Shapes anpassen. Das folgende Code‑Snippet erfüllt diesen Zweck:
```cs
// Definieren Sie die Diagrammgröße mit einem Fenster. 
chart.SizeWithWindow = true;

// Setzen Sie die Fensterbreite der Arbeitsmappe in Zoll (geteilt durch 72, da PowerPoint 72 Pixel pro Zoll verwendet).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Setzen Sie die Fensterhöhe der Arbeitsmappe in Zoll.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Speichern Sie die Arbeitsmappe in einen Speicherstrom.
MemoryStream workbookStream = workbook.SaveToStream();

// Erstellen Sie einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Szenario 2**  
Angenommen, wir möchten eine Präsentation von Grund auf erstellen und einen OLE-Objektrahmen beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe einfügen. Im folgenden Code‑Snippet erstellen wir einen OLE‑Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Anschließend setzen wir das Excel‑Arbeitsmappen‑Fenster auf dieselbe Größe – 4 Zoll hoch und 9,5 Zoll breit.
```cs
// Unsere gewünschte Höhe.
int desiredHeight = 288; // 4 Zoll (4 * 72)

// Unsere gewünschte Breite.
int desiredWidth = 684;//9.5 Zoll (9.5 * 72)

// Diagrammgröße mit einem Fenster definieren.
chart.SizeWithWindow = true;

// Fensterbreite der Arbeitsmappe in Zoll festlegen.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Fensterhöhe der Arbeitsmappe in Zoll festlegen.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Arbeitsmappe in einen Speicherstrom speichern.
MemoryStream workbookStream = workbook.SaveToStream();

// OLE-Objektrahmen mit den eingebetteten Excel-Daten erstellen.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **Zweiter Ansatz**

In diesem Ansatz lernen wir, wie die Größe des Diagramms in der eingebetteten Excel-Arbeitsmappe so eingestellt wird, dass sie der Größe des OLE-Objektrahmens in der PowerPoint-Folie entspricht. Dieser Ansatz ist nützlich, wenn die Diagrammgröße im Voraus bekannt ist und sich nie ändert.

**Szenario 1**  
Angenommen, wir haben eine Vorlage definiert und möchten darauf basierend Präsentationen erstellen. Nehmen wir an, es gibt in der Vorlage ein Shape mit Index 2, an dem wir einen OLE‑Rahmen mit einer eingebetteten Excel‑Arbeitsmappe platzieren wollen. In diesem Szenario ist die Größe des OLE‑Rahmens vordefiniert – sie entspricht der Größe des Shapes mit Index 2 in der Vorlage. Wir müssen lediglich die Diagrammgröße in der Arbeitsmappe an die Größe dieses Shapes anpassen. Das folgende Code‑Snippet erfüllt diesen Zweck:
```cs
// Diagrammgröße ohne Fenster definieren. 
chart.SizeWithWindow = false;

// Diagrammbreite in Pixeln festlegen (mit 96 multiplizieren, da Excel 96 Pixel pro Zoll verwendet).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Diagrammhöhe in Pixeln festlegen.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Diagrammdruckgröße definieren.
chart.PrintSize = PrintSizeType.Custom;

// Arbeitsmappe in einen Speicherstrom speichern.
MemoryStream workbookStream = workbook.SaveToStream();

// OLE-Objektrahmen mit den eingebetteten Excel-Daten erstellen.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Szenario 2**  
Angenommen, wir möchten eine Präsentation von Grund auf erstellen und einen OLE‑Objektrahmen beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einfügen. Im folgenden Code‑Snippet erstellen wir einen OLE‑Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Zusätzlich setzen wir die entsprechende Diagrammgröße auf dieselben Abmessungen: eine Höhe von 4 Zoll und eine Breite von 9,5 Zoll.
```cs
 // Unsere gewünschte Höhe.
int desiredHeight = 288; // 4 Zoll (4 * 576)

// Unsere gewünschte Breite.
int desiredWidth = 684; // 9,5 Zoll (9,5 * 576)

// Diagrammgröße ohne Fenster definieren. 
chart.SizeWithWindow = false;

// Diagrammbreite in Pixeln festlegen.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Diagrammhöhe in Pixeln festlegen.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Arbeitsmappe in einen Speicherstrom speichern.
MemoryStream workbookStream = workbook.SaveToStream();

// OLE‑Objektrahmen mit den eingebetteten Excel‑Daten erstellen.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **Fazit**

Es gibt zwei Ansätze zur Behebung des Diagramm‑Größenänderungsproblems. Die Wahl des Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleichermaßen, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Außerdem gibt es in dieser Lösung keine Begrenzung der Größe des OLE‑Objektrahmens.

## **FAQ**

**Warum ändert mein eingebettetes Excel-Diagramm nach der Aktivierung in PowerPoint seine Größe?**  
Das passiert, weil Excel bei der ersten Aktivierung versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Größenänderung führen kann.

**Ist es möglich, dieses Größenänderungsproblem vollständig zu verhindern?**  
Ja. Durch das Angleichen der Excel‑Arbeitsmappen‑Fenstergröße bzw. der Diagrammgröße an die Größe des OLE‑Objektrahmens vor dem Einbetten können die Diagrammgrößen konsistent gehalten werden.

**Welchen Ansatz sollte ich wählen, die Fenstergröße der Arbeitsmappe einstellen oder die Diagrammgröße festlegen?**  
Verwenden Sie **Ansatz 1 (Fenstergröße)**, wenn Sie das Seitenverhältnis der Arbeitsmappe beibehalten und später eventuell eine Größenanpassung zulassen möchten.  
Verwenden Sie **Ansatz 2 (Diagrammgröße)**, wenn die Diagrammabmessungen fest vorgegeben sind und sich nach dem Einbetten nicht ändern.

**Werden diese Methoden sowohl bei vorlagenbasierten Präsentationen als auch bei neuen Präsentationen funktionieren?**  
Ja. Beide Ansätze funktionieren gleich für Präsentationen, die aus Vorlagen erstellt wurden, sowie für neue Präsentationen.

**Gibt es eine Begrenzung für die Größe des OLE‑Objektrahmens?**  
Nein. Der OLE‑Rahmen kann auf jede beliebige Größe gesetzt werden, solange er angemessen zur Arbeitsmappe oder Diagrammgröße skaliert.

**Kann ich diese Methoden mit Diagrammen verwenden, die in anderen Tabellenkalkulationsprogrammen erstellt wurden?**  
Die Beispiele sind für Excel‑Diagramme, die mit Aspose.Cells erstellt wurden, aber die Prinzipien gelten auch für andere OLE‑kompatible Tabellenkalkulationsprogramme, sofern sie ähnliche Größenoptionen unterstützen.

## **Verwandte Abschnitte**

- [Excel-Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE‑Objekte automatisch mit einem PowerPoint-Add‑In aktualisieren](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)