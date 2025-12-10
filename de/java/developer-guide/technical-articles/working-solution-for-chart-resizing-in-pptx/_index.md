---
title: Arbeitslösung für Diagrammskalierung in PPTX
type: docs
weight: 40
url: /de/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammskalierung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Behebt unerwartete Diagrammskalierung in PPTX beim Einsatz eingebetteter Excel-OLE-Objekte mit Aspose.Slides für Java. Erfahren Sie zwei Methoden mit Code, um die Größen konsistent zu halten."
---

## **Hintergrund**

Es wurde beobachtet, dass in PowerPoint‑Präsentationen über Aspose‑Komponenten eingebettete Excel‑Diagramme, die als OLE‑Objekte vorliegen, nach ihrer ersten Aktivierung auf einen nicht spezifizierten Maßstab skaliert werden. Dieses Verhalten führt zu einem sichtbaren Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des Diagramms. Das Aspose‑Team hat das Problem detailliert untersucht und eine Lösung gefunden. Dieser Artikel beschreibt die Ursachen des Problems und die entsprechende Korrektur.

Im [previous article](/slides/de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man mit Aspose.Cells für Java ein Excel‑Diagramm erstellt und es mit Aspose.Slides für Java in eine PowerPoint‑Präsentation einbettet. Um das [object preview issue](/slides/de/java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE‑Objektrahmen des Diagramms zugewiesen. In der Ergebnis‑Präsentation wird das Excel‑Diagramm aktiviert, wenn Sie den OLE‑Objektrahmen, der das Diagrammbild anzeigt, doppelklicken. Endbenutzer können beliebige Änderungen in der zugrunde liegenden Excel‑Arbeitsmappe vornehmen und anschließend durch Klicken außerhalb der aktivierten Arbeitsmappe zur entsprechenden Folie zurückkehren. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE‑Objektrahmens als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Skalierung**

Da die Excel‑Arbeitsmappe über eine eigene Fenstergröße verfügt, versucht sie bei ihrer ersten Aktivierung, ihre ursprüngliche Größe beizubehalten. Der OLE‑Objektrahmen hingegen hat seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe die Größe und erhalten die richtigen Proportionen im Rahmen des Einbettungsprozesses. Je nach Unterschied zwischen der Excel‑Fenstergröße und der Größe bzw. Position des OLE‑Objektrahmens kommt es zu einer Skalierung.

## **Funktionsfähige Lösung**

Es gibt zwei mögliche Szenarien für die Erstellung von PowerPoint‑Präsentationen mit Aspose.Slides für Java.

**Scenario 1:** Eine Präsentation basierend auf einer vorhandenen Vorlage erstellen.

**Scenario 2:** Eine Präsentation von Grund auf neu erstellen.

Die hier bereitgestellte Lösung gilt für beide Szenarien. Die Grundlage aller Lösungsansätze ist dieselbe: **die Fenstergröße des eingebetteten OLE‑Objekts muss dem OLE‑Objektrahmen in der PowerPoint‑Folge entsprechen**. Im Folgenden werden die beiden Ansätze zu dieser Lösung erläutert.

## **Erster Ansatz**

In diesem Ansatz lernen wir, wie die Fenstergröße der eingebetteten Excel‑Arbeitsmappe so eingestellt wird, dass sie der Größe des OLE‑Objektrahmens in der PowerPoint‑Folge entspricht.

**Scenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten darauf basierend Präsentationen erstellen. Nehmen wir an, in der Vorlage befindet sich an Index 2 eine Form, in der wir einen OLE‑Rahmen mit einer eingebetteten Excel‑Arbeitsmappe platzieren wollen. In diesem Szenario ist die Größe des OLE‑Objektrahmens vordefiniert – sie entspricht der Größe der Form an Index 2 in der Vorlage. Alles, was wir tun müssen, ist die Fenstergröße der Arbeitsmappe auf die Größe dieser Form zu setzen. Der folgende Code‑Abschnitt erfüllt diesen Zweck:
```java
// Setze die Fensterbreite der Arbeitsmappe in Zoll (geteilt durch 576, da PowerPoint 576 Pixel pro Zoll verwendet).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Setze die Fensterhöhe der Arbeitsmappe in Zoll.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Speichere die Arbeitsmappe in einen Speicherstrom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Erstelle einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**Scenario 2**

Angenommen, wir möchten eine Präsentation von Grund auf neu erstellen und einen OLE‑Objektrahmen beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einfügen. Im folgenden Code‑Abschnitt erzeugen wir einen OLE‑Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Anschließend setzen wir das Excel‑Arbeitsmappen‑Fenster auf dieselbe Größe – 4 Zoll hoch und 9,5 Zoll breit.
```java
// Gewünschte Höhe.
int desiredHeight = 288; // 4 Zoll (4 * 72)
 
// Gewünschte Breite.
int desiredWidth = 684; // 9,5 Zoll (9,5 * 72)
 
// Definiere die Diagrammgröße mit einem Fenster.
chart.setSizeWithWindow(true);
 
// Setze die Fensterbreite der Arbeitsmappe in Zoll (geteilt durch 576, da PowerPoint 576 Pixel pro Zoll verwendet).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Setze die Fensterhöhe der Arbeitsmappe in Zoll.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Speichere die Arbeitsmappe in einen Speicherstrom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Erstelle einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **Zweiter Ansatz**

In diesem Ansatz lernen wir, wie die Größe des Diagramms in der eingebetteten Excel‑Arbeitsmappe so eingestellt wird, dass sie der Größe des OLE‑Objektrahmens in der PowerPoint‑Folge entspricht. Dieser Ansatz ist nützlich, wenn die Diagrammgröße im Voraus bekannt ist und sich niemals ändert.

**Scenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten darauf basierend Präsentationen erstellen. Nehmen wir an, in der Vorlage befindet sich an Index 2 eine Form, in der wir einen OLE‑Rahmen mit einer eingebetteten Excel‑Arbeitsmappe platzieren möchten. In diesem Szenario ist die Größe des OLE‑Rahmens vordefiniert – sie entspricht der Größe der Form an Index 2 in der Vorlage. Alles, was wir tun müssen, ist die Diagrammgröße in der Arbeitsmappe auf die Größe dieser Form zu setzen. Der folgende Code‑Abschnitt erfüllt diesen Zweck:
```java
// Definiere die Diagrammgröße ohne Fenster.
chart.setSizeWithWindow(false);
 
// Setze die Diagrammbreite in Pixeln (mit 96 multiplizieren, da Excel 96 Pixel pro Zoll verwendet).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Setze die Diagrammhöhe in Pixeln.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definiere die Druckgröße des Diagramms.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Speichere die Arbeitsmappe in einen Speicherstrom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Erstelle einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**Scenario 2**

Angenommen, wir möchten eine Präsentation von Grund auf neu erstellen und einen OLE‑Objektrahmen beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einfügen. Im folgenden Code‑Abschnitt erzeugen wir einen OLE‑Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Wir setzen zudem die entsprechende Diagrammgröße auf dieselben Abmessungen: eine Höhe von 4 Zoll und eine Breite von 9,5 Zoll.
```java
// Unsere gewünschte Höhe.
int desiredHeight = 288; // 4 Zoll (4 * 72)
 
// Unsere gewünschte Breite.
int desiredWidth = 684; // 9,5 Zoll (9,5 * 72)
 
// Definiere die Diagrammgröße ohne Fenster.
chart.setSizeWithWindow(false);
 
// Setze die Diagrammbreite in Pixeln (mit 96 multiplizieren, da Excel 96 Pixel pro Zoll verwendet).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Setze die Diagrammhöhe in Pixeln.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Speichere die Arbeitsmappe in einen Speicherstrom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Erstelle einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **Fazit**

Es gibt zwei Ansätze, um das Problem mit der Diagramm‑Skalierung zu beheben. Die Wahl des Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren identisch, egal ob die Präsentationen aus einer Vorlage oder von Grund auf neu erstellt werden. Außerdem gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objektrahmens.

## **FAQ**

**Warum ändert mein eingebettetes Excel‑Diagramm nach der Aktivierung in PowerPoint seine Größe?**

Das geschieht, weil Excel bei der ersten Aktivierung versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Skalierung führen kann.

**Ist es möglich, dieses Skalierungsproblem vollständig zu verhindern?**

Ja. Indem Sie die Fenstergröße der Excel‑Arbeitsmappe oder die Diagrammgröße vor dem Einbetten an die Größe des OLE‑Objektrahmens anpassen, können Sie die Diagrammgrößen konsistent halten.

**Welchen Ansatz sollte ich wählen, die Fenstergröße der Arbeitsmappe setzen oder die Diagrammgröße festlegen?**

Verwenden Sie **Ansatz 1 (Fenstergröße)**, wenn Sie das Seitenverhältnis der Arbeitsmappe beibehalten und später ggf. eine Größenänderung zulassen möchten.  
Verwenden Sie **Ansatz 2 (Diagrammgröße)**, wenn die Diagrammabmessungen festgelegt sind und sich nach dem Einbetten nicht ändern.

**Funktionieren diese Methoden sowohl bei vorlagenbasierten Präsentationen als auch bei neuen Präsentationen?**

Ja. Beide Ansätze funktionieren gleichermaßen für Präsentationen, die aus Vorlagen oder von Grund auf neu erstellt wurden.

**Gibt es eine Begrenzung für die Größe des OLE‑Objektrahmens?**

Nein. Der OLE‑Rahmen kann auf jede Größe gesetzt werden, solange er passend zur Arbeitsmappe oder zum Diagramm skaliert.

**Kann ich diese Methoden mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**

Die Beispiele sind für Excel‑Diagramme, die mit Aspose.Cells erstellt wurden, aber die Grundprinzipien gelten auch für andere OLE‑kompatible Tabellenkalkulationsprogramme, sofern diese ähnliche Größenoptionen unterstützen.

## **Verwandte Abschnitte**

- [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE‑Objekte automatisch mit einem PowerPoint‑Add‑In aktualisieren](/slides/de/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)